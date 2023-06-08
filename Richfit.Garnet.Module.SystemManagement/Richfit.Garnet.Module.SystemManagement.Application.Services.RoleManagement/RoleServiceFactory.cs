using Richfit.Garnet.Common.Configuration;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.IoC;

namespace Richfit.Garnet.Module.SystemManagement.Application.Services.RoleManagement;

/// <summary>
/// 角色服务工厂
/// </summary>
public class RoleServiceFactory
{
	public static IRoleAppService GetRoleService()
	{
		if (IsOrgCreateRole())
		{
			return ServiceLocator.Instance.GetService<IRoleAppService>();
		}
		return ServiceLocator.Instance.GetService<IRoleAppService>("Simple");
	}

	/// <summary>
	/// 机构是否创建角色
	/// </summary>
	/// <returns></returns>
	public static bool IsOrgCreateRole()
	{
		string IsOrgCreateRole = ConfigurationManager.CurrentPackage.Settings["IsOrgCreateRole"].ToString();
		return IsOrgCreateRole.EqualOrdinal("true", ignoreCase: true);
	}
}
