using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Context
{
    public interface IPath
    {
        DirectoryInfo MainDirectory { get; set; }
        //FileInfo StudentFile { get; set; }
        //FileInfo TeacherFIle { get; set; }
        FileInfo MainFile { get; set; }
    }
}
