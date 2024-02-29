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

    app.AddEndpoint<Car, CarPostDTO, CarPutDTO, CarGetDTO>();
    app.AddEndpoint<Color, ColorPostDTO, ColorPutDTO, ColorGetDTO>();
    app.AddEndpoint<Brand, BrandPostDTO, BrandPutDTO, BrandGetDTO>();
  app.AddEndpoint<Category, CategoryPostDTO, CategoryPutDTO, CategoryGetDTO>();
   app.AddEndpoint<CarColor, CarColorDTO>();
    app.AddEndpoint<CarCategory, CarCategoryDTO>();
        app.MapGet($"/api/carsbycategory/{{categoryId}}", (IDbService db, int categoryId) =>
        {
            try
            {
                var result = ((CarDbService)db).GetCarsByCategory<Car, CarGetDTO>(categoryId);
                return Results.Ok(result);
            }
            catch
            {
            }

            return Results.BadRequest($"Couldn't get the requested products of type {typeof(Car).Name}.");
        });

}

void RegisterServices()
{
    ConfigureAutoMapper();
    builder.Services.AddScoped<IDbService, CarDbService>();
}

void ConfigureAutoMapper()
{
    var config = new MapperConfiguration(cfg =>
    {
        cfg.CreateMap<Car, CarPostDTO>().ReverseMap();
        cfg.CreateMap<Car, CarPutDTO>().ReverseMap();
        cfg.CreateMap<Car, CarGetDTO>().ReverseMap();
        cfg.CreateMap<Car, CarSmallGetDTO>().ReverseMap();
        cfg.CreateMap<Color, ColorPostDTO>().ReverseMap();
        cfg.CreateMap<Color, ColorPutDTO>().ReverseMap();
        cfg.CreateMap<Color, ColorGetDTO>().ReverseMap();
        cfg.CreateMap<Brand, BrandPostDTO>().ReverseMap();
        cfg.CreateMap<Brand, BrandPutDTO>().ReverseMap();
        cfg.CreateMap<Brand, BrandGetDTO>().ReverseMap();
        cfg.CreateMap<Category, CategoryPostDTO>().ReverseMap();
        cfg.CreateMap<Category, CategoryPutDTO>().ReverseMap();
        cfg.CreateMap<Category, CategoryGetDTO>().ReverseMap();

        /*cfg.CreateMap<Filter, FilterGetDTO>().ReverseMap();
        cfg.CreateMap<Size, OptionDTO>().ReverseMap();
        cfg.CreateMap<Color, OptionDTO>().ReverseMap();*/
    });
    var mapper = config.CreateMapper();
    builder.Services.AddSingleton(mapper);
}

