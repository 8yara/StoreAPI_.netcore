using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreLibrary.API.DbContexts;
using StoreLibrary.API.Entities;

namespace StoreLibrary.API.Services
{
    public class StoreLibraryRepository : IStoreLibraryRepository, IDisposable
    {
        private readonly StoreDbContext _context;

        public StoreLibraryRepository(StoreDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

        }
        //get all products
        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.ToList<Product>();
        }
        //get product by cat id
        public IEnumerable<Product> GetProductsForCat(Guid catId)
        {
            if (catId == null)
            {
                throw new ArgumentNullException(nameof(catId));
            }
            return _context.Products.Where(a => a.CatID == catId)
                .OrderBy(c => c.Name)
                .ToList();
        }
        //get one product by category id and product id
        public Product GetProduct(Guid catId, Guid productId)
        {
            if (catId == null)
            {
                throw new ArgumentNullException(nameof(catId));
            }
            if (productId == null)
            {
                throw new ArgumentNullException(nameof(productId));
            }
            return _context.Products.Where(a => a.CatID == catId
            && a.Id == productId).FirstOrDefault();
            
        }
        //get products for a specific category in the query string
        public IEnumerable<Product> GetProductsForCat(string categoryID)
        {
            if (string.IsNullOrWhiteSpace(categoryID))
            {
                return GetProducts();
            }
            categoryID = categoryID.Trim();
            return _context.Products.Where(a => a.CatID.ToString() == categoryID).ToList();
        }

        //get one product
        public Product GetProduct(Guid prodId)
        {
            if (prodId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(prodId));
            };
            return _context.Products.FirstOrDefault(p => p.Id == prodId);
        }
        //add one product
        public void AddProduct(Guid catId, Product product)
        {
            if (catId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(catId));
            };
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));

            };
            product.CatID = catId;
            _context.Products.Add(product);
            _context.SaveChanges();
        }
        //add product
        public void AddProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            } 
        product.Id = Guid.NewGuid();
       // product.CatID = Guid.NewGuid();
            _context.Products.Add(product);
        
        }



            //update product
            public void UpdateProduct(Product product)
        {
            //Product newprod = (Product)_context.Products.Where(p => p.Id == product.Id);
            //newprod.Name = product.Name;
            //newprod.Price = product.Price;
            //newprod.ImgURL = product.ImgURL;
            //newprod.CatID = product.CatID;
            //_context.SaveChanges();
        }
        //delete product
        public void DeleteProduct(Product product)
        {
            _context.Products.Remove(product);
        }

        //get all categories
       public IEnumerable<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }
       public bool CategoryExists(Guid catId)
        {
            if (catId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(catId));
            }
            return _context.Categories.Any(a => a.Id == catId);
        }
        public bool ProductExists(Guid productId)
        {
            if (productId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(productId));
            }
            return _context.Products.Any(a => a.Id == productId);
        }
        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose resources when needed
            }
        }
    }
}
