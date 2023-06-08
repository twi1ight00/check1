using System;

namespace Richfit.Garnet.Common.AOP.Handler;

/// <summary>
/// 自定义错误代码的Exception
/// </summary>
public class CustomCodeException : Exception
{
	/// <summary>
	/// 错误代码，用于多语翻译的key值
	/// </summary>
	public string ErrorCode { get; private set; }

	/// <summary>
	/// 触发自定义异常的内部异常
	/// </summary>
	public Exception Exception { get; set; }

	/// <summary>
	/// 初始化自定义错误实例，只有异常编码
	/// </summary>
	/// <param name="exceptionCode"></param>
	public CustomCodeException(string exceptionCode)
	{
		ErrorCode = ((exceptionCode == null) ? string.Empty : exceptionCode);
		Exception = new Exception();
	}

	/// <summary>
	/// 初始化自定义错误实例
	/// </summary>
	/// <param name="exceptionCode">异常编码</param>
	/// <param name="innerException">触发自定义异常的内部异常</param>
	public CustomCodeException(string exceptionCode, Exception innerException)
	{
		ErrorCode = ((exceptionCode == null) ? string.Empty : exceptionCode);
		Exception = innerException;
	}

	/// <summary>
	/// 输出自定义异常
	/// </summary>
	/// <returns></returns>
	public override string ToString()
	{
		return $"Error Code: {ErrorCode}." + Environment.NewLine + base.ToString();
	}
}
