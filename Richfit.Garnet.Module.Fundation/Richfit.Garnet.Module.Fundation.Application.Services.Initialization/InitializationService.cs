using System;
using Richfit.Garnet.Module.Base.Application.Services;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;
using Richfit.Garnet.Module.Fundation.Application.DTO;

namespace Richfit.Garnet.Module.Fundation.Application.Services.Initialization;

/// <summary>
/// 系统初始化服务接口实现
/// </summary>
public class InitializationService : ServiceBase, IInitializationService
{
	/// <summary>
	/// 根据用户查询所属组织机构
	/// </summary>
	/// <param name="userId">用户UserID</param>
	/// <returns>用户所在机构列表</returns>
	public QueryResult<UserOrgDTO> GetUserOrganization(Guid userId)
	{
		QueryResult<UserOrgDTO> queryResult = new QueryResult<UserOrgDTO>();
		if (userId != Guid.Empty)
		{
			QueryCondition condition = new QueryCondition();
			condition.Add(QueryItem.GetQueryItem("UserID", userId.ToString(), "guid", " = "));
			queryResult = SqlQueryResult<UserOrgDTO>("GetUserOrgs", condition);
		}
		return queryResult;
	}
}
