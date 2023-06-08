using System;

namespace Richfit.Garnet.Common.Extensions;

/// <summary>
/// <see cref="T:System.Nullable`1" /> 类型扩展方法类
/// </summary>
public static class NullableExtensions
{
	/// <summary>
	/// 获取可空类型的值，如果可空类型为空则返回DBNull，否则返回可空类型的值
	/// </summary>
	/// <typeparam name="T">当前可空类型的基础类型</typeparam>
	/// <param name="value">当期可空类型的值</param>
	/// <returns>当前可空类型不为空时，返回可空类型的基础值；为空时返回 <see cref="T:System.DBNull" />。</returns>
	public static object EnsureDBNull<T>(this T? value) where T : struct
	{
		return value.HasValue ? ((object)value.Value) : DBNull.Value;
	}
}
