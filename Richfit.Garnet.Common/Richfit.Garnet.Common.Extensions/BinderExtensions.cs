using System;
using System.Reflection;

namespace Richfit.Garnet.Common.Extensions;

/// <summary>
/// <see cref="T:System.Reflection.Binder" /> 类型扩展方法类
/// </summary>
public static class BinderExtensions
{
	/// <summary>
	/// CanConvertPrimitive 方法句柄
	/// </summary>
	private static MethodInfo handlerForCanConvertPrimitive = null;

	/// <summary>
	/// CanConvertPrimitiveObjectToType 方法句柄
	/// </summary>
	private static MethodInfo handlerForCanConvertPrimitiveObjectToType = null;

	/// <summary>
	/// 检测源类型和目标类型之间是否可以执行基元的默认转换
	/// </summary>
	/// <param name="binder">当前绑定器</param>
	/// <param name="source">转换的源类型</param>
	/// <param name="target">转换的目标类型</param>
	/// <returns>如果可以执行默认转换返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的绑定器为空；或者转换的源类型 <paramref name="source" /> 为空；或者转换的目标类型 <paramref name="target" /> 为空。</exception>
	public static bool CanConvertPrimitive(this Binder binder, Type source, Type target)
	{
		binder.GuardNotNull("binder");
		source.GuardNotNull("source");
		target.GuardNotNull("target");
		if (handlerForCanConvertPrimitive.IsNull())
		{
			handlerForCanConvertPrimitive = Type.GetType("System.DefaultBinder").GetMethod("CanConvertPrimitive", BindingFlags.Static | BindingFlags.NonPublic);
			if (handlerForCanConvertPrimitive.IsNull())
			{
				throw new MissingMethodException("System.DefaultBinder", "CanConvertPrimitive");
			}
		}
		return (bool)handlerForCanConvertPrimitive.Invoke(null, new object[2] { source.UnderlyingSystemType, target.UnderlyingSystemType });
	}

	/// <summary>
	/// 检测源对象是否可以默认转换为目标的基元类型
	/// </summary>
	/// <param name="binder">当前绑定器</param>
	/// <param name="source">转换的源对象</param>
	/// <param name="target">转换的目标类型</param>
	/// <returns>如果可以执行默认的转换返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的绑定器为空；或者转换的源对象 <paramref name="source" /> 为空；或者转换的目标类型 <paramref name="target" /> 为空。</exception>
	public static bool CanConvertPrimitiveObjectToType(this Binder binder, object source, Type target)
	{
		binder.GuardNotNull("binder");
		source.GuardNotNull("source");
		target.GuardNotNull("target");
		if (handlerForCanConvertPrimitiveObjectToType.IsNull())
		{
			handlerForCanConvertPrimitiveObjectToType = Type.GetType("System.DefaultBinder").GetMethod("CanConvertPrimitiveObjectToType", BindingFlags.Static | BindingFlags.NonPublic);
			if (handlerForCanConvertPrimitiveObjectToType.IsNull())
			{
				throw new MissingMethodException("System.DefaultBinder", "CanConvertPrimitiveObjectToType");
			}
		}
		return (bool)handlerForCanConvertPrimitiveObjectToType.Invoke(null, new object[2] { source, target.UnderlyingSystemType });
	}
}
