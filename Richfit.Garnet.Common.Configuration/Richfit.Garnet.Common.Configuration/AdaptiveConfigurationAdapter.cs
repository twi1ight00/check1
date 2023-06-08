using System.Configuration;
using System.IO;
using System.Web.Configuration;
using Richfit.Garnet.Common.Extensions;

namespace Richfit.Garnet.Common.Configuration;

/// <summary>
/// 自适应配置提供器
/// </summary>
public class AdaptiveConfigurationAdapter : ConfigurationAdapter
{
	/// <summary>
	/// 初始化自适应配置提供器
	/// </summary>
	public AdaptiveConfigurationAdapter()
	{
	}

	/// <summary>
	/// 获取配置对象
	/// </summary>
	/// <returns>加载的配置对象</returns>
	public override System.Configuration.Configuration OpenConfiguration()
	{
		if (File.Exists("Web.config".GetAbsolutePath()))
		{
			base.Configuration = WebConfigurationManager.OpenWebConfiguration("/");
		}
		else
		{
			base.Configuration = System.Configuration.ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
		}
		return base.Configuration;
	}

	/// <summary>
	/// 获取配置对象
	/// </summary>
	/// <param name="location">Web系统位置</param>
	/// <returns>加载的配置对象</returns>
	public override System.Configuration.Configuration OpenConfiguration(string location)
	{
		if (File.Exists("Web.config".GetAbsolutePath()))
		{
			base.Configuration = WebConfigurationManager.OpenWebConfiguration(location);
		}
		else
		{
			base.Configuration = System.Configuration.ConfigurationManager.OpenMappedExeConfiguration(new ExeConfigurationFileMap
			{
				ExeConfigFilename = location
			}, ConfigurationUserLevel.None);
		}
		return base.Configuration;
	}
}
