using AutoMapper;
using Moq;
using NUnit.Framework;
using PayCore.ProductCatalog.Application;
using PayCore.ProductCatalog.Application.Dto_Validator.Product.Dto;
using PayCore.ProductCatalog.Application.Interfaces.Repositories;
using PayCore.ProductCatalog.Application.Interfaces.UnitOfWork;
using PayCore.ProductCatalog.Application.Mapping;
using PayCore.ProductCatalog.Application.Services;
using PayCore.ProductCatalog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCore.ProductCatalog.UnitTest
{
    public class ProductServiceTests
    {
        private readonly Mock<IProductRepository> _productRepository;
        private readonly Mock<IUnitOfWork> _unitOfWork;
        private readonly IMapper _mapper;
        static Random rnd = new Random();

        public ProductServiceTests()
        {
            var categoryRepositoryMock = new Mock<IProductRepository>();
            _unitOfWork = new Mock<IUnitOfWork>();
            _productRepository = new Mock<IProductRepository>();
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile())));
        }

        [Test]
        public async Task GetProduct_WithExistingItem_ReturnsExpectedItem()
        {
            _unitOfWork.Setup(u => u.Product).Returns(_productRepository.Object);
            _unitOfWork.Setup(repo => repo.Product.GetById(1)).ReturnsAsync(new Product { Id = rnd.Next(), ProductName = "Test",
                                                                                            Brand = new Brand {Id = rnd.Next(), BrandName = "Test" },
                                                                                            Color = new Color { Id = rnd.Next(), ColorName = "Test" },
                                                                                           Category = new Category { Id = rnd.Next(), CategoryName = "Test" },
                                                                                           Price = rnd.Next(), IsOfferable = true,IsSold = false,Description = "Test",
                                                                                           Status = true, Owner = new Account { Id = rnd.Next(), Name ="Test"} });
            var productService = new ProductService(_mapper, _unitOfWork.Object);


            var product = await productService.GetById(1);

            Assert.NotNull(product);
        }


        [Test]
        public void Insert_Product_With_Wrong_Brand_Category_ColorId_ReturnsNotFound()
        {
            //Arrange
            _unitOfWork.Setup(u => u.Product).Returns(_productRepository.Object);
            var dto = new ProductUpsertDto();
            _unitOfWork.Setup(repo => repo.Category.GetById(rnd.Next())).ReturnsAsync((Category)null);
            _unitOfWork.Setup(repo => repo.Brand.GetById(rnd.Next())).ReturnsAsync((Brand)null);
            _unitOfWork.Setup(repo => repo.Color.GetById(rnd.Next())).ReturnsAsync((Color)null);
            var categoryService = new ProductService(_mapper, _unitOfWork.Object);

            Assert.Throws<NotFoundException>(() => categoryService.InsertProduct(rnd.Next(),dto).GetAwaiter().GetResult());
        }


    }
}
