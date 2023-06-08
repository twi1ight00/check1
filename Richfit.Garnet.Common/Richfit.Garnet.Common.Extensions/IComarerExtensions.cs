using System;
using System.Collections;
using System.Collections.Generic;
using Richfit.Garnet.Common.Collections;

namespace Richfit.Garnet.Common.Extensions;

/// <summary>
/// <see cref="T:System.Collections.IComparer" /> 类型扩展方法
/// </summary>
public static class IComarerExtensions
{
	/// <summary>
	/// 将当前 <see cref="T:System.Collections.IComparer" /> 类型比较器转换为 <see cref="T:System.Collections.Generic.IComparer`1" /> 类型比较器
	/// </summary>
	/// <param name="comparer">当前比较器</param>
	/// <returns>转换后的泛型比较器</returns>
	/// <exception cref="T:System.ArgumentNullException">当前比较器为空。</exception>
	public static IComparer<object> ToComparer(this IComparer comparer)
	{
		comparer.GuardNotNull("comparer");
		return new CustomComparer<object>((Comparison<object>)comparer.Compare);
	}
}
