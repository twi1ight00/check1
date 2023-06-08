using System;
using System.Collections;
using System.Collections.Generic;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.Properties;

namespace Richfit.Garnet.Common.Collections;

/// <summary>
/// 自定义泛型对象比较器
/// </summary>
/// <typeparam name="T">比较的对象的类型</typeparam>
public class CustomComparer<T> : IComparer<T>
{
	/// <summary>
	/// 获取或者设置对象比较方法
	/// </summary>
	protected virtual Func<T, T, int> Comparison { get; set; }

	/// <summary>
	/// 初始化默认的比较器
	/// </summary>
	public CustomComparer()
	{
		Comparison = Comparer<T>.Default.Compare;
	}

	/// <summary>
	/// 使用指定的对象比较方法初始化比较器
	/// </summary>
	/// <param name="comparison">对象比较方法</param>
	/// <exception cref="T:System.ArgumentNullException">对象比较方法 <paramref name="comparison" /> 为空。</exception>
	public CustomComparer(Func<T, T, int> comparison)
	{
		comparison.GuardNotNull("comparison");
		Comparison = comparison;
	}

	/// <summary>
	/// 使用指定的对象比较方法初始化比较器
	/// </summary>
	/// <param name="comparison">对象比较方法</param>
	/// <exception cref="T:System.ArgumentNullException">对象比较方法 <paramref name="comparison" /> 为空。</exception>
	public CustomComparer(Comparison<T> comparison)
	{
		comparison.GuardNotNull("comparison");
		Func<T, T, int> comparison2 = (T x, T y) => comparison(x, y);
		Comparison = comparison2;
	}

	/// <summary>
	/// 比较两个对象的大小
	/// </summary>
	/// <param name="x">参与比较的第一个对象</param>
	/// <param name="y">参与比较的第二个对象</param>
	/// <returns>如果第一个对象小于第二个对象返回小于零的值；如果第一个对象等于第二个对象返回0；如果第一个对象大于第二个对象返回大于零的值</returns>
	public int Compare(T x, T y)
	{
		return Comparison(x, y);
	}
}
/// <summary>
/// 自定义对象比较器
/// </summary>
public class CustomComparer : CustomComparer<object>, IComparer
{
	/// <summary>
	/// 初始化默认的比较器
	/// </summary>
	public CustomComparer()
	{
		Comparison = delegate(object x, object y)
		{
			if (x is IComparable)
			{
				return ((IComparable)x).CompareTo(y);
			}
			if (!(y is IComparable))
			{
				throw new InvalidOperationException(Literals.MSG_ObjectNotSupportComparison);
			}
			return ((IComparable)y).CompareTo(x);
		};
	}

	/// <summary>
	/// 使用指定的对象比较方法初始化比较器
	/// </summary>
	/// <param name="comparison">对象比较方法</param>
	/// <exception cref="T:System.ArgumentNullException">对象比较方法 <paramref name="comparison" /> 为空。</exception>
	public CustomComparer(Func<object, object, int> comparison)
	{
		comparison.GuardNotNull("comparison");
		Comparison = comparison;
	}
}
