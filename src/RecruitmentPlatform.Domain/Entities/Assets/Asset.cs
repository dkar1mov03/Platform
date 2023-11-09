using RecruitmentPlatform.Domain.Commons;

namespace RecruitmentPlatform.Domain.Entities.Assets;

public class Asset : Auditable
{
    public string Path { get; set; }
}
