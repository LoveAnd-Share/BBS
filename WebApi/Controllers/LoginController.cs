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
    [Route("[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpGet]//查数据
        public string Login(string userNo,string password)
        {
            SqlHelper sqlHelper = new SqlHelper();
            DataTable res = SqlHelper.ExecuteTable("select * from Users");
            DataRow dataRow = null;
            for (int i = 0;i < res.Rows.Count;i++)
            {
                if(userNo == dataRow["userno"].ToString())
                {
                    if(password == dataRow["password"].ToString())
                    {
                        return "success";
                    }
                    else
                    {
                        continue;
                    }
                }
                else
                {
                    string a = dataRow["userno"].ToString();
                    continue;
                }
            }
            return "fail";          
        }
        /// <summary>
        /// 修改数据涉及可能需要原有的值保持不变，引入模型数据接收数据库的值
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="userNo"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="userLevel"></param>
        /// <returns></returns>
        [HttpPut]//改数据
        public string Insert(int Id,string userNo,string userName,string password,int? userLevel)
        {
            SqlHelper sqlHelper = new SqlHelper();
            //获取对应id的数据表
            DataTable table = SqlHelper.ExecuteTable(
                "select * from users where Id = @Id",
                new SqlParameter("@Id",Id)
                ); 
            if (table.Rows.Count > 0)
            {
                //获取第一行的数据
                DataRow dataRow = table.Rows[0];
                Users users = new Users();
                //将获取到的数据赋值给模型
                users.Id = (int)dataRow["Id"];
                users.UserNo = userNo ??dataRow["UserNo"].ToString();
                users.UserName = userName ?? dataRow["UserName"].ToString();
                users.UserLevel = userLevel ?? (int)dataRow["UserLevel"];
                users.Password = password ?? dataRow["Password"].ToString();
                SqlHelper.ExecuteNonQuery(
                "update users set userno = @userno,username = @username,userlevel = @userlevel,password = @password where id = @id",
                new SqlParameter("@userno",users.UserNo),
                new SqlParameter("@username",users.UserName),
                new SqlParameter("@userlevel", users.UserLevel),
                new SqlParameter("@password", users.Password),
                new SqlParameter("@id",users.Id)
                );
            }
            return "1";
        }
        [HttpPut]
        public string Insert1()
        {

            return "success";
        }
        [HttpPost]//增加数据
        public string Update(int UserNo,string UserName,int UserLevel,int password,int isdelete)
        {
            SqlHelper sqlHelper = new SqlHelper();
            
            SqlHelper.ExecuteNonQuery(
                "insert into users (userno,username,userlevel,password,isdelete) values(@userno ,@username ,@userlevel ,@password ,@isdelete)",
                new SqlParameter("@userno",UserNo),
                new SqlParameter("@username", UserName),
                new SqlParameter("@userlevel", UserLevel),
                new SqlParameter("@password", password),
                new SqlParameter("@isdelete", isdelete)

                );
            return "res";
        }
        [HttpDelete]//删数据
        public int Delete(int Id)
        {
            SqlHelper sqlHelper = new SqlHelper();
            SqlHelper.ExecuteNonQuery(
                "delete from users where id = @id",
                new SqlParameter("@id",Id)
                );
            return 1;
        }
    }
}
