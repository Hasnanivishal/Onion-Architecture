using Contract;

namespace Service.Abstraction
{
    public interface IPersonService
    {
        Task<PersonDto> CreateAsync(PersonAddDto personAddDto);

        Task DeleteAsync(Guid personId);

        Task<IEnumerable<PersonDto>> GetAllAsync();

        Task<PersonDto> GetByIdAsync(Guid personId);
    }
}
