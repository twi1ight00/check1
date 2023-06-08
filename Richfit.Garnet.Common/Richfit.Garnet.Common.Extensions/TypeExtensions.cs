using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using Richfit.Garnet.Common.Extensions.Method;
using Richfit.Garnet.Common.Patterns;
using Richfit.Garnet.Common.Properties;
using Richfit.Garnet.Common.Reflection;

namespace Richfit.Garnet.Common.Extensions;

/// <summary>
/// <see cref="T:System.Type" /> 的扩展方法类
/// </summary>
public static class TypeExtensions
{
	/// <summary>
	/// 创建元素类型为当前类型的指定长度的一维数组
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="length">一维数组的长度</param>
	/// <returns>创建的一维数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">一维数组长度小于0。</exception>
	public static Array CreateArray(this Type type, int length)
	{
		type.GuardNotNull("element type");
		length.GuardGreaterThanOrEqualTo(0, "array length");
		return Array.CreateInstance(type, length);
	}

	/// <summary>
	/// 创建元素类型为当前类型的指定长度的一维数组
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="length">一维数组的长度</param>
	/// <returns>创建的一维数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">一维数组长度小于0。</exception>
	public static Array CreateArray(this Type type, long length)
	{
		type.GuardNotNull("element type");
		length.GuardGreaterThanOrEqualTo(0L, "array length");
		return Array.CreateInstance(type, length);
	}

	/// <summary>
	/// 创建元素类型为当前类型的多维数组
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="rankLength">多维数组的每个维度的长度</param>
	/// <returns>创建的多维数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者各维度长度的数组 <paramref name="rankLength" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">各维度长度的数组中任一元素小于0。</exception>
	public static Array CreateArray(this Type type, params int[] rankLength)
	{
		type.GuardNotNull("element type");
		rankLength.GuardNotNull("rank length");
		rankLength.ForEach(delegate(int x)
		{
			x.GuardGreaterThanOrEqualTo(0, "length");
		});
		return Array.CreateInstance(type, rankLength);
	}

	/// <summary>
	/// 创建元素类型为当前类型的多维数组
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="rankLength">多维数组的每个维度的长度</param>
	/// <returns>创建的多维数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者各维度长度的数组 <paramref name="rankLength" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">各维度长度的数组中任一元素小于0。</exception>
	public static Array CreateArray(this Type type, params long[] rankLength)
	{
		type.GuardNotNull("element type");
		rankLength.GuardNotNull("rank length");
		rankLength.ForEach(delegate(long x)
		{
			x.GuardGreaterThanOrEqualTo(0L, "length");
		});
		return Array.CreateInstance(type, rankLength);
	}

	/// <summary>
	/// 获取指定类型的默认值
	/// </summary>
	/// <param name="type">获取默认值的类型</param>
	/// <returns>该类型的默认值</returns>
	public static object CreateDefault(this Type type)
	{
		type.GuardNotNull();
		return type.IsValueType ? Activator.CreateInstance(type) : null;
	}

	/// <summary>
	/// 创建当前类型的实例
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <returns>创建的当前类型的实例</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	public static object CreateInstance(this Type type)
	{
		return type.CreateInstance(null, BindingFlags.Default);
	}

	/// <summary>
	/// 创建当前类型的实例
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="args">调用的构造函数参数数组</param>
	/// <returns>创建的当前类型的实例</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	public static object CreateInstance(this Type type, params object[] args)
	{
		return type.CreateInstance(args, BindingFlags.Default);
	}

	/// <summary>
	/// 创建当前类型的实例
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="args">调用的构造函数参数数组</param>
	/// <param name="flags">构造函数绑定标志</param>
	/// <returns>创建的当前类型的实例</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	public static object CreateInstance(this Type type, object[] args, BindingFlags flags)
	{
		type.GuardNotNull("type");
		if (type == typeof(string) && (args == null || args.Length == 0))
		{
			return string.Empty;
		}
		if (type == typeof(DBNull))
		{
			return DBNull.Value;
		}
		return Activator.CreateInstance(type, flags, null, args, null);
	}

	/// <summary>
	/// 创建当前类型的实例
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="args">调用的构造函数参数数组</param>
	/// <param name="level">构造函数访问级别</param>
	/// <returns>创建的当前类型的实例</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	public static object CreateInstance(this Type type, object[] args, AccessLevels level)
	{
		return type.CreateInstance(args, level.ToBindingFlags() | BindingFlags.Instance);
	}

	/// <summary>
	/// 创建当前类型的实例
	/// </summary>
	/// <typeparam name="T">创建的实例的类型</typeparam>
	/// <param name="type">当前类型</param>
	/// <returns>创建的当前类型的实例</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前类型与指定的实例类型 <typeparamref name="T" /> 不兼容。</exception>
	public static T CreateInstance<T>(this Type type)
	{
		type.GuardNotNull("type");
		type.GuardInheritedType<T>("type");
		return (T)type.CreateInstance();
	}

	/// <summary>
	/// 创建当前类型的实例
	/// </summary>
	/// <typeparam name="T">创建的实例的类型</typeparam>
	/// <param name="type">当前类型</param>
	/// <param name="args">调用的构造函数参数数组</param>
	/// <returns>创建的当前类型的实例</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前类型与指定的实例类型 <typeparamref name="T" /> 不兼容。</exception>
	public static T CreateInstance<T>(this Type type, params object[] args)
	{
		type.GuardNotNull("type");
		type.GuardInheritedType<T>("type");
		return (T)type.CreateInstance(args);
	}

	/// <summary>
	/// 创建当前类型的实例
	/// </summary>
	/// <typeparam name="T">创建的实例的类型</typeparam>
	/// <param name="type">当前类型</param>
	/// <param name="args">调用的构造函数参数数组</param>
	/// <param name="flags">构造函数绑定标志</param>
	/// <returns>创建的当前类型的实例</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前类型与指定的实例类型 <typeparamref name="T" /> 不兼容。</exception>
	public static T CreateInstance<T>(this Type type, object[] args, BindingFlags flags)
	{
		type.GuardNotNull("type");
		type.GuardInheritedType<T>("type");
		return (T)type.CreateInstance(args, flags);
	}

	/// <summary>
	/// 创建当前类型的实例
	/// </summary>
	/// <typeparam name="T">创建的实例的类型</typeparam>
	/// <param name="type">当前类型</param>
	/// <param name="args">调用的构造函数参数数组</param>
	/// <param name="level">构造函数访问级别</param>
	/// <returns>创建的当前类型的实例</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前类型与指定的实例类型 <typeparamref name="T" /> 不兼容。</exception>
	public static T CreateInstance<T>(this Type type, object[] args, AccessLevels level)
	{
		type.GuardNotNull("type");
		type.GuardInheritedType<T>("type");
		return (T)type.CreateInstance(args, level);
	}

	/// <summary>
	/// 创建当前类型的实例
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <returns>创建的当前类型的实例，如果无法创建实例返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	public static object CreateInstanceOrNull(this Type type)
	{
		return type.CreateInstanceOrNull(null, BindingFlags.CreateInstance);
	}

	/// <summary>
	/// 创建当前类型的实例
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="args">调用的构造函数参数数组</param>
	/// <returns>创建的当前类型的实例，如果无法创建实例返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	public static object CreateInstanceOrNull(this Type type, params object[] args)
	{
		return type.CreateInstanceOrNull(args, BindingFlags.CreateInstance);
	}

	/// <summary>
	/// 创建当前类型的实例
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="args">调用的构造函数参数数组</param>
	/// <param name="flags">构造函数绑定标志</param>
	/// <returns>创建的当前类型的实例，如果无法创建实例返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	public static object CreateInstanceOrNull(this Type type, object[] args, BindingFlags flags)
	{
		type.GuardNotNull("type");
		try
		{
			return Activator.CreateInstance(type, flags, null, args, null);
		}
		catch
		{
			return null;
		}
	}

	/// <summary>
	/// 创建当前类型的实例
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="args">调用的构造函数参数数组</param>
	/// <param name="level">构造函数访问级别</param>
	/// <returns>创建的当前类型的实例，如果无法创建实例返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	public static object CreateInstanceOrNull(this Type type, object[] args, AccessLevels level)
	{
		return type.CreateInstanceOrNull(args, level.ToBindingFlags() | BindingFlags.Instance);
	}

	/// <summary>
	/// 创建当前类型的实例
	/// </summary>
	/// <typeparam name="T">创建的实例的类型</typeparam>
	/// <param name="type">当前类型</param>
	/// <returns>创建的当前类型的实例，如果无法创建实例则返回指定类型的默认值。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前类型与指定的实例类型 <typeparamref name="T" /> 不兼容。</exception>
	public static T CreateInstanceOrDefault<T>(this Type type)
	{
		type.GuardNotNull("type");
		type.GuardInheritedType<T>("type");
		try
		{
			return (T)Activator.CreateInstance(type);
		}
		catch
		{
			return default(T);
		}
	}

	/// <summary>
	/// 创建当前类型的实例
	/// </summary>
	/// <typeparam name="T">创建的实例的类型</typeparam>
	/// <param name="type">当前类型</param>
	/// <param name="args">调用的构造函数参数数组</param>
	/// <returns>创建的当前类型的实例，如果无法创建实例则返回指定类型的默认值。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前类型与指定的实例类型 <typeparamref name="T" /> 不兼容。</exception>
	public static T CreateInstanceOrDefault<T>(this Type type, params object[] args)
	{
		return type.CreateInstanceOrDefault(args, BindingFlags.CreateInstance, default(T));
	}

	/// <summary>
	/// 创建当前类型的实例
	/// </summary>
	/// <typeparam name="T">创建的实例的类型</typeparam>
	/// <param name="type">当前类型</param>
	/// <param name="args">调用的构造函数参数数组</param>
	/// <param name="defaultInstance">无法创建类型实例时，返回的默认实例</param>
	/// <returns>创建的当前类型的实例，如果无法创建实例则返回指定的默认实例。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前类型与指定的实例类型 <typeparamref name="T" /> 不兼容。</exception>
	public static T CreateInstanceOrDefault<T>(this Type type, object[] args, T defaultInstance = default(T))
	{
		return type.CreateInstanceOrDefault(args, BindingFlags.CreateInstance, defaultInstance);
	}

	/// <summary>
	/// 创建当前类型的实例
	/// </summary>
	/// <typeparam name="T">创建的实例的类型</typeparam>
	/// <param name="type">当前类型</param>
	/// <param name="args">调用的构造函数参数数组</param>
	/// <param name="flags">构造函数绑定标志</param>
	/// <param name="defaultInstance">无法创建类型实例时，返回的默认实例</param>
	/// <returns>创建的当前类型的实例，如果无法创建实例则返回指定的默认值。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前类型与指定的实例类型 <typeparamref name="T" /> 不兼容。</exception>
	public static T CreateInstanceOrDefault<T>(this Type type, object[] args, BindingFlags flags, T defaultInstance = default(T))
	{
		type.GuardNotNull("type");
		type.GuardInheritedType<T>("type");
		try
		{
			return (T)type.CreateInstance(args, flags);
		}
		catch
		{
			return defaultInstance;
		}
	}

	/// <summary>
	/// 创建当前类型的实例
	/// </summary>
	/// <typeparam name="T">创建的实例的类型</typeparam>
	/// <param name="type">当前类型</param>
	/// <param name="args">调用的构造函数参数数组</param>
	/// <param name="level">构造函数访问级别</param>
	/// <param name="defaultInstance">无法创建类型实例时，返回的默认实例</param>
	/// <returns>创建的当前类型的实例</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前类型与指定的实例类型 <typeparamref name="T" /> 不兼容。</exception>
	public static T CreateInstanceOrDefault<T>(this Type type, object[] args, AccessLevels level, T defaultInstance = default(T))
	{
		return type.CreateInstanceOrDefault(args, level.ToBindingFlags() | BindingFlags.Instance, defaultInstance);
	}

	/// <summary>
	/// 获取当前类型的访问级别
	/// </summary>
	/// <param name="type">当前待检测的类型</param>
	/// <returns>当前类型的访问级别</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	public static AccessLevels GetAccessLevel(this Type type)
	{
		type.GuardNotNull("type");
		if (type.IsNested)
		{
			if (type.IsNestedPublic)
			{
				return AccessLevels.Public;
			}
			if (type.IsNestedFamORAssem)
			{
				return AccessLevels.FamilyOrAssembly;
			}
			if (type.IsNestedAssembly)
			{
				return AccessLevels.Assembly;
			}
			if (type.IsNestedFamily)
			{
				return AccessLevels.Family;
			}
			if (type.IsNestedFamANDAssem)
			{
				return AccessLevels.FamilyAndAssembly;
			}
			if (type.IsNestedPrivate)
			{
				return AccessLevels.Private;
			}
		}
		else
		{
			if (type.IsPublic)
			{
				return AccessLevels.Public;
			}
			if (type.IsNotPublic)
			{
				return AccessLevels.NonPublic;
			}
		}
		throw new NotSupportedException(Literals.MSG_InvalidAccessibilityLevel);
	}

	/// <summary>
	/// 获取当前类型的程序集限定名称。该名称遵循C#语法。
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <returns>当前类型的程序集限定名称，包括命名空间和程序集名称。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	public static string GetAssemblyQualifiedName(this Type type)
	{
		type.GuardNotNull("type");
		StringBuilder buff = new StringBuilder();
		buff.Append(type.Namespace).Append(".");
		if (type.IsNested)
		{
			buff.Append(type.DeclaringType.GetName(nestedName: true)).Append("+");
		}
		if (type.IsGenericType)
		{
			buff.Append(type.Name.Remove(type.Name.IndexOf("`")));
			buff.Append("<");
			Type[] genericArguments = type.GetGenericArguments();
			foreach (Type genericType in genericArguments)
			{
				buff.Append(genericType.GetAssemblyQualifiedName()).Append(", ");
			}
			buff.Remove(buff.Length - 2, 2);
			buff.Append(">");
			buff.Append(", ").Append(type.Assembly.FullName);
			return buff.ToString();
		}
		return type.AssemblyQualifiedName;
	}

	/// <summary>
	/// 获取当前类型已经分配的第一个泛型参数
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <returns>当前类型已分配的第一个泛型参数；如果当前类型不是泛型类型或者没有已分配的泛型参数，则返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	public static Type GetAssignedGenericArgument(this Type type)
	{
		type.GuardNotNull("type");
		return (from a in type.GetGenericArguments()
			where !a.IsGenericParameter
			select a).FirstOrDefault();
	}

	/// <summary>
	/// 获取当前类型已经分配的泛型参数
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <returns>当前类型已分配的泛型参数；如果当前类型不是泛型类型返回空数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	public static Type[] GetAssignedGenericArguments(this Type type)
	{
		type.GuardNotNull("type");
		return (from a in type.GetGenericArguments()
			where !a.IsGenericParameter
			select a).ToArray();
	}

	/// <summary>
	/// 获取当前类型的继承结构中各层级的基类的数组
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <returns>当前类型从 <see cref="T:System.Object" /> 开始的继承的类型的数组，如果当前类型为 <see cref="T:System.Object" />，则返回空数组。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	public static Type[] GetBaseTypes(this Type type)
	{
		type.GuardNotNull("type");
		List<Type> baseTypes = new List<Type>();
		while (type.BaseType.IsNotNull())
		{
			type = type.BaseType;
			baseTypes.Add(type);
		}
		baseTypes.Reverse();
		return baseTypes.ToArray();
	}

	/// <summary>
	/// 获取当前类型中与参数类型数组匹配的公共实例构造函数
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="argTypes">参数类型数组</param>
	/// <returns>匹配的构造函数，如果没有匹配的构造函数返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	public static ConstructorInfo GetConstructor(this Type type, params Type[] argTypes)
	{
		return type.GetConstructor(argTypes);
	}

	/// <summary>
	/// 获取当前类型中与参数类型数组匹配的公共实例构造函数
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="argTypes">参数类型数组</param>
	/// <param name="optionalBinding">对于构造函数的可选参数是否也必须进行绑定</param>
	/// <returns>匹配的构造函数，如果没有匹配的构造函数返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	public static ConstructorInfo GetConstructor(this Type type, Type[] argTypes, bool optionalBinding)
	{
		return type.GetConstructors(argTypes, BindingFlags.Instance | BindingFlags.Public, optionalBinding).FirstOrDefault();
	}

	/// <summary>
	/// 获取当前类型中满足绑定条件的与参数类型数组匹配的构造函数
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="argTypes">参数类型数组</param>
	/// <param name="flags">构造函数绑定条件</param>
	/// <param name="optionalBinding">对于构造函数的可选参数是否也必须进行绑定，默认为对可选参数进行绑定</param>
	/// <returns>匹配的构造函数，如果没有匹配的构造函数返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	public static ConstructorInfo GetConstructor(this Type type, Type[] argTypes, BindingFlags flags, bool optionalBinding = true)
	{
		return type.GetConstructors(argTypes, flags, optionalBinding).FirstOrDefault();
	}

	/// <summary>
	/// 获取当前类型中指定访问级别与参数类型数组匹配的构造函数
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="argTypes">参数类型数组</param>
	/// <param name="level">获取的构造函数的访问级别</param>
	/// <param name="optionalBinding">对于构造函数的可选参数是否也必须进行绑定，默认为对可选参数进行绑定</param>
	/// <returns>匹配的构造函数，如果没有匹配的构造函数返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	public static ConstructorInfo GetConstructor(this Type type, Type[] argTypes, AccessLevels level, bool optionalBinding = true)
	{
		return type.GetConstructors(argTypes, level, optionalBinding).FirstOrDefault();
	}

	/// <summary>
	/// 获取当前类型中指定访问级别的构造函数
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="level">获取的构造函数的访问级别</param>
	/// <returns>当前类型中符合条件的构造函数</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	public static ConstructorInfo[] GetConstructors(this Type type, AccessLevels level)
	{
		type.GuardNotNull("type");
		return (from x in type.GetConstructors(level.ToBindingFlags())
			where x.GetAccessLevel().HasLevel(level)
			select x).ToArray();
	}

	/// <summary>
	/// 获取当前类型中满足绑定条件和筛选条件的构造函数
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="predicate">构造函数筛选条件</param>
	/// <param name="flags">构造函数绑定搜索标志，默认为公共实例标志</param>
	/// <returns>当前类型中符合条件的构造函数</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者构造函数筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static ConstructorInfo[] GetConstructors(this Type type, Func<ConstructorInfo, bool> predicate, BindingFlags flags = BindingFlags.Instance | BindingFlags.Public)
	{
		type.GuardNotNull("type");
		predicate.GuardNotNull("predicate");
		return type.GetConstructors(flags).Where(predicate).ToArray();
	}

	/// <summary>
	/// 获取当前类型中指定访问级别满足筛选条件的构造函数
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="predicate">构造函数筛选条件</param>
	/// <param name="level">获取的构造函数的访问级别</param>
	/// <returns>当前类型中符合条件的构造函数</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者构造函数筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static ConstructorInfo[] GetConstructors(this Type type, Func<ConstructorInfo, bool> predicate, AccessLevels level)
	{
		predicate.GuardNotNull("predicate");
		return type.GetConstructors(level).Where(predicate).ToArray();
	}

	/// <summary>
	/// 获取当前类型中与参数类型数组匹配的公共实例构造函数
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="argTypes">参数类型数组</param>
	/// <returns>当前类型中符合条件的构造函数</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者参数类型数组 <paramref name="argTypes" /> 为空。</exception>
	public static ConstructorInfo[] GetConstructors(this Type type, params Type[] argTypes)
	{
		return type.GetConstructors(argTypes, BindingFlags.Instance | BindingFlags.Public);
	}

	/// <summary>
	/// 获取当前类型中与参数类型数组匹配的公共实例构造函数
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="argTypes">参数类型数组</param>
	/// <param name="optionalBinding">对于构造函数的可选参数是否也必须进行绑定</param>
	/// <returns>当前类型中符合条件的构造函数</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者参数类型数组 <paramref name="argTypes" /> 为空。</exception>
	public static ConstructorInfo[] GetConstructors(this Type type, Type[] argTypes, bool optionalBinding)
	{
		return type.GetConstructors(argTypes, BindingFlags.Instance | BindingFlags.Public, optionalBinding);
	}

	/// <summary>
	/// 获取当前类型中满足绑定条件与参数类型数组匹配的构造函数
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="argTypes">参数类型数组</param>
	/// <param name="flags">构造函数绑定搜索标志</param>
	/// <param name="optionalBinding">对于构造函数的可选参数是否也必须进行绑定，默认为不对可选参数进行绑定</param>
	/// <returns>当前类型中符合条件的构造函数</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者参数类型数组 <paramref name="argTypes" /> 为空。</exception>
	public static ConstructorInfo[] GetConstructors(this Type type, Type[] argTypes, BindingFlags flags, bool optionalBinding = false)
	{
		type.GuardNotNull("type");
		argTypes.GuardNotNull("argument types");
		return (from x in type.GetConstructors(flags)
			where x.IsBindable(argTypes, optionalBinding)
			select x).ToArray();
	}

	/// <summary>
	/// 获取当前类型中指定访问级别与参数类型数组匹配的构造函数
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="argTypes">参数类型数组</param>
	/// <param name="level">获取的构造函数的访问级别</param>
	/// <param name="optionalBinding">对于构造函数的可选参数是否也必须进行绑定，默认为不对可选参数进行绑定</param>
	/// <returns>当前类型中符合条件的构造函数</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者参数类型数组 <paramref name="argTypes" /> 为空。</exception>
	public static ConstructorInfo[] GetConstructors(this Type type, Type[] argTypes, AccessLevels level, bool optionalBinding = false)
	{
		argTypes.GuardNotNull("argument types");
		return (from x in type.GetConstructors(level)
			where x.IsBindable(argTypes, optionalBinding)
			select x).ToArray();
	}

	/// <summary>
	/// 获取当前类型中具有与特性基类型相同或者继承于该基类型的自定义特性的公共实例构造函数
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="attributeType">特性基类型</param>
	/// <param name="inherit">是否从当前对象的继承结构中获取自定义特性</param>
	/// <returns>当前类型中符合条件的构造函数</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者特性基类型 <paramref name="attributeType" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">特性基类型 <paramref name="attributeType" /> 不是继承于 <see cref="T:System.Attribute" /> 类型。</exception>
	public static ConstructorInfo[] GetConstructors(this Type type, Type attributeType, bool inherit)
	{
		return type.GetConstructors(attributeType, BindingFlags.Instance | BindingFlags.Public, inherit);
	}

	/// <summary>
	/// 获取当前类型中具有与特性基类型相同或者继承于该基类型的自定义特性的构造函数
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="attributeType">特性基类型</param>
	/// <param name="flags">获取构造函数的绑定条件</param>
	/// <param name="inherit">是否从当前对象的继承结构中获取自定义特性</param>
	/// <returns>当前类型中符合条件的构造函数</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者特性基类型 <paramref name="attributeType" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">特性基类型 <paramref name="attributeType" /> 不是继承于 <see cref="T:System.Attribute" /> 类型。</exception>/// 
	public static ConstructorInfo[] GetConstructors(this Type type, Type attributeType, BindingFlags flags, bool inherit = false)
	{
		type.GuardNotNull("type");
		attributeType.GuardNotNull("attribute type").GuardInheritedType<Attribute>("attribute type");
		return (from c in type.GetConstructors(flags)
			where c.HasCustomAttribute(attributeType, inherit)
			select c).ToArray();
	}

	/// <summary>
	/// 获取当前类型中具有与特性基类型相同或者继承于该基类型的自定义特性的构造函数
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="attributeType">特性基类型</param>
	/// <param name="level">获取的构造函数的访问级别</param>
	/// <param name="inherit">是否从当前对象的继承结构中获取自定义特性</param>
	/// <returns>当前类型中符合条件的构造函数</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者特性基类型 <paramref name="attributeType" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">特性基类型 <paramref name="attributeType" /> 不是继承于 <see cref="T:System.Attribute" /> 类型。</exception>
	public static ConstructorInfo[] GetConstructors(this Type type, Type attributeType, AccessLevels level, bool inherit = false)
	{
		type.GuardNotNull("type");
		attributeType.GuardNotNull("attribute type").GuardInheritedType<Attribute>("attribute type");
		return (from c in type.GetConstructors(level)
			where c.HasCustomAttribute(attributeType, inherit)
			select c).ToArray();
	}

	/// <summary>
	/// 获取当前类型中具有指定名称的公共实例事件
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="eventName">事件名称</param>
	/// <param name="ignoreCase">事件名称是否区分大小写</param>
	/// <returns>匹配的事件，如果不存在匹配的事件返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者事件名称 <paramref name="eventName" /> 为空或者空串。</exception>
	public static EventInfo GetEvent(this Type type, string eventName, bool ignoreCase)
	{
		type.GuardNotNull("type");
		eventName.GuardNotNullAndEmpty("event name");
		return type.GetEvent(eventName, (BindingFlags.Instance | BindingFlags.Public).Combine(ignoreCase));
	}

	/// <summary>
	/// 获取当前类型中满足绑定条件的具有指定名称的事件
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="eventName">事件名称</param>
	/// <param name="flags">事件绑定搜索标志</param>
	/// <param name="ignoreCase">事件名称是否区分大小写</param>
	/// <returns>匹配的事件，如果不存在匹配的事件返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者事件名称 <paramref name="eventName" /> 为空或者空串。</exception>
	public static EventInfo GetEvent(this Type type, string eventName, BindingFlags flags, bool ignoreCase = false)
	{
		type.GuardNotNull("type");
		eventName.GuardNotNullAndEmpty("event name");
		return type.GetEvent(eventName, flags.Combine(ignoreCase));
	}

	/// <summary>
	/// 获取当前类型中指定访问级别具有指定名称的事件
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="eventName">事件名称</param>
	/// <param name="level">获取的事件的访问级别</param>
	/// <param name="ignoreCase">事件名称是否区分大小写</param>
	/// <returns>匹配的事件，如果不存在匹配的事件返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者事件名称 <paramref name="eventName" /> 为空或者空串。</exception>
	public static EventInfo GetEvent(this Type type, string eventName, AccessLevels level, bool ignoreCase = false)
	{
		type.GuardNotNull("type");
		eventName.GuardNotNullAndEmpty("event name");
		return (from x in type.GetEvents(level)
			where x.Name.EqualOrdinal(eventName, ignoreCase)
			select x).FirstOrDefault();
	}

	/// <summary>
	/// 获取当前类型中指定访问级别的事件
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="level">获取的事件的访问级别</param>
	/// <returns>当前类型中符合条件的事件</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	public static EventInfo[] GetEvents(this Type type, AccessLevels level)
	{
		type.GuardNotNull("type");
		return (from x in type.GetEvents(level.ToBindingFlags())
			where x.GetAccessLevel().HasLevel(level)
			select x).ToArray();
	}

	/// <summary>
	/// 获取当前类型中满足绑定条件和筛选条件的事件
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="predicate">事件筛选条件</param>
	/// <param name="flags">事件绑定搜索标志，默认为公共实例标志</param>
	/// <returns>当前类型中符合条件的事件</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者事件筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static EventInfo[] GetEvents(this Type type, Func<EventInfo, bool> predicate, BindingFlags flags = BindingFlags.Instance | BindingFlags.Public)
	{
		type.GuardNotNull("type");
		predicate.GuardNotNull("predicate");
		return type.GetEvents(flags).Where(predicate).ToArray();
	}

	/// <summary>
	/// 获取当前类型中指定访问级别满足筛选条件的事件
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="predicate">事件筛选条件</param>
	/// <param name="level">获取的事件的访问级别</param>
	/// <returns>当前类型中符合条件的事件</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者事件筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static EventInfo[] GetEvents(this Type type, Func<EventInfo, bool> predicate, AccessLevels level)
	{
		predicate.GuardNotNull("predicate");
		return type.GetEvents(level).Where(predicate).ToArray();
	}

	/// <summary>
	/// 获取当前类型中满足绑定条件和名称正则模式的事件
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="pattern">事件名称的正则模式</param>
	/// <param name="flags">事件绑定搜索标志，默认为公共实例标志</param>
	/// <returns>当前类型中符合条件的事件</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者事件名称的正则模式 <paramref name="pattern" /> 为空。</exception>
	public static EventInfo[] GetEvents(this Type type, Regex pattern, BindingFlags flags = BindingFlags.Instance | BindingFlags.Public)
	{
		type.GuardNotNull("type");
		pattern.GuardNotNull("event name pattern");
		return (from x in type.GetEvents(flags)
			where pattern.IsMatch(x.Name)
			select x).ToArray();
	}

	/// <summary>
	/// 获取当前类型中指定访问级别的满足名称正则模式的事件
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="pattern">事件名称的正则模式</param>
	/// <param name="level">获取的事件的访问级别</param>
	/// <returns>当前类型中符合条件的事件</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者事件名称的正则模式 <paramref name="pattern" /> 为空。</exception>
	public static EventInfo[] GetEvents(this Type type, Regex pattern, AccessLevels level)
	{
		pattern.GuardNotNull("event name pattern");
		return (from x in type.GetEvents(level)
			where pattern.IsMatch(x.Name)
			select x).ToArray();
	}

	/// <summary>
	/// 获取当前类型中具有与特性基类型相同或者继承于该基类型的自定义特性的公共实例事件
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="attributeType">特性基类型</param>
	/// <param name="inherit">是否从当前对象的继承结构中获取自定义特性</param>
	/// <returns>当前类型中符合条件的事件</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者特性基类型 <paramref name="attributeType" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">特性基类型 <paramref name="attributeType" /> 不是继承于 <see cref="T:System.Attribute" /> 类型。</exception>
	public static EventInfo[] GetEvents(this Type type, Type attributeType, bool inherit = false)
	{
		return type.GetEvents(attributeType, BindingFlags.Instance | BindingFlags.Public, inherit);
	}

	/// <summary>
	/// 获取当前类型中满足绑定条件，具有与特性基类型相同或者继承于该基类型的自定义特性的事件
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="attributeType">特性基类型</param>
	/// <param name="flags">获取事件的绑定条件</param>
	/// <param name="inherit">是否从当前对象的继承结构中获取自定义特性</param>
	/// <returns>当前类型中符合条件的事件</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者特性基类型 <paramref name="attributeType" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">特性基类型 <paramref name="attributeType" /> 不是继承于 <see cref="T:System.Attribute" /> 类型。</exception>
	public static EventInfo[] GetEvents(this Type type, Type attributeType, BindingFlags flags, bool inherit = false)
	{
		type.GuardNotNull("type");
		attributeType.GuardNotNull("attribute type").GuardInheritedType<Attribute>("attribute type");
		return (from c in type.GetEvents(flags)
			where c.HasCustomAttribute(attributeType, inherit)
			select c).ToArray();
	}

	/// <summary>
	/// 获取当前类型中具有指定访问级别，且与特性基类型相同或者继承于该基类型的自定义特性的事件
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="attributeType">特性基类型</param>
	/// <param name="level">获取的事件的访问级别</param>
	/// <param name="inherit">是否从当前对象的继承结构中获取自定义特性</param>
	/// <returns>当前类型中符合条件的事件</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者特性基类型 <paramref name="attributeType" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">特性基类型 <paramref name="attributeType" /> 不是继承于 <see cref="T:System.Attribute" /> 类型。</exception>
	public static EventInfo[] GetEvents(this Type type, Type attributeType, AccessLevels level, bool inherit = false)
	{
		type.GuardNotNull("type");
		attributeType.GuardNotNull("attribute type").GuardInheritedType<Attribute>("attribute type");
		return (from c in type.GetEvents(level)
			where c.HasCustomAttribute(attributeType, inherit)
			select c).ToArray();
	}

	/// <summary>
	/// 获取当前类型中具有指定名称的公共实例字段
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="fieldName">字段名称</param>
	/// <param name="ignoreCase">字段名称是否区分大小写</param>
	/// <returns>匹配的字段，如果不存在匹配的事件返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者字段名称 <paramref name="fieldName" /> 为空或者空串。</exception>
	public static FieldInfo GetField(this Type type, string fieldName, bool ignoreCase)
	{
		type.GuardNotNull("type");
		fieldName.GuardNotNullAndEmpty("event name");
		return type.GetField(fieldName, (BindingFlags.Instance | BindingFlags.Public).Combine(ignoreCase));
	}

	/// <summary>
	/// 获取当前类型中满足绑定条件的具有指定名称的字段
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="fieldName">字段名称</param>
	/// <param name="flags">字段绑定搜索标志</param>
	/// <param name="ignoreCase">字段名称是否区分大小写</param>
	/// <returns>匹配的字段，如果不存在匹配的事件返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者字段名称 <paramref name="fieldName" /> 为空或者空串。</exception>
	public static FieldInfo GetField(this Type type, string fieldName, BindingFlags flags, bool ignoreCase = false)
	{
		type.GuardNotNull("type");
		fieldName.GuardNotNullAndEmpty("event name");
		return type.GetField(fieldName, flags.Combine(ignoreCase));
	}

	/// <summary>
	/// 获取当前类型中指定访问级别和具有指定名称的字段
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="fieldName">字段名称</param>
	/// <param name="level">获取的字段的访问级别</param>
	/// <param name="ignoreCase">字段名称是否区分大小写</param>
	/// <returns>匹配的字段，如果不存在匹配的事件返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者字段名称 <paramref name="fieldName" /> 为空或者空串。</exception>
	public static FieldInfo GetField(this Type type, string fieldName, AccessLevels level, bool ignoreCase = false)
	{
		type.GuardNotNull("type");
		fieldName.GuardNotNullAndEmpty("event name");
		return (from x in type.GetFields(level)
			where x.Name.EqualOrdinal(fieldName, ignoreCase)
			select x).FirstOrDefault();
	}

	/// <summary>
	/// 按照指定路径从当前类型中获取公共实例字段
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="fieldPath">字段路径</param>
	/// <param name="ignoreCase">字段路径是否区分大小写</param>
	/// <returns>当前路径中匹配的字段，如果没有匹配的字段返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者字段路径 <paramref name="fieldPath" /> 为空或者空串.</exception>
	public static FieldInfo GetFieldByPath(this Type type, string fieldPath, bool ignoreCase = false)
	{
		return type.GetFieldByPath(fieldPath, BindingFlags.Instance | BindingFlags.Public, ignoreCase);
	}

	/// <summary>
	/// 按照指定路径从当前类型中获取符合绑定条件的字段
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="fieldPath">字段路径</param>
	/// <param name="flags">属性绑定条件</param>
	/// <param name="ignoreCase">字段路径是否区分大小写</param>
	/// <returns>当前路径中匹配的字段，如果没有匹配的字段返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者字段路径 <paramref name="fieldPath" /> 为空或者空串.</exception>
	public static FieldInfo GetFieldByPath(this Type type, string fieldPath, BindingFlags flags, bool ignoreCase = false)
	{
		type.GuardNotNull("type");
		fieldPath.GuardNotNullAndEmpty("field path");
		string[] fieldNames = fieldPath.Split(new char[1] { '.' }, StringSplitOptions.None);
		FieldInfo field = null;
		string[] array = fieldNames;
		foreach (string fieldName in array)
		{
			field = type.GetField(fieldName, flags, ignoreCase);
			if (field.IsNull())
			{
				return null;
			}
			type = field.FieldType;
		}
		return field;
	}

	/// <summary>
	/// 按照指定路径从当前类型中获取具有指定访问级别的字段
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="fieldPath">字段路径</param>
	/// <param name="level">获取的属性的访问级别</param>
	/// <param name="ignoreCase">字段路径是否区分大小写</param>
	/// <returns>当前路径中匹配的字段，如果没有匹配的字段返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者字段路径 <paramref name="fieldPath" /> 为空或者空串.</exception>
	public static FieldInfo GetFieldByPath(this Type type, string fieldPath, AccessLevels level, bool ignoreCase = false)
	{
		type.GuardNotNull("type");
		fieldPath.GuardNotNullAndEmpty("field path");
		string[] fieldNames = fieldPath.Split(new char[1] { '.' }, StringSplitOptions.None);
		FieldInfo field = null;
		string[] array = fieldNames;
		foreach (string fieldName in array)
		{
			field = type.GetField(fieldName, level, ignoreCase);
			if (field.IsNull())
			{
				return null;
			}
			type = field.FieldType;
		}
		return field;
	}

	/// <summary>
	/// 获取当前类型中指定访问级别的字段
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="level">获取的字段的访问级别</param>
	/// <returns>当前类型中符合条件的字段</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	public static FieldInfo[] GetFields(this Type type, AccessLevels level)
	{
		type.GuardNotNull("type");
		return (from x in type.GetFields(level.ToBindingFlags())
			where x.GetAccessLevel().HasLevel(level)
			select x).ToArray();
	}

	/// <summary>
	/// 获取当前类型中满足绑定条件和筛选条件的字段
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="predicate">字段筛选条件</param>
	/// <param name="flags">字段绑定搜索标志</param>
	/// <returns>当前类型中符合条件的字段</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者字段筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static FieldInfo[] GetFields(this Type type, Func<FieldInfo, bool> predicate, BindingFlags flags = BindingFlags.Instance | BindingFlags.Public)
	{
		type.GuardNotNull("type");
		predicate.GuardNotNull("predicate");
		return type.GetFields(flags).Where(predicate).ToArray();
	}

	/// <summary>
	/// 获取当前类型中指定访问级别满足筛选条件的字段
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="predicate">字段筛选条件</param>
	/// <param name="level">获取的字段的访问级别</param>
	/// <returns>当前类型中符合条件的字段</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者字段筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static FieldInfo[] GetFields(this Type type, Func<FieldInfo, bool> predicate, AccessLevels level)
	{
		predicate.GuardNotNull("predicate");
		return type.GetFields(level).Where(predicate).ToArray();
	}

	/// <summary>
	/// 获取当前类型中满足绑定条件和名称正则模式的字段
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="pattern">字段名称的正则模式</param>
	/// <param name="flags">字段绑定搜索标志</param>
	/// <returns>当前类型中符合条件的字段</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者字段名称的正则模式 <paramref name="pattern" /> 为空。</exception>
	public static FieldInfo[] GetFields(this Type type, Regex pattern, BindingFlags flags = BindingFlags.Instance | BindingFlags.Public)
	{
		type.GuardNotNull("type");
		pattern.GuardNotNull("event name pattern");
		return (from x in type.GetFields(flags)
			where pattern.IsMatch(x.Name)
			select x).ToArray();
	}

	/// <summary>
	/// 获取当前类型中指定访问级别的满足名称正则模式的字段
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="pattern">字段名称的正则模式</param>
	/// <param name="level">获取的字段的访问级别</param>
	/// <returns>当前类型中符合条件的字段</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者字段名称的正则模式 <paramref name="pattern" /> 为空。</exception>
	public static FieldInfo[] GetFields(this Type type, Regex pattern, AccessLevels level)
	{
		pattern.GuardNotNull("event name pattern");
		return (from x in type.GetFields(level)
			where pattern.IsMatch(x.Name)
			select x).ToArray();
	}

	/// <summary>
	/// 获取当前类型中具有与特性基类型相同或者继承于该基类型的自定义特性的公共实例字段
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="attributeType">特性基类型</param>
	/// <param name="inherit">是否从当前对象的继承结构中获取自定义特性</param>
	/// <returns>当前类型中符合条件的字段</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者特性基类型 <paramref name="attributeType" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">特性基类型 <paramref name="attributeType" /> 不是继承于 <see cref="T:System.Attribute" /> 类型。</exception>
	public static FieldInfo[] GetFields(this Type type, Type attributeType, bool inherit = false)
	{
		return type.GetFields(attributeType, BindingFlags.Instance | BindingFlags.Public, inherit);
	}

	/// <summary>
	/// 获取当前类型中满足绑定条件，具有与特性基类型相同或者继承于该基类型的自定义特性的字段
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="attributeType">特性基类型</param>
	/// <param name="flags">获取字段的绑定条件</param>
	/// <param name="inherit">是否从当前对象的继承结构中获取自定义特性</param>
	/// <returns>当前类型中符合条件的字段</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者特性基类型 <paramref name="attributeType" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">特性基类型 <paramref name="attributeType" /> 不是继承于 <see cref="T:System.Attribute" /> 类型。</exception>
	public static FieldInfo[] GetFields(this Type type, Type attributeType, BindingFlags flags, bool inherit = false)
	{
		type.GuardNotNull("type");
		attributeType.GuardNotNull("attribute type").GuardInheritedType<Attribute>("attribute type");
		return (from c in type.GetFields(flags)
			where c.HasCustomAttribute(attributeType, inherit)
			select c).ToArray();
	}

	/// <summary>
	/// 获取当前类型中具有指定访问级别，且与特性基类型相同或者继承于该基类型的自定义特性的字段
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="attributeType">特性基类型</param>
	/// <param name="level">获取的字段的访问级别</param>
	/// <param name="inherit">是否从当前对象的继承结构中获取自定义特性</param>
	/// <returns>当前类型中符合条件的字段</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者特性基类型 <paramref name="attributeType" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">特性基类型 <paramref name="attributeType" /> 不是继承于 <see cref="T:System.Attribute" /> 类型。</exception>
	public static FieldInfo[] GetFields(this Type type, Type attributeType, AccessLevels level, bool inherit = false)
	{
		type.GuardNotNull("type");
		attributeType.GuardNotNull("attribute type").GuardInheritedType<Attribute>("attribute type");
		return (from c in type.GetFields(level)
			where c.HasCustomAttribute(attributeType, inherit)
			select c).ToArray();
	}

	/// <summary>
	/// 获取当前类型的第一个泛型类型参数
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <returns>当前类型的第一个泛型类型参数；如果当前类型不是泛型类型返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	public static Type GetGenericArgument(this Type type)
	{
		type.GuardNotNull("type");
		return type.GetGenericArguments().FirstOrDefault();
	}

	/// <summary>
	/// 获取当前类型实现的与目标接口类型兼容的接口。
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="targetType">目标接口类型</param>
	/// <returns>当前类型实现的与目标接口类型兼容的接口，如果没有符合条件的接口返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者目标接口类型 <paramref name="targetType" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">目标类型 <paramref name="targetType" /> 不是接口。</exception>
	public static Type GetInterface(this Type type, Type targetType)
	{
		return type.GetInterfaces(targetType).FirstOrDefault();
	}

	/// <summary>
	/// 获取当前类型实现的具有指定名称的接口数组
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="name">接口名称，可以包含命名空间名称</param>
	/// <param name="ignoreCase">接口名称是否区分大小写</param>
	/// <returns>匹配的接口数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前接口为空；或者接口名称为空或者空串。</exception>
	public static Type[] GetInterfaces(this Type type, string name, bool ignoreCase = false)
	{
		type.GuardNotNull("type");
		name.GuardNotNullAndEmpty("name");
		List<Type> interfaceTypes = new List<Type>();
		Type[] interfaces = type.GetInterfaces();
		foreach (Type interfaceType in interfaces)
		{
			if (interfaceType.IsGenericType)
			{
				Type def = interfaceType.GetGenericTypeDefinition();
				if (def.Name.EqualOrdinal(name, ignoreCase) || def.FullName.EqualOrdinal(name, ignoreCase))
				{
					interfaceTypes.Add(interfaceType);
				}
			}
			else if (interfaceType.Name.EqualOrdinal(name, ignoreCase) || interfaceType.FullName.EqualOrdinal(name, ignoreCase))
			{
				interfaceTypes.Add(interfaceType);
			}
		}
		return interfaceTypes.ToArray();
	}

	/// <summary>
	/// 获取当前类型实现的具有指定名称模式的接口的数组
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="pattern">接口名称模式，应包含命名空间的模式</param>
	/// <returns>匹配的接口数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前接口为空；或者接口名称模式 <paramref name="pattern" /> 为空。</exception>
	public static Type[] GetInterfaces(this Type type, Regex pattern)
	{
		type.GuardNotNull("type");
		pattern.GuardNotNull("pattern");
		return (from t in type.GetInterfaces()
			where pattern.IsMatch(t.FullName)
			select t).ToArray();
	}

	/// <summary>
	/// 获取当前类型实现的与目标接口兼容的接口数组
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="targetType">目标接口类型</param>
	/// <returns>当前类型实现的接口</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者目标接口类型 <paramref name="targetType" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">目标类型 <paramref name="targetType" /> 不是接口。</exception>
	public static Type[] GetInterfaces(this Type type, Type targetType)
	{
		type.GuardNotNull("type");
		targetType.GuardNotNull("target type");
		targetType.Guard((Type x) => x.IsInterface, "target type");
		if (targetType.IsGenericType)
		{
			return (from t in type.GetInterfaces()
				where CheckGenericTypeCompatibility(t, targetType)
				select t).ToArray();
		}
		return (from t in type.GetInterfaces()
			where targetType.IsAssignableFrom(t)
			select t).ToArray();
	}

	/// <summary>
	/// 获取当前类型中指定访问级别的成员
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="level">获取的成员的访问级别</param>
	/// <returns>当前类型中符合条件的成员</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	public static MemberInfo[] GetMembers(this Type type, AccessLevels level)
	{
		type.GuardNotNull("type");
		return (from x in type.GetMembers(level.ToBindingFlags())
			where x.GetAccessLevel().HasLevel(level)
			select x).ToArray();
	}

	/// <summary>
	/// 获取当前类型中满足绑定条件和筛选条件的成员
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="predicate">成员筛选条件</param>
	/// <param name="flags">成员绑定搜索标志</param>
	/// <returns>当前类型中符合条件的成员</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者成员筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static MemberInfo[] GetMembers(this Type type, Func<MemberInfo, bool> predicate, BindingFlags flags = BindingFlags.Instance | BindingFlags.Public)
	{
		type.GuardNotNull("type");
		predicate.GuardNotNull("predicate");
		return type.GetMembers(flags).Where(predicate).ToArray();
	}

	/// <summary>
	/// 获取当前类型中指定访问级别满足筛选条件的成员
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="predicate">成员筛选条件</param>
	/// <param name="level">获取的成员的访问级别</param>
	/// <returns>当前类型中符合条件的成员</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者成员筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static MemberInfo[] GetMembers(this Type type, Func<MemberInfo, bool> predicate, AccessLevels level)
	{
		predicate.GuardNotNull("predicate");
		return type.GetMembers(level).Where(predicate).ToArray();
	}

	/// <summary>
	/// 获取当前类型中具有指定名称的公共实例成员
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="memberName">获取的成员的名称</param>
	/// <param name="ignoreCase">成员名称是否区分大小写</param>
	/// <returns>当前类型中符合条件的成员</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者成员名称 <paramref name="memberName" /> 为空或者空串。</exception>
	public static MemberInfo[] GetMembers(this Type type, string memberName, bool ignoreCase = false)
	{
		return type.GetMembers(memberName, BindingFlags.Instance | BindingFlags.Public, ignoreCase);
	}

	/// <summary>
	/// 获取当前类型中具有指定名称的满足绑定条件的成员
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="memberName">获取的成员的名称</param>
	/// <param name="flags">获取成员的绑定条件</param>
	/// <param name="ignoreCase">成员名称是否区分大小写</param>
	/// <returns>当前类型中符合条件的成员</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者成员名称 <paramref name="memberName" /> 为空或者空串。</exception>
	public static MemberInfo[] GetMembers(this Type type, string memberName, BindingFlags flags, bool ignoreCase = false)
	{
		type.GuardNotNull("type");
		memberName.GuardNotNullAndEmpty("member name");
		return type.GetMember(memberName, flags.Combine(ignoreCase));
	}

	/// <summary>
	/// 获取当前类型中具有指定名称和指定访问级别的成员
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="memberName">获取的成员的名称</param>
	/// <param name="level">获取的成员的访问级别</param>
	/// <param name="ignoreCase">成员名称是否区分大小写</param>
	/// <returns>当前类型中符合条件的成员</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者成员名称 <paramref name="memberName" /> 为空或者空串。</exception>
	public static MemberInfo[] GetMembers(this Type type, string memberName, AccessLevels level, bool ignoreCase = false)
	{
		type.GuardNotNull("type");
		memberName.GuardNotNullAndEmpty("member name");
		return (from m in type.GetMembers(level)
			where m.Name.EqualOrdinal(memberName, ignoreCase)
			select m).ToArray();
	}

	/// <summary>
	/// 获取当前类型中满足绑定条件和名称正则模式的成员
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="pattern">成员名称的正则模式</param>
	/// <param name="flags">成员绑定搜索标志</param>
	/// <returns>当前类型中符合条件的成员</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者成员名称的正则模式 <paramref name="pattern" /> 为空。</exception>
	public static MemberInfo[] GetMembers(this Type type, Regex pattern, BindingFlags flags = BindingFlags.Instance | BindingFlags.Public)
	{
		type.GuardNotNull("type");
		pattern.GuardNotNull("event name pattern");
		return (from x in type.GetMembers(flags)
			where pattern.IsMatch(x.Name)
			select x).ToArray();
	}

	/// <summary>
	/// 获取当前类型中指定访问级别的满足名称正则模式的成员
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="pattern">成员名称的正则模式</param>
	/// <param name="level">获取的成员的访问级别</param>
	/// <returns>当前类型中符合条件的成员</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者成员名称的正则模式 <paramref name="pattern" /> 为空。</exception>
	public static MemberInfo[] GetMembers(this Type type, Regex pattern, AccessLevels level)
	{
		pattern.GuardNotNull("event name pattern");
		return (from x in type.GetMembers(level)
			where pattern.IsMatch(x.Name)
			select x).ToArray();
	}

	/// <summary>
	/// 获取当前类型中指定访问级别和具有指定类型特性的成员
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="attributeType">成员应具有的特性的类型</param>
	/// <param name="inherit">是否从当前对象的继承结构中获取自定义特性</param>
	/// <returns>当前类型中符合条件的成员</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者特性类型 <paramref name="attributeType" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">特性类型 <paramref name="attributeType" /> 不是继承于 <see cref="T:System.Attribute" /> 类型。</exception>
	public static MemberInfo[] GetMembers(this Type type, Type attributeType, bool inherit = false)
	{
		type.GuardNotNull("type");
		attributeType.GuardNotNull("attribute type").GuardInheritedType<Attribute>("attribute type");
		return (from m in type.GetMembers()
			where m.IsDefined(attributeType, inherit)
			select m).ToArray();
	}

	/// <summary>
	/// 获取当前类型中满足绑定条件和具有指定类型特性的成员
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="attributeType">成员应具有的特性的类型</param>
	/// <param name="flags">成员绑定搜索标志</param>
	/// <param name="inherit">是否从当前对象的继承结构中获取自定义特性</param>
	/// <returns>当前类型中符合条件的成员</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者特性类型 <paramref name="attributeType" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">特性类型 <paramref name="attributeType" /> 不是继承于 <see cref="T:System.Attribute" /> 类型。</exception>
	public static MemberInfo[] GetMembers(this Type type, Type attributeType, BindingFlags flags, bool inherit = false)
	{
		type.GuardNotNull("type");
		attributeType.GuardNotNull("attribute type").GuardInheritedType<Attribute>("attribute type");
		return (from m in type.GetMembers(flags)
			where m.IsDefined(attributeType, inherit)
			select m).ToArray();
	}

	/// <summary>
	/// 获取当前类型中指定访问级别和具有指定类型特性的成员
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="attributeType">成员应具有的特性的类型</param>
	/// <param name="level">获取的成员的访问级别</param>
	/// <param name="inherit">是否从当前对象的继承结构中获取自定义特性</param>
	/// <returns>当前类型中符合条件的成员</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者特性类型 <paramref name="attributeType" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">特性类型 <paramref name="attributeType" /> 不是继承于 <see cref="T:System.Attribute" /> 类型。</exception>
	public static MemberInfo[] GetMembers(this Type type, Type attributeType, AccessLevels level, bool inherit = false)
	{
		type.GuardNotNull("type");
		attributeType.GuardNotNull("attribute type").GuardInheritedType<Attribute>("attribute type");
		return (from m in type.GetMembers(level)
			where m.IsDefined(attributeType, inherit)
			select m).ToArray();
	}

	/// <summary>
	/// 获取当前类型中满足绑定条件的成员
	/// </summary>
	/// <typeparam name="T">获取的成员类型</typeparam>
	/// <param name="type">当前类型</param>
	/// <param name="flags">成员绑定条件，默认为绑定公共实例成员</param>
	/// <returns>当前类型中符合条件的成员</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	public static T[] GetMembers<T>(this Type type, BindingFlags flags = BindingFlags.Instance | BindingFlags.Public) where T : MemberInfo
	{
		type.GuardNotNull("type");
		return type.GetMembers(flags).OfType<T>().ToArray();
	}

	/// <summary>
	/// 获取当前类型中指定访问级别的成员
	/// </summary>
	/// <typeparam name="T">获取的成员类型</typeparam>
	/// <param name="type">当前类型</param>
	/// <param name="level">获取的成员的访问级别</param>
	/// <returns>当前类型中符合条件的成员</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	public static T[] GetMembers<T>(this Type type, AccessLevels level) where T : MemberInfo
	{
		type.GuardNotNull("type");
		return (from x in type.GetMembers(level.ToBindingFlags()).OfType<T>()
			where x.GetAccessLevel().HasLevel(level)
			select x).ToArray();
	}

	/// <summary>
	/// 获取当前类型中满足绑定条件和筛选条件的成员
	/// </summary>
	/// <typeparam name="T">获取的成员类型</typeparam>
	/// <param name="type">当前类型</param>
	/// <param name="predicate">成员筛选条件</param>
	/// <param name="flags">成员绑定条件</param>
	/// <returns>当前类型中符合条件的成员</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者成员筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static T[] GetMembers<T>(this Type type, Func<T, bool> predicate, BindingFlags flags = BindingFlags.Instance | BindingFlags.Public) where T : MemberInfo
	{
		type.GuardNotNull("type");
		predicate.GuardNotNull("predicate");
		return type.GetMembers<T>(flags).Where(predicate).ToArray();
	}

	/// <summary>
	/// 获取当前类型中指定访问级别，满足筛选条件的成员
	/// </summary>
	/// <typeparam name="T">获取的成员类型</typeparam>
	/// <param name="type">当前类型</param>
	/// <param name="predicate">成员筛选条件</param>
	/// <param name="level">获取的成员的访问级别</param>
	/// <returns>当前类型中符合条件的成员</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者成员筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static T[] GetMembers<T>(this Type type, Func<T, bool> predicate, AccessLevels level) where T : MemberInfo
	{
		type.GuardNotNull("type");
		predicate.GuardNotNull("predicate");
		return type.GetMembers<T>(level).Where(predicate).ToArray();
	}

	/// <summary>
	/// 获取当前类型中具有指定名称的公共实例成员
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="memberName">获取的成员的名称</param>
	/// <param name="ignoreCase">成员名称是否区分大小写</param>
	/// <returns>当前类型中符合条件的成员</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者成员名称 <paramref name="memberName" /> 为空或者空串。</exception>
	public static T[] GetMembers<T>(this Type type, string memberName, bool ignoreCase = false) where T : MemberInfo
	{
		return type.GetMembers<T>(memberName, BindingFlags.Instance | BindingFlags.Public, ignoreCase);
	}

	/// <summary>
	/// 获取当前类型中具有指定名称的满足绑定条件的成员
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="memberName">获取的成员的名称</param>
	/// <param name="flags">获取成员的绑定条件</param>
	/// <param name="ignoreCase">成员名称是否区分大小写</param>
	/// <returns>当前类型中符合条件的成员</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者成员名称 <paramref name="memberName" /> 为空或者空串。</exception>
	public static T[] GetMembers<T>(this Type type, string memberName, BindingFlags flags, bool ignoreCase = false) where T : MemberInfo
	{
		type.GuardNotNull("type");
		memberName.GuardNotNullAndEmpty("member name");
		return type.GetMembers(memberName, flags.Combine(ignoreCase)).OfType<T>().ToArray();
	}

	/// <summary>
	/// 获取当前类型中具有指定访问级别的成员
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="memberName">获取的成员的名称</param>
	/// <param name="level">获取的成员的访问级别</param>
	/// <param name="ignoreCase">成员名称是否区分大小写</param>
	/// <returns>当前类型中符合条件的成员</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者成员名称 <paramref name="memberName" /> 为空或者空串。</exception>
	public static T[] GetMembers<T>(this Type type, string memberName, AccessLevels level, bool ignoreCase = false) where T : MemberInfo
	{
		type.GuardNotNull("type");
		memberName.GuardNotNullAndEmpty("member name");
		return (from m in type.GetMembers(level).OfType<T>()
			where m.Name.EqualOrdinal(memberName, ignoreCase)
			select m).ToArray();
	}

	/// <summary>
	/// 获取当前类型中满足绑定条件和名称正则模式的成员
	/// </summary>
	/// <typeparam name="T">获取的成员类型</typeparam>
	/// <param name="type">当前类型</param>
	/// <param name="pattern">成员名称的正则模式</param>
	/// <param name="flags">成员绑定搜索标志</param>
	/// <returns>当前类型中符合条件的成员</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者成员名称的正则模式 <paramref name="pattern" /> 为空。</exception>
	public static T[] GetMembers<T>(this Type type, Regex pattern, BindingFlags flags = BindingFlags.Instance | BindingFlags.Public) where T : MemberInfo
	{
		type.GuardNotNull("type");
		pattern.GuardNotNull("pattern");
		return (from m in type.GetMembers<T>(flags)
			where pattern.IsMatch(m.Name)
			select m).ToArray();
	}

	/// <summary>
	/// 获取当前类型中指定访问级别，满足名称正则模式的成员
	/// </summary>
	/// <typeparam name="T">获取的成员类型</typeparam>
	/// <param name="type">当前类型</param>
	/// <param name="pattern">成员名称的正则模式</param>
	/// <param name="level">获取的成员的访问级别</param>
	/// <returns>当前类型中符合条件的成员</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者成员名称的正则模式 <paramref name="pattern" /> 为空。</exception>
	public static T[] GetMembers<T>(this Type type, Regex pattern, AccessLevels level) where T : MemberInfo
	{
		type.GuardNotNull("type");
		pattern.GuardNotNull("pattern");
		return (from m in type.GetMembers<T>(level)
			where pattern.IsMatch(m.Name)
			select m).ToArray();
	}

	/// <summary>
	/// 获取当前类型中具有指定类型特性的成员
	/// </summary>
	/// <typeparam name="T">获取的成员类型</typeparam>
	/// <param name="type">当前类型</param>
	/// <param name="attributeType">成员应具有的特性的类型</param>
	/// <param name="inherit">是否从当前对象的继承结构中获取自定义特性</param>
	/// <returns>当前类型中符合条件的成员</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者特性类型 <paramref name="attributeType" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">特性类型 <paramref name="attributeType" /> 不是继承于 <see cref="T:System.Attribute" /> 类型。</exception>
	public static T[] GetMembers<T>(this Type type, Type attributeType, bool inherit = false) where T : MemberInfo
	{
		type.GuardNotNull("type");
		attributeType.GuardNotNull("attribute type").GuardInheritedType<Attribute>("attribute type");
		return (from m in type.GetMembers<T>()
			where m.IsDefined(attributeType, inherit)
			select m).ToArray();
	}

	/// <summary>
	/// 获取当前类型中满足绑定条件和具有指定类型特性的成员
	/// </summary>
	/// <typeparam name="T">获取的成员类型</typeparam>
	/// <param name="type">当前类型</param>
	/// <param name="attributeType">成员应具有的特性的类型</param>
	/// <param name="flags">成员绑定搜索标志</param>
	/// <param name="inherit">是否从当前对象的继承结构中获取自定义特性</param>
	/// <returns>当前类型中符合条件的成员</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者特性类型 <paramref name="attributeType" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">特性类型 <paramref name="attributeType" /> 不是继承于 <see cref="T:System.Attribute" /> 类型。</exception>
	public static T[] GetMembers<T>(this Type type, Type attributeType, BindingFlags flags, bool inherit = false) where T : MemberInfo
	{
		type.GuardNotNull("type");
		attributeType.GuardNotNull("attribute type").GuardInheritedType<Attribute>("attribute type");
		return (from m in type.GetMembers<T>(flags)
			where m.IsDefined(attributeType, inherit)
			select m).ToArray();
	}

	/// <summary>
	/// 获取当前类型中指定访问级别和具有指定类型特性的成员
	/// </summary>
	/// <typeparam name="T">获取的成员类型</typeparam>
	/// <param name="type">当前类型</param>
	/// <param name="attributeType">成员应具有的特性的类型</param>
	/// <param name="level">获取的成员的访问级别</param>
	/// <param name="inherit">是否从当前对象的继承结构中获取自定义特性</param>
	/// <returns>当前类型中符合条件的成员</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者特性类型 <paramref name="attributeType" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">特性类型 <paramref name="attributeType" /> 不是继承于 <see cref="T:System.Attribute" /> 类型。</exception>
	public static T[] GetMembers<T>(this Type type, Type attributeType, AccessLevels level, bool inherit = false) where T : MemberInfo
	{
		type.GuardNotNull("type");
		attributeType.GuardNotNull("attribute type").GuardInheritedType<Attribute>("attribute type");
		return (from m in type.GetMembers<T>(level)
			where m.IsDefined(attributeType, inherit)
			select m).ToArray();
	}

	/// <summary>
	/// 获取当前类型中具有指定名称的公共实例方法
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="methodName">方法名称</param>
	/// <param name="ignoreCase">方法名称是否区分大小写</param>
	/// <returns>匹配的方法，如果不存在匹配的方法返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者方法名称 <paramref name="methodName" /> 为空或者空串。</exception>
	public static MethodInfo GetMethod(this Type type, string methodName, bool ignoreCase)
	{
		type.GuardNotNull("type");
		methodName.GuardNotNullAndEmpty("method name");
		return type.GetMethod(methodName, (BindingFlags.Instance | BindingFlags.Public).Combine(ignoreCase));
	}

	/// <summary>
	/// 获取当前类型中满足绑定条件具有指定名称的方法
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="methodName">方法名称</param>
	/// <param name="flags">方法绑定条件</param>
	/// <param name="ignoreCase">方法名称是否区分大小写</param>
	/// <returns>匹配的方法，如果不存在匹配的方法返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者方法名称 <paramref name="methodName" /> 为空或者空串。</exception>
	public static MethodInfo GetMethod(this Type type, string methodName, BindingFlags flags, bool ignoreCase = false)
	{
		type.GuardNotNull("type");
		methodName.GuardNotNullAndEmpty("method name");
		return type.GetMethod(methodName, flags.Combine(ignoreCase));
	}

	/// <summary>
	/// 获取当前类型中指定访问级别和具有指定名称的方法
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="methodName">方法名称</param>
	/// <param name="level">获取的方法的访问级别</param>
	/// <param name="ignoreCase">方法名称是否区分大小写</param>
	/// <returns>匹配的方法，如果不存在匹配的方法返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者方法名称 <paramref name="methodName" /> 为空或者空串。</exception>
	public static MethodInfo GetMethod(this Type type, string methodName, AccessLevels level, bool ignoreCase = false)
	{
		return type.GetMethods(methodName, level, ignoreCase).FirstOrDefault();
	}

	/// <summary>
	/// 获取当前类型中具有指定名称并与给定参数类型数组匹配的公共实例方法
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="methodName">方法名称，区分大小写</param>
	/// <param name="argTypes">参数类型数组</param>
	/// <returns>匹配的方法，如果不存在匹配的方法返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者方法名称 <paramref name="methodName" /> 为空或者空串。</exception>
	public static MethodInfo GetMethod(this Type type, string methodName, params Type[] argTypes)
	{
		type.GuardNotNull("type");
		methodName.GuardNotNullAndEmpty("method name");
		return type.GetMethod(methodName, argTypes);
	}

	/// <summary>
	/// 获取当前类型中指定名称的，参数与给定参数类型数组匹配的公共实例方法
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="methodName">方法名称</param>
	/// <param name="argTypes">参数类型数组</param>
	/// <param name="ignoreCase">方法名称是否区分大小写</param>
	/// <param name="optionalBinding">对于构造函数的可选参数是否也必须进行绑定，默认为不对可选参数进行绑定</param>
	/// <returns>匹配的方法，如果不存在匹配的方法返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者方法名称 <paramref name="methodName" /> 为空或者空串。</exception>
	public static MethodInfo GetMethod(this Type type, string methodName, Type[] argTypes, bool ignoreCase = false, bool optionalBinding = false)
	{
		type.GuardNotNull("type");
		methodName.GuardNotNullAndEmpty("method name");
		return type.GetMethods(methodName, argTypes, ignoreCase, optionalBinding).FirstOrDefault();
	}

	/// <summary>
	/// 获取当前类型中满足匹配条件具有指定名称的的方法
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="methodName">方法名称</param>
	/// <param name="argTypes">参数类型数组</param>
	/// <param name="flags">方法绑定条件</param>
	/// <param name="ignoreCase">方法名称是否区分大小写</param>
	/// <param name="optionalBinding">对于构造函数的可选参数是否也必须进行绑定，默认为不对可选参数进行绑定</param>
	/// <returns>匹配的方法，如果不存在匹配的方法返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者方法名称 <paramref name="methodName" /> 为空或者空串。</exception>
	public static MethodInfo GetMethod(this Type type, string methodName, Type[] argTypes, BindingFlags flags, bool ignoreCase = false, bool optionalBinding = false)
	{
		return type.GetMethods(methodName, argTypes, flags, ignoreCase, optionalBinding).FirstOrDefault();
	}

	/// <summary>
	/// 获取当前类型中满足匹配条件具有指定名称的的方法
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="methodName">方法名称</param>
	/// <param name="argTypes">参数类型数组</param>
	/// <param name="level">获取的方法的访问级别</param>
	/// <param name="ignoreCase">方法名称是否区分大小写</param>
	/// <param name="optionalBinding">对于构造函数的可选参数是否也必须进行绑定，默认为不对可选参数进行绑定</param>
	/// <returns>匹配的方法，如果不存在匹配的方法返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者方法名称 <paramref name="methodName" /> 为空或者空串。</exception>
	public static MethodInfo GetMethod(this Type type, string methodName, Type[] argTypes, AccessLevels level, bool ignoreCase = false, bool optionalBinding = false)
	{
		return type.GetMethods(methodName, argTypes, level, ignoreCase, optionalBinding).FirstOrDefault();
	}

	/// <summary>
	/// 获取当前类型中指定访问级别的方法
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="level">获取的方法的访问级别</param>
	/// <returns>当前类型中符合条件的方法</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	public static MethodInfo[] GetMethods(this Type type, AccessLevels level)
	{
		type.GuardNotNull("type");
		return (from x in type.GetMethods(level.ToBindingFlags())
			where x.GetAccessLevel().HasLevel(level)
			select x).ToArray();
	}

	/// <summary>
	/// 获取当前类型中满足绑定条件和筛选条件的方法
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="predicate">方法筛选条件</param>
	/// <param name="flags">方法绑定搜索标志</param>
	/// <returns>当前类型中符合条件的方法</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者方法筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static MethodInfo[] GetMethods(this Type type, Func<MethodInfo, bool> predicate, BindingFlags flags = BindingFlags.Instance | BindingFlags.Public)
	{
		type.GuardNotNull("type");
		predicate.GuardNotNull("predicate");
		return type.GetMethods(flags).Where(predicate).ToArray();
	}

	/// <summary>
	/// 获取当前类型中指定访问级别满足筛选条件的方法
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="predicate">方法筛选条件</param>
	/// <param name="level">获取的方法的访问级别，默认为 <see cref="F:Richfit.Garnet.Common.Reflection.AccessLevels.Public" /></param>
	/// <returns>当前类型中符合条件的方法</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者方法筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static MethodInfo[] GetMethods(this Type type, Func<MethodInfo, bool> predicate, AccessLevels level)
	{
		predicate.GuardNotNull("predicate");
		return type.GetMethods(level).Where(predicate).ToArray();
	}

	/// <summary>
	/// 获取当前类型中与参数类型数组匹配的公共实例方法
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="argTypes">参数类型数组</param>
	/// <returns>当前类型中符合条件的方法</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者参数类型数组 <paramref name="argTypes" /> 为空。</exception>
	public static MethodInfo[] GetMethods(this Type type, params Type[] argTypes)
	{
		return type.GetMethods(argTypes, optionalBinding: false);
	}

	/// <summary>
	/// 获取当前类型中与参数类型数组匹配的公共实例方法
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="argTypes">参数类型数组</param>
	/// <param name="optionalBinding">对于方法的可选参数是否也必须进行绑定</param>
	/// <returns>当前类型中符合条件的方法</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者参数类型数组 <paramref name="argTypes" /> 为空。</exception>
	public static MethodInfo[] GetMethods(this Type type, Type[] argTypes, bool optionalBinding)
	{
		return type.GetMethods(argTypes, BindingFlags.Instance | BindingFlags.Public, optionalBinding);
	}

	/// <summary>
	/// 获取当前类型中满足绑定条件的与参数类型数组匹配的方法
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="argTypes">参数类型数组</param>
	/// <param name="flags">方法绑定搜索标志</param>
	/// <param name="optionalBinding">对于方法的可选参数是否也必须进行绑定，默认为不对可选参数进行绑定</param>
	/// <returns>当前类型中符合条件的方法</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者参数类型数组 <paramref name="argTypes" /> 为空。</exception>
	public static MethodInfo[] GetMethods(this Type type, Type[] argTypes, BindingFlags flags, bool optionalBinding = false)
	{
		type.GuardNotNull("type");
		argTypes.GuardNotNull("argument types");
		return (from x in type.GetMethods(flags)
			where x.IsBindable(argTypes, optionalBinding)
			select x).ToArray();
	}

	/// <summary>
	/// 获取当前类型中指定访问级别的与参数类型数组匹配的方法
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="argTypes">参数类型数组</param>
	/// <param name="level">获取的方法的访问级别</param>
	/// <param name="optionalBinding">对于方法的可选参数是否也必须进行绑定，默认为不对可选参数进行绑定</param>
	/// <returns>当前类型中符合条件的方法</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者参数类型数组 <paramref name="argTypes" /> 为空。</exception>
	public static MethodInfo[] GetMethods(this Type type, Type[] argTypes, AccessLevels level, bool optionalBinding = false)
	{
		argTypes.GuardNotNull("argument types");
		return (from x in type.GetMethods(level)
			where x.IsBindable(argTypes, optionalBinding)
			select x).ToArray();
	}

	/// <summary>
	/// 获取当前类型中的指定名称的公共实例方法
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="methodName">方法名称</param>
	/// <param name="ignoreCase">方法名称是否区分大小写</param>
	/// <returns>当前类型中符合条件的方法</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者方法名称 <paramref name="methodName" /> 为空或者空串。</exception>
	public static MethodInfo[] GetMethods(this Type type, string methodName, bool ignoreCase = false)
	{
		type.GuardNotNull("type");
		methodName.GuardNotNullAndEmpty("method name");
		return (from x in type.GetMethods(BindingFlags.Instance | BindingFlags.Public)
			where x.Name.EqualOrdinal(methodName, ignoreCase)
			select x).ToArray();
	}

	/// <summary>
	/// 获取当前类型中满足绑定条件和指定名称的方法
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="methodName">方法名称</param>
	/// <param name="flags">方法绑定搜索标志</param>
	/// <param name="ignoreCase">方法名称是否区分大小写</param>
	/// <returns>当前类型中符合条件的方法</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者方法名称 <paramref name="methodName" /> 为空或者空串。</exception>
	public static MethodInfo[] GetMethods(this Type type, string methodName, BindingFlags flags, bool ignoreCase = false)
	{
		type.GuardNotNull("type");
		methodName.GuardNotNullAndEmpty("method name");
		return (from x in type.GetMethods(flags)
			where x.Name.EqualOrdinal(methodName, ignoreCase)
			select x).ToArray();
	}

	/// <summary>
	/// 获取当前类型中指定访问级别和名称的方法
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="methodName">方法名称</param>
	/// <param name="level">获取的方法的访问级别</param>
	/// <param name="ignoreCase">方法名称是否区分大小写</param>
	/// <returns>当前类型中符合条件的方法</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者方法名称 <paramref name="methodName" /> 为空或者空串。</exception>
	public static MethodInfo[] GetMethods(this Type type, string methodName, AccessLevels level, bool ignoreCase = false)
	{
		methodName.GuardNotNullAndEmpty("method name");
		return (from x in type.GetMethods(level)
			where x.Name.EqualOrdinal(methodName, ignoreCase)
			select x).ToArray();
	}

	/// <summary>
	/// 获取当前类型中具有指定名称并与参数类型数组匹配的公共实例方法
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="methodName">方法名称</param>
	/// <param name="argTypes">参数类型数组</param>
	/// <returns>当前类型中符合条件的方法</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者方法名称 <paramref name="methodName" /> 为空或者空串；或者参数类型数组 <paramref name="argTypes" /> 为空。</exception>
	public static MethodInfo[] GetMethods(this Type type, string methodName, params Type[] argTypes)
	{
		return type.GetMethods(methodName, argTypes, ignoreCase: false, optionalBinding: false);
	}

	/// <summary>
	/// 获取当前类型中具有指定名称并与参数类型数组匹配的公共实例方法
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="methodName">方法名称</param>
	/// <param name="argTypes">参数类型数组</param>
	/// <param name="ignoreCase">方法名称是否区分大小写</param>
	/// <param name="optionalBinding">对于方法的可选参数是否也必须进行绑定，默认为不对可选参数进行绑定</param>
	/// <returns>当前类型中符合条件的方法</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者方法名称 <paramref name="methodName" /> 为空或者空串；或者参数类型数组 <paramref name="argTypes" /> 为空。</exception>
	public static MethodInfo[] GetMethods(this Type type, string methodName, Type[] argTypes, bool ignoreCase = false, bool optionalBinding = false)
	{
		type.GuardNotNull("type");
		methodName.GuardNotNullAndEmpty("method name");
		argTypes.GuardNotNull("argument types");
		return (from x in type.GetMethods(BindingFlags.Instance | BindingFlags.Public)
			where x.Name.EqualOrdinal(methodName, ignoreCase) && x.IsBindable(argTypes, optionalBinding)
			select x).ToArray();
	}

	/// <summary>
	/// 获取当前类型中满足绑定条件具有指定名称并与参数类型数组匹配的方法
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="methodName">方法名称</param>
	/// <param name="argTypes">参数类型数组</param>
	/// <param name="flags">方法绑定搜索标志</param>
	/// <param name="ignoreCase">方法名称是否区分大小写</param>
	/// <param name="optionalBinding">对于方法的可选参数是否也必须进行绑定，默认为不对可选参数进行绑定</param>
	/// <returns>当前类型中符合条件的方法</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者方法名称 <paramref name="methodName" /> 为空或者空串；或者参数类型数组 <paramref name="argTypes" /> 为空。</exception>
	public static MethodInfo[] GetMethods(this Type type, string methodName, Type[] argTypes, BindingFlags flags, bool ignoreCase = false, bool optionalBinding = false)
	{
		type.GuardNotNull("type");
		methodName.GuardNotNullAndEmpty("method name");
		argTypes.GuardNotNull("argument types");
		return (from x in type.GetMethods(flags)
			where x.Name.EqualOrdinal(methodName, ignoreCase) && x.IsBindable(argTypes, optionalBinding)
			select x).ToArray();
	}

	/// <summary>
	/// 获取当前类型中指定访问级别具有指定名称并与参数类型数组匹配的方法
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="methodName">方法名称</param>
	/// <param name="argTypes">参数类型数组</param>
	/// <param name="level">获取的方法的访问级别</param>
	/// <param name="ignoreCase">方法名称是否区分大小写</param>
	/// <param name="optionalBinding">对于方法的可选参数是否也必须进行绑定，默认为不对可选参数进行绑定</param>
	/// <returns>当前类型中符合条件的方法</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者方法名称 <paramref name="methodName" /> 为空或者空串；或者参数类型数组 <paramref name="argTypes" /> 为空。</exception>
	public static MethodInfo[] GetMethods(this Type type, string methodName, Type[] argTypes, AccessLevels level, bool ignoreCase = false, bool optionalBinding = false)
	{
		methodName.GuardNotNullAndEmpty("method name");
		argTypes.GuardNotNull("argument types");
		return (from x in type.GetMethods(level)
			where x.Name.EqualOrdinal(methodName, ignoreCase) && x.IsBindable(argTypes, optionalBinding)
			select x).ToArray();
	}

	/// <summary>
	/// 获取当前类型中满足绑定条件，与名称正则模式匹配的方法
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="pattern">方法名称的正则模式</param>
	/// <param name="flags">方法绑定搜索标志</param>
	/// <returns>当前类型中符合条件的方法</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者方法名称的正则模式 <paramref name="pattern" /> 为空。</exception>
	public static MethodInfo[] GetMethods(this Type type, Regex pattern, BindingFlags flags = BindingFlags.Instance | BindingFlags.Public)
	{
		type.GuardNotNull("type");
		pattern.GuardNotNull("method name pattern");
		return (from x in type.GetMethods(flags)
			where pattern.IsMatch(x.Name)
			select x).ToArray();
	}

	/// <summary>
	/// 获取当前类型中指定访问级别，与名称正则模式匹配的方法
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="pattern">方法名称的正则模式</param>
	/// <param name="level">获取的方法的访问级别</param>
	/// <returns>当前类型中符合条件的方法</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者方法名称的正则模式 <paramref name="pattern" /> 为空。</exception>
	public static MethodInfo[] GetMethods(this Type type, Regex pattern, AccessLevels level)
	{
		pattern.GuardNotNull("method name pattern");
		return (from x in type.GetMethods(level)
			where pattern.IsMatch(x.Name)
			select x).ToArray();
	}

	/// <summary>
	/// 获取当前类型中具有与特性基类型相同或者继承于该基类型的自定义特性的公共实例方法
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="attributeType">特性基类型</param>
	/// <param name="inherit">是否从当前对象的继承结构中获取自定义特性</param>
	/// <returns>当前类型中符合条件的方法</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者特性基类型 <paramref name="attributeType" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">特性基类型 <paramref name="attributeType" /> 不是继承于 <see cref="T:System.Attribute" /> 类型。</exception>
	public static MethodInfo[] GetMethods(this Type type, Type attributeType, bool inherit = false)
	{
		return type.GetMethods(attributeType, BindingFlags.Instance | BindingFlags.Public, inherit);
	}

	/// <summary>
	/// 获取当前类型中满足绑定条件，且与特性基类型相同或者继承于该基类型的自定义特性的方法
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="attributeType">特性基类型</param>
	/// <param name="flags">获取方法的绑定条件</param>
	/// <param name="inherit">是否从当前对象的继承结构中获取自定义特性</param>
	/// <returns>当前类型中符合条件的方法</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者特性基类型 <paramref name="attributeType" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">特性基类型 <paramref name="attributeType" /> 不是继承于 <see cref="T:System.Attribute" /> 类型。</exception>
	public static MethodInfo[] GetMethods(this Type type, Type attributeType, BindingFlags flags, bool inherit = false)
	{
		type.GuardNotNull("type");
		attributeType.GuardNotNull("attribute type").GuardInheritedType<Attribute>("attribute type");
		return (from c in type.GetMethods(flags)
			where c.HasCustomAttribute(attributeType, inherit)
			select c).ToArray();
	}

	/// <summary>
	/// 获取当前类型中具有指定访问级别，且与特性基类型相同或者继承于该基类型的自定义特性的方法
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="attributeType">特性基类型</param>
	/// <param name="level">获取的方法的访问级别</param>
	/// <param name="inherit">是否从当前对象的继承结构中获取自定义特性</param>
	/// <returns>当前类型中符合条件的方法</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者特性基类型 <paramref name="attributeType" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">特性基类型 <paramref name="attributeType" /> 不是继承于 <see cref="T:System.Attribute" /> 类型。</exception>
	public static MethodInfo[] GetMethods(this Type type, Type attributeType, AccessLevels level, bool inherit = false)
	{
		type.GuardNotNull("type");
		attributeType.GuardNotNull("attribute type").GuardInheritedType<Attribute>("attribute type");
		return (from c in type.GetMethods(level)
			where c.HasCustomAttribute(attributeType, inherit)
			select c).ToArray();
	}

	/// <summary>
	/// 获取当前类型的名称。该名称遵循C#语法。
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="nestedName">如果当前类型是嵌套类，是否获取嵌套的名称。</param>
	/// <returns>遵循C#语法的当前类型名称，类型名称不包括命名空间和程序集的名称。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型null。</exception>
	public static string GetName(this Type type, bool nestedName = false)
	{
		type.GuardNotNull("type");
		StringBuilder buff = new StringBuilder();
		if (type.IsNested && nestedName)
		{
			buff.Append(type.DeclaringType.GetName(nestedName: true)).Append("+");
		}
		if (type.IsGenericType)
		{
			buff.Append(type.Name.Remove(type.Name.IndexOf("`")));
			buff.Append("<");
			Type[] genericArguments = type.GetGenericArguments();
			foreach (Type genericType in genericArguments)
			{
				buff.Append(genericType.GetName(nestedName)).Append(",");
			}
			buff.Remove(buff.Length - 2, 2);
			buff.Append(">");
		}
		else
		{
			buff.Append(type.Name);
		}
		return buff.ToString();
	}

	/// <summary>
	/// 获取当前类型中具有指定名称的公共嵌套类型
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="typeName">嵌套类型名称</param>
	/// <param name="ignoreCase">嵌套类型名称是否区分大小写</param>
	/// <returns>匹配的嵌套类型，如果不存在匹配的嵌套类型返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者嵌套类型名称 <paramref name="typeName" /> 为空或者空串。</exception>
	public static Type GetNestedType(this Type type, string typeName, bool ignoreCase)
	{
		return type.GetNestedType(typeName, (BindingFlags.Instance | BindingFlags.Public).Combine(ignoreCase));
	}

	/// <summary>
	/// 获取当前类型中满足绑定条件的具有指定名称的嵌套类型
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="typeName">嵌套类型名称</param>
	/// <param name="flags">嵌套类型绑定搜索标志</param>
	/// <param name="ignoreCase">嵌套类型名称是否区分大小写</param>
	/// <returns>匹配的嵌套类型，如果不存在匹配的嵌套类型返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者嵌套类型名称 <paramref name="typeName" /> 为空或者空串。</exception>
	public static Type GetNestedType(this Type type, string typeName, BindingFlags flags, bool ignoreCase = false)
	{
		type.GuardNotNull("type");
		typeName.GuardNotNullAndEmpty("type name");
		return type.GetNestedType(typeName, flags.Combine(ignoreCase));
	}

	/// <summary>
	/// 获取当前类型中指定访问级别具有指定名称的嵌套类型
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="typeName">嵌套类型名称</param>
	/// <param name="level">获取的嵌套类型的访问级别</param>
	/// <param name="ignoreCase">嵌套类型名称是否区分大小写</param>
	/// <returns>匹配的嵌套类型，如果不存在匹配的嵌套类型返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者嵌套类型名称 <paramref name="typeName" /> 为空或者空串。</exception>
	public static Type GetNestedType(this Type type, string typeName, AccessLevels level, bool ignoreCase = false)
	{
		typeName.GuardNotNullAndEmpty("type name");
		return (from x in type.GetNestedTypes(level)
			where x.Name.EqualOrdinal(typeName, ignoreCase)
			select x).FirstOrDefault();
	}

	/// <summary>
	/// 按照指定的类型路径从当前类型中获取具有指定访问级别的嵌套类型
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="typePath">嵌套类型的路径</param>
	/// <param name="ignoreCase">嵌套类型的路径是否区分大小写</param>
	/// <returns>匹配的嵌套类型，如果不存在匹配的嵌套类型返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者嵌套类型的路径 <paramref name="typePath" /> 为空或者空串。</exception>
	public static Type GetNestedTypeByPath(this Type type, string typePath, bool ignoreCase = false)
	{
		return type.GetNestedTypeByPath(typePath, BindingFlags.Instance | BindingFlags.Public, ignoreCase);
	}

	/// <summary>
	/// 按照指定的类型路径从当前类型中获取满足指定绑定条件的嵌套类型
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="typePath">嵌套类型的路径</param>
	/// <param name="flags">嵌套类型的绑定条件</param>
	/// <param name="ignoreCase">嵌套类型的路径是否区分大小写</param>
	/// <returns>匹配的嵌套类型，如果不存在匹配的嵌套类型返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者嵌套类型的路径 <paramref name="typePath" /> 为空或者空串。</exception>
	public static Type GetNestedTypeByPath(this Type type, string typePath, BindingFlags flags, bool ignoreCase = false)
	{
		type.GuardNotNull("type");
		typePath.GuardNotNullAndEmpty("type path");
		string[] typeNames = typePath.Split(new char[1] { '.' }, StringSplitOptions.None);
		string[] array = typeNames;
		foreach (string typeName in array)
		{
			type = type.GetNestedType(typeName, flags, ignoreCase);
			if (type.IsNull())
			{
				return null;
			}
		}
		return type;
	}

	/// <summary>
	/// 按照指定的类型路径从当前类型中获取具有指定访问级别的嵌套类型
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="typePath">嵌套类型的路径</param>
	/// <param name="level">获取的嵌套类型的访问级别</param>
	/// <param name="ignoreCase">嵌套类型的路径是否区分大小写</param>
	/// <returns>匹配的嵌套类型，如果不存在匹配的嵌套类型返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者嵌套类型的路径 <paramref name="typePath" /> 为空或者空串。</exception>
	public static Type GetNestedTypeByPath(this Type type, string typePath, AccessLevels level, bool ignoreCase = false)
	{
		type.GuardNotNull("type");
		typePath.GuardNotNullAndEmpty("type path");
		string[] typeNames = typePath.Split(new char[1] { '.' }, StringSplitOptions.None);
		string[] array = typeNames;
		foreach (string typeName in array)
		{
			type = type.GetNestedType(typeName, level, ignoreCase);
			if (type.IsNull())
			{
				return null;
			}
		}
		return type;
	}

	/// <summary>
	/// 获取当前类型中指定访问级别的嵌套类型
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="level">获取的嵌套类型的访问级别</param>
	/// <returns>当前类型中符合条件的当前类型</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	public static Type[] GetNestedTypes(this Type type, AccessLevels level)
	{
		type.GuardNotNull("type");
		return (from x in type.GetNestedTypes(level.ToBindingFlags())
			where (x.GetAccessLevel() & level) > AccessLevels.Unspecified
			select x).ToArray();
	}

	/// <summary>
	/// 获取当前类型中满足绑定条件和筛选条件的嵌套类型
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="predicate">嵌套类型筛选条件</param>
	/// <param name="flags">嵌套类型绑定搜索标志</param>
	/// <returns>当前类型中符合条件的嵌套类型</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者嵌套类型筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static Type[] GetNestedTypes(this Type type, Func<Type, bool> predicate, BindingFlags flags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public)
	{
		type.GuardNotNull("type");
		predicate.GuardNotNull("predicate");
		return type.GetNestedTypes(flags).Where(predicate).ToArray();
	}

	/// <summary>
	/// 获取当前类型中指定访问级别满足筛选条件的嵌套类型
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="predicate">嵌套类型筛选条件</param>
	/// <param name="level">获取的嵌套类型的访问级别</param>
	/// <returns>当前类型中符合条件的嵌套类型</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者嵌套类型筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static Type[] GetNestedTypes(this Type type, Func<Type, bool> predicate, AccessLevels level)
	{
		predicate.GuardNotNull("predicate");
		return type.GetNestedTypes(level).Where(predicate).ToArray();
	}

	/// <summary>
	/// 获取当前类型中满足绑定条件和名称正则模式的嵌套类型
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="pattern">嵌套类型名称的正则模式</param>
	/// <param name="flags">嵌套类型绑定搜索标志</param>
	/// <returns>当前类型中符合条件的嵌套类型</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者嵌套类型名称的正则模式 <paramref name="pattern" /> 为空。</exception>
	public static Type[] GetNestedTypes(this Type type, Regex pattern, BindingFlags flags = BindingFlags.Instance | BindingFlags.Public)
	{
		type.GuardNotNull("type");
		pattern.GuardNotNull("field name pattern");
		return (from x in type.GetNestedTypes(flags)
			where pattern.IsMatch(x.Name)
			select x).ToArray();
	}

	/// <summary>
	/// 获取当前类型中指定访问级别，满足名称正则模式的嵌套类型
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="pattern">嵌套类型名称的正则模式</param>
	/// <param name="level">获取的嵌套类型的访问级别</param>
	/// <returns>当前类型中符合条件的嵌套类型</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者嵌套类型名称的正则模式 <paramref name="pattern" /> 为空。</exception>
	public static Type[] GetNestedTypes(this Type type, Regex pattern, AccessLevels level)
	{
		pattern.GuardNotNull("event name pattern");
		return (from x in type.GetNestedTypes(level)
			where pattern.IsMatch(x.Name)
			select x).ToArray();
	}

	/// <summary>
	/// 获取当前类型中具有与特性基类型相同或者继承于该基类型的自定义特性的公共嵌套类型
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="attributeType">特性基类型</param>
	/// <param name="inherit">是否从当前对象的继承结构中获取自定义特性</param>
	/// <returns>当前类型中符合条件的嵌套类型</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者特性基类型 <paramref name="attributeType" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">特性基类型 <paramref name="attributeType" /> 不是继承于 <see cref="T:System.Attribute" /> 类型。</exception>
	public static Type[] GetNestedTypes(this Type type, Type attributeType, bool inherit = false)
	{
		return type.GetNestedTypes(attributeType, BindingFlags.Instance | BindingFlags.Public, inherit);
	}

	/// <summary>
	/// 获取当前类型中满足绑定条件，且与特性基类型相同或者继承于该基类型的自定义特性的嵌套类型
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="attributeType">特性基类型</param>
	/// <param name="flags">获取嵌套类型的绑定条件</param>
	/// <param name="inherit">是否从当前对象的继承结构中获取自定义特性</param>
	/// <returns>当前类型中符合条件的嵌套类型</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者特性基类型 <paramref name="attributeType" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">特性基类型 <paramref name="attributeType" /> 不是继承于 <see cref="T:System.Attribute" /> 类型。</exception>
	public static Type[] GetNestedTypes(this Type type, Type attributeType, BindingFlags flags, bool inherit = false)
	{
		type.GuardNotNull("type");
		attributeType.GuardNotNull("attribute type").GuardInheritedType<Attribute>("attribute type");
		return (from c in type.GetNestedTypes(flags)
			where c.HasCustomAttribute(attributeType, inherit)
			select c).ToArray();
	}

	/// <summary>
	/// 获取当前类型中具有指定访问级别，且与特性基类型相同或者继承于该基类型的自定义特性的嵌套类型
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="attributeType">特性基类型</param>
	/// <param name="level">获取的嵌套类型的访问级别</param>
	/// <param name="inherit">是否从当前对象的继承结构中获取自定义特性</param>
	/// <returns>当前类型中符合条件的嵌套类型</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者特性基类型 <paramref name="attributeType" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">特性基类型 <paramref name="attributeType" /> 不是继承于 <see cref="T:System.Attribute" /> 类型。</exception>
	public static Type[] GetNestedTypes(this Type type, Type attributeType, AccessLevels level, bool inherit = false)
	{
		type.GuardNotNull("type");
		attributeType.GuardNotNull("attribute type").GuardInheritedType<Attribute>("attribute type");
		return (from c in type.GetNestedTypes(level)
			where c.HasCustomAttribute(attributeType, inherit)
			select c).ToArray();
	}

	/// <summary>
	/// 获取当前类型中指定访问级别的属性
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="level">获取的属性的访问级别</param>
	/// <returns>当前类型中符合条件的属性</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	public static PropertyInfo[] GetProperties(this Type type, AccessLevels level)
	{
		type.GuardNotNull("type");
		return (from x in type.GetProperties(level.ToBindingFlags())
			where x.GetAccessLevel().HasLevel(level)
			select x).ToArray();
	}

	/// <summary>
	/// 获取当前类型中满足绑定条件和筛选条件的属性
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="predicate">属性筛选条件</param>
	/// <param name="flags">属性绑定搜索标志</param>
	/// <returns>当前类型中符合条件的属性</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者属性筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static PropertyInfo[] GetProperties(this Type type, Func<PropertyInfo, bool> predicate, BindingFlags flags = BindingFlags.Instance | BindingFlags.Public)
	{
		type.GuardNotNull("type");
		predicate.GuardNotNull("predicate");
		return type.GetProperties(flags).Where(predicate).ToArray();
	}

	/// <summary>
	/// 获取当前类型中指定访问级别满足筛选条件的属性
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="predicate">属性筛选条件</param>
	/// <param name="level">获取的属性的访问级别</param>
	/// <returns>当前类型中符合条件的属性</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者属性筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static PropertyInfo[] GetProperties(this Type type, Func<PropertyInfo, bool> predicate, AccessLevels level)
	{
		predicate.GuardNotNull("predicate");
		return type.GetProperties(level).Where(predicate).ToArray();
	}

	/// <summary>
	/// 获取当前类型中与参数类型数组匹配的公共实例索引属性
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="returnType">返回值类型，如果不限定返回值类型则设置为空。</param>
	/// <param name="argTypes">参数类型数组，如果不限定参数类型则设置为空。</param>
	/// <param name="inheritBinding">设置为true，指示当前属性返回值类型应是给定返回值类型 <paramref name="returnType" /> 的基类或者其本身；设置为false，指示当前属性返回值类型应继承于给定返回值类型 <paramref name="returnType" /> 或者是其本身。</param>
	/// <param name="optionalBinding">对于索引属性的可选参数是否也必须进行绑定，默认为不对可选参数进行绑定</param>
	/// <returns>当前类型中符合条件的索引属性</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	public static PropertyInfo[] GetProperties(this Type type, Type returnType, Type[] argTypes, bool inheritBinding = false, bool optionalBinding = false)
	{
		return type.GetProperties(returnType, argTypes, BindingFlags.Instance | BindingFlags.Public, optionalBinding);
	}

	/// <summary>
	/// 获取当前类型中满足绑定条件的与参数类型数组匹配的索引属性
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="returnType">返回值类型，如果不限定返回值类型则设置为空。</param>
	/// <param name="argTypes">参数类型数组，如果不限定参数类型则设置为空。</param>
	/// <param name="flags">索引属性绑定搜索标志</param>
	/// <param name="inheritBinding">设置为true，指示当前属性返回值类型应是给定返回值类型 <paramref name="returnType" /> 的基类或者其本身；设置为false，指示当前属性返回值类型应继承于给定返回值类型 <paramref name="returnType" /> 或者是其本身。</param>
	/// <param name="optionalBinding">对于索引属性的可选参数是否也必须进行绑定，默认为不对可选参数进行绑定</param>
	/// <returns>当前类型中符合条件的索引属性</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	public static PropertyInfo[] GetProperties(this Type type, Type returnType, Type[] argTypes, BindingFlags flags, bool inheritBinding = false, bool optionalBinding = false)
	{
		type.GuardNotNull("type");
		return (from x in type.GetProperties(flags)
			where x.IsBindable(returnType, argTypes, inheritBinding, optionalBinding)
			select x).ToArray();
	}

	/// <summary>
	/// 获取当前类型中指定访问级别的与参数类型数组匹配的索引属性
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="returnType">返回值类型，如果不限定返回值类型则设置为空。</param>
	/// <param name="argTypes">参数类型数组，如果不限定参数类型则设置为空。</param>
	/// <param name="level">获取的索引属性的访问级别</param>
	/// <param name="inheritBinding">设置为true，指示当前属性返回值类型应是给定返回值类型 <paramref name="returnType" /> 的基类或者其本身；设置为false，指示当前属性返回值类型应继承于给定返回值类型 <paramref name="returnType" /> 或者是其本身。</param>
	/// <param name="optionalBinding">对于索引属性的可选参数是否也必须进行绑定，默认为不对可选参数进行绑定</param>
	/// <returns>当前类型中符合条件的索引属性</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	public static PropertyInfo[] GetProperties(this Type type, Type returnType, Type[] argTypes, AccessLevels level, bool inheritBinding = false, bool optionalBinding = false)
	{
		type.GuardNotNull("type");
		return (from x in type.GetProperties(level)
			where x.IsBindable(returnType, argTypes, inheritBinding, optionalBinding)
			select x).ToArray();
	}

	/// <summary>
	/// 获取当前类型中满足绑定条件和名称正则模式的属性
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="pattern">属性名称的正则模式</param>
	/// <param name="flags">属性绑定搜索标志</param>
	/// <returns>当前类型中符合条件的属性</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者属性名称的正则模式 <paramref name="pattern" /> 为空。</exception>
	public static PropertyInfo[] GetProperties(this Type type, Regex pattern, BindingFlags flags = BindingFlags.Instance | BindingFlags.Public)
	{
		type.GuardNotNull("type");
		pattern.GuardNotNull("property name pattern");
		return (from x in type.GetProperties(flags)
			where pattern.IsMatch(x.Name)
			select x).ToArray();
	}

	/// <summary>
	/// 获取当前类型中指定访问级别的满足名称正则模式的属性
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="pattern">属性名称的正则模式</param>
	/// <param name="level">获取的属性的访问级别</param>
	/// <returns>当前类型中符合条件的属性</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者属性名称的正则模式 <paramref name="pattern" /> 为空。</exception>
	public static PropertyInfo[] GetProperties(this Type type, Regex pattern, AccessLevels level)
	{
		pattern.GuardNotNull("property name pattern");
		return (from x in type.GetProperties(level)
			where pattern.IsMatch(x.Name)
			select x).ToArray();
	}

	/// <summary>
	/// 获取当前类型中具有与特性基类型相同或者继承于该基类型的自定义特性的公共实例属性
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="attributeType">特性基类型</param>
	/// <param name="inherit">是否从当前对象的继承结构中获取自定义特性</param>
	/// <returns>当前类型中符合条件的属性</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者特性基类型 <paramref name="attributeType" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">特性基类型 <paramref name="attributeType" /> 不是继承于 <see cref="T:System.Attribute" /> 类型。</exception>
	public static PropertyInfo[] GetProperties(this Type type, Type attributeType, bool inherit = false)
	{
		return type.GetProperties(attributeType, BindingFlags.Instance | BindingFlags.Public, inherit);
	}

	/// <summary>
	/// 获取当前类型中满足绑定条件，且与特性基类型相同或者继承于该基类型的自定义特性的属性
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="attributeType">特性基类型</param>
	/// <param name="flags">获取属性的绑定条件</param>
	/// <param name="inherit">是否从当前对象的继承结构中获取自定义特性</param>
	/// <returns>当前类型中符合条件的属性</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者特性基类型 <paramref name="attributeType" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">特性基类型 <paramref name="attributeType" /> 不是继承于 <see cref="T:System.Attribute" /> 类型。</exception>
	public static PropertyInfo[] GetProperties(this Type type, Type attributeType, BindingFlags flags, bool inherit = false)
	{
		type.GuardNotNull("type");
		attributeType.GuardNotNull("attribute type").GuardInheritedType<Attribute>("attribute type");
		return (from c in type.GetProperties(flags)
			where c.HasCustomAttribute(attributeType, inherit)
			select c).ToArray();
	}

	/// <summary>
	/// 获取当前类型中具有指定访问级别，且与特性基类型相同或者继承于该基类型的自定义特性的属性
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="attributeType">特性基类型</param>
	/// <param name="level">获取的属性的访问级别</param>
	/// <param name="inherit">是否从当前对象的继承结构中获取自定义特性</param>
	/// <returns>当前类型中符合条件的属性</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者特性基类型 <paramref name="attributeType" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">特性基类型 <paramref name="attributeType" /> 不是继承于 <see cref="T:System.Attribute" /> 类型。</exception>
	public static PropertyInfo[] GetProperties(this Type type, Type attributeType, AccessLevels level, bool inherit = false)
	{
		type.GuardNotNull("type");
		attributeType.GuardNotNull("attribute type").GuardInheritedType<Attribute>("attribute type");
		return (from c in type.GetProperties(level)
			where c.HasCustomAttribute(attributeType, inherit)
			select c).ToArray();
	}

	/// <summary>
	/// 获取当前类型中具有指定名称的公共实例属性
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="propertyName">属性名称</param>
	/// <param name="ignoreCase">属性名称是否区分大小写</param>
	/// <returns>匹配的属性，如果不存在匹配的属性返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者属性名称 <paramref name="propertyName" /> 为空或者空串。</exception>
	public static PropertyInfo GetProperty(this Type type, string propertyName, bool ignoreCase)
	{
		type.GuardNotNull("type");
		propertyName.GuardNotNullAndEmpty("property name");
		return type.GetProperty(propertyName, (BindingFlags.Instance | BindingFlags.Public).Combine(ignoreCase));
	}

	/// <summary>
	/// 获取当前类型中满足绑定条件的具有指定名称的属性
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="propertyName">属性名称</param>
	/// <param name="flags">属性绑定搜索标志</param>
	/// <param name="ignoreCase">属性名称是否区分大小写</param>
	/// <returns>匹配的属性，如果不存在匹配的属性返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者属性名称 <paramref name="propertyName" /> 为空或者空串。</exception>
	public static PropertyInfo GetProperty(this Type type, string propertyName, BindingFlags flags, bool ignoreCase = false)
	{
		type.GuardNotNull("type");
		propertyName.GuardNotNullAndEmpty("property name");
		return type.GetProperty(propertyName, flags.Combine(ignoreCase));
	}

	/// <summary>
	/// 获取当前类型中指定访问级别具有指定名称的属性
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="propertyName">属性名称</param>
	/// <param name="level">获取的属性的访问级别</param>
	/// <param name="ignoreCase">属性名称是否区分大小写</param>
	/// <returns>匹配的属性，如果不存在匹配的属性返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者属性名称 <paramref name="propertyName" /> 为空或者空串。</exception>
	public static PropertyInfo GetProperty(this Type type, string propertyName, AccessLevels level, bool ignoreCase = false)
	{
		type.GuardNotNull("type");
		propertyName.GuardNotNullAndEmpty("property name");
		return (from x in type.GetProperties(level)
			where x.Name.EqualOrdinal(propertyName, ignoreCase)
			select x).FirstOrDefault();
	}

	/// <summary>
	/// 获取当前类型中具有指定名称和返回值类型的公共实例属性
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="propertyName">属性名称</param>
	/// <param name="returnType">返回值类型</param>
	/// <param name="ignoreCase">属性名称是否区分大小写</param>
	/// <param name="inheritBinding">设置为true，指示当前属性返回值类型应是给定返回值类型 <paramref name="returnType" /> 的基类或者其本身；设置为false，指示当前属性返回值类型应继承于给定返回值类型 <paramref name="returnType" /> 或者是其本身。 </param>
	/// <returns>匹配的属性，如果不存在匹配的属性返回null。 </returns>
	/// <exception cref="T:System.ArgumentNullException"> 当前类型为空；或者属性名称 <paramref name="propertyName" /> 为空或者空串；或者返回值类型 <paramref name="returnType" /> 为空。</exception>
	public static PropertyInfo GetProperty(this Type type, string propertyName, Type returnType, bool ignoreCase = false, bool inheritBinding = false)
	{
		return type.GetProperty(propertyName, returnType, BindingFlags.Instance | BindingFlags.Public, ignoreCase, inheritBinding);
	}

	/// <summary>
	/// 获取当前类型中满足绑定条件，具有指定名称和返回值类型的属性
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="propertyName">属性名称</param>
	/// <param name="returnType">返回值类型</param>
	/// <param name="flags">属性绑定搜索标志</param>
	/// <param name="ignoreCase">属性名称是否区分大小写</param>
	/// <param name="inheritBinding">设置为true，指示当前属性返回值类型应是给定返回值类型 <paramref name="returnType" /> 的基类或者其本身；设置为false，指示当前属性返回值类型应继承于给定返回值类型 <paramref name="returnType" /> 或者是其本身。 </param>
	/// <returns>匹配的属性，如果不存在匹配的属性返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException"> 当前类型为空；或者属性名称 <paramref name="propertyName" /> 为空或者空串；或者返回值类型 <paramref name="returnType" /> 为空。</exception>
	public static PropertyInfo GetProperty(this Type type, string propertyName, Type returnType, BindingFlags flags, bool ignoreCase = false, bool inheritBinding = false)
	{
		PropertyInfo pinfo = type.GetProperty(propertyName, flags, ignoreCase);
		return pinfo.IsBindable(returnType, null, inheritBinding) ? pinfo : null;
	}

	/// <summary>
	/// 获取当前类型中具有指定访问级别、名称和返回值类型的属性
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="propertyName">属性名称</param>
	/// <param name="returnType">返回值类型</param>
	/// <param name="level">获取的属性的访问级别</param>
	/// <param name="ignoreCase">属性名称是否区分大小写</param>
	/// <param name="inheritBinding">设置为true，指示当前属性返回值类型应是给定返回值类型 <paramref name="returnType" /> 的基类或者其本身；设置为false，指示当前属性返回值类型应继承于给定返回值类型 <paramref name="returnType" /> 或者是其本身。 </param>
	/// <returns>匹配的属性，如果不存在匹配的属性返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException"> 当前类型为空；或者属性名称 <paramref name="propertyName" /> 为空或者空串；或者返回值类型 <paramref name="returnType" /> 为空。</exception>
	public static PropertyInfo GetProperty(this Type type, string propertyName, Type returnType, AccessLevels level, bool ignoreCase = false, bool inheritBinding = false)
	{
		PropertyInfo pinfo = type.GetProperty(propertyName, level, ignoreCase);
		return pinfo.IsBindable(returnType, null, inheritBinding) ? pinfo : null;
	}

	/// <summary>
	/// 获取当前类型中具有指定名称与参数类型数组匹配的公共实例属性
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="propertyName">属性名称</param>
	/// <param name="argTypes">参数类型数组</param>
	/// <param name="ignoreCase">属性名称是否区分大小写</param>
	/// <param name="optionalBinding">对于索引属性的可选参数是否也必须进行绑定，默认为不对可选参数进行绑定 </param>
	/// <returns>匹配的属性，如果不存在匹配的属性返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者属性名称 <paramref name="propertyName" /> 为空或者空串；或者参数类型数组 <paramref name="argTypes" /> 为空。</exception>
	public static PropertyInfo GetProperty(this Type type, string propertyName, Type[] argTypes, bool ignoreCase = false, bool optionalBinding = false)
	{
		return type.GetProperty(propertyName, argTypes, BindingFlags.Instance | BindingFlags.Public, ignoreCase, optionalBinding);
	}

	/// <summary>
	/// 获取当前类型中满足绑定条件，具有指定名称与参数类型数组匹配的属性
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="propertyName">属性名称</param>
	/// <param name="argTypes">参数类型数组</param>
	/// <param name="flags">属性绑定搜索标志</param>
	/// <param name="ignoreCase">属性名称是否区分大小写 </param>
	/// <param name="optionalBinding">对于索引属性的可选参数是否也必须进行绑定，默认为不对可选参数进行绑定 </param>
	/// <returns>匹配的属性，如果不存在匹配的属性返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者属性名称 <paramref name="propertyName" /> 为空或者空串；或者参数类型数组 <paramref name="argTypes" /> 为空。</exception>
	public static PropertyInfo GetProperty(this Type type, string propertyName, Type[] argTypes, BindingFlags flags, bool ignoreCase = false, bool optionalBinding = false)
	{
		PropertyInfo pinfo = type.GetProperty(propertyName, flags, ignoreCase);
		return pinfo.IsBindable(null, argTypes, inheritBinding: false, optionalBinding) ? pinfo : null;
	}

	/// <summary>
	/// 获取当前类型中具有指定访问级别、名称，且与参数类型数组匹配的属性
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="propertyName">属性名称</param>
	/// <param name="argTypes">参数类型数组</param>
	/// <param name="level">获取的属性的访问级别</param>
	/// <param name="ignoreCase">属性名称是否区分大小写</param>
	/// <param name="optionalBinding">对于索引属性的可选参数是否也必须进行绑定，默认为不对可选参数进行绑定 </param>
	/// <returns>匹配的属性，如果不存在匹配的属性返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者属性名称 <paramref name="propertyName" /> 为空或者空串；或者参数类型数组 <paramref name="argTypes" /> 为空。</exception>
	public static PropertyInfo GetProperty(this Type type, string propertyName, Type[] argTypes, AccessLevels level, bool ignoreCase = false, bool optionalBinding = false)
	{
		PropertyInfo pinfo = type.GetProperty(propertyName, level, ignoreCase);
		return pinfo.IsBindable(null, argTypes, inheritBinding: false, optionalBinding) ? pinfo : null;
	}

	/// <summary>
	/// 获取当前类型中具有指定名称与参数类型数组匹配的公共实例属性
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="propertyName">属性名称</param>
	/// <param name="returnType">返回值类型，如果不限定返回值类型则设置为空。</param>
	/// <param name="argTypes">参数类型数组，如果不限定参数类型则设置为空。</param>
	/// <param name="ignoreCase">属性名称是否区分大小写</param>
	/// <param name="inheritBinding">设置为true，指示当前属性返回值类型应是给定返回值类型 <paramref name="returnType" /> 的基类或者其本身；设置为false，指示当前属性返回值类型应继承于给定返回值类型 <paramref name="returnType" /> 或者是其本身。</param>
	/// <param name="optionalBinding">对于索引属性的可选参数是否也必须进行绑定，默认为不对可选参数进行绑定</param>
	/// <returns>匹配的属性，如果不存在匹配的属性返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者属性名称 <paramref name="propertyName" /> 为空或者空串；或者参数类型数组 <paramref name="argTypes" /> 为空。</exception>
	public static PropertyInfo GetProperty(this Type type, string propertyName, Type returnType, Type[] argTypes, bool ignoreCase = false, bool inheritBinding = false, bool optionalBinding = false)
	{
		return type.GetProperty(propertyName, returnType, argTypes, BindingFlags.Instance | BindingFlags.Public, ignoreCase, inheritBinding, optionalBinding);
	}

	/// <summary>
	/// 获取当前类型中具有指定名称与参数类型数组匹配的属性
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="propertyName">属性名称</param>
	/// <param name="returnType">返回值类型，如果不限定返回值类型则设置为空。</param>
	/// <param name="argTypes">参数类型数组，如果不限定参数类型则设置为空。</param>
	/// <param name="flags">属性绑定搜索标志</param>
	/// <param name="ignoreCase">属性名称是否区分大小写</param>
	/// <param name="inheritBinding">设置为true，指示当前属性返回值类型应是给定返回值类型 <paramref name="returnType" /> 的基类或者其本身；设置为false，指示当前属性返回值类型应继承于给定返回值类型 <paramref name="returnType" /> 或者是其本身。</param>
	/// <param name="optionalBinding">对于索引属性的可选参数是否也必须进行绑定，默认为不对可选参数进行绑定</param>
	/// <returns>匹配的属性，如果不存在匹配的属性返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者属性名称 <paramref name="propertyName" /> 为空或者空串；或者参数类型数组 <paramref name="argTypes" /> 为空。</exception>
	public static PropertyInfo GetProperty(this Type type, string propertyName, Type returnType, Type[] argTypes, BindingFlags flags, bool ignoreCase = false, bool inheritBinding = false, bool optionalBinding = false)
	{
		PropertyInfo pinfo = type.GetProperty(propertyName, flags, ignoreCase);
		return pinfo.IsBindable(returnType, argTypes, inheritBinding, optionalBinding) ? pinfo : null;
	}

	/// <summary>
	/// 获取当前类型中具有指定名称与参数类型数组匹配的属性
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="propertyName">属性名称</param>
	/// <param name="returnType">返回值类型，如果不限定返回值类型则设置为空。</param>
	/// <param name="argTypes">参数类型数组，如果不限定参数类型则设置为空。</param>
	/// <param name="level">获取的属性的访问级别</param>
	/// <param name="ignoreCase">属性名称是否区分大小写</param>
	/// <param name="inheritBinding">设置为true，指示当前属性返回值类型应是给定返回值类型 <paramref name="returnType" /> 的基类或者其本身；设置为false，指示当前属性返回值类型应继承于给定返回值类型 <paramref name="returnType" /> 或者是其本身。</param>
	/// <param name="optionalBinding">对于索引属性的可选参数是否也必须进行绑定，默认为不对可选参数进行绑定</param>
	/// <returns>匹配的属性，如果不存在匹配的属性返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者属性名称 <paramref name="propertyName" /> 为空或者空串；或者参数类型数组 <paramref name="argTypes" /> 为空。</exception>
	public static PropertyInfo GetProperty(this Type type, string propertyName, Type returnType, Type[] argTypes, AccessLevels level, bool ignoreCase = false, bool inheritBinding = false, bool optionalBinding = false)
	{
		PropertyInfo pinfo = type.GetProperty(propertyName, level, ignoreCase);
		return pinfo.IsBindable(returnType, argTypes, inheritBinding, optionalBinding) ? pinfo : null;
	}

	/// <summary>
	/// 按照属性路径在当前类型中获取公共实例属性
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="propertyPath">属性路径</param>
	/// <param name="ignoreCase">属性名称是否区分大小写</param>
	/// <returns>匹配的属性，如果不存在匹配的属性返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者属性路径 <paramref name="propertyPath" /> 为空或者空串。</exception>
	public static PropertyInfo GetPropertyByPath(this Type type, string propertyPath, bool ignoreCase = false)
	{
		return type.GetPropertyByPath(propertyPath, BindingFlags.Instance | BindingFlags.Public, ignoreCase);
	}

	/// <summary>
	/// 按照属性路径在当前类型中获取指定访问级别的属性
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="propertyPath">属性路径</param>
	/// <param name="flags">获取的属性的绑定条件</param>
	/// <param name="ignoreCase">属性名称是否区分大小写</param>
	/// <returns>匹配的属性，如果不存在匹配的属性返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者属性路径 <paramref name="propertyPath" /> 为空或者空串。</exception>
	public static PropertyInfo GetPropertyByPath(this Type type, string propertyPath, BindingFlags flags, bool ignoreCase = false)
	{
		type.GuardNotNull("type");
		propertyPath.GuardNotNullAndEmpty("property path");
		string[] propertyNames = propertyPath.Split(new char[1] { '.' }, StringSplitOptions.None);
		PropertyInfo property = null;
		string[] array = propertyNames;
		foreach (string propertyName in array)
		{
			property = type.GetProperty(propertyName, flags, ignoreCase);
			if (property.IsNull())
			{
				return null;
			}
			type = property.PropertyType;
		}
		return property;
	}

	/// <summary>
	/// 按照属性路径在当前类型中获取指定访问级别的属性
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="propertyPath">属性路径</param>
	/// <param name="level">获取的属性的访问级别</param>
	/// <param name="ignoreCase">属性名称是否区分大小写</param>
	/// <returns>匹配的属性，如果不存在匹配的属性返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者属性路径 <paramref name="propertyPath" /> 为空或者空串。</exception>
	public static PropertyInfo GetPropertyByPath(this Type type, string propertyPath, AccessLevels level, bool ignoreCase = false)
	{
		type.GuardNotNull("type");
		propertyPath.GuardNotNullAndEmpty("property path");
		string[] propertyNames = propertyPath.Split(new char[1] { '.' }, StringSplitOptions.None);
		PropertyInfo property = null;
		string[] array = propertyNames;
		foreach (string propertyName in array)
		{
			property = type.GetProperty(propertyName, level, ignoreCase);
			if (property.IsNull())
			{
				return null;
			}
			type = property.PropertyType;
		}
		return property;
	}

	/// <summary>
	/// 按照属性路径在当前类型中获取公共实例属性的属性类型
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="propertyPath">属性路径</param>
	/// <param name="ignoreCase">属性名称是否区分大小写</param>
	/// <returns>匹配的属性的属性类型，如果不存在匹配的属性返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者属性路径 <paramref name="propertyPath" /> 为空或者空串。</exception>
	public static Type GetPropertyType(this Type type, string propertyPath, bool ignoreCase = false)
	{
		return type.GetPropertyType(propertyPath, BindingFlags.Instance | BindingFlags.Public, ignoreCase);
	}

	/// <summary>
	/// 按照属性路径在当前类型中获取指定访问级别的属性的属性类型
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="propertyPath">属性路径</param>
	/// <param name="flags">获取属性的绑定条件</param>
	/// <param name="ignoreCase">属性名称是否区分大小写</param>
	/// <returns>匹配的属性的属性类型，如果不存在匹配的属性返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者属性路径 <paramref name="propertyPath" /> 为空或者空串。</exception>
	public static Type GetPropertyType(this Type type, string propertyPath, BindingFlags flags, bool ignoreCase = false)
	{
		type.GuardNotNull("type");
		propertyPath.GuardNotNullAndEmpty("property path");
		PropertyInfo pinfo = type.GetProperty(propertyPath, flags, ignoreCase);
		return pinfo.IsNull() ? null : pinfo.PropertyType;
	}

	/// <summary>
	/// 按照属性路径在当前类型中获取指定访问级别的属性的属性类型
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="propertyPath">属性路径</param>
	/// <param name="level">获取的属性的访问级别</param>
	/// <param name="ignoreCase">属性名称是否区分大小写</param>
	/// <returns>匹配的属性的属性类型，如果不存在匹配的属性返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者属性路径 <paramref name="propertyPath" /> 为空或者空串。</exception>
	public static Type GetPropertyType(this Type type, string propertyPath, AccessLevels level, bool ignoreCase = false)
	{
		type.GuardNotNull("type");
		propertyPath.GuardNotNullAndEmpty("property path");
		PropertyInfo pinfo = type.GetProperty(propertyPath, level, ignoreCase);
		return pinfo.IsNull() ? null : pinfo.PropertyType;
	}

	/// <summary>
	/// 获取当前类型的命名空间限定名称。该名称遵循C#语法。
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <returns>遵循C#语法的当前类型命名空间限定名称</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	public static string GetFullName(this Type type)
	{
		type.GuardNotNull("type");
		StringBuilder buff = new StringBuilder();
		buff.Append(type.Namespace).Append(".");
		if (type.IsNested)
		{
			buff.Append(type.DeclaringType.GetName(nestedName: true)).Append("+");
		}
		if (type.IsGenericType)
		{
			buff.Append(type.Name.Remove(type.Name.IndexOf("`")));
			buff.Append("<");
			Type[] genericArguments = type.GetGenericArguments();
			foreach (Type genericType in genericArguments)
			{
				buff.Append(genericType.GetFullName()).Append(", ");
			}
			buff.Remove(buff.Length - 2, 2);
			buff.Append(">");
		}
		else
		{
			buff.Append(type.Name);
		}
		return buff.ToString();
	}

	/// <summary>
	/// 检测当前类型是否是指定的类型，如果不符合则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <typeparam name="T">待检测的目标的类型</typeparam>
	/// <param name="type">当前类型</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过则返回当前类型</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	/// <exception cref="T:System.ArgumentException">如果当前类型不是指定的目标类型则抛出 <see cref="T:System.ArgumentException" /> 异常</exception>
	public static Type GuardType<T>(this Type type, string name = null, string message = null)
	{
		return type.GuardType(typeof(T), name, message);
	}

	/// <summary>
	/// 检测当前类型是否是指定的类型，如果不符合则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">待检测的目标的类型</typeparam>
	/// <param name="type">当前类型</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过则返回当前类型</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">如果当前类型不是指定的目标类型则抛出，则抛出参数 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static Type GuardType<T>(this Type type, Func<Exception> exceptionCreator)
	{
		return type.GuardType(typeof(T), exceptionCreator);
	}

	/// <summary>
	/// 检测当前类型是否是指定的类型，如果不符合则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <typeparam name="T">待检测的目标的类型</typeparam>
	/// <param name="type">当前类型</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检测通过则返回当前类型</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">如果当前类型不是指定的目标类型则抛出，则抛出参数 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static Type GuardType<T>(this Type type, Type exceptionType, params object[] args)
	{
		return type.GuardType(typeof(T), exceptionType, args);
	}

	/// <summary>
	/// 检测当前类型是否符合指定的类型，如果不符合则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="targetType">检测的目标类型</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过则返回当前类型</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者 <paramref name="targetType" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">如果当前类型不是指定的目标类型则抛出 <see cref="T:System.ArgumentException" /> 异常</exception>
	public static Type GuardType(this Type type, Type targetType, string name = null, string message = null)
	{
		type.GuardNotNull("type");
		targetType.GuardNotNull("target type");
		type.Guard(type.Equals(targetType), name.IfNull("item"), message.IfNull(Literals.MSG_TypeNotTarget_1.FormatValue(targetType.FullName)));
		return type;
	}

	/// <summary>
	/// 检测当前类型是否是指定的类型，如果不符合则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="targetType">检测的目标类型</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过则返回当前类型</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者 <paramref name="targetType" /> 为空；或者 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">如果当前类型不是指定的目标类型则抛出，则抛出参数 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static Type GuardType(this Type type, Type targetType, Func<Exception> exceptionCreator)
	{
		type.GuardNotNull("type");
		targetType.GuardNotNull("target type");
		type.Guard(type.Equals(targetType), exceptionCreator);
		return type;
	}

	/// <summary>
	/// 检测当前类型是否是指定的类型，如果不符合则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="targetType">检测的目标类型</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检测通过则返回当前类型</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者 <paramref name="targetType" /> 为空；或者 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">如果当前类型不是指定的目标类型则抛出，则抛出参数 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static Type GuardType(this Type type, Type targetType, Type exceptionType, params object[] args)
	{
		type.GuardNotNull("type");
		targetType.GuardNotNull("target type");
		type.Guard(type.Equals(targetType), exceptionType, args);
		return type;
	}

	/// <summary>
	/// 检测当前类型是否是指定的类型或者是指定类型的派生类型，如果不符合则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <typeparam name="T">检测的目标类型</typeparam>
	/// <param name="type">当前类型</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过则返回当前类型</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	/// <exception cref="T:System.ArgumentException">如果当前类型不是指定的类型或者不是指定类型的派生类型 <see cref="T:System.ArgumentException" /> 异常</exception>
	public static Type GuardInheritedType<T>(this Type type, string name = null, string message = null)
	{
		return type.GuardInheritedType(typeof(T), name, message);
	}

	/// <summary>
	/// 检测当前类型是否是指定的类型或者是指定类型的派生类型，如果不符合则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">检测的目标类型</typeparam>
	/// <param name="type">当前类型</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过则返回当前类型</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">如果当前类型不是指定的类型或者不是指定类型的派生类型，则抛出参数 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static Type GuardInheritedType<T>(this Type type, Func<Exception> exceptionCreator)
	{
		return type.GuardInheritedType(typeof(T), exceptionCreator);
	}

	/// <summary>
	/// 检测当前类型是否是指定的类型或者是指定类型的派生类型，如果不符合则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <typeparam name="T">检测的目标类型</typeparam>
	/// <param name="type">当前类型</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检测通过则返回当前类型</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">如果当前类型不是指定的类型或者不是指定类型的派生类型，则抛出参数 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static Type GuardInheritedType<T>(this Type type, Type exceptionType, params object[] args)
	{
		return type.GuardInheritedType(typeof(T), exceptionType, args);
	}

	/// <summary>
	/// 检测当前类型是否是指定的类型或者是指定类型的派生类型，如果不符合则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="targetType">检测的目标类型</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过返回当前类型</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者 <paramref name="targetType" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">如果当前类型不是指定的类型或者不是指定类型的派生类型 <see cref="T:System.ArgumentException" /> 异常</exception>
	public static Type GuardInheritedType(this Type type, Type targetType, string name = null, string message = null)
	{
		type.GuardNotNull("type");
		targetType.GuardNotNull("target type");
		type.Guard(targetType.IsAssignableFrom(type), name.IfNull("item"), message.IfNull(Literals.MSG_TypeNotInheritFromTarget_1.FormatValue(targetType.FullName)));
		return type;
	}

	/// <summary>
	/// 检测当前类型是否是指定的类型或者是指定类型的派生类型，如果不符合则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="targetType">检测的目标类型</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过则返回当前类型</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者 <paramref name="targetType" /> 为空；或者 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">如果当前类型不是指定的类型或者不是指定类型的派生类型，则抛出参数 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static Type GuardInheritedType(this Type type, Type targetType, Func<Exception> exceptionCreator)
	{
		type.GuardNotNull("type");
		targetType.GuardNotNull("target type");
		type.Guard(targetType.IsAssignableFrom(type), exceptionCreator);
		return type;
	}

	/// <summary>
	/// 检测当前类型是否是指定的类型或者是指定类型的派生类型，如果不符合则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="targetType">检测的目标类型</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检测通过返回当前类型</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者 <paramref name="targetType" /> 为空；或者 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">如果当前类型不是指定的类型或者不是指定类型的派生类型，则抛出参数 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static Type GuardInheritedType(this Type type, Type targetType, Type exceptionType, params object[] args)
	{
		type.GuardNotNull("type");
		targetType.GuardNotNull("target type");
		type.Guard(targetType.IsAssignableFrom(type), exceptionType, args);
		return type;
	}

	/// <summary>
	/// 检测当前类型是否实现了指定类型的接口
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="interfaceType">接口类型</param>
	/// <returns>如果当前类型实现了指定类型的接口返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者指定的接口类型 <paramref name="interfaceType" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">指定的类型 <paramref name="interfaceType" /> 不是接口。</exception>
	public static bool HasInterface(this Type type, Type interfaceType)
	{
		type.GuardNotNull("type");
		interfaceType.GuardNotNull("interface type");
		interfaceType.Guard((Type x) => x.IsInterface, "interface type");
		if (interfaceType.IsGenericTypeDefinition)
		{
			return type.GetInterfaces().Any((Type t) => t.IsGenericType && t.GetGenericTypeDefinition().Equals(interfaceType));
		}
		return interfaceType.IsAssignableFrom(type);
	}

	/// <summary>
	/// 检测当前类型是否实现了指定类型的接口
	/// </summary>
	/// <typeparam name="T">接口类型</typeparam>
	/// <param name="type">当前类型</param>
	/// <returns>如果当前类型实现了指定类型的接口返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	public static bool HasInterface<T>(this Type type)
	{
		return type.HasInterface(typeof(T));
	}

	/// <summary>
	/// 调用当前类型中能与给定参数进行绑定的公共实例构造函数
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="args">调用构造函数用的参数数组</param>
	/// <returns>调用成功后返回当前类型的实例</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	/// <exception cref="T:System.MissingMethodException">当前类型中没有可以与指定参数数组进行绑定的构造函数。</exception>
	/// <exception cref="T:System.Reflection.AmbiguousMatchException">存在多于一个可以与指定参数数组进行绑定的构造函数。</exception>
	public static object InvokeConstructor(this Type type, params object[] args)
	{
		return type.InvokeConstructor(null, args, BindingFlags.Instance | BindingFlags.Public);
	}

	/// <summary>
	/// 调用当前类型中能与给定参数进行绑定的公共实例构造函数
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="args">调用构造函数用的参数数组</param>
	/// <param name="optionalBinding">对于构造函数的可选参数是否也必须进行绑定</param>
	/// <returns>调用成功后返回当前类型的实例</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	/// <exception cref="T:System.MissingMethodException">当前类型中没有可以与指定参数数组进行绑定的构造函数。</exception>
	/// <exception cref="T:System.Reflection.AmbiguousMatchException">存在多于一个可以与指定参数数组进行绑定的构造函数。</exception>
	public static object InvokeConstructor(this Type type, object[] args, bool optionalBinding)
	{
		return type.InvokeConstructor(null, args, BindingFlags.Instance | BindingFlags.Public, optionalBinding);
	}

	/// <summary>
	/// 调用当前类型中能与给定参数进行绑定的构造函数
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="args">调用构造函数用的参数数组</param>
	/// <param name="flags">当前类型构造函数的搜索方式，默认为搜索公共实例构造函数</param>
	/// <param name="optionalBinding">对于构造函数的可选参数是否也必须进行绑定，默认为不对可选参数进行绑定</param>
	/// <returns>调用成功后返回当前类型的实例</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	/// <exception cref="T:System.MissingMethodException">当前类型中没有可以与指定参数数组进行绑定的构造函数。</exception>
	/// <exception cref="T:System.Reflection.AmbiguousMatchException">存在多于一个可以与指定参数数组进行绑定的构造函数。</exception>
	public static object InvokeConstructor(this Type type, object[] args, BindingFlags flags, bool optionalBinding = false)
	{
		return type.InvokeConstructor(null, args, flags, optionalBinding);
	}

	/// <summary>
	/// 调用当前类型中能与给定参数进行绑定的构造函数
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="args">调用构造函数用的参数数组</param>
	/// <param name="level">获取的构造函数的访问级别</param>
	/// <param name="optionalBinding">对于构造函数的可选参数是否也必须进行绑定，默认为不对可选参数进行绑定</param>
	/// <returns>调用成功后返回当前类型的实例</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	/// <exception cref="T:System.MissingMethodException">当前类型中没有可以与指定参数数组进行绑定的构造函数。</exception>
	/// <exception cref="T:System.Reflection.AmbiguousMatchException">存在多于一个可以与指定参数数组进行绑定的构造函数。</exception>
	public static object InvokeConstructor(this Type type, object[] args, AccessLevels level, bool optionalBinding = false)
	{
		return type.InvokeConstructor(null, args, level, optionalBinding);
	}

	/// <summary>
	/// 调用当前类型中能与给定命名参数进行绑定的公共实例构造函数
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="namedArgs">命名参数数组</param>
	/// <returns>调用成功后返回当前类型的实例</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	/// <exception cref="T:System.MissingMethodException">当前类型中没有可以与指定参数数组进行绑定的构造函数。</exception>
	/// <exception cref="T:System.Reflection.AmbiguousMatchException">存在多于一个可以与指定参数数组进行绑定的构造函数。</exception>
	public static object InvokeConstructor(this Type type, params NamedValue[] namedArgs)
	{
		return type.InvokeConstructor(namedArgs, BindingFlags.Instance | BindingFlags.Public);
	}

	/// <summary>
	/// 调用当前类型中能与给定命名参数进行绑定的公共实例构造函数
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="namedArgs">命名参数数组</param>
	/// <param name="optionalBinding">对于构造函数的可选参数是否也必须进行绑定，默认为不对可选参数进行绑定</param>
	/// <returns>调用成功后返回当前类型的实例</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	/// <exception cref="T:System.MissingMethodException">当前类型中没有可以与指定参数数组进行绑定的构造函数。</exception>
	/// <exception cref="T:System.Reflection.AmbiguousMatchException">存在多于一个可以与指定参数数组进行绑定的构造函数。</exception>
	public static object InvokeConstructor(this Type type, NamedValue[] namedArgs, bool optionalBinding)
	{
		return type.InvokeConstructor(namedArgs, BindingFlags.Instance | BindingFlags.Public, optionalBinding);
	}

	/// <summary>
	/// 调用当前类型中能与给定命名参数进行绑定的构造函数
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="namedArgs">命名参数数组</param>
	/// <param name="flags">当前类型构造函数的搜索方式，默认为搜索公共实例构造函数</param>
	/// <param name="optionalBinding">对于构造函数的可选参数是否也必须进行绑定，默认为不对可选参数进行绑定</param>
	/// <returns>调用成功后返回当前类型的实例</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	/// <exception cref="T:System.MissingMethodException">当前类型中没有可以与指定参数数组进行绑定的构造函数。</exception>
	/// <exception cref="T:System.Reflection.AmbiguousMatchException">存在多于一个可以与指定参数数组进行绑定的构造函数。</exception>
	public static object InvokeConstructor(this Type type, NamedValue[] namedArgs, BindingFlags flags, bool optionalBinding = false)
	{
		if (namedArgs.IsNull())
		{
			return type.InvokeConstructor(null, null, flags, optionalBinding);
		}
		return type.InvokeConstructor(namedArgs.Select((NamedValue n) => n.Name).ToArray(), namedArgs.Select((NamedValue n) => n.Value).ToArray(), flags, optionalBinding);
	}

	/// <summary>
	/// 调用当前类型中能与给定命名参数进行绑定的构造函数
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="namedArgs">命名参数数组</param>
	/// <param name="level">获取的构造函数的访问级别</param>
	/// <param name="optionalBinding">对于构造函数的可选参数是否也必须进行绑定，默认为不对可选参数进行绑定</param>
	/// <returns>调用成功后返回当前类型的实例</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	/// <exception cref="T:System.MissingMethodException">当前类型中没有可以与指定参数数组进行绑定的构造函数。</exception>
	/// <exception cref="T:System.Reflection.AmbiguousMatchException">存在多于一个可以与指定参数数组进行绑定的构造函数。</exception>
	public static object InvokeConstructor(this Type type, NamedValue[] namedArgs, AccessLevels level, bool optionalBinding = false)
	{
		if (namedArgs.IsNull())
		{
			return type.InvokeConstructor(null, null, level, optionalBinding);
		}
		return type.InvokeConstructor(namedArgs.Select((NamedValue n) => n.Name).ToArray(), namedArgs.Select((NamedValue n) => n.Value).ToArray(), level, optionalBinding);
	}

	/// <summary>
	/// 调用当前类型中能与给定命名参数进行绑定的公共实例构造函数
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="namedArgs">调用构造函数用的参数字典</param>
	/// <param name="optionalBinding">对于构造函数的可选参数是否也必须进行绑定，默认为不对可选参数进行绑定</param>
	/// <returns>调用成功后返回当前类型的实例</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	/// <exception cref="T:System.MissingMethodException">当前类型中没有可以与指定参数数组进行绑定的构造函数。</exception>
	/// <exception cref="T:System.Reflection.AmbiguousMatchException">存在多于一个可以与指定参数数组进行绑定的构造函数。</exception>
	public static object InvokeConstructor(this Type type, IDictionary<string, object> namedArgs, bool optionalBinding = false)
	{
		return type.InvokeConstructor(namedArgs, BindingFlags.Instance | BindingFlags.Public, optionalBinding);
	}

	/// <summary>
	/// 调用当前类型中能与给定命名参数进行绑定的构造函数
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="namedArgs">调用构造函数用的参数字典</param>
	/// <param name="flags">当前类型构造函数的搜索方式，默认为搜索公共实例构造函数</param>
	/// <param name="optionalBinding">对于构造函数的可选参数是否也必须进行绑定，默认为不对可选参数进行绑定</param>
	/// <returns>调用成功后返回当前类型的实例</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	/// <exception cref="T:System.MissingMethodException">当前类型中没有可以与指定参数数组进行绑定的构造函数。</exception>
	/// <exception cref="T:System.Reflection.AmbiguousMatchException">存在多于一个可以与指定参数数组进行绑定的构造函数。</exception>
	public static object InvokeConstructor(this Type type, IDictionary<string, object> namedArgs, BindingFlags flags, bool optionalBinding = false)
	{
		if (namedArgs.IsNull())
		{
			return type.InvokeConstructor(null, null, flags, optionalBinding);
		}
		Tuple<string[], object[]> pairs = namedArgs.GetKeyValues();
		return type.InvokeConstructor(pairs.Item1, pairs.Item2, flags, optionalBinding);
	}

	/// <summary>
	/// 调用当前类型中能与给定命名参数进行绑定的构造函数
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="namedArgs">调用构造函数用的参数字典</param>
	/// <param name="level">获取的构造函数的访问级别</param>
	/// <param name="optionalBinding">对于构造函数的可选参数是否也必须进行绑定，默认为不对可选参数进行绑定</param>
	/// <returns>调用成功后返回当前类型的实例</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	/// <exception cref="T:System.MissingMethodException">当前类型中没有可以与指定参数数组进行绑定的构造函数。</exception>
	/// <exception cref="T:System.Reflection.AmbiguousMatchException">存在多于一个可以与指定参数数组进行绑定的构造函数。</exception>
	public static object InvokeConstructor(this Type type, IDictionary<string, object> namedArgs, AccessLevels level, bool optionalBinding = false)
	{
		if (namedArgs.IsNull())
		{
			return type.InvokeConstructor(null, null, level, optionalBinding);
		}
		Tuple<string[], object[]> pairs = namedArgs.GetKeyValues();
		return type.InvokeConstructor(pairs.Item1, pairs.Item2, level, optionalBinding);
	}

	/// <summary>
	/// 调用当前类型中能与给定命名参数进行绑定的公共实例构造函数
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="names">调用构造函数用的参数名称数组</param>
	/// <param name="values">调用构造函数用的参数值数组</param>
	/// <param name="optionalBinding">对于构造函数的可选参数是否也必须进行绑定，默认为不对可选参数进行绑定</param>
	/// <returns>调用成功后返回当前类型的实例</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者参数名称数组不为空，而参数值数组为空。</exception>
	/// <exception cref="T:System.MissingMethodException">当前类型中没有可以与指定参数数组进行绑定的构造函数。</exception>
	/// <exception cref="T:System.Reflection.AmbiguousMatchException">存在多于一个可以与指定参数数组进行绑定的构造函数。</exception>
	public static object InvokeConstructor(this Type type, string[] names, object[] values, bool optionalBinding = false)
	{
		return type.InvokeConstructor(names, values, BindingFlags.Instance | BindingFlags.Public, optionalBinding);
	}

	/// <summary>
	/// 调用当前类型中能与给定命名参数进行绑定的构造函数
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="names">调用构造函数用的参数名称数组</param>
	/// <param name="values">调用构造函数用的参数值数组</param>
	/// <param name="flags">当前类型构造函数的搜索方式，默认为搜索公共实例构造函数</param>
	/// <param name="optionalBinding">对于构造函数的可选参数是否也必须进行绑定，默认为不对可选参数进行绑定</param>
	/// <returns>调用成功后返回当前类型的实例</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者参数名称数组不为空，而参数值数组为空。</exception>
	/// <exception cref="T:System.MissingMethodException">当前类型中没有可以与指定参数数组进行绑定的构造函数。</exception>
	/// <exception cref="T:System.Reflection.AmbiguousMatchException">存在多于一个可以与指定参数数组进行绑定的构造函数。</exception>
	public static object InvokeConstructor(this Type type, string[] names, object[] values, BindingFlags flags, bool optionalBinding = false)
	{
		type.GuardNotNull("type");
		if (names.IsNotNull())
		{
			values.GuardNotNull("values");
		}
		object state;
		MethodBase mb = Type.DefaultBinder.BindToMethod(optionalBinding ? BindingFlags.OptionalParamBinding : BindingFlags.Default, type.GetConstructors(flags), ref values, null, null, names, out state);
		object result = mb.Invoke(null, values);
		Type.DefaultBinder.ReorderArgumentArray(ref values, state);
		return result;
	}

	/// <summary>
	/// 调用当前类型中能与给定命名参数进行绑定的构造函数
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="names">调用构造函数用的参数名称数组</param>
	/// <param name="values">调用构造函数用的参数值数组</param>
	/// <param name="level">获取的构造函数的访问级别</param>
	/// <param name="optionalBinding">对于构造函数的可选参数是否也必须进行绑定，默认为不对可选参数进行绑定</param>
	/// <returns>调用成功后返回当前类型的实例</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者参数名称数组不为空，而参数值数组为空。</exception>
	/// <exception cref="T:System.MissingMethodException">当前类型中没有可以与指定参数数组进行绑定的构造函数。</exception>
	/// <exception cref="T:System.Reflection.AmbiguousMatchException">存在多于一个可以与指定参数数组进行绑定的构造函数。</exception>
	public static object InvokeConstructor(this Type type, string[] names, object[] values, AccessLevels level, bool optionalBinding = false)
	{
		type.GuardNotNull("type");
		if (names.IsNotNull())
		{
			values.GuardNotNull("values");
		}
		ConstructorInfo[] cinfos = type.GetConstructors(level);
		object state;
		MethodBase mb = Type.DefaultBinder.BindToMethod(optionalBinding ? BindingFlags.OptionalParamBinding : BindingFlags.Default, cinfos, ref values, null, null, names, out state);
		object result = mb.Invoke(null, values);
		Type.DefaultBinder.ReorderArgumentArray(ref values, state);
		return result;
	}

	/// <summary>
	/// 调用当前类型中能与给定参数进行绑定的公共实例方法
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="methodName">调用的方法名称，区分大小写</param>
	/// <param name="obj">调用方法用的对象</param>
	/// <param name="args">调用方法用的参数数组</param>
	/// <returns>调用方法的返回值；如果被调用方法无返回值则返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者方法名称 <paramref name="methodName" /> 为空或者空串。</exception>
	/// <exception cref="T:System.MissingMethodException">当前类型中没有可以与指定参数数组进行绑定的公共实例方法。</exception>
	/// <exception cref="T:System.Reflection.AmbiguousMatchException">存在多于一个可以与指定参数数组进行绑定的公共实例方法。</exception>
	public static object InvokeMethod(this Type type, string methodName, object obj, params object[] args)
	{
		return type.InvokeMethod(methodName, obj, null, args, BindingFlags.Instance | BindingFlags.Public);
	}

	/// <summary>
	/// 调用当前类型中能与给定参数进行绑定的方法
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="methodName">调用的方法名称</param>
	/// <param name="obj">调用方法用的对象</param>
	/// <param name="args">调用方法用的参数数组</param>
	/// <param name="ignoreCase">调用的方法名称是否区分大小写</param>
	/// <param name="optionalBinding">对于方法的可选参数是否也必须进行绑定，默认为不对可选参数进行绑定</param>
	/// <returns>调用方法的返回值；如果被调用方法无返回值则返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者方法名称 <paramref name="methodName" /> 为空或者空串。</exception>
	/// <exception cref="T:System.MissingMethodException">当前类型中没有可以与指定参数数组进行绑定的方法。</exception>
	/// <exception cref="T:System.Reflection.AmbiguousMatchException">存在多于一个可以与指定参数数组进行绑定的方法。</exception>
	public static object InvokeMethod(this Type type, string methodName, object obj, object[] args, bool ignoreCase = false, bool optionalBinding = false)
	{
		return type.InvokeMethod(methodName, obj, null, args, BindingFlags.Instance | BindingFlags.Public, ignoreCase, optionalBinding);
	}

	/// <summary>
	/// 调用当前类型中能与给定参数进行绑定的方法
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="methodName">调用的方法名称</param>
	/// <param name="obj">调用方法用的对象</param>
	/// <param name="args">调用方法用的参数数组</param>
	/// <param name="flags">方法的搜索方式</param>
	/// <param name="ignoreCase">调用的方法名称是否区分大小写</param>
	/// <param name="optionalBinding">对于方法的可选参数是否也必须进行绑定，默认为不对可选参数进行绑定</param>
	/// <returns>调用方法的返回值；如果被调用方法无返回值则返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者方法名称 <paramref name="methodName" /> 为空或者空串；或者调用方法用的对象 <paramref name="obj" /> 为空。</exception>
	/// <exception cref="T:System.MissingMethodException">当前类型中没有可以与指定参数数组进行绑定的方法。</exception>
	/// <exception cref="T:System.Reflection.AmbiguousMatchException">存在多于一个可以与指定参数数组进行绑定的方法。</exception>
	public static object InvokeMethod(this Type type, string methodName, object obj, object[] args, BindingFlags flags, bool ignoreCase = false, bool optionalBinding = false)
	{
		return type.InvokeMethod(methodName, obj, null, args, flags, ignoreCase, optionalBinding);
	}

	/// <summary>
	/// 调用当前类型中能与给定参数进行绑定的方法
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="methodName">调用的方法名称</param>
	/// <param name="obj">调用方法用的对象</param>
	/// <param name="args">调用方法用的参数数组</param>
	/// <param name="level">获取的方法的访问级别</param>
	/// <param name="ignoreCase">调用的方法名称是否区分大小写</param>
	/// <param name="optionalBinding">对于方法的可选参数是否也必须进行绑定，默认为不对可选参数进行绑定</param>
	/// <returns>调用方法的返回值；如果被调用方法无返回值则返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者方法名称 <paramref name="methodName" /> 为空或者空串。</exception>
	/// <exception cref="T:System.MissingMethodException">当前类型中没有可以与指定参数数组进行绑定的方法。</exception>
	/// <exception cref="T:System.Reflection.AmbiguousMatchException">存在多于一个可以与指定参数数组进行绑定的方法。</exception>
	public static object InvokeMethod(this Type type, string methodName, object obj, object[] args, AccessLevels level, bool ignoreCase = false, bool optionalBinding = false)
	{
		return type.InvokeMethod(methodName, obj, null, args, level, ignoreCase, optionalBinding);
	}

	/// <summary>
	/// 调用当前类型中能与给定命名参数进行绑定的公共实例方法
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="methodName">调用的方法名称</param>
	/// <param name="obj">调用方法用的对象</param>
	/// <param name="namedArgs">命名参数数组</param>
	/// <param name="ignoreCase">调用的方法名称是否区分大小写</param>
	/// <param name="optionalBinding">对于方法的可选参数是否也必须进行绑定，默认为不对可选参数进行绑定</param>
	/// <returns>调用方法的返回值；如果被调用方法无返回值则返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者方法名称 <paramref name="methodName" /> 为空或者空串。</exception>
	/// <exception cref="T:System.MissingMethodException">当前类型中没有可以与指定参数数组进行绑定的方法。</exception>
	/// <exception cref="T:System.Reflection.AmbiguousMatchException">存在多于一个可以与指定参数数组进行绑定的方法。</exception>
	public static object InvokeMethod(this Type type, string methodName, object obj, NamedValue[] namedArgs, bool ignoreCase = false, bool optionalBinding = false)
	{
		return type.InvokeMethod(methodName, obj, namedArgs, BindingFlags.Instance | BindingFlags.Public, ignoreCase, optionalBinding);
	}

	/// <summary>
	/// 调用当前类型中能与给定命名参数进行绑定的方法
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="methodName">调用的方法名称</param>
	/// <param name="obj">调用方法用的对象</param>
	/// <param name="namedArgs">命名参数数组</param>
	/// <param name="flags">方法的搜索方式</param>
	/// <param name="ignoreCase">调用的方法名称是否区分大小写</param>
	/// <param name="optionalBinding">对于方法的可选参数是否也必须进行绑定，默认为不对可选参数进行绑定</param>
	/// <returns>调用方法的返回值；如果被调用方法无返回值则返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者方法名称 <paramref name="methodName" /> 为空或者空串。</exception>
	/// <exception cref="T:System.MissingMethodException">当前类型中没有可以与指定参数数组进行绑定的方法。</exception>
	/// <exception cref="T:System.Reflection.AmbiguousMatchException">存在多于一个可以与指定参数数组进行绑定的方法。</exception>
	public static object InvokeMethod(this Type type, string methodName, object obj, NamedValue[] namedArgs, BindingFlags flags, bool ignoreCase = false, bool optionalBinding = false)
	{
		type.GuardNotNull("type");
		methodName.GuardNotNullAndEmpty("method name");
		if (namedArgs.IsNull())
		{
			return type.InvokeMethod(methodName, obj, null, null, flags, ignoreCase, optionalBinding);
		}
		return type.InvokeMethod(methodName, obj, namedArgs.Select((NamedValue n) => n.Name).ToArray(), namedArgs.Select((NamedValue n) => n.Value).ToArray(), flags, ignoreCase, optionalBinding);
	}

	/// <summary>
	/// 调用当前类型中能与给定命名参数进行绑定的方法
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="methodName">调用的方法名称</param>
	/// <param name="obj">调用方法用的对象</param>
	/// <param name="namedArgs">命名参数数组</param>
	/// <param name="level">获取的方法的访问级别</param>
	/// <param name="ignoreCase">调用的方法名称是否区分大小写</param>
	/// <param name="optionalBinding">对于方法的可选参数是否也必须进行绑定，默认为不对可选参数进行绑定</param>
	/// <returns>调用方法的返回值；如果被调用方法无返回值则返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者方法名称 <paramref name="methodName" /> 为空或者空串。</exception>
	/// <exception cref="T:System.MissingMethodException">当前类型中没有可以与指定参数数组进行绑定的方法。</exception>
	/// <exception cref="T:System.Reflection.AmbiguousMatchException">存在多于一个可以与指定参数数组进行绑定的方法。</exception>
	public static object InvokeMethod(this Type type, string methodName, object obj, NamedValue[] namedArgs, AccessLevels level, bool ignoreCase = false, bool optionalBinding = false)
	{
		type.GuardNotNull("type");
		methodName.GuardNotNullAndEmpty("method name");
		if (namedArgs.IsNull())
		{
			return type.InvokeMethod(methodName, obj, null, null, level, ignoreCase, optionalBinding);
		}
		return type.InvokeMethod(methodName, obj, namedArgs.Select((NamedValue n) => n.Name).ToArray(), namedArgs.Select((NamedValue n) => n.Value).ToArray(), level, ignoreCase, optionalBinding);
	}

	/// <summary>
	/// 调用当前类型中能与给定命名参数进行绑定的公共实例方法
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="methodName">调用的方法名称</param>
	/// <param name="obj">调用方法用的对象</param>
	/// <param name="namedArgs">调用方法用的参数字典</param>
	/// <param name="ignoreCase">调用的方法名称是否区分大小写</param>
	/// <param name="optionalBinding">对于方法的可选参数是否也必须进行绑定，默认为不对可选参数进行绑定</param>
	/// <returns>调用方法的返回值；如果被调用方法无返回值则返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者方法名称 <paramref name="methodName" /> 为空或者空串。</exception>
	/// <exception cref="T:System.MissingMethodException">当前类型中没有可以与指定参数数组进行绑定的方法。</exception>
	/// <exception cref="T:System.Reflection.AmbiguousMatchException">存在多于一个可以与指定参数数组进行绑定的方法。</exception>
	public static object InvokeMethod(this Type type, string methodName, object obj, IDictionary<string, object> namedArgs, bool ignoreCase = false, bool optionalBinding = false)
	{
		type.GuardNotNull("type");
		methodName.GuardNotNullAndEmpty("method name");
		if (namedArgs.IsNull())
		{
			return type.InvokeMethod(methodName, obj, null, null, BindingFlags.Instance | BindingFlags.Public, ignoreCase, optionalBinding);
		}
		Tuple<string[], object[]> pairs = namedArgs.GetKeyValues();
		return type.InvokeMethod(methodName, obj, pairs.Item1, pairs.Item2, BindingFlags.Instance | BindingFlags.Public, ignoreCase, optionalBinding);
	}

	/// <summary>
	/// 调用当前类型中能与给定命名参数进行绑定的方法
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="methodName">调用的方法名称</param>
	/// <param name="obj">调用方法用的对象</param>
	/// <param name="namedArgs">调用方法用的参数字典</param>
	/// <param name="flags">方法的搜索方式</param>
	/// <param name="ignoreCase">调用的方法名称是否区分大小写</param>
	/// <param name="optionalBinding">对于方法的可选参数是否也必须进行绑定，默认为不对可选参数进行绑定</param>
	/// <returns>调用方法的返回值；如果被调用方法无返回值则返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者方法名称 <paramref name="methodName" /> 为空或者空串。</exception>
	/// <exception cref="T:System.MissingMethodException">当前类型中没有可以与指定参数数组进行绑定的方法。</exception>
	/// <exception cref="T:System.Reflection.AmbiguousMatchException">存在多于一个可以与指定参数数组进行绑定的方法。</exception>
	public static object InvokeMethod(this Type type, string methodName, object obj, IDictionary<string, object> namedArgs, BindingFlags flags, bool ignoreCase = false, bool optionalBinding = false)
	{
		type.GuardNotNull("type");
		methodName.GuardNotNullAndEmpty("method name");
		if (namedArgs.IsNull())
		{
			return type.InvokeMethod(methodName, obj, null, null, flags, ignoreCase, optionalBinding);
		}
		Tuple<string[], object[]> pairs = namedArgs.GetKeyValues();
		return type.InvokeMethod(methodName, obj, pairs.Item1, pairs.Item2, flags, ignoreCase, optionalBinding);
	}

	/// <summary>
	/// 调用当前类型中能与给定命名参数进行绑定的方法
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="methodName">调用的方法名称</param>
	/// <param name="obj">调用方法用的对象</param>
	/// <param name="namedArgs">调用方法用的参数字典</param>
	/// <param name="level">获取的方法的访问级别</param>
	/// <param name="ignoreCase">调用的方法名称是否区分大小写</param>
	/// <param name="optionalBinding">对于方法的可选参数是否也必须进行绑定，默认为不对可选参数进行绑定</param>
	/// <returns>调用方法的返回值；如果被调用方法无返回值则返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者方法名称 <paramref name="methodName" /> 为空或者空串。</exception>
	/// <exception cref="T:System.MissingMethodException">当前类型中没有可以与指定参数数组进行绑定的方法。</exception>
	/// <exception cref="T:System.Reflection.AmbiguousMatchException">存在多于一个可以与指定参数数组进行绑定的方法。</exception>
	public static object InvokeMethod(this Type type, string methodName, object obj, IDictionary<string, object> namedArgs, AccessLevels level, bool ignoreCase = false, bool optionalBinding = false)
	{
		type.GuardNotNull("type");
		methodName.GuardNotNullAndEmpty("method name");
		if (namedArgs.IsNull())
		{
			return type.InvokeMethod(methodName, obj, null, null, level, ignoreCase, optionalBinding);
		}
		Tuple<string[], object[]> pairs = namedArgs.GetKeyValues();
		return type.InvokeMethod(methodName, obj, pairs.Item1, pairs.Item2, level, ignoreCase, optionalBinding);
	}

	/// <summary>
	/// 调用当前类型中能与给定命名参数进行绑定的公共实例方法
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="methodName">调用的方法名称</param>
	/// <param name="obj">调用方法用的对象</param>
	/// <param name="names">调用方法用的参数名称数组</param>
	/// <param name="values">调用方法用的参数值数组</param>
	/// <param name="ignoreCase">调用的方法名称是否区分大小写</param>
	/// <param name="optionalBinding">对于方法的可选参数是否也必须进行绑定，默认为不对可选参数进行绑定</param>
	/// <returns>调用方法的返回值；如果被调用方法无返回值则返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者方法名称 <paramref name="methodName" /> 为空或者空串；或者参数名称数组不为空，而参数值数组为空。</exception>
	/// <exception cref="T:System.MissingMethodException">当前类型中没有可以与指定参数数组进行绑定的方法。</exception>
	/// <exception cref="T:System.Reflection.AmbiguousMatchException">存在多于一个可以与指定参数数组进行绑定的方法。</exception>
	public static object InvokeMethod(this Type type, string methodName, object obj, string[] names, object[] values, bool ignoreCase = false, bool optionalBinding = false)
	{
		return type.InvokeMethod(methodName, obj, names, values, BindingFlags.Instance | BindingFlags.Public, ignoreCase, optionalBinding);
	}

	/// <summary>
	/// 调用当前类型中能与给定命名参数进行绑定的方法
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="methodName">调用的方法名称</param>
	/// <param name="obj">调用方法用的对象</param>
	/// <param name="names">调用方法用的参数名称数组</param>
	/// <param name="values">调用方法用的参数值数组</param>
	/// <param name="flags">方法的搜索方式</param>
	/// <param name="ignoreCase">调用的方法名称是否区分大小写</param>
	/// <param name="optionalBinding">对于方法的可选参数是否也必须进行绑定，默认为不对可选参数进行绑定</param>
	/// <returns>调用方法的返回值；如果被调用方法无返回值则返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者方法名称 <paramref name="methodName" /> 为空或者空串；或者参数名称数组不为空，而参数值数组为空。</exception>
	/// <exception cref="T:System.MissingMethodException">当前类型中没有可以与指定参数数组进行绑定的方法。</exception>
	/// <exception cref="T:System.Reflection.AmbiguousMatchException">存在多于一个可以与指定参数数组进行绑定的方法。</exception>
	public static object InvokeMethod(this Type type, string methodName, object obj, string[] names, object[] values, BindingFlags flags, bool ignoreCase = false, bool optionalBinding = false)
	{
		type.GuardNotNull("type");
		methodName.GuardNotNullAndEmpty("method name");
		if (names.IsNotNull())
		{
			values.GuardNotNull("values");
		}
		object state;
		MethodBase mb = Type.DefaultBinder.BindToMethod(optionalBinding ? BindingFlags.OptionalParamBinding : BindingFlags.Default, type.GetMethods(methodName, flags, ignoreCase), ref values, null, null, names, out state);
		object result = mb.Invoke(obj, values);
		Type.DefaultBinder.ReorderArgumentArray(ref values, state);
		return result;
	}

	/// <summary>
	/// 调用当前类型中能与给定命名参数进行绑定的方法
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="methodName">调用的方法名称</param>
	/// <param name="obj">调用方法用的对象</param>
	/// <param name="names">调用方法用的参数名称数组</param>
	/// <param name="values">调用方法用的参数值数组</param>
	/// <param name="level">获取的构造函数的访问级别</param>
	/// <param name="ignoreCase">调用的方法名称是否区分大小写</param>
	/// <param name="optionalBinding">对于方法的可选参数是否也必须进行绑定，默认为不对可选参数进行绑定</param>
	/// <returns>调用方法的返回值；如果被调用方法无返回值则返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者方法名称 <paramref name="methodName" /> 为空或者空串；或者参数名称数组不为空，而参数值数组为空。</exception>
	/// <exception cref="T:System.MissingMethodException">当前类型中没有可以与指定参数数组进行绑定的方法。</exception>
	/// <exception cref="T:System.Reflection.AmbiguousMatchException">存在多于一个可以与指定参数数组进行绑定的方法。</exception>
	public static object InvokeMethod(this Type type, string methodName, object obj, string[] names, object[] values, AccessLevels level, bool ignoreCase = false, bool optionalBinding = false)
	{
		type.GuardNotNull("type");
		methodName.GuardNotNullAndEmpty("method name");
		if (names.IsNotNull())
		{
			values.GuardNotNull("values");
		}
		MethodInfo[] minfos = type.GetMethods(methodName, level, ignoreCase);
		object state;
		MethodBase mb = Type.DefaultBinder.BindToMethod(optionalBinding ? BindingFlags.OptionalParamBinding : BindingFlags.Default, minfos, ref values, null, null, names, out state);
		object result = mb.Invoke(obj, values);
		Type.DefaultBinder.ReorderArgumentArray(ref values, state);
		return result;
	}

	/// <summary>
	/// 检测当前类型是否是可转换类型，支持使用 <see cref="M:System.Convert.ChangeType(System.Object,System.Type)" /> 方法进行转换
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <returns>如果支持转换返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	public static bool IsConvertible(this Type type)
	{
		type.GuardNotNull("type");
		return typeof(IConvertible).IsAssignableFrom(type);
	}

	/// <summary>
	/// 检测当前类型是否是可以表示小数的类型
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <returns>如果当前类型可以表示小数返回true，否则返回false。</returns>
	public static bool IsDecimal(this Type type)
	{
		type.GuardNotNull("type");
		return type.Equals(typeof(decimal)) || type.Equals(typeof(double)) || type.Equals(typeof(float));
	}

	/// <summary>
	/// 检测当前类型是否是可枚举类型，实现了 <see cref="T:System.Collections.IEnumerable" /> 接口
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <returns>如果当前类型是可枚举类型返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	public static bool IsEnumerable(this Type type)
	{
		type.GuardNotNull("type");
		return typeof(IEnumerable).IsAssignableFrom(type);
	}

	/// <summary>
	/// 检测当前类型是否是强类型可枚举类型，实现了 <see cref="T:System.Collections.Generic.IEnumerable`1" /> 接口
	/// </summary>
	/// <typeparam name="T">枚举元素类型</typeparam>
	/// <param name="type">当前类型</param>
	/// <returns>如果当前类型是可枚举类型返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	public static bool IsEnumerable<T>(this Type type)
	{
		type.GuardNotNull("type");
		return type.GetInterface(typeof(IEnumerable<T>)).IsNotNull();
	}

	/// <summary>
	/// 当前类型是否是可以实例化为对象
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="paramTypes">当前类型的构造函数参数类型</param>
	/// <returns>如果当前类型可以获取初始化的实例返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	/// <remarks>如果当前类型不是接口、不是抽象类型、是封闭类型、具有与给定参数类型匹配的构造函数，则认为可实例化。</remarks>
	public static bool IsInstance(this Type type, params Type[] paramTypes)
	{
		type.GuardNotNull("type");
		return !type.ContainsGenericParameters && !type.IsInterface && !type.IsAbstract && type.GetConstructor(paramTypes.IfNull(Type.EmptyTypes)).IsNotNull();
	}

	/// <summary>
	/// 检查当前类型是否是整数类型
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <returns>如果当前类型是整数类型则返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	public static bool IsInteger(this Type type)
	{
		type.GuardNotNull("type");
		return type == typeof(byte) || type == typeof(sbyte) || type == typeof(short) || type == typeof(int) || type == typeof(long) || type == typeof(ushort) || type == typeof(uint) || type == typeof(ulong);
	}

	/// <summary>
	/// 检测当前类型是否是可空类型，包括引用类型（类、接口）和可空值类型
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <returns>如果指定的类型是目标的可空类型返回true,否则返回false</returns>
	public static bool IsNullable(this Type type)
	{
		type.GuardNotNull("type");
		return type.IsClass || type.IsInterface || type.IsNullableValueType();
	}

	/// <summary>
	/// 检测当前类型是否是可空的值类型
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <returns>如果当前类型是可空的值类型返回true,否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	public static bool IsNullableValueType(this Type type)
	{
		type.GuardNotNull("type");
		return type.IsGenericType && type.GetGenericTypeDefinition().Equals(typeof(Nullable<>));
	}

	/// <summary>
	/// 检测当前类型是否是可空的值类型
	/// </summary>
	/// <typeparam name="T">可空值类型的泛型参数类型</typeparam>
	/// <param name="type">当前类型</param>
	/// <returns>如果当前类型是可空的值类型返回true,否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	public static bool IsNullableValueType<T>(this Type type)
	{
		type.GuardNotNull("type");
		return type.IsGenericType && type.GetGenericTypeDefinition().Equals(typeof(Nullable<>)) && type.GetGenericArguments()[0].Equals(typeof(T));
	}

	/// <summary>
	/// 检测当前类型是否是可空的值类型
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="argType">可空值类型的泛型参数类型</param>
	/// <returns>如果当前类型是可空的值类型返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	public static bool IsNullableValueType(this Type type, Type argType)
	{
		type.GuardNotNull("type");
		argType.GuardNotNull("argType");
		return type.IsGenericType && type.GetGenericTypeDefinition().Equals(typeof(Nullable<>)) && type.GetGenericArguments()[0].Equals(argType);
	}

	/// <summary>
	/// 检查当前类型是否是数值类型
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <returns>如果当前类型是数值类型返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	public static bool IsNumeric(this Type type)
	{
		type.GuardNotNull("type");
		return type.IsInteger() || type.IsDecimal();
	}

	/// <summary>
	/// 检测当前类型是否是引用类型
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <returns>如果当前类型是引用类型</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	public static bool IsReference(this Type type)
	{
		type.GuardNotNull("type");
		return type.IsClass || type.IsInterface;
	}

	/// <summary>
	/// 检测当前类型与指定类型是否兼容（当前类型是否可以默认转换为目标类型）
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="targetType">目标类型</param>
	/// <returns>如果当前类型与目标类型兼容返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者目标类型 <paramref name="targetType" /> 为空。</exception>
	public static bool IsType(this Type type, Type targetType)
	{
		type.GuardNotNull("type");
		targetType.GuardNotNull("target");
		if (targetType.IsAssignableFrom(type))
		{
			return true;
		}
		if (targetType.IsPrimitive)
		{
			return Type.DefaultBinder.CanConvertPrimitive(type, targetType);
		}
		if (targetType.IsInterface && targetType.IsGenericType)
		{
			return type.GetInterfaces().Any((Type t) => CheckGenericTypeCompatibility(t, targetType));
		}
		if (targetType.IsClass && targetType.IsGenericType)
		{
			return type.GetBaseTypes().Prepend(type).Any((Type t) => CheckGenericTypeCompatibility(t, targetType));
		}
		return false;
	}

	/// <summary>
	/// 检测当前类型与指定类型是否兼容（当前类型是否可以默认转换为目标类型）
	/// </summary>
	/// <typeparam name="T">目标类型</typeparam>
	/// <param name="type">当前类型</param>
	/// <returns>如果当前类型与目标类型兼容返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	public static bool IsType<T>(this Type type)
	{
		return type.IsType(typeof(T));
	}

	/// <summary>
	/// 筛选并返回当前类型序列中与给定的类型相同或者继承于给定的类型的类型的序列
	/// </summary>
	/// <param name="types">当前类型序列</param>
	/// <param name="type">筛选的类型</param>
	/// <returns>筛选后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型序列为空；或者筛选类型 <paramref name="type" /> 为空。</exception>
	public static IEnumerable<Type> WhereInheritedType(this IEnumerable<Type> types, Type type)
	{
		types.GuardNotNull("types");
		type.GuardNotNull("type");
		return types.Where((Type t) => type.IsAssignableFrom(t));
	}

	/// <summary>
	/// 筛选并返回当前类型序列中与给定的类型相同或者继承于给定的类型的类型的序列
	/// </summary>
	/// <typeparam name="T">筛选的类型</typeparam>
	/// <param name="types">当前类型序列</param>
	/// <returns>筛选后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型序列为空。</exception>
	public static IEnumerable<Type> WhereInheritedType<T>(this IEnumerable<Type> types)
	{
		return types.WhereInheritedType(typeof(T));
	}

	/// <summary>
	/// 筛选并返回当前类型序列中与给定类型相同的类型的序列
	/// </summary>
	/// <param name="types">当前类型序列</param>
	/// <param name="type">筛选的类型</param>
	/// <returns>筛选后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型序列为空；或者筛选类型 <paramref name="type" /> 为空。</exception>
	public static IEnumerable<Type> WhereType(this IEnumerable<Type> types, Type type)
	{
		types.GuardNotNull("types");
		type.GuardNotNull("type");
		return types.Where((Type t) => type.Equals(t));
	}

	/// <summary>
	/// 筛选并返回当前类型序列中与给定类型相同的类型的序列
	/// </summary>
	/// <typeparam name="T">筛选的类型</typeparam>
	/// <param name="types">当前类型序列</param>
	/// <returns>筛选后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型序列为空。</exception>
	public static IEnumerable<Type> WhereType<T>(this IEnumerable<Type> types)
	{
		return types.WhereType(typeof(T));
	}

	/// <summary>
	/// 检测两个泛型类型是否兼容
	/// </summary>
	/// <param name="type"></param>
	/// <param name="targetType"></param>
	/// <returns></returns>
	private static bool CheckGenericTypeCompatibility(Type type, Type targetType)
	{
		if (type.IsGenericType && targetType.IsGenericTypeDefinition)
		{
			return type.GetGenericTypeDefinition().Equals(targetType);
		}
		if (targetType.IsGenericType && type.IsGenericType && type.GetGenericTypeDefinition().Equals(targetType.GetGenericTypeDefinition()))
		{
			Type[] defArgs = targetType.GetGenericTypeDefinition().GetGenericArguments();
			Type[] interfaceArgs = type.GetGenericArguments();
			Type[] targetArgs = targetType.GetGenericArguments();
			for (int i = 0; i < defArgs.Length; i++)
			{
				if (defArgs[i].GenericParameterAttributes.HasFlag(GenericParameterAttributes.Covariant))
				{
					if (targetArgs[i].IsValueType || interfaceArgs[i].IsValueType || !targetArgs[i].IsAssignableFrom(interfaceArgs[i]))
					{
						return false;
					}
				}
				else if (defArgs[i].GenericParameterAttributes.HasFlag(GenericParameterAttributes.Contravariant))
				{
					if (targetArgs[i].IsValueType || interfaceArgs[i].IsValueType || !interfaceArgs[i].IsAssignableFrom(targetArgs[i]))
					{
						return false;
					}
				}
				else if (!targetArgs[i].Equals(interfaceArgs[i]))
				{
					return false;
				}
			}
			return true;
		}
		return targetType.IsAssignableFrom(type);
	}

	/// <summary>
	/// 获取成员类型对应的枚举
	/// </summary>
	/// <param name="memberType">成员类型</param>
	/// <returns>成员类型对应的枚举</returns>
	private static MemberTypes GetMemberTypeFromType(Type memberType)
	{
		if (typeof(ConstructorInfo).IsAssignableFrom(memberType))
		{
			return MemberTypes.Constructor;
		}
		if (typeof(EventInfo).IsAssignableFrom(memberType))
		{
			return MemberTypes.Event;
		}
		if (typeof(FieldInfo).IsAssignableFrom(memberType))
		{
			return MemberTypes.Field;
		}
		if (typeof(MethodInfo).IsAssignableFrom(memberType))
		{
			return MemberTypes.Method;
		}
		if (typeof(PropertyInfo).IsAssignableFrom(memberType))
		{
			return MemberTypes.Property;
		}
		if (typeof(Type).IsAssignableFrom(memberType))
		{
			return MemberTypes.NestedType;
		}
		return MemberTypes.Custom;
	}
}
