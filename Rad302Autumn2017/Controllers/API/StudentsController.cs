using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Rad302Autumn2017.Models;
using Rad302Autumn2017.DAL;
using System.Web.Http.Cors;

namespace Rad302Autumn2017.Controllers.API
{
    [RoutePrefix("api/students")]
    [EnableCors("http://localhost:49618/", "*", "*")]
    public class StudentsController : ApiController
    {
        //private AppDBContext _context;
        private IStudentRepository _context;

        public StudentsController()
        {
            _context = new StudentRepositoryEF(new AppDBContext());
            //_context = new AppDBContext();
        }

        //Get /API/students
        //Returns all students
        public IEnumerable<Student> GetStudents()
        {
            return _context.GetStudents();
            //return _context.Students.ToList();
        }

        //GET /api/students/id
        //Get specific student
        public Student GetStudent(string Id)
        {
            //var student = _context.Students.SingleOrDefault(s => s.StudentID == Id);

            //if (student == null)
            //{
            //    throw new HttpResponseException(HttpStatusCode.NotFound);
            //}

            return _context.GetStudent(Id);
        }

        //POST /api/students
        //Create new student
        [HttpPost]
        public Student CreateStudent(Student student)
        {
            //if (!ModelState.IsValid)
            //{
            //    throw new HttpResponseException(HttpStatusCode.BadRequest);
            //}
            //_context.Students.Add(student);
            //_context.SaveChanges();

            return _context.CreateStudent(student);
        }

        //PUT /api/students/id
        //Update existing student
        [HttpPut]
        public void UpdateStudent(string Id, Student student)
        {
            //if (!ModelState.IsValid)
            //{
            //    throw new HttpResponseException(HttpStatusCode.BadRequest);
            //}

            //var studentInDB = _context.Students.SingleOrDefault(s => s.StudentID == Id);

            //if (studentInDB == null)
            //{
            //    throw new HttpResponseException(HttpStatusCode.NotFound);
            //}

            //studentInDB.FirstName = student.FirstName;
            //studentInDB.SecondName = student.SecondName;
            //studentInDB.StudentID = student.StudentID;

            //_context.SaveChanges();

            _context.UpdateStudent(Id, student);

            //return _context.UpdateStudent(Id, student);

        }

        //DELETE /api/students/1
        //Delete a student
        [HttpDelete]
        public void DeleteStudent(string Id)
        {
            //var studentInDB = _context.Students.SingleOrDefault(s => s.StudentID == Id);

            //if (studentInDB == null)
            //{
            //    throw new HttpResponseException(HttpStatusCode.NotFound);
            //}

            //_context.Students.Remove(studentInDB);
            //_context.SaveChanges();

            _context.DeleteStudent(Id);

        }



    }
}
