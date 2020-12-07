using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASPNETCore5Sample.Models;
using ASPNETCore5Sample.Controllers;
using ASPNETCore5Sample.ViewModels.Courses;
using Omu.ValueInjecter;

namespace ASPNETCore5Sample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : BaseCRUDController<Course, int, CreateCourseModel, UpdateCourseModel>
    {
        private readonly ContosoUniversityContext _db;
        public CourseController(ContosoUniversityContext db)
            :base(db)
        {
            this._db = db;
        }

        ///// <summary>
        ///// 新增單筆資料
        ///// </summary>
        ///// <param name="model"></param>
        ///// <returns></returns>
        //[HttpPost("")]
        //public override ActionResult<Course> PostEntity(CreateCourseModel model)
        //{
        //    var addEntity = new Course();
        //    addEntity.InjectFrom(model);
        //    addEntity.CourseInstructor = model.CourseInstructor.Select(x => new CourseInstructor() { InstructorId = x.InstructorId }).ToList();
        //    addEntity.Enrollment = model.Enrollment.Select(x => new Enrollment() { StudentId = x.StudentId, Grade = x.Grade }).ToList();

        //    _db.Add(addEntity);

        //    _db.SaveChanges();

        //    return Created("api/Course", addEntity);
        //}

        ///// <summary>
        ///// 更新單筆資料
        ///// </summary>
        ///// <param name="id"></param>
        ///// <param name="model"></param>
        ///// <returns></returns>
        //[HttpPut("{id}")]
        //public override IActionResult PutEntity(int id, UpdateCourseModel model)
        //{
        //    var updateEntity = _db.Course.Find(id);
        //    updateEntity.InjectFrom(model);
        //    updateEntity.CourseInstructor = model.CourseInstructor.Select(x => new CourseInstructor() { InstructorId = x.InstructorId }).ToList();
        //    updateEntity.Enrollment = model.Enrollment.Select(x=> new Enrollment() { StudentId = x.StudentId, Grade = x.Grade }).ToList();

        //    _db.SaveChanges();

        //    return NoContent();
        //}

    }
}