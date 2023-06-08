using System.Globalization;
using System.Linq;
using Richfit.Garnet.Common.Configuration;
using Richfit.Garnet.Module.Fundation.Application.Services.Domain;
using Richfit.Garnet.Module.Localizing.Application.DTO;
using Richfit.Garnet.Module.Localizing.Application.Services;

namespace Richfit.Garnet.Module.Fundation.Application.Services.Logon;

/// <summary>
/// 登陆配置信息提供者
/// </summary>
internal class LogonConfigProvider
{
	/// <summary>
	/// 读取配置
	/// </summary>
	/// <returns></returns>
	internal static LogonConfig Read(string culture)
	{
		LogonConfig logonConfig = new LogonConfig
		{
			EnableMultiLanguage = ConfigurationManager.System.Settings.EnableMultiLanguage,
			DefaultCulture = (string.IsNullOrEmpty(culture) ? ConfigurationManager.System.Settings.DefaultCulture : new CultureInfo(culture)),
			EnableDomain = ConfigurationManager.System.Settings.EnableDomain,
			EnableTimeOffset = ConfigurationManager.System.Settings.EnableTimeOffset
		};
		logonConfig.AllLoginLocalizing = LocalizingCacheManager.GetLocalizing("SystemManagement", "Login", logonConfig.DefaultCulture.ToString());
		if (logonConfig.EnableMultiLanguage)
		{
			logonConfig.AllCulture = (from c in LocalizingCacheManager.GetAllLanguage()
				orderby c.SORT
				select c).ToList();
		}
		else
		{
			logonConfig.AllCulture = (from x in LocalizingCacheManager.GetAllLanguage()
				where x.CULTURE.Equals(logonConfig.DefaultCulture.ToString())
				orderby x.SORT
				select x).ToList();
		}
		if (logonConfig.EnableDomain)
		{
			logonConfig.AllDomain = DomainManager.GetAllDomain();
		}
		return logonConfig;
	}
}
