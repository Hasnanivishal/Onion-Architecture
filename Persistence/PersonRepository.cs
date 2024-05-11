using Domain.Entities;
using Domain.Repositories;
using System;

namespace Persistence
{
    public class PersonRepository : IPersonRepository
    {
        private static readonly List<Person> _persons =
        [
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Test",
                Address = "abc",
                DateOfBirth = DateTime.Now,
            }
        ];

        public Task<IEnumerable<Person>> GetAllAsync()
        {
            return Task.FromResult(_persons.AsEnumerable());
        }

        public Task<Person> GetByIdAsync(Guid personId)
        {
            var person = _persons.First(s => s.Id == personId)!;

            return Task.FromResult(person);
        }

        public Task Insert(Person person)
        {
            _persons.Add(person);

            return Task.CompletedTask;
        }

        public Task Remove(Person person)
        {
            _persons.Remove(person);

            return Task.CompletedTask;
        }
    }
}
