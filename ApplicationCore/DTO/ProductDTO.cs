using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.DTO
{
    public class ProductDTO : Product
    {
        public string PackageName { get; set; }
    }
}
