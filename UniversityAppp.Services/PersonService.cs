using System;
using System.Collections.Generic;
using System.Linq;
using UniversityAppp.Models;

namespace UniversityAppp.Services
{
    internal class PersonService<T> : IPersonService<T> where T: Person
    {
        static List<T> _persons = new List<T>();

        public void Create(T t)
        {
            if (t != null)
                _persons.Add(t);
        }

        public void Delete(Guid id)
        {
            _persons.RemoveAll(x => x.Id == id);
        }

        public T Get(Guid id) => _persons.FirstOrDefault(x => x.Id == id);

        public IEnumerable<T> GetAll() => _persons;

        public void Update(T t)
        {
            T currentPerson = _persons.FirstOrDefault(s => s.Id == t.Id);
            int index = -1;
            if (currentPerson != null)
                index = _persons.IndexOf(currentPerson);
            if (t != null)
                _persons[index] = t;
        }
    }
}