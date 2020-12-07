using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore5Sample.ViewModels.Enrollments
{
    public class CreateOrUpdateEnrollmentModel
    {
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public int? Grade { get; set; }
    }
}
