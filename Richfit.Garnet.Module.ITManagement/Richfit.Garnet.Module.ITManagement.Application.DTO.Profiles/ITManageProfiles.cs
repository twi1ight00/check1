using AutoMapper;
using Richfit.Garnet.Module.ITManagement.Domain.Models;

namespace Richfit.Garnet.Module.ITManagement.Application.DTO.Profiles;

public class ITManageProfiles : Profile
{
	protected override void Configure()
	{
		Mapper.CreateMap<IT_ACCOUNT, IT_ACCOUNTDTO>();
		Mapper.CreateMap<IT_ACCOUNTDTO, IT_ACCOUNT>();
		Mapper.CreateMap<IT_DEVICE, IT_DEVICEDTO>();
		Mapper.CreateMap<IT_DEVICEDTO, IT_DEVICE>();
		Mapper.CreateMap<IT_DEVICE_SCRAP, IT_DEVICE_SCRAPDTO>();
		Mapper.CreateMap<IT_DEVICE_SCRAPDTO, IT_DEVICE_SCRAP>();
		Mapper.CreateMap<IT_DEVICE_SCRAP_DETAIL, IT_DEVICE_SCRAP_DETAILDTO>();
		Mapper.CreateMap<IT_DEVICE_SCRAP_DETAILDTO, IT_DEVICE_SCRAP_DETAIL>();
		Mapper.CreateMap<IT_MATERIAL, IT_MATERIALDTO>();
		Mapper.CreateMap<IT_MATERIALDTO, IT_MATERIAL>();
		Mapper.CreateMap<IT_MATERIAL_CHECKIN, IT_MATERIAL_CHECKINDTO>();
		Mapper.CreateMap<IT_MATERIAL_CHECKINDTO, IT_MATERIAL_CHECKIN>();
		Mapper.CreateMap<IT_STOCK_IN, IT_STOCK_INDTO>();
		Mapper.CreateMap<IT_STOCK_INDTO, IT_STOCK_IN>();
		Mapper.CreateMap<IT_STOCK_IN_DETAIL, IT_STOCK_IN_DETAILDTO>();
		Mapper.CreateMap<IT_STOCK_IN_DETAILDTO, IT_STOCK_IN_DETAIL>();
		Mapper.CreateMap<IT_MATERIAL_APPLY_DETAILDTO, IT_MATERIAL_APPLY_DETAIL>();
		Mapper.CreateMap<IT_SUPPORTMANGDTO, IT_SUPPORTMANG>();
		Mapper.CreateMap<IT_SUPPORTMANG, IT_SUPPORTMANGDTO>();
	}
}
