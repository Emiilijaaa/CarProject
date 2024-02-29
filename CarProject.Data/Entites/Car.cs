namespace CarProject.Data.Entities;

//Car = Product
public class Car : IEntity
{
    public int Id { get; set; }
    public int Year { get; set; }
    public double Price { get; set; }
    public int BrandId { get; set; }
    public Brand Brand { get; set; }
    public int CategoryID { get; set; }
    public Category Category { get; set; }
    public string Description { get; set; } = string.Empty;
    public string PictureURL { get; set; } = string.Empty;

    public List<Category>? Categories { get; set; }

    public List<Color>? Colors { get; set; }
}