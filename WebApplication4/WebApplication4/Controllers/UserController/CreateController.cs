using Application.CQRS.UserCreate;
using Application.Interface;
using Application.Services;
using AutoMapper;
using Core.Entities.MappingProfiles;
using Core.Interfaces;
using Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication4.Controllers.UserController
{
    [ApiController]
    [Route("api/[controller]")]
    public class CreateController : ControllerBase
    {
        private readonly ISender _create;
        private readonly IMapper _mapper;
        //private readonly UserService _userService;
        //private readonly ISalt _Salt;


        public CreateController(ISender create, IMapper mapper) 
        {
            _create = create;
            _mapper = mapper;
            //_userService = userService;
            //_Salt = salt;
        }

        [HttpPost]
        public async Task<ActionResult> AddUser([FromBody] UserRequest user)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                //user.Password = await _userService.Register(user.Gmail, user.Password, _Salt.GetSalt());
                await _create.Send(new UserCreateCQRS(_mapper.Map<User>(user)));
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }
    }
}
