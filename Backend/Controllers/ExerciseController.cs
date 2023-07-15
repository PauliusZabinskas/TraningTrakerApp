
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TraningTrakerApp.Backend.Models;

namespace TraningTrakerApp.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExerciseController : ControllerBase
    {
        private static List<Exercise> exercises = new List<Exercise> {
            new Exercise { ExerciseName = "Default exercise"},
            new Exercise { ExerciseName = "Dead lift"},
            new Exercise { ExerciseName = "Dead lift"}
        };

        // Read all
        [HttpGet("GetAll")]
        public ActionResult<List<Exercise>> GetAll()  
        {
            return Ok(exercises);
        }

        // Read single
        [HttpGet("{id}")]
        public ActionResult<Exercise> GetSingle(Guid id)  
        {
            var exercise = exercises.FirstOrDefault(e => e.Id == id);
            if (exercise == null)
            {
                return NotFound();
            }
            return Ok(exercise);
        }

        // Create
        [HttpPost]
        public ActionResult<Exercise> CreateExercise(Exercise newExercise)  
        {
            newExercise.Id = Guid.NewGuid();
            exercises.Add(newExercise);
            return CreatedAtAction(nameof(GetSingle), new { id = newExercise.Id }, newExercise);
        }

        // Update
        [HttpPut("{id}")]
        public ActionResult Update(Guid id, Exercise updatedExercise)  
        {
            var existingExercise = exercises.FirstOrDefault(e => e.Id == id);
            if (existingExercise == null)
            {
                return NotFound();
            }
            existingExercise.ExerciseName = updatedExercise.ExerciseName;
            existingExercise.TargetedMuscleGroup = updatedExercise.TargetedMuscleGroup;
            existingExercise.ExerciseType = updatedExercise.ExerciseType;
            existingExercise.ExerciseSets = updatedExercise.ExerciseSets;
            existingExercise.ExerciseReps = updatedExercise.ExerciseReps;
            return NoContent();
        }

        // Delete
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)  
        {
            var existingExercise = exercises.FirstOrDefault(e => e.Id == id);
            if (existingExercise == null)
            {
                return NotFound();
            }
            exercises.Remove(existingExercise);
            return NoContent();
        }
    }
}
