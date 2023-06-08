using System.Collections.Generic;
using System.IO;

namespace ns71;

internal class Class3512 : Class3473
{
	private readonly int int_0;

	private List<Class3513> list_0 = new List<Class3513>();

	public List<Class3513> References
	{
		get
		{
			return list_0;
		}
		set
		{
			list_0 = value;
		}
	}

	internal Class3512(int codePage)
	{
		int_0 = codePage;
	}

	internal void method_0()
	{
	}

	internal override void vmethod_0(BinaryReader reader)
	{
		while (Class3522.smethod_0(reader) != 15)
		{
			Class3513 @class = new Class3513(int_0);
			@class.vmethod_0(reader);
			list_0.Add(@class);
		}
	}

	internal override void vmethod_1(BinaryWriter writer)
	{
		foreach (Class3513 item in list_0)
		{
			item.vmethod_1(writer);
		}
	}
}
