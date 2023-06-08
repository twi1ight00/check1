namespace x2182451cabb5c30d;

internal class xaa8e066abda92f6a : x92b42501109671de
{
	private readonly bool x437d78dd0d3af214;

	private object xfa6aceda0ccea535;

	private int xaabccab0c06d038b = 1;

	protected override string FieldTypeName => " TC  ";

	internal xaa8e066abda92f6a(xe5e546ef5f0503b2 context, bool isOmitPageNumbers)
		: base(context)
	{
		x437d78dd0d3af214 = isOmitPageNumbers;
	}

	internal override void x41e7a76e7e854e6e(x03f56b37a0050a82 x153c99a852375422)
	{
		if (base.x1a55de3a01c1c82d.x3146d638ec378671 == x25099a8bbbd55d1c.x1f66870c9a2c74a4)
		{
			x0769cdcc579bd707(x153c99a852375422);
		}
		base.x41e7a76e7e854e6e(x153c99a852375422);
	}

	internal override void xa4085ff83f9ddeeb()
	{
		if (base.x1a55de3a01c1c82d.x3146d638ec378671 == x25099a8bbbd55d1c.x1f66870c9a2c74a4)
		{
			xbbbbc5ea4258e1a4();
		}
		base.xa4085ff83f9ddeeb();
	}

	protected override void WriteSwitches()
	{
		if (x437d78dd0d3af214)
		{
			base.xe1410f585439c7d4.x93a8c149d218a60f("\\n");
		}
		if (xaabccab0c06d038b != 1)
		{
			base.xe1410f585439c7d4.x93a8c149d218a60f($" \\l {xaabccab0c06d038b}");
		}
		if (xfa6aceda0ccea535 != null)
		{
			base.xe1410f585439c7d4.x93a8c149d218a60f($" \\f {(char)xfa6aceda0ccea535}");
		}
	}

	internal override void xa2d8e36cb99ac0f4(x03f56b37a0050a82 x153c99a852375422)
	{
		switch (x153c99a852375422.x1dafd189c5465293())
		{
		case "\\tcl":
			xaabccab0c06d038b = x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		case "\\tcf":
			xfa6aceda0ccea535 = (char)x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		default:
			base.xa2d8e36cb99ac0f4(x153c99a852375422);
			break;
		}
	}
}
