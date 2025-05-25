using AutoMapper;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.Mapping;
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Platform, PlatformReadDto>();
        CreateMap<PlatformCreateDto, Platform>();
    }
}
