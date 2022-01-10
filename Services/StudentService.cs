using Models;
using Models.Context;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class StudentService : BaseService<Student>, IStudentService
    {
        private readonly IPath _path;
        public StudentService(IPath path) : base(path)
        {
            _path = path;
        }

        public override Student Get(Guid id)
        {
            using (StreamReader stream = new StreamReader(_path.MainFile.FullName, System.Text.Encoding.Default))
            {
                string line;
                while ((line = stream.ReadLine()) != null)
                {
                    string[] words = line.Split(' ');
                    if (words[0] == id.ToString())
                    {
                        Student student = new Student()
                        {
                            Id = Guid.Parse(words[0].Remove(0, 1)),
                            LastName = words[1],
                            FirstName = words[2],
                            Age = int.Parse(words[3]),
                            TeacherId = Guid.Parse(words[4])
                        };
                        return student;
                    }
                }
                return null;
            }
        }

        public override List<Student> GetAll()
        {
            List<Student> students = new List<Student>();
            using (StreamReader stream = new StreamReader(_path.MainFile.FullName, System.Text.Encoding.Default))
            {
                string line;
                while ((line = stream.ReadLine()) != null)
                {
                    string[] words = line.Split(' ');
                    Student student = new Student()
                    {
                        Id = Guid.Parse(words[0]),
                        LastName = words[1],
                        FirstName = words[2],
                        Age = int.Parse(words[3]),
                        TeacherId = Guid.Parse(words[4])
                    };
                    students.Add(student);
                }
                return students;
            }
        }

        public void Remove(Student model)
        {
            throw new NotImplementedException();
        }

        public void Update(Student model)
        {
           
        }
    }
}
