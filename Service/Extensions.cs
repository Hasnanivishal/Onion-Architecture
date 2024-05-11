using Contract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public static class Extensions
    {
        public static PersonDto ToPersonDto(this Person person)
        {
            return new PersonDto()
            {
                Id = person.Id,
                Name = person.Name,
                Address = person.Address,
                DateOfBirth = person.DateOfBirth,
            };
        }
    }
}
