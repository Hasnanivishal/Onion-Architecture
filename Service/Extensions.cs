using Contract;
using Domain.Entities;

namespace Service;

public static class Extensions
{
    public static PersonDto ToPersonDto(this Person person)
    {
        return new PersonDto(person.Id,
            person.Name,
            person.DateOfBirth,
            person.Address);
    }
}
