using System;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity.ObjectBuilder;

namespace Microsoft.Practices.Unity;

/// <summary>
/// This extension installs the default strategies and policies into the container
/// to implement the standard behavior of the Unity container.
/// </summary>
/// <summary>
/// This extension installs the default strategies and policies into the container
/// to implement the standard behavior of the Unity container.
/// </summary>
public class UnityDefaultStrategiesExtension : UnityContainerExtension
{
	/// <summary>
	/// Add the correct <see cref="T:Microsoft.Practices.ObjectBuilder2.IDynamicBuilderMethodCreatorPolicy" /> to the policy
	/// set. This version adds the appropriate policy for running on the desktop CLR.
	/// </summary>
	protected void SetDynamicBuilderMethodCreatorPolicy()
	{
		base.Context.Policies.SetDefault((IDynamicBuilderMethodCreatorPolicy)new DefaultDynamicBuilderMethodCreatorPolicy());
	}

	/// <summary>
	/// Add the default ObjectBuilder strategies &amp; policies to the container.
	/// </summary>
	protected override void Initialize()
	{
		base.Context.Strategies.AddNew<BuildKeyMappingStrategy>(UnityBuildStage.TypeMapping);
		base.Context.Strategies.AddNew<HierarchicalLifetimeStrategy>(UnityBuildStage.Lifetime);
		base.Context.Strategies.AddNew<LifetimeStrategy>(UnityBuildStage.Lifetime);
		base.Context.Strategies.AddNew<ArrayResolutionStrategy>(UnityBuildStage.Creation);
		base.Context.Strategies.AddNew<BuildPlanStrategy>(UnityBuildStage.Creation);
		base.Context.BuildPlanStrategies.AddNew<DynamicMethodConstructorStrategy>(UnityBuildStage.Creation);
		base.Context.BuildPlanStrategies.AddNew<DynamicMethodPropertySetterStrategy>(UnityBuildStage.Initialization);
		base.Context.BuildPlanStrategies.AddNew<DynamicMethodCallStrategy>(UnityBuildStage.Initialization);
		base.Context.Policies.SetDefault((IConstructorSelectorPolicy)new DefaultUnityConstructorSelectorPolicy());
		base.Context.Policies.SetDefault((IPropertySelectorPolicy)new DefaultUnityPropertySelectorPolicy());
		base.Context.Policies.SetDefault((IMethodSelectorPolicy)new DefaultUnityMethodSelectorPolicy());
		SetDynamicBuilderMethodCreatorPolicy();
		base.Context.Policies.SetDefault((IBuildPlanCreatorPolicy)new DynamicMethodBuildPlanCreatorPolicy(base.Context.BuildPlanStrategies));
		base.Context.Policies.Set((IBuildPlanPolicy)new DeferredResolveBuildPlanPolicy(), (object)typeof(Func<>));
		base.Context.Policies.Set((ILifetimePolicy)new PerResolveLifetimeManager(), (object)typeof(Func<>));
	}
}
