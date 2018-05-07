using Rad302Autumn2017.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Rad302Autumn2017.DAL;

namespace Rad302Autumn2017.Controllers.API
{
    public class AttendancesController : ApiController
    {
        //private AppDBContext _context;
        private IAttendanceRepository _context;


        public AttendancesController()
        {
            _context = new AttendanceRepositoryEF(new AppDBContext());
            //_context = new AppDBContext();
        }

        //Get /API/attendances
        //Returns all students
        public IEnumerable<Attendance> GetAttendances()
        {
            // return _context.Attendances.ToList();
            return _context.GetAttendances();
        }

        //GET /api/attendances/id
        //Get specific attendance record
        public Attendance GetAttendance(int Id)
        {
            //var attendance = _context.Attendances.SingleOrDefault(a => a.AttendanceID == Id);

            //if (attendance == null)
            //{
            //    throw new HttpResponseException(HttpStatusCode.NotFound);
            //}

            //return attendance;
            return _context.GetAttendance(Id);
        }

        //POST /api/attendances
        //Create new attendance
        [HttpPost]
        public Attendance CreateAttendance(Attendance attendance)
        {
            //if (!ModelState.IsValid)
            //{
            //    throw new HttpResponseException(HttpStatusCode.BadRequest);
            //}
            //_context.Attendances.Add(attendance);
            //_context.SaveChanges();

            //return attendance;
            return _context.CreateAttendance(attendance);
        }

        //PUT /api/attendances/id
        //Update existing attendance
        [HttpPut]
        public void UpdateAttendance(int Id, Attendance attendance)
        {
            //if (!ModelState.IsValid)
            //{
            //    throw new HttpResponseException(HttpStatusCode.BadRequest);
            //}

            //var attendanceInDb = _context.Attendances.SingleOrDefault(a => a.AttendanceID == Id);

            //if (attendanceInDb == null)
            //{
            //    throw new HttpResponseException(HttpStatusCode.NotFound);
            //}

            //attendanceInDb.ModuleID = attendance.ModuleID;
            //attendanceInDb.StudentID = attendance.StudentID;
            //attendanceInDb.Present = attendance.Present;
            //attendanceInDb.AttendanceDateTime = attendance.AttendanceDateTime;
            //attendanceInDb.AttendanceID = attendance.AttendanceID;

            //_context.SaveChanges();
            _context.UpdateAttendance(Id, attendance);

        }

        //DELETE /api/attendances/1
        //Delete an attendance
        [HttpDelete]
        public void DeleteAttendance(int Id)
        {
            //var attendanceInDb = _context.Attendances.SingleOrDefault(a => a.AttendanceID == Id);

            //if (attendanceInDb == null)
            //{
            //    throw new HttpResponseException(HttpStatusCode.NotFound);
            //}

            //_context.Attendances.Remove(attendanceInDb);
            //_context.SaveChanges();
            _context.DeleteAttendance(Id);
        }
    }
}
