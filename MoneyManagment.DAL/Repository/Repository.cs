using MoneyManagment.DAL.IRepository;
using MoneyManagment.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManagment.DAL.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Auditable
    {
        public ValueTask<bool> DeleteAsync(Expression<Func<TEntity, bool>> pridacate)
        {
            throw new NotImplementedException();
        }

        public ValueTask<TEntity> InsertAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public ValueTask SaveAsync()
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> SelectAllAsync(Expression<Func<TEntity, bool>> pridacate = null)
        {
            throw new NotImplementedException();
        }

        public ValueTask<TEntity> SelectAsync(Expression<Func<TEntity, bool>> pridacate)
        {
            throw new NotImplementedException();
        }

        public ValueTask<TEntity> UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
