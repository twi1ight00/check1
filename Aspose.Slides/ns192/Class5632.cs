using System;

namespace ns192;

internal class Class5632 : Class5630
{
	internal Class5632(Class5156 table, Class5155 row, int colIndex)
		: base(table, 0, 0)
	{
		method_3(row);
	}

	protected override void vmethod_0()
	{
		class5722_0 = Class5722.smethod_0(class5711_0);
		class5722_1 = Class5722.smethod_0(class5711_0);
		class5706_0 = Class5706.smethod_0();
		class5706_1 = Class5706.smethod_0();
	}

	public override Class5631 vmethod_1()
	{
		throw new NotSupportedException();
	}

	public override bool vmethod_2()
	{
		return false;
	}

	public override bool vmethod_3()
	{
		return true;
	}

	public override bool vmethod_4()
	{
		return true;
	}
}
