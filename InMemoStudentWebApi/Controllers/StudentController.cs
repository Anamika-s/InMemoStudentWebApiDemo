using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InMemoStudentWebApi.Models;

namespace InMemoStudentWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
       static List<Student> listStudents = null;
       public StudentController()
        {
            if(listStudents==null)
            {
                listStudents = new List<Student>()
                {
                                       new Student(){ StudentId=1, Name="Aashna", Batch="DotNet", Marks=90, DateOfBirth=Convert.ToDateTime("12/12/2000")},

                    new Student(){ StudentId=2, Name="Priynaka", Batch="DotNet", Marks=87, DateOfBirth=Convert.ToDateTime("12/12/2000")},
                    new Student(){ StudentId=3, Name="Tisha", Batch="SAP", Marks=98,DateOfBirth=Convert.ToDateTime("12/12/2000")},
                    new Student(){ StudentId=4, Name="Naveen", Batch="SAP", Marks=90,DateOfBirth=Convert.ToDateTime("12/12/2000")},
                    new Student(){ StudentId=5, Name="Siddhant", Batch="DotNet", Marks=90,DateOfBirth=Convert.ToDateTime("12/12/2000")},
                    new Student(){ StudentId=6, Name="Vaibhav", Batch="DotNet", Marks=90,DateOfBirth=Convert.ToDateTime("12/12/2000")},


                };
            }
        }
        // Get - All Records
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return listStudents.ToList();
        }

        // Get - One Record 
        [HttpGet]
        [Route("{id:int}")]
        public Student Get(int id)
        {
            //var student = (from x in listStudents
            //               where x.StudentId == id
            //               select x).FirstOrDefault();

            return listStudents.FirstOrDefault(x => x.StudentId == id);
        }

        [HttpPost]
        public void Post(Student student)
        {
            listStudents.Add(student);
        }
        [HttpDelete]
        [Route("{id:int}")]
        public void Delete(int id)
        {
            var student = listStudents.FirstOrDefault(x => x.StudentId == id);
            if(student!=null)
            {
                listStudents.Remove(student);
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        public void Put(int id, Student obj)
        {
            var student = listStudents.FirstOrDefault(x => x.StudentId == id);
            if(student!=null)
            {
                foreach(var temp in listStudents)
                {
                    if(temp.StudentId==id)
                    {
                        temp.Batch = obj.Batch;
                        temp.Marks = obj.Marks;
                        break;
                    }
                }
            }
        }

    }
}
