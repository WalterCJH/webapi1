using System;
using System.Collections.Generic;

#nullable disable

namespace webapi1.Models
{
    public partial class VwCourseStudent
    {
        public int? DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int CourseId { get; set; }
        public string CourseTitle { get; set; }
        public int? StudentId { get; set; }
        public string StudentName { get; set; }
    }
}
