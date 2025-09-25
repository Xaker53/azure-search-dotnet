using Application.CQRS.UserCreate;
using Application.Services;
using AutoMapper;
using Core.Entities.MappingProfiles;
using Core.Interfaces;
using Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Core.Entities;

namespace WebApplication4.Controllers.UserController
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController (UserReadService userReadService, UserService userService) : ControllerBase
    {
        private readonly UserReadService _userReadService = userReadService;
        private readonly UserService _userService = userService;


        [HttpPost]
        public async Task<ActionResult> LoginUser([FromBody] UserLogin user)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var token = await _userService.Login(user.UserGmail, user.Password);
                return Ok(token);
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }
    }
}
