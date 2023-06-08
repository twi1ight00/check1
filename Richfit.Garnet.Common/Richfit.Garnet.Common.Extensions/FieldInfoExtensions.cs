using System;
using System.Reflection;
using Richfit.Garnet.Common.Properties;
using Richfit.Garnet.Common.Reflection;

namespace Richfit.Garnet.Common.Extensions;

/// <summary>
/// FieldInfo类型扩展方法类
/// </summary>
public static class FieldInfoExtensions
{
	/// <summary>
	/// 获取当前字段的访问级别
	/// </summary>
	/// <param name="finfo">当前字段对象</param>
	/// <returns>当前字段的访问级别</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字段对象为空。</exception>
	public static AccessLevels GetAccessLevel(this FieldInfo finfo)
	{
		finfo.GuardNotNull("field");
		AccessLevels level = AccessLevels.Unspecified;
		if (finfo.IsPublic)
		{
			level = AccessLevels.Public;
		}
		else if (finfo.IsFamilyOrAssembly)
		{
			level = AccessLevels.FamilyOrAssembly;
		}
		else if (finfo.IsAssembly)
		{
			level = AccessLevels.Assembly;
		}
		else if (finfo.IsFamily)
		{
			level = AccessLevels.Family;
		}
		else if (finfo.IsFamilyAndAssembly)
		{
			level = AccessLevels.FamilyAndAssembly;
		}
		else
		{
			if (!finfo.IsPrivate)
			{
				throw new NotSupportedException(Literals.MSG_InvalidAccessibilityLevel);
			}
			level = AccessLevels.Private;
		}
		if (finfo.IsStatic)
		{
			return level | AccessLevels.Static;
		}
		return level | AccessLevels.Instance;
	}

	/// <summary>
	/// 获取当前静态字段的字段值
	/// </summary>
	/// <param name="finfo">当前静态字段</param>
	/// <returns>获取的字段值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前静态字段为空。</exception>
	public static object GetValue(this FieldInfo finfo)
	{
		finfo.GuardNotNull("field info");
		return finfo.GetValue(null);
	}

	/// <summary>
	/// 获取当前静态字段的字段值
	/// </summary>
	/// <typeparam name="T">获取的字段值类型</typeparam>
	/// <param name="finfo">当前静态字段</param>
	/// <returns>获取的字段值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前静态字段为空。</exception>
	public static T GetValue<T>(this FieldInfo finfo)
	{
		return finfo.GetValue().ConvertTo<T>();
	}

	/// <summary>
	/// 检测当前字段是否为实例字段
	/// </summary>
	/// <param name="finfo">当前字段对象</param>
	/// <returns>如果当前字段为实例字段返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字段对象为空。</exception>
	public static bool IsInstance(this FieldInfo finfo)
	{
		finfo.GuardNotNull("field info");
		return !finfo.IsStatic;
	}

	/// <summary>
	/// 设置当前静态字段的字段值
	/// </summary>
	/// <param name="finfo">当前静态字段</param>
	/// <param name="value">设置的字段值</param>
	/// <exception cref="T:System.ArgumentNullException">当前静态字段为空。</exception>
	public static void SetValue(this FieldInfo finfo, object value)
	{
		finfo.GuardNotNull("field info");
		finfo.SetValue(null, value);
	}
}
