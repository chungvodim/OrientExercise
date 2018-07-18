using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities
{
    public class Product: BaseEntity
    {
        public string Name { get; set; }
        public string ProductType { get; set; }
        public long PackageID { get; set; }
    }
}
