using Richfit.Garnet.Common.Configuration;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Module.Base.Infrastructure.Session;
using Richfit.Garnet.Module.Localizing.Application.Services;

namespace Richfit.Garnet.Module.Fundation.Application.Services.Initialization;

/// <summary>
/// 初始化配置信息提供者
/// </summary>
internal class InitializationConfigProvider
{
	/// <summary>
	/// 读取配置
	/// </summary>
	/// <returns>InitializationConfig</returns>
	internal static InitializationConfig Read()
	{
		InitializationConfig initializationConfig = new InitializationConfig();
		initializationConfig.Navigation = ConfigurationManager.System.Settings["Navigation"].ToString();
		initializationConfig.UserSessionInfo = SessionContext.UserInfo.MaskInfo();
		IInitializationService userService = ServiceLocator.Instance.GetService<IInitializationService>();
		initializationConfig.UserExistInOrg = userService.GetUserOrganization(SessionContext.UserInfo.UserID).List;
		initializationConfig.UILocalizing = LocalizingCacheManager.GetUserUILocalizing();
		return initializationConfig;
	}
}
