using CarProject.Data.Shared.Interfaces;

namespace CarProject.Data.Entities;


public class VehicleType : IEntity  
{
    public int Id { get; set; }
    public int VehicleId { get; set; }
    public OptionType OptionType { get; set; }
    public List<VehicleType>? VehicleTypes { get; set; }

}
