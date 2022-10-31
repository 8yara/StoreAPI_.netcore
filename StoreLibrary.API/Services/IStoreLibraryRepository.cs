using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreLibrary.API.Entities;

namespace StoreLibrary.API.Services
{
    public interface IStoreLibraryRepository
    {
        IEnumerable<Product> GetProductsForCat(Guid catId);
        IEnumerable<Product> GetProductsForCat(string categoryID);
        public Product GetProduct(Guid catId, Guid productId);
        IEnumerable<Product> GetProducts();//get all products

        Product GetProduct(Guid prodId);
        void AddProduct(Guid catId, Product product);
        public void AddProduct(Product product);

        public bool ProductExists(Guid productId);

        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
        IEnumerable<Category> GetCategories();
        bool CategoryExists(Guid catId);
        bool Save();



    }
}
