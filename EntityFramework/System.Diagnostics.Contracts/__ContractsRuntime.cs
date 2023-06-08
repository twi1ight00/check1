using System.Diagnostics.Contracts.Internal;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;

namespace System.Diagnostics.Contracts;

[CompilerGenerated]
internal static class __ContractsRuntime
{
	[CompilerGenerated]
	private class ContractException : Exception
	{
		private ContractFailureKind _Kind;

		private string _UserMessage;

		private string _Condition;

		ContractException(ContractFailureKind kind, string failure, string usermsg, string condition, Exception inner)
			: base(failure, inner)
		{
			_Kind = kind;
			_UserMessage = usermsg;
			_Condition = condition;
		}
	}

	[ThreadStatic]
	internal static int insideContractEvaluation;

	[DebuggerNonUserCode]
	[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
	internal static void Requires<TException>(bool condition, string msg, string conditionTxt) where TException : Exception
	{
		if (condition)
		{
			return;
		}
		string text = System.Diagnostics.Contracts.Internal.ContractHelper.RaiseContractFailedEvent(ContractFailureKind.Precondition, msg, conditionTxt, null);
		Exception ex = null;
		ConstructorInfo constructor = typeof(TException).GetConstructor(new Type[2]
		{
			typeof(string),
			typeof(string)
		});
		if ((object)constructor != null)
		{
			ex = ((!(constructor.GetParameters()[0].Name == "paramName")) ? (constructor.Invoke(new object[2] { text, msg }) as Exception) : (constructor.Invoke(new object[2] { msg, text }) as Exception));
		}
		else
		{
			constructor = typeof(TException).GetConstructor(new Type[1] { typeof(string) });
			if ((object)constructor != null)
			{
				ex = constructor.Invoke(new object[1] { text }) as Exception;
			}
		}
		if (ex == null)
		{
			throw new ArgumentException(text, msg);
		}
		throw ex;
	}

	internal static void ReportFailure(ContractFailureKind kind, string msg, string conditionTxt, Exception inner)
	{
		string text = System.Diagnostics.Contracts.Internal.ContractHelper.RaiseContractFailedEvent(kind, msg, conditionTxt, inner);
		if (text != null)
		{
			TriggerFailure(kind, text, msg, conditionTxt, inner);
		}
	}

	internal static void TriggerFailure(ContractFailureKind kind, string msg, string userMessage, string conditionTxt, Exception inner)
	{
		throw new ContractException(kind, msg, userMessage, conditionTxt, inner);
	}

	[DebuggerNonUserCode]
	[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
	internal static void Assert(bool condition, string msg, string conditionTxt)
	{
		if (!condition)
		{
			ReportFailure(ContractFailureKind.Assert, msg, conditionTxt, null);
		}
	}
}
