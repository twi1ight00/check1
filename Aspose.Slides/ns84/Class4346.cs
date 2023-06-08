using ns73;
using ns76;
using ns87;

namespace ns84;

internal class Class4346 : Class4345
{
	private Interface89 interface89_0;

	private string string_0;

	private Class3726 class3726_0;

	public Enum554 Fit => method_0<Enum554>(Enum600.const_101);

	public Class4219 FitPosition => new Class4219(vmethod_0(Enum600.const_102));

	public Enum559 Marks => method_0<Enum559>(Enum600.const_166);

	public Class4338 Bleed => method_2(Enum600.const_26);

	public Class4296 Margin => new Class4296(this);

	public Class4296 FirstPageMargin => new Class4296(new Class4346(interface89_0, Class4342.smethod_2(Enum514.const_6)));

	public Class4296 LeftPageMargin => new Class4296(new Class4346(interface89_0, Class4342.smethod_2(Enum514.const_7)));

	public Class4296 RightPageMargin => new Class4296(new Class4346(interface89_0, Class4342.smethod_2(Enum514.const_8)));

	public Class4174 Size => new Class4174(vmethod_0(Enum600.const_228));

	public Class4299 Background => new Class4299(this);

	public Class4298 Border => new Class4298(this);

	public Class4294 Font => new Class4294(this);

	internal Class4346(Interface89 document)
		: this(document, null)
	{
	}

	internal Class4346(Interface89 document, string pseudoElement)
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
