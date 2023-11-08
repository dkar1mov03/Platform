using RecruitmentPlatform.Domain.Entities.Employeers;
using RecruitmentPlatform.Domain.Entities.JobSeekers;

namespace RecruitmentPlatform.Service.DTOs.JobLists;

public class JobListForResultDto
{
    public long Id { get; set; }
    public string JobTitle { get; set; }
    public string CompanyName { get; set; }
    public string Description { get; set; }
    public string RequiredSkills { get; set; }
    public string Location { get; set; }
    public string AdditionalInformation { get; set; }
    public string Email {  get; set; }
}
