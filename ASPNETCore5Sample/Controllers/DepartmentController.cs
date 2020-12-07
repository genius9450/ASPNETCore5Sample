using Microsoft.AspNetCore.Mvc;
using ASPNETCore5Sample.Models;
using ASPNETCore5Sample.ViewModels.Departments;

namespace ASPNETCore5Sample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : BaseCRUDController<Department, int, CreateDepartmentModel, UpdateDepartmentModel>
    {
        public DepartmentController(ContosoUniversityContext db)
            : base(db)
        {
        }

    }
}