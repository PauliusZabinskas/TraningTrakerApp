using System.ComponentModel.DataAnnotations;
using TraningTrakerApp.Backend.Models;

namespace TraningApp.Backend.Models.DTOs;

public abstract class BaseExerciseDTO
{
    [Required]
    public string Name { get; set; } = "Default exercise";
    public string TargetedMuscleGroup { get; set; } = "Default Targeted muscle group";
    public ExerciseType ExerciseType { get; set; } = ExerciseType.StrengthTraining;
    public int ExerciseSets { get; set; } = 0;
    public int ExerciseReps { get; set; } = 0;

    public int SessionId { get; set; }
}