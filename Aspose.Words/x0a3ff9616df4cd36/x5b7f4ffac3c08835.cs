using x1c8faa688b1f0b0c;
using x24ed092a62874e86;
using x5794c252ba25e723;
using x6b8130194ad714f7;
using x6c95d9cf46ff5f25;
using x9e34b6f7e9185197;

namespace x0a3ff9616df4cd36;

internal class x5b7f4ffac3c08835 : x4e72ffd52a21c3db, x506b258dd39c6252
{
	private x55c6a66cc28d5b86 xbc445cc2cc6088dd = new x55c6a66cc28d5b86();

	xd9934398f56f27df x506b258dd39c6252.x6962a32db28ceac6 => xd9934398f56f27df.x4715beec4f069776;

	public x55c6a66cc28d5b86 xd3f06edc344811a0
	{
		get
		{
			return xbc445cc2cc6088dd;
		}
		set
		{
			xbc445cc2cc6088dd = value;
		}
	}

	public x5b7f4ffac3c08835(x6ecdfaec63740001 themeProvider)
		: base(themeProvider)
	{
	}

	public override void x550781f8db1cf5f2(x1844bb3f2776c1ac xea2f73f1401ce568, xfe2ff3c162b47c70 xa26acc418ddb3483, xda4dde4038ab80db x908dde28884ab446)
	{
		x506b258dd39c6252 x506b258dd39c6253 = new x14681578a79d12dc(x2898a4fa3477fa50);
		x506b258dd39c6253.x550781f8db1cf5f2(xea2f73f1401ce568, xa26acc418ddb3483, x908dde28884ab446);
		xea2f73f1401ce568.x698e9b05d858b9d7.xd3f06edc344811a0 = (float)xd3f06edc344811a0.x71c5078172d72420 - 0.01f;
	}

	public override void x550781f8db1cf5f2(xab391c46ff9a0a38 xe125219852864557, xda4dde4038ab80db x908dde28884ab446)
	{
		x506b258dd39c6252 x506b258dd39c6253 = new x14681578a79d12dc(x2898a4fa3477fa50);
		x506b258dd39c6253.x550781f8db1cf5f2(xe125219852864557, x908dde28884ab446);
		base.x550781f8db1cf5f2(xe125219852864557, x908dde28884ab446);
	}

	protected override xc020fa2f5133cba8 ChangeBrush(xc020fa2f5133cba8 brush, xda4dde4038ab80db additionalColorModifier)
	{
		int num = x15e971129fd80714.xffd822a191639f47(255.0 * xd3f06edc344811a0.x71c5078172d72420);
		x26d9ecb4bdf0456d x9b41425268471380 = brush.x9b41425268471380;
		x26d9ecb4bdf0456d color = ((x9b41425268471380.xc613adc4330033f3 < num) ? new x26d9ecb4bdf0456d(x9b41425268471380.xda71bf6f7c07c3bc, 0, 0, 0) : new x26d9ecb4bdf0456d(x9b41425268471380.xda71bf6f7c07c3bc, 255, 255, 255));
		return new xc020fa2f5133cba8(color);
	}
}
