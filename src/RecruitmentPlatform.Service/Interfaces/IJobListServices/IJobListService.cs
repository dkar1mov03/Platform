using RecruitmentPlatform.Service.DTOs.JobLists;
using RecruitmentPlatform.Service.DTOs.JobSeekers;

namespace RecruitmentPlatform.Service.Interfaces.IJobLists;

public interface IJobListService
{
    Task<bool> RemoveAsync(long id);
    Task<JobListForResultDto> RetrieveByIdAsync(long id);
    Task<IEnumerable<JobListForResultDto>> RetrieveAllAsync();
    Task<JobListForResultDto> CreateAsync (JobListForCreationDto dto);
    Task<JobListForResultDto> ModifyAsync(long id, JobListForUpdateDto dto);
}
