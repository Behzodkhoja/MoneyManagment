using MoneyManagment.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManagment.DAL.IRepository
{
    public interface IRepository<TEntity> where TEntity : Auditable
    {
        ValueTask<TEntity> InsertAsync(TEntity entity);
        ValueTask<TEntity> UpdateAsync(TEntity entity);
        ValueTask<bool> DeleteAsync(Expression<Func<TEntity, bool>> pridacate);
        ValueTask<TEntity> SelectAsync(Expression<Func<TEntity, bool>> pridacate);
        IQueryable<TEntity> SelectAllAsync(Expression<Func<TEntity, bool>> pridacate = null);
        ValueTask SaveAsync();
    }
}

