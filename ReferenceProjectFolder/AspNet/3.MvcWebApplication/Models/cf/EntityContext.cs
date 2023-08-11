using System.Data.Entity;

namespace _3.MvcWebApplication.Models.cf
{
    public class EntityContext : DbContext
    {
        public EntityContext() : base("name=cfConnectionString")
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Staff> Staffs { get; set; }
    }
}