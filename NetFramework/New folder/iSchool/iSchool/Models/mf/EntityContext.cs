using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace iSchool.Models.mf
{
    public class EntityContext1 : DbContext
    {
        public EntityContext1() : base("name=mfConnectionString") { }
        public DbSet<Employee> Employees { get; set; }
    }
}