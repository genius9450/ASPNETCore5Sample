﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Newtonsoft.Json;
using System;
using System.Collections.Generic;


namespace ASPNETCore5Sample.Models
{
    public partial class CourseInstructor
    {
        public int CourseId { get; set; }
        public int InstructorId { get; set; }

        [JsonIgnore]
        public virtual Course Course { get; set; }
        [JsonIgnore]
        public virtual Person Instructor { get; set; }
    }
}