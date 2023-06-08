using System;
using Richfit.Garnet.Common.Extensions;

namespace Richfit.Garnet.Module.Importing.Aspose.Excel;

/// <summary>
/// 项目值解析异常类型
/// </summary>
public class ValueResolveException : Exception
{
	/// <summary>
	/// 获取项目值解析上下文对象
	/// </summary>
	public ValueResolveContext Context { get; private set; }

	/// <summary>
	/// 初始化项目值解析异常
	/// </summary>
	/// <param name="context">项目解析上下文对象</param>
	public ValueResolveException(ValueResolveContext context)
		: this(context, string.Empty, null)
	{
	}

	/// <summary>
	/// 初始化项目值解析异常
	/// </summary>
	/// <param name="context">项目解析上下文对象</param>
	/// <param name="message">异常信息</param>
	public ValueResolveException(ValueResolveContext context, string message)
		: this(context, message, null)
	{
	}

	/// <summary>
	/// 初始化项目值解析异常
	/// </summary>
	/// <param name="context">项目解析上下文对象</param>
	/// <param name="innerException">引发本异常的内部异常</param>
	public ValueResolveException(ValueResolveContext context, Exception innerException)
		: this(context, string.Empty, innerException)
	{
	}

	/// <summary>
	/// 初始化项目值解析异常
	/// </summary>
	/// <param name="context">项目解析上下文对象</param>
	/// <param name="message">异常信息</param>
	/// <param name="innerException">引发本异常的内部异常</param>
	public ValueResolveException(ValueResolveContext context, string message, Exception innerException)
		: base(message, innerException)
	{
		context.GuardNotNull("context");
		Context = context;
	}
}
