using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace iSchool.Models.cf
{
    public class EntityContext : DbContext
    {
        public EntityContext() : base("name=cfConnectionString") { }
        public DbSet<Student> Students { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Staff_Course> Staffs_Courses { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}