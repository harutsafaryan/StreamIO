using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Student
    {
        public Student()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public int Age { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public Guid TeacherId { get; set; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            //stringBuilder.Append('$');
            stringBuilder.Append(Id);
            stringBuilder.Append(' ');
            stringBuilder.Append(LastName);
            stringBuilder.Append(' ');
            stringBuilder.Append(FirstName);
            stringBuilder.Append(' ');
            stringBuilder.Append(Age);
            stringBuilder.Append(' ');
            stringBuilder.Append(TeacherId);
            return stringBuilder.ToString();
        }
    }
}
