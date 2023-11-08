using RecruitmentPlatform.Domain.Commons;
using RecruitmentPlatform.Domain.Entities.JobLists;
using RecruitmentPlatform.Domain.Entities.JobSeekers;
using RecruitmentPlatform.Domain.Enums;

namespace RecruitmentPlatform.Domain.Entities.JobAplications;

public class JobAplication : Auditable
{
    public long JobListId { get; set; }
    public JobList JobList { get; set; }
    public long JobSeekerId { get; set; }
    public JobSeeker JobSeeker { get; set; }
    public string CoverLetter { get; set; }
    public string AdditionalDocuments { get; set; }
    public JobAplicationType JobAplicationType { get; set; }

}