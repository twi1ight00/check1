using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Security;
using System.Security.Permissions;

namespace Microsoft.Practices.Unity.InterceptionExtension;

/// <summary>
/// A class that wraps the inputs of a <see cref="T:System.Runtime.Remoting.Messaging.IMethodCallMessage" /> into the
/// <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.IParameterCollection" /> interface.
/// </summary>
[SecurityCritical(SecurityCriticalScope.Everything)]
[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.Infrastructure)]
internal class TransparentProxyInputParameterCollection : ParameterCollection
{
	/// <summary>
	/// Constructs a new <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.TransparentProxyInputParameterCollection" /> that wraps the
	/// given method call and arguments.
	/// </summary>
	/// <param name="callMessage">The call message.</param>
	/// <param name="arguments">The arguments.</param>
	public TransparentProxyInputParameterCollection(IMethodCallMessage callMessage, object[] arguments)
		: base(arguments, callMessage.MethodBase.GetParameters(), (ParameterInfo info) => !info.IsOut)
	{
	}
}
