﻿using Microsoft.EntityFrameworkCore;
using MoneyManagment.DAL.DbContexts;
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
        private readonly AppDbContext dbContext;
        private readonly DbSet<TEntity> dbSet;

        public Repository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = dbContext.Set<TEntity>();
        }

        public async ValueTask<bool> DeleteAsync(Expression<Func<TEntity, bool>> pridacate)
        {
            var entity = await this.dbSet.FirstOrDefaultAsync(pridacate);
            if (entity == null)
                return false;
            entity.IsDeleted = true;
            return true;
        }

        public async ValueTask<TEntity> InsertAsync(TEntity entity)
        {
            var entry = await this.dbSet.AddAsync(entity);
            return entry.Entity;

        }

        public async ValueTask SaveAsync() =>
            await this.dbContext.SaveChangesAsync();

        public IQueryable<TEntity> SelectAllAsync(Expression<Func<TEntity, bool>> pridacate = null) =>
            pridacate is null ? this.dbSet : this.dbSet.Where(pridacate);

        public async ValueTask<TEntity> SelectAsync(Expression<Func<TEntity, bool>> pridacate) =>
            await this.SelectAllAsync(pridacate).FirstOrDefaultAsync();

        public async ValueTask<TEntity> UpdateAsync(TEntity entity)
        {
            var entry = this.dbSet.Update(entity);
            return entry.Entity;
        }
    }
}
