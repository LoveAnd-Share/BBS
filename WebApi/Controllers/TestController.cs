using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;

namespace WebApi.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public void Get(int id,string name)
        {
            string connstr = "Data source=.;Initial Catalog=Students;User ID=sa;Password=123456;Encrypt=True;TrustServerCertificate=True";
            SqlConnection connection = new SqlConnection(connstr);
            connection.Open();
            string sql = "select * from Student";
            SqlCommand cmd = new SqlCommand(sql, connection);

        }
    }
}
