using System;
using System.Collections.Generic;

namespace Richfit.Garnet.Module.Fundation.Application.Services.BusinessMenu;

/// <summary>
/// 用户业务服务，系统定义接口并提供默认实现，业务系统中可以重写，采用容器注入
/// </summary>
public interface IUserBusinessService
{
	/// <summary>
	/// 获得某用户的业务功能Id
	/// </summary>
	/// <param name="userId">用户UserID</param>
	/// <param name="userOrgId">用户所属组织机构ID</param>
	/// <returns>某用户的业务功能列表Id</returns>
	IList<Guid> GetUserBusinessId(Guid userId, Guid userOrgId);
}
