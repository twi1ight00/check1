using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Richfit.Garnet.Common.Collections;
using Richfit.Garnet.Common.Data;
using Richfit.Garnet.Common.Mapping;
using Richfit.Garnet.Common.Patterns;
using Richfit.Garnet.Common.Properties;

namespace Richfit.Garnet.Common.Extensions;

/// <summary>
/// <see cref="T:System.Object" /> 类型扩展方法类
///
/// 包括：
/// 1. Object类型对象的扩展方法
/// 2. Object类型数组及泛型集合的扩展方法
/// 3. 没有约束的泛型类型的扩展方法
/// 4. 没有约束的泛型类型数组的扩展方法
/// </summary>
public static class ObjectExtensions
{
	/// <summary>
	/// 递归委托
	/// </summary>
	/// <typeparam name="A"></typeparam>
	/// <typeparam name="R"></typeparam>
	/// <param name="r"></param>
	/// <returns></returns>
	private delegate Func<A, R> RD<A, R>(RD<A, R> r);

	/// <summary>
	/// 将当前对象转换为指定的类型，不检测转换时可能产生的溢出错误
	/// </summary>
	/// <typeparam name="T">转换的目标类型</typeparam>
	/// <param name="obj">当前对象</param>
	/// <returns>转换后的目标类型的值</returns>
	public static T As<T>(this object obj)
	{
		return (T)obj;
	}

	/// <summary>
	/// 将当前对象转换为指定的类型
	/// </summary>
	/// <typeparam name="T">转换的目标类型</typeparam>
	/// <param name="obj">当前对象</param>
	/// <param name="checkOverflow">是否检查转换溢出</param>
	/// <returns>转换后的目标类型的值</returns>
	/// <exception cref="T:System.OverflowException">当 <paramref name="checkOverflow" /> 为true是，转换的当前对象超过了目标类型所能表示的数值范围。</exception>
	public static T As<T>(this object obj, bool checkOverflow)
	{
		if (checkOverflow)
		{
			return (T)obj;
		}
		return (T)obj;
	}

	/// <summary>
	/// 将当前对象转换为只有该对象一个元素的对象数组
	/// </summary>
	/// <param name="obj">当前对象</param>
	/// <returns>包含当前对象的对象数组；如果当前对象为空，则返回的对象数组将包含一个空元素。</returns>
	public static object[] AsArray(this object obj)
	{
		return new object[1] { obj };
	}

	/// <summary>
	/// 将当前值转换为只有该值一个元素的值数组
	/// </summary>
	/// <typeparam name="T">当前值类型</typeparam>
	/// <param name="value">当前值</param>
	/// <returns>包含当前值的值数组；如果当前值为空，则返回的对象数组将包含一个空元素。</returns>
	public static T[] AsArray<T>(this T value)
	{
		return new T[1] { value };
	}

	/// <summary>
	/// 将当前值转换为可空的值类型
	/// </summary>
	/// <typeparam name="T">当前值类型</typeparam>
	/// <param name="value">当前值</param>
	/// <returns>当前值类型的可空类型数值</returns>
	public static T? AsNullable<T>(this T value) where T : struct
	{
		return value;
	}

	/// <summary>
	/// 将当前对象转换为 <see cref="T:System.Object" /> 类型对象
	/// </summary>
	/// <param name="obj">当前对象</param>
	/// <returns>转换后的对象</returns>
	public static object AsObject(this object obj)
	{
		return obj;
	}

	/// <summary>
	/// 尝试将当前对象转换为目标类型；如果当前对象不能转换为目标类型，返回目标类型的默认值
	/// </summary>
	/// <typeparam name="T">转换的目标类型</typeparam>
	/// <param name="obj">当前对象</param>
	/// <param name="defaultValue">目标类型的默认值</param>
	/// <returns>转换后目标类型的值</returns>
	public static T AsOr<T>(this object obj, T defaultValue = default(T))
	{
		if (!(obj is T result))
		{
			return defaultValue;
		}
		return result;
	}

	/// <summary>
	/// 判断当前对象是否介于两个指定的两个值之间
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="value">当前对象</param>
	/// <param name="min">值范围的最小值</param>
	/// <param name="max">值范围的最大值</param>
	/// <param name="comparison">对象值比较方法</param>
	/// <param name="includeMin">值范围是否包含最小值，默认包含最小值</param>
	/// <param name="includeMax">值范围是否包含最大值，默认包含最大值</param>
	/// <returns>如果指定值介于最大值和最小值之间返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException">值范围最小值 <paramref name="min" /> 大于最大值 <paramref name="max" /></exception>
	public static bool Between<T>(this T value, T min, T max, Func<T, T, int> comparison, bool includeMin = true, bool includeMax = true)
	{
		comparison = comparison.IfNull(Comparer<T>.Default.Compare);
		if (comparison(min, max) > 0)
		{
			throw new ArgumentOutOfRangeException("min & max", Literals.MSG_ValueRangeMinGreaterThanMax);
		}
		return (comparison(value, min) > 0 && comparison(value, max) < 0) || (includeMin && comparison(value, min) == 0) || (includeMax && comparison(value, max) == 0);
	}

	/// <summary>
	/// 判断当前对象是否介于两个指定的两个值之间
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="value">当前对象</param>
	/// <param name="min">值范围的最小值</param>
	/// <param name="max">值范围的最大值</param>
	/// <param name="comparer">对象值比较对象</param>
	/// <param name="includeMin">值范围是否包含最小值，默认包含最小值</param>
	/// <param name="includeMax">值范围是否包含最大值，默认包含最大值</param>
	/// <returns>如果指定值介于最大值和最小值之间返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException">值范围最小值 <paramref name="min" /> 大于最大值 <paramref name="max" /></exception>
	public static bool Between<T>(this T value, T min, T max, IComparer<T> comparer, bool includeMin = true, bool includeMax = true)
	{
		return value.Between(min, max, comparer.IfNull(Comparer<T>.Default).Compare, includeMin, includeMax);
	}

	/// <summary>
	/// 判断当前对象是否介于两个指定的两个值之间
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="value">当前对象</param>
	/// <param name="min">值范围的最小值</param>
	/// <param name="max">值范围的最大值</param>
	/// <param name="comparison">对象值比较方法</param>
	/// <param name="includeMin">值范围是否包含最小值，默认包含最小值</param>
	/// <param name="includeMax">值范围是否包含最大值，默认包含最大值</param>
	/// <returns>如果指定值介于最大值和最小值之间返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException">值范围最小值 <paramref name="min" /> 大于最大值 <paramref name="max" /></exception>
	public static bool NotBetween<T>(this T value, T min, T max, Func<T, T, int> comparison, bool includeMin = true, bool includeMax = true)
	{
		return !value.Between(min, max, comparison, includeMin, includeMax);
	}

	/// <summary>
	/// 判断当前对象是否介于两个指定的两个值之间
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="value">当前对象</param>
	/// <param name="min">值范围的最小值</param>
	/// <param name="max">值范围的最大值</param>
	/// <param name="comparer">对象值比较对象</param>
	/// <param name="includeMin">值范围是否包含最小值，默认包含最小值</param>
	/// <param name="includeMax">值范围是否包含最大值，默认包含最大值</param>
	/// <returns>如果指定值介于最大值和最小值之间返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException">值范围最小值 <paramref name="min" /> 大于最大值 <paramref name="max" /></exception>
	public static bool NotBetween<T>(this T value, T min, T max, IComparer<T> comparer, bool includeMin = true, bool includeMax = true)
	{
		return !value.Between(min, max, comparer, includeMin, includeMax);
	}

	/// <summary>
	/// 创建当前对象的二进制副本
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="source">当前对象</param>
	/// <returns>复制的新对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象 <paramref name="source" /> 为空。</exception>
	public static T BinaryCopy<T>(this T source)
	{
		source.GuardNotNull("source");
		object obj;
		using (Stream stream = new MemoryStream())
		{
			IFormatter formatter = new BinaryFormatter();
			formatter.Serialize(stream, source);
			stream.Position = 0L;
			obj = formatter.Deserialize(stream);
			stream.Close();
		}
		return (T)obj;
	}

	/// <summary>
	/// 将当前对象序列化为二进制字节数据
	/// </summary>
	/// <param name="source">当前对象</param>
	/// <returns>当前对象序列化后的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象 <paramref name="source" /> 为空。</exception>
	public static byte[] BinarySerialize(this object source)
	{
		source.GuardNotNull("source");
		byte[] output;
		using (MemoryStream stream = new MemoryStream())
		{
			BinaryFormatter formatter = new BinaryFormatter();
			formatter.Serialize(stream, source);
			stream.Flush();
			output = stream.ToArray();
			stream.Close();
		}
		return output;
	}

	/// <summary>
	/// 检测当前对象是否在指定的范围中；如果在范围中则返回当前对象；如果小于最小值，则返回最小值；如果大于最大值，则返回最大值
	/// </summary>
	/// <typeparam name="T">当前值类型</typeparam>
	/// <param name="value">当前值</param>
	/// <param name="min">值范围的最小值</param>
	/// <param name="max">值范围的最大值</param>
	/// <returns>处理结果</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException">最小值 <paramref name="min" /> 大于最大值 <paramref name="max" /></exception>
	public static T Clamp<T>(this T value, T min, T max)
	{
		return value.Clamp(min, max, Comparer<T>.Default.Compare);
	}

	/// <summary>
	/// 检测当前对象是否在指定的范围中；如果在范围中则返回当前对象；如果小于最小值，则返回最小值；如果大于最大值，则返回最大值
	/// </summary>
	/// <typeparam name="T">当前值类型</typeparam>
	/// <param name="value">当前值</param>
	/// <param name="min">值范围的最小值</param>
	/// <param name="max">值范围的最大值</param>
	/// <param name="comparison">对象比较方法</param>
	/// <returns>处理结果</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException">最小值 <paramref name="min" /> 大于最大值 <paramref name="max" /></exception>
	public static T Clamp<T>(this T value, T min, T max, Func<T, T, int> comparison)
	{
		comparison = comparison.IfNull(Comparer<T>.Default.Compare);
		if (comparison(min, max) > 0)
		{
			throw new ArgumentOutOfRangeException("min & max", Literals.MSG_ValueRangeMinGreaterThanMax);
		}
		if (comparison(value, min) < 0)
		{
			return min;
		}
		if (comparison(value, max) > 0)
		{
			return max;
		}
		return value;
	}

	/// <summary>
	/// 检测当前对象是否在指定的范围中；如果在范围中则返回当前对象；如果小于最小值，则返回最小值；如果大于最大值，则返回最大值
	/// </summary>
	/// <typeparam name="T">当前值类型</typeparam>
	/// <param name="value">当前值</param>
	/// <param name="min">值范围的最小值</param>
	/// <param name="max">值范围的最大值</param>
	/// <param name="comparer">对象比较对象</param>
	/// <returns>处理结果</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException">最小值 <paramref name="min" /> 大于最大值 <paramref name="max" /></exception>
	public static T Clamp<T>(this T value, T min, T max, IComparer<T> comparer)
	{
		return value.Clamp(min, max, comparer.IfNull(Comparer<T>.Default).Compare);
	}

	/// <summary>
	/// 将当前对象按照指定的比较方式与目标对象进行比较，如果满足指定的比较方式的条件，返回true；如果不满足则返回false。
	/// </summary>
	/// <typeparam name="T">比较的对象类型</typeparam>
	/// <param name="value">当前待比较的对象</param>
	/// <param name="target">待比较的目标对象</param>
	/// <param name="mode">指定的比较方式</param>
	/// <param name="comparer">对象比较器</param>
	/// <returns>如果满足比较方式指定的条件返回true，否则返回false。</returns>
	public static bool CompareTo<T>(this T value, T target, ComparisonMode mode, IComparer<T> comparer)
	{
		comparer = comparer.IfNull(Comparer<T>.Default);
		return value.CompareTo(target, mode, comparer.Compare);
	}

	/// <summary>
	/// 将当前对象按照指定的比较方式与目标对象进行比较，如果满足指定的比较方式的条件，返回true；如果不满足则返回false。
	/// </summary>
	/// <typeparam name="T">比较的对象类型</typeparam>
	/// <param name="value">当前待比较的对象</param>
	/// <param name="target">待比较的目标对象</param>
	/// <param name="mode">指定的比较方式</param>
	/// <param name="comparsion">对象比较方法</param>
	/// <returns>如果满足比较方式指定的条件返回true，否则返回false。</returns>
	public static bool CompareTo<T>(this T value, T target, ComparisonMode mode, Func<T, T, int> comparsion)
	{
		comparsion = comparsion.IfNull(Comparer<T>.Default.Compare);
		int result = comparsion(value, target);
		bool flag = false;
		if (!flag && mode.HasFlag(ComparisonMode.Equal))
		{
			flag = result == 0;
		}
		if (!flag && mode.HasFlag(ComparisonMode.GreaterThan))
		{
			flag = result > 0;
		}
		if (!flag && mode.HasFlag(ComparisonMode.LessThan))
		{
			flag = result < 0;
		}
		flag.GuardTrue("comparsion");
		if (mode.HasFlag(ComparisonMode.Not))
		{
			flag = !flag;
		}
		return flag;
	}

	/// <summary>
	/// 将当前值转换为目标类型的值
	/// </summary>
	/// <param name="value">当前值</param>
	/// <param name="targetType">转换的目标类型</param>
	/// <param name="culture">转换时使用的区域信息</param>
	/// <returns>转换后的值</returns>
	/// <exception cref="T:System.ArgumentNullException">转换的目标类型 <paramref name="targetType" /> 为空。</exception>
	/// <remarks>如果当前值为空，则返回目标类型的默认值。</remarks>
	public static object ConvertTo(this object value, Type targetType, CultureInfo culture = null)
	{
		return value.ConvertTo(targetType, null, culture);
	}

	/// <summary>
	/// 将当前值转换为目标类型的值
	/// </summary>
	/// <param name="value">当前值</param>
	/// <param name="targetType">转换的目标类型</param>
	/// <param name="defaultValue">如果无法将当前值转换为目标类型，则返回该默认值</param>
	/// <param name="culture">转换时使用的区域信息</param>
	/// <returns>转换后的值</returns>
	/// <exception cref="T:System.ArgumentNullException">转换的目标类型 <paramref name="targetType" /> 为空。</exception>
	/// <remarks>如果当前值为空，则返回目标类型的默认值。</remarks>
	public static object ConvertTo(this object value, Type targetType, object defaultValue, CultureInfo culture = null)
	{
		return value.ConvertTo(targetType, (object v, Type t) => defaultValue, culture);
	}

	/// <summary>
	/// 将当前值转换为目标类型的值
	/// </summary>
	/// <param name="value">当前值</param>
	/// <param name="targetType">转换的目标类型</param>
	/// <param name="conversion">当前值到目标类型的转换方法</param>
	/// <param name="culture">转换时使用的区域信息</param>
	/// <returns>转换后的值</returns>
	/// <exception cref="T:System.ArgumentNullException">转换的目标类型 <paramref name="targetType" /> 为空。</exception>
	/// <remarks>如果当前值为空，则返回目标类型的默认值。</remarks>
	public static object ConvertTo(this object value, Type targetType, Func<object, Type, object> conversion, CultureInfo culture = null)
	{
		targetType.GuardNotNull("target type");
		culture = culture.IfNull(CultureInfo.CurrentCulture);
		if (value.IsNull())
		{
			return targetType.CreateDefault();
		}
		Type valueType = value.GetType();
		if (targetType.IsAssignableFrom(valueType))
		{
			return value;
		}
		if (valueType.IsNullableValueType())
		{
			return valueType.GetProperty("Value").GetValue(value, null).ConvertTo(targetType);
		}
		if (targetType.IsNullableValueType())
		{
			return targetType.CreateInstance(value.ConvertTo(targetType.GetGenericArgument()));
		}
		if (typeof(IConvertible).IsAssignableFrom(valueType) && typeof(IConvertible).IsAssignableFrom(targetType))
		{
			return Convert.ChangeType(value, targetType, culture);
		}
		TypeConverter typeConverter = TypeDescriptor.GetConverter(targetType);
		if (typeConverter.IsNotNull() && !typeConverter.GetType().ReferenceEquals(typeof(TypeConverter)) && typeConverter.CanConvertFrom(valueType))
		{
			return typeConverter.ConvertFrom(null, culture, value);
		}
		typeConverter = TypeDescriptor.GetConverter(valueType);
		if (typeConverter.IsNotNull() && !typeConverter.GetType().ReferenceEquals(typeof(TypeConverter)) && typeConverter.CanConvertTo(targetType))
		{
			return typeConverter.ConvertTo(null, culture, value, targetType);
		}
		if (TypeMapper.IsMappable(valueType, targetType))
		{
			return TypeMapper.StaticMap(value, valueType, targetType);
		}
		if (conversion.IsNotNull())
		{
			try
			{
				return conversion(value, targetType);
			}
			catch (Exception ex)
			{
				throw new InvalidCastException(Literals.MSG_InvalidCast_2.FormatValue(value, targetType), ex);
			}
		}
		throw new InvalidCastException(Literals.MSG_InvalidCast_2.FormatValue(value, targetType));
	}

	/// <summary>
	/// 将当前值转换为目标类型的值
	/// </summary>
	/// <typeparam name="T">转换的目标类型</typeparam>
	/// <param name="value">当前值</param>
	/// <param name="culture">转换时使用的区域信息</param>
	/// <returns>转换后的值</returns>
	/// <remarks>如果当前值为空，则返回目标类型的默认值。</remarks>
	public static T ConvertTo<T>(this object value, CultureInfo culture = null)
	{
		if (value.IsNull())
		{
			return default(T);
		}
		return (T)value.ConvertTo(typeof(T), culture);
	}

	/// <summary>
	/// 将当前值转换为目标类型的值
	/// </summary>
	/// <typeparam name="T">转换的目标类型</typeparam>
	/// <param name="value">当前值</param>
	/// <param name="defaultValue">如果无法将当前值转换为目标类型，则返回该默认值</param>
	/// <param name="culture">转换时使用的区域信息</param>
	/// <returns>转换后的值</returns>
	/// <remarks>如果当前值为空，则返回目标类型的默认值。</remarks>
	public static T ConvertTo<T>(this object value, T defaultValue, CultureInfo culture = null)
	{
		if (value.IsNull())
		{
			return default(T);
		}
		return (T)value.ConvertTo(typeof(T), defaultValue, culture);
	}

	/// <summary>
	/// 将当前值转换为目标类型的值
	/// </summary>
	/// <typeparam name="T">转换的目标类型</typeparam>
	/// <param name="value">当前值</param>
	/// <param name="conversion">当前值到目标类型的转换方法</param>
	/// <param name="culture">转换时使用的区域信息</param>
	/// <returns>转换后的值</returns>
	/// <remarks>如果当前值为空，则返回目标类型的默认值。</remarks>
	public static T ConvertTo<T>(this object value, Func<object, Type, object> conversion, CultureInfo culture = null)
	{
		if (value.IsNull())
		{
			return default(T);
		}
		return (T)value.ConvertTo(typeof(T), conversion, culture);
	}

	/// <summary>
	/// 深度复制当前对象，返回复制后的对象
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="source">待复制的当前对象</param>
	/// <returns>复制的新对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象 <paramref name="source" /> 为空。</exception>
	public static T DeepCopy<T>(this T source)
	{
		return source.BinaryCopy();
	}

	/// <summary>
	/// 如果当前对象为空则返回DBNull，否则返回对象本身
	/// </summary>
	/// <param name="obj">待检测的值</param>
	/// <returns>如果对象为空则返回DBNull，否则返回对象本身</returns>
	public static object EnsureDBNull(this object obj)
	{
		return obj.IsNull() ? DBNull.Value : obj;
	}

	/// <summary>
	/// 如果当前对象为空则返回当前对象类型的默认值
	/// </summary>
	/// <param name="obj">当前对象</param>
	/// <param name="type">当前对象类型</param>
	/// <returns>当前对象本身或者对象类型的默认值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象类型 <paramref name="type" /> 为空。</exception>
	public static object EnsureDefault(this object obj, Type type)
	{
		type.GuardNotNull("type");
		return obj.IsNull() ? type.CreateDefault() : obj;
	}

	/// <summary>
	/// 如果当前对象为空则返回当前对象类型的默认值
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="obj">当前对象</param>
	/// <returns>当前对象本身或者对象类型的默认值</returns>
	public static T EnsureDefault<T>(this T obj)
	{
		return obj.IsNull() ? default(T) : obj;
	}

	/// <summary>
	/// 递归主体
	/// </summary>
	/// <typeparam name="A"></typeparam>
	/// <typeparam name="R"></typeparam>
	/// <param name="f"></param>
	/// <returns></returns>
	private static Func<A, R> RH<A, R>(Func<Func<A, R>, Func<A, R>> f)
	{
		RD<A, R> rd = (RD<A, R> r) => (A a) => f(r(r))(a);
		return rd(rd);
	}

	/// <summary>
	/// 递归获取对象的属性值，对象的属性应返回枚举数，且枚举元素类型与该元素相同；不存在枚举元素时应返回空集合
	/// </summary>
	/// <typeparam name="T">对象类型，枚举元素类型</typeparam>
	/// <param name="obj">当前待处理的对象</param>
	/// <param name="selector">对象属性值选择器</param>
	/// <param name="predicate">筛选条件</param>
	/// <returns>对象属性值枚举数</returns>
	public static IEnumerable<T> Enumerate<T>(this T obj, Func<T, IEnumerable<T>> selector, Func<T, bool> predicate = null)
	{
		obj.GuardNotNull();
		selector.GuardNotNull();
		predicate = predicate.IfNull((T x) => true);
		return RH((Func<T, IEnumerable<T>> f) => (T s) => selector(obj).Where(predicate).Concat(selector(obj).Where(predicate).SelectMany(f)))(obj);
	}

	/// <summary>
	/// 将当前对象格式化为字符串
	/// </summary>
	/// <param name="obj">当前对象</param>
	/// <param name="format">格式化字符串</param>
	/// <param name="provider">格式化</param>
	/// <returns>格式化后的对象字符串表示；如果当前对象为空，则返回 <see cref="F:System.String.Empty" />；如果格式化字符串为空，则返回当前对象的 <see cref="M:System.Object.ToString" /> 返回值。</returns>
	public static string FormatUsing(this object obj, string format, IFormatProvider provider = null)
	{
		if (obj.IsNull())
		{
			return string.Empty;
		}
		if (format.IsNullOrEmpty())
		{
			return obj.ToString();
		}
		return string.Format(provider, format, new object[1] { obj });
	}

	/// <summary>
	/// 将当前对象格式化为字符串
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="obj">当前对象</param>
	/// <param name="formatting">自定义格式化方法</param>
	/// <returns>格式化后的对象字符串表示</returns>
	/// <remarks>如果 <paramref name="formatting" /> 为空，则调用 <see cref="M:System.Object.ToString" /> 方法生成对象的字符串表示。</remarks>
	public static string FormatUsing<T>(this T obj, Func<T, string> formatting)
	{
		formatting = formatting.IfNull((T x) => x.ToString());
		return formatting(obj);
	}

	/// <summary>
	/// 获取当前对象上与给定属性路径匹配的公共实例属性
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="propertyPath">属性路径</param>
	/// <param name="owner">当前层级属性的所有者对象</param>
	/// <param name="ignoreCase">属性路径中各级属性名称是否区分大小写，默认为false。</param>
	/// <returns>与属性路径匹配的属性对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者 <paramref name="propertyPath" /> 为空或者空串。</exception>
	public static PropertyInfo GetProperty(this object item, string propertyPath, out object owner, bool ignoreCase = false)
	{
		return GetProperty(item, propertyPath, (Type t, string n) => t.GetProperty(n, ignoreCase), out owner);
	}

	/// <summary>
	/// 获取当前对象上与给定属性路径匹配的属性
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="propertyPath">属性路径</param>
	/// <param name="flags">属性的绑定条件</param>
	/// <param name="owner">当前层级属性的所有者对象</param>
	/// <param name="ignoreCase">属性路径中各级属性名称是否区分大小写，默认为false。</param>
	/// <returns>与属性路径匹配的属性对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者 <paramref name="propertyPath" /> 为空或者空串。</exception>
	public static PropertyInfo GetProperty(this object item, string propertyPath, BindingFlags flags, out object owner, bool ignoreCase = false)
	{
		return GetProperty(item, propertyPath, (Type t, string n) => t.GetProperty(n, flags, ignoreCase), out owner);
	}

	private static PropertyInfo GetProperty(object item, string propertyPath, Func<Type, string, PropertyInfo> getter, out object owner)
	{
		item.GuardNotNull("item");
		propertyPath.GuardNotNullAndEmpty("Property Path");
		owner = null;
		string[] propertyNames = propertyPath.Split(new char[1] { '.' }, StringSplitOptions.None);
		object handler = item;
		PropertyInfo property = null;
		string[] array = propertyNames;
		foreach (string propertyName in array)
		{
			if (handler.IsNull())
			{
				owner = null;
				return null;
			}
			property = getter(handler.GetType(), propertyName);
			if (property.IsNull())
			{
				owner = null;
				return null;
			}
			owner = handler;
			handler = property.GetValue(handler, null);
		}
		return property;
	}

	/// <summary>
	/// 获取当前对象上与给定属性路径匹配的实例公共属性的值，如果未找到指定的属性则抛出异常。
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="propertyPath">属性路径</param>
	/// <param name="ignoreCase">属性路径中各级属性名称是否区分大小写，默认为false。</param>
	/// <returns>与属性路径匹配的属性的值</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="item" /> 为空，或者 <paramref name="propertyPath" /> 为空或者空串。</exception>
	/// <exception cref="T:System.MissingMemberException">属性路径 <paramref name="propertyPath" /> 指定的属性未找到。</exception>
	/// <exception cref="T:System.Reflection.TargetException">属性路径 <paramref name="propertyPath" /> 指定的属性不可读。</exception>
	/// <remarks>本方法按照指定的属性路径获取对象的属性、对象属性的属性（对象属性值时对象时）等任意层级的属性值。</remarks>
	public static object GetPropertyValue(this object item, string propertyPath, bool ignoreCase = false)
	{
		item.GuardNotNull("item");
		propertyPath.GuardNotNullAndEmpty("Property Path");
		object owner = null;
		PropertyInfo pinfo = item.GetProperty(propertyPath, out owner, ignoreCase);
		if (pinfo.IsNotNull())
		{
			pinfo.Guard(pinfo.CanRead, () => new TargetException(Literals.MSG_ObjectPropertyUnreadable));
			return pinfo.GetValue(owner, null);
		}
		throw new MissingMemberException(item.GetType().FullName, propertyPath);
	}

	/// <summary>
	/// 获取当前对象上与给定属性路径匹配的实例公共属性的值，如果未找到指定的默认值。
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="propertyPath">属性路径</param>
	/// <param name="defaultValue">指定名称的属性不存在时返回的默认值</param>
	/// <param name="ignoreCase">属性路径中各级属性名称是否区分大小写，默认为false。</param>
	/// <returns>与属性路径匹配的属性的值</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="item" /> 为空，或者 <paramref name="propertyPath" /> 为空或者空串。</exception>
	/// <exception cref="T:System.MissingMemberException">属性路径 <paramref name="propertyPath" /> 指定的属性未找到。</exception>
	/// <exception cref="T:System.Reflection.TargetException">属性路径 <paramref name="propertyPath" /> 指定的属性不可读。</exception>
	/// <remarks>本方法按照指定的属性路径获取对象的属性、对象属性的属性（对象属性值时对象时）等任意层级的属性值。</remarks>
	public static object GetPropertyValue(this object item, string propertyPath, object defaultValue, bool ignoreCase = false)
	{
		item.GuardNotNull("item");
		propertyPath.GuardNotNullAndEmpty("Property Path");
		object owner = null;
		PropertyInfo pinfo = item.GetProperty(propertyPath, out owner, ignoreCase);
		if (pinfo.IsNotNull())
		{
			pinfo.Guard(pinfo.CanRead, () => new TargetException(Literals.MSG_ObjectPropertyUnreadable));
			return pinfo.GetValue(owner, null);
		}
		return defaultValue;
	}

	/// <summary>
	/// 获取当前对象上与给定属性路径匹配的属性的值，如果未找到指定的属性则抛出异常。
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="propertyPath">属性路径</param>
	/// <param name="flags">属性绑定标志</param>
	/// <param name="ignoreCase">属性路径中各级属性名称是否区分大小写，默认为false。</param>
	/// <returns>与属性路径匹配的属性的值</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="item" /> 为空，或者 <paramref name="propertyPath" /> 为空或者空串。</exception>
	/// <exception cref="T:System.MissingMemberException">属性路径 <paramref name="propertyPath" /> 指定的属性未找到。</exception>
	/// <exception cref="T:System.Reflection.TargetException">属性路径 <paramref name="propertyPath" /> 指定的属性不可读。</exception>
	/// <remarks>本方法按照指定的属性路径获取对象的属性、对象属性的属性（对象属性值时对象时）等任意层级的属性值。</remarks>
	public static object GetPropertyValue(this object item, string propertyPath, BindingFlags flags, bool ignoreCase = false)
	{
		item.GuardNotNull("item");
		propertyPath.GuardNotNullAndEmpty("Property Path");
		object owner = null;
		PropertyInfo pinfo = item.GetProperty(propertyPath, flags, out owner, ignoreCase);
		if (pinfo.IsNotNull())
		{
			pinfo.Guard(pinfo.CanRead, () => new TargetException(Literals.MSG_ObjectPropertyUnreadable));
			return pinfo.GetValue(owner, null);
		}
		throw new MissingMemberException(item.GetType().FullName, propertyPath);
	}

	/// <summary>
	/// 获取当前对象上与给定属性路径匹配的属性的值，如果未找到指定的属性则抛出异常。
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="propertyPath">属性路径</param>
	/// <param name="flags">属性绑定标志</param>
	/// <param name="defaultValue">指定名称的属性不存在时返回的默认值</param>
	/// <param name="ignoreCase">属性路径中各级属性名称是否区分大小写，默认为false。</param>
	/// <returns>与属性路径匹配的属性的值</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="item" /> 为空，或者 <paramref name="propertyPath" /> 为空或者空串。</exception>
	/// <exception cref="T:System.MissingMemberException">属性路径 <paramref name="propertyPath" /> 指定的属性未找到。</exception>
	/// <exception cref="T:System.Reflection.TargetException">属性路径 <paramref name="propertyPath" /> 指定的属性不可读。</exception>
	/// <remarks>本方法按照指定的属性路径获取对象的属性、对象属性的属性（对象属性值时对象时）等任意层级的属性值。</remarks>
	public static object GetPropertyValue(this object item, string propertyPath, BindingFlags flags, object defaultValue, bool ignoreCase = false)
	{
		item.GuardNotNull("item");
		propertyPath.GuardNotNullAndEmpty("Property Path");
		object owner = null;
		PropertyInfo pinfo = item.GetProperty(propertyPath, flags, out owner, ignoreCase);
		if (pinfo.IsNotNull())
		{
			pinfo.Guard(pinfo.CanRead, () => new TargetException(Literals.MSG_ObjectPropertyUnreadable));
			return pinfo.GetValue(owner, null);
		}
		return defaultValue;
	}

	/// <summary>
	/// 获取当前对象上与给定属性路径匹配的实例公共属性的值，如果未找到指定的属性则抛出异常。
	/// </summary>
	/// <typeparam name="T">属性值类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="propertyPath">属性路径</param>
	/// <param name="ignoreCase">属性路径中各级属性名称是否区分大小写，默认为false。</param>
	/// <returns>与属性路径匹配的属性的值</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="item" /> 为空，或者 <paramref name="propertyPath" /> 为空或者空串。</exception>
	/// <exception cref="T:System.MissingMemberException">属性路径 <paramref name="propertyPath" /> 指定的属性未找到。</exception>
	/// <exception cref="T:System.Reflection.TargetException">属性路径 <paramref name="propertyPath" /> 指定的属性不可读。</exception>
	/// <remarks>本方法按照指定的属性路径获取对象的属性、对象属性的属性（对象属性值时对象时）等任意层级的属性值。</remarks>
	public static T GetPropertyValue<T>(this object item, string propertyPath, bool ignoreCase = false)
	{
		return item.GetPropertyValue(propertyPath, ignoreCase).ConvertTo<T>();
	}

	/// <summary>
	/// 获取当前对象上与给定属性路径匹配的实例公共属性的值，如果未找到指定的默认值。
	/// </summary>
	/// <typeparam name="T">属性值类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="propertyPath">属性路径</param>
	/// <param name="defaultValue">指定名称的属性不存在时返回的默认值</param>
	/// <param name="ignoreCase">属性路径中各级属性名称是否区分大小写，默认为false。</param>
	/// <returns>与属性路径匹配的属性的值</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="item" /> 为空，或者 <paramref name="propertyPath" /> 为空或者空串。</exception>
	/// <exception cref="T:System.MissingMemberException">属性路径 <paramref name="propertyPath" /> 指定的属性未找到。</exception>
	/// <exception cref="T:System.Reflection.TargetException">属性路径 <paramref name="propertyPath" /> 指定的属性不可读。</exception>
	/// <remarks>本方法按照指定的属性路径获取对象的属性、对象属性的属性（对象属性值时对象时）等任意层级的属性值。</remarks>
	public static T GetPropertyValue<T>(this object item, string propertyPath, T defaultValue, bool ignoreCase = false)
	{
		return item.GetPropertyValue(propertyPath, defaultValue, ignoreCase).ConvertTo<T>();
	}

	/// <summary>
	/// 获取当前对象上与给定属性路径匹配的属性的值，如果未找到指定的属性则抛出异常。
	/// </summary>
	/// <typeparam name="T">属性值类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="propertyPath">属性路径</param>
	/// <param name="flags">属性绑定标志</param>
	/// <param name="ignoreCase">属性路径中各级属性名称是否区分大小写，默认为false。</param>
	/// <returns>与属性路径匹配的属性的值</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="item" /> 为空，或者 <paramref name="propertyPath" /> 为空或者空串。</exception>
	/// <exception cref="T:System.MissingMemberException">属性路径 <paramref name="propertyPath" /> 指定的属性未找到。</exception>
	/// <exception cref="T:System.Reflection.TargetException">属性路径 <paramref name="propertyPath" /> 指定的属性不可读。</exception>
	/// <remarks>本方法按照指定的属性路径获取对象的属性、对象属性的属性（对象属性值时对象时）等任意层级的属性值。</remarks>
	public static T GetPropertyValue<T>(this object item, string propertyPath, BindingFlags flags, bool ignoreCase = false)
	{
		return item.GetPropertyValue(propertyPath, flags, ignoreCase).ConvertTo<T>();
	}

	/// <summary>
	/// 获取当前对象上与给定属性路径匹配的属性的值，如果未找到指定的属性则抛出异常。
	/// </summary>
	/// <typeparam name="T">属性值类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="propertyPath">属性路径</param>
	/// <param name="flags">属性绑定标志</param>
	/// <param name="defaultValue">指定名称的属性不存在时返回的默认值</param>
	/// <param name="ignoreCase">属性路径中各级属性名称是否区分大小写，默认为false。</param>
	/// <returns>与属性路径匹配的属性的值</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="item" /> 为空，或者 <paramref name="propertyPath" /> 为空或者空串。</exception>
	/// <exception cref="T:System.MissingMemberException">属性路径 <paramref name="propertyPath" /> 指定的属性未找到。</exception>
	/// <exception cref="T:System.Reflection.TargetException">属性路径 <paramref name="propertyPath" /> 指定的属性不可读。</exception>
	/// <remarks>本方法按照指定的属性路径获取对象的属性、对象属性的属性（对象属性值时对象时）等任意层级的属性值。</remarks>
	public static T GetPropertyValue<T>(this object item, string propertyPath, BindingFlags flags, T defaultValue, bool ignoreCase = false)
	{
		return item.GetPropertyValue(propertyPath, flags, defaultValue, ignoreCase).ConvertTo<T>();
	}

	/// <summary>
	/// 检测当前对象是否满足指定条件，不满足则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="condition">要测试的条件表达式</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">错误消息</param>
	/// <exception cref="T:System.ArgumentException">测试的条件表达式 <paramref name="condition" /> 为false。</exception>
	public static void Guard(this object item, bool condition, string name = null, string message = null)
	{
		if (!condition)
		{
			throw new ArgumentException(message.IfNull(Literals.MSG_ValueError_1.FormatValue(item)), name.IfNull("Condition"));
		}
	}

	/// <summary>
	/// 检测当前对象是否满足指定条件，不满足则抛出由参数 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="condition">要测试的条件表达式</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <exception cref="T:System.ArgumentNullException">异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常生成方法 <paramref name="exceptionCreator" /> 执行异常或者返回空。</exception>
	/// <exception cref="T:System.Exception">当测试的条件表达式 <paramref name="condition" /> 为false时，抛出由参数 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static void Guard(this object item, bool condition, Func<Exception> exceptionCreator)
	{
		if (exceptionCreator.IsNull())
		{
			throw new ArgumentNullException("Exception Creator", Literals.MSG_ExceptionCreatorNull);
		}
		if (!condition)
		{
			Exception exception = null;
			try
			{
				exception = exceptionCreator();
			}
			catch (Exception ex)
			{
				throw new TargetInvocationException(Literals.MSG_ExceptionCreatingFailed, ex);
			}
			if (exception.IsNull())
			{
				throw new TargetInvocationException(Literals.MSG_ExceptionCreatingFailed, null);
			}
			throw exception;
		}
	}

	/// <summary>
	/// 检测当前对象是否满足指定条件，不满足则抛出由参数 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="condition">要测试的条件表达式</param>
	/// <param name="exceptionType">不满足条件时抛出的异常类型</param>
	/// <param name="args">异常参数列表</param>
	/// <exception cref="T:System.ArgumentNullException">异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">异常类型 <paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常类型 <paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当测试的条件表达式 <paramref name="condition" /> 为false时，抛出由参数 <paramref name="exceptionType" /> 指定的异常</exception>
	public static void Guard(this object item, bool condition, Type exceptionType, params object[] args)
	{
		if (exceptionType.IsNull())
		{
			throw new ArgumentNullException("Exception Type", Literals.MSG_ExceptionTypeNull);
		}
		if (!typeof(Exception).IsAssignableFrom(exceptionType))
		{
			throw new NotSupportedException(Literals.MSG_ExceptionTypeError);
		}
		if (!condition)
		{
			try
			{
				throw (Exception)Activator.CreateInstance(exceptionType, args);
			}
			catch (Exception ex)
			{
				throw new TargetInvocationException(Literals.MSG_ExceptionCreatingFailed, ex);
			}
		}
	}

	/// <summary>
	/// 检测当前对象是否满足指定断言，不满足则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="predicate">检测断言</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过则返回当前对象本身</returns>
	/// <exception cref="T:System.ArgumentNullException">检测断言 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">检测断言 <paramref name="predicate" /> 返回值为false。</exception>
	public static T Guard<T>(this T item, Func<T, bool> predicate, string name = null, string message = null)
	{
		predicate.GuardNotNull("predicate", Literals.MSG_PredicateNull);
		item.Guard(predicate(item), name, message);
		return item;
	}

	/// <summary>
	/// 检测当前对象是否满足指定断言，不满足则抛出参数 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="predicate">检测断言</param>
	/// <param name="exceptionCreator">异常生成器</param>
	/// <returns>如果检测通过则返回当前对象本身</returns>
	/// <exception cref="T:System.ArgumentNullException">检测断言 <paramref name="predicate" /> 为空；或者异常生成器 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常生成器 <paramref name="exceptionCreator" /> 执行异常或者返回空。</exception>
	/// <exception cref="T:System.Exception">当检测断言 <paramref name="predicate" /> 返回值为false时，抛出由参数 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static T Guard<T>(this T item, Func<T, bool> predicate, Func<Exception> exceptionCreator)
	{
		predicate.GuardNotNull("predicate", Literals.MSG_PredicateNull);
		item.Guard(predicate(item), exceptionCreator);
		return item;
	}

	/// <summary>
	/// 检测当前对象是否满足指定断言，不满足则抛出由参数 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="predicate">检测断言</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检测通过则返回当前对象本身</returns>
	/// <exception cref="T:System.ArgumentNullException">检测断言 <paramref name="predicate" /> 为空；或者 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">异常类型 <paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常类型 <paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当检测断言 <paramref name="predicate" /> 返回值为false时，抛出由参数 <paramref name="exceptionType" /> 指定的异常</exception>
	public static T Guard<T>(this T item, Func<T, bool> predicate, Type exceptionType, params object[] args)
	{
		predicate.GuardNotNull("predicate", Literals.MSG_PredicateNull);
		item.Guard(predicate(item), exceptionType, args);
		return item;
	}

	/// <summary>
	/// 检测当前对象是否在指定范围内，超出指定的值范围则抛出 <see cref="T:System.ArgumentOutOfRangeException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="min">最小值</param>
	/// <param name="max">最大值</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">错误消息</param>
	/// <param name="comparison">对象值比较器</param>
	/// <param name="includeMin">值范围是否包含最小值，默认包含最小值</param>
	/// <param name="includeMax">值范围是否包含最大值，默认包含最大值</param>
	/// <returns>如果检测通过则返回当前对象</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException">当前对象超出指定的范围。</exception>
	/// <exception cref="T:System.ArgumentException">最小值 <paramref name="min" /> 大于最大值 <paramref name="max" />。</exception>
	public static T GuardBetween<T>(this T item, T min, T max, string name, string message, Func<T, T, int> comparison, bool includeMin = true, bool includeMax = true)
	{
		item.Guard(item.Between(min, max, comparison, includeMin, includeMax), () => new ArgumentOutOfRangeException(name.IfNull("item"), message.IfNull(Literals.MSG_ValueOutOfRange)));
		return item;
	}

	/// <summary>
	/// 检测当前对象是否在指定范围内，超出指定的值范围则抛出参数 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="min">最小值</param>
	/// <param name="max">最大值</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <param name="comparison">对象值比较方法</param>
	/// <param name="includeMin">值范围是否包含最小值，默认包含最小值</param>
	/// <param name="includeMax">值范围是否包含最大值，默认包含最大值</param>
	/// <returns>如果检测通过则返回当前对象</returns>
	/// <exception cref="T:System.ArgumentNullException">异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">范围最小值 <paramref name="min" /> 大于最大值 <paramref name="max" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常生成方法 <paramref name="exceptionCreator" /> 执行异常或者返回空。</exception>
	/// <exception cref="T:System.Exception">当前对象超出指定的范围，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static T GuardBetween<T>(this T item, T min, T max, Func<Exception> exceptionCreator, Func<T, T, int> comparison, bool includeMin = true, bool includeMax = true)
	{
		item.Guard(item.Between(min, max, comparison, includeMin, includeMax), exceptionCreator);
		return item;
	}

	/// <summary>
	/// 检测当前对象是否在指定范围内，超出指定的值范围则抛出参数 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="min">最小值</param>
	/// <param name="max">最大值</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <param name="comparison">对象值比较方法</param>
	/// <param name="includeMin">值范围是否包含最小值，默认包含最小值</param>
	/// <param name="includeMax">值范围是否包含最大值，默认包含最大值</param>
	/// <returns>如果检测通过则返回当前对象</returns>
	/// <exception cref="T:System.ArgumentNullException">异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">范围最小值 <paramref name="min" /> 大于最大值 <paramref name="max" />。</exception>
	/// <exception cref="T:System.NotSupportedException">异常类型 <paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象超出指定的范围，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static T GuardBetween<T>(this T item, T min, T max, Type exceptionType, object[] args, Func<T, T, int> comparison, bool includeMin = true, bool includeMax = true)
	{
		item.Guard(item.Between(min, max, comparison, includeMin, includeMax), exceptionType, args);
		return item;
	}

	/// <summary>
	/// 检测当前对象是否不在指定范围内，在指定的值范围则抛出 <see cref="T:System.ArgumentOutOfRangeException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="min">最小值</param>
	/// <param name="max">最大值</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">错误消息</param>
	/// <param name="comparison">对象值比较器</param>
	/// <param name="includeMin">值范围是否包含最小值，默认包含最小值</param>
	/// <param name="includeMax">值范围是否包含最大值，默认包含最大值</param>
	/// <returns>如果检测通过则返回当前对象</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException">当前对象在指定的范围中。</exception>
	/// <exception cref="T:System.ArgumentException">范围最小值 <paramref name="min" /> 大于最大值 <paramref name="max" />。</exception>
	public static T GuardNotBetween<T>(this T item, T min, T max, string name, string message, Func<T, T, int> comparison, bool includeMin = true, bool includeMax = true)
	{
		item.Guard(item.NotBetween(min, max, comparison, includeMin, includeMax), () => new ArgumentOutOfRangeException(name.IfNull("item"), message.IfNull(Literals.MSG_ValueInRange)));
		return item;
	}

	/// <summary>
	/// 检测当前对象是否不在指定范围内，在指定的值范围则抛出参数 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="min">最小值</param>
	/// <param name="max">最大值</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <param name="comparison">对象值比较方法</param>
	/// <param name="includeMin">值范围是否包含最小值，默认包含最小值</param>
	/// <param name="includeMax">值范围是否包含最大值，默认包含最大值</param>
	/// <returns>如果检测通过则返回当前对象</returns>
	/// <exception cref="T:System.ArgumentNullException">异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">范围最小值 <paramref name="min" /> 大于最大值 <paramref name="max" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前对象在指定的范围中，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static T GuardNotBetween<T>(this T item, T min, T max, Func<Exception> exceptionCreator, Func<T, T, int> comparison, bool includeMin = true, bool includeMax = true)
	{
		item.Guard(item.NotBetween(min, max, comparison, includeMin, includeMax), exceptionCreator);
		return item;
	}

	/// <summary>
	/// 检测当前对象是否不在指定范围内，在指定的值范围则抛出参数 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="min">最小值</param>
	/// <param name="max">最大值</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <param name="comparison">对象值比较方法</param>
	/// <param name="includeMin">值范围是否包含最小值，默认包含最小值</param>
	/// <param name="includeMax">值范围是否包含最大值，默认包含最大值</param>
	/// <returns>如果检测通过则返回当前对象</returns>
	/// <exception cref="T:System.ArgumentNullException">异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">范围最小值 <paramref name="min" /> 大于最大值 <paramref name="max" />。</exception>
	/// <exception cref="T:System.NotSupportedException">异常类型 <paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常类型 <paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象在指定的范围中，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static T GuardNotBetween<T>(this T item, T min, T max, Type exceptionType, object[] args, Func<T, T, int> comparison, bool includeMin = true, bool includeMax = true)
	{
		item.Guard(item.NotBetween(min, max, comparison, includeMin, includeMax), exceptionType, args);
		return item;
	}

	/// <summary>
	/// 检测当前对象是否等于其类型的默认值，如果对象不等于其类型的默认值则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="type">当前对象类型</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过则返回当前对象</returns>
	/// <exception cref="T:System.ArgumentException">当前对象不等于其类型的默认值。</exception>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空时，对象类型也为空。</exception>
	public static object GuardDefault(this object item, Type type = null, string name = null, string message = null)
	{
		item.Guard(item.IsDefault(type), name.IfNull("item"), message.IfNull(Literals.MSG_ValueNotDefault));
		return item;
	}

	/// <summary>
	/// 检测当前对象是否等于其类型的默认值，如果对象不等于其类型的默认值则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过则返回当前对象</returns>
	/// <exception cref="T:System.ArgumentException">当前对象不等于其类型的默认值。</exception>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空时，对象类型也为空。</exception>
	public static T GuardDefault<T>(this T item, string name = null, string message = null)
	{
		item.Guard(item.IsDefault(), name.IfNull("item"), message.IfNull(Literals.MSG_ValueNotDefault));
		return item;
	}

	/// <summary>
	/// 检测当前对象是否等于其类型的默认值，如果对象不等于其类型的默认值则抛出参数 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过则返回当前对象</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前对象不等于其类型的默认值，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static T GuardDefault<T>(this T item, Func<Exception> exceptionCreator)
	{
		item.Guard(item.IsDefault(), exceptionCreator);
		return item;
	}

	/// <summary>
	/// 检测当前对象是否等于其类型的默认值，如果对象不等于其类型的默认值则抛出参数 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检测通过则返回当前对象</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象不等于其类型的默认值，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static T GuardDefault<T>(this T item, Type exceptionType, object[] args = null)
	{
		item.Guard(item.IsDefault(), exceptionType, args);
		return item;
	}

	/// <summary>
	/// 检测当前对象是否不等于其类型的默认值，如果对象等于其类型的默认值则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="type">当前对象类型</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过则返回当前对象</returns>
	/// <exception cref="T:System.ArgumentException">当前对象等于其类型的默认值。</exception>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空时，对象类型也为空。</exception>
	public static object GuardNotDefault(this object item, Type type = null, string name = null, string message = null)
	{
		item.Guard(item.IsNotDefault(type), name.IfNull("item"), message.IfNull(Literals.MSG_ValueNotDefault));
		return item;
	}

	/// <summary>
	/// 检测当前对象是否不等于其类型的默认值，如果对象等于其类型的默认值则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过则返回当前对象</returns>
	/// <exception cref="T:System.ArgumentException">当前对象等于其类型的默认值。</exception>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空时，对象类型也为空。</exception>
	public static T GuardNotDefault<T>(this T item, string name = null, string message = null)
	{
		item.Guard(item.IsNotDefault(), name.IfNull("item"), message.IfNull(Literals.MSG_ValueNotDefault));
		return item;
	}

	/// <summary>
	/// 检测当前对象是否不等于其类型的默认值，如果对象等于其类型的默认值则抛出参数 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过则返回当前对象</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前对象等于其类型的默认值，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static T GuardNotDefault<T>(this T item, Func<Exception> exceptionCreator)
	{
		item.Guard(item.IsNotDefault(), exceptionCreator);
		return item;
	}

	/// <summary>
	/// 检测当前对象是否不等于其类型的默认值，如果对象等于其类型的默认值则抛出参数 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检测通过则返回当前对象</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象等于其类型的默认值，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static T GuardNotDefault<T>(this T item, Type exceptionType, object[] args = null)
	{
		item.Guard(item.IsNotDefault(), exceptionType, args);
		return item;
	}

	/// <summary>
	/// 检测当前对象是否等于指定值，如果不等于指定值则抛出 <see cref="T:System.ArgumentOutOfRangeException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <param name="equalition">对象相等比较方法</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException">当前对象不等于 <paramref name="value" /> 时。</exception>
	public static T GuardEqualTo<T>(this T item, T value, string name, string message, Func<T, T, bool> equalition)
	{
		item.Guard(item.IsEqualTo(value, equalition), () => new ArgumentOutOfRangeException(name.IfNull("item"), message.IfNull(Literals.MSG_ValueNotEqualToTarget_1.FormatValue(value))));
		return item;
	}

	/// <summary>
	/// 检测当前对象是否等于指定值，如果不等于指定值则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <param name="equalition">对象相等比较方法</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException">异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常生成方法 <paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前对象的值不等于 <paramref name="value" /> 的值，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static T GuardEqualTo<T>(this T item, T value, Func<Exception> exceptionCreator, Func<T, T, bool> equalition)
	{
		item.Guard(item.IsEqualTo(value, equalition), exceptionCreator);
		return item;
	}

	/// <summary>
	/// 检测当前对象是否等于指定值，如果不等于指定值则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <param name="equalition">对象相等比较方法</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException">异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">异常类型 <paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常类型 <paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象的值不等于 <paramref name="value" /> 的值，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static T GuardEqualTo<T>(this T item, T value, Type exceptionType, object[] args, Func<T, T, bool> equalition)
	{
		item.Guard(item.IsEqualTo(value, equalition), exceptionType, args);
		return item;
	}

	/// <summary>
	/// 检测当前对象是否不等于指定值，如果等于指定值则抛出 <see cref="T:System.ArgumentOutOfRangeException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前对象的类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <param name="equalition">对象相等比较方法</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException">当前对象等于 <paramref name="value" /> 时。</exception>
	public static T GuardNotEqualTo<T>(this T item, T value, string name, string message, Func<T, T, bool> equalition)
	{
		item.Guard(item.IsNotEqualTo(value, equalition), () => new ArgumentOutOfRangeException(name.IfNull("item"), message.IfNull(Literals.MSG_ValueEqualToTarget_1.FormatValue(value))));
		return item;
	}

	/// <summary>
	/// 检测当前对象是否不等于指定值，如果等于指定值则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">当前对象的类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="equalition">对象相等比较方法</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException">异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常生成方法 <paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前对象的值等于 <paramref name="value" /> 的值，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static T GuardNotEqualTo<T>(this T item, T value, Func<Exception> exceptionCreator, Func<T, T, bool> equalition)
	{
		item.Guard(item.IsNotEqualTo(value, equalition), exceptionCreator);
		return item;
	}

	/// <summary>
	/// 检测当前对象是否不等于指定值，如果等于指定值则抛出  <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <param name="equalition">对象相等比较方法</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException">异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">异常类型 <paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常类型 <paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象的值等于 <paramref name="value" /> 的值，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static T GuardNotEqualTo<T>(this T item, T value, Type exceptionType, object[] args, Func<T, T, bool> equalition)
	{
		item.Guard(item.IsNotEqualTo(value, equalition), exceptionType, args);
		return item;
	}

	/// <summary>
	/// 检测指定的处理是否抛出任意异常，如果未抛出异常，则抛出 <see cref="T:System.InvalidOperationException" /> 异常
	/// </summary>
	/// <typeparam name="T">待处理的对象类型</typeparam>
	/// <param name="item">待处理的对象</param>
	/// <param name="action">对象处理方法</param>
	/// <param name="message">没有出现期望的异常时的消息</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">如果 <paramref name="action" /> 没有抛出异常，则抛出该异常。</exception>
	public static void GuardException<T>(this T item, Action<T> action, string message = null)
	{
		item.GuardException(action, typeof(Exception), message);
	}

	/// <summary>
	/// 检测指定的处理是否抛出任意异常，如果未抛出异常，则抛出参数 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">待处理的对象类型</typeparam>
	/// <param name="item">待处理的对象</param>
	/// <param name="action">对象处理方法</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="action" /> 为空；或者 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception"><paramref name="action" /> 没有抛出异常，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static void GuardException<T>(this T item, Action<T> action, Func<Exception> exceptionCreator)
	{
		item.GuardException(action, typeof(Exception), exceptionCreator);
	}

	/// <summary>
	/// 检测指定的处理是否抛出任意异常，如果未抛出异常，则抛出参数 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <typeparam name="T">待处理的对象类型</typeparam>
	/// <param name="item">待处理的对象</param>
	/// <param name="action">对象处理方法</param>
	/// <param name="exceptionType">抛出的指定的异常</param>
	/// <param name="args">异常参数</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="action" /> 为空；或者 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception"><paramref name="action" /> 没有抛出异常，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static void GuardException<T>(this T item, Action<T> action, Type exceptionType, params object[] args)
	{
		item.GuardException(action, typeof(Exception), exceptionType, args);
	}

	/// <summary>
	/// 检测指定的处理是否抛出期望的异常，如果未抛出期望的异常，则抛出 <see cref="T:System.InvalidOperationException" /> 异常
	/// </summary>
	/// <typeparam name="T">待处理的对象类型</typeparam>
	/// <param name="item">待处理的对象</param>
	/// <param name="action">对象处理方法</param>
	/// <param name="expectedException">期望抛出的异常类型</param>
	/// <param name="message">没有出现期望的异常时的消息</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="action" /> 为空；或者 <paramref name="expectedException" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="expectedException" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.InvalidOperationException">如果 <paramref name="action" /> 没有抛出 <paramref name="expectedException" /> 指定的异常，则抛出该异常。</exception>
	/// <remarks>指定的处理 <paramref name="action" /> 应抛出异常，该异常应是 <paramref name="expectedException" /> 指定的类型或者是从 <paramref name="expectedException" /> 继承的类型；否则将抛出异常。</remarks>
	public static void GuardException<T>(this T item, Action<T> action, Type expectedException, string message = null)
	{
		action.GuardNotNull("Action", Literals.MSG_ActionNull);
		expectedException.GuardNotNull("Expected Exception", Literals.MSG_ExpectedExceptionTypeNull);
		if (!typeof(Exception).IsAssignableFrom(expectedException))
		{
			throw new NotSupportedException(Literals.MSG_ExpectedExceptionError);
		}
		try
		{
			action(item);
		}
		catch (Exception ex)
		{
			if (expectedException.IsAssignableFrom(ex.GetType()))
			{
				return;
			}
		}
		throw new InvalidOperationException(message.IfNull(Literals.MSG_ExpectedExceptionNotOccured));
	}

	/// <summary>
	/// 检测指定的处理是否抛出期望的异常，如果未抛出期望的异常，则抛出参数 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">待处理的对象类型</typeparam>
	/// <param name="item">待处理的对象</param>
	/// <param name="action">对象处理方法</param>
	/// <param name="expectedException">期望的异常类型</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="action" /> 为空；或者 <paramref name="expectedException" /> 为空；或者 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="expectedException" /> 不是继承于 <see cref="T:System.Exception" /></exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception"><paramref name="action" /> 没有抛出 <paramref name="expectedException" /> 指定的异常，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	/// <remarks>指定的处理 <paramref name="action" /> 应抛出异常，该异常应是 <paramref name="expectedException" /> 指定的类型或者是从 <paramref name="expectedException" /> 继承的类型；否则将抛出异常。</remarks>
	public static void GuardException<T>(this T item, Action<T> action, Type expectedException, Func<Exception> exceptionCreator)
	{
		action.GuardNotNull("Action", Literals.MSG_ActionNull);
		expectedException.GuardNotNull("Expected Exception", Literals.MSG_ExpectedExceptionTypeNull);
		if (!typeof(Exception).IsAssignableFrom(expectedException))
		{
			throw new NotSupportedException(Literals.MSG_ExpectedExceptionError);
		}
		exceptionCreator.GuardNotNull("Exception Creator", Literals.MSG_ExceptionCreatorNull);
		try
		{
			action(item);
		}
		catch (Exception ex)
		{
			if (expectedException.IsAssignableFrom(ex.GetType()))
			{
				return;
			}
		}
		Exception exception = null;
		try
		{
			exception = exceptionCreator();
		}
		catch (Exception ex)
		{
			throw new TargetInvocationException(Literals.MSG_ExceptionCreatingFailed, ex);
		}
		if (exception.IsNull())
		{
			throw new TargetInvocationException(Literals.MSG_ExceptionCreatingFailed, null);
		}
		throw exception;
	}

	/// <summary>
	/// 检测指定的处理是否抛出期望的异常，如果未抛出期望的异常，则抛出参数 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <typeparam name="T">待处理的对象类型</typeparam>
	/// <param name="item">待处理的对象</param>
	/// <param name="action">对象处理方法</param>
	/// <param name="expectedException">期望的异常类型</param>
	/// <param name="exceptionType">抛出的指定的异常</param>
	/// <param name="args">异常参数</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="action" /> 为空；或者 <paramref name="expectedException" /> 为空；或者 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="expectedException" /> 不是继承于 <see cref="T:System.Exception" />；或者 <paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception"><paramref name="action" /> 未抛出符合参数 <paramref name="expectedException" /> 指定类型的异常，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	/// <remarks>指定的处理 <paramref name="action" /> 应抛出异常，该异常应是 <paramref name="expectedException" /> 指定的类型或者是从 <paramref name="expectedException" /> 继承的类型；否则将抛出异常。</remarks>
	public static void GuardException<T>(this T item, Action<T> action, Type expectedException, Type exceptionType, params object[] args)
	{
		action.GuardNotNull("Action", Literals.MSG_ActionNull);
		expectedException.GuardNotNull("Expected Exception", Literals.MSG_ExpectedExceptionTypeNull);
		if (!typeof(Exception).IsAssignableFrom(expectedException))
		{
			throw new NotSupportedException(Literals.MSG_ExpectedExceptionError);
		}
		exceptionType.GuardNotNull("Exception Type", Literals.MSG_ExceptionTypeNull);
		if (!typeof(Exception).IsAssignableFrom(exceptionType))
		{
			throw new NotSupportedException(Literals.MSG_ExceptionTypeError);
		}
		try
		{
			action(item);
		}
		catch (Exception ex2)
		{
			if (expectedException.IsAssignableFrom(ex2.GetType()))
			{
				return;
			}
		}
		try
		{
			throw (Exception)Activator.CreateInstance(exceptionType, args);
		}
		catch (Exception ex2)
		{
			throw new TargetInvocationException(Literals.MSG_ExceptionCreatingFailed, ex2);
		}
	}

	/// <summary>
	/// 检测当前对象是否大于指定值，如果不大于指定值则抛出 <see cref="T:System.ArgumentOutOfRangeException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <param name="comparison">对象比较方法</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException">当前对象小于等于 <paramref name="value" /> 的值。</exception>
	public static T GuardGreaterThan<T>(this T item, T value, string name, string message, Func<T, T, int> comparison)
	{
		item.Guard(item.IsGreaterThan(value, comparison), name.IfNull("item"), message.IfNull(Literals.MSG_ValueLessThanOrEqualToTarget_1.FormatValue(value)));
		return item;
	}

	/// <summary>
	/// 检测当前对象是否大于指定值，如果不大于指定值则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <param name="comparison">对象比较方法</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException">异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常生成方法 <paramref name="exceptionCreator" /> 执行异常或者返回空。</exception>
	/// <exception cref="T:System.Exception">当前对象的值小于等于 <paramref name="value" /> 的值，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static T GuardGreaterThan<T>(this T item, T value, Func<Exception> exceptionCreator, Func<T, T, int> comparison)
	{
		item.Guard(item.IsGreaterThan(value, comparison), exceptionCreator);
		return item;
	}

	/// <summary>
	/// 检测当前对象是否大于指定值，如果不大于指定值则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <param name="comparison">对象比较方法</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException">异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">异常类型 <paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常类型 <paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象的值小于等于 <paramref name="value" /> 的值，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static T GuardGreaterThan<T>(this T item, T value, Type exceptionType, object[] args, Func<T, T, int> comparison)
	{
		item.Guard(item.IsGreaterThan(value, comparison), exceptionType, args);
		return item;
	}

	/// <summary>
	/// 检测当前对象是否大于等于指定值，如果小于指定值则抛出 <see cref="T:System.ArgumentOutOfRangeException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <param name="comparison">对象比较方法</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException">当前对象小于 <paramref name="value" /> 时。</exception>
	public static T GuardGreaterThanOrEqualTo<T>(this T item, T value, string name, string message, Func<T, T, int> comparison)
	{
		item.Guard(item.IsGreaterThanOrEqualTo(value, comparison), () => new ArgumentOutOfRangeException(name.IfNull("item"), message.IfNull(Literals.MSG_ValueLessThanTarget_1.FormatValue(value))));
		return item;
	}

	/// <summary>
	/// 检测当前对象是否大于等于指定值，如果小于指定值则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <param name="comparison">对象比较方法</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException">异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常生成方法 <paramref name="exceptionCreator" /> 执行异常或者返回空。</exception>
	/// <exception cref="T:System.Exception">当前对象的值小于 <paramref name="value" /> 的值，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static T GuardGreaterThanOrEqualTo<T>(this T item, T value, Func<Exception> exceptionCreator, Func<T, T, int> comparison)
	{
		item.Guard(item.IsGreaterThanOrEqualTo(value, comparison), exceptionCreator);
		return item;
	}

	/// <summary>
	/// 检测当前对象是否大于等于指定值，如果小于指定值则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <param name="comparison">对象比较方法</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException">异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">异常类型 <paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常类型 <paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象的值小于 <paramref name="value" /> 的值，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static T GuardGreaterThanOrEqualTo<T>(this T item, T value, Type exceptionType, object[] args, Func<T, T, int> comparison)
	{
		item.Guard(item.IsGreaterThanOrEqualTo(value, comparison), exceptionType, args);
		return item;
	}

	/// <summary>
	/// 检测当前对象是否小于指定值，如果不小于指定值则抛出 <see cref="T:System.ArgumentOutOfRangeException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <param name="comparison">对象比较方法</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException">当前对象大于等于 <paramref name="value" /> 时。</exception>
	public static T GuardLessThan<T>(this T item, T value, string name, string message, Func<T, T, int> comparison)
	{
		item.Guard(item.IsLessThan(value, comparison), () => new ArgumentOutOfRangeException(name.IfNull("item"), message.IfNull(Literals.MSG_ValueGreaterThanOrEqualToTarget_1.FormatValue(value))));
		return item;
	}

	/// <summary>
	/// 检测当前对象是否小于指定值，如果不小于指定值则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <param name="comparison">对象比较方法</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException">异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常生成方法 <paramref name="exceptionCreator" /> 执行异常或者返回空。</exception>
	/// <exception cref="T:System.Exception">当前对象的值大于等于 <paramref name="value" /> 的值，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static T GuardLessThan<T>(this T item, T value, Func<Exception> exceptionCreator, Func<T, T, int> comparison)
	{
		item.Guard(item.IsLessThan(value, comparison), exceptionCreator);
		return item;
	}

	/// <summary>
	/// 检测当前对象是否小于指定值，如果不小于指定值则抛出抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <param name="comparison">对象比较方法</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException">异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">异常类型 <paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常类型 <paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象的值大于等于 <paramref name="value" /> 的值，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static T GuardLessThan<T>(this T item, T value, Type exceptionType, object[] args, Func<T, T, int> comparison)
	{
		item.Guard(item.IsLessThan(value, comparison), exceptionType, args);
		return item;
	}

	/// <summary>
	/// 检测当前对象是否小于等于指定值，如果大于指定值则抛出 <see cref="T:System.ArgumentOutOfRangeException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <param name="comparison">对象比较方法</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException">当前对象大于 <paramref name="value" /> 的值。</exception>
	public static T GuardLessThanOrEqualTo<T>(this T item, T value, string name, string message, Func<T, T, int> comparison)
	{
		item.Guard(item.IsLessThanOrEqualTo(value, comparison), () => new ArgumentOutOfRangeException(name.IfNull("items"), message.IfNull(Literals.MSG_ValueGreaterThanTarget_1.FormatValue(value))));
		return item;
	}

	/// <summary>
	/// 检测当前对象是否小于等于指定值，如果大于指定值则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <param name="comparison">对象比较方法</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException">异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常生成方法 <paramref name="exceptionCreator" /> 执行异常或者返回空。</exception>
	/// <exception cref="T:System.Exception">当前对象的值大于 <paramref name="value" /> 的值，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static T GuardLessThanOrEqualTo<T>(this T item, T value, Func<Exception> exceptionCreator, Func<T, T, int> comparison)
	{
		item.Guard(item.IsLessThanOrEqualTo(value, comparison), exceptionCreator);
		return item;
	}

	/// <summary>
	/// 检测当前对象是否小于等于指定值，如果大于指定值则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <param name="comparison">对象比较方法</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException">异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">异常类型 <paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常类型 <paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象的值大于 <paramref name="value" /> 的值，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static T GuardLessThanOrEqualTo<T>(this T item, T value, Type exceptionType, object[] args, Func<T, T, int> comparison)
	{
		item.Guard(item.IsLessThanOrEqualTo(value, comparison), exceptionType, args);
		return item;
	}

	/// <summary>
	/// 检测当前对象是否不是为空或者 <see cref="T:System.DBNull" />，如果为空或者 <see cref="T:System.DBNull" /> 则抛出 <see cref="T:System.ArgumentNullException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空或者 <see cref="T:System.DBNull" />。</exception>
	public static T GuardNotNullAndDBNull<T>(this T item, string name = null, string message = null)
	{
		item.Guard(item.IsNotNullAndDBNull(), () => new ArgumentNullException(name.IfNull("item"), message.IfNull(Literals.MSG_ValueNullOrDBNull)));
		return item;
	}

	/// <summary>
	/// 检测当前对象是否不是为空或者 <see cref="T:System.DBNull" />，如果为空或者 <see cref="T:System.DBNull" /> 则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前对象的值为空或者 <see cref="T:System.DBNull" />，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static T GuardNotNullAndDBNull<T>(this T item, Func<Exception> exceptionCreator)
	{
		item.Guard(item.IsNotNullAndDBNull(), exceptionCreator);
		return item;
	}

	/// <summary>
	/// 检测当前对象是否不是为空或者 <see cref="T:System.DBNull" />，如果为空或者 <see cref="T:System.DBNull" /> 则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象的值为空或者 <see cref="T:System.DBNull" />，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static T GuardNotNullAndDBNull<T>(this T item, Type exceptionType, params object[] args)
	{
		item.Guard(item.IsNotNullAndDBNull(), exceptionType, args);
		return item;
	}

	/// <summary>
	/// 检测当前对象是否为空（null）或者是其类型的默认值，如果为空或者是其类型默认值抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentException">当前对象为空或者等于其类型的默认值</exception>
	public static T GuardNotNullAndDefault<T>(this T item, string name = null, string message = null)
	{
		item.Guard(item.IsNotNullAndDefault(), name.IfNull("item"), message.IfNull(Literals.MSG_ValueNullOrDefault));
		return item;
	}

	/// <summary>
	/// 检测当前对象是否为空或者是指定类型的默认值，如果为空或者类型默认值抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <param name="equalition">对象相等比较方法</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前对象的值为空或者等于其类型的默认值，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static T GuardNotNullAndDefault<T>(this T item, Func<Exception> exceptionCreator, Func<T, T, bool> equalition = null)
	{
		item.Guard(item.IsNotNullAndDefault(equalition), exceptionCreator);
		return item;
	}

	/// <summary>
	/// 检测当前对象是否为空或者是指定类型默认值，如果为空或者类型默认值抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <param name="equalition">对象相等比较方法</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象的值为空或者等于其类型的默认值，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static T GuardNotNullAndDefault<T>(this T item, Type exceptionType, object[] args = null, Func<T, T, bool> equalition = null)
	{
		item.Guard(item.IsNotNullAndDefault(equalition), exceptionType, args);
		return item;
	}

	/// <summary>
	/// 检测当前对象是否为空，如果不为空抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">错误消息</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentException">当前对象不为空。</exception>
	public static T GuardNull<T>(this T item, string name = null, string message = null)
	{
		item.Guard(item.IsNull(), name.IfNull("item"), message.IfNull(Literals.MSG_ValueNotNull));
		return item;
	}

	/// <summary>
	/// 检测当前对象是否为空，如果不为空抛出参数 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前对象不为空，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static T GuardNull<T>(this T item, Func<Exception> exceptionCreator)
	{
		item.Guard(item.IsNull(), exceptionCreator);
		return item;
	}

	/// <summary>
	/// 检测当前对象是否为空，如果不为空抛出参数 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前当前对象不为空，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static T GuardNull<T>(this T item, Type exceptionType, params object[] args)
	{
		item.Guard(item.IsNull(), exceptionType, args);
		return item;
	}

	/// <summary>
	/// 检测当前对象是否为空，如果为空抛出 <see cref="T:System.ArgumentNullException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">错误消息</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空。</exception>
	public static T GuardNotNull<T>(this T item, string name = null, string message = null)
	{
		item.Guard(item.IsNotNull(), () => new ArgumentNullException(name.IfNull("item"), message.IfNull(Literals.MSG_ValueNull)));
		return item;
	}

	/// <summary>
	/// 检测当前对象是否为空，如果为空抛出参数 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前对象为空，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static T GuardNotNull<T>(this T item, Func<Exception> exceptionCreator)
	{
		item.Guard(item.IsNotNull(), exceptionCreator);
		return item;
	}

	/// <summary>
	/// 检测当前对象是否为空，如果为空抛出参数 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象为空，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static T GuardNotNull<T>(this T item, Type exceptionType, params object[] args)
	{
		item.Guard(item.IsNotNull(), exceptionType, args);
		return item;
	}

	/// <summary>
	/// 检测当前对象是否是指定值之一，如果不等于任何指定的值则抛出 <see cref="T:System.ArgumentOutOfRangeException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="values">检测的指定值列表</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <param name="equalition">对象相等比较器</param>
	/// <returns>如果检测通过则返回对象本身</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException">当前对象不在给定的值列表 <paramref name="values" /> 中。</exception>
	public static T GuardIn<T>(this T item, IEnumerable<T> values, string name, string message, Func<T, T, bool> equalition)
	{
		item.Guard(item.In(values, equalition), () => new ArgumentOutOfRangeException(name.IfNull("item"), message.IfNull(Literals.MSG_ValueNotInTargets)));
		return item;
	}

	/// <summary>
	/// 检测当前对象是否是指定值之一，如果不等于任何指定的值，则抛出 <paramref name="exceptionCreator" /> 生成的异常。
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="values">检测的指定值列表</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <param name="equalition">对象相等比较方法</param>
	/// <returns>如果检测通过则返回对象本身</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前对象不在给定的值列表 <paramref name="values" /> 中，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static T GuardIn<T>(this T item, IEnumerable<T> values, Func<Exception> exceptionCreator, Func<T, T, bool> equalition)
	{
		item.Guard(item.In(values, equalition), exceptionCreator);
		return item;
	}

	/// <summary>
	/// 检测当前对象是否是指定值之一，如果不等于任何指定的值，则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="values">检测的指定值列表</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <param name="equalition">对象相等比较方法</param>
	/// <returns>如果检测通过则返回对象本身</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象不在给定的值列表 <paramref name="values" /> 中，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static T GuardIn<T>(this T item, IEnumerable<T> values, Type exceptionType, object[] args, Func<T, T, bool> equalition)
	{
		item.Guard(item.In(values, equalition), exceptionType, args);
		return item;
	}

	/// <summary>
	/// 检测当前对象是否不是指定值，如果等于任何指定的值则抛出 <see cref="T:System.ArgumentOutOfRangeException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="values">检测的指定值列表</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <param name="equalition">对象相等比较器</param>
	/// <returns>如果检测通过则返回对象本身</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException">当前对象在给定的值列表 <paramref name="values" /> 中。</exception>
	public static T GuardNotIn<T>(this T item, IEnumerable<T> values, string name, string message, Func<T, T, bool> equalition)
	{
		item.Guard(item.NotIn(values, equalition), () => new ArgumentOutOfRangeException(name.IfNull("item"), message.IfNull(Literals.MSG_ValueInTargets)));
		return item;
	}

	/// <summary>
	/// 检测当前对象是否不是指定值，如果等于任何指定的值，则抛出 <paramref name="exceptionCreator" /> 生成的异常。
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="values">检测的指定值列表</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <param name="equalition">对象相等比较方法</param>
	/// <returns>如果检测通过则返回对象本身</returns>
	/// <exception cref="T:System.ArgumentNullException">异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常生成方法 <paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前对象在给定的值列表 <paramref name="values" /> 中，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static T GuardNotIn<T>(this T item, IEnumerable<T> values, Func<Exception> exceptionCreator, Func<T, T, bool> equalition)
	{
		item.Guard(item.NotIn(values, equalition), exceptionCreator);
		return item;
	}

	/// <summary>
	/// 检测当前对象是否不是指定值，如果等于任何指定的值，则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="values">检测的指定值列表</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <param name="equalition">对象相等比较方法</param>
	/// <returns>如果检测通过则返回对象本身</returns>
	/// <exception cref="T:System.ArgumentNullException">异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">异常类型 <paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常类型 <paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象在给定的值列表 <paramref name="values" /> 中，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static T GuardNotIn<T>(this T item, IEnumerable<T> values, Type exceptionType, object[] args, Func<T, T, bool> equalition)
	{
		item.Guard(item.NotIn(values, equalition), exceptionType, args);
		return item;
	}

	/// <summary>
	/// 检测当前对象是否是指定类型的实例，如果不是则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过则返回当前对象</returns>
	/// <exception cref="T:System.ArgumentException">当前对象为空，或者不是 <typeparamref name="T" /> 指定的类型的实例</exception>
	public static void GuardInstanceOfType<T>(this object item, string name = null, string message = null)
	{
		item.Guard(item.IsInstanceOf<T>(), name.IfNull("item"), message.IfNull(Literals.MSG_ObjectNotOfType));
	}

	/// <summary>
	/// 检测当前对象是否是指定类型的实例，如果不是则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过则返回当前对象</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前对象为空，或者不是 <typeparamref name="T" /> 指定的类型的实例，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static void GuardInstanceOfType<T>(this object item, Func<Exception> exceptionCreator)
	{
		item.Guard(item.IsInstanceOf<T>(), exceptionCreator);
	}

	/// <summary>
	/// 检测当前对象是否是指定类型的实例，如果不是则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检测通过则返回当前对象</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象为空，或者不是 <typeparamref name="T" /> 指定的类型的实例，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static void GuardInstanceOfType<T>(this object item, Type exceptionType, params object[] args)
	{
		item.Guard(item.IsInstanceOf<T>(), exceptionType, args);
	}

	/// <summary>
	/// 检测当前对象是否是指定类型的实例，如果不是则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="type">检测的目标类型</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过则返回当前对象</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="type" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前对象为空，或者不是 <paramref name="type" /> 指定的类型的实例</exception>
	public static T GuardInstanceOfType<T>(this T item, Type type, string name = null, string message = null)
	{
		type.GuardNotNull("type", Literals.MSG_TypeNull);
		item.Guard(item.IsInstanceOf(type), name.IfNull("item"), message.IfNull(Literals.MSG_ObjectNotOfType));
		return item;
	}

	/// <summary>
	/// 检测当前对象是否是指定类型的实例，如果不是则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="type">检测的目标类型</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过则返回当前对象</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionCreator" /> 为空；或者 <paramref name="type" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前对象为空，或者不是 <paramref name="type" /> 指定的类型的实例，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static T GuardInstanceOfType<T>(this T item, Type type, Func<Exception> exceptionCreator)
	{
		type.GuardNotNull("type", Literals.MSG_TypeNull);
		item.Guard(item.IsInstanceOf(type), exceptionCreator);
		return item;
	}

	/// <summary>
	/// 检测当前对象是否是指定类型的实例，如果不是则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="type">检测的目标类型</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检测通过则返回当前对象</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionType" /> 为空；或者 <paramref name="type" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象为空，或者不是 <paramref name="type" /> 指定的类型的实例，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static T GuardInstanceOfType<T>(this T item, Type type, Type exceptionType, params object[] args)
	{
		type.GuardNotNull("type", Literals.MSG_TypeNull);
		item.Guard(item.IsInstanceOf(type), exceptionType, args);
		return item;
	}

	/// <summary>
	/// 检测当前对象是否不是指定类型的实例，如果是则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过则返回当前对象</returns>
	/// <exception cref="T:System.ArgumentException">当前对象是 <typeparamref name="T" /> 指定的类型的实例</exception>
	public static void GuardNotInstanceOfType<T>(this object item, string name = null, string message = null)
	{
		item.Guard(!item.IsInstanceOf<T>(), name.IfNull("item"), message.IfNull(Literals.MSG_ObjectOfType));
	}

	/// <summary>
	/// 检测当前对象是否不是指定类型的实例，如果是则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过则返回当前对象</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前对象是 <typeparamref name="T" /> 指定的类型的实例，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static void GuardNotInstanceOfType<T>(this object item, Func<Exception> exceptionCreator)
	{
		item.Guard(!item.IsInstanceOf<T>(), exceptionCreator);
	}

	/// <summary>
	/// 检测当前对象是否不是指定类型的实例，如果是则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检测通过则返回当前对象</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象是 <typeparamref name="T" /> 指定的类型的实例，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static void GuardNotInstanceOfType<T>(this object item, Type exceptionType, params object[] args)
	{
		item.Guard(!item.IsInstanceOf<T>(), exceptionType, args);
	}

	/// <summary>
	/// 检测当前对象是否不是指定类型的实例，如果是则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="type">检测的目标类型</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过则返回当前对象</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="type" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前对象是 <paramref name="type" /> 指定的类型的实例</exception>
	public static T GuardNotInstanceOfType<T>(this T item, Type type, string name = null, string message = null)
	{
		type.GuardNotNull("type", Literals.MSG_TypeNull);
		item.Guard(!item.IsInstanceOf(type), name.IfNull("item"), message.IfNull(Literals.MSG_ObjectOfType));
		return item;
	}

	/// <summary>
	/// 检测当前对象是否不是指定类型的实例，如果是则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="type">检测的目标类型</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过则返回当前对象</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionCreator" /> 为空；或者 <paramref name="type" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前对象是 <paramref name="type" /> 指定的类型的实例，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static T GuardNotInstanceOfType<T>(this T item, Type type, Func<Exception> exceptionCreator)
	{
		type.GuardNotNull("type", Literals.MSG_TypeNull);
		item.Guard(!item.IsInstanceOf(type), exceptionCreator);
		return item;
	}

	/// <summary>
	/// 检测当前对象是否不是指定类型的实例，如果是则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="type">检测的目标类型</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检测通过则返回当前对象</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionType" /> 为空；或者 <paramref name="type" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象是 <paramref name="type" /> 指定的类型的实例，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static T GuardNotInstanceOfType<T>(this T item, Type type, Type exceptionType, params object[] args)
	{
		type.GuardNotNull("type", Literals.MSG_TypeNull);
		item.Guard(!item.IsInstanceOf(type), exceptionType, args);
		return item;
	}

	/// <summary>
	/// 检测当前对象是否为值类型，如果不是值类型则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前对象的类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果通过检测则返回对象本身</returns>
	/// <exception cref="T:System.ArgumentException">当前对象为空，或者不是值类型的对象。</exception>
	public static T GuardInstanceOfValueType<T>(this T item, string name = null, string message = null)
	{
		item.Guard(item.IsValueType(), name.IfNull("item"), message.IfNull(Literals.MSG_ObjectNotOfValueType));
		return item;
	}

	/// <summary>
	/// 检测当前对象是否为值类型，如果不是值类型则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">当前对象的类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果通过检测则返回对象本身</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前对象为空，或者不是值类型的对象，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static T GuardInstanceOfValueType<T>(this T item, Func<Exception> exceptionCreator)
	{
		item.Guard(item.IsValueType(), exceptionCreator);
		return item;
	}

	/// <summary>
	/// 检测当前对象是否为值类型，如果不是值类型则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <typeparam name="T">当前对象的类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果通过检测则返回对象本身</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象为空，或者不是值类型的对象，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static T GuardInstanceOfValueType<T>(this T item, Type exceptionType, params object[] args)
	{
		item.Guard(item.IsValueType(), exceptionType, args);
		return item;
	}

	/// <summary>
	/// 检测当前对象是否为引用类型，如果不是引用类型则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前对象的类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果通过检测则返回对象本身</returns>
	/// <exception cref="T:System.ArgumentException">当前对象为空，或者所属的类型不是类或者接口。</exception>
	public static T GuardInstanceOfReferenceType<T>(this T item, string name = null, string message = null)
	{
		item.Guard(item.IsReferenceType(), name.IfNull("item"), message.IfNull(Literals.MSG_ObjectNotOfReferenceType));
		return item;
	}

	/// <summary>
	/// 检测当前对象是否为引用类型，如果不是引用类型则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">当前对象的类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果通过检测则返回对象本身</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前对象为空，或者所属的类型不是类或者接口，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static T GuardInstanceOfReferenceType<T>(this T item, Func<Exception> exceptionCreator)
	{
		item.Guard(item.IsReferenceType(), exceptionCreator);
		return item;
	}

	/// <summary>
	/// 检测当前对象是否为引用类型，如果不是引用类型则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <typeparam name="T">当前对象的类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果通过检测则返回对象本身</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象为空，或者所属的类型不是类或者接口，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static T GuardInstanceOfReferenceType<T>(this T item, Type exceptionType, params object[] args)
	{
		item.Guard(item.IsReferenceType(), exceptionType, args);
		return item;
	}

	/// <summary>
	/// 检测当前对象是否实现了指定的接口
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="interfaceType">检测的接口类型</param>
	/// <returns>如果当前对象实现了指定的接口则返回true，否则返回false。如果当前对象等于null，则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="interfaceType" /> 为空。</exception>
	public static bool HasInterface(this object item, Type interfaceType)
	{
		interfaceType.GuardNotNull("Interface Type");
		return item.IsNotNull() && item.GetType().HasInterface(interfaceType);
	}

	/// <summary>
	/// 检测当前对象是否实现了指定的接口
	/// </summary>
	/// <typeparam name="T">指定接口类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <returns>如果当前对象实现了指定的接口则返回true，否则返回false。如果当前对象等于null，则返回false。</returns>
	public static bool HasInterface<T>(this object item)
	{
		return item.IsNotNull() && item.GetType().HasInterface<T>();
	}

	/// <summary>
	/// 如果当前对象满足指定的断言 <paramref name="predicate" />，则返回 <paramref name="value" /> 的值，否则返回对象本身
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="predicate">检测断言</param>
	/// <param name="value">指定值</param>
	/// <returns>如果对象满足指定的断言检测，则返回 <paramref name="value" /> 的值，否则返回对象本身</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="predicate" /> 为空。</exception>
	public static T If<T>(this T item, Func<T, bool> predicate, T value)
	{
		predicate.GuardNotNull("Predicate");
		return predicate(item) ? value : item;
	}

	/// <summary>
	/// 如果当前对象满足指定的断言 <paramref name="predicate" />，则返回 <paramref name="trueValue" /> 的值，否则返回 <paramref name="falseValue" /> 的值
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="predicate">检测断言</param>
	/// <param name="trueValue">当前检测条件为true时返回这个值</param>
	/// <param name="falseValue">当检测条件为false是返回这个值</param>
	/// <returns>如果对象满足指定的断言检测，返回 <paramref name="trueValue" /> 的值，否则返回 <paramref name="falseValue" /> 的值</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="predicate" /> 为空。</exception>
	public static T If<T>(this T item, Func<T, bool> predicate, T trueValue, T falseValue)
	{
		predicate.GuardNotNull("Predicate");
		return predicate(item) ? trueValue : falseValue;
	}

	/// <summary>
	/// 如果当前对象为空，则返回 <paramref name="result" />，否则返回对象本身
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="result">替代值</param>
	/// <returns>处理结果</returns>
	public static T IfNull<T>(this T item, T result)
	{
		return item.IsNull() ? result : item;
	}

	/// <summary>
	/// 如果对象不为空，则返回 <paramref name="result" /> 的值，否则返回结果类型 <typeparamref name="T" /> 的类型默认值
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="result">替代值</param>
	/// <returns>处理结果</returns>
	public static T IfNotNull<T>(this T item, T result)
	{
		return item.IsNotNull() ? result : item;
	}

	/// <summary>
	/// 如果当前对象为空或者为DBNull，返回 <paramref name="result" /> 的值，否则返回对象本身
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="result">替代值</param>
	/// <returns>处理结果</returns>
	public static T IfNullOrDBNull<T>(this T item, T result)
	{
		return item.IsNullOrDBNull() ? result : item;
	}

	/// <summary>
	/// 如果当前对象不是null或者DBNull，返回 <paramref name="result" /> 的值，否则返回对象本身
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="result">替代值</param>
	/// <returns>处理结果</returns>
	public static T IfNotNullAndDBNull<T>(this T item, T result)
	{
		return item.IsNotNullAndDBNull() ? result : item;
	}

	/// <summary>
	/// 检测当前对象是否存在于给定的值列表中
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="values">给定的值列表</param>
	/// <returns>如果当前对象存在于值列表中返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">值列表 <paramref name="values" /> 为空。</exception>
	public static bool In<T>(this T item, params T[] values)
	{
		return item.In(values, EqualityComparer<T>.Default);
	}

	/// <summary>
	/// 检测当前对象是否存在于给定的值列表中
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="values">给定的值列表</param>
	/// <returns>如果当前对象存在于值列表中返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">值列表 <paramref name="values" /> 为空。</exception>
	public static bool In<T>(this T item, IEnumerable<T> values)
	{
		return item.In(values, EqualityComparer<T>.Default.Equals);
	}

	/// <summary>
	/// 检测当前对象是否存在于给定的值列表中
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="values">给定的值列表</param>
	/// <param name="equaliter">对象相等比较器</param>
	/// <returns>如果当前对象存在于值列表中返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">值列表 <paramref name="values" /> 为空。</exception>
	public static bool In<T>(this T item, IEnumerable<T> values, IEqualityComparer<T> equaliter)
	{
		return item.In(values, equaliter.IfNull(EqualityComparer<T>.Default).Equals);
	}

	/// <summary>
	/// 检测当前对象是否存在于给定的值列表中
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="values">给定的值列表</param>
	/// <param name="equalition">对象相等比较方法</param>
	/// <returns>如果当前对象存在于值列表中返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">值列表 <paramref name="values" /> 为空。</exception>
	public static bool In<T>(this T item, IEnumerable<T> values, Func<T, T, bool> equalition)
	{
		values.GuardNotNull("Values");
		equalition = equalition.IfNull(EqualityComparer<T>.Default.Equals);
		foreach (T value in values)
		{
			if (equalition(item, value))
			{
				return true;
			}
		}
		return false;
	}

	/// <summary>
	/// 检测当前对象是不否存在于给定的值列表中
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="values">给定的值列表</param>
	/// <returns>如果当前对象不存在于值列表中返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">值列表 <paramref name="values" /> 为空。</exception>
	public static bool NotIn<T>(this T item, params T[] values)
	{
		return !item.In(values);
	}

	/// <summary>
	/// 检测当前对象是否不存在于给定的值列表中
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="values">给定的值列表</param>
	/// <returns>如果当前对象不存在于值列表中返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">值列表 <paramref name="values" /> 为空。</exception>
	public static bool NotIn<T>(this T item, IEnumerable<T> values)
	{
		return !item.In(values);
	}

	/// <summary>
	/// 检测当前对象是否不存在于给定的值列表中
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="values">给定的值列表</param>
	/// <param name="equaliter">对象相等比较器</param>
	/// <returns>如果当前对象不存在于值列表中返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">值列表 <paramref name="values" /> 为空。</exception>
	public static bool NotIn<T>(this T item, IEnumerable<T> values, IEqualityComparer<T> equaliter)
	{
		return !item.In(values, equaliter);
	}

	/// <summary>
	/// 检测当前对象是否不存在于给定的值列表中
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="values">给定的值列表</param>
	/// <param name="equalition">对象相等比较方法</param>
	/// <returns>如果当前对象不存在于值列表中返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">值列表 <paramref name="values" /> 为空。</exception>
	public static bool NotIn<T>(this T item, IEnumerable<T> values, Func<T, T, bool> equalition)
	{
		return !item.In(values, equalition);
	}

	/// <summary>
	/// 调用当前对象中能与给定参数进行绑定的公共实例方法
	/// </summary>
	/// <param name="obj">当前对象</param>
	/// <param name="methodName">调用的方法名称，区分大小写</param>
	/// <param name="args">调用方法用的参数数组</param>
	/// <returns>调用方法的返回值；如果被调用方法无返回值则返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者方法名称 <paramref name="methodName" /> 为空或者空串。</exception>
	/// <exception cref="T:System.MissingMethodException">当前对象中没有可以与指定参数数组进行绑定的公共实例方法。</exception>
	/// <exception cref="T:System.Reflection.AmbiguousMatchException">存在多于一个可以与指定参数数组进行绑定的公共实例方法。</exception>
	public static object InvokeMethod(this object obj, string methodName, params object[] args)
	{
		obj.GuardNotNull("item");
		return obj.GetType().InvokeMethod(methodName, obj, args);
	}

	/// <summary>
	/// 调用当前对象中能与给定参数进行绑定的公共实例方法
	/// </summary>
	/// <param name="obj">当前对象</param>
	/// <param name="methodName">调用的方法名称</param>
	/// <param name="args">调用方法用的参数数组</param>
	/// <param name="ignoreCase">调用的方法名称是否区分大小写</param>
	/// <param name="optionalBinding">对于方法的可选参数是否也必须进行绑定，默认为不对可选参数进行绑定</param>
	/// <returns>调用方法的返回值；如果被调用方法无返回值则返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者方法名称 <paramref name="methodName" /> 为空或者空串。</exception>
	/// <exception cref="T:System.MissingMethodException">当前对象中没有可以与指定参数数组进行绑定的方法。</exception>
	/// <exception cref="T:System.Reflection.AmbiguousMatchException">存在多于一个可以与指定参数数组进行绑定的方法。</exception>
	public static object InvokeMethod(this object obj, string methodName, object[] args, bool ignoreCase = false, bool optionalBinding = false)
	{
		obj.GuardNotNull("item");
		return obj.GetType().InvokeMethod(methodName, obj, args, ignoreCase, optionalBinding);
	}

	/// <summary>
	/// 调用当前对象中能与给定参数进行绑定的方法
	/// </summary>
	/// <param name="obj">当前对象</param>
	/// <param name="methodName">调用的方法名称</param>
	/// <param name="args">调用方法用的参数数组</param>
	/// <param name="flags">方法的搜索方式</param>
	/// <param name="ignoreCase">调用的方法名称是否区分大小写</param>
	/// <param name="optionalBinding">对于方法的可选参数是否也必须进行绑定，默认为不对可选参数进行绑定</param>
	/// <returns>调用方法的返回值；如果被调用方法无返回值则返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者方法名称 <paramref name="methodName" /> 为空或者空串。</exception>
	/// <exception cref="T:System.MissingMethodException">当前对象中没有可以与指定参数数组进行绑定的方法。</exception>
	/// <exception cref="T:System.Reflection.AmbiguousMatchException">存在多于一个可以与指定参数数组进行绑定的方法。</exception>
	public static object InvokeMethod(this object obj, string methodName, object[] args, BindingFlags flags, bool ignoreCase = false, bool optionalBinding = false)
	{
		obj.GuardNotNull("item");
		return obj.GetType().InvokeMethod(methodName, obj, args, flags, ignoreCase, optionalBinding);
	}

	/// <summary>
	/// 调用当前对象中能与给定命名参数进行绑定的公共实例方法
	/// </summary>
	/// <param name="obj">当前对象</param>
	/// <param name="methodName">调用的方法名称</param>
	/// <param name="namedArgs">命名参数数组</param>
	/// <param name="ignoreCase">调用的方法名称是否区分大小写</param>
	/// <param name="optionalBinding">对于方法的可选参数是否也必须进行绑定，默认为不对可选参数进行绑定</param>
	/// <returns>调用方法的返回值；如果被调用方法无返回值则返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者方法名称 <paramref name="methodName" /> 为空或者空串。</exception>
	/// <exception cref="T:System.MissingMethodException">当前对象中没有可以与指定参数数组进行绑定的方法。</exception>
	/// <exception cref="T:System.Reflection.AmbiguousMatchException">存在多于一个可以与指定参数数组进行绑定的方法。</exception>
	public static object InvokeMethod(this object obj, string methodName, NamedValue[] namedArgs, bool ignoreCase = false, bool optionalBinding = false)
	{
		obj.GuardNotNull("item");
		return obj.GetType().InvokeMethod(methodName, obj, namedArgs, ignoreCase, optionalBinding);
	}

	/// <summary>
	/// 调用当前对象中能与给定命名参数进行绑定的方法
	/// </summary>
	/// <param name="obj">当前对象</param>
	/// <param name="methodName">调用的方法名称</param>
	/// <param name="namedArgs">命名参数数组</param>
	/// <param name="flags">方法的搜索方式</param>
	/// <param name="ignoreCase">调用的方法名称是否区分大小写</param>
	/// <param name="optionalBinding">对于方法的可选参数是否也必须进行绑定，默认为不对可选参数进行绑定</param>
	/// <returns>调用方法的返回值；如果被调用方法无返回值则返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者方法名称 <paramref name="methodName" /> 为空或者空串。</exception>
	/// <exception cref="T:System.MissingMethodException">当前对象中没有可以与指定参数数组进行绑定的方法。</exception>
	/// <exception cref="T:System.Reflection.AmbiguousMatchException">存在多于一个可以与指定参数数组进行绑定的方法。</exception>
	public static object InvokeMethod(this object obj, string methodName, NamedValue[] namedArgs, BindingFlags flags, bool ignoreCase = false, bool optionalBinding = false)
	{
		obj.GuardNotNull("item");
		return obj.GetType().InvokeMethod(methodName, obj, namedArgs, flags, ignoreCase, optionalBinding);
	}

	/// <summary>
	/// 调用当前对象中能与给定命名参数进行绑定的公共实例方法
	/// </summary>
	/// <param name="obj">当前对象</param>
	/// <param name="methodName">调用的方法名称</param>
	/// <param name="namedArgs">调用方法用的参数字典</param>
	/// <param name="ignoreCase">调用的方法名称是否区分大小写</param>
	/// <param name="optionalBinding">对于方法的可选参数是否也必须进行绑定，默认为不对可选参数进行绑定</param>
	/// <returns>调用方法的返回值；如果被调用方法无返回值则返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者方法名称 <paramref name="methodName" /> 为空或者空串。</exception>
	/// <exception cref="T:System.MissingMethodException">当前对象中没有可以与指定参数数组进行绑定的方法。</exception>
	/// <exception cref="T:System.Reflection.AmbiguousMatchException">存在多于一个可以与指定参数数组进行绑定的方法。</exception>
	public static object InvokeMethod(this object obj, string methodName, IDictionary<string, object> namedArgs, bool ignoreCase = false, bool optionalBinding = false)
	{
		obj.GuardNotNull("object");
		return obj.GetType().InvokeMethod(methodName, obj, namedArgs, ignoreCase, optionalBinding);
	}

	/// <summary>
	/// 调用当前对象中能与给定命名参数进行绑定的方法
	/// </summary>
	/// <param name="obj">当前对象</param>
	/// <param name="methodName">调用的方法名称</param>
	/// <param name="namedArgs">调用方法用的参数字典</param>
	/// <param name="flags">方法的搜索方式</param>
	/// <param name="ignoreCase">调用的方法名称是否区分大小写</param>
	/// <param name="optionalBinding">对于方法的可选参数是否也必须进行绑定，默认为不对可选参数进行绑定</param>
	/// <returns>调用方法的返回值；如果被调用方法无返回值则返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者方法名称 <paramref name="methodName" /> 为空或者空串。</exception>
	/// <exception cref="T:System.MissingMethodException">当前对象中没有可以与指定参数数组进行绑定的方法。</exception>
	/// <exception cref="T:System.Reflection.AmbiguousMatchException">存在多于一个可以与指定参数数组进行绑定的方法。</exception>
	public static object InvokeMethod(this object obj, string methodName, IDictionary<string, object> namedArgs, BindingFlags flags, bool ignoreCase = false, bool optionalBinding = false)
	{
		obj.GuardNotNull("object");
		return obj.GetType().InvokeMethod(methodName, obj, namedArgs, flags, ignoreCase, optionalBinding);
	}

	/// <summary>
	/// 调用当前对象中能与给定命名参数进行绑定的公共实例方法
	/// </summary>
	/// <param name="obj">当前对象</param>
	/// <param name="methodName">调用的方法名称</param>
	/// <param name="names">调用方法用的参数名称数组</param>
	/// <param name="values">调用方法用的参数值数组</param>
	/// <param name="ignoreCase">调用的方法名称是否区分大小写</param>
	/// <param name="optionalBinding">对于方法的可选参数是否也必须进行绑定，默认为不对可选参数进行绑定</param>
	/// <returns>调用方法的返回值；如果被调用方法无返回值则返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者方法名称 <paramref name="methodName" /> 为空或者空串；或者参数名称数组不为空，而参数值数组为空。</exception>
	/// <exception cref="T:System.MissingMethodException">当前对象中没有可以与指定参数数组进行绑定的方法。</exception>
	/// <exception cref="T:System.Reflection.AmbiguousMatchException">存在多于一个可以与指定参数数组进行绑定的方法。</exception>
	public static object InvokeMethod(this object obj, string methodName, string[] names, object[] values, bool ignoreCase = false, bool optionalBinding = false)
	{
		obj.GuardNotNull("object");
		return obj.GetType().InvokeMethod(methodName, obj, names, values, ignoreCase, optionalBinding);
	}

	/// <summary>
	/// 调用当前对象中能与给定命名参数进行绑定的方法
	/// </summary>
	/// <param name="obj">当前对象</param>
	/// <param name="methodName">调用的方法名称</param>
	/// <param name="names">调用方法用的参数名称数组</param>
	/// <param name="values">调用方法用的参数值数组</param>
	/// <param name="flags">方法的搜索方式</param>
	/// <param name="ignoreCase">调用的方法名称是否区分大小写</param>
	/// <param name="optionalBinding">对于方法的可选参数是否也必须进行绑定，默认为不对可选参数进行绑定</param>
	/// <returns>调用方法的返回值；如果被调用方法无返回值则返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者方法名称 <paramref name="methodName" /> 为空或者空串；或者参数名称数组不为空，而参数值数组为空。</exception>
	/// <exception cref="T:System.MissingMethodException">当前对象中没有可以与指定参数数组进行绑定的方法。</exception>
	/// <exception cref="T:System.Reflection.AmbiguousMatchException">存在多于一个可以与指定参数数组进行绑定的方法。</exception>
	public static object InvokeMethod(this object obj, string methodName, string[] names, object[] values, BindingFlags flags, bool ignoreCase = false, bool optionalBinding = false)
	{
		obj.GuardNotNull("object");
		return obj.GetType().InvokeMethod(methodName, obj, names, values, flags, ignoreCase, optionalBinding);
	}

	/// <summary>
	/// 检测当前对象是否是数组类型
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <returns>如果当前对象是数组类型则返回true，否则返回false。如果当前对象为空，则返回false。</returns>
	public static bool IsArray(this object item)
	{
		return item.IsNotNull() && (item.GetType().IsArray || typeof(Array).IsAssignableFrom(item.GetType()));
	}

	/// <summary>
	/// 检测当前对象是否不是数组类型
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <returns>如果当前对象不是数组类型则返回true，否则返回false。如果当前对象为空，则返回true。</returns>
	public static bool IsNotArray(this object item)
	{
		return !item.IsArray();
	}

	/// <summary>
	/// 检测对象是否是 <see cref="T:System.DBNull" />。
	/// </summary>
	/// <param name="item">待检测的对象</param>
	/// <returns>如果是 <see cref="T:System.DBNull" /> 则返回true，否则返回false；如果对象为空也返回false。</returns>
	/// <remarks>空（null）和 <see cref="T:System.DBNull" /> 是两个不同的值。如果对象为空，则本方法返回false。本方法使用 <see cref="M:System.Convert.IsDBNull(System.Object)" /> 检测对象值。</remarks>
	public static bool IsDBNull(this object item)
	{
		return item.IsNotNull() && Convert.IsDBNull(item);
	}

	/// <summary>
	/// 检测对象是否不是 <see cref="T:System.DBNull" />。
	/// </summary>
	/// <param name="item">待检测的对象</param>
	/// <returns>如果不是 <see cref="T:System.DBNull" /> 则返回true，否则返回false；如果对象为空返回true。</returns>
	/// <remarks>空（null）和 <see cref="T:System.DBNull" /> 是两个不同的值。如果对象为空，则本方法返回false。本方法使用 <see cref="M:System.Convert.IsDBNull(System.Object)" /> 检测对象值。</remarks>
	public static bool IsNotDBNull(this object item)
	{
		return item.IsNull() || !Convert.IsDBNull(item);
	}

	/// <summary>
	/// 检测当前对象是否是指定类型的默认值
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="type">当前对象类型</param>
	/// <returns>如果当前对象等于指定类型的默认值返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空时，对象类型 <paramref name="type" /> 为空。</exception>
	public static bool IsDefault(this object item, Type type = null)
	{
		if (item.IsNull())
		{
			type.GuardNotNull("type");
		}
		else
		{
			type = item.GetType();
		}
		if (type.IsValueType)
		{
			return item.IsNotNull() && item.Equals(Activator.CreateInstance(type));
		}
		return item.IsNull();
	}

	/// <summary>
	/// 检测当前值对象是否是其类型的默认值
	/// </summary>
	/// <typeparam name="T">当前值对象类型</typeparam>
	/// <param name="item">当前值对象</param>
	/// <returns>如果当前值对象等于其类型默认值返回true，否则返回false。</returns>
	public static bool IsDefault<T>(this T item)
	{
		return item.IsDefault(typeof(T));
	}

	/// <summary>
	/// 检测当前值对象是否是其类型的默认值
	/// </summary>
	/// <typeparam name="T">当前值对象类型</typeparam>
	/// <param name="item">当前值对象</param>
	/// <param name="equaliter">对象相等比较器</param>
	/// <returns>如果当前值对象等于其类型默认值返回true，否则返回false。</returns>
	public static bool IsDefault<T>(this T item, IEqualityComparer<T> equaliter)
	{
		return equaliter.IfNull(EqualityComparer<T>.Default).Equals(item, default(T));
	}

	/// <summary>
	/// 检测当前值对象是否是其类型的默认值
	/// </summary>
	/// <typeparam name="T">当前值对象类型</typeparam>
	/// <param name="item">当前值对象</param>
	/// <param name="equalition">对象相等比较方法</param>
	/// <returns>如果当前值对象等于其类型默认值返回true，否则返回false。</returns>
	public static bool IsDefault<T>(this T item, Func<T, T, bool> equalition)
	{
		return equalition.IfNull(EqualityComparer<T>.Default.Equals)(item, default(T));
	}

	/// <summary>
	/// 检测当前对象是否不是指定类型的默认值
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="type">当前对象类型</param>
	/// <returns>如果当前对象不等于指定类型的默认值返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空时，对象类型 <paramref name="type" /> 为空。</exception>
	public static bool IsNotDefault(this object item, Type type = null)
	{
		return !item.IsDefault(type);
	}

	/// <summary>
	/// 检测当前值对象是否不是其类型的默认值
	/// </summary>
	/// <typeparam name="T">当前值对象类型</typeparam>
	/// <param name="item">当前值对象</param>
	/// <returns>如果当前值对象不等于其类型默认值返回true，否则返回false。</returns>
	public static bool IsNotDefault<T>(this T item)
	{
		return !item.IsDefault();
	}

	/// <summary>
	/// 检测当前值对象是否不是其类型的默认值
	/// </summary>
	/// <typeparam name="T">当前值对象类型</typeparam>
	/// <param name="item">当前值对象</param>
	/// <param name="equaliter">对象相等比较器</param>
	/// <returns>如果当前值对象不等于其类型默认值返回true，否则返回false。</returns>
	public static bool IsNotDefault<T>(this T item, IEqualityComparer<T> equaliter)
	{
		return !item.IsDefault(equaliter);
	}

	/// <summary>
	/// 检测当前值对象是否不是其类型的默认值
	/// </summary>
	/// <typeparam name="T">当前值对象类型</typeparam>
	/// <param name="item">当前值对象</param>
	/// <param name="equalition">对象相等比较方法</param>
	/// <returns>如果当前值对象不等于其类型默认值返回true，否则返回false。</returns>
	public static bool IsNotDefault<T>(this T item, Func<T, T, bool> equalition)
	{
		return !item.IsDefault(equalition);
	}

	/// <summary>
	/// 检测当前对象是否等于目标对象
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="target">比较目标对象</param>
	/// <returns>如果两个对象值相等返回true，否则返回false</returns>
	public static bool IsEqualTo(this object item, object target)
	{
		return item.ObjectEquals(target);
	}

	/// <summary>
	/// 检测当前对象是否等于 <paramref name="target" /> 的值
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="target">比较目标对象</param>
	/// <returns>如果当前对象等于 <paramref name="target" /> 的值返回true，否则返回false</returns>
	public static bool IsEqualTo<T>(this T item, T target)
	{
		return ((object)item).IsEqualTo((object)target);
	}

	/// <summary>
	/// 检测当前对象是否等于 <paramref name="target" /> 的值
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="target">比较目标对象</param>
	/// <param name="equaliter">对象相等比较器</param>
	/// <returns>如果当前对象等于 <paramref name="target" /> 的值返回true，否则返回false</returns>
	public static bool IsEqualTo<T>(this T item, T target, IEqualityComparer<T> equaliter)
	{
		return equaliter.IfNull(EqualityComparer<T>.Default).Equals(item, target);
	}

	/// <summary>
	/// 检测当前对象是否等于 <paramref name="target" /> 的值
	/// </summary>
	/// <typeparam name="S">当前对象类型</typeparam>
	/// <typeparam name="T">比较的目标对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="target">比较目标对象</param>
	/// <param name="equalition">对象相等比较方法</param>
	/// <returns>如果两个对象值相等返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="equalition" /> 为空。</exception>
	public static bool IsEqualTo<S, T>(this S item, T target, Func<S, T, bool> equalition)
	{
		equalition.GuardNotNull("equalition");
		return equalition(item, target);
	}

	/// <summary>
	/// 检测当前对象是否不等于目标对象
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="target">目标对象</param>
	/// <returns>如果两个对象值不相等返回true，否则返回false</returns>
	public static bool IsNotEqualTo(this object item, object target)
	{
		return !item.IsEqualTo(target);
	}

	/// <summary>
	/// 检测当前对象是否不等于 <paramref name="value" /> 的值
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <returns>如果当前对象不等于 <paramref name="value" /> 的值返回true，否则返回false</returns>
	public static bool IsNotEqualTo<T>(this T item, T value)
	{
		return !item.IsEqualTo(value);
	}

	/// <summary>
	/// 检测当前对象是否不等于 <paramref name="value" /> 的值
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="equaliter">对象相等比较器</param>
	/// <returns>如果当前对象不等于 <paramref name="value" /> 的值返回true，否则返回false</returns>
	public static bool IsNotEqualTo<T>(this T item, T value, IEqualityComparer<T> equaliter)
	{
		return !item.IsEqualTo(value, equaliter);
	}

	/// <summary>
	/// 检测当前对象是否不等于 <paramref name="target" /> 的值
	/// </summary>
	/// <typeparam name="S">当前对象类型</typeparam>
	/// <typeparam name="T">比较的目标对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="target">比较目标对象</param>
	/// <param name="equalition">对象相等比较方法</param>
	/// <returns>如果两个对象值不相等返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="equalition" /> 为空。</exception>
	public static bool IsNotEqualTo<S, T>(this S item, T target, Func<S, T, bool> equalition)
	{
		return !item.IsEqualTo(target, equalition);
	}

	/// <summary>
	/// 检测当前对象是否大于 <paramref name="value" /> 的值
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="comparer">对象比较对象</param>
	/// <returns>如果当前对象大于 <paramref name="value" /> 的值返回true，否则返回false</returns>
	public static bool IsGreaterThan<T>(this T item, T value, IComparer<T> comparer)
	{
		return comparer.IfNull(Comparer<T>.Default).Compare(item, value) > 0;
	}

	/// <summary>
	/// 检测当前对象是否大于 <paramref name="value" /> 的值
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="comparison">对象比较方法</param>
	/// <returns>如果当前对象大于 <paramref name="value" /> 的值返回true，否则返回false</returns>
	public static bool IsGreaterThan<T>(this T item, T value, Func<T, T, int> comparison)
	{
		return comparison.IfNull(Comparer<T>.Default.Compare)(item, value) > 0;
	}

	/// <summary>
	/// 检测当前对象是否大于等于 <paramref name="value" /> 的值
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="comparer">对象比较对象</param>
	/// <returns>如果当前对象大于等于 <paramref name="value" /> 的值返回true，否则返回false</returns>
	public static bool IsGreaterThanOrEqualTo<T>(this T item, T value, IComparer<T> comparer)
	{
		return comparer.IfNull(Comparer<T>.Default).Compare(item, value) >= 0;
	}

	/// <summary>
	/// 检测当前对象是否大于等于 <paramref name="value" /> 的值
	/// </summary>
	/// <typeparam name="T">待检测的对象类型</typeparam>
	/// <param name="item">待检测的对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="comparison">对象比较方法</param>
	/// <returns>如果当前对象大于等于 <paramref name="value" /> 的值返回true，否则返回false</returns>
	public static bool IsGreaterThanOrEqualTo<T>(this T item, T value, Func<T, T, int> comparison)
	{
		return comparison.IfNull(Comparer<T>.Default.Compare)(item, value) >= 0;
	}

	/// <summary>
	/// 检测当前对象是否是指定类型的实例
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="type">指定的目标类型</param>
	/// <returns>如果当前对象是指定类型的实例则返回true，否则返回false。如果当前对象为空，则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="type" /> 为空。</exception>
	public static bool IsInstanceOf(this object item, Type type)
	{
		type.GuardNotNull("Instance Type");
		return item.IsNotNull() && type.IsInstanceOfType(item);
	}

	/// <summary>
	/// 检测当前对象是否是指定类型的实例
	/// </summary>
	/// <typeparam name="T">指定的目标类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <returns>如果当前对象是指定类型的实例则返回true，否则返回false。如果当前对象为空，则返回false。</returns>
	public static bool IsInstanceOf<T>(this object item)
	{
		return item.IsNotNull() && typeof(T).IsInstanceOfType(item);
	}

	/// <summary>
	/// 检测当前对象是否小于 <paramref name="value" /> 的值
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="comparer">对象比较对象</param>
	/// <returns>如果当前对象小于 <paramref name="value" /> 的值返回true，否则返回false</returns>
	public static bool IsLessThan<T>(this T item, T value, IComparer<T> comparer)
	{
		return comparer.IfNull(Comparer<T>.Default).Compare(item, value) < 0;
	}

	/// <summary>
	/// 检测当前对象是否小于 <paramref name="value" /> 的值
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="comparison">对象比较方法</param>
	/// <returns>如果当前对象小于 <paramref name="value" /> 的值返回true，否则返回false</returns>
	public static bool IsLessThan<T>(this T item, T value, Func<T, T, int> comparison)
	{
		return comparison.IfNull(Comparer<T>.Default.Compare)(item, value) < 0;
	}

	/// <summary>
	/// 检测当前对象是否小于等于 <paramref name="value" /> 的值
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="comparer">对象比较对象</param>
	/// <returns>如果当前对象小于等于 <paramref name="value" /> 的值返回true，否则返回false</returns>
	public static bool IsLessThanOrEqualTo<T>(this T item, T value, IComparer<T> comparer)
	{
		return comparer.IfNull(Comparer<T>.Default).Compare(item, value) <= 0;
	}

	/// <summary>
	/// 检测当前对象是否小于等于 <paramref name="value" /> 的值
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="comparison">对象比较方法</param>
	/// <returns>如果当前对象小于等于 <paramref name="value" /> 的值返回true，否则返回false</returns>
	public static bool IsLessThanOrEqualTo<T>(this T item, T value, Func<T, T, int> comparison)
	{
		return comparison.IfNull(Comparer<T>.Default.Compare)(item, value) <= 0;
	}

	/// <summary>
	/// 检测当前对象是否为空（null）
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <returns>如果为空返回true，否则返回false</returns>
	public static bool IsNull(this object item)
	{
		return object.ReferenceEquals(item, null);
	}

	/// <summary>
	/// 检测对象是否不为空（null）
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <returns>如果不为空返回true，否则返回false</returns>
	public static bool IsNotNull(this object item)
	{
		return !object.ReferenceEquals(item, null);
	}

	/// <summary>
	/// 检测对象是否为空或者 <see cref="T:System.DBNull" />
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <returns>如果对象为空或者是 <see cref="T:System.DBNull" /> 则返回true，否则返回false。</returns>
	public static bool IsNullOrDBNull(this object item)
	{
		return item.IsNull() || item.IsDBNull();
	}

	/// <summary>
	/// 检测对象是否不为空（null）且不为 <see cref="T:System.DBNull" />
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <returns>如果对象不为空或者是 <see cref="T:System.DBNull" /> 则返回true，否则返回false。</returns>
	public static bool IsNotNullAndDBNull(this object item)
	{
		return item.IsNotNull() && item.IsNotDBNull();
	}

	/// <summary>
	/// 检测当前对象是否为空（null）或者等于指定类型的默认值
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="type">默认值的类型</param>
	/// <returns>如果当前对象为空（null）或者等于指定类型的默认值返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空时，对象类型 <paramref name="type" /> 为空。</exception>
	public static bool IsNullOrDefault(this object item, Type type = null)
	{
		return item.IsNull() || item.IsDefault(type);
	}

	/// <summary>
	/// 检测当前对象是否为空（null）或者等于指定类型的默认值
	/// </summary>
	/// <typeparam name="T">默认值的类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <returns>如果当前对象为空（null）或者等于指定类型的默认值返回true，否则返回false</returns>
	public static bool IsNullOrDefault<T>(this T item)
	{
		return item.IsNull() || item.IsDefault();
	}

	/// <summary>
	/// 检测当前对象是否为空（null）或者等于指定类型的默认值
	/// </summary>
	/// <typeparam name="T">默认值的类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="equaliter">对象相等比较器</param>
	/// <returns>如果当前对象为空（null）或者等于指定类型的默认值返回true，否则返回false</returns>
	public static bool IsNullOrDefault<T>(this T item, IEqualityComparer<T> equaliter)
	{
		return item.IsNull() || item.IsDefault(equaliter);
	}

	/// <summary>
	/// 检测当前对象是否为空（null）或者等于指定类型的默认值
	/// </summary>
	/// <typeparam name="T">默认值的类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="equalition">对象相等比较方法</param>
	/// <returns>如果当前对象是否为空（null）或者等于指定类型的默认值返回true，否则返回false</returns>
	public static bool IsNullOrDefault<T>(this T item, Func<T, T, bool> equalition)
	{
		return item.IsNull() || item.IsDefault(equalition);
	}

	/// <summary>
	/// 检测当前对象是否不为空（null）且不等于指定类型的默认值
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="type">默认值的类型</param>
	/// <returns>如果当前对象不为空（null）或者不等于指定类型的默认值返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空时，对象类型 <paramref name="type" /> 为空。</exception>
	public static bool IsNotNullAndDefault(this object item, Type type = null)
	{
		return item.IsNotNull() && item.IsNotDefault(type);
	}

	/// <summary>
	/// 检测当前对象是否不为空（null）且不等于指定类型的默认值
	/// </summary>
	/// <typeparam name="T">默认值的类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <returns>如果当前对象不为空（null）或者不等于指定类型的默认值返回true，否则返回false</returns>
	public static bool IsNotNullAndDefault<T>(this T item)
	{
		return item.IsNotNull() && item.IsNotDefault();
	}

	/// <summary>
	/// 检测当前对象是否不为空（null）且不等于指定类型的默认值
	/// </summary>
	/// <typeparam name="T">默认值的类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="equaliter">对象相等比较器</param>
	/// <returns>如果当前对象不为空（null）或者不等于指定类型的默认值返回true，否则返回false</returns>
	public static bool IsNotNullAndDefault<T>(this T item, IEqualityComparer<T> equaliter)
	{
		return item.IsNotNull() && item.IsNotDefault(equaliter);
	}

	/// <summary>
	/// 检测当前对象是否不为空（null）且不等于指定类型的默认值
	/// </summary>
	/// <typeparam name="T">默认值的类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="equalition">对象相等比较方法</param>
	/// <returns>如果当前对象是否为空（null）或者等于指定类型的默认值返回true，否则返回false</returns>
	public static bool IsNotNullAndDefault<T>(this T item, Func<T, T, bool> equalition)
	{
		return item.IsNotNull() && item.IsNotDefault(equalition);
	}

	/// <summary>
	/// 判断当前对象是否是引用类型（类或者接口）
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <returns>如果当前对象是引用类型则返回true，否则返回false。如果当前对象为空，则返回false。</returns>
	public static bool IsReferenceType(this object item)
	{
		return item.IsNotNull() && item.GetType().IsReferenceType();
	}

	/// <summary>
	/// 检测当前对象与目标类型是否兼容
	/// </summary>
	/// <param name="obj">当前对象</param>
	/// <param name="type">检测的目标类型</param>
	/// <returns>如果当前对象与目标类型兼容返回true，否则返回false。</returns>
	public static bool IsType(this object obj, Type type)
	{
		return obj.IsNotNull() && obj.GetType().IsType(type);
	}

	/// <summary>
	/// 检测当前对象与目标类型是否兼容
	/// </summary>
	/// <typeparam name="T">检测的目标类型</typeparam>
	/// <param name="obj">当前对象</param>
	/// <returns>如果当前对象与目标类型兼容返回true，否则返回false。</returns>
	public static bool IsType<T>(this object obj)
	{
		return obj.IsNotNull() && obj.GetType().IsType<T>();
	}

	/// <summary>
	/// 检测当前对象是否为值类型
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <returns>如果当前对象为值类型则返回true，否则返回false。如果当前对象为空，则返回false。</returns>
	public static bool IsValueType(this object item)
	{
		return item.IsNotNull() && item.GetType().IsValueType;
	}

	/// <summary>
	/// 将当前对象序列化为Json表达式
	/// </summary>
	/// <param name="obj">当前对象</param>
	/// <returns>序列化后的Json表达式</returns>
	public static string JsonSerialize(this object obj)
	{
		IsoDateTimeConverter converter = new IsoDateTimeConverter();
		converter.DateTimeFormat = "yyyy-MM-ddTHH:mm:ss.fff";
		return obj.JsonSerialize(converter);
	}

	/// <summary>
	/// 将当前对象序列化为Json表达式
	/// </summary>
	/// <param name="obj">当前对象</param>
	/// <param name="converters">自定义的Json转换器</param>
	/// <returns>序列化后的Json表达式</returns>
	public static string JsonSerialize(this object obj, params JsonConverter[] converters)
	{
		return JsonConvert.SerializeObject(obj, converters);
	}

	/// <summary>
	/// 构造将当前对象作为唯一元素的数组
	/// </summary>
	/// <typeparam name="T">对象类型</typeparam>
	/// <param name="value">当前对象</param>
	/// <returns>对象数组</returns>
	public static T[] MakeArray<T>(this T value)
	{
		return new T[1] { value };
	}

	/// <summary>
	/// 构造当前对象类型的一维数组，并使用当前对象填充全部数组元素
	/// </summary>
	/// <typeparam name="T">对象类型</typeparam>
	/// <param name="value">当前对象</param>
	/// <param name="length">对象数组长度</param>
	/// <returns>对象数组</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="length" /> 小于0。</exception>
	public static T[] MakeArray<T>(this T value, int length)
	{
		length.GuardGreaterThanOrEqualTo(0, "Length");
		T[] values = new T[length];
		for (int i = 0; i < values.Length; i++)
		{
			values[i] = value;
		}
		return values;
	}

	/// <summary>
	/// 构造当前对象类型的一维数组，并使用当前对象填充全部数组元素
	/// </summary>
	/// <typeparam name="T">对象类型</typeparam>
	/// <param name="value">当前对象</param>
	/// <param name="length">对象数组长度</param>
	/// <returns>对象数组</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="length" /> 小于0。</exception>
	public static T[] MakeArray<T>(this T value, long length)
	{
		length.GuardGreaterThanOrEqualTo(0L, "Length");
		T[] values = new T[length];
		for (long i = 0L; i < values.LongLength; i++)
		{
			values[i] = value;
		}
		return values;
	}

	/// <summary>
	/// 构造当前对象类型的多维数组，并使用当前对象填充全部数组元素
	/// </summary>
	/// <typeparam name="T">对象类型</typeparam>
	/// <param name="value">当前对象</param>
	/// <param name="lengths">对象多维数组各个维度的长度</param>
	/// <returns>对象数组</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="lengths" /> 为空。</exception>
	public static Array MakeArray<T>(this T value, int[] lengths)
	{
		lengths.GuardNotNull("lengths");
		Array array = typeof(T).CreateArray(lengths);
		array.Fill(value);
		return array;
	}

	/// <summary>
	/// 构造当前对象类型的一维数组，并使用当前对象填充全部数组元素
	/// </summary>
	/// <typeparam name="T">对象类型</typeparam>
	/// <param name="value">当前对象</param>
	/// <param name="lengths">对象多维数组各个维度的长度</param>
	/// <returns>对象数组</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="lengths" /> 为空。</exception>
	public static Array MakeArray<T>(this T value, long[] lengths)
	{
		lengths.GuardNotNull("lengths");
		Array array = typeof(T).CreateArray(lengths);
		array.Fill(value);
		return array;
	}

	/// <summary>
	/// 将当前对象映射为目标类型的对象
	/// </summary>
	/// <typeparam name="T">映射的目标类型</typeparam>
	/// <param name="source">当前对象</param>
	/// <returns>映射生成的目标类型对象</returns>
	public static T MapTo<T>(this object source)
	{
		return TypeMapper.Map<T>(source);
	}

	/// <summary>
	/// 把源对象映射为目标类型
	/// </summary>
	/// <typeparam name="S">映射的源对象类型</typeparam>
	/// <typeparam name="T">映射的目标类型</typeparam>
	/// <param name="source">映射的源对象</param>
	/// <param name="target">映射的目标对象</param>
	/// <returns>映射填充后的目标对象</returns>
	public static T MapTo<S, T>(this S source, T target)
	{
		TypeMapper.Map(source, target);
		return target;
	}

	/// <summary>
	/// 把源对象映射为目标类型
	/// </summary>
	/// <param name="source">映射的源对象</param>
	/// <param name="targetType">映射的目标类型</param>
	/// <returns>映射生成的目标类型对象</returns>
	/// <exception cref="T:System.ArgumentNullException">映射的目标类型 <paramref name="targetType" /> 为空。</exception>
	public static object MapTo(this object source, Type targetType)
	{
		targetType.GuardNotNull("target type");
		return source.IsNull() ? targetType.CreateDefault() : TypeMapper.Map(source, source.GetType(), targetType);
	}

	/// <summary>
	/// 把源对象映射为目标类型
	/// </summary>
	/// <param name="source">映射的源对象</param>
	/// <param name="sourceType">映射的源类型</param>
	/// <param name="targetType">映射的目标类型</param>
	/// <returns>映射生成的目标类型对象</returns>
	/// <exception cref="T:System.ArgumentNullException">映射的源类型 <paramref name="sourceType" /> 为空；或者映射的目标类型 <paramref name="targetType" /> 为空。</exception>
	public static object MapTo(this object source, Type sourceType, Type targetType)
	{
		sourceType.GuardNotNull("source type");
		targetType.GuardNotNull("target type");
		return TypeMapper.Map(source, sourceType, targetType);
	}

	/// <summary>
	/// 将源对象映射到目标对象
	/// </summary>
	/// <param name="source">映射的源对象</param>
	/// <param name="target">映射的目标对象</param>
	/// <param name="sourceType">映射的源类型</param>
	/// <param name="targetType">映射的目标类型</param>
	/// <exception cref="T:System.ArgumentNullException">映射的源类型 <paramref name="sourceType" /> 为空；或者映射的目标类型 <paramref name="targetType" /> 为空。</exception>
	/// <returns>映射填充的目标对象</returns>
	public static object MapTo(this object source, object target, Type sourceType, Type targetType)
	{
		sourceType.GuardNotNull("source type");
		targetType.GuardNotNull("target type");
		TypeMapper.Map(source, target, sourceType, targetType);
		return target;
	}

	/// <summary>
	/// 返回当前值和指定值之间的最大者
	/// </summary>
	/// <typeparam name="T">比较的对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="maxValue">比较的值</param>
	/// <returns>返回两者中的最大值，如果两个值相等返回当前值本身</returns>
	public static T Max<T>(this T item, T maxValue)
	{
		return (Comparer<T>.Default.Compare(item, maxValue) >= 0) ? item : maxValue;
	}

	/// <summary>
	/// 返回当前值和指定值之间的最大者
	/// </summary>
	/// <typeparam name="T">比较的对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="maxValue">比较的值</param>
	/// <param name="comparer">值比较对象</param>
	/// <returns>返回两者中的最大值，如果两个值相等返回当前值本身</returns>
	public static T Max<T>(this T item, T maxValue, IComparer<T> comparer)
	{
		return (comparer.IfNull(Comparer<T>.Default).Compare(item, maxValue) >= 0) ? item : maxValue;
	}

	/// <summary>
	/// 返回当前值和指定值之间的最大者
	/// </summary>
	/// <typeparam name="T">比较的对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="maxValue">比较的值</param>
	/// <param name="comparison">值比较方法</param>
	/// <returns>返回两者中的最大值，如果两个值相等返回当前值本身</returns>
	public static T Max<T>(this T item, T maxValue, Func<T, T, int> comparison)
	{
		return (comparison.IfNull(Comparer<T>.Default.Compare)(item, maxValue) >= 0) ? item : maxValue;
	}

	/// <summary>
	/// 返回当前值和指定值之间的最小值
	/// </summary>
	/// <typeparam name="T">比较的对象类型</typeparam>
	/// <param name="value">待比较的值</param>
	/// <param name="minValue">比较的值</param>
	/// <returns>返回两者中的最小值，如果两个值相等返回当前值本身</returns>
	public static T Min<T>(this T value, T minValue)
	{
		return (Comparer<T>.Default.Compare(minValue, value) < 0) ? minValue : value;
	}

	/// <summary>
	/// 返回当前值和指定值之间的最小值
	/// </summary>
	/// <typeparam name="T">比较的对象类型</typeparam>
	/// <param name="value">待比较的值</param>
	/// <param name="minValue">比较的值</param>
	/// <param name="comparer">值比较对象</param>
	/// <returns>返回两者中的最小值，如果两个值相等返回当前值本身</returns>
	public static T Min<T>(this T value, T minValue, IComparer<T> comparer)
	{
		return (comparer.IfNull(Comparer<T>.Default).Compare(minValue, value) < 0) ? minValue : value;
	}

	/// <summary>
	/// 返回当前值和指定值之间的最小值
	/// </summary>
	/// <typeparam name="T">比较的对象类型</typeparam>
	/// <param name="value">待比较的值</param>
	/// <param name="minValue">比较的值</param>
	/// <param name="comparison">值比较方法</param>
	/// <returns>返回两者中的最小值，如果两个值相等返回当前值本身</returns>
	public static T Min<T>(this T value, T minValue, Func<T, T, int> comparison)
	{
		return (comparison.IfNull(Comparer<T>.Default.Compare)(minValue, value) < 0) ? minValue : value;
	}

	/// <summary>
	/// 调用对象比较方法，检测当前对象是否等于目标对象
	/// </summary>
	/// <param name="obj">当前对象</param>
	/// <param name="target">比较的目标对象</param>
	/// <returns>如果当前对象等于目标对象返回true，否则返回false。</returns>
	public static bool ObjectEquals(this object obj, object target)
	{
		if (object.ReferenceEquals(obj, target))
		{
			return true;
		}
		return (obj.IsNull() || obj.Equals(target)) && (target.IsNull() || target.Equals(obj));
	}

	/// <summary>
	/// 判断当前对象是否满足指定的断言检测
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="predicate">测试断言</param>
	/// <returns>如果当前对象满足指定的断言返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="predicate" /> 为空。</exception>
	public static bool Predicate<T>(this T item, Func<T, bool> predicate)
	{
		predicate.GuardNotNull("predicate");
		return predicate(item);
	}

	/// <summary>
	/// 比较两个对象的引用是否相同
	/// </summary>
	/// <typeparam name="X">参与比较的第一个对象的类型</typeparam>
	/// <typeparam name="Y">参与比较的第二个对象的类型</typeparam>
	/// <param name="x">参与比较的第一个对象</param>
	/// <param name="y">参与比较的第二个对象</param>
	/// <returns>如果两个对象的引用相同发挥true，否则返回false</returns>
	public static bool ReferenceEquals<X, Y>(this X x, Y y)
	{
		return object.ReferenceEquals(x, y);
	}

	/// <summary>
	/// 设置当前对象的由属性路径指定的属性的值
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="obj">当前对象</param>
	/// <param name="propertyPath">属性路径</param>
	/// <param name="value">设置的属性值</param>
	/// <param name="ignoreCase">绑定属性时是否区分大小写</param>
	/// <param name="ignoreMissing">如果指定的属性不存在是否忽略该属性，否则将抛出异常。</param>
	/// <param name="isCover">如果原来有值，是否覆盖（true 覆盖，false 不覆盖）</param>
	/// <returns>处理后的当前对象</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="obj" /> 为空，或者 <paramref name="propertyPath" /> 为空或者空串。</exception>
	/// <exception cref="T:System.Reflection.TargetException">属性路径 <paramref name="propertyPath" /> 指定的属性不可写。</exception>
	/// <exception cref="T:System.MissingMemberException">当 <paramref name="ignoreMissing" /> 为false时，属性路径 <paramref name="propertyPath" /> 指定的属性未找到。</exception>
	/// <exception cref="T:System.InvalidOperationException">属性路径 <paramref name="propertyPath" /> 指定的属性的类型与设置的属性值 <paramref name="value" /> 不匹配。</exception>
	/// <remarks>本方法按照指定的属性路径获取对象的属性、对象属性的属性（对象属性值时对象时）等任意层级的属性值。</remarks>
	public static T SetPropertyValue<T>(this T obj, string propertyPath, object value, bool ignoreCase = false, bool ignoreMissing = false, bool isCover = false)
	{
		return obj.SetPropertyValue(propertyPath, value, BindingFlags.Instance | BindingFlags.Public, ignoreCase, ignoreMissing, isCover);
	}

	/// <summary>
	/// 设置当前对象的由属性路径指定的属性的值。
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="obj">当前对象</param>
	/// <param name="propertyPath">属性路径</param>
	/// <param name="value">设置的属性值</param>
	/// <param name="flags">属性绑定标志</param>
	/// <param name="ignoreCase">绑定属性时是否区分大小写</param>
	/// <param name="ignoreMissing">如果指定的属性不存在是否忽略该属性，否则将抛出异常。</param>
	/// <param name="isCover">如果原来有值，是否覆盖（true 覆盖，false 不覆盖）</param>
	/// <returns>处理后的当前对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者属性路径 <paramref name="propertyPath" /> 为空或者空串。</exception>
	/// <exception cref="T:System.Reflection.TargetException">属性路径 <paramref name="propertyPath" /> 指定的属性不可写。</exception>
	/// <exception cref="T:System.MissingMemberException">当 <paramref name="ignoreMissing" /> 为false时，属性路径 <paramref name="propertyPath" /> 指定的属性未找到。</exception>
	/// <exception cref="T:System.InvalidOperationException">属性路径 <paramref name="propertyPath" /> 指定的属性的类型与设置的属性值 <paramref name="value" /> 不匹配。</exception>
	public static T SetPropertyValue<T>(this T obj, string propertyPath, object value, BindingFlags flags, bool ignoreCase = false, bool ignoreMissing = false, bool isCover = false)
	{
		obj.GuardNotNull("object");
		propertyPath.GuardNotNullAndEmpty("property path");
		object owner = null;
		PropertyInfo pinfo = obj.GetProperty(propertyPath, flags, out owner, ignoreCase);
		if (pinfo.IsNull())
		{
			if (ignoreMissing)
			{
				return obj;
			}
			throw new MissingMemberException(obj.GetType().FullName, propertyPath);
		}
		object oldValue = null;
		bool flag = true;
		if (!isCover)
		{
			oldValue = PropertyInfoExtensions.GetValue(pinfo, obj);
			if (pinfo.PropertyType == typeof(DateTime))
			{
				flag = (DateTime)oldValue == DateTime.MinValue;
			}
			else if (pinfo.PropertyType == typeof(decimal))
			{
				flag = Convert.ToDecimal(oldValue) == 0m;
			}
			else if (!oldValue.IsNull())
			{
				flag = false;
			}
		}
		if (!flag)
		{
			return obj;
		}
		pinfo.Guard(pinfo.CanWrite, () => new TargetException(Literals.MSG_ObjectPropertyUnwritable));
		if (value.IsNull())
		{
			if (!pinfo.PropertyType.IsNullable())
			{
				throw new InvalidOperationException(Literals.MSG_ObjectPropertyTypeNotMatch, null);
			}
			pinfo.SetValue(owner, value, null);
		}
		else if (pinfo.PropertyType.IsAssignableFrom(value.GetType()))
		{
			pinfo.SetValue(owner, value, null);
		}
		else
		{
			try
			{
				value = value.ConvertTo(pinfo.PropertyType);
			}
			catch (Exception ex)
			{
				throw new InvalidOperationException(Literals.MSG_ObjectPropertyTypeNotMatch, ex);
			}
			pinfo.SetValue(owner, value, null);
		}
		return obj;
	}

	/// <summary>
	/// 创建当前对象的浅表副本
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <returns>当前对象的浅表副本</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="item" /> 为空。</exception>
	public static T ShallowCopy<T>(this T item)
	{
		item.GuardNotNull("item");
		MethodInfo minfo = typeof(T).GetMethod("MemberwiseClone", BindingFlags.Instance | BindingFlags.NonPublic);
		if (minfo.IsNull())
		{
			throw new TargetException(Literals.MSG_ObjectNoMemberwiseClone);
		}
		return (T)minfo.Invoke(item, null);
	}

	/// <summary>
	/// 根据 <paramref name="switcher" /> 的处理结果，执行不同的委托
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="obj">当前对象</param>
	/// <param name="switcher">选择处理委托。</param>
	/// <param name="actions">执行委托数组。</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="switcher" /> 为空；或者 <paramref name="actions" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="switcher" /> 的结果值超过委托数组 <paramref name="actions" /> 的最大索引位置。</exception>
	/// <remarks>
	/// <paramref name="switcher" /> 接收 <typeparamref name="T" /> 类型的输入值，返回 <see cref="T:System.Int32" /> 类型的返回值。该返回值对应 <paramref name="actions" /> 中委托的索引，将会执行该返回值对应位置的委托。
	/// </remarks>
	public static void Switch<T>(this T obj, Func<T, int> switcher, params Action[] actions)
	{
		switcher.GuardNotNull("Swticher");
		actions.GuardNotNull("Actions");
		int index = switcher(obj);
		if (0 <= index && index < actions.Length)
		{
			actions[index]();
			return;
		}
		throw new ArgumentOutOfRangeException("Action Index", Literals.MSG_SwitchIndexOutOfRange);
	}

	/// <summary>
	/// 根据 <paramref name="switcher" /> 的处理结果，执行不同的委托
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="obj">当前对象</param>
	/// <param name="switcher">选择处理委托。</param>
	/// <param name="actions">执行委托数组。</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="switcher" /> 为空；或者 <paramref name="actions" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="switcher" /> 的结果值超过委托数组 <paramref name="actions" /> 的最大索引位置。</exception>
	/// <remarks>
	/// <paramref name="switcher" /> 接收 <typeparamref name="T" /> 类型的输入值，返回 <see cref="T:System.Int32" /> 类型的返回值。该返回值对应 <paramref name="actions" /> 中委托的索引，将会执行该返回值对应位置的委托。
	/// </remarks>
	public static void Switch<T>(this T obj, Func<T, int> switcher, params Action<T>[] actions)
	{
		switcher.GuardNotNull("Swticher");
		actions.GuardNotNull("Actions");
		int index = switcher(obj);
		if (0 <= index && index < actions.Length)
		{
			actions[index](obj);
			return;
		}
		throw new ArgumentOutOfRangeException("Action Index", Literals.MSG_SwitchIndexOutOfRange);
	}

	/// <summary>
	/// 将当前对象转换为数据行，创建并返回包含该数据行的数据表。当前对象的所有公共实例属性转换为数据表的列。
	/// </summary>
	/// <param name="obj">当前对象</param>
	/// <returns>映射生成的数据表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空。</exception>
	public static DataTable ToDataTable(this object obj)
	{
		return obj.ToDataTable<DataTable>();
	}

	/// <summary>
	/// 将当前对象转换为数据行，并存入指定的数据表中。当前对象的所有公共实例属性转换为数据表的列。
	/// </summary>
	/// <typeparam name="T">数据表类型</typeparam>
	/// <param name="obj">当前对象</param>
	/// <param name="table">存入的数据表</param>
	/// <returns>存入数据行的数据表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空。</exception>
	public static T ToDataTable<T>(this object obj, T table = null) where T : DataTable, new()
	{
		return obj.ToDataTable(BindingFlags.Instance | BindingFlags.Public, table);
	}

	/// <summary>
	/// 将当前对象转换为数据行，创建并返回包含该数据行的数据表
	/// </summary>
	/// <param name="obj">当前对象</param>
	/// <param name="flags">属性绑定标志</param>
	/// <returns>映射生成的数据表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空。</exception>
	public static DataTable ToDataTable(this object obj, BindingFlags flags)
	{
		return obj.ToDataTable<DataTable>(flags);
	}

	/// <summary>
	/// 将当前对象转换为数据行，并存入指定的数据表中
	/// </summary>
	/// <typeparam name="T">数据表类型</typeparam>
	/// <param name="obj">当前对象</param>
	/// <param name="flags">属性绑定标志</param>
	/// <param name="table">存入的数据表</param>
	/// <returns>存入数据行的数据表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空。</exception>
	public static T ToDataTable<T>(this object obj, BindingFlags flags, T table = null) where T : DataTable, new()
	{
		return obj.ToDataTable(new DataMapping[0], flags, onlyMapping: false, ignoreCase: false, table);
	}

	/// <summary>
	/// 将当前对象转换为数据行，创建并返回包含该数据行的数据表。当前对象的所有公共实例属性转换为数据表的列。
	/// </summary>
	/// <param name="obj">当前对象</param>
	/// <param name="propertyNames">转换的对象属性名称列表</param>
	/// <param name="onlyMapping">是否只处理在映射中定义的属性</param>
	/// <param name="ignoreCase">名称比较是否区分大小写</param>
	/// <returns>映射生成的数据表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者转换的对象属性名称列表 <paramref name="propertyNames" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">映射中指定的对象属性不存在。</exception>
	public static DataTable ToDataTable(this object obj, string[] propertyNames, bool onlyMapping = false, bool ignoreCase = false)
	{
		return obj.ToDataTable<DataTable>(propertyNames, onlyMapping, ignoreCase);
	}

	/// <summary>
	/// 将当前对象转换为数据行，并存入指定的数据表中。当前对象的所有公共实例属性转换为数据表的列。
	/// </summary>
	/// <typeparam name="T">数据表类型</typeparam>
	/// <param name="obj">当前对象</param>
	/// <param name="propertyNames">转换的对象属性名称列表</param>
	/// <param name="onlyMapping">是否只处理在映射中定义的属性</param>
	/// <param name="ignoreCase">名称比较是否区分大小写</param>
	/// <param name="table">存入的数据表</param>
	/// <returns>存入数据行的数据表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者转换的对象属性名称列表 <paramref name="propertyNames" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">映射中指定的对象属性不存在。</exception>
	public static T ToDataTable<T>(this object obj, string[] propertyNames, bool onlyMapping = false, bool ignoreCase = false, T table = null) where T : DataTable, new()
	{
		return obj.ToDataTable(propertyNames, BindingFlags.Instance | BindingFlags.Public, onlyMapping, ignoreCase, table);
	}

	/// <summary>
	/// 将当前对象转换为数据行，创建并返回包含该数据行的数据表
	/// </summary>
	/// <param name="obj">当前对象</param>
	/// <param name="propertyNames">转换的对象属性名称列表</param>
	/// <param name="flags">属性绑定标志</param>
	/// <param name="onlyMapping">是否只处理在映射中定义的属性</param>
	/// <param name="ignoreCase">名称比较是否区分大小写</param>
	/// <returns>映射生成的数据表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者转换的对象属性名称列表 <paramref name="propertyNames" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">映射中指定的对象属性不存在。</exception>
	public static DataTable ToDataTable(this object obj, string[] propertyNames, BindingFlags flags, bool onlyMapping = false, bool ignoreCase = false)
	{
		return obj.ToDataTable<DataTable>(propertyNames, flags, onlyMapping, ignoreCase);
	}

	/// <summary>
	/// 将当前对象转换为数据行，并存入指定的数据表中
	/// </summary>
	/// <typeparam name="T">数据表类型</typeparam>
	/// <param name="obj">当前对象</param>
	/// <param name="propertyNames">转换的对象属性名称列表</param>
	/// <param name="flags">属性绑定标志</param>
	/// <param name="onlyMapping">是否只处理在映射中定义的属性</param>
	/// <param name="ignoreCase">名称比较是否区分大小写</param>
	/// <param name="table">存入的数据表</param>
	/// <returns>存入数据行的数据表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者转换的对象属性名称列表 <paramref name="propertyNames" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">映射中指定的对象属性不存在。</exception>
	public static T ToDataTable<T>(this object obj, string[] propertyNames, BindingFlags flags, bool onlyMapping = false, bool ignoreCase = false, T table = null) where T : DataTable, new()
	{
		propertyNames.GuardNotNull("property names");
		DataMapping[] mappings = (from n in propertyNames.Where((string n) => n.IsNotNull()).Distinct()
			select new DataMapping(null, n)).ToArray();
		return obj.ToDataTable(mappings, flags, onlyMapping, ignoreCase, table);
	}

	/// <summary>
	/// 将当前对象转换为数据行，创建并返回包含该数据行的数据表。当前对象的所有公共实例属性转换为数据表的列。
	/// </summary>
	/// <param name="obj">当前对象</param>
	/// <param name="mappings">对象属性到数据列的映射</param>
	/// <param name="onlyMapping">是否只处理在映射中定义的属性</param>
	/// <param name="ignoreCase">名称比较是否区分大小写</param>
	/// <returns>映射生成的数据表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者属性映射规则 <paramref name="mappings" /> 为空。</exception>
	/// <exception cref="T:System.MissingMemberException">映射中指定的对象属性不存在</exception>
	/// <exception cref="T:System.Data.DuplicateNameException">映射的数据列名称重复</exception>
	public static DataTable ToDataTable(this object obj, DataMapping[] mappings, bool onlyMapping = false, bool ignoreCase = false)
	{
		return obj.ToDataTable<DataTable>(mappings, onlyMapping, ignoreCase);
	}

	/// <summary>
	/// 将当前对象转换为数据行，并存入指定的数据表中。当前对象的所有公共实例属性转换为数据表的列。
	/// </summary>
	/// <typeparam name="T">数据表类型</typeparam>
	/// <param name="obj">当前对象</param>
	/// <param name="mappings">对象属性到数据列的映射</param>
	/// <param name="onlyMapping">是否只处理在映射中定义的属性</param>
	/// <param name="ignoreCase">名称比较是否区分大小写</param>
	/// <param name="table">存入的数据表</param>
	/// <returns>存入数据行的数据表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者属性映射规则 <paramref name="mappings" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">映射中指定的对象属性不存在。</exception>
	/// <exception cref="T:System.Data.DuplicateNameException">映射的数据列名称重复</exception>
	public static T ToDataTable<T>(this object obj, DataMapping[] mappings, bool onlyMapping = false, bool ignoreCase = false, T table = null) where T : DataTable, new()
	{
		return obj.ToDataTable(mappings, BindingFlags.Instance | BindingFlags.Public, onlyMapping, ignoreCase, table);
	}

	/// <summary>
	/// 将当前对象转换为数据行，创建并返回包含该数据行的数据表。
	/// </summary>
	/// <param name="obj">当前对象</param>
	/// <param name="mappings">对象属性到数据列的映射，对象属性名称支持属性路径，未设置对象属性则忽略</param>
	/// <param name="flags">属性绑定标志</param>
	/// <param name="onlyMapping">是否只处理在映射中定义的属性</param>
	/// <param name="ignoreCase">名称比较是否区分大小写</param>
	/// <returns>映射生成的数据表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者属性映射规则 <paramref name="mappings" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">映射中指定的对象属性不存在。</exception>
	/// <exception cref="T:System.Data.DuplicateNameException">映射的数据列名称重复。</exception>
	public static DataTable ToDataTable(this object obj, DataMapping[] mappings, BindingFlags flags, bool onlyMapping = false, bool ignoreCase = false)
	{
		return obj.ToDataTable<DataTable>(mappings, flags, onlyMapping, ignoreCase);
	}

	/// <summary>
	/// 将当前对象转换为数据行，并存入指定的数据表中。
	/// </summary>
	/// <typeparam name="T">数据表类型</typeparam>
	/// <param name="obj">当前对象</param>
	/// <param name="mappings">对象属性到数据列的映射，对象属性名称支持属性路径，未设置对象属性则忽略</param>
	/// <param name="flags">属性绑定标志</param>
	/// <param name="onlyMapping">是否只处理在映射中定义的属性</param>
	/// <param name="ignoreCase">名称比较是否区分大小写</param>
	/// <param name="table">存入的数据表</param>
	/// <returns>存入数据行的数据表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者属性映射规则 <paramref name="mappings" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">映射中指定的对象属性不存在。</exception>
	/// <exception cref="T:System.Data.DuplicateNameException">映射的数据列名称重复。</exception>
	public static T ToDataTable<T>(this object obj, DataMapping[] mappings, BindingFlags flags, bool onlyMapping = false, bool ignoreCase = false, T table = null) where T : DataTable, new()
	{
		obj.GuardNotNull("object");
		mappings.GuardNotNull("mappings");
		table = table.IfNull(new T());
		Dictionary<string, Tuple<DataColumn, PropertyInfo, object>> columns = new Dictionary<string, Tuple<DataColumn, PropertyInfo, object>>(ignoreCase ? StringComparer.OrdinalIgnoreCase : StringComparer.Ordinal);
		columns.TryAddRange(table.Columns(), (DataColumn c) => c.ColumnName, (DataColumn c) => new Tuple<DataColumn, PropertyInfo, object>(c, null, null));
		object owner;
		if (onlyMapping)
		{
			foreach (DataMapping mapping in mappings.Where((DataMapping m) => m.IsNotNull() && m.PropertyName.IsNotNullAndEmpty()))
			{
				PropertyInfo pinfo = obj.GetProperty(mapping.PropertyName, flags, out owner, ignoreCase);
				if (pinfo.IsNull())
				{
					throw new ArgumentException(Literals.MSG_MissingProperty_1.FormatValue(mapping.PropertyName), "mappings");
				}
				string columnName = mapping.ColumnName.IfNullOrEmpty(pinfo.Name);
				if (columns.ContainsKey(columnName))
				{
					if (!pinfo.PropertyType.IsType(columns[columnName].Item1.DataType))
					{
						throw new DuplicateNameException(Literals.MSG_DataColumnDuplication_1.FormatValue(columnName));
					}
					Tuple<DataColumn, PropertyInfo, object> tuple = columns[columnName];
					columns[columnName] = new Tuple<DataColumn, PropertyInfo, object>(tuple.Item1, pinfo, owner);
				}
				else
				{
					DataColumn column = new DataColumn(columnName, pinfo.PropertyType);
					table.Columns.Add(column);
					columns.Add(columnName, new Tuple<DataColumn, PropertyInfo, object>(column, pinfo, owner));
				}
			}
		}
		else
		{
			Dictionary<string, DataMapping> properties = new Dictionary<string, DataMapping>(ignoreCase ? StringComparer.OrdinalIgnoreCase : StringComparer.Ordinal);
			properties.TryAddRange(mappings.Where((DataMapping m) => m.IsNotNull() && m.ColumnName.IsNotNullAndEmpty()), (DataMapping m) => m.PropertyName);
			PropertyInfo[] properties2 = obj.GetType().GetProperties(flags);
			foreach (PropertyInfo pinfo in properties2)
			{
				if (properties.ContainsKey(pinfo.Name))
				{
					string columnName = properties[pinfo.Name].ColumnName.IfNullOrEmpty(pinfo.Name);
					if (columns.ContainsKey(columnName))
					{
						if (!pinfo.PropertyType.IsType(columns[columnName].Item1.DataType))
						{
							throw new DuplicateNameException(Literals.MSG_DataColumnDuplication_1.FormatValue(columnName));
						}
						Tuple<DataColumn, PropertyInfo, object> tuple = columns[columnName];
						columns[columnName] = new Tuple<DataColumn, PropertyInfo, object>(tuple.Item1, pinfo, obj);
					}
					else
					{
						DataColumn column = new DataColumn(columnName, pinfo.PropertyType);
						table.Columns.Add(column);
						columns.Add(columnName, new Tuple<DataColumn, PropertyInfo, object>(column, pinfo, obj));
					}
					properties.Remove(pinfo.Name);
				}
				else
				{
					string columnName = pinfo.Name;
					if (columns.ContainsKey(columnName))
					{
						if (!pinfo.PropertyType.IsType(columns[columnName].Item1.DataType))
						{
							throw new DuplicateNameException(Literals.MSG_DataColumnDuplication_1.FormatValue(columnName));
						}
						Tuple<DataColumn, PropertyInfo, object> tuple = columns[columnName];
						columns[columnName] = new Tuple<DataColumn, PropertyInfo, object>(tuple.Item1, pinfo, obj);
					}
					else
					{
						DataColumn column = new DataColumn(columnName, pinfo.PropertyType);
						table.Columns.Add(column);
						columns.Add(columnName, new Tuple<DataColumn, PropertyInfo, object>(column, pinfo, obj));
					}
				}
				foreach (DataMapping mapping in properties.Values)
				{
					PropertyInfo extraPinfo = obj.GetProperty(mapping.PropertyName, out owner, ignoreCase);
					if (extraPinfo.IsNull())
					{
						throw new ArgumentException(Literals.MSG_MissingProperty_1.FormatValue(mapping.PropertyName), "mappings");
					}
					string columnName = mapping.ColumnName.IfNullOrEmpty(extraPinfo.Name);
					if (columns.ContainsKey(columnName))
					{
						if (!pinfo.PropertyType.IsType(columns[columnName].Item1.DataType))
						{
							throw new DuplicateNameException(Literals.MSG_DataColumnDuplication_1.FormatValue(columnName));
						}
						Tuple<DataColumn, PropertyInfo, object> tuple = columns[columnName];
						columns[columnName] = new Tuple<DataColumn, PropertyInfo, object>(tuple.Item1, pinfo, owner);
					}
					else
					{
						DataColumn column = new DataColumn(columnName, pinfo.PropertyType);
						table.Columns.Add(column);
						columns.Add(columnName, new Tuple<DataColumn, PropertyInfo, object>(column, pinfo, owner));
					}
				}
			}
		}
		DataRow row = table.NewRow();
		foreach (KeyValuePair<string, Tuple<DataColumn, PropertyInfo, object>> kvp in columns)
		{
			if (kvp.Value.Item2.IsNotNull())
			{
				row[kvp.Value.Item1] = kvp.Value.Item2.GetValue(kvp.Value.Item3, null).ConvertTo(kvp.Value.Item2.PropertyType);
			}
		}
		table.Rows.Add(row);
		row.AcceptChanges();
		return table;
	}

	/// <summary>
	/// 为当前对象执行指定的处理，返回可能出现的异常；如果未发生异常，则返回null。
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="action">对象处理方法</param>
	/// <returns>返回处理过程中可能出现的异常；如果未发生异常，则返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="action" /> 为空。</exception>
	public static Exception Try<T>(this T item, Action<T> action)
	{
		action.GuardNotNull("action");
		return action.Try(item);
	}

	/// <summary>
	/// 对当前对象执行指定的处理，并由指定的异常捕获器处理异常；如果未定义异常捕获器则抛出异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="action">对象处理方法</param>
	/// <param name="catcher">异常捕获器</param>
	/// <param name="finalizer">终结处理，无论异常是否发生，都将执行该处理</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="action" /> 为空。</exception>
	public static void Try<T>(this T item, Action<T> action, Action<Exception> catcher, Action finalizer = null)
	{
		action.GuardNotNull("action");
		action.Try(item, catcher, finalizer);
	}

	/// <summary>
	/// 为当前对象执行指定的处理，返回可能出现的异常；如果未发生异常，则返回null。
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <typeparam name="R">处理结果类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="func">函数处理委托</param>
	/// <param name="result">函数处理结果</param>
	/// <returns>返回处理过程中可能出现的异常；如果未发生异常，则返回null。</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="func" /> 为空。</exception>
	public static Exception Try<T, R>(this T item, Func<T, R> func, out R result)
	{
		func.GuardNotNull("func");
		return func.Try(item, out result);
	}

	/// <summary>
	/// 为当前对象执行指定的处理，如果处理成功返回处理结果，否则返回指定的默认值，并输出处理产生的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <typeparam name="R">处理结果类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="func">函数处理委托</param>
	/// <param name="defaultValue">函数处理默认值</param>
	/// <param name="ex">处理中产生的异常，如果处理成功，返回null</param>
	/// <returns>函数处理结果</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="func" /> 为空。</exception>
	public static R Try<T, R>(this T item, Func<T, R> func, R defaultValue, out Exception ex)
	{
		func.GuardNotNull("func");
		ex = func.Try(item, out var result);
		return ex.IsNull() ? result : defaultValue;
	}

	/// <summary>
	/// 对当前对象执行函数处理委托，并由指定的异常捕获器处理异常，并返回异常时的结果值；如果未定义异常捕获器则抛出异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <typeparam name="R">处理结果类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="func">函数处理委托</param>
	/// <param name="catcher">异常捕获器</param>
	/// <param name="finalizer">终结处理，无论异常是否发生，都将执行该处理</param>
	/// <returns>函数处理结果</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="func" /> 为空。</exception>
	public static R Try<T, R>(this T item, Func<T, R> func, Func<Exception, R> catcher, Action<R> finalizer = null)
	{
		func.GuardNotNull("func");
		return func.Try(item, catcher, finalizer);
	}

	/// <summary>
	/// 如果当前对象满足指定的断言 <paramref name="predicate" />，则返回 <paramref name="func" /> 的返回值
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <typeparam name="R">返回值类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="predicate">检测断言</param>
	/// <param name="func">满足断言条件时执行的函数</param>
	/// <returns>如果对象满足指定的断言检测，返回 <paramref name="func" /> 的返回值，否则返回对象本身</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="predicate" /> 为空；或者 <paramref name="func" /> 为空。</exception>
	public static R When<T, R>(this T item, Func<T, bool> predicate, Func<R> func)
	{
		predicate.GuardNotNull("Predicate");
		func.GuardNotNull("Func");
		return predicate(item) ? func() : item.As<R>();
	}

	/// <summary>
	/// 如果当前对象满足指定的断言 <paramref name="predicate" />，则返回 <paramref name="trueFunc" /> 的返回值，否则返回 <paramref name="falseFunc" /> 的返回值
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <typeparam name="R">处理函数返回值类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="predicate">检测断言</param>
	/// <param name="trueFunc">满足断言条件时执行的函数</param>
	/// <param name="falseFunc">不满足断言条件执行的函数</param>
	/// <returns>如果对象满足指定的断言检测，返回 <paramref name="trueFunc" /> 的返回值，否则返回 <paramref name="falseFunc" /> 的返回值</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="predicate" /> 为空；或者 <paramref name="trueFunc" /> 为空；或者 <paramref name="falseFunc" /> 为空。</exception>
	public static R When<T, R>(this T item, Func<T, bool> predicate, Func<R> trueFunc, Func<R> falseFunc)
	{
		predicate.GuardNotNull("Predicate");
		trueFunc.GuardNotNull("True Func");
		falseFunc.GuardNotNull("False Func");
		return predicate(item) ? trueFunc() : falseFunc();
	}

	/// <summary>
	/// 如果当前对象满足指定的断言检测条件，则执行 <paramref name="action" /> 委托
	/// </summary>
	/// <typeparam name="T">对象类型</typeparam>
	/// <param name="item">待检测的对象</param>
	/// <param name="predicate">检测断言</param>
	/// <param name="action">对象处理方法</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="predicate" /> 为空；或者 <paramref name="action" /> 为空。</exception>
	public static void When<T>(this T item, Func<T, bool> predicate, Action action)
	{
		predicate.GuardNotNull("Predicate");
		action.GuardNotNull("Action");
		if (predicate(item))
		{
			action();
		}
	}

	/// <summary>
	/// 如果对象满足指定的断言检测条件，则执行指定的 <paramref name="trueAction" /> 委托，否则执行 <paramref name="falseAction" /> 委托
	/// </summary>
	/// <typeparam name="T">对象类型</typeparam>
	/// <param name="item">待检测的对象</param>
	/// <param name="predicate">检测断言</param>
	/// <param name="trueAction">满足断言条件时执行的动作</param>
	/// <param name="falseAction">不满足断言条件执行的动作</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="predicate" /> 为空；或者 <paramref name="trueAction" /> 为空；或者 <paramref name="falseAction" /> 为空。</exception>
	public static void When<T>(this T item, Func<T, bool> predicate, Action trueAction, Action falseAction)
	{
		predicate.GuardNotNull("Predicate");
		trueAction.GuardNotNull("True Action");
		falseAction.GuardNotNull("False Action");
		if (predicate(item))
		{
			trueAction();
		}
		else
		{
			falseAction();
		}
	}

	/// <summary>
	/// 如果当前对象为空，则返回 <paramref name="evaluator" /> 的结果值，否则返回对象本身
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="evaluator">值函数，不能为空</param>
	/// <returns>处理结果</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="evaluator" /> 为空。</exception>
	public static T WhenNull<T>(this T item, Func<T> evaluator)
	{
		evaluator.GuardNotNull("Evaluator");
		return item.IsNull() ? evaluator() : item;
	}

	/// <summary>
	/// 如果当前对象为空，则执行 <paramref name="action" /> 委托
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="action">执行的委托</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="action" /> 为空。</exception>
	public static void WhenNull<T>(this T item, Action action)
	{
		action.GuardNotNull("Action");
		if (item.IsNull())
		{
			action();
		}
	}

	/// <summary>
	/// 如果对象不为空，则返回 <paramref name="evaluator" /> 的结果值，否则返回对象本身
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="evaluator">值函数</param>
	/// <returns>处理结果</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="evaluator" /> 为空。</exception>
	public static T WhenNotNull<T>(this T item, Func<T> evaluator)
	{
		evaluator.GuardNotNull("Evaluator");
		return item.IsNotNull() ? evaluator() : item;
	}

	/// <summary>
	/// 如果对象不为空，则执行 <paramref name="action" /> 委托
	/// </summary>
	/// <typeparam name="T">对象类型</typeparam>
	/// <param name="item">待检测的对象</param>
	/// <param name="action">待执行的动作</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="action" /> 为空。</exception>
	public static void WhenNotNull<T>(this T item, Action action)
	{
		action.GuardNotNull("action");
		if (item.IsNotNull())
		{
			action();
		}
	}

	/// <summary>
	/// 如果当前对象为空或者为DBNull，则返回 <paramref name="evaluator" /> 的结果值，否则返回对象本身
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="evaluator">值函数，不能为空</param>
	/// <returns>处理结果</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="evaluator" /> 为空。</exception>
	public static T WhenNullOrDBNull<T>(this T item, Func<T> evaluator)
	{
		evaluator.GuardNotNull("Evaluator");
		return item.IsNullOrDBNull() ? evaluator() : item;
	}

	/// <summary>
	/// 如果当前对象为空或者为DBNull，则执行 <paramref name="action" /> 委托
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="action">执行的动作</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="action" /> 为空。</exception>
	public static void WhenNullOrDBNull<T>(this T item, Action action)
	{
		action.GuardNotNull("action");
		if (item.IsNullOrDBNull())
		{
			action();
		}
	}

	/// <summary>
	/// 如果当前对象不是null或者DBNull，则返回 <paramref name="evaluator" /> 的结果值，否则返回对象本身
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="evaluator">值函数，不能为空</param>
	/// <returns>处理结果</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="evaluator" /> 为空。</exception>
	public static T WhenNotNullAndDBNull<T>(this T item, Func<T> evaluator)
	{
		evaluator.GuardNotNull("Evaluator");
		return item.IsNotNullAndDBNull() ? evaluator() : item;
	}

	/// <summary>
	/// 如果当前对象不是null或者DBNull，则执行 <paramref name="action" /> 委托
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="action">执行的动作</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="action" /> 为空。</exception>
	public static void WhenNotNullAndDBNull<T>(this T item, Action action)
	{
		action.GuardNotNull("action");
		if (item.IsNotNullAndDBNull())
		{
			action();
		}
	}

	/// <summary>
	/// 将当前对象序列化为Xml字符流
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="type">当前对象的类型</param>
	/// <returns>对象的Xml序列化字符流</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空时，对象类型 <paramref name="type" /> 为空。</exception>
	public static string XmlSerialize(this object item, Type type = null)
	{
		if (item.IsNull())
		{
			type.GuardNotNull("type");
		}
		else
		{
			type = item.GetType();
		}
		using StringWriter writer = new StringWriter();
		XmlSerializer serializer = new XmlSerializer(type);
		serializer.Serialize(writer, item);
		writer.Flush();
		return writer.ToString();
	}
}
