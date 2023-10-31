using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TalabatG02.Core.Entities;

namespace TalabatG02.Repository.Data
{
    public static class StoreContextSeed
    {
        public static  async Task SeedAsync(StoreContext dbcontext)
        {
            if (!dbcontext.productBrands.Any())
            {

            var brandData = File.ReadAllText("../TalabatG02.Repository/Data/DataSeed/brands.json");
            var brands =JsonSerializer.Deserialize<List<ProductBrand>>(brandData);
            if (brands?.Count>0)
            {
                foreach (var brand in brands)
                    await dbcontext.productBrands.AddAsync(brand);
                await dbcontext.SaveChangesAsync();
            }

            }
            if (!dbcontext.productTypes.Any())
            {

                var typesdData = File.ReadAllText("../TalabatG02.Repository/Data/DataSeed/types.json");
                var types = JsonSerializer.Deserialize<List<ProductType>>(typesdData);
                if (types?.Count > 0)
                {
                    foreach (var type in types)
                        await dbcontext.productTypes.AddAsync(type);
                    await dbcontext.SaveChangesAsync();
                }

            }
            if (!dbcontext.products.Any())
            {

                var productData  = File.ReadAllText("../TalabatG02.Repository/Data/DataSeed/products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productData);
                if (products?.Count > 0)
                {
                    foreach (var product in products)
                        await dbcontext.products.AddAsync(product);
                    await dbcontext.SaveChangesAsync();
                }

            }


        }
    }
}
