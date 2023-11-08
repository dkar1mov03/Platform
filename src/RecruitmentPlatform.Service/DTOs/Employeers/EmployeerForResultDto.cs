namespace RecruitmentPlatform.Service.DTOs.Employeers;

public class EmployeerForResultDto
{
    public long Id { get; set; }
    public string CompanyName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; } = string.Empty;
    public string Industry { get; set; }
    public string Website { get; set; }
    public string Location { get; set; }
}
