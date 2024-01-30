namespace CarShop.API.DTO.DTOs;

public class ColorPostDTO
{
    public string Name { get; set; } = string.Empty;
}

public class ColorPutDTO : BrandPostDTO
{
    public int Id { get; set; }
}

public class ColorGetDTO : BrandPutDTO
{
    //public List<ColorGetDTO>? Cars { get; set; }
}
