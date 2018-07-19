using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities
{
    public class Product: BaseEntity
    {
        public virtual string Name { get; set; }
        public virtual string ProductType { get; set; }
        public virtual long PackageID { get; set; }
    }
}
