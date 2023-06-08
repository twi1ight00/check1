using System;

namespace Richfit.Garnet.Common.Cache;

/// <summary>
/// 缓存项目实体
/// </summary>
public class CacheEntry
{
	/// <summary>
	/// 缓存加载委托
	/// </summary>
	/// <returns></returns>
	public delegate object LoaderDelegate();

	/// <summary>
	/// 获取或者设置缓存加载委托
	/// </summary>
	public LoaderDelegate LoadDelegate { get; set; }

	/// <summary>
	/// 加载Function
	/// </summary>
	public Func<object, object> LoadFunction { get; set; }

	/// <summary>
	/// Function参数
	/// </summary>
	public object FuntionParam { get; set; }

	/// <summary>
	/// 创建缓存项目实体对象
	/// </summary>
	internal CacheEntry()
	{
	}
}
