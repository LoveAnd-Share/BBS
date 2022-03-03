using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    //[Route("[controller]/[action]")]
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpGet]
        public int num(string num,string password)
        {
            string config = "Data source=.;Initial Catalog=BBS;User ID=sa;Password=123456;Encrypt=True;TrustServerCertificate=True";
            SqlConnection sqlConnection = new SqlConnection(config);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Users",sqlConnection);
            SqlDataAdapter sda = new SqlDataAdapter(sqlCommand);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            DataTable res = ds.Tables[0];
            DataRow dataRow = res.Rows[0];
            var value = dataRow["UserNo"].ToString();

            return 1;
        }
        [HttpPut]
        public int put(string num,string password)
        {
            return 1;
        }
        [HttpPost]
        public int post()
        {
            return 1;
        }
        [HttpDelete]
        public int remove()
        {
            return 1;
        }
    }
}
