using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using talbat.core.Entities;
using Microsoft.EntityFrameworkCore;

namespace talbat.Repositrey.data.dataseeding
{

    public static class StoreContextSeed
    {
        //public static async Task SeedAsync(dbcontext dbContext)
        //{
        //    var BrandsData = File.ReadAllText("../Talabat.Repository/Data/DataSeed/brands.json");
        //    var Brands = JsonSerializer.Deserialize<List<ProductBrand>>(Brands Data);
        //    if (Brands?.Count > 0)
        //    {
        //        foreach (var Brand in Brands)
        //        {
        //            await dbContext.Set<ProductBrand>().AddAsync(Brand);
        //        }
        //    }
        //    await dbContext.SaveChangesAsync();
        //    // Seeding Types
        //    var TypesData = File.ReadAllText("../");
        //}

        // Seeding
        public static async Task SeedAsync(DbContext dbContext)
        {
            // Seeding Product Brands
            var productBrands = new List<ProductBrand>
        {
            new ProductBrand { Name = "zara" },
            new ProductBrand { Name = "max" },
            new ProductBrand { Name = "h&m" }
            // Add more brands as needed
        };

            foreach (var brand in productBrands)
            {
                var existingBrand = await dbContext.Set<ProductBrand>()
                    .FirstOrDefaultAsync(b => b.Name == brand.Name);

                if (existingBrand == null)
                {
                    await dbContext.Set<ProductBrand>().AddAsync(brand);
                }
            }

            // Seeding Product 
            var products = new List<Product>
        {
            new Product{
                Name = "hat",
                PictureUrl="images/hat-core1.png",
                ProductBrandId=1,
                productTypeId=1,
                Price=70,
                Description="hat"


            },
          
            // Add more types as needed
        };

            foreach (var type in products)
            {
                var existingType = await dbContext.Set<Product>()
                    .FirstOrDefaultAsync(t => t.Name == type.Name);

                if (existingType == null)
                {
                    await dbContext.Set<Product>().AddAsync(type);
                }
            }



         

            await dbContext.SaveChangesAsync();
        }
    }
}
       