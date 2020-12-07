using Microsoft.AspNetCore.Mvc;
using ASPNETCore5Sample.Models;
using ASPNETCore5Sample.ViewModels.Enrollments;

namespace ASPNETCore5Sample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : BaseCRUDController<Enrollment, int, CreateOrUpdateEnrollmentModel, CreateOrUpdateEnrollmentModel>
    {
        public EnrollmentController(ContosoUniversityContext db)
            : base(db)
        {
        }

    }
}