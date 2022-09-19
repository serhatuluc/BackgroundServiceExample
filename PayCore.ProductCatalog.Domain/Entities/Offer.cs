﻿

namespace PayCore.ProductCatalog.Domain.Entities
{
    public class Offer:BaseEntity
    {
        public virtual bool IsApproved { get; set; } = false;
        public virtual int OfferedPrice { get; set; }
        public virtual Product Product { get; set; }
        public virtual Account Account { get; set; }
    }
}
