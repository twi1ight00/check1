using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.Practices.Unity.InterceptionExtension.Properties;
using Microsoft.Practices.Unity.Utility;

namespace Microsoft.Practices.Unity.InterceptionExtension;

/// <summary>
/// High-level API for performing interception on existing and new objects.
/// </summary>
public static class Intercept
{
	/// <summary>
	/// Returns a <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.IInterceptingProxy" /> for type <typeparamref name="T" /> which wraps 
	/// the supplied <paramref name="target" />.
	/// </summary>
	/// <typeparam name="T">The type to intercept.</typeparam>
	/// <param name="target">The instance to intercept.</param>
	/// <param name="interceptor">The <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.IInstanceInterceptor" /> to use when creating the proxy.</param>
	/// <param name="interceptionBehaviors">The interception behaviors for the new proxy.</param>
	/// <param name="additionalInterfaces">Any additional interfaces the proxy must implement.</param>
	/// <returns>A proxy for <paramref name="target" /> compatible with <typeparamref name="T" />.</returns>
	/// <exception cref="T:System.ArgumentNullException">when <paramref name="target" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.ArgumentNullException">when <paramref name="interceptor" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.ArgumentNullException">when <paramref name="interceptionBehaviors" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.ArgumentNullException">when <paramref name="additionalInterfaces" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.ArgumentException">when <paramref name="interceptor" /> cannot intercept 
	/// <typeparamref name="T" />.</exception>
	public static T ThroughProxyWithAdditionalInterfaces<T>(T target, IInstanceInterceptor interceptor, IEnumerable<IInterceptionBehavior> interceptionBehaviors, IEnumerable<Type> additionalInterfaces) where T : class
	{
		return (T)ThroughProxyWithAdditionalInterfaces(typeof(T), target, interceptor, interceptionBehaviors, additionalInterfaces);
	}

	/// <summary>
	/// Returns a <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.IInterceptingProxy" /> for type <typeparamref name="T" /> which wraps
	/// the supplied <paramref name="target" />.
	/// </summary>
	/// <typeparam name="T">Type to intercept.</typeparam>
	/// <param name="target">The instance to intercept.</param>
	/// <param name="interceptor">The <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.IInstanceInterceptor" /> to use when creating the proxy.</param>
	/// <param name="interceptionBehaviors">The interception behaviors for the new proxy.</param>
	/// <returns>A proxy for <paramref name="target" /> compatible with <typeparamref name="T" />.</returns>
	/// <exception cref="T:System.ArgumentNullException">when <paramref name="target" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.ArgumentNullException">when <paramref name="interceptor" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.ArgumentNullException">when <paramref name="interceptionBehaviors" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.ArgumentException">when <paramref name="interceptor" /> cannot intercept 
	/// <typeparamref name="T" />.</exception>
	public static T ThroughProxy<T>(T target, IInstanceInterceptor interceptor, IEnumerable<IInterceptionBehavior> interceptionBehaviors) where T : class
	{
		return (T)ThroughProxyWithAdditionalInterfaces(typeof(T), target, interceptor, interceptionBehaviors, Type.EmptyTypes);
	}

	/// <summary>
	/// Returns a <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.IInterceptingProxy" /> for type <paramref name="interceptedType" /> which wraps 
	/// the supplied <paramref name="target" />.
	/// </summary>
	/// <param name="interceptedType">The type to intercept.</param>
	/// <param name="target">The instance to intercept.</param>
	/// <param name="interceptor">The <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.IInstanceInterceptor" /> to use when creating the proxy.</param>
	/// <param name="interceptionBehaviors">The interception behaviors for the new proxy.</param>
	/// <param name="additionalInterfaces">Any additional interfaces the proxy must implement.</param>
	/// <returns>A proxy for <paramref name="target" /> compatible with <paramref name="interceptedType" />.</returns>
	/// <exception cref="T:System.ArgumentNullException">when <paramref name="interceptedType" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.ArgumentNullException">when <paramref name="target" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.ArgumentNullException">when <paramref name="interceptor" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.ArgumentNullException">when <paramref name="interceptionBehaviors" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.ArgumentNullException">when <paramref name="additionalInterfaces" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.ArgumentException">when <paramref name="interceptor" /> cannot intercept 
	/// <paramref name="interceptedType" />.</exception>
	public static object ThroughProxyWithAdditionalInterfaces(Type interceptedType, object target, IInstanceInterceptor interceptor, IEnumerable<IInterceptionBehavior> interceptionBehaviors, IEnumerable<Type> additionalInterfaces)
	{
		Guard.ArgumentNotNull(interceptedType, "interceptedType");
		Guard.ArgumentNotNull(target, "target");
		Guard.ArgumentNotNull(interceptor, "interceptor");
		Guard.ArgumentNotNull(interceptionBehaviors, "interceptionBehaviors");
		Guard.ArgumentNotNull(additionalInterfaces, "additionalInterfaces");
		if (!interceptor.CanIntercept(interceptedType))
		{
			throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.InterceptionNotSupported, interceptedType.FullName), "interceptedType");
		}
		List<IInterceptionBehavior> source = interceptionBehaviors.ToList();
		if (source.Where((IInterceptionBehavior ib) => ib == null).Count() > 0)
		{
			throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.NullBehavior), "interceptionBehaviors");
		}
		List<IInterceptionBehavior> list = source.Where((IInterceptionBehavior ib) => ib.WillExecute).ToList();
		List<Type> list2 = GetAllAdditionalInterfaces(list, additionalInterfaces).ToList();
		if (list.Count == 0 && list2.Count == 0)
		{
			return target;
		}
		IInterceptingProxy interceptingProxy = interceptor.CreateProxy(interceptedType, target, list2.ToArray());
		foreach (IInterceptionBehavior item in list)
		{
			interceptingProxy.AddInterceptionBehavior(item);
		}
		return interceptingProxy;
	}

	/// <summary>
	/// Returns a <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.IInterceptingProxy" /> for type <paramref name="interceptedType" /> which wraps 
	/// the supplied <paramref name="target" />.
	/// </summary>
	/// <param name="interceptedType">The type to intercept.</param>
	/// <param name="target">The instance to intercept.</param>
	/// <param name="interceptor">The <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.IInstanceInterceptor" /> to use when creating the proxy.</param>
	/// <param name="interceptionBehaviors">The interception behaviors for the new proxy.</param>
	/// <returns>A proxy for <paramref name="target" /> compatible with <paramref name="interceptedType" />.</returns>
	/// <exception cref="T:System.ArgumentNullException">when <paramref name="interceptedType" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.ArgumentNullException">when <paramref name="target" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.ArgumentNullException">when <paramref name="interceptor" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.ArgumentNullException">when <paramref name="interceptionBehaviors" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.ArgumentException">when <paramref name="interceptor" /> cannot intercept 
	/// <paramref name="interceptedType" />.</exception>
	public static object ThroughProxy(Type interceptedType, object target, IInstanceInterceptor interceptor, IEnumerable<IInterceptionBehavior> interceptionBehaviors)
	{
		return ThroughProxyWithAdditionalInterfaces(interceptedType, target, interceptor, interceptionBehaviors, Type.EmptyTypes);
	}

	/// <summary>
	/// Creates a new instance of type <typeparamref name="T" /> that is intercepted with the behaviors in 
	/// <paramref name="interceptionBehaviors" />.
	/// </summary>
	/// <typeparam name="T">The type of the object to create.</typeparam>
	/// <param name="interceptor">The <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.ITypeInterceptor" /> to use when creating the proxy.</param>
	/// <param name="interceptionBehaviors">The interception behaviors for the new proxy.</param>
	/// <param name="additionalInterfaces">Any additional interfaces the proxy must implement.</param>
	/// <param name="constructorParameters">The arguments for the creation of the new instance.</param>
	/// <returns>An instance of a class compatible with <typeparamref name="T" /> that includes execution of the
	/// given <paramref name="interceptionBehaviors" />.</returns>
	/// <exception cref="T:System.ArgumentNullException">when <paramref name="interceptor" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.ArgumentNullException">when <paramref name="interceptionBehaviors" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.ArgumentNullException">When <paramref name="additionalInterfaces" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.ArgumentException">when <paramref name="interceptor" /> cannot intercept 
	/// <typeparamref name="T" />.</exception>
	public static T NewInstanceWithAdditionalInterfaces<T>(ITypeInterceptor interceptor, IEnumerable<IInterceptionBehavior> interceptionBehaviors, IEnumerable<Type> additionalInterfaces, params object[] constructorParameters) where T : class
	{
		return (T)NewInstanceWithAdditionalInterfaces(typeof(T), interceptor, interceptionBehaviors, additionalInterfaces, constructorParameters);
	}

	/// <summary>
	/// Creates a new instance of type <typeparamref name="T" /> that is intercepted with the behaviors in 
	/// <paramref name="interceptionBehaviors" />.
	/// </summary>
	/// <typeparam name="T">The type of the object to create.</typeparam>
	/// <param name="interceptor">The <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.ITypeInterceptor" /> to use when creating the proxy.</param>
	/// <param name="interceptionBehaviors">The interception behaviors for the new proxy.</param>
	/// <param name="constructorParameters">The arguments for the creation of the new instance.</param>
	/// <returns>An instance of a class compatible with <typeparamref name="T" /> that includes execution of the
	/// given <paramref name="interceptionBehaviors" />.</returns>
	/// <exception cref="T:System.ArgumentNullException">when <paramref name="interceptor" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.ArgumentNullException">when <paramref name="interceptionBehaviors" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.ArgumentException">when <paramref name="interceptor" /> cannot intercept 
	/// <typeparamref name="T" />.</exception>
	public static T NewInstance<T>(ITypeInterceptor interceptor, IEnumerable<IInterceptionBehavior> interceptionBehaviors, params object[] constructorParameters) where T : class
	{
		return (T)NewInstanceWithAdditionalInterfaces(typeof(T), interceptor, interceptionBehaviors, Type.EmptyTypes, constructorParameters);
	}

	/// <summary>
	/// Creates a new instance of type <paramref name="type" /> that is intercepted with the behaviors in 
	/// <paramref name="interceptionBehaviors" />.
	/// </summary>
	/// <param name="type">The type of the object to create.</param>
	/// <param name="interceptor">The <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.ITypeInterceptor" /> to use when creating the proxy.</param>
	/// <param name="interceptionBehaviors">The interception behaviors for the new proxy.</param>
	/// <param name="additionalInterfaces">Any additional interfaces the instance must implement.</param>
	/// <param name="constructorParameters">The arguments for the creation of the new instance.</param>
	/// <returns>An instance of a class compatible with <paramref name="type" /> that includes execution of the
	/// given <paramref name="interceptionBehaviors" />.</returns>
	/// <exception cref="T:System.ArgumentNullException">when <paramref name="type" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.ArgumentNullException">when <paramref name="interceptor" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.ArgumentNullException">when <paramref name="interceptionBehaviors" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.ArgumentNullException">when <paramref name="additionalInterfaces" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.ArgumentException">when <paramref name="interceptor" /> cannot intercept 
	/// <paramref name="type" />.</exception>
	public static object NewInstanceWithAdditionalInterfaces(Type type, ITypeInterceptor interceptor, IEnumerable<IInterceptionBehavior> interceptionBehaviors, IEnumerable<Type> additionalInterfaces, params object[] constructorParameters)
	{
		Guard.ArgumentNotNull(type, "type");
		Guard.ArgumentNotNull(interceptor, "interceptor");
		Guard.ArgumentNotNull(interceptionBehaviors, "interceptionBehaviors");
		Guard.ArgumentNotNull(additionalInterfaces, "additionalInterfaces");
		if (!interceptor.CanIntercept(type))
		{
			throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.InterceptionNotSupported, type.FullName), "type");
		}
		List<IInterceptionBehavior> source = interceptionBehaviors.ToList();
		if (source.Where((IInterceptionBehavior ib) => ib == null).Count() > 0)
		{
			throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.NullBehavior), "interceptionBehaviors");
		}
		IEnumerable<IInterceptionBehavior> enumerable = source.Where((IInterceptionBehavior ib) => ib.WillExecute);
		Type[] allAdditionalInterfaces = GetAllAdditionalInterfaces(enumerable, additionalInterfaces);
		Type type2 = interceptor.CreateProxyType(type, allAdditionalInterfaces);
		IInterceptingProxy interceptingProxy = (IInterceptingProxy)Activator.CreateInstance(type2, constructorParameters);
		foreach (IInterceptionBehavior item in enumerable)
		{
			interceptingProxy.AddInterceptionBehavior(item);
		}
		return interceptingProxy;
	}

	/// <summary>
	/// Creates a new instance of type <paramref name="type" /> that is intercepted with the behaviors in 
	/// <paramref name="interceptionBehaviors" />.
	/// </summary>
	/// <param name="type">The type of the object to create.</param>
	/// <param name="interceptor">The <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.ITypeInterceptor" /> to use when creating the proxy.</param>
	/// <param name="interceptionBehaviors">The interception behaviors for the new proxy.</param>
	/// <param name="constructorParameters">The arguments for the creation of the new instance.</param>
	/// <returns>An instance of a class compatible with <paramref name="type" /> that includes execution of the
	/// given <paramref name="interceptionBehaviors" />.</returns>
	/// <exception cref="T:System.ArgumentNullException">when <paramref name="type" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.ArgumentNullException">when <paramref name="interceptor" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.ArgumentNullException">when <paramref name="interceptionBehaviors" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.ArgumentException">when <paramref name="interceptor" /> cannot intercept 
	/// <paramref name="type" />.</exception>
	public static object NewInstance(Type type, ITypeInterceptor interceptor, IEnumerable<IInterceptionBehavior> interceptionBehaviors, params object[] constructorParameters)
	{
		return NewInstanceWithAdditionalInterfaces(type, interceptor, interceptionBehaviors, Type.EmptyTypes, constructorParameters);
	}

	/// <summary>
	/// Computes the array with all the additional interfaces for the interception of an object.
	/// </summary>
	/// <param name="interceptionBehaviors">The interception behaviors for the new proxy.</param>
	/// <param name="additionalInterfaces">Any additional interfaces the instance must implement.</param>
	/// <returns>An array with the required interfaces for </returns>
	/// <exception cref="T:System.ArgumentException">when the interfaces are not valid.</exception>
	public static Type[] GetAllAdditionalInterfaces(IEnumerable<IInterceptionBehavior> interceptionBehaviors, IEnumerable<Type> additionalInterfaces)
	{
		IEnumerable<Type> first = interceptionBehaviors.SelectMany(delegate(IInterceptionBehavior ib)
		{
			if (ib == null)
			{
				throw new ArgumentException(Resources.ExceptionContainsNullElement, "interceptionBehaviors");
			}
			return CheckInterfaces(ib.GetRequiredInterfaces(), "interceptionBehaviors", (string error) => string.Format(CultureInfo.CurrentCulture, Resources.ExceptionRequiredInterfacesInvalid, error, ib.GetType().Name));
		});
		IEnumerable<Type> second = CheckInterfaces(additionalInterfaces, "additionalInterfaces", (string error) => string.Format(CultureInfo.CurrentCulture, Resources.ExceptionAdditionalInterfacesInvalid, error));
		return first.Concat(second).ToArray();
	}

	private static IEnumerable<Type> CheckInterfaces(IEnumerable<Type> interfaces, string argumentName, Func<string, string> messageFormatter)
	{
		if (interfaces == null)
		{
			throw new ArgumentException(messageFormatter(Resources.ExceptionNullInterfacesCollection));
		}
		return interfaces.Select(delegate(Type type)
		{
			if (type == null)
			{
				throw new ArgumentException(messageFormatter(Resources.ExceptionContainsNullElement), argumentName);
			}
			if (!type.IsInterface)
			{
				throw new ArgumentException(messageFormatter(string.Format(CultureInfo.CurrentCulture, Resources.ExceptionTypeIsNotInterface, type.Name)), argumentName);
			}
			if (type.IsGenericTypeDefinition)
			{
				throw new ArgumentException(messageFormatter(string.Format(CultureInfo.CurrentCulture, Resources.ExceptionTypeIsOpenGeneric, type.Name)), argumentName);
			}
			return type;
		});
	}
}
