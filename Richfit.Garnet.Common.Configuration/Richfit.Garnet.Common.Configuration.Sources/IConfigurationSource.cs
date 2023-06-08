using System;
using Richfit.Garnet.Common.Patterns;

namespace Richfit.Garnet.Common.Configuration.Sources;

/// <summary>
/// 配置源接口
/// </summary>
public interface IConfigurationSource : ISyncableObject, IDisposableObject, IDisposable
{
	/// <summary>
	/// 获取配置源ID
	/// 配置源ID用于标识配置源的唯一状态,如果配置源发生变更,配置源ID会发生变更.
	/// 标识配置源请使用配置源名称
	/// </summary>
	Guid SourceID { get; }

	/// <summary>
	/// 获取配置源名称
	/// </summary>
	string SourceName { get; }

	/// <summary>
	/// 获取或者设置配置源类型，根据该类型可以生成配置源对象
	/// </summary>
	Type SourceType { get; set; }

	/// <summary>
	/// 获取或者设置配置源类别
	/// </summary>
	string Category { get; set; }

	/// <summary>
	/// 获取配置源位置
	/// </summary>
	string Location { get; }

	/// <summary>
	/// 指示配置源是否有效
	/// </summary>
	bool IsValid { get; }

	/// <summary>
	/// 获取或者设置原始配置数据
	/// </summary>
	object RawData { get; set; }

	/// <summary>
	/// 获取配置源所属的配置组
	/// </summary>
	IConfigurationSourceGroup Owner { get; }
}
