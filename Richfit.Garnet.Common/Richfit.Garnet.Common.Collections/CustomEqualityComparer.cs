using System;
using System.Collections;
using System.Collections.Generic;
using Richfit.Garnet.Common.Extensions;

namespace Richfit.Garnet.Common.Collections;

/// <summary>
/// 可自定义的相等比较器
/// </summary>
/// <typeparam name="T">比较器基础类型</typeparam>
public class CustomEqualityComparer<T> : IEqualityComparer<T>
{
	/// <summary>
	/// 获取或者设置对象相等比较方法
	/// </summary>
	protected virtual Func<T, T, bool> Equalition { get; set; }

	/// <summary>
	/// 获取或者设置对象散列值计算方法
	/// </summary>
	protected virtual Func<T, int> Hashing { get; set; }

	/// <summary>
	/// 初始化相等比较器
	/// </summary>
	public CustomEqualityComparer()
	{
		Equalition = EqualityComparer<T>.Default.Equals;
		Hashing = (T x) => (!object.ReferenceEquals(x, null)) ? x.GetHashCode() : 0;
	}

	/// <summary>
	/// 使用对象相等比较方法初始化相等比较器
	/// </summary>
	/// <param name="equalition">对象相等比较方法</param>
	/// <exception cref="T:System.ArgumentNullException">对象相等比较方法 <paramref name="equalition" /> 为空</exception>
	public CustomEqualityComparer(Func<T, T, bool> equalition)
		: this()
	{
		equalition.GuardNotNull("equalition");
		Equalition = equalition;
	}

	/// <summary>
	/// 使用对象相等比较方法和对象哈希值计算方法初始化相等比较器
	/// </summary>
	/// <param name="equalition">对象相等比较方法</param>
	/// <param name="hashing">对象哈希值计算方法</param>
	/// <exception cref="T:System.ArgumentNullException">对象相等比较方法 <paramref name="equalition" /> 为空；或者对象哈希值计算方法 <paramref name="hashing" /> 为空。</exception>
	public CustomEqualityComparer(Func<T, T, bool> equalition, Func<T, int> hashing)
	{
		equalition.GuardNotNull("equalition");
		hashing.GuardNotNull("hashing");
		Equalition = equalition;
		Hashing = hashing;
	}

	/// <summary>
	/// 检测两个对象是否相等
	/// </summary>
	/// <param name="x">参与比较的第一个对象</param>
	/// <param name="y">参与比较的第二个对象</param>
	/// <returns>如果两个对象相等返回true，否则返回false</returns>
	public bool Equals(T x, T y)
	{
		return Equalition(x, y);
	}

	/// <summary>
	/// 获取对象的哈希值
	/// </summary>
	/// <param name="obj">需要计算哈希值的对象</param>
	/// <returns>计算出的对象的哈希值</returns>
	public int GetHashCode(T obj)
	{
		return Hashing(obj);
	}
}
/// <summary>
/// 自定义对象相等比较器
/// </summary>
public class CustomEqualityComparer : CustomEqualityComparer<object>, IEqualityComparer
{
	/// <summary>
	/// 初始化相等比较器
	/// </summary>
	public CustomEqualityComparer()
	{
		Equalition = delegate(object x, object y)
		{
			if (!object.ReferenceEquals(x, null))
			{
				return x.Equals(y);
			}
			return object.ReferenceEquals(y, null) || y.Equals(x);
		};
		Hashing = (object x) => (!object.ReferenceEquals(x, null)) ? x.GetHashCode() : 0;
	}

	/// <summary>
	/// 使用指定的相等比较方法初始化相等比较器
	/// </summary>
	/// <param name="equalition">对象相等比较方法</param>
	/// <exception cref="T:System.ArgumentNullException">对象相等比较方法 <paramref name="equalition" /> 为空</exception>
	public CustomEqualityComparer(Func<object, object, bool> equalition)
		: this()
	{
		equalition.GuardNotNull("equalition");
		Equalition = equalition;
	}

	/// <summary>
	/// 使用指定的相等比较方法和哈希计算方法初始化相等比较器
	/// </summary>
	/// <param name="equalition">对象相等比较方法</param>
	/// <param name="hashing">对象哈希值计算方法</param>
	/// <exception cref="T:System.ArgumentNullException">对象相等比较方法 <paramref name="equalition" /> 为空；或者对象哈希值计算方法 <paramref name="hashing" /> 为空。</exception>
	public CustomEqualityComparer(Func<object, object, bool> equalition, Func<object, int> hashing)
	{
		equalition.GuardNotNull("equalition");
		hashing.GuardNotNull("hashing");
		Equalition = equalition;
		Hashing = hashing;
	}
}
