using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace MarmyzaShop.Models
{
    public class GenericRepository <T> : IRepository<T> where T : class
    {
        private ApplicationDbContext db;
        public GenericRepository()
        {
            this.db = new ApplicationDbContext();
        }
        public virtual IQueryable<T> GetAll()
        {

            IQueryable<T> query = db.Set<T>();
            return query;
        }

        public IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {

            IQueryable<T> query = db.Set<T>().Where(predicate);
            return query;
        }

        public virtual void Create(T entity)
        {
            db.Set<T>().Add(entity);
        }
        public virtual void Update(T entity)
        {
            db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }
        public virtual void Delete(T entity)
        {
            db.Set<T>().Remove(entity);
        }
        public virtual void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
        }
    }
}