using Indivuellt_projekt_Databas.Models;

namespace Indivuellt_projekt_Databas
{
    
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }
        static void Menu()
        {
            Console.WriteLine("What do you want to do? \n 1. Show teachers in the departments\n 2. Show student information\n 3. Show active courses");
            switch (Console.ReadLine())
            {
                case "1":
                    DepartmentEmployees();
                    break;
                    case "2":
                    StudentInfo();
                    break;
                case "3":
                    ActiveCourses();
                    break;
            }
        }
        static void DepartmentEmployees()
        {
            var context = new HighschoolDbContext();
            var departments = context.Departments;
            for (int i = 1; i <= departments.Count(); i++)
            {
                var DepartmentName = context.Departments
                    .Where(x => x.DepartmentId == i)
                    .Select(x => x.Department1)
                    .FirstOrDefault();

                var Teachers = context.Employees
                              .Where(x => x.Title == "Teacher")
                              .Where(x => x.DepartmentId == i);

                Console.WriteLine($"\n Department: {DepartmentName}\n Teachers in the department: {Teachers.Count()}");
                foreach(var item in Teachers)
                {
                    Console.WriteLine($" {item.Fname} {item.Lname}");
                }
            }
            Console.ReadKey();
            Console.Clear();
            Menu();
        }
        static void StudentInfo()
        {
            var context = new HighschoolDbContext();
            var students = from s in context.Students
                           join c in context.Classes on s.ClassId equals c.ClassId
                           orderby s.StudentId
                           select new
                           {
                               StudID = s.StudentId,
                               Name = s.Fname + " " + s.Lname,
                               SSN = s.Ssn,
                               Class = c.Class1
                           };
            foreach(var item in students)
            {
                Console.WriteLine($"\n ID: {item.StudID} Name: {item.Name} SSN:{item.SSN} Class: {item.Class}");
            }
            Console.ReadKey();
            Console.Clear();
            Menu();
        }
        static void ActiveCourses()
        {
            var context = new HighschoolDbContext();
            var courses = context.Courses;
            foreach(var item in courses)
            {
                Console.WriteLine(item.Course1);
            }
            Console.ReadKey();
            Console.Clear();
            Menu();
        }
    }
}