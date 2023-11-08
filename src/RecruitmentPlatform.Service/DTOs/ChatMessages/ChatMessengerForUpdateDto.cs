namespace RecruitmentPlatform.Service.DTOs.ChatMessages;

public class ChatMessengerForUpdateDto
{
    public long SenderId { get; set; }
    public long ReceiverId { get; set; }
    public string MessageContent { get; set; }
}
