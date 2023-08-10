using System.Text.Json;
using System.Text.Json.Serialization;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Services;
using TraningApp.Backend.Models.DTOs;
using TraningApp.Backend.Models.DTOs.SessionDTOs;
using TraningApp.Backend.Services;
using TraningTrakerApp.Backend.Models;
using Session = TraningApp.Backend.Models.Session;

namespace TraningTrakerApp.Backend.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class SessionController : ControllerBase
{
    private readonly IRepository<Session> _repository;
    private readonly ICurrentUser _userService;
    private readonly ICurrentSession _currentSession;
    private readonly IMapper _mapper;

    public SessionController(IRepository<Session> repository, ICurrentUser userService, ICurrentSession currentSession, IMapper mapper) 
    {
        _mapper = mapper;
        _currentSession = currentSession;
        _repository = repository;
        _userService = userService;
    }

    // Read all
    [HttpGet]
    public async Task<IActionResult> GetAllSessions([FromQuery] int? skip, [FromQuery] int? limit)  
    {
        IEnumerable<Session?> result = await _repository.FindManyBy(x => x.CreatedBy == _userService.GetUser(), skip, limit);
        
        return Ok(_mapper.Map<List<SessionDTO>>(result));
    }
    

    // Read single
    [HttpGet("{id}", Name = "GetByIntID")]
    public async Task<IActionResult> GetById(int id)  
    {
        int? currentUserId = _userService.GetUser();
        Session? result = await _repository.Get(id);

        if(result != null && currentUserId == result.CreatedBy)
        {
            SessionDetailsDTO sessionDetailsDTO = _mapper.Map<SessionDetailsDTO>(result);
            return Ok(sessionDetailsDTO);

        }else if(result == null)
        {
            return NotFound();
        }

        return Unauthorized();
       
    }

    

    // Create
    [HttpPost]
    public async Task<IActionResult> CreateSession([FromBody]CreateSessionDTO newSession)  
    {
        newSession.CreatedBy = _userService.GetUser();

        Session MappedSession = _mapper.Map<Session>(newSession);

        Session result = await _repository.Create(MappedSession);

        CreateSessionDTO sessionDto = _mapper.Map<CreateSessionDTO>(result);

        // return CreatedAtAction("GetByIntID", new { result.Id }, result);

        return Ok(sessionDto);
        
    }

    // Update
    [HttpPatch]
    public async Task<IActionResult> Update([FromBody]Session updatedSession)  
    {
        int? currentuserId = _userService.GetUser();

        

        if(updatedSession != null && currentuserId == updatedSession.CreatedBy)
        {
            
            await _repository.Update(updatedSession);
            return Ok();
        }else if (updatedSession == null)
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

    [HttpPost]
    public async Task<IActionResult> AddExerciseToSession([FromBody] CreateExerciseDTO AddExerciseDTO)
    {

        int? sessionID = _currentSession.GetSession();

        Session session = await _repository.Get(sessionID.Value);

        IEnumerable<Exercise> exerciseList = session.Exercises;

        int? currentuserId = _userService.GetUser();

        if(session != null && currentuserId == session.CreatedBy)
        {
            Exercise mappedToExercise = _mapper.Map<Exercise>(AddExerciseDTO);
            session.Exercises =  exerciseList.Append(mappedToExercise).ToList();

            await _repository.Update(session);

            SessionDetailsDTO sessionDTO = _mapper.Map<SessionDetailsDTO>(session);

            return Ok(sessionDTO);

        }else if (session == null)
        {
            return NotFound();
        }
        return Unauthorized();
    }

    

// [HttpPost]
// public async Task<IActionResult> AddExerciseToSession([FromBody] CreateExerciseDTO AddExercise)
// {
//     int? sessionID = _currentSession.GetSession();

//     Session session = await _repository.Get(sessionID.Value);

//     List<Exercise> exerciseList = session.Exercises?.ToList() ?? new List<Exercise>();

//     int? currentUserId = _userService.GetUser();

//     if (session != null && currentUserId == session.CreatedBy)
//     {
//         Exercise mappedToExercise = _mapper.Map<Exercise>(AddExercise);
//         exerciseList.Add(mappedToExercise); // Add exercise to the list

//         session.Exercises = exerciseList; // Assign the updated list back to session

//         await _repository.Update(session);

//         SessionDetailsDTO sessionDTO = _mapper.Map<SessionDetailsDTO>(session);

//         // Configure JsonSerializerOptions to handle object cycles
//         var jsonOptions = new JsonSerializerOptions
//         {
//             ReferenceHandler = ReferenceHandler.Preserve
//         };

//         // Serialize the sessionDTO object to JSON using the configured options
//         string sessionJson = JsonSerializer.Serialize(sessionDTO, jsonOptions);

//         return Ok(sessionJson);
//     }
//     else if (session == null)
//     {
//         return NotFound();
//     }
//     return Unauthorized();
// }



    
}
