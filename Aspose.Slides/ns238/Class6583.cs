using System.Collections.Generic;
using ns224;

namespace ns238;

internal class Class6583 : Class6568
{
	private short short_0 = 1;

	private List<Class6591> list_0 = new List<Class6591>();

	private short short_1;

	public short CharacterId => short_1;

	public Class6583(Class6567 context, short characterId)
		: base(context)
	{
		short_1 = characterId;
	}

	public void method_0(short childId, Class6002 renderTransform, string name)
	{
		method_1(childId, renderTransform, name, isClip: false);
	}

	public void method_1(short childId, Class6002 renderTransform, string name, bool isClip)
	{
		Class6591 item = new Class6591(childId, renderTransform, short_0++, name, isClip);
		list_0.Add(item);
	}

	public void Write()
	{
		Class6584 @class = new Class6584(base.Context);
		@class.method_0();
		base.Writer.method_1(short_1);
		base.Writer.method_1(1);
		Class6580 class2 = new Class6580(base.Context);
		foreach (Class6591 item in list_0)
		{
			class2.method_1(item);
		}
		base.Writer.method_16(Enum878.const_1, 0);
		base.Writer.method_16(Enum878.const_0, 0);
		@class.method_1(Enum878.const_31);
	}
}
