using PayCore.ProductCatalog.Service.Dto_Validator.Product.Dto;


namespace PayCore.ProductCatalog.Service.Dto_Validator
{
    public class OfferViewDto
    {
        public virtual int Id { get; set; }
        public int OfferedPrice { get; set; }
        public bool IsApproved { get; set; }
        public bool Status { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public ProductViewDto Product { get; set; }
    }
}
