using Microsoft.WindowsAzure.MediaServices.Client;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace AuthenticatedSchoolSystem.Models.Back_End
{
    public class AcfObjectContext : DbContext, IDbContext
    {
        public IDisposable BeginTransaction()
        {
            throw new NotImplementedException();
        }

        #region Methods

        public string CreateDatabaseScript()
        {
            return ((IObjectContextAdapter)this).ObjectContext.CreateDatabaseScript();
        }

        public void ExecuteSqlCommand(string v)
        {
            throw new NotImplementedException();
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }

        IDisposable IDbContext.BeginTransaction()
        {
            throw new NotImplementedException();
        }

        void IDbContext.ExecuteSqlCommand(string v)
        {
            throw new NotImplementedException();
        }

        void IDbContext.SaveChanges()
        {
            throw new NotImplementedException();
        }

        //public IList<TEntity> ExecuteStoredProcedureList<TEntity>(string commandText, params object[] parameters) where TEntity:BaseEntity, new()
        //{
        //    if (parameters != null & parameters.Length > 0)
        //    {
        //    }
        //    return
        //}

        #endregion Methods
    }

    public interface IDbContext
    {
        IDisposable BeginTransaction();

        void ExecuteSqlCommand(string v);

        void SaveChanges();
    }
}