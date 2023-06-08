using System;
using System.Linq;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Module.Base.Application.Services;
using Richfit.Garnet.Module.Base.Domain;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;
using Richfit.Garnet.Module.Base.Infrastructure.Exceptions;
using Richfit.Garnet.Module.Base.Infrastructure.Session;
using Richfit.Garnet.Module.Logistics.Application.DTO;
using Richfit.Garnet.Module.Logistics.Domain.Models;

namespace Richfit.Garnet.Module.Logistics.Application.Services;

public class VehicleService : ServiceBase, IVehicleService
{
	private readonly IRepository<LM_VEHICLE_MANAGE> vehicleRepository;

	public VehicleService(IRepository<LM_VEHICLE_MANAGE> repositoryVehicle)
	{
		vehicleRepository = repositoryVehicle;
	}

	public QueryResult<LM_VEHICLE_MANAGEDTO> GetAllVehicleList(LM_VEHICLE_MANAGEDTO vehicelmagDTO)
	{
		return SqlQueryPager<LM_VEHICLE_MANAGEDTO>("GetVehicleList", vehicelmagDTO);
	}

	public LM_VEHICLE_MANAGEDTO AddVehicle(LM_VEHICLE_MANAGEDTO vehicelmagDTO)
	{
		if (vehicelmagDTO == null)
		{
			throw new ArgumentException("AddVehicle方法参数不能为空！");
		}
		if (vehicelmagDTO.IsValid())
		{
			LM_VEHICLE_MANAGE vehicelPOCO = new LM_VEHICLE_MANAGE();
			vehicelmagDTO.VEHICLE_ID = Guid.NewGuid();
			vehicelmagDTO.CREATOR = SessionContext.UserInfo.UserID;
			vehicelmagDTO.CREATETIME = DateTime.Now;
			vehicelmagDTO.USER_NAME = SessionContext.UserInfo.UserName;
			vehicelmagDTO.ORG_NAME = SessionContext.UserInfo.UserName;
			vehicelmagDTO.MODIFYTIME = DateTime.Now;
			vehicelmagDTO.IS_DEL = 0m;
			vehicelPOCO = vehicelmagDTO.AdaptAsEntity<LM_VEHICLE_MANAGE>();
			vehicleRepository.AddCommit(vehicelPOCO);
			return vehicelPOCO.AdaptAsDTO<LM_VEHICLE_MANAGEDTO>();
		}
		throw new ValidationException(vehicelmagDTO.GetInvalidMessages());
	}

	public LM_VEHICLE_MANAGEDTO UpdateVehicle(LM_VEHICLE_MANAGEDTO vehicelmagDTO)
	{
		if (vehicelmagDTO == null)
		{
			throw new ArgumentException("AddEmployee方法参数不能为空！");
		}
		if (vehicelmagDTO.IsValid())
		{
			LM_VEHICLE_MANAGE vehicelPOCO = vehicleRepository.Find((LM_VEHICLE_MANAGE a) => a.VEHICLE_ID == vehicelmagDTO.VEHICLE_ID);
			vehicelPOCO.VEHICLE_NO = vehicelmagDTO.VEHICLE_NO;
			vehicelPOCO.DRIVER = vehicelmagDTO.DRIVER;
			vehicelPOCO.VEHICLE_NAME = vehicelmagDTO.VEHICLE_NAME;
			vehicelPOCO.IS_ENABLED = vehicelmagDTO.IS_ENABLED;
			vehicelPOCO.ODOMETER_NO = vehicelmagDTO.ODOMETER_NO;
			vehicelPOCO.IS_BOUND_DRIVE = vehicelmagDTO.IS_BOUND_DRIVE;
			vehicelmagDTO.MODIFIER = SessionContext.UserInfo.UserID;
			vehicelmagDTO.MODIFYTIME = DateTime.Now;
			vehicleRepository.UpdateCommit(vehicelPOCO);
			return vehicelPOCO.AdaptAsDTO<LM_VEHICLE_MANAGEDTO>();
		}
		throw new ValidationException(vehicelmagDTO.GetInvalidMessages());
	}

	public void DelVehicle(string ids)
	{
		string[] idArray = ids.Split(",", removeEmptyEntries: true);
		if (idArray == null || !idArray.Any())
		{
			return;
		}
		idArray.ForEach(delegate(string x)
		{
			Guid id = Guid.Parse(x);
			LM_VEHICLE_MANAGE lM_VEHICLE_MANAGE = vehicleRepository.Find((LM_VEHICLE_MANAGE a) => a.VEHICLE_ID == id && a.IS_DEL == (decimal?)0m);
			if (lM_VEHICLE_MANAGE != null)
			{
				lM_VEHICLE_MANAGE.IS_DEL = 1m;
				vehicleRepository.UpdateCommit(lM_VEHICLE_MANAGE);
			}
		});
	}
}
