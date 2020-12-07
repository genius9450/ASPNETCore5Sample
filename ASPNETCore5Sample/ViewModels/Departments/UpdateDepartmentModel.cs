using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore5Sample.ViewModels.Departments
{
    public class UpdateDepartmentModel
    {
        public string Name { get; set; }
        public decimal Budget { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public int? InstructorId { get; set; }
    }
}
