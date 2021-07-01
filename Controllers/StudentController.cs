using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EFCore.Services;
using EFCore.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            
            _studentService = studentService;
        }


        [HttpGet]
        public List<Student> Students(){
            List<Student> studentList = _studentService.getAll();
            return studentList;
        }


        [HttpPost]
        public List<Student> Students(Student student){
            _studentService.Create(student);
            return _studentService.getAll();
        }

        [HttpPut("{id}")]
        public List<Student> Students(Guid id, Student student){
            _studentService.Update(id, student);
            return _studentService.getAll();
        }

        [HttpDelete("{id}")]
        public List<Student> Students(Guid id){
            _studentService.Delete(id);
            return _studentService.getAll();
        }
        
        [HttpGet("{fristname}/{lastname}/{city}")]
        public List<Student> Students(string fristname, string lastname,string city){
            List<Student> list = _studentService.Filter(fristname, lastname,city);
            return list;
        }
    }
}
