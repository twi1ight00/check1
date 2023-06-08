using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity.Utility;

namespace Microsoft.Practices.Unity;

/// <summary>
/// This strategy implements the logic that will call container.ResolveAll
/// when an array parameter is detected.
/// </summary>
public class ArrayResolutionStrategy : BuilderStrategy
{
	private delegate object ArrayResolver(IBuilderContext context);

	private static readonly MethodInfo genericResolveArrayMethod = typeof(ArrayResolutionStrategy).GetMethod("ResolveArray", BindingFlags.DeclaredOnly | BindingFlags.Static | BindingFlags.NonPublic);

	/// <summary>
	/// Do the PreBuildUp stage of construction. This is where the actual work is performed.
	/// </summary>
	/// <param name="context">Current build context.</param>
	public override void PreBuildUp(IBuilderContext context)
	{
		Guard.ArgumentNotNull(context, "context");
		Type type = context.BuildKey.Type;
		if (type.IsArray && type.GetArrayRank() == 1)
		{
			Type elementType = type.GetElementType();
			MethodInfo method = genericResolveArrayMethod.MakeGenericMethod(elementType);
			ArrayResolver arrayResolver = (ArrayResolver)Delegate.CreateDelegate(typeof(ArrayResolver), method);
			context.Existing = arrayResolver(context);
			context.BuildComplete = true;
		}
	}

	private static object ResolveArray<T>(IBuilderContext context)
	{
		IUnityContainer container = context.NewBuildUp<IUnityContainer>();
		List<T> list = new List<T>(container.ResolveAll<T>(new ResolverOverride[0]));
		return list.ToArray();
	}
}
