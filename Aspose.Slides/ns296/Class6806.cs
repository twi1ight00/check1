using ns277;
using ns284;
using ns286;
using ns84;

namespace ns296;

internal abstract class Class6806
{
	private Class6983 class6983_0;

	private Interface355 interface355_0;

	private Class6772 class6772_0;

	public Interface355 Settings => interface355_0;

	public Class6983 Element => class6983_0;

	public Class4347 StyleDeclaration => class6983_0.StyleDeclarationInternal;

	public Class6772 Builder => class6772_0;

	protected Class6806(Class6983 element)
		: this(element, null, null)
	{
	}

	protected Class6806(Class6983 element, Interface355 settings)
		: this(element, settings, null)
	{
	}

	protected Class6806(Class6983 element, Interface355 settings, Class6772 builder)
	{
		class6983_0 = element;
		interface355_0 = settings;
		class6772_0 = builder;
	}

	public abstract string vmethod_0();
}
