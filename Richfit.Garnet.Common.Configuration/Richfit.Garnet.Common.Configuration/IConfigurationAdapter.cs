using System;
using System.Configuration;
using Richfit.Garnet.Common.Patterns;

namespace Richfit.Garnet.Common.Configuration;

/// <summary>
/// 配置信息的适配器
/// 在不同的系统结构上获取配置对象
/// </summary>
public interface IConfigurationAdapter : IDisposableObject, IDisposable
{
	/// <summary>
	/// 获取当前的配置对象
	/// </summary>
	System.Configuration.Configuration Current { get; }

	/// <summary>
	/// 获取系统默认的配置对象
	/// 客户端系统为app.config的配置对象
	/// Web系统为web.config的配置对象
	/// </summary>
	/// <returns>加载的配置对象</returns>
	System.Configuration.Configuration OpenConfiguration();

	/// <summary>
	/// 获取指定位置下的配置文件的对象
	/// </summary>
	/// <param name="location">配置文件位置</param>
	/// <returns>加载的配置对象</returns>
	System.Configuration.Configuration OpenConfiguration(string location);

	/// <summary>
	/// 获取默认配置对象的配置节
	/// 如果需要获取特定的配置节，请先使用相应的GetConfiguration方法，打开配置对象
	/// </summary>
	/// <param name="sectionName">配置节名称</param>
	/// <returns>匹配的配置节，无法找到配置节返回null</returns>
	ConfigurationSection GetSection(string sectionName);
}
