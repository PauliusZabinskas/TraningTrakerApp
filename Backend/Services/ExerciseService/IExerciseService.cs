using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraningTrakerApp.Backend.Models;

namespace TraningTrakerApp.Backend.Services.ExerciseService
{
    public interface IExerciseService
    {
        List<Exercise> GetAllExercises();
        Exercise GetExerciseById(int id);
        List<Exercise> AddExercise(Exercise exercise);
    }
}