using Microsoft.AspNetCore.Mvc;
using Services;
using TraningApp.Backend.Services;
using Session = TraningApp.Backend.Models.Session;

namespace TraningTrakerApp.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SessionController : ControllerBase
{
    private readonly IRepository<Session> _repository;
    private readonly ICurrentUser _userService;

    public SessionController(IRepository<Session> repository, ICurrentUser userService) 
    {
      _repository = repository;
      _userService = userService;
    }

    // Read all
    [HttpGet]
    public async Task<IActionResult> GetAllSessions([FromQuery] int? skip, [FromQuery] int? limit)  
    {
        IEnumerable<Session?> result = await _repository.FindManyBy(x => x.CreatedBy == _userService.GetUser(), skip, limit);
        return Ok(result);
    }

    // Read single
    [HttpGet("{id}", Name = "GetByIntID")]
    public async Task<IActionResult> GetById(int id)  
    {
        int? currentUserId = _userService.GetUser();
        Session? result = await _repository.Get(id);

        if(result != null && currentUserId == result.CreatedBy)
        {
            return Ok(result);

        }else if(result == null)
        {
            return NotFound();
        }

        return Unauthorized();
       
    }

    // Create
    [HttpPost]
    public async Task<IActionResult> CreateSession([FromBody]Session newSession)  
    {
        newSession.CreatedBy = _userService.GetUser();

        Session result = await _repository.Create(newSession);

        //  return CreatedAtAction("GetByIntID", new { result.Id }, result);

        return Ok(result);
        
    }

    // Update
    [HttpPatch]
    public async Task<IActionResult> Update([FromBody]Session updatedExercise)  
    {
        int? currentuserId = _userService.GetUser();

        if(updatedExercise != null && currentuserId == updatedExercise.CreatedBy)
        {
            await _repository.Update(updatedExercise);
            return Ok();
        }else if (updatedExercise == null)
        {
            return NotFound();
        }
        return Unauthorized();
    }

    // Delete
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteById(int id)  
    {
        int? currentUserId = _userService.GetUser();
        Session currentSession = await _repository.Get(id);

        if (currentSession != null && currentUserId == currentSession.CreatedBy)
        {
            await _repository.Delete(id);
            return Ok();

        }
        return NoContent();
    }
}
