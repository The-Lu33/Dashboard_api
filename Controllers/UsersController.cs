using Microsoft.AspNetCore.Mvc;
using Dashboard_api.Models;
using Dashboard_api.Services;

namespace Dashboard_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var users = await _usersService.GetAllAsync();
            return Ok(users);
        }
        [HttpPost]
        public async Task<ActionResult> Post(Users user)
        {
            try
            {

                var login = await _usersService.LoginSingUp(user);
                Console.WriteLine(login);

                return Ok(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al registrar el usuario: " + ex.Message);
                // Manejar el error según tus necesidades
                return NotFound(ex.Message);
            }
        }
    }
}