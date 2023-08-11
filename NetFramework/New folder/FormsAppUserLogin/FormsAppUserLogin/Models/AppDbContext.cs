using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FormsAppUserLogin.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<UserAccount> userAccount { get; set; }
    }
}