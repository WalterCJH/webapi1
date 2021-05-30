using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Omu.ValueInjecter;
using webapi1.Models;
using webapi1.Services;
using webapi1.ViewModel;

namespace webapi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class DepartmentController : ControllerBase
    {
        private readonly ContosoUniversityContext db;
        // private readonly IMyService svc;
        // private readonly IMyService svc2;
        // private readonly IMyServiceSingleton svcs;

        public DepartmentController(ContosoUniversityContext db
        // , MyService svc, MyService2 svc2
        // ,IMyServiceSingleton svcs
        )
        {
            // this.svc = svc;
            // this.svc2 = svc2;
            // this.svcs = svcs;
            this.db = db;
        }

        // [HttpGet("getMyService")]
        // public ActionResult<string> GetMyService()
        // {
        //     return svc.Name;
        // }

        // [HttpGet("getMyService2")]
        // public ActionResult<string> GetMyService2()
        // {
        //     return svc2.Name;
        // }

        // [HttpGet("getMyServiceSingleton")]
        // public ActionResult<string> GetIServiceSingleton()
        // {

        //     return svcs.Name;
        // }

        [HttpGet("", Name = nameof(GetDepartments))]
        public ActionResult<IEnumerable<Department>> GetDepartments()
        {
            return db.Departments;
        }

        [HttpGet("{id}", Name = nameof(GetDepartmentById))]
        public ActionResult<DepartmentRead> GetDepartmentById(int id)
        {
            var dept = db.Departments.Find(id);

            if (dept == null)
            {
                return NotFound();
            }


            // db.Entry(dept).Collection(x => x.Courses).Load();
            db.Entry(dept).Reference(x => x.Instructor).Load();

            var result = (new DepartmentRead()).InjectFrom(dept) as DepartmentRead;

            result.InstructorName = $"{dept.Instructor?.FirstName} {dept.Instructor?.LastName}";

            return result;
        }

        [HttpPost("", Name = nameof(PostDepartment))]
        public ActionResult<Department> PostDepartment(Department model)
        {
            return null;
        }

        [HttpPut("{id}", Name = nameof(PutDepartment))]
        public IActionResult PutDepartment(int id, Department model)
        {
            return NoContent();
        }

        [HttpDelete("{id}", Name = nameof(DeleteDepartmentById))]
        public ActionResult<Department> DeleteDepartmentById(int id)
        {
            return null;
        }
    }
}