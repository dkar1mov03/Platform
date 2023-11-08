using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RecruitmentPlatform.Data.IRepositories;
using RecruitmentPlatform.Domain.Entities.JobAplications;
using RecruitmentPlatform.Service.DTOs.JobAplications;
using RecruitmentPlatform.Service.Exceptions;
using RecruitmentPlatform.Service.Interfaces.IJobAplications;

namespace RecruitmentPlatform.Service.Services.JobAplicationServices;

public class JobAplicationService : IJobAplicationService
{
    IMapper _mapper;
    IRepository<JobAplication> _jobAplicationRepository;

    public JobAplicationService(IMapper mapper , IRepository<JobAplication> jobAplicationRepository)
    {
        _mapper = mapper;
        _jobAplicationRepository = jobAplicationRepository;
    }

    public async Task<JobAplicationForResultDto> CreateAsync(JobAplicationForCreationDto dto)
    {
        var jobs = await _jobAplicationRepository.SelectAll()
                .Where(j => j.AdditionalDocuments == dto.AdditionalDocuments)
                .FirstOrDefaultAsync();

        if (jobs is not null)
            throw new RecruitmentException(409, "User is already exist.");

        var mappedJob = _mapper.Map<JobAplication>(dto);
        mappedJob.CreatedAt = DateTime.UtcNow;

        var createdUser = await _jobAplicationRepository.InsertAsync(mappedJob);
        return _mapper.Map<JobAplicationForResultDto>(mappedJob);
    }

    public async Task<JobAplicationForResultDto> ModifyAsync(long id, JobAplicationForUpdateDto dto)
    {
        var job = await _jobAplicationRepository.SelectAll()
                .Where(u => u.Id == id)
                .FirstOrDefaultAsync();
        if (job is null)
            throw new RecruitmentException(404, "Job is not found");

        job.UpdatedAt = DateTime.UtcNow;
        var person = _mapper.Map(dto, job);

        await _jobAplicationRepository.UpdateAsync(person);

        return _mapper.Map<JobAplicationForResultDto>(person);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var job = await _jobAplicationRepository.SelectAll()
                .Where(u => u.Id == id)
                .FirstOrDefaultAsync();
        if (job is null)
            throw new RecruitmentException(404, "Job is not found");

        await _jobAplicationRepository.DeleteAsync(id);

        return true;
    }


    public async Task<IEnumerable<JobAplicationForResultDto>> RetrieveAllAsync()
    {
        var jobs = await _jobAplicationRepository.SelectAll()
                .AsNoTracking()
                .ToListAsync();

        return _mapper.Map<IEnumerable<JobAplicationForResultDto>>(jobs);
    }


    public async Task<JobAplicationForResultDto> RetrieveByIdAsync(long id)
    {
        var jobs = await _jobAplicationRepository.SelectAll()
                .Where(u => u.Id == id)
                .FirstOrDefaultAsync();
        if (jobs is null)
            throw new RecruitmentException(404, "Job is not found");

        return _mapper.Map<JobAplicationForResultDto>(jobs);
    }
}
