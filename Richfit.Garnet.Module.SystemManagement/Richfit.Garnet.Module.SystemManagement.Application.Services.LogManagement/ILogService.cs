using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;
using Richfit.Garnet.Module.SystemManagement.Application.DTO;

namespace Richfit.Garnet.Module.SystemManagement.Application.Services.LogManagement;

public interface ILogService
{
	QueryResult<SYS_LOGDTO> QueryLogList(QueryCondition queryCondition);
}
