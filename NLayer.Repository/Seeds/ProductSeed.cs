using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Models;

namespace NLayer.Repository.Seeds
{
    internal class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(new Product
            {
                Id = 1,
                CategoryId = 1,
                Name = "kalem 1",
                Price = 100,
                Stock = 20,
                CreatedDate = DateTime.Now,

            },
            new Product
            {
                Id = 2,
                CategoryId = 2,
                Name = "kalem 2",
                Price = 200,
                Stock = 30,
                CreatedDate = DateTime.Now,

            },
            new Product
            {
                Id = 3,
                CategoryId = 2,
                Name = "kitap 1",
                Price = 3300,
                Stock = 40,
                CreatedDate = DateTime.Now,

            },
            new Product
            {
                Id = 4,
                CategoryId = 2,
                Name = "kitap 2",
                Price = 6600,
                Stock = 30,
                CreatedDate = DateTime.Now,

            }
            );
        }
    }
}
