using System;
using System.Reflection;
using Richfit.Garnet.Common.Properties;
using Richfit.Garnet.Common.Reflection;

namespace Richfit.Garnet.Common.Extensions;

/// <summary>
/// <see cref="T:System.Reflection.MemberInfo" /> 类型扩展方法类
/// </summary>
public static class MemberInfoExtensions
{
	/// <summary>
	/// 获取当前成员的访问级别
	/// </summary>
	/// <param name="minfo">当前成员</param>
	/// <returns>当前成员的访问级别</returns>
	/// <exception cref="T:System.ArgumentNullException">当前成员为空。</exception>
	/// <exception cref="T:System.NotSupportedException">当前成员不支持获取访问级别。</exception>
	public static AccessLevels GetAccessLevel(this MemberInfo minfo)
	{
		minfo.GuardNotNull("member info");
		if (minfo is Type)
		{
			return ((Type)minfo).GetAccessLevel();
		}
		if (minfo is ConstructorInfo)
		{
			return ((ConstructorInfo)minfo).GetAccessLevel();
		}
		if (minfo is PropertyInfo)
		{
			return ((PropertyInfo)minfo).GetAccessLevel();
		}
		if (minfo is MethodBase)
		{
			return ((MethodBase)minfo).GetAccessLevel();
		}
		if (minfo is FieldInfo)
		{
			return ((FieldInfo)minfo).GetAccessLevel();
		}
		if (minfo is EventInfo)
		{
			return ((EventInfo)minfo).GetAccessLevel();
		}
		throw new NotSupportedException(Literals.MSG_InvalidAccessibilityLevel);
	}
}
