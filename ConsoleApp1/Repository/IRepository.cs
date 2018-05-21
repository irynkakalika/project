using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp1.Repository
{
    public interface IRepository<T>
    {
        List<T> Read();
        void Insert(T obj);
        void Update(T obj);
        void Delete(int id);
    }
}