using System;
using System.Collections.Generic;
using EFCore.Models;

namespace EFCore.Services{
    public interface IStudentService{
        List<Student> getAll();
        void Update(Guid id, Student student);
        void Create(Student student);
        
        void Delete(Guid id);
        List<Student> Filter(string fname, string lname ,string city);
    }
}