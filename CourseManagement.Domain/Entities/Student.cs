namespace CourseManagement.Domain.Entities
{
    public class Student
    {
        public string Name { get; }
        public int Age { get; }

        public Student(string name, int age)
        {
            if (age < 18) throw new ArgumentException("Only adults can register.");
            Name = name;
            Age = age;
        }
    }
}
