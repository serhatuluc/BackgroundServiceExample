
using System.Collections.Generic;

namespace PayCore.ProductCatalog.Data.Entities
{
    public class Color:BaseEntity
    {
        public virtual string ColorName { get; set; }
        public virtual IList<Product> Products { get; set; }

    }
}
