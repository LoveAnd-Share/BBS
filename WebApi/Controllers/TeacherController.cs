using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        
        [HttpGet]
        public List<Students> Retrieve()
        {
            SqlHelper sqlHelper = new SqlHelper();
            DataTable res = SqlHelper.ExecuteTable("select * from Student");
            DataRow dataRow = null;
            List<Students> students = new List<Students>();
            Students student = new Students();
            for (int i = 0; i < res.Rows.Count; i++)
            {
                dataRow = res.Rows[i];                          
                
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
