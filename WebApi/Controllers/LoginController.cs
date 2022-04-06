using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Core;
using WebApi.Models;
namespace WebApi.Controllers
{
    //[Route("[controller]/[action]")]
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpGet]//查数据
        public string num(string num,string password)
        {
            SqlHelper sqlHelper = new SqlHelper();
            DataTable res = sqlHelper.ExecuteTable("select * from Users");
            DataRow dataRow = res.Rows[1];
            
            var UserNo = dataRow["UserNo"].ToString();
            var pwd = dataRow["Password"].ToString();
            if(UserNo == num && pwd == password)
            {
                return "登录成功";
            }
            else
            {
                return "用户名或者密码错误";
            }
        }
        [HttpPut]//改数据
        public int put(int Id,string userNo,string userName,string password,int? userLevel)
        {
            SqlHelper sqlHelper = new SqlHelper();
            DataTable table = sqlHelper.ExecuteTable(
                "select * from user where Id = @Id",
                new SqlParameter("@Id",Id)
                );
            DataRow dataRow = null;
            if(table.Rows.Count > 0)
            {
                //获取第一行的数据
                dataRow = table.Rows[0];
                Users users = new Users();
                //将获取到的数据库的数据赋值给模型
                users.Id = (int)dataRow["Id"];
                users.UserNo = userNo??(string)dataRow["UserNo"];
                users.UserName = userName??(string)dataRow["UserName"];
                users.UserLevel = userLevel??(int)dataRow["UserLevel"];
                users.Password = password??(string)dataRow["Password"];





                sqlHelper.ExecuteNonQuery(
                "upadte users set userno = '1234' where id = 7",
                new SqlParameter("@userno",userNo),
                new SqlParameter("username",userName),
                new SqlParameter("userlevel",userLevel),
                new SqlParameter("password",password)
                
                );
            }
            
            return 1;
        }
        [HttpPost]//增加数据
        public string post(int UserNo,string UserName,int UserLevel,int password)
        {
            //建立连接的实例
            SqlConnection sqlConnection = new SqlConnection("Data source=.;Initial Catalog=BBS;User ID=sa;Password=123456;Encrypt=True;TrustServerCertificate=True");
            //打开数据库
            sqlConnection.Open();
            string str = $"insert into Users(UserNo,UserName,UserLevel,Password,IsDelete) values('{UserNo}','{UserName}','{UserLevel}', '{password}', 0)";
            SqlCommand sqlCommand = new SqlCommand(str,sqlConnection);
            sqlCommand.ExecuteNonQuery();
            return "ss";
        }
        [HttpDelete]//删数据
        public int remove(int Id)
        {
            string config = "Data source=.;Initial Catalog=BBS;User ID=sa;Password=123456;Encrypt=True;TrustServerCertificate=True";
            SqlConnection sqlConnection = new SqlConnection(config);
            sqlConnection.Open();
            //sql语句
            string update = $"delete from Users where  Id = @Id";
            SqlCommand sqlCommand = new SqlCommand(update, sqlConnection);
            //传入sql语句的参数
            SqlParameter sqlParameter = new SqlParameter("@Id", Id);
            //为sql命令添加参数
            sqlCommand.Parameters.Add(sqlParameter);
            sqlCommand.ExecuteNonQuery();
            return 1;
        }
    }
}
