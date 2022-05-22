using Microsoft.AspNetCore.Mvc;
using restaurant_api.Domain.DTOs.User;
using System.Threading.Tasks;

namespace restaurant_api.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public AccountController()
        {

        }

        [HttpPost("register")]
        public Task<ActionResult> RegisterUser([FromBody] RegisterUserDto registerUserDto)
        {

        }
    }
}
