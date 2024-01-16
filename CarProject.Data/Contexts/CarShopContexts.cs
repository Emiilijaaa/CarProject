using CarProject.Data.Entites;
using CarProject.Data.Entities;
using Microsoft.EntityFrameworkCore;
 
namespace CarProject.Data.Contexts;

public class CarShopContext(DbContextOptions<CarShopContext> options) : DbContext(options)

{

    public DbSet<Brand> Brands => Set<Brand>();

    public DbSet<Car> Cars => Set<Car>();

    public DbSet<Color> Colors => Set<Color>();

    public DbSet<Filter> Filters => Set<Filter>();

    public DbSet<CategoryFilter> CategoryFilters => Set<CategoryFilter>();

    public DbSet<VehicleType> VehicleTypes => Set<VehicleType>();

    public DbSet<Category> Categories => Set<Category>();

    protected override void OnModelCreating(ModelBuilder builder)

    {

        base.OnModelCreating(builder);

        // Define composite keys for join tables

        

        builder.Entity<CarColor>()

            .HasKey(cc => new { cc.CarId, cc.ColorId });

        builder.Entity<CarCategory>()

            .HasKey(cc => new { cc.CarId, cc.CategoryId });


        // Many-to-Many Relationships

        builder.Entity<Car>()

            .HasOne(c => c.Brand)

            .WithMany(b => b.Cars);

            

        builder.Entity<Car>()

            .HasMany(c => c.Colors)

            .WithMany(col => col.Cars)

            .UsingEntity<CarColor>();

        builder.Entity<Car>()

            .HasMany(c => c.Categories)

            .WithMany(cat => cat.Cars)

            .UsingEntity<CarCategory>();

        builder.Entity<Car>()

            .HasOne(c => c.VehicleType)

            .WithMany(vt => vt.Cars);

            

        // CategoryFilter Many-to-Many Relationship

        builder.Entity<Category>()

            .HasMany(cat => cat.Filters)

            .WithMany(f => f.Categories)

            .UsingEntity<CategoryFilter>();



    }

}

