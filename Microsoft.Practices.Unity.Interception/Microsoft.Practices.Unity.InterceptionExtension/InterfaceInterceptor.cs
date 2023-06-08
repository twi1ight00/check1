using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Practices.Unity.Utility;

namespace Microsoft.Practices.Unity.InterceptionExtension;

/// <summary>
/// An instance interceptor that works by generating a
/// proxy class on the fly for a single interface.
/// </summary>
public class InterfaceInterceptor : IInstanceInterceptor, IInterceptor
{
	private static readonly Dictionary<GeneratedTypeKey, Type> interceptorClasses = new Dictionary<GeneratedTypeKey, Type>(new GeneratedTypeKey.GeneratedTypeKeyComparer());

	/// <summary>
	/// Can this interceptor generate a proxy for the given type?
	/// </summary>
	/// <param name="t">Type to check.</param>
	/// <returns>True if interception is possible, false if not.</returns>
	public bool CanIntercept(Type t)
	{
		Guard.ArgumentNotNull(t, "t");
		return t.IsInterface;
	}

	/// <summary>
	/// Returns a sequence of methods on the given type that can be
	/// intercepted.
	/// </summary>
	/// <param name="interceptedType">Type that was specified when this interceptor
	/// was created (typically an interface).</param>
	/// <param name="implementationType">The concrete type of the implementing object.</param>
	/// <returns>Sequence of <see cref="T:System.Reflection.MethodInfo" /> objects.</returns>
	public IEnumerable<MethodImplementationInfo> GetInterceptableMethods(Type interceptedType, Type implementationType)
	{
		Guard.ArgumentNotNull(interceptedType, "interceptedType");
		Guard.ArgumentNotNull(implementationType, "implementationType");
		return DoGetInterceptableMethods(interceptedType, implementationType);
	}

	private IEnumerable<MethodImplementationInfo> DoGetInterceptableMethods(Type interceptedType, Type implementationType)
	{
		if (interceptedType.IsInterface && implementationType.IsInterface && interceptedType.IsAssignableFrom(implementationType))
		{
			MethodInfo[] methods = interceptedType.GetMethods();
			for (int j = 0; j < methods.Length; j++)
			{
				yield return new MethodImplementationInfo(methods[j], methods[j]);
			}
		}
		else
		{
			InterfaceMapping mapping = implementationType.GetInterfaceMap(interceptedType);
			for (int i = 0; i < mapping.InterfaceMethods.Length; i++)
			{
				yield return new MethodImplementationInfo(mapping.InterfaceMethods[i], mapping.TargetMethods[i]);
			}
		}
		try
		{
			Type[] interfaces = interceptedType.GetInterfaces();
			foreach (Type type in interfaces)
			{
				foreach (MethodImplementationInfo item in DoGetInterceptableMethods(type, implementationType))
				{
					yield return item;
				}
			}
		}
		finally
		{
		}
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
		Guard.ArgumentNotNull(additionalInterfaces, "additionalInterfaces");
		Type type = t;
		bool flag = false;
		if (t.IsGenericType)
		{
			type = t.GetGenericTypeDefinition();
			flag = true;
		}
		GeneratedTypeKey key = new GeneratedTypeKey(type, additionalInterfaces);
		Type value;
		lock (interceptorClasses)
		{
			if (!interceptorClasses.TryGetValue(key, out value))
			{
				InterfaceInterceptorClassGenerator interfaceInterceptorClassGenerator = new InterfaceInterceptorClassGenerator(type, additionalInterfaces);
				value = interfaceInterceptorClassGenerator.CreateProxyType();
				interceptorClasses[key] = value;
			}
		}
		if (flag)
		{
			value = value.MakeGenericType(t.GetGenericArguments());
		}
		return (IInterceptingProxy)value.GetConstructors()[0].Invoke(new object[2] { target, t });
	}
}
