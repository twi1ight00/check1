using System;
using Richfit.Garnet.Common.Configuration.Designs;
using Richfit.Garnet.Common.Patterns;

namespace Richfit.Garnet.Common.Configuration.Sources;

/// <summary>
/// Unity容器拦截配置源接口
/// </summary>
public interface IInterceptionGroupConfigurationSource : IConfigurationSource, ISyncableObject, IDisposableObject, IDisposable
{
	/// <summary>
	/// 获取或者设置配置的原始文本
	/// </summary>
	string Text { get; }

	/// <summary>
	/// 获取拦截配置节
	/// </summary>
	/// <returns>拦截配置节</returns>
	PolicyInterceptionSection GetConfiguration();
}
