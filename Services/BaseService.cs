using Models.Context;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BaseService<T> : IBaseService<T>
    {
        private readonly IPath _path;
        public BaseService(IPath path)
        {
            _path = path;
        }
        public void Add(T model)
        {

            using (FileStream stream = new FileStream(_path.MainFile.FullName, FileMode.OpenOrCreate))
            {
                byte[] array = System.Text.Encoding.Default.GetBytes(model.ToString());
                stream.Seek(0, SeekOrigin.End);
                stream.Write(array, 0, array.Length);
                stream.WriteByte(0x0A);
            }

        }

        public virtual T Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public virtual List<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public virtual void Remove(T model)
        {
        }

        public virtual void Update(T model)
        {
            throw new NotImplementedException();
        }
    }
}
