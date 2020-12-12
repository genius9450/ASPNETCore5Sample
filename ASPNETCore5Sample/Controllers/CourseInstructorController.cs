using Microsoft.AspNetCore.Mvc;
using ASPNETCore5Sample.Models;
using ASPNETCore5Sample.ViewModels.CourseInstructor;
using System.Collections.Generic;
using System.Linq;
using Omu.ValueInjecter;
using Microsoft.AspNetCore.Http;

namespace ASPNETCore5Sample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseInstructorController : ControllerBase
    {
        private readonly ContosoUniversityContext _db;
        public CourseInstructorController(ContosoUniversityContext db)
        {
            this._db = db;
        }

        /// <summary>
        /// 取得所有資料
        /// </summary>
        /// <returns></returns>
        [HttpGet("")]
        public ActionResult<IEnumerable<CourseInstructor>> GetEntitys()
        {
            return _db.CourseInstructor.ToList();
        }

        /// <summary>
        /// 取得單筆資料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{courseId}/{instructorId}")]
        public ActionResult<CourseInstructor> GetEntityById(int courseId, int instructorId)
        {
            return _db.CourseInstructor.Find(courseId, instructorId);
        }

        /// <summary>
        /// 新增單筆資料
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        public virtual ActionResult PostEntity(CreateOrUpdateCourseInstructorModel model)
        {
            CourseInstructor addEntity = new CourseInstructor();
            addEntity.InjectFrom(model);
            _db.Add(addEntity);

            _db.SaveChanges();
            
            return Created("api/CourseInstructor", addEntity);
        }

        /// <summary>
        /// 刪除單筆資料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{courseId}/{instructorId}")]
        public ActionResult DeleteEntityById(int courseId, int instructorId)
        {
            var delEntity = _db.CourseInstructor.Find(courseId, instructorId);
            _db.Remove(delEntity);

            _db.SaveChanges();

            return Ok();
        }

    }
}