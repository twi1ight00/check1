using System;
using Richfit.Garnet.Common.Patterns;

namespace Richfit.Garnet.Common.Configuration.Sources;

/// <summary>
/// 可刷新配置源接口
/// </summary>
public interface IRefreshableConfigurationSource : IConfigurationSource, ISyncableObject, IDisposableObject, IDisposable
{
	/// <summary>
	/// 刷新配置源
	/// </summary>
	void Refresh();
}
