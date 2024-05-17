using AzureSearch.Quickstart;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication4.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AzureController : ControllerBase
    {
        private ConnectAzure connect = new();
        [HttpPost(Name = "GetAzure")]
        public List<Files> Get([FromBody] string model)
        {
            List<Files> list = null;
            if (connect != null)
            {
                list = connect.ConnectSearchFiles(model);
            }
            return list;
        }
    }
}
