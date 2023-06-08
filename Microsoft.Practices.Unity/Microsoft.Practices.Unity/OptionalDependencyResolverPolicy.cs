using System;
using System.Globalization;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity.Properties;
using Microsoft.Practices.Unity.Utility;

namespace Microsoft.Practices.Unity;

/// <summary>
/// A <see cref="T:Microsoft.Practices.ObjectBuilder2.IDependencyResolverPolicy" /> that will attempt to
/// resolve a value, and return null if it cannot rather than throwing.
/// </summary>
public class OptionalDependencyResolverPolicy : IDependencyResolverPolicy, IBuilderPolicy
{
	private readonly Type type;

	private readonly string name;

	/// <summary>
	/// Type this resolver will resolve.
	/// </summary>
	public Type DependencyType => type;

	/// <summary>
	/// Name this resolver will resolve.
	/// </summary>
	public string Name => name;

	/// <summary>
	/// Construct a new <see cref="T:Microsoft.Practices.Unity.OptionalDependencyResolverPolicy" /> object
	/// that will attempt to resolve the given name and type from the container.
	/// </summary>
	/// <param name="type">Type to resolve. Must be a reference type.</param>
	/// <param name="name">Name to resolve with.</param>
	public OptionalDependencyResolverPolicy(Type type, string name)
	{
		Guard.ArgumentNotNull(type, "type");
		if (type.IsValueType)
		{
			throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.OptionalDependenciesMustBeReferenceTypes, type.Name));
		}
		this.type = type;
		this.name = name;
	}

	/// <summary>
	/// Construct a new <see cref="T:Microsoft.Practices.Unity.OptionalDependencyResolverPolicy" /> object
	/// that will attempt to resolve the given type from the container.
	/// </summary>
	/// <param name="type">Type to resolve. Must be a reference type.</param>
	public OptionalDependencyResolverPolicy(Type type)
		: this(type, null)
	{
	}

	/// <summary>
	/// Get the value for a dependency.
	/// </summary>
	/// <param name="context">Current build context.</param>
	/// <returns>The value for the dependency.</returns>
	public object Resolve(IBuilderContext context)
	{
		Guard.ArgumentNotNull(context, "context");
		NamedTypeBuildKey newBuildKey = new NamedTypeBuildKey(type, name);
		try
		{
			return context.NewBuildUp(newBuildKey);
		}
		catch (Exception)
		{
			return null;
		}
	}
}
