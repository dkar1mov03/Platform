using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RecruitmentPlatform.Data.IRepositories;
using RecruitmentPlatform.Domain.Entities.JobSeekers;
using RecruitmentPlatform.Service.DTOs.JobSeekers;
using RecruitmentPlatform.Service.Exceptions;
using RecruitmentPlatform.Service.Interfaces.IJobSeekers;

namespace RecruitmentPlatform.Service.Services.JobSeekerServices;

public class JobSeekerService : IJobSeekerService
{
    IMapper _mapper;
    IRepository<JobSeeker> _jobSekeerRepository;

    public JobSeekerService(IMapper mapper,IRepository<JobSeeker> jobSekeerRepository)
    {
        _mapper = mapper;
        _jobSekeerRepository = jobSekeerRepository;
    }

    public async Task<JobSeekerForResultDto> CreateAsync(JobSeekerForCreationDto dto)
    {
        var users = await _jobSekeerRepository.SelectAll()
                .Where(u => u.Password == dto.Password)
                .FirstOrDefaultAsync();

        if (users is not null)
            throw new RecruitmentException(409, "User is already exist.");

        var mappedUser = _mapper.Map<JobSeeker>(dto);
        mappedUser.CreatedAt = DateTime.UtcNow;

        var createdUser = await _jobSekeerRepository.InsertAsync(mappedUser);
        return _mapper.Map<JobSeekerForResultDto>(mappedUser);
    }

    public async Task<JobSeekerForResultDto> ModifyAsync(long id, JobSeekerForUpdateDto dto)
    {
        var user = await _jobSekeerRepository.SelectAll()
                .Where(u => u.Id == id)
                .FirstOrDefaultAsync();
        if (user is null)
            throw new RecruitmentException(404, "User not found");

        user.UpdatedAt = DateTime.UtcNow;
        var person = _mapper.Map(dto, user);

        await _jobSekeerRepository.UpdateAsync(person);

        return _mapper.Map<JobSeekerForResultDto>(person);
    }


    public async Task<bool> RemoveAsync(long id)
    {
        var user = await _jobSekeerRepository.SelectAll()
                .Where(u => u.Id == id)
                .FirstOrDefaultAsync();
        if (user is null)
            throw new RecruitmentException(404, "User is not found");

        await _jobSekeerRepository.DeleteAsync(id);

        return true;
    }

    public async Task<IEnumerable<JobSeekerForResultDto>> RetrieveAllAsync()
    {
        var users = await _jobSekeerRepository.SelectAll()
                .AsNoTracking()
                .ToListAsync();

        return _mapper.Map<IEnumerable<JobSeekerForResultDto>>(users);
    }

    public async Task<JobSeekerForResultDto> RetrieveByIdAsync(long id)
    {
        var users = await _jobSekeerRepository.SelectAll()
                .Where(u => u.Id == id)
                .FirstOrDefaultAsync();
        if (users is null)
            throw new RecruitmentException(404, "User is not found");

        return _mapper.Map<JobSeekerForResultDto>(users);
    }
}
