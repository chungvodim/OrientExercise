using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.DTO;
using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProductsByPackageIDAsync(long packageID);
        Task<Product> AddProductAsync(Product product);
        Task UpdatePackageNameAsync(long packageID, string packageName);
        Task<Package> GetPackageAsync(long packageID);
        Task DeleteProductAsync(long productID);
    }
}
