namespace RecruitmentPlatform.Service.DTOs.JobSeekers;

public class JobSeekerForResultDto
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Skills { get; set; }
    public string Experience { get; set; }
    public string Preferences { get; set; }
    public string ResumeLink { get; set; }
}
