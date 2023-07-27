using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services;
using TraningApp.Backend.Models;
using TraningApp.Backend.Services;

namespace TraningApp.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SessionControler : ControllerBase
    {
        private readonly IRepository<Session> _repository;
        private readonly ICurrentUser _userService;

        public SessionControler(IRepository<Session> repository, ICurrentUser currentUser)
        {
            _repository = repository;
            _userService = currentUser;
        }
        [HttpPost]
        public async Task<IActionResult> CreateSession([FromBody] Session item)
        {
            int? currentUser = _userService.GetUser();
            if(currentUser != null)
            {
                item.CreatedBy = currentUser.Value;
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
            if(item != null & item.CreatedBy == _userService.GetUser())
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
            IEnumerable<Session?> myTasks = await _repository.FindManyBy(x => x.CreatedBy == _userService.GetUser(), skip, limit);
            return Ok(myTasks);
        }

    }
}