#define DEBUG
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using Richfit.Garnet.Common.Patterns;
using Richfit.Garnet.Common.Properties;
using Richfit.Garnet.Common.Reflection;

namespace Richfit.Garnet.Common.Utility;

/// <summary>
/// <see cref="T:System.Type" /> 类型辅助类
/// </summary>
public static class TypeHelper
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
	public static bool CanConvertPrimitive(Binder binder, Type source, Type target)
	{
		Guard.AssertNotNull(binder, "binder");
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(target, "target");
		if (ObjectHelper.IsNull(handlerForCanConvertPrimitive))
		{
			handlerForCanConvertPrimitive = Type.GetType("System.DefaultBinder").GetMethod("CanConvertPrimitive", BindingFlags.Static | BindingFlags.NonPublic);
			if (ObjectHelper.IsNull(handlerForCanConvertPrimitive))
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
	public static bool CanConvertPrimitiveObjectToType(Binder binder, object source, Type target)
	{
		Guard.AssertNotNull(binder, "binder");
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(target, "target");
		if (ObjectHelper.IsNull(handlerForCanConvertPrimitiveObjectToType))
		{
			handlerForCanConvertPrimitiveObjectToType = Type.GetType("System.DefaultBinder").GetMethod("CanConvertPrimitiveObjectToType", BindingFlags.Static | BindingFlags.NonPublic);
			if (ObjectHelper.IsNull(handlerForCanConvertPrimitiveObjectToType))
			{
				throw new MissingMethodException("System.DefaultBinder", "CanConvertPrimitiveObjectToType");
			}
		}
		return (bool)handlerForCanConvertPrimitiveObjectToType.Invoke(null, new object[2] { source, target.UnderlyingSystemType });
	}

	/// <summary>
	/// 创建元素类型为当前类型的指定长度的一维数组
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="length">一维数组的长度</param>
	/// <returns>创建的一维数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">一维数组长度小于0。</exception>
	public static Array CreateArray(Type type, int length)
	{
		Guard.AssertNotNull(type, "element type");
		Guard.AssertGreaterThanOrEqualTo(length, 0, "array length");
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
	public static Array CreateArray(Type type, params int[] rankLength)
	{
		Guard.AssertNotNull(type, "element type");
		Guard.AssertNotNull(rankLength, "rank length");
		Array.ForEach(rankLength, delegate(int x)
		{
			Guard.AssertGreaterThanOrEqualTo(x, 0, "rank length");
		});
		return Array.CreateInstance(type, rankLength);
	}

	/// <summary>
	/// 创建指定类型的一维数组
	/// </summary>
	/// <typeparam name="T">创建的数组类型</typeparam>
	/// <param name="length">创建数组元素个数</param>
	/// <returns>创建的一维数组</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException">创建的数组元素个数小于0。</exception>
	public static T[] CreateArray<T>(int length)
	{
		Guard.AssertGreaterThanOrEqualTo(length, 0, "length");
		return new T[length];
	}

	/// <summary>
	/// 创建元素类型为当前类型的指定长度的一维数组
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="length">一维数组的长度</param>
	/// <returns>创建的一维数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">一维数组长度小于0。</exception>
	public static Array CreateArray(Type type, long length)
	{
		Guard.AssertNotNull(type, "element type");
		Guard.AssertGreaterThanOrEqualTo(length, 0L, "array length");
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
	public static Array CreateArray(Type type, params long[] rankLength)
	{
		Guard.AssertNotNull(type, "element type");
		Guard.AssertNotNull(rankLength, "rank length");
		Array.ForEach(rankLength, delegate(long x)
		{
			Guard.AssertGreaterThanOrEqualTo(x, 0L, "rank length");
		});
		return Array.CreateInstance(type, rankLength);
	}

	/// <summary>
	/// 创建指定类型的一维数组
	/// </summary>
	/// <typeparam name="T">创建的数组类型</typeparam>
	/// <param name="length">创建数组元素个数</param>
	/// <returns>创建的一维数组</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException">创建的数组元素个数小于0。</exception>
	public static T[] CreateArray<T>(long length)
	{
		Guard.AssertGreaterThanOrEqualTo(length, 0L, "length");
		return new T[length];
	}

	/// <summary>
	/// 创建元素类型为当前类型的指定长度的一维数组
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="length">一维数组的长度</param>
	/// <returns>创建的一维数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">一维数组长度小于0。</exception>
	public static Array CreateLongArray(Type type, long length)
	{
		Guard.AssertNotNull(type, "element type");
		Guard.AssertGreaterThanOrEqualTo(length, 0L, "array length");
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
	public static Array CreateLongArray(Type type, params long[] rankLength)
	{
		Guard.AssertNotNull(type, "element type");
		Guard.AssertNotNull(rankLength, "rank length");
		Array.ForEach(rankLength, delegate(long x)
		{
			Guard.AssertGreaterThanOrEqualTo(x, 0L, "rank length");
		});
		return Array.CreateInstance(type, rankLength);
	}

	/// <summary>
	/// 创建指定类型的一维数组
	/// </summary>
	/// <typeparam name="T">创建的数组类型</typeparam>
	/// <param name="length">创建数组元素个数</param>
	/// <returns>创建的一维数组</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException">创建的数组元素个数小于0。</exception>
	public static T[] CreateLongArray<T>(long length)
	{
		Guard.AssertGreaterThanOrEqualTo(length, 0L, "length");
		return new T[length];
	}

	/// <summary>
	/// 获取当前类型的默认值
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <returns>当前类型的默认值</returns>
	public static object CreateDefault(Type type)
	{
		Guard.AssertNotNull(type, "type");
		if (type.IsValueType)
		{
			return Activator.CreateInstance(type);
		}
		return null;
	}

	/// <summary>
	/// 获取指定类型的默认值
	/// </summary>
	/// <typeparam name="T">获取默认值的类型</typeparam>
	/// <returns>指定类型的默认值</returns>
	public static T CreateDefault<T>()
	{
		return (T)CreateDefault(typeof(T));
	}

	/// <summary>
	/// 获取当前类型的默认值
	/// </summary>
	/// <typeparam name="T">获取默认值的类型</typeparam>
	/// <param name="type">当前类型</param>
	/// <returns>当前类型的默认值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前类型与指定的默认值类型不符。</exception>
	public static T CreateDefault<T>(Type type)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertInheritedType<T>(type);
		return (T)CreateDefault(type);
	}

	/// <summary>
	/// 创建当前类型的默认实例
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <returns>创建的当前类型的实例</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	/// <remarks>
	/// 本方法为以下类型定义了默认实例：
	/// String : 空白字符串
	/// CultureInfo : 固定区域信息
	/// </remarks>
	public static object CreateInstance(Type type)
	{
		Guard.AssertNotNull(type, "type");
		return Activator.CreateInstance(type);
	}

	/// <summary>
	/// 创建当前类型的实例
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="args">调用的构造函数参数数组</param>
	/// <returns>创建的当前类型的实例</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	public static object CreateInstance(Type type, params object[] args)
	{
		Guard.AssertNotNull(type, "type");
		return Activator.CreateInstance(type, args);
	}

	/// <summary>
	/// 创建当前类型的实例
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="args">调用的构造函数参数数组</param>
	/// <param name="flags">构造函数绑定标志</param>
	/// <returns>创建的当前类型的实例</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	public static object CreateInstance(Type type, object[] args, BindingFlags flags)
	{
		Guard.AssertNotNull(type, "type");
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
	public static object CreateInstance(Type type, object[] args, AccessLevels level)
	{
		Guard.AssertNotNull(type, "type");
		ConstructorInfo cinfo = GetConstructor(type, Type.GetTypeArray(args), level);
		if (ObjectHelper.IsNull(cinfo))
		{
			throw new MissingMethodException(Literals.MSG_MissingConstructor);
		}
		return cinfo.Invoke(args);
	}

	/// <summary>
	/// 创建当前类型的实例
	/// </summary>
	/// <typeparam name="T">创建的实例的类型</typeparam>
	/// <returns>创建的当前类型的实例</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前类型与指定的实例类型 <typeparamref name="T" /> 不兼容。</exception>
	public static T CreateInstance<T>()
	{
		return (T)CreateInstance(typeof(T));
	}

	/// <summary>
	/// 创建当前类型的实例
	/// </summary>
	/// <typeparam name="T">创建的实例的类型</typeparam>
	/// <param name="type">当前类型</param>
	/// <returns>创建的当前类型的实例</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前类型与指定的实例类型 <typeparamref name="T" /> 不兼容。</exception>
	public static T CreateInstance<T>(Type type)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertInheritedType<T>(type, "type");
		return (T)CreateInstance(type);
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
	public static T CreateInstance<T>(Type type, params object[] args)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertInheritedType<T>(type, "type");
		return (T)CreateInstance(type, args);
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
	public static T CreateInstance<T>(Type type, object[] args, BindingFlags flags)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertInheritedType<T>(type, "type");
		return (T)CreateInstance(type, args, flags);
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
	public static T CreateInstance<T>(Type type, object[] args, AccessLevels level)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertInheritedType<T>(type, "type");
		return (T)CreateInstance(type, args, level);
	}

	/// <summary>
	/// 创建当前程序集中所有可实例化类型的实例
	/// </summary>
	/// <param name="assembly">当前程序集</param>
	/// <param name="creator">类型实例创建方法</param>
	/// <returns>所有符合条件类型的实例序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前程序集为空。</exception>
	/// <remarks>如果未指定类型实例化方法则默认调用类型的无参数构造函数，如果没有无参数构造函数则忽略该类型。</remarks>
	public static object[] CreateInstance(Assembly assembly, Func<Type, object> creator = null)
	{
		Guard.AssertNotNull(assembly, "assembly");
		creator = ObjectHelper.IfNull(creator, (Type t) => CreateInstance(t));
		return (from t in assembly.GetTypes()
			select creator(t)).ToArray();
	}

	/// <summary>
	/// 创建当前程序集中所有可实例化类型的实例
	/// </summary>
	/// <typeparam name="T">从当前程序集中选取的类型的基类类型</typeparam>
	/// <param name="assembly">当前程序集</param>
	/// <param name="creator">类型实例创建方法</param>
	/// <returns>所有符合条件类型的实例序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前程序集为空。</exception>
	/// <remarks>如果未指定类型实例化方法则默认调用类型的无参数构造函数，如果没有无参数构造函数则忽略该类型。</remarks>
	public static T[] CreateInstance<T>(Assembly assembly, Func<Type, T> creator = null)
	{
		Guard.AssertNotNull(assembly, "assembly");
		creator = ObjectHelper.IfNull(creator, (Type t) => CreateInstance<T>(t));
		return (from t in assembly.GetTypes()
			select creator(t)).ToArray();
	}

	/// <summary>
	/// 创建当前程序集中所有可实例化类型的实例
	/// </summary>
	/// <param name="assembly">当前程序集</param>
	/// <param name="predicate">当前程序集中类型的过滤条件</param>
	/// <param name="creator">类型实例创建方法</param>
	/// <returns>所有符合条件类型的实例序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前程序集为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <remarks>如果未指定类型实例化方法则默认调用类型的无参数构造函数，如果没有无参数构造函数则忽略该类型。</remarks>
	public static object[] CreateInstance(Assembly assembly, Func<Type, bool> predicate, Func<Type, object> creator = null)
	{
		Guard.AssertNotNull(assembly, "assembly");
		Guard.AssertNotNull(predicate, "predicate");
		creator = ObjectHelper.IfNull(creator, (Type t) => CreateInstance(t));
		return (from t in assembly.GetTypes().Where(predicate)
			select creator(t)).ToArray();
	}

	/// <summary>
	/// 创建当前程序集中所有可实例化类型的实例
	/// </summary>
	/// <typeparam name="T">从当前程序集中选取的类型的基类类型</typeparam>
	/// <param name="assembly">当前程序集</param>
	/// <param name="predicate">当前程序集中类型的过滤条件</param>
	/// <param name="creator">类型实例创建方法</param>
	/// <returns>所有符合条件类型的实例序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前程序集为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <remarks>如果未指定类型实例化方法则默认调用类型的无参数构造函数，如果没有无参数构造函数则忽略该类型。</remarks>
	public static T[] CreateInstance<T>(Assembly assembly, Func<Type, bool> predicate, Func<Type, T> creator = null)
	{
		Guard.AssertNotNull(assembly, "assembly");
		Guard.AssertNotNull(predicate, "predicate");
		creator = ObjectHelper.IfNull(creator, (Type t) => CreateInstance<T>(t));
		return (from t in assembly.GetTypes().Where(predicate)
			select creator(t)).ToArray();
	}

	/// <summary>
	/// 创建当前类型的实例
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <returns>创建的当前类型的实例，如果无法创建实例返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	public static object CreateInstanceOrNull(Type type)
	{
		Guard.AssertNotNull(type, "type");
		Exception ex;
		return ObjectHelper.Try(type, (Type t) => CreateInstance(t), null, out ex);
	}

	/// <summary>
	/// 创建当前类型的实例
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="args">调用的构造函数参数数组</param>
	/// <returns>创建的当前类型的实例，如果无法创建实例返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	public static object CreateInstanceOrNull(Type type, params object[] args)
	{
		Guard.AssertNotNull(type, "type");
		Exception ex;
		return ObjectHelper.Try(type, (Type t) => CreateInstance(t, args), null, out ex);
	}

	/// <summary>
	/// 创建当前类型的实例
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="args">调用的构造函数参数数组</param>
	/// <param name="flags">构造函数绑定标志</param>
	/// <returns>创建的当前类型的实例，如果无法创建实例返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	public static object CreateInstanceOrNull(Type type, object[] args, BindingFlags flags)
	{
		Guard.AssertNotNull(type, "type");
		Exception ex;
		return ObjectHelper.Try(type, (Type t) => CreateInstance(t, args, flags), null, out ex);
	}

	/// <summary>
	/// 创建当前类型的实例
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="args">调用的构造函数参数数组</param>
	/// <param name="level">构造函数访问级别</param>
	/// <returns>创建的当前类型的实例，如果无法创建实例返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	public static object CreateInstanceOrNull(Type type, object[] args, AccessLevels level)
	{
		Guard.AssertNotNull(type, "type");
		Exception ex;
		return ObjectHelper.Try(type, (Type t) => CreateInstance(t, args, level), null, out ex);
	}

	/// <summary>
	/// 创建当前类型的实例
	/// </summary>
	/// <typeparam name="T">创建的实例的类型</typeparam>
	/// <param name="type">当前类型</param>
	/// <returns>创建的当前类型的实例，如果无法创建实例则返回指定类型的默认值。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前类型与指定的实例类型 <typeparamref name="T" /> 不兼容。</exception>
	public static T CreateInstanceOrDefault<T>(Type type)
	{
		Guard.AssertNotNull(type, "type");
		Exception ex;
		return ObjectHelper.Try(type, (Type t) => CreateInstance<T>(t), default(T), out ex);
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
	public static T CreateInstanceOrDefault<T>(Type type, params object[] args)
	{
		Guard.AssertNotNull(type, "type");
		Exception ex;
		return ObjectHelper.Try(type, (Type t) => CreateInstance<T>(t, args), default(T), out ex);
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
	public static T CreateInstanceOrDefault<T>(Type type, object[] args, T defaultInstance = default(T))
	{
		Guard.AssertNotNull(type, "type");
		Exception ex;
		return ObjectHelper.Try(type, (Type t) => CreateInstance<T>(t, args), defaultInstance, out ex);
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
	public static T CreateInstanceOrDefault<T>(Type type, object[] args, BindingFlags flags, T defaultInstance = default(T))
	{
		Guard.AssertNotNull(type, "type");
		Exception ex;
		return ObjectHelper.Try(type, (Type t) => CreateInstance<T>(t, args, flags), defaultInstance, out ex);
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
	public static T CreateInstanceOrDefault<T>(Type type, object[] args, AccessLevels level, T defaultInstance = default(T))
	{
		Guard.AssertNotNull(type, "type");
		Exception ex;
		return ObjectHelper.Try(type, (Type t) => CreateInstance<T>(t, args, level), defaultInstance, out ex);
	}

	/// <summary>
	/// 获取当前成员的访问级别
	/// </summary>
	/// <param name="minfo">当前成员</param>
	/// <returns>当前成员的访问级别</returns>
	/// <exception cref="T:System.ArgumentNullException">当前成员为空。</exception>
	/// <exception cref="T:System.NotSupportedException">当前成员不支持获取访问级别。</exception>
	public static AccessLevels GetAccessLevel(MemberInfo minfo)
	{
		Guard.AssertNotNull(minfo, "member info");
		if (minfo is Type)
		{
			return GetAccessLevel((Type)minfo);
		}
		if (minfo is ConstructorInfo)
		{
			return GetAccessLevel((ConstructorInfo)minfo);
		}
		if (minfo is PropertyInfo)
		{
			return GetAccessLevel((PropertyInfo)minfo);
		}
		if (minfo is MethodBase)
		{
			return GetAccessLevel((MethodBase)minfo);
		}
		if (minfo is FieldInfo)
		{
			return GetAccessLevel((FieldInfo)minfo);
		}
		if (minfo is EventInfo)
		{
			return GetAccessLevel((EventInfo)minfo);
		}
		throw new NotSupportedException(Literals.MSG_InvalidAccessibilityLevel);
	}

	/// <summary>
	/// 获取当前类型的访问级别
	/// </summary>
	/// <param name="type">当前待检测的类型</param>
	/// <returns>当前类型的访问级别</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	public static AccessLevels GetAccessLevel(Type type)
	{
		Guard.AssertNotNull(type, "type");
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
	/// 获取当前方法的访问级别
	/// </summary>
	/// <param name="method">当前方法</param>
	/// <returns>当前方法的访问级别</returns>
	/// <exception cref="T:System.ArgumentNullException">当前方法对象为空。</exception>
	/// <exception cref="T:System.NotSupportedException">当前方法不支持获取访问级别。</exception>
	public static AccessLevels GetAccessLevel(MethodBase method)
	{
		Guard.AssertNotNull(method, "method info");
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
	/// 获取当前字段的访问级别
	/// </summary>
	/// <param name="finfo">当前字段对象</param>
	/// <returns>当前字段的访问级别</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字段对象为空。</exception>
	public static AccessLevels GetAccessLevel(FieldInfo finfo)
	{
		Guard.AssertNotNull(finfo, "field");
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
	/// 获取当前事件的访问级别，属性的访问级别由get和set方法的最高级别决定
	/// </summary>
	/// <param name="einfo">当前事件对象</param>
	/// <returns>当前事件的访问级别</returns>
	/// <exception cref="T:System.ArgumentNullException">当前事件对象为空。</exception>
	/// <exception cref="T:System.NotSupportedException">当前事件不支持获取访问级别。</exception>
	public static AccessLevels GetAccessLevel(EventInfo einfo)
	{
		Guard.AssertNotNull(einfo, "event info");
		MethodInfo ainfo = einfo.GetAddMethod(nonPublic: true);
		int alevel = (int)((!ObjectHelper.IsNull(ainfo)) ? GetAccessLevel(ainfo) : AccessLevels.Unspecified);
		MethodInfo rinfo = einfo.GetRemoveMethod(nonPublic: true);
		int rlevel = (int)((!ObjectHelper.IsNull(rinfo)) ? GetAccessLevel(rinfo) : AccessLevels.Unspecified);
		int result = Math.Min(alevel, rlevel);
		if (result == 0)
		{
			throw new NotSupportedException(Literals.MSG_InvalidAccessibilityLevel);
		}
		return (AccessLevels)result;
	}

	/// <summary>
	/// 获取当前属性的访问级别，属性的访问级别由get和set方法的最高级别决定
	/// </summary>
	/// <param name="pinfo">当前属性</param>
	/// <returns>当前属性的访问级别</returns>
	/// <exception cref="T:System.ArgumentNullException">当前属性为空。</exception>
	/// <exception cref="T:System.NotSupportedException">当前属性不支持获取访问级别。</exception>
	public static AccessLevels GetAccessLevel(PropertyInfo pinfo)
	{
		Guard.AssertNotNull(pinfo, "property info");
		MethodInfo ginfo = pinfo.GetGetMethod(nonPublic: true);
		int glevel = (int)((!ObjectHelper.IsNull(ginfo)) ? GetAccessLevel(ginfo) : AccessLevels.Unspecified);
		MethodInfo sinfo = pinfo.GetSetMethod(nonPublic: true);
		int slevel = (int)((!ObjectHelper.IsNull(sinfo)) ? GetAccessLevel(sinfo) : AccessLevels.Unspecified);
		int result = Math.Min(glevel, slevel);
		if (result == 0)
		{
			throw new NotSupportedException(Literals.MSG_InvalidAccessibilityLevel);
		}
		return (AccessLevels)result;
	}

	/// <summary>
	/// 获取当前文件中程序集的完全名称
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <returns>当前文件中程序集的完全名称</returns>
	public static string GetAssemblyFullName(FileInfo file)
	{
		return GetAssemblyName(file).FullName;
	}

	/// <summary>
	/// 获取当前程序集文件中程序集的完整名称
	/// </summary>
	/// <param name="assemblyFile">当前程序集文件</param>
	/// <returns>当前程序集文件中程序集的完整名称</returns>
	/// <exception cref="T:System.ArgumentNullException">当前程序集文件为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前程序集文件不存在。</exception>
	public static string GetAssemblyFullName(string assemblyFile)
	{
		Guard.AssertNotNull(assemblyFile, "assembly file");
		Guard.AssertFileExistence(assemblyFile);
		return AssemblyName.GetAssemblyName(assemblyFile).FullName;
	}

	/// <summary>
	/// 获取当前类型的程序集限定名称。该名称遵循C#语法。
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <returns>当前类型的程序集限定名称，包括命名空间和程序集名称。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	public static string GetAssemblyQualifiedName(Type type)
	{
		Guard.AssertNotNull(type, "type");
		StringBuilder buff = new StringBuilder();
		buff.Append(type.Namespace).Append(".");
		if (type.IsNested)
		{
			buff.Append(GetName(type.DeclaringType, nestedName: true)).Append("+");
		}
		if (type.IsGenericType)
		{
			buff.Append(type.Name.Remove(type.Name.IndexOf("`")));
			buff.Append("<");
			Type[] genericArguments = type.GetGenericArguments();
			foreach (Type genericType in genericArguments)
			{
				buff.Append(GetAssemblyQualifiedName(genericType)).Append(", ");
			}
			buff.Remove(buff.Length - 2, 2);
			buff.Append(">");
			buff.Append(", ").Append(type.Assembly.FullName);
			return buff.ToString();
		}
		return type.AssemblyQualifiedName;
	}

	/// <summary>
	/// 获取当前文件中程序集的名称
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <returns>当前文件中程序集的名称</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	public static AssemblyName GetAssemblyName(FileInfo file)
	{
		Guard.AssertNotNull(file, "file");
		Guard.AssertFileExistence(file);
		return AssemblyName.GetAssemblyName(file.FullName);
	}

	/// <summary>
	/// 获取当前程序集文件中程序集的名称
	/// </summary>
	/// <param name="assemblyFile">当前程序集文件</param>
	/// <returns>当前程序集文件中程序集的名称</returns>
	/// <exception cref="T:System.ArgumentNullException">当前程序集文件为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前程序集文件不存在。</exception>
	public static AssemblyName GetAssemblyName(string assemblyFile)
	{
		Guard.AssertNotNull(assemblyFile, "assembly file");
		Guard.AssertFileExistence(assemblyFile);
		return AssemblyName.GetAssemblyName(assemblyFile);
	}

	/// <summary>
	/// 获取当前文件中的程序集的版本号
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <returns>当前文件中的程序集的版本号</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	public static Version GetAssemblyVersion(FileInfo file)
	{
		Guard.AssertNotNull(file, "file");
		Guard.AssertFileExistence(file);
		return GetAssemblyName(file).Version;
	}

	/// <summary>
	/// 获取当前程序集文件中程序集的版本信息
	/// </summary>
	/// <param name="assemblyFile">当前程序集文件</param>
	/// <returns>获取的程序集版本信息,如果无法获取则返回null</returns>
	/// <exception cref="T:System.ArgumentNullException">当前程序集文件为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前程序集文件不存在。</exception>
	public static Version GetAssemblyVersion(string assemblyFile)
	{
		Guard.AssertNotNull(assemblyFile, "assembly file");
		Guard.AssertFileExistence(assemblyFile);
		return AssemblyName.GetAssemblyName(assemblyFile).Version;
	}

	/// <summary>
	/// 获取当前文件中的程序集的完整版本号
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <returns>当前文件中的程序集的完整版本号</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	public static string GetAssemblyFullVersion(FileInfo file)
	{
		Guard.AssertNotNull(file, "file");
		Guard.AssertFileExistence(file);
		return GetAssemblyVersion(file).ToString(4);
	}

	/// <summary>
	/// 获取当前程序集文件中程序集的完整版本信息字符串
	/// </summary>
	/// <param name="assemblyFile">当前程序集文件</param>
	/// <returns>获取的程序集版本号,如果无法获取则返回null</returns>
	/// <exception cref="T:System.ArgumentNullException">当前程序集文件为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前程序集文件不存在。</exception>
	public static string GetAssemblyFullVersion(string assemblyFile)
	{
		Guard.AssertNotNull(assemblyFile, "assembly file");
		Guard.AssertFileExistence(assemblyFile);
		return AssemblyName.GetAssemblyName(assemblyFile).Version.ToString(4);
	}

	/// <summary>
	/// 获取当前文件中的程序集的简短版本号
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <returns>当前文件中的程序集的简短版本号</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	public static string GetAssemblyShortVersion(FileInfo file)
	{
		Guard.AssertNotNull(file, "file");
		Guard.AssertFileExistence(file);
		return GetAssemblyVersion(file).ToString(2);
	}

	/// <summary>
	/// 获取当前程序集文件中程序集的简单版本信息字符串
	/// </summary>
	/// <param name="assemblyFile">当前程序集文件</param>
	/// <returns>获取的程序集版本号,如果无法获取则返回null</returns>
	/// <exception cref="T:System.ArgumentNullException">当前程序集文件为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前程序集文件不存在。</exception>
	public static string GetAssemblyShortVersion(string assemblyFile)
	{
		Guard.AssertNotNull(assemblyFile, "assembly file");
		Guard.AssertFileExistence(assemblyFile);
		return AssemblyName.GetAssemblyName(assemblyFile).Version.ToString(2);
	}

	/// <summary>
	/// 获取当前类型已经分配的第一个泛型参数
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <returns>当前类型已分配的第一个泛型参数；如果当前类型不是泛型类型或者没有已分配的泛型参数，则返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	public static Type GetAssignedGenericArgument(Type type)
	{
		Guard.AssertNotNull(type, "type");
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
	public static Type[] GetAssignedGenericArguments(Type type)
	{
		Guard.AssertNotNull(type, "type");
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
	public static Type[] GetBaseTypes(Type type)
	{
		Guard.AssertNotNull(type, "type");
		List<Type> baseTypes = new List<Type>();
		while (ObjectHelper.IsNotNull(type.BaseType))
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
	public static ConstructorInfo GetConstructor(Type type, params Type[] argTypes)
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
	public static ConstructorInfo GetConstructor(Type type, Type[] argTypes, bool optionalBinding)
	{
		return GetConstructors(type, argTypes, BindingFlags.Instance | BindingFlags.Public, optionalBinding).FirstOrDefault();
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
	public static ConstructorInfo GetConstructor(Type type, Type[] argTypes, BindingFlags flags, bool optionalBinding = true)
	{
		return GetConstructors(type, argTypes, flags, optionalBinding).FirstOrDefault();
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
	public static ConstructorInfo GetConstructor(Type type, Type[] argTypes, AccessLevels level, bool optionalBinding = true)
	{
		return GetConstructors(type, argTypes, level, optionalBinding).FirstOrDefault();
	}

	/// <summary>
	/// 获取当前类型中满足指定绑定条件的构造函数
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="flags">构造函数的绑定条件</param>
	/// <returns>满足条件的构造函数</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	public static ConstructorInfo[] GetConstructors(Type type, BindingFlags flags = BindingFlags.Instance | BindingFlags.Public)
	{
		Guard.AssertNotNull(type, "type");
		return type.GetConstructors(flags);
	}

	/// <summary>
	/// 获取当前类型中指定访问级别的构造函数
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="level">获取的构造函数的访问级别</param>
	/// <returns>当前类型中符合条件的构造函数</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	public static ConstructorInfo[] GetConstructors(Type type, AccessLevels level)
	{
		Guard.AssertNotNull(type, "type");
		return (from x in GetConstructors(type, EnumHelper.ToBindingFlags(level))
			where EnumHelper.HasLevel(GetAccessLevel(x), level)
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
	public static ConstructorInfo[] GetConstructors(Type type, Func<ConstructorInfo, bool> predicate, BindingFlags flags = BindingFlags.Instance | BindingFlags.Public)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNull(predicate, "predicate");
		return GetConstructors(type, flags).Where(predicate).ToArray();
	}

	/// <summary>
	/// 获取当前类型中指定访问级别满足筛选条件的构造函数
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="predicate">构造函数筛选条件</param>
	/// <param name="level">获取的构造函数的访问级别</param>
	/// <returns>当前类型中符合条件的构造函数</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者构造函数筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static ConstructorInfo[] GetConstructors(Type type, Func<ConstructorInfo, bool> predicate, AccessLevels level)
	{
		Guard.AssertNotNull(predicate, "predicate");
		return GetConstructors(type, level).Where(predicate).ToArray();
	}

	/// <summary>
	/// 获取当前类型中与参数类型数组匹配的公共实例构造函数
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="argTypes">参数类型数组</param>
	/// <returns>当前类型中符合条件的构造函数</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者参数类型数组 <paramref name="argTypes" /> 为空。</exception>
	public static ConstructorInfo[] GetConstructors(Type type, params Type[] argTypes)
	{
		return GetConstructors(type, argTypes, BindingFlags.Instance | BindingFlags.Public);
	}

	/// <summary>
	/// 获取当前类型中与参数类型数组匹配的公共实例构造函数
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="argTypes">参数类型数组</param>
	/// <param name="optionalBinding">对于构造函数的可选参数是否也必须进行绑定</param>
	/// <returns>当前类型中符合条件的构造函数</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者参数类型数组 <paramref name="argTypes" /> 为空。</exception>
	public static ConstructorInfo[] GetConstructors(Type type, Type[] argTypes, bool optionalBinding)
	{
		return GetConstructors(type, argTypes, BindingFlags.Instance | BindingFlags.Public, optionalBinding);
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
	public static ConstructorInfo[] GetConstructors(Type type, Type[] argTypes, BindingFlags flags, bool optionalBinding = false)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNull(argTypes, "argument types");
		return (from x in GetConstructors(type, flags)
			where IsBindable(x, argTypes, optionalBinding)
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
	public static ConstructorInfo[] GetConstructors(Type type, Type[] argTypes, AccessLevels level, bool optionalBinding = false)
	{
		Guard.AssertNotNull(argTypes, "argument types");
		return (from x in GetConstructors(type, level)
			where IsBindable(x, argTypes, optionalBinding)
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
	public static ConstructorInfo[] GetConstructors(Type type, Type attributeType, bool inherit)
	{
		return GetConstructors(type, attributeType, BindingFlags.Instance | BindingFlags.Public, inherit);
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
	public static ConstructorInfo[] GetConstructors(Type type, Type attributeType, BindingFlags flags, bool inherit = false)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNull(attributeType, "attribute type");
		Guard.AssertInheritedType<Attribute>(attributeType, "attribute type");
		return (from c in GetConstructors(type, flags)
			where HasCustomAttribute(c, attributeType, inherit)
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
	public static ConstructorInfo[] GetConstructors(Type type, Type attributeType, AccessLevels level, bool inherit = false)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNull(attributeType, "attribute type");
		Guard.AssertInheritedType<Attribute>(attributeType, "attribute type");
		return (from c in GetConstructors(type, level)
			where HasCustomAttribute(c, attributeType, inherit)
			select c).ToArray();
	}

	/// <summary>
	/// 获取当前对象上找到的第一个自定义特性
	/// </summary>
	/// <param name="provider">当前对象</param>
	/// <param name="inherit">是否从当前对象的继承结构中获取自定义特性</param>
	/// <returns>当前对象找到的第一个自定义特性；如果没有则返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空。</exception>
	public static Attribute GetCustomAttribute(ICustomAttributeProvider provider, bool inherit = false)
	{
		Guard.AssertNotNull(provider, "attribute provider");
		return provider.GetCustomAttributes(inherit).OfType<Attribute>().FirstOrDefault();
	}

	/// <summary>
	/// 获取当前对象上与特性基类型相同或者从特性基类型继承的自定义特性
	/// </summary>
	/// <param name="provider">当前对象</param>
	/// <param name="attributeType">获取的自定义特性的基类型</param>
	/// <param name="inherit">是否从当前对象的继承结构中获取自定义特性</param>
	/// <returns>符合条件的第一个自定义特性；如果没有符合条件的特性，返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者自定义特性的基类型 <paramref name="attributeType" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">自定义特性的基类型 <paramref name="attributeType" /> 不是从 <see cref="T:System.Attribute" /> 继承的。</exception>
	public static Attribute GetCustomAttribute(ICustomAttributeProvider provider, Type attributeType, bool inherit = false)
	{
		Guard.AssertNotNull(provider, "attribute provider");
		Guard.AssertNotNull(attributeType, "attribute type");
		Guard.AssertInheritedType<Attribute>(attributeType, "attribute type");
		return provider.GetCustomAttributes(attributeType, inherit).OfType<Attribute>().FirstOrDefault();
	}

	/// <summary>
	/// 获取当前对象上满足特性筛选条件的自定义特性
	/// </summary>
	/// <param name="provider">当前对象</param>
	/// <param name="predicate">特性筛选条件</param>
	/// <param name="inherit">是否从当前对象的继承结构中获取自定义特性</param>
	/// <returns>符合条件的第一个自定义特性；如果没有符合条件的特性，返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者特性筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static Attribute GetCustomAttribute(ICustomAttributeProvider provider, Func<Attribute, bool> predicate, bool inherit = false)
	{
		Guard.AssertNotNull(provider, "attribute provider");
		Guard.AssertNotNull(predicate, "attribute predicate");
		return provider.GetCustomAttributes(inherit).OfType<Attribute>().Where(predicate)
			.FirstOrDefault();
	}

	/// <summary>
	/// 获取当前对象上与特性基类型相同或者从特性基类型继承的，满足特性筛选条件的自定义特性
	/// </summary>
	/// <param name="provider">当前对象</param>
	/// <param name="attributeType">获取的自定义特性的基类型</param>
	/// <param name="predicate">特性筛选条件</param>
	/// <param name="inherit">是否从当前对象的继承结构中获取自定义特性</param>
	/// <returns>符合条件的第一个自定义特性；如果没有符合条件的特性，返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者自定义特性的基类型 <paramref name="attributeType" /> 为空；或者特性筛选条件 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">自定义特性的基类型 <paramref name="attributeType" /> 不是从 <see cref="T:System.Attribute" /> 继承的。</exception>
	public static Attribute GetCustomAttribute(ICustomAttributeProvider provider, Type attributeType, Func<Attribute, bool> predicate, bool inherit = false)
	{
		Guard.AssertNotNull(provider, "attribute provider");
		Guard.AssertNotNull(attributeType, "attribute type");
		Guard.AssertInheritedType<Attribute>(attributeType, "attribute type");
		Guard.AssertNotNull(predicate, "attribute predicate");
		return provider.GetCustomAttributes(attributeType, inherit).OfType<Attribute>().Where(predicate)
			.FirstOrDefault();
	}

	/// <summary>
	/// 获取当前对象上与特性基类型相同或者从特性基类型继承的自定义特性
	/// </summary>
	/// <typeparam name="T">获取的自定义特性的基类型</typeparam>
	/// <param name="provider">当前对象</param>
	/// <param name="inherit">是否从当前对象的继承结构中获取自定义特性</param>
	/// <returns>符合条件的第一个自定义特性；如果没有符合条件的特性，返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空。</exception>
	public static T GetCustomAttribute<T>(ICustomAttributeProvider provider, bool inherit = false) where T : Attribute
	{
		Guard.AssertNotNull(provider, "attribute provider");
		return provider.GetCustomAttributes(typeof(T), inherit).OfType<T>().FirstOrDefault();
	}

	/// <summary>
	/// 获取当前对象上与特性基类型相同或者从特性基类型继承的，满足特性筛选条件的自定义特性
	/// </summary>
	/// <typeparam name="T">获取的自定义特性的基类型</typeparam>
	/// <param name="provider">当前对象</param>
	/// <param name="predicate">特性筛选条件</param>
	/// <param name="inherit">是否从当前对象的继承结构中获取自定义特性</param>
	/// <returns>符合条件的第一个自定义特性；如果没有符合条件的特性，返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者特性筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static T GetCustomAttribute<T>(ICustomAttributeProvider provider, Func<T, bool> predicate, bool inherit = false) where T : Attribute
	{
		Guard.AssertNotNull(provider, "attribute provider");
		Guard.AssertNotNull(predicate, "attribute predicate");
		return provider.GetCustomAttributes(typeof(T), inherit).OfType<T>().Where(predicate)
			.FirstOrDefault();
	}

	/// <summary>
	/// 获取当前对象上满足特性筛选条件的自定义特性
	/// </summary>
	/// <param name="provider">当前对象</param>
	/// <param name="predicate">特性筛选条件</param>
	/// <param name="inherit">是否从当前对象的继承结构中获取自定义特性</param>
	/// <returns>符合条件的自定义特性的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者特性筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static Attribute[] GetCustomAttributes(ICustomAttributeProvider provider, Func<Attribute, bool> predicate, bool inherit = false)
	{
		Guard.AssertNotNull(provider, "attribute provider");
		Guard.AssertNotNull(predicate, "attribute predicate");
		return provider.GetCustomAttributes(inherit).OfType<Attribute>().Where(predicate)
			.ToArray();
	}

	/// <summary>
	/// 获取当前对象上与特性基类型相同或者从特性基类型继承的，满足特性筛选条件的自定义特性
	/// </summary>
	/// <param name="provider">当前对象</param>
	/// <param name="attributeType">获取的自定义特性的基类型</param>
	/// <param name="predicate">特性筛选条件</param>
	/// <param name="inherit">是否从当前对象的继承结构中获取自定义特性</param>
	/// <returns>符合条件的自定义特性的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者特性基类型 <paramref name="attributeType" /> 为空；或者特性筛选条件 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">自定义特性的基类型 <paramref name="attributeType" /> 不是从 <see cref="T:System.Attribute" /> 继承的。</exception>
	public static Attribute[] GetCustomAttributes(ICustomAttributeProvider provider, Type attributeType, Func<Attribute, bool> predicate, bool inherit = false)
	{
		Guard.AssertNotNull(provider, "attribute provider");
		Guard.AssertNotNull(attributeType, "attribute type");
		Guard.AssertInheritedType<Attribute>(attributeType, "attribute type");
		Guard.AssertNotNull(predicate, "attribute predicate");
		return provider.GetCustomAttributes(attributeType, inherit).OfType<Attribute>().Where(predicate)
			.ToArray();
	}

	/// <summary>
	/// 获取当前对象上与特性基类型相同或者从特性基类型继承的自定义特性
	/// </summary>
	/// <typeparam name="T">获取的自定义特性的基类型</typeparam>
	/// <param name="provider">当前对象</param>
	/// <param name="inherit">是否从当前对象的继承结构中获取自定义特性</param>
	/// <returns>符合条件的自定义特性的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空。</exception>
	public static T[] GetCustomAttributes<T>(ICustomAttributeProvider provider, bool inherit = false) where T : Attribute
	{
		Guard.AssertNotNull(provider, "attribute provider");
		return provider.GetCustomAttributes(typeof(T), inherit).OfType<T>().ToArray();
	}

	/// <summary>
	/// 获取当前对象上与特性基类型相同或者从特性基类型继承的，满足特性筛选条件的自定义特性
	/// </summary>
	/// <typeparam name="T">获取的自定义特性的基类型</typeparam>
	/// <param name="provider">当前对象</param>
	/// <param name="predicate">特性筛选条件</param>
	/// <param name="inherit">是否从当前对象的继承结构中获取自定义特性</param>
	/// <returns>符合条件的自定义特性的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者特性筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static T[] GetCustomAttributes<T>(ICustomAttributeProvider provider, Func<T, bool> predicate, bool inherit = false) where T : Attribute
	{
		Guard.AssertNotNull(provider, "attribute provider");
		Guard.AssertNotNull(predicate, "attribute predicate");
		return provider.GetCustomAttributes(typeof(T), inherit).OfType<T>().Where(predicate)
			.ToArray();
	}

	/// <summary>
	/// 获取当前类型中具有指定名称的公共实例事件
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="eventName">事件名称</param>
	/// <param name="ignoreCase">事件名称是否区分大小写</param>
	/// <returns>匹配的事件，如果不存在匹配的事件返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者事件名称 <paramref name="eventName" /> 为空或者空串。</exception>
	public static EventInfo GetEvent(Type type, string eventName, bool ignoreCase)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNullAndEmpty(eventName, "event name");
		return type.GetEvent(eventName, EnumHelper.Combine(BindingFlags.Instance | BindingFlags.Public, ignoreCase));
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
	public static EventInfo GetEvent(Type type, string eventName, BindingFlags flags, bool ignoreCase = false)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNullAndEmpty(eventName, "event name");
		return type.GetEvent(eventName, EnumHelper.Combine(flags, ignoreCase));
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
	public static EventInfo GetEvent(Type type, string eventName, AccessLevels level, bool ignoreCase = false)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNullAndEmpty(eventName, "event name");
		return (from x in GetEvents(type, level)
			where TextHelper.EqualOrdinal(x.Name, eventName, ignoreCase)
			select x).FirstOrDefault();
	}

	/// <summary>
	/// 获取当前类型中指定绑定条件的事件
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="flags">事件绑定条件</param>
	/// <returns>当前类型中符合条件的时间</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	public static EventInfo[] GetEvents(Type type, BindingFlags flags = BindingFlags.Instance | BindingFlags.Public)
	{
		Guard.AssertNotNull(type, "type");
		return type.GetEvents(flags);
	}

	/// <summary>
	/// 获取当前类型中指定访问级别的事件
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="level">获取的事件的访问级别</param>
	/// <returns>当前类型中符合条件的事件</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	public static EventInfo[] GetEvents(Type type, AccessLevels level)
	{
		Guard.AssertNotNull(type, "type");
		return (from x in GetEvents(type, EnumHelper.ToBindingFlags(level))
			where EnumHelper.HasLevel(GetAccessLevel(x), level)
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
	public static EventInfo[] GetEvents(Type type, Func<EventInfo, bool> predicate, BindingFlags flags = BindingFlags.Instance | BindingFlags.Public)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNull(predicate, "predicate");
		return GetEvents(type, flags).Where(predicate).ToArray();
	}

	/// <summary>
	/// 获取当前类型中指定访问级别满足筛选条件的事件
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="predicate">事件筛选条件</param>
	/// <param name="level">获取的事件的访问级别</param>
	/// <returns>当前类型中符合条件的事件</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者事件筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static EventInfo[] GetEvents(Type type, Func<EventInfo, bool> predicate, AccessLevels level)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNull(predicate, "predicate");
		return GetEvents(type, level).Where(predicate).ToArray();
	}

	/// <summary>
	/// 获取当前类型中满足绑定条件和名称正则模式的事件
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="pattern">事件名称的正则模式</param>
	/// <param name="flags">事件绑定搜索标志，默认为公共实例标志</param>
	/// <returns>当前类型中符合条件的事件</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者事件名称的正则模式 <paramref name="pattern" /> 为空。</exception>
	public static EventInfo[] GetEvents(Type type, Regex pattern, BindingFlags flags = BindingFlags.Instance | BindingFlags.Public)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNull(pattern, "event name pattern");
		return (from x in GetEvents(type, flags)
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
	public static EventInfo[] GetEvents(Type type, Regex pattern, AccessLevels level)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNull(pattern, "event name pattern");
		return (from x in GetEvents(type, level)
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
	public static EventInfo[] GetEvents(Type type, Type attributeType, bool inherit = false)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNull(attributeType, "attribute type");
		return GetEvents(type, attributeType, BindingFlags.Instance | BindingFlags.Public, inherit);
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
	public static EventInfo[] GetEvents(Type type, Type attributeType, BindingFlags flags, bool inherit = false)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNull(attributeType, "attribute type");
		Guard.AssertInheritedType<Attribute>(attributeType, "attribute type");
		return (from c in GetEvents(type, flags)
			where HasCustomAttribute(c, attributeType, inherit)
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
	public static EventInfo[] GetEvents(Type type, Type attributeType, AccessLevels level, bool inherit = false)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNull(attributeType, "attribute type");
		Guard.AssertInheritedType<Attribute>(attributeType, "attribute type");
		return (from c in GetEvents(type, level)
			where HasCustomAttribute(c, attributeType, inherit)
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
	public static FieldInfo GetField(Type type, string fieldName, bool ignoreCase)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNullAndEmpty(fieldName, "field name");
		return type.GetField(fieldName, EnumHelper.Combine(BindingFlags.Instance | BindingFlags.Public, ignoreCase));
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
	public static FieldInfo GetField(Type type, string fieldName, BindingFlags flags, bool ignoreCase = false)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNullAndEmpty(fieldName, "field name");
		return type.GetField(fieldName, EnumHelper.Combine(flags, ignoreCase));
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
	public static FieldInfo GetField(Type type, string fieldName, AccessLevels level, bool ignoreCase = false)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNullAndEmpty(fieldName, "field name");
		return (from x in GetFields(type, level)
			where TextHelper.EqualOrdinal(x.Name, fieldName, ignoreCase)
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
	public static FieldInfo GetFieldByPath(Type type, string fieldPath, bool ignoreCase = false)
	{
		return GetFieldByPath(type, fieldPath, BindingFlags.Instance | BindingFlags.Public, ignoreCase);
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
	public static FieldInfo GetFieldByPath(Type type, string fieldPath, BindingFlags flags, bool ignoreCase = false)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNullAndEmpty(fieldPath, "field path");
		string[] fieldNames = fieldPath.Split(new char[1] { '.' }, StringSplitOptions.None);
		FieldInfo field = null;
		string[] array = fieldNames;
		foreach (string fieldName in array)
		{
			field = GetField(type, fieldName, flags, ignoreCase);
			if (ObjectHelper.IsNull(field))
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
	public static FieldInfo GetFieldByPath(Type type, string fieldPath, AccessLevels level, bool ignoreCase = false)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNullAndEmpty(fieldPath, "field path");
		string[] fieldNames = fieldPath.Split(new char[1] { '.' }, StringSplitOptions.None);
		FieldInfo field = null;
		string[] array = fieldNames;
		foreach (string fieldName in array)
		{
			field = GetField(type, fieldName, level, ignoreCase);
			if (ObjectHelper.IsNull(field))
			{
				return null;
			}
			type = field.FieldType;
		}
		return field;
	}

	/// <summary>
	/// 获取当前类型中指定绑定条件的字段
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="flags">字段绑定条件</param>
	/// <returns>当前类型中符合绑定条件的字段</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	public static FieldInfo[] GetFields(Type type, BindingFlags flags = BindingFlags.Instance | BindingFlags.Public)
	{
		Guard.AssertNotNull(type, "type");
		return type.GetFields(flags);
	}

	/// <summary>
	/// 获取当前类型中指定访问级别的字段
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="level">获取的字段的访问级别</param>
	/// <returns>当前类型中符合条件的字段</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	public static FieldInfo[] GetFields(Type type, AccessLevels level)
	{
		Guard.AssertNotNull(type, "type");
		return (from x in GetFields(type, EnumHelper.ToBindingFlags(level))
			where EnumHelper.HasLevel(GetAccessLevel(x), level)
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
	public static FieldInfo[] GetFields(Type type, Func<FieldInfo, bool> predicate, BindingFlags flags = BindingFlags.Instance | BindingFlags.Public)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNull(predicate, "predicate");
		return GetFields(type, flags).Where(predicate).ToArray();
	}

	/// <summary>
	/// 获取当前类型中指定访问级别满足筛选条件的字段
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="predicate">字段筛选条件</param>
	/// <param name="level">获取的字段的访问级别</param>
	/// <returns>当前类型中符合条件的字段</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者字段筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static FieldInfo[] GetFields(Type type, Func<FieldInfo, bool> predicate, AccessLevels level)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNull(predicate, "predicate");
		return GetFields(type, level).Where(predicate).ToArray();
	}

	/// <summary>
	/// 获取当前类型中满足绑定条件和名称正则模式的字段
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="pattern">字段名称的正则模式</param>
	/// <param name="flags">字段绑定搜索标志</param>
	/// <returns>当前类型中符合条件的字段</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者字段名称的正则模式 <paramref name="pattern" /> 为空。</exception>
	public static FieldInfo[] GetFields(Type type, Regex pattern, BindingFlags flags = BindingFlags.Instance | BindingFlags.Public)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNull(pattern, "field name pattern");
		return (from x in GetFields(type, flags)
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
	public static FieldInfo[] GetFields(Type type, Regex pattern, AccessLevels level)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNull(pattern, "field name pattern");
		return (from x in GetFields(type, level)
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
	public static FieldInfo[] GetFields(Type type, Type attributeType, bool inherit = false)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNull(attributeType, "attribute type");
		return GetFields(type, attributeType, BindingFlags.Instance | BindingFlags.Public, inherit);
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
	public static FieldInfo[] GetFields(Type type, Type attributeType, BindingFlags flags, bool inherit = false)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNull(attributeType, "attribute type");
		Guard.AssertInheritedType<Attribute>(attributeType, "attribute type");
		return (from c in GetFields(type, flags)
			where HasCustomAttribute(c, attributeType, inherit)
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
	public static FieldInfo[] GetFields(Type type, Type attributeType, AccessLevels level, bool inherit = false)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNull(attributeType, "attribute type");
		Guard.AssertInheritedType<Attribute>(attributeType, "attribute type");
		return (from c in GetFields(type, level)
			where HasCustomAttribute(c, attributeType, inherit)
			select c).ToArray();
	}

	/// <summary>
	/// 获取当前类型的第一个泛型类型参数
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <returns>当前类型的第一个泛型类型参数；如果当前类型不是泛型类型返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	public static Type GetGenericArgument(Type type)
	{
		Guard.AssertNotNull(type, "type");
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
	public static Type GetInterface(Type type, Type targetType)
	{
		return GetInterfaces(type, targetType).FirstOrDefault();
	}

	/// <summary>
	/// 获取当前类型实现的具有指定名称的接口数组
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="name">接口名称，可以包含命名空间名称</param>
	/// <param name="ignoreCase">接口名称是否区分大小写</param>
	/// <returns>匹配的接口数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前接口为空；或者接口名称为空或者空串。</exception>
	public static Type[] GetInterfaces(Type type, string name, bool ignoreCase = false)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNullAndEmpty(name, "name");
		List<Type> interfaceTypes = new List<Type>();
		Type[] interfaces = type.GetInterfaces();
		foreach (Type interfaceType in interfaces)
		{
			if (interfaceType.IsGenericType)
			{
				Type def = interfaceType.GetGenericTypeDefinition();
				if (TextHelper.EqualOrdinal(def.Name, name, ignoreCase) || TextHelper.EqualOrdinal(def.FullName, name, ignoreCase))
				{
					interfaceTypes.Add(interfaceType);
				}
			}
			else if (TextHelper.EqualOrdinal(interfaceType.Name, name, ignoreCase) || TextHelper.EqualOrdinal(interfaceType.FullName, name, ignoreCase))
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
	public static Type[] GetInterfaces(Type type, Regex pattern)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNull(pattern, "pattern");
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
	public static Type[] GetInterfaces(Type type, Type targetType)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNull(targetType, "target type");
		Guard.Assert(targetType, (Type x) => x.IsInterface, "target type");
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
	/// 获取当前类型中指定绑定条件的成员
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="flags">成员绑定条件</param>
	/// <returns>当前类型中符合绑定条件的成员</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	public static MemberInfo[] GetMembers(Type type, BindingFlags flags = BindingFlags.Instance | BindingFlags.Public)
	{
		Guard.AssertNotNull(type, "type");
		return type.GetMembers(flags);
	}

	/// <summary>
	/// 获取当前类型中指定访问级别的成员
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="level">获取的成员的访问级别</param>
	/// <returns>当前类型中符合条件的成员</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	public static MemberInfo[] GetMembers(Type type, AccessLevels level)
	{
		Guard.AssertNotNull(type, "type");
		return (from x in type.GetMembers(EnumHelper.ToBindingFlags(level))
			where EnumHelper.HasLevel(GetAccessLevel(x), level)
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
	public static MemberInfo[] GetMembers(Type type, Func<MemberInfo, bool> predicate, BindingFlags flags = BindingFlags.Instance | BindingFlags.Public)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNull(predicate, "predicate");
		return GetMembers(type, flags).Where(predicate).ToArray();
	}

	/// <summary>
	/// 获取当前类型中指定访问级别满足筛选条件的成员
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="predicate">成员筛选条件</param>
	/// <param name="level">获取的成员的访问级别</param>
	/// <returns>当前类型中符合条件的成员</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者成员筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static MemberInfo[] GetMembers(Type type, Func<MemberInfo, bool> predicate, AccessLevels level)
	{
		Guard.AssertNotNull(predicate, "predicate");
		return GetMembers(type, level).Where(predicate).ToArray();
	}

	/// <summary>
	/// 获取当前类型中具有指定名称的公共实例成员
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="memberName">获取的成员的名称</param>
	/// <param name="ignoreCase">成员名称是否区分大小写</param>
	/// <returns>当前类型中符合条件的成员</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者成员名称 <paramref name="memberName" /> 为空或者空串。</exception>
	public static MemberInfo[] GetMembers(Type type, string memberName, bool ignoreCase = false)
	{
		return GetMembers(type, memberName, BindingFlags.Instance | BindingFlags.Public, ignoreCase);
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
	public static MemberInfo[] GetMembers(Type type, string memberName, BindingFlags flags, bool ignoreCase = false)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNullAndEmpty(memberName, "member name");
		return GetMembers(type, memberName, EnumHelper.Combine(flags, ignoreCase));
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
	public static MemberInfo[] GetMembers(Type type, string memberName, AccessLevels level, bool ignoreCase = false)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNullAndEmpty(memberName, "member name");
		return (from m in GetMembers(type, level)
			where TextHelper.EqualOrdinal(m.Name, memberName, ignoreCase)
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
	public static MemberInfo[] GetMembers(Type type, Regex pattern, BindingFlags flags = BindingFlags.Instance | BindingFlags.Public)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNull(pattern, "event name pattern");
		return (from x in GetMembers(type, flags)
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
	public static MemberInfo[] GetMembers(Type type, Regex pattern, AccessLevels level)
	{
		Guard.AssertNotNull(pattern, "event name pattern");
		return (from x in GetMembers(type, level)
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
	public static MemberInfo[] GetMembers(Type type, Type attributeType, bool inherit = false)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNull(attributeType, "attribute type");
		Guard.AssertInheritedType<Attribute>(attributeType, "attribute type");
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
	public static MemberInfo[] GetMembers(Type type, Type attributeType, BindingFlags flags, bool inherit = false)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNull(attributeType, "attribute type");
		Guard.AssertInheritedType<Attribute>(attributeType, "attribute type");
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
	public static MemberInfo[] GetMembers(Type type, Type attributeType, AccessLevels level, bool inherit = false)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNull(attributeType, "attribute type");
		Guard.AssertInheritedType<Attribute>(attributeType, "attribute type");
		return (from m in GetMembers(type, level)
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
	public static T[] GetMembers<T>(Type type, BindingFlags flags = BindingFlags.Instance | BindingFlags.Public) where T : MemberInfo
	{
		Guard.AssertNotNull(type, "type");
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
	public static T[] GetMembers<T>(Type type, AccessLevels level) where T : MemberInfo
	{
		Guard.AssertNotNull(type, "type");
		return (from x in GetMembers(type, EnumHelper.ToBindingFlags(level)).OfType<T>()
			where EnumHelper.HasLevel(GetAccessLevel(x), level)
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
	public static T[] GetMembers<T>(Type type, Func<T, bool> predicate, BindingFlags flags = BindingFlags.Instance | BindingFlags.Public) where T : MemberInfo
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNull(predicate, "predicate");
		return GetMembers<T>(type, flags).Where(predicate).ToArray();
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
	public static T[] GetMembers<T>(Type type, Func<T, bool> predicate, AccessLevels level) where T : MemberInfo
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNull(predicate, "predicate");
		return GetMembers<T>(type, level).Where(predicate).ToArray();
	}

	/// <summary>
	/// 获取当前类型中具有指定名称的公共实例成员
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="memberName">获取的成员的名称</param>
	/// <param name="ignoreCase">成员名称是否区分大小写</param>
	/// <returns>当前类型中符合条件的成员</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者成员名称 <paramref name="memberName" /> 为空或者空串。</exception>
	public static T[] GetMembers<T>(Type type, string memberName, bool ignoreCase = false) where T : MemberInfo
	{
		return GetMembers<T>(type, memberName, BindingFlags.Instance | BindingFlags.Public, ignoreCase);
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
	public static T[] GetMembers<T>(Type type, string memberName, BindingFlags flags, bool ignoreCase = false) where T : MemberInfo
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNullAndEmpty(memberName, "member name");
		return GetMembers(type, memberName, EnumHelper.Combine(flags, ignoreCase)).OfType<T>().ToArray();
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
	public static T[] GetMembers<T>(Type type, string memberName, AccessLevels level, bool ignoreCase = false) where T : MemberInfo
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNullAndEmpty(memberName, "member name");
		return (from m in GetMembers(type, level).OfType<T>()
			where TextHelper.EqualOrdinal(m.Name, memberName, ignoreCase)
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
	public static T[] GetMembers<T>(Type type, Regex pattern, BindingFlags flags = BindingFlags.Instance | BindingFlags.Public) where T : MemberInfo
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNull(pattern, "pattern");
		return (from m in GetMembers<T>(type, flags)
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
	public static T[] GetMembers<T>(Type type, Regex pattern, AccessLevels level) where T : MemberInfo
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNull(pattern, "pattern");
		return (from m in GetMembers<T>(type, level)
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
	public static T[] GetMembers<T>(Type type, Type attributeType, bool inherit = false) where T : MemberInfo
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNull(attributeType, "attribute type");
		Guard.AssertInheritedType<Attribute>(attributeType, "attribute type");
		return (from m in GetMembers<T>(type)
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
	public static T[] GetMembers<T>(Type type, Type attributeType, BindingFlags flags, bool inherit = false) where T : MemberInfo
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNull(attributeType, "attribute type");
		Guard.AssertInheritedType<Attribute>(attributeType, "attribute type");
		return (from m in GetMembers<T>(type, flags)
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
	public static T[] GetMembers<T>(Type type, Type attributeType, AccessLevels level, bool inherit = false) where T : MemberInfo
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNull(attributeType, "attribute type");
		Guard.AssertInheritedType<Attribute>(attributeType, "attribute type");
		return (from m in GetMembers<T>(type, level)
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
	public static MethodInfo GetMethod(Type type, string methodName, bool ignoreCase)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNullAndEmpty(methodName, "method name");
		return type.GetMethod(methodName, EnumHelper.Combine(BindingFlags.Instance | BindingFlags.Public, ignoreCase));
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
	public static MethodInfo GetMethod(Type type, string methodName, BindingFlags flags, bool ignoreCase = false)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNullAndEmpty(methodName, "method name");
		return type.GetMethod(methodName, EnumHelper.Combine(flags, ignoreCase));
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
	public static MethodInfo GetMethod(Type type, string methodName, AccessLevels level, bool ignoreCase = false)
	{
		return GetMethods(type, methodName, level, ignoreCase).FirstOrDefault();
	}

	/// <summary>
	/// 获取当前类型中具有指定名称并与给定参数类型数组匹配的公共实例方法
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="methodName">方法名称，区分大小写</param>
	/// <param name="argTypes">参数类型数组</param>
	/// <returns>匹配的方法，如果不存在匹配的方法返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者方法名称 <paramref name="methodName" /> 为空或者空串。</exception>
	public static MethodInfo GetMethod(Type type, string methodName, params Type[] argTypes)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNullAndEmpty(methodName, "method name");
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
	public static MethodInfo GetMethod(Type type, string methodName, Type[] argTypes, bool ignoreCase = false, bool optionalBinding = false)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNullAndEmpty(methodName, "method name");
		return GetMethods(type, methodName, argTypes, ignoreCase, optionalBinding).FirstOrDefault();
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
	public static MethodInfo GetMethod(Type type, string methodName, Type[] argTypes, BindingFlags flags, bool ignoreCase = false, bool optionalBinding = false)
	{
		return GetMethods(type, methodName, argTypes, flags, ignoreCase, optionalBinding).FirstOrDefault();
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
	public static MethodInfo GetMethod(Type type, string methodName, Type[] argTypes, AccessLevels level, bool ignoreCase = false, bool optionalBinding = false)
	{
		return GetMethods(type, methodName, argTypes, level, ignoreCase, optionalBinding).FirstOrDefault();
	}

	/// <summary>
	/// 获取当前类型中指定访问级别的方法
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="flags">获取的方法的绑定条件</param>
	/// <returns>当前类型中符合条件的方法</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	public static MethodInfo[] GetMethods(Type type, BindingFlags flags)
	{
		Guard.AssertNotNull(type, "type");
		return type.GetMethods(flags);
	}

	/// <summary>
	/// 获取当前类型中指定访问级别的方法
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="level">获取的方法的访问级别</param>
	/// <returns>当前类型中符合条件的方法</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	public static MethodInfo[] GetMethods(Type type, AccessLevels level)
	{
		Guard.AssertNotNull(type, "type");
		return (from x in type.GetMethods(EnumHelper.ToBindingFlags(level))
			where EnumHelper.HasLevel(GetAccessLevel(x), level)
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
	public static MethodInfo[] GetMethods(Type type, Func<MethodInfo, bool> predicate, BindingFlags flags = BindingFlags.Instance | BindingFlags.Public)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNull(predicate, "predicate");
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
	public static MethodInfo[] GetMethods(Type type, Func<MethodInfo, bool> predicate, AccessLevels level)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNull(predicate, "predicate");
		return GetMethods(type, level).Where(predicate).ToArray();
	}

	/// <summary>
	/// 获取当前类型中与参数类型数组匹配的公共实例方法
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="argTypes">参数类型数组</param>
	/// <returns>当前类型中符合条件的方法</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者参数类型数组 <paramref name="argTypes" /> 为空。</exception>
	public static MethodInfo[] GetMethods(Type type, params Type[] argTypes)
	{
		Guard.AssertNotNull(type, "type");
		return GetMethods(type, argTypes, optionalBinding: false);
	}

	/// <summary>
	/// 获取当前类型中与参数类型数组匹配的公共实例方法
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="argTypes">参数类型数组</param>
	/// <param name="optionalBinding">对于方法的可选参数是否也必须进行绑定</param>
	/// <returns>当前类型中符合条件的方法</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者参数类型数组 <paramref name="argTypes" /> 为空。</exception>
	public static MethodInfo[] GetMethods(Type type, Type[] argTypes, bool optionalBinding)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNull(argTypes, "argument types");
		return GetMethods(type, argTypes, BindingFlags.Instance | BindingFlags.Public, optionalBinding);
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
	public static MethodInfo[] GetMethods(Type type, Type[] argTypes, BindingFlags flags, bool optionalBinding = false)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNull(argTypes, "argument types");
		return (from x in type.GetMethods(flags)
			where IsBindable(x, argTypes, optionalBinding)
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
	public static MethodInfo[] GetMethods(Type type, Type[] argTypes, AccessLevels level, bool optionalBinding = false)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNull(argTypes, "argument types");
		return (from x in GetMethods(type, level)
			where IsBindable(x, argTypes, optionalBinding)
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
	public static MethodInfo[] GetMethods(Type type, string methodName, bool ignoreCase = false)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNullAndEmpty(methodName, "method name");
		return (from x in type.GetMethods(BindingFlags.Instance | BindingFlags.Public)
			where TextHelper.EqualOrdinal(x.Name, methodName, ignoreCase)
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
	public static MethodInfo[] GetMethods(Type type, string methodName, BindingFlags flags, bool ignoreCase = false)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNullAndEmpty(methodName, "method name");
		return (from x in type.GetMethods(flags)
			where TextHelper.EqualOrdinal(x.Name, methodName, ignoreCase)
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
	public static MethodInfo[] GetMethods(Type type, string methodName, AccessLevels level, bool ignoreCase = false)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNullAndEmpty(methodName, "method name");
		return (from x in GetMethods(type, level)
			where TextHelper.EqualOrdinal(x.Name, methodName, ignoreCase)
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
	public static MethodInfo[] GetMethods(Type type, string methodName, params Type[] argTypes)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNullAndEmpty(methodName, "method name");
		return GetMethods(type, methodName, argTypes, ignoreCase: false, optionalBinding: false);
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
	public static MethodInfo[] GetMethods(Type type, string methodName, Type[] argTypes, bool ignoreCase = false, bool optionalBinding = false)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNullAndEmpty(methodName, "method name");
		Guard.AssertNotNull(argTypes, "argument types");
		return (from x in type.GetMethods(BindingFlags.Instance | BindingFlags.Public)
			where TextHelper.EqualOrdinal(x.Name, methodName, ignoreCase) && IsBindable(x, argTypes, optionalBinding)
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
	public static MethodInfo[] GetMethods(Type type, string methodName, Type[] argTypes, BindingFlags flags, bool ignoreCase = false, bool optionalBinding = false)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNullAndEmpty(methodName, "method name");
		Guard.AssertNotNull(argTypes, "argument types");
		return (from x in type.GetMethods(flags)
			where TextHelper.EqualOrdinal(x.Name, methodName, ignoreCase) && IsBindable(x, argTypes, optionalBinding)
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
	public static MethodInfo[] GetMethods(Type type, string methodName, Type[] argTypes, AccessLevels level, bool ignoreCase = false, bool optionalBinding = false)
	{
		Guard.AssertNotNullAndEmpty(methodName, "method name");
		Guard.AssertNotNull(argTypes, "argument types");
		return (from x in GetMethods(type, level)
			where TextHelper.EqualOrdinal(x.Name, methodName, ignoreCase) && IsBindable(x, argTypes, optionalBinding)
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
	public static MethodInfo[] GetMethods(Type type, Regex pattern, BindingFlags flags = BindingFlags.Instance | BindingFlags.Public)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNull(pattern, "method name pattern");
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
	public static MethodInfo[] GetMethods(Type type, Regex pattern, AccessLevels level)
	{
		Guard.AssertNotNull(pattern, "method name pattern");
		return (from x in GetMethods(type, level)
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
	public static MethodInfo[] GetMethods(Type type, Type attributeType, bool inherit = false)
	{
		return GetMethods(type, attributeType, BindingFlags.Instance | BindingFlags.Public, inherit);
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
	public static MethodInfo[] GetMethods(Type type, Type attributeType, BindingFlags flags, bool inherit = false)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNull(attributeType, "attribute type");
		Guard.AssertInheritedType<Attribute>(attributeType, "attribute type");
		return (from c in type.GetMethods(flags)
			where HasCustomAttribute(c, attributeType, inherit)
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
	public static MethodInfo[] GetMethods(Type type, Type attributeType, AccessLevels level, bool inherit = false)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNull(attributeType, "attribute type");
		Guard.AssertInheritedType<Attribute>(attributeType, "attribute type");
		return (from c in GetMethods(type, level)
			where HasCustomAttribute(c, attributeType, inherit)
			select c).ToArray();
	}

	/// <summary>
	/// 获取当前类型的名称。该名称遵循C#语法。
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="nestedName">如果当前类型是嵌套类，是否获取嵌套的名称。</param>
	/// <returns>遵循C#语法的当前类型名称，类型名称不包括命名空间和程序集的名称。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型null。</exception>
	public static string GetName(Type type, bool nestedName = false)
	{
		Guard.AssertNotNull(type, "type");
		StringBuilder buff = new StringBuilder();
		if (type.IsNested && nestedName)
		{
			buff.Append(GetName(type.DeclaringType, nestedName: true)).Append("+");
		}
		if (type.IsGenericType)
		{
			buff.Append(type.Name.Remove(type.Name.IndexOf("`")));
			buff.Append("<");
			Type[] genericArguments = type.GetGenericArguments();
			foreach (Type genericType in genericArguments)
			{
				buff.Append(GetName(genericType, nestedName)).Append(",");
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
	public static Type GetNestedType(Type type, string typeName, bool ignoreCase)
	{
		return type.GetNestedType(typeName, EnumHelper.Combine(BindingFlags.Instance | BindingFlags.Public, ignoreCase));
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
	public static Type GetNestedType(Type type, string typeName, BindingFlags flags, bool ignoreCase = false)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNullAndEmpty(typeName, "type name");
		return type.GetNestedType(typeName, EnumHelper.Combine(flags, ignoreCase));
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
	public static Type GetNestedType(Type type, string typeName, AccessLevels level, bool ignoreCase = false)
	{
		Guard.AssertNotNullAndEmpty(typeName, "type name");
		return (from x in GetNestedTypes(type, level)
			where TextHelper.EqualOrdinal(x.Name, typeName, ignoreCase)
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
	public static Type GetNestedTypeByPath(Type type, string typePath, bool ignoreCase = false)
	{
		return GetNestedTypeByPath(type, typePath, BindingFlags.Instance | BindingFlags.Public, ignoreCase);
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
	public static Type GetNestedTypeByPath(Type type, string typePath, BindingFlags flags, bool ignoreCase = false)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNullAndEmpty(typePath, "type path");
		string[] typeNames = typePath.Split(new char[1] { '.' }, StringSplitOptions.None);
		string[] array = typeNames;
		foreach (string typeName in array)
		{
			type = GetNestedType(type, typeName, flags, ignoreCase);
			if (ObjectHelper.IsNull(type))
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
	public static Type GetNestedTypeByPath(Type type, string typePath, AccessLevels level, bool ignoreCase = false)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNullAndEmpty(typePath, "type path");
		string[] typeNames = typePath.Split(new char[1] { '.' }, StringSplitOptions.None);
		string[] array = typeNames;
		foreach (string typeName in array)
		{
			type = GetNestedType(type, typeName, level, ignoreCase);
			if (ObjectHelper.IsNull(type))
			{
				return null;
			}
		}
		return type;
	}

	/// <summary>
	/// 获取当前类型中符合绑定条件的嵌套类型
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="flags">当前类型中嵌套类型的绑定条件</param>
	/// <returns>当前类型中符合绑定条件的嵌套类型</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	public static Type[] GetNestedTypes(Type type, BindingFlags flags)
	{
		Guard.AssertNotNull(type, "type");
		return type.GetNestedTypes(flags);
	}

	/// <summary>
	/// 获取当前类型中指定访问级别的嵌套类型
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="level">获取的嵌套类型的访问级别</param>
	/// <returns>当前类型中符合条件的当前类型</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	public static Type[] GetNestedTypes(Type type, AccessLevels level)
	{
		Guard.AssertNotNull(type, "type");
		return (from x in type.GetNestedTypes(EnumHelper.ToBindingFlags(level))
			where EnumHelper.HasLevel(GetAccessLevel(x), level)
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
	public static Type[] GetNestedTypes(Type type, Func<Type, bool> predicate, BindingFlags flags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNull(predicate, "predicate");
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
	public static Type[] GetNestedTypes(Type type, Func<Type, bool> predicate, AccessLevels level)
	{
		Guard.AssertNotNull(predicate, "predicate");
		return GetNestedTypes(type, level).Where(predicate).ToArray();
	}

	/// <summary>
	/// 获取当前类型中满足绑定条件和名称正则模式的嵌套类型
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="pattern">嵌套类型名称的正则模式</param>
	/// <param name="flags">嵌套类型绑定搜索标志</param>
	/// <returns>当前类型中符合条件的嵌套类型</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者嵌套类型名称的正则模式 <paramref name="pattern" /> 为空。</exception>
	public static Type[] GetNestedTypes(Type type, Regex pattern, BindingFlags flags = BindingFlags.Instance | BindingFlags.Public)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNull(pattern, "field name pattern");
		return (from x in GetNestedTypes(type, flags)
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
	public static Type[] GetNestedTypes(Type type, Regex pattern, AccessLevels level)
	{
		Guard.AssertNotNull(pattern, "event name pattern");
		return (from x in GetNestedTypes(type, level)
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
	public static Type[] GetNestedTypes(Type type, Type attributeType, bool inherit = false)
	{
		return GetNestedTypes(type, attributeType, BindingFlags.Instance | BindingFlags.Public, inherit);
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
	public static Type[] GetNestedTypes(Type type, Type attributeType, BindingFlags flags, bool inherit = false)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNull(attributeType, "attribute type");
		Guard.AssertInheritedType<Attribute>(attributeType, "attribute type");
		return (from c in type.GetNestedTypes(flags)
			where HasCustomAttribute(c, attributeType, inherit)
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
	public static Type[] GetNestedTypes(Type type, Type attributeType, AccessLevels level, bool inherit = false)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNull(attributeType, "attribute type");
		Guard.AssertInheritedType<Attribute>(attributeType, "attribute type");
		return (from c in GetNestedTypes(type, level)
			where HasCustomAttribute(c, attributeType, inherit)
			select c).ToArray();
	}

	/// <summary>
	/// 获取当前类型中指定绑定条件的属性
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="flags">获取属性的绑定条件</param>
	/// <returns>当前类型中符合绑定条件的属性</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	public static PropertyInfo[] GetProperties(Type type, BindingFlags flags)
	{
		Guard.AssertNotNull(type);
		return type.GetProperties(flags);
	}

	/// <summary>
	/// 获取当前类型中指定访问级别的属性
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="level">获取的属性的访问级别</param>
	/// <returns>当前类型中符合条件的属性</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	public static PropertyInfo[] GetProperties(Type type, AccessLevels level)
	{
		Guard.AssertNotNull(type, "type");
		return (from x in type.GetProperties(EnumHelper.ToBindingFlags(level))
			where EnumHelper.HasLevel(GetAccessLevel(x), level)
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
	public static PropertyInfo[] GetProperties(Type type, Func<PropertyInfo, bool> predicate, BindingFlags flags = BindingFlags.Instance | BindingFlags.Public)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNull(predicate, "predicate");
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
	public static PropertyInfo[] GetProperties(Type type, Func<PropertyInfo, bool> predicate, AccessLevels level)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNull(predicate, "predicate");
		return GetProperties(type, level).Where(predicate).ToArray();
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
	public static PropertyInfo[] GetProperties(Type type, Type returnType, Type[] argTypes, bool inheritBinding = false, bool optionalBinding = false)
	{
		Guard.AssertNotNull(type, "type");
		return GetProperties(type, returnType, argTypes, BindingFlags.Instance | BindingFlags.Public, optionalBinding);
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
	public static PropertyInfo[] GetProperties(Type type, Type returnType, Type[] argTypes, BindingFlags flags, bool inheritBinding = false, bool optionalBinding = false)
	{
		Guard.AssertNotNull(type, "type");
		return (from x in type.GetProperties(flags)
			where IsBindable(x, returnType, argTypes, inheritBinding, optionalBinding)
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
	public static PropertyInfo[] GetProperties(Type type, Type returnType, Type[] argTypes, AccessLevels level, bool inheritBinding = false, bool optionalBinding = false)
	{
		Guard.AssertNotNull(type, "type");
		return (from x in GetProperties(type, level)
			where IsBindable(x, returnType, argTypes, inheritBinding, optionalBinding)
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
	public static PropertyInfo[] GetProperties(Type type, Regex pattern, BindingFlags flags = BindingFlags.Instance | BindingFlags.Public)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNull(pattern, "property name pattern");
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
	public static PropertyInfo[] GetProperties(Type type, Regex pattern, AccessLevels level)
	{
		Guard.AssertNotNull(pattern, "property name pattern");
		return (from x in GetProperties(type, level)
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
	public static PropertyInfo[] GetProperties(Type type, Type attributeType, bool inherit = false)
	{
		return GetProperties(type, attributeType, BindingFlags.Instance | BindingFlags.Public, inherit);
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
	public static PropertyInfo[] GetProperties(Type type, Type attributeType, BindingFlags flags, bool inherit = false)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNull(attributeType, "attribute type");
		Guard.AssertInheritedType<Attribute>(attributeType, "attribute type");
		return (from c in type.GetProperties(flags)
			where HasCustomAttribute(c, attributeType, inherit)
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
	public static PropertyInfo[] GetProperties(Type type, Type attributeType, AccessLevels level, bool inherit = false)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNull(attributeType, "attribute type");
		Guard.AssertInheritedType<Attribute>(attributeType, "attribute type");
		return (from c in GetProperties(type, level)
			where HasCustomAttribute(c, attributeType, inherit)
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
	public static PropertyInfo GetProperty(Type type, string propertyName, bool ignoreCase)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNullAndEmpty(propertyName, "property name");
		return type.GetProperty(propertyName, EnumHelper.Combine(BindingFlags.Instance | BindingFlags.Public, ignoreCase));
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
	public static PropertyInfo GetProperty(Type type, string propertyName, BindingFlags flags, bool ignoreCase = false)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNullAndEmpty(propertyName, "property name");
		return type.GetProperty(propertyName, EnumHelper.Combine(flags, ignoreCase));
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
	public static PropertyInfo GetProperty(Type type, string propertyName, AccessLevels level, bool ignoreCase = false)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNullAndEmpty(propertyName, "property name");
		return (from x in GetProperties(type, level)
			where TextHelper.EqualOrdinal(x.Name, propertyName, ignoreCase)
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
	public static PropertyInfo GetProperty(Type type, string propertyName, Type returnType, bool ignoreCase = false, bool inheritBinding = false)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNullAndEmpty(propertyName, "property name");
		return GetProperty(type, propertyName, returnType, BindingFlags.Instance | BindingFlags.Public, ignoreCase, inheritBinding);
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
	public static PropertyInfo GetProperty(Type type, string propertyName, Type returnType, BindingFlags flags, bool ignoreCase = false, bool inheritBinding = false)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNullAndEmpty(propertyName, "property name");
		PropertyInfo pinfo = GetProperty(type, propertyName, flags, ignoreCase);
		return IsBindable(pinfo, returnType, null, inheritBinding) ? pinfo : null;
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
	public static PropertyInfo GetProperty(Type type, string propertyName, Type returnType, AccessLevels level, bool ignoreCase = false, bool inheritBinding = false)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNullAndEmpty(propertyName, "property name");
		PropertyInfo pinfo = GetProperty(type, propertyName, level, ignoreCase);
		return IsBindable(pinfo, returnType, null, inheritBinding) ? pinfo : null;
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
	public static PropertyInfo GetProperty(Type type, string propertyName, Type[] argTypes, bool ignoreCase = false, bool optionalBinding = false)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNullAndEmpty(propertyName, "property name");
		return GetProperty(type, propertyName, argTypes, BindingFlags.Instance | BindingFlags.Public, ignoreCase, optionalBinding);
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
	public static PropertyInfo GetProperty(Type type, string propertyName, Type[] argTypes, BindingFlags flags, bool ignoreCase = false, bool optionalBinding = false)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNullAndEmpty(propertyName, "property name");
		PropertyInfo pinfo = GetProperty(type, propertyName, flags, ignoreCase);
		return IsBindable(pinfo, null, argTypes, inheritBinding: false, optionalBinding) ? pinfo : null;
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
	public static PropertyInfo GetProperty(Type type, string propertyName, Type[] argTypes, AccessLevels level, bool ignoreCase = false, bool optionalBinding = false)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNullAndEmpty(propertyName, "property name");
		PropertyInfo pinfo = GetProperty(type, propertyName, level, ignoreCase);
		return IsBindable(pinfo, null, argTypes, inheritBinding: false, optionalBinding) ? pinfo : null;
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
	public static PropertyInfo GetProperty(Type type, string propertyName, Type returnType, Type[] argTypes, bool ignoreCase = false, bool inheritBinding = false, bool optionalBinding = false)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNullAndEmpty(propertyName, "property name");
		return GetProperty(type, propertyName, returnType, argTypes, BindingFlags.Instance | BindingFlags.Public, ignoreCase, inheritBinding, optionalBinding);
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
	public static PropertyInfo GetProperty(Type type, string propertyName, Type returnType, Type[] argTypes, BindingFlags flags, bool ignoreCase = false, bool inheritBinding = false, bool optionalBinding = false)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNullAndEmpty(propertyName, "property name");
		PropertyInfo pinfo = GetProperty(type, propertyName, flags, ignoreCase);
		return IsBindable(pinfo, returnType, argTypes, inheritBinding, optionalBinding) ? pinfo : null;
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
	public static PropertyInfo GetProperty(Type type, string propertyName, Type returnType, Type[] argTypes, AccessLevels level, bool ignoreCase = false, bool inheritBinding = false, bool optionalBinding = false)
	{
		PropertyInfo pinfo = GetProperty(type, propertyName, level, ignoreCase);
		return IsBindable(pinfo, returnType, argTypes, inheritBinding, optionalBinding) ? pinfo : null;
	}

	/// <summary>
	/// 按照属性路径在当前类型中获取公共实例属性
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="propertyPath">属性路径</param>
	/// <param name="ignoreCase">属性名称是否区分大小写</param>
	/// <returns>匹配的属性，如果不存在匹配的属性返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者属性路径 <paramref name="propertyPath" /> 为空或者空串。</exception>
	public static PropertyInfo GetPropertyByPath(Type type, string propertyPath, bool ignoreCase = false)
	{
		return GetPropertyByPath(type, propertyPath, BindingFlags.Instance | BindingFlags.Public, ignoreCase);
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
	public static PropertyInfo GetPropertyByPath(Type type, string propertyPath, BindingFlags flags, bool ignoreCase = false)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNullAndEmpty(propertyPath, "property path");
		string[] propertyNames = propertyPath.Split(new char[1] { '.' }, StringSplitOptions.None);
		PropertyInfo property = null;
		string[] array = propertyNames;
		foreach (string propertyName in array)
		{
			property = GetProperty(type, propertyName, flags, ignoreCase);
			if (ObjectHelper.IsNull(property))
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
	public static PropertyInfo GetPropertyByPath(Type type, string propertyPath, AccessLevels level, bool ignoreCase = false)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNullAndEmpty(propertyPath, "property path");
		string[] propertyNames = propertyPath.Split(new char[1] { '.' }, StringSplitOptions.None);
		PropertyInfo property = null;
		string[] array = propertyNames;
		foreach (string propertyName in array)
		{
			property = GetProperty(type, propertyName, level, ignoreCase);
			if (ObjectHelper.IsNull(property))
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
	public static Type GetPropertyType(Type type, string propertyPath, bool ignoreCase = false)
	{
		return GetPropertyType(type, propertyPath, BindingFlags.Instance | BindingFlags.Public, ignoreCase);
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
	public static Type GetPropertyType(Type type, string propertyPath, BindingFlags flags, bool ignoreCase = false)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNullAndEmpty(propertyPath, "property path");
		PropertyInfo pinfo = GetProperty(type, propertyPath, flags, ignoreCase);
		return ObjectHelper.IsNull(pinfo) ? null : pinfo.PropertyType;
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
	public static Type GetPropertyType(Type type, string propertyPath, AccessLevels level, bool ignoreCase = false)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNullAndEmpty(propertyPath, "property path");
		PropertyInfo pinfo = GetProperty(type, propertyPath, level, ignoreCase);
		return ObjectHelper.IsNull(pinfo) ? null : pinfo.PropertyType;
	}

	/// <summary>
	/// 获取当前类型的命名空间限定名称。该名称遵循C#语法。
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <returns>遵循C#语法的当前类型命名空间限定名称</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	public static string GetFullName(Type type)
	{
		Guard.AssertNotNull(type, "type");
		StringBuilder buff = new StringBuilder();
		buff.Append(type.Namespace).Append(".");
		if (type.IsNested)
		{
			buff.Append(GetName(type.DeclaringType, nestedName: true)).Append("+");
		}
		if (type.IsGenericType)
		{
			buff.Append(type.Name.Remove(type.Name.IndexOf("`")));
			buff.Append("<");
			Type[] genericArguments = type.GetGenericArguments();
			foreach (Type genericType in genericArguments)
			{
				buff.Append(GetFullName(genericType)).Append(", ");
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
	/// 获取当前程序集完全名称
	/// </summary>
	/// <param name="assembly">当前程序集</param>
	/// <returns>获取的程序集完全名称。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前程序集为空。</exception>
	public static string GetFullName(Assembly assembly)
	{
		Guard.AssertNotNull(assembly, "assembly");
		return assembly.GetName().FullName;
	}

	/// <summary>
	/// 获取当前静态字段的字段值
	/// </summary>
	/// <param name="finfo">当前静态字段</param>
	/// <returns>获取的字段值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前静态字段为空。</exception>
	public static object GetValue(FieldInfo finfo)
	{
		Guard.AssertNotNull(finfo, "field info");
		return finfo.GetValue(null);
	}

	/// <summary>
	/// 获取当前字段的字段值
	/// </summary>
	/// <param name="finfo">当前字段</param>
	/// <param name="handler">当前字段关联的对象实例</param>
	/// <returns>获取的字段值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字段为空。</exception>
	public static object GetValue(FieldInfo finfo, object handler)
	{
		Guard.AssertNotNull(finfo, "field info");
		return finfo.GetValue(handler);
	}

	/// <summary>
	/// 获取当前静态字段的字段值
	/// </summary>
	/// <typeparam name="T">获取的字段值类型</typeparam>
	/// <param name="finfo">当前静态字段</param>
	/// <returns>获取的字段值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前静态字段为空。</exception>
	public static T GetValue<T>(FieldInfo finfo)
	{
		return ConvertHelper.Cast<T>(GetValue(finfo));
	}

	/// <summary>
	/// 获取当前字段的字段值
	/// </summary>
	/// <typeparam name="T">获取的字段值类型</typeparam>
	/// <param name="finfo">当前字段</param>
	/// <param name="handler">当前字段关联的对象实例</param>
	/// <returns>获取的字段值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字段为空。</exception>
	public static T GetValue<T>(FieldInfo finfo, object handler)
	{
		return ConvertHelper.Cast<T>(GetValue(finfo, handler));
	}

	/// <summary>
	/// 获取当前静态属性的属性值
	/// </summary>
	/// <param name="pinfo">当前静态属性</param>
	/// <returns>当前静态属性的属性值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前静态属性为空。</exception>
	public static object GetValue(PropertyInfo pinfo)
	{
		Guard.EnsureNotNull(pinfo, "property info");
		return pinfo.GetValue(null, null);
	}

	/// <summary>
	/// 获取当前属性的属性值
	/// </summary>
	/// <param name="pinfo">当前属性</param>
	/// <param name="handler">当前属性关联的实例对象；如果当前属性为静态属性，则该参数需要设置为空</param>
	/// <returns>实例对象的属性值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前属性为空。</exception>
	public static object GetValue(PropertyInfo pinfo, object handler)
	{
		Guard.EnsureNotNull(pinfo, "property info");
		return pinfo.GetValue(handler, null);
	}

	/// <summary>
	/// 获取当前静态属性的属性值
	/// </summary>
	/// <typeparam name="T">当前属性值类型</typeparam>
	/// <param name="pinfo">当前静态属性</param>
	/// <returns>当前静态属性的属性值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前静态属性为空。</exception>
	public static T GetValue<T>(PropertyInfo pinfo)
	{
		return ConvertHelper.Cast<T>(GetValue(pinfo));
	}

	/// <summary>
	/// 获取当前属性的属性值
	/// </summary>
	/// <typeparam name="T">当前属性值类型</typeparam>
	/// <param name="pinfo">当前属性</param>
	/// <param name="handler">当前属性关联的实例对象；如果当前属性为静态属性，则该参数需要设置为空</param>
	/// <returns>实例对象的属性值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前属性为空。</exception>
	public static T GetValue<T>(PropertyInfo pinfo, object handler)
	{
		return ConvertHelper.Cast<T>(GetValue(pinfo, handler));
	}

	/// <summary>
	/// 获取当前程序集的版本号
	/// </summary>
	/// <param name="assembly">当前程序集</param>
	/// <returns>获取的程序集版本号</returns>
	/// <exception cref="T:System.ArgumentNullException">当前程序集为空。</exception>
	public static Version GetVersion(Assembly assembly)
	{
		Guard.AssertNotNull(assembly, "assembly");
		return assembly.GetName().Version;
	}

	/// <summary>
	/// 获取当前程序集的版本完整字符表达式
	/// </summary>
	/// <param name="assembly">当前程序集</param>
	/// <returns>获取的程序集版本号</returns>
	/// <exception cref="T:System.ArgumentNullException">当前程序集为空。</exception>
	public static string GetFullVersion(Assembly assembly)
	{
		return GetVersion(assembly).ToString(4);
	}

	/// <summary>
	/// 获取当前程序集的版本简短字符表达式
	/// </summary>
	/// <param name="assembly">当前程序集</param>
	/// <returns>获取的程序集版本号</returns>
	/// <exception cref="T:System.ArgumentNullException">当前程序集为空。</exception>
	public static string GetShortVersion(Assembly assembly)
	{
		return GetVersion(assembly).ToString(2);
	}

	/// <summary>
	/// 从当前的程序集中获取满足指定条件的类型
	/// </summary>
	/// <param name="assembly">当前程序集</param>
	/// <param name="predicate">类型筛选条件</param>
	/// <returns>返回当前程序集中符合条件的所有类型</returns>
	/// <exception cref="T:System.ArgumentNullException">当前程序集为空；<paramref name="predicate" /> 为空。</exception>
	public static Type[] GetTypes(Assembly assembly, Func<Type, bool> predicate)
	{
		Guard.AssertNotNull(assembly, "assembly");
		Guard.AssertNotNull(predicate, "predicate");
		return assembly.GetTypes().Where(predicate).ToArray();
	}

	/// <summary>
	/// 从当前的程序集中获取等于指定类型或者以指定类型为基类的类型
	/// </summary>
	/// <param name="assembly">当前程序集</param>
	/// <param name="baseType">类型的基类</param>
	/// <returns>当前程序集中与指定的基类类型相同或者是该基类的子类的所有类型的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前程序集为空；<paramref name="baseType" /> 为空。</exception>
	public static Type[] GetTypes(Assembly assembly, Type baseType)
	{
		Guard.AssertNotNull(assembly, "assembly");
		Guard.AssertNotNull(baseType, "base type");
		return WhereInheritedType(assembly.GetTypes(), baseType).ToArray();
	}

	/// <summary>
	/// 从当前的程序集中获取以指定类型或者以指定类型为基类的类型
	/// </summary>
	/// <typeparam name="T">指定的类型基类</typeparam>
	/// <param name="assembly">当前程序集</param>
	/// <returns>当前程序集中与指定的基类类型相同或者是该基类的子类的所有类型的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前程序集为空。</exception>
	public static Type[] GetTypes<T>(Assembly assembly)
	{
		Guard.AssertNotNull(assembly, "assembly");
		return WhereInheritedType<T>(assembly.GetTypes()).ToArray();
	}

	/// <summary>
	/// 从当前程序集中获取以指定类型为基类且满足指定条件的类型
	/// </summary>
	/// <typeparam name="T">指定的类型基类</typeparam>
	/// <param name="assembly">当前程序集</param>
	/// <param name="predicate">类型筛选条件</param>
	/// <returns>返回指定程序集中符合条件的所有类型</returns>
	/// <exception cref="T:System.ArgumentNullException">当前程序集为空；<paramref name="predicate" /> 为空。</exception>
	public static Type[] GetTypes<T>(Assembly assembly, Func<Type, bool> predicate)
	{
		Guard.AssertNotNull(assembly, "assembly");
		Guard.AssertNotNull(predicate, "predicate");
		return WhereInheritedType<T>(assembly.GetTypes()).Where(predicate).ToArray();
	}

	/// <summary>
	/// 检测当前对象上是否定义了与特性基类型相同或者继承于该基类型的自定义特性
	/// </summary>
	/// <param name="provider">当前对象</param>
	/// <param name="attributeType">自定义特性的基类型</param>
	/// <param name="inherit">是否从当前对象的继承结构中获取自定义特性</param>
	/// <returns>如果定义了符合条件的特性返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者自定义特性的基类型 <paramref name="attributeType" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">自定义特性的基类型 <paramref name="attributeType" /> 不是从 <see cref="T:System.Attribute" /> 继承的。</exception>
	public static bool HasCustomAttribute(ICustomAttributeProvider provider, Type attributeType, bool inherit = false)
	{
		Guard.AssertNotNull(provider, "attribute provider");
		Guard.AssertNotNull(attributeType, "attribute type");
		return provider.IsDefined(attributeType, inherit);
	}

	/// <summary>
	/// 检测当前对象上是否定义了与特性基类型相同或者继承于该基类型的自定义特性
	/// </summary>
	/// <typeparam name="T">自定义特性的基类型</typeparam>
	/// <param name="provider">当前对象</param>
	/// <param name="inherit">是否从当前对象的继承结构中获取自定义特性</param>
	/// <returns>如果定义了符合条件的特性返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前反射的对象为空。</exception>
	public static bool HasCustomAttribute<T>(ICustomAttributeProvider provider, bool inherit = false) where T : Attribute
	{
		Guard.AssertNotNull(provider, "attribute provider");
		return provider.IsDefined(typeof(T), inherit);
	}

	/// <summary>
	/// 检测当前类型是否实现了指定类型的接口
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="interfaceType">接口类型</param>
	/// <returns>如果当前类型实现了指定类型的接口返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者指定的接口类型 <paramref name="interfaceType" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">指定的类型 <paramref name="interfaceType" /> 不是接口。</exception>
	public static bool HasInterface(Type type, Type interfaceType)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNull(interfaceType, "interface type");
		Guard.Assert(interfaceType, (Type x) => x.IsInterface, "interface type");
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
	public static bool HasInterface<T>(Type type)
	{
		return HasInterface(type, typeof(T));
	}

	/// <summary>
	/// 使用指定的参数值调用当前方法
	/// </summary>
	/// <param name="method">当前方法</param>
	/// <param name="obj">调用当前方法的对象</param>
	/// <param name="args">用于方法调用的参数数组</param>
	/// <returns>被调用方法的返回值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前方法为空。</exception>
	/// <exception cref="T:System.Reflection.TargetException">当前方法为实例方法，而调用对象 <paramref name="obj" /> 为空。</exception>
	public static object Invoke(MethodBase method, object obj, params object[] args)
	{
		return Invoke(method, obj, args, optionalBinding: false);
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
	public static object Invoke(MethodBase method, object obj, object[] args, bool optionalBinding)
	{
		return Invoke(method, obj, null, args, optionalBinding);
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
	public static object Invoke(MethodBase method, object obj, NamedValue[] namedArgs, bool optionalBinding = false)
	{
		if (ObjectHelper.IsNull(namedArgs))
		{
			return Invoke(method, obj, null, null, optionalBinding);
		}
		return Invoke(method, obj, namedArgs.Select((NamedValue x) => x.Name).ToArray(), namedArgs.Select((NamedValue x) => x.Value).ToArray(), optionalBinding);
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
	public static object Invoke(MethodBase method, object obj, IDictionary<string, object> namedArgs, bool optionalBinding = false)
	{
		if (ObjectHelper.IsNull(namedArgs))
		{
			return Invoke(method, obj, null, null, optionalBinding);
		}
		Tuple<string[], object[]> pairs = CollectionHelper.GetKeyValues(namedArgs);
		return Invoke(method, obj, pairs.Item1, pairs.Item2, optionalBinding);
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
	public static object Invoke(MethodBase method, object obj, string[] names, object[] values, bool optionalBinding = false)
	{
		Guard.AssertNotNull(method, "method");
		if (ObjectHelper.IsNotNull(names))
		{
			Guard.AssertNotNull(values, "values");
		}
		BindingFlags flags = EnumHelper.Combine(BindingFlags.Default, IgnoreCase: false, DeclaredOnly: false, Instance: false, Static: false, Public: false, NonPublic: false, FlattenHierarchy: false, InvokeMethod: false, CreateInstance: false, GetField: false, SetField: false, GetProperty: false, SetProperty: false, PutDispProperty: false, PutRefDispProperty: false, ExactBinding: false, SuppressChangeType: false, optionalBinding);
		method = Type.DefaultBinder.BindToMethod(flags, new MethodBase[1] { method }, ref values, null, null, names, out var state);
		object result = method.Invoke(obj, values);
		Type.DefaultBinder.ReorderArgumentArray(ref values, state);
		return result;
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
	public static object InvokeConstructor(Type type, params object[] args)
	{
		return InvokeConstructor(type, null, args, BindingFlags.Instance | BindingFlags.Public);
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
	public static object InvokeConstructor(Type type, object[] args, bool optionalBinding)
	{
		return InvokeConstructor(type, null, args, BindingFlags.Instance | BindingFlags.Public, optionalBinding);
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
	public static object InvokeConstructor(Type type, object[] args, BindingFlags flags, bool optionalBinding = false)
	{
		return InvokeConstructor(type, null, args, flags, optionalBinding);
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
	public static object InvokeConstructor(Type type, object[] args, AccessLevels level, bool optionalBinding = false)
	{
		return InvokeConstructor(type, null, args, level, optionalBinding);
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
	public static object InvokeConstructor(Type type, params NamedValue[] namedArgs)
	{
		return InvokeConstructor(type, namedArgs, BindingFlags.Instance | BindingFlags.Public);
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
	public static object InvokeConstructor(Type type, NamedValue[] namedArgs, bool optionalBinding)
	{
		return InvokeConstructor(type, namedArgs, BindingFlags.Instance | BindingFlags.Public, optionalBinding);
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
	public static object InvokeConstructor(Type type, NamedValue[] namedArgs, BindingFlags flags, bool optionalBinding = false)
	{
		if (ObjectHelper.IsNull(namedArgs))
		{
			return InvokeConstructor(type, null, null, flags, optionalBinding);
		}
		return InvokeConstructor(type, namedArgs.Select((NamedValue n) => n.Name).ToArray(), namedArgs.Select((NamedValue n) => n.Value).ToArray(), flags, optionalBinding);
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
	public static object InvokeConstructor(Type type, NamedValue[] namedArgs, AccessLevels level, bool optionalBinding = false)
	{
		if (ObjectHelper.IsNull(namedArgs))
		{
			return InvokeConstructor(type, null, null, level, optionalBinding);
		}
		return InvokeConstructor(type, namedArgs.Select((NamedValue n) => n.Name).ToArray(), namedArgs.Select((NamedValue n) => n.Value).ToArray(), level, optionalBinding);
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
	public static object InvokeConstructor(Type type, IDictionary<string, object> namedArgs, bool optionalBinding = false)
	{
		return InvokeConstructor(type, namedArgs, BindingFlags.Instance | BindingFlags.Public, optionalBinding);
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
	public static object InvokeConstructor(Type type, IDictionary<string, object> namedArgs, BindingFlags flags, bool optionalBinding = false)
	{
		if (ObjectHelper.IsNull(namedArgs))
		{
			return InvokeConstructor(type, null, null, flags, optionalBinding);
		}
		Tuple<string[], object[]> pairs = CollectionHelper.GetKeyValues(namedArgs);
		return InvokeConstructor(type, pairs.Item1, pairs.Item2, flags, optionalBinding);
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
	public static object InvokeConstructor(Type type, IDictionary<string, object> namedArgs, AccessLevels level, bool optionalBinding = false)
	{
		if (ObjectHelper.IsNull(namedArgs))
		{
			return InvokeConstructor(type, null, null, level, optionalBinding);
		}
		Tuple<string[], object[]> pairs = CollectionHelper.GetKeyValues(namedArgs);
		return InvokeConstructor(type, pairs.Item1, pairs.Item2, level, optionalBinding);
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
	public static object InvokeConstructor(Type type, string[] names, object[] values, bool optionalBinding = false)
	{
		return InvokeConstructor(type, names, values, BindingFlags.Instance | BindingFlags.Public, optionalBinding);
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
	public static object InvokeConstructor(Type type, string[] names, object[] values, BindingFlags flags, bool optionalBinding = false)
	{
		Guard.AssertNotNull(type, "type");
		if (ObjectHelper.IsNotNull(names))
		{
			Guard.AssertNotNull(values, "values");
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
	public static object InvokeConstructor(Type type, string[] names, object[] values, AccessLevels level, bool optionalBinding = false)
	{
		Guard.AssertNotNull(type, "type");
		if (ObjectHelper.IsNotNull(names))
		{
			Guard.AssertNotNull(values, "values");
		}
		ConstructorInfo[] cinfos = GetConstructors(type, level);
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
	public static object InvokeMethod(Type type, string methodName, object obj, params object[] args)
	{
		return InvokeMethod(type, methodName, obj, null, args, BindingFlags.Instance | BindingFlags.Public);
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
	public static object InvokeMethod(Type type, string methodName, object obj, object[] args, bool ignoreCase = false, bool optionalBinding = false)
	{
		return InvokeMethod(type, methodName, obj, null, args, BindingFlags.Instance | BindingFlags.Public, ignoreCase, optionalBinding);
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
	public static object InvokeMethod(Type type, string methodName, object obj, object[] args, BindingFlags flags, bool ignoreCase = false, bool optionalBinding = false)
	{
		return InvokeMethod(type, methodName, obj, null, args, flags, ignoreCase, optionalBinding);
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
	public static object InvokeMethod(Type type, string methodName, object obj, object[] args, AccessLevels level, bool ignoreCase = false, bool optionalBinding = false)
	{
		return InvokeMethod(type, methodName, obj, null, args, level, ignoreCase, optionalBinding);
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
	public static object InvokeMethod(Type type, string methodName, object obj, NamedValue[] namedArgs, bool ignoreCase = false, bool optionalBinding = false)
	{
		return InvokeMethod(type, methodName, obj, namedArgs, BindingFlags.Instance | BindingFlags.Public, ignoreCase, optionalBinding);
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
	public static object InvokeMethod(Type type, string methodName, object obj, NamedValue[] namedArgs, BindingFlags flags, bool ignoreCase = false, bool optionalBinding = false)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNullAndEmpty(methodName, "method name");
		if (ObjectHelper.IsNull(namedArgs))
		{
			return InvokeMethod(type, methodName, obj, null, null, flags, ignoreCase, optionalBinding);
		}
		return InvokeMethod(type, methodName, obj, namedArgs.Select((NamedValue n) => n.Name).ToArray(), namedArgs.Select((NamedValue n) => n.Value).ToArray(), flags, ignoreCase, optionalBinding);
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
	public static object InvokeMethod(Type type, string methodName, object obj, NamedValue[] namedArgs, AccessLevels level, bool ignoreCase = false, bool optionalBinding = false)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNullAndEmpty(methodName, "method name");
		if (ObjectHelper.IsNull(namedArgs))
		{
			return InvokeMethod(type, methodName, obj, null, null, level, ignoreCase, optionalBinding);
		}
		return InvokeMethod(type, methodName, obj, namedArgs.Select((NamedValue n) => n.Name).ToArray(), namedArgs.Select((NamedValue n) => n.Value).ToArray(), level, ignoreCase, optionalBinding);
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
	public static object InvokeMethod(Type type, string methodName, object obj, IDictionary<string, object> namedArgs, bool ignoreCase = false, bool optionalBinding = false)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNullAndEmpty(methodName, "method name");
		if (ObjectHelper.IsNull(namedArgs))
		{
			return InvokeMethod(type, methodName, obj, null, null, BindingFlags.Instance | BindingFlags.Public, ignoreCase, optionalBinding);
		}
		Tuple<string[], object[]> pairs = CollectionHelper.GetKeyValues(namedArgs);
		return InvokeMethod(type, methodName, obj, pairs.Item1, pairs.Item2, BindingFlags.Instance | BindingFlags.Public, ignoreCase, optionalBinding);
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
	public static object InvokeMethod(Type type, string methodName, object obj, IDictionary<string, object> namedArgs, BindingFlags flags, bool ignoreCase = false, bool optionalBinding = false)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNullAndEmpty(methodName, "method name");
		if (ObjectHelper.IsNull(namedArgs))
		{
			return InvokeMethod(type, methodName, obj, null, null, flags, ignoreCase, optionalBinding);
		}
		Tuple<string[], object[]> pairs = CollectionHelper.GetKeyValues(namedArgs);
		return InvokeMethod(type, methodName, obj, pairs.Item1, pairs.Item2, flags, ignoreCase, optionalBinding);
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
	public static object InvokeMethod(Type type, string methodName, object obj, IDictionary<string, object> namedArgs, AccessLevels level, bool ignoreCase = false, bool optionalBinding = false)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNullAndEmpty(methodName, "method name");
		if (ObjectHelper.IsNull(namedArgs))
		{
			return InvokeMethod(type, methodName, obj, null, null, level, ignoreCase, optionalBinding);
		}
		Tuple<string[], object[]> pairs = CollectionHelper.GetKeyValues(namedArgs);
		return InvokeMethod(type, methodName, obj, pairs.Item1, pairs.Item2, level, ignoreCase, optionalBinding);
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
	public static object InvokeMethod(Type type, string methodName, object obj, string[] names, object[] values, bool ignoreCase = false, bool optionalBinding = false)
	{
		return InvokeMethod(type, methodName, obj, names, values, BindingFlags.Instance | BindingFlags.Public, ignoreCase, optionalBinding);
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
	public static object InvokeMethod(Type type, string methodName, object obj, string[] names, object[] values, BindingFlags flags, bool ignoreCase = false, bool optionalBinding = false)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNullAndEmpty(methodName, "method name");
		if (ObjectHelper.IsNotNull(names))
		{
			Guard.AssertNotNull(values, "values");
		}
		object state;
		MethodBase mb = Type.DefaultBinder.BindToMethod(optionalBinding ? BindingFlags.OptionalParamBinding : BindingFlags.Default, GetMethods(type, methodName, flags, ignoreCase), ref values, null, null, names, out state);
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
	public static object InvokeMethod(Type type, string methodName, object obj, string[] names, object[] values, AccessLevels level, bool ignoreCase = false, bool optionalBinding = false)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNullAndEmpty(methodName, "method name");
		if (ObjectHelper.IsNotNull(names))
		{
			Guard.AssertNotNull(values, "values");
		}
		MethodInfo[] minfos = GetMethods(type, methodName, level, ignoreCase);
		object state;
		MethodBase mb = Type.DefaultBinder.BindToMethod(optionalBinding ? BindingFlags.OptionalParamBinding : BindingFlags.Default, minfos, ref values, null, null, names, out state);
		object result = mb.Invoke(obj, values);
		Type.DefaultBinder.ReorderArgumentArray(ref values, state);
		return result;
	}

	/// <summary>
	/// 检测当前方法是否可以使用指定类型的参数进行绑定
	/// </summary>
	/// <param name="method">当前的方法对象</param>
	/// <param name="argTypes">方法参数类型数组</param>
	/// <returns>如果当前方法对象可以使用指定类型的参数进行绑定返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前方法对象为空；或者方法参数类型数组 <paramref name="argTypes" /> 为空；或者方法参数类型数组中存在null元素。</exception>
	/// <remarks>当给定的参数类型的数组中每个类型与当前方法的参数的类型依次兼容，且无剩余参数或者剩余参数均为可选参数时，认为给定的参数序列与当前方法的参数序列兼容。</remarks>
	public static bool IsBindable(MethodBase method, params Type[] argTypes)
	{
		return IsBindable(method, argTypes, optionalBinding: false);
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
	public static bool IsBindable(MethodBase method, Type[] argTypes, bool optionalBinding = false)
	{
		Guard.AssertNotNull(method, "method");
		Guard.AssertNotNull(argTypes, "parameter types");
		Array.ForEach(argTypes, delegate(Type p)
		{
			Guard.AssertNotNull(p, "parameter type");
		});
		if (optionalBinding)
		{
			return ObjectHelper.IsNotNull(Type.DefaultBinder.SelectMethod(BindingFlags.Default, new MethodBase[1] { method }, argTypes, null));
		}
		ParameterInfo[] pinfos = method.GetParameters();
		if (pinfos.Length < argTypes.Length)
		{
			return false;
		}
		int index;
		for (index = 0; index < pinfos.Length; index++)
		{
			if (!argTypes[index].Equals(pinfos[index].ParameterType) && (!argTypes[index].IsPrimitive || !CanConvertPrimitive(Type.DefaultBinder, argTypes[index], pinfos[index].ParameterType)) && !pinfos[index].ParameterType.IsAssignableFrom(argTypes[index]))
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
	/// 检测当前索引属性是否可以使用指定类型的参数进行绑定
	/// </summary>
	/// <param name="property">当前的索引属性对象</param>
	/// <param name="returnType">当前属性的返回值类型，如果不需要绑定返回值则设置为空。</param>
	/// <param name="argTypes">索引属性参数类型数组，如果不需要绑定属性参数则设置为空。</param>
	/// <returns>如果当前索引属性对象可以使用指定类型的参数进行绑定返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前索引属性对象为空；或者索引属性参数类型数组中存在null元素。</exception>
	/// <remarks>当给定的参数类型的数组中每个类型与当前索引属性的参数的类型依次兼容，且无剩余参数或者剩余参数均为可选参数时，认为给定的参数序列与当前索引属性的参数序列可匹配。</remarks>
	public static bool IsBindable(PropertyInfo property, Type returnType, params Type[] argTypes)
	{
		return IsBindable(property, returnType, argTypes, inheritBinding: false, optionalBinding: false);
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
	public static bool IsBindable(PropertyInfo property, Type returnType, Type[] argTypes, bool inheritBinding = false, bool optionalBinding = false)
	{
		Guard.AssertNotNull(property, "property");
		if (ObjectHelper.IsNotNull(argTypes))
		{
			Array.ForEach(argTypes, delegate(Type p)
			{
				Guard.AssertNotNull(p, "parameter type");
			});
		}
		if ((ObjectHelper.IsNull(returnType) || inheritBinding) && (ObjectHelper.IsNull(argTypes) || optionalBinding))
		{
			return ObjectHelper.IsNotNull(Type.DefaultBinder.SelectProperty(BindingFlags.Default, new PropertyInfo[1] { property }, returnType, argTypes, null));
		}
		if (ObjectHelper.IsNotNull(returnType) && ((inheritBinding && !property.PropertyType.IsAssignableFrom(returnType)) || (!inheritBinding && !returnType.IsAssignableFrom(property.PropertyType))))
		{
			return false;
		}
		if (ObjectHelper.IsNotNull(argTypes))
		{
			ParameterInfo[] pinfos = property.GetIndexParameters();
			if (pinfos.Length < argTypes.Length || (optionalBinding && pinfos.Length != argTypes.Length))
			{
				return false;
			}
			int index;
			for (index = 0; index < pinfos.Length; index++)
			{
				if (!argTypes[index].Equals(pinfos[index].ParameterType) && (!argTypes[index].IsPrimitive || !CanConvertPrimitive(Type.DefaultBinder, argTypes[index], pinfos[index].ParameterType)) && !pinfos[index].ParameterType.IsAssignableFrom(argTypes[index]))
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
	/// 检测当前类型是否是可转换类型，支持使用 <see cref="M:System.Convert.ChangeType(System.Object,System.Type)" /> 方法进行转换
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <returns>如果支持转换返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	public static bool IsConvertible(Type type)
	{
		Guard.AssertNotNull(type, "type");
		return typeof(IConvertible).IsAssignableFrom(type);
	}

	/// <summary>
	/// 检测当前类型是否是可以表示小数的类型
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <returns>如果当前类型可以表示小数返回true，否则返回false。</returns>
	public static bool IsDecimal(Type type)
	{
		Guard.AssertNotNull(type, "type");
		return type.Equals(typeof(decimal)) || type.Equals(typeof(double)) || type.Equals(typeof(float));
	}

	/// <summary>
	/// 检测当前类型是否是可枚举类型，实现了 <see cref="T:System.Collections.IEnumerable" /> 接口
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <returns>如果当前类型是可枚举类型返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	public static bool IsEnumerable(Type type)
	{
		Guard.AssertNotNull(type, "type");
		return typeof(IEnumerable).IsAssignableFrom(type);
	}

	/// <summary>
	/// 检测当前类型是否是强类型可枚举类型，实现了 <see cref="T:System.Collections.Generic.IEnumerable`1" /> 接口
	/// </summary>
	/// <typeparam name="T">枚举元素类型</typeparam>
	/// <param name="type">当前类型</param>
	/// <returns>如果当前类型是可枚举类型返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	public static bool IsEnumerable<T>(Type type)
	{
		Guard.AssertNotNull(type, "type");
		return ObjectHelper.IsNotNull(GetInterface(type, typeof(IEnumerable<T>)));
	}

	/// <summary>
	/// 当前类型是否是可以实例化为对象
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="paramTypes">当前类型的构造函数参数类型</param>
	/// <returns>如果当前类型可以获取初始化的实例返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	/// <remarks>如果当前类型不是接口、不是抽象类型、是封闭类型、具有与给定参数类型匹配的构造函数，则认为可实例化。</remarks>
	public static bool IsInstance(Type type, params Type[] paramTypes)
	{
		Guard.AssertNotNull(type, "type");
		return !type.ContainsGenericParameters && !type.IsInterface && !type.IsAbstract && ObjectHelper.IsNotNull(type.GetConstructor(ObjectHelper.IfNull(paramTypes, Type.EmptyTypes)));
	}

	/// <summary>
	/// 检测当前方法是否是实例方法，实例构造函数也认为是实例方法
	/// </summary>
	/// <param name="minfo">当前方法对象</param>
	/// <returns>如果当前方法为是实例方法返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前方法对象为空。</exception>
	public static bool IsInstance(MethodBase minfo)
	{
		Guard.AssertNotNull(minfo, "Method Info");
		return !minfo.IsStatic;
	}

	/// <summary>
	/// 检测当前字段是否为实例字段
	/// </summary>
	/// <param name="finfo">当前字段对象</param>
	/// <returns>如果当前字段为实例字段返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字段对象为空。</exception>
	public static bool IsInstance(FieldInfo finfo)
	{
		Guard.AssertNotNull(finfo, "field info");
		return !finfo.IsStatic;
	}

	/// <summary>
	/// 检测当前事件是否为实例事件
	/// </summary>
	/// <param name="einfo">当前事件对象</param>
	/// <returns>如果当前事件为实例事件返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前事件对象为空。</exception>
	public static bool IsInstance(EventInfo einfo)
	{
		Guard.EnsureNotNull(einfo, "event info");
		return !IsStatic(einfo);
	}

	/// <summary>
	/// 检测当前属性是否为实例属性
	/// </summary>
	/// <param name="pinfo">当前属性对象</param>
	/// <returns>如果当前属性为实例属性返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前属性对象为空。</exception>
	public static bool IsInstance(PropertyInfo pinfo)
	{
		Guard.AssertNotNull(pinfo, "property info");
		return !IsStatic(pinfo);
	}

	/// <summary>
	/// 检查当前类型是否是整数类型
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <returns>如果当前类型是整数类型则返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	public static bool IsInteger(Type type)
	{
		Guard.AssertNotNull(type, "type");
		return type == typeof(byte) || type == typeof(sbyte) || type == typeof(short) || type == typeof(int) || type == typeof(long) || type == typeof(ushort) || type == typeof(uint) || type == typeof(ulong);
	}

	/// <summary>
	/// 检测当前类型是否是可空类型，包括引用类型（类、接口）和可空值类型
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <returns>如果指定的类型是目标的可空类型返回true,否则返回false</returns>
	public static bool IsNullable(Type type)
	{
		Guard.AssertNotNull(type, "type");
		return type.IsClass || type.IsInterface || IsNullableValueType(type);
	}

	/// <summary>
	/// 检测当前类型是否是可空的值类型
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <returns>如果当前类型是可空的值类型返回true,否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	public static bool IsNullableValueType(Type type)
	{
		Guard.AssertNotNull(type, "type");
		return type.IsGenericType && type.GetGenericTypeDefinition().Equals(typeof(Nullable<>));
	}

	/// <summary>
	/// 检测当前类型是否是可空的值类型
	/// </summary>
	/// <typeparam name="T">可空值类型的泛型参数类型</typeparam>
	/// <param name="type">当前类型</param>
	/// <returns>如果当前类型是可空的值类型返回true,否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	public static bool IsNullableValueType<T>(Type type)
	{
		Guard.AssertNotNull(type, "type");
		return type.IsGenericType && type.GetGenericTypeDefinition().Equals(typeof(Nullable<>)) && type.GetGenericArguments()[0].Equals(typeof(T));
	}

	/// <summary>
	/// 检测当前类型是否是可空的值类型
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="argType">可空值类型的泛型参数类型</param>
	/// <returns>如果当前类型是可空的值类型返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	public static bool IsNullableValueType(Type type, Type argType)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNull(argType, "argType");
		return type.IsGenericType && type.GetGenericTypeDefinition().Equals(typeof(Nullable<>)) && type.GetGenericArguments()[0].Equals(argType);
	}

	/// <summary>
	/// 检查当前类型是否是数值类型
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <returns>如果当前类型是数值类型返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	public static bool IsNumeric(Type type)
	{
		Guard.AssertNotNull(type, "type");
		return IsInteger(type) || IsDecimal(type);
	}

	/// <summary>
	/// 检测当前类型是否是引用类型
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <returns>如果当前类型是引用类型</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	public static bool IsReference(Type type)
	{
		Guard.AssertNotNull(type, "type");
		return type.IsClass || type.IsInterface;
	}

	/// <summary>
	/// 检测当前事件是否为静态属性
	/// </summary>
	/// <param name="einfo">当前事件对象</param>
	/// <returns>如果当前事件为静态事件返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前事件事件对象为空。</exception>
	public static bool IsStatic(EventInfo einfo)
	{
		Guard.EnsureNotNull(einfo, "event info");
		MethodInfo minfo = einfo.GetAddMethod(nonPublic: true);
		if (ObjectHelper.IsNotNull(minfo))
		{
			return minfo.IsStatic;
		}
		minfo = einfo.GetRemoveMethod(nonPublic: true);
		if (ObjectHelper.IsNotNull(minfo))
		{
			return minfo.IsStatic;
		}
		return false;
	}

	/// <summary>
	/// 检测当前属性是否为静态属性
	/// </summary>
	/// <param name="pinfo">当前属性对象</param>
	/// <returns>如果当前属性为静态属性返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前属性对象为空。</exception>
	/// <remarks>本方法将查找属性的get或者set方法，如果get方法或者set方法为静态方法，则该属性为静态属性。</remarks>
	public static bool IsStatic(PropertyInfo pinfo)
	{
		Guard.AssertNotNull(pinfo, "property info");
		MethodInfo minfo = pinfo.GetGetMethod(nonPublic: true);
		if (ObjectHelper.IsNotNull(minfo))
		{
			return minfo.IsStatic;
		}
		minfo = pinfo.GetSetMethod(nonPublic: true);
		if (ObjectHelper.IsNotNull(minfo))
		{
			return minfo.IsStatic;
		}
		return false;
	}

	/// <summary>
	/// 检测当前类型与指定类型是否兼容（当前类型是否可以默认转换为目标类型）
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="targetType">目标类型</param>
	/// <returns>如果当前类型与目标类型兼容返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者目标类型 <paramref name="targetType" /> 为空。</exception>
	public static bool IsType(Type type, Type targetType)
	{
		Guard.AssertNotNull(type, "type");
		Guard.AssertNotNull(targetType, "target");
		if (targetType.IsAssignableFrom(type))
		{
			return true;
		}
		if (targetType.IsPrimitive)
		{
			return CanConvertPrimitive(Type.DefaultBinder, type, targetType);
		}
		if (targetType.IsInterface && targetType.IsGenericType)
		{
			return type.GetInterfaces().Any((Type t) => CheckGenericTypeCompatibility(t, targetType));
		}
		if (targetType.IsClass && targetType.IsGenericType)
		{
			return CollectionHelper.Prepend(GetBaseTypes(type), type).Any((Type t) => CheckGenericTypeCompatibility(t, targetType));
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
	public static bool IsType<T>(Type type)
	{
		return IsType(type, typeof(T));
	}

	/// <summary>
	/// 根据当前程序集名称加载程序集到当前应用程序域
	/// </summary>
	/// <param name="name">当前程序集名称</param>
	/// <returns>已加载的程序集对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前程序集名称为空。</exception>
	public static Assembly LoadAssembly(AssemblyName name)
	{
		Guard.AssertNotNull(name, "name");
		return Assembly.Load(name);
	}

	/// <summary>
	/// 加载当前的文件中的程序集
	/// </summary>
	/// <param name="file">加载当前的文件中的程序集</param>
	/// <returns>从当前的文件中加载的程序集</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	public static Assembly LoadAssembly(FileInfo file)
	{
		Guard.AssertNotNull(file, "file");
		Guard.AssertFileExistence(file);
		return Assembly.LoadFrom(file.FullName);
	}

	/// <summary>
	/// 加载当前名称的程序集到当前应用程序域
	/// </summary>
	/// <param name="assemblyName">当前程序集名称</param>
	/// <returns>加载的程序集</returns>
	/// <exception cref="T:System.ArgumentNullException">当前程序集名称为空或者空串。</exception>
	public static Assembly LoadAssembly(string assemblyName)
	{
		Guard.AssertNotNullAndEmpty(assemblyName, "assembly name");
		return Assembly.Load(assemblyName);
	}

	/// <summary>
	/// 加载当前的文件中的程序集
	/// </summary>
	/// <param name="file">加载当前的文件中的程序集</param>
	/// <returns>从当前的文件中加载的程序集</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	public static Assembly LoadAssemblyFile(FileInfo file)
	{
		Guard.AssertNotNull(file, "file");
		Guard.AssertFileExistence(file);
		return Assembly.LoadFile(file.FullName);
	}

	/// <summary>
	/// 加载当前文件中的程序集到当前应用程序域
	/// </summary>
	/// <param name="assemblyFile">当前程序集文件</param>
	/// <returns>加载的程序集</returns>
	/// <exception cref="T:System.ArgumentNullException">当前程序集文件为空或者空串。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前程序集文件不存在。</exception>
	public static Assembly LoadAssemblyFile(string assemblyFile)
	{
		Guard.AssertNotNull(assemblyFile, "assembly file");
		Guard.AssertFileExistence(assemblyFile);
		return Assembly.LoadFile(assemblyFile);
	}

	/// <summary>
	/// 加载当前文件中的程序集到当前应用程序域
	/// </summary>
	/// <param name="assemblyFile">当前程序集文件</param>
	/// <returns>加载的程序集</returns>
	/// <exception cref="T:System.ArgumentNullException">当前程序集文件为空或者空串。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前程序集文件不存在。</exception>
	public static Assembly LoadAssemblyFrom(string assemblyFile)
	{
		Guard.AssertNotNull(assemblyFile, "assembly file");
		Guard.AssertFileExistence(assemblyFile);
		return Assembly.LoadFrom(assemblyFile);
	}

	/// <summary>
	/// 加载当前目录下的文件中的程序集
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="recursive">是否在子目录中查找文件</param>
	/// <returns>加载的程序集数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	/// <remarks>搜索当前目录下扩展名为 "dll" 的文件。</remarks>
	public static Assembly[] LoadAssemblies(DirectoryInfo directory, bool recursive = false)
	{
		return LoadAssemblies(directory, "*.dll", (AssemblyName a) => true, recursive);
	}

	/// <summary>
	/// 加载当前目录下的满足指定筛选条件的文件中的程序集
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="assemblyPredicate">程序集筛选方法</param>
	/// <param name="recursive">是否在子目录中查找</param>
	/// <returns>加载的程序集数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者筛选方法 <paramref name="assemblyPredicate" /> 为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	/// <remarks>搜索当前目录下扩展名为 "dll" 的文件。</remarks>
	public static Assembly[] LoadAssemblies(DirectoryInfo directory, Func<AssemblyName, bool> assemblyPredicate, bool recursive = false)
	{
		return LoadAssemblies(directory, "*.dll", assemblyPredicate, recursive);
	}

	/// <summary>
	/// 加载当前目录下的满足指定筛选条件的程序集
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="searching">程序集文件搜索模式</param>
	/// <param name="assemblyPredicate">程序集筛选方法；如果为空，则忽略程序集筛选。</param>
	/// <param name="recursive">是否在子目录中查找</param>
	/// <returns>加载的程序集数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者 <paramref name="searching" /> 为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	public static Assembly[] LoadAssemblies(DirectoryInfo directory, string searching, Func<AssemblyName, bool> assemblyPredicate, bool recursive = false)
	{
		Guard.AssertNotNull(directory, "directory");
		Guard.AssertDirectoryExistence(directory);
		Guard.AssertNotNull(searching, "searching");
		Guard.AssertNotNull(assemblyPredicate, "assembly predicate");
		return LoadAssemblies(directory, (DirectoryInfo d) => IOHelper.Files(d, searching, recursive), assemblyPredicate);
	}

	/// <summary>
	/// 加载当前目录下文件全名与指定模式匹配的文件中的程序集
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="pattern">文件全名匹配模式</param>
	/// <param name="assemblyPredicate">程序集筛选方法；如果为空，则忽略程序集筛选。</param>
	/// <param name="recursive">是否在子目录中查找文件</param>
	/// <returns>加载的程序集数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者筛选方法 <paramref name="pattern" /> 为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	public static Assembly[] LoadAssemblies(DirectoryInfo directory, Regex pattern, Func<AssemblyName, bool> assemblyPredicate, bool recursive = false)
	{
		Guard.AssertNotNull(directory, "directory");
		Guard.AssertDirectoryExistence(directory);
		Guard.AssertNotNull(pattern, "pattern");
		Guard.AssertNotNull(assemblyPredicate, "assembly predicate");
		return LoadAssemblies(directory, (FileInfo f) => pattern.IsMatch(f.FullName), assemblyPredicate, recursive);
	}

	/// <summary>
	/// 加载当前目录下的满足指定筛选条件的程序集
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="predicate">程序集文件筛选方法</param>
	/// <param name="assemblyPredicate">程序集筛选方法；如果为空，则忽略程序集筛选。</param>
	/// <param name="recursive">是否在子目录中查找文件</param>
	/// <returns>加载的程序集数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者筛选方法 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	public static Assembly[] LoadAssemblies(DirectoryInfo directory, Func<FileInfo, bool> predicate, Func<AssemblyName, bool> assemblyPredicate, bool recursive = false)
	{
		Guard.AssertNotNull(directory, "directory");
		Guard.AssertDirectoryExistence(directory);
		Guard.AssertNotNull(predicate, "predicate");
		Guard.AssertNotNull(assemblyPredicate, "assembly predicate");
		return LoadAssemblies(directory, (DirectoryInfo d) => IOHelper.Files(d, predicate, recursive), assemblyPredicate);
	}

	private static Assembly[] LoadAssemblies(DirectoryInfo directory, Func<DirectoryInfo, IEnumerable<FileInfo>> enumerator, Func<AssemblyName, bool> assemblyPredicate)
	{
		List<Assembly> assemblies = new List<Assembly>();
		foreach (FileInfo finfo in enumerator(directory))
		{
			try
			{
				AssemblyName name = AssemblyName.GetAssemblyName(finfo.FullName);
				if (ObjectHelper.IsNull(assemblyPredicate) || assemblyPredicate(name))
				{
					assemblies.Add(LoadAssembly(name));
				}
			}
			catch (ArgumentNullException)
			{
			}
			catch (BadImageFormatException)
			{
			}
		}
		return assemblies.ToArray();
	}

	/// <summary>
	/// 根据当前程序集名称加载程序集到指定的应用程序域中；
	/// </summary>
	/// <param name="name">当前程序集名称</param>
	/// <param name="domain">加载的目标应用程序域</param>
	/// <returns>已加载的程序集对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前程序集为空；或者 <paramref name="domain" /> 为空。</exception>
	/// <remarks>在将当前的程序集加载到指定的应用程序域中的同时，也会将该程序集加载到当前应用程序域中，并且返回加载到当前应用程序域中的程序集。</remarks>
	public static Assembly LoadAssemblyTo(AssemblyName name, AppDomain domain)
	{
		Guard.AssertNotNull(name, "name");
		Guard.AssertNotNull(domain, "domain");
		return domain.Load(name);
	}

	/// <summary>
	/// 根据容器中的定义解析当前类型名称，返回解析出的类型
	/// </summary>
	/// <param name="typeName">当前类型名称</param>
	/// <param name="throwError">如果无法解析类型名称是否抛出异常，默认为false</param>
	/// <returns>如果成功解析类型名称则返回类型对象，否则根据 <paramref name="throwError" /> 的设置返回空或者抛出异常。如果当前没有容器配置则返回空。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型名称为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当 <paramref name="throwError" /> 设置为true时，当前类型名称无法解析。</exception>
	public static Type ResolveContainerType(string typeName, bool throwError = false)
	{
		Guard.AssertNotNull(typeName, "type name");
		ITypeResolver resolver = TypeResolver.GetResolver<UnityTypeResolver>();
		return ObjectHelper.IsNull(resolver) ? null : resolver.ResolveType(typeName, throwError);
	}

	/// <summary>
	/// 将当前类型名称解析为其所表示的类型；类型名称区分大小写。
	/// </summary>
	/// <param name="typeName">当前类型名称</param>
	/// <returns>解析成功返回类型对象，解析失败返回空。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型名称为空。</exception>
	public static Type ResolveType(string typeName)
	{
		Guard.AssertNotNull(typeName, "type name");
		return TypeResolver.Resolve(typeName);
	}

	/// <summary>
	/// 将当前类型名称解析为其所表示的类型
	/// </summary>
	/// <param name="typeName">当前类型名称</param>
	/// <param name="throwError">如果转换失败是否抛出异常</param>
	/// <param name="ignoreCase">解析类型名称时是否区分大小写，默认为区分大小写（false）</param>
	/// <returns>解析成功返回类型对象，解析失败时根据 <paramref name="throwError" /> 的设置。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型名称为空。</exception>
	public static Type ResolveType(string typeName, bool throwError, bool ignoreCase = false)
	{
		Guard.AssertNotNull(typeName, "type name");
		return TypeResolver.Resolve(typeName, throwError, ignoreCase);
	}

	/// <summary>
	/// 设置当前静态字段的字段值
	/// </summary>
	/// <param name="finfo">当前静态字段</param>
	/// <param name="value">设置的字段值</param>
	/// <exception cref="T:System.ArgumentNullException">当前静态字段为空。</exception>
	public static void SetValue(FieldInfo finfo, object value)
	{
		Guard.AssertNotNull(finfo, "field info");
		finfo.SetValue(null, value);
	}

	/// <summary>
	/// 设置当前静态字段的字段值
	/// </summary>
	/// <param name="finfo">当前静态字段</param>
	/// <param name="handler">当前字段关联的对象实例</param>
	/// <param name="value">设置的字段值</param>
	/// <exception cref="T:System.ArgumentNullException">当前静态字段为空。</exception>
	public static void SetValue(FieldInfo finfo, object handler, object value)
	{
		Guard.AssertNotNull(finfo, "field info");
		finfo.SetValue(handler, value);
	}

	/// <summary>
	/// 设置当前静态属性的属性值
	/// </summary>
	/// <param name="pinfo">当前静态属性</param>
	/// <param name="value">设置的属性值</param>
	/// <exception cref="T:System.ArgumentNullException">当前静态属性为空。</exception>
	public static void SetValue(PropertyInfo pinfo, object value)
	{
		Guard.AssertNotNull(pinfo, "property info");
		pinfo.SetValue(null, value, null);
	}

	/// <summary>
	/// 设置当前属性的属性值
	/// </summary>
	/// <param name="pinfo">当前属性</param>
	/// <param name="handler">当前属性所属类型的实例对象；如果当前属性为静态属性，则该参数需要设置为空</param>
	/// <param name="value">设置的属性值</param>
	/// <exception cref="T:System.ArgumentNullException">当前属性为空。</exception>
	public static void SetValue(PropertyInfo pinfo, object handler, object value)
	{
		Guard.AssertNotNull(pinfo, "property info");
		pinfo.SetValue(handler, value, null);
	}

	/// <summary>
	/// 筛选并返回当前类型序列中与给定的类型相同或者继承于给定的类型的类型的序列
	/// </summary>
	/// <param name="types">当前类型序列</param>
	/// <param name="type">筛选的类型</param>
	/// <returns>筛选后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型序列为空；或者筛选类型 <paramref name="type" /> 为空。</exception>
	public static IEnumerable<Type> WhereInheritedType(IEnumerable<Type> types, Type type)
	{
		Guard.AssertNotNull(types, "types");
		Guard.AssertNotNull(type, "type");
		return types.Where((Type t) => type.IsAssignableFrom(t));
	}

	/// <summary>
	/// 筛选并返回当前类型序列中与给定的类型相同或者继承于给定的类型的类型的序列
	/// </summary>
	/// <typeparam name="T">筛选的类型</typeparam>
	/// <param name="types">当前类型序列</param>
	/// <returns>筛选后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型序列为空。</exception>
	public static IEnumerable<Type> WhereInheritedType<T>(IEnumerable<Type> types)
	{
		return WhereInheritedType(types, typeof(T));
	}

	/// <summary>
	/// 筛选并返回当前类型序列中与给定类型相同的类型的序列
	/// </summary>
	/// <param name="types">当前类型序列</param>
	/// <param name="type">筛选的类型</param>
	/// <returns>筛选后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型序列为空；或者筛选类型 <paramref name="type" /> 为空。</exception>
	public static IEnumerable<Type> WhereType(IEnumerable<Type> types, Type type)
	{
		Guard.AssertNotNull(types, "types");
		Guard.AssertNotNull(type, "type");
		return types.Where((Type t) => type.Equals(t));
	}

	/// <summary>
	/// 筛选并返回当前类型序列中与给定类型相同的类型的序列
	/// </summary>
	/// <typeparam name="T">筛选的类型</typeparam>
	/// <param name="types">当前类型序列</param>
	/// <returns>筛选后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型序列为空。</exception>
	public static IEnumerable<Type> WhereType<T>(IEnumerable<Type> types)
	{
		return WhereType(types, typeof(T));
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
