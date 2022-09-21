using PayCore.ProductCatalog.Service.Dto_Validator.Account.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayCore.ProductCatalog.Service.Interfaces.Services
{
    public interface IAccountService
    {
        Task<IEnumerable<AccountViewDto>> GetAll();
        Task<AccountViewDto> GetById(int id);
        Task Insert(AccountUpsertDto dto);
        Task Remove(int id);
        Task Update(int id, AccountUpsertDto dto);
    }
}
