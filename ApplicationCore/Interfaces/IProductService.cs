using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetProductsByPackageID(long packageID);
        Product AddProduct(Product product);
        void UpdatePackageName(long packageID, string packageName);
        Package GetPackage(long packageID);
    }
}
