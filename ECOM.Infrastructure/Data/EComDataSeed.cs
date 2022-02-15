using ECOM.Core.Entities;
using Microsoft.Extensions.Logging;
using System.Reflection;
using System.Text.Json;

namespace ECOM.Infrastructure.Data
{
    public class EComDataSeed
    {
        public static async Task SeedAsync(EComDbContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                //var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                if (!context.ProductBrands.Any())
                {
                    var brandsData = File.ReadAllText(@"../ECOM.Infrastructure/Data/DataSeed/brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                    
                    foreach (var item in brands)
                    {
                        item.Id = 0;
                        context.ProductBrands.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.ProductTypes.Any())
                {
                    var typesData = File.ReadAllText(@"../ECOM.Infrastructure/Data/DataSeed/types.json");
                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);

                    foreach (var item in types)
                    {
                        item.Id = 0;
                        context.ProductTypes.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.Products.Any())
                {
                    var productsData = File.ReadAllText(@"../ECOM.Infrastructure/Data/DataSeed/products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                    foreach (var item in products)
                    {
                        item.Id = 0;
                        context.Products.Add(item);
                    }

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<EComDataSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}
