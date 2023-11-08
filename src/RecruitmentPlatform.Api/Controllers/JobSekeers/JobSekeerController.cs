using Microsoft.AspNetCore.Mvc;
using RecruitmentPlatform.Api.Models;
using RecruitmentPlatform.Service.DTOs.JobSeekers;
using RecruitmentPlatform.Service.Interfaces.IJobSeekers;

namespace RecruitmentPlatform.Api.Controllers.JobSekeers
{
    public class JobSekeerController : BaseController
    {
        IJobSeekerService jobSeekerService;
        public JobSekeerController(IJobSeekerService jobSeekerService)
        {
            this.jobSeekerService = jobSeekerService;   
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromForm] JobSeekerForCreationDto dto) =>
            Ok(new Response
            {
                StatusCode = 200,
                Message = "Success",
                Data = await this.jobSeekerService.CreateAsync(dto)
            });

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync([FromRoute(Name = "id")] long id, [FromForm] JobSeekerForUpdateDto dto) =>
            Ok(new Response
            {
                StatusCode = 200,
                Message = "Success",
                Data = await this.jobSeekerService.ModifyAsync(id, dto)
            });
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute(Name = "id")] long id) =>
            Ok(new Response
            {
                StatusCode = 200,
                Message = "Success",
                Data = await this.jobSeekerService.RemoveAsync(id)
            });
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute(Name = "id")] long id) =>
            Ok(new Response
            {
                StatusCode = 200,
                Message = "Success",
                Data = await this.jobSeekerService.RetrieveByIdAsync(id)
            });
        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(new Response
            {
                StatusCode = 200,
                Message = "Success",
                Data = await this.jobSeekerService.RetrieveAllAsync()
            });
    }
}
