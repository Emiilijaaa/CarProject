﻿using CarProject.Data.Shared.Interfaces;

namespace CarProject.Data.Entities;

public class Category : IEntity 
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Car>? Cars { get; set; }
    public List<Filter>? Filters { get; set; }

}