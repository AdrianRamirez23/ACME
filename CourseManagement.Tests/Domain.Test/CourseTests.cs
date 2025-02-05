using CourseManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Tests.Domain.Test
{
    public class CourseTests
    {
        [Fact]
        public void Should_Create_Course_With_Valid_Dates()
        {
            var course = new Course("Math", 100, DateTime.Today, DateTime.Today.AddDays(30));
            Assert.Equal("Math", course.Name);
        }

        [Fact]
        public void Should_Throw_Exception_When_StartDate_Is_After_EndDate()
        {
            Assert.Throws<ArgumentException>(() => new Course("Science", 100, DateTime.Today.AddDays(30), DateTime.Today));
        }
    }
}
