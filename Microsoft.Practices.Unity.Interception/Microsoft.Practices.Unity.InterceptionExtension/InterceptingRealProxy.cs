using System;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;
using System.Security;
using System.Security.Permissions;
using Microsoft.Practices.Unity.InterceptionExtension.Properties;
using Microsoft.Practices.Unity.Utility;

namespace Microsoft.Practices.Unity.InterceptionExtension;

/// <summary>
/// This class provides the remoting-based interception mechanism. It is
/// invoked by a call on the corresponding TransparentProxy
/// object. It routes calls through the handlers as appropriate.
/// </summary>
[SecurityCritical(SecurityCriticalScope.Everything)]
[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.Infrastructure)]
public class InterceptingRealProxy : RealProxy, IRemotingTypeInfo, IInterceptingProxy
{
	private readonly InterceptionBehaviorPipeline interceptorsPipeline = new InterceptionBehaviorPipeline();

	private readonly object target;

	private readonly ReadOnlyCollection<Type> additionalInterfaces;

	private string typeName;

	/// <summary>
	/// Returns the target of this intercepted call.
	/// </summary>
	/// <value>The target object.</value>
	public object Target => target;

	/// <summary>
	/// Gets or sets the fully qualified type name of the server object in a <see cref="T:System.Runtime.Remoting.ObjRef"></see>.
	/// </summary>
	///
	/// <value>
	/// The fully qualified type name of the server object in a <see cref="T:System.Runtime.Remoting.ObjRef"></see>.
	/// </value>
	///
	/// <exception cref="T:System.Security.SecurityException">The immediate caller makes the call through a reference to the interface and does not have infrastructure permission. </exception><PermissionSet><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="Infrastructure" /></PermissionSet>
	public string TypeName
	{
		[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.Infrastructure)]
		get
		{
			return typeName;
		}
		[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.Infrastructure)]
		set
		{
			typeName = value;
		}
	}

	/// <summary>
	/// Creates a new <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.InterceptingRealProxy" /> instance that applies
	/// the given policies to the given target object.
	/// </summary>
	/// <param name="target">Target object to intercept calls to.</param>
	/// <param name="classToProxy">Type to return as the type being proxied.</param>
	/// <param name="additionalInterfaces">Additional interfaces the proxy must implement.</param>
	public InterceptingRealProxy(object target, Type classToProxy, params Type[] additionalInterfaces)
		: base(classToProxy)
	{
		Guard.ArgumentNotNull(target, "target");
		this.target = target;
		this.additionalInterfaces = CheckAdditionalInterfaces(additionalInterfaces);
		typeName = target.GetType().FullName;
	}

	private static ReadOnlyCollection<Type> CheckAdditionalInterfaces(Type[] interfaces)
	{
		return new ReadOnlyCollection<Type>(interfaces);
	}

	/// <summary>
	/// Adds a <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.IInterceptionBehavior" /> to the proxy.
	/// </summary>
	/// <param name="interceptor">The <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.IInterceptionBehavior" /> to add.</param>
	public void AddInterceptionBehavior(IInterceptionBehavior interceptor)
	{
		Guard.ArgumentNotNull(interceptor, "interceptor");
		interceptorsPipeline.Add(interceptor);
	}

	/// <summary>
	/// Checks whether the proxy that represents the specified object type can be cast to the type represented by the <see cref="T:System.Runtime.Remoting.IRemotingTypeInfo"></see> interface.
	/// </summary>
	///
	/// <returns>
	/// true if cast will succeed; otherwise, false.
	/// </returns>
	///
	/// <param name="fromType">The type to cast to. </param>
	/// <param name="o">The object for which to check casting. </param>
	/// <exception cref="T:System.Security.SecurityException">The immediate caller makes the call through a reference to the interface and does not have infrastructure permission. </exception>
	[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.Infrastructure)]
	public bool CanCastTo(Type fromType, object o)
	{
		Guard.ArgumentNotNull(fromType, "fromType");
		Guard.ArgumentNotNull(o, "o");
		if (fromType == typeof(IInterceptingProxy))
		{
			return true;
		}
		if (fromType.IsAssignableFrom(o.GetType()))
		{
			return true;
		}
		foreach (Type additionalInterface in additionalInterfaces)
		{
			if (fromType.IsAssignableFrom(additionalInterface))
			{
				return true;
			}
		}
		return false;
	}

	/// <summary>
	/// Executes a method call represented by the <paramref name="msg" />
	/// parameter. The CLR will call this method when a method is called
	/// on the TransparentProxy. This method runs the invocation through
	/// the call handler pipeline and finally sends it down to the
	/// target object, and then back through the pipeline. 
	/// </summary>
	/// <param name="msg">An <see cref="T:System.Runtime.Remoting.Messaging.IMessage" /> object that contains the information
	/// about the method call.</param>
	/// <returns>An <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.TransparentProxyMethodReturn" /> object contains the
	/// information about the target method's return value.</returns>
	[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.Infrastructure)]
	public override IMessage Invoke(IMessage msg)
	{
		Guard.ArgumentNotNull(msg, "msg");
		IMethodCallMessage callMessage = (IMethodCallMessage)msg;
		if (callMessage.MethodBase.DeclaringType == typeof(IInterceptingProxy))
		{
			return HandleInterceptingProxyMethod(callMessage);
		}
		TransparentProxyMethodInvocation invocation = new TransparentProxyMethodInvocation(callMessage, target);
		IMethodReturn methodReturn = interceptorsPipeline.Invoke(invocation, delegate(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
		{
			if (callMessage.MethodBase.DeclaringType.IsAssignableFrom(target.GetType()))
			{
				try
				{
					object returnValue = callMessage.MethodBase.Invoke(target, invocation.Arguments);
					return input.CreateMethodReturn(returnValue, invocation.Arguments);
				}
				catch (TargetInvocationException ex)
				{
					return input.CreateExceptionMethodReturn(ex.InnerException);
				}
			}
			return input.CreateExceptionMethodReturn(new InvalidOperationException(Resources.ExceptionAdditionalInterfaceNotImplemented));
		});
		return ((TransparentProxyMethodReturn)methodReturn).ToMethodReturnMessage();
	}

	private IMessage HandleInterceptingProxyMethod(IMethodCallMessage callMessage)
	{
		string methodName;
		if ((methodName = callMessage.MethodName) != null && methodName == "AddInterceptionBehavior")
		{
			return ExecuteAddInterceptionBehavior(callMessage);
		}
		throw new InvalidOperationException();
	}

	private IMessage ExecuteAddInterceptionBehavior(IMethodCallMessage callMessage)
	{
		IInterceptionBehavior interceptor = (IInterceptionBehavior)callMessage.InArgs[0];
		AddInterceptionBehavior(interceptor);
		return new ReturnMessage(null, new object[0], 0, callMessage.LogicalCallContext, callMessage);
	}
}
