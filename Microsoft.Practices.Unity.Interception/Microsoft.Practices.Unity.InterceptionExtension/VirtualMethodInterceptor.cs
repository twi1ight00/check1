using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using Microsoft.Practices.Unity.InterceptionExtension.Properties;
using Microsoft.Practices.Unity.Utility;

namespace Microsoft.Practices.Unity.InterceptionExtension;

/// <summary>
/// A type based interceptor that works by generated a new class
/// on the fly that derives from the target class.
/// </summary>
public class VirtualMethodInterceptor : ITypeInterceptor, IInterceptor
{
	private static readonly Dictionary<GeneratedTypeKey, Type> derivedClasses = new Dictionary<GeneratedTypeKey, Type>(new GeneratedTypeKey.GeneratedTypeKeyComparer());

	/// <summary>
	/// Can this interceptor generate a proxy for the given type?
	/// </summary>
	/// <param name="t">Type to check.</param>
	/// <returns>True if interception is possible, false if not.</returns>
	public bool CanIntercept(Type t)
	{
		Guard.ArgumentNotNull(t, "t");
		if (t.IsClass && (t.IsPublic || t.IsNestedPublic) && t.IsVisible)
		{
			return !t.IsSealed;
		}
		return false;
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
		Guard.ArgumentNotNull(implementationType, "implementationType");
		return DoGetInterceptableMethods(interceptedType, implementationType);
	}

	private IEnumerable<MethodImplementationInfo> DoGetInterceptableMethods(Type interceptedType, Type implementationType)
	{
		Dictionary<MethodInfo, MethodInfo> interceptableMethodsToInterfaceMap = new Dictionary<MethodInfo, MethodInfo>();
		MethodInfo[] methods = implementationType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		foreach (MethodInfo methodInfo in methods)
		{
			if (MethodOverride.MethodCanBeIntercepted(methodInfo))
			{
				interceptableMethodsToInterfaceMap[methodInfo] = null;
			}
		}
		Type[] interfaces = implementationType.GetInterfaces();
		foreach (Type interfaceType in interfaces)
		{
			InterfaceMapping interfaceMap = implementationType.GetInterfaceMap(interfaceType);
			for (int k = 0; k < interfaceMap.InterfaceMethods.Length; k++)
			{
				if (interceptableMethodsToInterfaceMap.ContainsKey(interfaceMap.TargetMethods[k]))
				{
					interceptableMethodsToInterfaceMap[interfaceMap.TargetMethods[k]] = interfaceMap.InterfaceMethods[k];
				}
			}
		}
		foreach (KeyValuePair<MethodInfo, MethodInfo> kvp in interceptableMethodsToInterfaceMap)
		{
			KeyValuePair<MethodInfo, MethodInfo> keyValuePair = kvp;
			MethodInfo value = keyValuePair.Value;
			KeyValuePair<MethodInfo, MethodInfo> keyValuePair2 = kvp;
			yield return new MethodImplementationInfo(value, keyValuePair2.Key);
		}
	}

	/// <summary>
	/// Create a type to proxy for the given type <paramref name="t" />.
	/// </summary>
	/// <param name="t">Type to proxy.</param>
	/// <param name="additionalInterfaces">Additional interfaces the proxy must implement.</param>
	/// <returns>New type that can be instantiated instead of the
	/// original type t, and supports interception.</returns>
	public Type CreateProxyType(Type t, params Type[] additionalInterfaces)
	{
		Guard.ArgumentNotNull(t, "t");
		Guard.ArgumentNotNull(additionalInterfaces, "additionalInterfaces");
		if (!CanIntercept(t))
		{
			throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources.InterceptionNotSupported, t.Name));
		}
		Type type = t;
		bool flag = false;
		if (t.IsGenericType)
		{
			type = t.GetGenericTypeDefinition();
			flag = true;
		}
		GeneratedTypeKey key = new GeneratedTypeKey(type, additionalInterfaces);
		Type value;
		lock (derivedClasses)
		{
			if (!derivedClasses.TryGetValue(key, out value))
			{
				InterceptingClassGenerator interceptingClassGenerator = new InterceptingClassGenerator(type, additionalInterfaces);
				value = interceptingClassGenerator.GenerateType();
				derivedClasses[key] = value;
			}
		}
		if (flag)
		{
			value = value.MakeGenericType(t.GetGenericArguments());
		}
		return value;
	}
}
