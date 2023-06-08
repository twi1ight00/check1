using System;
using System.Collections.Generic;
using Microsoft.Practices.ObjectBuilder2;

namespace Microsoft.Practices.Unity.InterceptionExtension;

/// <summary>
/// An <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.IAdditionalInterfacesPolicy" /> that accumulates a sequence of 
/// <see cref="T:System.Type" /> instances representing the additional interfaces for an intercepted object.
/// </summary>
public class AdditionalInterfacesPolicy : IAdditionalInterfacesPolicy, IBuilderPolicy
{
	private readonly List<Type> additionalInterfaces;

	/// <summary>
	/// Gets the <see cref="T:System.Type" /> instances accumulated by this policy.
	/// </summary>
	public IEnumerable<Type> AdditionalInterfaces => additionalInterfaces;

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.AdditionalInterfacesPolicy" /> class.
	/// </summary>
	public AdditionalInterfacesPolicy()
	{
		additionalInterfaces = new List<Type>();
	}

	internal void AddAdditionalInterface(Type additionalInterface)
	{
		additionalInterfaces.Add(additionalInterface);
	}

	internal static AdditionalInterfacesPolicy GetOrCreate(IPolicyList policies, Type typeToCreate, string name)
	{
		NamedTypeBuildKey buildKey = new NamedTypeBuildKey(typeToCreate, name);
		IAdditionalInterfacesPolicy additionalInterfacesPolicy = policies.GetNoDefault<IAdditionalInterfacesPolicy>(buildKey, localOnly: false);
		if (additionalInterfacesPolicy == null || !(additionalInterfacesPolicy is AdditionalInterfacesPolicy))
		{
			additionalInterfacesPolicy = new AdditionalInterfacesPolicy();
			policies.Set(additionalInterfacesPolicy, buildKey);
		}
		return (AdditionalInterfacesPolicy)additionalInterfacesPolicy;
	}
}
