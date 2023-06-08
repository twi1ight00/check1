using ns234;

namespace ns237;

internal class Class6513 : Class6511
{
	private int int_1;

	internal int Length
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
		}
	}

	internal Class6513(Class6672 context)
		: base(context)
	{
	}

	public override void vmethod_0(Class6679 writer)
	{
		writer.method_29(this);
		writer.method_0(Class6159.smethod_24(int_1));
		writer.method_30();
	}
}
