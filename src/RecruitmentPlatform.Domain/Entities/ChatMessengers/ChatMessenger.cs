using RecruitmentPlatform.Domain.Commons;
using RecruitmentPlatform.Domain.Entities.Employeers;
using RecruitmentPlatform.Domain.Entities.JobSeekers;
using RecruitmentPlatform.Domain.Enums;

namespace RecruitmentPlatform.Domain.Entities.ChatMessengers;

public class ChatMessenger : Auditable
{
    public long SenderId { get; set; }
    public JobSeeker JobSeeker { get; set; }
    public long ReceiverId { get; set; }
    public Employeer Employeer { get; set; }
    public string MessageContent { get; set; }
    public ChatMessageType MessageType { get; set; }  
}
