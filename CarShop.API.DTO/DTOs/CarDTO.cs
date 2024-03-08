namespace CarShop.API.DTO;

public class CarPostDTO
{
    public int Year { get; set; }
    public double Price { get; set; }
    public int CategoryId { get; set; }
    public int BrandId { get; set; }
    public string Description { get; set; } 
    public string PictureURL { get; set; } 

}
public class CarPutDTO : CarPostDTO
{
    public int Id { get; set; }
}
public class CarGetDTO : CarPutDTO
{
    public BrandGetDTO Brand { get; set; }
    public CategoryGetDTO? Category { get; set; }
    public List<ColorGetDTO>? Colors { get; set; }
    public List<BrandGetDTO>? Brands { get; set; }


}
public class CartItemDTO : CarPutDTO
{
    public ColorGetDTO? Color { get; set; }
}

public class CarSmallGetDTO : CarPutDTO
{

}


