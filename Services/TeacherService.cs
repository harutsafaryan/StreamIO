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
    public class TeacherService : BaseService<Teacher>, ITeacherService
    {
        private readonly IPath _path;
        public TeacherService(IPath path) : base(path)
        {
            _path = path;
        }

        public override Teacher Get(Guid id)
        {
            using (FileStream stream = new FileStream(_path.MainFile.FullName, FileMode.OpenOrCreate))
            {
                StringBuilder teacherString = new StringBuilder();
                byte[] temp = new byte[1];
                string strTemp;

                for (int i = 0; i < stream.Length; i++)
                {
                    stream.Read(temp, 0, 1);
                    strTemp = Encoding.Default.GetString(temp);
                    if (strTemp != "\n")
                    {
                        teacherString.Append(strTemp);
                    }
                    else
                    {
                        string[] words = teacherString.ToString().Split(' ');
                        if (words[0] == id.ToString())
                        {
                            Teacher teacher = new Teacher()
                            {
                                Id = Guid.Parse(words[0]),
                                LastName = words[1],
                                FirstName = words[2],
                                Age = int.Parse(words[3]),
                            };
                            return teacher;
                        }
                        teacherString.Clear();
                    }
                }
                return null;
            }
        }

        public override List<Teacher> GetAll()
        {
            List<Teacher> teachers = new List<Teacher>();

            using (FileStream stream = new FileStream(_path.MainFile.FullName, FileMode.OpenOrCreate))
            {
                StringBuilder teacherString = new StringBuilder();
                byte[] temp = new byte[1];
                string strTemp;

                for (int i = 0; i < stream.Length; i++)
                {
                    stream.Read(temp, 0, 1);
                    strTemp = Encoding.Default.GetString(temp);
                    if (strTemp != "\n")
                    {
                        teacherString.Append(strTemp);
                    }
                    else
                    {
                        string[] words = teacherString.ToString().Split(' ');
                        Teacher teacher = new Teacher()
                        {
                            Id = Guid.Parse(words[0]),
                            LastName = words[1],
                            FirstName = words[2],
                            Age = int.Parse(words[3]),
                        };
                        teachers.Add(teacher);
                        teacherString.Clear();
                    }
                }
                return teachers;
            }
        }

        public List<Student> GetStudentsByTeacher(Teacher model, IStudentService studentService)
        {
            return studentService.GetAll().Where(student => student.TeacherId == model.Id).ToList();
        }

        public override void Remove(Teacher model)
        {
            List<Teacher> teachers = GetAll();
            int index = 0;
            for (int i = 0; i < teachers.Count; i++)
            {
                if (teachers[i].Id == model.Id)
                {
                    index = i;
                }
            }

            StringBuilder newString = new StringBuilder();
            int j = 0;
            while (j < teachers.Count)
            {
                if (j != index)
                {
                    string temp = teachers[j].ToString();
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

