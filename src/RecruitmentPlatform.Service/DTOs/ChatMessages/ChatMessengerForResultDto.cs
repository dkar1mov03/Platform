using RecruitmentPlatform.Domain.Entities.Employeers;
using RecruitmentPlatform.Domain.Entities.JobSeekers;

namespace RecruitmentPlatform.Service.DTOs.ChatMessages;

public class ChatMessengerForResultDto
{
    public long Id { get; set; }
    public long SenderId { get; set; }
    public long ReceiverId { get; set; }
    public string MessageContent { get; set; }
}
