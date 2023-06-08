using System;

namespace Richfit.Garnet.Common.Cache.Provider;

/// <summary>
/// 缓存提供者接口
/// </summary>
public interface ICacheProvider
{
	/// <summary>
	/// 设置缓存项目；如果指定缓存项目存在则覆盖；缓存项目常驻内存不过期
	/// </summary>
	/// <param name="key">缓存项目的键</param>
	/// <param name="value">缓存项目的值</param>
	void Set(string key, object value);

	/// <summary>
	/// 设置缓存项目；如果指定缓存项目存在则覆盖；缓存项目驻留 <paramref name="slidingSpan" /> 指定的时间
	/// </summary>
	/// <param name="key">缓存项目的键</param>
	/// <param name="value">缓存项目的值</param>
	/// <param name="slidingSpan">项目在缓存中驻留的时间</param>
	void Set(string key, object value, TimeSpan slidingSpan);

	/// <summary>
	/// 设置缓存项目；如果指定缓存项目存在则覆盖；缓存项目的值由处理函数 <paramref name="valueUpdating" /> 提供
	/// </summary>
	/// <typeparam name="T">添加的缓存项目的类型</typeparam>
	/// <param name="key">缓存项目的键</param>
	/// <param name="valueUpdating">缓存项目的值处理函数</param>
	void Set<T>(string key, Func<T, T> valueUpdating);

	/// <summary>
	/// 设置缓存项目；如果指定缓存项目存在则覆盖；缓存项目驻留 <paramref name="slidingSpan" /> 指定的时间；缓存项目的值由处理函数 <paramref name="valueUpdating" /> 提供
	/// </summary>
	/// <typeparam name="T">添加的缓存项目的类型</typeparam>
	/// <param name="key">缓存项目的键</param>
	/// <param name="slidingSpan">驻留内存时间</param>
	/// <param name="valueUpdating">缓存项目的值处理函数</param>
	void Set<T>(string key, TimeSpan slidingSpan, Func<T, T> valueUpdating);

	/// <summary>
	/// 获取具有指定键的缓存项目的值
	/// </summary>
	/// <param name="key">缓存项目的键</param>
	/// <returns>获取的缓存项目的值</returns>
	object Get(string key);

	/// <summary>
	/// 根据键值移除缓存对象
	/// </summary>
	/// <param name="key">移除的缓存项目的键</param>
	/// <returns>如果成功移除返回移除的项目值，否则返回空</returns>
	object Remove(string key);

	/// <summary>
	/// 移除缓存中的所有项目
	/// </summary>
	void RemoveAll();

	/// <summary>
	/// 检测缓存中是否存在具有指定的键的项目
	/// </summary>
	/// <param name="key">缓存项目的键</param>
	/// <returns>如果存在返回true，否则返回false。</returns>
	bool Contains(string key);
}
