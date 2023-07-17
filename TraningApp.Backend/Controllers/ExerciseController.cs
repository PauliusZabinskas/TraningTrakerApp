
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TraningApp.Backend.Services;
using TraningTrakerApp.Backend.Models;

namespace TraningTrakerApp.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExerciseController : ControllerBase
    {
        private readonly IRepository<Exercise> _repository;

        public ExerciseController(IRepository<Exercise> repository) 
        {
          _repository = repository;   
        }

        // Read all
        [HttpGet]
        public async Task<IEnumerable<Exercise>> GetAllExersises()  
        {
            return await _repository.GetAll();
        }

        // Read single
        [HttpGet("{id}", Name = "GetById")]
        public async Task<IActionResult> GetById(Guid id)  
        {
           Exercise? result = await _repository.Get(id);

           if(result != null)
           {
             return Ok(result);
           }
           return NotFound();
        }

        // Create
        [HttpPost]
        public async Task<IActionResult> CreateExercise([FromBody]Exercise newExercise)  
        {
            Exercise result = await _repository.Create(newExercise);
            return CreatedAtAction("GetById", new {id = result.Id});
        }

        // Update
        [HttpPatch]
        public async Task<IActionResult> Update([FromBody]Exercise updatedExercise)  
        {
            await _repository.Update(updatedExercise);
            return Ok();
        }

        // Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(Guid id)  
        {
            await _repository.Delete(id);
            return Ok();
        }
    }
}
