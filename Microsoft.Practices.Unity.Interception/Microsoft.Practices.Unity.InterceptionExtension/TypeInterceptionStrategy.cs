using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity.Utility;

namespace Microsoft.Practices.Unity.InterceptionExtension;

/// <summary>
/// A <see cref="T:Microsoft.Practices.ObjectBuilder2.IBuilderStrategy" /> that hooks up type interception. It looks for
/// a <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.ITypeInterceptionPolicy" /> for the current build key, or the current
/// build type. If present, it substitutes types so that that proxy class gets
/// built up instead. On the way back, it hooks up the appropriate handlers.
///  </summary>
public class TypeInterceptionStrategy : BuilderStrategy
{
	private class EffectiveInterceptionBehaviorsPolicy : IBuilderPolicy
	{
		public IEnumerable<IInterceptionBehavior> Behaviors { get; set; }

		public EffectiveInterceptionBehaviorsPolicy()
		{
			Behaviors = new List<IInterceptionBehavior>();
		}
	}

	private class DerivedTypeConstructorSelectorPolicy : IConstructorSelectorPolicy, IBuilderPolicy
	{
		private readonly Type interceptingType;

		private readonly IConstructorSelectorPolicy originalConstructorSelectorPolicy;

		public DerivedTypeConstructorSelectorPolicy(Type interceptingType, IConstructorSelectorPolicy originalConstructorSelectorPolicy)
		{
			this.interceptingType = interceptingType;
			this.originalConstructorSelectorPolicy = originalConstructorSelectorPolicy;
		}

		public SelectedConstructor SelectConstructor(IBuilderContext context, IPolicyList resolverPolicyDestination)
		{
			SelectedConstructor originalConstructor = originalConstructorSelectorPolicy.SelectConstructor(context, resolverPolicyDestination);
			return FindNewConstructor(originalConstructor, interceptingType);
		}

		private static SelectedConstructor FindNewConstructor(SelectedConstructor originalConstructor, Type interceptingType)
		{
			ParameterInfo[] parameters = originalConstructor.Constructor.GetParameters();
			ConstructorInfo constructor = interceptingType.GetConstructor(parameters.Select((ParameterInfo pi) => pi.ParameterType).ToArray());
			SelectedConstructor selectedConstructor = new SelectedConstructor(constructor);
			string[] parameterKeys = originalConstructor.GetParameterKeys();
			foreach (string newKey in parameterKeys)
			{
				selectedConstructor.AddParameterKey(newKey);
			}
			return selectedConstructor;
		}
	}

	/// <summary>
	/// Called during the chain of responsibility for a build operation. The
	/// PreBuildUp method is called when the chain is being executed in the
	/// forward direction.
	/// </summary>
	/// <remarks>In this class, PreBuildUp is responsible for figuring out if the
	/// class is proxiable, and if so, replacing it with a proxy class.</remarks>
	/// <param name="context">Context of the build operation.</param>
	public override void PreBuildUp(IBuilderContext context)
	{
		Guard.ArgumentNotNull(context, "context");
		if (context.Existing != null)
		{
			return;
		}
		Type type = context.BuildKey.Type;
		ITypeInterceptionPolicy typeInterceptionPolicy = FindInterceptionPolicy<ITypeInterceptionPolicy>(context);
		if (typeInterceptionPolicy == null)
		{
			return;
		}
		ITypeInterceptor interceptor = typeInterceptionPolicy.GetInterceptor(context);
		if (interceptor.CanIntercept(type))
		{
			IInterceptionBehaviorsPolicy interceptionBehaviorsPolicy = FindInterceptionPolicy<IInterceptionBehaviorsPolicy>(context);
			IEnumerable<IInterceptionBehavior> enumerable = ((interceptionBehaviorsPolicy == null) ? Enumerable.Empty<IInterceptionBehavior>() : (from ib in interceptionBehaviorsPolicy.GetEffectiveBehaviors(context, interceptor, type, type)
				where ib.WillExecute
				select ib));
			IAdditionalInterfacesPolicy additionalInterfacesPolicy = FindInterceptionPolicy<IAdditionalInterfacesPolicy>(context);
			IEnumerable<Type> additionalInterfaces = ((additionalInterfacesPolicy != null) ? additionalInterfacesPolicy.AdditionalInterfaces : Type.EmptyTypes);
			context.Policies.Set(new EffectiveInterceptionBehaviorsPolicy
			{
				Behaviors = enumerable
			}, context.BuildKey);
			Type[] allAdditionalInterfaces = Intercept.GetAllAdditionalInterfaces(enumerable, additionalInterfaces);
			Type interceptingType = interceptor.CreateProxyType(type, allAdditionalInterfaces);
			IPolicyList containingPolicyList;
			IConstructorSelectorPolicy originalConstructorSelectorPolicy = context.Policies.Get<IConstructorSelectorPolicy>(context.BuildKey, out containingPolicyList);
			containingPolicyList.Set((IConstructorSelectorPolicy)new DerivedTypeConstructorSelectorPolicy(interceptingType, originalConstructorSelectorPolicy), (object)context.BuildKey);
		}
	}

	/// <summary>
	/// Called during the chain of responsibility for a build operation. The
	/// PostBuildUp method is called when the chain has finished the PreBuildUp
	/// phase and executes in reverse order from the PreBuildUp calls.
	/// </summary>
	/// <remarks>In this class, PostBuildUp checks to see if the object was proxiable,
	/// and if it was, wires up the handlers.</remarks>
	/// <param name="context">Context of the build operation.</param>
	public override void PostBuildUp(IBuilderContext context)
	{
		Guard.ArgumentNotNull(context, "context");
		if (!(context.Existing is IInterceptingProxy interceptingProxy))
		{
			return;
		}
		EffectiveInterceptionBehaviorsPolicy effectiveInterceptionBehaviorsPolicy = context.Policies.Get<EffectiveInterceptionBehaviorsPolicy>(context.BuildKey, localOnly: true);
		if (effectiveInterceptionBehaviorsPolicy == null)
		{
			return;
		}
		foreach (IInterceptionBehavior behavior in effectiveInterceptionBehaviorsPolicy.Behaviors)
		{
			interceptingProxy.AddInterceptionBehavior(behavior);
		}
	}

	private static TPolicy FindInterceptionPolicy<TPolicy>(IBuilderContext context) where TPolicy : class, IBuilderPolicy
	{
		return context.Policies.Get<TPolicy>(context.BuildKey, localOnly: false) ?? context.Policies.Get<TPolicy>(context.BuildKey.Type, localOnly: false);
	}
}
