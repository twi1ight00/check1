using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;
using Richfit.Garnet.Module.Portal.Application.DTO;

namespace Richfit.Garnet.Module.Portal.Application.Services;

public interface IPortalService
{
	QueryResult<SYS_PORTALDTO> GetPortals();

	QueryResult<SYS_USER_PORTALDTO> GetMyPortals();

	void UpdateMyPortals(List<SYS_USER_PORTALDTO> userPortalDTOs);
}
