using AutoMapper;
using Moq;
using NUnit.Framework;
using PayCore.ProductCatalog.Service;
using PayCore.ProductCatalog.Service.Interfaces.Repositories;
using PayCore.ProductCatalog.Service.Interfaces.UnitOfWork;
using PayCore.ProductCatalog.Service.Mapping;
using PayCore.ProductCatalog.Service.Services;
using PayCore.ProductCatalog.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using PayCore.ProductCatalog.Service.Dto_Validator;

namespace PayCore.ProductCatalog.UnitTest
{
    public class CategoryServiceTests
    {
        private readonly Mock<ICategoryRepository> _categoryRepository;
        private readonly Mock<IUnitOfWork> _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryServiceTests()
        {
            var categoryRepositoryMock = new Mock<ICategoryRepository>();
            _unitOfWork = new Mock<IUnitOfWork>();
            _categoryRepository = new Mock<ICategoryRepository>();
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile())));

        }

        [Test]
        public async Task GetCategory_WithExistingItem_ReturnsExpectedItem()
        {
            _unitOfWork.Setup(u => u.Category).Returns(_categoryRepository.Object);
            _unitOfWork.Setup(repo => repo.Category.GetById(1)).ReturnsAsync(new Category { Id = 1, CategoryName = "Test"});
            var categoryService = new CategoryService(_mapper,_unitOfWork.Object);


            var category = await categoryService.GetById(1);

            Assert.NotNull(category);
        }

        [Test]
        public async Task GetAllCategory_ReturnsListOfCategory()
        {
            _unitOfWork.Setup(u => u.Category).Returns(_categoryRepository.Object);
            _unitOfWork.Setup(repo => repo.Category.GetAll()).ReturnsAsync(new List<Category>() { new Category { Id = 1, CategoryName = "car" }, new Category { Id = 2, CategoryName = "Book" } });
            var categoryService = new CategoryService(_mapper, _unitOfWork.Object);


            var category = await categoryService.GetAll();

            Assert.NotNull(category);

        }

        [Test]
        public void Delete_WithNonExistingItem_ReturnNotFoundException()
        {
            //Arrange
            _unitOfWork.Setup(u => u.Category).Returns(_categoryRepository.Object);
            _unitOfWork.Setup(repo => repo.Category.GetById(It.IsAny<int>())).ReturnsAsync((Category)null);
            var categoryService = new CategoryService(_mapper, _unitOfWork.Object);

            //Act //Assert
            Assert.Throws<NotFoundException>(()=>categoryService.Remove(It.IsAny<int>()).GetAwaiter().GetResult());
        }

       
        [Test]
        public void Update_NonExistingItem_ReturnNotFound()
        {
            //Arrange
            _unitOfWork.Setup(u => u.Category).Returns(_categoryRepository.Object);
            var dto = new CategoryUpsertDto();
            _unitOfWork.Setup(repo => repo.Category.GetById(It.IsAny<int>())).ReturnsAsync((Category)null);
            var categoryService = new CategoryService(_mapper, _unitOfWork.Object);

            Assert.Throws<NotFoundException>(() => categoryService.Update(It.IsAny<int>(),dto).GetAwaiter().GetResult());
        }

       
    }
}