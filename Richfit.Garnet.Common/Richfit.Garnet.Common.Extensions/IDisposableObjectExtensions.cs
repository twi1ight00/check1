using System;
using Richfit.Garnet.Common.Patterns;
using Richfit.Garnet.Common.Properties;

namespace Richfit.Garnet.Common.Extensions;

/// <summary>
/// 可清理对象接口 <see cref="T:System.ObjectDisposedException" /> 扩展类
/// </summary>
public static class IDisposableObjectExtensions
{
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
	public static T GuardNotDisposed<T>(this T obj, string name = null, string message = null) where T : IDisposableObject
	{
		obj.GuardNotNull("disposable obj");
		obj.Guard(!obj.IsDisposed, () => new ObjectDisposedException(name.IfNull("object"), message.IfNull(Literals.MSG_ObjectDisposed)));
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
	public static T GuardNotDisposed<T>(this T obj, Func<Exception> exceptionCreator) where T : IDisposableObject
	{
		obj.GuardNotNull("disposable obj");
		obj.Guard(!obj.IsDisposed, exceptionCreator);
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
	public static T GuardNotDisposed<T>(this T obj, Type exceptionType, params object[] args) where T : IDisposableObject
	{
		obj.GuardNotNull("disposable obj");
		obj.Guard(!obj.IsDisposed, exceptionType, args);
		return obj;
	}
}
