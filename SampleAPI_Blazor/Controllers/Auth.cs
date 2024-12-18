using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleAPI_Blazor.Models;
using SampleAPI_Blazor.Services;

namespace SampleAPI_Blazor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Auth(AuthService _auth, TokenManager _token) : ControllerBase
    {
        [HttpPost]
        public IActionResult Login(LoginDTO loginDTO)
        {
            
            return Ok(_token.GenerateToken(_auth.Login(loginDTO.Email, loginDTO.Password)));
        }
    }
}
