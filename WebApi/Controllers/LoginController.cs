﻿using Microsoft.AspNetCore.Http;
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
        public string num(string num,string password)
        {
            //连接数据库的字符串
            string config = "Data source=.;Initial Catalog=BBS;User ID=sa;Password=123456;Encrypt=True;TrustServerCertificate=True";
            //创建连接数据库的实例
            using SqlConnection sqlConnection = new SqlConnection(config);
            //打开数据库
            sqlConnection.Open();
            //操作数据库
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Users",sqlConnection);
            //
            SqlDataAdapter sda = new SqlDataAdapter(sqlCommand);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            DataTable res = ds.Tables[0];
            DataRow dataRow = res.Rows[0];
            //关闭数据库连接
            sqlConnection.Close();
            sqlConnection.Dispose();
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
