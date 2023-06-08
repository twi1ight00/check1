using System;
using Microsoft.Practices.Unity.Configuration;
using Richfit.Garnet.Common.Patterns;

namespace Richfit.Garnet.Common.Configuration.Sources;

/// <summary>
/// Unity配置源接口
/// </summary>
public interface IUnityGroupConfigurationSource : IConfigurationSource, ISyncableObject, IDisposableObject, IDisposable
{
	/// <summary>
	/// 获取或者设置配置的原始文本
	/// </summary>
	string Text { get; }

	/// <summary>
	/// 获取Unity配置节
	/// </summary>
	/// <returns>Unity配置节</returns>
	UnityConfigurationSection GetConfiguration();
}
