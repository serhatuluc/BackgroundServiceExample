using Microsoft.AspNetCore.Mvc;
using PayCore.ProductCatalog.Service.Dto_Validator.Account.Dto;
using PayCore.ProductCatalog.Service.Interfaces.Services;
using System.Threading.Tasks;
using PayCore.ProductCatalog.Service.Interfaces;
using PayCore.ProductCatalog.Data.Token;

namespace PayCore.ProductCatalog.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAccountService accountService;
        private readonly ITokenService tokenService;

        public AuthController(IAccountService accountService, ITokenService tokenService)
        {
            this.accountService = accountService;
            this.tokenService = tokenService;
        }

        [HttpPost("Login")]
        public async Task<TokenResponse> Login([FromBody] TokenRequest request)
        {
            var response = await tokenService.GenerateToken(request);
            return response;
        }

        [HttpPost("register")]
        public virtual async Task<IActionResult> Create([FromBody] AccountUpsertDto dto)
        {
            await accountService.Insert(dto);
            return Ok();
        }

        
    }
}
