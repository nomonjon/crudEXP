namespace product.Data;
using Microsoft.EntityFrameworkCore;
using product.Models;


public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) 
        : base(dbContextOptions)
    {
    }

    public DbSet<Car> Cars { get; set; } = null!;
    public DbSet<Comment> Comments { get; set; } = null!;
}
