namespace CarShop.API.DTO.DTOs;

public class VehicleTypePostDTO
{
    public string Name { get; set; }


    public OptionType OptionType { get; set; }
}

public class VehicleTypePutDTO : VehicleTypePostDTO
{
    public int Id { get; set; }
}

public class VehicleTypeGetDTO : VehicleTypePutDTO
{
    public List<CarGetDTO>? Cars { get; set; }

}