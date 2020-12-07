using Microsoft.AspNetCore.Mvc;
using ASPNETCore5Sample.Models;
using ASPNETCore5Sample.ViewModels.OfficeAssignments;

namespace ASPNETCore5Sample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficeAssignmentController : BaseCRUDController<OfficeAssignment, int, CreateOfficeAssignmentModel, UpdateOfficeAssignmentModel>
    {
        public OfficeAssignmentController(ContosoUniversityContext db)
            : base(db)
        {
        }

    }
}