using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarmyzaShop.Models.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        private readonly ApplicationDbContext context;
        private bool disposed;
        private Dictionary<string, object> repositories;

        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
        }
        public UnitOfWork()
        {
            context = new ApplicationDbContext();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public void Save()
        {
            context.SaveChanges();
        }
        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }

        public GenericRepository<T> Repository<T>() where T : class
        {
            if (repositories == null)
            {
                repositories = new Dictionary<string, object>();
            }

            var type = typeof(T).Name;

            if (!repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<T>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), context);
                repositories.Add(type, repositoryInstance);
            }
            return (GenericRepository<T>)repositories[type];
        }
    }
}