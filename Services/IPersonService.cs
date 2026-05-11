using MegaTec_Task.DTOs;
using MegaTec_Task.Models;

namespace MegaTec_Task.Services;

public interface IPersonService
{
    Task<Person> CreatePersonAsync(PersonCreateDto dto, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Person>> GetAllPeopleAsync(CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Person>> SearchByNameAsync(string name, CancellationToken cancellationToken = default);
    Task<byte[]> ExportPeoplePdfAsync(CancellationToken cancellationToken = default);
}
