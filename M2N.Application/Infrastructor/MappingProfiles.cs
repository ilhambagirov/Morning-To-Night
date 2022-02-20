using AutoMapper;
using M2N.Application.DSOs;
using M2N.Application.DTOs;
using M2N.Domain.Models;

namespace M2N.Application.Infrastructor
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<TaskDto, AppTask>().ReverseMap();
            CreateMap<TaskEditDto, AppTask>().ReverseMap();
            CreateMap<TaskChangeStageDto, AppTask>().ReverseMap();

            CreateMap<AppTask, TaskDso>()
                .ForMember(x => x.CagetoryName, o => o.MapFrom(x => x.TaskCategory.Name))
                .ForMember(x => x.CategoryDate, o => o.MapFrom(x => x.TaskCategory.CreatedDate))
                .ForMember(x => x.StageName, o => o.MapFrom(x => x.Stage.Name))
                .ReverseMap();

            CreateMap<TaskCategoryDto, TaskCategory>().ReverseMap();
            CreateMap<TaskCategoryDso, TaskCategory>().ReverseMap();
        }
    }
}
