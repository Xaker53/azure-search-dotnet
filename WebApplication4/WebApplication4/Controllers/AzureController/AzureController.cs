using AzureSearch.Quickstart;
using Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication4.Controllers.AzureController
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Policy = "ReadPolicy")]
    public class AzureController (ConnectAzure connect) : ControllerBase
    {
        //private ConnectAzure connect = new();
        [HttpPost(Name = "GetAzure")]
        public List<Files> Get([FromBody] AzureRequestDTO model)
        {
            List<Files> list = null;
            if (connect != null)
            {
                list = connect.ConnectSearchFiles(model.Request, model.UserId);
            }
            return list;
        }
    }
}
