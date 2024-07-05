using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using z.Fellowship.Domain;

namespace z.Fellowship.Persistence.Repositories;

public interface IAsyncRepository <TEntity , TEntityId>  : IQuery<TEntity>
    where TEntity : BaseEntity<TEntityId>
{
    Task<TEntity?> GetAsync(
            Expression<Func<TEntity, bool>> predicate,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, 
            bool withDeleted = false,
            bool enableTracking = true,
            CancellationToken cancellationToken = default);

    Task<bool> AnyAsync(
          Expression<Func<TEntity, bool>>? predicate = null,
          bool withDeleted = false,
          bool enableTracking = true,
          CancellationToken cancellationToken = default);


    Task<TEntity> AddAsync(TEntity entity);

    Task<TEntity> UpdateAsync(TEntity entity);

    Task<TEntity> DeleteAsync(TEntity entity, bool permanent = false);

    Task<TEntity> KillAsync(TEntity entity);

}
