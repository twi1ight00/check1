using System;
using System.Reflection;
using Richfit.Garnet.Common.Properties;
using Richfit.Garnet.Common.Reflection;

namespace Richfit.Garnet.Common.Extensions;

/// <summary>
/// <see cref="T:System.Reflection.PropertyInfo" /> 类型扩展方法类
/// </summary>
public static class PropertyInfoExtensions
{
	/// <summary>
	/// 获取当前属性的访问级别，属性的访问级别由get和set方法的最高级别决定
	/// </summary>
	/// <param name="pinfo">当前属性</param>
	/// <returns>当前属性的访问级别</returns>
	/// <exception cref="T:System.ArgumentNullException">当前属性为空。</exception>
	/// <exception cref="T:System.NotSupportedException">当前属性不支持获取访问级别。</exception>
	public static AccessLevels GetAccessLevel(this PropertyInfo pinfo)
	{
		pinfo.GuardNotNull("property info");
		MethodInfo ginfo = pinfo.GetGetMethod(nonPublic: true);
		int glevel = (int)((!ginfo.IsNull()) ? ginfo.GetAccessLevel() : AccessLevels.Unspecified);
		MethodInfo sinfo = pinfo.GetSetMethod(nonPublic: true);
		int slevel = (int)((!sinfo.IsNull()) ? sinfo.GetAccessLevel() : AccessLevels.Unspecified);
		int result = Math.Min(glevel, slevel);
		if (result == 0)
		{
			throw new NotSupportedException(Literals.MSG_InvalidAccessibilityLevel);
		}
		return (AccessLevels)result;
	}

	/// <summary>
	/// 获取当前静态属性的属性值
	/// </summary>
	/// <param name="pinfo">当前静态属性</param>
	/// <returns>当前静态属性的属性值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前静态属性为空。</exception>
	public static object GetValue(this PropertyInfo pinfo)
	{
		pinfo.GuardNotNull("property info");
		return pinfo.GetValue(null, null);
	}

	/// <summary>
	/// 获取当前属性的属性值
	/// </summary>
	/// <param name="pinfo">当前属性</param>
	/// <param name="obj">当前属性所属类型的实例对象；如果当前属性为静态属性，则该参数需要设置为空</param>
	/// <returns>实例对象的属性值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前属性为空。</exception>
	public static object GetValue(this PropertyInfo pinfo, object obj)
	{
		pinfo.GuardNotNull("property info");
		return pinfo.GetValue(obj, null);
	}

	/// <summary>
	/// 获取当前静态属性的属性值
	/// </summary>
	/// <typeparam name="T">当前属性值类型</typeparam>
	/// <param name="pinfo">当前静态属性</param>
	/// <returns>当前静态属性的属性值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前静态属性为空。</exception>
	public static T GetValue<T>(this PropertyInfo pinfo)
	{
		return pinfo.GetValue().ConvertTo<T>();
	}

	/// <summary>
	/// 获取当前属性的属性值
	/// </summary>
	/// <typeparam name="T">当前属性值类型</typeparam>
	/// <param name="pinfo">当前属性</param>
	/// <param name="obj">当前属性所属类型的实例对象；如果当前属性为静态属性，则该参数需要设置为空</param>
	/// <returns>实例对象的属性值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前属性为空。</exception>
	public static T GetValue<T>(this PropertyInfo pinfo, object obj)
	{
		return GetValue(pinfo, obj).ConvertTo<T>();
	}

	/// <summary>
	/// 检测当前索引属性是否可以使用指定类型的参数进行绑定
	/// </summary>
	/// <param name="property">当前的索引属性对象</param>
	/// <param name="returnType">当前属性的返回值类型，如果不需要绑定返回值则设置为空。</param>
	/// <param name="argTypes">索引属性参数类型数组，如果不需要绑定属性参数则设置为空。</param>
	/// <returns>如果当前索引属性对象可以使用指定类型的参数进行绑定返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前索引属性对象为空；或者索引属性参数类型数组中存在null元素。</exception>
	/// <remarks>当给定的参数类型的数组中每个类型与当前索引属性的参数的类型依次兼容，且无剩余参数或者剩余参数均为可选参数时，认为给定的参数序列与当前索引属性的参数序列可匹配。</remarks>
	public static bool IsBindable(this PropertyInfo property, Type returnType, params Type[] argTypes)
	{
		return property.IsBindable(returnType, argTypes, inheritBinding: false, optionalBinding: false);
	}

	/// <summary>
	/// 检测当前索引属性是否可以使用指定类型的参数进行绑定
	/// </summary>
	/// <param name="property">当前的索引属性对象</param>
	/// <param name="returnType">当前属性的返回值类型，如果不需要绑定返回值则设置为空。</param>
	/// <param name="argTypes">索引属性参数类型数组，如果不需要绑定属性参数则设置为空。</param>
	/// <param name="inheritBinding">设置为true，指示当前属性返回值类型应是给定返回值类型 <paramref name="returnType" /> 的基类或者其本身；设置为false，指示当前属性返回值类型应继承于给定返回值类型 <paramref name="returnType" /> 或者是其本身。</param>
	/// <param name="optionalBinding">对于索引属性的可选参数是否也必须进行绑定，默认为不对可选参数进行绑定</param>
	/// <returns>如果当前索引属性对象可以使用指定类型的参数进行绑定返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前索引属性对象为空；或者索引属性参数类型数组中存在null元素。</exception>
	/// <remarks>当给定的参数类型的序列中每个类型与当前索引属性的参数的类型依次兼容，且无剩余参数或者剩余参数均为可选参数时，认为给定的参数序列与当前索引属性的参数序列可匹配。</remarks>
	public static bool IsBindable(this PropertyInfo property, Type returnType, Type[] argTypes, bool inheritBinding = false, bool optionalBinding = false)
	{
		property.GuardNotNull("property");
		if (argTypes.IsNotNull())
		{
			argTypes.ForEach(delegate(Type p)
			{
				p.GuardNotNull("parameter type");
			});
		}
		if ((returnType.IsNull() || inheritBinding) && (argTypes.IsNull() || optionalBinding))
		{
			return Type.DefaultBinder.SelectProperty(BindingFlags.Default, new PropertyInfo[1] { property }, returnType, argTypes, null).IsNotNull();
		}
		if (returnType.IsNotNull() && ((inheritBinding && !property.PropertyType.IsAssignableFrom(returnType)) || (!inheritBinding && !returnType.IsAssignableFrom(property.PropertyType))))
		{
			return false;
		}
		if (argTypes.IsNotNull())
		{
			ParameterInfo[] pinfos = property.GetIndexParameters();
			if (pinfos.Length < argTypes.Length || (optionalBinding && pinfos.Length != argTypes.Length))
			{
				return false;
			}
			int index;
			for (index = 0; index < pinfos.Length; index++)
			{
				if (!argTypes[index].Equals(pinfos[index].ParameterType) && (!argTypes[index].IsPrimitive || !Type.DefaultBinder.CanConvertPrimitive(argTypes[index], pinfos[index].ParameterType)) && !pinfos[index].ParameterType.IsAssignableFrom(argTypes[index]))
				{
					return false;
				}
			}
			for (int i = index; i < pinfos.Length; i++)
			{
				if (!pinfos[i].IsOptional)
				{
					return false;
				}
			}
			return true;
		}
		return false;
	}

	/// <summary>
	/// 检测当前属性是否为实例属性
	/// </summary>
	/// <param name="pinfo">当前属性对象</param>
	/// <returns>如果当前属性为实例属性返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前属性对象为空。</exception>
	public static bool IsInstance(this PropertyInfo pinfo)
	{
		pinfo.GuardNotNull("property info");
		return !pinfo.IsStatic();
	}

	/// <summary>
	/// 检测当前属性是否为静态属性
	/// </summary>
	/// <param name="pinfo">当前属性对象</param>
	/// <returns>如果当前属性为静态属性返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前属性对象为空。</exception>
	/// <remarks>本方法将查找属性的get或者set方法，如果get方法或者set方法为静态方法，则该属性为静态属性。</remarks>
	public static bool IsStatic(this PropertyInfo pinfo)
	{
		pinfo.GuardNotNull("property info");
		MethodInfo minfo = pinfo.GetGetMethod(nonPublic: true);
		if (minfo.IsNotNull())
		{
			return minfo.IsStatic;
		}
		minfo = pinfo.GetSetMethod(nonPublic: true);
		if (minfo.IsNotNull())
		{
			return minfo.IsStatic;
		}
		return false;
	}

	/// <summary>
	/// 设置当前静态属性的属性值
	/// </summary>
	/// <param name="pinfo">当前静态属性</param>
	/// <param name="value">设置的属性值</param>
	/// <exception cref="T:System.ArgumentNullException">当前静态属性为空。</exception>
	public static void SetValue(this PropertyInfo pinfo, object value)
	{
		pinfo.GuardNotNull("property info");
		pinfo.SetValue(null, value, null);
	}

	/// <summary>
	/// 设置当前属性的属性值
	/// </summary>
	/// <param name="pinfo">当前属性</param>
	/// <param name="obj">当前属性所属类型的实例对象；如果当前属性为静态属性，则该参数需要设置为空</param>
	/// <param name="value">设置的属性值</param>
	/// <exception cref="T:System.ArgumentNullException">当前属性为空。</exception>
	public static void SetValue(this PropertyInfo pinfo, object obj, object value)
	{
		pinfo.GuardNotNull("property info");
		pinfo.SetValue(obj, value, null);
	}
}
