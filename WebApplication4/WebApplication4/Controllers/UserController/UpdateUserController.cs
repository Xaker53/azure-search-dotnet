using System.Text.Json;
using Application.Services;
using AutoMapper;
using Core.Entities.MappingProfiles;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication4.Controllers.UserController
{
    [ApiController]
    [Route("api/[controller]")]

    public class UpdateUserController : Controller
    {
        private readonly UserUpdateService? _userUpdateService;
        private readonly IMapper _mapper;

        public UpdateUserController(UserUpdateService userUpdate, IMapper mapper)
        {
            _userUpdateService = userUpdate;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> UpdateInfoUser(UserRequest changes )
        {
            try
            {
                var result = await _userUpdateService.UpdateUser(_mapper.Map<UserDTO>(changes));
                if (result != null)
                {
                    return Ok();
                }
                else
                {
                    throw new Exception("Error updating data");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
