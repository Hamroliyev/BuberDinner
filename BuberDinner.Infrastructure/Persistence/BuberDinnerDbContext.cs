using BuberDinner.Domain.Menu;
using Microsoft.EntityFrameworkCore;

namespace BuberDinner.Infrastructure.Persistence;

public class BuberdinnerDbContext : DbContext
{
    public BuberdinnerDbContext(
        DbContextOptions<BuberdinnerDbContext> options) : base(options)
    {

    }

    public DbSet<Menu> Menus { get; set;} 
}
