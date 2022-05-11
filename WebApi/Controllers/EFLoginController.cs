using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("any")]
    public class EFLoginController : ControllerBase
    {
        /// <summary>
        /// 登陆校验
        /// </summary>
        /// <param name="userNo"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpGet]
        public string Login(string userNo, string password)
        {
            using (StudentsContext DbStudents = new StudentsContext())
            {
                var TeacherList = DbStudents.Teachers.ToList();
                foreach(Teacher item in TeacherList)
                {
                    if(userNo == item.Userno || password == item.Password)
                    {
                        return "success";
                    }
                }
            }           
            return "fail";           
        }
    }
}
