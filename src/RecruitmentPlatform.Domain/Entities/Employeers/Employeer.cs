using RecruitmentPlatform.Domain.Commons;

namespace RecruitmentPlatform.Domain.Entities.Employeers;

public class Employeer : Auditable
{
    public string CompanyName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Industry { get; set; }
    public string Website {get; set; }
    public string Location { get; set; }
}
