using CourseManagement.Domain.Entities;
using CourseManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Infrastructure.Persistence
{
    public class InMemoryEnrollmentRepository : IEnrollmentRepository
    {
        private readonly List<Enrollment> _enrollments = new List<Enrollment>();

        public void Add(Enrollment enrollment) => _enrollments.Add(enrollment);

        public List<Enrollment> GetAll() => _enrollments;

        public List<Enrollment> GetByDateRange(DateTime from, DateTime to)
        {
            return _enrollments
                .Where(e => e.Course.StartDate >= from && e.Course.EndDate <= to)
                .ToList();
        }
    }
}
