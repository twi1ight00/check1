using System.Reflection;
using Microsoft.Practices.Unity.Utility;

namespace Microsoft.Practices.Unity.InterceptionExtension;

internal static class IMethodReturnMethods
{
	internal static MethodInfo GetException => StaticReflection.GetPropertyGetMethodInfo((IMethodReturn imr) => imr.Exception);

	internal static MethodInfo GetReturnValue => StaticReflection.GetPropertyGetMethodInfo((IMethodReturn imr) => imr.ReturnValue);

	internal static MethodInfo GetOutputs => StaticReflection.GetPropertyGetMethodInfo((IMethodReturn imr) => imr.Outputs);
}
