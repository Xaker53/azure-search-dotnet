using Application.Interface.CQRS.DeleteUser;
using Application.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Persistence.Interactions;

namespace WebApplication4.Controllers.UserController
{
    //[Route("api/[controller]")]
    public class DeleteUserController(ISender sender) : Controller
    {
        private readonly ISender _sender;

        [HttpDelete ("api/DeleteUser/{Gmail}")]
        public async Task<IActionResult> DeleteUser(UserDeleteCQRS EmailUser)
        {
            try
            {
                return await sender.Send(EmailUser) == true ? Ok() : throw new Exception("User not found or deleted");
                //return await _userDelete.Delete(EmailUser) == true? Ok() : throw new Exception("User not found or deleted");
            }
            catch(Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
