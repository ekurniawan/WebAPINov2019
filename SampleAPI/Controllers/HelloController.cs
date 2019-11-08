using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleAPI.Models;

namespace SampleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelloController : ControllerBase
    {
        List<Student> lstStudent;
        public HelloController()
        {
            lstStudent = new List<Student>
            {
                new Student{StudentID=1,FirstName="Erick",LastName="Kurniawan"},
                new Student{StudentID=2,FirstName="Budi",LastName="Anduk" },
                new Student{StudentID=3,FirstName="Joko",LastName="Purwadi"}
            };
        }

        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return lstStudent;
        }

        //menambahkan post
        [HttpPost]
        public IActionResult Post(Student student)
        {
            lstStudent.Add(student);
            return StatusCode(201, student);
        } 

        [HttpGet]
        [Route("{id}")]
        public Student Get(int id)
        {
            var result = lstStudent.Where(s => s.StudentID == id).FirstOrDefault();
            return result;
        }

        [HttpGet]
        [Route("GetData")]
        public string GetData()
        {
            return "Hello World";
        }
    }
}