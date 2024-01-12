namespace CarProject.Data.Entities;

//Car = Product
public class Car : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    //public int Year { get; set; }
    //public decimal Price { get; set; }
    // public int BrandId { get; set; }
    //public Brand Brand { get; set; }

    //public List<Car>? Cars { get; set; }
    public List<Category>? Categories { get; set; }
    public List<Color>? Colors { get; set; }
    //public List<VehicleType>? VehicleTypes { get; set; }

}