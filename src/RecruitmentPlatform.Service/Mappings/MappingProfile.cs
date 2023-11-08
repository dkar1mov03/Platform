using AutoMapper;
using RecruitmentPlatform.Domain.Entities.ChatMessengers;
using RecruitmentPlatform.Domain.Entities.Employeers;
using RecruitmentPlatform.Domain.Entities.JobAplications;
using RecruitmentPlatform.Domain.Entities.JobLists;
using RecruitmentPlatform.Domain.Entities.JobSeekers;
using RecruitmentPlatform.Service.DTOs.ChatMessages;
using RecruitmentPlatform.Service.DTOs.Employeers;
using RecruitmentPlatform.Service.DTOs.JobAplications;
using RecruitmentPlatform.Service.DTOs.JobLists;
using RecruitmentPlatform.Service.DTOs.JobSeekers;

namespace RecruitmentPlatform.Service.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
     
        //ChatMEssengers

        CreateMap<ChatMessenger,ChatMessengerForCreationDto>().ReverseMap();
        CreateMap<ChatMessenger,ChatMessengerForResultDto>().ReverseMap();
        CreateMap<ChatMessenger,ChatMessengerForUpdateDto>().ReverseMap();

        //Employeers

        CreateMap<Employeer,EmployeerForCreationDto>().ReverseMap();
        CreateMap<Employeer,EmployeerForResultDto>().ReverseMap();
        CreateMap<Employeer,EmployeerForUpdateDto>().ReverseMap();

        //JobAplications

        CreateMap<JobAplication,JobAplicationForCreationDto>().ReverseMap();
        CreateMap<JobAplication,JobAplicationForResultDto>().ReverseMap();
        CreateMap<JobAplication,JobAplicationForUpdateDto>().ReverseMap();

        //JobLists

        CreateMap<JobList,JobListForCreationDto>().ReverseMap();
        CreateMap<JobList,JobListForResultDto>().ReverseMap();
        CreateMap<JobList, JobListForUpdateDto>().ReverseMap();

        //JObSekeers

        CreateMap<JobSeeker,JobSeekerForCreationDto>().ReverseMap();
        CreateMap<JobSeeker,JobSeekerForResultDto>().ReverseMap();
        CreateMap<JobSeeker,JobSeekerForUpdateDto>().ReverseMap();

    }
}
