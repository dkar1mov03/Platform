using RecruitmentPlatform.Service.DTOs.JobSeekers;
using RecruitmentPlatform.Service.Services.JobSeekerServices;

namespace RecruitmentPlatform.Service.Interfaces.IJobSeekers;

public interface IJobSeekerService
{
    Task<bool> RemoveAsync(long id);
    Task<JobSeekerForResultDto> RetrieveByIdAsync(long id);
    Task<IEnumerable<JobSeekerForResultDto>> RetrieveAllAsync();
    Task<JobSeekerForResultDto> CreateAsync(JobSeekerForCreationDto dto);
    Task<JobSeekerForResultDto> ModifyAsync(long id, JobSeekerForUpdateDto dto);
}
