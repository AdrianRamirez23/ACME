using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Domain.Entities
{
    public class Course
    {
        public string Name { get; }
        public decimal RegistrationFee { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }

        public Course(string name, decimal fee, DateTime startDate, DateTime endDate)
        {
            if (startDate >= endDate)
                throw new ArgumentException("Start date must be before end date.");

            Name = name;
            RegistrationFee = fee;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
