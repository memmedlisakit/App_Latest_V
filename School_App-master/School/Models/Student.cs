using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace School.Models
{
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
        public bool Gender { get; set; } 
    }
}
