using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreLibrary.API.Entities
{
    public class Product

    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength (20)]
        public string Name { get; set; }

        [Required]
        
        public int Price { get; set; }
        public string ImgURL { get; set; }


        [ForeignKey("CatID")]
        public Category category { get; set; }

        public Guid CatID { get; set; }
    }
}
