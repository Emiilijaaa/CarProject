using CarProject.Data.Shared.Interfaces;

namespace CarProject.Data.Entities;


public class VehicleType : IEntity  
{
    public string Name { get; set; }
    public int Id { get; set; }
    public OptionType OptionType { get; set; }
    public List<Car>? Cars { get; set; }

}
