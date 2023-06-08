using System;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;
using Richfit.Garnet.Module.Fundation.Application.DTO;

namespace Richfit.Garnet.Module.Fundation.Application.Services.Initialization;

/// <summary>
/// 系统初始化服务接口定义
/// </summary>
public interface IInitializationService
{
	/// <summary>
	/// 根据用户查询所属组织机构
	/// </summary>
	/// <param name="userId">用户UserID</param>
	/// <returns>用户所在机构列表</returns>
	QueryResult<UserOrgDTO> GetUserOrganization(Guid userId);
}
