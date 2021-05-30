using System;

namespace webapi1.ViewModel
{
    public class DepartmentRead
    {        
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public DateTime StartDate { get; set; }
        public int? InstructorId { get; set; }
        public string InstructorName { get; set; }
    }
}