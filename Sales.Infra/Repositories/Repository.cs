using Sales.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Infra.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly SalesDbContext _context;
        private IDbSet<T> _dbSet;

        public Repository(SalesDbContext context)
        {
            _context = context;
            this._dbSet = _context.Set<T>();
        }

        protected virtual IDbSet<T> DbSet
        {
            get { return _dbSet ?? (_dbSet = _context.Set<T>()); }
        }

        public virtual IQueryable<T> GetAll
        {
            get { return DbSet; }
        }

        public virtual void Delete(object id)
        {
            var entityToDelete = DbSet.Find(id);
            try
            {
                if (entityToDelete == null)
                    throw new ArgumentNullException("entity");

                if (_context.Entry(entityToDelete).State == EntityState.Detached)
                    DbSet.Attach(entityToDelete);

                this.DbSet.Remove(entityToDelete);

                this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                throw GenerateException(dbEx);
            }
        }

        public virtual T GetById(object id)
        {
            return this.DbSet.Find(id);
        }

        public virtual void Insert(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                this.DbSet.Add(entity);

                this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                throw GenerateException(dbEx);
            }
        }

        public virtual void Update(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                DbSet.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;

                this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                throw GenerateException(dbEx);
            }
        }

        private static Exception GenerateException(DbEntityValidationException dbEx)
        {
            var msg = string.Empty;

            foreach (var validationErrors in dbEx.EntityValidationErrors)
                foreach (var validationError in validationErrors.ValidationErrors)
                    msg += Environment.NewLine +
                           string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);

            var fail = new Exception(msg, dbEx);
            return fail;
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
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
