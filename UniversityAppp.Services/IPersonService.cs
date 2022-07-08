using System;
using System.Collections.Generic;
using UniversityAppp.Models;

namespace UniversityAppp.Services
{
    public interface IPersonService<T> where T: Person
    {
        IEnumerable<T>? GetAll();
        T Get(Guid id);
        void Create(T t);
        void Update(T t);
        void Delete(Guid id);
    }
}