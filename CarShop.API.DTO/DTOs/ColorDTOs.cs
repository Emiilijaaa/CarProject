namespace CarShop.API.DTO.DTOs;

public class ColorPostDTO
{
    public string Name { get; set; } = string.Empty;
    public OptionType OptionType { get; set; }
}

public class ColorPutDTO : ColorPostDTO
{
    public int Id { get; set; }
}

public class ColorGetDTO : ColorPutDTO
{
    //public List<ColorGetDTO>? Cars { get; set; }
}
