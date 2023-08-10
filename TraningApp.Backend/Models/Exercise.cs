using System.ComponentModel.DataAnnotations.Schema;
using TraningApp.Backend.Models;

namespace TraningTrakerApp.Backend.Models
{
    public class Exercise 
    {

        public int Id { get; set; } 
        public string Name { get; set; } = "Default exercise";
        public string TargetedMuscleGroup { get; set; } = "Default Targeted muscle group";
        public ExerciseType ExerciseType { get; set; } = ExerciseType.StrengthTraining;
        public int ExerciseSets { get; set; } = 0;
        public int ExerciseReps { get; set; } = 0;
        
        // making connection to Session model
        [ForeignKey(nameof(SessionId))]
        public int SessionId { get; set; }
        public Session Session { get; set; } = null!;
        
    }
}


