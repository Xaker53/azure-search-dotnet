using Application;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace WebApplication4.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GetEmailController : Controller
    {
        private readonly UserReadService _userReadService;

        public GetEmailController (UserReadService userReadService)
        {
            _userReadService = userReadService;
        }

        [HttpPost]
        public async Task<IActionResult> GetInfoUser([FromBody] string Email)
        {
            return  await _userReadService.GetInfoGmail(Email) != null  ? Ok() : NotFound("Not found Email");

        }
    }
}
