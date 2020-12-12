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
        public CourseController(ContosoUniversityContext db)
            :base(db)
        {
            this.PKeyName = "CourseId";
        }

        [HttpGet("GetError")]
        public void GetError()
        {
            throw new Exception("發生例外錯誤Here");
        }

        /// <summary>
        /// 取得課程學生資料
        /// </summary>
        /// <returns></returns>
        [HttpGet("Student/{id}")]
        public ActionResult<IEnumerable<VwCourseStudents>> GetCourseStudents(int id)
        {
            return _db.VwCourseStudents.Where(x => x.CourseId == id).ToList();
        }

        /// <summary>
        /// 取得課程學生數量資料
        /// </summary>
        /// <returns></returns>
        [HttpGet("StudentCount/{id}")]
        public ActionResult<IEnumerable<VwCourseStudentCount>> GetCourseStudentCounts(int id)
        {
            return _db.VwCourseStudentCount.Where(x => x.CourseId == id).ToList();
        }

    }
}