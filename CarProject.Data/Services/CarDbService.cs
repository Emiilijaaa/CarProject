
using CarProject.Data.Entities;

namespace CarProject.Data.Services;

public class CarDbService(CarShopContext db, IMapper mapper) : DbService(db, mapper)
{
    public List<TDto> GetCarsByCategory<TEntity, TDto>(int categoryId)
        where TEntity : class
        where TDto : class

    {
        //IncludeNavigationsFor<Color>();
        IncludeNavigationsFor<Brand>();
        var cars=db.Cars.Where(c => c.CategoryID == categoryId).ToList();
        return mapper.Map<List<TDto>>(cars);
    }
}