using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RecruitmentPlatform.Data.IRepositories;
using RecruitmentPlatform.Domain.Entities.Employeers;
using RecruitmentPlatform.Service.DTOs.Employeers;
using RecruitmentPlatform.Service.Exceptions;
using RecruitmentPlatform.Service.Interfaces.IEmployeers;

namespace RecruitmentPlatform.Service.Services.EmployeerServices;

public class EmployeerService : IEmployeerService
{
    IMapper _mapper;
    IRepository<Employeer> _employeerRepository;
    public EmployeerService(IMapper mapper,IRepository<Employeer> employeerRepository)
    {
        _mapper = mapper;
        _employeerRepository = employeerRepository;
    }
    public async Task<EmployeerForResultDto> CreateAsync(EmployeerForCreationDto dto)
    {
        var employeers = await _employeerRepository.SelectAll()
                .Where(e => e.Password == dto.Password)
                .FirstOrDefaultAsync();

        if (employeers is not null)
            throw new RecruitmentException(409, "Employeer is already exist.");

        var mappedUser = _mapper.Map<Employeer>(dto);
        mappedUser.CreatedAt = DateTime.UtcNow;

        var createdUser = await _employeerRepository.InsertAsync(mappedUser);
        return _mapper.Map<EmployeerForResultDto>(mappedUser);
    }

    public async Task<EmployeerForResultDto> ModifyAsync(long id, EmployeerForUpdateDto dto)
    {
        var employeer = await _employeerRepository.SelectAll()
                .Where(u => u.Id == id)
                .FirstOrDefaultAsync();
        if (employeer is null)
            throw new RecruitmentException(404, "User not found");

        employeer.UpdatedAt = DateTime.UtcNow;
        var person = _mapper.Map(dto, employeer);

        await _employeerRepository.UpdateAsync(person);

        return _mapper.Map<EmployeerForResultDto>(person);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var user = await _employeerRepository.SelectAll()
                .Where(u => u.Id == id)
                .FirstOrDefaultAsync();
        if (user is null)
            throw new RecruitmentException(404, "User is not found");

        await _employeerRepository.DeleteAsync(id);

        return true;
    }

    public async Task<IEnumerable<EmployeerForResultDto>> RerieveAllAsync()
    {
        var employeers = await this._employeerRepository.SelectAll()
                .Include(e => e.Id)
                .AsNoTracking()
                .ToListAsync();

        return _mapper.Map<IEnumerable<EmployeerForResultDto>>(employeers);
    }

    public async Task<EmployeerForResultDto> RetrieveByIdAsync(long id)
    {
        var employeers = await _employeerRepository.SelectAll()
                .Where(e => e.Id == id)
                .FirstOrDefaultAsync();
        if (employeers is null)
            throw new RecruitmentException(404, "User is not found");

        return _mapper.Map<EmployeerForResultDto>(employeers);
    }
}
