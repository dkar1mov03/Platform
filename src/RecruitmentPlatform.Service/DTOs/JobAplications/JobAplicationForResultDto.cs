using RecruitmentPlatform.Domain.Entities.JobLists;
using RecruitmentPlatform.Domain.Entities.JobSeekers;

namespace RecruitmentPlatform.Service.DTOs.JobAplications;

public class JobAplicationForResultDto
{
    public long Id { get; set; }
    public long JobListId { get; set; }
    public long JobSeekerId { get; set; }
    public string CoverLetter { get; set; }
    public string AdditionalDocuments { get; set; }
}
