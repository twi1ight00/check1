using AutoMapper;
using Richfit.Garnet.Module.Supervise.Domain.Models;

namespace Richfit.Garnet.Module.Supervise.Application.DTO.Profiles;

public class SuperviseProfiles : Profile
{
	protected override void Configure()
	{
		Mapper.CreateMap<SUP_ASSIGN_TASK, SUP_ASSIGN_TASKDTO>();
		Mapper.CreateMap<SUP_ASSIGN_TASKDTO, SUP_ASSIGN_TASK>();
		Mapper.CreateMap<SUP_CHANGE, SUP_CHANGEDTO>();
		Mapper.CreateMap<SUP_CHANGEDTO, SUP_CHANGE>();
		Mapper.CreateMap<SUP_FEED_BACK, SUP_FEED_BACKDTO>();
		Mapper.CreateMap<SUP_FEED_BACKDTO, SUP_FEED_BACK>();
		Mapper.CreateMap<SUP_FEED_BACK, SUP_FEED_BACKDTO>();
		Mapper.CreateMap<SUP_FEED_BACKDTO, SUP_FEED_BACK>();
		Mapper.CreateMap<SUP_PORJECT, SUP_PORJECTDTO>();
		Mapper.CreateMap<SUP_PORJECTDTO, SUP_PORJECT>();
		Mapper.CreateMap<SUP_PORJECT_USER, SUP_PORJECT_USERDTO>();
		Mapper.CreateMap<SUP_PORJECT_USERDTO, SUP_PORJECT_USER>();
		Mapper.CreateMap<SUP_TASK_USER, SUP_TASK_USERDTO>();
		Mapper.CreateMap<SUP_TASK_USERDTO, SUP_TASK_USER>();
		Mapper.CreateMap<SUP_TASK_PROGRESS, SUP_TASK_PROGRESSDTO>();
		Mapper.CreateMap<SUP_TASK_PROGRESSDTO, SUP_TASK_PROGRESS>();
	}
}
