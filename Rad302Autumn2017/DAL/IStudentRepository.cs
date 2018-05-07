using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rad302Autumn2017.Models;

namespace Rad302Autumn2017.DAL
{
    public interface IStudentRepository : IDisposable
    {
        IEnumerable<Student> GetStudents();
        Student GetStudent(string Id);
        Student CreateStudent(Student student);
        void UpdateStudent(string Id, Student student);
        void DeleteStudent(string Id);

    }
}