using System;
using System.Collections.Generic;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.Properties;

namespace Richfit.Garnet.Common.Collections;

/// <summary>
/// 表示一个值的范围
/// </summary>
public class Range<T> where T : IComparable<T>
{
	/// <summary>
	/// 值比较方法
	/// </summary>
	private Func<T, T, int> comparison;

	/// <summary>
	/// 值范围的终止值
	/// </summary>
	private T end = default(T);

	/// <summary>
	/// 值范围是否包含终止值
	/// </summary>
	private bool endIncluded = false;

	/// <summary>
	/// 值范围终止值的检验方法
	/// </summary>
	private Func<T, bool> endValidating;

	/// <summary>
	/// 值范围的起始值
	/// </summary>
	private T start = default(T);

	/// <summary>
	/// 值范围是否包含起始值
	/// </summary>
	private bool startIncluded = true;

	/// <summary>
	/// 范围起始值的检验方法
	/// </summary>
	private Func<T, bool> startValidating;

	/// <summary>
	/// 获取或者设置值比较方法
	/// </summary>
	public Func<T, T, int> Comparison
	{
		get
		{
			return comparison;
		}
		set
		{
			comparison = value.IfNull(Comparer<T>.Default.Compare);
		}
	}

	/// <summary>
	/// 获取或者设置值范围的终止值
	/// </summary>
	/// <remarks>可以设置 <see cref="P:Richfit.Garnet.Common.Collections.Range`1.EndIncluded" /> 属性来决定值范围是否包含终止值。</remarks>
	public T End
	{
		get
		{
			return end;
		}
		set
		{
			if (EndValidating.IsNotNull() && !EndValidating(value))
			{
				throw new ArgumentException(Literals.MSG_ValueError, "Range End");
			}
			end = value;
		}
	}

	/// <summary>
	/// 获取或者设置值范围是否包含终止值
	/// </summary>
	public bool EndIncluded
	{
		get
		{
			return endIncluded;
		}
		set
		{
			endIncluded = value;
		}
	}

	/// <summary>
	/// 获取或者设置值范围终止值的检验方法
	/// </summary>
	public Func<T, bool> EndValidating
	{
		get
		{
			return endValidating;
		}
		set
		{
			endValidating = value;
		}
	}

	/// <summary>
	/// 获取或者设置值范围的起始值
	/// </summary>
	/// <remarks>可以设置 <see cref="P:Richfit.Garnet.Common.Collections.Range`1.StartIncluded" /> 属性来决定值范围是否包含起始值。</remarks>
	public T Start
	{
		get
		{
			return start;
		}
		set
		{
			if (StartValidating.IsNotNull() && !StartValidating(value))
			{
				throw new ArgumentException(Literals.MSG_ValueError, "Range Start");
			}
			start = value;
		}
	}

	/// <summary>
	/// 获取或者设置值范围是否包含起始值
	/// </summary>
	public bool StartIncluded
	{
		get
		{
			return startIncluded;
		}
		set
		{
			startIncluded = value;
		}
	}

	/// <summary>
	/// 获取或者设置值范围起始值的检验方法。
	/// </summary>
	public Func<T, bool> StartValidating
	{
		get
		{
			return startValidating;
		}
		set
		{
			startValidating = value;
		}
	}

	/// <summary>
	/// 初始化值范围；默认值范围包括起始值，不包括终止值
	/// </summary>
	/// <param name="start">值范围的起始值</param>
	/// <param name="end">值范围的终止值</param>
	public Range(T start, T end)
	{
		Start = start;
		End = end;
		StartIncluded = true;
		EndIncluded = false;
	}

	/// <summary>
	/// 初始化值范围；默认值范围包括起始值，不包括终止值
	/// </summary>
	/// <param name="start">值范围的起始值</param>
	/// <param name="end">值范围的终止值</param>
	/// <param name="comparer">值范围比较器</param>
	public Range(T start, T end, IComparer<T> comparer)
	{
		Start = start;
		End = end;
		StartIncluded = true;
		EndIncluded = false;
		Comparison = (comparer.IsNull() ? null : new Func<T, T, int>(comparer.Compare));
	}

	/// <summary>
	/// 初始化值范围；默认值范围包括起始值，不包括终止值
	/// </summary>
	/// <param name="start">值范围的起始值</param>
	/// <param name="end">值范围的终止值</param>
	/// <param name="comparison">值范围比较方法</param>
	public Range(T start, T end, Func<T, T, int> comparison)
	{
		Start = start;
		End = end;
		StartIncluded = true;
		EndIncluded = false;
		Comparison = comparison;
	}

	/// <summary>
	/// 初始化值范围；默认值范围包括起始值，不包括终止值
	/// </summary>
	/// <param name="range">值范围的起始值和终止值数组；第一个元素为起始值，第二个元素为终止值</param>
	/// <exception cref="T:System.ArgumentNullException">值范围数组 <paramref name="range" /> 为空。</exception>
	public Range(T[] range)
	{
		range.GuardNotNull("range");
		Start = range[0];
		End = range[1];
		StartIncluded = true;
		EndIncluded = false;
	}

	/// <summary>
	/// 初始化值范围；默认值范围包括起始值，不包括终止值
	/// </summary>
	/// <param name="range">值范围的起始值和终止值数组；第一个元素为起始值，第二个元素为终止值</param>
	/// <param name="comparer">值范围比较器</param>
	/// <exception cref="T:System.ArgumentNullException">值范围数组 <paramref name="range" /> 为空。</exception>
	public Range(T[] range, IComparer<T> comparer)
	{
		range.GuardNotNull("range");
		Start = range[0];
		End = range[1];
		StartIncluded = true;
		EndIncluded = false;
		Comparison = (comparer.IsNull() ? null : new Func<T, T, int>(comparer.Compare));
	}

	/// <summary>
	/// 初始化值范围
	/// </summary>
	/// <param name="range">值范围的起始值和终止值数组；第一个元素为起始值，第二个元素为终止值</param>
	/// <param name="comparison">值范围比较方法</param>
	/// <exception cref="T:System.ArgumentNullException">值范围数组 <paramref name="range" /> 为空。</exception>
	public Range(T[] range, Func<T, T, int> comparison)
	{
		range.GuardNotNull("range");
		Start = range[0];
		End = range[1];
		StartIncluded = true;
		EndIncluded = false;
		Comparison = comparison;
	}

	/// <summary>
	/// 初始化值范围；默认值范围包括起始值，不包括终止值
	/// </summary>
	/// <param name="range">值范围的起始值和终止值数组；<see cref="P:System.Tuple`2.Item1" /> 为起始值，<see cref="P:System.Tuple`2.Item2" /> 为终止值</param>
	/// <exception cref="T:System.ArgumentNullException">值范围数组 <paramref name="range" /> 为空。</exception>
	public Range(Tuple<T, T> range)
	{
		range.GuardNotNull("range");
		Start = range.Item1;
		End = range.Item2;
		StartIncluded = true;
		EndIncluded = false;
	}

	/// <summary>
	/// 初始化值范围；默认值范围包括起始值，不包括终止值
	/// </summary>
	/// <param name="range">值范围的起始值和终止值数组；<see cref="P:System.Tuple`2.Item1" /> 为起始值，<see cref="P:System.Tuple`2.Item2" /> 为终止值</param>
	/// <param name="comparer">值范围比较器</param>
	/// <exception cref="T:System.ArgumentNullException">值范围数组 <paramref name="range" /> 为空。</exception>
	public Range(Tuple<T, T> range, IComparer<T> comparer)
	{
		range.GuardNotNull("range");
		Start = range.Item1;
		End = range.Item2;
		StartIncluded = true;
		EndIncluded = false;
		Comparison = (comparer.IsNull() ? null : new Func<T, T, int>(comparer.Compare));
	}

	/// <summary>
	/// 初始化值范围
	/// </summary>
	/// <param name="range">值范围的起始值和终止值数组；<see cref="P:System.Tuple`2.Item1" /> 为起始值，<see cref="P:System.Tuple`2.Item2" /> 为终止值</param>
	/// <param name="comparison">值范围比较方法</param>
	/// <exception cref="T:System.ArgumentNullException">值范围数组 <paramref name="range" /> 为空。</exception>
	public Range(Tuple<T, T> range, Func<T, T, int> comparison)
	{
		range.GuardNotNull("range");
		Start = range.Item1;
		End = range.Item2;
		StartIncluded = true;
		EndIncluded = false;
		Comparison = comparison;
	}

	/// <summary>
	/// 检测指定值是否在当前值范围中
	/// </summary>
	/// <param name="value">检查的指定值</param>
	/// <returns>如果指定在当前值范围内返回true，否则返回false。</returns>
	public bool Contains(T value)
	{
		return (comparison(Start, value) < 0 && comparison(value, End) < 0) || (StartIncluded && comparison(Start, value) == 0) || (EndIncluded && comparison(value, End) == 0);
	}

	/// <summary>
	/// 检测指定的值范围是否包含在当前值范围内
	/// </summary>
	/// <param name="range">检测的值范围</param>
	/// <returns>如果指定的值范围包含在当前值范围内返回true，否则返回false。</returns>
	public bool Contains(Range<T> range)
	{
		return Contains(range.Start) && Contains(range.End);
	}

	/// <summary>
	/// 在当前的值范围内重复执行指定的方法委托
	/// </summary>
	/// <param name="action">执行的方法委托</param>
	/// <param name="increasing">循环递增方法</param>
	/// <exception cref="T:System.ArgumentNullException">方法委托 <paramref name="action" /> 为空；或者循环递增方法 <paramref name="increasing" /> 为空。</exception>
	public void For(Action action, Func<T, T> increasing)
	{
		action.GuardNotNull("action");
		For((Action<T>)delegate
		{
			action();
		}, increasing);
	}

	/// <summary>
	/// 在当前的值范围内重复执行指定的方法委托
	/// </summary>
	/// <param name="action">执行的方法委托</param>
	/// <param name="increasing">循环递增方法</param>
	/// <exception cref="T:System.ArgumentNullException">方法委托 <paramref name="action" /> 为空；或者循环递增方法 <paramref name="increasing" /> 为空。</exception>
	public void For(Action<T> action, Func<T, T> increasing)
	{
		action.GuardNotNull("action");
		increasing.GuardNotNull("increasing");
		T current = start;
		if (!StartIncluded)
		{
			current = increasing(current);
		}
		int status = 0;
		while (true)
		{
			bool flag = true;
			status = comparison(current, End);
			if (status < 0 || (status == 0 && EndIncluded))
			{
				action(current);
				current = increasing(current);
				continue;
			}
			break;
		}
	}

	/// <summary>
	/// 在当前的值范围内重复执行指定的函数委托，并返回结果序列
	/// </summary>
	/// <typeparam name="R">执行的函数委托返回值类型</typeparam>
	/// <param name="evaluation">执行的函数委托</param>
	/// <param name="increasing">循环递增方法</param>
	/// <returns>函数委托重复执行后的结果序列</returns>
	/// <exception cref="T:System.ArgumentNullException">方法委托 <paramref name="evaluation" /> 为空；或者循环递增方法 <paramref name="increasing" /> 为空。</exception>
	public IEnumerable<R> ForEval<R>(Func<R> evaluation, Func<T, T> increasing)
	{
		evaluation.GuardNotNull("evaluation");
		increasing.GuardNotNull("increasing");
		return ForEval((T x) => evaluation(), increasing);
	}

	/// <summary>
	/// 在当前的值范围内重复执行指定的函数委托，并返回结果序列
	/// </summary>
	/// <typeparam name="R">执行的函数委托返回值类型</typeparam>
	/// <param name="evaluation">执行的函数委托</param>
	/// <param name="increasing">循环递增方法</param>
	/// <returns>函数委托重复执行后的结果序列</returns>
	/// <exception cref="T:System.ArgumentNullException">方法委托 <paramref name="evaluation" /> 为空；或者循环递增方法 <paramref name="increasing" /> 为空。</exception>
	public IEnumerable<R> ForEval<R>(Func<T, R> evaluation, Func<T, T> increasing)
	{
		evaluation.GuardNotNull("evaluation");
		increasing.GuardNotNull("increasing");
		T current = start;
		if (!StartIncluded)
		{
			current = increasing(current);
		}
		while (true)
		{
			int status = comparison(current, End);
			if (status < 0 || (status == 0 && EndIncluded))
			{
				yield return evaluation(current);
				current = increasing(current);
				continue;
			}
			break;
		}
	}

	/// <summary>
	/// 将值范围转换为由范围起始值和终止值组成的两个元素的数组
	/// </summary>
	/// <returns>值范围端点数组</returns>
	public T[] ToArray()
	{
		return new T[2] { Start, End };
	}

	/// <summary>
	/// 将值范围转换为由范围起始值和终止值组成的 <see cref="T:System.Tuple`2" /> 结构。
	/// </summary>
	/// <returns>值范围端点结构</returns>
	public Tuple<T, T> ToTuple()
	{
		return Tuple.Create(Start, End);
	}
}
