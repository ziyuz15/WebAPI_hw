using Microsoft.EntityFrameworkCore;
using Order.ApplicationCore.Entities;

namespace Order.Infrastructure.Data;

public class OrderDbContext:DbContext
{
    public OrderDbContext(DbContextOptions<OrderDbContext> options):base(options)
    {
    }
    public DbSet<Orders> Orders { get; set; }
    public DbSet<OrderDetails> OrderDetails { get; set; }
}