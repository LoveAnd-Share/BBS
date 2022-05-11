﻿using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Core;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("any")]
    public class EFStudentController : ControllerBase
    {
        /// <summary>
        /// 添加学生的数据
        /// </summary>
        /// <param name="id">学号</param>
        /// <param name="name">姓名</param>
        /// <param name="teName">教师姓名</param>
        /// <param name="age">学生年龄</param>
        [HttpPost]
        public void AddStu(int id, string name, string teName, int age)
        {
            using (StudentsContext DbStudents = new StudentsContext())
            {
                Student student = new Student();
                var stuList = DbStudents.Students.ToList();
                foreach (Student stu in stuList)
                {
                    if (stu.Id == id)
                    {
                        throw new Exception("学号已存在");
                    }
                }
                student.Id = id;
                student.Name = name;
                student.TeName = teName;
                student.Age = age;
                DbStudents.Students.Add(student);
                DbStudents.SaveChanges();
            }
        }
        /// <summary>
        /// 根据id修改学生信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="teName"></param>
        /// <param name="age"></param>
        [HttpPut]
        public void UpdateStu(int id, string name, string teName, int age)
        {
            using (StudentsContext DbStudents = new StudentsContext())
            {
                var stuList = DbStudents.Students.ToList();
                foreach (Student stu in stuList)
                {
                    if (stu.Id == id)
                    {
                        stu.Name = name;
                        stu.TeName = teName;
                        stu.Age = age;
                        DbStudents.SaveChanges();
                        break;
                    }
                }             
            }
        }
        /// <summary>
        /// 根据学号删除学生
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete]
        public void DeleteStu(int id)
        {
            using (StudentsContext DbStudents = new StudentsContext())
            {
                var stuList = DbStudents.Students.ToList();
                foreach (Student stu in stuList)
                {
                    if (stu.Id == id)
                    {
                        DbStudents.Students.Remove(stu);
                        DbStudents.SaveChanges();
                        break;
                    }
                }
            }
        }

    }
}