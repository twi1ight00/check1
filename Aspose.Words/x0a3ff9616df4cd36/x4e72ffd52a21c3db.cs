using x1c8faa688b1f0b0c;
using x24ed092a62874e86;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;
using x9e34b6f7e9185197;
using xf84f8427dc22d095;

namespace x0a3ff9616df4cd36;

internal abstract class x4e72ffd52a21c3db : x506b258dd39c6252
{
	protected readonly x6ecdfaec63740001 x2898a4fa3477fa50;

	xd9934398f56f27df x506b258dd39c6252.x6962a32db28ceac6 => xd9934398f56f27df.x7b8788264ab563ac;

	protected x4e72ffd52a21c3db(x6ecdfaec63740001 themeProvider)
	{
		x2898a4fa3477fa50 = themeProvider;
	}

	protected virtual xc020fa2f5133cba8 ChangeBrush(xc020fa2f5133cba8 brush, xda4dde4038ab80db additionalColorModifier)
	{
		return brush;
	}

	public virtual void x550781f8db1cf5f2(x1844bb3f2776c1ac xea2f73f1401ce568, xfe2ff3c162b47c70 xa26acc418ddb3483, xda4dde4038ab80db x908dde28884ab446)
	{
	}

	public virtual void x550781f8db1cf5f2(xab391c46ff9a0a38 xe125219852864557, xda4dde4038ab80db x908dde28884ab446)
	{
		if (xe125219852864557.x9e5d5f9128c69a8f != null && xe125219852864557.x9e5d5f9128c69a8f.x60465f602599d327 is xc020fa2f5133cba8)
		{
			xe125219852864557.x9e5d5f9128c69a8f.x60465f602599d327 = ChangeBrush((xc020fa2f5133cba8)xe125219852864557.x9e5d5f9128c69a8f.x60465f602599d327, x908dde28884ab446);
		}
		if (xe125219852864557.x60465f602599d327 != null && xe125219852864557.x60465f602599d327 is xc020fa2f5133cba8)
		{
			xe125219852864557.x60465f602599d327 = ChangeBrush((xc020fa2f5133cba8)xe125219852864557.x60465f602599d327, x908dde28884ab446);
		}
	}

	internal virtual x173da201543be1fe xb5c45a878919d53b(xda4dde4038ab80db x908dde28884ab446)
	{
		return new x173da201543be1fe(this, x908dde28884ab446);
	}
}
