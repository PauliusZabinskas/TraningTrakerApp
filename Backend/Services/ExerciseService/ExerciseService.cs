using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraningTrakerApp.Backend.Models;

namespace TraningTrakerApp.Backend.Services.ExerciseService
{
    public class ExerciseService : IExerciseService
    {
        private static List<Exercise> exercises = new List<Exercise> {
            new Exercise { ExerciseName = "Default exercise"},
            new Exercise { ExerciseName = "Dead lift"},
            new Exercise { ExerciseName = "Dead lift"}
        };

        public List<Exercise> AddExercise(Exercise newExercise)
        {
            newExercise.Id = Guid.NewGuid();
            exercises.Add(newExercise);
            return newExercise;
        
        }

        public List<Exercise> GetAllExercises()
        {
            return exercises;
        }

        public Exercise GetExerciseById(int id)
        {
            var exercise = exercises.FirstOrDefault(e => e.Id == id);
            if (exercise == null)
            {
                return NotFound();
            }
            return exercise;
        }
    }
}