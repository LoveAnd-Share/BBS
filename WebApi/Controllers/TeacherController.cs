using Microsoft.AspNetCore.Cors;
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
    [EnableCors("any")]
    public class TeacherController : ControllerBase
    {
        [HttpGet]
        public string Login(string userNo, string password)
        {
            SqlHelper sqlHelper = new SqlHelper();
            DataTable res = SqlHelper.ExecuteTable("select * from Teacher");
            DataRow dataRow = null;
            for(int i = 0;i < res.Rows.Count;i++)
            {
                dataRow = res.Rows[i];           
                if (userNo == dataRow["userno"].ToString())
                {
                    if (password == dataRow["password"].ToString())
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
                    continue;
                }
            }
            return "fail";
        }
        /// <summary>
        /// 原生sql分页查询
        /// </summary>
        /// <param name="pageIndex">页标</param>
        /// <param name="pageSize">页大小</param>
        /// <returns></returns>
        [HttpGet]
        public List<Students> PageSelect(int pageIndex,int pageSize)
        {
            SqlHelper sqlHelper = new SqlHelper();
            DataTable res = SqlHelper.ExecuteTable("select * from Student order by id offset @start rows fetch next @pageSize rows only"
                ,new SqlParameter("@start",(pageIndex-1)*pageSize+1)
                ,new SqlParameter("@pageSize",pageSize)
                );
            DataRow dataRow = null;
            List<Students> students = new List<Students>();           
            for (int i = 0; i < res.Rows.Count; i++)
            {
                dataRow = res.Rows[i];
                Students student = new Students();
                student.Id = (int)dataRow["id"];
                student.Name = dataRow["name"].ToString();
                student.Tename = dataRow["teName"].ToString();
                student.Age = (int)dataRow["age"];
                students.Add(student);
            }

            return students;           
        }

    }
}
