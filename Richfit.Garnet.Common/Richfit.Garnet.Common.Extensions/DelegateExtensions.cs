using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Richfit.Garnet.Common.Collections;
using Richfit.Garnet.Common.Properties;

namespace Richfit.Garnet.Common.Extensions;

/// <summary>
/// <see cref="T:System.Delegate" /> 委托的扩展方法
/// 1. Delegate类型的扩展方法
/// 2. Action系列委托的扩展方法
/// 3. Func系列委托的扩展方法
/// </summary>
public static class DelegateExtensions
{
	/// <summary>
	/// 将执行当前委托指定次数
	/// </summary>
	/// <param name="handler">当前委托</param>
	/// <param name="count">执行的次数</param>
	/// <param name="parameters">执行参数</param>
	/// <exception cref="T:System.ArgumentNullException">当前执行的委托为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0。</exception>
	public static void For(this Delegate handler, int count, params object[] parameters)
	{
		handler.GuardNotNull("handler");
		count.GuardGreaterThanOrEqualTo(0, "count");
		while (count-- > 0)
		{
			handler.DynamicInvoke(parameters);
		}
	}

	/// <summary>
	/// 将执行当前委托指定次数
	/// </summary>
	/// <param name="handler">当前委托</param>
	/// <param name="count">执行的次数</param>
	/// <param name="parameters">执行参数</param>
	/// <exception cref="T:System.ArgumentNullException">当前执行的委托为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0。</exception>
	public static void ForLong(this Delegate handler, long count, params object[] parameters)
	{
		handler.GuardNotNull("handler");
		count.GuardGreaterThanOrEqualTo(0L, "count");
		while (count-- > 0)
		{
			handler.DynamicInvoke(parameters);
		}
	}

	/// <summary>
	/// 将执行当前委托指定次数，并返回委托的执行结果序列
	/// </summary>
	/// <param name="handler">当前委托</param>
	/// <param name="count">执行的次数</param>
	/// <param name="parameters">执行参数</param>
	/// <returns>委托依次执行后产生的结果序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前执行的委托为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0。</exception>
	public static IEnumerable<object> ForEval(this Delegate handler, int count, params object[] parameters)
	{
		return handler.ForEval<object>(count, parameters);
	}

	/// <summary>
	/// 将执行当前委托指定次数，并返回委托的执行结果序列
	/// </summary>
	/// <param name="handler">当前委托</param>
	/// <param name="count">执行的次数</param>
	/// <param name="parameters">执行参数</param>
	/// <returns>委托依次执行后产生的结果序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前执行的委托为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0。</exception>
	public static IEnumerable<T> ForEval<T>(this Delegate handler, int count, params object[] parameters)
	{
		handler.GuardNotNull("handler");
		count.GuardGreaterThanOrEqualTo(0, "count");
		while (count-- > 0)
		{
			yield return (T)handler.DynamicInvoke(parameters);
		}
	}

	/// <summary>
	/// 将执行当前委托指定次数，并返回委托的执行结果序列
	/// </summary>
	/// <param name="handler">当前委托</param>
	/// <param name="count">执行的次数</param>
	/// <param name="parameters">执行参数</param>
	/// <returns>委托依次执行后产生的结果序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前执行的委托为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0。</exception>
	public static IEnumerable<object> ForEval(this Delegate handler, long count, params object[] parameters)
	{
		return handler.ForEval<object>(count, parameters);
	}

	/// <summary>
	/// 将执行当前委托指定次数，并返回委托的执行结果序列
	/// </summary>
	/// <param name="handler">当前委托</param>
	/// <param name="count">执行的次数</param>
	/// <param name="parameters">执行参数</param>
	/// <returns>委托依次执行后产生的结果序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前执行的委托为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0。</exception>
	public static IEnumerable<T> ForEval<T>(this Delegate handler, long count, params object[] parameters)
	{
		handler.GuardNotNull("handler");
		count.GuardGreaterThanOrEqualTo(0L, "count");
		while (count-- > 0)
		{
			yield return (T)handler.DynamicInvoke(parameters);
		}
	}

	/// <summary>
	/// 将当前的委托执行指定次数
	/// </summary>
	/// <param name="action">当前委托</param>
	/// <param name="count">执行的次数</param>
	/// <exception cref="T:System.ArgumentNullException">当前执行的委托为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0。</exception>
	public static void For(this Action action, int count)
	{
		action.GuardNotNull("action");
		count.GuardGreaterThanOrEqualTo(0, "count");
		while (count-- > 0)
		{
			action();
		}
	}

	/// <summary>
	/// 将当前的委托执行指定次数
	/// </summary>
	/// <param name="action">当前委托</param>
	/// <param name="range">执行计数区间</param>
	/// <exception cref="T:System.ArgumentNullException">当前执行的委托为空。</exception>
	/// <remarks>
	/// 执行的计数区间的起始计数由 <see cref="P:Richfit.Garnet.Common.Collections.Range`1.Start" /> 指定;
	/// 执行的计数区间的终止计数由 <see cref="P:Richfit.Garnet.Common.Collections.Range`1.End" /> 指定;
	/// 执行的计数区间不包含终止计数值本身。
	/// </remarks>
	public static void For(this Action action, Range<int> range)
	{
		action.GuardNotNull("action");
		range.For(action, (int i) => i + 1);
	}

	/// <summary>
	/// 将当前的委托执行指定次数
	/// </summary>
	/// <param name="action">当前委托</param>
	/// <param name="count">执行的次数</param>
	/// <exception cref="T:System.ArgumentNullException">当前执行的委托为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0。</exception>
	public static void ForLong(this Action action, long count)
	{
		action.GuardNotNull("action");
		count.GuardGreaterThanOrEqualTo(0L, "count");
		while (count-- > 0)
		{
			action();
		}
	}

	/// <summary>
	/// 将当前的委托执行指定次数
	/// </summary>
	/// <param name="action">当前委托</param>
	/// <param name="range">执行计数区间</param>
	/// <exception cref="T:System.ArgumentNullException">当前执行的委托为空。</exception>
	/// <remarks>
	/// 执行的计数区间的起始计数由 <see cref="P:Richfit.Garnet.Common.Collections.Range`1.Start" /> 指定;
	/// 执行的计数区间的终止计数由 <see cref="P:Richfit.Garnet.Common.Collections.Range`1.End" /> 指定;
	/// 执行的计数区间不包含终止计数值本身。
	/// </remarks>
	public static void ForLong(this Action action, Range<long> range)
	{
		action.GuardNotNull("action");
		range.For(action, (long i) => i + 1);
	}

	/// <summary>
	/// 将当前的委托执行指定次数
	/// </summary>
	/// <param name="action">当前委托</param>
	/// <param name="count">执行的次数</param>
	/// <exception cref="T:System.ArgumentNullException">当前委托为空。</exception>
	/// <remarks>待执行的委托 <paramref name="action" />, 接收一个 <see cref="T:System.Int32" /> 类型的参数，该参数从0开始累加。</remarks>
	public static void For(this Action<int> action, int count)
	{
		action.GuardNotNull("action");
		action.For(0, count);
	}

	/// <summary>
	/// 将当前的委托执行指定次数
	/// </summary>
	/// <param name="action">当前委托</param>
	/// <param name="start">执行计数起始值</param>
	/// <param name="count">执行计数的数量</param>
	/// <param name="step">累加步进值，默认值为1</param>
	/// <exception cref="T:System.ArgumentNullException">当前委托为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0；或者 <paramref name="step" /> 小于等于0。</exception>
	/// <remarks>待执行的委托 <paramref name="action" />, 接收一个 <see cref="T:System.Int32" /> 类型的参数，该参数表示当前执行的索引次数，从 <paramref name="start" /> 开始累加。</remarks>
	public static void For(this Action<int> action, int start, int count, int step = 1)
	{
		action.GuardNotNull("action");
		count.GuardGreaterThanOrEqualTo(0, "count");
		step.GuardGreaterThan(0, "step");
		int end = start + step * count;
		if (step > 0)
		{
			for (int i = start; i < end; i += step)
			{
				action(i);
			}
			return;
		}
		if (step < 0)
		{
			for (int i = start; i > end; i += step)
			{
				action(i);
			}
			return;
		}
		throw new ArgumentOutOfRangeException("step");
	}

	/// <summary>
	/// 将当前的委托执行指定次数
	/// </summary>
	/// <param name="action">当前委托</param>
	/// <param name="range">执行计数区间</param>
	/// <exception cref="T:System.ArgumentOutOfRangeException">当前委托为空。</exception>
	/// <remarks>
	/// 执行的计数区间的起始计数由 <see cref="P:Richfit.Garnet.Common.Collections.Range`1.Start" /> 指定;
	/// 执行的计数区间的终止计数由 <see cref="P:Richfit.Garnet.Common.Collections.Range`1.End" /> 指定;
	/// 执行的计数区间不包含终止计数值本身。
	/// </remarks>
	public static void For(this Action<int> action, Range<int> range)
	{
		action.GuardNotNull("action");
		range.For(delegate(int i)
		{
			action(i);
		}, (int i) => i + 1);
	}

	/// <summary>
	/// 将当前的委托执行指定次数
	/// </summary>
	/// <param name="action">当前委托</param>
	/// <param name="count">执行的次数</param>
	/// <exception cref="T:System.ArgumentNullException">当前委托为空。</exception>
	/// <remarks>待执行的委托 <paramref name="action" />, 接收一个 <see cref="T:System.Int64" /> 类型的参数，该参数从0开始累加。</remarks>
	public static void ForLong(this Action<long> action, long count)
	{
		action.GuardNotNull("action");
		action.ForLong(0L, count, 1L);
	}

	/// <summary>
	/// 将当前的委托执行指定次数
	/// </summary>
	/// <param name="action">当前委托</param>
	/// <param name="start">执行计数起始值</param>
	/// <param name="count">执行计数的数量</param>
	/// <param name="step">累加步进值，默认值为1</param>
	/// <exception cref="T:System.ArgumentNullException">当前委托为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0；或者 <paramref name="step" /> 小于等于0。</exception>
	/// <remarks>待执行的委托 <paramref name="action" />, 接收一个 <see cref="T:System.Int64" /> 类型的参数，该参数表示当前执行的索引次数，从 <paramref name="start" /> 开始累加。</remarks>
	public static void ForLong(this Action<long> action, long start, long count, long step = 1L)
	{
		action.GuardNotNull("action");
		count.GuardGreaterThanOrEqualTo(0L, "count");
		step.GuardGreaterThan(0L, "step");
		long end = start + step * count;
		if (step > 0)
		{
			for (long i = start; i < end; i += step)
			{
				action(i);
			}
			return;
		}
		if (step < 0)
		{
			for (long i = start; i > end; i += step)
			{
				action(i);
			}
			return;
		}
		throw new ArgumentOutOfRangeException("step");
	}

	/// <summary>
	/// 将当前的委托执行指定次数
	/// </summary>
	/// <param name="action">当前委托</param>
	/// <param name="range">执行计数区间</param>
	/// <exception cref="T:System.ArgumentOutOfRangeException">当前委托为空。</exception>
	/// <remarks>
	/// 执行的计数区间的起始计数由 <see cref="P:Richfit.Garnet.Common.Collections.Range`1.Start" /> 指定;
	/// 执行的计数区间的终止计数由 <see cref="P:Richfit.Garnet.Common.Collections.Range`1.End" /> 指定;
	/// 执行的计数区间不包含终止计数值本身。
	/// </remarks>
	public static void ForLong(this Action<long> action, Range<long> range)
	{
		action.GuardNotNull("action");
		range.For(delegate(long i)
		{
			action(i);
		}, (long i) => i + 1);
	}

	/// <summary>
	/// 在指定的数据源序列上执行当前处理方法委托
	/// </summary>
	/// <typeparam name="T">数据源元素类型</typeparam>
	/// <param name="action">当前委托</param>
	/// <param name="source">指定的数据源序列</param>
	/// <exception cref="T:System.ArgumentNullException">当前委托为空；或者 <paramref name="source" /> 为空。</exception>
	public static void For<T>(this Action<T> action, IEnumerable<T> source)
	{
		action.GuardNotNull("action");
		source.GuardNotNull("source");
		foreach (T item in source)
		{
			action(item);
		}
	}

	/// <summary>
	/// 在指定的数据源序列上执行当前处理方法委托
	/// </summary>
	/// <typeparam name="T">数据源元素类型</typeparam>
	/// <param name="action">当前委托</param>
	/// <param name="source">指定的数据源序列</param>
	/// <param name="count">需要处理的数据源元素个数</param>
	/// <exception cref="T:System.ArgumentNullException">当前委托为空；或者 <paramref name="source" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0。</exception>
	public static void For<T>(this Action<T> action, IEnumerable<T> source, int count)
	{
		action.GuardNotNull("action");
		source.GuardNotNull("source");
		count.GuardGreaterThanOrEqualTo(0);
		foreach (T item in source.Take(count))
		{
			action(item);
		}
	}

	/// <summary>
	/// 在指定的数据源序列上执行当前处理方法委托
	/// </summary>
	/// <typeparam name="T">数据源元素类型</typeparam>
	/// <param name="action">当前委托</param>
	/// <param name="source">指定的数据源序列</param>
	/// <param name="start">需要处理的数据源元素起始索引</param>
	/// <param name="count">需要处理的数据源元素个数</param>
	/// <exception cref="T:System.ArgumentNullException">当前委托为空；或者 <paramref name="source" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="start" /> 小于0；或者 <paramref name="count" /> 小于0。</exception>
	public static void For<T>(this Action<T> action, IEnumerable<T> source, int start, int count)
	{
		action.GuardNotNull("action");
		source.GuardNotNull("source");
		start.GuardGreaterThanOrEqualTo(0, "start");
		count.GuardGreaterThanOrEqualTo(0, "count");
		foreach (T item in source.Skip(start).Take(count))
		{
			action(item);
		}
	}

	/// <summary>
	/// 在指定的数据源序列上执行当前处理方法委托
	/// </summary>
	/// <typeparam name="T">数据源元素类型</typeparam>
	/// <param name="action">当前委托</param>
	/// <param name="source">指定的数据源序列</param>
	/// <exception cref="T:System.ArgumentNullException">当前委托为空；或者 <paramref name="source" /> 为空。</exception>
	public static void ForLong<T>(this Action<T> action, IEnumerable<T> source)
	{
		action.GuardNotNull("action");
		source.GuardNotNull("source");
		foreach (T item in source)
		{
			action(item);
		}
	}

	/// <summary>
	/// 在指定的数据源序列上执行当前处理方法委托
	/// </summary>
	/// <typeparam name="T">数据源元素类型</typeparam>
	/// <param name="action">当前委托</param>
	/// <param name="source">指定的数据源序列</param>
	/// <param name="count">需要处理的数据源元素个数</param>
	/// <exception cref="T:System.ArgumentNullException">当前委托为空；或者 <paramref name="source" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0。</exception>
	public static void ForLong<T>(this Action<T> action, IEnumerable<T> source, long count)
	{
		action.GuardNotNull("action");
		source.GuardNotNull("source");
		count.GuardGreaterThanOrEqualTo(0L);
		foreach (T item in source.TakeLong(count))
		{
			action(item);
		}
	}

	/// <summary>
	/// 在指定的数据源序列上执行当前处理方法委托
	/// </summary>
	/// <typeparam name="T">数据源元素类型</typeparam>
	/// <param name="action">当前委托</param>
	/// <param name="source">指定的数据源序列</param>
	/// <param name="start">需要处理的数据源元素起始索引</param>
	/// <param name="count">需要处理的数据源元素个数</param>
	/// <exception cref="T:System.ArgumentNullException">当前委托为空；或者 <paramref name="source" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="start" /> 小于0；或者 <paramref name="count" /> 小于0。</exception>
	public static void ForLong<T>(this Action<T> action, IEnumerable<T> source, long start, long count)
	{
		action.GuardNotNull("action");
		source.GuardNotNull("source");
		start.GuardGreaterThanOrEqualTo(0L, "start");
		count.GuardGreaterThanOrEqualTo(0L, "count");
		foreach (T item in source.SkipLong(start).TakeLong(count))
		{
			action(item);
		}
	}

	/// <summary>
	/// 在指定的数据源序列上执行当前处理方法委托
	/// </summary>
	/// <typeparam name="T">数据源元素类型</typeparam>
	/// <param name="action">当前委托</param>
	/// <param name="source">指定的数据源序列</param>
	/// <exception cref="T:System.ArgumentNullException">当前委托为空；或者 <paramref name="source" /> 为空。</exception>
	/// <remarks>当前委托接收当前数据元素和当前数据元素到处理开始位置的偏移量作为参数。</remarks>
	public static void For<T>(this Action<T, int> action, IEnumerable<T> source)
	{
		action.GuardNotNull("action");
		source.GuardNotNull("source");
		int index = 0;
		foreach (T item in source)
		{
			action(item, index++);
		}
	}

	/// <summary>
	/// 在指定的数据源序列上执行当前处理方法委托
	/// </summary>
	/// <typeparam name="T">数据源元素类型</typeparam>
	/// <param name="action">当前委托</param>
	/// <param name="source">指定的数据源序列</param>
	/// <param name="count">需要处理的数据源元素个数</param>
	/// <exception cref="T:System.ArgumentNullException">当前委托为空；或者 <paramref name="source" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0。</exception>
	/// <remarks>当前委托接收当前数据元素和当前数据元素到处理开始位置的偏移量作为参数。</remarks>
	public static void For<T>(this Action<T, int> action, IEnumerable<T> source, int count)
	{
		action.GuardNotNull("action");
		source.GuardNotNull("source");
		count.GuardGreaterThanOrEqualTo(0);
		int index = 0;
		foreach (T item in source.Take(count))
		{
			action(item, index++);
		}
	}

	/// <summary>
	/// 在指定的数据源序列上执行当前处理方法委托
	/// </summary>
	/// <typeparam name="T">数据源元素类型</typeparam>
	/// <param name="action">当前委托</param>
	/// <param name="source">指定的数据源序列</param>
	/// <param name="start">需要处理的数据源元素起始索引</param>
	/// <param name="count">需要处理的数据源元素个数</param>
	/// <exception cref="T:System.ArgumentNullException">当前委托为空；或者 <paramref name="source" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="start" /> 小于0；或者 <paramref name="count" /> 小于0。</exception>
	/// <remarks>当前委托接收当前数据元素和当前数据元素到处理开始位置的偏移量作为参数。</remarks>
	public static void For<T>(this Action<T, int> action, IEnumerable<T> source, int start, int count)
	{
		action.GuardNotNull("action");
		source.GuardNotNull("source");
		start.GuardGreaterThanOrEqualTo(0, "start");
		count.GuardGreaterThanOrEqualTo(0, "count");
		int index = 0;
		foreach (T item in source.Skip(start).Take(count))
		{
			action(item, index++);
		}
	}

	/// <summary>
	/// 在指定的数据源序列上执行当前处理方法委托
	/// </summary>
	/// <typeparam name="T">数据源元素类型</typeparam>
	/// <param name="action">当前委托</param>
	/// <param name="source">指定的数据源序列</param>
	/// <exception cref="T:System.ArgumentNullException">当前委托为空；或者 <paramref name="source" /> 为空。</exception>
	/// <remarks>当前委托接收当前数据元素和当前数据元素到处理开始位置的偏移量作为参数。</remarks>
	public static void ForLong<T>(this Action<T, long> action, IEnumerable<T> source)
	{
		action.GuardNotNull("action");
		source.GuardNotNull("source");
		long index = 0L;
		foreach (T item in source)
		{
			action(item, index++);
		}
	}

	/// <summary>
	/// 在指定的数据源序列上执行当前处理方法委托
	/// </summary>
	/// <typeparam name="T">数据源元素类型</typeparam>
	/// <param name="action">当前委托</param>
	/// <param name="source">指定的数据源序列</param>
	/// <param name="count">需要处理的数据源元素个数</param>
	/// <exception cref="T:System.ArgumentNullException">当前委托为空；或者 <paramref name="source" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0。</exception>
	/// <remarks>当前委托接收当前数据元素和当前数据元素到处理开始位置的偏移量作为参数。</remarks>
	public static void ForLong<T>(this Action<T, long> action, IEnumerable<T> source, long count)
	{
		action.GuardNotNull("action");
		source.GuardNotNull("source");
		count.GuardGreaterThanOrEqualTo(0L);
		long index = 0L;
		foreach (T item in source.TakeLong(count))
		{
			action(item, index++);
		}
	}

	/// <summary>
	/// 在指定的数据源序列上执行当前处理方法委托
	/// </summary>
	/// <typeparam name="T">数据源元素类型</typeparam>
	/// <param name="action">当前委托</param>
	/// <param name="source">指定的数据源序列</param>
	/// <param name="start">需要处理的数据源元素起始索引</param>
	/// <param name="count">需要处理的数据源元素个数</param>
	/// <exception cref="T:System.ArgumentNullException">当前委托为空；或者 <paramref name="source" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="start" /> 小于0；或者 <paramref name="count" /> 小于0。</exception>
	/// <remarks>当前委托接收当前数据元素和当前数据元素到处理开始位置的偏移量作为参数。</remarks>
	public static void ForLong<T>(this Action<T, long> action, IEnumerable<T> source, long start, long count)
	{
		action.GuardNotNull("action");
		source.GuardNotNull("source");
		start.GuardGreaterThanOrEqualTo(0L, "start");
		count.GuardGreaterThanOrEqualTo(0L, "count");
		long index = 0L;
		foreach (T item in source.SkipLong(start).TakeLong(count))
		{
			action(item, index++);
		}
	}

	/// <summary>
	/// 将当前的函数委托执行指定次数，并返回结果序列
	/// </summary>
	/// <typeparam name="R">函数委托结果类型</typeparam>
	/// <param name="func">当前函数委托</param>
	/// <param name="count">执行的次数</param>
	/// <returns>函数委托的结果序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前函数委托为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0；</exception>
	/// <remarks>返回结果序列实现延迟处理，当遍历结果序列时才会实际计算结果序列。</remarks>
	public static IEnumerable<R> ForEval<R>(this Func<R> func, int count)
	{
		func.GuardNotNull("func");
		count.GuardGreaterThanOrEqualTo(0, "count");
		while (count-- > 0)
		{
			yield return func();
		}
	}

	/// <summary>
	/// 将当前的函数委托执行指定次数，并返回结果序列
	/// </summary>
	/// <typeparam name="R">函数委托结果类型</typeparam>
	/// <param name="func">当前函数委托</param>
	/// <param name="range">执行计数区间</param>
	/// <returns>函数委托的结果序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前函数委托为空。</exception>
	/// <remarks>
	/// 执行的计数区间的起始计数由 <see cref="P:Richfit.Garnet.Common.Collections.Range`1.Start" /> 指定;
	/// 执行的计数区间的终止计数由 <see cref="P:Richfit.Garnet.Common.Collections.Range`1.End" /> 指定;
	/// 执行的计数区间不包含终止计数值本身。
	/// </remarks>
	public static IEnumerable<R> ForEval<R>(this Func<R> func, Range<int> range)
	{
		func.GuardNotNull("func");
		return range.ForEval(func, (int i) => i + 1);
	}

	/// <summary>
	/// 将当前的函数委托执行指定次数，并返回结果序列
	/// </summary>
	/// <typeparam name="R">函数委托结果类型</typeparam>
	/// <param name="func">当前函数委托</param>
	/// <param name="count">执行的次数</param>
	/// <returns>函数委托的结果序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前函数委托为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0；</exception>
	/// <remarks>返回结果序列实现延迟处理，当遍历结果序列时才会实际计算结果序列。</remarks>
	public static IEnumerable<R> ForEvalLong<R>(this Func<R> func, long count)
	{
		func.GuardNotNull("func");
		count.GuardGreaterThanOrEqualTo(0L, "count");
		while (count-- > 0)
		{
			yield return func();
		}
	}

	/// <summary>
	/// 将当前的函数委托执行指定次数，并返回结果序列
	/// </summary>
	/// <typeparam name="R">函数委托结果类型</typeparam>
	/// <param name="func">当前函数委托</param>
	/// <param name="range">执行计数区间</param>
	/// <returns>函数委托的结果序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前函数委托为空。</exception>
	/// <remarks>
	/// 执行的计数区间的起始计数由 <see cref="P:Richfit.Garnet.Common.Collections.Range`1.Start" /> 指定;
	/// 执行的计数区间的终止计数由 <see cref="P:Richfit.Garnet.Common.Collections.Range`1.End" /> 指定;
	/// 执行的计数区间不包含终止计数值本身。
	/// </remarks>
	public static IEnumerable<R> ForEvalLong<R>(this Func<R> func, Range<long> range)
	{
		func.GuardNotNull("func");
		return range.ForEval(func, (long i) => i + 1);
	}

	/// <summary>
	/// 将当前的函数委托执行指定次数，并返回结果序列
	/// </summary>
	/// <typeparam name="R">函数委托结果类型</typeparam>
	/// <param name="func">当前函数委托</param>
	/// <param name="count">执行的次数</param>
	/// <returns>函数委托的结果序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前函数委托为空。</exception>
	/// <remarks>待执行的函数委托 <paramref name="func" />, 接收一个 <see cref="T:System.Int32" /> 类型的参数；该参数从0开始累加。</remarks>
	public static IEnumerable<R> ForEval<R>(this Func<int, R> func, int count)
	{
		return func.ForEval(0, count);
	}

	/// <summary>
	/// 将当前的函数委托指定指定的次数，并返回结果序列
	/// </summary>
	/// <typeparam name="R">函数委托结果类型</typeparam>
	/// <param name="func">当前函数委托</param>
	/// <param name="start">执行计数起始值</param>
	/// <param name="count">执行计数的数量</param>
	/// <param name="step">累加步进值，默认值为1</param>
	/// <returns>函数委托的结果序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前函数委托为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0；或者 <paramref name="step" /> 小于等于0。</exception>
	/// <remarks>待执行的函数委托 <paramref name="func" />, 接收一个 <see cref="T:System.Int32" /> 类型的参数，该参数表示当前执行的索引次数，从 <paramref name="start" /> 开始累加。</remarks>
	public static IEnumerable<R> ForEval<R>(this Func<int, R> func, int start, int count, int step = 1)
	{
		func.GuardNotNull("func");
		count.GuardGreaterThanOrEqualTo(0, "count");
		step.GuardNotEqualTo(0, "step");
		int end = start + step * count;
		if (step > 0)
		{
			for (int j = start; j < end; j += step)
			{
				yield return func(j);
			}
			yield break;
		}
		if (step < 0)
		{
			for (int i = start; i > end; i += step)
			{
				yield return func(i);
			}
			yield break;
		}
		throw new ArgumentOutOfRangeException("step");
	}

	/// <summary>
	/// 将当前的函数委托指定指定的次数，并返回结果序列
	/// </summary>
	/// <typeparam name="R">函数委托结果类型</typeparam>
	/// <param name="func">当前函数委托</param>
	/// <param name="range">执行计数区间</param>
	/// <returns>函数委托的结果序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前委托为空。</exception>
	/// <remarks>
	/// 执行的计数区间的起始计数由 <see cref="P:Richfit.Garnet.Common.Collections.Range`1.Start" /> 指定;
	/// 执行的计数区间的终止计数由 <see cref="P:Richfit.Garnet.Common.Collections.Range`1.End" /> 指定;
	/// 执行的计数区间不包含终止计数值本身。
	/// </remarks>
	public static IEnumerable<R> ForEval<R>(this Func<int, R> func, Range<int> range)
	{
		func.GuardNotNull("func");
		return range.ForEval(func, (int i) => i + 1);
	}

	/// <summary>
	/// 将当前的函数委托执行指定次数，并返回结果序列
	/// </summary>
	/// <typeparam name="R">函数委托结果类型</typeparam>
	/// <param name="func">当前函数委托</param>
	/// <param name="count">执行的次数</param>
	/// <returns>函数委托的结果序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前函数委托为空。</exception>
	/// <remarks>待执行的函数委托 <paramref name="func" />, 接收一个 <see cref="T:System.Int64" /> 类型的参数；该参数从0开始累加。</remarks>
	public static IEnumerable<R> ForEvalLong<R>(this Func<long, R> func, long count)
	{
		return func.ForEvalLong(0L, count, 1L);
	}

	/// <summary>
	/// 将当前的函数委托指定指定的次数，并返回结果序列
	/// </summary>
	/// <typeparam name="R">函数委托结果类型</typeparam>
	/// <param name="func">当前函数委托</param>
	/// <param name="start">执行计数起始值</param>
	/// <param name="count">执行计数的数量</param>
	/// <param name="step">累加步进值，默认值为1</param>
	/// <returns>函数委托的结果序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前函数委托为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0；或者 <paramref name="step" /> 小于等于0。</exception>
	/// <remarks>待执行的函数委托 <paramref name="func" />, 接收一个 <see cref="T:System.Int64" /> 类型的参数，该参数表示当前执行的索引次数，从 <paramref name="start" /> 开始累加。</remarks>
	public static IEnumerable<R> ForEvalLong<R>(this Func<long, R> func, long start, long count, long step = 1L)
	{
		func.GuardNotNull("func");
		count.GuardGreaterThanOrEqualTo(0L, "count");
		step.GuardNotEqualTo(0L, "step");
		long end = start + step * count;
		if (step > 0)
		{
			for (long j = start; j < end; j += step)
			{
				yield return func(j);
			}
			yield break;
		}
		if (step < 0)
		{
			for (long i = start; i > end; i += step)
			{
				yield return func(i);
			}
			yield break;
		}
		throw new ArgumentOutOfRangeException("step");
	}

	/// <summary>
	/// 将当前的函数委托指定指定的次数，并返回结果序列
	/// </summary>
	/// <typeparam name="R">函数委托结果类型</typeparam>
	/// <param name="func">当前函数委托</param>
	/// <param name="range">执行计数区间</param>
	/// <returns>函数委托的结果序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前委托为空。</exception>
	/// <remarks>
	/// 执行的计数区间的起始计数由 <see cref="P:Richfit.Garnet.Common.Collections.Range`1.Start" /> 指定;
	/// 执行的计数区间的终止计数由 <see cref="P:Richfit.Garnet.Common.Collections.Range`1.End" /> 指定;
	/// 执行的计数区间不包含终止计数值本身。
	/// </remarks>
	public static IEnumerable<R> ForEvalLong<R>(this Func<long, R> func, Range<long> range)
	{
		func.GuardNotNull("func");
		return range.ForEval(func, (long i) => i + 1);
	}

	/// <summary>
	/// 在指定的数据源序列上执行当前函数委托，并返回处理结果序列
	/// </summary>
	/// <typeparam name="T">数据源元素类型</typeparam>
	/// <typeparam name="R">函数委托返回值类型</typeparam>
	/// <param name="func">当前函数委托</param>
	/// <param name="source">指定的数据源序列</param>
	/// <returns>函数委托处理结果序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前函数委托为空；<paramref name="source" /> 为空。</exception>
	public static IEnumerable<R> ForEval<T, R>(this Func<T, R> func, IEnumerable<T> source)
	{
		func.GuardNotNull("func");
		source.GuardNotNull("source");
		foreach (T item in source)
		{
			yield return func(item);
		}
	}

	/// <summary>
	/// 在指定的数据源序列上执行当前函数委托，并返回处理结果序列
	/// </summary>
	/// <typeparam name="T">数据源元素类型</typeparam>
	/// <typeparam name="R">函数委托返回值类型</typeparam>
	/// <param name="func">当前函数委托</param>
	/// <param name="source">指定的数据源序列</param>
	/// <param name="count">需要处理的数据源元素个数</param>
	/// <returns>函数委托处理结果序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前函数委托为空；或者 <paramref name="source" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0。</exception>
	public static IEnumerable<R> ForEval<T, R>(this Func<T, R> func, IEnumerable<T> source, int count)
	{
		func.GuardNotNull("func");
		source.GuardNotNull("source");
		count.GuardGreaterThanOrEqualTo(0, "count");
		foreach (T item in source.Take(count))
		{
			yield return func(item);
		}
	}

	/// <summary>
	/// 在指定的数据源序列上执行当前函数委托，并返回处理结果序列
	/// </summary>
	/// <typeparam name="T">数据源元素类型</typeparam>
	/// <typeparam name="R">函数委托返回值类型</typeparam>
	/// <param name="func">当前函数委托</param>
	/// <param name="source">指定的数据源序列</param>
	/// <param name="start">需要处理的数据源元素起始索引</param>
	/// <param name="count">需要处理的数据源元素个数</param>
	/// <returns>函数委托处理结果序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前函数委托为空；或者 <paramref name="source" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="start" /> 小于0；或者 <paramref name="count" /> 小于0。</exception>
	public static IEnumerable<R> ForEval<T, R>(this Func<T, R> func, IEnumerable<T> source, int start, int count)
	{
		func.GuardNotNull("func");
		source.GuardNotNull("source");
		start.GuardGreaterThanOrEqualTo(0, "start");
		count.GuardGreaterThanOrEqualTo(0, "count");
		foreach (T item in source.Skip(start).Take(count))
		{
			yield return func(item);
		}
	}

	/// <summary>
	/// 在指定的数据源序列上执行当前函数委托，并返回处理结果序列
	/// </summary>
	/// <typeparam name="T">数据源元素类型</typeparam>
	/// <typeparam name="R">函数委托返回值类型</typeparam>
	/// <param name="func">当前函数委托</param>
	/// <param name="source">指定的数据源序列</param>
	/// <returns>函数委托处理结果序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前函数委托为空；<paramref name="source" /> 为空。</exception>
	public static IEnumerable<R> ForEvalLong<T, R>(this Func<T, R> func, IEnumerable<T> source)
	{
		func.GuardNotNull("func");
		source.GuardNotNull("source");
		foreach (T item in source)
		{
			yield return func(item);
		}
	}

	/// <summary>
	/// 在指定的数据源序列上执行当前函数委托，并返回处理结果序列
	/// </summary>
	/// <typeparam name="T">数据源元素类型</typeparam>
	/// <typeparam name="R">函数委托返回值类型</typeparam>
	/// <param name="func">当前函数委托</param>
	/// <param name="source">指定的数据源序列</param>
	/// <param name="count">需要处理的数据源元素个数</param>
	/// <returns>函数委托处理结果序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前函数委托为空；或者 <paramref name="source" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0。</exception>
	public static IEnumerable<R> ForEvalLong<T, R>(this Func<T, R> func, IEnumerable<T> source, long count)
	{
		func.GuardNotNull("func");
		source.GuardNotNull("source");
		count.GuardGreaterThanOrEqualTo(0L, "count");
		foreach (T item in source.TakeLong(count))
		{
			yield return func(item);
		}
	}

	/// <summary>
	/// 在指定的数据源序列上执行当前函数委托，并返回处理结果序列
	/// </summary>
	/// <typeparam name="T">数据源元素类型</typeparam>
	/// <typeparam name="R">函数委托返回值类型</typeparam>
	/// <param name="func">当前函数委托</param>
	/// <param name="source">指定的数据源序列</param>
	/// <param name="start">需要处理的数据源元素起始索引</param>
	/// <param name="count">需要处理的数据源元素个数</param>
	/// <returns>函数委托处理结果序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前函数委托为空；或者 <paramref name="source" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="start" /> 小于0；或者 <paramref name="count" /> 小于0。</exception>
	public static IEnumerable<R> ForEvalLong<T, R>(this Func<T, R> func, IEnumerable<T> source, long start, long count)
	{
		func.GuardNotNull("func");
		source.GuardNotNull("source");
		start.GuardGreaterThanOrEqualTo(0L, "start");
		count.GuardGreaterThanOrEqualTo(0L, "count");
		foreach (T item in source.SkipLong(start).TakeLong(count))
		{
			yield return func(item);
		}
	}

	/// <summary>
	/// 在指定的数据源序列上执行当前函数委托，并返回处理结果序列
	/// </summary>
	/// <typeparam name="T">数据源元素类型</typeparam>
	/// <typeparam name="R">函数委托返回值类型</typeparam>
	/// <param name="func">当前函数委托</param>
	/// <param name="source">指定的数据源序列</param>
	/// <returns>函数委托处理结果序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前函数委托为空；或者 <paramref name="source" /> 为空。</exception>
	/// <remarks>当前函数委托接收当前数据元素和当前数据元素到处理开始位置的偏移量作为参数</remarks>
	public static IEnumerable<R> ForEval<T, R>(this Func<T, int, R> func, IEnumerable<T> source)
	{
		func.GuardNotNull("func");
		source.GuardNotNull("source");
		int index = 0;
		foreach (T item in source)
		{
			yield return func(item, index++);
		}
	}

	/// <summary>
	/// 在指定的数据源序列上执行当前函数委托，并返回处理结果序列
	/// </summary>
	/// <typeparam name="T">数据源元素类型</typeparam>
	/// <typeparam name="R">函数委托返回值类型</typeparam>
	/// <param name="func">当前函数委托</param>
	/// <param name="source">指定的数据源序列</param>
	/// <param name="count">需要处理的数据源元素个数</param>
	/// <returns>函数委托处理结果序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前函数委托为空；或者 <paramref name="source" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0。</exception>
	/// <remarks>当前函数委托接收当前数据元素和当前数据元素到处理开始位置的偏移量作为参数</remarks>
	public static IEnumerable<R> ForEval<T, R>(this Func<T, int, R> func, IEnumerable<T> source, int count)
	{
		func.GuardNotNull("func");
		source.GuardNotNull("source");
		count.GuardGreaterThanOrEqualTo(0, "count");
		int index = 0;
		foreach (T item in source.Take(count))
		{
			yield return func(item, index++);
		}
	}

	/// <summary>
	/// 在指定的数据源序列上执行当前函数委托，并返回处理结果序列
	/// </summary>
	/// <typeparam name="T">数据源元素类型</typeparam>
	/// <typeparam name="R">函数委托返回值类型</typeparam>
	/// <param name="func">当前函数委托</param>
	/// <param name="source">指定的数据源序列</param>
	/// <param name="start">需要处理的数据源元素起始索引</param>
	/// <param name="count">需要处理的数据源元素个数</param>
	/// <returns>函数委托处理结果序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前函数委托为空；或者 <paramref name="source" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="start" /> 小于0；或者 <paramref name="count" /> 小于0。</exception>
	/// <remarks>当前函数委托接收当前数据元素和当前数据元素到处理开始位置的偏移量作为参数</remarks>
	public static IEnumerable<R> ForEval<T, R>(this Func<T, int, R> func, IEnumerable<T> source, int start, int count)
	{
		func.GuardNotNull("func");
		source.GuardNotNull("source");
		start.GuardGreaterThanOrEqualTo(0, "start");
		count.GuardGreaterThanOrEqualTo(0, "count");
		int index = 0;
		foreach (T item in source.Skip(start).Take(count))
		{
			yield return func(item, index++);
		}
	}

	/// <summary>
	/// 在指定的数据源序列上执行当前函数委托，并返回处理结果序列
	/// </summary>
	/// <typeparam name="T">数据源元素类型</typeparam>
	/// <typeparam name="R">函数委托返回值类型</typeparam>
	/// <param name="func">当前函数委托</param>
	/// <param name="source">指定的数据源序列</param>
	/// <returns>函数委托处理结果序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前函数委托为空；或者 <paramref name="source" /> 为空。</exception>
	/// <remarks>当前函数委托接收当前数据元素和当前数据元素到处理开始位置的偏移量作为参数</remarks>
	public static IEnumerable<R> ForEvalLong<T, R>(this Func<T, long, R> func, IEnumerable<T> source)
	{
		func.GuardNotNull("func");
		source.GuardNotNull("source");
		long index = 0L;
		foreach (T item in source)
		{
			yield return func(item, index++);
		}
	}

	/// <summary>
	/// 在指定的数据源序列上执行当前函数委托，并返回处理结果序列
	/// </summary>
	/// <typeparam name="T">数据源元素类型</typeparam>
	/// <typeparam name="R">函数委托返回值类型</typeparam>
	/// <param name="func">当前函数委托</param>
	/// <param name="source">指定的数据源序列</param>
	/// <param name="count">需要处理的数据源元素个数</param>
	/// <returns>函数委托处理结果序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前函数委托为空；或者 <paramref name="source" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0。</exception>
	/// <remarks>当前函数委托接收当前数据元素和当前数据元素到处理开始位置的偏移量作为参数</remarks>
	public static IEnumerable<R> ForEvalLong<T, R>(this Func<T, long, R> func, IEnumerable<T> source, long count)
	{
		func.GuardNotNull("func");
		source.GuardNotNull("source");
		count.GuardGreaterThanOrEqualTo(0L, "count");
		long index = 0L;
		foreach (T item in source.TakeLong(count))
		{
			yield return func(item, index++);
		}
	}

	/// <summary>
	/// 在指定的数据源序列上执行当前函数委托，并返回处理结果序列
	/// </summary>
	/// <typeparam name="T">数据源元素类型</typeparam>
	/// <typeparam name="R">函数委托返回值类型</typeparam>
	/// <param name="func">当前函数委托</param>
	/// <param name="source">指定的数据源序列</param>
	/// <param name="start">需要处理的数据源元素起始索引</param>
	/// <param name="count">需要处理的数据源元素个数</param>
	/// <returns>函数委托处理结果序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前函数委托为空；或者 <paramref name="source" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="start" /> 小于0；或者 <paramref name="count" /> 小于0。</exception>
	/// <remarks>当前函数委托接收当前数据元素和当前数据元素到处理开始位置的偏移量作为参数</remarks>
	public static IEnumerable<R> ForEvalLong<T, R>(this Func<T, long, R> func, IEnumerable<T> source, long start, long count)
	{
		func.GuardNotNull("func");
		source.GuardNotNull("source");
		start.GuardGreaterThanOrEqualTo(0L, "start");
		count.GuardGreaterThanOrEqualTo(0L, "count");
		long index = 0L;
		foreach (T item in source.SkipLong(start).TakeLong(count))
		{
			yield return func(item, index++);
		}
	}

	/// <summary>
	/// 并行执行当前方法委托，执行指定的次数
	/// </summary>
	/// <param name="action">当前方法委托</param>
	/// <param name="count">运行的次数</param>
	/// <param name="options">执行参数对象，如果设置为空则忽略参数</param>
	/// <returns>有关已完成的循环部分的信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前方法委托为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0。</exception>
	public static ParallelLoopResult ForParallel(this Action action, int count, ParallelOptions options = null)
	{
		action.GuardNotNull("action");
		count.GuardGreaterThanOrEqualTo(0);
		if (options.IsNull())
		{
			return Parallel.For(0, count, (Action<int>)delegate
			{
				action();
			});
		}
		return Parallel.For(0, count, options, (Action<int>)delegate
		{
			action();
		});
	}

	/// <summary>
	/// 并行执行当前方法委托，执行指定的次数
	/// </summary>
	/// <param name="action">当前方法委托</param>
	/// <param name="count">运行的次数</param>
	/// <param name="options">执行参数对象，如果设置为空则忽略参数</param>
	/// <returns>有关已完成的循环部分的信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前方法委托为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0。</exception>
	/// <remarks>待执行的方法委托 <paramref name="action" />, 接收一个 <see cref="T:System.Int32" /> 类型的参数；该参数表示当前执行的次数，从1开始累加，直到 <paramref name="count" />。</remarks>
	public static ParallelLoopResult ForParallel(this Action<int> action, int count, ParallelOptions options = null)
	{
		action.GuardNotNull("action");
		count.GuardGreaterThanOrEqualTo(0);
		if (options.IsNull())
		{
			return Parallel.For(1, count + 1, action);
		}
		return Parallel.For(1, count + 1, options, action);
	}

	/// <summary>
	/// 并行执行当前方法委托，执行指定的次数
	/// </summary>
	/// <param name="action">当前方法委托</param>
	/// <param name="start">开始的索引</param>
	/// <param name="count">运行的次数</param>
	/// <param name="options">执行参数对象，如果设置为空则忽略参数</param>
	/// <returns>有关已完成的循环部分的信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前方法委托为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0。</exception>
	/// <remarks>待执行的方法委托 <paramref name="action" />, 接收一个 <see cref="T:System.Int32" /> 类型的参数，该参数表示当前执行的索引次数，从 <paramref name="start" /> 开始累加。</remarks>
	public static ParallelLoopResult ForParallel(this Action<int> action, int start, int count, ParallelOptions options = null)
	{
		action.GuardNotNull("action");
		count.GuardGreaterThanOrEqualTo(0);
		if (options.IsNull())
		{
			return Parallel.For(start, start + count, action);
		}
		return Parallel.For(start, start + count, options, action);
	}

	/// <summary>
	/// 并行执行当前方法委托，执行指定的次数
	/// </summary>
	/// <param name="action">当前方法委托</param>
	/// <param name="count">运行的次数</param>
	/// <param name="options">执行参数对象，如果设置为空则忽略参数</param>
	/// <returns>有关已完成的循环部分的信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前方法委托为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0。</exception>
	/// <remarks>待执行的方法委托 <paramref name="action" />, 接收的 <see cref="T:System.Int32" /> 类型的参数表示当前执行的次数，从1开始累加，直到 <paramref name="count" />。</remarks>
	public static ParallelLoopResult ForParallel(this Action<int, ParallelLoopState> action, int count, ParallelOptions options = null)
	{
		action.GuardNotNull("action");
		count.GuardGreaterThanOrEqualTo(0);
		if (options.IsNull())
		{
			return Parallel.For(1, count + 1, action);
		}
		return Parallel.For(1, count + 1, options, action);
	}

	/// <summary>
	/// 并行执行当前方法委托，执行指定的次数
	/// </summary>
	/// <param name="action">当前方法委托</param>
	/// <param name="start">开始的索引</param>
	/// <param name="count">运行的次数</param>
	/// <param name="options">执行参数对象，如果设置为空则忽略参数</param>
	/// <returns>有关已完成的循环部分的信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前方法委托为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0。</exception>
	/// <remarks>待执行的方法委托 <paramref name="action" />, 接收一个 <see cref="T:System.Int32" /> 类型的参数，该参数表示当前执行的索引次数，从 <paramref name="start" /> 开始累加。</remarks>
	public static ParallelLoopResult ForParallel(this Action<int, ParallelLoopState> action, int start, int count, ParallelOptions options = null)
	{
		action.GuardNotNull("action");
		count.GuardGreaterThanOrEqualTo(0);
		if (options.IsNull())
		{
			return Parallel.For(start, start + count, action);
		}
		return Parallel.For(start, start + count, options, action);
	}

	/// <summary>
	/// 并行执行当前方法委托，执行指定的次数
	/// </summary>
	/// <param name="action">当前方法委托</param>
	/// <param name="count">运行的次数</param>
	/// <param name="options">执行参数对象，如果设置为空则忽略参数</param>
	/// <returns>有关已完成的循环部分的信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前方法委托为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0。</exception>
	public static ParallelLoopResult ForParallelLong(this Action action, long count, ParallelOptions options = null)
	{
		action.GuardNotNull("action");
		count.GuardGreaterThanOrEqualTo(0L);
		if (options.IsNull())
		{
			return Parallel.For(0L, count, (Action<long>)delegate
			{
				action();
			});
		}
		return Parallel.For(0L, count, options, (Action<long>)delegate
		{
			action();
		});
	}

	/// <summary>
	/// 并行执行当前方法委托，执行指定的次数
	/// </summary>
	/// <param name="action">当前方法委托</param>
	/// <param name="count">运行的次数</param>
	/// <param name="options">执行参数对象，如果设置为空则忽略参数</param>
	/// <returns>有关已完成的循环部分的信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前方法委托为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0。</exception>
	/// <remarks>待执行的方法委托 <paramref name="action" />, 接收一个 <see cref="T:System.Int64" /> 类型的参数；该参数表示当前执行的次数，从1开始累加，直到 <paramref name="count" />。</remarks>
	public static ParallelLoopResult ForParallelLong(this Action<long> action, long count, ParallelOptions options = null)
	{
		action.GuardNotNull("action");
		count.GuardGreaterThanOrEqualTo(0L);
		if (options.IsNull())
		{
			return Parallel.For(1L, count + 1, action);
		}
		return Parallel.For(1L, count + 1, options, action);
	}

	/// <summary>
	/// 并行执行当前方法委托，执行指定的次数
	/// </summary>
	/// <param name="action">当前方法委托</param>
	/// <param name="start">开始的索引</param>
	/// <param name="count">运行的次数</param>
	/// <param name="options">执行参数对象，如果设置为空则忽略参数</param>
	/// <returns>有关已完成的循环部分的信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前方法委托为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0。</exception>
	/// <remarks>待执行的方法委托 <paramref name="action" />, 接收一个 <see cref="T:System.Int64" /> 类型的参数，该参数表示当前执行的索引次数，从 <paramref name="start" /> 开始累加。</remarks>
	public static ParallelLoopResult ForParallelLong(this Action<long> action, long start, long count, ParallelOptions options = null)
	{
		action.GuardNotNull("action");
		count.GuardGreaterThanOrEqualTo(0L);
		if (options.IsNull())
		{
			return Parallel.For(start, start + count, action);
		}
		return Parallel.For(start, start + count, options, action);
	}

	/// <summary>
	/// 并行执行当前方法委托，执行指定的次数
	/// </summary>
	/// <param name="action">当前方法委托</param>
	/// <param name="count">运行的次数</param>
	/// <param name="options">执行参数对象，如果设置为空则忽略参数</param>
	/// <returns>有关已完成的循环部分的信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前方法委托为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0。</exception>
	/// <remarks>待执行的方法委托 <paramref name="action" />, 接收的 <see cref="T:System.Int64" /> 类型的参数表示当前执行的次数，从1开始累加，直到 <paramref name="count" />。</remarks>
	public static ParallelLoopResult ForParallelLong(this Action<long, ParallelLoopState> action, long count, ParallelOptions options = null)
	{
		action.GuardNotNull("action");
		count.GuardGreaterThanOrEqualTo(0L);
		if (options.IsNull())
		{
			return Parallel.For(1L, count + 1, action);
		}
		return Parallel.For(1L, count + 1, options, action);
	}

	/// <summary>
	/// 并行执行当前方法委托，执行指定的次数
	/// </summary>
	/// <param name="action">当前方法委托</param>
	/// <param name="start">开始的索引</param>
	/// <param name="count">运行的次数</param>
	/// <param name="options">执行参数对象，如果设置为空则忽略参数</param>
	/// <returns>有关已完成的循环部分的信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前方法委托为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0。</exception>
	/// <remarks>待执行的方法委托 <paramref name="action" />, 接收一个 <see cref="T:System.Int64" /> 类型的参数，该参数表示当前执行的索引次数，从 <paramref name="start" /> 开始累加。</remarks>
	public static ParallelLoopResult ForParallelLong(this Action<long, ParallelLoopState> action, long start, long count, ParallelOptions options = null)
	{
		action.GuardNotNull("action");
		count.GuardGreaterThanOrEqualTo(0L);
		if (options.IsNull())
		{
			return Parallel.For(start, start + count, action);
		}
		return Parallel.For(start, start + count, options, action);
	}

	/// <summary>
	/// 在给定数据源序列上并行执行当前方法委托
	/// </summary>
	/// <typeparam name="T">数据源元素类型</typeparam>
	/// <param name="action">当前方法委托</param>
	/// <param name="source">可枚举的数据源</param>
	/// <param name="options">执行参数对象，如果设置为空则忽略参数</param>
	/// <returns>有关已完成的循环部分的信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前方法委托为空；或者 <paramref name="source" /> 为空。</exception>
	public static ParallelLoopResult ForEachParallel<T>(this Action<T> action, IEnumerable<T> source, ParallelOptions options = null)
	{
		return ForEachParallel(delegate(T v, ParallelLoopState s, long i)
		{
			action(v);
		}, source, options);
	}

	/// <summary>
	/// 在给定数据源序列上并行执行当前方法委托
	/// </summary>
	/// <typeparam name="T">数据源元素类型</typeparam>
	/// <param name="action">当前方法委托</param>
	/// <param name="source">可枚举的数据源</param>
	/// <param name="options">执行参数对象，如果设置为空则忽略参数</param>
	/// <returns>有关已完成的循环部分的信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前方法委托为空；或者 <paramref name="source" /> 为空。</exception>
	public static ParallelLoopResult ForEachParallel<T>(this Action<T, ParallelLoopState> action, IEnumerable<T> source, ParallelOptions options = null)
	{
		return ForEachParallel(delegate(T v, ParallelLoopState s, long i)
		{
			action(v, s);
		}, source, options);
	}

	/// <summary>
	/// 在给定数据源序列上并行执行当前方法委托
	/// </summary>
	/// <typeparam name="T">数据源元素类型</typeparam>
	/// <param name="action">当前方法委托</param>
	/// <param name="source">可枚举的数据源</param>
	/// <param name="options">执行参数对象，如果设置为空则忽略参数</param>
	/// <returns>有关已完成的循环部分的信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前方法委托为空；或者 <paramref name="source" /> 为空。</exception>
	public static ParallelLoopResult ForEachParallel<T>(this Action<T, ParallelLoopState, long> action, IEnumerable<T> source, ParallelOptions options = null)
	{
		action.GuardNotNull("action");
		source.GuardNotNull("source");
		if (options.IsNull())
		{
			return Parallel.ForEach(source, action);
		}
		return Parallel.ForEach(source, options, action);
	}

	/// <summary>
	/// 如果当前函数委托的返回值不等于false，则抛出 <see cref="T:System.InvalidOperationException" /> 异常
	/// </summary>
	/// <param name="func">当前函数委托</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前函数委托为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前函数委托返回true时。</exception>
	public static bool GuardFalse(this Func<bool> func, string message = null)
	{
		func.GuardNotNull("Guarded Func");
		func.Guard(!func(), () => new InvalidOperationException(message.IfNull(Literals.MSG_ValueTrue)));
		return false;
	}

	/// <summary>
	/// 如果当前函数委托的返回值不等于false，则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <param name="func">当前函数委托</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前函数委托为空。</exception>
	/// <exception cref="T:System.Exception">当前函数委托返回true时，抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static bool GuardFalse(this Func<bool> func, Func<Exception> exceptionCreator)
	{
		func.GuardNotNull("Guarded Func");
		func.Guard(!func(), exceptionCreator);
		return false;
	}

	/// <summary>
	/// 如果当前函数委托的返回值不等于false，则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <param name="func">当前函数委托</param>
	/// <param name="exceptionType">指定的异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检测通过返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前函数委托为空；或者 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.Exception">当前函数委托返回true时，抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static bool GuardFalse(this Func<bool> func, Type exceptionType, params object[] args)
	{
		func.GuardNotNull("Guarded Func");
		exceptionType.GuardNotNull("Exception Type");
		func.Guard(!func(), exceptionType, args);
		return false;
	}

	/// <summary>
	/// 如果当前函数委托的返回值不等于true，则抛出 <see cref="T:System.InvalidOperationException" /> 异常
	/// </summary>
	/// <param name="func">当前函数委托</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过返回true</returns>
	/// <exception cref="T:System.ArgumentNullException">当前函数委托为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前函数委托返回false时。</exception>
	public static bool GuardTrue(this Func<bool> func, string message = null)
	{
		func.GuardNotNull("Guarded Func");
		func.Guard(func(), () => new InvalidOperationException(message.IfNull(Literals.MSG_ValueFalse)));
		return true;
	}

	/// <summary>
	/// 如果当前函数委托的返回值不等于true，则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <param name="func">当前函数委托</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过返回true</returns>
	/// <exception cref="T:System.ArgumentNullException">当前函数委托为空。</exception>
	/// <exception cref="T:System.Exception">当前函数委托返回false时，抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static bool GuardTrue(this Func<bool> func, Func<Exception> exceptionCreator)
	{
		func.GuardNotNull("Guarded Func");
		func.Guard(func(), exceptionCreator);
		return true;
	}

	/// <summary>
	/// 如果当前函数委托的返回值不等于true，则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <param name="func">当前函数委托</param>
	/// <param name="exceptionType">指定的异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检测通过返回true</returns>
	/// <exception cref="T:System.ArgumentNullException">当前函数委托为空；或者 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.Exception">当前函数委托返回false时，抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static bool GuardTrue(this Func<bool> func, Type exceptionType, params object[] args)
	{
		func.GuardNotNull("Guarded Func");
		exceptionType.GuardNotNull("Exception Type");
		func.Guard(func(), exceptionType, args);
		return true;
	}

	/// <summary>
	/// 将当前委托分解为单路委托数组
	/// </summary>
	/// <param name="handler">当前委托</param>
	/// <returns>单路委托列表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前委托为空。</exception>
	public static Delegate[] Split(this Delegate handler)
	{
		handler.GuardNotNull("handler");
		return handler.GetInvocationList().ToArray();
	}

	/// <summary>
	/// 将当前委托分解为单路委托数组
	/// </summary>
	/// <typeparam name="T">委托类型</typeparam>
	/// <param name="handler">当前委托</param>
	/// <returns>单路委托列表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前委托为空。</exception>
	public static T[] Split<T>(this Delegate handler)
	{
		handler.GuardNotNull("handler");
		return handler.GetInvocationList().OfType<T>().ToArray();
	}

	/// <summary>
	/// 将相等比较方法转化为相等比较对象
	/// </summary>
	/// <param name="equalition">当前相等比较方法</param>
	/// <returns>使用指定当前比较方法的比较对象</returns>
	/// <remarks>如果当前相等比较方法为空，则使用 <see cref="M:System.Object.Equals(System.Object)" /> 检测对象的相等性。</remarks>
	public static IEqualityComparer ToComparer(this Func<object, object, bool> equalition)
	{
		equalition = equalition.IfNull(delegate(object x, object y)
		{
			if ((!x.IsNotNull() || !x.Equals(y)) && y.IsNotNull())
			{
				y.Equals(x);
			}
			return true;
		});
		return new CustomEqualityComparer(equalition);
	}

	/// <summary>
	/// 将相等比较方法转化为相等比较对象
	/// </summary>
	/// <typeparam name="T">比较的对象类型</typeparam>
	/// <param name="equalition">当前相等比较方法</param>
	/// <returns>使用当前相等比较方法的比较对象；如果当前相等比较方法为空，返回 <see cref="P:System.Collections.Generic.EqualityComparer`1.Default" />。</returns>
	public static IEqualityComparer<T> ToComparer<T>(this Func<T, T, bool> equalition)
	{
		object result;
		if (!equalition.IsNull())
		{
			IEqualityComparer<T> equalityComparer = new CustomEqualityComparer<T>(equalition);
			result = equalityComparer;
		}
		else
		{
			result = EqualityComparer<T>.Default;
		}
		return (IEqualityComparer<T>)result;
	}

	/// <summary>
	/// 将大小比较方法转化为大小比较对象
	/// </summary>
	/// <param name="comparison">当前大小比较方法</param>
	/// <returns>使用当前大小比较方法的比较对象；如果当前相等比较方法为空，返回 <see cref="F:System.Collections.Comparer.Default" />。</returns>
	public static IComparer ToComparer(this Func<object, object, int> comparison)
	{
		object result;
		if (!comparison.IsNull())
		{
			IComparer comparer = new CustomComparer(comparison);
			result = comparer;
		}
		else
		{
			result = Comparer.Default;
		}
		return (IComparer)result;
	}

	/// <summary>
	/// 将大小比较方法转化为大小比较对象
	/// </summary>
	/// <typeparam name="T">比较的对象类型</typeparam>
	/// <param name="comparison">当前大小比较方法</param>
	/// <returns>使用当前大小比较方法的比较对象；如果当前相等比较方法为空，返回 <see cref="P:System.Collections.Generic.Comparer`1.Default" />。</returns>
	public static IComparer<T> ToComparer<T>(this Func<T, T, int> comparison)
	{
		object result;
		if (!comparison.IsNull())
		{
			IComparer<T> comparer = new CustomComparer<T>(comparison);
			result = comparer;
		}
		else
		{
			result = Comparer<T>.Default;
		}
		return (IComparer<T>)result;
	}

	/// <summary>
	/// 将大小比较方法转化为大小比较对象
	/// </summary>
	/// <typeparam name="T">比较的对象类型</typeparam>
	/// <param name="comparison">当前大小比较方法</param>
	/// <returns>使用当前大小比较方法的比较对象；如果当前相等比较方法为空，返回 <see cref="P:System.Collections.Generic.Comparer`1.Default" />。</returns>
	public static IComparer<T> ToComparer<T>(this Comparison<T> comparison)
	{
		object result;
		if (!comparison.IsNull())
		{
			IComparer<T> comparer = new CustomComparer<T>(comparison);
			result = comparer;
		}
		else
		{
			result = Comparer<T>.Default;
		}
		return (IComparer<T>)result;
	}

	/// <summary>
	/// 执行当前委托，并返回可能出现的异常
	/// </summary>
	/// <param name="action">当前待执行的方法委托</param>
	/// <returns>执行中可能出现的异常，如果未出现异常返回null</returns>
	/// <exception cref="T:System.ArgumentNullException">当前待执行的方法为空。</exception>
	public static Exception Try(this Action action)
	{
		action.GuardNotNull("action");
		try
		{
			action();
			return null;
		}
		catch (Exception result)
		{
			return result;
		}
	}

	/// <summary>
	/// 执行当前委托，并返回可能出现的异常
	/// </summary>
	/// <typeparam name="T">委托执行参数类型</typeparam>
	/// <param name="action">当前待执行的方法委托</param>
	/// <param name="arg">委托执行的参数</param>
	/// <returns>执行中可能出现的异常，如果未出现异常返回null</returns>
	/// <exception cref="T:System.ArgumentNullException">当前待执行的方法为空。</exception>
	public static Exception Try<T>(this Action<T> action, T arg)
	{
		action.GuardNotNull("action");
		try
		{
			action(arg);
			return null;
		}
		catch (Exception result)
		{
			return result;
		}
	}

	/// <summary>
	/// 执行当前委托，并返回可能出现的异常
	/// </summary>
	/// <typeparam name="T1">委托执行参数类型</typeparam>
	/// <typeparam name="T2">委托执行参数类型</typeparam>
	/// <param name="action">当前待执行的方法委托</param>
	/// <param name="arg1">委托执行的参数</param>
	/// <param name="arg2">委托执行的参数</param>
	/// <returns>执行中可能出现的异常，如果未出现异常返回null</returns>
	/// <exception cref="T:System.ArgumentNullException">当前待执行的方法为空。</exception>
	public static Exception Try<T1, T2>(this Action<T1, T2> action, T1 arg1, T2 arg2)
	{
		action.GuardNotNull("action");
		try
		{
			action(arg1, arg2);
			return null;
		}
		catch (Exception result)
		{
			return result;
		}
	}

	/// <summary>
	/// 执行当前委托，并返回可能出现的异常
	/// </summary>
	/// <typeparam name="T1">委托执行参数类型</typeparam>
	/// <typeparam name="T2">委托执行参数类型</typeparam>
	/// <typeparam name="T3">委托执行参数类型</typeparam>
	/// <param name="action">当前待执行的方法委托</param>
	/// <param name="arg1">委托执行的参数</param>
	/// <param name="arg2">委托执行的参数</param>
	/// <param name="arg3">委托执行的参数</param>
	/// <returns>执行中可能出现的异常，如果未出现异常返回null</returns>
	/// <exception cref="T:System.ArgumentNullException">当前待执行的方法为空。</exception>
	public static Exception Try<T1, T2, T3>(this Action<T1, T2, T3> action, T1 arg1, T2 arg2, T3 arg3)
	{
		action.GuardNotNull("action");
		try
		{
			action(arg1, arg2, arg3);
			return null;
		}
		catch (Exception result)
		{
			return result;
		}
	}

	/// <summary>
	/// 执行当前委托，并返回可能出现的异常
	/// </summary>
	/// <typeparam name="T1">委托执行参数类型</typeparam>
	/// <typeparam name="T2">委托执行参数类型</typeparam>
	/// <typeparam name="T3">委托执行参数类型</typeparam>
	/// <typeparam name="T4">委托执行参数类型</typeparam>
	/// <param name="action">当前待执行的方法委托</param>
	/// <param name="arg1">委托执行的参数</param>
	/// <param name="arg2">委托执行的参数</param>
	/// <param name="arg3">委托执行的参数</param>
	/// <param name="arg4">委托执行的参数</param>
	/// <returns>执行中可能出现的异常，如果未出现异常返回null</returns>
	/// <exception cref="T:System.ArgumentNullException">当前待执行的方法为空。</exception>
	public static Exception Try<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
	{
		action.GuardNotNull("action");
		try
		{
			action(arg1, arg2, arg3, arg4);
			return null;
		}
		catch (Exception result)
		{
			return result;
		}
	}

	/// <summary>
	/// 执行当前委托，并返回可能出现的异常
	/// </summary>
	/// <typeparam name="T1">委托执行参数类型</typeparam>
	/// <typeparam name="T2">委托执行参数类型</typeparam>
	/// <typeparam name="T3">委托执行参数类型</typeparam>
	/// <typeparam name="T4">委托执行参数类型</typeparam>
	/// <typeparam name="T5">委托执行参数类型</typeparam>
	/// <param name="action">当前待执行的方法委托</param>
	/// <param name="arg1">委托执行的参数</param>
	/// <param name="arg2">委托执行的参数</param>
	/// <param name="arg3">委托执行的参数</param>
	/// <param name="arg4">委托执行的参数</param>
	/// <param name="arg5">委托执行的参数</param>
	/// <returns>执行中可能出现的异常，如果未出现异常返回null</returns>
	/// <exception cref="T:System.ArgumentNullException">当前待执行的方法为空。</exception>
	public static Exception Try<T1, T2, T3, T4, T5>(this Action<T1, T2, T3, T4, T5> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
	{
		action.GuardNotNull("action");
		try
		{
			action(arg1, arg2, arg3, arg4, arg5);
			return null;
		}
		catch (Exception result)
		{
			return result;
		}
	}

	/// <summary>
	/// 执行当前委托，并由指定的异常捕获器处理异常；如果未定义异常捕获器则抛出异常
	/// </summary>
	/// <param name="action">当前待执行的方法委托</param>
	/// <param name="catcher">异常捕获器</param>
	/// <param name="finalizer">终结处理，无论异常是否发生，都将执行该处理</param>
	/// <exception cref="T:System.ArgumentNullException">当前待执行的方法为空。</exception>
	public static void Try(this Action action, Action<Exception> catcher, Action finalizer = null)
	{
		action.GuardNotNull("action");
		try
		{
			action();
		}
		catch (Exception ex)
		{
			if (catcher.IsNotNull())
			{
				catcher(ex);
				return;
			}
			throw;
		}
		finally
		{
			if (finalizer.IsNotNull())
			{
				finalizer();
			}
		}
	}

	/// <summary>
	/// 执行当前委托，并由指定的异常捕获器处理异常；如果未定义异常捕获器则抛出异常
	/// </summary>
	/// <typeparam name="T">委托参数类型</typeparam>
	/// <param name="action">当前待执行的方法委托</param>
	/// <param name="arg">委托参数</param>
	/// <param name="catcher">异常捕获器</param>
	/// <param name="finalizer">终结处理，无论异常是否发生，都将执行该处理</param>
	/// <exception cref="T:System.ArgumentNullException">当前执行的方法委托为空。</exception>
	public static void Try<T>(this Action<T> action, T arg, Action<Exception> catcher, Action finalizer = null)
	{
		action.GuardNotNull("action");
		try
		{
			action(arg);
		}
		catch (Exception ex)
		{
			if (catcher.IsNotNull())
			{
				catcher(ex);
				return;
			}
			throw;
		}
		finally
		{
			if (finalizer.IsNotNull())
			{
				finalizer();
			}
		}
	}

	/// <summary>
	/// 执行当前委托，并由指定的异常捕获器处理异常；如果未定义异常捕获器则抛出异常
	/// </summary>
	/// <typeparam name="T1">委托参数类型</typeparam>
	/// <typeparam name="T2">委托参数类型</typeparam>
	/// <param name="action">当前待执行的方法委托</param>
	/// <param name="arg1">委托参数</param>
	/// <param name="arg2">委托参数</param>
	/// <param name="catcher">异常捕获器</param>
	/// <param name="finalizer">终结处理，无论异常是否发生，都将执行该处理</param>
	/// <exception cref="T:System.ArgumentNullException">当前执行的方法委托为空。</exception>
	public static void Try<T1, T2>(this Action<T1, T2> action, T1 arg1, T2 arg2, Action<Exception> catcher, Action finalizer = null)
	{
		action.GuardNotNull("action");
		try
		{
			action(arg1, arg2);
		}
		catch (Exception ex)
		{
			if (catcher.IsNotNull())
			{
				catcher(ex);
				return;
			}
			throw;
		}
		finally
		{
			if (finalizer.IsNotNull())
			{
				finalizer();
			}
		}
	}

	/// <summary>
	/// 执行当前委托，并由指定的异常捕获器处理异常；如果未定义异常捕获器则抛出异常
	/// </summary>
	/// <typeparam name="T1">委托参数类型</typeparam>
	/// <typeparam name="T2">委托参数类型</typeparam>
	/// <typeparam name="T3">委托参数类型</typeparam>
	/// <param name="action">当前待执行的方法委托</param>
	/// <param name="arg1">委托参数</param>
	/// <param name="arg2">委托参数</param>
	/// <param name="arg3">委托参数</param>
	/// <param name="catcher">异常捕获器</param>
	/// <param name="finalizer">终结处理，无论异常是否发生，都将执行该处理</param>
	/// <exception cref="T:System.ArgumentNullException">当前执行的方法委托为空。</exception>
	public static void Try<T1, T2, T3>(this Action<T1, T2, T3> action, T1 arg1, T2 arg2, T3 arg3, Action<Exception> catcher, Action finalizer = null)
	{
		action.GuardNotNull("action");
		try
		{
			action(arg1, arg2, arg3);
		}
		catch (Exception ex)
		{
			if (catcher.IsNotNull())
			{
				catcher(ex);
				return;
			}
			throw;
		}
		finally
		{
			if (finalizer.IsNotNull())
			{
				finalizer();
			}
		}
	}

	/// <summary>
	/// 执行当前委托，并由指定的异常捕获器处理异常；如果未定义异常捕获器则抛出异常
	/// </summary>
	/// <typeparam name="T1">委托参数类型</typeparam>
	/// <typeparam name="T2">委托参数类型</typeparam>
	/// <typeparam name="T3">委托参数类型</typeparam>
	/// <typeparam name="T4">委托参数类型</typeparam>
	/// <param name="action">当前待执行的方法委托</param>
	/// <param name="arg1">委托参数</param>
	/// <param name="arg2">委托参数</param>
	/// <param name="arg3">委托参数</param>
	/// <param name="arg4">委托参数</param>
	/// <param name="catcher">异常捕获器</param>
	/// <param name="finalizer">终结处理，无论异常是否发生，都将执行该处理</param>
	/// <exception cref="T:System.ArgumentNullException">当前执行的方法委托为空。</exception>
	public static void Try<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4, Action<Exception> catcher, Action finalizer = null)
	{
		action.GuardNotNull("action");
		try
		{
			action(arg1, arg2, arg3, arg4);
		}
		catch (Exception ex)
		{
			if (catcher.IsNotNull())
			{
				catcher(ex);
				return;
			}
			throw;
		}
		finally
		{
			if (finalizer.IsNotNull())
			{
				finalizer();
			}
		}
	}

	/// <summary>
	/// 执行当前委托，并由指定的异常捕获器处理异常；如果未定义异常捕获器则抛出异常
	/// </summary>
	/// <typeparam name="T1">委托参数类型</typeparam>
	/// <typeparam name="T2">委托参数类型</typeparam>
	/// <typeparam name="T3">委托参数类型</typeparam>
	/// <typeparam name="T4">委托参数类型</typeparam>
	/// <typeparam name="T5">委托参数类型</typeparam>
	/// <param name="action">当前待执行的方法委托</param>
	/// <param name="arg1">委托参数</param>
	/// <param name="arg2">委托参数</param>
	/// <param name="arg3">委托参数</param>
	/// <param name="arg4">委托参数</param>
	/// <param name="arg5">委托参数</param>
	/// <param name="catcher">异常捕获器</param>
	/// <param name="finalizer">终结处理，无论异常是否发生，都将执行该处理</param>
	/// <exception cref="T:System.ArgumentNullException">当前执行的方法委托为空。</exception>
	public static void Try<T1, T2, T3, T4, T5>(this Action<T1, T2, T3, T4, T5> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, Action<Exception> catcher, Action finalizer = null)
	{
		action.GuardNotNull("action");
		try
		{
			action(arg1, arg2, arg3, arg4, arg5);
		}
		catch (Exception ex)
		{
			if (catcher.IsNotNull())
			{
				catcher(ex);
				return;
			}
			throw;
		}
		finally
		{
			if (finalizer.IsNotNull())
			{
				finalizer();
			}
		}
	}

	/// <summary>
	/// 执行当前委托，并由指定的异常捕获器处理异常；如果未定义异常捕获器则抛出异常。
	/// 执行过程中发生异常，将按顺序寻找异常捕获器数组中第一个参数类型匹配的异常捕获器。
	/// </summary>
	/// <param name="action">当前待执行的方法委托</param>
	/// <param name="catchers">异常捕获器数组，捕获器应是带一个参数的Action泛型委托</param>
	/// <exception cref="T:System.ArgumentNullException">当前执行的方法委托为空。</exception>
	public static void Try(this Action action, params Delegate[] catchers)
	{
		action.GuardNotNull("action");
		action.Try(catchers, null);
	}

	/// <summary>
	/// 执行当前委托，并由指定的异常捕获器处理异常；如果未定义异常捕获器则抛出异常。
	/// 执行过程中发生异常，将按顺序寻找异常捕获器数组中第一个参数类型匹配的异常捕获器。
	/// </summary>
	/// <param name="action">当前待执行的方法委托</param>
	/// <param name="catchers">异常捕获器数组，捕获器应是带一个参数的Action泛型委托</param>
	/// <param name="finalizer">终结处理，无论异常是否发生，都将执行该处理</param>
	/// <exception cref="T:System.ArgumentNullException">当前执行的方法委托为空。</exception>
	public static void Try(this Action action, Delegate[] catchers, Action finalizer)
	{
		action.GuardNotNull("action");
		try
		{
			action();
		}
		catch (Exception ex)
		{
			if (catchers.IsNotNull() && catchers.Length > 0)
			{
				ParameterInfo[] pinfos = null;
				foreach (Delegate catcher in catchers)
				{
					pinfos = catcher.Method.GetParameters();
					if (pinfos.Length == 1 && pinfos[0].ParameterType.IsAssignableFrom(ex.GetType()))
					{
						catcher.DynamicInvoke(ex);
					}
				}
			}
			throw;
		}
		finally
		{
			if (finalizer.IsNotNull())
			{
				finalizer();
			}
		}
	}

	/// <summary>
	/// 执行当前函数委托，并返回可能出现的异常，并返回函数结果
	/// </summary>
	/// <typeparam name="R">函数返回值类型</typeparam>
	/// <param name="func">当前执行的函数委托</param>
	/// <param name="result">函数执行结果，如果函数执行异常，返回其类型的默认值</param>
	/// <returns>执行中可能出现的异常，如果未出现异常返回null</returns>
	/// <exception cref="T:System.ArgumentNullException">当前执行的函数委托为空。</exception>
	public static Exception Try<R>(this Func<R> func, out R result)
	{
		func.GuardNotNull("func");
		try
		{
			result = func();
			return null;
		}
		catch (Exception ex)
		{
			result = default(R);
			return ex;
		}
	}

	/// <summary>
	/// 执行当前函数委托，并返回可能出现的异常，并返回函数结果
	/// </summary>
	/// <typeparam name="T">委托执行参数类型</typeparam>
	/// <typeparam name="R">函数返回值类型</typeparam>
	/// <param name="func">当前执行的函数委托</param>
	/// <param name="arg">委托执行的参数</param>
	/// <param name="result">函数执行结果，如果函数执行异常，返回null</param>
	/// <returns>执行中可能出现的异常，如果未出现异常返回null</returns>
	/// <exception cref="T:System.ArgumentNullException">当前执行的函数委托为空。</exception>
	public static Exception Try<T, R>(this Func<T, R> func, T arg, out R result)
	{
		func.GuardNotNull("func");
		try
		{
			result = func(arg);
			return null;
		}
		catch (Exception ex)
		{
			result = default(R);
			return ex;
		}
	}

	/// <summary>
	/// 执行当前函数委托，并返回可能出现的异常，并返回函数结果
	/// </summary>
	/// <typeparam name="T1">委托执行参数类型</typeparam>
	/// <typeparam name="T2">委托执行参数类型</typeparam>
	/// <typeparam name="R">函数返回值类型</typeparam>
	/// <param name="func">当前执行的函数委托</param>
	/// <param name="arg1">委托执行的参数</param>
	/// <param name="arg2">委托执行的参数</param>
	/// <param name="result">函数执行结果，如果函数执行异常，返回null</param>
	/// <returns>执行中可能出现的异常，如果未出现异常返回null</returns>
	/// <exception cref="T:System.ArgumentNullException">当前执行的函数委托为空。</exception>
	public static Exception Try<T1, T2, R>(this Func<T1, T2, R> func, T1 arg1, T2 arg2, out R result)
	{
		func.GuardNotNull("func");
		try
		{
			result = func(arg1, arg2);
			return null;
		}
		catch (Exception ex)
		{
			result = default(R);
			return ex;
		}
	}

	/// <summary>
	/// 执行当前函数委托，并返回可能出现的异常，并返回函数结果
	/// </summary>
	/// <typeparam name="T1">委托执行参数类型</typeparam>
	/// <typeparam name="T2">委托执行参数类型</typeparam>
	/// <typeparam name="T3">委托执行参数类型</typeparam>
	/// <typeparam name="R">函数返回值类型</typeparam>
	/// <param name="func">当前执行的函数委托</param>
	/// <param name="arg1">委托执行的参数</param>
	/// <param name="arg2">委托执行的参数</param>
	/// <param name="arg3">委托执行的参数</param>
	/// <param name="result">函数执行结果，如果函数执行异常，返回null</param>
	/// <returns>执行中可能出现的异常，如果未出现异常返回null</returns>
	/// <exception cref="T:System.ArgumentNullException">当前执行的函数委托为空。</exception>
	public static Exception Try<T1, T2, T3, R>(this Func<T1, T2, T3, R> func, T1 arg1, T2 arg2, T3 arg3, out R result)
	{
		func.GuardNotNull("func");
		try
		{
			result = func(arg1, arg2, arg3);
			return null;
		}
		catch (Exception ex)
		{
			result = default(R);
			return ex;
		}
	}

	/// <summary>
	/// 执行当前函数委托，并返回可能出现的异常，并返回函数结果
	/// </summary>
	/// <typeparam name="T1">委托执行参数类型</typeparam>
	/// <typeparam name="T2">委托执行参数类型</typeparam>
	/// <typeparam name="T3">委托执行参数类型</typeparam>
	/// <typeparam name="T4">委托执行参数类型</typeparam>
	/// <typeparam name="R">函数返回值类型</typeparam>
	/// <param name="func">当前执行的函数委托</param>
	/// <param name="arg1">委托执行的参数</param>
	/// <param name="arg2">委托执行的参数</param>
	/// <param name="arg3">委托执行的参数</param>
	/// <param name="arg4">委托执行的参数</param>
	/// <param name="result">函数执行结果，如果函数执行异常，返回null</param>
	/// <returns>执行中可能出现的异常，如果未出现异常返回null</returns>
	/// <exception cref="T:System.ArgumentNullException">当前执行的函数委托为空。</exception>
	public static Exception Try<T1, T2, T3, T4, R>(this Func<T1, T2, T3, T4, R> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, out R result)
	{
		func.GuardNotNull("func");
		try
		{
			result = func(arg1, arg2, arg3, arg4);
			return null;
		}
		catch (Exception ex)
		{
			result = default(R);
			return ex;
		}
	}

	/// <summary>
	/// 执行当前函数委托，并返回可能出现的异常，并返回函数结果
	/// </summary>
	/// <typeparam name="T1">委托执行参数类型</typeparam>
	/// <typeparam name="T2">委托执行参数类型</typeparam>
	/// <typeparam name="T3">委托执行参数类型</typeparam>
	/// <typeparam name="T4">委托执行参数类型</typeparam>
	/// <typeparam name="T5">委托执行参数类型</typeparam>
	/// <typeparam name="R">函数返回值类型</typeparam>
	/// <param name="func">当前执行的函数委托</param>
	/// <param name="arg1">委托执行的参数</param>
	/// <param name="arg2">委托执行的参数</param>
	/// <param name="arg3">委托执行的参数</param>
	/// <param name="arg4">委托执行的参数</param>
	/// <param name="arg5">委托执行的参数</param>
	/// <param name="result">函数执行结果，如果函数执行异常，返回null</param>
	/// <returns>执行中可能出现的异常，如果未出现异常返回null</returns>
	/// <exception cref="T:System.ArgumentNullException">当前执行的函数委托为空。</exception>
	public static Exception Try<T1, T2, T3, T4, T5, R>(this Func<T1, T2, T3, T4, T5, R> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, out R result)
	{
		func.GuardNotNull("func");
		try
		{
			result = func(arg1, arg2, arg3, arg4, arg5);
			return null;
		}
		catch (Exception ex)
		{
			result = default(R);
			return ex;
		}
	}

	/// <summary>
	/// 执行当前函数处理委托，并由指定的异常捕获器处理异常，并返回异常时的结果值；如果未定义异常捕获器则抛出异常
	/// </summary>
	/// <typeparam name="R">函数处理委托结果类型</typeparam>
	/// <param name="func">当前执行的函数委托</param>
	/// <param name="catcher">异常捕获器</param>
	/// <param name="finalizer">终结处理，无论异常是否发生，都将执行该处理</param>
	/// <returns>函数处理结果</returns>
	/// <exception cref="T:System.ArgumentNullException">当前执行的函数委托为空。</exception>
	public static R Try<R>(this Func<R> func, Func<Exception, R> catcher, Action<R> finalizer = null)
	{
		func.GuardNotNull("func");
		R result = default(R);
		try
		{
			return result = func();
		}
		catch (Exception ex)
		{
			if (catcher.IsNotNull())
			{
				return result = catcher(ex);
			}
			throw;
		}
		finally
		{
			if (finalizer.IsNotNull())
			{
				finalizer(result);
			}
		}
	}

	/// <summary>
	/// 执行当前函数处理委托，并由指定的异常捕获器处理异常，并返回异常时的结果值；如果未定义异常捕获器则抛出异常
	/// </summary>
	/// <typeparam name="T">函数处理委托参数类型</typeparam>
	/// <typeparam name="R">函数处理委托结果类型</typeparam>
	/// <param name="func">当前执行的函数委托</param>
	/// <param name="arg">函数处理委托参数</param>
	/// <param name="catcher">异常捕获器</param>
	/// <param name="finalizer">终结处理，无论异常是否发生，都将执行该处理</param>
	/// <returns>函数处理结果</returns>
	/// <exception cref="T:System.ArgumentNullException">当前执行的函数委托为空。</exception>
	public static R Try<T, R>(this Func<T, R> func, T arg, Func<Exception, R> catcher, Action<R> finalizer = null)
	{
		func.GuardNotNull("func");
		R result = default(R);
		try
		{
			return result = func(arg);
		}
		catch (Exception ex)
		{
			if (catcher.IsNotNull())
			{
				return result = catcher(ex);
			}
			throw;
		}
		finally
		{
			if (finalizer.IsNotNull())
			{
				finalizer(result);
			}
		}
	}

	/// <summary>
	/// 执行当前函数处理委托，并由指定的异常捕获器处理异常，并返回异常时的结果值；如果未定义异常捕获器则抛出异常
	/// </summary>
	/// <typeparam name="T1">函数处理委托参数类型</typeparam>
	/// <typeparam name="T2">函数处理委托参数类型</typeparam>
	/// <typeparam name="R">函数处理委托结果类型</typeparam>
	/// <param name="func">当前执行的函数委托</param>
	/// <param name="arg1">函数处理委托参数</param>
	/// <param name="arg2">函数处理委托参数</param>
	/// <param name="catcher">异常捕获器</param>
	/// <param name="finalizer">终结处理，无论异常是否发生，都将执行该处理</param>
	/// <returns>函数处理结果</returns>
	/// <exception cref="T:System.ArgumentNullException">当前执行的函数委托为空。</exception>
	public static R Try<T1, T2, R>(this Func<T1, T2, R> func, T1 arg1, T2 arg2, Func<Exception, R> catcher, Action<R> finalizer = null)
	{
		func.GuardNotNull("func");
		R result = default(R);
		try
		{
			return result = func(arg1, arg2);
		}
		catch (Exception ex)
		{
			if (catcher.IsNotNull())
			{
				return result = catcher(ex);
			}
			throw;
		}
		finally
		{
			if (finalizer.IsNotNull())
			{
				finalizer(result);
			}
		}
	}

	/// <summary>
	/// 执行当前函数处理委托，并由指定的异常捕获器处理异常，并返回异常时的结果值；如果未定义异常捕获器则抛出异常
	/// </summary>
	/// <typeparam name="T1">函数处理委托参数类型</typeparam>
	/// <typeparam name="T2">函数处理委托参数类型</typeparam>
	/// <typeparam name="T3">函数处理委托参数类型</typeparam>
	/// <typeparam name="R">函数处理委托结果类型</typeparam>
	/// <param name="func">当前执行的函数委托</param>
	/// <param name="arg1">函数处理委托参数</param>
	/// <param name="arg2">函数处理委托参数</param>
	/// <param name="arg3">函数处理委托参数</param>
	/// <param name="catcher">异常捕获器</param>
	/// <param name="finalizer">终结处理，无论异常是否发生，都将执行该处理</param>
	/// <returns>函数处理结果</returns>
	/// <exception cref="T:System.ArgumentNullException">当前执行的函数委托为空。</exception>
	public static R Try<T1, T2, T3, R>(this Func<T1, T2, T3, R> func, T1 arg1, T2 arg2, T3 arg3, Func<Exception, R> catcher, Action<R> finalizer = null)
	{
		func.GuardNotNull("func");
		R result = default(R);
		try
		{
			return result = func(arg1, arg2, arg3);
		}
		catch (Exception ex)
		{
			if (catcher.IsNotNull())
			{
				return result = catcher(ex);
			}
			throw;
		}
		finally
		{
			if (finalizer.IsNotNull())
			{
				finalizer(result);
			}
		}
	}

	/// <summary>
	/// 执行当前函数处理委托，并由指定的异常捕获器处理异常，并返回异常时的结果值；如果未定义异常捕获器则抛出异常
	/// </summary>
	/// <typeparam name="T1">函数处理委托参数类型</typeparam>
	/// <typeparam name="T2">函数处理委托参数类型</typeparam>
	/// <typeparam name="T3">函数处理委托参数类型</typeparam>
	/// <typeparam name="T4">函数处理委托参数类型</typeparam>
	/// <typeparam name="R">函数处理委托结果类型</typeparam>
	/// <param name="func">当前执行的函数委托</param>
	/// <param name="arg1">函数处理委托参数</param>
	/// <param name="arg2">函数处理委托参数</param>
	/// <param name="arg3">函数处理委托参数</param>
	/// <param name="arg4">函数处理委托参数</param>
	/// <param name="catcher">异常捕获器</param>
	/// <param name="finalizer">终结处理，无论异常是否发生，都将执行该处理</param>
	/// <returns>函数处理结果</returns>
	/// <exception cref="T:System.ArgumentNullException">当前执行的函数委托为空。</exception>
	public static R Try<T1, T2, T3, T4, R>(this Func<T1, T2, T3, T4, R> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, Func<Exception, R> catcher, Action<R> finalizer = null)
	{
		func.GuardNotNull("func");
		R result = default(R);
		try
		{
			return result = func(arg1, arg2, arg3, arg4);
		}
		catch (Exception ex)
		{
			if (catcher.IsNotNull())
			{
				return result = catcher(ex);
			}
			throw;
		}
		finally
		{
			if (finalizer.IsNotNull())
			{
				finalizer(result);
			}
		}
	}

	/// <summary>
	/// 执行当前函数处理委托，并由指定的异常捕获器处理异常，并返回异常时的结果值；如果未定义异常捕获器则抛出异常
	/// </summary>
	/// <typeparam name="T1">函数处理委托参数类型</typeparam>
	/// <typeparam name="T2">函数处理委托参数类型</typeparam>
	/// <typeparam name="T3">函数处理委托参数类型</typeparam>
	/// <typeparam name="T4">函数处理委托参数类型</typeparam>
	/// <typeparam name="T5">函数处理委托参数类型</typeparam>
	/// <typeparam name="R">函数处理委托结果类型</typeparam>
	/// <param name="func">当前执行的函数委托</param>
	/// <param name="arg1">函数处理委托参数</param>
	/// <param name="arg2">函数处理委托参数</param>
	/// <param name="arg3">函数处理委托参数</param>
	/// <param name="arg4">函数处理委托参数</param>
	/// <param name="arg5">函数处理委托参数</param>
	/// <param name="catcher">异常捕获器</param>
	/// <param name="finalizer">终结处理，无论异常是否发生，都将执行该处理</param>
	/// <returns>函数处理结果</returns>
	/// <exception cref="T:System.ArgumentNullException">当前执行的函数委托为空。</exception>
	public static R Try<T1, T2, T3, T4, T5, R>(this Func<T1, T2, T3, T4, T5, R> func, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, Func<Exception, R> catcher, Action<R> finalizer = null)
	{
		func.GuardNotNull("func");
		R result = default(R);
		try
		{
			return result = func(arg1, arg2, arg3, arg4, arg5);
		}
		catch (Exception ex)
		{
			if (catcher.IsNotNull())
			{
				return result = catcher(ex);
			}
			throw;
		}
		finally
		{
			if (finalizer.IsNotNull())
			{
				finalizer(result);
			}
		}
	}

	/// <summary>
	/// 执行当前函数处理委托，并由指定的异常捕获器处理异常，并返回异常时的结果值；如果未定义异常捕获器则抛出异常
	/// 执行过程中发生异常，将按顺序寻找异常捕获器数组中第一个参数类型匹配的异常捕获器。
	/// </summary>
	/// <param name="func">当前执行的函数委托</param>
	/// <param name="catchers">异常捕获器数组，捕获器应是带一个参数的Func泛型委托</param>
	/// <returns>函数处理结果</returns>
	/// <exception cref="T:System.ArgumentNullException">当前执行的函数委托为空。</exception>
	public static R Try<R>(this Func<R> func, params Delegate[] catchers)
	{
		func.GuardNotNull("func");
		return func.Try(catchers, null);
	}

	/// <summary>
	/// 执行当前函数处理委托，并由指定的异常捕获器处理异常，并返回异常时的结果值；如果未定义异常捕获器则抛出异常
	/// 执行过程中发生异常，将按顺序寻找异常捕获器数组中第一个参数类型匹配的异常捕获器。
	/// </summary>
	/// <param name="func">当前执行的函数委托</param>
	/// <param name="catchers">异常捕获器数组，捕获器应是带一个参数的Func泛型委托</param>
	/// <param name="finalizer">终结处理，无论异常是否发生，都将执行该处理</param>
	/// <returns>函数处理结果</returns>
	/// <exception cref="T:System.ArgumentNullException">当前执行的函数委托为空。</exception>
	public static R Try<R>(this Func<R> func, Delegate[] catchers, Action<R> finalizer)
	{
		func.GuardNotNull("func");
		R result = default(R);
		try
		{
			return result = func();
		}
		catch (Exception ex)
		{
			if (catchers.IsNotNull() && catchers.Length > 0)
			{
				ParameterInfo[] pinfos = null;
				foreach (Delegate catcher in catchers)
				{
					pinfos = catcher.Method.GetParameters();
					if (pinfos.Length == 1 && pinfos[0].ParameterType.IsAssignableFrom(ex.GetType()))
					{
						return result = (R)catcher.DynamicInvoke(ex);
					}
				}
			}
			throw;
		}
		finally
		{
			if (finalizer.IsNotNull())
			{
				finalizer(result);
			}
		}
	}

	/// <summary>
	/// 执行当前委托，并返回可能出现的异常
	/// </summary>
	/// <param name="handler">当前执行的委托</param>
	/// <param name="parameters">委托执行的参数</param>
	/// <returns>执行中可能出现的异常，如果未出现异常返回null</returns>
	/// <exception cref="T:System.ArgumentNullException">当前执行的委托为空。</exception>
	public static Exception Try(this Delegate handler, params object[] parameters)
	{
		handler.GuardNotNull("handler");
		try
		{
			handler.DynamicInvoke(parameters);
			return null;
		}
		catch (Exception result)
		{
			return result;
		}
	}

	/// <summary>
	/// 执行当前委托，并返回可能出现的异常
	/// </summary>
	/// <param name="handler">当前执行的委托</param>
	/// <param name="parameters">委托执行的参数</param>
	/// <param name="result">委托执行的结果，如果出现异常则返回null</param>
	/// <returns>执行中可能出现的异常，如果未出现异常返回null</returns>
	/// <exception cref="T:System.ArgumentNullException">当前执行的委托为空。</exception>
	public static Exception Try(this Delegate handler, object[] parameters, out object result)
	{
		handler.GuardNotNull("handler");
		try
		{
			result = handler.DynamicInvoke(parameters);
			return null;
		}
		catch (Exception ex)
		{
			result = null;
			return ex;
		}
	}

	/// <summary>
	/// 执行当前委托，并返回可能出现的异常
	/// </summary>
	/// <param name="handler">当前执行的委托</param>
	/// <param name="parameters">委托执行的参数</param>
	/// <param name="catcher">异常捕获器</param>
	/// <param name="finalizer">终结处理，无论异常是否发生，都将执行该处理</param>
	/// <exception cref="T:System.ArgumentNullException">当前执行的委托为空。</exception>
	public static void Try(this Delegate handler, object[] parameters, Action<Exception> catcher, Action finalizer = null)
	{
		handler.GuardNotNull("handler");
		try
		{
			handler.DynamicInvoke(parameters);
		}
		catch (Exception ex)
		{
			if (catcher.IsNotNull())
			{
				catcher(ex);
				return;
			}
			throw;
		}
		finally
		{
			if (finalizer.IsNotNull())
			{
				finalizer();
			}
		}
	}

	/// <summary>
	/// 执行当前委托，并由指定的异常捕获方法捕获异常，未指定异常捕获方法则抛出异常
	/// </summary>
	/// <param name="handler">当前执行的委托</param>
	/// <param name="parameters">委托执行的参数</param>
	/// <param name="catcher">异常捕获方法</param>
	/// <param name="finalizer">终结处理，无论异常是否发生，都将执行该处理</param>
	/// <returns>委托执行结果</returns>
	/// <exception cref="T:System.ArgumentNullException">当前执行的委托为空。</exception>
	public static object Try(this Delegate handler, object[] parameters, Func<Exception, object> catcher, Action<object> finalizer = null)
	{
		handler.GuardNotNull("handler");
		object result = null;
		try
		{
			return result = handler.DynamicInvoke(parameters);
		}
		catch (Exception ex)
		{
			if (catcher.IsNotNull())
			{
				return result = catcher(ex);
			}
			throw ex;
		}
		finally
		{
			if (finalizer.IsNotNull())
			{
				finalizer(result);
			}
		}
	}

	/// <summary>
	/// 当前循环条件为真时，重复执行指定的委托。
	/// </summary>
	/// <param name="predicate">当前循环条件</param>
	/// <param name="action">重复执行的委托</param>
	/// <exception cref="T:System.ArgumentNullException">当前循环条件为空；或者 <paramref name="action" /> 为空。</exception>
	public static void While(Func<bool> predicate, Action action)
	{
		predicate.GuardNotNull("predicate");
		action.GuardNotNull("action");
		while (predicate())
		{
			action();
		}
	}
}
