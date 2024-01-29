using Microsoft.EntityFrameworkCore.Diagnostics;

namespace CarShop.API.DTO;

public class CarColorPostDTO
{
    public int Year { get; set; }
    public double Price { get; set; }

    public int VehicleTypeId { get; set; }
    public int BrandId { get; set; }


}
public class CarColorPutDTO : CarColorPostDTO
{
    public int Id { get; set; }

}
public class CarColorGetDTO : CarColorPutDTO
{

    public List<CategoryGetDTO>? Categories { get; set; }

    public List<ColorGetDTO>? Colors { get; set; }
    public string VehicleType { get; set; }

}


public class CarColorSmallGetDTO : CarPutDTO
{

}
