using Nop.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Data
{
    /// <summary>
    /// Entity Framework repository
    /// </summary>
    public partial class EfRepository<T> : Nop.Core.Data.IRepository<T> where T : BaseEntity
    {
        private readonly IDbContext _context;
        private IDbSet<T> _entities;
        private IDbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                {
                    _entities = Context.Set<T>();
                }
                return _entities;
            }
        }

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="context">Object context IDbContext context</param>
        public EfRepository()
        {
            //this._context = new NopObjectContext();
            this._context = UnitOfWorkFactory.CurrentUnitOfWork.Context;
        }
        public IDbContext Context
        {
            get {
                return _context;//UnitOfWorkFactory.CurrentUnitOfWork.Context; 
            }
        }
        public T GetById(object id)
        {
            string typeName = this.Entities.ElementType.Name;
            return this.Entities.Find(id);
        }
        public void Insert(T entity)
        {
            Insert(entity, true);
        }
        public void Insert(T entity, bool isSubmit)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");
                this.Entities.Add(entity);
                if (isSubmit)
                {
                    this.Context.SaveChanges();
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg += string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;

                var fail = new Exception(msg, dbEx);
                //Debug.WriteLine(fail.Message, fail);
                throw fail;
            }
        }
        public void Update(T entity)
        {
            Update(entity, true);
        }
        public void Update(T entity, bool isSubmit)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");
                if (isSubmit)
                {
                    this.Context.SaveChanges();
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);

                var fail = new Exception(msg, dbEx);
                //Debug.WriteLine(fail.Message, fail);
                throw fail;
            }
        }
        public void Delete(T entity)
        {
            Delete(entity, true);
        }
        public void Delete(T entity, bool isSubmit)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                this.Entities.Remove(entity);
                if (isSubmit)
                {
                    this.Context.SaveChanges();
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);

                var fail = new Exception(msg, dbEx);
                //Debug.WriteLine(fail.Message, fail);
                throw fail;
            }
        }
        public void Flush()
        {
            Context.SaveChanges();
        }
        /// <summary>
        ///没有限定SiteId的Table
        /// </summary>
        public virtual IQueryable<T> FullTable
        {
            get
            {
                return this.Entities;
            }
        }

    }
}
