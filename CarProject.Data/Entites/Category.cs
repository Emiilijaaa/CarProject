
namespace CarProject.Data.Entites;

public class Category : IEntity
{
    public int Id { get; set; }
    public string Brand { get; set; }
    public string Color { get; set; }
    public int price { get; set; }
    public string vehicleType {get; set;}
    public int year { get; set; }
}
