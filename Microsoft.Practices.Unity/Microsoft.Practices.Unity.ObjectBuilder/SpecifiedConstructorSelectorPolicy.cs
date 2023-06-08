using System;
using System.Reflection;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity.Utility;

namespace Microsoft.Practices.Unity.ObjectBuilder;

/// <summary>
/// An implementation of <see cref="T:Microsoft.Practices.ObjectBuilder2.IConstructorSelectorPolicy" /> that selects
/// the given constructor and creates the appropriate resolvers to call it with
/// the specified parameters.
/// </summary>
public class SpecifiedConstructorSelectorPolicy : IConstructorSelectorPolicy, IBuilderPolicy
{
	private readonly ConstructorInfo ctor;

	private readonly MethodReflectionHelper ctorReflector;

	private readonly InjectionParameterValue[] parameterValues;

	/// <summary>
	/// Create an instance of <see cref="T:Microsoft.Practices.Unity.ObjectBuilder.SpecifiedConstructorSelectorPolicy" /> that
	/// will return the given constructor, being passed the given injection values
	/// as parameters.
	/// </summary>
	/// <param name="ctor">The constructor to call.</param>
	/// <param name="parameterValues">Set of <see cref="T:Microsoft.Practices.Unity.InjectionParameterValue" /> objects
	/// that describes how to obtain the values for the constructor parameters.</param>
	public SpecifiedConstructorSelectorPolicy(ConstructorInfo ctor, InjectionParameterValue[] parameterValues)
	{
		this.ctor = ctor;
		ctorReflector = new MethodReflectionHelper(ctor);
		this.parameterValues = parameterValues;
	}

	/// <summary>
	/// Choose the constructor to call for the given type.
	/// </summary>
	/// <param name="context">Current build context</param>
	/// <param name="resolverPolicyDestination">The <see cref="T:Microsoft.Practices.ObjectBuilder2.IPolicyList" /> to add any
	/// generated resolver objects into.</param>
	/// <returns>The chosen constructor.</returns>
	public SelectedConstructor SelectConstructor(IBuilderContext context, IPolicyList resolverPolicyDestination)
	{
		Type type = context.BuildKey.Type;
		ReflectionHelper reflectionHelper = new ReflectionHelper(ctor.DeclaringType);
		SelectedConstructor result;
		if (!ctorReflector.MethodHasOpenGenericParameters && !reflectionHelper.IsOpenGeneric)
		{
			result = new SelectedConstructor(ctor);
		}
		else
		{
			Type[] closedParameterTypes = ctorReflector.GetClosedParameterTypes(type.GetGenericArguments());
			result = new SelectedConstructor(type.GetConstructor(closedParameterTypes));
		}
		SpecifiedMemberSelectorHelper.AddParameterResolvers(type, resolverPolicyDestination, parameterValues, result);
		return result;
	}
}
