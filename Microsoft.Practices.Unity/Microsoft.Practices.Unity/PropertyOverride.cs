using System;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity.Utility;

namespace Microsoft.Practices.Unity;

/// <summary>
/// A <see cref="T:Microsoft.Practices.Unity.ResolverOverride" /> that lets you override
/// the value for a specified property.
/// </summary>
public class PropertyOverride : ResolverOverride
{
	private readonly string propertyName;

	private readonly InjectionParameterValue propertyValue;

	/// <summary>
	///  Create an instance of <see cref="T:Microsoft.Practices.Unity.PropertyOverride" />.
	/// </summary>
	/// <param name="propertyName">The property name.</param>
	/// <param name="propertyValue">Value to use for the property.</param>
	public PropertyOverride(string propertyName, object propertyValue)
	{
		this.propertyName = propertyName;
		this.propertyValue = InjectionParameterValue.ToParameter(propertyValue);
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
		if (context.CurrentOperation is ResolvingPropertyValueOperation resolvingPropertyValueOperation && resolvingPropertyValueOperation.PropertyName == propertyName)
		{
			return propertyValue.GetResolverPolicy(dependencyType);
		}
		return null;
	}
}
