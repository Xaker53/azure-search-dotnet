using Application.CQRS.DeleteUser;
using Application.CQRS.UserDeleteIndex;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication4.Controllers.UserController
{

    [Authorize(Policy = "ReadPolicy")]

    public class DeletingUserIndexesController (ISender _sender) : Controller
    {
        [HttpDelete ("api/DeleteIndex/{UserGmail}")]
        public async Task<IActionResult> DeleteIndex(UserDeleteIndexCQRS Email)
        {
            try
            {
                return await _sender.Send(Email) == true ? Ok() : throw new Exception("User not found");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            
        }
    }
}
