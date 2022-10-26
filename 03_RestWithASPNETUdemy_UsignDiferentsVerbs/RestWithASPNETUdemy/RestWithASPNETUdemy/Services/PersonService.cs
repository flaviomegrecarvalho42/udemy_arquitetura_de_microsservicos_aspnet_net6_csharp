using RestWithASPNETUdemy.Models;
using RestWithASPNETUdemy.Services.Interfaces;
using System.Collections.Generic;
using System.Threading;

namespace RestWithASPNETUdemy.Services
{
    public class PersonService : IPersonService
    {
        private volatile int count;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
        }

        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();

            for (int i = 0; i < 8; i++)
            {
                Person person = MockPerson(i);
                persons.Add(person);
            }

            return persons;
        }

        public Person FindById(long id)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Flavio",
                LastName = "Carvalho",
                Address = "Rio de Janeiro - RJ - Brasil",
                Gender = "Male"
            };
        }

        public Person Update(Person person)
        {
            return person;
        }

        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = string.Concat("Person FirstName", i),
                LastName = string.Concat("Person LastName", i),
                Address = string.Concat("Some Address", i),
                Gender = string.Concat("Male", i)
            };
        }

        private int IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}
