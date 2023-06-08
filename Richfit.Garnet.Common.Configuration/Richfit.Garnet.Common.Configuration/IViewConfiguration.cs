using System;
using System.IO;
using Richfit.Garnet.Common.Configuration.Sources;
using Richfit.Garnet.Common.Patterns;

namespace Richfit.Garnet.Common.Configuration;

/// <summary>
/// 视图化配置接口
/// </summary>
/// <typeparam name="V">视图类型</typeparam>
public interface IViewConfiguration<V> : IConfiguration, IRefreshableConfigurationSource, ISavableConfigurationSource, IWatchingConfigurationSource, IConfigurationSource, ISyncableObject, IDisposableObject, IDisposable where V : IConfigurationView
{
	/// <summary>
	/// 获取配置文件对象
	/// </summary>
	FileInfo File { get; }

	/// <summary>
	/// 默认配置视图，对该视图的更改将会映射到配置源中
	/// </summary>
	V View { get; }
}
