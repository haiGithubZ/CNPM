using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;

namespace Jhipster.Domain.Repositories.Interfaces
{
    public interface IFluentRepository<TEntity> : INoSqlFluentRepository<TEntity> where TEntity : class
    {
        IFluentRepository<TEntity> Include(Expression<Func<TEntity, object>> expression);
        IFluentRepository<TEntity> Include(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include);
        IFluentRepository<TEntity> AsNoTracking();
    }
}
