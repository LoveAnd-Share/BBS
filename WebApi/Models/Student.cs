using System;
using System.Collections.Generic;

#nullable disable

namespace WebApi.Models
{
    public partial class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TeName { get; set; }
        public int? Age { get; set; }
    }
}
