using System;
using Richfit.Garnet.Common.Patterns;

namespace Richfit.Garnet.Common.Configuration.Sources;

/// <summary>
/// 组配置源接口
/// </summary>
[ConfigurationSourceMapping(typeof(GroupConfigurationSource))]
public interface IGroupConfigurationSource : IConfigurationSource, ISyncableObject, IDisposableObject, IDisposable
{
	/// <summary>
	/// 获取容器的子配置源组对象
	/// </summary>
	IConfigurationSourceGroup Group { get; }

	/// <summary>
	/// 获取配置源数组
	/// </summary>
	IConfigurationSource[] Sources { get; }

	/// <summary>
	/// 获取配置源数组及其所有子配置源的数组
	/// </summary>
	IConfigurationSource[] AllSources { get; }

	/// <summary>
	/// 获取指定类型的所有配置源
	/// </summary>
	/// <typeparam name="T">配置源类型</typeparam>
	/// <param name="recursive">是否递归查找所有的子配置源</param>
	/// <returns>指定类型的所有配置源</returns>
	T[] GetAll<T>(bool recursive = false) where T : IConfigurationSource;

	/// <summary>
	/// 获取指定的配置源
	/// </summary>
	/// <typeparam name="T">配置源类型</typeparam>
	/// <param name="recursive">是否递归查找所有的子配置源</param>
	/// <returns>指定类型的配置源</returns>
	T Get<T>(bool recursive = false) where T : IConfigurationSource;

	/// <summary>
	/// 获取指定的配置源
	/// </summary>
	/// <typeparam name="T">配置源类型</typeparam>
	/// <param name="name">配置源类型名称</param>
	/// <param name="recursive">是否递归查找所有的子配置源</param>
	/// <returns>指定类型的配置源</returns>
	T Get<T>(string name, bool recursive = false) where T : IConfigurationSource;
}
