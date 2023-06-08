using System;
using System.Globalization;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity.InterceptionExtension.Properties;
using Microsoft.Practices.Unity.Utility;

namespace Microsoft.Practices.Unity.InterceptionExtension;

/// <summary>
/// Stores information about a single <see cref="T:System.Type" /> to be an additional interface for an intercepted object and
/// configures a container accordingly.
/// </summary>
public class AdditionalInterface : InterceptionMember
{
	private readonly Type additionalInterface;

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.AdditionalInterface" /> with a 
	/// <see cref="T:System.Type" />.
	/// </summary>
	/// <param name="additionalInterface">A descriptor representing the interception behavior to use.</param>
	/// <exception cref="T:System.ArgumentNullException">when <paramref name="additionalInterface" /> is
	/// <see langword="null" />.</exception>
	/// <exception cref="T:System.ArgumentException">when <paramref name="additionalInterface" /> is not an interface.
	/// </exception>
	public AdditionalInterface(Type additionalInterface)
	{
		Guard.ArgumentNotNull(additionalInterface, "additionalInterface");
		if (!additionalInterface.IsInterface)
		{
			throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.ExceptionTypeIsNotInterface, additionalInterface.Name), "additionalInterface");
		}
		this.additionalInterface = additionalInterface;
	}

	/// <summary>
	/// Add policies to the <paramref name="policies" /> to configure the container to use the represented 
	/// <see cref="T:System.Type" /> as an additional interface for the supplied parameters.
	/// </summary>
	/// <param name="serviceType">Interface being registered.</param>
	/// <param name="implementationType">Type to register.</param>
	/// <param name="name">Name used to resolve the type object.</param>
	/// <param name="policies">Policy list to add policies to.</param>
	public override void AddPolicies(Type serviceType, Type implementationType, string name, IPolicyList policies)
	{
		AdditionalInterfacesPolicy orCreate = AdditionalInterfacesPolicy.GetOrCreate(policies, implementationType, name);
		orCreate.AddAdditionalInterface(additionalInterface);
	}
}
/// <summary>
/// Stores information about a single <see cref="T:System.Type" /> to be an additional interface for an intercepted object and
/// configures a container accordingly.
/// </summary>
/// <typeparam name="T">The interface.</typeparam>
public class AdditionalInterface<T> : AdditionalInterface where T : class
{
	/// <summary>
	/// Initializes a new instance of the <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.AdditionalInterface`1" />.
	/// </summary>
	public AdditionalInterface()
		: base(typeof(T))
	{
	}
}
