using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProductsByPackageIDAsync(long packageID);
        Task<Product> AddProductAsync(Product product);
        Task UpdatePackageNameAsync(long packageID, string packageName);
        Task<Package> GetPackageAsync(long packageID);
    }
}
