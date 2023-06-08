using System.Collections;

namespace Richfit.Garnet.Common.Extensions.Collections;

/// <summary>
/// <see cref="T:System.Collections.ICollection" /> 接口类型扩展方法类
/// </summary>
public static class ICollectionExtensions
{
	/// <summary>
	/// 将当前集合作为 <see cref="T:System.Collections.ICollection" /> 类型返回
	/// </summary>
	/// <param name="collection">当前集合</param>
	/// <returns><see cref="T:System.Collections.ICollection" /> 类型的集合</returns>
	public static ICollection AsCollection(this ICollection collection)
	{
		return collection;
	}

	/// <summary>
	/// 检测当前集合是否为空或者不包含任何元素。
	/// </summary>
	/// <param name="collection">当前集合</param>
	/// <returns>如果当前集合为空或者不包含任何元素返回true，否则返回false。</returns>
	public static bool IsNullOrEmpty(this ICollection collection)
	{
		return collection.IsNull() || collection.Count == 0;
	}

	/// <summary>
	/// 检测当前集合是否不为空且包含元素
	/// </summary>
	/// <param name="collection">当前集合</param>
	/// <returns>如果当前集合不为空且包含元素返回true，否则返回false。</returns>
	public static bool IsNotNullAndEmpty(this ICollection collection)
	{
		return collection.IsNotNull() && collection.Count > 0;
	}
}
