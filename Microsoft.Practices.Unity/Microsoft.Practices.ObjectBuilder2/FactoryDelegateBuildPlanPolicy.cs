using System;
using Microsoft.Practices.Unity;

namespace Microsoft.Practices.ObjectBuilder2;

internal class FactoryDelegateBuildPlanPolicy : IBuildPlanPolicy, IBuilderPolicy
{
	private readonly Func<IUnityContainer, Type, string, object> factory;

	public FactoryDelegateBuildPlanPolicy(Func<IUnityContainer, Type, string, object> factory)
	{
		this.factory = factory;
	}

	/// <summary>
	/// Creates an instance of this build plan's type, or fills
	/// in the existing type if passed in.
	/// </summary>
	/// <param name="context">Context used to build up the object.</param>
	public void BuildUp(IBuilderContext context)
	{
		if (context.Existing == null)
		{
			IUnityContainer arg = context.NewBuildUp<IUnityContainer>();
			context.Existing = factory(arg, context.BuildKey.Type, context.BuildKey.Name);
			DynamicMethodConstructorStrategy.SetPerBuildSingleton(context);
		}
	}
}
