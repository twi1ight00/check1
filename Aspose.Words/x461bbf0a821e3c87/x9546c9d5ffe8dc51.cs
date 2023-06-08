using Aspose.Words.Tables;
using x9db5f2e5af3d596e;

namespace x461bbf0a821e3c87;

internal class x9546c9d5ffe8dc51
{
	private readonly xf8cef531dae89ea3 xede608e9bc344cf9;

	private readonly bool xc0db85428f03a11e;

	private int x30847a984f14c2c8 = 1;

	private int xd21e01f8913f5ed9 = 1;

	private readonly Cell x0bad497096c4da58;

	internal xf8cef531dae89ea3 xf8cef531dae89ea3 => xede608e9bc344cf9;

	internal Cell x82d4d8bcc20a864f => x0bad497096c4da58;

	internal bool xccc3088817e63d2c => xc0db85428f03a11e;

	internal int x2f4795c5e4c1617e
	{
		get
		{
			return x30847a984f14c2c8;
		}
		set
		{
			x30847a984f14c2c8 = value;
		}
	}

	internal int xe9fd99df52338f59
	{
		get
		{
			return xd21e01f8913f5ed9;
		}
		set
		{
			xd21e01f8913f5ed9 = value;
		}
	}

	private x9546c9d5ffe8dc51(bool isPad, xf8cef531dae89ea3 cellPr, Cell cellNode)
	{
		xc0db85428f03a11e = isPad;
		xede608e9bc344cf9 = cellPr;
		x0bad497096c4da58 = cellNode;
	}

	internal static x9546c9d5ffe8dc51 x3f6efc6c7757adcf(xf8cef531dae89ea3 x51dd02ffcbaa972d, Cell xefe1b783eaf4ab44)
	{
		return new x9546c9d5ffe8dc51(isPad: false, (xf8cef531dae89ea3)x51dd02ffcbaa972d.x8b61531c8ea35b85(), xefe1b783eaf4ab44);
	}

	internal static x9546c9d5ffe8dc51 x64306b032bd977c9(xf8cef531dae89ea3 x51dd02ffcbaa972d, Cell xefe1b783eaf4ab44)
	{
		x9546c9d5ffe8dc51 x9546c9d5ffe8dc52 = x3f6efc6c7757adcf(x51dd02ffcbaa972d, xefe1b783eaf4ab44);
		xf8cef531dae89ea3 xf8cef531dae89ea = x9546c9d5ffe8dc52.xede608e9bc344cf9;
		xf8cef531dae89ea.x338a5e6ab7c5595e = CellMerge.Previous;
		xf8cef531dae89ea.xa8c2637cc4888928 = x51dd02ffcbaa972d.xa8c2637cc4888928;
		xf8cef531dae89ea.xaea087ab32102492 = x51dd02ffcbaa972d.xaea087ab32102492;
		xf8cef531dae89ea.x79d902473861f242 = x51dd02ffcbaa972d.x79d902473861f242;
		xf8cef531dae89ea.xd7a21e27974f626c = x51dd02ffcbaa972d.xd7a21e27974f626c;
		xf8cef531dae89ea.xbf9846a75147a8a9 = x51dd02ffcbaa972d.xbf9846a75147a8a9;
		xf8cef531dae89ea.xb5d07e936a4ada49 = x51dd02ffcbaa972d.xb5d07e936a4ada49;
		return x9546c9d5ffe8dc52;
	}

	internal static x9546c9d5ffe8dc51 xd0d8db66037c4103()
	{
		return new x9546c9d5ffe8dc51(isPad: true, new xf8cef531dae89ea3(), null);
	}
}
