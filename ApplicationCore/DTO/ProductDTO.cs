using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApplicationCore.DTO
{
    public class ProductDTO : Product
    {
        public string PackageName { get; set; }
        [StringLength(10)]
        public override string Name { get; set; }
    }
}
