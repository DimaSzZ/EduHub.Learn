using AutoMapper;
using EduHub.StudentService.Application.Services.Dto.Educator;
using EduHub.StudentService.Domain.ValueObjects;

namespace EduHub.StudentService.Application.Services.Mapping.Educator
{
    public class EducatorMappingProfile : Profile
    {
        public EducatorMappingProfile()
        {
            CreateMap<EducatorRequestDto, Domain.Entities.Educator>()
                .ConstructUsing(dto =>
                    new Domain.Entities.Educator(
                        Guid.NewGuid(),
                        new FullName(dto.FirstName, dto.Surname, dto.Patronymic),
                        dto.Gender,
                        new Phone(dto.Phone),
                        dto.WorkExperience,
                        dto.DateEmployment
                    ));
            
            CreateMap<EducatorRequestUpdateDto, Domain.Entities.Educator>().ReverseMap();
            
            CreateMap<Domain.Entities.Educator, EducatorResponseDto>().ReverseMap();
        }
    }
}