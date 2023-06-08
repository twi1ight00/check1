using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;
using Richfit.Garnet.Module.Logistics.Application.DTO;

namespace Richfit.Garnet.Module.Logistics.Application.Services;

public interface IVehicleService
{
	QueryResult<LM_VEHICLE_MANAGEDTO> GetAllVehicleList(LM_VEHICLE_MANAGEDTO vehicelmagDTO);

	LM_VEHICLE_MANAGEDTO AddVehicle(LM_VEHICLE_MANAGEDTO vehicelmagDTO);

	LM_VEHICLE_MANAGEDTO UpdateVehicle(LM_VEHICLE_MANAGEDTO vehicelmagDTO);

	void DelVehicle(string IDs);
}
