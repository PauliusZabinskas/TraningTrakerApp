using Microsoft.AspNetCore.Mvc;
using Services;
using TraningApp.Backend.Models;
using TraningApp.Backend.Services;
using TraningTrakerApp.Backend.Models;

namespace TraningApp.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SessionControler : ControllerBase
    {
        private readonly IRepository<Session> _repository;
        private readonly ICurrentUser _userService;
        


        public SessionControler(IRepository<Session> repository, ICurrentUser currentUserService)
        {
            _repository = repository;
            _userService = currentUserService;
            
        }
        [HttpPost]
        public async Task<IActionResult> CreateSession([FromBody] Session item)
        {
            int? currentUser = _userService.GetUser();
            if(currentUser != null)
            {
                item.CreatedByUser = currentUser.Value;
                Session result = await _repository.Create(item);
                return CreatedAtAction("GetSessionByID", new{result.Id}, result);
            }
            return BadRequest();
        }

        [HttpGet("{id}", Name = "GetSessionByID")]
        public async Task<IActionResult> GetSession(int id)
        {
            Session? result = await _repository.Get(id);
            if(result != null && result.Id == id)
            {
                return Ok(result);
            }else if (result == null)
            {
                return NotFound(result);
            }
            return Unauthorized();
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateSession([FromBody] Session item)
        {
            if(item != null & item.CreatedByUser == _userService.GetUser())
            {
                await _repository.Update(item);
                return Ok();
            } else if (item == null)
            {
                return NotFound(item);
            }
            return Unauthorized(item);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSession(int id)
        {
            Session? result = await _repository.Get(id);
            if (result != null && result.Id == _userService.GetUser())
            {
                await _repository.Delete(id);
            } else if (result == null)
            {
                return NotFound();
            }

            return Unauthorized(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSession([FromQuery] int? skip, [FromQuery] int? limit)
        {
            IEnumerable<Session?> myTasks = await _repository.FindManyBy(x => x.CreatedByUser == _userService.GetUser(), skip, limit);
            return Ok(myTasks);
        }

        [HttpPost]
        public async Task<IActionResult> AddNew(Exercise exercise)
        {
            await _repository.
        }

    }
}