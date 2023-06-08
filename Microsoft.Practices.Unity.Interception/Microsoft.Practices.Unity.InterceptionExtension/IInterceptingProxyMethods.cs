using System.Reflection;
using Microsoft.Practices.Unity.Utility;

namespace Microsoft.Practices.Unity.InterceptionExtension;

internal static class IInterceptingProxyMethods
{
	internal static MethodInfo AddInterceptionBehavior => StaticReflection.GetMethodInfo((IInterceptingProxy ip) => ip.AddInterceptionBehavior(null));
}
