using ApplicationCore.Entities;
using ApplicationCore.Enums;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class MyDbContextSeed
    {
        public static async Task SeedAsync(MyDbContext myDbContext, ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;
            try
            {
                // TODO: Only run this if using a real database
                // context.Database.Migrate();

                if (!myDbContext.Packages.Any())
                {
                    myDbContext.Packages.AddRange(GetPreconfiguredPackages());

                    await myDbContext.SaveChangesAsync();
                }

                if (!myDbContext.Products.Any())
                {
                    myDbContext.Products.AddRange(GetPreconfiguredProducts());

                    await myDbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if (retryForAvailability < 10)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<MyDbContextSeed>();
                    log.LogError(ex.Message);
                    await SeedAsync(myDbContext, loggerFactory, retryForAvailability);
                }
            }
        }

        static IEnumerable<Package> GetPreconfiguredPackages()
        {
            return new List<Package>()
            {
                new Package() { Name = "Azure"},
                new Package() { Name = "AWS" },
            };
        }

        static IEnumerable<Product> GetPreconfiguredProducts()
        {
            return new List<Product>()
            {
                new Product() { Name = "Soccer Shoes", ProductType = ProductType.SPORT, PackageID = 1},
                new Product() { Name = "Soccer Balls", ProductType = ProductType.SPORT, PackageID = 1},
                new Product() { Name = "Knife", ProductType = ProductType.TOOL, PackageID = 2},
                new Product() { Name = "Jewelry", ProductType = ProductType.HAND_MADE, PackageID = 2 }
            };
        }

    }
}
