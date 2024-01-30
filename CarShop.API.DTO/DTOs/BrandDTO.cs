namespace CarShop.API.DTO.DTOs;

public class BrandPostDTO
{
    public string Name { get; set; } = string.Empty;
    public OptionType OptionType { get; set; }

}

public class BrandPutDTO : BrandPostDTO
{
    public int Id { get; set; }
}

public class BrandGetDTO : BrandPutDTO
{
    public List<CarGetDTO>? Cars { get; set; }

}
