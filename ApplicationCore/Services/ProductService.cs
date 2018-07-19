using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<IEnumerable<Product>> GetProductsByPackageIDAsync(long packageID)
        {
            return await _productRepository.ListAsync(x => x.PackageID == packageID, null);
        }

        public async Task UpdatePackageNameAsync(long packageID, string packageName)
        {
            var package = await _packageRepository.GetByIdAsync(packageID);
            package.Name = packageName;
            await _packageRepository.UpdateAsync(package);
        }
    }
}
