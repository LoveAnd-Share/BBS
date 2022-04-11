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
        [HttpGet("{num}")]
        public string GetNum(int num)
        {
            return "num";
        }
        [HttpGet]
        public string GetName(int userno)
        {
            string conStr = "Data source=.;Initial Catalog=BBS;User ID=sa;Password=123456;Encrypt=True;TrustServerCertificate=True";
            SqlConnection connection = new SqlConnection(conStr);
            connection.Open();
            string sqlStr = "select * from users where userno = @userno";
            SqlCommand cmd = new SqlCommand(sqlStr,connection);
            SqlParameter sqlParameter = new SqlParameter("@userno",userno);
            cmd.Parameters.Add(sqlParameter);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet data = new DataSet();
            adapter.Fill(data);
            DataTable table = data.Tables[0];
            DataRow row = table.Rows[0];
            return row["userno"].ToString();
        }
        [HttpPost]
        public string Post()
        {
            string str = "Data source=.;Initial Catalog=BBS;User ID=sa;Password=123456;Encrypt=True;TrustServerCertificate=True";
            SqlConnection connection = new SqlConnection(str);
            connection.Open();
            string cmdStr = "insert into users (userno,username,userlevel,password,isdelete) values (123,'ma',15,123,0)";
            SqlCommand sqlCmd = new SqlCommand(cmdStr,connection);
            sqlCmd.ExecuteNonQuery();
;            return "success";
        }
        [HttpDelete]
        public string Delete(int id)
        {
            string str = "Data source=.;Initial Catalog=BBS;User ID=sa;Password=123456;Encrypt=True;TrustServerCertificate=True";
            using ( SqlConnection connection = new SqlConnection(str))
            {
                connection.Open();
                string cmdStr = "delete from users where id = @id";
                SqlCommand sqlCmd = new SqlCommand(cmdStr, connection);
                sqlCmd.Parameters.Add(new SqlParameter("@id", id));
                sqlCmd.ExecuteNonQuery();
            }          
            return "success";
        }
    }
}
