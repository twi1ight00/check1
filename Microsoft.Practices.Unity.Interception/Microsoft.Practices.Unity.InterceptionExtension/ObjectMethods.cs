using System.Reflection;
using Microsoft.Practices.Unity.Utility;

namespace Microsoft.Practices.Unity.InterceptionExtension;

internal static class ObjectMethods
{
	internal static ConstructorInfo Constructor => StaticReflection.GetConstructorInfo(() => new object());
}
