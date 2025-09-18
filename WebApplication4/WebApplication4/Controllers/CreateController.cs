using Microsoft.AspNetCore.Mvc;
using Core.Interfaces;
using Core.Models;
using UserService;
using Application;

namespace WebApplication4.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CreateController : ControllerBase
    {
        private readonly UserAddService _create;

        public CreateController(UserAddService create)
        {
            this._create = create;
        }

        [HttpPost]
        public async Task<ActionResult> AddUser([FromBody] User user)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                await _create.Add(user);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }
    }
}
