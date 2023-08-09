using Microsoft.AspNetCore.Mvc;
using TraningApp.Backend.Models;
using TraningApp.Backend.Services;

[ApiController]

[Route("[controller]/[action]")]

public class UserController : ControllerBase
{
    
    private readonly IRepository<User> _repository;

    
    public UserController(IRepository<User> repository)
    {
        
        _repository = repository;
    }

    
    [HttpGet]
    public async Task<IActionResult> GetAllUsers([FromQuery] int? skip, [FromQuery] int? take)
    {
        IEnumerable<User> users = await _repository.GetAll(take, skip);
        return Ok(users);
    }

    [HttpGet("{id}", Name = "GetUserById")]
    public async Task<IActionResult> GetUser(int id)
    {
        User result = await _repository.Get(id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] User user)
    {
        User result = await _repository.Create(user);
        
        // return CreatedAtAction("GetByGuid", new { id = result.Id });
        // return CreatedAtAction("GetUserById", new {result.Id}, result);   
        return Ok(result); 
    }

    [HttpPatch]
    public async Task<IActionResult> UpdateUser([FromBody] User user)
    {
        
        await _repository.Update(user);
        return Ok();
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        await _repository.Delete(id);
        return Ok();

    }
}