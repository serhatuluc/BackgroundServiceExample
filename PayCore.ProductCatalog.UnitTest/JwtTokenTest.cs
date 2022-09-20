using AutoMapper;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using PayCore.ProductCatalog.Application;
using PayCore.ProductCatalog.Application.Interfaces;
using PayCore.ProductCatalog.Application.Interfaces.Repositories;
using PayCore.ProductCatalog.Application.Interfaces.UnitOfWork;
using PayCore.ProductCatalog.Application.Mapping;
using PayCore.ProductCatalog.Domain.Jwt;
using PayCore.ProductCatalog.Domain.Token;
using System.Threading.Tasks;

namespace PayCore.ProductCatalog.UnitTest
{
    public class JwtTokenTest
    {
        private readonly Mock<IAccountRepository> _accountRepository;
        private readonly Mock<IUnitOfWork> _unitOfWork;
        private readonly Mock<IOptionsMonitor<JwtConfig>> _jwtConfig;
        private readonly TokenRequest _tokenRequest;
        private readonly TokenResponse _tokenResponse;

        public JwtTokenTest()
        {
            _tokenRequest = new TokenRequest();
            _tokenResponse = new TokenResponse();
            _unitOfWork = new Mock<IUnitOfWork>();
            _accountRepository = new Mock<IAccountRepository>();
            _jwtConfig = new Mock<IOptionsMonitor<JwtConfig>>();
        }

        [Test]
        public void JwtTokenRequestTest()
        {
            _unitOfWork.Setup(u => u.Account).Returns(_accountRepository.Object);
            var tokenService = new TokenService(_jwtConfig.Object, _unitOfWork.Object);

            var tokenResponse = tokenService.GenerateToken(_tokenRequest);

            Assert.NotNull(tokenResponse);
        }
    }
}
