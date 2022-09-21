using AutoMapper;
using Moq;
using NUnit.Framework;
using PayCore.ProductCatalog.Application;
using PayCore.ProductCatalog.Application.Interfaces.Repositories;
using PayCore.ProductCatalog.Application.Interfaces.UnitOfWork;
using PayCore.ProductCatalog.Application.Mapping;
using PayCore.ProductCatalog.Application.Services;
using PayCore.ProductCatalog.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayCore.ProductCatalog.UnitTest.ServiceTests
{
    public class OfferServiceTests
    {
        private readonly Mock<IOfferRepository> _offerRepository;
        private readonly Mock<IUnitOfWork> _unitOfWork;
        private readonly IMapper _mapper;

        public OfferServiceTests()
        {
            var offerRepositoryMock = new Mock<IOfferRepository>();
            _unitOfWork = new Mock<IUnitOfWork>();
            _offerRepository = new Mock<IOfferRepository>();
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile())));
        }

        [Test]
        public void ApproveOffer_WithNonExistingOffer_ReturnsNotFoundException()
        {
            //Arrange
            _unitOfWork.Setup(u => u.Offer).Returns(_offerRepository.Object);
            _unitOfWork.Setup(u => u.Offer.GetOfferstoUser(It.IsAny<int>())).ReturnsAsync((List<Offer>)null);
            var offerService = new OfferService(_mapper, _unitOfWork.Object);

            //Act //Assert
            Assert.Throws<NotFoundException>(() => offerService.ApproveOffer(It.IsAny<int>(), It.IsAny<int>()).GetAwaiter().GetResult());
        }

        [Test]
        public void DisApproveOffer_WithNonExistingOffer_ReturnsNotFoundException()
        {
            //Arrange
            _unitOfWork.Setup(u => u.Offer).Returns(_offerRepository.Object);
            _unitOfWork.Setup(u => u.Offer.GetOfferstoUser(It.IsAny<int>())).ReturnsAsync((List<Offer>)null);
            var offerService = new OfferService(_mapper, _unitOfWork.Object);

            //Act //Assert
            Assert.Throws<NotFoundException>(() => offerService.DisapproveOffer(It.IsAny<int>(), It.IsAny<int>()).GetAwaiter().GetResult());
        }

        [Test]
        public async Task GetOffersOfUser_WithExistingItem_ReturnsExpectedItems()
        {
            _unitOfWork.Setup(u => u.Offer).Returns(_offerRepository.Object);
            var listOfOffer = new List<Offer>();
            listOfOffer.Add(new Offer
            {
                Id = 1,
                IsApproved = false,
                OfferedPrice = 1,
                Status = true,
                Customer = new Account { Id = 1, Name = "Test" },
                Product = new Product
                {
                    Id = 1,
                    ProductName = "Test",
                    Price = 1,
                    Description = "Test",
                    Category = new Category {Id = 1, CategoryName = "Test" },
                    Color = new Color { Id = 1, ColorName = "Test" },
                    Brand = new Brand { Id = 1, BrandName = "Test" },
                    IsSold = false,
                    IsOfferable = true,
                    Status = true,
                    Owner = new Account { Id = 1, Name = "Test" }
                }
            });
            _unitOfWork.Setup(repo => repo.Offer.GetOfferOfUser(It.IsAny<int>())).ReturnsAsync(listOfOffer);
            var offerService = new OfferService(_mapper, _unitOfWork.Object);


            var product = await offerService.GetOffersofUser(It.IsAny<int>());

            Assert.NotNull(product);
        }


        [Test]
        public async Task GetOffersToUser_WithExistingItem_ReturnsExpectedItems()
        {
            _unitOfWork.Setup(u => u.Offer).Returns(_offerRepository.Object);
            var listOfOffer = new List<Offer>();
            listOfOffer.Add(new Offer
            {
                Id = 1,
                IsApproved = false,
                OfferedPrice = 1,
                Status = true,
                Customer = new Account { Id = 1, Name = "Test" },
                Product = new Product
                {
                    Id = 1,
                    ProductName = "Test",
                    Price = 1,
                    Description = "Test",
                    Category = new Category { Id = 1, CategoryName = "Test" },
                    Color = new Color { Id = 1, ColorName = "Test" },
                    Brand = new Brand { Id = 1, BrandName = "Test" },
                    IsSold = false,
                    IsOfferable = true,
                    Status = true,
                    Owner = new Account { Id = 1, Name = "Test" }
                }
            });
            _unitOfWork.Setup(repo => repo.Offer.GetOfferstoUser(It.IsAny<int>())).ReturnsAsync(listOfOffer);
            var offerService = new OfferService(_mapper, _unitOfWork.Object);


            var product = await offerService.GetOffersToUser(It.IsAny<int>());

            Assert.NotNull(product);
        }







    }
}