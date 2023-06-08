using System.Configuration;

namespace Richfit.Garnet.Common.Configuration;

/// <summary>
/// 客户端应用程序配置适配器
/// </summary>
public class ApplicationConfigurationAdapter : ConfigurationAdapter
{
	/// <summary>
	/// 初始化
	/// </summary>
	public ApplicationConfigurationAdapter()
	{
	}

	/// <summary>
	/// 初始化
	/// </summary>
	/// <param name="location">配置文件位置</param>
	public ApplicationConfigurationAdapter(string location)
		: base(location)
	{
	}

	/// <summary>
	/// 获取应用系统的app.config的配置对象
	/// </summary>
	/// <returns>加载的配置对象</returns>
	public override System.Configuration.Configuration OpenConfiguration()
	{
		return base.Configuration = System.Configuration.ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
	}

	/// <summary>
	/// 获取应用系统的app.config的配置对象
	/// </summary>
	/// <param name="location">配置文件位置</param>
	/// <returns>加载的配置对象</returns>
	public override System.Configuration.Configuration OpenConfiguration(string location)
	{
		return base.Configuration = System.Configuration.ConfigurationManager.OpenMappedExeConfiguration(new ExeConfigurationFileMap
		{
			ExeConfigFilename = location
		}, ConfigurationUserLevel.None);
	}
}
