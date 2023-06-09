using System;
using System.Collections.Generic;
using Microsoft.Practices.Unity.Utility;

namespace Microsoft.Practices.Unity.InterceptionExtension;

/// <summary>
/// Transient class that supports convenience method for specifying interception policies.
/// </summary>
public class PolicyDefinition
{
	private delegate PolicyDefinition UpdateElements(string name);

	private readonly string policyName;

	private readonly Interception extension;

	private readonly List<ResolvedParameter> rulesParameters;

	private readonly List<string> handlersNames;

	/// <summary>
	/// The <see cref="T:Microsoft.Practices.Unity.IUnityContainer" /> that is currently being
	/// configured.
	/// </summary>
	public IUnityContainer Container => extension.Container;

	/// <summary>
	/// The <see cref="P:Microsoft.Practices.Unity.InterceptionExtension.PolicyDefinition.Interception" /> extension to which the policy was added.
	/// </summary>
	/// <remarks>
	/// Use this property to start adding a new policy.
	/// </remarks>
	public Interception Interception => extension;

	internal PolicyDefinition(string policyName, Interception extension)
	{
		this.policyName = policyName;
		this.extension = extension;
		rulesParameters = new List<ResolvedParameter>();
		handlersNames = new List<string>();
		this.extension.Container.RegisterType<InjectionPolicy, RuleDrivenPolicy>(this.policyName, new InjectionMember[0]);
		UpdateRuleDrivenPolicyInjection();
	}

	private PolicyDefinition UpdateRuleDrivenPolicyInjection()
	{
		extension.Container.RegisterType<RuleDrivenPolicy>(policyName, new InjectionMember[1]
		{
			new InjectionConstructor(policyName, new ResolvedArrayParameter<IMatchingRule>(rulesParameters.ToArray()), handlersNames.ToArray())
		});
		return this;
	}

	private PolicyDefinition UpdateRulesParameters(string name)
	{
		rulesParameters.Add(new ResolvedParameter<IMatchingRule>(name));
		return UpdateRuleDrivenPolicyInjection();
	}

	private PolicyDefinition UpdateHandlerNames(string name)
	{
		handlersNames.Add(name);
		return UpdateRuleDrivenPolicyInjection();
	}

	private static string NewName()
	{
		return Guid.NewGuid().ToString();
	}

	/// <summary>
	/// Adds a reference to matching rule by name.
	/// </summary>
	/// <param name="name">The name for the matching rule.</param>
	/// <returns>
	/// The <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.PolicyDefinition" /> than allows further configuration of the policy.
	/// </returns>
	/// <remarks>
	/// The details of how the rule should be created by the container must be specified using a 
	/// standard injection specification mechanism.
	/// </remarks>
	public PolicyDefinition AddMatchingRule(string name)
	{
		return AddElement<IMatchingRule>(name, UpdateRulesParameters);
	}

	/// <summary>
	/// Makes <paramref name="instance" /> a matching rule in the current policy.
	/// </summary>
	/// <param name="instance">The new <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.IMatchingRule" /> for the policy.</param>
	/// <returns>
	/// The <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.PolicyDefinition" /> than allows further configuration of the policy.
	/// </returns>
	public PolicyDefinition AddMatchingRule(IMatchingRule instance)
	{
		return AddElement(instance, UpdateRulesParameters);
	}

	/// <summary>
	/// Configures injection for a new <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.IMatchingRule" /> and makes it available
	/// as a matching rule in the current policy.
	/// </summary>
	/// <param name="type">The type for the new matching rule.</param>
	/// <param name="injectionMembers">Objects containing the details on which members to inject and how.</param>
	/// <returns>
	/// The <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.PolicyDefinition" /> than allows further configuration of the policy.
	/// </returns>
	public PolicyDefinition AddMatchingRule(Type type, params InjectionMember[] injectionMembers)
	{
		return AddElement<IMatchingRule>(type, NewName(), null, injectionMembers, UpdateRulesParameters);
	}

	/// <summary>
	/// Configures injection for a new <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.IMatchingRule" /> and makes it available
	/// as a matching rule in the current policy, using the given <see cref="T:Microsoft.Practices.Unity.LifetimeManager" />.
	/// </summary>
	/// <param name="type">The type for the new matching rule.</param>
	/// <param name="lifetimeManager">The <see cref="T:Microsoft.Practices.Unity.LifetimeManager" /> that controls the lifetime
	/// of the configured matching rule.</param>
	/// <param name="injectionMembers">Objects containing the details on which members to inject and how.</param>
	/// <returns>
	/// The <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.PolicyDefinition" /> than allows further configuration of the policy.
	/// </returns>
	public PolicyDefinition AddMatchingRule(Type type, LifetimeManager lifetimeManager, params InjectionMember[] injectionMembers)
	{
		return AddElement<IMatchingRule>(type, NewName(), lifetimeManager, injectionMembers, UpdateRulesParameters);
	}

	/// <summary>
	/// Configures injection for a new <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.IMatchingRule" /> using the specified name
	/// and makes it available as a matching rule in the current policy.
	/// </summary>
	/// <param name="type">The type for the new matching rule.</param>
	/// <param name="name">The name for the injection configuration for the matching rule.</param>
	/// <param name="injectionMembers">Objects containing the details on which members to inject and how.</param>
	/// <returns>
	/// The <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.PolicyDefinition" /> than allows further configuration of the policy.
	/// </returns>
	public PolicyDefinition AddMatchingRule(Type type, string name, params InjectionMember[] injectionMembers)
	{
		return AddElement<IMatchingRule>(type, name, null, injectionMembers, UpdateRulesParameters);
	}

	/// <summary>
	/// Configures injection for a new <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.IMatchingRule" /> and makes it available
	/// as a matching rule in the current policy, using the given <see cref="T:Microsoft.Practices.Unity.LifetimeManager" />.
	/// </summary>
	/// <param name="type">The type for the new matching rule.</param>
	/// <param name="name">The name for the injection configuration for the matching rule.</param>
	/// <param name="lifetimeManager">The <see cref="T:Microsoft.Practices.Unity.LifetimeManager" /> that controls the lifetime
	/// of the configured matching rule.</param>
	/// <param name="injectionMembers">Objects containing the details on which members to inject and how.</param>
	/// <returns>
	/// The <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.PolicyDefinition" /> than allows further configuration of the policy.
	/// </returns>
	public PolicyDefinition AddMatchingRule(Type type, string name, LifetimeManager lifetimeManager, params InjectionMember[] injectionMembers)
	{
		return AddElement<IMatchingRule>(type, name, lifetimeManager, injectionMembers, UpdateRulesParameters);
	}

	/// <summary>
	/// Configures injection for a new <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.IMatchingRule" /> and makes it available
	/// as a matching rule in the current policy.
	/// </summary>
	/// <typeparam name="TMatchingRule">The type for the new matching rule.</typeparam>
	/// <param name="injectionMembers">Objects containing the details on which members to inject and how.</param>
	/// <returns>
	/// The <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.PolicyDefinition" /> than allows further configuration of the policy.
	/// </returns>
	public PolicyDefinition AddMatchingRule<TMatchingRule>(params InjectionMember[] injectionMembers) where TMatchingRule : IMatchingRule
	{
		return AddElement<IMatchingRule, TMatchingRule>(NewName(), null, injectionMembers, UpdateRulesParameters);
	}

	/// <summary>
	/// Configures injection for a new <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.IMatchingRule" /> and makes it available
	/// as a matching rule in the current policy, using the given <see cref="T:Microsoft.Practices.Unity.LifetimeManager" />.
	/// </summary>
	/// <typeparam name="TMatchingRule">The type for the new matching rule.</typeparam>
	/// <param name="lifetimeManager">The <see cref="T:Microsoft.Practices.Unity.LifetimeManager" /> that controls the lifetime
	/// of the configured matching rule.</param>
	/// <param name="injectionMembers">Objects containing the details on which members to inject and how.</param>
	/// <returns>
	/// The <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.PolicyDefinition" /> than allows further configuration of the policy.
	/// </returns>
	public PolicyDefinition AddMatchingRule<TMatchingRule>(LifetimeManager lifetimeManager, params InjectionMember[] injectionMembers) where TMatchingRule : IMatchingRule
	{
		return AddElement<IMatchingRule, TMatchingRule>(NewName(), lifetimeManager, injectionMembers, UpdateRulesParameters);
	}

	/// <summary>
	/// Configures injection for a new <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.IMatchingRule" /> using the specified name
	/// and makes it available as a matching rule in the current policy.
	/// </summary>
	/// <typeparam name="TMatchingRule">The type for the new matching rule.</typeparam>
	/// <param name="name">The name for the injection configuration for the matching rule.</param>
	/// <param name="injectionMembers">Objects containing the details on which members to inject and how.</param>
	/// <returns>
	/// The <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.PolicyDefinition" /> than allows further configuration of the policy.
	/// </returns>
	public PolicyDefinition AddMatchingRule<TMatchingRule>(string name, params InjectionMember[] injectionMembers) where TMatchingRule : IMatchingRule
	{
		return AddElement<IMatchingRule, TMatchingRule>(name, null, injectionMembers, UpdateRulesParameters);
	}

	/// <summary>
	/// Configures injection for a new <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.IMatchingRule" /> using the specified name
	/// and makes it available as a matching rule in the current policy, 
	/// using the given <see cref="T:Microsoft.Practices.Unity.LifetimeManager" />.
	/// </summary>
	/// <typeparam name="TMatchingRule">The type for the new matching rule.</typeparam>
	/// <param name="name">The name for the injection configuration for the matching rule.</param>
	/// <param name="lifetimeManager">The <see cref="T:Microsoft.Practices.Unity.LifetimeManager" /> that controls the lifetime
	/// of the configured matching rule.</param>
	/// <param name="injectionMembers">Objects containing the details on which members to inject and how.</param>
	/// <returns>
	/// The <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.PolicyDefinition" /> than allows further configuration of the policy.
	/// </returns>
	public PolicyDefinition AddMatchingRule<TMatchingRule>(string name, LifetimeManager lifetimeManager, params InjectionMember[] injectionMembers) where TMatchingRule : IMatchingRule
	{
		return AddElement<IMatchingRule, TMatchingRule>(name, lifetimeManager, injectionMembers, UpdateRulesParameters);
	}

	/// <summary>
	/// Adds a reference to call handler by name.
	/// </summary>
	/// <param name="name">The name for the call handler.</param>
	/// <returns>
	/// The <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.PolicyDefinition" /> than allows further configuration of the policy.
	/// </returns>
	/// <remarks>
	/// The details of how the handler should be created by the container must be specified using a 
	/// standard injection specification mechanism.
	/// </remarks>
	public PolicyDefinition AddCallHandler(string name)
	{
		return AddElement<ICallHandler>(name, UpdateHandlerNames);
	}

	/// <summary>
	/// Makes <paramref name="instance" /> a call handler in the current policy.
	/// </summary>
	/// <param name="instance">The new <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.ICallHandler" /> for the policy.</param>
	/// <returns>
	/// The <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.PolicyDefinition" /> than allows further configuration of the policy.
	/// </returns>
	public PolicyDefinition AddCallHandler(ICallHandler instance)
	{
		return AddElement(instance, UpdateHandlerNames);
	}

	/// <summary>
	/// Configures injection for a new <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.ICallHandler" /> and makes it available
	/// as a call handler in the current policy.
	/// </summary>
	/// <param name="type">The type for the new call handler.</param>
	/// <param name="injectionMembers">Objects containing the details on which members to inject and how.</param>
	/// <returns>
	/// The <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.PolicyDefinition" /> than allows further configuration of the policy.
	/// </returns>
	public PolicyDefinition AddCallHandler(Type type, params InjectionMember[] injectionMembers)
	{
		return AddElement<ICallHandler>(type, NewName(), null, injectionMembers, UpdateHandlerNames);
	}

	/// <summary>
	/// Configures injection for a new <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.ICallHandler" /> and makes it available
	/// as a call handler in the current policy, using the given <see cref="T:Microsoft.Practices.Unity.LifetimeManager" />.
	/// </summary>
	/// <param name="type">The type for the new call handler.</param>
	/// <param name="lifetimeManager">The <see cref="T:Microsoft.Practices.Unity.LifetimeManager" /> that controls the lifetime
	/// of the configured call handler.</param>
	/// <param name="injectionMembers">Objects containing the details on which members to inject and how.</param>
	/// <returns>
	/// The <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.PolicyDefinition" /> than allows further configuration of the policy.
	/// </returns>
	public PolicyDefinition AddCallHandler(Type type, LifetimeManager lifetimeManager, params InjectionMember[] injectionMembers)
	{
		return AddElement<ICallHandler>(type, NewName(), lifetimeManager, injectionMembers, UpdateHandlerNames);
	}

	/// <summary>
	/// Configures injection for a new <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.ICallHandler" /> using the specified name
	/// and makes it available as a call handler in the current policy.
	/// </summary>
	/// <param name="type">The type for the new call handler.</param>
	/// <param name="name">The name for the injection configuration for the call handler.</param>
	/// <param name="injectionMembers">Objects containing the details on which members to inject and how.</param>
	/// <returns>
	/// The <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.PolicyDefinition" /> than allows further configuration of the policy.
	/// </returns>
	public PolicyDefinition AddCallHandler(Type type, string name, params InjectionMember[] injectionMembers)
	{
		return AddElement<ICallHandler>(type, name, null, injectionMembers, UpdateHandlerNames);
	}

	/// <summary>
	/// Configures injection for a new <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.ICallHandler" /> using the specified name
	/// and makes it available as a call handler in the current policy, 
	/// using the given <see cref="T:Microsoft.Practices.Unity.LifetimeManager" />.
	/// </summary>
	/// <param name="type">The type for the new call handler.</param>
	/// <param name="name">The name for the injection configuration for the call handler.</param>
	/// <param name="lifetimeManager">The <see cref="T:Microsoft.Practices.Unity.LifetimeManager" /> that controls the lifetime
	/// of the configured call handler.</param>
	/// <param name="injectionMembers">Objects containing the details on which members to inject and how.</param>
	/// <returns>
	/// The <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.PolicyDefinition" /> than allows further configuration of the policy.
	/// </returns>
	public PolicyDefinition AddCallHandler(Type type, string name, LifetimeManager lifetimeManager, params InjectionMember[] injectionMembers)
	{
		return AddElement<ICallHandler>(type, name, lifetimeManager, injectionMembers, UpdateHandlerNames);
	}

	/// <summary>
	/// Configures injection for a new <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.ICallHandler" /> and makes it available
	/// as a call handler in the current policy.
	/// </summary>
	/// <typeparam name="TCallHandler">The type for the new call handler.</typeparam>
	/// <param name="injectionMembers">Objects containing the details on which members to inject and how.</param>
	/// <returns>
	/// The <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.PolicyDefinition" /> than allows further configuration of the policy.
	/// </returns>
	public PolicyDefinition AddCallHandler<TCallHandler>(params InjectionMember[] injectionMembers) where TCallHandler : ICallHandler
	{
		return AddElement<ICallHandler, TCallHandler>(NewName(), null, injectionMembers, UpdateHandlerNames);
	}

	/// <summary>
	/// Configures injection for a new <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.ICallHandler" /> and makes it available
	/// as a call handler in the current policy, using the given <see cref="T:Microsoft.Practices.Unity.LifetimeManager" />.
	/// </summary>
	/// <typeparam name="TCallHandler">The type for the new call handler.</typeparam>
	/// <param name="lifetimeManager">The <see cref="T:Microsoft.Practices.Unity.LifetimeManager" /> that controls the lifetime
	/// of the configured call handler.</param>
	/// <param name="injectionMembers">Objects containing the details on which members to inject and how.</param>
	/// <returns>
	/// The <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.PolicyDefinition" /> than allows further configuration of the policy.
	/// </returns>
	public PolicyDefinition AddCallHandler<TCallHandler>(LifetimeManager lifetimeManager, params InjectionMember[] injectionMembers) where TCallHandler : ICallHandler
	{
		return AddElement<ICallHandler, TCallHandler>(NewName(), lifetimeManager, injectionMembers, UpdateHandlerNames);
	}

	/// <summary>
	/// Configures injection for a new <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.ICallHandler" /> using the specified name
	/// and makes it available as a call handler in the current policy.
	/// </summary>
	/// <typeparam name="TCallHandler">The type for the new call handler.</typeparam>
	/// <param name="name">The name for the injection configuration for the call handler .</param>
	/// <param name="injectionMembers">Objects containing the details on which members to inject and how.</param>
	/// <returns>
	/// The <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.PolicyDefinition" /> than allows further configuration of the policy.
	/// </returns>
	public PolicyDefinition AddCallHandler<TCallHandler>(string name, params InjectionMember[] injectionMembers) where TCallHandler : ICallHandler
	{
		return AddElement<ICallHandler, TCallHandler>(name, null, injectionMembers, UpdateHandlerNames);
	}

	/// <summary>
	/// Configures injection for a new <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.ICallHandler" /> using the specified name
	/// and makes it available as a call handler in the current policy, 
	/// using the given <see cref="T:Microsoft.Practices.Unity.LifetimeManager" />.
	/// </summary>
	/// <typeparam name="TCallHandler">The type for the new call handler.</typeparam>
	/// <param name="name">The name for the injection configuration for the call handler .</param>
	/// <param name="lifetimeManager">The <see cref="T:Microsoft.Practices.Unity.LifetimeManager" /> that controls the lifetime
	/// of the configured call handler.</param>
	/// <param name="injectionMembers">Objects containing the details on which members to inject and how.</param>
	/// <returns>
	/// The <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.PolicyDefinition" /> than allows further configuration of the policy.
	/// </returns>
	public PolicyDefinition AddCallHandler<TCallHandler>(string name, LifetimeManager lifetimeManager, params InjectionMember[] injectionMembers) where TCallHandler : ICallHandler
	{
		return AddElement<ICallHandler, TCallHandler>(name, lifetimeManager, injectionMembers, UpdateHandlerNames);
	}

	private PolicyDefinition AddElement<T>(string name, UpdateElements update)
	{
		Guard.ArgumentNotNull(name, "name");
		return update(name);
	}

	private PolicyDefinition AddElement<T>(T instance, UpdateElements update)
	{
		Guard.ArgumentNotNull(instance, "instance");
		string name = NewName();
		Container.RegisterInstance(name, instance);
		return update(name);
	}

	private PolicyDefinition AddElement<T>(Type type, string name, LifetimeManager lifetimeManager, InjectionMember[] injectionMembers, UpdateElements update)
	{
		Guard.ArgumentNotNullOrEmpty(name, "name");
		Guard.ArgumentNotNull(type, "type");
		Guard.TypeIsAssignable(typeof(T), type, "type");
		Guard.ArgumentNotNull(injectionMembers, "injectionMembers");
		Container.RegisterType(typeof(T), type, name, lifetimeManager, injectionMembers);
		return update(name);
	}

	private PolicyDefinition AddElement<T, TElement>(string name, LifetimeManager lifetimeManager, InjectionMember[] injectionMembers, UpdateElements update) where TElement : T
	{
		return AddElement<T>(typeof(TElement), name, lifetimeManager, injectionMembers, update);
	}
}
