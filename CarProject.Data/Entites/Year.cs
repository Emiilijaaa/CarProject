using CarProject.Data.Shared.Interfaces;

namespace CarProject.Data.Entities;
public class Year : IEntity
{
    public int Id { get; set; }
    public int YearModel { get; set; }
    public OptionType OptionType { get; set; }

}