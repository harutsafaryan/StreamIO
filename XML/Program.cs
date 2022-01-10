using Microsoft.Extensions.DependencyInjection;
using Models;
using Models.Context;
using Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML
{
    class Program
    {
        static void Main(string[] args)
        {
            Teacher teacher1 = new Teacher
            {
                FirstName = "Anahit",
                LastName = "Karapetyan",
                Age = 60
            };

            Teacher teacher2 = new Teacher
            {
                FirstName = "Vardan",
                LastName = "Simonyan",
                Age = 48
            };

            Student student1 = new Student
            {
                FirstName = "Simon",
                LastName = "Martirosyan",
                Age = 55,
                TeacherId = teacher1.Id
            };
            
            Student student2 = new Student
            {
                FirstName = "Karen",
                LastName = "vardanyan",
                Age = 35,
                TeacherId = teacher2.Id
            };

            IPath teacherPath = new Models.Context.Path(@"C:\University", "teacher");
            IPath studentPath = new Models.Context.Path(@"C:\University", "student");

            StudentService studentService = new StudentService(studentPath);
            studentService.Add(student1);
            studentService.Add(student2);

            TeacherService teacherService = new TeacherService(teacherPath);
            teacherService.Add(teacher1);
            teacherService.Add(teacher2);
            teacherService.Get(teacher1.Id);

            teacher1.Age = 28;
            teacherService.Update(teacher1);

            List<Student> students = studentService.GetAll();
            List<Teacher> teachers = teacherService.GetAll();
        }
    }
}
