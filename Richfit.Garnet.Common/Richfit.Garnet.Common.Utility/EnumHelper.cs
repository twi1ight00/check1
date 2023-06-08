#define DEBUG
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;
using Richfit.Garnet.Common.Properties;
using Richfit.Garnet.Common.Reflection;

namespace Richfit.Garnet.Common.Utility;

/// <summary>
/// 枚举类型辅助类
/// </summary>
public static class EnumHelper
{
	/// <summary>
	/// 清除当前枚举中已经设置的标志位
	/// </summary>
	/// <typeparam name="E">当前枚举类型</typeparam>
	/// <param name="variable">当前枚举值</param>
	/// <param name="flag">需要清除的枚举标志</param>
	/// <returns>处理后的枚举值</returns>
	/// <exception cref="T:System.ArgumentException">当前枚举变量不是 <see cref="T:System.Enum" /> 类型。</exception>
	public static E ClearFlag<E>(E variable, E flag) where E : struct
	{
		Guard.Assert(typeof(E).IsEnum, "variable", string.Format(Literals.MSG_TypeNotEnum_1, typeof(E).FullName));
		long value = Convert.ToInt64(variable);
		value &= ~Convert.ToInt64(flag);
		return (E)Enum.ToObject(typeof(E), value);
	}

	/// <summary>
	/// 清除当前枚举的所有标志位
	/// </summary>
	/// <typeparam name="E">当前枚举类型</typeparam>
	/// <param name="variable">当前枚举值</param>
	/// <returns>处理后枚举值</returns>
	/// <exception cref="T:System.ArgumentException">当前枚举变量不是 <see cref="T:System.Enum" /> 类型。</exception>
	public static E ClearFlags<E>(E variable) where E : struct
	{
		Guard.Assert(typeof(E).IsEnum, "variable", string.Format(Literals.MSG_TypeNotEnum_1, typeof(E).FullName));
		long value = Convert.ToInt64(variable);
		value = 0L;
		return (E)Enum.ToObject(typeof(E), value);
	}

	/// <summary>
	/// 清除当前枚举中指定的枚举标志
	/// </summary>
	/// <typeparam name="E">当前枚举类型</typeparam>
	/// <param name="variable">当前枚举值</param>
	/// <param name="flags">需要清除的枚举标记数组</param>
	/// <returns>处理后的枚举值</returns>
	/// <exception cref="T:System.ArgumentException">当前枚举变量不是 <see cref="T:System.Enum" /> 类型。</exception>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="flags" /> 为空。</exception>
	public static E ClearFlags<E>(E variable, params E[] flags) where E : struct
	{
		Guard.Assert(typeof(E).IsEnum, "variable", string.Format(Literals.MSG_TypeNotEnum_1, typeof(E).FullName));
		Guard.AssertNotNull(flags, "flags");
		long value = Convert.ToInt64(variable);
		foreach (E flag in flags)
		{
			value &= ~Convert.ToInt64(flag);
		}
		return (E)Enum.ToObject(typeof(E), value);
	}

	/// <summary>
	/// 检查当前枚举中是否设置了指定的枚举的全部标志位
	/// </summary>
	/// <typeparam name="E">当前枚举类型</typeparam>
	/// <param name="variable">当前枚举值</param>
	/// <param name="flag">需要检查的枚举标记</param>
	/// <returns>如果当前枚举包含指定的枚举的所有标志位则返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentException">当前枚举变量不是 <see cref="T:System.Enum" /> 类型。</exception>
	public static bool HasAllFlag<E>(E variable, E flag) where E : struct
	{
		Guard.Assert(typeof(E).IsEnum, "variable", string.Format(Literals.MSG_TypeNotEnum_1, typeof(E).FullName));
		long value = Convert.ToInt64(variable);
		long flagValue = Convert.ToInt64(flag);
		return (value & flagValue) == flagValue;
	}

	/// <summary>
	/// 检查当前枚举是否设置了指定的全部枚举的全部标志位
	/// </summary>
	/// <typeparam name="E">当前枚举类型</typeparam>
	/// <param name="variable">当前枚举</param>
	/// <param name="flags">需要检查的枚举标记</param>
	/// <returns>如果当前枚举包含全部的指定枚举值的所有标志位则返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentException">当前枚举变量不是 <see cref="T:System.Enum" /> 类型。</exception>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="flags" /> 为空。</exception>
	public static bool HasAllFlags<E>(E variable, params E[] flags) where E : struct
	{
		Guard.Assert(typeof(E).IsEnum, "variable", string.Format(Literals.MSG_TypeNotEnum_1, typeof(E).FullName));
		Guard.AssertNotNull(flags, "flags");
		long value = Convert.ToInt64(variable);
		foreach (E flag in flags)
		{
			long flagValue = Convert.ToInt64(flag);
			if ((value & flagValue) != flagValue)
			{
				return false;
			}
		}
		return true;
	}

	/// <summary>
	/// 检查当前枚举是否设置了指定的枚举的任一标志位
	/// </summary>
	/// <typeparam name="E">当前枚举类型</typeparam>
	/// <param name="variable">当前枚举值</param>
	/// <param name="flag">需要检查的枚举标记</param>
	/// <returns>如果当前枚举包含指定枚举的任一标志位则返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentException">当前枚举变量不是 <see cref="T:System.Enum" /> 类型。</exception>
	public static bool HasAnyFlag<E>(E variable, E flag) where E : struct
	{
		Guard.Assert(typeof(E).IsEnum, "variable", string.Format(Literals.MSG_TypeNotEnum_1, typeof(E).FullName));
		long value = Convert.ToInt64(variable);
		long flagValue = Convert.ToInt64(flag);
		return (value & flagValue) > 0;
	}

	/// <summary>
	/// 检查当前枚举是否设置了指定的任一枚举的任一标志位
	/// </summary>
	/// <typeparam name="E">当前枚举类型</typeparam>
	/// <param name="variable">当前枚举值</param>
	/// <param name="flags">需要检查的枚举标记</param>
	/// <returns>如果当前枚举包含指定的任一枚举的任一标志位则返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentException">当前枚举变量不是 <see cref="T:System.Enum" /> 类型。</exception>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="flags" /> 为空。</exception>
	public static bool HasAnyFlags<E>(E variable, params E[] flags) where E : struct
	{
		Guard.Assert(typeof(E).IsEnum, "variable", string.Format(Literals.MSG_TypeNotEnum_1, typeof(E).FullName));
		Guard.AssertNotNull(flags, "flags");
		long value = Convert.ToInt64(variable);
		foreach (E flag in flags)
		{
			long flagValue = Convert.ToInt64(flag);
			if ((value & flagValue) > 0)
			{
				return true;
			}
		}
		return false;
	}

	/// <summary>
	/// 给当前的枚举值设置指定的枚举标志位
	/// </summary>
	/// <typeparam name="E">当前枚举类型</typeparam>
	/// <param name="variable">当前枚举值</param>
	/// <param name="flag">需要设置的枚举标志</param>
	/// <returns>处理后的枚举值</returns>
	/// <exception cref="T:System.ArgumentException">当前枚举变量不是 <see cref="T:System.Enum" /> 类型。</exception>
	public static E SetFlag<E>(E variable, E flag) where E : struct
	{
		Guard.Assert(typeof(E).IsEnum, "variable", string.Format(Literals.MSG_TypeNotEnum_1, typeof(E).FullName));
		long value = Convert.ToInt64(variable);
		value |= Convert.ToInt64(flag);
		return (E)Enum.ToObject(typeof(E), value);
	}

	/// <summary>
	/// 给当前的枚举值设置指定的枚举标志位
	/// </summary>
	/// <typeparam name="E">当前枚举类型</typeparam>
	/// <param name="variable">当前枚举值</param>
	/// <param name="flags">需要设置的枚举标志</param>
	/// <returns>处理后的枚举值</returns>
	/// <exception cref="T:System.ArgumentException">当前枚举变量不是 <see cref="T:System.Enum" /> 类型。</exception>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="flags" /> 为空。</exception>
	public static E SetFlag<E>(E variable, params E[] flags) where E : struct
	{
		Guard.Assert(typeof(E).IsEnum, "variable", string.Format(Literals.MSG_TypeNotEnum_1, typeof(E).FullName));
		Guard.AssertNotNull(flags, "flags");
		long value = Convert.ToInt64(variable);
		foreach (E flag in flags)
		{
			value |= Convert.ToInt64(flag);
		}
		return (E)Enum.ToObject(typeof(E), value);
	}

	/// <summary>
	/// 保留当前枚举值中指定的标志位，清除其他标志位
	/// </summary>
	/// <typeparam name="E">当前枚举类型</typeparam>
	/// <param name="variable">当前枚举值</param>
	/// <param name="flag">需要保留的枚举标志</param>
	/// <returns>处理后的枚举值</returns>
	/// <exception cref="T:System.ArgumentException">当前枚举变量不是 <see cref="T:System.Enum" /> 类型。</exception>
	public static E KeepFlag<E>(E variable, E flag) where E : struct
	{
		Guard.Assert(typeof(E).IsEnum, "variable", string.Format(Literals.MSG_TypeNotEnum_1, typeof(E).FullName));
		long value = Convert.ToInt64(flag);
		value &= Convert.ToInt64(variable);
		return (E)Enum.ToObject(typeof(E), value);
	}

	/// <summary>
	/// 保留当前枚举值中指定的标志位，清除其他标志位
	/// </summary>
	/// <typeparam name="E">当前枚举类型</typeparam>
	/// <param name="variable">当前枚举值</param>
	/// <param name="flags">需要保留的枚举标志</param>
	/// <returns>处理后的枚举值</returns>
	/// <exception cref="T:System.ArgumentException">当前枚举变量不是 <see cref="T:System.Enum" /> 类型。</exception>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="flags" /> 为空。</exception>
	public static E KeepFlags<E>(E variable, params E[] flags) where E : struct
	{
		Guard.Assert(typeof(E).IsEnum, "variable", string.Format(Literals.MSG_TypeNotEnum_1, typeof(E).FullName));
		Guard.EnsureNotNull(flags, "flags");
		long value = 0L;
		foreach (E flag in flags)
		{
			value |= Convert.ToInt64(flag);
		}
		value &= Convert.ToInt64(variable);
		return (E)Enum.ToObject(typeof(E), value);
	}

	/// <summary>
	/// 向当前 <see cref="T:Richfit.Garnet.Common.Reflection.AccessLevels" /> 类型的枚举中组合指定的枚举值
	/// </summary>
	/// <param name="levels">当前枚举值</param>
	/// <param name="Public">组合 <see cref="F:Richfit.Garnet.Common.Reflection.AccessLevels.Public" /> 枚举值</param>
	/// <param name="FamilyOrAssembly">组合 <see cref="F:Richfit.Garnet.Common.Reflection.AccessLevels.FamilyOrAssembly" /> 枚举值</param>
	/// <param name="Assembly">组合 <see cref="F:Richfit.Garnet.Common.Reflection.AccessLevels.Assembly" /> 枚举值</param>
	/// <param name="Family">组合 <see cref="F:Richfit.Garnet.Common.Reflection.AccessLevels.Family" /> 枚举值</param>
	/// <param name="FamilyAndAssembly">组合 <see cref="F:Richfit.Garnet.Common.Reflection.AccessLevels.FamilyAndAssembly" /> 枚举值</param>
	/// <param name="Private">组合 <see cref="F:Richfit.Garnet.Common.Reflection.AccessLevels.Private" /> 枚举值</param>
	/// <param name="NonPublic">组合 <see cref="F:Richfit.Garnet.Common.Reflection.AccessLevels.NonPublic" /> 枚举值</param>
	/// <param name="Instance">组合 <see cref="F:Richfit.Garnet.Common.Reflection.AccessLevels.Instance" /> 枚举值</param>
	/// <param name="Static">组合 <see cref="F:Richfit.Garnet.Common.Reflection.AccessLevels.Static" /> 枚举值</param>
	/// <param name="Both">组合 <see cref="F:Richfit.Garnet.Common.Reflection.AccessLevels.Both" /> 枚举值</param>
	/// <returns>组合后的枚举值</returns>
	public static AccessLevels Combine(AccessLevels levels, bool Public = false, bool FamilyOrAssembly = false, bool Assembly = false, bool Family = false, bool FamilyAndAssembly = false, bool Private = false, bool NonPublic = false, bool Instance = false, bool Static = false, bool Both = false)
	{
		if (Public)
		{
			levels |= AccessLevels.Public;
		}
		if (FamilyOrAssembly)
		{
			levels |= AccessLevels.FamilyOrAssembly;
		}
		if (Assembly)
		{
			levels |= AccessLevels.Assembly;
		}
		if (Family)
		{
			levels |= AccessLevels.Family;
		}
		if (FamilyAndAssembly)
		{
			levels |= AccessLevels.FamilyAndAssembly;
		}
		if (Private)
		{
			levels |= AccessLevels.Private;
		}
		if (NonPublic)
		{
			levels |= AccessLevels.NonPublic;
		}
		if (Instance)
		{
			levels |= AccessLevels.Instance;
		}
		if (Static)
		{
			levels |= AccessLevels.Static;
		}
		if (Both)
		{
			levels |= AccessLevels.Both;
		}
		return levels;
	}

	/// <summary>
	/// 将访问级别枚举转换为绑定条件
	/// </summary>
	/// <param name="level">访问级别枚举</param>
	/// <returns>绑定条件</returns>
	public static BindingFlags ToBindingFlags(AccessLevels level)
	{
		BindingFlags flags = BindingFlags.Default;
		if (level.HasFlag(AccessLevels.Public))
		{
			flags |= BindingFlags.Public;
		}
		if ((level & AccessLevels.NonPublic) > AccessLevels.Unspecified)
		{
			flags |= BindingFlags.NonPublic;
		}
		if (level.HasFlag(AccessLevels.Instance))
		{
			flags |= BindingFlags.Instance;
		}
		if (level.HasFlag(AccessLevels.Static))
		{
			flags |= BindingFlags.Static;
		}
		return flags;
	}

	/// <summary>
	/// 检测当前访问级别枚举是否具有指定的访问级别的标记
	/// </summary>
	/// <param name="level">当前访问级别枚举</param>
	/// <param name="checkLevel">检测的访问级别枚举</param>
	/// <returns>如果当前访问级别枚举具有指定级别返回true，否则返回false。</returns>
	public static bool HasLevel(AccessLevels level, AccessLevels checkLevel)
	{
		return (level & (AccessLevels)255 & (checkLevel & (AccessLevels)255)) > AccessLevels.Unspecified && (level & (AccessLevels)65280 & (checkLevel & (AccessLevels)65280)) > AccessLevels.Unspecified;
	}

	/// <summary>
	/// 向当前 <see cref="T:System.Reflection.BindingFlags" /> 类型的枚举中组合指定的枚举值
	/// </summary>
	/// <param name="flags">当前枚举值</param>
	/// <param name="IgnoreCase">组合 <see cref="F:System.Reflection.BindingFlags.IgnoreCase" /> 枚举值</param>
	/// <param name="DeclaredOnly">组合 <see cref="F:System.Reflection.BindingFlags.DeclaredOnly" /> 枚举值</param>
	/// <param name="Instance">组合 <see cref="F:System.Reflection.BindingFlags.Instance" /> 枚举值</param>
	/// <param name="Static">组合 <see cref="F:System.Reflection.BindingFlags.Static" /> 枚举值</param>
	/// <param name="Public">组合 <see cref="F:System.Reflection.BindingFlags.Public" /> 枚举值</param>
	/// <param name="NonPublic">组合 <see cref="F:System.Reflection.BindingFlags.NonPublic" /> 枚举值</param>
	/// <param name="FlattenHierarchy">组合 <see cref="F:System.Reflection.BindingFlags.FlattenHierarchy" /> 枚举值</param>
	/// <param name="InvokeMethod">组合 <see cref="F:System.Reflection.BindingFlags.InvokeMethod" /> 枚举值</param>
	/// <param name="CreateInstance">组合 <see cref="F:System.Reflection.BindingFlags.CreateInstance" /> 枚举值</param>
	/// <param name="GetField">组合 <see cref="F:System.Reflection.BindingFlags.GetField" /> 枚举值</param>
	/// <param name="SetField">组合 <see cref="F:System.Reflection.BindingFlags.SetField" /> 枚举值</param>
	/// <param name="GetProperty">组合 <see cref="F:System.Reflection.BindingFlags.GetProperty" /> 枚举值</param>
	/// <param name="SetProperty">组合 <see cref="F:System.Reflection.BindingFlags.SetProperty" /> 枚举值</param>
	/// <param name="PutDispProperty">组合 <see cref="F:System.Reflection.BindingFlags.PutDispProperty" /> 枚举值</param>
	/// <param name="PutRefDispProperty">组合 <see cref="F:System.Reflection.BindingFlags.PutRefDispProperty" /> 枚举值</param>
	/// <param name="ExactBinding">组合 <see cref="F:System.Reflection.BindingFlags.ExactBinding" /> 枚举值</param>
	/// <param name="SuppressChangeType">组合 <see cref="F:System.Reflection.BindingFlags.SuppressChangeType" /> 枚举值</param>
	/// <param name="OptionalParamBinding">组合 <see cref="F:System.Reflection.BindingFlags.OptionalParamBinding" /> 枚举值</param>
	/// <param name="IgnoreReturn">组合 <see cref="F:System.Reflection.BindingFlags.IgnoreReturn" /> 枚举值</param>
	/// <returns>组合后的枚举值</returns>
	public static BindingFlags Combine(BindingFlags flags, bool IgnoreCase = false, bool DeclaredOnly = false, bool Instance = false, bool Static = false, bool Public = false, bool NonPublic = false, bool FlattenHierarchy = false, bool InvokeMethod = false, bool CreateInstance = false, bool GetField = false, bool SetField = false, bool GetProperty = false, bool SetProperty = false, bool PutDispProperty = false, bool PutRefDispProperty = false, bool ExactBinding = false, bool SuppressChangeType = false, bool OptionalParamBinding = false, bool IgnoreReturn = false)
	{
		if (IgnoreCase)
		{
			flags |= BindingFlags.IgnoreCase;
		}
		if (DeclaredOnly)
		{
			flags |= BindingFlags.DeclaredOnly;
		}
		if (Instance)
		{
			flags |= BindingFlags.Instance;
		}
		if (Static)
		{
			flags |= BindingFlags.Static;
		}
		if (Public)
		{
			flags |= BindingFlags.Public;
		}
		if (NonPublic)
		{
			flags |= BindingFlags.NonPublic;
		}
		if (FlattenHierarchy)
		{
			flags |= BindingFlags.FlattenHierarchy;
		}
		if (InvokeMethod)
		{
			flags |= BindingFlags.InvokeMethod;
		}
		if (CreateInstance)
		{
			flags |= BindingFlags.CreateInstance;
		}
		if (GetField)
		{
			flags |= BindingFlags.GetField;
		}
		if (SetField)
		{
			flags |= BindingFlags.SetField;
		}
		if (GetProperty)
		{
			flags |= BindingFlags.GetProperty;
		}
		if (SetProperty)
		{
			flags |= BindingFlags.SetProperty;
		}
		if (PutDispProperty)
		{
			flags |= BindingFlags.PutDispProperty;
		}
		if (PutRefDispProperty)
		{
			flags |= BindingFlags.PutRefDispProperty;
		}
		if (ExactBinding)
		{
			flags |= BindingFlags.ExactBinding;
		}
		if (SuppressChangeType)
		{
			flags |= BindingFlags.SuppressChangeType;
		}
		if (OptionalParamBinding)
		{
			flags |= BindingFlags.OptionalParamBinding;
		}
		if (IgnoreReturn)
		{
			flags |= BindingFlags.IgnoreReturn;
		}
		return flags;
	}

	/// <summary>
	/// 确保当前正则表达式选项枚举具有 LeftToRight 选项
	/// </summary>
	/// <param name="options">当前选项枚举</param>
	/// <returns>处理后的选项枚举</returns>
	public static RegexOptions EnsureLeftToRightOption(RegexOptions options)
	{
		if (options.HasFlag(RegexOptions.RightToLeft))
		{
			return options & ~RegexOptions.RightToLeft;
		}
		return options;
	}

	/// <summary>
	/// 确保当前正则表达式选项枚举具有 RightToLeft 选项
	/// </summary>
	/// <param name="options">当前选项枚举</param>
	/// <returns>处理后的选项枚举</returns>
	public static RegexOptions EnsureRightToLeftOption(RegexOptions options)
	{
		return options | RegexOptions.RightToLeft;
	}

	/// <summary>
	/// 将StringComparison枚举转换为相应的比较器
	/// </summary>
	/// <param name="option">待转换的枚举</param>
	/// <returns>相应规则的比较器</returns>
	public static IEqualityComparer<string> ToComparer(StringComparison option)
	{
		return option switch
		{
			StringComparison.CurrentCulture => StringComparer.CurrentCulture, 
			StringComparison.CurrentCultureIgnoreCase => StringComparer.CurrentCultureIgnoreCase, 
			StringComparison.InvariantCulture => StringComparer.InvariantCulture, 
			StringComparison.InvariantCultureIgnoreCase => StringComparer.InvariantCultureIgnoreCase, 
			StringComparison.Ordinal => StringComparer.Ordinal, 
			StringComparison.OrdinalIgnoreCase => StringComparer.OrdinalIgnoreCase, 
			_ => throw new NotSupportedException(), 
		};
	}

	/// <summary>
	/// 计算当前日期部分的周期数
	/// </summary>
	/// <param name="parts">当前日期部分</param>
	/// <returns>当前日期部分的周期数</returns>
	/// <remarks>每个月按30日计算；每年按12月计算。</remarks>
	public static long GetTicks(DateTimeParts parts)
	{
		long ticks = 0L;
		ticks += (long)(parts & DateTimeParts.Millisecond) / 100L * 10000;
		ticks += (long)(parts & DateTimeParts.Second) / 50L * 10000000;
		ticks += (long)(parts & DateTimeParts.Minute) / 22L * 600000000;
		ticks += (long)(parts & DateTimeParts.Hour) / 8L * 36000000000L;
		ticks += (long)(parts & DateTimeParts.Day) / 4L * 864000000000L;
		ticks += (long)(parts & DateTimeParts.Month) / 2L * 30 * 864000000000L;
		return ticks + (long)(parts & DateTimeParts.Year) / 1L * 30 * 12 * 864000000000L;
	}
}
