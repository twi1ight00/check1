using System;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity.Utility;

namespace Microsoft.Practices.Unity;

/// <summary>
/// A <see cref="T:Microsoft.Practices.Unity.ResolverOverride" /> class that lets you
/// override a named parameter passed to a constructor.
/// </summary>
public class ParameterOverride : ResolverOverride
{
	private readonly string parameterName;

	private readonly InjectionParameterValue parameterValue;

	/// <summary>
	/// Construct a new <see cref="T:Microsoft.Practices.Unity.ParameterOverride" /> object that will
	/// override the given named constructor parameter, and pass the given
	/// value.
	/// </summary>
	/// <param name="parameterName">Name of the constructor parameter.</param>
	/// <param name="parameterValue">Value to pass for the constructor.</param>
	public ParameterOverride(string parameterName, object parameterValue)
	{
		this.parameterName = parameterName;
		this.parameterValue = InjectionParameterValue.ToParameter(parameterValue);
	}

	/// <summary>
	/// Return a <see cref="T:Microsoft.Practices.ObjectBuilder2.IDependencyResolverPolicy" /> that can be used to give a value
	/// for the given desired dependency.
	/// </summary>
	/// <param name="context">Current build context.</param>
	/// <param name="dependencyType">Type of dependency desired.</param>
	/// <returns>a <see cref="T:Microsoft.Practices.ObjectBuilder2.IDependencyResolverPolicy" /> object if this override applies, null if not.</returns>
	public override IDependencyResolverPolicy GetResolver(IBuilderContext context, Type dependencyType)
	{
		Guard.ArgumentNotNull(context, "context");
		if (context.CurrentOperation is ConstructorArgumentResolveOperation constructorArgumentResolveOperation && constructorArgumentResolveOperation.ParameterName == parameterName)
		{
			return parameterValue.GetResolverPolicy(dependencyType);
		}
		return null;
	}
}
