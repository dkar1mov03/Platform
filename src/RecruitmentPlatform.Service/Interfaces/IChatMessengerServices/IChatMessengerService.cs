using RecruitmentPlatform.Domain.Entities.ChatMessengers;
using RecruitmentPlatform.Service.DTOs.ChatMessages;

namespace RecruitmentPlatform.Service.Interfaces.IChatMessengers;

public interface IChatMessengerService
{
    Task<bool> RemoveAsync(long id);
    Task <ChatMessengerForResultDto> RetrieveByIdAsync(long id);
    Task<IEnumerable<ChatMessengerForResultDto>> RetrieveAllAsync();
    Task<ChatMessengerForResultDto> CreateAsync(ChatMessengerForCreationDto dto);
    Task<ChatMessengerForResultDto> ModifyAsync(long id, ChatMessengerForUpdateDto dto);
}
