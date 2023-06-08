using ns73;
using ns76;
using ns84;
using ns87;

namespace ns94;

internal class Class4348 : Class4345
{
	private Interface89 interface89_0;

	private string string_0;

	private Class3726 class3726_0;

	public Class4217 Top => new Class4217(vmethod_0(Enum600.const_165));

	public Class4217 Right => new Class4217(vmethod_0(Enum600.const_164));

	public Class4217 Bottom => new Class4217(vmethod_0(Enum600.const_162));

	public Class4217 Left => new Class4217(vmethod_0(Enum600.const_163));

	internal Class4348(Interface89 document)
		: this(document, null)
	{
	}

	internal Class4348(Interface89 document, string pseudoElement)
	{
		interface89_0 = document;
		string_0 = pseudoElement;
		class3726_0 = (Class3726)document.Engine;
	}

	internal override Class3679 vmethod_0(Enum600 type)
	{
		int propertyIndex = class3726_0.method_1(type);
		return class3726_0.method_15(string_0, propertyIndex);
	}

	internal override Class3679 vmethod_1(Enum600 type, string pseudo)
	{
		int propertyIndex = class3726_0.method_1(type);
		return class3726_0.method_15(pseudo, propertyIndex);
	}
}
