namespace CarProject.Data.Services;

public class CategoryDbService(CarShopContext db, IMapper mapper) : DbService(db, mapper)
{
    public override async Task<List<TDto>> GetAsync<TEntity, TDto>()
    {
        //IncludeNavigationsFor<Filter>();
        //IncludeNavigationsFor<Product>();
        return await base.GetAsync<TEntity, TDto>();
    }
}