using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace School.Models
{
    public class Activation_C
    {  
        public int id { get; set; }
        public string activation_code { get; set; }
        public bool status { get; set; }
        public string username { get; set; }
        public string computer_info { get; set; }
        public string user_email { get; set; }
    }
}
