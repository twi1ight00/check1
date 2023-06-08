using System.Drawing;
using x5794c252ba25e723;
using xeb665d1aeef09d64;

namespace x1c8faa688b1f0b0c;

internal class x8fd773b74dcec1bc : xfa6279ffd07aa4c9
{
	private const int x84f7717b2f865411 = 0;

	private string x4574aea041dd835f = "";

	private string x9913fbaf0b91e577 = "";

	private SizeF x3b77a41bd57164d6 = SizeF.Empty;

	private readonly bool xe7ec03a0dc51638b;

	private int x049c595f8783548a;

	private x26d9ecb4bdf0456d xb5f3cf33a6e66b37 = x26d9ecb4bdf0456d.x89fffa2751fdecbe;

	private xe39d06eee35dd23d x4884fd3dc186019b = x6132db19c1686804;

	private int xcf110145779a13ac;

	private static readonly xe39d06eee35dd23d x6132db19c1686804;

	internal static readonly char[] x4e0562cd625a1408;

	public bool x172ec8314cc6064b => xe7ec03a0dc51638b;

	public int x7e9904b269e29b39
	{
		get
		{
			return x049c595f8783548a;
		}
		set
		{
			x049c595f8783548a = value;
		}
	}

	public string xd2f68ee6f47e9dfb => x4574aea041dd835f;

	public string x08c5d9f4b0653c8d
	{
		get
		{
			if (xe7ec03a0dc51638b)
			{
				return x9913fbaf0b91e577;
			}
			return x4574aea041dd835f;
		}
	}

	public xe39d06eee35dd23d xddffcb24e864cfcc
	{
		get
		{
			return x4884fd3dc186019b;
		}
		set
		{
			x4884fd3dc186019b = value;
		}
	}

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

	public x26d9ecb4bdf0456d xca02aeead29a2213
	{
		get
		{
			return xb5f3cf33a6e66b37;
		}
		set
		{
			xb5f3cf33a6e66b37 = value;
		}
	}

	public override RectangleF BoundingBox => new RectangleF(base.xc22eade24b085d91, x437e3b626c0fdd43);

	public bool xe3ccff5629a1e888 => xcf110145779a13ac > 1;

	public x8fd773b74dcec1bc(PointF origin, string name, SizeF size, string plainText)
		: this(origin, name, size, isRichText: false, plainText, string.Empty)
	{
	}

	public x8fd773b74dcec1bc(PointF origin, string name, SizeF size, string richText, string plainText)
		: this(origin, name, size, isRichText: true, richText, plainText)
	{
	}

	private x8fd773b74dcec1bc(PointF origin, string name, SizeF size, bool isRichText, string value, string plainText)
		: base(new PointF(origin.X - 1.75f, origin.Y), name)
	{
		xe7ec03a0dc51638b = isRichText;
		x4574aea041dd835f = value;
		x9913fbaf0b91e577 = plainText;
		x374c36a9387a8101(size);
	}

	public override void Accept(xf51865b83a7a0b3b visitor)
	{
		visitor.VisitFormFieldText(this);
	}

	private void x374c36a9387a8101(SizeF x0ceec69a97f73617)
	{
		float height = x0ceec69a97f73617.Height;
		float x53531537bb3331e = x4884fd3dc186019b.x53531537bb3331e6;
		string[] array = x08c5d9f4b0653c8d.Split(x4e0562cd625a1408);
		xcf110145779a13ac = array.Length;
		float num = x53531537bb3331e * (float)xcf110145779a13ac + 3.5f;
		x437e3b626c0fdd43 = new SizeF(x0ceec69a97f73617.Width + 3.5f, (num > height) ? num : height);
		base.xc22eade24b085d91 = new PointF(base.xc22eade24b085d91.X, base.xc22eade24b085d91.Y + x437e3b626c0fdd43.Height - height - 1.75f);
	}

	static x8fd773b74dcec1bc()
	{
		x4e0562cd625a1408 = new char[2] { '\n', '\r' };
		x6132db19c1686804 = x9d888f53892d94df.x9834ddb0e0bd5996.x491f5a7224612753("Times New Roman", 12f, FontStyle.Regular);
	}
}
