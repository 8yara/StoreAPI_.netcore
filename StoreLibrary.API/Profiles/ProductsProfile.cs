using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace StoreLibrary.API.Profiles
{
    public class ProductsProfile:Profile
    {
        public ProductsProfile()
        {
            CreateMap<Entities.Product, Models.ProductDTO>();
            CreateMap<Models.ProductInputDTO, Entities.Product>();
            CreateMap<Models.ProductToUpdateDTO, Entities.Product>();
            CreateMap<Entities.Product, Models.ProductToUpdateDTO>();
        }
    }
}
