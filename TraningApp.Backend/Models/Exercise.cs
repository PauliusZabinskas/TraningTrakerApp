namespace TraningTrakerApp.Backend.Models
{
    public class Exercise
    {

        public int Id { get; set; } 
        public string ExerciseName { get; set; } = "Default exercise";
        public string TargetedMuscleGroup { get; set; } = "Default Targeted muscle group";
        public ExerciseType ExerciseType { get; set; } = ExerciseType.StrengthTraining;
        public int ExerciseSets { get; set; } = 0;
        public int ExerciseReps { get; set; } = 0;
        

    }
}


