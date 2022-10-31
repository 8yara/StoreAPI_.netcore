using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreLibrary.API.Models
{
    public class ProductDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string ImgURL { get; set; }
        public Guid CatID { get; set; }
    }
}
