using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StoreLibrary.API.Entities;


namespace StoreLibrary.API.DbContexts
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options)
   : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // seed the database with dummy data
            modelBuilder.Entity<Category>().HasData(
           new Category()
           {
               Id = Guid.Parse("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"),
               Name = "Shirts"
           },
             new Category()
             {
                 Id = Guid.Parse("5b1c2b4d-48c7-402a-80c3-cc796ad49c6c"),
                 Name = "Pantss"
             }

           );
            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    Id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    CatID = Guid.Parse("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"),
                    Name = "polo shirt",
                    Price = 300,
                    ImgURL = "",

                }

                );

        

            base.OnModelCreating(modelBuilder);
        }
    }
}
