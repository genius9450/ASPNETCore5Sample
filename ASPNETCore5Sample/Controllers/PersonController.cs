using Microsoft.AspNetCore.Mvc;
using ASPNETCore5Sample.Models;
using ASPNETCore5Sample.ViewModels.Persons;

namespace ASPNETCore5Sample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : BaseCRUDController<Person, int, CreatePersonModel, UpdatePersonModel>
    {
        public PersonController(ContosoUniversityContext db)
            : base(db)
        {
        }

    }
}
