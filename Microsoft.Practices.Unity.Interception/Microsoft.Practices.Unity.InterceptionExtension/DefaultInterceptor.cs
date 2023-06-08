using System;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity.Utility;

namespace Microsoft.Practices.Unity.InterceptionExtension;

/// <summary>
/// A <see cref="T:Microsoft.Practices.Unity.InjectionMember" /> that can be passed to the
/// <see cref="M:Microsoft.Practices.Unity.IUnityContainer.RegisterType(System.Type,System.Type,System.String,Microsoft.Practices.Unity.LifetimeManager,Microsoft.Practices.Unity.InjectionMember[])" /> method to specify
/// which interceptor to use. This member sets up the default
/// interceptor for a type - this will be used regardless of which 
/// name is used to resolve the type.
/// </summary>
public class DefaultInterceptor : InjectionMember
{
	private readonly IInterceptor interceptor;

	private readonly NamedTypeBuildKey interceptorKey;

	private bool IsInstanceInterceptor
	{
		get
		{
			if (interceptor != null)
			{
				return interceptor is IInstanceInterceptor;
			}
			return typeof(IInstanceInterceptor).IsAssignableFrom(interceptorKey.Type);
		}
	}

	/// <summary>
	/// Construct a new <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.DefaultInterceptor" /> instance that,
	/// when applied to a container, will register the given
	/// interceptor as the default one.
	/// </summary>
	/// <param name="interceptor">Interceptor to use.</param>
	public DefaultInterceptor(IInterceptor interceptor)
	{
		Guard.ArgumentNotNull(interceptor, "intereptor");
		this.interceptor = interceptor;
	}

	/// <summary>
	/// Construct a new <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.DefaultInterceptor" /> that, when
	/// applied to a container, will register the given type as
	/// the default interceptor. 
	/// </summary>
	/// <param name="interceptorType">Type of interceptor.</param>
	/// <param name="name">Name to use to resolve the interceptor.</param>
	public DefaultInterceptor(Type interceptorType, string name)
	{
		Guard.ArgumentNotNull(interceptorType, "interceptorType");
		Guard.TypeIsAssignable(typeof(IInterceptor), interceptorType, "interceptorType");
		interceptorKey = new NamedTypeBuildKey(interceptorType, name);
	}

	/// <summary>
	/// Construct a new <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.DefaultInterceptor" /> that, when
	/// applied to a container, will register the given type as
	/// the default interceptor. 
	/// </summary>
	/// <param name="interceptorType">Type of interceptor.</param>
	public DefaultInterceptor(Type interceptorType)
		: this(interceptorType, null)
	{
	}

	/// <summary>
	/// Add policies to the <paramref name="policies" /> to configure the
	/// container to call this constructor with the appropriate parameter values.
	/// </summary>
	/// <param name="serviceType">Type of interface being registered. If no interface,
	/// this will be null.</param>
	/// <param name="implementationType">Type of concrete type being registered.</param>
	/// <param name="name">Name used to resolve the type object.</param>
	/// <param name="policies">Policy list to add policies to.</param>
	public override void AddPolicies(Type serviceType, Type implementationType, string name, IPolicyList policies)
	{
		if (IsInstanceInterceptor)
		{
			AddDefaultInstanceInterceptor(implementationType, policies);
		}
		else
		{
			AddDefaultTypeInterceptor(implementationType, policies);
		}
	}

	private void AddDefaultInstanceInterceptor(Type typeToIntercept, IPolicyList policies)
	{
		IInstanceInterceptionPolicy policy = ((interceptor == null) ? ((IInstanceInterceptionPolicy)new ResolvedInstanceInterceptionPolicy(interceptorKey)) : ((IInstanceInterceptionPolicy)new FixedInstanceInterceptionPolicy((IInstanceInterceptor)interceptor)));
		policies.Set(policy, typeToIntercept);
	}

	private void AddDefaultTypeInterceptor(Type typeToIntercept, IPolicyList policies)
	{
		ITypeInterceptionPolicy policy = ((interceptor == null) ? ((ITypeInterceptionPolicy)new ResolvedTypeInterceptionPolicy(interceptorKey)) : ((ITypeInterceptionPolicy)new FixedTypeInterceptionPolicy((ITypeInterceptor)interceptor)));
		policies.Set(policy, typeToIntercept);
	}
}
/// <summary>
/// A generic version of <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.DefaultInterceptor" /> so that
/// you can specify the interceptor type using generics.
/// </summary>
/// <typeparam name="TInterceptor"></typeparam>
public class DefaultInterceptor<TInterceptor> : DefaultInterceptor where TInterceptor : ITypeInterceptor
{
	/// <summary>
	/// Create a new instance of <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.DefaultInterceptor`1" />.
	/// </summary>
	/// <param name="name">Name to use when resolving interceptor.</param>
	public DefaultInterceptor(string name)
		: base(typeof(TInterceptor), name)
	{
	}

	/// <summary>
	/// Create a new instance of <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.DefaultInterceptor`1" />.
	/// </summary>
	public DefaultInterceptor()
		: base(typeof(TInterceptor))
	{
	}
}
