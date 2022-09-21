
using System.Collections.Generic;

namespace PayCore.ProductCatalog.Data.Entities
{
    public class Category:BaseEntity
    {
        public virtual string CategoryName { get; set; }
        public virtual IList<Product> Products { get; set; }

    }
}
