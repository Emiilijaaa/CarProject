using CarProject.Data.Shared.Interfaces;
namespace CarShop.API.Extensions.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Internal;

public static class HttpExtensions 
{
    public static  void AddEndpoint<TEntity, TPostDto, TPutDto, TGetDto>(this WebApplication app)
    where TEntity : class, IEntity where TPostDto : class where TPutDto : class where TGetDto : class
    {
        var node = typeof(TEntity).Name.ToLower();
        app.MapGet($"/api/{node}s", HttpGetAsync<TEntity, TGetDto>);
    }

    public static async Task<IResult> HttpGetAsync<TEntity, TDto>(this IDbService db)
        where TEntity : class where TDto : class => 
        Results.Ok();
}
