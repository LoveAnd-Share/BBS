using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Core;
using System.Data;
using Microsoft.Data.SqlClient;
namespace WebApi.Dal
{
    public class UserDal
    {
        public Users GetUserById(int id)
        {
            DataTable table =  SqlHelper.ExecuteTable("select * from Users where id = @id",
                new SqlParameter("@id",id)
                );
            DataRow dataRow = null;
            if(table.Rows.Count > 0)
            {
                dataRow = table.Rows[0];
            }
            Users user = new Users();
            user.Id = (int)dataRow["Id"];
            user.UserNo = dataRow["UserNo"].ToString();
            user.UserName =  dataRow["UserName"].ToString();
            user.UserLevel =  (int)dataRow["UserLevel"];
            user.Password =  dataRow["Password"].ToString();
            return user;
        }
        public Users GetUsersByNoAndPwd(string userNo, string password)
        {
            DataTable table = SqlHelper.ExecuteTable("select * from Users where userno = @userno and password = @password",
                new SqlParameter("@userno", userNo),
                new SqlParameter("@password", password)
                );
            DataRow dataRow = null;
            if (table.Rows.Count > 0)
            {
                dataRow = table.Rows[0];
            }
            Users user = new Users();
            user.Id = (int)dataRow["Id"];
            user.UserNo = dataRow["UserNo"].ToString();
            user.UserName = dataRow["UserName"].ToString();
            user.UserLevel = (int)dataRow["UserLevel"];
            user.Password = dataRow["Password"].ToString();
            return user;
        }
    }
}
