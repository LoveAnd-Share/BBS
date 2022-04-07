using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet("{num}")]
        public string GetNum(int num)
        {
            return "num";
        }
        [HttpGet]
        public string GetName()
        {
            return "name";
        }
    }
}
