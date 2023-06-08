using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Remoting.Proxies;
using System.Security;
using System.Security.Permissions;
using Microsoft.Practices.Unity.Utility;

namespace Microsoft.Practices.Unity.InterceptionExtension;

/// <summary>
/// An instance interceptor that uses remoting proxies to do the
/// interception.
/// </summary>
[SecurityCritical(SecurityCriticalScope.Everything)]
[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.Infrastructure)]
public class TransparentProxyInterceptor : IInstanceInterceptor, IInterceptor
{
	/// <summary>
	/// Can this interceptor generate a proxy for the given type?
	/// </summary>
	/// <param name="t">Type to check.</param>
	/// <returns>True if interception is possible, false if not.</returns>
	public bool CanIntercept(Type t)
	{
		Guard.ArgumentNotNull(t, "t");
		if (!typeof(MarshalByRefObject).IsAssignableFrom(t))
		{
			return t.IsInterface;
		}
		return true;
	}

	/// <summary>
	/// Returns a sequence of methods on the given type that can be
	/// intercepted.
	/// </summary>
	/// <param name="interceptedType">The intercepted type.</param>
	/// <param name="implementationType">The concrete type of the implementing object.</param>
	/// <returns>Sequence of <see cref="T:System.Reflection.MethodInfo" /> objects.</returns>
	public IEnumerable<MethodImplementationInfo> GetInterceptableMethods(Type interceptedType, Type implementationType)
	{
		if (typeof(MarshalByRefObject).IsAssignableFrom(implementationType))
		{
			return GetMBROMethods(implementationType);
		}
		return GetImplementedInterfaceMethods(implementationType);
	}

	private static IEnumerable<MethodImplementationInfo> GetMBROMethods(Type t)
	{
		Dictionary<MethodInfo, bool> haveSeenMethod = new Dictionary<MethodInfo, bool>();
		foreach (MethodImplementationInfo methodImpl in GetImplementedInterfaceMethods(t))
		{
			haveSeenMethod[methodImpl.ImplementationMethodInfo] = true;
			yield return methodImpl;
		}
		try
		{
			MethodInfo[] methods = t.GetMethods();
			foreach (MethodInfo method in methods)
			{
				if (IsNotSystemMethod(method) && !haveSeenMethod.ContainsKey(method))
				{
					yield return new MethodImplementationInfo(null, method);
				}
			}
		}
		finally
		{
		}
	}

	private static IEnumerable<MethodImplementationInfo> GetImplementedInterfaceMethods(Type t)
	{
		try
		{
			Type[] interfaces = t.GetInterfaces();
			foreach (Type itf in interfaces)
			{
				InterfaceMapping mapping = t.GetInterfaceMap(itf);
				for (int i = 0; i < mapping.InterfaceMethods.Length; i++)
				{
					yield return new MethodImplementationInfo(mapping.InterfaceMethods[i], mapping.TargetMethods[i]);
				}
			}
		}
		finally
		{
		}
	}

	private static bool IsNotSystemMethod(MethodInfo method)
	{
		if (method.DeclaringType != typeof(MarshalByRefObject))
		{
			return method.DeclaringType != typeof(object);
		}
		return false;
	}

	/// <summary>
	/// Create a proxy object that provides interception for <paramref name="target" />.
	/// </summary>
	/// <param name="t">Type to generate the proxy of.</param>
	/// <param name="target">Object to create the proxy for.</param>
	/// <param name="additionalInterfaces">Additional interfaces the proxy must implement.</param>
	/// <returns>The proxy object.</returns>
	public IInterceptingProxy CreateProxy(Type t, object target, params Type[] additionalInterfaces)
	{
		Guard.ArgumentNotNull(t, "t");
		Guard.ArgumentNotNull(target, "target");
		RealProxy realProxy = new InterceptingRealProxy(target, t, additionalInterfaces);
		return (IInterceptingProxy)realProxy.GetTransparentProxy();
	}
}
