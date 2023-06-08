using System;
using Richfit.Garnet.Common.Extensions;

namespace Richfit.Garnet.Module.Importing.Aspose.Excel;

/// <summary>
/// 项目值验证异常类
/// </summary>
public class ValueValidateException : Exception
{
	/// <summary>
	/// 获取项目值解析上下文对象
	/// </summary>
	public ValueValidateContext Context { get; private set; }

	/// <summary>
	/// 初始化项目值验证异常类
	/// </summary>
	/// <param name="context">项目验证上下文对象</param>
	public ValueValidateException(ValueValidateContext context)
		: this(context, string.Empty, null)
	{
	}

	/// <summary>
	/// 初始化项目值验证异常
	/// </summary>
	/// <param name="context">项目验证上下文对象</param>
	/// <param name="message">异常信息</param>
	public ValueValidateException(ValueValidateContext context, string message)
		: this(context, message, null)
	{
	}

	/// <summary>
	/// 初始化项目值验证异常
	/// </summary>
	/// <param name="context">项目验证上下文对象</param>
	/// <param name="innerException">引发本异常的内部异常</param>
	public ValueValidateException(ValueValidateContext context, Exception innerException)
		: this(context, string.Empty, innerException)
	{
	}

	/// <summary>
	/// 初始化项目值验证异常
	/// </summary>
	/// <param name="context">项目验证上下文对象</param>
	/// <param name="message">异常信息</param>
	/// <param name="innerException">引发本异常的内部异常</param>
	public ValueValidateException(ValueValidateContext context, string message, Exception innerException)
		: base(message, innerException)
	{
		context.GuardNotNull("context");
		Context = context;
	}
}
