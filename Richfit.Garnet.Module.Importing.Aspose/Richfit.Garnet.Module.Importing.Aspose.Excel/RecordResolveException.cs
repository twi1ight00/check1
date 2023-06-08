using System;
using Richfit.Garnet.Common.Extensions;

namespace Richfit.Garnet.Module.Importing.Aspose.Excel;

/// <summary>
/// 数据记录解析异常类
/// </summary>
public class RecordResolveException : Exception
{
	/// <summary>
	/// 获取数据记录解析上下文对象
	/// </summary>
	public RecordResolveContext Context { get; private set; }

	/// <summary>
	/// 初始化异常
	/// </summary>
	/// <param name="context">数据记录解析上下文对象</param>
	public RecordResolveException(RecordResolveContext context)
		: this(context, string.Empty, null)
	{
	}

	/// <summary>
	/// 初始化异常
	/// </summary>
	/// <param name="context">数据记录解析上下文对象</param>
	/// <param name="message">异常信息</param>
	public RecordResolveException(RecordResolveContext context, string message)
		: this(context, message, null)
	{
	}

	/// <summary>
	/// 初始化异常
	/// </summary>
	/// <param name="context">数据记录解析上下文对象</param>
	/// <param name="innerException">引发本异常的内部异常</param>
	public RecordResolveException(RecordResolveContext context, Exception innerException)
		: this(context, string.Empty, innerException)
	{
	}

	/// <summary>
	/// 初始化异常
	/// </summary>
	/// <param name="context">数据记录解析上下文对象</param>
	/// <param name="message">异常信息</param>
	/// <param name="innerException">引发本异常的内部异常</param>
	public RecordResolveException(RecordResolveContext context, string message, Exception innerException)
		: base(message, innerException)
	{
		context.GuardNotNull("context");
		Context = context;
	}
}
