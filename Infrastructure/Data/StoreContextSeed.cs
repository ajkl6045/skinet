﻿using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Text.Json;
using Core.Entities;

namespace Infrastructure.Data
{
  public  class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context,ILoggerFactory loggerFactory )
        {
            try
            {
                if(!context.ProductBrands.Any())
                {
                    var brandsData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                    foreach(var item in brands)
                    {
                        ProductBrand model = new ProductBrand
                        {
                            Name=item.Name
                        };
                        context.ProductBrands.Add(model);
                    }
                    await context.SaveChangesAsync();
                }
                if (!context.ProductTypes.Any())
                {
                    var typesData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
                    foreach (var item in types)
                    {
                        ProductType model = new ProductType
                        {
                            Name = item.Name
                        };
                        context.ProductTypes.Add(model);
                    }
                    await context.SaveChangesAsync();
                }
                if (!context.Products.Any())
                {
                    var productsData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                    foreach (var item in products)
                    {
                        //Product model = new Product
                        //{
                        //    Name = item.Name,
                        //    Description=item.Description,
                        //    Price=item.Price,
                        //    PictureUrl=item.PictureUrl,
                        //    ProductBrandId=item.ProductBrandId,
                        //    ProductTypeId=item.ProductTypeId
                        //};
                        context.Products.Add(item);
                    }
                    await context.SaveChangesAsync();
                }
            }
            catch(Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}