using System.Configuration;
using System.Web.Configuration;

namespace Richfit.Garnet.Common.Configuration;

/// <summary>
/// Web系统配置适配器
/// </summary>
public class WebConfigurationAdapter : ConfigurationAdapter
{
	/// <summary>
	/// 初始化
	/// </summary>
	public WebConfigurationAdapter()
	{
	}

	/// <summary>
	/// 初始化
	/// </summary>
	/// <param name="location">配置文件位置</param>
	public WebConfigurationAdapter(string location)
		: base(location)
	{
	}

	/// <summary>
	/// 获取Web系统的web.config的配置对象
	/// </summary>
	/// <returns>加载的配置对象</returns>
	public override System.Configuration.Configuration OpenConfiguration()
	{
		return base.Configuration = WebConfigurationManager.OpenWebConfiguration("/");
	}

	/// <summary>
	/// 获取Web系统的web.config的配置对象
	/// </summary>
	/// <param name="location">Web系统位置</param>
	/// <returns>加载的配置对象</returns>
	public override System.Configuration.Configuration OpenConfiguration(string location)
	{
		return base.Configuration = WebConfigurationManager.OpenWebConfiguration(location);
	}
}
