using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore5Sample.ViewModels.Departments
{
    public class CreateDepartmentModel
    {
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public decimal Budget { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public int? InstructorId { get; set; }
    }
}
