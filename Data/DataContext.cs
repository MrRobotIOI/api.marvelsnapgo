using Microsoft.EntityFrameworkCore;
using WarHammer40KAPI.Entities;

namespace WarHammer40KAPI.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }

    public DbSet<MSCard> MSCards { get; set; }
    public DbSet<users> users { get; set; }
    public DbSet<sessions> sessions { get; set; }
}
 