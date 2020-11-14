using System.Threading.Tasks;
using alone_mysql_dc_comics.Authentication;
using alone_mysql_dc_comics.Dto.User;
using alone_mysql_dc_comics.Models;
using Microsoft.AspNetCore.Mvc;

namespace alone_mysql_dc_comics.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authrepo;
        public AuthController(IAuthRepository authrepo)
        {
            _authrepo = authrepo;

        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserRegisterDto newUser){
            ServiceResponse<int> response = await _authrepo.Register(
                new User{UserName=newUser.Username, },newUser.Password
            );
            if(!response.Success){
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginDto request){
            ServiceResponse<string> response = await _authrepo.Login(
                request.Username, request.Password
            );
            if(!response.Success){
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}