

namespace PayCore.ProductCatalog.Service.Dto_Validator.Product.Dto
{
    public class ProductUpsertDto
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; } 
        public int Price { get; set; }
        public bool IsOfferable { get; set; }

    }
}
