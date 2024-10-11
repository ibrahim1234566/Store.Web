using Microsoft.Extensions.Logging;
using Store.Data.Context;
using Store.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Store.Repository
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreDbContext Context,ILoggerFactory loggerFactory)
        {
            try
            {
                if (Context.productTypes != null && !Context.productTypes.Any())
                {
                    var Data = File.ReadAllText("../Store.Repository/SeedData/types.json");
                    var Types = JsonSerializer.Deserialize<List<ProductType>>(Data);
                    if (Types is not null)
                    {
                        await Context.productTypes.AddRangeAsync(Types);
                    }
                  
                }
                if (Context.productBrands!=null && !Context.productBrands.Any())
                {
                    var Data = File.ReadAllText("../Store.Repository/SeedData/brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(Data);
                    if (brands is not null)
                    {
                        await Context.productBrands.AddRangeAsync(brands);
                    }
                   
                }
                
                if (Context.Products != null && !Context.Products.Any())
                {
                    var Data = File.ReadAllText("../Store.Repository/SeedData/products.json");
                    var productss = JsonSerializer.Deserialize<List<Product>>(Data);
                    if (productss is not null)
                    {
                        await Context.Products.AddRangeAsync(productss);
                    }
                    
                }
                await Context.SaveChangesAsync();


            }
            catch (Exception ex) 
            
            {
               var logger = loggerFactory.CreateLogger<StoreDbContext>();
                logger.LogError(ex.Message);

            }

        }
    }
}
