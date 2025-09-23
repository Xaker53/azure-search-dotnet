using Microsoft.AspNetCore.Mvc;
using Core.Interfaces;
using Core.Models;
using Application.Services;
using MediatR;
using Application.CQRS.UserCreate;

namespace WebApplication4.Controllers.UserController
{
    [ApiController]
    [Route("api/[controller]")]
    public class CreateController : ControllerBase
    {
        private readonly ISender _create;

        public CreateController(ISender create)
        {
            _create = create;
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
                await _create.Send(new UserCreateCQRS(user));
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }
    }
}
