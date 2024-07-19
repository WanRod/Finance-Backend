using Microsoft.EntityFrameworkCore;
using Project.Finance.Domain.Entites;

namespace Project.Finance.Infrastructure;

public class FinanceDbContext : DbContext
{
    //Created database if not exists
    public FinanceDbContext(DbContextOptions<FinanceDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    //Configure enums and schemas
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Input> InputDbSet { get; set; }

    public DbSet<OutputType> OutputTypeDbSet { get; set; }

    public DbSet<Output> OutputDbSet { get; set; }

}
