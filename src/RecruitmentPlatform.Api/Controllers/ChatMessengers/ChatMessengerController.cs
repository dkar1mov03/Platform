using Microsoft.AspNetCore.Mvc;
using RecruitmentPlatform.Api.Models;
using RecruitmentPlatform.Service.DTOs.ChatMessages;
using RecruitmentPlatform.Service.Interfaces.IChatMessengers;

namespace RecruitmentPlatform.Api.Controllers.ChatMessengers
{
    public class ChatMessengerController : BaseController
    {
        IChatMessengerService _chatMessengerService;
        public ChatMessengerController(IChatMessengerService chatMessengerService)
        {
            this._chatMessengerService = chatMessengerService;
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromForm] ChatMessengerForCreationDto dto) =>
            Ok(new Response
            {
                StatusCode = 200,
                Message = "Success",
                Data = await this._chatMessengerService.CreateAsync(dto)
            });

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync([FromRoute(Name = "id")] long id, [FromForm] ChatMessengerForUpdateDto dto) =>
            Ok(new Response
            {
                StatusCode = 200,
                Message = "Success",
                Data = await this._chatMessengerService.ModifyAsync(id, dto)
            });
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute(Name = "id")] long id) =>
            Ok(new Response
            {
                StatusCode = 200,
                Message = "Success",
                Data = await this._chatMessengerService.RemoveAsync(id)
            });
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute(Name = "id")] long id) =>
            Ok(new Response
            {
                StatusCode = 200,
                Message = "Success",
                Data = await this._chatMessengerService.RetrieveByIdAsync(id)
            });
        [HttpGet]
        public async Task<IActionResult> SelectAll() =>
            Ok(new Response
            {
                StatusCode = 200,
                Message = "Success",
                Data = await this._chatMessengerService.RetrieveAllAsync()
            });
    }
}
