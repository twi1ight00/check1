using System.Reflection;

namespace Microsoft.Practices.ObjectBuilder2;

/// <summary>
/// Objects of this type are the return value from <see cref="M:Microsoft.Practices.ObjectBuilder2.IConstructorSelectorPolicy.SelectConstructor(Microsoft.Practices.ObjectBuilder2.IBuilderContext,Microsoft.Practices.ObjectBuilder2.IPolicyList)" />.
/// It encapsulates the desired <see cref="T:System.Reflection.ConstructorInfo" /> with the string keys
/// needed to look up the <see cref="T:Microsoft.Practices.ObjectBuilder2.IDependencyResolverPolicy" /> for each
/// parameter.
/// </summary>
public class SelectedConstructor : SelectedMemberWithParameters<ConstructorInfo>
{
	/// <summary>
	/// The constructor this object wraps.
	/// </summary>
	public ConstructorInfo Constructor => base.MemberInfo;

	/// <summary>
	/// Create a new <see cref="T:Microsoft.Practices.ObjectBuilder2.SelectedConstructor" /> instance which
	/// contains the given constructor.
	/// </summary>
	/// <param name="constructor">The constructor to wrap.</param>
	public SelectedConstructor(ConstructorInfo constructor)
		: base(constructor)
	{
	}
}
