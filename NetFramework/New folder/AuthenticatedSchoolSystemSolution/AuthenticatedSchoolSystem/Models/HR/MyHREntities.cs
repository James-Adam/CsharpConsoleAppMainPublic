using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace AuthenticatedSchoolSystem.Models.HR
{
    public class MyHREntities : DbContext
    {
        public MyHREntities()
            : base("name=HRConnectionString")
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<ActionLog> ActionLog { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}