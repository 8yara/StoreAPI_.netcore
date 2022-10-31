using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreLibrary.API.Models
{
    public class ProductToUpdateDTO
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string ImgURL { get; set; }
    }
}
