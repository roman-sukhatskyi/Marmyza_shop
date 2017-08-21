using MarmyzaShop.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using MarmyzaShop.Models;

namespace MarmyzaShop.Implementations
{
    public class UnitOfWork<C> : IDisposable, IUnitOfWork where C : ApplicationDbContext, new()
    {
        private C context = new C();
        private Hashtable repositories = new Hashtable();
        public IRepository<T> GetRepository<T>() where T : class
        {
            if (!repositories.Contains(typeof(T)))
            {
                repositories.Add(typeof(T), new Repository<T>(context));
            }
            return (IRepository<T>)repositories[typeof(T)];
        }
        public void Save()
        {
            context.SaveChanges();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}