using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetAllAsync();

        Task<Person> GetByIdAsync(Guid personId);

        Task Insert(Person owner);

        Task Remove(Person owner);
    }
}
