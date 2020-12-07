using Microsoft.AspNetCore.Mvc;
using ASPNETCore5Sample.Models;
using ASPNETCore5Sample.ViewModels.Departments;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ASPNETCore5Sample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : BaseCRUDController<Department, int, CreateDepartmentModel, UpdateDepartmentModel>
    {
        private readonly ContosoUniversityContextProcedures _procedures;
        public DepartmentController(ContosoUniversityContext db,
            ContosoUniversityContextProcedures procedures)
            : base(db)
        {
            _procedures = procedures;
        }

        /// <summary>
        /// 新增單筆資料
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("")]
        public override ActionResult<Department> PostEntity(CreateDepartmentModel model)
        {
            OutputParameter<int> returnValue = new OutputParameter<int>();
            var output = _procedures.Department_Insert(model.Name, model.Budget, model.StartDate, model.InstructorId, returnValue).GetAwaiter().GetResult();

            return Created("api/Department", output);
        }

        /// <summary>
        /// 更新單筆資料
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public override ActionResult PutEntity(int id, UpdateDepartmentModel model)
        {
            var updateEntity = _db.Department.Find(id);

            OutputParameter<int> returnValue = new OutputParameter<int>();
            _procedures.Department_Update(id, model.Name, model.Budget, model.StartDate, model.InstructorId, updateEntity.RowVersion, returnValue).GetAwaiter().GetResult();

            return NoContent();
        }

        /// <summary>
        /// 刪除單筆資料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public override ActionResult<Department> DeleteEntityById(int id)
        {
            var del = _db.Department.Find(id);

            OutputParameter<int> returnValue = new OutputParameter<int>();
            _procedures.Department_Delete(id, del.RowVersion, returnValue).GetAwaiter().GetResult();

            return Ok();
        }

        /// <summary>
        /// 取得部門課程數量
        /// </summary>
        /// <returns></returns>
        [HttpGet("CourseCount/{id}")]
        public async Task<ActionResult<IEnumerable<VwDepartmentCourseCount>>> GetCourseCounts(int id)
        {            
            return await _db.VwDepartmentCourseCount.FromSqlInterpolated($"SELECT * FROM vwDepartmentCourseCount WHERE DepartmentID = {id}").ToListAsync();            
        }

    }
}