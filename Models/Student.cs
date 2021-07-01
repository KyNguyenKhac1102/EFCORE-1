using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.Models{
    [Table("Student")]
    public class Student{
        [Key]
        public Guid StudentID {get; set;}

        public string FristName {get; set;}
        public string LastName {get; set;}
        public string City {get; set;}
        public string State {get; set;}
        public string FullName(){
            return $"{FristName} {LastName}";
        }
        // [ForeignKey("Class")]
        // public Guid ClassId {get; set;}
    }
}