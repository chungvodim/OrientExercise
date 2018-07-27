using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ApplicationCore.DTO;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ProductController : BaseApiController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService) => _productService = productService;

        /// <summary>
        /// api/Product/GetProductsByPackageID?PackageID=1
        /// </summary>
        /// <param name="packageID"></param>
        /// <returns></returns>
        [HttpGet]
        [ActionName("GetProductsByPackageID")]
        public async Task<IEnumerable<ProductDTO>> GetProductsByPackageID(long packageID)
        {
            return await _productService.GetProductsByPackageIDAsync(packageID);
        }

        /// <summary>
        /// api/Product/AddProduct
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> AddProduct([FromBody] ProductDTO product)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(new ApiResponse(HttpStatusCode.BadRequest, ApiResponseType.Error, "Invalid Input"));
            //}
            await _productService.AddProductAsync(product);
            return Ok(new ApiResponse(HttpStatusCode.OK, ApiResponseType.Success, "Add product successfully"));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(long productID)
        {
            await _productService.DeleteProductAsync(productID);
            return Ok(new ApiResponse(HttpStatusCode.OK, ApiResponseType.Success, "Delete product successfully"));
        }

        /// <summary>
        /// api/Product/GetProductsAndUpdatePackageNameByPackageID?packageID=1&packageName=hehe
        /// </summary>
        /// <param name="packageID"></param>
        /// <param name="packageName"></param>
        /// <returns></returns>
        [HttpPost]
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
        [HttpGet]
        public async Task<Package> GetPackage(long packageID)
        {
            return await _productService.GetPackageAsync(packageID);
        }
    }
}