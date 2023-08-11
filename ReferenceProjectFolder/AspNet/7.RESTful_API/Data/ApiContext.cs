using _7.RESTful_API.Models;
using Microsoft.EntityFrameworkCore;

namespace _7.RESTful_API.Data;

public class ApiContext : DbContext
{
    public ApiContext(DbContextOptions<ApiContext> options)
        : base(options)
    {
    }

    public DbSet<HotelBooking> Bookings { get; set; }
}