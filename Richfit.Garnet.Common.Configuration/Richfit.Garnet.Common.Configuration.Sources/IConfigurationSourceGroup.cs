using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Richfit.Garnet.Common.Patterns;

namespace Richfit.Garnet.Common.Configuration.Sources;

/// <summary>
/// 配置组接口
/// </summary>
public interface IConfigurationSourceGroup : IConfigurationSource, ISyncableObject, IDisposableObject, IDisposable, IEnumerable<IConfigurationSource>, IEnumerable
{
	/// <summary>
	/// 配置组标识, 当配置组的内容发生变更后, 配置组的标识应发生更改
	/// </summary>
	Guid GroupID { get; }

	/// <summary>
	/// 获取配置组所属的配置源
	/// </summary>
	new IConfigurationSource Owner { get; }

	/// <summary>
	/// 获取配置集合中包含的配置源数量
	/// </summary>
	int Count { get; }

	/// <summary>
	/// 获取配置集合中有效配置源的数组
	/// </summary>
	IConfigurationSource[] Sources { get; }

	/// <summary>
	/// 刷新配置源集合中的项目
	/// </summary>
	void Refresh();

	/// <summary>
	/// 保存配置源集合中的项目
	/// </summary>
	void Save();

	/// <summary>
	/// 获取配置集合中的所有的配置源
	/// </summary>
	/// <param name="predicate">配置源过滤条件，为null则视为未指定条件</param>
	/// <returns>获取的配置源数组</returns>
	IConfigurationSource[] GetSources(Func<IConfigurationSource, bool> predicate = null);

	/// <summary>
	/// 获取配置集合中的所有配置源及其子配置源的序列
	/// </summary>
	/// <param name="predicate">配置源过滤条件，为null则视为未指定条件</param>
	/// <returns>获取的配置源及其子配置源的数组</returns>
	IConfigurationSource[] GetGroupSources(Func<IConfigurationSource, bool> predicate = null);

	/// <summary>
	/// 获取配置集合中的所有配置源及其子配置源的序列
	/// </summary>
	/// <typeparam name="T">配置源类型</typeparam>
	/// <returns>匹配的配置源数组</returns>
	T[] GetGroupSources<T>();

	/// <summary>
	/// 获取符合类型的所有的配置源
	/// </summary>
	/// <typeparam name="T">配置源类型</typeparam>
	/// <returns>匹配的配置源数组</returns>
	T[] GetSources<T>() where T : IConfigurationSource;

	/// <summary>
	/// 获取符合类型的所有的配置源
	/// </summary>
	/// <param name="type">配置源类型</param>
	/// <returns>匹配的配置源数组</returns>
	IConfigurationSource[] GetSources(Type type);

	/// <summary>
	/// 获取匹配指定ID的配置源
	/// </summary>
	/// <param name="id">配置源ID</param>
	/// <returns>匹配的配置源数组</returns>
	IConfigurationSource[] GetSources(Guid id);

	/// <summary>
	/// 获取匹配指定ID的配置源
	/// </summary>
	/// <typeparam name="T">配置源类型</typeparam>
	/// <param name="id">配置源ID</param>
	/// <returns>匹配的配置源数组</returns>
	T[] GetSources<T>(Guid id) where T : IConfigurationSource;

	/// <summary>
	/// 获取匹配指定ID的配置源
	/// </summary>
	/// <param name="id">配置源ID</param>
	/// <param name="type">配置源类型</param>
	/// <returns>匹配的配置源数组</returns>
	IConfigurationSource[] GetSources(Guid id, Type type);

	/// <summary>
	/// 获取匹配指定名称的配置源
	/// </summary>
	/// <param name="name">配置源名称</param>
	/// <param name="ignoreCase">配置源名称是否忽略大小写</param>
	/// <returns>匹配的配置源数组</returns>
	IConfigurationSource[] GetSources(string name, bool ignoreCase = true);

	/// <summary>
	/// 获取匹配指定名称的配置源
	/// </summary>
	/// <param name="pattern">配置源名称的正则匹配模式</param>
	/// <param name="options">正则表达式选项</param>
	/// <param name="wholeMatching">是否进行完整匹配，默认为false。</param>
	/// <returns>匹配的配置源数组</returns>
	IConfigurationSource[] GetSources(string pattern, RegexOptions options, bool wholeMatching = false);

	/// <summary>
	/// 获取匹配指定名称的配置源
	/// </summary>
	/// <param name="pattern">配置源名称的正则匹配模式</param>
	/// <param name="wholeMatching">是否进行完整匹配，默认为false。</param>
	/// <returns>匹配的配置源数组</returns>
	IConfigurationSource[] GetSources(Regex pattern, bool wholeMatching = false);

	/// <summary>
	/// 获取符合类型具有指定名称的所有配置源
	/// </summary>
	/// <typeparam name="T">配置源类型</typeparam>
	/// <param name="name">配置源名称</param>
	/// <param name="ignoreCase">配置源名称是否忽略大小写</param>
	/// <returns>匹配的配置源数组</returns>
	T[] GetSources<T>(string name, bool ignoreCase = true) where T : IConfigurationSource;

	/// <summary>
	/// 获取符合类型具有指定名称的所有的配置源
	/// </summary>
	/// <param name="name">配置源名称</param>
	/// <param name="type">配置源类型</param>
	/// <param name="ignoreCase">配置源名称是否忽略大小写</param>
	/// <returns>匹配的配置源数组</returns>
	IConfigurationSource[] GetSources(string name, Type type, bool ignoreCase = true);

	/// <summary>
	/// 获取符合类型的第一个配置源
	/// </summary>
	/// <typeparam name="T">配置源类型</typeparam>
	/// <returns>匹配的第一个配置源，如果没有匹配的配置源返回null</returns>
	T GetSource<T>() where T : IConfigurationSource;

	/// <summary>
	/// 获取符合类型的第一个配置源
	/// </summary>
	/// <param name="type">配置源类型</param>
	/// <returns>匹配的第一个配置源，如果没有匹配的配置源返回null</returns>
	IConfigurationSource GetSource(Type type);

	/// <summary>
	/// 获取指定ID的配置源
	/// </summary>
	/// <param name="id">配置源ID</param>
	/// <returns>匹配的第一个配置源，如果没有匹配的配置源返回null</returns>
	IConfigurationSource GetSource(Guid id);

	/// <summary>
	/// 获取指定ID的配置源
	/// </summary>
	/// <typeparam name="T">配置源类型</typeparam>
	/// <param name="id">配置源ID</param>
	/// <returns>匹配的第一个配置源，如果没有匹配的配置源返回null</returns>
	T GetSource<T>(Guid id) where T : IConfigurationSource;

	/// <summary>
	/// 获取指定名称的配置源
	/// </summary>
	/// <param name="id">配置源ID</param>
	/// <param name="type">配置源类型</param>
	/// <returns>匹配的第一个配置源，如果没有匹配的配置源返回null</returns>
	IConfigurationSource GetSource(Guid id, Type type);

	/// <summary>
	/// 获取指定名称的配置源
	/// </summary>
	/// <param name="name">配置源名称</param>
	/// <param name="ignoreCase">配置源名称是否忽略大小写</param>
	/// <returns>匹配的第一个配置源，如果没有匹配的配置源返回null</returns>
	IConfigurationSource GetSource(string name, bool ignoreCase = true);

	/// <summary>
	/// 获取指定名称的配置源
	/// </summary>
	/// <typeparam name="T">配置源类型</typeparam>
	/// <param name="name">配置源名称</param>
	/// <param name="ignoreCase">配置源名称是否忽略大小写</param>
	/// <returns>匹配的第一个配置源，如果没有匹配的配置源返回null</returns>
	T GetSource<T>(string name, bool ignoreCase = true) where T : IConfigurationSource;

	/// <summary>
	/// 获取指定名称的配置源
	/// </summary>
	/// <param name="name">配置源名称</param>
	/// <param name="type">配置源类型</param>
	/// <param name="ignoreCase">配置源名称是否忽略大小写</param>
	/// <returns>匹配的第一个配置源，如果没有匹配的配置源返回null</returns>
	IConfigurationSource GetSource(string name, Type type, bool ignoreCase = true);

	/// <summary>
	/// 添加配置源，同一个配置源只添加一次，重复添加则会忽略。
	/// </summary>
	/// <param name="source">待添加的配置源</param>
	/// <returns>如果添加成功返回true，否则返回false</returns>
	bool Add(IConfigurationSource source);

	/// <summary>
	/// 添加配置源序列
	/// </summary>
	/// <param name="sources">待添加的配置源序列</param>
	/// <returns>成功添加的配置源数量</returns>
	int AddRange(IEnumerable<IConfigurationSource> sources);

	/// <summary>
	/// 移除配置源
	/// </summary>
	/// <param name="source">待移除的配置源</param>
	/// <returns>移除是否成功</returns>
	bool Remove(IConfigurationSource source);

	/// <summary>
	/// 移除指定类型的配置源
	/// </summary>
	/// <typeparam name="T">配置源类型</typeparam>
	/// <returns>是否移除成功</returns>
	bool Remove<T>() where T : IConfigurationSource;

	/// <summary>
	/// 移除指定类型的配置源
	/// </summary>
	/// <param name="type">配置源类型</param>
	/// <returns>是否移除成功</returns>
	bool Remove(Type type);

	/// <summary>
	/// 移除指定ID的配置源
	/// </summary>
	/// <param name="id">配置源ID</param>
	/// <returns>移除是否成功</returns>
	bool Remove(Guid id);

	/// <summary>
	/// 移除指定名称的配置源
	/// </summary>
	/// <param name="name">配置源名称</param>
	/// <param name="ignoreCase">配置源名称是否忽略大小写</param>
	/// <returns>移除是否成功</returns>
	bool Remove(string name, bool ignoreCase = true);

	/// <summary>
	/// 清空配置源集合
	/// </summary>
	void Clear();
}
