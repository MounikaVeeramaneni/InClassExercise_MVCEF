using Microsoft.EntityFrameworkCore;
using MVC_EF_Start.Models;

namespace MVC_EF_Start.DataAccess
{
  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Product> Products { get; set; }
    public DbSet<Store> Stores { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Orderdetail> Orderdetails { get; set; }
  }
}