using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraansportManagementBLLibrary
{
    public interface IRepo<T>
    {
        void Add(T t);
        void Update(int id, T t);

        ICollection<T> GetAll();
        T Get(int id);

        void Delete(int id);
    }
}
