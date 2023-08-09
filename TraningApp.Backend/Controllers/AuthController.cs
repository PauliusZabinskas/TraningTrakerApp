// using Microsoft.AspNetCore.Mvc;
// using TraningApp.Backend.Identity;
// using TraningApp.Backend.Models;
// using TraningApp.Backend.Services;

// namespace TraningApp.Backend.Controllers;

// [ApiController]
// [Route("[controller]/[action]")]
// public class AuthController : ControllerBase
// {
//     private readonly IUserManager<User> _userManager;

//     public AuthController(IUserManager<User> userManager)
//     {
//         _userManager = userManager;
//     }

//     [HttpPost]
//     public Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
//     {
//         throw new NotImplementedException();
//     }

//     [HttpPost]
//     public Task<IActionResult> Register([FromBody] LoginRequest loginRequest)
//     {
//         throw new NotImplementedException();
//     }

//     [HttpPost]
//     public Task<IActionResult> ChangePassword()
//     {
//         throw new NotImplementedException();
//     }
// }