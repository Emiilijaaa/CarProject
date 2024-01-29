
namespace CarShop.API.DTO;

public class CarPostDTO
{
    public int Year { get; set; }
    public double Price { get; set; }

    public int VehicleTypeId { get; set; }
    public int BrandId { get; set; }


}
public class CarPutDTO : CarPostDTO
{
    public int Id { get; set; }

}
public class CarGetDTO : CarPutDTO
{

    public List<CategoryGetDTO>? Categories { get; set; }

    public List<ColorGetDTO>? Colors { get; set; }
    public VehicleTypeGetDTO VehicleType { get; set; }

}


public class CarSmallGetDTO : CarPutDTO
{

}


