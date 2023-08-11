//using Microsoft.WindowsAzure.MediaServices.Client;

namespace CsharpConsoleAppMain._5.DevMicroAzureAndWebService;

public class ActObjectContext : System.Data.Entity.DbContext, IDbContext
{
    #region Methods

    //public string CreateDatabaseScript()
    //{
    //    return ((IObjectContextAdapter)this).ObjectContext.CreateDatabaseScript();
    //}
    //public new IDbSet<TEntity> Set<TEntity>()where TEntity : BaseEntity
    //{
    //    return base.Set<TEntity>();
    //}

    //public IList<TEntity> ExecuteStoredProcedureList<TEntity>(string commandText, params object[] parameters) where TEntity:BaseEntity, new()
    //{
    //    if (parameters != null & parameters.Length > 0)
    //    {
    //    }
    //    return (IList<TEntity>)parameters;
    //}

    #endregion Methods
}

public interface IDbContext
{
    // just a dummy to allow for compilation
}