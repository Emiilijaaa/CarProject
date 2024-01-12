using CarProject.Data.Shared.Interfaces;

namespace CarProject.Data.Entities;

public class Price : IEntity
{
    public int Id { get; set; }
    public decimal CarPrice { get; set; }
    public OptionType OptionType { get; set; }

}