using System.Collections;
using System.Reflection;

namespace Microsoft.Practices.Unity.InterceptionExtension;

internal static class IListMethods
{
	internal static MethodInfo GetItem => typeof(IList).GetProperty("Item").GetGetMethod();
}
