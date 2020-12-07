﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore5Sample.ViewModels.Persons
{
    public class CreatePersonModel
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime? HireDate { get; set; }
        public DateTime? EnrollmentDate { get; set; }
        public string Discriminator { get; set; }
    }
}
