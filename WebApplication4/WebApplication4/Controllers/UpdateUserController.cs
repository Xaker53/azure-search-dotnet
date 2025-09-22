using System.Text.Json;
using Application;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication4.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UpdateUserController : Controller
    {
        private readonly UserUpdateService? _userUpdateService;

        public UpdateUserController(UserUpdateService userUpdate)
        {
            _userUpdateService = userUpdate;
        }

        [HttpPost]
        public async Task<IActionResult> UpdateInfoUser([FromBody]UserDTO changes )
        {
            try
            {
                var result = await _userUpdateService.UpdateUser(changes);
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
