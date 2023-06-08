using x24ed092a62874e86;
using x38a89dee67fc7a16;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;
using x9e34b6f7e9185197;
using xa6cc8e39f9a280d7;

namespace x0a3ff9616df4cd36;

internal class xd096be68e56d04ab : x4e72ffd52a21c3db, x506b258dd39c6252
{
	private const int x811a41573b9c66db = 10;

	private xd7e8497b32a408b8 xc149d14a92c0e8bc;

	private xd7e8497b32a408b8 x7bdf9b2b2a477f89;

	private bool x68dda4598210c0d3;

	xd9934398f56f27df x506b258dd39c6252.x6962a32db28ceac6 => xd9934398f56f27df.x682bf606592add24;

	public xd7e8497b32a408b8 xe45d094267773d42
	{
		get
		{
			return xc149d14a92c0e8bc;
		}
		set
		{
			xc149d14a92c0e8bc = value;
		}
	}

	public xd7e8497b32a408b8 xefc54b39ecf0f4f0
	{
		get
		{
			return x7bdf9b2b2a477f89;
		}
		set
		{
			x7bdf9b2b2a477f89 = value;
		}
	}

	public bool xf5442a8f9a3234d8
	{
		get
		{
			return x68dda4598210c0d3;
		}
		set
		{
			x68dda4598210c0d3 = value;
		}
	}

	public xd096be68e56d04ab(x6ecdfaec63740001 themeProvider)
		: base(themeProvider)
	{
	}

	public override void x550781f8db1cf5f2(x1844bb3f2776c1ac xea2f73f1401ce568, xfe2ff3c162b47c70 xa26acc418ddb3483, xda4dde4038ab80db x908dde28884ab446)
	{
		x26d9ecb4bdf0456d x26d9ecb4bdf0456d = x8e140fff7b258952(x908dde28884ab446);
		x26d9ecb4bdf0456d x26d9ecb4bdf0456d2 = x5335fe131cc1e94d(x908dde28884ab446);
		if (xa26acc418ddb3483 == xfe2ff3c162b47c70.x796ab23ce57ee1e0)
		{
			xb6c5e334584625b7(xea2f73f1401ce568, x26d9ecb4bdf0456d, x26d9ecb4bdf0456d2);
			return;
		}
		xaf230aa026fb819b[] x23029bec4dd3e = new xaf230aa026fb819b[1]
		{
			new xaf230aa026fb819b(x26d9ecb4bdf0456d, x26d9ecb4bdf0456d2)
		};
		xea2f73f1401ce568.x698e9b05d858b9d7.xbe789c544c465680(x23029bec4dd3e);
	}

	protected override xc020fa2f5133cba8 ChangeBrush(xc020fa2f5133cba8 brush, xda4dde4038ab80db additionalColorModifier)
	{
		x26d9ecb4bdf0456d x9b41425268471380 = brush.x9b41425268471380;
		x26d9ecb4bdf0456d color = x9b41425268471380;
		if (x26d9ecb4bdf0456d.Equals(x9b41425268471380, x8e140fff7b258952(additionalColorModifier)))
		{
			color = x5335fe131cc1e94d(additionalColorModifier);
		}
		return new xc020fa2f5133cba8(color);
	}

	private void xb6c5e334584625b7(x1844bb3f2776c1ac xea2f73f1401ce568, x26d9ecb4bdf0456d xd8f4ced32393873c, x26d9ecb4bdf0456d x4d74759054fd8037)
	{
		xea2f73f1401ce568.x698e9b05d858b9d7.xf276f6a75b584d31 = new xf276f6a75b584d31(xd8f4ced32393873c, 10);
		xea2f73f1401ce568.x4c3c038aa99fff39(x4d74759054fd8037);
	}

	private x26d9ecb4bdf0456d x8e140fff7b258952(xda4dde4038ab80db x908dde28884ab446)
	{
		x26d9ecb4bdf0456d x26d9ecb4bdf0456d = xe45d094267773d42.x9f7ccd52de411b4f(x2898a4fa3477fa50, x908dde28884ab446);
		if (!xf5442a8f9a3234d8)
		{
			x26d9ecb4bdf0456d = new x26d9ecb4bdf0456d(255, x26d9ecb4bdf0456d);
		}
		return x26d9ecb4bdf0456d;
	}

	private x26d9ecb4bdf0456d x5335fe131cc1e94d(xda4dde4038ab80db x908dde28884ab446)
	{
		return xefc54b39ecf0f4f0.x9f7ccd52de411b4f(x2898a4fa3477fa50, x908dde28884ab446);
	}
}
