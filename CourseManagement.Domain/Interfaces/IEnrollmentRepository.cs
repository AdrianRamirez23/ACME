using CourseManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Domain.Interfaces
{
    public interface IEnrollmentRepository
    {
        void Add(Enrollment enrollment);
        List<Enrollment> GetAll();
        List<Enrollment> GetByDateRange(DateTime from, DateTime to);
    }
}
