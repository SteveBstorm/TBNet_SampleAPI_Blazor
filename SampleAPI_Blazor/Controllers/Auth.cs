using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleAPI_Blazor.Hubs;
using SampleAPI_Blazor.Models;
using SampleAPI_Blazor.Services;

namespace SampleAPI_Blazor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Auth(AuthService _auth, TokenManager _token, ChatHub chat) : ControllerBase
    {
        [HttpPost]
        public IActionResult Login(LoginDTO loginDTO)
        {
            
            return Ok(_token.GenerateToken(_auth.Login(loginDTO.Email, loginDTO.Password)));
        }

        [HttpPost("chat/{message}")]
        public async Task<IActionResult> Send(string message)
        {
            await chat.SendMessage(message);
            return Ok();
        }
    }
}
