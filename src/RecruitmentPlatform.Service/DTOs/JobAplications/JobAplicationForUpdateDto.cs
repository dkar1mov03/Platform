namespace RecruitmentPlatform.Service.DTOs.JobAplications;

public class JobAplicationForUpdateDto
{
    public long JobListId { get; set; }
    public long JobSeekerId { get; set; }
    public string CoverLetter { get; set; }
    public string AdditionalDocuments { get; set; }
}
