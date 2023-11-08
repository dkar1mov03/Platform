using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RecruitmentPlatform.Data.IRepositories;
using RecruitmentPlatform.Domain.Entities.JobLists;
using RecruitmentPlatform.Service.DTOs.JobLists;
using RecruitmentPlatform.Service.DTOs.JobSeekers;
using RecruitmentPlatform.Service.Exceptions;
using RecruitmentPlatform.Service.Interfaces.IJobLists;

namespace RecruitmentPlatform.Service.Services.JobListServices;

public class JobListService : IJobListService
{
    IMapper _mapper;
    IRepository<JobList> _jobListRepository;
    public JobListService(IMapper mapper,IRepository<JobList> jobListRepository)
    {
        _mapper = mapper;
        _jobListRepository = jobListRepository;
    }

    public async Task<JobListForResultDto> CreateAsync(JobListForCreationDto dto)
    {
        var jobs = await _jobListRepository.SelectAll()
                .Where(j => j.Email == dto.Email)
                .FirstOrDefaultAsync();

        if (jobs is not null)
            throw new RecruitmentException(409, "Job is already exist.");

        var mappedUser = _mapper.Map<JobList>(dto);
        mappedUser.CreatedAt = DateTime.UtcNow;

        var createdUser = await _jobListRepository.InsertAsync(mappedUser);
        return _mapper.Map<JobListForResultDto>(mappedUser);
    }

    public async Task<JobListForResultDto> ModifyAsync(long id, JobListForUpdateDto dto)
    {
        var job = await _jobListRepository.SelectAll()
                .Where(j => j.Id == id)
                .FirstOrDefaultAsync();
        if (job is null)
            throw new RecruitmentException(404, "Job not found");

        job.UpdatedAt = DateTime.UtcNow;
        var person = _mapper.Map(dto, job);

        await _jobListRepository.UpdateAsync(person);

        return _mapper.Map<JobListForResultDto>(person);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var job = await _jobListRepository.SelectAll()
                .Where(u => u.Id == id)
                .FirstOrDefaultAsync();
        if (job is null)
            throw new RecruitmentException(404, "Job is not found");

        await _jobListRepository.DeleteAsync(id);

        return true;
    }

    public async Task<IEnumerable<JobListForResultDto>> RetrieveAllAsync()
    {
        var jobs = await _jobListRepository.SelectAll()
                .ToListAsync();

        return _mapper.Map<IEnumerable<JobListForResultDto>>(jobs);
    }

    public async Task<JobListForResultDto> RetrieveByIdAsync(long id)
    {
        var jobs = await _jobListRepository.SelectAll()
             .Where(u => u.Id == id)
             .FirstOrDefaultAsync();
        if (jobs is null)
            throw new RecruitmentException(404, "Job is not found");

        return _mapper.Map<JobListForResultDto>(jobs);
    }
}
