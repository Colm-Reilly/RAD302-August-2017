using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rad302Autumn2017.Models
{
    public class Attendance
    {
        public int AttendanceID { get; set; }
        public int ModuleID { get; set; }
        public string StudentID { get; set; }
        public DateTime AttendanceDateTime { get; set; }
        public bool Present { get; set; }
    }
}