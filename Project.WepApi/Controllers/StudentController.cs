using Core.Utilities.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project.Business.Abstract;
using Project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.WepApi.Controllers
{
    [Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    public class StudentController : ControllerBase
    {
        private IStudentService studentService;


        public StudentController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpGet]
        public IDataResult<List<Student>> Get()
        {

            return studentService.GetAll();
        }
        [HttpPost]
        public IResult Add(Student student)
        {

            return studentService.Add(student);
        }
    }
}
