using Microsoft.EntityFrameworkCore;

namespace API_UBAM.DatabaseContext;

public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options)
{

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }
}