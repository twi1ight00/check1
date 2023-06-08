using System.Reflection;
using Microsoft.Practices.Unity.Utility;

namespace Microsoft.Practices.Unity.InterceptionExtension;

internal static class VirtualMethodInvocationMethods
{
	internal static ConstructorInfo VirtualMethodInvocation => StaticReflection.GetConstructorInfo(() => new VirtualMethodInvocation(null, null));
}
