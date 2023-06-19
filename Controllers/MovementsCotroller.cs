using Dashboard_api.Services;
using Dashboard_api.Models;
using Microsoft.AspNetCore.Mvc;
namespace Dashboard_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovementsController : ControllerBase
    {
        private readonly IMovementsService _movementsService;

        public MovementsController(IMovementsService movementsService)
        {
            _movementsService = movementsService;
        }

        // GET: api/movements
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var movements = await _movementsService.GetAllAsync();
            return Ok(movements);
        }
        [HttpGet("{email}")]
        public async Task<ActionResult>Get(string email){
            var movement = await _movementsService.GetAllAsyncForEmail(email);
            return Ok(movement);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Movements movements)
        {
            await _movementsService.CreateAsync(movements);
            return Ok(movements);
        }
    }
}