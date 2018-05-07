using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rad302Autumn2017.Models;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Net;
using Rad302Autumn2017.DAL;

namespace Rad302Autumn2017.DAL
{
    public class StudentRepositoryEF : IStudentRepository
    {
        private AppDBContext _context;


        public StudentRepositoryEF(AppDBContext context)
        {
            _context = context;
            //_context = new AppDBContext();
        }

        //Get /API/students
        //Returns all students
        public IEnumerable<Student> GetStudents()
        {
            return _context.Students.ToList();
        }

        //GET /api/students/id
        //Get specific student
        public Student GetStudent(string Id)
        {
            var student = _context.Students.SingleOrDefault(s => s.StudentID == Id);

            if (student == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return student;
        }

        //POST /api/students
        //Create new student
        [HttpPost]
        public Student CreateStudent(Student student)
        {
            
            _context.Students.Add(student);
            _context.SaveChanges();

            return student;
        }

        //PUT /api/students/id
        //Update existing student
        [HttpPut]
        public void UpdateStudent(string Id, Student student)
        {
            
            var studentInDB = _context.Students.SingleOrDefault(s => s.StudentID == Id);

            if (studentInDB == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            studentInDB.FirstName = student.FirstName;
            studentInDB.SecondName = student.SecondName;
            studentInDB.StudentID = student.StudentID;

            _context.SaveChanges();

        }

        //DELETE /api/students/1
        //Delete a student
        [HttpDelete]
        public void DeleteStudent(string Id)
        {
            var studentInDB = _context.Students.SingleOrDefault(s => s.StudentID == Id);

            if (studentInDB == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Students.Remove(studentInDB);
            _context.SaveChanges();
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}