using System;
using System.Reflection;
using Microsoft.Practices.Unity.Utility;

namespace Microsoft.Practices.Unity.InterceptionExtension;

internal static class MethodBaseMethods
{
	internal static MethodInfo GetMethodFromHandle => StaticReflection.GetMethodInfo(() => MethodBase.GetMethodFromHandle(default(RuntimeMethodHandle)));

	internal static MethodInfo GetMethodForGenericFromHandle => StaticReflection.GetMethodInfo(() => MethodBase.GetMethodFromHandle(default(RuntimeMethodHandle), default(RuntimeTypeHandle)));
}
