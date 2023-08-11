using System.Data.Entity;

namespace AuthenticatedSchoolSystem.Models.Back_End
{
    public class ObjectContext : DbContext
    {
        public ObjectContext() : base("")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            _ = modelBuilder.Configurations.Add(new DecisionTreeAttributeMap());
            //modelBuilder.Configurations.Add(new ItemMasterMap());
            //modelBuilder.Configurations.Add(new DecisionTreeMap());
            //modelBuilder.Configurations.Add(new QuoteMap());
            //modelBuilder.Configurations.Add(new QuotedServiceMap());
            //modelBuilder.Configurations.Add(new QuoteUploadedFileMap());
            //modelBuilder.Configurations.Add(new QuoteDetailLineMap());
            //modelBuilder.Configurations.Add(new JWOMap());
            //modelBuilder.Configurations.Add(new AdvItemServiceMap());
            //modelBuilder.Configurations.Add(new AdvItemServiceDependencyMap());
            //modelBuilder.Configurations.Add(new QuoteAssumtionMap());
            //modelBuilder.Configurations.Add(new DecisionTreeGridResultMap());
            //modelBuilder.Configurations.Add(new RateMap());
            //modelBuilder.Configurations.Add(new EmployeeTypeMap());
            //modelBuilder.Configurations.Add(new SalesPersonMap());
            //modelBuilder.Configurations.Add(new OpportunityMap());
            //modelBuilder.Configurations.Add(new UserProfileMap());
            //modelBuilder.Configurations.Add(new AdvItemServiceMultiplierMap());
        }
    }
}