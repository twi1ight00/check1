using System.Collections.Generic;
using ns305;
using ns84;

namespace ns86;

internal class Class4150 : Class4147
{
	private List<Enum630> list_0;

	public Class4150(params Enum630[] display)
	{
		list_0 = new List<Enum630>(display);
	}

	public override bool imethod_0(Class6981 candidate)
	{
		Class4347 @class = Class4347.smethod_1(candidate);
		return list_0.Contains(@class.Display.Value);
	}
}
