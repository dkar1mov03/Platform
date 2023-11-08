using Microsoft.AspNetCore.Mvc;
using RecruitmentPlatform.Api.Models;
using RecruitmentPlatform.Service.DTOs.JobAplications;
using RecruitmentPlatform.Service.Interfaces.IJobAplications;

namespace RecruitmentPlatform.Api.Controllers.JobAplications
{
    public class JobAplicationController : BaseController
    {
        IJobAplicationService jobAplicationService;
        public JobAplicationController(IJobAplicationService jobAplicationService)
        {
            this.jobAplicationService = jobAplicationService;
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromForm] JobAplicationForCreationDto dto) =>
            Ok(new Response
            {
                StatusCode = 200,
                Message = "Success",
                Data = await this.jobAplicationService.CreateAsync(dto)
            });

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync([FromRoute(Name = "id")] long id, [FromForm] JobAplicationForUpdateDto dto) =>
            Ok(new Response
            {
                StatusCode = 200,
                Message = "Success",
                Data = await this.jobAplicationService.ModifyAsync(id, dto)
            });
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute(Name = "id")] long id) =>
            Ok(new Response
            {
                StatusCode = 200,
                Message = "Success",
                Data = await this.jobAplicationService.RemoveAsync(id)
            });
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute(Name = "id")] long id) =>
            Ok(new Response
            {
                StatusCode = 200,
                Message = "Success",
                Data = await this.jobAplicationService.RetrieveByIdAsync(id)
            });
        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(new Response
            {
                StatusCode = 200,
                Message = "Success",
                Data = await this.jobAplicationService.RetrieveAllAsync()
            });
    }
}
