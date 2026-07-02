using System;
using victor.api.Models;
using victor.api.Data;
using Microsoft.EntityFrameworkCore;

namespace victor.api.Data;

public class AppDataContext : DbContext
{
    public DbSet<Pressao> Pressao { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Victor.db");
    }

}