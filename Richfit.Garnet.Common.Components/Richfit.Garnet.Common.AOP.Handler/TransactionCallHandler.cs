using System;
using System.Collections;
using System.Reflection;
using System.Text;
using System.Transactions;
using Microsoft.Practices.Unity.InterceptionExtension;
using Richfit.Garnet.Common.Logging;

namespace Richfit.Garnet.Common.AOP.Handler;

/// <summary>
/// 用于事务拦截的特性驱动的拦截处理器
/// </summary>
public class TransactionCallHandler : ICallHandler
{
	/// <summary>
	/// 获取或者设置处理器执行顺序
	/// </summary>
	public int Order { get; set; }

	/// <summary>
	/// 初始化事务拦截处理器
	/// </summary>
	public TransactionCallHandler()
	{
	}

	/// <summary>
	/// 调用被拦截的方法
	/// </summary>
	/// <param name="input">调用参数</param>
	/// <param name="getNext">调用队列委托</param>
	/// <returns>调用结果</returns>
	public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
	{
		using TransactionScope ts = new TransactionScope(TransactionScopeOption.Required);
		try
		{
			IMethodReturn result = getNext()(input, getNext);
			if (result.Exception == null)
			{
				ts.Complete();
			}
			else
			{
				ts.Dispose();
			}
			return result;
		}
		catch (Exception ex)
		{
			StringBuilder message = new StringBuilder();
			message.AppendLine("Exception occured: " + ex.Message);
			message.AppendLine("StackTrace: ");
			message.AppendLine(ex.StackTrace);
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
			throw ex;
		}
	}
}
