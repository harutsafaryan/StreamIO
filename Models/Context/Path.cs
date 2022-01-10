using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Context
{
    public class Path : IPath
    {
        public DirectoryInfo MainDirectory { get; set; }
        public FileInfo MainFile { get; set; }


        public Path(string dirName, string fileName)
        {
            string path = $"{dirName}\\{fileName}.txt";

            MainDirectory = new DirectoryInfo(dirName);
            if (!MainDirectory.Exists)
            {
                MainDirectory.Create();
            }
            MainFile = new FileInfo(path);
        }
    }
}
