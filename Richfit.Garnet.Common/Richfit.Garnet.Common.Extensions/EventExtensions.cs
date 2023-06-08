using System;
using System.Reflection;
using Richfit.Garnet.Common.Properties;
using Richfit.Garnet.Common.Reflection;

namespace Richfit.Garnet.Common.Extensions;

/// <summary>
/// <see cref="T:System.Reflection.EventInfo" /> 类型扩展方法类
/// </summary>
public static class EventExtensions
{
	/// <summary>
	/// 获取当前事件的访问级别，属性的访问级别由get和set方法的最高级别决定
	/// </summary>
	/// <param name="einfo">当前事件对象</param>
	/// <returns>当前事件的访问级别</returns>
	/// <exception cref="T:System.ArgumentNullException">当前事件对象为空。</exception>
	/// <exception cref="T:System.NotSupportedException">当前事件不支持获取访问级别。</exception>
	public static AccessLevels GetAccessLevel(this EventInfo einfo)
	{
		einfo.GuardNotNull("event info");
		MethodInfo ainfo = einfo.GetAddMethod(nonPublic: true);
		int alevel = (int)((!ainfo.IsNull()) ? ainfo.GetAccessLevel() : AccessLevels.Unspecified);
		MethodInfo rinfo = einfo.GetRemoveMethod(nonPublic: true);
		int rlevel = (int)((!rinfo.IsNull()) ? rinfo.GetAccessLevel() : AccessLevels.Unspecified);
		int result = Math.Min(alevel, rlevel);
		if (result == 0)
		{
			throw new NotSupportedException(Literals.MSG_InvalidAccessibilityLevel);
		}
		return (AccessLevels)result;
	}

	/// <summary>
	/// 检测当前事件是否为实例事件
	/// </summary>
	/// <param name="einfo">当前事件对象</param>
	/// <returns>如果当前事件为实例事件返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前事件对象为空。</exception>
	public static bool IsInstance(this EventInfo einfo)
	{
		einfo.GuardNotNull("event info");
		return !einfo.IsStatic();
	}

	/// <summary>
	/// 检测当前事件是否为静态属性
	/// </summary>
	/// <param name="einfo">当前事件对象</param>
	/// <returns>如果当前事件为静态事件返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前事件事件对象为空。</exception>
	public static bool IsStatic(this EventInfo einfo)
	{
		einfo.GuardNotNull("event info");
		MethodInfo minfo = einfo.GetAddMethod(nonPublic: true);
		if (minfo.IsNotNull())
		{
			return minfo.IsStatic;
		}
		minfo = einfo.GetRemoveMethod(nonPublic: true);
		if (minfo.IsNotNull())
		{
			return minfo.IsStatic;
		}
		return false;
	}
}
