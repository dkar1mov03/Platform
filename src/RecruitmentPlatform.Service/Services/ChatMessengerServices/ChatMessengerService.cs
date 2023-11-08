using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RecruitmentPlatform.Data.IRepositories;
using RecruitmentPlatform.Data.Repositories;
using RecruitmentPlatform.Domain.Entities.ChatMessengers;
using RecruitmentPlatform.Service.DTOs.ChatMessages;
using RecruitmentPlatform.Service.Exceptions;
using RecruitmentPlatform.Service.Interfaces.IChatMessengers;

namespace RecruitmentPlatform.Service.Services.ChatMessengers;

public class ChatMessengerService : IChatMessengerService
{
    IMapper _mapper;
    IRepository<ChatMessenger> _chatMessengerRepository;
    public ChatMessengerService(IMapper mapper,IRepository<ChatMessenger> chatMessengerRepository)
    {
        _mapper = mapper;
        _chatMessengerRepository = chatMessengerRepository;
    }
    public async Task<ChatMessengerForResultDto> CreateAsync(ChatMessengerForCreationDto dto)
    {
        var chats = await _chatMessengerRepository.SelectAll()
            .Where(c => c.MessageContent == dto.MessageContent)
            .FirstOrDefaultAsync();

        if (chats is not null)
            throw new RecruitmentException(409,"Chat is already exists.");
        var mappedChat = _mapper.Map<ChatMessenger>(dto);
        mappedChat.CreatedAt = DateTime.UtcNow;

        var createdChat = await _chatMessengerRepository.InsertAsync(mappedChat);

        return _mapper.Map<ChatMessengerForResultDto>(createdChat);
    }

    public async Task<ChatMessengerForResultDto> ModifyAsync(long id, ChatMessengerForUpdateDto dto)
    {
        var chat = await _chatMessengerRepository.SelectAll()
            .Where(c => c.Id == id)
            .FirstOrDefaultAsync();

        if (chat is null)
            throw new RecruitmentException(404, "Chat is not found");

        chat.UpdatedAt = DateTime.UtcNow;
        var chatUser = _mapper.Map(dto, chat);

        await _chatMessengerRepository.UpdateAsync(chatUser);

        return _mapper.Map<ChatMessengerForResultDto>(chatUser);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var chat = await _chatMessengerRepository.SelectAll()
            .Where (c => c.Id == id)
            .FirstOrDefaultAsync();
        if (chat is null)
            throw new RecruitmentException(404,"Chat is not found");

        await _chatMessengerRepository.DeleteAsync(id);

        return true;
    }

    public async Task<IEnumerable<ChatMessengerForResultDto>> RetrieveAllAsync()
    {
        var chats = await _chatMessengerRepository.SelectAll()
                .Include(c => c.Id)
                .AsNoTracking()
                .ToListAsync();

        return _mapper.Map<IEnumerable<ChatMessengerForResultDto>>(chats);
    }

    public async Task<ChatMessengerForResultDto> RetrieveByIdAsync(long id)
    {
        //var chats = await this._chatMessengerRepository.SelectAll().ToListAsync();
        //return (ChatMessengerForResultDto)_mapper.Map<IEnumerable<ChatMessengerForCreationDto>>(chats);
        var chat = await _chatMessengerRepository.SelectByIdAsync(id);
        if (chat is not null && !chat.IsDeleted)
            return _mapper.Map<ChatMessengerForResultDto>(chat);

        throw new Exception("Chat not found");
    }
}
