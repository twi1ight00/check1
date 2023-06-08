using System;
using System.Reflection;
using Microsoft.Practices.ObjectBuilder2;

namespace Microsoft.Practices.Unity.InterceptionExtension;

internal static class InvokeInterceptionBehaviorDelegateMethods
{
	internal static ConstructorInfo InvokeInterceptionBehaviorDelegate => typeof(InvokeInterceptionBehaviorDelegate).GetConstructor(Sequence.Collect<Type>(typeof(object), typeof(IntPtr)));
}
