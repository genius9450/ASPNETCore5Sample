﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore5Sample.ViewModels.Courses
{
    public class CreateCourseModel
    {
        public string Title { get; set; }
        public int Credits { get; set; }
        public int DepartmentId { get; set; }

        //public List<CourseInstrutorModel> CourseInstructor { get; set; }
        //public List<EnrollmentModel> Enrollment { get; set; }
    }
}
