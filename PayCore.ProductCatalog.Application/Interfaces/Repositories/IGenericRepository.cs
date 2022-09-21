using PayCore.ProductCatalog.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PayCore.ProductCatalog.Service.Interfaces.Repositories
{
    public interface IGenericRepository<Entity> where Entity : BaseEntity
    {
        Task Create(Entity entity);
        Task Update(Entity entity);
        Task Delete(Entity entity);
        #nullable enable
        Task<IEnumerable<Entity>> GetAll(Expression<Func<Entity, bool>> expression);
        Task<IEnumerable<Entity>> GetAll();
        Task<Entity> GetById(int id);

    }
}
