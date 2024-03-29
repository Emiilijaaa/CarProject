using AutoMapper;
using Blazored.LocalStorage;
using CarShop.UI;
using CarShop.UI.Models.Link;
using CarShop.UI.Services;
using CarShop.UI.Storage.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddHttpClient<CategoryHttpClient>(); 
builder.Services.AddHttpClient<CarHttpClient>();
builder.Services.AddSingleton<UIService>();
builder.Services.AddSingleton<IStorageService, LocalStorage>();
builder.Services.AddBlazoredLocalStorageAsSingleton();



ConfigureAutoMapper();


await builder.Build().RunAsync();

void ConfigureAutoMapper()
{
    var config = new MapperConfiguration(cfg =>
    {
        cfg.CreateMap<CartItemDTO, CarGetDTO>().ReverseMap();
    });
    var mapper = config.CreateMapper();
    builder.Services.AddSingleton(mapper);
}