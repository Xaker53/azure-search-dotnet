using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication4.Controllers.UserController
{
    //[Route("api/[controller]")]
    public class DeleteUserController (UserDeleteService _userDelete) : Controller
    {
        [HttpDelete ("api/DeleteUser/{EmailUser}")]
        public async Task<IActionResult> DeleteUser(string EmailUser)
        {
            try
            {
                return await _userDelete.Delete(EmailUser) == true? Ok() : throw new Exception("User not found or deleted");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
