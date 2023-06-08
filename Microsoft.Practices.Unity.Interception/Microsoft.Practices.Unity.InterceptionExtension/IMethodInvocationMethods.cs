using System.Reflection;
using Microsoft.Practices.Unity.Utility;

namespace Microsoft.Practices.Unity.InterceptionExtension;

/// <summary>
/// MethodInfo objects for the methods we need to generate
/// calls to on IMethodInvocation.
/// </summary>
internal static class IMethodInvocationMethods
{
	internal static MethodInfo CreateExceptionMethodReturn => StaticReflection.GetMethodInfo((IMethodInvocation mi) => mi.CreateExceptionMethodReturn(null));

	internal static MethodInfo CreateReturn => typeof(IMethodInvocation).GetMethod("CreateMethodReturn");

	internal static MethodInfo GetArguments => StaticReflection.GetPropertyGetMethodInfo((IMethodInvocation mi) => mi.Arguments);
}
