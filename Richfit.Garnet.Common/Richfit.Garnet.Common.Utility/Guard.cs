#define DEBUG
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using Richfit.Garnet.Common.Patterns;
using Richfit.Garnet.Common.Properties;

namespace Richfit.Garnet.Common.Utility;

/// <summary>
/// 断言检测工具类
/// </summary>
public static class Guard
{
	/// <summary>
	/// 检测当前断言条件是否为true，不满足则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <param name="predicate">断言条件</param>
	/// <param name="name">断言条件名称</param>
	/// <param name="message">抛出异常时的错误消息</param>
	/// <exception cref="T:System.ArgumentException">当前断言条件为false时，抛出异常。</exception>
	[Conditional("DEBUG")]
	public static void Assert(bool predicate, string name = null, string message = null)
	{
		Ensure(predicate, name, message);
	}

	/// <summary>
	/// 检测当前断言条件是否为true，不满足则抛出由参数 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <param name="predicate">断言条件</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <exception cref="T:System.ArgumentNullException">异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常生成方法 <paramref name="exceptionCreator" /> 执行异常或者返回空。</exception>
	/// <exception cref="T:System.Exception">当前断言条件是否为false时，抛出由参数 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	[Conditional("DEBUG")]
	public static void Assert(bool predicate, Func<Exception> exceptionCreator)
	{
		Ensure(predicate, exceptionCreator);
	}

	/// <summary>
	/// 检测当前断言条件是否为true，不满足则抛出由参数 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <param name="predicate">断言条件</param>
	/// <param name="exceptionType">不满足条件时抛出的异常类型</param>
	/// <param name="args">异常参数列表</param>
	/// <exception cref="T:System.ArgumentNullException">异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">异常类型 <paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常类型 <paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前断言条件是否为false时，抛出由参数 <paramref name="exceptionType" /> 指定的异常</exception>
	[Conditional("DEBUG")]
	public static void Assert(bool predicate, Type exceptionType, params object[] args)
	{
		Ensure(predicate, exceptionType, args);
	}

	/// <summary>
	/// 检测当前断言是否为true，不满足则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <param name="predicate">当前断言</param>
	/// <param name="name">断言条件名称</param>
	/// <param name="message">抛出异常时的错误消息</param>
	/// <exception cref="T:System.ArgumentNullException">当前断言 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前断言条件为false时，抛出异常。</exception>
	[Conditional("DEBUG")]
	public static void Assert(Func<bool> predicate, string name = null, string message = null)
	{
		Ensure(predicate, name, message);
	}

	/// <summary>
	/// 检测当前断言是否为true，不满足则抛出由参数 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <param name="predicate">当前断言</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前断言 <paramref name="predicate" /> 为空；或者异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常生成方法 <paramref name="exceptionCreator" /> 执行异常或者返回空。</exception>
	/// <exception cref="T:System.Exception">当前断言是否为false时，抛出由参数 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	[Conditional("DEBUG")]
	public static void Assert(Func<bool> predicate, Func<Exception> exceptionCreator)
	{
		Ensure(predicate, exceptionCreator);
	}

	/// <summary>
	/// 检测当前断言是否为true，不满足则抛出由参数 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <param name="predicate">当前断言</param>
	/// <param name="exceptionType">不满足条件时抛出的异常类型</param>
	/// <param name="args">异常参数列表</param>
	/// <exception cref="T:System.ArgumentNullException">当前断言 <paramref name="predicate" /> 为空；或者异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">异常类型 <paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常类型 <paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前断言条件是否为false时，抛出由参数 <paramref name="exceptionType" /> 指定的异常</exception>
	[Conditional("DEBUG")]
	public static void Assert(Func<bool> predicate, Type exceptionType, params object[] args)
	{
		Ensure(predicate, exceptionType, args);
	}

	/// <summary>
	/// 检测当前对象是否满足指定断言，不满足则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="obj">当前对象</param>
	/// <param name="predicate">对象检测断言</param>
	/// <param name="name">当前对象名称</param>
	/// <param name="message">抛出异常时的错误信息</param>
	/// <exception cref="T:System.ArgumentNullException">对象检测断言 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">对象检测断言为false时，抛出异常。</exception>
	[Conditional("DEBUG")]
	public static void Assert<T>(T obj, Func<T, bool> predicate, string name = null, string message = null)
	{
		Ensure(obj, predicate, name, message);
	}

	/// <summary>
	/// 检测当前对象是否满足指定断言，不满足则抛出由参数 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="obj">当前对象</param>
	/// <param name="predicate">对象检测断言</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <exception cref="T:System.ArgumentNullException">对象检测断言；或者异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常生成方法 <paramref name="exceptionCreator" /> 执行异常或者返回空。</exception>
	/// <exception cref="T:System.Exception">当前对象不满足指定断言，抛出由参数 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	[Conditional("DEBUG")]
	public static void Assert<T>(T obj, Func<T, bool> predicate, Func<Exception> exceptionCreator)
	{
		Ensure(obj, predicate, exceptionCreator);
	}

	/// <summary>
	/// 检测当前对象是否满足指定断言，不满足则抛出由参数 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="obj">当前对象</param>
	/// <param name="predicate">对象检测条件</param>
	/// <param name="exceptionType">不满足条件时抛出的异常类型</param>
	/// <param name="args">异常参数列表</param>
	/// <exception cref="T:System.ArgumentNullException">对象检测条件 <paramref name="predicate" /> 为空；或者异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">异常类型 <paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常类型 <paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象不满足指定断言，抛出由参数 <paramref name="exceptionType" /> 指定的异常</exception>
	[Conditional("DEBUG")]
	public static void Assert<T>(T obj, Func<T, bool> predicate, Type exceptionType, params object[] args)
	{
		Ensure(obj, predicate, exceptionType, args);
	}

	/// <summary>
	/// 检测当前序列中的所有元素是否全部满足指定的条件，不全部满足则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <param name="items">当前序列</param>
	/// <param name="predicate">指定的检测规则</param>
	/// <param name="name">序列名称</param>
	/// <param name="message">异常信息</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测规则 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前序列中的任一元素不满足指定检测规则。</exception>
	[Conditional("DEBUG")]
	public static void AssertAll(IEnumerable items, Func<object, bool> predicate, string name = null, string message = null)
	{
		EnsureAll(items, predicate, name, message);
	}

	/// <summary>
	/// 检测当前序列中的所有元素是否全部满足指定的条件，不全部满足则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <param name="items">当前序列</param>
	/// <param name="predicate">指定的检测规则</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测规则 <paramref name="predicate" /> 为空；或者异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前序列中的任一元素不满足指定检测规则，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertAll(IEnumerable items, Func<object, bool> predicate, Func<Exception> exceptionCreator)
	{
		EnsureAll(items, predicate, exceptionCreator);
	}

	/// <summary>
	/// 检测当前序列中的所有元素是否全部满足指定的条件，不全部满足则抛出 <paramref name="exceptionType" /> 类型的异常
	/// </summary>
	/// <param name="items">当前序列</param>
	/// <param name="predicate">指定的检测规则</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测规则 <paramref name="predicate" /> 为空；或者异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前序列中的任一元素不满足指定检测规则，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertAll(IEnumerable items, Func<object, bool> predicate, Type exceptionType, params object[] args)
	{
		EnsureAll(items, predicate, exceptionType, args);
	}

	/// <summary>
	/// 检测当前序列中的所有元素是否全部满足指定的条件，不全部满足则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="items">当前序列</param>
	/// <param name="predicate">指定的检测规则</param>
	/// <param name="name">序列名称</param>
	/// <param name="message">异常信息</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测规则 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前序列中的任一元素不满足指定检测规则。</exception>
	[Conditional("DEBUG")]
	public static void AssertAll<T>(IEnumerable<T> items, Func<T, bool> predicate, string name = null, string message = null)
	{
		EnsureAll(items, predicate, name, message);
	}

	/// <summary>
	/// 检测当前序列中的所有元素是否全部满足指定的条件，不全部满足则抛出指定异常
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="items">当前序列</param>
	/// <param name="predicate">指定的检测规则</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测规则 <paramref name="predicate" /> 为空；或者异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前序列中的任一元素不满足指定检测规则，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertAll<T>(IEnumerable<T> items, Func<T, bool> predicate, Func<Exception> exceptionCreator)
	{
		EnsureAll(items, predicate, exceptionCreator);
	}

	/// <summary>
	/// 检测当前序列中的所有元素是否全部满足指定的条件，不全部满足则抛出指定异常
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="items">当前序列</param>
	/// <param name="predicate">指定的检测规则</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测规则 <paramref name="predicate" /> 为空；或者异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前序列中的任一元素不满足指定检测规则，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertAll<T>(IEnumerable<T> items, Func<T, bool> predicate, Type exceptionType, params object[] args)
	{
		EnsureAll(items, predicate, exceptionType, args);
	}

	/// <summary>
	/// 检测当前序列中的所有元素是否全部不满足指定的条件，如果存在满足条件的元素则抛出 <see cref="T:System.ArgumentException" /> 异常。
	/// </summary>
	/// <param name="items">当前序列</param>
	/// <param name="predicate">指定的检测规则</param>
	/// <param name="name">序列名称</param>
	/// <param name="message">异常信息</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测规则 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前序列中的任一元素满足指定检测规则。</exception>
	[Conditional("DEBUG")]
	public static void AssertAllNot(IEnumerable items, Func<object, bool> predicate, string name = null, string message = null)
	{
		EnsureAllNot(items, predicate, name, message);
	}

	/// <summary>
	/// 检测当前序列中的所有元素是否全部不满足指定的条件，如果存在满足条件的元素则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <param name="items">当前序列</param>
	/// <param name="predicate">指定的检测规则</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测规则 <paramref name="predicate" /> 为空；或者异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前序列中的任一元素满足指定检测规则，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertAllNot(IEnumerable items, Func<object, bool> predicate, Func<Exception> exceptionCreator)
	{
		EnsureAllNot(items, predicate, exceptionCreator);
	}

	/// <summary>
	/// 检测当前序列中的所有元素是否全部不满足指定的条件，如果存在满足条件的元素则抛出 <paramref name="exceptionType" /> 类型的异常
	/// </summary>
	/// <param name="items">当前序列</param>
	/// <param name="predicate">指定的检测规则</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测规则 <paramref name="predicate" /> 为空；或者异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前序列中的任一元素满足指定检测规则，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertAllNot(IEnumerable items, Func<object, bool> predicate, Type exceptionType, params object[] args)
	{
		EnsureAllNot(items, predicate, exceptionType, args);
	}

	/// <summary>
	/// 检测当前序列中的所有元素是否全部不满足指定的条件，如果存在满足条件的元素则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="items">当前序列</param>
	/// <param name="predicate">指定的检测规则</param>
	/// <param name="name">序列名称</param>
	/// <param name="message">异常信息</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测规则 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前序列中的任一元素满足指定检测规则。</exception>
	[Conditional("DEBUG")]
	public static void AssertAllNot<T>(IEnumerable<T> items, Func<T, bool> predicate, string name = null, string message = null)
	{
		EnsureAllNot(items, predicate, name, message);
	}

	/// <summary>
	/// 检测当前序列中的所有元素是否全部不满足指定的条件，如果存在满足条件的元素则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="items">当前序列</param>
	/// <param name="predicate">指定的检测规则</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测规则 <paramref name="predicate" /> 为空；或者异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前序列中的任一元素满足指定检测规则，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertAllNot<T>(IEnumerable<T> items, Func<T, bool> predicate, Func<Exception> exceptionCreator)
	{
		EnsureAllNot(items, predicate, exceptionCreator);
	}

	/// <summary>
	/// 检测当前序列中的所有元素是否全部不满足指定的条件，如果存在满足条件的元素则抛出 <paramref name="exceptionType" /> 类型的异常
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="items">当前待检测的序列</param>
	/// <param name="predicate">指定的检测规则</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测规则 <paramref name="predicate" /> 为空；或者异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前序列中的任一元素满足指定检测规则，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertAllNot<T>(IEnumerable<T> items, Func<T, bool> predicate, Type exceptionType, params object[] args)
	{
		EnsureAllNot(items, predicate, exceptionType, args);
	}

	/// <summary>
	/// 检测当前序列中是否有满足指定的条件的元素，如果不存在满足条件的元素则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <param name="items">当前待检测的序列</param>
	/// <param name="predicate">指定的检测规则</param>
	/// <param name="name">序列名称</param>
	/// <param name="message">异常信息</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测规则 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前序列中的元素全部不满足指定检测规则。</exception>
	[Conditional("DEBUG")]
	public static void AssertAny(IEnumerable items, Func<object, bool> predicate, string name = null, string message = null)
	{
		EnsureAny(items, predicate, name, message);
	}

	/// <summary>
	/// 检测当前序列中是否有满足指定的条件的元素，如果不存在满足条件的元素则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <param name="items">当前待检测的序列</param>
	/// <param name="predicate">指定的检测规则</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测规则 <paramref name="predicate" /> 为空；或者异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前序列中的元素全部不满足指定检测规则，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertAny(IEnumerable items, Func<object, bool> predicate, Func<Exception> exceptionCreator)
	{
		EnsureAny(items, predicate, exceptionCreator);
	}

	/// <summary>
	/// 检测当前序列中是否有满足指定的条件的元素，如果不存在满足条件的元素则抛出 <paramref name="exceptionType" /> 类型的异常
	/// </summary>
	/// <param name="items">当前待检测的序列</param>
	/// <param name="predicate">指定的检测规则</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测规则 <paramref name="predicate" /> 为空；或者异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前序列中的元素全部不满足指定检测规则，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertAny(IEnumerable items, Func<object, bool> predicate, Type exceptionType, params object[] args)
	{
		EnsureAny(items, predicate, exceptionType, args);
	}

	/// <summary>
	/// 检测当前序列中是否有满足指定的条件的元素，如果不存在满足条件的元素则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="items">当前待检测的序列</param>
	/// <param name="predicate">指定的检测规则</param>
	/// <param name="name">序列名称</param>
	/// <param name="message">异常信息</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测规则 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前序列中的元素全部不满足指定检测规则。</exception>
	[Conditional("DEBUG")]
	public static void AssertAny<T>(IEnumerable<T> items, Func<T, bool> predicate, string name = null, string message = null)
	{
		EnsureAny(items, predicate, name, message);
	}

	/// <summary>
	/// 检测当前序列中是否有满足指定的条件的元素，如果不存在满足条件的元素则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="items">当前待检测的序列</param>
	/// <param name="predicate">指定的检测规则</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测规则 <paramref name="predicate" /> 为空；或者异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前序列中的元素全部不满足指定检测规则，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertAny<T>(IEnumerable<T> items, Func<T, bool> predicate, Func<Exception> exceptionCreator)
	{
		EnsureAny(items, predicate, exceptionCreator);
	}

	/// <summary>
	/// 检测当前序列中是否有满足指定的条件的元素，如果不存在满足条件的元素则抛出 <paramref name="exceptionType" /> 类型的异常
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="items">当前待检测的序列</param>
	/// <param name="predicate">指定的检测规则</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测规则 <paramref name="predicate" /> 为空；或者异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前序列中的元素全部不满足指定检测规则，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertAny<T>(IEnumerable<T> items, Func<T, bool> predicate, Type exceptionType, params object[] args)
	{
		EnsureAny(items, predicate, exceptionType, args);
	}

	/// <summary>
	/// 检测当前序列中是否有不满足指定的条件的元素，全部都满足条件的元素则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <param name="items">当前序列</param>
	/// <param name="predicate">指定的检测规则</param>
	/// <param name="name">序列名称</param>
	/// <param name="message">异常信息</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测规则 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前序列中的元素全部满足指定检测规则。</exception>
	[Conditional("DEBUG")]
	public static void AssertAnyNot(IEnumerable items, Func<object, bool> predicate, string name = null, string message = null)
	{
		EnsureAnyNot(items, predicate, name, message);
	}

	/// <summary>
	/// 检测当前序列中是否有不满足指定的条件的元素，全部都满足条件的元素则抛出指定异常
	/// </summary>
	/// <param name="items">当前待检测的序列</param>
	/// <param name="predicate">指定的检测规则</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测规则 <paramref name="predicate" /> 为空；或者异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前序列中的元素全部满足指定检测规则，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertAnyNot(IEnumerable items, Func<object, bool> predicate, Func<Exception> exceptionCreator)
	{
		EnsureAnyNot(items, predicate, exceptionCreator);
	}

	/// <summary>
	/// 检测当前序列中是否有不满足指定的条件的元素，全部都满足条件的元素则抛出指定异常
	/// </summary>
	/// <param name="items">当前待检测的序列</param>
	/// <param name="predicate">指定的检测规则</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测规则 <paramref name="predicate" /> 为空；或者异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前序列中的元素全部满足指定检测规则，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertAnyNot(IEnumerable items, Func<object, bool> predicate, Type exceptionType, params object[] args)
	{
		EnsureAnyNot(items, predicate, exceptionType, args);
	}

	/// <summary>
	/// 检测当前序列中是否有不满足指定的条件的元素，全部都满足条件的元素则抛出ArgumentException
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="items">当前待检测的序列</param>
	/// <param name="predicate">指定的检测规则</param>
	/// <param name="name">序列名称</param>
	/// <param name="message">异常信息</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测规则 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前序列中的元素全部满足指定检测规则。</exception>
	public static void AssertAnyNot<T>(IEnumerable<T> items, Func<T, bool> predicate, string name = null, string message = null)
	{
		EnsureAnyNot(items, predicate, name, message);
	}

	/// <summary>
	/// 检测当前序列中是否有不满足指定的条件的元素，全部都满足条件的元素则抛出指定异常
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="items">当前待检测的序列</param>
	/// <param name="predicate">指定的检测规则</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测规则 <paramref name="predicate" /> 为空；或者异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前序列中的元素全部满足指定检测规则，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static void AssertAnyNot<T>(IEnumerable<T> items, Func<T, bool> predicate, Func<Exception> exceptionCreator)
	{
		EnsureAnyNot(items, predicate, exceptionCreator);
	}

	/// <summary>
	/// 检测当前序列中是否有不满足指定的条件的元素，全部都满足条件的元素则抛出指定异常
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="items">当前待检测的序列</param>
	/// <param name="predicate">指定的检测规则</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测规则 <paramref name="predicate" /> 为空；或者异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前序列中的元素全部满足指定检测规则，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static void AssertAnyNot<T>(IEnumerable<T> items, Func<T, bool> predicate, Type exceptionType, params object[] args)
	{
		EnsureAnyNot(items, predicate, exceptionType, args);
	}

	/// <summary>
	/// 检测当前数组的元素个数，如果数组的元素个数不等于 <paramref name="length" />，则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="length">数组需要满足的指定长度</param>
	/// <param name="name">数组对象名称</param>
	/// <param name="message">异常信息</param>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="length" /> 小于0。</exception>
	/// <exception cref="T:System.ArgumentException">如果当前数组元素个数不等于 <paramref name="length" />，则抛出该异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertArrayLength(Array array, int length, string name = null, string message = null)
	{
		EnsureArrayLength(array, length, name, message);
	}

	/// <summary>
	/// 检测当前数组的元素个数，如果数组的元素个数不等于 <paramref name="length" />，则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="length">数组需要满足的指定长度</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="length" /> 小于0。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">如果当前数组元素个数不等于 <paramref name="length" />，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertArrayLength(Array array, int length, Func<Exception> exceptionCreator)
	{
		EnsureArrayLength(array, length, exceptionCreator);
	}

	/// <summary>
	/// 检测当前数组的元素个数，如果数组的元素个数不等于 <paramref name="length" />，则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="length">数组需要满足的指定长度</param>
	/// <param name="exceptionType">抛出的异常类型</param>
	/// <param name="args">异常参数</param>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="length" /> 小于0。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">如果当前数组元素个数不等于 <paramref name="length" />，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertArrayLength(Array array, int length, Type exceptionType, params object[] args)
	{
		EnsureArrayLength(array, length, exceptionType, args);
	}

	/// <summary>
	/// 检测当前数组的元素个数，如果数组的元素个数不等于 <paramref name="length" />，则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="length">数组需要满足的指定长度</param>
	/// <param name="name">数组对象名称</param>
	/// <param name="message">异常信息</param>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="length" /> 小于0。</exception>
	/// <exception cref="T:System.ArgumentException">如果当前数组元素个数不等于 <paramref name="length" />，则抛出该异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertArrayLength(Array array, long length, string name = null, string message = null)
	{
		EnsureArrayLength(array, length, name, message);
	}

	/// <summary>
	/// 检测当前数组的元素个数，如果数组的元素个数不等于 <paramref name="length" />，则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="length">数组需要满足的指定长度</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="length" /> 小于0。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">如果当前数组元素个数不等于 <paramref name="length" />，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertArrayLength(Array array, long length, Func<Exception> exceptionCreator)
	{
		EnsureArrayLength(array, length, exceptionCreator);
	}

	/// <summary>
	/// 检测当前数组的元素个数，如果数组的元素个数不等于 <paramref name="length" />，则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="length">数组需要满足的指定长度</param>
	/// <param name="exceptionType">抛出的异常类型</param>
	/// <param name="args">异常参数</param>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="length" /> 小于0。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">如果当前数组元素个数不等于 <paramref name="length" />，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertArrayLength(Array array, long length, Type exceptionType, params object[] args)
	{
		EnsureArrayLength(array, length, exceptionType, args);
	}

	/// <summary>
	/// 检测当前数组的元素个数，如果数组的元素个数不等于 <paramref name="length" />，则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="length">数组需要满足的指定长度</param>
	/// <param name="name">数组对象名称</param>
	/// <param name="message">异常信息</param>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="length" /> 小于0。</exception>
	/// <exception cref="T:System.ArgumentException">如果当前数组元素个数不等于 <paramref name="length" />，则抛出该异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertArrayLength<T>(T[] array, int length, string name = null, string message = null)
	{
		EnsureArrayLength(array, length, name, message);
	}

	/// <summary>
	/// 检测当前数组的元素个数，如果数组的元素个数不等于 <paramref name="length" />，则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="length">数组需要满足的指定长度</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="length" /> 小于0。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">如果当前数组元素个数不等于 <paramref name="length" />，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertArrayLength<T>(T[] array, int length, Func<Exception> exceptionCreator)
	{
		EnsureArrayLength(array, length, exceptionCreator);
	}

	/// <summary>
	/// 检测当前数组的元素个数，如果数组的元素个数不等于 <paramref name="length" />，则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="length">数组需要满足的指定长度</param>
	/// <param name="exceptionType">抛出的异常类型</param>
	/// <param name="args">异常参数</param>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="length" /> 小于0。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">如果当前数组元素个数不等于 <paramref name="length" />，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertArrayLength<T>(T[] array, int length, Type exceptionType, params object[] args)
	{
		EnsureArrayLength(array, length, exceptionType, args);
	}

	/// <summary>
	/// 检测当前数组的元素个数，如果数组的元素个数不等于 <paramref name="length" />，则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="length">数组需要满足的指定长度</param>
	/// <param name="name">数组对象名称</param>
	/// <param name="message">异常信息</param>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="length" /> 小于0。</exception>
	/// <exception cref="T:System.ArgumentException">如果当前数组元素个数不等于 <paramref name="length" />，则抛出该异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertArrayLength<T>(T[] array, long length, string name = null, string message = null)
	{
		EnsureArrayLength(array, length, name, message);
	}

	/// <summary>
	/// 检测当前数组的元素个数，如果数组的元素个数不等于 <paramref name="length" />，则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="length">数组需要满足的指定长度</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="length" /> 小于0。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">如果当前数组元素个数不等于 <paramref name="length" />，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertArrayLength<T>(T[] array, long length, Func<Exception> exceptionCreator)
	{
		EnsureArrayLength(array, length, exceptionCreator);
	}

	/// <summary>
	/// 检测当前数组的元素个数，如果数组的元素个数不等于 <paramref name="length" />，则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="length">数组需要满足的指定长度</param>
	/// <param name="exceptionType">抛出的异常类型</param>
	/// <param name="args">异常参数</param>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="length" /> 小于0。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">如果当前数组元素个数不等于 <paramref name="length" />，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertArrayLength<T>(T[] array, long length, Type exceptionType, params object[] args)
	{
		EnsureArrayLength(array, length, exceptionType, args);
	}

	/// <summary>
	/// 检测当前数组的秩（维数），如果数组的秩（维数）不等于 <paramref name="rank" />，则抛出 <see cref="T:System.RankException" /> 异常
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="rank">数组需要满足的秩（维数）</param>
	/// <param name="name">数组对象名称</param>
	/// <param name="message">异常信息</param>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="rank" /> 小于1。</exception>
	/// <exception cref="T:System.RankException">当前数组的秩（维数）不等于 <paramref name="rank" />。</exception>
	[Conditional("DEBUG")]
	public static void AssertArrayRank(Array array, int rank, string name = null, string message = null)
	{
		EnsureArrayRank(array, rank, name, message);
	}

	/// <summary>
	/// 检测当前数组的秩（维数），如果数组的秩（维数）不等于 <paramref name="rank" />，则抛出 <paramref name="exceptionCreator" /> 生成的异常。
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="rank">数组需要满足的秩（维数）</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="rank" /> 小于1。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前数组的秩（维数）不等于 <paramref name="rank" />，则抛出 <paramref name="exceptionCreator" /> 生成的异常</exception>
	[Conditional("DEBUG")]
	public static void AssertArrayRank(Array array, int rank, Func<Exception> exceptionCreator)
	{
		EnsureArrayRank(array, rank, exceptionCreator);
	}

	/// <summary>
	/// 检测当前数组的秩（维数），如果数组的秩（维数）不等于 <paramref name="rank" />，则抛出 <paramref name="exceptionType" /> 指定的异常。
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="rank">数组需要满足的秩（维数）</param>
	/// <param name="exceptionType">抛出的异常类型</param>
	/// <param name="args">异常参数</param>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="rank" /> 小于1。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前数组的秩（维数）不等于 <paramref name="rank" />，则抛出 <paramref name="exceptionType" /> 指定的异常</exception>
	[Conditional("DEBUG")]
	public static void AssertArrayRank(Array array, int rank, Type exceptionType, params object[] args)
	{
		EnsureArrayRank(array, rank, exceptionType, args);
	}

	/// <summary>
	/// 检测当前数组的秩（维数），如果数组的秩（维数）不等于 <paramref name="rank" />，则抛出 <see cref="T:System.RankException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="rank">数组需要满足的秩（维数）</param>
	/// <param name="name">数组对象名称</param>
	/// <param name="message">异常信息</param>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="rank" /> 小于1。</exception>
	/// <exception cref="T:System.RankException">当前数组的秩（维数）不等于 <paramref name="rank" />。</exception>
	[Conditional("DEBUG")]
	public static void AssertArrayRank<T>(T[] array, int rank, string name = null, string message = null)
	{
		EnsureArrayRank(array, rank, name, message);
	}

	/// <summary>
	/// 检测当前数组的秩（维数），如果数组的秩（维数）不等于 <paramref name="rank" />，则抛出 <paramref name="exceptionCreator" /> 生成的异常。
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">前数组</param>
	/// <param name="rank">数组需要满足的秩（维数）</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="rank" /> 小于1。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前数组的秩（维数）不等于 <paramref name="rank" />，则抛出 <paramref name="exceptionCreator" /> 生成的异常</exception>
	[Conditional("DEBUG")]
	public static void AssertArrayRank<T>(T[] array, int rank, Func<Exception> exceptionCreator)
	{
		EnsureArrayRank(array, rank, exceptionCreator);
	}

	/// <summary>
	/// 检测当前数组的秩（维数），如果数组的秩（维数）不等于 <paramref name="rank" />，则抛出 <paramref name="exceptionType" /> 指定的异常。
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="rank">数组需要满足的秩（维数）</param>
	/// <param name="exceptionType">抛出的异常类型</param>
	/// <param name="args">异常参数</param>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="rank" /> 小于1。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前数组的秩（维数）不等于 <paramref name="rank" />，则抛出 <paramref name="exceptionType" /> 指定的异常</exception>
	[Conditional("DEBUG")]
	public static void AssertArrayRank<T>(T[] array, int rank, Type exceptionType, params object[] args)
	{
		EnsureArrayRank(array, rank, exceptionType, args);
	}

	/// <summary>
	/// 检测当前数组的指定秩（维度） <paramref name="rank" /> 的元素数量，如果不等于 <paramref name="length" /> 则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="rank">数组检查元素数量的秩（维度），从1开始</param>
	/// <param name="length">数组指定秩（维度）中元素数量的条件</param>
	/// <param name="name">数组的名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过返回当前数组本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="rank" /> 小于1；或者 <paramref name="length" /> 小于0。</exception>
	/// <exception cref="T:System.ArgumentException">如果当前数组指定秩（维数）<paramref name="rank" /> 的元素数量不等于 <paramref name="length" />，则抛出该异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertArrayRankLength(Array array, int rank, int length, string name = null, string message = null)
	{
		EnsureArrayRankLength(array, rank, length, name, message);
	}

	/// <summary>
	/// 检测当前数组的指定秩（维度） <paramref name="rank" /> 的元素数量，如果不等于 <paramref name="length" /> 则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="rank">数组检查元素数量的秩（维度），从1开始</param>
	/// <param name="length">数组指定秩（维度）中元素数量的条件</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过返回当前数组本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="rank" /> 小于1；或者 <paramref name="length" /> 小于0。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">如果当前数组指定秩（维数）<paramref name="rank" /> 的元素数量不等于 <paramref name="length" />，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertArrayRankLength(Array array, int rank, int length, Func<Exception> exceptionCreator)
	{
		EnsureArrayRankLength(array, rank, length, exceptionCreator);
	}

	/// <summary>
	/// 检测当前数组的指定秩（维度） <paramref name="rank" /> 的元素数量，如果不等于 <paramref name="length" /> 则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="rank">数组检查元素数量的秩（维度），从1开始</param>
	/// <param name="length">数组指定秩（维度）中元素数量的条件</param>
	/// <param name="exceptionType">抛出的异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检测通过返回当前数组本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="rank" /> 小于1；或者 <paramref name="length" /> 小于0。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">如果当前数组指定秩（维数）<paramref name="rank" /> 的元素数量不等于 <paramref name="length" />，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertArrayRankLength(Array array, int rank, int length, Type exceptionType, params object[] args)
	{
		EnsureArrayRankLength(array, rank, length, exceptionType, args);
	}

	/// <summary>
	/// 检测当前数组的指定秩（维度） <paramref name="rank" /> 的元素数量，如果不等于 <paramref name="length" /> 则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="rank">数组检查元素数量的秩（维度），从1开始</param>
	/// <param name="length">数组指定秩（维度）中元素数量的条件</param>
	/// <param name="name">数组的名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过返回当前数组本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="rank" /> 小于1；或者 <paramref name="length" /> 小于0。</exception>
	/// <exception cref="T:System.ArgumentException">如果当前数组指定秩（维数）<paramref name="rank" /> 的元素数量不等于 <paramref name="length" />，则抛出该异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertArrayRankLength(Array array, int rank, long length, string name = null, string message = null)
	{
		EnsureArrayRankLength(array, rank, length, name, message);
	}

	/// <summary>
	/// 检测当前数组的指定秩（维度） <paramref name="rank" /> 的元素数量，如果不等于 <paramref name="length" /> 则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="rank">数组检查元素数量的秩（维度），从1开始</param>
	/// <param name="length">数组指定秩（维度）中元素数量的条件</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过返回当前数组本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="rank" /> 小于1；或者 <paramref name="length" /> 小于0。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">如果当前数组指定秩（维数）<paramref name="rank" /> 的元素数量不等于 <paramref name="length" />，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertArrayRankLength(Array array, int rank, long length, Func<Exception> exceptionCreator)
	{
		EnsureArrayRankLength(array, rank, length, exceptionCreator);
	}

	/// <summary>
	/// 检测当前数组的指定秩（维度） <paramref name="rank" /> 的元素数量，如果不等于 <paramref name="length" /> 则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="rank">数组检查元素数量的秩（维度），从1开始</param>
	/// <param name="length">数组指定秩（维度）中元素数量的条件</param>
	/// <param name="exceptionType">抛出的异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检测通过返回当前数组本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="rank" /> 小于1；或者 <paramref name="length" /> 小于0。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">如果当前数组指定秩（维数）<paramref name="rank" /> 的元素数量不等于 <paramref name="length" />，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertArrayRankLength(Array array, int rank, long length, Type exceptionType, params object[] args)
	{
		EnsureArrayRankLength(array, rank, length, exceptionType, args);
	}

	/// <summary>
	/// 检测当前数组的指定秩（维度） <paramref name="rank" /> 的元素数量，如果不等于 <paramref name="length" /> 则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="rank">数组检查元素数量的秩（维度），从1开始</param>
	/// <param name="length">数组指定秩（维度）中元素数量的条件</param>
	/// <param name="name">数组的名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过返回当前数组本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="rank" /> 小于1；或者 <paramref name="length" /> 小于0。</exception>
	/// <exception cref="T:System.ArgumentException">如果当前数组指定秩（维数）<paramref name="rank" /> 的元素数量不等于 <paramref name="length" />，则抛出该异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertArrayRankLength<T>(T[] array, int rank, int length, string name = null, string message = null)
	{
		EnsureArrayRankLength(array, rank, length, name, message);
	}

	/// <summary>
	/// 检测当前数组的指定秩（维度） <paramref name="rank" /> 的元素数量，如果不等于 <paramref name="length" /> 则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="rank">数组检查元素数量的秩（维度），从1开始</param>
	/// <param name="length">数组指定秩（维度）中元素数量的条件</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过返回当前数组本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="rank" /> 小于1；或者 <paramref name="length" /> 小于0。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">如果当前数组指定秩（维数）<paramref name="rank" /> 的元素数量不等于 <paramref name="length" />，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertArrayRankLength<T>(T[] array, int rank, int length, Func<Exception> exceptionCreator)
	{
		EnsureArrayRankLength(array, rank, length, exceptionCreator);
	}

	/// <summary>
	/// 检测当前数组的指定秩（维度） <paramref name="rank" /> 的元素数量，如果不等于 <paramref name="length" /> 则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="rank">数组检查元素数量的秩（维度），从1开始</param>
	/// <param name="length">数组指定秩（维度）中元素数量的条件</param>
	/// <param name="exceptionType">抛出的异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检测通过返回当前数组本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="rank" /> 小于1；或者 <paramref name="length" /> 小于0。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">如果当前数组指定秩（维数）<paramref name="rank" /> 的元素数量不等于 <paramref name="length" />，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertArrayRankLength<T>(T[] array, int rank, int length, Type exceptionType, params object[] args)
	{
		EnsureArrayRankLength(array, rank, length, exceptionType, args);
	}

	/// <summary>
	/// 检测当前数组的指定秩（维度） <paramref name="rank" /> 的元素数量，如果不等于 <paramref name="length" /> 则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="rank">数组检查元素数量的秩（维度），从1开始</param>
	/// <param name="length">数组指定秩（维度）中元素数量的条件</param>
	/// <param name="name">数组的名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过返回当前数组本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="rank" /> 小于1；或者 <paramref name="length" /> 小于0。</exception>
	/// <exception cref="T:System.ArgumentException">如果当前数组指定秩（维数）<paramref name="rank" /> 的元素数量不等于 <paramref name="length" />，则抛出该异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertArrayRankLength<T>(T[] array, int rank, long length, string name = null, string message = null)
	{
		EnsureArrayRankLength(array, rank, length, name, message);
	}

	/// <summary>
	/// 检测当前数组的指定秩（维度） <paramref name="rank" /> 的元素数量，如果不等于 <paramref name="length" /> 则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="rank">数组检查元素数量的秩（维度），从1开始</param>
	/// <param name="length">数组指定秩（维度）中元素数量的条件</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过返回当前数组本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="rank" /> 小于1；或者 <paramref name="length" /> 小于0。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">如果当前数组指定秩（维数）<paramref name="rank" /> 的元素数量不等于 <paramref name="length" />，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertArrayRankLength<T>(T[] array, int rank, long length, Func<Exception> exceptionCreator)
	{
		EnsureArrayRankLength(array, rank, length, exceptionCreator);
	}

	/// <summary>
	/// 检测当前数组的指定秩（维度） <paramref name="rank" /> 的元素数量，如果不等于 <paramref name="length" /> 则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="rank">数组检查元素数量的秩（维度），从1开始</param>
	/// <param name="length">数组指定秩（维度）中元素数量的条件</param>
	/// <param name="exceptionType">抛出的异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检测通过返回当前数组本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="rank" /> 小于1；或者 <paramref name="length" /> 小于0。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">如果当前数组指定秩（维数）<paramref name="rank" /> 的元素数量不等于 <paramref name="length" />，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertArrayRankLength<T>(T[] array, int rank, long length, Type exceptionType, params object[] args)
	{
		EnsureArrayRankLength(array, rank, length, exceptionType, args);
	}

	/// <summary>
	/// 检测当前数组是否与目标数组具有相同的结构（维度相同，各维度元素数量相同），如果不相同则抛出 <see cref="T:System.ArgumentException" /> 异常。
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="target">比较的目标数组</param>
	/// <param name="name">数组名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过则返回原数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="target" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">如果当前数组与目标数组不相同则抛出该异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertSameArray(Array array, Array target, string name = null, string message = null)
	{
		EnsureArraySameStructure(array, target, name, message);
	}

	/// <summary>
	/// 检测当前数组是否与目标数组具有相同的结构（维度相同，各维度元素数量相同），如果不相同则抛出 <paramref name="exceptionCreator" /> 生成的异常。
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="target">比较的目标数组</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过则返回原数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="target" /> 为空；或者 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">如果当前数组与目标数组不相同，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertSameArray(Array array, Array target, Func<Exception> exceptionCreator)
	{
		EnsureArraySameStructure(array, target, exceptionCreator);
	}

	/// <summary>
	/// 检测当前数组是否与目标数组具有相同的结构（维度相同，各维度元素数量相同），如果不相同则抛出 <paramref name="exceptionType" /> 指定的异常。
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="target">比较的目标数组</param>
	/// <param name="exceptionType">指定的异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检测通过则返回原数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="target" /> 为空；或者 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">如果当前数组与目标数组不相同，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertSameArray(Array array, Array target, Type exceptionType, params object[] args)
	{
		EnsureArraySameStructure(array, target, exceptionType, args);
	}

	/// <summary>
	/// 检测当前数组是否与目标数组具有相同的结构（维度相同，各维度元素数量相同），如果不相同则抛出 <see cref="T:System.ArgumentException" /> 异常。
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <typeparam name="K">比较的数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="target">比较的目标数组</param>
	/// <param name="name">数组名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过则返回原数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="target" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">如果当前数组与目标数组不相同则抛出该异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertSameArray<T, K>(T[] array, K[] target, string name = null, string message = null)
	{
		EnsureArraySameStructure(array, target, name, message);
	}

	/// <summary>
	/// 检测当前数组是否与目标数组具有相同的结构（维度相同，各维度元素数量相同），如果不相同则抛出 <paramref name="exceptionCreator" /> 生成的异常。
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <typeparam name="K">比较的数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="target">比较的目标数组</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过则返回原数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="target" /> 为空；或者 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">如果当前数组与目标数组不相同，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertSameArray<T, K>(T[] array, K[] target, Func<Exception> exceptionCreator)
	{
		EnsureArraySameStructure(array, target, exceptionCreator);
	}

	/// <summary>
	/// 检测当前数组是否与目标数组具有相同的结构（维度相同，各维度元素数量相同），如果不相同则抛出 <paramref name="exceptionType" /> 指定的异常。
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <typeparam name="K">比较的数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="target">比较的目标数组</param>
	/// <param name="exceptionType">指定的异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检测通过则返回原数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="target" /> 为空；或者 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">如果当前数组与目标数组不相同，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertSameArray<T, K>(T[] array, K[] target, Type exceptionType, params object[] args)
	{
		EnsureArraySameStructure(array, target, exceptionType, args);
	}

	/// <summary>
	/// 检测当前对象是否在指定范围内，超出指定的值范围则抛出 <see cref="T:System.ArgumentOutOfRangeException" /> 异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="min">最小值</param>
	/// <param name="max">最大值</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">错误消息</param>
	/// <param name="includeMin">值范围是否包含最小值，默认包含最小值</param>
	/// <param name="includeMax">值范围是否包含最大值，默认包含最大值</param>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空。</exception>
	[Conditional("DEBUG")]
	public static void AssertBetween(IComparable item, object min, object max, string name = null, string message = null, bool includeMin = true, bool includeMax = true)
	{
		EnsureBetween(item, min, max, name, message, includeMin, includeMax);
	}

	/// <summary>
	/// 检测当前对象是否在指定范围内，超出指定的值范围则抛出参数 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="min">最小值</param>
	/// <param name="max">最大值</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <param name="includeMin">值范围是否包含最小值，默认包含最小值</param>
	/// <param name="includeMax">值范围是否包含最大值，默认包含最大值</param>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常生成方法 <paramref name="exceptionCreator" /> 执行异常或者返回空。</exception>
	/// <exception cref="T:System.Exception">当前对象超出指定的范围，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertBetween(IComparable item, object min, object max, Func<Exception> exceptionCreator, bool includeMin = true, bool includeMax = true)
	{
		EnsureBetween(item, min, max, exceptionCreator, includeMin, includeMax);
	}

	/// <summary>
	/// 检测当前对象是否在指定范围内，超出指定的值范围则抛出参数 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="min">最小值</param>
	/// <param name="max">最大值</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <param name="includeMin">值范围是否包含最小值，默认包含最小值</param>
	/// <param name="includeMax">值范围是否包含最大值，默认包含最大值</param>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">异常类型 <paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常类型 <paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象超出指定的范围，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertBetween(IComparable item, object min, object max, Type exceptionType, object[] args = null, bool includeMin = true, bool includeMax = true)
	{
		EnsureBetween(item, min, max, exceptionType, args, includeMin, includeMax);
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
	/// <param name="includeMin">值范围是否包含最小值，默认包含最小值</param>
	/// <param name="includeMax">值范围是否包含最大值，默认包含最大值</param>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">当前对象超出指定的范围；或者值范围最小值 <paramref name="min" /> 大于最大值 <paramref name="max" /></exception>
	[Conditional("DEBUG")]
	public static void AssertBetween<T>(IComparable<T> item, T min, T max, string name = null, string message = null, bool includeMin = true, bool includeMax = true) where T : IComparable<T>
	{
		EnsureBetween(item, min, max, name, message, includeMin, includeMax);
	}

	/// <summary>
	/// 检测当前对象是否在指定范围内，超出指定的值范围则抛出参数 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="min">最小值</param>
	/// <param name="max">最大值</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <param name="includeMin">值范围是否包含最小值，默认包含最小值</param>
	/// <param name="includeMax">值范围是否包含最大值，默认包含最大值</param>
	/// <returns>如果检测通过则返回当前对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">值范围最小值 <paramref name="min" /> 大于最大值 <paramref name="max" /></exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常生成方法 <paramref name="exceptionCreator" /> 执行异常或者返回空。</exception>
	/// <exception cref="T:System.Exception">当前对象超出指定的范围，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertBetween<T>(IComparable<T> item, T min, T max, Func<Exception> exceptionCreator, bool includeMin = true, bool includeMax = true) where T : IComparable<T>
	{
		EnsureBetween(item, min, max, exceptionCreator, includeMin, includeMax);
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
	/// <param name="includeMin">值范围是否包含最小值，默认包含最小值</param>
	/// <param name="includeMax">值范围是否包含最大值，默认包含最大值</param>
	/// <returns>如果检测通过则返回当前对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">值范围最小值 <paramref name="min" /> 大于最大值 <paramref name="max" /></exception>
	/// <exception cref="T:System.NotSupportedException">异常类型 <paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常类型 <paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象超出指定的范围，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertBetween<T>(IComparable<T> item, T min, T max, Type exceptionType, object[] args = null, bool includeMin = true, bool includeMax = true) where T : IComparable<T>
	{
		EnsureBetween(item, min, max, exceptionType, args, includeMin, includeMax);
	}

	/// <summary>
	/// 检测当前对象是否不在指定范围内，在指定的值范围则抛出 <see cref="T:System.ArgumentOutOfRangeException" /> 异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="min">最小值</param>
	/// <param name="max">最大值</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">错误消息</param>
	/// <param name="includeMin">值范围是否包含最小值，默认包含最小值</param>
	/// <param name="includeMax">值范围是否包含最大值，默认包含最大值</param>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空。</exception>
	[Conditional("DEBUG")]
	public static void AssertNotBetween(IComparable item, object min, object max, string name = null, string message = null, bool includeMin = true, bool includeMax = true)
	{
		EnsureNotBetween(item, min, max, name, message, includeMin, includeMax);
	}

	/// <summary>
	/// 检测当前对象是否不在指定范围内，在指定的值范围则抛出参数 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="min">最小值</param>
	/// <param name="max">最大值</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <param name="includeMin">值范围是否包含最小值，默认包含最小值</param>
	/// <param name="includeMax">值范围是否包含最大值，默认包含最大值</param>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常生成方法 <paramref name="exceptionCreator" /> 执行异常或者返回空。</exception>
	/// <exception cref="T:System.Exception">当前对象在指定的范围中，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertNotBetween(IComparable item, object min, object max, Func<Exception> exceptionCreator, bool includeMin = true, bool includeMax = true)
	{
		EnsureNotBetween(item, min, max, exceptionCreator, includeMin, includeMax);
	}

	/// <summary>
	/// 检测当前对象是否不在指定范围内，在指定的值范围则抛出参数 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="min">最小值</param>
	/// <param name="max">最大值</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <param name="includeMin">值范围是否包含最小值，默认包含最小值</param>
	/// <param name="includeMax">值范围是否包含最大值，默认包含最大值</param>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">异常类型 <paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常类型 <paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象在指定的范围中，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertNotBetween(IComparable item, object min, object max, Type exceptionType, object[] args = null, bool includeMin = true, bool includeMax = true)
	{
		EnsureNotBetween(item, min, max, exceptionType, args, includeMin, includeMax);
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
	/// <param name="includeMin">值范围是否包含最小值，默认包含最小值</param>
	/// <param name="includeMax">值范围是否包含最大值，默认包含最大值</param>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">当前对象在指定的范围中；或者值范围最小值 <paramref name="min" /> 大于最大值 <paramref name="max" /></exception>
	[Conditional("DEBUG")]
	public static void AssertNotBetween<T>(IComparable<T> item, T min, T max, string name = null, string message = null, bool includeMin = true, bool includeMax = true) where T : IComparable<T>
	{
		EnsureNotBetween(item, min, max, name, message, includeMin, includeMax);
	}

	/// <summary>
	/// 检测当前对象是否不在指定范围内，在指定的值范围则抛出参数 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="min">最小值</param>
	/// <param name="max">最大值</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <param name="includeMin">值范围是否包含最小值，默认包含最小值</param>
	/// <param name="includeMax">值范围是否包含最大值，默认包含最大值</param>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">值范围最小值 <paramref name="min" /> 大于最大值 <paramref name="max" /></exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常生成方法 <paramref name="exceptionCreator" /> 执行异常或者返回空。</exception>
	/// <exception cref="T:System.Exception">当前对象在指定的范围中，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertNotBetween<T>(IComparable<T> item, T min, T max, Func<Exception> exceptionCreator, bool includeMin = true, bool includeMax = true) where T : IComparable<T>
	{
		EnsureNotBetween(item, min, max, exceptionCreator, includeMin, includeMax);
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
	/// <param name="includeMin">值范围是否包含最小值，默认包含最小值</param>
	/// <param name="includeMax">值范围是否包含最大值，默认包含最大值</param>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">值范围最小值 <paramref name="min" /> 大于最大值 <paramref name="max" /></exception>
	/// <exception cref="T:System.NotSupportedException">异常类型 <paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常类型 <paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象在指定的范围中，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertNotBetween<T>(IComparable<T> item, T min, T max, Type exceptionType, object[] args = null, bool includeMin = true, bool includeMax = true) where T : IComparable<T>
	{
		EnsureNotBetween(item, min, max, exceptionType, args, includeMin, includeMax);
	}

	/// <summary>
	/// 检测当前对象是否等于其类型的默认值，如果对象不等于其类型的默认值则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="type">当前对象类型</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <exception cref="T:System.ArgumentException">当前对象不等于其类型的默认值。</exception>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空时，当前对象类型 <paramref name="type" /> 为空。</exception>
	[Conditional("DEBUG")]
	public static void AssertDefault(object item, Type type, string name = null, string message = null)
	{
		EnsureDefault(item, type, name, message);
	}

	/// <summary>
	/// 检测当前对象是否等于其类型的默认值，如果对象不等于其类型的默认值则抛出参数 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="type">当前对象类型</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前对象不等于其类型的默认值，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertDefault(object item, Type type, Func<Exception> exceptionCreator)
	{
		EnsureDefault(item, type, exceptionCreator);
	}

	/// <summary>
	/// 检测当前对象是否等于其类型的默认值，如果对象不等于其类型的默认值则抛出参数 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="type">当前对象类型</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象不等于其类型的默认值，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertDefault(object item, Type type, Type exceptionType, params object[] args)
	{
		EnsureDefault(item, type, exceptionType, args);
	}

	/// <summary>
	/// 检测当前对象是否等于其类型的默认值，如果对象不等于其类型的默认值则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <exception cref="T:System.ArgumentException">当前对象不等于其类型的默认值。</exception>
	[Conditional("DEBUG")]
	public static void AssertDefault<T>(T item, string name = null, string message = null)
	{
		EnsureDefault(item, name, message);
	}

	/// <summary>
	/// 检测当前对象是否等于其类型的默认值，如果对象不等于其类型的默认值则抛出参数 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前对象不等于其类型的默认值，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertDefault<T>(T item, Func<Exception> exceptionCreator)
	{
		EnsureDefault(item, exceptionCreator);
	}

	/// <summary>
	/// 检测当前对象是否等于其类型的默认值，如果对象不等于其类型的默认值则抛出参数 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象不等于其类型的默认值，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertDefault<T>(T item, Type exceptionType, params object[] args)
	{
		EnsureDefault(item, exceptionType, args);
	}

	/// <summary>
	/// 检测当前对象是否不等于其类型的默认值，如果对象等于其类型的默认值则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="type">当前对象类型</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <exception cref="T:System.ArgumentException">当前对象等于其类型的默认值。</exception>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空时，对象类型也为空。</exception>
	[Conditional("DEBUG")]
	public static void AssertNotDefault(object item, Type type, string name = null, string message = null)
	{
		EnsureNotDefault(item, type, name, message);
	}

	/// <summary>
	/// 检测当前对象是否不等于其类型的默认值，如果对象等于其类型的默认值则抛出参数 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="type">当前对象类型</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前对象等于其类型的默认值，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertNotDefault(object item, Type type, Func<Exception> exceptionCreator)
	{
		EnsureNotDefault(item, type, exceptionCreator);
	}

	/// <summary>
	/// 检测当前对象是否不等于其类型的默认值，如果对象等于其类型的默认值则抛出参数 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="type">当前对象类型</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象等于其类型的默认值，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertNotDefault(object item, Type type, Type exceptionType, params object[] args)
	{
		EnsureNotDefault(item, type, exceptionType, args);
	}

	/// <summary>
	/// 检测当前对象是否不等于其类型的默认值，如果对象等于其类型的默认值则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <exception cref="T:System.ArgumentException">当前对象等于其类型的默认值。</exception>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空时，对象类型也为空。</exception>
	[Conditional("DEBUG")]
	public static void AssertNotDefault<T>(T item, string name = null, string message = null)
	{
		EnsureNotDefault(item, name, message);
	}

	/// <summary>
	/// 检测当前对象是否不等于其类型的默认值，如果对象等于其类型的默认值则抛出参数 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前对象等于其类型的默认值，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertNotDefault<T>(T item, Func<Exception> exceptionCreator)
	{
		EnsureNotDefault(item, exceptionCreator);
	}

	/// <summary>
	/// 检测当前对象是否不等于其类型的默认值，如果对象等于其类型的默认值则抛出参数 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象等于其类型的默认值，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertNotDefault<T>(T item, Type exceptionType, params object[] args)
	{
		EnsureNotDefault(item, exceptionType, args);
	}

	/// <summary>
	/// 检测当前目录是否存在，如果不存在则抛出 <see cref="T:System.IO.DirectoryNotFoundException" /> 异常。
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="message">错误消息</param>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	[Conditional("DEBUG")]
	public static void AssertDirectoryExistence(DirectoryInfo directory, string message = null)
	{
		EnsureDirectoryExistence(directory, message);
	}

	/// <summary>
	/// 检测当前目录是否存在，如果当前目录不存在则抛出 <paramref name="exceptionCreator" /> 生成的异常。
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">如果当前目录不存在则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertDirectoryExistence(DirectoryInfo directory, Func<Exception> exceptionCreator)
	{
		EnsureDirectoryExistence(directory, exceptionCreator);
	}

	/// <summary>
	/// 检测当前目录是否存在，如果当前目录不存在则抛出 <paramref name="exceptionType" /> 指定的异常。
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="exceptionType">抛出的异常类型</param>
	/// <param name="args">异常参数</param>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">如果当前目录不存在则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertDirectoryExistence(DirectoryInfo directory, Type exceptionType, params object[] args)
	{
		EnsureDirectoryExistence(directory, exceptionType, args);
	}

	/// <summary>
	/// 检测当前目录是否存在，如果不存在则抛出 <see cref="T:System.IO.DirectoryNotFoundException" /> 异常。
	/// </summary>
	/// <param name="directory">当前目录路径</param>
	/// <param name="message">错误消息</param>
	/// <exception cref="T:System.ArgumentNullException">当前目录路径为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录路径指定的目录不存在。</exception>
	[Conditional("DEBUG")]
	public static void AssertDirectoryExistence(string directory, string message = null)
	{
		EnsureDirectoryExistence(directory, message);
	}

	/// <summary>
	/// 检测当前目录是否存在，如果不存在则抛出 <paramref name="exceptionCreator" /> 生成的异常。
	/// </summary>
	/// <param name="directory">当前目录路径</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">如果当前目录路径指定的目录不存在则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertDirectoryExistence(string directory, Func<Exception> exceptionCreator)
	{
		EnsureDirectoryExistence(directory, exceptionCreator);
	}

	/// <summary>
	/// 检测当前目录是否存在，如果不存在则抛出 <paramref name="exceptionType" /> 指定的异常。
	/// </summary>
	/// <param name="directory">当前目录路径</param>
	/// <param name="exceptionType">抛出的异常类型</param>
	/// <param name="args">创建异常时的参数</param>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">如果当前目录路径指定的目录不存在则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertDirectoryExistence(string directory, Type exceptionType, params object[] args)
	{
		EnsureDirectoryExistence(directory, exceptionType, args);
	}

	/// <summary>
	/// 检测当前对象是否等于指定值，如果不等于指定值则抛出 <see cref="T:System.ArgumentOutOfRangeException" /> 异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <exception cref="T:System.ArgumentOutOfRangeException">当前对象不等于 <paramref name="value" /> 时。</exception>
	[Conditional("DEBUG")]
	public static void AssertEqualTo(object item, object value, string name = null, string message = null)
	{
		EnsureEqualTo(item, value, name, message);
	}

	/// <summary>
	/// 检测当前对象是否等于指定值，如果不等于指定值则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <exception cref="T:System.ArgumentNullException">异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常生成方法 <paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前对象的值不等于 <paramref name="value" /> 的值，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertEqualTo(object item, object value, Func<Exception> exceptionCreator)
	{
		EnsureEqualTo(item, value, exceptionCreator);
	}

	/// <summary>
	/// 检测当前对象是否等于指定值，如果不等于指定值则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <exception cref="T:System.ArgumentNullException">异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">异常类型 <paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常类型 <paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象的值不等于 <paramref name="value" /> 的值，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertEqualTo(object item, object value, Type exceptionType, params object[] args)
	{
		EnsureEqualTo(item, value, exceptionType, args);
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
	/// <exception cref="T:System.ArgumentOutOfRangeException">当前对象不等于 <paramref name="value" /> 时。</exception>
	[Conditional("DEBUG")]
	public static void AssertEqualTo<T>(T item, T value, string name, string message, Func<T, T, bool> equalition)
	{
		EnsureEqualTo(item, value, name, message, equalition);
	}

	/// <summary>
	/// 检测当前对象是否等于指定值，如果不等于指定值则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <param name="equalition">对象相等比较方法</param>
	/// <exception cref="T:System.ArgumentNullException">异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常生成方法 <paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前对象的值不等于 <paramref name="value" /> 的值，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertEqualTo<T>(T item, T value, Func<Exception> exceptionCreator, Func<T, T, bool> equalition)
	{
		EnsureEqualTo(item, value, exceptionCreator, equalition);
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
	/// <exception cref="T:System.ArgumentNullException">异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">异常类型 <paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常类型 <paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象的值不等于 <paramref name="value" /> 的值，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertEqualTo<T>(T item, T value, Type exceptionType, object[] args, Func<T, T, bool> equalition)
	{
		EnsureEqualTo(item, value, exceptionType, args, equalition);
	}

	/// <summary>
	/// 检测当前对象是否不等于指定值，如果等于指定值则抛出 <see cref="T:System.ArgumentOutOfRangeException" /> 异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <exception cref="T:System.ArgumentOutOfRangeException">当前对象等于 <paramref name="value" /> 时。</exception>
	[Conditional("DEBUG")]
	public static void AssertNotEqualTo(object item, object value, string name = null, string message = null)
	{
		Assert(ObjectHelper.IsNotEqualTo(item, value), () => new ArgumentOutOfRangeException(ObjectHelper.IfNull(name, "item"), ObjectHelper.IfNull(message, string.Format(Literals.MSG_ValueEqualToTarget_1, value))));
	}

	/// <summary>
	/// 检测当前对象是否不等于指定值，如果等于指定值则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <exception cref="T:System.ArgumentNullException">异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常生成方法 <paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前对象的值等于 <paramref name="value" /> 的值，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertNotEqualTo(object item, object value, Func<Exception> exceptionCreator)
	{
		Assert(ObjectHelper.IsNotEqualTo(item, value), exceptionCreator);
	}

	/// <summary>
	/// 检测当前对象是否不等于指定值，如果等于指定值则抛出  <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <exception cref="T:System.ArgumentNullException">异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">异常类型 <paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常类型 <paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象的值等于 <paramref name="value" /> 的值，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertNotEqualTo(object item, object value, Type exceptionType, params object[] args)
	{
		Assert(ObjectHelper.IsNotEqualTo(item, value), exceptionType, args);
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
	/// <exception cref="T:System.ArgumentOutOfRangeException">当前对象等于 <paramref name="value" /> 时。</exception>
	[Conditional("DEBUG")]
	public static void AssertNotEqualTo<T>(T item, T value, string name, string message, Func<T, T, bool> equalition)
	{
		Assert(ObjectHelper.IsNotEqualTo(item, value, equalition), () => new ArgumentOutOfRangeException(ObjectHelper.IfNull(name, "item"), ObjectHelper.IfNull(message, string.Format(Literals.MSG_ValueEqualToTarget_1, value))));
	}

	/// <summary>
	/// 检测当前对象是否不等于指定值，如果等于指定值则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">当前对象的类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="equalition">对象相等比较方法</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <exception cref="T:System.ArgumentNullException">异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常生成方法 <paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前对象的值等于 <paramref name="value" /> 的值，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertNotEqualTo<T>(T item, T value, Func<Exception> exceptionCreator, Func<T, T, bool> equalition)
	{
		Assert(ObjectHelper.IsNotEqualTo(item, value, equalition), exceptionCreator);
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
	/// <exception cref="T:System.ArgumentNullException">异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">异常类型 <paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常类型 <paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象的值等于 <paramref name="value" /> 的值，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertNotEqualTo<T>(T item, T value, Type exceptionType, object[] args, Func<T, T, bool> equalition)
	{
		Assert(ObjectHelper.IsNotEqualTo(item, value, equalition), exceptionType, args);
	}

	/// <summary>
	/// 检测指定的处理是否抛出任意异常，如果未抛出异常，则抛出 <see cref="T:System.InvalidOperationException" /> 异常
	/// </summary>
	/// <param name="action">对象处理方法</param>
	/// <param name="message">没有出现期望的异常时的消息</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">如果 <paramref name="action" /> 没有抛出异常，则抛出该异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertExpectedException(Action action, string message = null)
	{
		EnsureExpectedException(action, message);
	}

	/// <summary>
	/// 检测指定的处理是否抛出任意异常，如果未抛出异常，则抛出参数 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <param name="action">对象处理方法</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="action" /> 为空；或者 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception"><paramref name="action" /> 没有抛出异常，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertExpectedException(Action action, Func<Exception> exceptionCreator)
	{
		EnsureExpectedException(action, exceptionCreator);
	}

	/// <summary>
	/// 检测指定的处理是否抛出任意异常，如果未抛出异常，则抛出参数 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <param name="action">对象处理方法</param>
	/// <param name="exceptionType">抛出的指定的异常</param>
	/// <param name="args">异常参数</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="action" /> 为空；或者 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception"><paramref name="action" /> 没有抛出异常，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertExpectedException(Action action, Type exceptionType, params object[] args)
	{
		EnsureExpectedException(action, exceptionType, args);
	}

	/// <summary>
	/// 检测指定的处理是否抛出期望的异常，如果未抛出期望的异常，则抛出 <see cref="T:System.InvalidOperationException" /> 异常
	/// </summary>
	/// <param name="action">对象处理方法</param>
	/// <param name="expectedException">期望抛出的异常类型</param>
	/// <param name="message">没有出现期望的异常时的消息</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="action" /> 为空；或者 <paramref name="expectedException" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="expectedException" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.InvalidOperationException">如果 <paramref name="action" /> 没有抛出 <paramref name="expectedException" /> 指定的异常，则抛出该异常。</exception>
	/// <remarks>指定的处理 <paramref name="action" /> 应抛出异常，该异常应是 <paramref name="expectedException" /> 指定的类型或者是从 <paramref name="expectedException" /> 继承的类型；否则将抛出异常。</remarks>
	[Conditional("DEBUG")]
	public static void AssertExpectedException(Action action, Type expectedException, string message = null)
	{
		EnsureExpectedException(action, expectedException, message);
	}

	/// <summary>
	/// 检测指定的处理是否抛出期望的异常，如果未抛出期望的异常，则抛出参数 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <param name="action">对象处理方法</param>
	/// <param name="expectedException">期望的异常类型</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="action" /> 为空；或者 <paramref name="expectedException" /> 为空；或者 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="expectedException" /> 不是继承于 <see cref="T:System.Exception" /></exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception"><paramref name="action" /> 没有抛出 <paramref name="expectedException" /> 指定的异常，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	/// <remarks>指定的处理 <paramref name="action" /> 应抛出异常，该异常应是 <paramref name="expectedException" /> 指定的类型或者是从 <paramref name="expectedException" /> 继承的类型；否则将抛出异常。</remarks>
	[Conditional("DEBUG")]
	public static void AssertExpectedException(Action action, Type expectedException, Func<Exception> exceptionCreator)
	{
		EnsureExpectedException(action, expectedException, exceptionCreator);
	}

	/// <summary>
	/// 检测指定的处理是否抛出期望的异常，如果未抛出期望的异常，则抛出参数 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <param name="action">对象处理方法</param>
	/// <param name="expectedException">期望的异常类型</param>
	/// <param name="exceptionType">抛出的指定的异常</param>
	/// <param name="args">异常参数</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="action" /> 为空；或者 <paramref name="expectedException" /> 为空；或者 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="expectedException" /> 不是继承于 <see cref="T:System.Exception" />；或者 <paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception"><paramref name="action" /> 未抛出符合参数 <paramref name="expectedException" /> 指定类型的异常，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	/// <remarks>指定的处理 <paramref name="action" /> 应抛出异常，该异常应是 <paramref name="expectedException" /> 指定的类型或者是从 <paramref name="expectedException" /> 继承的类型；否则将抛出异常。</remarks>
	[Conditional("DEBUG")]
	public static void AssertExpectedException(Action action, Type expectedException, Type exceptionType, params object[] args)
	{
		EnsureExpectedException(action, expectedException, exceptionType, args);
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
	[Conditional("DEBUG")]
	public static void AssertExpectedException<T>(T item, Action<T> action, string message = null)
	{
		EnsureExpectedException(item, action, message);
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
	[Conditional("DEBUG")]
	public static void AssertExpectedException<T>(T item, Action<T> action, Func<Exception> exceptionCreator)
	{
		EnsureExpectedException(item, action, exceptionCreator);
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
	[Conditional("DEBUG")]
	public static void AssertExpectedException<T>(T item, Action<T> action, Type exceptionType, params object[] args)
	{
		EnsureExpectedException(item, action, exceptionType, args);
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
	[Conditional("DEBUG")]
	public static void AssertExpectedException<T>(T item, Action<T> action, Type expectedException, string message = null)
	{
		EnsureExpectedException(item, action, expectedException, message);
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
	[Conditional("DEBUG")]
	public static void AssertExpectedException<T>(T item, Action<T> action, Type expectedException, Func<Exception> exceptionCreator)
	{
		EnsureExpectedException(item, action, expectedException, exceptionCreator);
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
	[Conditional("DEBUG")]
	public static void AssertExpectedException<T>(T item, Action<T> action, Type expectedException, Type exceptionType, params object[] args)
	{
		EnsureExpectedException(item, action, expectedException, exceptionType, args);
	}

	/// <summary>
	/// 检测当前值是否等于false，如果不等于false，抛出 <see cref="T:System.ArgumentOutOfRangeException" /> 异常
	/// </summary>
	/// <param name="value">当前布尔值</param>
	/// <param name="name">参数名称</param>
	/// <param name="message">异常消息</param>
	/// <exception cref="T:System.ArgumentOutOfRangeException">如果 <paramref name="value" /> 为true。</exception>
	[Conditional("DEBUG")]
	public static void AssertFalse(bool value, string name = null, string message = null)
	{
		EnsureFalse(value, name, message);
	}

	/// <summary>
	/// 检测当前值是否等于false，如果不等于false，抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <param name="value">当前布尔值</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception"><paramref name="value" /> 不等于false，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertFalse(bool value, Func<Exception> exceptionCreator)
	{
		EnsureFalse(value, exceptionCreator);
	}

	/// <summary>
	/// 检测当前值是否等于false，如果不等于false，否则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <param name="value">当前布尔值</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception"><paramref name="value" /> 不等于false，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertFalse(bool value, Type exceptionType, params object[] args)
	{
		EnsureFalse(value, exceptionType, args);
	}

	/// <summary>
	/// 检测当前文件是否存在，如果不存在则抛出 <see cref="T:System.IO.FileNotFoundException" /> 异常。
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <param name="message">错误消息</param>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	[Conditional("DEBUG")]
	public static void AssertFileExistence(FileInfo file, string message = null)
	{
		EnsureFileExistence(file, message);
	}

	/// <summary>
	/// 检测当前文件是否存在，如果不存在则抛出 <paramref name="exceptionCreator" /> 生成的异常。
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空；或者 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">如果当前文件不存在则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertFileExistence(FileInfo file, Func<Exception> exceptionCreator)
	{
		EnsureFileExistence(file, exceptionCreator);
	}

	/// <summary>
	/// 检测当前文件是否存在，如果不存在则抛出 <paramref name="exceptionType" /> 指定的异常。
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <param name="exceptionType">抛出的异常类型</param>
	/// <param name="args">异常参数</param>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空；或者 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">如果当前文件不存在则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertFileExistence(FileInfo file, Type exceptionType, params object[] args)
	{
		EnsureFileExistence(file, exceptionType, args);
	}

	/// <summary>
	/// 检测当前文件是否存在，如果文件不存在则抛出 <see cref="T:System.IO.FileNotFoundException" /> 异常。
	/// </summary>
	/// <param name="file">当前文件路径</param>
	/// <param name="message">错误消息</param>
	/// <returns>如果当前文件路径指定的文件存在则返回该路径</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件路径为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件路径指定的文件不存在。</exception>
	[Conditional("DEBUG")]
	public static void AssertFileExistence(string file, string message = null)
	{
		EnsureFileExistence(file, message);
	}

	/// <summary>
	/// 检测当前文件是否存在，如果文件不存在则抛出 <paramref name="exceptionCreator" /> 生成的异常。
	/// </summary>
	/// <param name="file">当前文件路径</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果当前文件路径指定的文件存在则返回该路径</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">如果当前文件路径指定的文件不存在则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertFileExistence(string file, Func<Exception> exceptionCreator)
	{
		EnsureFileExistence(file, exceptionCreator);
	}

	/// <summary>
	/// 检测当前文件是否存在，如果文件不存在则抛出 <paramref name="exceptionType" /> 指定的异常。
	/// </summary>
	/// <param name="file">当前文件路径</param>
	/// <param name="exceptionType">抛出的异常类型</param>
	/// <param name="args">创建异常时的参数</param>
	/// <returns>如果当前文件路径指定的文件存在则返回该路径</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">如果当前文件路径指定的文件不存在则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertFileExistence(string file, Type exceptionType, params object[] args)
	{
		EnsureFileExistence(file, exceptionType, args);
	}

	/// <summary>
	/// 检测当前对象是否大于指定值，如果不大于指定值则抛出 <see cref="T:System.ArgumentOutOfRangeException" /> 异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">当前对象的值小于等于 <paramref name="value" /> 的值。</exception>
	[Conditional("DEBUG")]
	public static void AssertGreaterThan(IComparable item, object value, string name = null, string message = null)
	{
		EnsureGreaterThan(item, value, name, message);
	}

	/// <summary>
	/// 检测当前对象是否大于指定值，如果不大于指定值则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常生成方法 <paramref name="exceptionCreator" /> 执行异常或者返回空。</exception>
	/// <exception cref="T:System.Exception">当前对象的值小于等于 <paramref name="value" /> 的值，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertGreaterThan(IComparable item, object value, Func<Exception> exceptionCreator)
	{
		EnsureGreaterThan(item, value, exceptionCreator);
	}

	/// <summary>
	/// 检测当前对象是否大于指定值，如果不大于指定值则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">异常类型 <paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常类型 <paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象的值小于等于 <paramref name="value" /> 的值，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertGreaterThan(IComparable item, object value, Type exceptionType, params object[] args)
	{
		EnsureGreaterThan(item, value, exceptionType, args);
	}

	/// <summary>
	/// 检测当前对象是否大于指定值，如果不大于指定值则抛出 <see cref="T:System.ArgumentOutOfRangeException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">当前对象的值小于等于 <paramref name="value" /> 的值。</exception>
	[Conditional("DEBUG")]
	public static void AssertGreaterThan<T>(IComparable<T> item, T value, string name = null, string message = null) where T : IComparable<T>
	{
		EnsureGreaterThan(item, value, name, message);
	}

	/// <summary>
	/// 检测当前对象是否大于指定值，如果不大于指定值则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常生成方法 <paramref name="exceptionCreator" /> 执行异常或者返回空。</exception>
	/// <exception cref="T:System.Exception">当前对象的值小于等于 <paramref name="value" /> 的值，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertGreaterThan<T>(IComparable<T> item, T value, Func<Exception> exceptionCreator) where T : IComparable<T>
	{
		EnsureGreaterThan(item, value, exceptionCreator);
	}

	/// <summary>
	/// 检测当前对象是否大于指定值，如果不大于指定值则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">异常类型 <paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常类型 <paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象的值小于等于 <paramref name="value" /> 的值，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertGreaterThan<T>(IComparable<T> item, T value, Type exceptionType, params object[] args) where T : IComparable<T>
	{
		EnsureGreaterThan(item, value, exceptionType, args);
	}

	/// <summary>
	/// 检测当前对象是否大于等于指定值，如果小于指定值则抛出 <see cref="T:System.ArgumentOutOfRangeException" /> 异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">当前对象小于 <paramref name="value" /> 时。</exception>
	[Conditional("DEBUG")]
	public static void AssertGreaterThanOrEqualTo(IComparable item, object value, string name = null, string message = null)
	{
		EnsureGreaterThanOrEqualTo(item, value, name, message);
	}

	/// <summary>
	/// 检测当前对象是否大于等于指定值，如果小于指定值则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常生成方法 <paramref name="exceptionCreator" /> 执行异常或者返回空。</exception>
	/// <exception cref="T:System.Exception">当前对象的值小于 <paramref name="value" /> 的值，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertGreaterThanOrEqualTo(IComparable item, object value, Func<Exception> exceptionCreator)
	{
		EnsureGreaterThanOrEqualTo(item, value, exceptionCreator);
	}

	/// <summary>
	/// 检测当前对象是否大于等于指定值，如果小于指定值则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">异常类型 <paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常类型 <paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象的值小于 <paramref name="value" /> 的值，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertGreaterThanOrEqualTo(IComparable item, object value, Type exceptionType, params object[] args)
	{
		EnsureGreaterThanOrEqualTo(item, value, exceptionType, args);
	}

	/// <summary>
	/// 检测当前对象是否大于等于指定值，如果小于指定值则抛出 <see cref="T:System.ArgumentOutOfRangeException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">当前对象小于 <paramref name="value" /> 时。</exception>
	[Conditional("DEBUG")]
	public static void AssertGreaterThanOrEqualTo<T>(IComparable<T> item, T value, string name = null, string message = null) where T : IComparable<T>
	{
		EnsureGreaterThanOrEqualTo(item, value, name, message);
	}

	/// <summary>
	/// 检测当前对象是否大于等于指定值，如果小于指定值则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常生成方法 <paramref name="exceptionCreator" /> 执行异常或者返回空。</exception>
	/// <exception cref="T:System.Exception">当前对象的值小于 <paramref name="value" /> 的值，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertGreaterThanOrEqualTo<T>(IComparable<T> item, T value, Func<Exception> exceptionCreator) where T : IComparable<T>
	{
		EnsureGreaterThanOrEqualTo(item, value, exceptionCreator);
	}

	/// <summary>
	/// 检测当前对象是否大于等于指定值，如果小于指定值则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">异常类型 <paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常类型 <paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象的值小于 <paramref name="value" /> 的值，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertGreaterThanOrEqualTo<T>(IComparable<T> item, T value, Type exceptionType, params object[] args) where T : IComparable<T>
	{
		EnsureGreaterThanOrEqualTo(item, value, exceptionType, args);
	}

	/// <summary>
	/// 检测当前对象是否是指定值之一，如果不等于任何指定的值则抛出 <see cref="T:System.ArgumentOutOfRangeException" /> 异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="values">检测的指定值列表</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <exception cref="T:System.ArgumentOutOfRangeException">当前对象不在给定的值列表 <paramref name="values" /> 中。</exception>
	[Conditional("DEBUG")]
	public static void AssertIn(object item, IEnumerable values, string name = null, string message = null)
	{
		EnsureIn(item, values, name, message);
	}

	/// <summary>
	/// 检测当前对象是否是指定值之一，如果不等于任何指定的值，则抛出 <paramref name="exceptionCreator" /> 生成的异常。
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="values">检测的指定值列表</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前对象不在给定的值列表 <paramref name="values" /> 中，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertIn(object item, IEnumerable values, Func<Exception> exceptionCreator)
	{
		EnsureIn(item, values, exceptionCreator);
	}

	/// <summary>
	/// 检测当前对象是否是指定值之一，如果不等于任何指定的值，则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="values">检测的指定值列表</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象不在给定的值列表 <paramref name="values" /> 中，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertIn(object item, IEnumerable values, Type exceptionType, params object[] args)
	{
		EnsureIn(item, values, exceptionType, args);
	}

	/// <summary>
	/// 检测当前对象是否是指定值之一，如果不等于任何指定的值则抛出 <see cref="T:System.ArgumentOutOfRangeException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="values">检测的指定值列表</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <exception cref="T:System.ArgumentOutOfRangeException">当前对象不在给定的值列表 <paramref name="values" /> 中。</exception>
	[Conditional("DEBUG")]
	public static void AssertIn<T>(T item, IEnumerable<T> values, string name = null, string message = null)
	{
		EnsureIn(item, values, name, message);
	}

	/// <summary>
	/// 检测当前对象是否是指定值之一，如果不等于任何指定的值，则抛出 <paramref name="exceptionCreator" /> 生成的异常。
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="values">检测的指定值列表</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前对象不在给定的值列表 <paramref name="values" /> 中，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertIn<T>(T item, IEnumerable<T> values, Func<Exception> exceptionCreator)
	{
		EnsureIn(item, values, exceptionCreator);
	}

	/// <summary>
	/// 检测当前对象是否是指定值之一，如果不等于任何指定的值，则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="values">检测的指定值列表</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象不在给定的值列表 <paramref name="values" /> 中，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertIn<T>(T item, IEnumerable<T> values, Type exceptionType, params object[] args)
	{
		EnsureIn(item, values, exceptionType, args);
	}

	/// <summary>
	/// 检测当前对象是否不是指定值，如果等于任何指定的值则抛出 <see cref="T:System.ArgumentOutOfRangeException" /> 异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="values">检测的指定值列表</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <exception cref="T:System.ArgumentOutOfRangeException">当前对象在给定的值列表 <paramref name="values" /> 中。</exception>
	[Conditional("DEBUG")]
	public static void AssertNotIn(object item, IEnumerable values, string name = null, string message = null)
	{
		EnsureNotIn(item, values, name, message);
	}

	/// <summary>
	/// 检测当前对象是否不是指定值，如果等于任何指定的值，则抛出 <paramref name="exceptionCreator" /> 生成的异常。
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="values">检测的指定值列表</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <exception cref="T:System.ArgumentNullException">异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常生成方法 <paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前对象在给定的值列表 <paramref name="values" /> 中，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertNotIn(object item, IEnumerable values, Func<Exception> exceptionCreator)
	{
		EnsureNotIn(item, values, exceptionCreator);
	}

	/// <summary>
	/// 检测当前对象是否不是指定值，如果等于任何指定的值，则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="values">检测的指定值列表</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <exception cref="T:System.ArgumentNullException">异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">异常类型 <paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常类型 <paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象在给定的值列表 <paramref name="values" /> 中，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertNotIn(object item, IEnumerable values, Type exceptionType, params object[] args)
	{
		EnsureNotIn(item, values, exceptionType, args);
	}

	/// <summary>
	/// 检测当前对象是否不是指定值，如果等于任何指定的值则抛出 <see cref="T:System.ArgumentOutOfRangeException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="values">检测的指定值列表</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <exception cref="T:System.ArgumentOutOfRangeException">当前对象在给定的值列表 <paramref name="values" /> 中。</exception>
	[Conditional("DEBUG")]
	public static void AssertNotIn<T>(T item, IEnumerable<T> values, string name = null, string message = null)
	{
		EnsureNotIn(item, values, name, message);
	}

	/// <summary>
	/// 检测当前对象是否不是指定值，如果等于任何指定的值，则抛出 <paramref name="exceptionCreator" /> 生成的异常。
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="values">检测的指定值列表</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <exception cref="T:System.ArgumentNullException">异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常生成方法 <paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前对象在给定的值列表 <paramref name="values" /> 中，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertNotIn<T>(T item, IEnumerable<T> values, Func<Exception> exceptionCreator)
	{
		EnsureNotIn(item, values, exceptionCreator);
	}

	/// <summary>
	/// 检测当前对象是否不是指定值，如果等于任何指定的值，则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="values">检测的指定值列表</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <exception cref="T:System.ArgumentNullException">异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">异常类型 <paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常类型 <paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象在给定的值列表 <paramref name="values" /> 中，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertNotIn<T>(T item, IEnumerable<T> values, Type exceptionType, params object[] args)
	{
		EnsureNotIn(item, values, exceptionType, args);
	}

	/// <summary>
	/// 检测当前字符串长度是否是指定值；如果当前字符串的长度不等于指定长度则抛出 <see cref="T:System.ArgumentException" /> 异常。
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <param name="length">字符串的目标长度</param>
	/// <param name="name">参数名称</param>
	/// <param name="message">异常信息</param>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前字符串的长度不等于指定长度 <paramref name="length" />。</exception>
	[Conditional("DEBUG")]
	public static void AssertLength(string s, long length, string name = null, string message = null)
	{
		EnsureLength(s, length, name, message);
	}

	/// <summary>
	/// 检测当前字符串长度是否是指定值；如果当前字符串的长度不等于指定长度则抛出 <paramref name="exceptionCreator" /> 生成的异常。
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <param name="length">字符串的目标长度</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空；或者 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前字符串的长度不等于指定长度 <paramref name="length" />，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertLength(string s, long length, Func<Exception> exceptionCreator)
	{
		EnsureLength(s, length, exceptionCreator);
	}

	/// <summary>
	/// 检测当前字符串长度是否是指定值；如果当前字符串的长度不等于指定长度则抛出 <paramref name="exceptionType" /> 指定的异常。
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <param name="length">字符串的目标长度</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空；或者 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前字符串的长度不等于指定长度 <paramref name="length" />，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertLength(string s, long length, Type exceptionType, params object[] args)
	{
		EnsureLength(s, length, exceptionType, args);
	}

	/// <summary>
	/// 检测当前对象是否小于指定值，如果不小于指定值则抛出 <see cref="T:System.ArgumentOutOfRangeException" /> 异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">当前对象大于等于 <paramref name="value" /> 时。</exception>
	[Conditional("DEBUG")]
	public static void AssertLessThan(IComparable item, object value, string name = null, string message = null)
	{
		EnsureLessThan(item, value, name, message);
	}

	/// <summary>
	/// 检测当前对象是否小于指定值，如果不小于指定值则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常生成方法 <paramref name="exceptionCreator" /> 执行异常或者返回空。</exception>
	/// <exception cref="T:System.Exception">当前对象的值大于等于 <paramref name="value" /> 的值，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertLessThan(IComparable item, object value, Func<Exception> exceptionCreator)
	{
		EnsureLessThan(item, value, exceptionCreator);
	}

	/// <summary>
	/// 检测当前对象是否小于指定值，如果不小于指定值则抛出抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">异常类型 <paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常类型 <paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象的值大于等于 <paramref name="value" /> 的值，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertLessThan(IComparable item, object value, Type exceptionType, params object[] args)
	{
		EnsureLessThan(item, value, exceptionType, args);
	}

	/// <summary>
	/// 检测当前对象是否小于指定值，如果不小于指定值则抛出 <see cref="T:System.ArgumentOutOfRangeException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">当前对象大于等于 <paramref name="value" /> 时。</exception>
	[Conditional("DEBUG")]
	public static void AssertLessThan<T>(IComparable<T> item, T value, string name = null, string message = null) where T : IComparable<T>
	{
		EnsureLessThan(item, value, name, message);
	}

	/// <summary>
	/// 检测当前对象是否小于指定值，如果不小于指定值则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常生成方法 <paramref name="exceptionCreator" /> 执行异常或者返回空。</exception>
	/// <exception cref="T:System.Exception">当前对象的值大于等于 <paramref name="value" /> 的值，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertLessThan<T>(IComparable<T> item, T value, Func<Exception> exceptionCreator) where T : IComparable<T>
	{
		EnsureLessThan(item, value, exceptionCreator);
	}

	/// <summary>
	/// 检测当前对象是否小于指定值，如果不小于指定值则抛出抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">异常类型 <paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常类型 <paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象的值大于等于 <paramref name="value" /> 的值，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertLessThan<T>(IComparable<T> item, T value, Type exceptionType, params object[] args) where T : IComparable<T>
	{
		EnsureLessThan(item, value, exceptionType, args);
	}

	/// <summary>
	/// 检测当前对象是否小于等于指定值，如果大于指定值则抛出 <see cref="T:System.ArgumentOutOfRangeException" /> 异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">当前对象大于 <paramref name="value" /> 的值。</exception>
	[Conditional("DEBUG")]
	public static void AssertLessThanOrEqualTo(IComparable item, object value, string name = null, string message = null)
	{
		EnsureLessThanOrEqualTo(item, value, name, message);
	}

	/// <summary>
	/// 检测当前对象是否小于等于指定值，如果大于指定值则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回空。</exception>
	/// <exception cref="T:System.Exception">当前对象的值大于 <paramref name="value" /> 的值，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertLessThanOrEqualTo(IComparable item, object value, Func<Exception> exceptionCreator)
	{
		EnsureLessThanOrEqualTo(item, value, exceptionCreator);
	}

	/// <summary>
	/// 检测当前对象是否小于等于指定值，如果大于指定值则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">异常类型 <paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常类型 <paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象的值大于 <paramref name="value" /> 的值，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertLessThanOrEqualTo(IComparable item, object value, Type exceptionType, params object[] args)
	{
		EnsureLessThanOrEqualTo(item, value, exceptionType, args);
	}

	/// <summary>
	/// 检测当前对象是否小于等于指定值，如果大于指定值则抛出 <see cref="T:System.ArgumentOutOfRangeException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">当前对象大于 <paramref name="value" /> 的值。</exception>
	[Conditional("DEBUG")]
	public static void AssertLessThanOrEqualTo<T>(IComparable<T> item, T value, string name = null, string message = null) where T : IComparable<T>
	{
		EnsureLessThanOrEqualTo(item, value, name, message);
	}

	/// <summary>
	/// 检测当前对象是否小于等于指定值，如果大于指定值则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回空。</exception>
	/// <exception cref="T:System.Exception">当前对象的值大于 <paramref name="value" /> 的值，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertLessThanOrEqualTo<T>(IComparable<T> item, T value, Func<Exception> exceptionCreator) where T : IComparable<T>
	{
		EnsureLessThanOrEqualTo(item, value, exceptionCreator);
	}

	/// <summary>
	/// 检测当前对象是否小于等于指定值，如果大于指定值则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">异常类型 <paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常类型 <paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象的值大于 <paramref name="value" /> 的值，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertLessThanOrEqualTo<T>(IComparable<T> item, T value, Type exceptionType, params object[] args) where T : IComparable<T>
	{
		EnsureLessThanOrEqualTo(item, value, exceptionType, args);
	}

	/// <summary>
	/// 检测当前可清理的对象是否已经被清理，如果被清理则抛出异常
	/// </summary>
	/// <typeparam name="T">当前可清理对象的类型</typeparam>
	/// <param name="obj">当前可清理对象</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <exception cref="T:System.ArgumentNullException">当前可清理对象为空。</exception>
	/// <exception cref="T:System.ObjectDisposedException">当前可清理对象已经被清理。</exception>
	[Conditional("DEBUG")]
	public static void AssertNotDisposed<T>(T obj, string name = null, string message = null) where T : IDisposableObject
	{
		EnsureNotDisposed(obj, name, message);
	}

	/// <summary>
	/// 检测当前可清理的对象是否已经被清理，如果被清理则抛出异常
	/// </summary>
	/// <typeparam name="T">当前可清理对象的类型</typeparam>
	/// <param name="obj">当前可清理对象</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空；或者 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">如果当前文件不存在则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertNotDisposed<T>(T obj, Func<Exception> exceptionCreator) where T : IDisposableObject
	{
		EnsureNotDisposed(obj, exceptionCreator);
	}

	/// <summary>
	/// 检测当前可清理的对象是否已经被清理，如果被清理则抛出异常
	/// </summary>
	/// <typeparam name="T">当前可清理对象的类型</typeparam>
	/// <param name="obj">当前可清理对象</param>
	/// <param name="exceptionType">抛出的异常类型</param>
	/// <param name="args">异常参数</param>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空；或者 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">如果当前文件不存在则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertNotDisposed<T>(T obj, Type exceptionType, params object[] args) where T : IDisposableObject
	{
		EnsureNotDisposed(obj, exceptionType, args);
	}

	/// <summary>
	/// 检测当前对象是否不是为空或者 <see cref="T:System.DBNull" />，如果为空或者 <see cref="T:System.DBNull" /> 则抛出 <see cref="T:System.ArgumentNullException" /> 异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空或者 <see cref="T:System.DBNull" />。</exception>
	[Conditional("DEBUG")]
	public static void AssertNotNullAndDBNull(object item, string name = null, string message = null)
	{
		EnsureNotNullAndDBNull(item, name, message);
	}

	/// <summary>
	/// 检测当前对象是否不是为空或者 <see cref="T:System.DBNull" />，如果为空或者 <see cref="T:System.DBNull" /> 则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前对象的值为空或者 <see cref="T:System.DBNull" />，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertNotNullAndDBNull(object item, Func<Exception> exceptionCreator)
	{
		EnsureNotNullAndDBNull(item, exceptionCreator);
	}

	/// <summary>
	/// 检测当前对象是否不是为空或者 <see cref="T:System.DBNull" />，如果为空或者 <see cref="T:System.DBNull" /> 则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象的值为空或者 <see cref="T:System.DBNull" />，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertNotNullAndDBNull(object item, Type exceptionType, params object[] args)
	{
		EnsureNotNullAndDBNull(item, exceptionType, args);
	}

	/// <summary>
	/// 检测当前对象是否为空（null）或者是其类型的默认值，如果为空或者是其类型默认值抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="type">当前对象类型</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <exception cref="T:System.ArgumentException">当前对象为空或者等于其类型的默认值</exception>
	[Conditional("DEBUG")]
	public static void AssertNotNullAndDefault(object item, Type type, string name = null, string message = null)
	{
		EnsureNotNullAndDefault(item, type, name, message);
	}

	/// <summary>
	/// 检测当前对象是否为空或者是指定类型的默认值，如果为空或者类型默认值抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="type">当前对象类型</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前对象的值为空或者等于其类型的默认值，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertNotNullAndDefault(object item, Type type, Func<Exception> exceptionCreator)
	{
		EnsureNotNullAndDefault(item, type, exceptionCreator);
	}

	/// <summary>
	/// 检测当前对象是否为空或者是指定类型默认值，如果为空或者类型默认值抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="type">当前对象类型</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象的值为空或者等于其类型的默认值，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertNotNullAndDefault(object item, Type type, Type exceptionType, params object[] args)
	{
		EnsureNotNullAndDefault(item, type, exceptionType, args);
	}

	/// <summary>
	/// 检测当前对象是否为空（null）或者是其类型的默认值，如果为空或者是其类型默认值抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <exception cref="T:System.ArgumentException">当前对象为空或者等于其类型的默认值</exception>
	[Conditional("DEBUG")]
	public static void AssertNotNullAndDefault<T>(T item, string name = null, string message = null)
	{
		EnsureNotNullAndDefault(item, name, message);
	}

	/// <summary>
	/// 检测当前对象是否为空或者是指定类型的默认值，如果为空或者类型默认值抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前对象的值为空或者等于其类型的默认值，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertNotNullAndDefault<T>(T item, Func<Exception> exceptionCreator)
	{
		EnsureNotNullAndDefault(item, exceptionCreator);
	}

	/// <summary>
	/// 检测当前对象是否为空或者是指定类型默认值，如果为空或者类型默认值抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象的值为空或者等于其类型的默认值，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertNotNullAndDefault<T>(T item, Type exceptionType, params object[] args)
	{
		EnsureNotNullAndDefault(item, exceptionType, args);
	}

	/// <summary>
	/// 检测当前序列是否不为空或者空序列，如果为空或者空序列抛出 <see cref="T:System.ArgumentNullException" /> 异常
	/// </summary>
	/// <param name="items">当前序列</param>
	/// <param name="name">列表名称</param>
	/// <param name="message">异常信息</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空或者为空序列。</exception>
	[Conditional("DEBUG")]
	public static void AssertNotNullAndEmpty(IEnumerable items, string name = null, string message = null)
	{
		EnsureNotNullAndEmpty(items, name, message);
	}

	/// <summary>
	/// 检测当前序列是否不为空或者空序列，如果为空或者空序列抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <param name="items">当前序列</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">如果当前序列为空或者空序列，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertNotNullAndEmpty(IEnumerable items, Func<Exception> exceptionCreator)
	{
		EnsureNotNullAndEmpty(items, exceptionCreator);
	}

	/// <summary>f
	/// 检测当前序列是否不为空或者空序列，如果为空或者空序列抛出 <paramref name="exceptionType" /> 类型的异常
	/// </summary>
	/// <param name="items">当前序列</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">如果当前序列为空或者空序列，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertNotNullAndEmpty(IEnumerable items, Type exceptionType, params object[] args)
	{
		EnsureNotNullAndEmpty(items, exceptionType, args);
	}

	/// <summary>
	/// 检测当前字符串是否为空或者空串，如果为空或者空串，则抛出 <see cref="T:System.ArgumentNullException" /> 异常。
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <param name="name">参数名称</param>
	/// <param name="message">异常信息</param>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空或者空串。</exception>
	[Conditional("DEBUG")]
	public static void AssertNotNullAndEmpty(string s, string name = null, string message = null)
	{
		EnsureNotNullAndEmpty(s, name, message);
	}

	/// <summary>
	/// 检测当前字符串是否为空或者空串，如果为空或者空串，则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <exception cref="T:System.ArgumentNullException">异常生成方法<paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常生成方法<paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前字符串为空或者空串，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertNotNullAndEmpty(string s, Func<Exception> exceptionCreator)
	{
		EnsureNotNullAndEmpty(s, exceptionCreator);
	}

	/// <summary>
	/// 检测当前字符串是否为空或者空串，如果为空或者空串，则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前字符串为空或者空串，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertNotNullAndEmpty(string s, Type exceptionType, params object[] args)
	{
		EnsureNotNullAndEmpty(s, exceptionType, args);
	}

	/// <summary>
	/// 检测当前字符串是否为空、空串或者全部为空白字符，如果为空、空串或者全部为空白字符，则抛出 <see cref="T:System.ArgumentNullException" /> 异常
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <param name="name">参数名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空、空串或者全部为空白字符。</exception>
	[Conditional("DEBUG")]
	public static void AssertNotNullAndWhiteSpace(string s, string name = null, string message = null)
	{
		EnsureNotNullAndWhiteSpace(s, name, message);
	}

	/// <summary>
	/// 检测当前字符串是否为空、空串或者全部为空白字符，如果为空、空串或者全部为空白字符，则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前字符串为空、空串或者全部为空白字符，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertNotNullAndWhiteSpace(string s, Func<Exception> exceptionCreator)
	{
		EnsureNotNullAndWhiteSpace(s, exceptionCreator);
	}

	/// <summary>
	/// 检测当前字符串是否为空、空串或者全部为空白字符，如果为空、空串或者全部为空白字符，则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前字符串为空、空串或者全部为空白字符，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertNotNullAndWhiteSpace(string s, Type exceptionType, params object[] args)
	{
		EnsureNotNullAndWhiteSpace(s, exceptionType, args);
	}

	/// <summary>
	/// 检测当前对象是否为空，如果不为空抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">错误消息</param>
	/// <exception cref="T:System.ArgumentException">当前对象不为空。</exception>
	[Conditional("DEBUG")]
	public static void AssertNull(object item, string name = null, string message = null)
	{
		EnsureNull(item, name, message);
	}

	/// <summary>
	/// 检测当前对象是否为空，如果不为空抛出参数 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前对象不为空，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertNull(object item, Func<Exception> exceptionCreator)
	{
		EnsureNull(item, exceptionCreator);
	}

	/// <summary>
	/// 检测当前对象是否为空，如果不为空抛出参数 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前当前对象不为空，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertNull(object item, Type exceptionType, params object[] args)
	{
		EnsureNull(item, exceptionType, args);
	}

	/// <summary>
	/// 检测当前对象是否为空，如果为空抛出 <see cref="T:System.ArgumentNullException" /> 异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">错误消息</param>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空。</exception>
	[Conditional("DEBUG")]
	public static void AssertNotNull(object item, string name = null, string message = null)
	{
		EnsureNotNull(item, name, message);
	}

	/// <summary>
	/// 检测当前对象是否为空，如果为空抛出参数 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前对象为空，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertNotNull(object item, Func<Exception> exceptionCreator)
	{
		EnsureNotNull(item, exceptionCreator);
	}

	/// <summary>
	/// 检测当前对象是否为空，如果为空抛出参数 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象为空，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertNotNull(object item, Type exceptionType, params object[] args)
	{
		EnsureNotNull(item, exceptionType, args);
	}

	/// <summary>
	/// 检测当前索引是否小于等于指定的上限，如果大于指定上限则抛出 <see cref="T:System.IndexOutOfRangeException" /> 异常。
	/// </summary>
	/// <param name="index">当前索引</param>
	/// <param name="max">索引的最大值（上限）</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <exception cref="T:System.IndexOutOfRangeException">当前索引大于 <paramref name="max" />。</exception>
	[Conditional("DEBUG")]
	public static void AssertIndexHighBound(int index, int max, string name = null, string message = null)
	{
		EnsureIndexHighBound(index, max, name, message);
	}

	/// <summary>
	/// 检测当前索引是否小于等于指定的上限，如果大于指定上限则抛出 <paramref name="exceptionCreator" /> 生成的异常。
	/// </summary>
	/// <param name="index">当前索引</param>
	/// <param name="max">索引的最大值（上限）</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">如果当前索引大于 <paramref name="max" />，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertIndexHighBound(int index, int max, Func<Exception> exceptionCreator)
	{
		EnsureIndexHighBound(index, max, exceptionCreator);
	}

	/// <summary>
	/// 检测当前索引是否小于等于指定的上限，如果大于指定上限则抛出 <paramref name="exceptionType" /> 指定的异常。
	/// </summary>
	/// <param name="index">当前索引</param>
	/// <param name="max">索引的最大值（上限）</param>
	/// <param name="exceptionType">抛出的异常类型</param>
	/// <param name="args">异常构造参数</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">如果当前索引大于 <paramref name="max" />，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertIndexHighBound(int index, int max, Type exceptionType, params object[] args)
	{
		EnsureIndexHighBound(index, max, exceptionType, args);
	}

	/// <summary>
	/// 检测当前索引是否小于等于指定的上限，如果大于指定上限则抛出 <see cref="T:System.IndexOutOfRangeException" /> 异常。
	/// </summary>
	/// <param name="index">当前索引</param>
	/// <param name="max">索引的最大值（上限）</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <exception cref="T:System.IndexOutOfRangeException">当前索引大于 <paramref name="max" />。</exception>
	[Conditional("DEBUG")]
	public static void AssertIndexHighBound(long index, long max, string name = null, string message = null)
	{
		EnsureIndexHighBound(index, max, name, message);
	}

	/// <summary>
	/// 检测当前索引是否小于等于指定的上限，如果大于指定上限则抛出 <paramref name="exceptionCreator" /> 生成的异常。
	/// </summary>
	/// <param name="index">当前索引</param>
	/// <param name="max">索引的最大值（上限）</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">如果当前索引大于 <paramref name="max" />，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertIndexHighBound(long index, long max, Func<Exception> exceptionCreator)
	{
		EnsureIndexHighBound(index, max, exceptionCreator);
	}

	/// <summary>
	/// 检测当前索引是否小于等于指定的上限，如果大于指定上限则抛出 <paramref name="exceptionType" /> 指定的异常。
	/// </summary>
	/// <param name="index">当前索引</param>
	/// <param name="max">索引的最大值（上限）</param>
	/// <param name="exceptionType">抛出的异常类型</param>
	/// <param name="args">异常构造参数</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">如果当前索引大于 <paramref name="max" />，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertIndexHighBound(long index, long max, Type exceptionType, params object[] args)
	{
		EnsureIndexHighBound(index, max, exceptionType, args);
	}

	/// <summary>
	/// 检测当前索引是否大于等于指定的下限，如果小于指定下限则抛出 <see cref="T:System.IndexOutOfRangeException" /> 异常。
	/// </summary>
	/// <param name="index">当前索引</param>
	/// <param name="min">索引的最小值（下限）</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <exception cref="T:System.IndexOutOfRangeException">当前索引小于 <paramref name="min" />。</exception>
	[Conditional("DEBUG")]
	public static void AssertIndexLowBound(int index, int min, string name = null, string message = null)
	{
		EnsureIndexLowBound(index, min, name, message);
	}

	/// <summary>
	/// 检测当前索引是否大于等于指定的下限，如果小于指定下限则抛出 <paramref name="exceptionCreator" /> 生成的异常。
	/// </summary>
	/// <param name="index">当前索引</param>
	/// <param name="min">索引的最小值（下限）</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">如果当前索引小于 <paramref name="min" />，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	/// <remarks>索引的最小值默认为 0。</remarks>
	[Conditional("DEBUG")]
	public static void AssertIndexLowBound(int index, int min, Func<Exception> exceptionCreator)
	{
		EnsureIndexLowBound(index, min, exceptionCreator);
	}

	/// <summary>
	/// 检测当前索引是否大于等于指定的下限，如果小于指定下限则抛出 <paramref name="exceptionType" /> 指定的异常。
	/// </summary>
	/// <param name="index">当前索引</param>
	/// <param name="min">索引的最小值（下限）</param>
	/// <param name="exceptionType">抛出的异常类型</param>
	/// <param name="args">异常构造参数</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">如果当前索引小于 <paramref name="min" />，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertIndexLowBound(int index, int min, Type exceptionType, params object[] args)
	{
		EnsureIndexLowBound(index, min, exceptionType, args);
	}

	/// <summary>
	/// 检测当前索引是否大于等于指定的下限，如果小于指定下限则抛出 <see cref="T:System.IndexOutOfRangeException" /> 异常。
	/// </summary>
	/// <param name="index">当前索引</param>
	/// <param name="min">索引的最小值（下限）</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <exception cref="T:System.IndexOutOfRangeException">当前索引小于 <paramref name="min" />。</exception>
	[Conditional("DEBUG")]
	public static void AssertIndexLowBound(long index, long min, string name = null, string message = null)
	{
		EnsureIndexLowBound(index, min, name, message);
	}

	/// <summary>
	/// 检测当前索引是否大于等于指定的下限，如果小于指定下限则抛出 <paramref name="exceptionCreator" /> 生成的异常。
	/// </summary>
	/// <param name="index">当前索引</param>
	/// <param name="min">索引的最小值（下限）</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">如果当前索引小于 <paramref name="min" />，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	/// <remarks>索引的最小值默认为 0。</remarks>
	[Conditional("DEBUG")]
	public static void AssertIndexLowBound(long index, long min, Func<Exception> exceptionCreator)
	{
		EnsureIndexLowBound(index, min, exceptionCreator);
	}

	/// <summary>
	/// 检测当前索引是否大于等于指定的下限，如果小于指定下限则抛出 <paramref name="exceptionType" /> 指定的异常。
	/// </summary>
	/// <param name="index">当前索引</param>
	/// <param name="min">索引的最小值（下限）</param>
	/// <param name="exceptionType">抛出的异常类型</param>
	/// <param name="args">异常构造参数</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">如果当前索引小于 <paramref name="min" />，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertIndexLowBound(long index, long min, Type exceptionType, params object[] args)
	{
		EnsureIndexLowBound(index, min, exceptionType, args);
	}

	/// <summary>
	/// 检测当前索引是否在指定的范围内，如果超出指定范围则抛出 <see cref="T:System.IndexOutOfRangeException" /> 异常。
	/// </summary>
	/// <param name="index">当前索引</param>
	/// <param name="min">索引的最小值</param>
	/// <param name="max">索引的最大值</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <exception cref="T:System.IndexOutOfRangeException">当前索引小于 <paramref name="min" />，或者大于 <paramref name="max" />。</exception>
	[Conditional("DEBUG")]
	public static void AssertIndexRange(int index, int min, int max, string name = null, string message = null)
	{
		EnsureIndexRange(index, min, max, name, message);
	}

	/// <summary>
	/// 检测当前索引是否在指定的范围内，如果超出指定范围则抛出 <paramref name="exceptionCreator" /> 生成的异常。
	/// </summary>
	/// <param name="index">当前索引</param>
	/// <param name="min">索引的最小值</param>
	/// <param name="max">索引的最大值</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">如果当前索引小于 <paramref name="min" />，或者大于 <paramref name="max" />，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertIndexRange(int index, int min, int max, Func<Exception> exceptionCreator)
	{
		EnsureIndexRange(index, min, max, exceptionCreator);
	}

	/// <summary>
	/// 检测当前索引是否在指定的范围内，如果超出指定范围则抛出 <paramref name="exceptionType" /> 指定的异常。
	/// </summary>
	/// <param name="index">当前索引</param>
	/// <param name="min">索引的最小值</param>
	/// <param name="max">索引的最大值</param>
	/// <param name="exceptionType">抛出的异常类型</param>
	/// <param name="args">异常构造参数</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">如果当前索引小于 <paramref name="min" />，或者大于 <paramref name="max" />，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertIndexRange(int index, int min, int max, Type exceptionType, params object[] args)
	{
		EnsureIndexRange(index, min, max, exceptionType, args);
	}

	/// <summary>
	/// 检测当前索引是否在指定的范围内，如果超出指定范围则抛出 <see cref="T:System.IndexOutOfRangeException" /> 异常。
	/// </summary>
	/// <param name="index">当前索引</param>
	/// <param name="min">索引的最小值</param>
	/// <param name="max">索引的最大值</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <exception cref="T:System.IndexOutOfRangeException">当前索引小于 <paramref name="min" />，或者大于 <paramref name="max" />。</exception>
	[Conditional("DEBUG")]
	public static void AssertIndexRange(long index, long min, long max, string name = null, string message = null)
	{
		EnsureIndexRange(index, min, max, name, message);
	}

	/// <summary>
	/// 检测当前索引是否在指定的范围内，如果超出指定范围则抛出 <paramref name="exceptionCreator" /> 生成的异常。
	/// </summary>
	/// <param name="index">当前索引</param>
	/// <param name="min">索引的最小值</param>
	/// <param name="max">索引的最大值</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">如果当前索引小于 <paramref name="min" />，或者大于 <paramref name="max" />，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertIndexRange(long index, long min, long max, Func<Exception> exceptionCreator)
	{
		EnsureIndexRange(index, min, max, exceptionCreator);
	}

	/// <summary>
	/// 检测当前索引是否在指定的范围内，如果超出指定范围则抛出 <paramref name="exceptionType" /> 指定的异常。
	/// </summary>
	/// <param name="index">当前索引</param>
	/// <param name="min">索引的最小值</param>
	/// <param name="max">索引的最大值</param>
	/// <param name="exceptionType">抛出的异常类型</param>
	/// <param name="args">异常构造参数</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">如果当前索引小于 <paramref name="min" />，或者大于 <paramref name="max" />，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertIndexRange(long index, long min, long max, Type exceptionType, params object[] args)
	{
		EnsureIndexRange(index, min, max, exceptionType, args);
	}

	/// <summary>
	/// 检测当前类型是否是指定的类型或者是指定类型的派生类型，如果不符合则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <typeparam name="T">检测的目标类型</typeparam>
	/// <param name="type">当前类型</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	/// <exception cref="T:System.ArgumentException">如果当前类型不是指定的类型或者不是指定类型的派生类型 <see cref="T:System.ArgumentException" /> 异常</exception>
	public static void AssertInheritedType<T>(Type type, string name = null, string message = null)
	{
		EnsureInheritedType<T>(type, name, message);
	}

	/// <summary>
	/// 检测当前类型是否是指定的类型或者是指定类型的派生类型，如果不符合则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">检测的目标类型</typeparam>
	/// <param name="type">当前类型</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">如果当前类型不是指定的类型或者不是指定类型的派生类型，则抛出参数 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static void AssertInheritedType<T>(Type type, Func<Exception> exceptionCreator)
	{
		EnsureInheritedType<T>(type, exceptionCreator);
	}

	/// <summary>
	/// 检测当前类型是否是指定的类型或者是指定类型的派生类型，如果不符合则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <typeparam name="T">检测的目标类型</typeparam>
	/// <param name="type">当前类型</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">如果当前类型不是指定的类型或者不是指定类型的派生类型，则抛出参数 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static void AssertInheritedType<T>(Type type, Type exceptionType, params object[] args)
	{
		EnsureInheritedType<T>(type, exceptionType, args);
	}

	/// <summary>
	/// 检测当前类型是否是指定的类型或者是指定类型的派生类型，如果不符合则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="targetType">检测的目标类型</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者 <paramref name="targetType" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">如果当前类型不是指定的类型或者不是指定类型的派生类型 <see cref="T:System.ArgumentException" /> 异常</exception>
	public static void AssertInheritedType(Type type, Type targetType, string name = null, string message = null)
	{
		EnsureInheritedType(type, targetType, name, message);
	}

	/// <summary>
	/// 检测当前类型是否是指定的类型或者是指定类型的派生类型，如果不符合则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="targetType">检测的目标类型</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者 <paramref name="targetType" /> 为空；或者 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">如果当前类型不是指定的类型或者不是指定类型的派生类型，则抛出参数 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static void AssertInheritedType(Type type, Type targetType, Func<Exception> exceptionCreator)
	{
		EnsureInheritedType(type, targetType, exceptionCreator);
	}

	/// <summary>
	/// 检测当前类型是否是指定的类型或者是指定类型的派生类型，如果不符合则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="targetType">检测的目标类型</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者 <paramref name="targetType" /> 为空；或者 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">如果当前类型不是指定的类型或者不是指定类型的派生类型，则抛出参数 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static void AssertInheritedType(Type type, Type targetType, Type exceptionType, params object[] args)
	{
		EnsureInheritedType(type, targetType, exceptionType, args);
	}

	/// <summary>
	/// 检测当前对象是否是指定类型的实例，如果不是则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <typeparam name="T">检测的目标类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <exception cref="T:System.ArgumentException">当前对象为空，或者不是 <typeparamref name="T" /> 指定的类型的实例</exception>
	[Conditional("DEBUG")]
	public static void AssertInstanceOfType<T>(object item, string name = null, string message = null)
	{
		EnsureInstanceOfType<T>(item, name, message);
	}

	/// <summary>
	/// 检测当前对象是否是指定类型的实例，如果不是则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">检测的目标类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前对象为空，或者不是 <typeparamref name="T" /> 指定的类型的实例，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertInstanceOfType<T>(object item, Func<Exception> exceptionCreator)
	{
		EnsureInstanceOfType<T>(item, exceptionCreator);
	}

	/// <summary>
	/// 检测当前对象是否是指定类型的实例，如果不是则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <typeparam name="T">检测的目标类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象为空，或者不是 <typeparamref name="T" /> 指定的类型的实例，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertInstanceOfType<T>(object item, Type exceptionType, params object[] args)
	{
		EnsureInstanceOfType<T>(item, exceptionType, args);
	}

	/// <summary>
	/// 检测当前对象是否是指定类型的实例，如果不是则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="type">检测的目标类型</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="type" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前对象为空，或者不是 <paramref name="type" /> 指定的类型的实例</exception>
	[Conditional("DEBUG")]
	public static void AssertInstanceOfType(object item, Type type, string name = null, string message = null)
	{
		EnsureInstanceOfType(item, type, name, message);
	}

	/// <summary>
	/// 检测当前对象是否是指定类型的实例，如果不是则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="type">检测的目标类型</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionCreator" /> 为空；或者 <paramref name="type" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前对象为空，或者不是 <paramref name="type" /> 指定的类型的实例，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertInstanceOfType(object item, Type type, Func<Exception> exceptionCreator)
	{
		EnsureInstanceOfType(item, type, exceptionCreator);
	}

	/// <summary>
	/// 检测当前对象是否是指定类型的实例，如果不是则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="type">检测的目标类型</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionType" /> 为空；或者 <paramref name="type" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象为空，或者不是 <paramref name="type" /> 指定的类型的实例，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertInstanceOfType(object item, Type type, Type exceptionType, params object[] args)
	{
		EnsureInstanceOfType(item, type, exceptionType, args);
	}

	/// <summary>
	/// 检测当前对象是否不是指定类型的实例，如果是则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <typeparam name="T">检测的目标类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <exception cref="T:System.ArgumentException">当前对象是 <typeparamref name="T" /> 指定的类型的实例</exception>
	[Conditional("DEBUG")]
	public static void AssertNotInstanceOfType<T>(object item, string name = null, string message = null)
	{
		EnsureNotInstanceOfType<T>(item, name, message);
	}

	/// <summary>
	/// 检测当前对象是否不是指定类型的实例，如果是则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">检测的目标类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前对象是 <typeparamref name="T" /> 指定的类型的实例，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertNotInstanceOfType<T>(object item, Func<Exception> exceptionCreator)
	{
		EnsureNotInstanceOfType<T>(item, exceptionCreator);
	}

	/// <summary>
	/// 检测当前对象是否不是指定类型的实例，如果是则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <typeparam name="T">检测的目标类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象是 <typeparamref name="T" /> 指定的类型的实例，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertNotInstanceOfType<T>(object item, Type exceptionType, params object[] args)
	{
		EnsureNotInstanceOfType<T>(item, exceptionType, args);
	}

	/// <summary>
	/// 检测当前对象是否不是指定类型的实例，如果是则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="type">检测的目标类型</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="type" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前对象是 <paramref name="type" /> 指定的类型的实例</exception>
	[Conditional("DEBUG")]
	public static void AssertNotInstanceOfType(object item, Type type, string name = null, string message = null)
	{
		EnsureNotInstanceOfType(item, type, name, message);
	}

	/// <summary>
	/// 检测当前对象是否不是指定类型的实例，如果是则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="type">检测的目标类型</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionCreator" /> 为空；或者 <paramref name="type" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前对象是 <paramref name="type" /> 指定的类型的实例，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertNotInstanceOfType(object item, Type type, Func<Exception> exceptionCreator)
	{
		EnsureNotInstanceOfType(item, type, exceptionCreator);
	}

	/// <summary>
	/// 检测当前对象是否不是指定类型的实例，如果是则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="type">检测的目标类型</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionType" /> 为空；或者 <paramref name="type" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象是 <paramref name="type" /> 指定的类型的实例，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertNotInstanceOfType(object item, Type type, Type exceptionType, params object[] args)
	{
		EnsureNotInstanceOfType(item, type, exceptionType, args);
	}

	/// <summary>
	/// 检测当前对象是否为值类型，如果不是值类型则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <exception cref="T:System.ArgumentException">当前对象为空，或者不是值类型的对象。</exception>
	[Conditional("DEBUG")]
	public static void AssertInstanceOfValueType(object item, string name = null, string message = null)
	{
		EnsureInstanceOfValueType(item, name, message);
	}

	/// <summary>
	/// 检测当前对象是否为值类型，如果不是值类型则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前对象为空，或者不是值类型的对象，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertInstanceOfValueType(object item, Func<Exception> exceptionCreator)
	{
		EnsureInstanceOfValueType(item, exceptionCreator);
	}

	/// <summary>
	/// 检测当前对象是否为值类型，如果不是值类型则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象为空，或者不是值类型的对象，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertInstanceOfValueType(object item, Type exceptionType, params object[] args)
	{
		EnsureInstanceOfValueType(item, exceptionType, args);
	}

	/// <summary>
	/// 检测当前对象是否为引用类型，如果不是引用类型则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <exception cref="T:System.ArgumentException">当前对象为空，或者所属的类型不是类或者接口。</exception>
	[Conditional("DEBUG")]
	public static void AssertInstanceOfReferenceType(object item, string name = null, string message = null)
	{
		EnsureInstanceOfReferenceType(item, name, message);
	}

	/// <summary>
	/// 检测当前对象是否为引用类型，如果不是引用类型则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前对象为空，或者所属的类型不是类或者接口，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertInstanceOfReferenceType(object item, Func<Exception> exceptionCreator)
	{
		EnsureInstanceOfReferenceType(item, exceptionCreator);
	}

	/// <summary>
	/// 检测当前对象是否为引用类型，如果不是引用类型则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象为空，或者所属的类型不是类或者接口，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertInstanceOfReferenceType(object item, Type exceptionType, params object[] args)
	{
		EnsureInstanceOfReferenceType(item, exceptionType, args);
	}

	/// <summary>
	/// 检测当前值是否等于true，如果不等于true，抛出 <see cref="T:System.ArgumentOutOfRangeException" /> 异常
	/// </summary>
	/// <param name="value">当前布尔值</param>
	/// <param name="name">参数名称</param>
	/// <param name="message">异常消息</param>
	/// <exception cref="T:System.ArgumentOutOfRangeException">如果 <paramref name="value" /> 为false。</exception>
	[Conditional("DEBUG")]
	public static void AssertTrue(bool value, string name = null, string message = null)
	{
		EnsureTrue(value, name, message);
	}

	/// <summary>
	/// 检测当前值是否等于true，如果不等于true，抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <param name="value">当前布尔值</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception"><paramref name="value" /> 不等于true，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertTrue(bool value, Func<Exception> exceptionCreator)
	{
		EnsureTrue(value, exceptionCreator);
	}

	/// <summary>
	/// 检测当前值是否等于true，如果不等于true，抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <param name="value">当前布尔值</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception"><paramref name="value" /> 不等于true，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertTrue(bool value, Type exceptionType, params object[] args)
	{
		EnsureTrue(value, exceptionType, args);
	}

	/// <summary>
	/// 如果当前函数委托的返回值不等于true，则抛出 <see cref="T:System.InvalidOperationException" /> 异常
	/// </summary>
	/// <param name="func">当前函数委托</param>
	/// <param name="name">参数名称</param>
	/// <param name="message">异常信息</param>
	/// <exception cref="T:System.ArgumentNullException">当前函数委托为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前函数委托返回false时。</exception>
	[Conditional("DEBUG")]
	public static void AssertTrue(Func<bool> func, string name = null, string message = null)
	{
		EnsureTrue(func, name, message);
	}

	/// <summary>
	/// 如果当前函数委托的返回值不等于true，则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <param name="func">当前函数委托</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前函数委托为空。</exception>
	/// <exception cref="T:System.Exception">当前函数委托返回false时，抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertTrue(Func<bool> func, Func<Exception> exceptionCreator)
	{
		EnsureTrue(func, exceptionCreator);
	}

	/// <summary>
	/// 如果当前函数委托的返回值不等于true，则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <param name="func">当前函数委托</param>
	/// <param name="exceptionType">指定的异常类型</param>
	/// <param name="args">异常参数</param>
	/// <exception cref="T:System.ArgumentNullException">当前函数委托为空；或者 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.Exception">当前函数委托返回false时，抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertTrue(Func<bool> func, Type exceptionType, params object[] args)
	{
		EnsureTrue(func, exceptionType, args);
	}

	/// <summary>
	/// 检测当前类型是否是指定的类型，如果不符合则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <typeparam name="T">待检测的目标的类型</typeparam>
	/// <param name="type">当前类型</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空。</exception>
	/// <exception cref="T:System.ArgumentException">如果当前类型不是指定的目标类型则抛出 <see cref="T:System.ArgumentException" /> 异常</exception>
	[Conditional("DEBUG")]
	public static void AssertType<T>(Type type, string name = null, string message = null)
	{
		EnsureType<T>(type, name, message);
	}

	/// <summary>
	/// 检测当前类型是否是指定的类型，如果不符合则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">待检测的目标的类型</typeparam>
	/// <param name="type">当前类型</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">如果当前类型不是指定的目标类型则抛出，则抛出参数 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertType<T>(Type type, Func<Exception> exceptionCreator)
	{
		EnsureType<T>(type, exceptionCreator);
	}

	/// <summary>
	/// 检测当前类型是否是指定的类型，如果不符合则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <typeparam name="T">待检测的目标的类型</typeparam>
	/// <param name="type">当前类型</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">如果当前类型不是指定的目标类型则抛出，则抛出参数 <paramref name="exceptionType" /> 指定的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertType<T>(Type type, Type exceptionType, params object[] args)
	{
		EnsureType<T>(type, exceptionType, args);
	}

	/// <summary>
	/// 检测当前类型是否符合指定的类型，如果不符合则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="targetType">检测的目标类型</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者 <paramref name="targetType" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">如果当前类型不是指定的目标类型则抛出 <see cref="T:System.ArgumentException" /> 异常</exception>
	[Conditional("DEBUG")]
	public static void AssertType(Type type, Type targetType, string name = null, string message = null)
	{
		EnsureType(type, targetType, name, message);
	}

	/// <summary>
	/// 检测当前类型是否是指定的类型，如果不符合则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="targetType">检测的目标类型</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者 <paramref name="targetType" /> 为空；或者 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">如果当前类型不是指定的目标类型则抛出，则抛出参数 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertType(Type type, Type targetType, Func<Exception> exceptionCreator)
	{
		EnsureType(type, targetType, exceptionCreator);
	}

	/// <summary>
	/// 检测当前类型是否是指定的类型，如果不符合则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="targetType">检测的目标类型</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者 <paramref name="targetType" /> 为空；或者 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">如果当前类型不是指定的目标类型则抛出，则抛出参数 <paramref name="exceptionType" /> 指定的异常。</exception>
	[Conditional("DEBUG")]
	public static void AssertType(Type type, Type targetType, Type exceptionType, params object[] args)
	{
		EnsureType(type, targetType, exceptionType, args);
	}

	/// <summary>
	/// 检测当前断言条件是否为true，不满足则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <param name="predicate">断言条件</param>
	/// <param name="name">断言条件名称</param>
	/// <param name="message">抛出异常时的错误消息</param>
	/// <exception cref="T:System.ArgumentException">当前断言条件为false时，抛出异常。</exception>
	public static void Ensure(bool predicate, string name = null, string message = null)
	{
		if (!predicate)
		{
			throw new ArgumentException(message ?? Literals.MSG_PredicateNotMatched, name ?? "Predicate");
		}
	}

	/// <summary>
	/// 检测当前断言条件是否为true，不满足则抛出由参数 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <param name="predicate">断言条件</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <exception cref="T:System.ArgumentNullException">异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常生成方法 <paramref name="exceptionCreator" /> 执行异常或者返回空。</exception>
	/// <exception cref="T:System.Exception">当前断言条件是否为false时，抛出由参数 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static void Ensure(bool predicate, Func<Exception> exceptionCreator)
	{
		if (exceptionCreator == null)
		{
			throw new ArgumentNullException("Exception Creator", Literals.MSG_ExceptionCreatorNull);
		}
		if (!predicate)
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
			if (exception == null)
			{
				throw new TargetInvocationException(Literals.MSG_ExceptionCreatingFailed, null);
			}
			throw exception;
		}
	}

	/// <summary>
	/// 检测当前断言条件是否为true，不满足则抛出由参数 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <param name="predicate">断言条件</param>
	/// <param name="exceptionType">不满足条件时抛出的异常类型</param>
	/// <param name="args">异常参数列表</param>
	/// <exception cref="T:System.ArgumentNullException">异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">异常类型 <paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常类型 <paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前断言条件是否为false时，抛出由参数 <paramref name="exceptionType" /> 指定的异常</exception>
	public static void Ensure(bool predicate, Type exceptionType, params object[] args)
	{
		if (exceptionType == null)
		{
			throw new ArgumentNullException("Exception Type", Literals.MSG_ExceptionTypeNull);
		}
		if (!typeof(Exception).IsAssignableFrom(exceptionType))
		{
			throw new NotSupportedException(Literals.MSG_ExceptionTypeError);
		}
		if (!predicate)
		{
			Exception exception = null;
			try
			{
				exception = (Exception)Activator.CreateInstance(exceptionType, args ?? new object[0]);
			}
			catch (Exception ex)
			{
				throw new TargetInvocationException(Literals.MSG_ExceptionCreatingFailed, ex);
			}
			throw exception;
		}
	}

	/// <summary>
	/// 检测当前断言是否为true，不满足则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <param name="predicate">当前断言</param>
	/// <param name="name">断言条件名称</param>
	/// <param name="message">抛出异常时的错误消息</param>
	/// <exception cref="T:System.ArgumentNullException">当前断言 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前断言条件为false时，抛出异常。</exception>
	public static void Ensure(Func<bool> predicate, string name = null, string message = null)
	{
		EnsureNotNull(predicate, "predicate");
		if (!predicate())
		{
			throw new ArgumentException(message ?? Literals.MSG_PredicateNotMatched, name ?? "Predicate");
		}
	}

	/// <summary>
	/// 检测当前断言是否为true，不满足则抛出由参数 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <param name="predicate">当前断言</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前断言 <paramref name="predicate" /> 为空；或者异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常生成方法 <paramref name="exceptionCreator" /> 执行异常或者返回空。</exception>
	/// <exception cref="T:System.Exception">当前断言是否为false时，抛出由参数 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static void Ensure(Func<bool> predicate, Func<Exception> exceptionCreator)
	{
		EnsureNotNull(predicate, "predicate");
		if (exceptionCreator == null)
		{
			throw new ArgumentNullException("Exception Creator", Literals.MSG_ExceptionCreatorNull);
		}
		if (!predicate())
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
			if (exception == null)
			{
				throw new TargetInvocationException(Literals.MSG_ExceptionCreatingFailed, null);
			}
			throw exception;
		}
	}

	/// <summary>
	/// 检测当前断言是否为true，不满足则抛出由参数 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <param name="predicate">当前断言</param>
	/// <param name="exceptionType">不满足条件时抛出的异常类型</param>
	/// <param name="args">异常参数列表</param>
	/// <exception cref="T:System.ArgumentNullException">当前断言 <paramref name="predicate" /> 为空；或者异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">异常类型 <paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常类型 <paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前断言条件是否为false时，抛出由参数 <paramref name="exceptionType" /> 指定的异常</exception>
	public static void Ensure(Func<bool> predicate, Type exceptionType, params object[] args)
	{
		EnsureNotNull(predicate, "predicate");
		if (exceptionType == null)
		{
			throw new ArgumentNullException("Exception Type", Literals.MSG_ExceptionTypeNull);
		}
		if (!typeof(Exception).IsAssignableFrom(exceptionType))
		{
			throw new NotSupportedException(Literals.MSG_ExceptionTypeError);
		}
		if (!predicate())
		{
			Exception exception = null;
			try
			{
				exception = (Exception)Activator.CreateInstance(exceptionType, args ?? new object[0]);
			}
			catch (Exception ex)
			{
				throw new TargetInvocationException(Literals.MSG_ExceptionCreatingFailed, ex);
			}
			throw exception;
		}
	}

	/// <summary>
	/// 检测当前对象是否满足指定断言，不满足则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="obj">当前对象</param>
	/// <param name="predicate">对象检测断言</param>
	/// <param name="name">当前对象名称</param>
	/// <param name="message">抛出异常时的错误信息</param>
	/// <returns>如果当前对象满足指定断言，则返回当前对象。</returns>
	/// <exception cref="T:System.ArgumentNullException">对象检测断言 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">对象检测断言为false时，抛出异常。</exception>
	public static T Ensure<T>(T obj, Func<T, bool> predicate, string name = null, string message = null)
	{
		EnsureNotNull(predicate, "predicate");
		if (!predicate(obj))
		{
			throw new ArgumentException(message ?? string.Format(Literals.MSG_ValueError_1, obj), name ?? "Predicate");
		}
		return obj;
	}

	/// <summary>
	/// 检测当前对象是否满足指定断言，不满足则抛出由参数 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="obj">当前对象</param>
	/// <param name="predicate">对象检测断言</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果当前对象满足指定断言，则返回当前对象。</returns>
	/// <exception cref="T:System.ArgumentNullException">对象检测断言；或者异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常生成方法 <paramref name="exceptionCreator" /> 执行异常或者返回空。</exception>
	/// <exception cref="T:System.Exception">当前对象不满足指定断言，抛出由参数 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static T Ensure<T>(T obj, Func<T, bool> predicate, Func<Exception> exceptionCreator)
	{
		EnsureNotNull(predicate, "predicate");
		if (exceptionCreator == null)
		{
			throw new ArgumentNullException("Exception Creator", Literals.MSG_ExceptionCreatorNull);
		}
		if (!predicate(obj))
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
			if (exception == null)
			{
				throw new TargetInvocationException(Literals.MSG_ExceptionCreatingFailed, null);
			}
			throw exception;
		}
		return obj;
	}

	/// <summary>
	/// 检测当前对象是否满足指定断言，不满足则抛出由参数 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="obj">当前对象</param>
	/// <param name="predicate">对象检测条件</param>
	/// <param name="exceptionType">不满足条件时抛出的异常类型</param>
	/// <param name="args">异常参数列表</param>
	/// <returns>如果当前对象满足指定断言，则返回当前对象。</returns>
	/// <exception cref="T:System.ArgumentNullException">对象检测条件 <paramref name="predicate" /> 为空；或者异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">异常类型 <paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常类型 <paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象不满足指定断言，抛出由参数 <paramref name="exceptionType" /> 指定的异常</exception>
	public static T Ensure<T>(T obj, Func<T, bool> predicate, Type exceptionType, params object[] args)
	{
		EnsureNotNull(predicate, "predicate");
		if (exceptionType == null)
		{
			throw new ArgumentNullException("Exception Type", Literals.MSG_ExceptionTypeNull);
		}
		if (!typeof(Exception).IsAssignableFrom(exceptionType))
		{
			throw new NotSupportedException(Literals.MSG_ExceptionTypeError);
		}
		if (!predicate(obj))
		{
			Exception exception = null;
			try
			{
				exception = (Exception)Activator.CreateInstance(exceptionType, args ?? new object[0]);
			}
			catch (Exception ex)
			{
				throw new TargetInvocationException(Literals.MSG_ExceptionCreatingFailed, ex);
			}
			throw exception;
		}
		return obj;
	}

	/// <summary>
	/// 检测当前序列中的所有元素是否全部满足指定的条件，不全部满足则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <typeparam name="E">当前序列类型</typeparam>
	/// <param name="items">当前序列</param>
	/// <param name="predicate">指定的检测规则</param>
	/// <param name="name">序列名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检查通过则返回原序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测规则 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前序列中的任一元素不满足指定检测规则。</exception>
	public static E EnsureAll<E>(E items, Func<object, bool> predicate, string name = null, string message = null) where E : IEnumerable
	{
		EnsureNotNull(items, "items");
		EnsureNotNull(predicate, "predicate");
		Ensure(CollectionHelper.All(items, predicate), name ?? "item", message ?? Literals.MSG_SequenceAnyOneElementNotInPredicate);
		return items;
	}

	/// <summary>
	/// 检测当前序列中的所有元素是否全部满足指定的条件，不全部满足则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="E">当前序列类型</typeparam>
	/// <param name="items">当前序列</param>
	/// <param name="predicate">指定的检测规则</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检查通过则返回原序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测规则 <paramref name="predicate" /> 为空；或者异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前序列中的任一元素不满足指定检测规则，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static E EnsureAll<E>(E items, Func<object, bool> predicate, Func<Exception> exceptionCreator) where E : IEnumerable
	{
		EnsureNotNull(items, "items");
		EnsureNotNull(predicate, "predicate");
		Ensure(CollectionHelper.All(items, predicate), exceptionCreator);
		return items;
	}

	/// <summary>
	/// 检测当前序列中的所有元素是否全部满足指定的条件，不全部满足则抛出 <paramref name="exceptionType" /> 类型的异常
	/// </summary>
	/// <typeparam name="E">当前序列类型</typeparam>
	/// <param name="items">当前序列</param>
	/// <param name="predicate">指定的检测规则</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检查通过则返回原序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测规则 <paramref name="predicate" /> 为空；或者异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前序列中的任一元素不满足指定检测规则，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static E EnsureAll<E>(E items, Func<object, bool> predicate, Type exceptionType, params object[] args) where E : IEnumerable
	{
		EnsureNotNull(items, "items");
		EnsureNotNull(predicate, "predicate");
		Ensure(CollectionHelper.All(items, predicate), exceptionType, args);
		return items;
	}

	/// <summary>
	/// 检测当前序列中的所有元素是否全部满足指定的条件，不全部满足则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <typeparam name="E">当前序列类型</typeparam>
	/// <param name="items">当前序列</param>
	/// <param name="predicate">指定的检测规则</param>
	/// <param name="name">序列名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检查通过则返回原序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测规则 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前序列中的任一元素不满足指定检测规则。</exception>
	public static E EnsureAll<T, E>(E items, Func<T, bool> predicate, string name = null, string message = null) where E : IEnumerable<T>
	{
		EnsureNotNull(items, "items");
		EnsureNotNull(predicate, "predicate");
		Ensure(items.All(predicate), name ?? "item", message ?? Literals.MSG_SequenceAnyOneElementNotInPredicate);
		return items;
	}

	/// <summary>
	/// 检测当前序列中的所有元素是否全部满足指定的条件，不全部满足则抛出指定异常
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <typeparam name="E">当前序列类型</typeparam>
	/// <param name="items">当前序列</param>
	/// <param name="predicate">指定的检测规则</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检查通过则返回原序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测规则 <paramref name="predicate" /> 为空；或者异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前序列中的任一元素不满足指定检测规则，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static E EnsureAll<T, E>(E items, Func<T, bool> predicate, Func<Exception> exceptionCreator) where E : IEnumerable<T>
	{
		EnsureNotNull(items, "items");
		EnsureNotNull(predicate, "predicate");
		Ensure(items.All(predicate), exceptionCreator);
		return items;
	}

	/// <summary>
	/// 检测当前序列中的所有元素是否全部满足指定的条件，不全部满足则抛出指定异常
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <typeparam name="E">当前序列类型</typeparam>
	/// <param name="items">当前序列</param>
	/// <param name="predicate">指定的检测规则</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检查通过则返回原序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测规则 <paramref name="predicate" /> 为空；或者异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前序列中的任一元素不满足指定检测规则，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static E EnsureAll<T, E>(E items, Func<T, bool> predicate, Type exceptionType, params object[] args) where E : IEnumerable<T>
	{
		EnsureNotNull(items, "items");
		EnsureNotNull(predicate, "predicate");
		Ensure(items.All(predicate), exceptionType, args);
		return items;
	}

	/// <summary>
	/// 检测当前序列中的所有元素是否全部不满足指定的条件，如果存在满足条件的元素则抛出 <see cref="T:System.ArgumentException" /> 异常。
	/// </summary>
	/// <typeparam name="E">当前序列类型</typeparam>
	/// <param name="items">当前序列</param>
	/// <param name="predicate">指定的检测规则</param>
	/// <param name="name">序列名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检查通过则返回原序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测规则 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前序列中的任一元素满足指定检测规则。</exception>
	public static E EnsureAllNot<E>(E items, Func<object, bool> predicate, string name = null, string message = null) where E : IEnumerable
	{
		EnsureNotNull(items, "items");
		EnsureNotNull(predicate, "predicate");
		Ensure(CollectionHelper.AllNot(items, predicate), name ?? "item", message ?? Literals.MSG_SequenceAnyOneElementInPredicate);
		return items;
	}

	/// <summary>
	/// 检测当前序列中的所有元素是否全部不满足指定的条件，如果存在满足条件的元素则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="E">当前序列类型</typeparam>
	/// <param name="items">当前序列</param>
	/// <param name="predicate">指定的检测规则</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检查通过则返回原序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测规则 <paramref name="predicate" /> 为空；或者异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前序列中的任一元素满足指定检测规则，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static E EnsureAllNot<E>(E items, Func<object, bool> predicate, Func<Exception> exceptionCreator) where E : IEnumerable
	{
		EnsureNotNull(items, "items");
		EnsureNotNull(predicate, "predicate");
		Ensure(CollectionHelper.AllNot(items, predicate), exceptionCreator);
		return items;
	}

	/// <summary>
	/// 检测当前序列中的所有元素是否全部不满足指定的条件，如果存在满足条件的元素则抛出 <paramref name="exceptionType" /> 类型的异常
	/// </summary>
	/// <typeparam name="E">当前序列类型</typeparam>
	/// <param name="items">当前序列</param>
	/// <param name="predicate">指定的检测规则</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检查通过则返回原序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测规则 <paramref name="predicate" /> 为空；或者异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前序列中的任一元素满足指定检测规则，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static E EnsureAllNot<E>(E items, Func<object, bool> predicate, Type exceptionType, params object[] args) where E : IEnumerable
	{
		EnsureNotNull(items, "items");
		EnsureNotNull(predicate, "predicate");
		Ensure(CollectionHelper.AllNot(items, predicate), exceptionType, args);
		return items;
	}

	/// <summary>
	/// 检测当前序列中的所有元素是否全部不满足指定的条件，如果存在满足条件的元素则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <typeparam name="E">当前序列类型</typeparam>
	/// <param name="items">当前序列</param>
	/// <param name="predicate">指定的检测规则</param>
	/// <param name="name">序列名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检查通过则返回原序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测规则 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前序列中的任一元素满足指定检测规则。</exception>
	public static E EnsureAllNot<T, E>(E items, Func<T, bool> predicate, string name = null, string message = null) where E : IEnumerable<T>
	{
		EnsureNotNull(items, "items");
		EnsureNotNull(predicate, "predicate");
		Ensure(CollectionHelper.AllNot(items, predicate), name ?? "item", message ?? Literals.MSG_SequenceAnyOneElementInPredicate);
		return items;
	}

	/// <summary>
	/// 检测当前序列中的所有元素是否全部不满足指定的条件，如果存在满足条件的元素则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <typeparam name="E">当前序列类型</typeparam>
	/// <param name="items">当前序列</param>
	/// <param name="predicate">指定的检测规则</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检查通过则返回原序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测规则 <paramref name="predicate" /> 为空；或者异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前序列中的任一元素满足指定检测规则，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static E EnsureAllNot<T, E>(E items, Func<T, bool> predicate, Func<Exception> exceptionCreator) where E : IEnumerable<T>
	{
		EnsureNotNull(items, "items");
		EnsureNotNull(predicate, "predicate");
		Ensure(CollectionHelper.AllNot(items, predicate), exceptionCreator);
		return items;
	}

	/// <summary>
	/// 检测当前序列中的所有元素是否全部不满足指定的条件，如果存在满足条件的元素则抛出 <paramref name="exceptionType" /> 类型的异常
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <typeparam name="E">当前序列类型</typeparam>
	/// <param name="items">当前待检测的序列</param>
	/// <param name="predicate">指定的检测规则</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检查通过则返回原序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测规则 <paramref name="predicate" /> 为空；或者异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前序列中的任一元素满足指定检测规则，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static E EnsureAllNot<T, E>(E items, Func<T, bool> predicate, Type exceptionType, params object[] args) where E : IEnumerable<T>
	{
		EnsureNotNull(items, "items");
		EnsureNotNull(predicate, "predicate");
		Ensure(CollectionHelper.AllNot(items, predicate), exceptionType, args);
		return items;
	}

	/// <summary>
	/// 检测当前序列中是否有满足指定的条件的元素，如果不存在满足条件的元素则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <typeparam name="E">当前序列类型</typeparam>
	/// <param name="items">当前待检测的序列</param>
	/// <param name="predicate">指定的检测规则</param>
	/// <param name="name">序列名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检查通过则返回原序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测规则 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前序列中的元素全部不满足指定检测规则。</exception>
	public static E EnsureAny<E>(E items, Func<object, bool> predicate, string name = null, string message = null) where E : IEnumerable
	{
		EnsureNotNull(items, "items");
		EnsureNotNull(predicate, "predicate");
		Ensure(CollectionHelper.Any(items, predicate), name ?? "item", message ?? Literals.MSG_SequenceNotElementInPredicate);
		return items;
	}

	/// <summary>
	/// 检测当前序列中是否有满足指定的条件的元素，如果不存在满足条件的元素则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="E">当前序列类型</typeparam>
	/// <param name="items">当前待检测的序列</param>
	/// <param name="predicate">指定的检测规则</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检查通过则返回原序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测规则 <paramref name="predicate" /> 为空；或者异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前序列中的元素全部不满足指定检测规则，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static E EnsureAny<E>(E items, Func<object, bool> predicate, Func<Exception> exceptionCreator) where E : IEnumerable
	{
		EnsureNotNull(items, "items");
		EnsureNotNull(predicate, "predicate");
		Ensure(CollectionHelper.Any(items, predicate), exceptionCreator);
		return items;
	}

	/// <summary>
	/// 检测当前序列中是否有满足指定的条件的元素，如果不存在满足条件的元素则抛出 <paramref name="exceptionType" /> 类型的异常
	/// </summary>
	/// <typeparam name="E">当前序列类型</typeparam>
	/// <param name="items">当前待检测的序列</param>
	/// <param name="predicate">指定的检测规则</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检查通过则返回原序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测规则 <paramref name="predicate" /> 为空；或者异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前序列中的元素全部不满足指定检测规则，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static E EnsureAny<E>(E items, Func<object, bool> predicate, Type exceptionType, params object[] args) where E : IEnumerable
	{
		EnsureNotNull(items, "items");
		EnsureNotNull(predicate, "predicate");
		Ensure(CollectionHelper.Any(items, predicate), exceptionType, args);
		return items;
	}

	/// <summary>
	/// 检测当前序列中是否有满足指定的条件的元素，如果不存在满足条件的元素则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <typeparam name="E">当前序列类型</typeparam>
	/// <param name="items">当前待检测的序列</param>
	/// <param name="predicate">指定的检测规则</param>
	/// <param name="name">序列名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检查通过则返回原序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测规则 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前序列中的元素全部不满足指定检测规则。</exception>
	public static E EnsureAny<T, E>(E items, Func<T, bool> predicate, string name = null, string message = null) where E : IEnumerable<T>
	{
		EnsureNotNull(items, "items");
		EnsureNotNull(predicate, "predicate");
		Ensure(items.Any(predicate), name ?? "item", message ?? Literals.MSG_SequenceNotElementInPredicate);
		return items;
	}

	/// <summary>
	/// 检测当前序列中是否有满足指定的条件的元素，如果不存在满足条件的元素则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <typeparam name="E">当前序列类型</typeparam>
	/// <param name="items">当前待检测的序列</param>
	/// <param name="predicate">指定的检测规则</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检查通过则返回原序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测规则 <paramref name="predicate" /> 为空；或者异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前序列中的元素全部不满足指定检测规则，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static E EnsureAny<T, E>(E items, Func<T, bool> predicate, Func<Exception> exceptionCreator) where E : IEnumerable<T>
	{
		EnsureNotNull(items, "items");
		EnsureNotNull(predicate, "predicate");
		Ensure(items.Any(predicate), exceptionCreator);
		return items;
	}

	/// <summary>
	/// 检测当前序列中是否有满足指定的条件的元素，如果不存在满足条件的元素则抛出 <paramref name="exceptionType" /> 类型的异常
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <typeparam name="E">当前序列类型</typeparam>
	/// <param name="items">当前待检测的序列</param>
	/// <param name="predicate">指定的检测规则</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检查通过则返回原序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测规则 <paramref name="predicate" /> 为空；或者异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前序列中的元素全部不满足指定检测规则，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static E EnsureAny<T, E>(E items, Func<T, bool> predicate, Type exceptionType, params object[] args) where E : IEnumerable<T>
	{
		EnsureNotNull(items, "items");
		EnsureNotNull(predicate, "predicate");
		Ensure(items.Any(predicate), exceptionType, args);
		return items;
	}

	/// <summary>
	/// 检测当前序列中是否有不满足指定的条件的元素，全部都满足条件的元素则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <typeparam name="E">当前序列类型</typeparam>
	/// <param name="items">当前序列</param>
	/// <param name="predicate">指定的检测规则</param>
	/// <param name="name">序列名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检查通过则返回原序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测规则 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前序列中的元素全部满足指定检测规则。</exception>
	public static E EnsureAnyNot<E>(E items, Func<object, bool> predicate, string name = null, string message = null) where E : IEnumerable
	{
		EnsureNotNull(items, "items");
		EnsureNotNull(predicate, "predicate");
		Ensure(CollectionHelper.AnyNot(items, predicate), name ?? "item", message ?? Literals.MSG_SequenceAllElementInPredicate);
		return items;
	}

	/// <summary>
	/// 检测当前序列中是否有不满足指定的条件的元素，全部都满足条件的元素则抛出指定异常
	/// </summary>
	/// <typeparam name="E">当前序列类型</typeparam>
	/// <param name="items">当前待检测的序列</param>
	/// <param name="predicate">指定的检测规则</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检查通过则返回原序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测规则 <paramref name="predicate" /> 为空；或者异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前序列中的元素全部满足指定检测规则，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static E EnsureAnyNot<E>(E items, Func<object, bool> predicate, Func<Exception> exceptionCreator) where E : IEnumerable
	{
		EnsureNotNull(items, "items");
		EnsureNotNull(predicate, "predicate");
		Ensure(CollectionHelper.AnyNot(items, predicate), exceptionCreator);
		return items;
	}

	/// <summary>
	/// 检测当前序列中是否有不满足指定的条件的元素，全部都满足条件的元素则抛出指定异常
	/// </summary>
	/// <typeparam name="E">当前序列类型</typeparam>
	/// <param name="items">当前待检测的序列</param>
	/// <param name="predicate">指定的检测规则</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检查通过则返回原序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测规则 <paramref name="predicate" /> 为空；或者异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前序列中的元素全部满足指定检测规则，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static E EnsureAnyNot<E>(E items, Func<object, bool> predicate, Type exceptionType, params object[] args) where E : IEnumerable
	{
		EnsureNotNull(items, "items");
		EnsureNotNull(predicate, "predicate");
		Ensure(CollectionHelper.AnyNot(items, predicate), exceptionType, args);
		return items;
	}

	/// <summary>
	/// 检测当前序列中是否有不满足指定的条件的元素，全部都满足条件的元素则抛出ArgumentException
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <typeparam name="E">当前序列类型</typeparam>
	/// <param name="items">当前待检测的序列</param>
	/// <param name="predicate">指定的检测规则</param>
	/// <param name="name">序列名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检查通过则返回原序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测规则 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前序列中的元素全部满足指定检测规则。</exception>
	public static E EnsureAnyNot<T, E>(E items, Func<T, bool> predicate, string name = null, string message = null) where E : IEnumerable<T>
	{
		EnsureNotNull(items, "items");
		EnsureNotNull(predicate, "predicate");
		Ensure(CollectionHelper.AnyNot(items, predicate), name ?? "item", message ?? Literals.MSG_SequenceAllElementInPredicate);
		return items;
	}

	/// <summary>
	/// 检测当前序列中是否有不满足指定的条件的元素，全部都满足条件的元素则抛出指定异常
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <typeparam name="E">当前序列类型</typeparam>
	/// <param name="items">当前待检测的序列</param>
	/// <param name="predicate">指定的检测规则</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检查通过则返回原序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测规则 <paramref name="predicate" /> 为空；或者异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前序列中的元素全部满足指定检测规则，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static E EnsureAnyNot<T, E>(E items, Func<T, bool> predicate, Func<Exception> exceptionCreator) where E : IEnumerable<T>
	{
		EnsureNotNull(items, "items");
		EnsureNotNull(predicate, "predicate");
		Ensure(CollectionHelper.AnyNot(items, predicate), exceptionCreator);
		return items;
	}

	/// <summary>
	/// 检测当前序列中是否有不满足指定的条件的元素，全部都满足条件的元素则抛出指定异常
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <typeparam name="E">当前序列类型</typeparam>
	/// <param name="items">当前待检测的序列</param>
	/// <param name="predicate">指定的检测规则</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检查通过则返回原序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测规则 <paramref name="predicate" /> 为空；或者异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前序列中的元素全部满足指定检测规则，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static E EnsureAnyNot<T, E>(E items, Func<T, bool> predicate, Type exceptionType, params object[] args) where E : IEnumerable<T>
	{
		EnsureNotNull(items, "items");
		EnsureNotNull(predicate, "predicate");
		Ensure(CollectionHelper.AnyNot(items, predicate), exceptionType, args);
		return items;
	}

	/// <summary>
	/// 检测当前数组的元素个数，如果数组的元素个数不等于 <paramref name="length" />，则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="length">数组需要满足的指定长度</param>
	/// <param name="name">数组对象名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过返回当前数组本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="length" /> 小于0。</exception>
	/// <exception cref="T:System.ArgumentException">如果当前数组元素个数不等于 <paramref name="length" />，则抛出该异常。</exception>
	public static Array EnsureArrayLength(Array array, int length, string name = null, string message = null)
	{
		EnsureNotNull(array, "array");
		EnsureGreaterThanOrEqualTo(length, 0, "length");
		Ensure(array.Length == length, () => new ArgumentException(message ?? Literals.MSG_ArrayLengthError, name ?? "array"));
		return array;
	}

	/// <summary>
	/// 检测当前数组的元素个数，如果数组的元素个数不等于 <paramref name="length" />，则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="length">数组需要满足的指定长度</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过返回当前数组本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="length" /> 小于0。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">如果当前数组元素个数不等于 <paramref name="length" />，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static Array EnsureArrayLength(Array array, int length, Func<Exception> exceptionCreator)
	{
		EnsureNotNull(array, "array");
		EnsureGreaterThanOrEqualTo(length, 0, "length");
		Ensure(array.Length == length, exceptionCreator);
		return array;
	}

	/// <summary>
	/// 检测当前数组的元素个数，如果数组的元素个数不等于 <paramref name="length" />，则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="length">数组需要满足的指定长度</param>
	/// <param name="exceptionType">抛出的异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检测通过返回当前数组本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="length" /> 小于0。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">如果当前数组元素个数不等于 <paramref name="length" />，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static Array EnsureArrayLength(Array array, int length, Type exceptionType, params object[] args)
	{
		EnsureNotNull(array, "array");
		EnsureGreaterThanOrEqualTo(length, 0, "length");
		Ensure(array.Length == length, exceptionType, args);
		return array;
	}

	/// <summary>
	/// 检测当前数组的元素个数，如果数组的元素个数不等于 <paramref name="length" />，则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="length">数组需要满足的指定长度</param>
	/// <param name="name">数组对象名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过返回当前数组本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="length" /> 小于0。</exception>
	/// <exception cref="T:System.ArgumentException">如果当前数组元素个数不等于 <paramref name="length" />，则抛出该异常。</exception>
	public static Array EnsureArrayLength(Array array, long length, string name = null, string message = null)
	{
		EnsureNotNull(array, "array");
		EnsureGreaterThanOrEqualTo(length, 0L, "length");
		Ensure(array.LongLength == length, () => new ArgumentException(message ?? Literals.MSG_ArrayLengthError, name ?? "array"));
		return array;
	}

	/// <summary>
	/// 检测当前数组的元素个数，如果数组的元素个数不等于 <paramref name="length" />，则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="length">数组需要满足的指定长度</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过返回当前数组本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="length" /> 小于0。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">如果当前数组元素个数不等于 <paramref name="length" />，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static Array EnsureArrayLength(Array array, long length, Func<Exception> exceptionCreator)
	{
		EnsureNotNull(array, "array");
		EnsureGreaterThanOrEqualTo(length, 0L, "length");
		Ensure(array.LongLength == length, exceptionCreator);
		return array;
	}

	/// <summary>
	/// 检测当前数组的元素个数，如果数组的元素个数不等于 <paramref name="length" />，则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="length">数组需要满足的指定长度</param>
	/// <param name="exceptionType">抛出的异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检测通过返回当前数组本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="length" /> 小于0。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">如果当前数组元素个数不等于 <paramref name="length" />，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static Array EnsureArrayLength(Array array, long length, Type exceptionType, params object[] args)
	{
		EnsureNotNull(array, "array");
		EnsureGreaterThanOrEqualTo(length, 0L, "length");
		Ensure(array.LongLength == length, exceptionType, args);
		return array;
	}

	/// <summary>
	/// 检测当前数组的元素个数，如果数组的元素个数不等于 <paramref name="length" />，则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="length">数组需要满足的指定长度</param>
	/// <param name="name">数组对象名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过返回当前数组本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="length" /> 小于0。</exception>
	/// <exception cref="T:System.ArgumentException">如果当前数组元素个数不等于 <paramref name="length" />，则抛出该异常。</exception>
	public static T[] EnsureArrayLength<T>(T[] array, int length, string name = null, string message = null)
	{
		EnsureNotNull(array, "array");
		EnsureGreaterThanOrEqualTo(length, 0, "length");
		Ensure(array.Length == length, () => new ArgumentException(message ?? Literals.MSG_ArrayLengthError, name ?? "array"));
		return array;
	}

	/// <summary>
	/// 检测当前数组的元素个数，如果数组的元素个数不等于 <paramref name="length" />，则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="length">数组需要满足的指定长度</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过返回当前数组本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="length" /> 小于0。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">如果当前数组元素个数不等于 <paramref name="length" />，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static T[] EnsureArrayLength<T>(T[] array, int length, Func<Exception> exceptionCreator)
	{
		EnsureNotNull(array, "array");
		EnsureGreaterThanOrEqualTo(length, 0, "length");
		Ensure(array.Length == length, exceptionCreator);
		return array;
	}

	/// <summary>
	/// 检测当前数组的元素个数，如果数组的元素个数不等于 <paramref name="length" />，则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="length">数组需要满足的指定长度</param>
	/// <param name="exceptionType">抛出的异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检测通过返回当前数组本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="length" /> 小于0。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">如果当前数组元素个数不等于 <paramref name="length" />，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static T[] EnsureArrayLength<T>(T[] array, int length, Type exceptionType, params object[] args)
	{
		EnsureNotNull(array, "array");
		EnsureGreaterThanOrEqualTo(length, 0, "length");
		Ensure(array.Length == length, exceptionType, args);
		return array;
	}

	/// <summary>
	/// 检测当前数组的元素个数，如果数组的元素个数不等于 <paramref name="length" />，则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="length">数组需要满足的指定长度</param>
	/// <param name="name">数组对象名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过返回当前数组本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="length" /> 小于0。</exception>
	/// <exception cref="T:System.ArgumentException">如果当前数组元素个数不等于 <paramref name="length" />，则抛出该异常。</exception>
	public static T[] EnsureArrayLength<T>(T[] array, long length, string name = null, string message = null)
	{
		EnsureNotNull(array, "array");
		EnsureGreaterThanOrEqualTo(length, 0L, "length");
		Ensure(array.LongLength == length, () => new ArgumentException(message ?? Literals.MSG_ArrayLengthError, name ?? "array"));
		return array;
	}

	/// <summary>
	/// 检测当前数组的元素个数，如果数组的元素个数不等于 <paramref name="length" />，则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="length">数组需要满足的指定长度</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过返回当前数组本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="length" /> 小于0。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">如果当前数组元素个数不等于 <paramref name="length" />，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static T[] EnsureArrayLength<T>(T[] array, long length, Func<Exception> exceptionCreator)
	{
		EnsureNotNull(array, "array");
		EnsureGreaterThanOrEqualTo(length, 0L, "length");
		Ensure(array.LongLength == length, exceptionCreator);
		return array;
	}

	/// <summary>
	/// 检测当前数组的元素个数，如果数组的元素个数不等于 <paramref name="length" />，则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="length">数组需要满足的指定长度</param>
	/// <param name="exceptionType">抛出的异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检测通过返回当前数组本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="length" /> 小于0。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">如果当前数组元素个数不等于 <paramref name="length" />，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static T[] EnsureArrayLength<T>(T[] array, long length, Type exceptionType, params object[] args)
	{
		EnsureNotNull(array, "array");
		EnsureGreaterThanOrEqualTo(length, 0L, "length");
		Ensure(array.LongLength == length, exceptionType, args);
		return array;
	}

	/// <summary>
	/// 检测当前数组的秩（维数），如果数组的秩（维数）不等于 <paramref name="rank" />，则抛出 <see cref="T:System.RankException" /> 异常
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="rank">数组需要满足的秩（维数）</param>
	/// <param name="name">数组对象名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过返回当前数组本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="rank" /> 小于1。</exception>
	/// <exception cref="T:System.RankException">当前数组的秩（维数）不等于 <paramref name="rank" />。</exception>
	public static Array EnsureArrayRank(Array array, int rank, string name = null, string message = null)
	{
		EnsureNotNull(array, "array");
		EnsureGreaterThanOrEqualTo(rank, 1, "rank");
		Ensure(array.Rank == rank, () => new RankException(string.Format(message ?? Literals.MSG_ArrayRankError_1, name ?? "array")));
		return array;
	}

	/// <summary>
	/// 检测当前数组的秩（维数），如果数组的秩（维数）不等于 <paramref name="rank" />，则抛出 <paramref name="exceptionCreator" /> 生成的异常。
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="rank">数组需要满足的秩（维数）</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过返回当前数组本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="rank" /> 小于1。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前数组的秩（维数）不等于 <paramref name="rank" />，则抛出 <paramref name="exceptionCreator" /> 生成的异常</exception>
	public static Array EnsureArrayRank(Array array, int rank, Func<Exception> exceptionCreator)
	{
		EnsureNotNull(array, "array");
		EnsureGreaterThanOrEqualTo(rank, 1, "rank");
		Ensure(array.Rank == rank, exceptionCreator);
		return array;
	}

	/// <summary>
	/// 检测当前数组的秩（维数），如果数组的秩（维数）不等于 <paramref name="rank" />，则抛出 <paramref name="exceptionType" /> 指定的异常。
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="rank">数组需要满足的秩（维数）</param>
	/// <param name="exceptionType">抛出的异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检测通过返回当前数组本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="rank" /> 小于1。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前数组的秩（维数）不等于 <paramref name="rank" />，则抛出 <paramref name="exceptionType" /> 指定的异常</exception>
	public static Array EnsureArrayRank(Array array, int rank, Type exceptionType, params object[] args)
	{
		EnsureNotNull(array, "array");
		EnsureGreaterThanOrEqualTo(rank, 1, "rank");
		Ensure(array.Rank == rank, exceptionType, args);
		return array;
	}

	/// <summary>
	/// 检测当前数组的秩（维数），如果数组的秩（维数）不等于 <paramref name="rank" />，则抛出 <see cref="T:System.RankException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="rank">数组需要满足的秩（维数）</param>
	/// <param name="name">数组对象名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过返回当前数组本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="rank" /> 小于1。</exception>
	/// <exception cref="T:System.RankException">当前数组的秩（维数）不等于 <paramref name="rank" />。</exception>
	public static T[] EnsureArrayRank<T>(T[] array, int rank, string name = null, string message = null)
	{
		EnsureNotNull(array, "array");
		EnsureGreaterThanOrEqualTo(rank, 1, "rank");
		Ensure(array.Rank == rank, () => new RankException(string.Format(message ?? Literals.MSG_ArrayRankError_1, name ?? "array")));
		return array;
	}

	/// <summary>
	/// 检测当前数组的秩（维数），如果数组的秩（维数）不等于 <paramref name="rank" />，则抛出 <paramref name="exceptionCreator" /> 生成的异常。
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">前数组</param>
	/// <param name="rank">数组需要满足的秩（维数）</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过返回当前数组本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="rank" /> 小于1。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前数组的秩（维数）不等于 <paramref name="rank" />，则抛出 <paramref name="exceptionCreator" /> 生成的异常</exception>
	public static T[] EnsureArrayRank<T>(T[] array, int rank, Func<Exception> exceptionCreator)
	{
		EnsureNotNull(array, "array");
		EnsureGreaterThanOrEqualTo(rank, 1, "rank");
		Ensure(array.Rank == rank, exceptionCreator);
		return array;
	}

	/// <summary>
	/// 检测当前数组的秩（维数），如果数组的秩（维数）不等于 <paramref name="rank" />，则抛出 <paramref name="exceptionType" /> 指定的异常。
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="rank">数组需要满足的秩（维数）</param>
	/// <param name="exceptionType">抛出的异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检测通过返回当前数组本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="rank" /> 小于1。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前数组的秩（维数）不等于 <paramref name="rank" />，则抛出 <paramref name="exceptionType" /> 指定的异常</exception>
	public static T[] EnsureArrayRank<T>(T[] array, int rank, Type exceptionType, params object[] args)
	{
		EnsureNotNull(array, "array");
		EnsureGreaterThanOrEqualTo(rank, 1, "rank");
		Ensure(array.Rank == rank, exceptionType, args);
		return array;
	}

	/// <summary>
	/// 检测当前数组的指定秩（维度） <paramref name="rank" /> 的元素数量，如果不等于 <paramref name="length" /> 则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="rank">数组检查元素数量的秩（维度），从1开始</param>
	/// <param name="length">数组指定秩（维度）中元素数量的条件</param>
	/// <param name="name">数组的名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过返回当前数组本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="rank" /> 小于1；或者 <paramref name="length" /> 小于0。</exception>
	/// <exception cref="T:System.ArgumentException">如果当前数组指定秩（维数）<paramref name="rank" /> 的元素数量不等于 <paramref name="length" />，则抛出该异常。</exception>
	public static Array EnsureArrayRankLength(Array array, int rank, int length, string name = null, string message = null)
	{
		EnsureNotNull(array, "array");
		EnsureBetween(rank, 1, array.Rank, "rank");
		EnsureGreaterThanOrEqualTo(length, 0, "length");
		Ensure(array.GetLength(rank - 1) == length, () => new ArgumentException(string.Format(message ?? Literals.MSG_ArrayRankLengthError_1, rank), name ?? "array"));
		return array;
	}

	/// <summary>
	/// 检测当前数组的指定秩（维度） <paramref name="rank" /> 的元素数量，如果不等于 <paramref name="length" /> 则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="rank">数组检查元素数量的秩（维度），从1开始</param>
	/// <param name="length">数组指定秩（维度）中元素数量的条件</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过返回当前数组本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="rank" /> 小于1；或者 <paramref name="length" /> 小于0。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">如果当前数组指定秩（维数）<paramref name="rank" /> 的元素数量不等于 <paramref name="length" />，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static Array EnsureArrayRankLength(Array array, int rank, int length, Func<Exception> exceptionCreator)
	{
		EnsureNotNull(array, "array");
		EnsureBetween(rank, 1, array.Rank, "rank");
		EnsureGreaterThanOrEqualTo(length, 0, "length");
		Ensure(array.GetLength(rank - 1) == length, exceptionCreator);
		return array;
	}

	/// <summary>
	/// 检测当前数组的指定秩（维度） <paramref name="rank" /> 的元素数量，如果不等于 <paramref name="length" /> 则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="rank">数组检查元素数量的秩（维度），从1开始</param>
	/// <param name="length">数组指定秩（维度）中元素数量的条件</param>
	/// <param name="exceptionType">抛出的异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检测通过返回当前数组本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="rank" /> 小于1；或者 <paramref name="length" /> 小于0。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">如果当前数组指定秩（维数）<paramref name="rank" /> 的元素数量不等于 <paramref name="length" />，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static Array EnsureArrayRankLength(Array array, int rank, int length, Type exceptionType, params object[] args)
	{
		EnsureNotNull(array, "array");
		EnsureBetween(rank, 1, array.Rank, "rank");
		EnsureGreaterThanOrEqualTo(length, 0, "length");
		Ensure(array.GetLength(rank - 1) == length, exceptionType, args);
		return array;
	}

	/// <summary>
	/// 检测当前数组的指定秩（维度） <paramref name="rank" /> 的元素数量，如果不等于 <paramref name="length" /> 则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="rank">数组检查元素数量的秩（维度），从1开始</param>
	/// <param name="length">数组指定秩（维度）中元素数量的条件</param>
	/// <param name="name">数组的名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过返回当前数组本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="rank" /> 小于1；或者 <paramref name="length" /> 小于0。</exception>
	/// <exception cref="T:System.ArgumentException">如果当前数组指定秩（维数）<paramref name="rank" /> 的元素数量不等于 <paramref name="length" />，则抛出该异常。</exception>
	public static Array EnsureArrayRankLength(Array array, int rank, long length, string name = null, string message = null)
	{
		EnsureNotNull(array, "array");
		EnsureBetween(rank, 1, array.Rank, "rank");
		EnsureGreaterThanOrEqualTo(length, 0L, "length");
		Ensure(array.GetLongLength(rank - 1) == length, () => new ArgumentException(string.Format(message ?? Literals.MSG_ArrayRankLengthError_1, rank), name ?? "array"));
		return array;
	}

	/// <summary>
	/// 检测当前数组的指定秩（维度） <paramref name="rank" /> 的元素数量，如果不等于 <paramref name="length" /> 则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="rank">数组检查元素数量的秩（维度），从1开始</param>
	/// <param name="length">数组指定秩（维度）中元素数量的条件</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过返回当前数组本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="rank" /> 小于1；或者 <paramref name="length" /> 小于0。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">如果当前数组指定秩（维数）<paramref name="rank" /> 的元素数量不等于 <paramref name="length" />，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static Array EnsureArrayRankLength(Array array, int rank, long length, Func<Exception> exceptionCreator)
	{
		EnsureNotNull(array, "array");
		EnsureBetween(rank, 1, array.Rank, "rank");
		EnsureGreaterThanOrEqualTo(length, 0L, "length");
		Ensure(array.GetLongLength(rank - 1) == length, exceptionCreator);
		return array;
	}

	/// <summary>
	/// 检测当前数组的指定秩（维度） <paramref name="rank" /> 的元素数量，如果不等于 <paramref name="length" /> 则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="rank">数组检查元素数量的秩（维度），从1开始</param>
	/// <param name="length">数组指定秩（维度）中元素数量的条件</param>
	/// <param name="exceptionType">抛出的异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检测通过返回当前数组本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="rank" /> 小于1；或者 <paramref name="length" /> 小于0。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">如果当前数组指定秩（维数）<paramref name="rank" /> 的元素数量不等于 <paramref name="length" />，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static Array EnsureArrayRankLength(Array array, int rank, long length, Type exceptionType, params object[] args)
	{
		EnsureNotNull(array, "array");
		EnsureBetween(rank, 1, array.Rank, "rank");
		EnsureGreaterThanOrEqualTo(length, 0L, "length");
		Ensure(array.GetLongLength(rank - 1) == length, exceptionType, args);
		return array;
	}

	/// <summary>
	/// 检测当前数组的指定秩（维度） <paramref name="rank" /> 的元素数量，如果不等于 <paramref name="length" /> 则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="rank">数组检查元素数量的秩（维度），从1开始</param>
	/// <param name="length">数组指定秩（维度）中元素数量的条件</param>
	/// <param name="name">数组的名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过返回当前数组本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="rank" /> 小于1；或者 <paramref name="length" /> 小于0。</exception>
	/// <exception cref="T:System.ArgumentException">如果当前数组指定秩（维数）<paramref name="rank" /> 的元素数量不等于 <paramref name="length" />，则抛出该异常。</exception>
	public static T[] EnsureArrayRankLength<T>(T[] array, int rank, int length, string name = null, string message = null)
	{
		EnsureNotNull(array, "array");
		EnsureBetween(rank, 1, array.Rank, "rank");
		EnsureGreaterThanOrEqualTo(length, 0, "length");
		Ensure(array.GetLength(rank - 1) == length, () => new ArgumentException(string.Format(message ?? Literals.MSG_ArrayRankLengthError_1, rank), name ?? "array"));
		return array;
	}

	/// <summary>
	/// 检测当前数组的指定秩（维度） <paramref name="rank" /> 的元素数量，如果不等于 <paramref name="length" /> 则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="rank">数组检查元素数量的秩（维度），从1开始</param>
	/// <param name="length">数组指定秩（维度）中元素数量的条件</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过返回当前数组本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="rank" /> 小于1；或者 <paramref name="length" /> 小于0。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">如果当前数组指定秩（维数）<paramref name="rank" /> 的元素数量不等于 <paramref name="length" />，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static T[] EnsureArrayRankLength<T>(T[] array, int rank, int length, Func<Exception> exceptionCreator)
	{
		EnsureNotNull(array, "array");
		EnsureBetween(rank, 1, array.Rank, "rank");
		EnsureGreaterThanOrEqualTo(length, 0, "length");
		Ensure(array.GetLength(rank - 1) == length, exceptionCreator);
		return array;
	}

	/// <summary>
	/// 检测当前数组的指定秩（维度） <paramref name="rank" /> 的元素数量，如果不等于 <paramref name="length" /> 则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="rank">数组检查元素数量的秩（维度），从1开始</param>
	/// <param name="length">数组指定秩（维度）中元素数量的条件</param>
	/// <param name="exceptionType">抛出的异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检测通过返回当前数组本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="rank" /> 小于1；或者 <paramref name="length" /> 小于0。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">如果当前数组指定秩（维数）<paramref name="rank" /> 的元素数量不等于 <paramref name="length" />，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static T[] EnsureArrayRankLength<T>(T[] array, int rank, int length, Type exceptionType, params object[] args)
	{
		EnsureNotNull(array, "array");
		EnsureBetween(rank, 1, array.Rank, "rank");
		EnsureGreaterThanOrEqualTo(length, 0, "length");
		Ensure(array.GetLength(rank - 1) == length, exceptionType, args);
		return array;
	}

	/// <summary>
	/// 检测当前数组的指定秩（维度） <paramref name="rank" /> 的元素数量，如果不等于 <paramref name="length" /> 则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="rank">数组检查元素数量的秩（维度），从1开始</param>
	/// <param name="length">数组指定秩（维度）中元素数量的条件</param>
	/// <param name="name">数组的名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过返回当前数组本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="rank" /> 小于1；或者 <paramref name="length" /> 小于0。</exception>
	/// <exception cref="T:System.ArgumentException">如果当前数组指定秩（维数）<paramref name="rank" /> 的元素数量不等于 <paramref name="length" />，则抛出该异常。</exception>
	public static T[] EnsureArrayRankLength<T>(T[] array, int rank, long length, string name = null, string message = null)
	{
		EnsureNotNull(array, "array");
		EnsureBetween(rank, 1, array.Rank, "rank");
		EnsureGreaterThanOrEqualTo(length, 0L, "length");
		Ensure(array.GetLongLength(rank - 1) == length, () => new ArgumentException(string.Format(message ?? Literals.MSG_ArrayRankLengthError_1, rank), name ?? "array"));
		return array;
	}

	/// <summary>
	/// 检测当前数组的指定秩（维度） <paramref name="rank" /> 的元素数量，如果不等于 <paramref name="length" /> 则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="rank">数组检查元素数量的秩（维度），从1开始</param>
	/// <param name="length">数组指定秩（维度）中元素数量的条件</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过返回当前数组本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="rank" /> 小于1；或者 <paramref name="length" /> 小于0。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">如果当前数组指定秩（维数）<paramref name="rank" /> 的元素数量不等于 <paramref name="length" />，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static T[] EnsureArrayRankLength<T>(T[] array, int rank, long length, Func<Exception> exceptionCreator)
	{
		EnsureNotNull(array, "array");
		EnsureBetween(rank, 1, array.Rank, "rank");
		EnsureGreaterThanOrEqualTo(length, 0L, "length");
		Ensure(array.GetLongLength(rank - 1) == length, exceptionCreator);
		return array;
	}

	/// <summary>
	/// 检测当前数组的指定秩（维度） <paramref name="rank" /> 的元素数量，如果不等于 <paramref name="length" /> 则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="rank">数组检查元素数量的秩（维度），从1开始</param>
	/// <param name="length">数组指定秩（维度）中元素数量的条件</param>
	/// <param name="exceptionType">抛出的异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检测通过返回当前数组本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="rank" /> 小于1；或者 <paramref name="length" /> 小于0。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">如果当前数组指定秩（维数）<paramref name="rank" /> 的元素数量不等于 <paramref name="length" />，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static T[] EnsureArrayRankLength<T>(T[] array, int rank, long length, Type exceptionType, params object[] args)
	{
		EnsureNotNull(array, "array");
		EnsureBetween(rank, 1, array.Rank, "rank");
		EnsureGreaterThanOrEqualTo(length, 0L, "length");
		Ensure(array.GetLongLength(rank - 1) == length, exceptionType, args);
		return array;
	}

	/// <summary>
	/// 检测当前数组是否与目标数组具有相同的结构（维度相同，各维度元素数量相同），如果不相同则抛出 <see cref="T:System.ArgumentException" /> 异常。
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="target">比较的目标数组</param>
	/// <param name="name">数组名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过则返回原数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="target" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">如果当前数组与目标数组不相同则抛出该异常。</exception>
	public static Array EnsureArraySameStructure(Array array, Array target, string name = null, string message = null)
	{
		EnsureNotNull(array, "array");
		EnsureNotNull(target, "target");
		Ensure(ArrayHelper.IsSameStructure(array, target), () => new ArgumentException(message ?? Literals.MSG_ArrayDifferent, name ?? "array"));
		return array;
	}

	/// <summary>
	/// 检测当前数组是否与目标数组具有相同的结构（维度相同，各维度元素数量相同），如果不相同则抛出 <paramref name="exceptionCreator" /> 生成的异常。
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="target">比较的目标数组</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过则返回原数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="target" /> 为空；或者 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">如果当前数组与目标数组不相同，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static Array EnsureArraySameStructure(Array array, Array target, Func<Exception> exceptionCreator)
	{
		EnsureNotNull(array, "array");
		EnsureNotNull(target, "target");
		Ensure(ArrayHelper.IsSameStructure(array, target), exceptionCreator);
		return array;
	}

	/// <summary>
	/// 检测当前数组是否与目标数组具有相同的结构（维度相同，各维度元素数量相同），如果不相同则抛出 <paramref name="exceptionType" /> 指定的异常。
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="target">比较的目标数组</param>
	/// <param name="exceptionType">指定的异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检测通过则返回原数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="target" /> 为空；或者 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">如果当前数组与目标数组不相同，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static Array EnsureArraySameStructure(Array array, Array target, Type exceptionType, params object[] args)
	{
		EnsureNotNull(array, "array");
		EnsureNotNull(target, "target");
		Ensure(ArrayHelper.IsSameStructure(array, target), exceptionType, args);
		return array;
	}

	/// <summary>
	/// 检测当前数组是否与目标数组具有相同的结构（维度相同，各维度元素数量相同），如果不相同则抛出 <see cref="T:System.ArgumentException" /> 异常。
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <typeparam name="K">比较的数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="target">比较的目标数组</param>
	/// <param name="name">数组名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过则返回原数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="target" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">如果当前数组与目标数组不相同则抛出该异常。</exception>
	public static T[] EnsureArraySameStructure<T, K>(T[] array, K[] target, string name = null, string message = null)
	{
		EnsureNotNull(array, "array");
		EnsureNotNull(target, "target");
		Ensure(ArrayHelper.EnsureArraySameStructure(array, target), () => new ArgumentException(message ?? Literals.MSG_ArrayDifferent, name ?? "array"));
		return array;
	}

	/// <summary>
	/// 检测当前数组是否与目标数组具有相同的结构（维度相同，各维度元素数量相同），如果不相同则抛出 <paramref name="exceptionCreator" /> 生成的异常。
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <typeparam name="K">比较的数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="target">比较的目标数组</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过则返回原数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="target" /> 为空；或者 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">如果当前数组与目标数组不相同，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static T[] EnsureArraySameStructure<T, K>(T[] array, K[] target, Func<Exception> exceptionCreator)
	{
		EnsureNotNull(array, "array");
		EnsureNotNull(target, "target");
		Ensure(ArrayHelper.EnsureArraySameStructure(array, target), exceptionCreator);
		return array;
	}

	/// <summary>
	/// 检测当前数组是否与目标数组具有相同的结构（维度相同，各维度元素数量相同），如果不相同则抛出 <paramref name="exceptionType" /> 指定的异常。
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <typeparam name="K">比较的数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="target">比较的目标数组</param>
	/// <param name="exceptionType">指定的异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检测通过则返回原数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="target" /> 为空；或者 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">如果当前数组与目标数组不相同，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static T[] EnsureArraySameStructure<T, K>(T[] array, K[] target, Type exceptionType, params object[] args)
	{
		EnsureNotNull(array, "array");
		EnsureNotNull(target, "target");
		Ensure(ArrayHelper.EnsureArraySameStructure(array, target), exceptionType, args);
		return array;
	}

	/// <summary>
	/// 检测当前对象是否在指定范围内，超出指定的值范围则抛出 <see cref="T:System.ArgumentOutOfRangeException" /> 异常
	/// </summary>
	/// <param name="value">当前对象</param>
	/// <param name="min">最小值</param>
	/// <param name="max">最大值</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">错误消息</param>
	/// <param name="includeMin">值范围是否包含最小值，默认包含最小值</param>
	/// <param name="includeMax">值范围是否包含最大值，默认包含最大值</param>
	/// <returns>如果检测通过则返回当前对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空。</exception>
	public static object EnsureBetween(IComparable value, object min, object max, string name = null, string message = null, bool includeMin = true, bool includeMax = true)
	{
		Ensure(ObjectHelper.Between(value, min, max, includeMin, includeMax), () => new ArgumentOutOfRangeException(name ?? "value", message ?? Literals.MSG_ValueOutOfRange));
		return value;
	}

	/// <summary>
	/// 检测当前对象是否在指定范围内，超出指定的值范围则抛出参数 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <param name="value">当前对象</param>
	/// <param name="min">最小值</param>
	/// <param name="max">最大值</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <param name="includeMin">值范围是否包含最小值，默认包含最小值</param>
	/// <param name="includeMax">值范围是否包含最大值，默认包含最大值</param>
	/// <returns>如果检测通过则返回当前对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常生成方法 <paramref name="exceptionCreator" /> 执行异常或者返回空。</exception>
	/// <exception cref="T:System.Exception">当前对象超出指定的范围，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static object EnsureBetween(IComparable value, object min, object max, Func<Exception> exceptionCreator, bool includeMin = true, bool includeMax = true)
	{
		Ensure(ObjectHelper.Between(value, min, max, includeMin, includeMax), exceptionCreator);
		return value;
	}

	/// <summary>
	/// 检测当前对象是否在指定范围内，超出指定的值范围则抛出参数 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <param name="value">当前对象</param>
	/// <param name="min">最小值</param>
	/// <param name="max">最大值</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <param name="includeMin">值范围是否包含最小值，默认包含最小值</param>
	/// <param name="includeMax">值范围是否包含最大值，默认包含最大值</param>
	/// <returns>如果检测通过则返回当前对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">异常类型 <paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常类型 <paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象超出指定的范围，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static object EnsureBetween(IComparable value, object min, object max, Type exceptionType, object[] args = null, bool includeMin = true, bool includeMax = true)
	{
		Ensure(ObjectHelper.Between(value, min, max, includeMin, includeMax), exceptionType, args);
		return value;
	}

	/// <summary>
	/// 检测当前对象是否在指定范围内，超出指定的值范围则抛出 <see cref="T:System.ArgumentOutOfRangeException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="value">当前对象</param>
	/// <param name="min">最小值</param>
	/// <param name="max">最大值</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">错误消息</param>
	/// <param name="includeMin">值范围是否包含最小值，默认包含最小值</param>
	/// <param name="includeMax">值范围是否包含最大值，默认包含最大值</param>
	/// <returns>如果检测通过则返回当前对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">当前对象超出指定的范围；或者值范围最小值 <paramref name="min" /> 大于最大值 <paramref name="max" /></exception>
	public static T EnsureBetween<T>(IComparable<T> value, T min, T max, string name = null, string message = null, bool includeMin = true, bool includeMax = true) where T : IComparable<T>
	{
		Ensure(ObjectHelper.Between(value, min, max, includeMin, includeMax), () => new ArgumentOutOfRangeException(name ?? "value", message ?? Literals.MSG_ValueOutOfRange));
		return ObjectHelper.As<T>(value);
	}

	/// <summary>
	/// 检测当前对象是否在指定范围内，超出指定的值范围则抛出参数 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="value">当前对象</param>
	/// <param name="min">最小值</param>
	/// <param name="max">最大值</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <param name="includeMin">值范围是否包含最小值，默认包含最小值</param>
	/// <param name="includeMax">值范围是否包含最大值，默认包含最大值</param>
	/// <returns>如果检测通过则返回当前对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">值范围最小值 <paramref name="min" /> 大于最大值 <paramref name="max" /></exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常生成方法 <paramref name="exceptionCreator" /> 执行异常或者返回空。</exception>
	/// <exception cref="T:System.Exception">当前对象超出指定的范围，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static T EnsureBetween<T>(IComparable<T> value, T min, T max, Func<Exception> exceptionCreator, bool includeMin = true, bool includeMax = true) where T : IComparable<T>
	{
		Ensure(ObjectHelper.Between(value, min, max, includeMin, includeMax), exceptionCreator);
		return ObjectHelper.As<T>(value);
	}

	/// <summary>
	/// 检测当前对象是否在指定范围内，超出指定的值范围则抛出参数 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="value">当前对象</param>
	/// <param name="min">最小值</param>
	/// <param name="max">最大值</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <param name="includeMin">值范围是否包含最小值，默认包含最小值</param>
	/// <param name="includeMax">值范围是否包含最大值，默认包含最大值</param>
	/// <returns>如果检测通过则返回当前对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">值范围最小值 <paramref name="min" /> 大于最大值 <paramref name="max" /></exception>
	/// <exception cref="T:System.NotSupportedException">异常类型 <paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常类型 <paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象超出指定的范围，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static T EnsureBetween<T>(IComparable<T> value, T min, T max, Type exceptionType, object[] args = null, bool includeMin = true, bool includeMax = true) where T : IComparable<T>
	{
		Ensure(ObjectHelper.Between(value, min, max, includeMin, includeMax), exceptionType, args);
		return ObjectHelper.As<T>(value);
	}

	/// <summary>
	/// 检测当前对象是否不在指定范围内，在指定的值范围则抛出 <see cref="T:System.ArgumentOutOfRangeException" /> 异常
	/// </summary>
	/// <param name="value">当前对象</param>
	/// <param name="min">最小值</param>
	/// <param name="max">最大值</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">错误消息</param>
	/// <param name="includeMin">值范围是否包含最小值，默认包含最小值</param>
	/// <param name="includeMax">值范围是否包含最大值，默认包含最大值</param>
	/// <returns>如果检测通过则返回当前对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空。</exception>
	public static object EnsureNotBetween(IComparable value, object min, object max, string name = null, string message = null, bool includeMin = true, bool includeMax = true)
	{
		Ensure(ObjectHelper.NotBetween(value, min, max, includeMin, includeMax), () => new ArgumentOutOfRangeException(name ?? "value", message ?? Literals.MSG_ValueInRange));
		return value;
	}

	/// <summary>
	/// 检测当前对象是否不在指定范围内，在指定的值范围则抛出参数 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <param name="value">当前对象</param>
	/// <param name="min">最小值</param>
	/// <param name="max">最大值</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <param name="includeMin">值范围是否包含最小值，默认包含最小值</param>
	/// <param name="includeMax">值范围是否包含最大值，默认包含最大值</param>
	/// <returns>如果检测通过则返回当前对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常生成方法 <paramref name="exceptionCreator" /> 执行异常或者返回空。</exception>
	/// <exception cref="T:System.Exception">当前对象在指定的范围中，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static object EnsureNotBetween(IComparable value, object min, object max, Func<Exception> exceptionCreator, bool includeMin = true, bool includeMax = true)
	{
		Ensure(ObjectHelper.NotBetween(value, min, max, includeMin, includeMax), exceptionCreator);
		return value;
	}

	/// <summary>
	/// 检测当前对象是否不在指定范围内，在指定的值范围则抛出参数 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <param name="value">当前对象</param>
	/// <param name="min">最小值</param>
	/// <param name="max">最大值</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <param name="includeMin">值范围是否包含最小值，默认包含最小值</param>
	/// <param name="includeMax">值范围是否包含最大值，默认包含最大值</param>
	/// <returns>如果检测通过则返回当前对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">异常类型 <paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常类型 <paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象在指定的范围中，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static object EnsureNotBetween(IComparable value, object min, object max, Type exceptionType, object[] args = null, bool includeMin = true, bool includeMax = true)
	{
		Ensure(ObjectHelper.NotBetween(value, min, max, includeMin, includeMax), exceptionType, args);
		return value;
	}

	/// <summary>
	/// 检测当前对象是否不在指定范围内，在指定的值范围则抛出 <see cref="T:System.ArgumentOutOfRangeException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="value">当前对象</param>
	/// <param name="min">最小值</param>
	/// <param name="max">最大值</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">错误消息</param>
	/// <param name="includeMin">值范围是否包含最小值，默认包含最小值</param>
	/// <param name="includeMax">值范围是否包含最大值，默认包含最大值</param>
	/// <returns>如果检测通过则返回当前对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">当前对象在指定的范围中；或者值范围最小值 <paramref name="min" /> 大于最大值 <paramref name="max" /></exception>
	public static T EnsureNotBetween<T>(IComparable<T> value, T min, T max, string name = null, string message = null, bool includeMin = true, bool includeMax = true) where T : IComparable<T>
	{
		Ensure(ObjectHelper.NotBetween(value, min, max, includeMin, includeMax), () => new ArgumentOutOfRangeException(name ?? "value", message ?? Literals.MSG_ValueInRange));
		return ObjectHelper.As<T>(value);
	}

	/// <summary>
	/// 检测当前对象是否不在指定范围内，在指定的值范围则抛出参数 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="value">当前对象</param>
	/// <param name="min">最小值</param>
	/// <param name="max">最大值</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <param name="includeMin">值范围是否包含最小值，默认包含最小值</param>
	/// <param name="includeMax">值范围是否包含最大值，默认包含最大值</param>
	/// <returns>如果检测通过则返回当前对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">值范围最小值 <paramref name="min" /> 大于最大值 <paramref name="max" /></exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常生成方法 <paramref name="exceptionCreator" /> 执行异常或者返回空。</exception>
	/// <exception cref="T:System.Exception">当前对象在指定的范围中，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static T EnsureNotBetween<T>(IComparable<T> value, T min, T max, Func<Exception> exceptionCreator, bool includeMin = true, bool includeMax = true) where T : IComparable<T>
	{
		Ensure(ObjectHelper.NotBetween(value, min, max, includeMin, includeMax), exceptionCreator);
		return ObjectHelper.As<T>(value);
	}

	/// <summary>
	/// 检测当前对象是否不在指定范围内，在指定的值范围则抛出参数 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="value">当前对象</param>
	/// <param name="min">最小值</param>
	/// <param name="max">最大值</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <param name="includeMin">值范围是否包含最小值，默认包含最小值</param>
	/// <param name="includeMax">值范围是否包含最大值，默认包含最大值</param>
	/// <returns>如果检测通过则返回当前对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">值范围最小值 <paramref name="min" /> 大于最大值 <paramref name="max" /></exception>
	/// <exception cref="T:System.NotSupportedException">异常类型 <paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常类型 <paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象在指定的范围中，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static T EnsureNotBetween<T>(IComparable<T> value, T min, T max, Type exceptionType, object[] args = null, bool includeMin = true, bool includeMax = true) where T : IComparable<T>
	{
		Ensure(ObjectHelper.NotBetween(value, min, max, includeMin, includeMax), exceptionType, args);
		return ObjectHelper.As<T>(value);
	}

	/// <summary>
	/// 检测当前对象是否等于其类型的默认值，如果对象不等于其类型的默认值则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <param name="value">当前对象</param>
	/// <param name="type">当前对象类型</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果当前对象等于其类型的默认值，则返回该对象</returns>
	/// <exception cref="T:System.ArgumentException">当前对象不等于其类型的默认值。</exception>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空时，当前对象类型 <paramref name="type" /> 为空。</exception>
	public static object EnsureDefault(object value, Type type, string name = null, string message = null)
	{
		Ensure(ObjectHelper.IsDefault(value, type), name ?? "value", message ?? Literals.MSG_ValueNotDefault);
		return value;
	}

	/// <summary>
	/// 检测当前对象是否等于其类型的默认值，如果对象不等于其类型的默认值则抛出参数 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <param name="value">当前对象</param>
	/// <param name="type">当前对象类型</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果当前对象等于其类型的默认值，则返回该对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空时，当前对象类型 <paramref name="type" /> 为空；或者异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前对象不等于其类型的默认值，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static object EnsureDefault(object value, Type type, Func<Exception> exceptionCreator)
	{
		Ensure(ObjectHelper.IsDefault(value, type), exceptionCreator);
		return value;
	}

	/// <summary>
	/// 检测当前对象是否等于其类型的默认值，如果对象不等于其类型的默认值则抛出参数 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <param name="value">当前对象</param>
	/// <param name="type">当前对象类型</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果当前对象等于其类型的默认值，则返回该对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空时，当前对象类型 <paramref name="type" /> 为空；或者异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象不等于其类型的默认值，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static object EnsureDefault(object value, Type type, Type exceptionType, params object[] args)
	{
		Ensure(ObjectHelper.IsDefault(value, type), exceptionType, args);
		return value;
	}

	/// <summary>
	/// 检测当前对象是否等于其类型的默认值，如果对象不等于其类型的默认值则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="value">当前对象</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果当前对象等于其类型的默认值，则返回该对象</returns>
	/// <exception cref="T:System.ArgumentException">当前对象不等于其类型的默认值。</exception>
	public static T EnsureDefault<T>(T value, string name = null, string message = null)
	{
		Ensure(ObjectHelper.IsDefault(value), name ?? "value", message ?? Literals.MSG_ValueNotDefault);
		return value;
	}

	/// <summary>
	/// 检测当前对象是否等于其类型的默认值，如果对象不等于其类型的默认值则抛出参数 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="value">当前对象</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果当前对象等于其类型的默认值，则返回该对象</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前对象不等于其类型的默认值，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static T EnsureDefault<T>(T value, Func<Exception> exceptionCreator)
	{
		Ensure(ObjectHelper.IsDefault(value), exceptionCreator);
		return value;
	}

	/// <summary>
	/// 检测当前对象是否等于其类型的默认值，如果对象不等于其类型的默认值则抛出参数 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="value">当前对象</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果当前对象等于其类型的默认值，则返回该对象</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象不等于其类型的默认值，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static T EnsureDefault<T>(T value, Type exceptionType, params object[] args)
	{
		Ensure(ObjectHelper.IsDefault(value), exceptionType, args);
		return value;
	}

	/// <summary>
	/// 检测当前对象是否不等于其类型的默认值，如果对象等于其类型的默认值则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <param name="value">当前对象</param>
	/// <param name="type">当前对象类型</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果当前对象不等于其类型的默认值，则返回该对象</returns>
	/// <exception cref="T:System.ArgumentException">当前对象等于其类型的默认值。</exception>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空时，对象类型也为空。</exception>
	public static object EnsureNotDefault(object value, Type type, string name = null, string message = null)
	{
		Ensure(ObjectHelper.IsNotDefault(value, type), name ?? "value", message ?? Literals.MSG_ValueDefault);
		return value;
	}

	/// <summary>
	/// 检测当前对象是否不等于其类型的默认值，如果对象等于其类型的默认值则抛出参数 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <param name="value">当前对象</param>
	/// <param name="type">当前对象类型</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果当前对象不等于其类型的默认值，则返回该对象</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前对象等于其类型的默认值，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static object EnsureNotDefault(object value, Type type, Func<Exception> exceptionCreator)
	{
		Ensure(ObjectHelper.IsNotDefault(value, type), exceptionCreator);
		return value;
	}

	/// <summary>
	/// 检测当前对象是否不等于其类型的默认值，如果对象等于其类型的默认值则抛出参数 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <param name="value">当前对象</param>
	/// <param name="type">当前对象类型</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果当前对象不等于其类型的默认值，则返回该对象</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象等于其类型的默认值，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static object EnsureNotDefault(object value, Type type, Type exceptionType, params object[] args)
	{
		Ensure(ObjectHelper.IsNotDefault(value, type), exceptionType, args);
		return value;
	}

	/// <summary>
	/// 检测当前对象是否不等于其类型的默认值，如果对象等于其类型的默认值则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="value">当前对象</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果当前对象不等于其类型的默认值，则返回该对象</returns>
	/// <exception cref="T:System.ArgumentException">当前对象等于其类型的默认值。</exception>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空时，对象类型也为空。</exception>
	public static T EnsureNotDefault<T>(T value, string name = null, string message = null)
	{
		Ensure(ObjectHelper.IsNotDefault(value), name ?? "value", message ?? Literals.MSG_ValueNotDefault);
		return value;
	}

	/// <summary>
	/// 检测当前对象是否不等于其类型的默认值，如果对象等于其类型的默认值则抛出参数 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="value">当前对象</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果当前对象不等于其类型的默认值，则返回该对象</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前对象等于其类型的默认值，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static T EnsureNotDefault<T>(T value, Func<Exception> exceptionCreator)
	{
		Ensure(ObjectHelper.IsNotDefault(value), exceptionCreator);
		return value;
	}

	/// <summary>
	/// 检测当前对象是否不等于其类型的默认值，如果对象等于其类型的默认值则抛出参数 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="value">当前对象</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果当前对象不等于其类型的默认值，则返回该对象</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象等于其类型的默认值，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static T EnsureNotDefault<T>(T value, Type exceptionType, params object[] args)
	{
		Ensure(ObjectHelper.IsNotDefault(value), exceptionType, args);
		return value;
	}

	/// <summary>
	/// 检测当前目录是否存在，如果不存在则抛出 <see cref="T:System.IO.DirectoryNotFoundException" /> 异常。
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="message">错误消息</param>
	/// <returns>如果当前目录存在则返回当前目录</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录不存在。</exception>
	public static DirectoryInfo EnsureDirectoryExistence(DirectoryInfo directory, string message = null)
	{
		EnsureNotNull(directory, "directory");
		directory.Refresh();
		Ensure(directory.Exists, () => new DirectoryNotFoundException(message ?? string.Format(Literals.MSG_DirectoryNotFound_1, directory.FullName)));
		return directory;
	}

	/// <summary>
	/// 检测当前目录是否存在，如果当前目录不存在则抛出 <paramref name="exceptionCreator" /> 生成的异常。
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果当前目录存在则返回当前目录</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">如果当前目录不存在则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static DirectoryInfo EnsureDirectoryExistence(DirectoryInfo directory, Func<Exception> exceptionCreator)
	{
		EnsureNotNull(directory, "directory");
		directory.Refresh();
		Ensure(directory.Exists, exceptionCreator);
		return directory;
	}

	/// <summary>
	/// 检测当前目录是否存在，如果当前目录不存在则抛出 <paramref name="exceptionType" /> 指定的异常。
	/// </summary>
	/// <param name="directory">当前目录</param>
	/// <param name="exceptionType">抛出的异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果当前目录存在则返回当前目录</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">如果当前目录不存在则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static DirectoryInfo EnsureDirectoryExistence(DirectoryInfo directory, Type exceptionType, params object[] args)
	{
		EnsureNotNull(directory, "directory");
		directory.Refresh();
		Ensure(directory.Exists, exceptionType, args);
		return directory;
	}

	/// <summary>
	/// 检测当前目录是否存在，如果不存在则抛出 <see cref="T:System.IO.DirectoryNotFoundException" /> 异常。
	/// </summary>
	/// <param name="directory">当前目录路径</param>
	/// <param name="message">错误消息</param>
	/// <returns>如果当前目录路径指定的目录存在则返回该路径</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录路径为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录路径指定的目录不存在。</exception>
	public static string EnsureDirectoryExistence(string directory, string message = null)
	{
		EnsureNotNull(directory, "directory");
		Ensure(Directory.Exists(directory), () => new DirectoryNotFoundException(message ?? string.Format(Literals.MSG_DirectoryNotFound_1, directory)));
		return directory;
	}

	/// <summary>
	/// 检测当前目录是否存在，如果不存在则抛出 <paramref name="exceptionCreator" /> 生成的异常。
	/// </summary>
	/// <param name="directory">当前目录路径</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果当前目录路径指定的目录存在则返回该路径</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">如果当前目录路径指定的目录不存在则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static string EnsureDirectoryExistence(string directory, Func<Exception> exceptionCreator)
	{
		EnsureNotNull(directory, "directory");
		Ensure(Directory.Exists(directory), exceptionCreator);
		return directory;
	}

	/// <summary>
	/// 检测当前目录是否存在，如果不存在则抛出 <paramref name="exceptionType" /> 指定的异常。
	/// </summary>
	/// <param name="directory">当前目录路径</param>
	/// <param name="exceptionType">抛出的异常类型</param>
	/// <param name="args">创建异常时的参数</param>
	/// <returns>如果当前目录路径指定的目录存在则返回该路径</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">如果当前目录路径指定的目录不存在则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static string EnsureDirectoryExistence(string directory, Type exceptionType, params object[] args)
	{
		EnsureNotNull(directory, "directory");
		Ensure(Directory.Exists(directory), exceptionType, args);
		return directory;
	}

	/// <summary>
	/// 检测当前对象是否等于指定值，如果不等于指定值则抛出 <see cref="T:System.ArgumentOutOfRangeException" /> 异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果当前对象等于指定值则返回当前对象。</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException">当前对象不等于 <paramref name="value" /> 时。</exception>
	public static object EnsureEqualTo(object item, object value, string name = null, string message = null)
	{
		Ensure(object.ReferenceEquals(item, value) || ObjectHelper.IsEqualTo(item, value), () => new ArgumentOutOfRangeException(name ?? "item", message ?? string.Format(Literals.MSG_ValueNotEqualToTarget_1, value)));
		return item;
	}

	/// <summary>
	/// 检测当前对象是否等于指定值，如果不等于指定值则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果当前对象等于指定值则返回当前对象。</returns>
	/// <exception cref="T:System.ArgumentNullException">异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常生成方法 <paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前对象的值不等于 <paramref name="value" /> 的值，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static object EnsureEqualTo(object item, object value, Func<Exception> exceptionCreator)
	{
		Ensure(object.ReferenceEquals(item, value) || ObjectHelper.IsEqualTo(item, value), exceptionCreator);
		return item;
	}

	/// <summary>
	/// 检测当前对象是否等于指定值，如果不等于指定值则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果当前对象等于指定值则返回当前对象。</returns>
	/// <exception cref="T:System.ArgumentNullException">异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">异常类型 <paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常类型 <paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象的值不等于 <paramref name="value" /> 的值，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static object EnsureEqualTo(object item, object value, Type exceptionType, params object[] args)
	{
		Ensure(object.ReferenceEquals(item, value) || ObjectHelper.IsEqualTo(item, value), exceptionType, args);
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
	/// <returns>如果当前对象等于指定值则返回当前对象。</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException">当前对象不等于 <paramref name="value" /> 时。</exception>
	public static T EnsureEqualTo<T>(T item, T value, string name = null, string message = null, Func<T, T, bool> equalition = null)
	{
		Ensure(object.ReferenceEquals(item, value) || ObjectHelper.IsEqualTo(item, value, equalition), () => new ArgumentOutOfRangeException(name ?? "item", message ?? string.Format(Literals.MSG_ValueNotEqualToTarget_1, value)));
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
	/// <returns>如果当前对象等于指定值则返回当前对象。</returns>
	/// <exception cref="T:System.ArgumentNullException">异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常生成方法 <paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前对象的值不等于 <paramref name="value" /> 的值，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static T EnsureEqualTo<T>(T item, T value, Func<Exception> exceptionCreator = null, Func<T, T, bool> equalition = null)
	{
		Ensure(object.ReferenceEquals(item, value) || ObjectHelper.IsEqualTo(item, value, equalition), exceptionCreator);
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
	/// <returns>如果当前对象等于指定值则返回当前对象。</returns>
	/// <exception cref="T:System.ArgumentNullException">异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">异常类型 <paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常类型 <paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象的值不等于 <paramref name="value" /> 的值，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static T EnsureEqualTo<T>(T item, T value, Type exceptionType, object[] args = null, Func<T, T, bool> equalition = null)
	{
		Ensure(object.ReferenceEquals(item, value) || ObjectHelper.IsEqualTo(item, value, equalition), exceptionType, args);
		return item;
	}

	/// <summary>
	/// 检测当前对象是否不等于指定值，如果等于指定值则抛出 <see cref="T:System.ArgumentOutOfRangeException" /> 异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果当前对象不等于指定值则返回当前对象。</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException">当前对象等于 <paramref name="value" /> 时。</exception>
	public static object EnsureNotEqualTo(object item, object value, string name = null, string message = null)
	{
		Ensure(ObjectHelper.IsNotEqualTo(item, value), () => new ArgumentOutOfRangeException(name ?? "item", message ?? string.Format(Literals.MSG_ValueEqualToTarget_1, value)));
		return item;
	}

	/// <summary>
	/// 检测当前对象是否不等于指定值，如果等于指定值则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果当前对象不等于指定值则返回当前对象。</returns>
	/// <exception cref="T:System.ArgumentNullException">异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常生成方法 <paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前对象的值等于 <paramref name="value" /> 的值，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static object EnsureNotEqualTo(object item, object value, Func<Exception> exceptionCreator)
	{
		Ensure(ObjectHelper.IsNotEqualTo(item, value), exceptionCreator);
		return item;
	}

	/// <summary>
	/// 检测当前对象是否不等于指定值，如果等于指定值则抛出  <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果当前对象不等于指定值则返回当前对象。</returns>
	/// <exception cref="T:System.ArgumentNullException">异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">异常类型 <paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常类型 <paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象的值等于 <paramref name="value" /> 的值，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static object EnsureNotEqualTo(object item, object value, Type exceptionType, params object[] args)
	{
		Ensure(ObjectHelper.IsNotEqualTo(item, value), exceptionType, args);
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
	/// <returns>如果当前对象不等于指定值则返回当前对象。</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException">当前对象等于 <paramref name="value" /> 时。</exception>
	public static T EnsureNotEqualTo<T>(T item, T value, string name = null, string message = null, Func<T, T, bool> equalition = null)
	{
		Ensure(ObjectHelper.IsNotEqualTo(item, value, equalition), () => new ArgumentOutOfRangeException(name ?? "item", message ?? string.Format(Literals.MSG_ValueEqualToTarget_1, value)));
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
	/// <returns>如果当前对象不等于指定值则返回当前对象。</returns>
	/// <exception cref="T:System.ArgumentNullException">异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常生成方法 <paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前对象的值等于 <paramref name="value" /> 的值，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static T EnsureNotEqualTo<T>(T item, T value, Func<Exception> exceptionCreator = null, Func<T, T, bool> equalition = null)
	{
		Ensure(ObjectHelper.IsNotEqualTo(item, value, equalition), exceptionCreator);
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
	/// <exception cref="T:System.ArgumentNullException">异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">异常类型 <paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常类型 <paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象的值等于 <paramref name="value" /> 的值，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static T EnsureNotEqualTo<T>(T item, T value, Type exceptionType = null, object[] args = null, Func<T, T, bool> equalition = null)
	{
		Ensure(ObjectHelper.IsNotEqualTo(item, value, equalition), exceptionType, args);
		return item;
	}

	/// <summary>
	/// 检测指定的处理是否抛出任意异常，如果未抛出异常，则抛出 <see cref="T:System.InvalidOperationException" /> 异常
	/// </summary>
	/// <param name="action">对象处理方法</param>
	/// <param name="message">没有出现期望的异常时的消息</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">如果 <paramref name="action" /> 没有抛出异常，则抛出该异常。</exception>
	public static void EnsureExpectedException(Action action, string message = null)
	{
		EnsureExpectedException(action, typeof(Exception), message);
	}

	/// <summary>
	/// 检测指定的处理是否抛出任意异常，如果未抛出异常，则抛出参数 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <param name="action">对象处理方法</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="action" /> 为空；或者 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception"><paramref name="action" /> 没有抛出异常，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static void EnsureExpectedException(Action action, Func<Exception> exceptionCreator)
	{
		EnsureExpectedException(action, typeof(Exception), exceptionCreator);
	}

	/// <summary>
	/// 检测指定的处理是否抛出任意异常，如果未抛出异常，则抛出参数 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <param name="action">对象处理方法</param>
	/// <param name="exceptionType">抛出的指定的异常</param>
	/// <param name="args">异常参数</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="action" /> 为空；或者 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception"><paramref name="action" /> 没有抛出异常，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static void EnsureExpectedException(Action action, Type exceptionType, object[] args)
	{
		EnsureExpectedException(action, typeof(Exception), exceptionType, args);
	}

	/// <summary>
	/// 检测指定的处理是否抛出期望的异常，如果未抛出期望的异常，则抛出 <see cref="T:System.InvalidOperationException" /> 异常
	/// </summary>
	/// <param name="action">对象处理方法</param>
	/// <param name="expectedException">期望抛出的异常类型</param>
	/// <param name="message">没有出现期望的异常时的消息</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="action" /> 为空；或者 <paramref name="expectedException" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="expectedException" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.InvalidOperationException">如果 <paramref name="action" /> 没有抛出 <paramref name="expectedException" /> 指定的异常，则抛出该异常。</exception>
	/// <remarks>指定的处理 <paramref name="action" /> 应抛出异常，该异常应是 <paramref name="expectedException" /> 指定的类型或者是从 <paramref name="expectedException" /> 继承的类型；否则将抛出异常。</remarks>
	public static void EnsureExpectedException(Action action, Type expectedException, string message = null)
	{
		EnsureNotNull(action, "Action", Literals.MSG_ActionNull);
		EnsureNotNull(expectedException, "Expected Exception", Literals.MSG_ExpectedExceptionTypeNull);
		if (!typeof(Exception).IsAssignableFrom(expectedException))
		{
			throw new NotSupportedException(Literals.MSG_ExpectedExceptionError);
		}
		try
		{
			action();
		}
		catch (Exception ex)
		{
			if (expectedException.IsAssignableFrom(ex.GetType()))
			{
				return;
			}
		}
		throw new InvalidOperationException(message ?? Literals.MSG_ExpectedExceptionNotOccured);
	}

	/// <summary>
	/// 检测指定的处理是否抛出期望的异常，如果未抛出期望的异常，则抛出参数 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <param name="action">对象处理方法</param>
	/// <param name="expectedException">期望的异常类型</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="action" /> 为空；或者 <paramref name="expectedException" /> 为空；或者 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="expectedException" /> 不是继承于 <see cref="T:System.Exception" /></exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception"><paramref name="action" /> 没有抛出 <paramref name="expectedException" /> 指定的异常，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	/// <remarks>指定的处理 <paramref name="action" /> 应抛出异常，该异常应是 <paramref name="expectedException" /> 指定的类型或者是从 <paramref name="expectedException" /> 继承的类型；否则将抛出异常。</remarks>
	public static void EnsureExpectedException(Action action, Type expectedException, Func<Exception> exceptionCreator)
	{
		EnsureNotNull(action, "Action", Literals.MSG_ActionNull);
		EnsureNotNull(expectedException, "Expected Exception", Literals.MSG_ExpectedExceptionTypeNull);
		if (!typeof(Exception).IsAssignableFrom(expectedException))
		{
			throw new NotSupportedException(Literals.MSG_ExpectedExceptionError);
		}
		EnsureNotNull(exceptionCreator, "Exception Creator", Literals.MSG_ExceptionCreatorNull);
		try
		{
			action();
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
		if (ObjectHelper.IsNull(exception))
		{
			throw new TargetInvocationException(Literals.MSG_ExceptionCreatingFailed, null);
		}
		throw exception;
	}

	/// <summary>
	/// 检测指定的处理是否抛出期望的异常，如果未抛出期望的异常，则抛出参数 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <param name="action">对象处理方法</param>
	/// <param name="expectedException">期望的异常类型</param>
	/// <param name="exceptionType">抛出的指定的异常</param>
	/// <param name="args">异常参数</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="action" /> 为空；或者 <paramref name="expectedException" /> 为空；或者 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="expectedException" /> 不是继承于 <see cref="T:System.Exception" />；或者 <paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception"><paramref name="action" /> 未抛出符合参数 <paramref name="expectedException" /> 指定类型的异常，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	/// <remarks>指定的处理 <paramref name="action" /> 应抛出异常，该异常应是 <paramref name="expectedException" /> 指定的类型或者是从 <paramref name="expectedException" /> 继承的类型；否则将抛出异常。</remarks>
	public static void EnsureExpectedException(Action action, Type expectedException, Type exceptionType, params object[] args)
	{
		EnsureNotNull(action, "Action", Literals.MSG_ActionNull);
		EnsureNotNull(expectedException, "Expected Exception", Literals.MSG_ExpectedExceptionTypeNull);
		if (!typeof(Exception).IsAssignableFrom(expectedException))
		{
			throw new NotSupportedException(Literals.MSG_ExpectedExceptionError);
		}
		EnsureNotNull(exceptionType, "Exception Type", Literals.MSG_ExceptionTypeNull);
		if (!typeof(Exception).IsAssignableFrom(exceptionType))
		{
			throw new NotSupportedException(Literals.MSG_ExceptionTypeError);
		}
		try
		{
			action();
		}
		catch (Exception ex2)
		{
			if (expectedException.IsAssignableFrom(ex2.GetType()))
			{
				return;
			}
		}
		Exception exception;
		try
		{
			exception = (Exception)Activator.CreateInstance(exceptionType, args ?? new object[0]);
		}
		catch (Exception ex2)
		{
			throw new TargetInvocationException(Literals.MSG_ExceptionCreatingFailed, ex2);
		}
		throw exception;
	}

	/// <summary>
	/// 检测指定的处理是否抛出任意异常，如果未抛出异常，则抛出 <see cref="T:System.InvalidOperationException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="action">对象处理方法</param>
	/// <param name="message">没有出现期望的异常时的消息</param>
	/// <returns>如果满足条件则返回当前对象本身。</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">如果 <paramref name="action" /> 没有抛出异常，则抛出该异常。</exception>
	public static T EnsureExpectedException<T>(T item, Action<T> action, string message = null)
	{
		return EnsureExpectedException(item, action, typeof(Exception), message);
	}

	/// <summary>
	/// 检测指定的处理是否抛出任意异常，如果未抛出异常，则抛出参数 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="action">对象处理方法</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果满足条件则返回当前对象本身。</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="action" /> 为空；或者 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception"><paramref name="action" /> 没有抛出异常，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static T EnsureExpectedException<T>(T item, Action<T> action, Func<Exception> exceptionCreator)
	{
		return EnsureExpectedException(item, action, typeof(Exception), exceptionCreator);
	}

	/// <summary>
	/// 检测指定的处理是否抛出任意异常，如果未抛出异常，则抛出参数 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="action">对象处理方法</param>
	/// <param name="exceptionType">抛出的指定的异常</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果满足条件则返回当前对象本身。</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="action" /> 为空；或者 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception"><paramref name="action" /> 没有抛出异常，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static T EnsureExpectedException<T>(T item, Action<T> action, Type exceptionType, object[] args)
	{
		return EnsureExpectedException(item, action, typeof(Exception), exceptionType, args);
	}

	/// <summary>
	/// 检测指定的处理是否抛出期望的异常，如果未抛出期望的异常，则抛出 <see cref="T:System.InvalidOperationException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="action">对象处理方法</param>
	/// <param name="expectedException">期望抛出的异常类型</param>
	/// <param name="message">没有出现期望的异常时的消息</param>
	/// <returns>如果满足条件则返回当前对象本身。</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="action" /> 为空；或者 <paramref name="expectedException" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="expectedException" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.InvalidOperationException">如果 <paramref name="action" /> 没有抛出 <paramref name="expectedException" /> 指定的异常，则抛出该异常。</exception>
	/// <remarks>指定的处理 <paramref name="action" /> 应抛出异常，该异常应是 <paramref name="expectedException" /> 指定的类型或者是从 <paramref name="expectedException" /> 继承的类型；否则将抛出异常。</remarks>
	public static T EnsureExpectedException<T>(T item, Action<T> action, Type expectedException, string message = null)
	{
		EnsureNotNull(action, "Action", Literals.MSG_ActionNull);
		EnsureNotNull(expectedException, "Expected Exception", Literals.MSG_ExpectedExceptionTypeNull);
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
				return item;
			}
		}
		throw new InvalidOperationException(message ?? Literals.MSG_ExpectedExceptionNotOccured);
	}

	/// <summary>
	/// 检测指定的处理是否抛出期望的异常，如果未抛出期望的异常，则抛出参数 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="action">对象处理方法</param>
	/// <param name="expectedException">期望的异常类型</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果满足条件则返回当前对象本身。</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="action" /> 为空；或者 <paramref name="expectedException" /> 为空；或者 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="expectedException" /> 不是继承于 <see cref="T:System.Exception" /></exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception"><paramref name="action" /> 没有抛出 <paramref name="expectedException" /> 指定的异常，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	/// <remarks>指定的处理 <paramref name="action" /> 应抛出异常，该异常应是 <paramref name="expectedException" /> 指定的类型或者是从 <paramref name="expectedException" /> 继承的类型；否则将抛出异常。</remarks>
	public static T EnsureExpectedException<T>(T item, Action<T> action, Type expectedException, Func<Exception> exceptionCreator)
	{
		EnsureNotNull(action, "Action", Literals.MSG_ActionNull);
		EnsureNotNull(expectedException, "Expected Exception", Literals.MSG_ExpectedExceptionTypeNull);
		if (!typeof(Exception).IsAssignableFrom(expectedException))
		{
			throw new NotSupportedException(Literals.MSG_ExpectedExceptionError);
		}
		EnsureNotNull(exceptionCreator, "Exception Creator", Literals.MSG_ExceptionCreatorNull);
		try
		{
			action(item);
		}
		catch (Exception ex)
		{
			if (expectedException.IsAssignableFrom(ex.GetType()))
			{
				return item;
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
		if (ObjectHelper.IsNull(exception))
		{
			throw new TargetInvocationException(Literals.MSG_ExceptionCreatingFailed, null);
		}
		throw exception;
	}

	/// <summary>
	/// 检测指定的处理是否抛出期望的异常，如果未抛出期望的异常，则抛出参数 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="action">对象处理方法</param>
	/// <param name="expectedException">期望的异常类型</param>
	/// <param name="exceptionType">抛出的指定的异常</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果满足条件则返回当前对象本身。</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="action" /> 为空；或者 <paramref name="expectedException" /> 为空；或者 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="expectedException" /> 不是继承于 <see cref="T:System.Exception" />；或者 <paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception"><paramref name="action" /> 未抛出符合参数 <paramref name="expectedException" /> 指定类型的异常，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	/// <remarks>指定的处理 <paramref name="action" /> 应抛出异常，该异常应是 <paramref name="expectedException" /> 指定的类型或者是从 <paramref name="expectedException" /> 继承的类型；否则将抛出异常。</remarks>
	public static T EnsureExpectedException<T>(T item, Action<T> action, Type expectedException, Type exceptionType, params object[] args)
	{
		EnsureNotNull(action, "Action", Literals.MSG_ActionNull);
		EnsureNotNull(expectedException, "Expected Exception", Literals.MSG_ExpectedExceptionTypeNull);
		if (!typeof(Exception).IsAssignableFrom(expectedException))
		{
			throw new NotSupportedException(Literals.MSG_ExpectedExceptionError);
		}
		EnsureNotNull(exceptionType, "Exception Type", Literals.MSG_ExceptionTypeNull);
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
				return item;
			}
		}
		Exception exception;
		try
		{
			exception = (Exception)Activator.CreateInstance(exceptionType, args ?? new object[0]);
		}
		catch (Exception ex2)
		{
			throw new TargetInvocationException(Literals.MSG_ExceptionCreatingFailed, ex2);
		}
		throw exception;
	}

	/// <summary>
	/// 检测当前值是否等于false，如果不等于false，抛出 <see cref="T:System.ArgumentOutOfRangeException" /> 异常
	/// </summary>
	/// <param name="value">当前布尔值</param>
	/// <param name="name">参数名称</param>
	/// <param name="message">异常消息</param>
	/// <returns>如果检测通过返回false</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException">如果 <paramref name="value" /> 为true。</exception>
	public static bool EnsureFalse(bool value, string name = null, string message = null)
	{
		Ensure(!value, () => new ArgumentOutOfRangeException(name ?? "value", message ?? Literals.MSG_ValueTrue));
		return value;
	}

	/// <summary>
	/// 检测当前值是否等于false，如果不等于false，抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <param name="value">当前布尔值</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过返回false</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception"><paramref name="value" /> 不等于false，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static bool EnsureFalse(bool value, Func<Exception> exceptionCreator)
	{
		Ensure(!value, exceptionCreator);
		return value;
	}

	/// <summary>
	/// 检测当前值是否等于false，如果不等于false，否则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <param name="value">当前布尔值</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检测通过返回false</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception"><paramref name="value" /> 不等于false，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static bool EnsureFalse(bool value, Type exceptionType, params object[] args)
	{
		Ensure(!value, exceptionType, args);
		return value;
	}

	/// <summary>
	/// 如果当前函数委托的返回值不等于false，则抛出 <see cref="T:System.InvalidOperationException" /> 异常
	/// </summary>
	/// <param name="func">当前函数委托</param>
	/// <param name="name">参数名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前函数委托为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前函数委托返回true时。</exception>
	public static bool EnsureFalse(Func<bool> func, string name = null, string message = null)
	{
		EnsureNotNull(func, "Func");
		Ensure(!func(), () => new InvalidOperationException(message ?? Literals.MSG_ValueTrue));
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
	public static bool EnsureFalse(Func<bool> func, Func<Exception> exceptionCreator)
	{
		EnsureNotNull(func, "Func");
		Ensure(!func(), exceptionCreator);
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
	public static bool EnsureFalse(Func<bool> func, Type exceptionType, params object[] args)
	{
		EnsureNotNull(func, "Func");
		EnsureNotNull(exceptionType, "Exception Type");
		Ensure(!func(), exceptionType, args);
		return false;
	}

	/// <summary>
	/// 检测当前文件是否存在，如果不存在则抛出 <see cref="T:System.IO.FileNotFoundException" /> 异常。
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <param name="message">错误消息</param>
	/// <returns>如果当前文件存在则返回当前文件对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件不存在。</exception>
	public static FileInfo EnsureFileExistence(FileInfo file, string message = null)
	{
		EnsureNotNull(file, "file");
		Ensure(file.Exists, () => new FileNotFoundException(message ?? string.Format(Literals.MSG_FileNotFoundException_1, file.FullName), file.Name));
		return file;
	}

	/// <summary>
	/// 检测当前文件是否存在，如果不存在则抛出 <paramref name="exceptionCreator" /> 生成的异常。
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果当前文件存在则返回当前文件对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空；或者 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">如果当前文件不存在则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static FileInfo EnsureFileExistence(FileInfo file, Func<Exception> exceptionCreator)
	{
		EnsureNotNull(file, "file");
		Ensure(file.Exists, exceptionCreator);
		return file;
	}

	/// <summary>
	/// 检测当前文件是否存在，如果不存在则抛出 <paramref name="exceptionType" /> 指定的异常。
	/// </summary>
	/// <param name="file">当前文件</param>
	/// <param name="exceptionType">抛出的异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果当前文件存在则返回当前文件对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空；或者 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">如果当前文件不存在则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static FileInfo EnsureFileExistence(FileInfo file, Type exceptionType, params object[] args)
	{
		EnsureNotNull(file, "file");
		Ensure(file.Exists, exceptionType, args);
		return file;
	}

	/// <summary>
	/// 检测当前文件是否存在，如果文件不存在则抛出 <see cref="T:System.IO.FileNotFoundException" /> 异常。
	/// </summary>
	/// <param name="file">当前文件路径</param>
	/// <param name="message">错误消息</param>
	/// <returns>如果当前文件路径指定的文件存在则返回该路径</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件路径为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件路径指定的文件不存在。</exception>
	public static string EnsureFileExistence(string file, string message = null)
	{
		EnsureNotNull(file, "file");
		Ensure(File.Exists(file), () => new FileNotFoundException(message ?? string.Format(Literals.MSG_FileNotFoundException_1, file), Path.GetFileName(file)));
		return file;
	}

	/// <summary>
	/// 检测当前文件是否存在，如果文件不存在则抛出 <paramref name="exceptionCreator" /> 生成的异常。
	/// </summary>
	/// <param name="file">当前文件路径</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果当前文件路径指定的文件存在则返回该路径</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">如果当前文件路径指定的文件不存在则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static string EnsureFileExistence(string file, Func<Exception> exceptionCreator)
	{
		EnsureNotNull(file, "file");
		Ensure(File.Exists(file), exceptionCreator);
		return file;
	}

	/// <summary>
	/// 检测当前文件是否存在，如果文件不存在则抛出 <paramref name="exceptionType" /> 指定的异常。
	/// </summary>
	/// <param name="file">当前文件路径</param>
	/// <param name="exceptionType">抛出的异常类型</param>
	/// <param name="args">创建异常时的参数</param>
	/// <returns>如果当前文件路径指定的文件存在则返回该路径</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">如果当前文件路径指定的文件不存在则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static string EnsureFileExistence(string file, Type exceptionType, params object[] args)
	{
		EnsureNotNull(file, "file");
		Ensure(File.Exists(file), exceptionType, args);
		return file;
	}

	/// <summary>
	/// 检测当前对象是否大于指定值，如果不大于指定值则抛出 <see cref="T:System.ArgumentOutOfRangeException" /> 异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">当前对象的值小于等于 <paramref name="value" /> 的值。</exception>
	public static object EnsureGreaterThan(IComparable item, object value, string name = null, string message = null)
	{
		Ensure(ObjectHelper.IsGreaterThan(item, value), () => new ArgumentOutOfRangeException(name ?? "item", message ?? string.Format(Literals.MSG_ValueLessThanOrEqualToTarget_1, value)));
		return item;
	}

	/// <summary>
	/// 检测当前对象是否大于指定值，如果不大于指定值则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常生成方法 <paramref name="exceptionCreator" /> 执行异常或者返回空。</exception>
	/// <exception cref="T:System.Exception">当前对象的值小于等于 <paramref name="value" /> 的值，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static object EnsureGreaterThan(IComparable item, object value, Func<Exception> exceptionCreator)
	{
		Ensure(ObjectHelper.IsGreaterThan(item, value), exceptionCreator);
		return item;
	}

	/// <summary>
	/// 检测当前对象是否大于指定值，如果不大于指定值则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">异常类型 <paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常类型 <paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象的值小于等于 <paramref name="value" /> 的值，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static object EnsureGreaterThan(IComparable item, object value, Type exceptionType, params object[] args)
	{
		Ensure(ObjectHelper.IsGreaterThan(item, value), exceptionType, args);
		return item;
	}

	/// <summary>
	/// 检测当前对象是否大于指定值，如果不大于指定值则抛出 <see cref="T:System.ArgumentOutOfRangeException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">当前对象的值小于等于 <paramref name="value" /> 的值。</exception>
	public static T EnsureGreaterThan<T>(IComparable<T> item, T value, string name = null, string message = null) where T : IComparable<T>
	{
		Ensure(ObjectHelper.IsGreaterThan(item, value), () => new ArgumentOutOfRangeException(name ?? "item", message ?? string.Format(Literals.MSG_ValueLessThanOrEqualToTarget_1, value)));
		return ObjectHelper.As<T>(item);
	}

	/// <summary>
	/// 检测当前对象是否大于指定值，如果不大于指定值则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常生成方法 <paramref name="exceptionCreator" /> 执行异常或者返回空。</exception>
	/// <exception cref="T:System.Exception">当前对象的值小于等于 <paramref name="value" /> 的值，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static T EnsureGreaterThan<T>(IComparable<T> item, T value, Func<Exception> exceptionCreator) where T : IComparable<T>
	{
		Ensure(ObjectHelper.IsGreaterThan(item, value), exceptionCreator);
		return ObjectHelper.As<T>(item);
	}

	/// <summary>
	/// 检测当前对象是否大于指定值，如果不大于指定值则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">异常类型 <paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常类型 <paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象的值小于等于 <paramref name="value" /> 的值，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static T EnsureGreaterThan<T>(IComparable<T> item, T value, Type exceptionType, params object[] args) where T : IComparable<T>
	{
		Ensure(ObjectHelper.IsGreaterThan(item, value), exceptionType, args);
		return ObjectHelper.As<T>(item);
	}

	/// <summary>
	/// 检测当前对象是否大于等于指定值，如果小于指定值则抛出 <see cref="T:System.ArgumentOutOfRangeException" /> 异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">当前对象小于 <paramref name="value" /> 时。</exception>
	public static object EnsureGreaterThanOrEqualTo(IComparable item, object value, string name = null, string message = null)
	{
		Ensure(ObjectHelper.IsGreaterThanOrEqualTo(item, value), () => new ArgumentOutOfRangeException(name ?? "item", message ?? string.Format(Literals.MSG_ValueLessThanTarget_1, value)));
		return item;
	}

	/// <summary>
	/// 检测当前对象是否大于等于指定值，如果小于指定值则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常生成方法 <paramref name="exceptionCreator" /> 执行异常或者返回空。</exception>
	/// <exception cref="T:System.Exception">当前对象的值小于 <paramref name="value" /> 的值，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static object EnsureGreaterThanOrEqualTo(IComparable item, object value, Func<Exception> exceptionCreator)
	{
		Ensure(ObjectHelper.IsGreaterThanOrEqualTo(item, value), exceptionCreator);
		return item;
	}

	/// <summary>
	/// 检测当前对象是否大于等于指定值，如果小于指定值则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">异常类型 <paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常类型 <paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象的值小于 <paramref name="value" /> 的值，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static object EnsureGreaterThanOrEqualTo(IComparable item, object value, Type exceptionType, params object[] args)
	{
		Ensure(ObjectHelper.IsGreaterThanOrEqualTo(item, value), exceptionType, args);
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
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">当前对象小于 <paramref name="value" /> 时。</exception>
	public static T EnsureGreaterThanOrEqualTo<T>(IComparable<T> item, T value, string name = null, string message = null) where T : IComparable<T>
	{
		Ensure(ObjectHelper.IsGreaterThanOrEqualTo(item, value), () => new ArgumentOutOfRangeException(name ?? "item", message ?? string.Format(Literals.MSG_ValueLessThanTarget_1, value)));
		return ObjectHelper.As<T>(item);
	}

	/// <summary>
	/// 检测当前对象是否大于等于指定值，如果小于指定值则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常生成方法 <paramref name="exceptionCreator" /> 执行异常或者返回空。</exception>
	/// <exception cref="T:System.Exception">当前对象的值小于 <paramref name="value" /> 的值，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static T EnsureGreaterThanOrEqualTo<T>(IComparable<T> item, T value, Func<Exception> exceptionCreator) where T : IComparable<T>
	{
		Ensure(ObjectHelper.IsGreaterThanOrEqualTo(item, value), exceptionCreator);
		return ObjectHelper.As<T>(item);
	}

	/// <summary>
	/// 检测当前对象是否大于等于指定值，如果小于指定值则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">异常类型 <paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常类型 <paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象的值小于 <paramref name="value" /> 的值，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static T EnsureGreaterThanOrEqualTo<T>(IComparable<T> item, T value, Type exceptionType, params object[] args) where T : IComparable<T>
	{
		Ensure(ObjectHelper.IsGreaterThanOrEqualTo(item, value), exceptionType, args);
		return ObjectHelper.As<T>(item);
	}

	/// <summary>
	/// 检测当前对象是否是指定值之一，如果不等于任何指定的值则抛出 <see cref="T:System.ArgumentOutOfRangeException" /> 异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="values">检测的指定值列表</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果当前对象在给定列表中，则返回当前对象。</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException">当前对象不在给定的值列表 <paramref name="values" /> 中。</exception>
	public static object EnsureIn(object item, IEnumerable values, string name = null, string message = null)
	{
		Ensure(ObjectHelper.In(item, values), () => new ArgumentOutOfRangeException(name ?? "item", message ?? Literals.MSG_ValueNotInTargets));
		return item;
	}

	/// <summary>
	/// 检测当前对象是否是指定值之一，如果不等于任何指定的值，则抛出 <paramref name="exceptionCreator" /> 生成的异常。
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="values">检测的指定值列表</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果当前对象在给定列表中，则返回当前对象。</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前对象不在给定的值列表 <paramref name="values" /> 中，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static object EnsureIn(object item, IEnumerable values, Func<Exception> exceptionCreator)
	{
		Ensure(ObjectHelper.In(item, values), exceptionCreator);
		return item;
	}

	/// <summary>
	/// 检测当前对象是否是指定值之一，如果不等于任何指定的值，则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="values">检测的指定值列表</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果当前对象在给定列表中，则返回当前对象。</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象不在给定的值列表 <paramref name="values" /> 中，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static object EnsureIn(object item, IEnumerable values, Type exceptionType, params object[] args)
	{
		Ensure(ObjectHelper.In(item, values), exceptionType, args);
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
	/// <returns>如果当前对象在给定列表中，则返回当前对象。</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException">当前对象不在给定的值列表 <paramref name="values" /> 中。</exception>
	public static T EnsureIn<T>(T item, IEnumerable<T> values, string name = null, string message = null)
	{
		Ensure(ObjectHelper.In(item, values), () => new ArgumentOutOfRangeException(name ?? "item", message ?? Literals.MSG_ValueNotInTargets));
		return item;
	}

	/// <summary>
	/// 检测当前对象是否是指定值之一，如果不等于任何指定的值，则抛出 <paramref name="exceptionCreator" /> 生成的异常。
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="values">检测的指定值列表</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果当前对象在给定列表中，则返回当前对象。</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前对象不在给定的值列表 <paramref name="values" /> 中，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static T EnsureIn<T>(T item, IEnumerable<T> values, Func<Exception> exceptionCreator)
	{
		Ensure(ObjectHelper.In(item, values), exceptionCreator);
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
	/// <returns>如果当前对象在给定列表中，则返回当前对象。</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象不在给定的值列表 <paramref name="values" /> 中，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static T EnsureIn<T>(T item, IEnumerable<T> values, Type exceptionType, params object[] args)
	{
		Ensure(ObjectHelper.In(item, values), exceptionType, args);
		return item;
	}

	/// <summary>
	/// 检测当前对象是否不是指定值，如果等于任何指定的值则抛出 <see cref="T:System.ArgumentOutOfRangeException" /> 异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="values">检测的指定值列表</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果当前对象不在指定的列表中，则返回对象本身。</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException">当前对象在给定的值列表 <paramref name="values" /> 中。</exception>
	public static object EnsureNotIn(object item, IEnumerable values, string name = null, string message = null)
	{
		Ensure(ObjectHelper.NotIn(item, values), () => new ArgumentOutOfRangeException(name ?? "item", message ?? Literals.MSG_ValueInTargets));
		return item;
	}

	/// <summary>
	/// 检测当前对象是否不是指定值，如果等于任何指定的值，则抛出 <paramref name="exceptionCreator" /> 生成的异常。
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="values">检测的指定值列表</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果当前对象不在指定的列表中，则返回对象本身。</returns>
	/// <exception cref="T:System.ArgumentNullException">异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常生成方法 <paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前对象在给定的值列表 <paramref name="values" /> 中，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static object EnsureNotIn(object item, IEnumerable values, Func<Exception> exceptionCreator)
	{
		Ensure(ObjectHelper.NotIn(item, values), exceptionCreator);
		return item;
	}

	/// <summary>
	/// 检测当前对象是否不是指定值，如果等于任何指定的值，则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="values">检测的指定值列表</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果当前对象不在指定的列表中，则返回对象本身。</returns>
	/// <exception cref="T:System.ArgumentNullException">异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">异常类型 <paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常类型 <paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象在给定的值列表 <paramref name="values" /> 中，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static object EnsureNotIn(object item, IEnumerable values, Type exceptionType, params object[] args)
	{
		Ensure(ObjectHelper.NotIn(item, values), exceptionType, args);
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
	/// <returns>如果当前对象不在指定的列表中，则返回对象本身。</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException">当前对象在给定的值列表 <paramref name="values" /> 中。</exception>
	public static T EnsureNotIn<T>(T item, IEnumerable<T> values, string name = null, string message = null)
	{
		Ensure(ObjectHelper.NotIn(item, values), () => new ArgumentOutOfRangeException(name ?? "item", message ?? Literals.MSG_ValueInTargets));
		return item;
	}

	/// <summary>
	/// 检测当前对象是否不是指定值，如果等于任何指定的值，则抛出 <paramref name="exceptionCreator" /> 生成的异常。
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="values">检测的指定值列表</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果当前对象不在指定的列表中，则返回对象本身。</returns>
	/// <exception cref="T:System.ArgumentNullException">异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常生成方法 <paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前对象在给定的值列表 <paramref name="values" /> 中，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static T EnsureNotIn<T>(T item, IEnumerable<T> values, Func<Exception> exceptionCreator)
	{
		Ensure(ObjectHelper.NotIn(item, values), exceptionCreator);
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
	/// <returns>如果当前对象不在指定的列表中，则返回对象本身。</returns>
	/// <exception cref="T:System.ArgumentNullException">异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">异常类型 <paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常类型 <paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象在给定的值列表 <paramref name="values" /> 中，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static T EnsureNotIn<T>(T item, IEnumerable<T> values, Type exceptionType, params object[] args)
	{
		Ensure(ObjectHelper.NotIn(item, values), exceptionType, args);
		return item;
	}

	/// <summary>
	/// 检测当前字符串长度是否是指定值；如果当前字符串的长度不等于指定长度则抛出 <see cref="T:System.ArgumentException" /> 异常。
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <param name="length">字符串的目标长度</param>
	/// <param name="name">参数名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前字符串的长度不等于指定长度 <paramref name="length" />。</exception>
	public static string EnsureLength(string s, long length, string name = null, string message = null)
	{
		EnsureNotNull(s, "s");
		Ensure(s.Length == length, name ?? "s", message ?? string.Format(Literals.MSG_StringLengthError_1, length));
		return s;
	}

	/// <summary>
	/// 检测当前字符串长度是否是指定值；如果当前字符串的长度不等于指定长度则抛出 <paramref name="exceptionCreator" /> 生成的异常。
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <param name="length">字符串的目标长度</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空；或者 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前字符串的长度不等于指定长度 <paramref name="length" />，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static string EnsureLength(string s, long length, Func<Exception> exceptionCreator)
	{
		EnsureNotNull(s, "s");
		Ensure(s.Length == length, exceptionCreator);
		return s;
	}

	/// <summary>
	/// 检测当前字符串长度是否是指定值；如果当前字符串的长度不等于指定长度则抛出 <paramref name="exceptionType" /> 指定的异常。
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <param name="length">字符串的目标长度</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空；或者 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前字符串的长度不等于指定长度 <paramref name="length" />，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static string EnsureLength(string s, long length, Type exceptionType, params object[] args)
	{
		EnsureNotNull(s, "s");
		Ensure(s.Length == length, exceptionType, args);
		return s;
	}

	/// <summary>
	/// 检测当前对象是否小于指定值，如果不小于指定值则抛出 <see cref="T:System.ArgumentOutOfRangeException" /> 异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">当前对象大于等于 <paramref name="value" /> 时。</exception>
	public static object EnsureLessThan(IComparable item, object value, string name = null, string message = null)
	{
		Ensure(ObjectHelper.IsLessThan(item, value), () => new ArgumentOutOfRangeException(name ?? "item", message ?? string.Format(Literals.MSG_ValueGreaterThanTarget_1, value)));
		return item;
	}

	/// <summary>
	/// 检测当前对象是否小于指定值，如果不小于指定值则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常生成方法 <paramref name="exceptionCreator" /> 执行异常或者返回空。</exception>
	/// <exception cref="T:System.Exception">当前对象的值大于等于 <paramref name="value" /> 的值，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static object EnsureLessThan(IComparable item, object value, Func<Exception> exceptionCreator)
	{
		Ensure(ObjectHelper.IsLessThan(item, value), exceptionCreator);
		return item;
	}

	/// <summary>
	/// 检测当前对象是否小于指定值，如果不小于指定值则抛出抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">异常类型 <paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常类型 <paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象的值大于等于 <paramref name="value" /> 的值，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static object EnsureLessThan(IComparable item, object value, Type exceptionType, params object[] args)
	{
		Ensure(ObjectHelper.IsLessThan(item, value), exceptionType, args);
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
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">当前对象大于等于 <paramref name="value" /> 时。</exception>
	public static T EnsureLessThan<T>(IComparable<T> item, T value, string name = null, string message = null) where T : IComparable<T>
	{
		Ensure(ObjectHelper.IsLessThan(item, value), () => new ArgumentOutOfRangeException(name ?? "item", message ?? string.Format(Literals.MSG_ValueGreaterThanOrEqualToTarget_1, value)));
		return ObjectHelper.As<T>(item);
	}

	/// <summary>
	/// 检测当前对象是否小于指定值，如果不小于指定值则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常生成方法 <paramref name="exceptionCreator" /> 执行异常或者返回空。</exception>
	/// <exception cref="T:System.Exception">当前对象的值大于等于 <paramref name="value" /> 的值，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static T EnsureLessThan<T>(IComparable<T> item, T value, Func<Exception> exceptionCreator) where T : IComparable<T>
	{
		Ensure(ObjectHelper.IsLessThan(item, value), exceptionCreator);
		return ObjectHelper.As<T>(item);
	}

	/// <summary>
	/// 检测当前对象是否小于指定值，如果不小于指定值则抛出抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">异常类型 <paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常类型 <paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象的值大于等于 <paramref name="value" /> 的值，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static T EnsureLessThan<T>(IComparable<T> item, T value, Type exceptionType, params object[] args) where T : IComparable<T>
	{
		Ensure(ObjectHelper.IsLessThan(item, value), exceptionType, args);
		return ObjectHelper.As<T>(item);
	}

	/// <summary>
	/// 检测当前对象是否小于等于指定值，如果大于指定值则抛出 <see cref="T:System.ArgumentOutOfRangeException" /> 异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">当前对象大于 <paramref name="value" /> 的值。</exception>
	public static object EnsureLessThanOrEqualTo(IComparable item, object value, string name = null, string message = null)
	{
		Ensure(ObjectHelper.IsLessThanOrEqualTo(item, value), () => new ArgumentOutOfRangeException(name ?? "item", message ?? string.Format(Literals.MSG_ValueGreaterThanTarget_1, value)));
		return item;
	}

	/// <summary>
	/// 检测当前对象是否小于等于指定值，如果大于指定值则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回空。</exception>
	/// <exception cref="T:System.Exception">当前对象的值大于 <paramref name="value" /> 的值，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static object EnsureLessThanOrEqualTo(IComparable item, object value, Func<Exception> exceptionCreator)
	{
		Ensure(ObjectHelper.IsLessThanOrEqualTo(item, value), exceptionCreator);
		return item;
	}

	/// <summary>
	/// 检测当前对象是否小于等于指定值，如果大于指定值则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">异常类型 <paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常类型 <paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象的值大于 <paramref name="value" /> 的值，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static object EnsureLessThanOrEqualTo(IComparable item, object value, Type exceptionType, params object[] args)
	{
		Ensure(ObjectHelper.IsLessThanOrEqualTo(item, value), exceptionType, args);
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
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">当前对象大于 <paramref name="value" /> 的值。</exception>
	public static T EnsureLessThanOrEqualTo<T>(IComparable<T> item, T value, string name = null, string message = null) where T : IComparable<T>
	{
		Ensure(ObjectHelper.IsLessThanOrEqualTo(item, value), () => new ArgumentOutOfRangeException(name ?? "item", message ?? string.Format(Literals.MSG_ValueGreaterThanTarget_1, value)));
		return ObjectHelper.As<T>(item);
	}

	/// <summary>
	/// 检测当前对象是否小于等于指定值，如果大于指定值则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回空。</exception>
	/// <exception cref="T:System.Exception">当前对象的值大于 <paramref name="value" /> 的值，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static T EnsureLessThanOrEqualTo<T>(IComparable<T> item, T value, Func<Exception> exceptionCreator) where T : IComparable<T>
	{
		Ensure(ObjectHelper.IsLessThanOrEqualTo(item, value), exceptionCreator);
		return ObjectHelper.As<T>(item);
	}

	/// <summary>
	/// 检测当前对象是否小于等于指定值，如果大于指定值则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">异常类型 <paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常类型 <paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象的值大于 <paramref name="value" /> 的值，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static T EnsureLessThanOrEqualTo<T>(IComparable<T> item, T value, Type exceptionType, params object[] args) where T : IComparable<T>
	{
		Ensure(ObjectHelper.IsLessThanOrEqualTo(item, value), exceptionType, args);
		return ObjectHelper.As<T>(item);
	}

	/// <summary>
	/// 检测当前可清理的对象是否已经被清理，如果被清理则抛出异常
	/// </summary>
	/// <typeparam name="T">当前可清理对象的类型</typeparam>
	/// <param name="obj">当前可清理对象</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过则返回对象本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前可清理对象为空。</exception>
	/// <exception cref="T:System.ObjectDisposedException">当前可清理对象已经被清理。</exception>
	public static T EnsureNotDisposed<T>(T obj, string name = null, string message = null) where T : IDisposableObject
	{
		AssertNotNull(obj, "object");
		Assert(!obj.IsDisposed, () => new ObjectDisposedException(name ?? "object", message ?? Literals.MSG_ObjectDisposed));
		return obj;
	}

	/// <summary>
	/// 检测当前可清理的对象是否已经被清理，如果被清理则抛出异常
	/// </summary>
	/// <typeparam name="T">当前可清理对象的类型</typeparam>
	/// <param name="obj">当前可清理对象</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过则返回对象本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空；或者 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">如果当前文件不存在则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static T EnsureNotDisposed<T>(T obj, Func<Exception> exceptionCreator) where T : IDisposableObject
	{
		AssertNotNull(obj, "object");
		Assert(!obj.IsDisposed, exceptionCreator);
		return obj;
	}

	/// <summary>
	/// 检测当前可清理的对象是否已经被清理，如果被清理则抛出异常
	/// </summary>
	/// <typeparam name="T">当前可清理对象的类型</typeparam>
	/// <param name="obj">当前可清理对象</param>
	/// <param name="exceptionType">抛出的异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检测通过则返回对象本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件为空；或者 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">如果当前文件不存在则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static T EnsureNotDisposed<T>(T obj, Type exceptionType, params object[] args) where T : IDisposableObject
	{
		AssertNotNull(obj, "object");
		Assert(!obj.IsDisposed, exceptionType, args);
		return obj;
	}

	/// <summary>
	/// 检测当前对象是否不是为空或者 <see cref="T:System.DBNull" />，如果为空或者 <see cref="T:System.DBNull" /> 则抛出 <see cref="T:System.ArgumentNullException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果当前对象满足条件则返回当前对象本身。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空或者 <see cref="T:System.DBNull" />。</exception>
	public static T EnsureNotNullAndDBNull<T>(T item, string name = null, string message = null)
	{
		Ensure(ObjectHelper.IsNotNullAndDBNull(item), name ?? "item", message ?? Literals.MSG_ValueNullOrDBNull);
		return item;
	}

	/// <summary>
	/// 检测当前对象是否不是为空或者 <see cref="T:System.DBNull" />，如果为空或者 <see cref="T:System.DBNull" /> 则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果当前对象满足条件则返回当前对象本身。</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前对象的值为空或者 <see cref="T:System.DBNull" />，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static T EnsureNotNullAndDBNull<T>(T item, Func<Exception> exceptionCreator)
	{
		Ensure(ObjectHelper.IsNotNullAndDBNull(item), exceptionCreator);
		return item;
	}

	/// <summary>
	/// 检测当前对象是否不是为空或者 <see cref="T:System.DBNull" />，如果为空或者 <see cref="T:System.DBNull" /> 则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果当前对象满足条件则返回当前对象本身。</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象的值为空或者 <see cref="T:System.DBNull" />，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static T EnsureNotNullAndDBNull<T>(T item, Type exceptionType, params object[] args)
	{
		Ensure(ObjectHelper.IsNotNullAndDBNull(item), exceptionType, args);
		return item;
	}

	/// <summary>
	/// 检测当前对象是否为空或者是其类型的默认值，如果为空或者是其类型默认值抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="type">当前对象类型</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果当前对象满足条件则返回对象本身。</returns>
	/// <exception cref="T:System.ArgumentException">当前对象为空或者等于其类型的默认值</exception>
	public static object EnsureNotNullAndDefault(object item, Type type, string name = null, string message = null)
	{
		Ensure(ObjectHelper.IsNotNullAndDefault(item, type), name ?? "item", message ?? Literals.MSG_ValueNullOrDefault);
		return item;
	}

	/// <summary>
	/// 检测当前对象是否为空或者是指定类型的默认值，如果为空或者类型默认值抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="type">当前对象类型</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果当前对象满足条件则返回对象本身。</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前对象的值为空或者等于其类型的默认值，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static object EnsureNotNullAndDefault(object item, Type type, Func<Exception> exceptionCreator)
	{
		Ensure(ObjectHelper.IsNotNullAndDefault(item, type), exceptionCreator);
		return item;
	}

	/// <summary>
	/// 检测当前对象是否为空或者是指定类型默认值，如果为空或者类型默认值抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="type">当前对象类型</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果当前对象满足条件则返回对象本身。</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象的值为空或者等于其类型的默认值，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static object EnsureNotNullAndDefault(object item, Type type, Type exceptionType, params object[] args)
	{
		Ensure(ObjectHelper.IsNotNullAndDefault(item, type), exceptionType, args);
		return item;
	}

	/// <summary>
	/// 检测当前对象是否为空（null）或者是其类型的默认值，如果为空或者是其类型默认值抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果当前对象满足条件则返回对象本身。</returns>
	/// <exception cref="T:System.ArgumentException">当前对象为空或者等于其类型的默认值</exception>
	public static T EnsureNotNullAndDefault<T>(T item, string name = null, string message = null)
	{
		Ensure(ObjectHelper.IsNotNullAndDefault(item), name ?? "item", message ?? Literals.MSG_ValueNullOrDefault);
		return item;
	}

	/// <summary>
	/// 检测当前对象是否为空或者是指定类型的默认值，如果为空或者类型默认值抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果当前对象满足条件则返回对象本身。</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前对象的值为空或者等于其类型的默认值，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static T EnsureNotNullAndDefault<T>(T item, Func<Exception> exceptionCreator)
	{
		Ensure(ObjectHelper.IsNotNullAndDefault(item), exceptionCreator);
		return item;
	}

	/// <summary>
	/// 检测当前对象是否为空或者是指定类型默认值，如果为空或者类型默认值抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象的值为空或者等于其类型的默认值，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static T EnsureNotNullAndDefault<T>(T item, Type exceptionType, params object[] args)
	{
		Ensure(ObjectHelper.IsNotNullAndDefault(item), exceptionType, args);
		return item;
	}

	/// <summary>
	/// 检测当前序列是否不为空或者空序列，如果为空或者空序列抛出 <see cref="T:System.ArgumentNullException" /> 异常
	/// </summary>
	/// <typeparam name="E">当前序列类型</typeparam>
	/// <param name="items">当前序列</param>
	/// <param name="name">列表名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空或者为空序列。</exception>
	public static E EnsureNotNullAndEmpty<E>(E items, string name = null, string message = null) where E : IEnumerable
	{
		Ensure(CollectionHelper.IsNotNullAndEmpty(items), () => new ArgumentNullException(name ?? "items", message ?? Literals.MSG_SequenceNullOrEmpty));
		return items;
	}

	/// <summary>
	/// 检测当前序列是否不为空或者空序列，如果为空或者空序列抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="E">当前序列类型</typeparam>
	/// <param name="items">当前序列</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">如果当前序列为空或者空序列，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static E EnsureNotNullAndEmpty<E>(E items, Func<Exception> exceptionCreator) where E : IEnumerable
	{
		Ensure(CollectionHelper.IsNotNullAndEmpty(items), exceptionCreator);
		return items;
	}

	/// <summary>f
	/// 检测当前序列是否不为空或者空序列，如果为空或者空序列抛出 <paramref name="exceptionType" /> 类型的异常
	/// </summary>
	/// <typeparam name="E">当前序列类型</typeparam>
	/// <param name="items">当前序列</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">如果当前序列为空或者空序列，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static E EnsureNotNullAndEmpty<E>(E items, Type exceptionType, params object[] args) where E : IEnumerable
	{
		Ensure(CollectionHelper.IsNotNullAndEmpty(items), exceptionType, args);
		return items;
	}

	/// <summary>
	/// 检测当前字符串是否为空或者空串，如果为空或者空串，则抛出 <see cref="T:System.ArgumentNullException" /> 异常。
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <param name="name">参数名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空或者空串。</exception>
	public static string EnsureNotNullAndEmpty(string s, string name = null, string message = null)
	{
		Ensure(!string.IsNullOrEmpty(s), () => new ArgumentNullException(name ?? "s", message ?? Literals.MSG_StringNullOrEmpty));
		return s;
	}

	/// <summary>
	/// 检测当前字符串是否为空或者空串，如果为空或者空串，则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException">异常生成方法<paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常生成方法<paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前字符串为空或者空串，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static string EnsureNotNullAndEmpty(string s, Func<Exception> exceptionCreator)
	{
		Ensure(!string.IsNullOrEmpty(s), exceptionCreator);
		return s;
	}

	/// <summary>
	/// 检测当前字符串是否为空或者空串，如果为空或者空串，则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前字符串为空或者空串，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static string EnsureNotNullAndEmpty(string s, Type exceptionType, params object[] args)
	{
		Ensure(!string.IsNullOrEmpty(s), exceptionType, args);
		return s;
	}

	/// <summary>
	/// 检测当前字符串是否为空、空串或者全部为空白字符，如果为空、空串或者全部为空白字符，则抛出 <see cref="T:System.ArgumentNullException" /> 异常
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <param name="name">参数名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空、空串或者全部为空白字符。</exception>
	public static string EnsureNotNullAndWhiteSpace(string s, string name = null, string message = null)
	{
		Ensure(!string.IsNullOrWhiteSpace(s), () => new ArgumentNullException(name ?? "s", message ?? Literals.MSG_StringNullOrWhiteSpace));
		return s;
	}

	/// <summary>
	/// 检测当前字符串是否为空、空串或者全部为空白字符，如果为空、空串或者全部为空白字符，则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前字符串为空、空串或者全部为空白字符，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static string EnsureNotNullAndWhiteSpace(string s, Func<Exception> exceptionCreator)
	{
		Ensure(!string.IsNullOrWhiteSpace(s), exceptionCreator);
		return s;
	}

	/// <summary>
	/// 检测当前字符串是否为空、空串或者全部为空白字符，如果为空、空串或者全部为空白字符，则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前字符串为空、空串或者全部为空白字符，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static string EnsureNotNullAndWhiteSpace(string s, Type exceptionType, params object[] args)
	{
		Ensure(!string.IsNullOrWhiteSpace(s), exceptionType, args);
		return s;
	}

	/// <summary>
	/// 检测当前对象是否为空，如果不为空抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前对象为空</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">错误消息</param>
	/// <returns>如果当前对象为空则返回空。</returns>
	/// <exception cref="T:System.ArgumentException">当前对象不为空。</exception>
	public static T EnsureNull<T>(T item, string name = null, string message = null)
	{
		Ensure(ObjectHelper.IsNull(item), name ?? "item", message ?? Literals.MSG_ValueNotNull);
		return item;
	}

	/// <summary>
	/// 检测当前对象是否为空，如果不为空抛出参数 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">当前对象为空</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果当前对象为空则返回空。</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前对象不为空，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static T EnsureNull<T>(T item, Func<Exception> exceptionCreator)
	{
		Ensure(ObjectHelper.IsNull(item), exceptionCreator);
		return item;
	}

	/// <summary>
	/// 检测当前对象是否为空，如果不为空抛出参数 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <typeparam name="T">当前对象为空</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果当前对象为空则返回空。</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前当前对象不为空，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static T EnsureNull<T>(T item, Type exceptionType, params object[] args)
	{
		Ensure(ObjectHelper.IsNull(item), exceptionType, args);
		return item;
	}

	/// <summary>
	/// 检测当前对象是否为空，如果为空抛出 <see cref="T:System.ArgumentNullException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前对象为空</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">错误消息</param>
	/// <returns>如果当前对象不为空，则返回对象本身。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空。</exception>
	public static T EnsureNotNull<T>(T item, string name = null, string message = null)
	{
		Ensure(ObjectHelper.IsNotNull(item), () => new ArgumentNullException(name ?? "item", message ?? Literals.MSG_ValueNull));
		return item;
	}

	/// <summary>
	/// 检测当前对象是否为空，如果为空抛出参数 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">当前对象为空</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果当前对象不为空，则返回对象本身。</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前对象为空，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static T EnsureNotNull<T>(T item, Func<Exception> exceptionCreator)
	{
		Ensure(ObjectHelper.IsNotNull(item), exceptionCreator);
		return item;
	}

	/// <summary>
	/// 检测当前对象是否为空，如果为空抛出参数 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <typeparam name="T">当前对象为空</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果当前对象不为空，则返回对象本身。</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象为空，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static T EnsureNotNull<T>(T item, Type exceptionType, params object[] args)
	{
		Ensure(ObjectHelper.IsNotNull(item), exceptionType, args);
		return item;
	}

	/// <summary>
	/// 检测当前索引是否小于等于指定的上限，如果大于指定上限则抛出 <see cref="T:System.IndexOutOfRangeException" /> 异常。
	/// </summary>
	/// <param name="index">当前索引</param>
	/// <param name="max">索引的最大值（上限）</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过返回当前索引</returns>
	/// <exception cref="T:System.IndexOutOfRangeException">当前索引大于 <paramref name="max" />。</exception>
	public static int EnsureIndexHighBound(int index, int max, string name = null, string message = null)
	{
		message = message ?? string.Format(Literals.MSG_IndexGreaterThanHighBound_2, name ?? "index", max);
		Ensure(index <= max, () => new IndexOutOfRangeException(message));
		return index;
	}

	/// <summary>
	/// 检测当前索引是否小于等于指定的上限，如果大于指定上限则抛出 <paramref name="exceptionCreator" /> 生成的异常。
	/// </summary>
	/// <param name="index">当前索引</param>
	/// <param name="max">索引的最大值（上限）</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过返回当前索引</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">如果当前索引大于 <paramref name="max" />，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static int EnsureIndexHighBound(int index, int max, Func<Exception> exceptionCreator)
	{
		Ensure(index <= max, exceptionCreator);
		return index;
	}

	/// <summary>
	/// 检测当前索引是否小于等于指定的上限，如果大于指定上限则抛出 <paramref name="exceptionType" /> 指定的异常。
	/// </summary>
	/// <param name="index">当前索引</param>
	/// <param name="max">索引的最大值（上限）</param>
	/// <param name="exceptionType">抛出的异常类型</param>
	/// <param name="args">异常构造参数</param>
	/// <returns>如果检测通过返回当前索引</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">如果当前索引大于 <paramref name="max" />，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static int EnsureIndexHighBound(int index, int max, Type exceptionType, params object[] args)
	{
		Ensure(index <= max, exceptionType, args);
		return index;
	}

	/// <summary>
	/// 检测当前索引是否小于等于指定的上限，如果大于指定上限则抛出 <see cref="T:System.IndexOutOfRangeException" /> 异常。
	/// </summary>
	/// <param name="index">当前索引</param>
	/// <param name="max">索引的最大值（上限）</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过返回当前索引</returns>
	/// <exception cref="T:System.IndexOutOfRangeException">当前索引大于 <paramref name="max" />。</exception>
	public static long EnsureIndexHighBound(long index, long max, string name = null, string message = null)
	{
		message = message ?? string.Format(Literals.MSG_IndexGreaterThanHighBound_2, name ?? "index", max);
		Ensure(index <= max, () => new IndexOutOfRangeException(message));
		return index;
	}

	/// <summary>
	/// 检测当前索引是否小于等于指定的上限，如果大于指定上限则抛出 <paramref name="exceptionCreator" /> 生成的异常。
	/// </summary>
	/// <param name="index">当前索引</param>
	/// <param name="max">索引的最大值（上限）</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过返回当前索引</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">如果当前索引大于 <paramref name="max" />，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static long EnsureIndexHighBound(long index, long max, Func<Exception> exceptionCreator)
	{
		Ensure(index <= max, exceptionCreator);
		return index;
	}

	/// <summary>
	/// 检测当前索引是否小于等于指定的上限，如果大于指定上限则抛出 <paramref name="exceptionType" /> 指定的异常。
	/// </summary>
	/// <param name="index">当前索引</param>
	/// <param name="max">索引的最大值（上限）</param>
	/// <param name="exceptionType">抛出的异常类型</param>
	/// <param name="args">异常构造参数</param>
	/// <returns>如果检测通过返回当前索引</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">如果当前索引大于 <paramref name="max" />，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static long EnsureIndexHighBound(long index, long max, Type exceptionType, params object[] args)
	{
		Ensure(index <= max, exceptionType, args);
		return index;
	}

	/// <summary>
	/// 检测当前索引是否大于等于指定的下限，如果小于指定下限则抛出 <see cref="T:System.IndexOutOfRangeException" /> 异常。
	/// </summary>
	/// <param name="index">当前索引</param>
	/// <param name="min">索引的最小值（下限）</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过返回当前索引</returns>
	/// <exception cref="T:System.IndexOutOfRangeException">当前索引小于 <paramref name="min" />。</exception>
	public static int EnsureIndexLowBound(int index, int min, string name = null, string message = null)
	{
		message = message ?? string.Format(Literals.MSG_IndexLessThanLowBound_2, name ?? "index", min);
		Ensure(index >= min, () => new IndexOutOfRangeException(message));
		return index;
	}

	/// <summary>
	/// 检测当前索引是否大于等于指定的下限，如果小于指定下限则抛出 <paramref name="exceptionCreator" /> 生成的异常。
	/// </summary>
	/// <param name="index">当前索引</param>
	/// <param name="min">索引的最小值（下限）</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过返回当前索引</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">如果当前索引小于 <paramref name="min" />，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	/// <remarks>索引的最小值默认为 0。</remarks>
	public static int EnsureIndexLowBound(int index, int min, Func<Exception> exceptionCreator)
	{
		Ensure(index >= min, exceptionCreator);
		return index;
	}

	/// <summary>
	/// 检测当前索引是否大于等于指定的下限，如果小于指定下限则抛出 <paramref name="exceptionType" /> 指定的异常。
	/// </summary>
	/// <param name="index">当前索引</param>
	/// <param name="min">索引的最小值（下限）</param>
	/// <param name="exceptionType">抛出的异常类型</param>
	/// <param name="args">异常构造参数</param>
	/// <returns>如果检测通过返回当前索引</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">如果当前索引小于 <paramref name="min" />，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static int EnsureIndexLowBound(int index, int min, Type exceptionType, params object[] args)
	{
		Ensure(index >= min, exceptionType, args);
		return index;
	}

	/// <summary>
	/// 检测当前索引是否大于等于指定的下限，如果小于指定下限则抛出 <see cref="T:System.IndexOutOfRangeException" /> 异常。
	/// </summary>
	/// <param name="index">当前索引</param>
	/// <param name="min">索引的最小值（下限）</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过返回当前索引</returns>
	/// <exception cref="T:System.IndexOutOfRangeException">当前索引小于 <paramref name="min" />。</exception>
	public static long EnsureIndexLowBound(long index, long min, string name = null, string message = null)
	{
		message = message ?? string.Format(Literals.MSG_IndexLessThanLowBound_2, name ?? "index", min);
		Ensure(index >= min, () => new IndexOutOfRangeException(message));
		return index;
	}

	/// <summary>
	/// 检测当前索引是否大于等于指定的下限，如果小于指定下限则抛出 <paramref name="exceptionCreator" /> 生成的异常。
	/// </summary>
	/// <param name="index">当前索引</param>
	/// <param name="min">索引的最小值（下限）</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过返回当前索引</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">如果当前索引小于 <paramref name="min" />，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	/// <remarks>索引的最小值默认为 0。</remarks>
	public static long EnsureIndexLowBound(long index, long min, Func<Exception> exceptionCreator)
	{
		Ensure(index >= min, exceptionCreator);
		return index;
	}

	/// <summary>
	/// 检测当前索引是否大于等于指定的下限，如果小于指定下限则抛出 <paramref name="exceptionType" /> 指定的异常。
	/// </summary>
	/// <param name="index">当前索引</param>
	/// <param name="min">索引的最小值（下限）</param>
	/// <param name="exceptionType">抛出的异常类型</param>
	/// <param name="args">异常构造参数</param>
	/// <returns>如果检测通过返回当前索引</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">如果当前索引小于 <paramref name="min" />，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static long EnsureIndexLowBound(long index, long min, Type exceptionType, params object[] args)
	{
		Ensure(index >= min, exceptionType, args);
		return index;
	}

	/// <summary>
	/// 检测当前索引是否在指定的范围内，如果超出指定范围则抛出 <see cref="T:System.IndexOutOfRangeException" /> 异常。
	/// </summary>
	/// <param name="index">当前索引</param>
	/// <param name="min">索引的最小值</param>
	/// <param name="max">索引的最大值</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过返回当前索引</returns>
	/// <exception cref="T:System.IndexOutOfRangeException">当前索引小于 <paramref name="min" />，或者大于 <paramref name="max" />。</exception>
	public static int EnsureIndexRange(int index, int min, int max, string name = null, string message = null)
	{
		message = string.Format(message ?? Literals.MSG_IndexOutOfRange_1, name ?? "index");
		Ensure(min <= index && index <= max, () => new IndexOutOfRangeException(message));
		return index;
	}

	/// <summary>
	/// 检测当前索引是否在指定的范围内，如果超出指定范围则抛出 <paramref name="exceptionCreator" /> 生成的异常。
	/// </summary>
	/// <param name="index">当前索引</param>
	/// <param name="min">索引的最小值</param>
	/// <param name="max">索引的最大值</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过返回当前索引</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">如果当前索引小于 <paramref name="min" />，或者大于 <paramref name="max" />，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static int EnsureIndexRange(int index, int min, int max, Func<Exception> exceptionCreator)
	{
		Ensure(min <= index && index <= max, exceptionCreator);
		return index;
	}

	/// <summary>
	/// 检测当前索引是否在指定的范围内，如果超出指定范围则抛出 <paramref name="exceptionType" /> 指定的异常。
	/// </summary>
	/// <param name="index">当前索引</param>
	/// <param name="min">索引的最小值</param>
	/// <param name="max">索引的最大值</param>
	/// <param name="exceptionType">抛出的异常类型</param>
	/// <param name="args">异常构造参数</param>
	/// <returns>如果检测通过返回当前索引</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">如果当前索引小于 <paramref name="min" />，或者大于 <paramref name="max" />，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static int EnsureIndexRange(int index, int min, int max, Type exceptionType, params object[] args)
	{
		Ensure(min <= index && index <= max, exceptionType, args);
		return index;
	}

	/// <summary>
	/// 检测当前索引是否在指定的范围内，如果超出指定范围则抛出 <see cref="T:System.IndexOutOfRangeException" /> 异常。
	/// </summary>
	/// <param name="index">当前索引</param>
	/// <param name="min">索引的最小值</param>
	/// <param name="max">索引的最大值</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过返回当前索引</returns>
	/// <exception cref="T:System.IndexOutOfRangeException">当前索引小于 <paramref name="min" />，或者大于 <paramref name="max" />。</exception>
	public static long EnsureIndexRange(long index, long min, long max, string name = null, string message = null)
	{
		message = string.Format(message ?? Literals.MSG_IndexOutOfRange_1, name ?? "index");
		Ensure(min <= index && index <= max, () => new IndexOutOfRangeException(message));
		return index;
	}

	/// <summary>
	/// 检测当前索引是否在指定的范围内，如果超出指定范围则抛出 <paramref name="exceptionCreator" /> 生成的异常。
	/// </summary>
	/// <param name="index">当前索引</param>
	/// <param name="min">索引的最小值</param>
	/// <param name="max">索引的最大值</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过返回当前索引</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">如果当前索引小于 <paramref name="min" />，或者大于 <paramref name="max" />，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static long EnsureIndexRange(long index, long min, long max, Func<Exception> exceptionCreator)
	{
		Ensure(min <= index && index <= max, exceptionCreator);
		return index;
	}

	/// <summary>
	/// 检测当前索引是否在指定的范围内，如果超出指定范围则抛出 <paramref name="exceptionType" /> 指定的异常。
	/// </summary>
	/// <param name="index">当前索引</param>
	/// <param name="min">索引的最小值</param>
	/// <param name="max">索引的最大值</param>
	/// <param name="exceptionType">抛出的异常类型</param>
	/// <param name="args">异常构造参数</param>
	/// <returns>如果检测通过返回当前索引</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">如果当前索引小于 <paramref name="min" />，或者大于 <paramref name="max" />，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static long EnsureIndexRange(long index, long min, long max, Type exceptionType, params object[] args)
	{
		Ensure(min <= index && index <= max, exceptionType, args);
		return index;
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
	public static Type EnsureInheritedType<T>(Type type, string name = null, string message = null)
	{
		return EnsureInheritedType(type, typeof(T), name, message);
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
	public static Type EnsureInheritedType<T>(Type type, Func<Exception> exceptionCreator)
	{
		return EnsureInheritedType(type, typeof(T), exceptionCreator);
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
	public static Type EnsureInheritedType<T>(Type type, Type exceptionType, params object[] args)
	{
		return EnsureInheritedType(type, typeof(T), exceptionType, args);
	}

	/// <summary>
	/// 检测当前类型是否是指定的类型或者是指定类型的派生类型，如果不符合则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="baseType">检测的目标类型</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过返回当前类型</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者 <paramref name="baseType" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">如果当前类型不是指定的类型或者不是指定类型的派生类型 <see cref="T:System.ArgumentException" /> 异常</exception>
	public static Type EnsureInheritedType(Type type, Type baseType, string name = null, string message = null)
	{
		EnsureNotNull(type, "type");
		EnsureNotNull(baseType, "base type");
		Ensure(baseType.IsAssignableFrom(type), name ?? "type", message ?? string.Format(Literals.MSG_TypeNotInheritFromTarget_1, baseType.FullName));
		return type;
	}

	/// <summary>
	/// 检测当前类型是否是指定的类型或者是指定类型的派生类型，如果不符合则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="baseType">检测的目标类型</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过则返回当前类型</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者 <paramref name="baseType" /> 为空；或者 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">如果当前类型不是指定的类型或者不是指定类型的派生类型，则抛出参数 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static Type EnsureInheritedType(Type type, Type baseType, Func<Exception> exceptionCreator)
	{
		EnsureNotNull(type, "type");
		EnsureNotNull(baseType, "base type");
		Ensure(baseType.IsAssignableFrom(type), exceptionCreator);
		return type;
	}

	/// <summary>
	/// 检测当前类型是否是指定的类型或者是指定类型的派生类型，如果不符合则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <param name="type">当前类型</param>
	/// <param name="baseType">检测的目标类型</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检测通过返回当前类型</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型为空；或者 <paramref name="baseType" /> 为空；或者 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">如果当前类型不是指定的类型或者不是指定类型的派生类型，则抛出参数 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static Type EnsureInheritedType(Type type, Type baseType, Type exceptionType, params object[] args)
	{
		EnsureNotNull(type, "type");
		EnsureNotNull(baseType, "base type");
		Ensure(baseType.IsAssignableFrom(type), exceptionType, args);
		return type;
	}

	/// <summary>
	/// 检测当前对象是否是指定类型的实例，如果不是则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <typeparam name="T">检测的目标类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果当前对象是指定类型的实例，则返回转换为指定类型的当前对象。</returns>
	/// <exception cref="T:System.ArgumentException">当前对象不是指定类型 <typeparamref name="T" /> 的实例。</exception>
	public static T EnsureInstanceOfType<T>(object item, string name = null, string message = null)
	{
		Ensure(ObjectHelper.IsInstanceOf<T>(item), name ?? "item", message ?? Literals.MSG_ObjectNotOfType);
		return (T)item;
	}

	/// <summary>
	/// 检测当前对象是否是指定类型的实例，如果不是则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">检测的目标类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果当前对象是指定类型的实例，则返回转换为指定类型的当前对象。</returns>
	/// <exception cref="T:System.ArgumentNullException">异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前对象为空，或者不是 <typeparamref name="T" /> 指定的类型的实例，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static T EnsureInstanceOfType<T>(object item, Func<Exception> exceptionCreator)
	{
		Ensure(ObjectHelper.IsInstanceOf<T>(item), exceptionCreator);
		return (T)item;
	}

	/// <summary>
	/// 检测当前对象是否是指定类型的实例，如果不是则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <typeparam name="T">检测的目标类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果当前对象是指定类型的实例，则返回转换为指定类型的当前对象。</returns>
	/// <exception cref="T:System.ArgumentNullException">异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">异常类型 <paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常类型 <paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象为空，或者不是 <typeparamref name="T" /> 指定的类型的实例，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static T EnsureInstanceOfType<T>(object item, Type exceptionType, params object[] args)
	{
		Ensure(ObjectHelper.IsInstanceOf<T>(item), exceptionType, args);
		return (T)item;
	}

	/// <summary>
	/// 检测当前对象是否是指定类型的实例，如果不是则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="type">检测的目标类型</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果当前对象是指定类型的实例，则返回当前对象本身。</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="type" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前对象为空，或者不是 <paramref name="type" /> 指定的类型的实例</exception>
	public static object EnsureInstanceOfType(object item, Type type, string name = null, string message = null)
	{
		EnsureNotNull(type, "type", Literals.MSG_TypeNull);
		Ensure(ObjectHelper.IsInstanceOf(item, type), name ?? "item", message ?? Literals.MSG_ObjectNotOfType);
		return item;
	}

	/// <summary>
	/// 检测当前对象是否是指定类型的实例，如果不是则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="type">检测的目标类型</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果当前对象是指定类型的实例，则返回当前对象本身。</returns>
	/// <exception cref="T:System.ArgumentNullException">异常生成方法 <paramref name="exceptionCreator" /> 为空；或者 <paramref name="type" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常生成方法 <paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前对象为空，或者不是 <paramref name="type" /> 指定的类型的实例，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static object EnsureInstanceOfType(object item, Type type, Func<Exception> exceptionCreator)
	{
		EnsureNotNull(type, "type", Literals.MSG_TypeNull);
		Ensure(ObjectHelper.IsInstanceOf(item, type), exceptionCreator);
		return item;
	}

	/// <summary>
	/// 检测当前对象是否是指定类型的实例，如果不是则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="type">检测的目标类型</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果当前对象是指定类型的实例，则返回当前对象本身。</returns>
	/// <exception cref="T:System.ArgumentNullException">异常类型 <paramref name="exceptionType" /> 为空；或者 <paramref name="type" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">异常类型 <paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常类型 <paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象为空，或者不是 <paramref name="type" /> 指定的类型的实例，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static object EnsureInstanceOfType(object item, Type type, Type exceptionType, params object[] args)
	{
		EnsureNotNull(type, "type", Literals.MSG_TypeNull);
		Ensure(ObjectHelper.IsInstanceOf(item, type), exceptionType, args);
		return item;
	}

	/// <summary>
	/// 检测当前对象是否不是指定类型的实例，如果是则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <typeparam name="T">检测的目标类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果当前对象不是指定类型的实例则返回当前对象本身。</returns>
	/// <exception cref="T:System.ArgumentException">当前对象是 <typeparamref name="T" /> 指定的类型的实例</exception>
	public static object EnsureNotInstanceOfType<T>(object item, string name = null, string message = null)
	{
		Ensure(!ObjectHelper.IsInstanceOf<T>(item), name ?? "item", message ?? Literals.MSG_ObjectOfType);
		return item;
	}

	/// <summary>
	/// 检测当前对象是否不是指定类型的实例，如果是则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">检测的目标类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果当前对象不是指定类型的实例则返回当前对象本身。</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前对象是 <typeparamref name="T" /> 指定的类型的实例，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static object EnsureNotInstanceOfType<T>(object item, Func<Exception> exceptionCreator)
	{
		Ensure(!ObjectHelper.IsInstanceOf<T>(item), exceptionCreator);
		return item;
	}

	/// <summary>
	/// 检测当前对象是否不是指定类型的实例，如果是则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <typeparam name="T">检测的目标类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果当前对象不是指定类型的实例则返回当前对象本身。</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象是 <typeparamref name="T" /> 指定的类型的实例，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static object EnsureNotInstanceOfType<T>(object item, Type exceptionType, params object[] args)
	{
		Ensure(!ObjectHelper.IsInstanceOf<T>(item), exceptionType, args);
		return item;
	}

	/// <summary>
	/// 检测当前对象是否不是指定类型的实例，如果是则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="type">检测的目标类型</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果当前对象不是指定类型的实例则返回当前对象本身。</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="type" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前对象是 <paramref name="type" /> 指定的类型的实例</exception>
	public static object EnsureNotInstanceOfType(object item, Type type, string name = null, string message = null)
	{
		EnsureNotNull(type, "type", Literals.MSG_TypeNull);
		Ensure(!ObjectHelper.IsInstanceOf(item, type), name ?? "item", message ?? Literals.MSG_ObjectOfType);
		return item;
	}

	/// <summary>
	/// 检测当前对象是否不是指定类型的实例，如果是则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="type">检测的目标类型</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果当前对象不是指定类型的实例则返回当前对象本身。</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionCreator" /> 为空；或者 <paramref name="type" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前对象是 <paramref name="type" /> 指定的类型的实例，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static object EnsureNotInstanceOfType(object item, Type type, Func<Exception> exceptionCreator)
	{
		EnsureNotNull(type, "type", Literals.MSG_TypeNull);
		Ensure(!ObjectHelper.IsInstanceOf(item, type), exceptionCreator);
		return item;
	}

	/// <summary>
	/// 检测当前对象是否不是指定类型的实例，如果是则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="type">检测的目标类型</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果当前对象不是指定类型的实例则返回当前对象本身。</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionType" /> 为空；或者 <paramref name="type" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象是 <paramref name="type" /> 指定的类型的实例，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static object EnsureNotInstanceOfType(object item, Type type, Type exceptionType, params object[] args)
	{
		EnsureNotNull(type, "type", Literals.MSG_TypeNull);
		Ensure(!ObjectHelper.IsInstanceOf(item, type), exceptionType, args);
		return item;
	}

	/// <summary>
	/// 检测当前对象是否为值类型，如果不是值类型则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果当前对象为值类型则抛出当前对象本身。</returns>
	/// <exception cref="T:System.ArgumentException">当前对象为空，或者不是值类型的对象。</exception>
	public static object EnsureInstanceOfValueType(object item, string name = null, string message = null)
	{
		Ensure(ObjectHelper.IsValueType(item), name ?? "item", message ?? Literals.MSG_ObjectNotOfValueType);
		return item;
	}

	/// <summary>
	/// 检测当前对象是否为值类型，如果不是值类型则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果当前对象为值类型则抛出当前对象本身。</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前对象为空，或者不是值类型的对象，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static object EnsureInstanceOfValueType(object item, Func<Exception> exceptionCreator)
	{
		Ensure(ObjectHelper.IsValueType(item), exceptionCreator);
		return item;
	}

	/// <summary>
	/// 检测当前对象是否为值类型，如果不是值类型则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果当前对象为值类型则抛出当前对象本身。</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象为空，或者不是值类型的对象，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static object EnsureInstanceOfValueType(object item, Type exceptionType, params object[] args)
	{
		Ensure(ObjectHelper.IsValueType(item), exceptionType, args);
		return item;
	}

	/// <summary>
	/// 检测当前对象是否为引用类型，如果不是引用类型则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果当前对象为引用类型则返回当前对象本事。</returns>
	/// <exception cref="T:System.ArgumentException">当前对象为空，或者所属的类型不是类或者接口。</exception>
	public static object EnsureInstanceOfReferenceType(object item, string name = null, string message = null)
	{
		Ensure(ObjectHelper.IsReferenceType(item), name ?? "item", message ?? Literals.MSG_ObjectNotOfReferenceType);
		return item;
	}

	/// <summary>
	/// 检测当前对象是否为引用类型，如果不是引用类型则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果当前对象为引用类型则返回当前对象本事。</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前对象为空，或者所属的类型不是类或者接口，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static object EnsureInstanceOfReferenceType(object item, Func<Exception> exceptionCreator)
	{
		Ensure(ObjectHelper.IsReferenceType(item), exceptionCreator);
		return item;
	}

	/// <summary>
	/// 检测当前对象是否为引用类型，如果不是引用类型则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <param name="item">当前对象</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果当前对象为引用类型则返回当前对象本事。</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象为空，或者所属的类型不是类或者接口，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static object EnsureInstanceOfReferenceType(object item, Type exceptionType, params object[] args)
	{
		Ensure(ObjectHelper.IsReferenceType(item), exceptionType, args);
		return item;
	}

	/// <summary>
	/// 检测当前值是否等于true，如果不等于true，抛出 <see cref="T:System.ArgumentOutOfRangeException" /> 异常
	/// </summary>
	/// <param name="value">当前布尔值</param>
	/// <param name="name">参数名称</param>
	/// <param name="message">异常消息</param>
	/// <returns>如果检测通过返回true</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException">如果 <paramref name="value" /> 为false。</exception>
	public static bool EnsureTrue(bool value, string name = null, string message = null)
	{
		Ensure(value, () => new ArgumentOutOfRangeException(name ?? "value", message ?? Literals.MSG_ValueFalse));
		return value;
	}

	/// <summary>
	/// 检测当前值是否等于true，如果不等于true，抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <param name="value">当前布尔值</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过返回true</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception"><paramref name="value" /> 不等于true，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static bool EnsureTrue(bool value, Func<Exception> exceptionCreator)
	{
		Ensure(value, exceptionCreator);
		return value;
	}

	/// <summary>
	/// 检测当前值是否等于true，如果不等于true，抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <param name="value">当前布尔值</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检测通过返回true</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception"><paramref name="value" /> 不等于true，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static bool EnsureTrue(bool value, Type exceptionType, params object[] args)
	{
		Ensure(value, exceptionType, args);
		return value;
	}

	/// <summary>
	/// 如果当前函数委托的返回值不等于true，则抛出 <see cref="T:System.InvalidOperationException" /> 异常
	/// </summary>
	/// <param name="func">当前函数委托</param>
	/// <param name="name">参数名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过返回true</returns>
	/// <exception cref="T:System.ArgumentNullException">当前函数委托为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前函数委托返回false时。</exception>
	public static bool EnsureTrue(Func<bool> func, string name = null, string message = null)
	{
		EnsureNotNull(func, "func");
		Ensure(func(), () => new InvalidOperationException(message ?? Literals.MSG_ValueFalse));
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
	public static bool EnsureTrue(Func<bool> func, Func<Exception> exceptionCreator)
	{
		EnsureNotNull(func, "func");
		Ensure(func(), exceptionCreator);
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
	public static bool EnsureTrue(Func<bool> func, Type exceptionType, params object[] args)
	{
		EnsureNotNull(func, "func");
		Ensure(func(), exceptionType, args);
		return true;
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
	public static Type EnsureType<T>(Type type, string name = null, string message = null)
	{
		return EnsureType(type, typeof(T), name, message);
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
	public static Type EnsureType<T>(Type type, Func<Exception> exceptionCreator)
	{
		return EnsureType(type, typeof(T), exceptionCreator);
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
	public static Type EnsureType<T>(Type type, Type exceptionType, params object[] args)
	{
		return EnsureType(type, typeof(T), exceptionType, args);
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
	public static Type EnsureType(Type type, Type targetType, string name = null, string message = null)
	{
		EnsureNotNull(type, "source type");
		EnsureNotNull(targetType, "target type");
		Ensure(type.Equals(targetType), name ?? "source type", message ?? string.Format(Literals.MSG_TypeNotTarget_1, targetType.FullName));
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
	public static Type EnsureType(Type type, Type targetType, Func<Exception> exceptionCreator)
	{
		EnsureNotNull(type, "source type");
		EnsureNotNull(targetType, "target type");
		Ensure(type.Equals(targetType), exceptionCreator);
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
	public static Type EnsureType(Type type, Type targetType, Type exceptionType, params object[] args)
	{
		EnsureNotNull(type, "source type");
		EnsureNotNull(targetType, "target type");
		Ensure(type.Equals(targetType), exceptionType, args);
		return type;
	}
}
