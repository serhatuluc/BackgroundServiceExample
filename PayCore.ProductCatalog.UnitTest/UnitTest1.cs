using AutoMapper;
using Moq;
using NUnit.Framework;
using PayCore.ProductCatalog.Application.Interfaces.Repositories;
using PayCore.ProductCatalog.Application.Interfaces.UnitOfWork;
using PayCore.ProductCatalog.Application.Mapping;
using PayCore.ProductCatalog.Application.Services;
using PayCore.ProductCatalog.Domain.Entities;
using System.Threading.Tasks;

namespace PayCore.ProductCatalog.UnitTest
{
    public class Tests
    {
        private readonly Mock<ICategoryRepository> _categoryRepository;
        private readonly Mock<IUnitOfWork> _unitOfWork;
        private readonly IMapper _mapper;

        public Tests()
        {
            var categoryRepositoryMock = new Mock<ICategoryRepository>();
            _unitOfWork = new Mock<IUnitOfWork>();
            _categoryRepository = new Mock<ICategoryRepository>();
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile())));

        }

        [Test]
        public async Task GetCategoryByIdTest()
        {
            _unitOfWork.Setup(u => u.Category).Returns(_categoryRepository.Object);
            _unitOfWork.Setup(repo => repo.Category.GetById(1)).ReturnsAsync(new Category { Id = 1, CategoryName = "car"});
            var categoryService = new CategoryService(_mapper,_unitOfWork.Object);


            var category = await categoryService.GetById(1);

            Assert.NotNull(category);
        }
    }
}