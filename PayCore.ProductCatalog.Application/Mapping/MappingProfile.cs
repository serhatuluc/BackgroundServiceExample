using AutoMapper;
using PayCore.ProductCatalog.Service.Dto_Validator;
using PayCore.ProductCatalog.Service.Dto_Validator.Account.Dto;
using PayCore.ProductCatalog.Service.Dto_Validator.Product.Dto;
using PayCore.ProductCatalog.Data.Entities;

namespace PayCore.ProductCatalog.Service.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Brand
            CreateMap<Brand, BrandViewDto>().ReverseMap();
            CreateMap<Brand, BrandUpsertDto>().ReverseMap();

            //Category
            CreateMap<Category, CategoryViewDto>().ReverseMap();
            CreateMap<Category, CategoryUpsertDto>().ReverseMap();

            //Color
            CreateMap<Color, ColorViewDto>().ReverseMap();
            CreateMap<Color, ColorUpsertDto>().ReverseMap();

            //Product
            CreateMap<Product, ProductViewDto>().ReverseMap();
            CreateMap<Product, ProductUpsertDto>().ReverseMap();

            //Offer
            CreateMap<Offer, OfferViewDto>().ReverseMap();
            CreateMap<Offer, OfferUpsertDto>().ReverseMap();

            //Account
            CreateMap<Account, AccountViewDto>().ReverseMap();
            CreateMap<Account, AccountUpsertDto>().ReverseMap();
        }
    }
}
