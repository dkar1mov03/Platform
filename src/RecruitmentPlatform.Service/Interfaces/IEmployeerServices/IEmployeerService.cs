using RecruitmentPlatform.Domain.Entities.Employeers;
using RecruitmentPlatform.Service.DTOs.Employeers;

namespace RecruitmentPlatform.Service.Interfaces.IEmployeers;

public interface IEmployeerService
{
    Task<bool> RemoveAsync (long id);
    Task<EmployeerForResultDto> RetrieveByIdAsync (long id);
    Task<IEnumerable<EmployeerForResultDto>> RerieveAllAsync ();
    Task<EmployeerForResultDto> CreateAsync (EmployeerForCreationDto dto);
    Task<EmployeerForResultDto> ModifyAsync (long id, EmployeerForUpdateDto dto);
}
