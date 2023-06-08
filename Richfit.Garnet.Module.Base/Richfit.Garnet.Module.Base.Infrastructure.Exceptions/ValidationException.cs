using System;
using System.Collections.Generic;
using Richfit.Garnet.Common.Extensions;

namespace Richfit.Garnet.Module.Base.Infrastructure.Exceptions;

/// <summary>
/// 自定义验证异常
/// </summary>
public class ValidationException : Exception
{
	private IEnumerable<string> validateMessages;

	private string validateCode;

	/// <summary>
	/// 验证错误消息
	/// </summary>
	public IEnumerable<string> ValidateMessages => validateMessages;

	/// <summary>
	/// 验证错误编码，如SystemManagement.Public.V_0009，注意必须是V_开始的形式
	/// </summary>
	public string ValidateCode
	{
		get
		{
			return validateCode;
		}
		set
		{
			validateCode = value;
		}
	}

	/// <summary>
	/// 构造异常对象
	/// </summary>
	/// <param name="validateCode">验证代码</param>
	public ValidationException(string validateCode)
	{
		this.validateCode = validateCode;
	}

	/// <summary>
	/// 构造异常对象
	/// </summary>
	/// <param name="validateMessages">验证信息</param>
	public ValidationException(IEnumerable<string> validateMessages)
	{
		this.validateMessages = validateMessages;
	}

	/// <summary>
	/// 构造异常对象
	/// </summary>
	/// <param name="validateCode">验证代码</param>
	/// <param name="validateMessages">验证信息</param>
	public ValidationException(string validateCode, IEnumerable<string> validateMessages)
	{
		this.validateCode = validateCode;
		this.validateMessages = validateMessages;
	}

	/// <summary>
	/// 验证消息字符串，分号分隔
	/// </summary>
	/// <returns></returns>
	public override string ToString()
	{
		if (validateMessages != null)
		{
			return validateMessages.JoinString(";");
		}
		return string.Empty;
	}
}
