using System.Drawing;
using x6c95d9cf46ff5f25;

namespace x1c8faa688b1f0b0c;

internal class xc67adcdbca121a26 : xbaec545ec01f92ca
{
	private const int x8742c51e2f24b653 = 0;

	private SizeF x3b77a41bd57164d6 = SizeF.Empty;

	private readonly int x7c466acb47993d36;

	public SizeF x437e3b626c0fdd43
	{
		get
		{
			return x3b77a41bd57164d6;
		}
		set
		{
			x3b77a41bd57164d6 = value;
		}
	}

	public float xdc1bf80853046136 => x3b77a41bd57164d6.Width;

	public float xb0f146032f47c24e => x3b77a41bd57164d6.Height;

	public int x87406eebf687e0d7 => x4574ea26106f0edb.xdbd829479885762d(xdc1bf80853046136);

	public int x0969cb0cdb4d079f => x4574ea26106f0edb.xdbd829479885762d(xb0f146032f47c24e);

	public int xef64f56541986736 => x7c466acb47993d36;

	public xc67adcdbca121a26(float width, float height)
		: this(new SizeF(width, height), 0)
	{
	}

	public xc67adcdbca121a26(SizeF size, int tray)
	{
		x3b77a41bd57164d6 = size;
		x7c466acb47993d36 = tray;
	}

	public override void Accept(xf51865b83a7a0b3b visitor)
	{
		visitor.VisitPageStart(this);
		base.Accept(visitor);
		visitor.VisitPageEnd(this);
	}
}
