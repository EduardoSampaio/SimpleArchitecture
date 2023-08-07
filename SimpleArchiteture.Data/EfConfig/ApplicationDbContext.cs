using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SimpleArchiteture.Data.EntitiesEfMap;
using SimpleArchiteture.Domain.Entities;

namespace SimpleArchiteture.Data.EfConfig;
public class ApplicationDbContext: IdentityDbContext<IdentityUser>
{
    public DbSet<RentCar> RentCars { get; set; }

    public ApplicationDbContext()
    {
        
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new RentCarTypeConfiguration());
        base.OnModelCreating(builder);
    }

}
