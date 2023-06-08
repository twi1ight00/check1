using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Application.Services;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;

namespace Richfit.Garnet.Module.Fundation.Application.Services.BusinessMenu;

/// <summary>
/// 用户业务服务实现
/// </summary>
public class UserBusinessService : ServiceBase, IUserBusinessService
{
	/// <summary>
	/// 获得某用户的业务功能Id
	/// </summary>
	/// <param name="userId">用户UserID</param>
	/// <param name="userOrgId">用户所属组织机构ID</param>
	/// <returns>某用户的业务功能列表Id</returns>
	public IList<Guid> GetUserBusinessId(Guid userId, Guid userOrgId)
	{
		QueryCondition condition = new QueryCondition();
		condition.Add(QueryItem.GetQueryItem("UserId", userId.ToString(), "guid", " = "));
		condition.Add(QueryItem.GetQueryItem("OrgId", userOrgId.ToString(), "guid", " = "));
		condition.Add(QueryItem.GetQueryItem("UserId", userId.ToString(), "guid", " = "));
		condition.Add(QueryItem.GetQueryItem("OrgId", userOrgId.ToString(), "guid", " = "));
		return SqlQueryResult<Guid>("GetUserBusinessId", condition).List;
	}
}
