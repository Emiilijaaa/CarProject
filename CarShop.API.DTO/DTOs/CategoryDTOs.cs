﻿namespace CarShop.API.DTO;

public class CategoryPostDTO
{
    public string Name { get; set; } = string.Empty;

}
public class CategoryPutDTO : CategoryPostDTO
{
    public int Id { get; set; }

}
    public class CategoryGetDTO : CategoryPutDTO
    {
        //public List<FilterGetDTO> 
    }

    public class CategorySmallGetDTO : CategoryPutDTO
    {

    }