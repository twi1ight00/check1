#define DEBUG
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Richfit.Garnet.Common.Collections;
using Richfit.Garnet.Common.Data;
using Richfit.Garnet.Common.Mapping;
using Richfit.Garnet.Common.Patterns;
using Richfit.Garnet.Common.Properties;

namespace Richfit.Garnet.Common.Utility;

/// <summary>
/// <see cref="T:System.Object" /> 类型了辅助类
/// </summary>
public static class ObjectHelper
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
	/// 全局的自定义Json转换器
	/// </summary>
	private static JsonConverter[] jsonConverters = null;

	/// <summary>
	/// 将待转换的对象转换为指定的类型，不检测转换时可能产生的溢出错误
	/// </summary>
	/// <typeparam name="T">转换的目标类型</typeparam>
	/// <param name="obj">待转换的对象</param>
	/// <returns>转换后的目标类型的值</returns>
	public static T As<T>(object obj)
	{
		return (T)obj;
	}

	/// <summary>
	/// 将待转换的对象转换为指定的类型
	/// </summary>
	/// <typeparam name="T">转换的目标类型</typeparam>
	/// <param name="obj">待转换的对象</param>
	/// <param name="checkOverflow">是否检查转换溢出</param>
	/// <returns>转换后的目标类型的值</returns>
	/// <exception cref="T:System.OverflowException">当 <paramref name="checkOverflow" /> 为true是，待转换的对象超过了目标类型所能表示的数值范围。</exception>
	public static T As<T>(object obj, bool checkOverflow)
	{
		if (checkOverflow)
		{
			return (T)obj;
		}
		return (T)obj;
	}

	/// <summary>
	/// 将待转换的对象转换为只有该对象一个元素的对象数组
	/// </summary>
	/// <param name="obj">待转换的对象</param>
	/// <returns>包含待转换的对象的对象数组；如果待转换的对象为空，则返回的对象数组将包含一个空元素。</returns>
	public static object[] AsArray(object obj)
	{
		return new object[1] { obj };
	}

	/// <summary>
	/// 将待转换的对象转换为只有该值一个元素的对象数组
	/// </summary>
	/// <typeparam name="T">待转换的对象类型</typeparam>
	/// <param name="value">待转换的对象</param>
	/// <returns>包含待转换的对象的数组；如果待转换的对象为空，则返回的对象数组将包含一个空元素。</returns>
	public static T[] AsArray<T>(T value)
	{
		return new T[1] { value };
	}

	/// <summary>
	/// 将待转换的对象转换为可空的值类型
	/// </summary>
	/// <typeparam name="T">待转换的对象类型</typeparam>
	/// <param name="value">待转换的对象</param>
	/// <returns>待转换的对象类型的可空类型数值</returns>
	public static T? AsNullable<T>(T value) where T : struct
	{
		return value;
	}

	/// <summary>
	/// 将待转换的对象转换为 <see cref="T:System.Object" /> 类型对象
	/// </summary>
	/// <param name="obj">待转换的对象</param>
	/// <returns>转换后的对象</returns>
	public static object AsObject(object obj)
	{
		return obj;
	}

	/// <summary>
	/// 尝试将待转换的对象转换为目标类型；如果待转换的对象不能转换为目标类型，返回目标类型的默认值
	/// </summary>
	/// <typeparam name="T">转换的目标类型</typeparam>
	/// <param name="obj">待转换的对象</param>
	/// <param name="defaultValue">目标类型的默认值</param>
	/// <returns>转换后目标类型的值</returns>
	public static T AsOrDefault<T>(object obj, T defaultValue = default(T))
	{
		if (!(obj is T result))
		{
			return defaultValue;
		}
		return result;
	}

	/// <summary>
	/// 判断当前对象值是否介于两个对象值之间
	/// </summary>
	/// <param name="value">当前对象</param>
	/// <param name="min">值范围的最小值</param>
	/// <param name="max">值范围的最大值</param>
	/// <param name="includeMin">值范围是否包含最小值，默认包含最小值</param>
	/// <param name="includeMax">值范围是否包含最大值，默认包含最大值</param>
	/// <returns>如果当前对象介于最大值和最小值之间返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空。</exception>
	public static bool Between(IComparable value, object min, object max, bool includeMin = true, bool includeMax = true)
	{
		Guard.AssertNotNull(value, "value");
		return (value.CompareTo(min) > 0 && value.CompareTo(max) < 0) || (includeMin && value.CompareTo(min) == 0) || (includeMax && value.CompareTo(max) == 0);
	}

	/// <summary>
	/// 判断当前对象值是否介于两个对象值之间
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="value">当前对象</param>
	/// <param name="min">值范围的最小值</param>
	/// <param name="max">值范围的最大值</param>
	/// <param name="includeMin">值范围是否包含最小值，默认包含最小值</param>
	/// <param name="includeMax">值范围是否包含最大值，默认包含最大值</param>
	/// <returns>如果当前对象介于最大值和最小值之间返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者最小值为空；或者最大值为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">值范围最小值 <paramref name="min" /> 大于最大值 <paramref name="max" /></exception>
	public static bool Between<T>(IComparable<T> value, T min, T max, bool includeMin = true, bool includeMax = true) where T : IComparable<T>
	{
		Guard.AssertNotNull(value, "value");
		Guard.AssertNotNull(min, "min value");
		Guard.AssertNotNull(max, "max value");
		Guard.AssertLessThanOrEqualTo(min, max, "min & max", Literals.MSG_ValueRangeMinGreaterThanMax);
		return (value.CompareTo(min) > 0 && value.CompareTo(max) < 0) || (includeMin && value.CompareTo(min) == 0) || (includeMax && value.CompareTo(max) == 0);
	}

	/// <summary>
	/// 判断当前对象值是否不介于两个对象值之间
	/// </summary>
	/// <param name="value">当前对象</param>
	/// <param name="min">值范围的最小值</param>
	/// <param name="max">值范围的最大值</param>
	/// <param name="includeMin">值范围是否包含最小值，默认包含最小值</param>
	/// <param name="includeMax">值范围是否包含最大值，默认包含最大值</param>
	/// <returns>如果当前对象介于最大值和最小值之间返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空。</exception>
	public static bool NotBetween(IComparable value, object min, object max, bool includeMin = true, bool includeMax = true)
	{
		return !Between(value, min, max, includeMin, includeMax);
	}

	/// <summary>
	/// 判断当前对象值是否不介于两个对象值之间
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="value">当前对象</param>
	/// <param name="min">值范围的最小值</param>
	/// <param name="max">值范围的最大值</param>
	/// <param name="includeMin">值范围是否包含最小值，默认包含最小值</param>
	/// <param name="includeMax">值范围是否包含最大值，默认包含最大值</param>
	/// <returns>如果当前对象介于最大值和最小值之间返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">值范围最小值 <paramref name="min" /> 大于最大值 <paramref name="max" /></exception>
	public static bool NotBetween<T>(IComparable<T> value, T min, T max, bool includeMin = true, bool includeMax = true) where T : IComparable<T>
	{
		return !Between(value, min, max, includeMin, includeMax);
	}

	/// <summary>
	/// 创建待复制的对象的二进制副本
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="source">待复制的对象</param>
	/// <returns>复制的新对象</returns>
	/// <exception cref="T:System.ArgumentNullException">待复制的对象 <paramref name="source" /> 为空。</exception>
	public static T BinaryCopy<T>(T source)
	{
		Guard.AssertNotNull(source, "source");
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
	/// 将当前字节数组反序列化为对象
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <returns>反序列化生成的对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空。</exception>
	/// <remarks>当前字节数组应是由二进制序列化生成的。</remarks>
	/// <seealso cref="M:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter.Deserialize(System.IO.Stream)" />
	public static object BinaryDeserialize(byte[] bytes)
	{
		Guard.AssertNotNull(bytes, "bytes");
		using MemoryStream stream = new MemoryStream(bytes);
		BinaryFormatter formatter = new BinaryFormatter();
		return formatter.Deserialize(stream);
	}

	/// <summary>
	/// 将当前字节数组反序列化为对象
	/// </summary>
	/// <typeparam name="T">反序列化的目标对象类型</typeparam>
	/// <param name="bytes">当前字节数组</param>
	/// <returns>反序列化生成的对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空。</exception>
	/// <remarks>当前字节数组应是由二进制序列化生成的。</remarks>
	/// <seealso cref="M:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter.Deserialize(System.IO.Stream)" />
	public static T BinaryDeserialize<T>(byte[] bytes)
	{
		return As<T>(BinaryDeserialize(bytes));
	}

	/// <summary>
	/// 将当前字节序列反序列化为对象
	/// </summary>
	/// <param name="bytes">当前字节序列</param>
	/// <returns>反序列化生成的对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空。</exception>
	/// <remarks>当前字节数组应是由二进制序列化生成的。</remarks>
	/// <seealso cref="M:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter.Deserialize(System.IO.Stream)" />
	public static object BinaryDeserialize(IEnumerable<byte> bytes)
	{
		Guard.AssertNotNull(bytes, "bytes");
		using MemoryStream stream = new MemoryStream(1024);
		foreach (byte b in bytes)
		{
			stream.WriteByte(b);
		}
		stream.Position = 0L;
		BinaryFormatter formatter = new BinaryFormatter();
		return formatter.Deserialize(stream);
	}

	/// <summary>
	/// 将当前字节序列反序列化为对象
	/// </summary>
	/// <typeparam name="T">反序列化的目标对象类型</typeparam>
	/// <param name="bytes">当前字节序列</param>
	/// <returns>反序列化生成的对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空。</exception>
	/// <remarks>当前字节数组应是由二进制序列化生成的。</remarks>
	/// <seealso cref="M:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter.Deserialize(System.IO.Stream)" />
	public static T BinaryDeserialize<T>(IEnumerable<byte> bytes)
	{
		return As<T>(BinaryDeserialize(bytes));
	}

	/// <summary>
	/// 将当前对象序列化为二进制字节数据
	/// </summary>
	/// <param name="source">当前对象</param>
	/// <returns>当前对象序列化后的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象 <paramref name="source" /> 为空。</exception>
	public static byte[] BinarySerialize(object source)
	{
		Guard.AssertNotNull(source, "source");
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
	/// <exception cref="T:System.ArgumentNullException">当前值为空；或者最小值为空；或者最大值为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">最小值 <paramref name="min" /> 大于最大值 <paramref name="max" /></exception>
	public static T Clamp<T>(IComparable<T> value, T min, T max) where T : IComparable<T>
	{
		Guard.AssertNotNull(value, "value");
		Guard.AssertNotNull(min, "min");
		Guard.AssertNotNull(max, "max");
		if (min.CompareTo(max) > 0 || max.CompareTo(min) < 0)
		{
			throw new ArgumentOutOfRangeException("min & max", Literals.MSG_ValueRangeMinGreaterThanMax);
		}
		if (value.CompareTo(min) < 0)
		{
			return min;
		}
		if (value.CompareTo(max) > 0)
		{
			return max;
		}
		return (T)value;
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
	public static T Clamp<T>(T value, T min, T max, Func<T, T, int> comparison)
	{
		comparison = IfNull(comparison, Comparer<T>.Default.Compare);
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
	public static T Clamp<T>(T value, T min, T max, IComparer<T> comparer)
	{
		return Clamp(value, min, max, IfNull(comparer, Comparer<T>.Default).Compare);
	}

	/// <summary>
	/// 将当前对象按照指定的比较方式与目标对象进行比较，如果满足指定的比较方式的条件，返回true；如果不满足则返回false。
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="target">待比较的目标对象</param>
	/// <param name="comparison">指定的比较方式</param>
	/// <returns>如果当前对象满足比较方式指定的条件返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空。</exception>
	public static bool CompareTo(IComparable item, object target, ComparisonMode comparison)
	{
		Guard.AssertNotNull(item, "item");
		int result = item.CompareTo(target);
		bool flag = false;
		if (!flag && comparison.HasFlag(ComparisonMode.Equal))
		{
			flag = result == 0;
		}
		if (!flag && comparison.HasFlag(ComparisonMode.GreaterThan))
		{
			flag = result > 0;
		}
		if (!flag && comparison.HasFlag(ComparisonMode.LessThan))
		{
			flag = result < 0;
		}
		Guard.AssertTrue(flag, "comparsion");
		if (comparison.HasFlag(ComparisonMode.Not))
		{
			flag = !flag;
		}
		return flag;
	}

	/// <summary>
	/// 将当前对象按照指定的比较方式与目标对象进行比较，如果满足指定的比较方式的条件，返回true；如果不满足则返回false。
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="target">待比较的目标对象</param>
	/// <param name="comparison">指定的比较方式</param>
	/// <returns>如果当前对象满足比较方式指定的条件返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空。</exception>
	public static bool CompareTo<T>(IComparable<T> item, T target, ComparisonMode comparison) where T : IComparable<T>
	{
		Guard.AssertNotNull(item, "item");
		int result = item.CompareTo(target);
		bool flag = false;
		if (!flag && comparison.HasFlag(ComparisonMode.Equal))
		{
			flag = result == 0;
		}
		if (!flag && comparison.HasFlag(ComparisonMode.GreaterThan))
		{
			flag = result > 0;
		}
		if (!flag && comparison.HasFlag(ComparisonMode.LessThan))
		{
			flag = result < 0;
		}
		Guard.AssertTrue(flag, "comparsion");
		if (comparison.HasFlag(ComparisonMode.Not))
		{
			flag = !flag;
		}
		return flag;
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
	public static bool CompareTo<T>(T value, T target, ComparisonMode mode, IComparer<T> comparer)
	{
		comparer = IfNull(comparer, Comparer<T>.Default);
		return CompareTo(value, target, mode, comparer.Compare);
	}

	/// <summary>
	/// 将当前对象按照指定的比较方式与目标对象进行比较，如果满足指定的比较方式的条件，返回true；如果不满足则返回false。
	/// </summary>
	/// <typeparam name="T">比较的对象类型</typeparam>
	/// <param name="value">当前待比较的对象</param>
	/// <param name="target">待比较的目标对象</param>
	/// <param name="mode">指定的比较方式</param>
	/// <param name="comparison">对象比较方法</param>
	/// <returns>如果满足比较方式指定的条件返回true，否则返回false。</returns>
	public static bool CompareTo<T>(T value, T target, ComparisonMode mode, Func<T, T, int> comparison)
	{
		comparison = IfNull(comparison, Comparer<T>.Default.Compare);
		int result = comparison(value, target);
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
		Guard.AssertTrue(flag, "comparsion");
		if (mode.HasFlag(ComparisonMode.Not))
		{
			flag = !flag;
		}
		return flag;
	}

	/// <summary>
	/// 深度复制当前对象，返回复制后的对象
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="source">待复制的当前对象</param>
	/// <returns>复制的新对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象 <paramref name="source" /> 为空。</exception>
	public static T DeepCopy<T>(T source)
	{
		return BinaryCopy(source);
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
	public static IEnumerable<T> Enumerate<T>(T obj, Func<T, IEnumerable<T>> selector, Func<T, bool> predicate = null)
	{
		Guard.AssertNotNull(obj, "obj");
		Guard.AssertNotNull(selector, "selector");
		predicate = IfNull(predicate, (T x) => true);
		return RH((Func<T, IEnumerable<T>> f) => (T s) => selector(obj).Where(predicate).Concat(selector(obj).Where(predicate).SelectMany(f)))(obj);
	}

	/// <summary>
	/// 将当前对象格式化为字符串
	/// </summary>
	/// <param name="obj">当前对象</param>
	/// <param name="format">格式化字符串</param>
	/// <param name="provider">格式化</param>
	/// <returns>格式化后的对象字符串表示；如果当前对象为空，则返回 <see cref="F:System.String.Empty" />；如果格式化字符串为空，则返回当前对象的 <see cref="M:System.Object.ToString" /> 返回值。</returns>
	public static string FormatWith(object obj, string format, IFormatProvider provider = null)
	{
		if (IsNull(obj))
		{
			return string.Empty;
		}
		if (string.IsNullOrEmpty(format))
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
	public static string FormatWith<T>(T obj, Func<T, string> formatting)
	{
		formatting = IfNull(formatting, (T x) => x.ToString());
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
	public static PropertyInfo GetProperty(object item, string propertyPath, out object owner, bool ignoreCase = false)
	{
		return GetProperty(item, propertyPath, (Type t, string n) => TypeHelper.GetProperty(t, n, ignoreCase), out owner);
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
	public static PropertyInfo GetProperty(object item, string propertyPath, BindingFlags flags, out object owner, bool ignoreCase = false)
	{
		return GetProperty(item, propertyPath, (Type t, string n) => TypeHelper.GetProperty(t, n, flags, ignoreCase), out owner);
	}

	private static PropertyInfo GetProperty(object item, string propertyPath, Func<Type, string, PropertyInfo> getter, out object owner)
	{
		Guard.AssertNotNull(item, "item");
		Guard.AssertNotNullAndEmpty(propertyPath, "Property Path");
		owner = null;
		string[] propertyNames = propertyPath.Split(new char[1] { '.' }, StringSplitOptions.None);
		object handler = item;
		PropertyInfo property = null;
		string[] array = propertyNames;
		foreach (string propertyName in array)
		{
			if (IsNull(handler))
			{
				owner = null;
				return null;
			}
			property = getter(handler.GetType(), propertyName);
			if (IsNull(property))
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
	public static object GetPropertyValue(object item, string propertyPath, bool ignoreCase = false)
	{
		Guard.AssertNotNull(item, "item");
		Guard.AssertNotNullAndEmpty(propertyPath, "Property Path");
		object owner = null;
		PropertyInfo pinfo = GetProperty(item, propertyPath, out owner, ignoreCase);
		if (IsNotNull(pinfo))
		{
			Guard.Assert(pinfo.CanRead, () => new TargetException(Literals.MSG_ObjectPropertyUnreadable));
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
	public static object GetPropertyValue(object item, string propertyPath, object defaultValue, bool ignoreCase = false)
	{
		Guard.AssertNotNull(item, "item");
		Guard.AssertNotNullAndEmpty(propertyPath, "Property Path");
		object owner = null;
		PropertyInfo pinfo = GetProperty(item, propertyPath, out owner, ignoreCase);
		if (IsNotNull(pinfo))
		{
			Guard.Assert(pinfo.CanRead, () => new TargetException(Literals.MSG_ObjectPropertyUnreadable));
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
	public static object GetPropertyValue(object item, string propertyPath, BindingFlags flags, bool ignoreCase = false)
	{
		Guard.AssertNotNull(item, "item");
		Guard.AssertNotNullAndEmpty(propertyPath, "Property Path");
		object owner = null;
		PropertyInfo pinfo = GetProperty(item, propertyPath, flags, out owner, ignoreCase);
		if (IsNotNull(pinfo))
		{
			Guard.Assert(pinfo.CanRead, () => new TargetException(Literals.MSG_ObjectPropertyUnreadable));
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
	public static object GetPropertyValue(object item, string propertyPath, BindingFlags flags, object defaultValue, bool ignoreCase = false)
	{
		Guard.AssertNotNull(item, "item");
		Guard.AssertNotNullAndEmpty(propertyPath, "Property Path");
		object owner = null;
		PropertyInfo pinfo = GetProperty(item, propertyPath, flags, out owner, ignoreCase);
		if (IsNotNull(pinfo))
		{
			Guard.Assert(pinfo.CanRead, () => new TargetException(Literals.MSG_ObjectPropertyUnreadable));
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
	public static T GetPropertyValue<T>(object item, string propertyPath, bool ignoreCase = false)
	{
		return ConvertHelper.Cast<T>(GetPropertyValue(item, propertyPath, ignoreCase));
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
	public static T GetPropertyValue<T>(object item, string propertyPath, T defaultValue, bool ignoreCase = false)
	{
		return ConvertHelper.Cast<T>(GetPropertyValue(item, propertyPath, defaultValue, ignoreCase));
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
	public static T GetPropertyValue<T>(object item, string propertyPath, BindingFlags flags, bool ignoreCase = false)
	{
		return ConvertHelper.Cast<T>(GetPropertyValue(item, propertyPath, flags, ignoreCase));
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
	public static T GetPropertyValue<T>(object item, string propertyPath, BindingFlags flags, T defaultValue, bool ignoreCase = false)
	{
		return ConvertHelper.Cast<T>(GetPropertyValue(item, propertyPath, flags, defaultValue, ignoreCase));
	}

	/// <summary>
	/// 检测当前对象是否实现了指定的接口
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="interfaceType">检测的接口类型</param>
	/// <returns>如果当前对象实现了指定的接口则返回true，否则返回false。如果当前对象等于null，则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="interfaceType" /> 为空。</exception>
	public static bool HasInterface(object item, Type interfaceType)
	{
		Guard.AssertNotNull(interfaceType, "Interface Type");
		return IsNotNull(item) && TypeHelper.HasInterface(item.GetType(), interfaceType);
	}

	/// <summary>
	/// 检测当前对象是否实现了指定的接口
	/// </summary>
	/// <typeparam name="T">指定接口类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <returns>如果当前对象实现了指定的接口则返回true，否则返回false。如果当前对象等于null，则返回false。</returns>
	public static bool HasInterface<T>(object item)
	{
		return IsNotNull(item) && TypeHelper.HasInterface<T>(item.GetType());
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
	public static T If<T>(T item, Func<T, bool> predicate, T value)
	{
		Guard.AssertNotNull(predicate, "predicate");
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
	public static T If<T>(T item, Func<T, bool> predicate, T trueValue, T falseValue)
	{
		Guard.AssertNotNull(predicate, "predicate");
		return predicate(item) ? trueValue : falseValue;
	}

	/// <summary>
	/// 如果当前对象满足指定的断言 <paramref name="predicate" />，则返回 <paramref name="value" /> 的值，否则返回对象本身
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <typeparam name="R">结果对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="predicate">检测断言</param>
	/// <param name="value">指定值</param>
	/// <returns>如果对象满足指定的断言检测，则返回 <paramref name="value" /> 的值，否则返回对象本身</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="predicate" /> 为空。</exception>
	public static R IfThen<T, R>(T item, Func<T, bool> predicate, R value)
	{
		Guard.AssertNotNull(predicate, "predicate");
		return predicate(item) ? value : As<R>(item);
	}

	/// <summary>
	/// 如果当前对象满足指定的断言 <paramref name="predicate" />，则返回 <paramref name="trueValue" /> 的值，否则返回 <paramref name="falseValue" /> 的值
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <typeparam name="R">结果对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="predicate">检测断言</param>
	/// <param name="trueValue">当前检测条件为true时返回这个值</param>
	/// <param name="falseValue">当检测条件为false是返回这个值</param>
	/// <returns>如果对象满足指定的断言检测，返回 <paramref name="trueValue" /> 的值，否则返回 <paramref name="falseValue" /> 的值</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="predicate" /> 为空。</exception>
	public static R IfThen<T, R>(T item, Func<T, bool> predicate, R trueValue, R falseValue)
	{
		Guard.AssertNotNull(predicate, "predicate");
		return predicate(item) ? As<R>(trueValue) : As<R>(falseValue);
	}

	/// <summary>
	/// 如果当前对象为空，则返回 <paramref name="result" />，否则返回对象本身
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="result">替代值</param>
	/// <returns>处理结果</returns>
	public static T IfNull<T>(T item, T result)
	{
		return IsNull(item) ? result : item;
	}

	/// <summary>
	/// 如果当前对象为空，则返回 <paramref name="result" />，否则返回对象本身
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <typeparam name="R">结果对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="result">替代值</param>
	/// <returns>处理结果</returns>
	public static R IfNullThen<T, R>(T item, R result)
	{
		return IsNull(item) ? result : As<R>(item);
	}

	/// <summary>
	/// 如果对象不为空，则返回 <paramref name="result" /> 的值，否则返回结果类型 <typeparamref name="T" /> 的类型默认值
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="result">替代值</param>
	/// <returns>处理结果</returns>
	public static T IfNotNull<T>(T item, T result)
	{
		return IsNotNull(item) ? result : item;
	}

	/// <summary>
	/// 如果对象不为空，则返回 <paramref name="result" /> 的值，否则返回结果类型 <typeparamref name="T" /> 的类型默认值
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <typeparam name="R">结果对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="result">替代值</param>
	/// <returns>处理结果</returns>
	public static R IfNotNullThen<T, R>(T item, R result)
	{
		return IsNotNull(item) ? result : As<R>(item);
	}

	/// <summary>
	/// 如果当前对象为空或者为DBNull，返回 <paramref name="result" /> 的值，否则返回对象本身
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="result">替代值</param>
	/// <returns>处理结果</returns>
	public static T IfNullOrDBNull<T>(T item, T result)
	{
		return IsNullOrDBNull(item) ? result : item;
	}

	/// <summary>
	/// 如果当前对象为空或者为DBNull，返回 <paramref name="result" /> 的值，否则返回对象本身
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <typeparam name="R">结果对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="result">替代值</param>
	/// <returns>处理结果</returns>
	public static R IfNullOrDBNullThen<T, R>(T item, R result)
	{
		return IsNullOrDBNull(item) ? result : As<R>(item);
	}

	/// <summary>
	/// 如果当前对象不是null或者DBNull，返回 <paramref name="result" /> 的值，否则返回对象本身
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="result">替代值</param>
	/// <returns>处理结果</returns>
	public static T IfNotNullAndDBNull<T>(T item, T result)
	{
		return IsNotNullAndDBNull(item) ? result : item;
	}

	/// <summary>
	/// 如果当前对象不是null或者DBNull，返回 <paramref name="result" /> 的值，否则返回对象本身
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <typeparam name="R">结果对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="result">替代值</param>
	/// <returns>处理结果</returns>
	public static R IfNotNullAndDBNullThen<T, R>(T item, R result)
	{
		return IsNotNullAndDBNull(item) ? result : As<R>(item);
	}

	/// <summary>
	/// 检测当前对象是否存在于给定的值列表中
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="values">给定的值列表</param>
	/// <returns>如果当前对象存在于值列表中返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">值列表 <paramref name="values" /> 为空。</exception>
	public static bool In(object item, params object[] values)
	{
		return In(item, (IEnumerable)values);
	}

	/// <summary>
	/// 检测当前对象是否存在于给定的值列表中
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="values">给定的值列表</param>
	/// <returns>如果当前对象存在于值列表中返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">值列表 <paramref name="values" /> 为空。</exception>
	public static bool In(object item, IEnumerable values)
	{
		Guard.AssertNotNull(values, "Values");
		foreach (object value in values)
		{
			if (IsEqualTo(item, value))
			{
				return true;
			}
		}
		return false;
	}

	/// <summary>
	/// 检测当前对象是否存在于给定的值列表中
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="values">给定的值列表</param>
	/// <returns>如果当前对象存在于值列表中返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">值列表 <paramref name="values" /> 为空。</exception>
	public static bool In<T>(T item, params T[] values)
	{
		return In(item, (IEnumerable<T>)values);
	}

	/// <summary>
	/// 检测当前对象是否存在于给定的值列表中
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="values">给定的值列表</param>
	/// <returns>如果当前对象存在于值列表中返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">值列表 <paramref name="values" /> 为空。</exception>
	public static bool In<T>(T item, IEnumerable<T> values)
	{
		Guard.AssertNotNull(values, "Values");
		foreach (T value in values)
		{
			if (IsEqualTo(item, value))
			{
				return true;
			}
		}
		return false;
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
	public static bool In<T>(T item, IEnumerable<T> values, IEqualityComparer<T> equaliter)
	{
		Guard.AssertNotNull(values, "Values");
		foreach (T value in values)
		{
			if (IsEqualTo(item, value, equaliter))
			{
				return true;
			}
		}
		return false;
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
	public static bool In<T>(T item, IEnumerable<T> values, Func<T, T, bool> equalition)
	{
		Guard.AssertNotNull(values, "Values");
		foreach (T value in values)
		{
			if (IsEqualTo(item, value, equalition))
			{
				return true;
			}
		}
		return false;
	}

	/// <summary>
	/// 检测当前对象是不否存在于给定的值列表中
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="values">给定的值列表</param>
	/// <returns>如果当前对象不存在于值列表中返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">值列表 <paramref name="values" /> 为空。</exception>
	public static bool NotIn(object item, params object[] values)
	{
		return !In(item, values);
	}

	/// <summary>
	/// 检测当前对象是否不存在于给定的值列表中
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="values">给定的值列表</param>
	/// <returns>如果当前对象不存在于值列表中返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">值列表 <paramref name="values" /> 为空。</exception>
	public static bool NotIn(object item, IEnumerable values)
	{
		return !In(item, values);
	}

	/// <summary>
	/// 检测当前对象是不否存在于给定的值列表中
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="values">给定的值列表</param>
	/// <returns>如果当前对象不存在于值列表中返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">值列表 <paramref name="values" /> 为空。</exception>
	public static bool NotIn<T>(T item, params T[] values)
	{
		return !In(item, values);
	}

	/// <summary>
	/// 检测当前对象是否不存在于给定的值列表中
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="values">给定的值列表</param>
	/// <returns>如果当前对象不存在于值列表中返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">值列表 <paramref name="values" /> 为空。</exception>
	public static bool NotIn<T>(T item, IEnumerable<T> values)
	{
		return !In(item, values);
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
	public static bool NotIn<T>(T item, IEnumerable<T> values, IEqualityComparer<T> equaliter)
	{
		return !In(item, values, equaliter);
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
	public static bool NotIn<T>(T item, IEnumerable<T> values, Func<T, T, bool> equalition)
	{
		return !In(item, values, equalition);
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
	public static object InvokeMethod(object obj, string methodName, params object[] args)
	{
		Guard.AssertNotNull(obj, "item");
		return TypeHelper.InvokeMethod(obj.GetType(), methodName, obj, args);
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
	public static object InvokeMethod(object obj, string methodName, object[] args, bool ignoreCase = false, bool optionalBinding = false)
	{
		Guard.AssertNotNull(obj, "item");
		return TypeHelper.InvokeMethod(obj.GetType(), methodName, obj, args, ignoreCase, optionalBinding);
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
	public static object InvokeMethod(object obj, string methodName, object[] args, BindingFlags flags, bool ignoreCase = false, bool optionalBinding = false)
	{
		Guard.AssertNotNull(obj, "item");
		return TypeHelper.InvokeMethod(obj.GetType(), methodName, obj, args, flags, ignoreCase, optionalBinding);
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
	public static object InvokeMethod(object obj, string methodName, NamedValue[] namedArgs, bool ignoreCase = false, bool optionalBinding = false)
	{
		Guard.AssertNotNull(obj, "item");
		return TypeHelper.InvokeMethod(obj.GetType(), methodName, obj, namedArgs, ignoreCase, optionalBinding);
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
	public static object InvokeMethod(object obj, string methodName, NamedValue[] namedArgs, BindingFlags flags, bool ignoreCase = false, bool optionalBinding = false)
	{
		Guard.AssertNotNull(obj, "item");
		return TypeHelper.InvokeMethod(obj.GetType(), methodName, obj, namedArgs, flags, ignoreCase, optionalBinding);
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
	public static object InvokeMethod(object obj, string methodName, IDictionary<string, object> namedArgs, bool ignoreCase = false, bool optionalBinding = false)
	{
		Guard.AssertNotNull(obj, "item");
		return TypeHelper.InvokeMethod(obj.GetType(), methodName, obj, namedArgs, ignoreCase, optionalBinding);
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
	public static object InvokeMethod(object obj, string methodName, IDictionary<string, object> namedArgs, BindingFlags flags, bool ignoreCase = false, bool optionalBinding = false)
	{
		Guard.AssertNotNull(obj, "item");
		return TypeHelper.InvokeMethod(obj.GetType(), methodName, obj, namedArgs, flags, ignoreCase, optionalBinding);
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
	public static object InvokeMethod(object obj, string methodName, string[] names, object[] values, bool ignoreCase = false, bool optionalBinding = false)
	{
		Guard.AssertNotNull(obj, "item");
		return TypeHelper.InvokeMethod(obj.GetType(), methodName, obj, names, values, ignoreCase, optionalBinding);
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
	public static object InvokeMethod(object obj, string methodName, string[] names, object[] values, BindingFlags flags, bool ignoreCase = false, bool optionalBinding = false)
	{
		Guard.AssertNotNull(obj, "item");
		return TypeHelper.InvokeMethod(obj.GetType(), methodName, obj, names, values, flags, ignoreCase, optionalBinding);
	}

	/// <summary>
	/// 检测对象是否是数组类型
	/// </summary>
	/// <param name="item">待检测的对象</param>
	/// <returns>如果待检测的对象是数组类型则返回true，否则返回false。如果待检测的对象为空，则返回false。</returns>
	public static bool IsArray(object item)
	{
		return IsNotNull(item) && (item.GetType().IsArray || typeof(Array).IsAssignableFrom(item.GetType()));
	}

	/// <summary>
	/// 检测对象是否不是数组类型
	/// </summary>
	/// <param name="item">待检测的对象</param>
	/// <returns>如果待检测的对象不是数组类型则返回true，否则返回false。如果待检测的对象为空，则返回true。</returns>
	public static bool IsNotArray(object item)
	{
		return !IsArray(item);
	}

	/// <summary>
	/// 检测对象是否是 <see cref="T:System.DBNull" />。
	/// </summary>
	/// <param name="item">待检测的对象</param>
	/// <returns>如果是 <see cref="T:System.DBNull" /> 则返回true，否则返回false；如果对象为空也返回false。</returns>
	/// <remarks>空（null）和 <see cref="T:System.DBNull" /> 是两个不同的值。如果对象为空，则本方法返回false。本方法使用 <see cref="M:System.Convert.IsDBNull(System.Object)" /> 检测对象值。</remarks>
	public static bool IsDBNull(object item)
	{
		return IsNotNull(item) && Convert.IsDBNull(item);
	}

	/// <summary>
	/// 检测对象是否不是 <see cref="T:System.DBNull" />。
	/// </summary>
	/// <param name="item">待检测的对象</param>
	/// <returns>如果不是 <see cref="T:System.DBNull" /> 则返回true，否则返回false；如果对象为空返回true。</returns>
	/// <remarks>空（null）和 <see cref="T:System.DBNull" /> 是两个不同的值。如果对象为空，则本方法返回false。本方法使用 <see cref="M:System.Convert.IsDBNull(System.Object)" /> 检测对象值。</remarks>
	public static bool IsNotDBNull(object item)
	{
		return IsNull(item) || !Convert.IsDBNull(item);
	}

	/// <summary>
	/// 检测对象是否是指定类型的默认值
	/// </summary>
	/// <param name="item">待检测的对象</param>
	/// <param name="type">待检测的对象类型</param>
	/// <returns>如果待检测的对象等于指定类型的默认值返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">待检测的对象为空时，对象类型 <paramref name="type" /> 为空。</exception>
	public static bool IsDefault(object item, Type type)
	{
		if (IsNull(item))
		{
			Guard.AssertNotNull(type, "type");
		}
		else if (IsNull(type))
		{
			type = item.GetType();
		}
		else
		{
			Guard.AssertInstanceOfType(item, type, "item");
		}
		if (type.IsValueType)
		{
			if (TypeHelper.IsNullableValueType(type))
			{
				return IsNull(item);
			}
			return IsNotNull(item) && item.Equals(Activator.CreateInstance(type));
		}
		return IsNull(item);
	}

	/// <summary>
	/// 检测待检测的对象是否是其类型的默认值
	/// </summary>
	/// <typeparam name="T">待检测的对象类型</typeparam>
	/// <param name="item">待检测的对象</param>
	/// <returns>如果待检测的对象等于其类型默认值返回true，否则返回false。</returns>
	public static bool IsDefault<T>(T item)
	{
		return IsDefault(item, typeof(T));
	}

	/// <summary>
	/// 检测待检测的对象是否是其类型的默认值
	/// </summary>
	/// <typeparam name="T">待检测的对象类型</typeparam>
	/// <param name="item">待检测的对象</param>
	/// <param name="equaliter">对象相等比较器</param>
	/// <returns>如果待检测的对象等于其类型默认值返回true，否则返回false。</returns>
	public static bool IsDefault<T>(T item, IEqualityComparer<T> equaliter)
	{
		return IfNull(equaliter, EqualityComparer<T>.Default).Equals(item, default(T));
	}

	/// <summary>
	/// 检测待检测的对象是否是其类型的默认值
	/// </summary>
	/// <typeparam name="T">待检测的对象类型</typeparam>
	/// <param name="item">待检测的对象</param>
	/// <param name="equalition">对象相等比较方法</param>
	/// <returns>如果待检测的对象等于其类型默认值返回true，否则返回false。</returns>
	public static bool IsDefault<T>(T item, Func<T, T, bool> equalition)
	{
		return IfNull(equalition, EqualityComparer<T>.Default.Equals)(item, default(T));
	}

	/// <summary>
	/// 检测待检测的对象是否不是指定类型的默认值
	/// </summary>
	/// <param name="item">待检测的对象</param>
	/// <param name="type">待检测的对象类型</param>
	/// <returns>如果待检测的对象不等于指定类型的默认值返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">待检测的对象为空时，对象类型 <paramref name="type" /> 为空。</exception>
	public static bool IsNotDefault(object item, Type type)
	{
		return !IsDefault(item, type);
	}

	/// <summary>
	/// 检测待检测的对象是否不是其类型的默认值
	/// </summary>
	/// <typeparam name="T">待检测的对象类型</typeparam>
	/// <param name="item">待检测的对象</param>
	/// <returns>如果待检测的对象不等于其类型默认值返回true，否则返回false。</returns>
	public static bool IsNotDefault<T>(T item)
	{
		return !IsDefault(item);
	}

	/// <summary>
	/// 检测待检测的对象是否不是其类型的默认值
	/// </summary>
	/// <typeparam name="T">待检测的对象类型</typeparam>
	/// <param name="item">待检测的对象</param>
	/// <param name="equaliter">对象相等比较器</param>
	/// <returns>如果待检测的对象不等于其类型默认值返回true，否则返回false。</returns>
	public static bool IsNotDefault<T>(T item, IEqualityComparer<T> equaliter)
	{
		return !IsDefault(item, equaliter);
	}

	/// <summary>
	/// 检测待检测的对象是否不是其类型的默认值
	/// </summary>
	/// <typeparam name="T">待检测的对象类型</typeparam>
	/// <param name="item">待检测的对象</param>
	/// <param name="equalition">对象相等比较方法</param>
	/// <returns>如果待检测的对象不等于其类型默认值返回true，否则返回false。</returns>
	public static bool IsNotDefault<T>(T item, Func<T, T, bool> equalition)
	{
		return !IsDefault(item, equalition);
	}

	/// <summary>
	/// 检测待检测的对象是否等于目标对象
	/// </summary>
	/// <param name="item">待检测的对象</param>
	/// <param name="target">比较目标对象</param>
	/// <returns>如果两个对象值相等返回true，否则返回false</returns>
	public static bool IsEqualTo(object item, object target)
	{
		if (item is IComparable)
		{
			Guard.AssertNotNull(item, "item");
			return ((IComparable)item).CompareTo(target) == 0;
		}
		return ObjectEquals(item, target);
	}

	/// <summary>
	/// 检测待检测的对象是否等于 <paramref name="target" /> 的值
	/// </summary>
	/// <typeparam name="T">待检测的对象类型</typeparam>
	/// <param name="item">待检测的对象</param>
	/// <param name="target">比较目标对象</param>
	/// <returns>如果待检测的对象等于 <paramref name="target" /> 的值返回true，否则返回false</returns>
	public static bool IsEqualTo<T>(T item, T target)
	{
		if (item is IComparable)
		{
			Guard.AssertNotNull(item, "item");
			return ((IComparable)(object)item).CompareTo(target) == 0;
		}
		if (item is IComparable<T>)
		{
			Guard.AssertNotNull(item, "item");
			return ((IComparable<T>)(object)item).CompareTo(target) == 0;
		}
		return IsEqualTo((object)item, (object)target);
	}

	/// <summary>
	/// 检测待检测的对象是否等于 <paramref name="target" /> 的值
	/// </summary>
	/// <typeparam name="T">待检测的对象类型</typeparam>
	/// <param name="item">待检测的对象</param>
	/// <param name="target">比较目标对象</param>
	/// <param name="equaliter">对象相等比较器</param>
	/// <returns>如果待检测的对象等于 <paramref name="target" /> 的值返回true，否则返回false</returns>
	public static bool IsEqualTo<T>(T item, T target, IEqualityComparer<T> equaliter)
	{
		if (IsNull(equaliter))
		{
			return IsEqualTo(item, target);
		}
		return equaliter.Equals(item, target);
	}

	/// <summary>
	/// 检测待检测的对象是否等于 <paramref name="target" /> 的值
	/// </summary>
	/// <typeparam name="S">待检测的对象类型</typeparam>
	/// <typeparam name="T">比较的目标对象类型</typeparam>
	/// <param name="item">待检测的对象</param>
	/// <param name="target">比较目标对象</param>
	/// <param name="equalition">对象相等比较方法</param>
	/// <returns>如果两个对象值相等返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="equalition" /> 为空。</exception>
	public static bool IsEqualTo<S, T>(S item, T target, Func<S, T, bool> equalition)
	{
		if (typeof(S) == typeof(T))
		{
			if (IsNull(equalition))
			{
				return IsEqualTo(item, (S)(object)target);
			}
			return equalition(item, target);
		}
		Guard.AssertNotNull(equalition, "equalition");
		return equalition(item, target);
	}

	/// <summary>
	/// 检测待检测的对象是否不等于目标对象
	/// </summary>
	/// <param name="item">待检测的对象</param>
	/// <param name="target">目标对象</param>
	/// <returns>如果两个对象值不相等返回true，否则返回false</returns>
	public static bool IsNotEqualTo(object item, object target)
	{
		return !IsEqualTo(item, target);
	}

	/// <summary>
	/// 检测待检测的对象是否不等于 <paramref name="value" /> 的值
	/// </summary>
	/// <typeparam name="T">待检测的对象类型</typeparam>
	/// <param name="item">待检测的对象</param>
	/// <param name="value">检测的基准值</param>
	/// <returns>如果待检测的对象不等于 <paramref name="value" /> 的值返回true，否则返回false</returns>
	public static bool IsNotEqualTo<T>(T item, T value)
	{
		return !IsEqualTo(item, value);
	}

	/// <summary>
	/// 检测待检测的对象是否不等于 <paramref name="value" /> 的值
	/// </summary>
	/// <typeparam name="T">待检测的对象类型</typeparam>
	/// <param name="item">待检测的对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="equaliter">对象相等比较器</param>
	/// <returns>如果待检测的对象不等于 <paramref name="value" /> 的值返回true，否则返回false</returns>
	public static bool IsNotEqualTo<T>(T item, T value, IEqualityComparer<T> equaliter)
	{
		return !IsEqualTo(item, value, equaliter);
	}

	/// <summary>
	/// 检测待检测的对象是否不等于 <paramref name="target" /> 的值
	/// </summary>
	/// <typeparam name="S">待检测的对象类型</typeparam>
	/// <typeparam name="T">比较的目标对象类型</typeparam>
	/// <param name="item">待检测的对象</param>
	/// <param name="target">比较目标对象</param>
	/// <param name="equalition">对象相等比较方法</param>
	/// <returns>如果两个对象值不相等返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="equalition" /> 为空。</exception>
	public static bool IsNotEqualTo<S, T>(S item, T target, Func<S, T, bool> equalition)
	{
		return !IsEqualTo(item, target, equalition);
	}

	/// <summary>
	/// 检测当前对象是否大于 <paramref name="value" /> 的值
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <returns>如果当前对象大于 <paramref name="value" /> 的值返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空。</exception>
	public static bool IsGreaterThan(IComparable item, object value)
	{
		Guard.AssertNotNull(item, "item");
		return item.CompareTo(value) > 0;
	}

	/// <summary>
	/// 检测当前对象是否大于 <paramref name="value" /> 的值
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <returns>如果当前对象大于 <paramref name="value" /> 的值返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空。</exception>
	public static bool IsGreaterThan<T>(IComparable<T> item, T value) where T : IComparable<T>
	{
		Guard.AssertNotNull(item, "item");
		return item.CompareTo(value) > 0;
	}

	/// <summary>
	/// 检测当前对象是否大于等于 <paramref name="value" /> 的值
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <returns>如果当前对象大于等于 <paramref name="value" /> 的值返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空。</exception>
	public static bool IsGreaterThanOrEqualTo(IComparable item, object value)
	{
		Guard.AssertNotNull(item, "item");
		return item.CompareTo(value) >= 0;
	}

	/// <summary>
	/// 检测当前对象是否大于等于 <paramref name="value" /> 的值
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <returns>如果当前对象大于等于 <paramref name="value" /> 的值返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空。</exception>
	public static bool IsGreaterThanOrEqualTo<T>(IComparable<T> item, T value) where T : IComparable<T>
	{
		Guard.AssertNotNull(item, "item");
		return item.CompareTo(value) >= 0;
	}

	/// <summary>
	/// 检测待检测的对象是否是指定类型的实例
	/// </summary>
	/// <param name="item">待检测的对象</param>
	/// <param name="type">指定的目标类型</param>
	/// <returns>如果待检测的对象是指定类型的实例则返回true，否则返回false。如果待检测的对象为空，则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="type" /> 为空。</exception>
	public static bool IsInstanceOf(object item, Type type)
	{
		Guard.AssertNotNull(type, "Instance Type");
		if (TypeHelper.IsNullableValueType(type))
		{
			return IsInstanceOf(item, TypeHelper.GetGenericArgument(type));
		}
		return IsNotNull(item) && type.IsInstanceOfType(item);
	}

	/// <summary>
	/// 检测待检测的对象是否是指定类型的实例
	/// </summary>
	/// <typeparam name="T">指定的目标类型</typeparam>
	/// <param name="item">待检测的对象</param>
	/// <returns>如果待检测的对象是指定类型的实例则返回true，否则返回false。如果待检测的对象为空，则返回false。</returns>
	public static bool IsInstanceOf<T>(object item)
	{
		if (TypeHelper.IsNullableValueType(typeof(T)))
		{
			return IsInstanceOf(item, TypeHelper.GetGenericArgument(typeof(T)));
		}
		return IsNotNull(item) && typeof(T).IsInstanceOfType(item);
	}

	/// <summary>
	/// 检测当前对象是否小于 <paramref name="value" /> 的值
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <returns>如果当前对象小于 <paramref name="value" /> 的值返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空。</exception>
	public static bool IsLessThan(IComparable item, object value)
	{
		Guard.AssertNotNull(item, "item");
		return item.CompareTo(value) < 0;
	}

	/// <summary>
	/// 检测当前对象是否小于 <paramref name="value" /> 的值
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <returns>如果当前对象小于 <paramref name="value" /> 的值返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空。</exception>
	public static bool IsLessThan<T>(IComparable<T> item, T value) where T : IComparable<T>
	{
		Guard.AssertNotNull(item, "item");
		return item.CompareTo(value) < 0;
	}

	/// <summary>
	/// 检测当前对象是否小于等于 <paramref name="value" /> 的值
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <returns>如果当前对象小于等于 <paramref name="value" /> 的值返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空。</exception>
	public static bool IsLessThanOrEqualTo(IComparable item, object value)
	{
		Guard.AssertNotNull(item, "item");
		return item.CompareTo(value) <= 0;
	}

	/// <summary>
	/// 检测当前对象是否小于等于 <paramref name="value" /> 的值
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <returns>如果当前对象小于等于 <paramref name="value" /> 的值返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空。</exception>
	public static bool IsLessThanOrEqualTo<T>(IComparable<T> item, T value) where T : IComparable<T>
	{
		Guard.AssertNotNull(item, "item");
		return item.CompareTo(value) <= 0;
	}

	/// <summary>
	/// 检测待检测的对象是否为空（null）
	/// </summary>
	/// <param name="item">待检测对象</param>
	/// <returns>如果为空返回true，否则返回false</returns>
	public static bool IsNull(object item)
	{
		return object.ReferenceEquals(item, null);
	}

	/// <summary>
	/// 检测待检测的对象是否不为空（null）
	/// </summary>
	/// <param name="item">待检测对象</param>
	/// <returns>如果不为空返回true，否则返回false</returns>
	public static bool IsNotNull(object item)
	{
		return !object.ReferenceEquals(item, null);
	}

	/// <summary>
	/// 检测待检测的对象是否为空或者 <see cref="T:System.DBNull" />
	/// </summary>
	/// <param name="item">待检测对象</param>
	/// <returns>如果待检测的对象为空或者是 <see cref="T:System.DBNull" /> 则返回true，否则返回false。</returns>
	public static bool IsNullOrDBNull(object item)
	{
		return IsNull(item) || IsDBNull(item);
	}

	/// <summary>
	/// 检测待检测对象是否不为空（null）且不为 <see cref="T:System.DBNull" />
	/// </summary>
	/// <param name="item">待检测对象</param>
	/// <returns>如果待检测对象不为空或者是 <see cref="T:System.DBNull" /> 则返回true，否则返回false。</returns>
	public static bool IsNotNullAndDBNull(object item)
	{
		return IsNotNull(item) && !IsDBNull(item);
	}

	/// <summary>
	/// 检测待检测对象是否为空（null）或者等于指定类型的默认值
	/// </summary>
	/// <param name="item">待检测对象</param>
	/// <param name="type">默认值的类型</param>
	/// <returns>如果待检测对象为空（null）或者等于指定类型的默认值返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">待检测对象为空时，对象类型 <paramref name="type" /> 为空。</exception>
	public static bool IsNullOrDefault(object item, Type type)
	{
		return IsNull(item) || IsDefault(item, type);
	}

	/// <summary>
	/// 检测待检测对象是否为空（null）或者等于指定类型的默认值
	/// </summary>
	/// <typeparam name="T">默认值的类型</typeparam>
	/// <param name="item">待检测对象</param>
	/// <returns>如果待检测对象为空（null）或者等于指定类型的默认值返回true，否则返回false</returns>
	public static bool IsNullOrDefault<T>(T item)
	{
		return IsNull(item) || IsDefault(item);
	}

	/// <summary>
	/// 检测待检测对象是否为空（null）或者等于指定类型的默认值
	/// </summary>
	/// <typeparam name="T">默认值的类型</typeparam>
	/// <param name="item">待检测对象</param>
	/// <param name="equaliter">对象相等比较器</param>
	/// <returns>如果待检测对象为空（null）或者等于指定类型的默认值返回true，否则返回false</returns>
	public static bool IsNullOrDefault<T>(T item, IEqualityComparer<T> equaliter)
	{
		return IsNull(item) || IsDefault(item);
	}

	/// <summary>
	/// 检测待检测对象是否为空（null）或者等于指定类型的默认值
	/// </summary>
	/// <typeparam name="T">默认值的类型</typeparam>
	/// <param name="item">待检测对象</param>
	/// <param name="equalition">对象相等比较方法</param>
	/// <returns>如果待检测对象象是否为空（null）或者等于指定类型的默认值返回true，否则返回false</returns>
	public static bool IsNullOrDefault<T>(T item, Func<T, T, bool> equalition)
	{
		return IsNull(item) || IsDefault(item, equalition);
	}

	/// <summary>
	/// 检测待检测对象是否不为空（null）且不等于指定类型的默认值
	/// </summary>
	/// <param name="item">待检测对象</param>
	/// <param name="type">默认值的类型</param>
	/// <returns>如果待检测对象不为空（null）或者不等于指定类型的默认值返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">待检测对象为空时，对象类型 <paramref name="type" /> 为空。</exception>
	public static bool IsNotNullAndDefault(object item, Type type)
	{
		return IsNotNull(item) && IsNotDefault(item, type);
	}

	/// <summary>
	/// 检测待检测对象是否不为空（null）且不等于指定类型的默认值
	/// </summary>
	/// <typeparam name="T">默认值的类型</typeparam>
	/// <param name="item">待检测对象</param>
	/// <returns>如果待检测对象不为空（null）或者不等于指定类型的默认值返回true，否则返回false</returns>
	public static bool IsNotNullAndDefault<T>(T item)
	{
		return IsNotNull(item) && IsNotDefault(item);
	}

	/// <summary>
	/// 检测待检测对象是否不为空（null）且不等于指定类型的默认值
	/// </summary>
	/// <typeparam name="T">默认值的类型</typeparam>
	/// <param name="item">待检测对象</param>
	/// <param name="equaliter">对象相等比较器</param>
	/// <returns>如果待检测对象不为空（null）或者不等于指定类型的默认值返回true，否则返回false</returns>
	public static bool IsNotNullAndDefault<T>(T item, IEqualityComparer<T> equaliter)
	{
		return IsNotNull(item) && IsNotDefault(item, equaliter);
	}

	/// <summary>
	/// 检测待检测对象是否不为空（null）且不等于指定类型的默认值
	/// </summary>
	/// <typeparam name="T">默认值的类型</typeparam>
	/// <param name="item">待检测对象</param>
	/// <param name="equalition">对象相等比较方法</param>
	/// <returns>如果待检测对象是否为空（null）或者等于指定类型的默认值返回true，否则返回false</returns>
	public static bool IsNotNullAndDefault<T>(T item, Func<T, T, bool> equalition)
	{
		return IsNotNull(item) && IsNotDefault(item, equalition);
	}

	/// <summary>
	/// 判断待检测对象是否是引用类型（类或者接口）
	/// </summary>
	/// <param name="item">待检测对象</param>
	/// <returns>如果待检测对象是引用类型则返回true，否则返回false。如果待检测对象为空，则返回false。</returns>
	public static bool IsReferenceType(object item)
	{
		return IsNotNull(item) && TypeHelper.IsReference(item.GetType());
	}

	/// <summary>
	/// 检测待检测对象与目标类型是否兼容
	/// </summary>
	/// <param name="obj">待检测对象</param>
	/// <param name="type">检测的目标类型</param>
	/// <returns>如果待检测对象与目标类型兼容返回true，否则返回false。</returns>
	public static bool IsType(object obj, Type type)
	{
		return IsNotNull(obj) && TypeHelper.IsType(obj.GetType(), type);
	}

	/// <summary>
	/// 检测待检测对象与目标类型是否兼容
	/// </summary>
	/// <typeparam name="T">检测的目标类型</typeparam>
	/// <param name="obj">待检测对象</param>
	/// <returns>如果待检测对象与目标类型兼容返回true，否则返回false。</returns>
	public static bool IsType<T>(object obj)
	{
		return IsNotNull(obj) && TypeHelper.IsType<T>(obj.GetType());
	}

	/// <summary>
	/// 检测待检测对象是否为值类型
	/// </summary>
	/// <param name="item">待检测对象</param>
	/// <returns>如果待检测对象为值类型则返回true，否则返回false。如果待检测对象为空，则返回false。</returns>
	public static bool IsValueType(object item)
	{
		return IsNotNull(item) && item.GetType().IsValueType;
	}

	/// <summary>
	/// 获取自定的Json转换器
	/// </summary>
	/// <returns>自定义的Json转换器数组</returns>
	private static JsonConverter[] GetPredefinedJsonConverters()
	{
		if (IsNull(jsonConverters))
		{
			jsonConverters = new JsonConverter[1]
			{
				new IsoDateTimeConverter
				{
					DateTimeFormat = "yyyy-MM-ddTHH:mm:ss.fff"
				}
			};
			return jsonConverters;
		}
		return jsonConverters;
	}

	/// <summary>
	/// 将当前JSON表达式反序列化为对象
	/// </summary>
	/// <param name="json">当前JSON表达式</param>
	/// <param name="type">反序列化的目标对象类型</param>
	/// <param name="converters">可选的JSON转换器；如果指定了JSON转换，则将忽略所有内置的JSON转换器。</param>
	/// <returns>反序列化生成的目标类型对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前JSON表达式为空；或者目标对象类型为空。</exception>
	public static object JsonDeserialize(string json, Type type, params JsonConverter[] converters)
	{
		Guard.AssertNotNull(json, "json");
		Guard.AssertNotNull(type, "type");
		if (IsNull(converters) || converters.Length == 0)
		{
			converters = GetPredefinedJsonConverters();
		}
		return JsonConvert.DeserializeObject(json, type, converters);
	}

	/// <summary>
	/// 将当前JSON表达式反序列化为对象
	/// </summary>
	/// <typeparam name="T">反序列化的目标对象类型</typeparam>
	/// <param name="json">当前JSON表达式</param>
	/// <param name="converters">可选的JSON转换器；如果指定了JSON转换，则将忽略所有内置的JSON转换器。</param>
	/// <returns>反序列化生成的目标类型对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前JSON表达式为空。</exception>
	public static T JsonDeserialize<T>(string json, params JsonConverter[] converters)
	{
		Guard.AssertNotNull(json, "json");
		if (IsNull(converters) || converters.Length == 0)
		{
			converters = GetPredefinedJsonConverters();
		}
		return JsonConvert.DeserializeObject<T>(json, converters);
	}

	/// <summary>
	/// 将当前JSON表达式反序列化为对象数组
	/// </summary>
	/// <param name="json">当前JSON表达式</param>
	/// <param name="converting">JSON标记到对象的转换方法</param>
	/// <returns>反序列化生成的对象数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前JSON表达式为空；或者JSON标记到对象的转换方法 <paramref name="converting" /> 为空。</exception>
	public static object[] JsonDeserializeToArray(string json, Func<JToken, object> converting)
	{
		Guard.AssertNotNull(json, "json");
		Guard.AssertNotNull(converting, "converting");
		object obj = JsonConvert.DeserializeObject(json);
		if (obj is JArray)
		{
			List<object> list = new List<object>();
			foreach (JToken token in (JArray)obj)
			{
				list.Add(converting(token));
			}
			return list.ToArray();
		}
		if (obj is JObject)
		{
			return new object[1] { converting((JObject)obj) };
		}
		return new object[0];
	}

	/// <summary>
	/// 将当前JSON表达式反序列化为对象数组
	/// </summary>
	/// <typeparam name="T">反序列化的数组元素类型</typeparam>
	/// <param name="json">当前JSON表达式</param>
	/// <param name="converting">JSON标记到对象的转换方法</param>
	/// <returns>反序列化生成的对象数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前JSON表达式为空；或者JSON标记到对象的转换方法 <paramref name="converting" /> 为空。</exception>
	public static T[] JsonDeserializeToArray<T>(string json, Func<JToken, T> converting)
	{
		Guard.AssertNotNull(json, "json");
		Guard.AssertNotNull(converting, "converting");
		object obj = JsonConvert.DeserializeObject(json);
		if (obj is JArray)
		{
			List<T> list = new List<T>();
			foreach (JToken token in (JArray)obj)
			{
				list.Add(converting(token));
			}
			return list.ToArray();
		}
		if (obj is JObject)
		{
			return new T[1] { converting((JObject)obj) };
		}
		throw new JsonException(Literals.MSG_JsonUnrecognized);
	}

	/// <summary>
	/// 将当前JSON表达式反序列化为对象列表
	/// </summary>
	/// <typeparam name="T">反序列化的列表元素类型</typeparam>
	/// <param name="json">当前JSON表达式</param>
	/// <param name="converters">可选的JSON转换器；如果指定了JSON转换，则将忽略所有内置的JSON转换器。</param>
	/// <returns>反序列化生成的对象列表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前JSON表达式为空。</exception>
	public static List<T> JsonDeserializeToList<T>(string json, params JsonConverter[] converters)
	{
		Guard.AssertNotNull(json, "json");
		if (IsNull(converters) || converters.Length == 0)
		{
			converters = GetPredefinedJsonConverters();
		}
		if (TextHelper.IsJsonArray(json))
		{
			return JsonConvert.DeserializeObject<List<T>>(json, converters);
		}
		if (TextHelper.IsJsonObject(json))
		{
			List<T> list = new List<T>();
			list.Add(JsonConvert.DeserializeObject<T>(json, converters));
			return list;
		}
		throw new JsonException(Literals.MSG_JsonUnrecognized);
	}

	/// <summary>
	/// 将当前对象序列化为Json表达式
	/// </summary>
	/// <param name="obj">当前对象</param>
	/// <returns>序列化后的Json表达式</returns>
	public static string JsonSerialize(object obj)
	{
		IsoDateTimeConverter converter = new IsoDateTimeConverter();
		converter.DateTimeFormat = "yyyy-MM-ddTHH:mm:ss.fff";
		return JsonSerialize(obj, converter);
	}

	/// <summary>
	/// 将当前对象序列化为Json表达式
	/// </summary>
	/// <param name="obj">当前对象</param>
	/// <param name="converters">自定义的Json转换器</param>
	/// <returns>序列化后的Json表达式</returns>
	public static string JsonSerialize(object obj, params JsonConverter[] converters)
	{
		return JsonConvert.SerializeObject(obj, converters);
	}

	/// <summary>
	/// 构造将当前对象作为唯一元素的数组
	/// </summary>
	/// <typeparam name="T">对象类型</typeparam>
	/// <param name="value">当前对象</param>
	/// <returns>对象数组</returns>
	public static T[] MakeArray<T>(T value)
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
	public static T[] MakeArray<T>(T value, int length)
	{
		Guard.AssertGreaterThanOrEqualTo(length, 0, "Length");
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
	public static T[] MakeArray<T>(T value, long length)
	{
		Guard.AssertGreaterThanOrEqualTo(length, 0L, "Length");
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
	public static Array MakeArray<T>(T value, int[] lengths)
	{
		Guard.AssertNotNull(lengths, "lengths");
		Array array = TypeHelper.CreateArray(typeof(T), lengths);
		ArrayHelper.Fill(array, value);
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
	public static Array MakeArray<T>(T value, long[] lengths)
	{
		Guard.AssertNotNull(lengths, "lengths");
		Array array = TypeHelper.CreateArray(typeof(T), lengths);
		ArrayHelper.Fill(array, value);
		return array;
	}

	/// <summary>
	/// 将当前对象映射为目标类型的对象
	/// </summary>
	/// <typeparam name="T">映射的目标类型</typeparam>
	/// <param name="source">当前对象</param>
	/// <returns>映射生成的目标类型对象</returns>
	public static T MapTo<T>(object source)
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
	public static T MapTo<S, T>(S source, T target)
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
	public static object MapTo(object source, Type targetType)
	{
		Guard.AssertNotNull(targetType, "target type");
		return IsNull(source) ? TypeHelper.CreateDefault(targetType) : TypeMapper.Map(source, source.GetType(), targetType);
	}

	/// <summary>
	/// 把源对象映射为目标类型
	/// </summary>
	/// <param name="source">映射的源对象</param>
	/// <param name="sourceType">映射的源类型</param>
	/// <param name="targetType">映射的目标类型</param>
	/// <returns>映射生成的目标类型对象</returns>
	/// <exception cref="T:System.ArgumentNullException">映射的源类型 <paramref name="sourceType" /> 为空；或者映射的目标类型 <paramref name="targetType" /> 为空。</exception>
	public static object MapTo(object source, Type sourceType, Type targetType)
	{
		Guard.AssertNotNull(sourceType, "source type");
		Guard.AssertNotNull(targetType, "target type");
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
	public static object MapTo(object source, object target, Type sourceType, Type targetType)
	{
		Guard.AssertNotNull(sourceType, "source type");
		Guard.AssertNotNull(targetType, "target type");
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
	/// <exception cref="T:System.ArgumentNullException">当前对象为空。</exception>
	public static T Max<T>(IComparable<T> item, T maxValue) where T : IComparable<T>
	{
		Guard.AssertNotNull(item, "item");
		return (item.CompareTo(maxValue) >= 0) ? ((T)item) : maxValue;
	}

	/// <summary>
	/// 返回当前值和指定值之间的最大者
	/// </summary>
	/// <typeparam name="T">比较的对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="maxValue">比较的值</param>
	/// <param name="comparer">值比较对象</param>
	/// <returns>返回两者中的最大值，如果两个值相等返回当前值本身</returns>
	public static T Max<T>(T item, T maxValue, IComparer<T> comparer)
	{
		return (IfNull(comparer, Comparer<T>.Default).Compare(item, maxValue) >= 0) ? item : maxValue;
	}

	/// <summary>
	/// 返回当前值和指定值之间的最大者
	/// </summary>
	/// <typeparam name="T">比较的对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="maxValue">比较的值</param>
	/// <param name="comparison">值比较方法</param>
	/// <returns>返回两者中的最大值，如果两个值相等返回当前值本身</returns>
	public static T Max<T>(T item, T maxValue, Func<T, T, int> comparison)
	{
		return (IfNull(comparison, Comparer<T>.Default.Compare)(item, maxValue) >= 0) ? item : maxValue;
	}

	/// <summary>
	/// 返回当前值和指定值之间的最小值
	/// </summary>
	/// <typeparam name="T">比较的对象类型</typeparam>
	/// <param name="item">待比较的值</param>
	/// <param name="minValue">比较的值</param>
	/// <returns>返回两者中的最小值，如果两个值相等返回当前值本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空。</exception>
	public static T Min<T>(IComparable<T> item, T minValue) where T : IComparable<T>
	{
		Guard.AssertNotNull(item, "item");
		return (item.CompareTo(minValue) <= 0) ? ((T)item) : minValue;
	}

	/// <summary>
	/// 返回当前值和指定值之间的最小值
	/// </summary>
	/// <typeparam name="T">比较的对象类型</typeparam>
	/// <param name="item">待比较的值</param>
	/// <param name="minValue">比较的值</param>
	/// <param name="comparer">值比较对象</param>
	/// <returns>返回两者中的最小值，如果两个值相等返回当前值本身</returns>
	public static T Min<T>(T item, T minValue, IComparer<T> comparer)
	{
		return (IfNull(comparer, Comparer<T>.Default).Compare(minValue, item) < 0) ? minValue : item;
	}

	/// <summary>
	/// 返回当前值和指定值之间的最小值
	/// </summary>
	/// <typeparam name="T">比较的对象类型</typeparam>
	/// <param name="item">待比较的值</param>
	/// <param name="minValue">比较的值</param>
	/// <param name="comparison">值比较方法</param>
	/// <returns>返回两者中的最小值，如果两个值相等返回当前值本身</returns>
	public static T Min<T>(T item, T minValue, Func<T, T, int> comparison)
	{
		return (IfNull(comparison, Comparer<T>.Default.Compare)(minValue, item) < 0) ? minValue : item;
	}

	/// <summary>
	/// 调用对象比较方法，检测当前对象是否等于目标对象
	/// </summary>
	/// <param name="obj">比较的对象</param>
	/// <param name="target">比较的目标对象</param>
	/// <returns>如果比较的对象等于目标对象返回true，否则返回false。</returns>
	public static bool ObjectEquals(object obj, object target)
	{
		if (object.ReferenceEquals(obj, target))
		{
			return true;
		}
		return (IsNull(obj) || obj.Equals(target)) && (IsNull(target) || target.Equals(obj));
	}

	/// <summary>
	/// 判断当前对象是否满足指定的断言检测
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="predicate">测试断言</param>
	/// <returns>如果当前对象满足指定的断言返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="predicate" /> 为空。</exception>
	public static bool Predicate<T>(T item, Func<T, bool> predicate)
	{
		Guard.AssertNotNull(predicate, "predicate");
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
	public static bool ReferenceEquals<X, Y>(X x, Y y)
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
	/// <returns>处理后的当前对象</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="obj" /> 为空，或者 <paramref name="propertyPath" /> 为空或者空串。</exception>
	/// <exception cref="T:System.Reflection.TargetException">属性路径 <paramref name="propertyPath" /> 指定的属性不可写。</exception>
	/// <exception cref="T:System.MissingMemberException">当 <paramref name="ignoreMissing" /> 为false时，属性路径 <paramref name="propertyPath" /> 指定的属性未找到。</exception>
	/// <exception cref="T:System.InvalidOperationException">属性路径 <paramref name="propertyPath" /> 指定的属性的类型与设置的属性值 <paramref name="value" /> 不匹配。</exception>
	/// <remarks>本方法按照指定的属性路径获取对象的属性、对象属性的属性（对象属性值时对象时）等任意层级的属性值。</remarks>
	public static T SetPropertyValue<T>(T obj, string propertyPath, object value, bool ignoreCase = false, bool ignoreMissing = false)
	{
		return SetPropertyValue(obj, propertyPath, value, BindingFlags.Instance | BindingFlags.Public, ignoreCase, ignoreMissing);
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
	/// <returns>处理后的当前对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者属性路径 <paramref name="propertyPath" /> 为空或者空串。</exception>
	/// <exception cref="T:System.Reflection.TargetException">属性路径 <paramref name="propertyPath" /> 指定的属性不可写。</exception>
	/// <exception cref="T:System.MissingMemberException">当 <paramref name="ignoreMissing" /> 为false时，属性路径 <paramref name="propertyPath" /> 指定的属性未找到。</exception>
	/// <exception cref="T:System.InvalidOperationException">属性路径 <paramref name="propertyPath" /> 指定的属性的类型与设置的属性值 <paramref name="value" /> 不匹配。</exception>
	public static T SetPropertyValue<T>(T obj, string propertyPath, object value, BindingFlags flags, bool ignoreCase = false, bool ignoreMissing = false)
	{
		Guard.AssertNotNull(obj, "object");
		Guard.AssertNotNullAndEmpty(propertyPath, "property path");
		object owner = null;
		PropertyInfo pinfo = GetProperty(obj, propertyPath, flags, out owner, ignoreCase);
		if (IsNull(pinfo))
		{
			if (ignoreMissing)
			{
				return obj;
			}
			throw new MissingMemberException(obj.GetType().FullName, propertyPath);
		}
		Guard.Assert(pinfo.CanWrite, () => new TargetException(Literals.MSG_ObjectPropertyUnwritable));
		if (IsNull(value))
		{
			if (!TypeHelper.IsNullable(pinfo.PropertyType))
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
				value = ConvertHelper.Cast(value, pinfo.PropertyType);
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
	public static T ShallowCopy<T>(T item)
	{
		Guard.AssertNotNull(item, "item");
		MethodInfo minfo = typeof(T).GetMethod("MemberwiseClone", BindingFlags.Instance | BindingFlags.NonPublic);
		if (IsNull(minfo))
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
	public static void Switch<T>(T obj, Func<T, int> switcher, params Action[] actions)
	{
		Guard.AssertNotNull(switcher, "Swticher");
		Guard.AssertNotNull(actions, "Actions");
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
	public static void Switch<T>(T obj, Func<T, int> switcher, params Action<T>[] actions)
	{
		Guard.AssertNotNull(switcher, "Swticher");
		Guard.AssertNotNull(actions, "Actions");
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
	public static DataTable ToDataTable(object obj)
	{
		return ToDataTable<DataTable>(obj);
	}

	/// <summary>
	/// 将当前对象转换为数据行，并存入指定的数据表中。当前对象的所有公共实例属性转换为数据表的列。
	/// </summary>
	/// <typeparam name="T">数据表类型</typeparam>
	/// <param name="obj">当前对象</param>
	/// <param name="table">存入的数据表</param>
	/// <returns>存入数据行的数据表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空。</exception>
	public static T ToDataTable<T>(object obj, T table = null) where T : DataTable, new()
	{
		return ToDataTable(obj, BindingFlags.Instance | BindingFlags.Public, table);
	}

	/// <summary>
	/// 将当前对象转换为数据行，创建并返回包含该数据行的数据表
	/// </summary>
	/// <param name="obj">当前对象</param>
	/// <param name="flags">属性绑定标志</param>
	/// <returns>映射生成的数据表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空。</exception>
	public static DataTable ToDataTable(object obj, BindingFlags flags)
	{
		return ToDataTable<DataTable>(obj, flags);
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
	public static T ToDataTable<T>(object obj, BindingFlags flags, T table = null) where T : DataTable, new()
	{
		return ToDataTable(obj, new DataMapping[0], flags, onlyMapping: false, ignoreCase: false, table);
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
	public static DataTable ToDataTable(object obj, string[] propertyNames, bool onlyMapping = false, bool ignoreCase = false)
	{
		return ToDataTable<DataTable>(obj, propertyNames, onlyMapping, ignoreCase);
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
	public static T ToDataTable<T>(object obj, string[] propertyNames, bool onlyMapping = false, bool ignoreCase = false, T table = null) where T : DataTable, new()
	{
		return ToDataTable(obj, propertyNames, BindingFlags.Instance | BindingFlags.Public, onlyMapping, ignoreCase, table);
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
	public static DataTable ToDataTable(object obj, string[] propertyNames, BindingFlags flags, bool onlyMapping = false, bool ignoreCase = false)
	{
		return ToDataTable<DataTable>(obj, propertyNames, flags, onlyMapping, ignoreCase);
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
	public static T ToDataTable<T>(object obj, string[] propertyNames, BindingFlags flags, bool onlyMapping = false, bool ignoreCase = false, T table = null) where T : DataTable, new()
	{
		Guard.AssertNotNull(propertyNames, "property names");
		DataMapping[] mappings = (from n in propertyNames.Where((string n) => IsNotNull(n)).Distinct()
			select new DataMapping(null, n)).ToArray();
		return ToDataTable(obj, mappings, flags, onlyMapping, ignoreCase, table);
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
	public static DataTable ToDataTable(object obj, DataMapping[] mappings, bool onlyMapping = false, bool ignoreCase = false)
	{
		return ToDataTable<DataTable>(obj, mappings, onlyMapping, ignoreCase);
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
	public static T ToDataTable<T>(object obj, DataMapping[] mappings, bool onlyMapping = false, bool ignoreCase = false, T table = null) where T : DataTable, new()
	{
		return ToDataTable(obj, mappings, BindingFlags.Instance | BindingFlags.Public, onlyMapping, ignoreCase, table);
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
	public static DataTable ToDataTable(object obj, DataMapping[] mappings, BindingFlags flags, bool onlyMapping = false, bool ignoreCase = false)
	{
		return ToDataTable<DataTable>(obj, mappings, flags, onlyMapping, ignoreCase);
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
	public static T ToDataTable<T>(object obj, DataMapping[] mappings, BindingFlags flags, bool onlyMapping = false, bool ignoreCase = false, T table = null) where T : DataTable, new()
	{
		Guard.AssertNotNull(obj, "object");
		Guard.AssertNotNull(mappings, "mappings");
		table = IfNull(table, new T());
		Dictionary<string, Tuple<DataColumn, PropertyInfo, object>> columns = new Dictionary<string, Tuple<DataColumn, PropertyInfo, object>>(ignoreCase ? StringComparer.OrdinalIgnoreCase : StringComparer.Ordinal);
		CollectionHelper.TryAddRange(columns, DataHelper.Columns(table), (DataColumn c) => c.ColumnName, (DataColumn c) => new Tuple<DataColumn, PropertyInfo, object>(c, null, null));
		object owner;
		if (onlyMapping)
		{
			foreach (DataMapping mapping in mappings.Where((DataMapping m) => IsNotNull(m) && !string.IsNullOrEmpty(m.PropertyName)))
			{
				PropertyInfo pinfo = GetProperty(obj, mapping.PropertyName, flags, out owner, ignoreCase);
				if (IsNull(pinfo))
				{
					throw new ArgumentException(string.Format(Literals.MSG_MissingProperty_1, mapping.PropertyName), "mappings");
				}
				string columnName = TextHelper.IfNullOrEmpty(mapping.ColumnName, pinfo.Name);
				if (columns.ContainsKey(columnName))
				{
					if (!TypeHelper.IsType(pinfo.PropertyType, columns[columnName].Item1.DataType))
					{
						throw new DuplicateNameException(string.Format(Literals.MSG_DataColumnDuplication_1, columnName));
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
			CollectionHelper.TryAddRange(properties, mappings.Where((DataMapping m) => IsNotNull(m) && !string.IsNullOrEmpty(m.ColumnName)), (DataMapping m) => m.PropertyName);
			PropertyInfo[] properties2 = obj.GetType().GetProperties(flags);
			foreach (PropertyInfo pinfo in properties2)
			{
				if (properties.ContainsKey(pinfo.Name))
				{
					string columnName = TextHelper.IfNullOrEmpty(properties[pinfo.Name].ColumnName, pinfo.Name);
					if (columns.ContainsKey(columnName))
					{
						if (!TypeHelper.IsType(pinfo.PropertyType, columns[columnName].Item1.DataType))
						{
							throw new DuplicateNameException(TextHelper.FormatValue(Literals.MSG_DataColumnDuplication_1, columnName));
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
						if (!TypeHelper.IsType(pinfo.PropertyType, columns[columnName].Item1.DataType))
						{
							throw new DuplicateNameException(TextHelper.FormatValue(Literals.MSG_DataColumnDuplication_1, columnName));
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
					PropertyInfo extraPinfo = GetProperty(obj, mapping.PropertyName, out owner, ignoreCase);
					if (IsNull(extraPinfo))
					{
						throw new ArgumentException(TextHelper.FormatValue(Literals.MSG_MissingProperty_1, mapping.PropertyName), "mappings");
					}
					string columnName = TextHelper.IfNullOrEmpty(mapping.ColumnName, extraPinfo.Name);
					if (columns.ContainsKey(columnName))
					{
						if (!TypeHelper.IsType(pinfo.PropertyType, columns[columnName].Item1.DataType))
						{
							throw new DuplicateNameException(TextHelper.FormatValue(Literals.MSG_DataColumnDuplication_1, columnName));
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
			if (IsNotNull(kvp.Value.Item2))
			{
				row[kvp.Value.Item1] = ConvertHelper.Cast(kvp.Value.Item2.GetValue(kvp.Value.Item3, null), kvp.Value.Item2.PropertyType);
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
	public static Exception Try<T>(T item, Action<T> action)
	{
		Guard.AssertNotNull(action, "action");
		return DelegateHelper.Try(action, item);
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
	public static void Try<T>(T item, Action<T> action, Action<Exception> catcher, Action finalizer = null)
	{
		Guard.AssertNotNull(action, "action");
		DelegateHelper.Try(action, item, catcher, finalizer);
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
	public static Exception Try<T, R>(T item, Func<T, R> func, out R result)
	{
		Guard.AssertNotNull(func, "func");
		return DelegateHelper.Try(func, item, out result);
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
	public static R Try<T, R>(T item, Func<T, R> func, R defaultValue, out Exception ex)
	{
		Guard.AssertNotNull(func, "func");
		ex = DelegateHelper.Try(func, item, out var result);
		return IsNull(ex) ? result : defaultValue;
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
	public static R Try<T, R>(T item, Func<T, R> func, Func<Exception, R> catcher, Action<R> finalizer = null)
	{
		Guard.AssertNotNull(func, "func");
		return DelegateHelper.Try(func, item, catcher, finalizer);
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
	public static R When<T, R>(T item, Func<T, bool> predicate, Func<R> func)
	{
		Guard.AssertNotNull(predicate, "predicate");
		Guard.AssertNotNull(func, "func");
		return predicate(item) ? func() : As<R>(item);
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
	public static R When<T, R>(T item, Func<T, bool> predicate, Func<R> trueFunc, Func<R> falseFunc)
	{
		Guard.AssertNotNull(predicate, "predicate");
		Guard.AssertNotNull(trueFunc, "true func");
		Guard.AssertNotNull(falseFunc, "false func");
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
	public static void When<T>(T item, Func<T, bool> predicate, Action action)
	{
		Guard.AssertNotNull(predicate, "predicate");
		Guard.AssertNotNull(action, "action");
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
	public static void When<T>(T item, Func<T, bool> predicate, Action trueAction, Action falseAction)
	{
		Guard.AssertNotNull(predicate, "predicate");
		Guard.AssertNotNull(trueAction, "true action");
		Guard.AssertNotNull(falseAction, "false action");
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
	/// 如果当前对象为空，则返回 <paramref name="evaluation" /> 的结果值，否则返回对象本身
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="evaluation">值函数，不能为空</param>
	/// <returns>处理结果</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="evaluation" /> 为空。</exception>
	public static T WhenNull<T>(T item, Func<T> evaluation)
	{
		Guard.AssertNotNull(evaluation, "evaluation");
		return IsNull(item) ? evaluation() : item;
	}

	/// <summary>
	/// 如果当前对象为空，则执行 <paramref name="action" /> 委托
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="action">执行的委托</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="action" /> 为空。</exception>
	public static void WhenNull<T>(T item, Action action)
	{
		Guard.AssertNotNull(action, "action");
		if (IsNull(item))
		{
			action();
		}
	}

	/// <summary>
	/// 如果对象不为空，则返回 <paramref name="evaluation" /> 的结果值，否则返回对象本身
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="evaluation">值函数</param>
	/// <returns>处理结果</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="evaluation" /> 为空。</exception>
	public static T WhenNotNull<T>(T item, Func<T> evaluation)
	{
		Guard.AssertNotNull(evaluation, "evaluation");
		return IsNotNull(item) ? evaluation() : item;
	}

	/// <summary>
	/// 如果对象不为空，则执行 <paramref name="action" /> 委托
	/// </summary>
	/// <typeparam name="T">对象类型</typeparam>
	/// <param name="item">待检测的对象</param>
	/// <param name="action">待执行的动作</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="action" /> 为空。</exception>
	public static void WhenNotNull<T>(T item, Action action)
	{
		Guard.AssertNotNull(action, "action");
		if (IsNotNull(item))
		{
			action();
		}
	}

	/// <summary>
	/// 如果当前对象为空或者为DBNull，则返回 <paramref name="evaluation" /> 的结果值，否则返回对象本身
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="evaluation">值函数，不能为空</param>
	/// <returns>处理结果</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="evaluation" /> 为空。</exception>
	public static T WhenNullOrDBNull<T>(T item, Func<T> evaluation)
	{
		Guard.AssertNotNull(evaluation, "evaluation");
		return IsNullOrDBNull(item) ? evaluation() : item;
	}

	/// <summary>
	/// 如果当前对象为空或者为DBNull，则执行 <paramref name="action" /> 委托
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="action">执行的动作</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="action" /> 为空。</exception>
	public static void WhenNullOrDBNull<T>(T item, Action action)
	{
		Guard.AssertNotNull(action, "action");
		if (IsNullOrDBNull(item))
		{
			action();
		}
	}

	/// <summary>
	/// 如果当前对象不是null或者DBNull，则返回 <paramref name="evaluation" /> 的结果值，否则返回对象本身
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="evaluation">值函数，不能为空</param>
	/// <returns>处理结果</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="evaluation" /> 为空。</exception>
	public static T WhenNotNullAndDBNull<T>(T item, Func<T> evaluation)
	{
		Guard.AssertNotNull(evaluation, "evaluation");
		return IsNotNullAndDBNull(item) ? evaluation() : item;
	}

	/// <summary>
	/// 如果当前对象不是null或者DBNull，则执行 <paramref name="action" /> 委托
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="action">执行的动作</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="action" /> 为空。</exception>
	public static void WhenNotNullAndDBNull<T>(T item, Action action)
	{
		Guard.AssertNotNull(action, "action");
		if (IsNotNullAndDBNull(item))
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
	public static string XmlSerialize(object item, Type type = null)
	{
		if (IsNull(item))
		{
			Guard.AssertNotNull(type, "type");
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

	/// <summary>
	/// 将当前XML文本反序列化为指定类型的对象
	/// </summary>
	/// <param name="xml">当前XML文本</param>
	/// <param name="type">反序列化的目标类型</param>
	/// <returns>反序列化生成的目标类型的对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前XML文本为空；或者目标类型 <paramref name="type" /> 为空。</exception>
	public static object XmlDeserialize(string xml, Type type)
	{
		Guard.AssertNotNull(xml, "xml");
		Guard.AssertNotNull(type, "type");
		using StringReader reader = new StringReader(xml);
		XmlSerializer serializer = new XmlSerializer(type);
		return serializer.Deserialize(reader);
	}

	/// <summary>
	/// 将当前XML文本反序列化为指定类型的对象
	/// </summary>
	/// <param name="xml">当前XML文本</param>
	/// <param name="type">反序列化的目标类型</param>
	/// <param name="defaultValue">无法反序列化时返回的默认值</param>
	/// <returns>反序列化生成的目标类型的对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前XML文本为空；或者目标类型 <paramref name="type" /> 为空。</exception>
	public static object XmlDeserialize(string xml, Type type, object defaultValue)
	{
		Guard.AssertNotNull(xml, "xml");
		Guard.AssertNotNull(type, "type");
		try
		{
			return XmlDeserialize(xml, type);
		}
		catch
		{
			return defaultValue;
		}
	}

	/// <summary>
	/// 将当前XML文本反序列化为指定类型的对象
	/// </summary>
	/// <typeparam name="T">反序列化的目标类型</typeparam>
	/// <param name="xml">当前XML文本</param>
	/// <returns>反序列化生成的目标类型的对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前XML文本为空。</exception>
	public static T XmlDeserialize<T>(string xml)
	{
		Guard.AssertNotNull(xml, "xml");
		return (T)XmlDeserialize(xml, typeof(T));
	}

	/// <summary>
	/// 将当前XML文本反序列化为指定类型的对象
	/// </summary>
	/// <typeparam name="T">反序列化的目标类型</typeparam>
	/// <param name="xml">当前XML文本</param>
	/// <param name="defaultValue">无法反序列化时返回的默认值</param>
	/// <returns>反序列化生成的目标类型的对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前XML文本为空。</exception>
	public static T XmlDeserialize<T>(string xml, T defaultValue)
	{
		Guard.AssertNotNull(xml, "xml");
		return (T)XmlDeserialize(xml, typeof(T), defaultValue);
	}

	/// <summary>
	/// 将当前Xml文档反序列化为对象
	/// </summary>
	/// <param name="xmldoc">当前Xml文档对象</param>
	/// <param name="type">反序列化的目标对象类型</param>
	/// <returns>反序列化生成的对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前Xml文档对象为空；或者反序列化的目标类型 <paramref name="type" /> 为空。</exception>
	public static object XmlDeserialize(XmlDocument xmldoc, Type type)
	{
		Guard.AssertNotNull(xmldoc, "xmldoc");
		Guard.AssertNotNull(type, "type");
		return XmlDeserialize(xmldoc.InnerXml, type);
	}

	/// <summary>
	/// 将当前Xml文档反序列化为对象
	/// </summary>
	/// <param name="xmldoc">当前Xml文档对象</param>
	/// <param name="type">反序列化的目标对象类型</param>
	/// <param name="defaultValue">无法反序列化时返回的对象</param>
	/// <returns>反序列化生成的对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前Xml文档对象为空；或者反序列化的目标类型 <paramref name="type" /> 为空。</exception>
	public static object XmlDeserialize(XmlDocument xmldoc, Type type, object defaultValue)
	{
		Guard.AssertNotNull(xmldoc, "xmldoc");
		Guard.AssertNotNull(type, "type");
		return XmlDeserialize(xmldoc.InnerXml, type, defaultValue);
	}

	/// <summary>
	/// 将当前Xml文档反序列化为对象
	/// </summary>
	/// <typeparam name="T">反序列化的目标对象类型</typeparam>
	/// <param name="xmldoc">当前Xml文档对象</param>
	/// <returns>反序列化生成的对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前Xml文件对象为空。</exception>
	public static T XmlDeserialize<T>(XmlDocument xmldoc)
	{
		Guard.AssertNotNull(xmldoc, "xmldoc");
		return XmlDeserialize<T>(xmldoc.InnerXml);
	}

	/// <summary>
	/// 将当前Xml文档反序列化为对象
	/// </summary>
	/// <typeparam name="T">反序列化的目标对象类型</typeparam>
	/// <param name="xmldoc">当前Xml文档对象</param>
	/// <param name="defaultValue">无法反序列化时返回的对象</param>
	/// <returns>反序列化生成的对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前Xml文件对象为空。</exception>
	public static T XmlDeserialize<T>(XmlDocument xmldoc, T defaultValue)
	{
		Guard.AssertNotNull(xmldoc, "xmldoc");
		return XmlDeserialize(xmldoc.InnerXml, defaultValue);
	}
}
