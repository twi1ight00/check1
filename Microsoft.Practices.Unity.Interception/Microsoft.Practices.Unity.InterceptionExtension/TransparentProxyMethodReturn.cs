using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Security;
using System.Security.Permissions;

namespace Microsoft.Practices.Unity.InterceptionExtension;

/// <summary>
/// An implementation of <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.IMethodReturn" /> that wraps the
/// remoting call and return messages.
/// </summary>
[SecurityCritical(SecurityCriticalScope.Everything)]
[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.Infrastructure)]
internal class TransparentProxyMethodReturn : IMethodReturn
{
	private readonly IMethodCallMessage callMessage;

	private readonly ParameterCollection outputs;

	private readonly IDictionary<string, object> invocationContext;

	private readonly object[] arguments;

	private object returnValue;

	private Exception exception;

	/// <summary>
	/// The collection of output parameters. If the method has no output
	/// parameters, this is a zero-length list (never null).
	/// </summary>
	/// <value>The output parameter collection.</value>
	public IParameterCollection Outputs => outputs;

	/// <summary>
	/// Return value from the method call.
	/// </summary>
	/// <remarks>This value is null if the method has no return value.</remarks>
	/// <value>The return value.</value>
	public object ReturnValue
	{
		get
		{
			return returnValue;
		}
		set
		{
			returnValue = value;
		}
	}

	/// <summary>
	/// If the method threw an exception, the exception object is here.
	/// </summary>
	/// <value>The exception, or null if no exception was thrown.</value>
	public Exception Exception
	{
		get
		{
			return exception;
		}
		set
		{
			exception = value;
		}
	}

	/// <summary>
	/// Retrieves a dictionary that can be used to store arbitrary additional
	/// values. This allows the user to pass values between call handlers.
	/// </summary>
	/// <remarks>This is guaranteed to be the same dictionary that was used
	/// in the IMethodInvocation object, so handlers can set context
	/// properties in the pre-call phase and retrieve them in the after-call phase.
	/// </remarks>
	/// <value>The invocation context dictionary.</value>
	public IDictionary<string, object> InvocationContext => invocationContext;

	/// <summary>
	/// Creates a new <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.TransparentProxyMethodReturn" /> object that contains a
	/// return value.
	/// </summary>
	/// <param name="callMessage">The original call message that invoked the method.</param>
	/// <param name="returnValue">Return value from the method.</param>
	/// <param name="arguments">Collections of arguments passed to the method (including the new
	/// values of any out params).</param>
	/// <param name="invocationContext">Invocation context dictionary passed into the call.</param>
	public TransparentProxyMethodReturn(IMethodCallMessage callMessage, object returnValue, object[] arguments, IDictionary<string, object> invocationContext)
	{
		this.callMessage = callMessage;
		this.invocationContext = invocationContext;
		this.arguments = arguments;
		this.returnValue = returnValue;
		outputs = new TransparentProxyOutputParameterCollection(callMessage, arguments);
	}

	/// <summary>
	/// Creates a new <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.TransparentProxyMethodReturn" /> object that contains an
	/// exception thrown by the target.
	/// </summary>
	/// <param name="ex">Exception that was thrown.</param>
	/// <param name="callMessage">The original call message that invoked the method.</param>
	/// <param name="invocationContext">Invocation context dictionary passed into the call.</param>
	public TransparentProxyMethodReturn(Exception ex, IMethodCallMessage callMessage, IDictionary<string, object> invocationContext)
	{
		this.callMessage = callMessage;
		this.invocationContext = invocationContext;
		exception = ex;
		arguments = new object[0];
		outputs = new ParameterCollection(arguments, new ParameterInfo[0], (ParameterInfo pi) => false);
	}

	/// <summary>
	/// Constructs a <see cref="T:System.Runtime.Remoting.Messaging.IMethodReturnMessage" /> for the remoting
	/// infrastructure based on the contents of this object.
	/// </summary>
	/// <returns>The <see cref="T:System.Runtime.Remoting.Messaging.IMethodReturnMessage" /> instance.</returns>
	public IMethodReturnMessage ToMethodReturnMessage()
	{
		if (exception == null)
		{
			return new ReturnMessage(returnValue, arguments, arguments.Length, callMessage.LogicalCallContext, callMessage);
		}
		return new ReturnMessage(exception, callMessage);
	}
}
