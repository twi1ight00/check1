using x24ed092a62874e86;
using x5794c252ba25e723;
using x6b8130194ad714f7;
using x6c95d9cf46ff5f25;
using x9e34b6f7e9185197;

namespace x0a3ff9616df4cd36;

internal class xb9219c89b0d3221b : x4e72ffd52a21c3db, x506b258dd39c6252
{
	private x55c6a66cc28d5b86 x376458a60fc4b5e2 = new x55c6a66cc28d5b86();

	private x55c6a66cc28d5b86 xadfe4e32d177d042 = new x55c6a66cc28d5b86();

	xd9934398f56f27df x506b258dd39c6252.x6962a32db28ceac6 => xd9934398f56f27df.xe921ddf3432f012a;

	public x55c6a66cc28d5b86 x6389c51ad2820f52
	{
		get
		{
			return x376458a60fc4b5e2;
		}
		set
		{
			x376458a60fc4b5e2 = value;
		}
	}

	public x55c6a66cc28d5b86 x4f7155e57c89d548
	{
		get
		{
			return xadfe4e32d177d042;
		}
		set
		{
			xadfe4e32d177d042 = value;
		}
	}

	public xb9219c89b0d3221b(x6ecdfaec63740001 themeProvider)
		: base(themeProvider)
	{
	}

	public override void x550781f8db1cf5f2(x1844bb3f2776c1ac xea2f73f1401ce568, xfe2ff3c162b47c70 xa26acc418ddb3483, xda4dde4038ab80db x908dde28884ab446)
	{
		xea2f73f1401ce568.x698e9b05d858b9d7.xb526ae6a95468f9a(xf6795ad0205a0397());
	}

	protected override xc020fa2f5133cba8 ChangeBrush(xc020fa2f5133cba8 brush, xda4dde4038ab80db additionalColorModifier)
	{
		return new xc020fa2f5133cba8(x1f2ba9b7cb678190.x30864e0aab264e78(brush.x9b41425268471380, xf6795ad0205a0397()));
	}

	private x1f2ba9b7cb678190 xf6795ad0205a0397()
	{
		float x6eebe5873d5613d = ((float)x4f7155e57c89d548.x71c5078172d72420 + 1f) / 2f;
		float x7245ca8139eba = ((float)x6389c51ad2820f52.x71c5078172d72420 + 1f) / 2f;
		return xc06ff6ce7d4ff5b3.xd2ad080e85a27b04(x6eebe5873d5613d, x7245ca8139eba);
	}
}
