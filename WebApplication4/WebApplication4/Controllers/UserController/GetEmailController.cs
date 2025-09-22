using Application.Services;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace WebApplication4.Controllers.UserController
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

        [HttpGet]
        public async Task<User> GetInfoUser([FromQuery] string Email)
        {
            //return  await _userReadService.GetInfoGmail(Email) != null  ? Ok() : NotFound("Not found Email"); // need to return User
            return await _userReadService.GetInfoGmail(Email);
            //return threw Exception();

        }
    }
}
