using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using ApplicationCore.DTO;
using Microsoft.EntityFrameworkCore;

namespace ApplicationCore.Services
{
    public class ProductService : IProductService
    {
        private readonly IAsyncRepository<Product> _productRepository;
        private readonly IAsyncRepository<Package> _packageRepository;
        private readonly IAppLogger<ProductService> _logger;
        public ProductService(
            IAsyncRepository<Product> productRepository,
            IAsyncRepository<Package> packageRepository,
            IAppLogger<ProductService> logger
            )
        {
            this._logger = logger;
            this._productRepository = productRepository;
            this._packageRepository = packageRepository;
        }

        public async Task<Product> AddProductAsync(Product product)
        {
            return await _productRepository.AddAsync(product);
        }

        public async Task<Package> GetPackageAsync(long packageID)
        {
            return await _packageRepository.GetByIdAsync(packageID);
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsByPackageIDAsync(long packageID)
        {
            var packageDbSet = _packageRepository.GetDbSet();
            var productDbSet = _productRepository.GetDbSet();
            var query = from pk in packageDbSet
                        join pd in productDbSet on pk.ID equals pd.PackageID
                        where pk.ID == packageID
                        select new ProductDTO
                        {
                            ID = pd.ID,
                            Name = pd.Name,
                            ProductType = pd.ProductType,
                            PackageID = pd.PackageID,
                            PackageName = pk.Name
                        };
            //return await _productRepository.ListAsync(x => x.PackageID == packageID, null);
            return await query.ToListAsync();
        }

        public async Task UpdatePackageNameAsync(long packageID, string packageName)
        {
            var package = await _packageRepository.GetByIdAsync(packageID);
            package.Name = packageName;
            await _packageRepository.UpdateAsync(package);
        }
    }
}
