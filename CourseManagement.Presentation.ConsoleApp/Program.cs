using CourseManagement.Application.Services;
using CourseManagement.Domain.Entities;
using CourseManagement.Infrastructure.PaymentGateway;

class Program
{
    static void Main()
    {
        var paymentService = new FakePaymentService();
        var enrollmentService = new EnrollmentService(paymentService);
        var students = new List<Student>();
        var courses = new List<Course>();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Gestión de Cursos ACME ===");
            Console.WriteLine("1. Registrar estudiante");
            Console.WriteLine("2. Registrar curso");
            Console.WriteLine("3. Inscribir estudiante en curso");
            Console.WriteLine("4. Listar cursos y estudiantes");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.Write("Ingrese nombre del estudiante: ");
                    string studentName = Console.ReadLine();
                    Console.Write("Ingrese edad del estudiante: ");
                    int age = int.Parse(Console.ReadLine());

                    try
                    {
                        var student = new Student(studentName, age);
                        students.Add(student);
                        Console.WriteLine("Estudiante registrado exitosamente.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                    break;

                case "2":
                    Console.Write("Ingrese nombre del curso: ");
                    string courseName = Console.ReadLine();
                    Console.Write("Ingrese tarifa de inscripción: ");
                    decimal fee = decimal.Parse(Console.ReadLine());
                    Console.Write("Ingrese fecha de inicio (yyyy-mm-dd): ");
                    DateTime startDate = DateTime.Parse(Console.ReadLine());
                    Console.Write("Ingrese fecha de finalización (yyyy-mm-dd): ");
                    DateTime endDate = DateTime.Parse(Console.ReadLine());

                    try
                    {
                        var course = new Course(courseName, fee, startDate, endDate);
                        courses.Add(course);
                        Console.WriteLine("Curso registrado exitosamente.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                    break;

                case "3":
                    Console.WriteLine("Seleccione un estudiante:");
                    for (int i = 0; i < students.Count; i++)
                        Console.WriteLine($"{i + 1}. {students[i].Name}");

                    int studentIndex = int.Parse(Console.ReadLine()) - 1;
                    Console.WriteLine("Seleccione un curso:");
                    for (int i = 0; i < courses.Count; i++)
                        Console.WriteLine($"{i + 1}. {courses[i].Name}");

                    int courseIndex = int.Parse(Console.ReadLine()) - 1;

                    var enrolled = enrollmentService.Enroll(students[studentIndex], courses[courseIndex]);
                    Console.WriteLine(enrolled ? "Inscripción exitosa." : "Error en la inscripción.");
                    break;

                case "4":
                    Console.WriteLine("Listado de cursos y estudiantes inscritos:");
                    var result = enrollmentService.GetCoursesWithEnrollments(DateTime.MinValue, DateTime.MaxValue);
                    foreach (var (course, enrolledStudents) in result)
                    {
                        Console.WriteLine($"Curso: {course.Name} - Inscritos: {string.Join(", ", enrolledStudents.ConvertAll(s => s.Name))}");
                    }
                    break;

                case "5":
                    return;

                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }

            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
        }
    }
}