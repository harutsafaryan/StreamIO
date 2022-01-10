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
            using (FileStream stream = new FileStream(_path.MainFile.FullName, FileMode.OpenOrCreate))
            {
                StringBuilder studentString = new StringBuilder();
                byte[] temp = new byte[1];
                string strTemp;

                for (int i = 0; i < stream.Length; i++)
                {
                    stream.Read(temp, 0, 1);
                    strTemp = Encoding.Default.GetString(temp);
                    if (strTemp != "\n")
                    {
                        studentString.Append(strTemp);
                    }
                    else
                    {
                        string[] words = studentString.ToString().Split(' ');
                        if (words[0] == id.ToString())
                        {
                            Student student = new Student()
                            {
                                Id = Guid.Parse(words[0]),
                                LastName = words[1],
                                FirstName = words[2],
                                Age = int.Parse(words[3]),
                                TeacherId = Guid.Parse(words[4])
                            };
                            return student;
                        }
                        studentString.Clear();
                    }
                }
                return null;
            }
        }

        public override List<Student> GetAll()
        {
            List<Student> students = new List<Student>();

            using (FileStream stream = new FileStream(_path.MainFile.FullName, FileMode.OpenOrCreate))
            {
                StringBuilder studentString = new StringBuilder();
                byte[] temp = new byte[1];
                string strTemp;

                for (int i = 0; i < stream.Length; i++)
                {
                    stream.Read(temp, 0, 1);
                    strTemp = Encoding.Default.GetString(temp);
                    if (strTemp != "\n")
                    {
                        studentString.Append(strTemp);
                    }
                    else
                    {
                        string[] words = studentString.ToString().Split(' ');
                        Student student = new Student()
                        {
                            Id = Guid.Parse(words[0]),
                            LastName = words[1],
                            FirstName = words[2],
                            Age = int.Parse(words[3]),
                            TeacherId = Guid.Parse(words[4])
                        };
                        students.Add(student);
                        studentString.Clear();
                    }
                }
                return students;
            }
        }

        public override void Remove(Student model)
        {
            List<Student> students = GetAll();
            int index = 0;
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].Id == model.Id)
                {
                    index = i;
                }
            }

            StringBuilder newString = new StringBuilder();
            int j = 0;
            while (j < students.Count)
            {
                if (j != index)
                {
                    string temp = students[j].ToString();
                    newString.Append(temp);
                    newString.Append('\n');
                }
                j++;
            }

            using (FileStream stream = new FileStream(_path.MainFile.FullName, FileMode.Truncate))
            {
                string newFile = newString.ToString();
                byte[] b = Encoding.Default.GetBytes(newFile);
                stream.Write(b, 0, b.Length);
            }
        }
    }
}
