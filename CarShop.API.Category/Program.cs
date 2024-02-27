using AutoMapper;
using CarProject.Data.Contexts;
using CarProject.Data.Entities;
using CarProject.Data.Services;
using CarShop.API.DTO.DTOs;
using CarShop.API.Extensions.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CarShopContext>(
    options =>
        options.UseSqlServer(
            builder.Configuration.GetConnectionString("CarShopConnection")));

/**********
 ** CORS Cross-Origin Resource Sharing**
 **********/
builder.Services.AddCors(policy =>
{
    policy.AddPolicy("CorsAllAccessPolicy", opt =>
        opt.AllowAnyOrigin()
           .AllowAnyHeader()
           .AllowAnyMethod()
    );
});

RegisterServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

RegisterEndpoints();
/************************
 ** CORS Configuration **
 ************************/
app.UseCors("CorsAllAccessPolicy");

app.Run();

void RegisterEndpoints()
{
    app.AddEndpoint<Category, CategoryPostDTO, CategoryPutDTO, CategoryGetDTO>();
    app.AddEndpoint<Car, CarPostDTO, CarPutDTO, CarGetDTO>();
    app.AddEndpoint<Color, ColorPostDTO, ColorPutDTO, ColorGetDTO>();
    app.AddEndpoint<Brand, BrandPostDTO, BrandPutDTO, BrandGetDTO>();
    //app.AddEndpoint<VehicleType, VehicleTypePostDTO, VehicleTypePutDTO, VehicleTypeGetDTO>();


}

void RegisterServices()
{
    ConfigureAutoMapper();
    builder.Services.AddScoped<IDbService, CategoryDbService>();
}

void ConfigureAutoMapper()
{
    var config = new MapperConfiguration(cfg =>
    {
        cfg.CreateMap<Category, CategoryPostDTO>().ReverseMap();
        cfg.CreateMap<Category, CategoryPutDTO>().ReverseMap();
        cfg.CreateMap<Category, CategoryGetDTO>().ReverseMap();
        cfg.CreateMap<Category, CategorySmallGetDTO>().ReverseMap();

        //cfg.CreateMap<VehicleType, VehicleTypePostDTO>().ReverseMap();
        //cfg.CreateMap<VehicleType, VehicleTypePutDTO>().ReverseMap();
       // cfg.CreateMap<VehicleType, VehicleTypeGetDTO>().ReverseMap();
        // cfg.CreateMap<VehicleType, VehicleTypeSmallGetDTO>().ReverseMap()

        cfg.CreateMap<Car, CarPostDTO>().ReverseMap();
        cfg.CreateMap<Car, CarPutDTO>().ReverseMap();
        cfg.CreateMap<Car, CarGetDTO>().ReverseMap();
        cfg.CreateMap<Car, CarSmallGetDTO>().ReverseMap();


        cfg.CreateMap<Color, ColorPostDTO>().ReverseMap();
        cfg.CreateMap<Color, ColorPutDTO>().ReverseMap();
        cfg.CreateMap<Color, ColorGetDTO>().ReverseMap();
        //cfg.CreateMap<Color, ColorSmallGetDTO>().ReverseMap();

        cfg.CreateMap<Brand, BrandPostDTO>().ReverseMap();
        cfg.CreateMap<Brand, BrandPutDTO>().ReverseMap();
        cfg.CreateMap<Brand, BrandGetDTO>().ReverseMap();
      //  cfg.CreateMap<Brand, BrandSmallGetDTO>().ReverseMap();





        /*cfg.CreateMap<Filter, FilterGetDTO>().ReverseMap();
        cfg.CreateMap<Size, OptionDTO>().ReverseMap();
        cfg.CreateMap<Color, OptionDTO>().ReverseMap();*/
    });
    var mapper = config.CreateMapper();
    builder.Services.AddSingleton(mapper);
}

