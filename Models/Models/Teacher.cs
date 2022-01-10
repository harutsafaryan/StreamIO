using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Teacher
    {
        public Teacher()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public int Age { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

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
            return stringBuilder.ToString();
        }
    }
}
