using PayCore.ProductCatalog.Service.Dto_Validator;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayCore.ProductCatalog.Service.Interfaces.Services
{
    public interface IColorService
    {
        Task<IEnumerable<ColorViewDto>> GetAll();
        Task<ColorViewDto> GetById(int id);
        Task Insert(ColorUpsertDto dto);
        Task Remove(int id);
        Task Update(int id, ColorUpsertDto dto);
    }
}
