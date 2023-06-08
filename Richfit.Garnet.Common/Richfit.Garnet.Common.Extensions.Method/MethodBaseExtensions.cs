using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Richfit.Garnet.Common.Patterns;
using Richfit.Garnet.Common.Properties;
using Richfit.Garnet.Common.Reflection;

namespace Richfit.Garnet.Common.Extensions.Method;

/// <summary>
/// <see cref="T:System.Reflection.MethodBase" /> 类型扩展方法类
/// </summary>
public static class MethodBaseExtensions
{
	/// <summary>
	/// 使用指定的参数值调用当前方法
	/// </summary>
	/// <param name="method">当前方法</param>
	/// <param name="obj">调用当前方法的对象</param>
	/// <param name="args">用于方法调用的参数数组</param>
	/// <returns>被调用方法的返回值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前方法为空。</exception>
	/// <exception cref="T:System.Reflection.TargetException">当前方法为实例方法，而调用对象 <paramref name="obj" /> 为空。</exception>
	public static object Invoke(this MethodBase method, object obj, params object[] args)
	{
		return method.Invoke(obj, args, optionalBinding: false);
	}

	/// <summary>
	/// 使用指定的参数值调用当前方法
	/// </summary>
	/// <param name="method">当前方法</param>
	/// <param name="obj">调用当前方法的对象</param>
	/// <param name="args">用于方法调用的参数数组</param>
	/// <param name="optionalBinding">对于方法的可选参数是否也必须进行绑定，默认为不对可选参数进行绑定</param>
	/// <returns>被调用方法的返回值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前方法为空。</exception>
	/// <exception cref="T:System.Reflection.TargetException">当前方法为实例方法，而调用对象 <paramref name="obj" /> 为空。</exception>
	public static object Invoke(this MethodBase method, object obj, object[] args, bool optionalBinding)
	{
		return method.Invoke(obj, null, args, optionalBinding);
	}

	/// <summary>
	/// 使用指定的命名参数调用当前方法
	/// </summary>
	/// <param name="method">当前方法</param>
	/// <param name="obj">调用当前方法的对象</param>
	/// <param name="namedArgs">用于调用当前方法的命名参数数组，命名参数的名称区分大小写。</param>
	/// <param name="optionalBinding">对于方法的可选参数是否也必须进行绑定，默认为不对可选参数进行绑定</param>
	/// <returns>被调用方法的返回值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前方法为空。</exception>
	/// <exception cref="T:System.Reflection.TargetException">当前方法为实例方法，而调用对象 <paramref name="obj" /> 为空。</exception>
	public static object Invoke(this MethodBase method, object obj, NamedValue[] namedArgs, bool optionalBinding = false)
	{
		if (namedArgs.IsNull())
		{
			return method.Invoke(obj, null, null, optionalBinding);
		}
		return method.Invoke(obj, namedArgs.Select((NamedValue x) => x.Name).ToArray(), namedArgs.Select((NamedValue x) => x.Value).ToArray(), optionalBinding);
	}

	/// <summary>
	/// 使用指定的命名参数调用当前方法
	/// </summary>
	/// <param name="method">当前方法</param>
	/// <param name="obj">调用当前方法的对象</param>
	/// <param name="namedArgs">用于调用当前方法的参数字典</param>
	/// <param name="optionalBinding">对于方法的可选参数是否也必须进行绑定，默认为不对可选参数进行绑定</param>
	/// <returns>被调用方法的返回值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前方法为空。</exception>
	/// <exception cref="T:System.Reflection.TargetException">当前方法为实例方法，而调用对象 <paramref name="obj" /> 为空。</exception>
	/// <remarks>调用方法时根据指定的参数名称进行参数匹配，参数名称是否区分大小写根据指定的参数字典决定。</remarks>
	public static object Invoke(this MethodBase method, object obj, IDictionary<string, object> namedArgs, bool optionalBinding = false)
	{
		if (namedArgs.IsNull())
		{
			return method.Invoke(obj, null, null, optionalBinding);
		}
		Tuple<string[], object[]> pairs = namedArgs.GetKeyValues();
		return method.Invoke(obj, pairs.Item1, pairs.Item2, optionalBinding);
	}

	/// <summary>
	/// 使用指定的命名参数调用当前方法
	/// </summary>
	/// <param name="method">当前方法</param>
	/// <param name="obj">调用当前方法的对象。</param>
	/// <param name="names">用于的调用的参数的名称数组，参数名称区分大小写</param>
	/// <param name="values">用于调用的参数的值数组</param>
	/// <param name="optionalBinding">对于方法的可选参数是否也必须进行绑定，默认为不对可选参数进行绑定</param>
	/// <returns>被调用方法的返回值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前方法为空；或者参数名称数组不为空，而参数值数组为空。</exception>
	/// <exception cref="T:System.Reflection.TargetException">当前方法为实例方法，而调用对象 <paramref name="obj" /> 为空。</exception>
	public static object Invoke(this MethodBase method, object obj, string[] names, object[] values, bool optionalBinding = false)
	{
		method.GuardNotNull("method");
		if (names.IsNotNull())
		{
			values.GuardNotNull("values");
		}
		BindingFlags flags = BindingFlags.Default.Combine(IgnoreCase: false, DeclaredOnly: false, Instance: false, Static: false, Public: false, NonPublic: false, FlattenHierarchy: false, InvokeMethod: false, CreateInstance: false, GetField: false, SetField: false, GetProperty: false, SetProperty: false, PutDispProperty: false, PutRefDispProperty: false, ExactBinding: false, SuppressChangeType: false, optionalBinding);
		method = Type.DefaultBinder.BindToMethod(flags, new MethodBase[1] { method }, ref values, null, null, names, out var state);
		object result = method.Invoke(obj, values);
		Type.DefaultBinder.ReorderArgumentArray(ref values, state);
		return result;
	}

	/// <summary>
	/// 获取当前方法的访问级别
	/// </summary>
	/// <param name="method">当前方法</param>
	/// <returns>当前方法的访问级别</returns>
	/// <exception cref="T:System.ArgumentNullException">当前方法对象为空。</exception>
	/// <exception cref="T:System.NotSupportedException">当前方法不支持获取访问级别。</exception>
	public static AccessLevels GetAccessLevel(this MethodBase method)
	{
		method.GuardNotNull("method info");
		AccessLevels level = AccessLevels.Unspecified;
		if (method.IsPublic)
		{
			level = AccessLevels.Public;
		}
		else if (method.IsFamilyOrAssembly)
		{
			level = AccessLevels.FamilyOrAssembly;
		}
		else if (method.IsAssembly)
		{
			level = AccessLevels.Assembly;
		}
		else if (method.IsFamily)
		{
			level = AccessLevels.Family;
		}
		else if (method.IsFamilyAndAssembly)
		{
			level = AccessLevels.FamilyAndAssembly;
		}
		else
		{
			if (!method.IsPrivate)
			{
				throw new NotSupportedException(Literals.MSG_InvalidAccessibilityLevel);
			}
			level = AccessLevels.Private;
		}
		if (method.IsStatic)
		{
			return level | AccessLevels.Static;
		}
		return level | AccessLevels.Instance;
	}

	/// <summary>
	/// 检测当前方法是否可以使用指定类型的参数进行绑定
	/// </summary>
	/// <param name="method">当前的方法对象</param>
	/// <param name="argTypes">方法参数类型数组</param>
	/// <returns>如果当前方法对象可以使用指定类型的参数进行绑定返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前方法对象为空；或者方法参数类型数组 <paramref name="argTypes" /> 为空；或者方法参数类型数组中存在null元素。</exception>
	/// <remarks>当给定的参数类型的数组中每个类型与当前方法的参数的类型依次兼容，且无剩余参数或者剩余参数均为可选参数时，认为给定的参数序列与当前方法的参数序列兼容。</remarks>
	public static bool IsBindable(this MethodBase method, params Type[] argTypes)
	{
		return method.IsBindable(argTypes, optionalBinding: false);
	}

	/// <summary>
	/// 检测当前方法是否可以使用指定类型的参数进行绑定
	/// </summary>
	/// <param name="method">当前的方法对象</param>
	/// <param name="argTypes">方法参数类型数组</param>
	/// <param name="optionalBinding">对于方法的可选参数是否也必须进行绑定，默认为不对可选参数进行绑定</param>
	/// <returns>如果当前方法对象可以使用指定类型的参数进行绑定返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前方法对象为空；或者方法参数类型数组 <paramref name="argTypes" /> 为空；或者方法参数类型数组中存在null元素。</exception>
	/// <remarks>当给定的参数类型的序列中每个类型与当前方法的参数的类型依次兼容，且无剩余参数或者剩余参数均为可选参数时，认为给定的参数序列与当前方法的参数序列兼容。</remarks>
	public static bool IsBindable(this MethodBase method, Type[] argTypes, bool optionalBinding = false)
	{
		method.GuardNotNull("method");
		argTypes.GuardNotNull("parameter types");
		argTypes.ForEach(delegate(Type p)
		{
			p.GuardNotNull("parameter type");
		});
		if (optionalBinding)
		{
			return Type.DefaultBinder.SelectMethod(BindingFlags.Default, new MethodBase[1] { method }, argTypes, null).IsNotNull();
		}
		ParameterInfo[] pinfos = method.GetParameters();
		if (pinfos.Length < argTypes.Length)
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

	/// <summary>
	/// 检测当前方法是否是实例方法，实例构造函数也认为是实例方法
	/// </summary>
	/// <param name="minfo">当前方法对象</param>
	/// <returns>如果当前方法为是实例方法返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前方法对象为空。</exception>
	public static bool IsInstance(this MethodBase minfo)
	{
		minfo.GuardNotNull("Method Info");
		return !minfo.IsStatic;
	}
}
