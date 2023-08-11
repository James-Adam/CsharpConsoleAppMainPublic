using Microsoft.WindowsAzure.MediaServices.Client;
using System;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace AuthenticatedSchoolSystem.Models.Back_End
{
    public class EfRepository<T> : IRepository<T> where T : BaseEntity
    {
        #region Ctor

        public EfRepository(IDbContext context)
        {
            _context = context;
        }

        #endregion Ctor

        #region Fields

        private readonly IDbContext _context;
        private readonly IDbSet<T> _entities;

        public object Table => throw new NotImplementedException();

        #endregion Fields

        #region Methods

        public virtual T GetById(object id)
        {
            return _entities.Find(id);
        }

        public virtual void Insert(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException(nameof(entity));
                }

                _ = _entities.Add(entity);

                _context.SaveChanges();
            }
            catch (DbEntityValidationException)
            {
                Console.WriteLine("Error");
            }
        }

        public virtual void Delete(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException(nameof(entity));
                }

                //this.Entities.Remove(entity);
                _context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                throw new Exception(GetFullErrorText(dbEx), dbEx);
            }
        }

        private string GetFullErrorText(DbEntityValidationException dbEx)
        {
            throw new NotImplementedException();
        }

        public void Delete(ItemMaster itemMaster)
        {
            throw new NotImplementedException();
        }

        public void Delete(DecisionTreeAttribute decisionTreeAttribute)
        {
            throw new NotImplementedException();
        }

        public void Insert(ItemMaster itemMaster)
        {
            throw new NotImplementedException();
        }

        public void Update(ItemMaster itemMaster)
        {
            throw new NotImplementedException();
        }

        #endregion Methods
    }

    public interface IRepository<T> where T : BaseEntity
    {
        object Table { get; }

        void Delete(ItemMaster itemMaster);

        void Delete(DecisionTreeAttribute decisionTreeAttribute);

        void Insert(ItemMaster itemMaster);

        void Update(ItemMaster itemMaster);
    }
}