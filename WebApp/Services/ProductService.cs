using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApp.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Package> _packageRepository;
        private readonly IAppLogger<ProductService> _logger;
        public ProductService(
            IRepository<Product> productRepository, 
            IRepository<Package> packageRepository,
            IAppLogger<ProductService> logger
            )
        {
            this._logger = logger;
            this._productRepository = productRepository;
            this._packageRepository = packageRepository;
        }

        public Product AddProduct(Product product)
        {
            return _productRepository.Add(product);
        }

        public Package GetPackage(long packageID)
        {
            return _packageRepository.GetById(packageID);
        }

        public IEnumerable<Product> GetProductsByPackageID(long packageID)
        {
            return _productRepository.List(x => x.PackageID == packageID, null);
        }

        public void UpdatePackageName(long packageID, string packageName)
        {
            var package = _packageRepository.GetById(packageID);
            package.Name = packageName;
            _packageRepository.Update(package);
        }
    }
}
