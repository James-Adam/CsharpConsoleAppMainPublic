using BulkyBookWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyBookWeb.Data;

public class ApplicationDbContext : DbContext //use dbContext. should inherit install framework
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
        base(options) //ctor //general setup
    {
    }

    //create db category table
    public DbSet<Category> Categories { get; set; }
}