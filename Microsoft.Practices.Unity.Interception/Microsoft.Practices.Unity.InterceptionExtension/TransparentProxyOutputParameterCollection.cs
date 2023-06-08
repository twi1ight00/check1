using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Security;
using System.Security.Permissions;

namespace Microsoft.Practices.Unity.InterceptionExtension;

/// <summary>
/// A class that wraps the outputs of a <see cref="T:System.Runtime.Remoting.Messaging.IMethodCallMessage" /> into the
/// <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.IParameterCollection" /> interface.
/// </summary>
[SecurityCritical(SecurityCriticalScope.Everything)]
[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.Infrastructure)]
internal class TransparentProxyOutputParameterCollection : ParameterCollection
{
	/// <summary>
	/// Constructs a new <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.TransparentProxyOutputParameterCollection" /> that wraps the
	/// given method call and arguments.
	/// </summary>
	/// <param name="callMessage">The call message.</param>
	/// <param name="arguments">The arguments.</param>
	public TransparentProxyOutputParameterCollection(IMethodCallMessage callMessage, object[] arguments)
		: base(arguments, callMessage.MethodBase.GetParameters(), (ParameterInfo parameterInfo) => parameterInfo.ParameterType.IsByRef)
	{
	}
}
