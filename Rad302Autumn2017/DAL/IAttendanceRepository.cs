using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rad302Autumn2017.DAL;
using Rad302Autumn2017.Models;

namespace Rad302Autumn2017.DAL
{
    public interface IAttendanceRepository :IDisposable
    {
        IEnumerable<Attendance> GetAttendances();
        Attendance GetAttendance(int Id);
        Attendance CreateAttendance(Attendance attendance);
        void UpdateAttendance(int Id, Attendance attendance);
        void DeleteAttendance(int Id);
    }
}