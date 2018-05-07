using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rad302Autumn2017.Models;
using Rad302Autumn2017.DAL;
using System.Web.Http;
using System.Net;

namespace Rad302Autumn2017.DAL
{
    public class AttendanceRepositoryEF : IAttendanceRepository
    {
        private AppDBContext _context;

        public AttendanceRepositoryEF(AppDBContext context)
        {
            _context = context;
        }

        //Get /API/attendances
        //Returns all students
        public IEnumerable<Attendance> GetAttendances()
        {
            return _context.Attendances.ToList();
        }

        //GET /api/attendances/id
        //Get specific attendance record
        public Attendance GetAttendance(int Id)
        {
            var attendance = _context.Attendances.SingleOrDefault(a => a.AttendanceID == Id);

            if (attendance == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return attendance;
        }

        //POST /api/attendances
        //Create new attendance
        [HttpPost]
        public Attendance CreateAttendance(Attendance attendance)
        {
            
            _context.Attendances.Add(attendance);
            _context.SaveChanges();

            return attendance;
        }

        //PUT /api/attendances/id
        //Update existing attendance
        [HttpPut]
        public void UpdateAttendance(int Id, Attendance attendance)
        {
            

            var attendanceInDb = _context.Attendances.SingleOrDefault(a => a.AttendanceID == Id);

            if (attendanceInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            attendanceInDb.ModuleID = attendance.ModuleID;
            attendanceInDb.StudentID = attendance.StudentID;
            attendanceInDb.Present = attendance.Present;
            attendanceInDb.AttendanceDateTime = attendance.AttendanceDateTime;
            attendanceInDb.AttendanceID = attendance.AttendanceID;

            _context.SaveChanges();

        }

        //DELETE /api/attendances/1
        //Delete an attendance
        [HttpDelete]
        public void DeleteAttendance(int Id)
        {
            var attendanceInDb = _context.Attendances.SingleOrDefault(a => a.AttendanceID == Id);

            if (attendanceInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Attendances.Remove(attendanceInDb);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}