using System;
using System.Collections.Generic;
using System.Linq;
using EFCore.Models;

namespace EFCore.Services{
    public class StudentService : IStudentService
    {
        private readonly StudentContext _studentContext;

        public StudentService(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }
        public List<Student> getAll()
        {
            return _studentContext.Student.ToList();
        }

        public void Update(Guid id, Student student)
        {
            var studentUpdate = _studentContext.Student.Find(id);
            studentUpdate.FristName = student.FristName;
            studentUpdate.LastName = student.LastName;
            studentUpdate.City = student.City;
            studentUpdate.State = student.State;
            _studentContext.SaveChanges();
        }
        public void Create(Student student)
        {
            student.StudentID = Guid.NewGuid();
            _studentContext.Student.Add(student);
            _studentContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var deleteStudent = _studentContext.Student.Find(id);
            _studentContext.Remove(deleteStudent);
            _studentContext.SaveChanges();
        }

        public List<Student> Filter(string fname, string lname,string city)
        {
            // Can't translate to query in database because  method  could not translate to query
            // List<Student> qualifyStudent = _studentContext.Student.Where(x => (x.FristName.Equals(name, StringComparison.CurrentCultureIgnoreCase) || x.LastName.Equals(name, StringComparison.CurrentCultureIgnoreCase)) && x.City.Equals(city, StringComparison.CurrentCultureIgnoreCase)).ToList();

            //auto case insensitive
            List<Student> qualifyStudent = _studentContext.Student.Where(x => (x.FristName == fname) && (x.LastName == lname) && x.City == city).ToList();
            return qualifyStudent;
        }
    }
}