using System;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity.ObjectBuilder;

namespace Microsoft.Practices.Unity;

/// <summary>
/// A <see cref="T:Microsoft.Practices.Unity.InjectionParameterValue" /> that lets you specify that
/// an instance of a generic type parameter should be resolved.
/// </summary>
public class GenericParameter : GenericParameterBase
{
	/// <summary>
	/// Create a new <see cref="T:Microsoft.Practices.Unity.GenericParameter" /> instance that specifies
	/// that the given named generic parameter should be resolved.
	/// </summary>
	/// <param name="genericParameterName">The generic parameter name to resolve.</param>
	public GenericParameter(string genericParameterName)
		: base(genericParameterName)
	{
	}

	/// <summary>
	/// Create a new <see cref="T:Microsoft.Practices.Unity.GenericParameter" /> instance that specifies
	/// that the given named generic parameter should be resolved.
	/// </summary>
	/// <param name="genericParameterName">The generic parameter name to resolve.</param>
	/// <param name="resolutionKey">name to use when looking up in the container.</param>
	public GenericParameter(string genericParameterName, string resolutionKey)
		: base(genericParameterName, resolutionKey)
	{
	}

	/// <summary>
	/// Return a <see cref="T:Microsoft.Practices.ObjectBuilder2.IDependencyResolverPolicy" /> instance that will
	/// return this types value for the parameter.
	/// </summary>
	/// <param name="typeToResolve">The actual type to resolve.</param>
	/// <param name="resolutionKey">The resolution key.</param>
	/// <returns>The <see cref="T:Microsoft.Practices.ObjectBuilder2.IDependencyResolverPolicy" />.</returns>
	protected override IDependencyResolverPolicy DoGetResolverPolicy(Type typeToResolve, string resolutionKey)
	{
		return new NamedTypeDependencyResolverPolicy(typeToResolve, resolutionKey);
	}
}
