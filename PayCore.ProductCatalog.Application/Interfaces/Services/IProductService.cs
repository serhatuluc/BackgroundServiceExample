using PayCore.ProductCatalog.Service.Dto_Validator.Product.Dto;
using PayCore.ProductCatalog.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PayCore.ProductCatalog.Service.Interfaces.Services
{
    public interface IProductService
    {
        //Fetches all products
        #nullable enable
        Task<IEnumerable<ProductViewDto>> GetAll(Expression<Func<Product, bool>>? expression = null);

        //Get product with id
        Task<ProductViewDto> GetById(int id);

        //Insert offerable Product 
        Task InsertProduct(int userId,ProductUpsertDto dto);

        //Remove product
        Task Remove(int productId,int userId);

        //Update product
        Task Update(int productId, int userId, ProductUpsertDto dto);

        //Buy without offering
        Task BuyProductWithoutOffer(int productId, int userId);

    }
}
