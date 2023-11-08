using RecruitmentPlatform.Service.DTOs.JobAplications;

namespace RecruitmentPlatform.Service.Interfaces.IJobAplications;

public interface IJobAplicationService
{
    Task<bool> RemoveAsync (long id);
    Task<JobAplicationForResultDto> RetrieveByIdAsync (long id);
    Task<IEnumerable<JobAplicationForResultDto>> RetrieveAllAsync ();
    Task<JobAplicationForResultDto> CreateAsync (JobAplicationForCreationDto dto);
    Task<JobAplicationForResultDto> ModifyAsync (long id,JobAplicationForUpdateDto dto);
}
