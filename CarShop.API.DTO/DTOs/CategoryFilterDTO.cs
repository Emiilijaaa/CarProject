using CarProject.API.DTO;

namespace CarShop.API.DTO;

public class CategoryFilterPutDTO : CategoryPostDTO
{
    public int FilterId { get; set; }
    public int CategoryId { get; set; }
}

