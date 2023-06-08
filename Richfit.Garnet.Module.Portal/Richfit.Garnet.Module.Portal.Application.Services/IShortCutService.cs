using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;
using Richfit.Garnet.Module.Portal.Application.DTO;

namespace Richfit.Garnet.Module.Portal.Application.Services;

public interface IShortCutService
{
	QueryResult<SYS_SHORTCUTDTO> GetShortcuts();

	void UpdateShortcuts(List<SYS_SHORTCUTDTO> shortcutDTOs);
}
