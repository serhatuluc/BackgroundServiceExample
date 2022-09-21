
using PayCore.ProductCatalog.Data.Token;
using System.Threading.Tasks;

namespace PayCore.ProductCatalog.Service.Interfaces
{
    public interface ITokenService
    {
        Task<TokenResponse> GenerateToken(TokenRequest tokenRequest);
    }
}
