using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rad302Autumn2017.Models;
using System.Data.Entity;

namespace Rad302Autumn2017.Models
{
    public class AppDBContext :DbContext 
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
    }
}