using Microsoft.AspNetCore.Mvc;
using Services;
using TraningApp.Backend.Services;
using TraningTrakerApp.Backend.Models;

namespace TraningTrakerApp.Backend.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class ExerciseConttroller : ControllerBase
{
    private readonly IRepository<Exercise> _repository;
    private readonly ICurrentUser _userService;

    public ExerciseConttroller(IRepository<Exercise> repository, ICurrentUser userService) 
    {
      _repository = repository;
      _userService = userService;
    }

    // Read all
    [HttpGet]
    public async Task<IEnumerable<Exercise>> GetAllExersises(int? page, int? limit)  
    {
        return await _repository.GetAll(page, limit);
    }

    // Read single
    [HttpGet("{id}", Name = "GetById")]
    public async Task<IActionResult> GetById(int id)  
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
        // return CreatedAtAction("GetById", new { result.Id }, result);
        return Ok(result);
        
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
    public async Task<IActionResult> DeleteById(int id)  
    {
        await _repository.Delete(id);
        return Ok();
    }
}
