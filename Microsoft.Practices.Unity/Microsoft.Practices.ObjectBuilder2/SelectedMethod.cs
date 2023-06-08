using System.Reflection;

namespace Microsoft.Practices.ObjectBuilder2;

/// <summary>
/// Objects of this type are the return value from <see cref="M:Microsoft.Practices.ObjectBuilder2.IMethodSelectorPolicy.SelectMethods(Microsoft.Practices.ObjectBuilder2.IBuilderContext,Microsoft.Practices.ObjectBuilder2.IPolicyList)" />.
/// It encapsulates the desired <see cref="T:System.Reflection.MethodInfo" /> with the string keys
/// needed to look up the <see cref="T:Microsoft.Practices.ObjectBuilder2.IDependencyResolverPolicy" /> for each
/// parameter.
/// </summary>
public class SelectedMethod : SelectedMemberWithParameters<MethodInfo>
{
	/// <summary>
	/// The constructor this object wraps.
	/// </summary>
	public MethodInfo Method => base.MemberInfo;

	/// <summary>
	/// Create a new <see cref="T:Microsoft.Practices.ObjectBuilder2.SelectedMethod" /> instance which
	/// contains the given method.
	/// </summary>
	/// <param name="method">The method</param>
	public SelectedMethod(MethodInfo method)
		: base(method)
	{
	}
}
