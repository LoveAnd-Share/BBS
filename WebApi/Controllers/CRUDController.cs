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
    [Route("api/[controller]")]
    [ApiController]
    public class CRUDController : ControllerBase
    {
        [HttpGet]
        public string Query(string username)
        {
            DataTable table = new DataTable();
            DataRow row = null;
            //配置连接的字符串
            string connStr = "Data source=.;Initial Catalog=BBS;User ID=sa;Password=123456;Encrypt=True;TrustServerCertificate=True";
            //创建连接数据库的实例
            using (SqlConnection connection = new SqlConnection(connStr))
            {               
                //调用方法打开数据库
                connection.Open();
                //创建操作数据库的命令,传参要求sql语句，连接的数据库实例
                SqlCommand cmd = new SqlCommand("select * from users where username = @username",connection);
                cmd.Parameters.Add(new SqlParameter("@username", username));
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.ExecuteReader();
                adapter.Fill(table);
                
            }
            return "success";
        }
    }
}
