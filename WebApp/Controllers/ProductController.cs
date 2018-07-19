using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    [ApiController]
    public class ProductController : BaseApiController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService) => _productService = productService;

        /// <summary>
        /// api/Product/GetProductsByPackageID?PackageID=1
        /// </summary>
        /// <param name="packageID"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IEnumerable<Product>> GetProductsByPackageID(long packageID)
        {
            return await _productService.GetProductsByPackageIDAsync(packageID);
        }

        /// <summary>
        /// api/Product/AddProduct
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<Product> AddProduct([FromBody] Product product)
        {
            return await _productService.AddProductAsync(product);
        }

        /// <summary>
        /// api/Product/GetProductsAndUpdatePackageNameByPackageID?packageID=1&packageName=hehe
        /// </summary>
        /// <param name="packageID"></param>
        /// <param name="packageName"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IEnumerable<Product>> GetProductsAndUpdatePackageNameByPackageID(long packageID, string packageName)
        {
            await _productService.UpdatePackageNameAsync(packageID, packageName);
            return await _productService.GetProductsByPackageIDAsync(packageID);
        }

        /// <summary>
        /// api/Product/GetPackage?packageID=1
        /// </summary>
        /// <param name="packageID"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<Package> GetPackage(long packageID)
        {
            return await _productService.GetPackageAsync(packageID);
        }
    }
}