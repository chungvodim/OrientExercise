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
        public IEnumerable<Product> GetProductsByPackageID(long packageID)
        {
            return _productService.GetProductsByPackageID(packageID);
        }

        /// <summary>
        /// api/Product/AddProduct
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        public Product AddProduct([FromBody] Product product)
        {
            return _productService.AddProduct(product);
        }

        /// <summary>
        /// api/Product/GetProductsAndUpdatePackageNameByPackageID?packageID=1&packageName=hehe
        /// </summary>
        /// <param name="packageID"></param>
        /// <param name="packageName"></param>
        /// <returns></returns>
        [HttpPut]
        public IEnumerable<Product> GetProductsAndUpdatePackageNameByPackageID(long packageID, string packageName)
        {
            _productService.UpdatePackageName(packageID, packageName);
            return _productService.GetProductsByPackageID(packageID);
        }

        /// <summary>
        /// api/Product/GetPackage?packageID=1
        /// </summary>
        /// <param name="packageID"></param>
        /// <returns></returns>
        [HttpPost]
        public Package GetPackage(long packageID)
        {
            return _productService.GetPackage(packageID);
        }
    }
}