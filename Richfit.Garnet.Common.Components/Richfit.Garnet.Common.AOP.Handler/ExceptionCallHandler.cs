using System;
using System.Collections;
using System.Reflection;
using System.Text;
using Microsoft.Practices.Unity.InterceptionExtension;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.Logging;

namespace Richfit.Garnet.Common.AOP.Handler;

/// <summary>
/// 用于异常拦截的特性驱动拦截处理器
/// </summary>
public class ExceptionCallHandler : ICallHandler
{
	/// <summary>
	/// 获取或者设置异常编码
	/// </summary>
	public string ExceptionCode { get; set; }

	/// <summary>
	/// 获取或者设置处理器执行顺序
	/// </summary>
	public int Order { get; set; }

	/// <summary>
	/// 初始化拦截处理器
	/// </summary>
	public ExceptionCallHandler()
	{
	}

	/// <summary>
	/// 指定异常编码初始化拦截处理器
	/// </summary>
	/// <param name="exceptionCode">异常编码</param>
	public ExceptionCallHandler(string exceptionCode)
	{
		ExceptionCode = exceptionCode;
	}

	/// <summary>
	/// 调用被拦截的方法
	/// </summary>
	/// <param name="input">调用参数</param>
	/// <param name="getNext">调用队列委托</param>
	/// <returns>调用结果</returns>
	public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
	{
		return Invoke(input, getNext, ExceptionCode);
	}

	/// <summary>
	/// 调用被拦截的方法
	/// </summary>
	/// <param name="input">调用参数</param>
	/// <param name="getNext">调用队列委托</param>
	/// <param name="exceptionCode">调用异常编码</param>
	/// <returns>调用结果</returns>
	public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext, string exceptionCode)
	{
		IMethodReturn result = getNext()(input, getNext);
		if (result.Exception != null)
		{
			StringBuilder message = new StringBuilder();
			message.AppendLine();
			message.AppendLine("Exception occured: " + ((Exception)(object)result.Exception).Message);
			message.AppendLine("Error Code: " + exceptionCode);
			message.AppendLine("StackTrace: ");
			message.AppendLine(((Exception)(object)result.Exception).StackTrace);
			message.Append("Invoke Method: ").Append(((MemberInfo)(object)input.MethodBase).Name).Append("@")
				.AppendLine(((MemberInfo)(object)input.MethodBase).DeclaringType.AssemblyQualifiedName);
			message.AppendLine("Parameters: ");
			for (int i = 0; i < ((ICollection)input.Arguments).Count; i++)
			{
				message.Append("[").Append(i).Append("]")
					.Append(((ParameterInfo)(object)input.Arguments.GetParameterInfo(i)).Name)
					.Append(":")
					.Append(((IList)input.Arguments)[i])
					.AppendLine();
			}
			ILogger log = LoggerManager.GetLogger("Exception");
			log.Error(message.ToString());
			throw new CustomCodeException(exceptionCode.IfNull(string.Empty), (Exception)(object)result.Exception);
		}
		return result;
	}
}
