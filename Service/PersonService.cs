using Contract;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
using Service.Abstraction;

namespace Service;

public sealed class PersonService(IPersonRepository personRepository) : IPersonService
{
    private readonly IPersonRepository personRepository = personRepository;

    public async Task<IEnumerable<PersonDto>> GetAllAsync()
    {
        var result = await personRepository.GetAllAsync();

        return result.Select(s => s.ToPersonDto());
    }

    public async Task<PersonDto> GetByIdAsync(Guid personId)
    {
        var result = await personRepository.GetByIdAsync(personId);

        return result is null ? throw new PersonNotFoundException(personId) : result.ToPersonDto();
    }

    public async Task<PersonDto> CreateAsync(PersonAddDto personAddDto)
    {
        var person = new Person()
        {
            Id = Guid.NewGuid(),
            Name = personAddDto.Name,
            Address = personAddDto.Address,
            DateOfBirth = personAddDto.DateOfBirth,
        };

        await personRepository.Insert(person);

        return person.ToPersonDto();
    }

    public async Task DeleteAsync(Guid personId)
    {
        var result = await personRepository.GetByIdAsync(personId) ?? throw new PersonNotFoundException(personId);

        await personRepository.Remove(result);
    }
}
