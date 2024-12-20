﻿using Microsoft.EntityFrameworkCore;
using Project.Finance.Domain.Entites;

namespace Project.Finance.Infrastructure;

public class FinanceDbContext(DbContextOptions<FinanceDbContext> options) : DbContext(options)
{
    //Configure enums and schemas
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Input> InputDbSet { get; set; }

    public DbSet<InputType> InputTypeDbSet { get; set; }

    public DbSet<Output> OutputDbSet { get; set; }

    public DbSet<OutputType> OutputTypeDbSet { get; set; }

    public DbSet<User> UserDbSet { get; set; }
}
