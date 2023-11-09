using RecruitmentPlatform.Domain.Commons;
using RecruitmentPlatform.Domain.Entities.Employeers;
using RecruitmentPlatform.Domain.Entities.JobSeekers;
using RecruitmentPlatform.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecruitmentPlatform.Domain.Entities.ChatMessengers;

public class ChatMessenger : Auditable
{
    public long SenderId { get; set; }
    [ForeignKey("JobSeekerId")]
    public JobSeeker JobSeeker { get; set; }
    public long ReceiverId { get; set; }
    [ForeignKey("EmployeerId")]
    public Employeer Employeer { get; set; }
    public string MessageContent { get; set; }
    public ChatMessageType MessageType { get; set; }  
}
