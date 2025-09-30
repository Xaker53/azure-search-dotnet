using Application.Services;
using AutoMapper;
using Core.Entities.MappingProfiles;
using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication4.Controllers.UserController
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Policy = "ReadPolicy")]
    public class GetEmailController : ControllerBase
    {
        private readonly UserReadService _userReadService;
        private readonly IMapper _mapper;

        public GetEmailController (UserReadService userReadService, IMapper mapper)
        {
            _userReadService = userReadService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<UserRequest> GetInfoUser([FromQuery] string Email)
        {
            //return  await _userReadService.GetInfoGmail(Email) != null  ? Ok() : NotFound("Not found Email"); // need to return User
            //var test = await _userReadService.GetInfoGmail(Email);
            return _mapper.Map<UserRequest>(await _userReadService.GetInfoGmail(Email));
            //return await _userReadService.GetInfoGmail(Email);
            //return threw Exception();

        }
    }
}
