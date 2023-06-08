using System;
using Richfit.Garnet.Common.Extensions;

namespace Richfit.Garnet.Module.Importing.Aspose.Excel;

/// <summary>
/// 数据记录验证异常
/// </summary>
public class RecordValidateException : Exception
{
	/// <summary>
	/// 获取数据记录验证上下文
	/// </summary>
	public RecordValidateContext Context { get; private set; }

	/// <summary>
	/// 初始化异常
	/// </summary>
	/// <param name="context">数据记录验证上下文</param>
	public RecordValidateException(RecordValidateContext context)
		: this(context, string.Empty, null)
	{
	}

	/// <summary>
	/// 初始化异常
	/// </summary>
	/// <param name="context">数据记录验证上下文</param>
	/// <param name="message">异常信息</param>
	public RecordValidateException(RecordValidateContext context, string message)
		: this(context, message, null)
	{
	}

	/// <summary>
	/// 初始化异常
	/// </summary>
	/// <param name="context">数据记录验证上下文</param>
	/// <param name="innerException">引发本异常的内部异常</param>
	public RecordValidateException(RecordValidateContext context, Exception innerException)
		: this(context, string.Empty, innerException)
	{
	}

	/// <summary>
	/// 初始化异常
	/// </summary>
	/// <param name="context">数据记录验证上下文</param>
	/// <param name="message">异常信息</param>
	/// <param name="innerException">引发本异常的内部异常</param>
	public RecordValidateException(RecordValidateContext context, string message, Exception innerException)
		: base(message, innerException)
	{
		context.GuardNotNull("context");
		Context = context;
	}
}
