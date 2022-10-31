using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StoreLibrary.API.Models;
using StoreLibrary.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreApiResponse;
using System.Net;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Cors;

namespace StoreLibrary.API.Controllers
{
    [ApiController]
    [Route("api/products")]

    public class ProductsController : BaseController
    {
        private IStoreLibraryRepository _storeLibraryRepository;
        public IMapper _mapper { get; }

        public ProductsController(IStoreLibraryRepository storeLibraryRepository, IMapper mapper)
        {
            _storeLibraryRepository = storeLibraryRepository ??
               throw new ArgumentNullException(nameof(storeLibraryRepository));
            _mapper = mapper ??
             throw new ArgumentNullException(nameof(mapper));

        }
        //1- GET: /products /{id}
        [HttpGet("{id:guid}")]
        public IActionResult GetProduct(Guid id)
        {
           
            var product = _storeLibraryRepository.GetProduct(id);
            if (product == null)
            {
                
                return CustomResult("Product Not Found", HttpStatusCode.NotFound);
            }
            return CustomResult("Product Found",_mapper.Map<ProductDTO>(product));
        }

        //2- get products by category id and get all products if no cat id is written
        //GET: /products?categoryID={id}
        //GET: /products
        [HttpGet(Name ="GetProduct")]
        public IActionResult GetProducts([FromQuery] string categoryID)
        {
           
                var ProductsFromRepo = _storeLibraryRepository.GetProductsForCat(categoryID);
            return CustomResult("Products Found", _mapper.Map<IEnumerable<ProductDTO>>(ProductsFromRepo));
               // return Ok(_mapper.Map<IEnumerable<ProductDTO>>(ProductsFromRepo));
        }


        //3- POST:products
        [HttpPost]
        public ActionResult<ProductDTO> CreateProduct(ProductInputDTO product)
        {
            var productEntity = _mapper.Map<Entities.Product>(product);
            _storeLibraryRepository.AddProduct(productEntity);
            _storeLibraryRepository.Save();

            var productToReturn = _mapper.Map<ProductDTO>(productEntity);
            return CreatedAtRoute("GetProduct",
                new { productId = productToReturn.Id },
                productToReturn);

                
        }

        //4- PUT: /products/{id}
        [HttpPut("{productId}")]
        public IActionResult UpdateProduct(Guid productId,ProductToUpdateDTO product)
        {
            
            var productFromRepo = _storeLibraryRepository.GetProduct(productId);
            if (productFromRepo == null)
            {
                return CustomResult("Product Not found",HttpStatusCode.NotFound);
            }
            _mapper.Map(product, productFromRepo);
            _storeLibraryRepository.UpdateProduct(productFromRepo);
            _storeLibraryRepository.Save();
            return CustomResult("Product updated", productFromRepo);
        }
        //5-  PATCH: /products/{id}
        [HttpPatch("{productId}")]
        public IActionResult PartiallyUpdateProduct(Guid productId,
            JsonPatchDocument<ProductToUpdateDTO> patchDocument)
        {
            var productFromRepo = _storeLibraryRepository.GetProduct(productId);
            if (productFromRepo == null)
            {
                return CustomResult("Product Not found",HttpStatusCode.NotFound);
            }
            var productToPatch = _mapper.Map<ProductToUpdateDTO>(productFromRepo);
            patchDocument.ApplyTo(productToPatch);

            _mapper.Map(productToPatch, productFromRepo);
            _storeLibraryRepository.UpdateProduct(productFromRepo);
            _storeLibraryRepository.Save();
            return CustomResult("Product Updated" , productFromRepo);


        }
        
       




    }
}
