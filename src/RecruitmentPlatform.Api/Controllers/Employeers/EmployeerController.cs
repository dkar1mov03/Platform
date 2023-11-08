using Microsoft.AspNetCore.Mvc;
using RecruitmentPlatform.Api.Models;
using RecruitmentPlatform.Service.DTOs.Employeers;
using RecruitmentPlatform.Service.Interfaces.IEmployeers;

namespace RecruitmentPlatform.Api.Controllers.Employeers
{
    public class EmployeerController : BaseController
    {
        IEmployeerService employeerService;
        public EmployeerController(IEmployeerService employeerService)
        {
            this.employeerService = employeerService;
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromForm] EmployeerForCreationDto dto) =>
            Ok(new Response
            {
                StatusCode = 200,
                Message = "Success",
                Data = await this.employeerService.CreateAsync(dto)
            });

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync([FromRoute(Name = "id")] long id, [FromForm] EmployeerForUpdateDto dto) =>
            Ok(new Response
            {
                StatusCode = 200,
                Message = "Success",
                Data = await this.employeerService.ModifyAsync(id, dto)
            });
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute(Name = "id")] long id) =>
            Ok(new Response
            {
                StatusCode = 200,
                Message = "Success",
                Data = await this.employeerService.RemoveAsync(id)
            });
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute(Name = "id")] long id) =>
            Ok(new Response
            {
                StatusCode = 200,
                Message = "Success",
                Data = await this.employeerService.RetrieveByIdAsync(id)
            });
        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(new Response
            {
                StatusCode = 200,
                Message = "Success",
                Data = await this.employeerService.RerieveAllAsync()
            });
    }
}
