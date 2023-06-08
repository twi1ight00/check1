using System.Drawing;
using System.IO;
using x5794c252ba25e723;

namespace x4f4df92b75ba3b67;

internal class x8b1c15f4cec97314 : x265d1165173b3fb3
{
	private MemoryStream x5121c5290eccb81c;

	private RectangleF x9284bbb976e4e2a2 = RectangleF.Empty;

	private x54366fa5f75a02f7 x435b26849f0d2436;

	internal RectangleF x2727839aafc09868
	{
		get
		{
			return x9284bbb976e4e2a2;
		}
		set
		{
			x9284bbb976e4e2a2 = value;
		}
	}

	internal x54366fa5f75a02f7 xaccac17571a8d9fa
	{
		get
		{
			return x435b26849f0d2436;
		}
		set
		{
			x435b26849f0d2436 = value;
		}
	}

	internal MemoryStream xe36c96d8c564b382
	{
		get
		{
			return x5121c5290eccb81c;
		}
		set
		{
			x5121c5290eccb81c = value;
		}
	}

	public x8b1c15f4cec97314(x4882ae789be6e2ef context)
		: base(context)
	{
	}

	internal override void x0a2e1f2c2da67e52(x4f40d990d5bf81a6 xbdfb620b7167944b)
	{
		base.x0a2e1f2c2da67e52(xbdfb620b7167944b);
		xbdfb620b7167944b.xa4dc0ad8886e23a2("/Type", "/XObject");
		xbdfb620b7167944b.xa4dc0ad8886e23a2("/Subtype", "/Form");
		xbdfb620b7167944b.xa4dc0ad8886e23a2("/FormType", 1);
		xbdfb620b7167944b.xa4dc0ad8886e23a2("/BBox", x9284bbb976e4e2a2);
		if (x435b26849f0d2436 != null)
		{
			xbdfb620b7167944b.xa4dc0ad8886e23a2("/Matrix", x435b26849f0d2436);
		}
		x8cedcaa9a62c6e39.x3a60bb04bce53320.x54ee0eb7efc094e0(xbdfb620b7167944b, "/Resources");
	}

	public override void WriteToPdf(x4f40d990d5bf81a6 writer)
	{
		x6210059f049f0d48(x5121c5290eccb81c.GetBuffer(), 0, (int)x5121c5290eccb81c.Length);
		base.WriteToPdf(writer);
	}
}
