using System;
using Richfit.Garnet.Common.Patterns;

namespace Richfit.Garnet.Common.Configuration.Sources;

/// <summary>
/// 可保存配置源接口
/// </summary>
public interface ISavableConfigurationSource : IConfigurationSource, ISyncableObject, IDisposableObject, IDisposable
{
	/// <summary>
	/// 保存配置源
	/// </summary>
	void Save();
}
