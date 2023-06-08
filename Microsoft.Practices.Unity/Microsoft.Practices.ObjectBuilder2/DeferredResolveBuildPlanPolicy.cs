using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Practices.Unity;

namespace Microsoft.Practices.ObjectBuilder2;

/// <summary>
/// Build plan for <see cref="T:System.Func`1" /> that will
/// return a func that will resolve the requested type
/// through this container later.
/// </summary>
internal class DeferredResolveBuildPlanPolicy : IBuildPlanPolicy, IBuilderPolicy
{
	private class ResolveTrampoline<TItem>
	{
		private readonly IUnityContainer container;

		private readonly string name;

		public ResolveTrampoline(IUnityContainer container, string name)
		{
			this.container = container;
			this.name = name;
		}

		public TItem Resolve()
		{
			return container.Resolve<TItem>(name, new ResolverOverride[0]);
		}
	}

	private class ResolveAllTrampoline<TItem>
	{
		private readonly IUnityContainer container;

		public ResolveAllTrampoline(IUnityContainer container)
		{
			this.container = container;
		}

		public IEnumerable<TItem> ResolveAll()
		{
			return container.ResolveAll<TItem>(new ResolverOverride[0]);
		}
	}

	public void BuildUp(IBuilderContext context)
	{
		if (context.Existing == null)
		{
			IUnityContainer currentContainer = context.NewBuildUp<IUnityContainer>();
			Type typeToBuild = GetTypeToBuild(context.BuildKey.Type);
			string name = context.BuildKey.Name;
			Delegate existing = ((!IsResolvingIEnumerable(typeToBuild)) ? CreateResolver(currentContainer, typeToBuild, name) : CreateResolveAllResolver(currentContainer, typeToBuild));
			context.Existing = existing;
			DynamicMethodConstructorStrategy.SetPerBuildSingleton(context);
		}
	}

	private static Type GetTypeToBuild(Type t)
	{
		return t.GetGenericArguments()[0];
	}

	private static bool IsResolvingIEnumerable(Type typeToBuild)
	{
		if (typeToBuild.IsGenericType)
		{
			return typeToBuild.GetGenericTypeDefinition() == typeof(IEnumerable<>);
		}
		return false;
	}

	private static Delegate CreateResolver(IUnityContainer currentContainer, Type typeToBuild, string nameToBuild)
	{
		Type type = typeof(ResolveTrampoline<>).MakeGenericType(typeToBuild);
		Type type2 = typeof(Func<>).MakeGenericType(typeToBuild);
		MethodInfo method = type.GetMethod("Resolve");
		object firstArgument = Activator.CreateInstance(type, currentContainer, nameToBuild);
		return Delegate.CreateDelegate(type2, firstArgument, method);
	}

	private static Delegate CreateResolveAllResolver(IUnityContainer currentContainer, Type enumerableType)
	{
		Type typeToBuild = GetTypeToBuild(enumerableType);
		Type type = typeof(ResolveAllTrampoline<>).MakeGenericType(typeToBuild);
		Type type2 = typeof(Func<>).MakeGenericType(enumerableType);
		MethodInfo method = type.GetMethod("ResolveAll");
		object firstArgument = Activator.CreateInstance(type, currentContainer);
		return Delegate.CreateDelegate(type2, firstArgument, method);
	}
}
