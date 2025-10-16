using Application.CQRS.UserCreate;
using Application.Interface;
using Application.Services;
using AutoMapper;
using Core.Entities;
using Core.Entities.MappingProfiles;
using Core.Interfaces;
using Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication4.Controllers.UserController
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController (IUserService userService) : ControllerBase
    {
        private readonly IUserService _userService = userService;


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
                return BadRequest(e.Message);
            }
        }
    }
}
