using Ciber.Models.Paging;
using System.Collections.Generic;

namespace Ciber.Models.Repository
{
    public interface IDataRepository<TEntity>
    {
        IEnumerable<PagedResult<TEntity>> GetAll(PagingImplementation pagingImplementation, int Year, int Month);
        TEntity Get(long id);
        void Add(TEntity entity);
        void Update(TEntity entityToUpdate, TEntity entity);
        void Delete(TEntity entity);
    }
}
