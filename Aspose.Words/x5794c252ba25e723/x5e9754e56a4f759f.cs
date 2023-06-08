using System.Drawing;
using System.Drawing.Drawing2D;

namespace x5794c252ba25e723;

internal class x5e9754e56a4f759f : x7fafd7c73d78a86d
{
	private x26d9ecb4bdf0456d[] xbd534f9b93225dac;

	private byte[] xd08494dce3b2b550;

	private float xf51fb015c49ee063 = float.MinValue;

	private RectangleF x42e0f67f3a0cb7dc = RectangleF.Empty;

	public byte[] xcc18177a965e0313
	{
		get
		{
			return xd08494dce3b2b550;
		}
		set
		{
			xd08494dce3b2b550 = value;
		}
	}

	public float xd163a712710650fc
	{
		get
		{
			return xf51fb015c49ee063;
		}
		set
		{
			xf51fb015c49ee063 = value;
		}
	}

	public x26d9ecb4bdf0456d[] xe25bcbc1e660bc36
	{
		get
		{
			return xbd534f9b93225dac;
		}
		set
		{
			xbd534f9b93225dac = value;
		}
	}

	public RectangleF x42eb8f4390d1e7ba
	{
		get
		{
			return x42e0f67f3a0cb7dc;
		}
		set
		{
			x42e0f67f3a0cb7dc = value;
		}
	}

	public x5e9754e56a4f759f(byte[] imageBytes)
		: this(imageBytes, WrapMode.Tile)
	{
	}

	public x5e9754e56a4f759f(byte[] imageBytes, WrapMode wrapMode)
		: base(x0b257a9fb413b6c3.x7b6a6d281546db99)
	{
		xcc18177a965e0313 = imageBytes;
		base.xaccac17571a8d9fa = new x54366fa5f75a02f7();
		base.x349ff0df1e641b4e = wrapMode;
	}
}
