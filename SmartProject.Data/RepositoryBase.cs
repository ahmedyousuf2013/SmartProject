using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartProject.Data
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected ApplicationDbContext ApplicationDbContext { get; set; }

        public RepositoryBase(ApplicationDbContext applicationDbContext)
        {
            this.ApplicationDbContext = applicationDbContext;
        }

        public IQueryable<T> FindAll()
        {
            return this.ApplicationDbContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.ApplicationDbContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Create(T entity)
        {
            this.ApplicationDbContext.Set<T>().Add(entity);
            this.ApplicationDbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            this.ApplicationDbContext.Set<T>().Update(entity);
            this.ApplicationDbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            this.ApplicationDbContext.Set<T>().Remove(entity);
            this.ApplicationDbContext.SaveChanges();
        }

        public async Task<T> SaveAsync(T entity) 
        {
            this.ApplicationDbContext.Set<T>().Add(entity);
         
            await this.ApplicationDbContext.SaveChangesAsync();

            return entity;
        }
    }
}
