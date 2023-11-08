using Microsoft.AspNetCore.Mvc;
using RecruitmentPlatform.Api.Models;
using RecruitmentPlatform.Service.DTOs.JobLists;
using RecruitmentPlatform.Service.Interfaces.IJobLists;

namespace RecruitmentPlatform.Api.Controllers.JobLists
{
    public class JobListController : BaseController
    {
        IJobListService jobListService;
        public JobListController(IJobListService jobListService)
        {
            this.jobListService = jobListService;
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromForm] JobListForCreationDto dto) =>
            Ok(new Response
            {
                StatusCode = 200,
                Message = "Success",
                Data = await this.jobListService.CreateAsync(dto)
            });

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync([FromRoute(Name = "id")] long id, [FromForm] JobListForUpdateDto dto) =>
            Ok(new Response
            {
                StatusCode = 200,
                Message = "Success",
                Data = await this.jobListService.ModifyAsync(id, dto)
            });
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute(Name = "id")] long id) =>
            Ok(new Response
            {
                StatusCode = 200,
                Message = "Success",
                Data = await this.jobListService.RemoveAsync(id)
            });
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute(Name = "id")] long id) =>
            Ok(new Response
            {
                StatusCode = 200,
                Message = "Success",
                Data = await this.jobListService.RetrieveByIdAsync(id)
            });
        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(new Response
            {
                StatusCode = 200,
                Message = "Success",
                Data = await this.jobListService.RetrieveAllAsync()
            });
    }
}
