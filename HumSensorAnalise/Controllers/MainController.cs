using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System.IO.Ports;

namespace HumSensorAnalise.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        //private PortConnections con;
        //public MainController(PortConnections con)
        //{
        //    this.con = con;
        //}
       
        [HttpGet]
        [Route("test")]
        public IActionResult action()
        {
            Service test = new Service();
            
            return Ok(test.StaticticLastFiveMinute());
        }


    }
}
