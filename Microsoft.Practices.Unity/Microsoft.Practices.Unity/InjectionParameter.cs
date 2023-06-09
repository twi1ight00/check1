using System;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity.ObjectBuilder;
using Microsoft.Practices.Unity.Properties;

namespace Microsoft.Practices.Unity;

/// <summary>
/// A class that holds on to the given value and provides
/// the required <see cref="T:Microsoft.Practices.ObjectBuilder2.IDependencyResolverPolicy" />
/// when the container is configured.
/// </summary>
public class InjectionParameter : TypedInjectionValue
{
	private readonly object parameterValue;

	/// <summary>
	/// Create an instance of <see cref="T:Microsoft.Practices.Unity.InjectionParameter" /> that stores
	/// the given value, using the runtime type of that value as the
	/// type of the parameter.
	/// </summary>
	/// <param name="parameterValue">Value to be injected for this parameter.</param>
	public InjectionParameter(object parameterValue)
		: this(GetParameterType(parameterValue), parameterValue)
	{
	}

	private static Type GetParameterType(object parameterValue)
	{
		if (parameterValue == null)
		{
			throw new ArgumentNullException("parameterValue", Resources.ExceptionNullParameterValue);
		}
		return parameterValue.GetType();
	}

	/// <summary>
	/// Create an instance of <see cref="T:Microsoft.Practices.Unity.InjectionParameter" /> that stores
	/// the given value, associated with the given type.
	/// </summary>
	/// <param name="parameterType">Type of the parameter.</param>
	/// <param name="parameterValue">Value of the parameter</param>
	public InjectionParameter(Type parameterType, object parameterValue)
		: base(parameterType)
	{
		this.parameterValue = parameterValue;
	}

	/// <summary>
	/// Return a <see cref="T:Microsoft.Practices.ObjectBuilder2.IDependencyResolverPolicy" /> instance that will
	/// return this types value for the parameter.
	/// </summary>
	/// <param name="typeToBuild">Type that contains the member that needs this parameter. Used
	/// to resolve open generic parameters.</param>
	/// <returns>The <see cref="T:Microsoft.Practices.ObjectBuilder2.IDependencyResolverPolicy" />.</returns>
	public override IDependencyResolverPolicy GetResolverPolicy(Type typeToBuild)
	{
		return new LiteralValueDependencyResolverPolicy(parameterValue);
	}
}
/// <summary>
/// A generic version of <see cref="T:Microsoft.Practices.Unity.InjectionParameter" /> that makes it a
/// little easier to specify the type of the parameter.
/// </summary>
/// <typeparam name="TParameter">Type of parameter.</typeparam>
public class InjectionParameter<TParameter> : InjectionParameter
{
	/// <summary>
	/// Create a new <see cref="T:Microsoft.Practices.Unity.InjectionParameter`1" />.
	/// </summary>
	/// <param name="parameterValue">Value for the parameter.</param>
	public InjectionParameter(TParameter parameterValue)
		: base(typeof(TParameter), parameterValue)
	{
	}
}
