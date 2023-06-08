using System.Drawing;
using ns87;

namespace ns84;

internal class Class4295 : Class4269
{
	internal enum Enum601
	{
		const_0,
		const_1,
		const_2,
		const_3
	}

	private Enum601 enum601_0;

	public Color Color => enum601_0 switch
	{
		Enum601.const_0 => method_2(Enum600.const_47), 
		Enum601.const_1 => method_2(Enum600.const_52), 
		Enum601.const_2 => method_2(Enum600.const_58), 
		Enum601.const_3 => method_2(Enum600.const_33), 
		_ => Color.Black, 
	};

	public Class4221 Width => enum601_0 switch
	{
		Enum601.const_0 => new Class4221(method_0(Enum600.const_49)), 
		Enum601.const_1 => new Class4221(method_0(Enum600.const_54)), 
		Enum601.const_2 => new Class4221(method_0(Enum600.const_62)), 
		Enum601.const_3 => new Class4221(method_0(Enum600.const_37)), 
		_ => null, 
	};

	public Enum605 Style => enum601_0 switch
	{
		Enum601.const_0 => method_1<Enum605>(Enum600.const_48), 
		Enum601.const_1 => method_1<Enum605>(Enum600.const_53), 
		Enum601.const_2 => method_1<Enum605>(Enum600.const_61), 
		Enum601.const_3 => method_1<Enum605>(Enum600.const_36), 
		_ => Enum605.const_0, 
	};

	internal Class4295(Class4345 model, Enum601 elementType)
		: base(model)
	{
		enum601_0 = elementType;
	}
}
