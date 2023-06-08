using x1c8faa688b1f0b0c;
using x24ed092a62874e86;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;
using x9e34b6f7e9185197;
using xa6cc8e39f9a280d7;

namespace x0a3ff9616df4cd36;

internal class x2c421831b88cb0f0 : x4e72ffd52a21c3db, x506b258dd39c6252
{
	private xd7e8497b32a408b8 xd7ebed0b19ceb7cd;

	private xd7e8497b32a408b8 x53032877bdcc2140;

	xd9934398f56f27df x506b258dd39c6252.x6962a32db28ceac6 => xd9934398f56f27df.x0559141203f05fd7;

	public xd7e8497b32a408b8 x55319f8d2729ba13
	{
		get
		{
			return xd7ebed0b19ceb7cd;
		}
		set
		{
			xd7ebed0b19ceb7cd = value;
		}
	}

	public xd7e8497b32a408b8 x94bdef4042073f5c
	{
		get
		{
			return x53032877bdcc2140;
		}
		set
		{
			x53032877bdcc2140 = value;
		}
	}

	public x2c421831b88cb0f0(x6ecdfaec63740001 themeProvider)
		: base(themeProvider)
	{
	}

	public override void x550781f8db1cf5f2(x1844bb3f2776c1ac xea2f73f1401ce568, xfe2ff3c162b47c70 xa26acc418ddb3483, xda4dde4038ab80db x908dde28884ab446)
	{
		x506b258dd39c6252 x506b258dd39c6253 = new x14681578a79d12dc(x2898a4fa3477fa50);
		x506b258dd39c6253.x550781f8db1cf5f2(xea2f73f1401ce568, xa26acc418ddb3483, x908dde28884ab446);
		xea2f73f1401ce568.x698e9b05d858b9d7.xb526ae6a95468f9a(xf6795ad0205a0397(x908dde28884ab446));
	}

	public override void x550781f8db1cf5f2(xab391c46ff9a0a38 xe125219852864557, xda4dde4038ab80db x908dde28884ab446)
	{
		x506b258dd39c6252 x506b258dd39c6253 = new x14681578a79d12dc(x2898a4fa3477fa50);
		x506b258dd39c6253.x550781f8db1cf5f2(xe125219852864557, x908dde28884ab446);
		base.x550781f8db1cf5f2(xe125219852864557, x908dde28884ab446);
	}

	protected override xc020fa2f5133cba8 ChangeBrush(xc020fa2f5133cba8 brush, xda4dde4038ab80db additionalColorModifier)
	{
		return new xc020fa2f5133cba8(x1f2ba9b7cb678190.x30864e0aab264e78(brush.x9b41425268471380, xf6795ad0205a0397(additionalColorModifier)));
	}

	private x1f2ba9b7cb678190 xf6795ad0205a0397(xda4dde4038ab80db x908dde28884ab446)
	{
		return xc06ff6ce7d4ff5b3.xe7b2641dc5375bea(x908dde28884ab446, x2898a4fa3477fa50, x55319f8d2729ba13, x94bdef4042073f5c);
	}
}
