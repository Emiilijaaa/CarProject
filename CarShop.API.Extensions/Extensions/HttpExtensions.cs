using CarProject.Data.Shared.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Internal;


namespace CarShop.API.Extensions.Extensions;

public static class HttpExtensions 
{
    public static  void AddEndpoint<TEntity, TPostDto, TPutDto, TGetDto>(this WebApplication app)
    where TEntity : class, IEntity where TPostDto : class where TPutDto : class where TGetDto : class
    {
        var node = typeof(TEntity).Name.ToLower();
        app.MapGet($"/api/{node}s", HttpGetAsync<TEntity, TGetDto>);
    }

    public static async Task<IResult> HttpGetAsync<TEntity, TDto>()
        where TEntity : class where TDto : class => 
        Results.Ok();
}

