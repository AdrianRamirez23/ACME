using CourseManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Tests.Domain.Test
{
    public class StudentTests
    {
        [Fact]
        public void Should_Create_Student_When_Age_Is_Valid()
        {
            var student = new Student("John Doe", 20);
            Assert.Equal("John Doe", student.Name);
            Assert.Equal(20, student.Age);
        }

        [Fact]
        public void Should_Throw_Exception_When_Age_Is_Less_Than_18()
        {
            Assert.Throws<ArgumentException>(() => new Student("Jane Doe", 17));
        }
    }
}
