using TraningTrakerApp.Backend.Models;

namespace TraningApp.Backend.Models;

public class Session
{
    public int Id { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
    public string? Name { get; set; } = "Default";
    public string? TargetedMuscleGroups { get; set; } = "Default";
    

    public  IEnumerable<Exercise> Exercises { get; set; } = new List<Exercise>();
    
    public int? CreatedBy { get; set; }
}