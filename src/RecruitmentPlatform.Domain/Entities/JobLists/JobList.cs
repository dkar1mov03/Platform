using RecruitmentPlatform.Domain.Commons;
using RecruitmentPlatform.Domain.Entities.Employeers;
using RecruitmentPlatform.Domain.Entities.JobSeekers;

namespace RecruitmentPlatform.Domain.Entities.JobLists;

public class JobList : Auditable
{
    public string JobTitle { get; set; }
    public string CompanyName { get; set; }
    public Employeer Employeer { get; set; }
    public string Description { get; set; }
    public string RequiredSkills { get; set; }
    public JobSeeker JobSeeker { get; set; }
    public string Location { get; set; }
    public string AdditionalInformation { get; set; }
    public string Email { get; set; }

}
