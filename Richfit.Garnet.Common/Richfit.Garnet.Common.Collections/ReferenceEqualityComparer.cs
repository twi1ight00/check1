using System.Collections;
using System.Collections.Generic;

namespace Richfit.Garnet.Common.Collections;

/// <summary>
/// 对象引用相等比较器
/// </summary>
/// <typeparam name="T">比较器基础类型</typeparam>
public class ReferenceEqualityComparer<T> : IEqualityComparer<T>
{
	/// <summary>
	/// 比较两个对象的引用是否相等
	/// </summary>
	/// <param name="x">进行比较的第一个对象</param>
	/// <param name="y">进行比较的第二个对象</param>
	/// <returns>如果两个对象引用相等（是同一个实例），则返回true，否则返回false</returns>
	public bool Equals(T x, T y)
	{
		return object.ReferenceEquals(x, y);
	}

	/// <summary>
	/// 计算指定对象的哈希值
	/// </summary>
	/// <param name="obj">要计算哈希值的对象</param>
	/// <returns>计算出的对象的哈希值</returns>
	public int GetHashCode(T obj)
	{
		return 0;
	}
}
/// <summary>
/// 对象引用相等比较器
/// </summary>
public class ReferenceEqualityComparer : IEqualityComparer
{
	/// <summary>
	/// 比较两个对象的引用是否相等
	/// </summary>
	/// <param name="x">进行比较的第一个对象</param>
	/// <param name="y">进行比较的第二个对象</param>
	/// <returns>如果两个对象引用相等（是同一个实例），则返回true，否则返回false</returns>
	public new bool Equals(object x, object y)
	{
		return object.ReferenceEquals(x, y);
	}

	/// <summary>
	/// 计算指定对象的哈希值
	/// </summary>
	/// <param name="obj">要计算哈希值的对象</param>
	/// <returns>计算出的对象的哈希值</returns>
	public int GetHashCode(object obj)
	{
		return 0;
	}
}
