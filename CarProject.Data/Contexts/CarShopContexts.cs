using CarProject.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarProject.Data.Contexts;

internal class CarShopContexts : DbContext
{
    public DbSet<Brand> Brands => Set<Brand>();
    public DbSet<CarBrand> CarBrands => Set<CarBrand>();
    public DbSet<Car> Cars => Set<Car>();
    public DbSet<CarCategory> CarCategories => Set<CarCategory>();
    public DbSet<Color> Colors => Set<Color>();
    public DbSet<CarColor> CarColors => Set<CarColor>();
    public DbSet<Filter> Filters => Set<Filter>();
    public DbSet<CategoryFilter> CategoryFilters => Set<CategoryFilter>();
    public DbSet<Price> Prices => Set<Price>();
    public DbSet<CarPrice> CarPrices => Set<CarPrice>();
    public DbSet<VehicleType> VehicleTypes => Set<VehicleType>();
    public DbSet<CarVehicleType> CarVehicleTypes => Set<CarVehicleType>();
    public DbSet<Year> Years => Set<Year>();
    public DbSet<CarYear> CarYears => Set<CarYear>();
    public DbSet<Category> Categories => Set<Category>();


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

    }
}
