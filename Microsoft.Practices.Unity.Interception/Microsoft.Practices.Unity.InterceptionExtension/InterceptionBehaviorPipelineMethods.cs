using System.Reflection;
using Microsoft.Practices.Unity.Utility;

namespace Microsoft.Practices.Unity.InterceptionExtension;

internal static class InterceptionBehaviorPipelineMethods
{
	internal static ConstructorInfo Constructor => StaticReflection.GetConstructorInfo(() => new InterceptionBehaviorPipeline());

	internal static MethodInfo Add => StaticReflection.GetMethodInfo((InterceptionBehaviorPipeline pip) => pip.Add(null));

	internal static MethodInfo Invoke => StaticReflection.GetMethodInfo((InterceptionBehaviorPipeline pip) => pip.Invoke(null, null));
}
