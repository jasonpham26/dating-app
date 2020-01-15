using System.Threading.Tasks;
using Dating.API.Data;
using Dating.API.Dtos;
using Dating.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dating.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AuthController : ControllerBase
  {
    private readonly IAuthRepository _repo;

    public AuthController(IAuthRepository repo)
    {
      _repo = repo;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
    {

      userForRegisterDto.Username = userForRegisterDto.Username.ToLower();

      if (await _repo.UserExist(userForRegisterDto.Username))
        return BadRequest("Username already exist");

      var userToCreate = new User
      {
        Username = userForRegisterDto.Username
      };

      var createdUser = await _repo.Register(userToCreate, userForRegisterDto.Password);

      return StatusCode(201);
    }

  }
}