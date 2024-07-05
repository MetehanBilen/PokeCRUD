using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts;

public class BaseDbContext : DbContext
{

    protected IConfiguration _configuration { get; set; }

    public DbSet<Ability> Abilities { get; set; }
    public DbSet<Pokemon> Pokemons { get; set; }
    public DbSet<Weakness> Weaknesses { get; set; }

    public BaseDbContext(DbContextOptions dbContextOptions,IConfiguration configuration):base(dbContextOptions)
    {
        _configuration = configuration;
       // Database.EnsureCreated(); //ilk migrationda hata veriyor sonra düzeltildi.
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }


}
