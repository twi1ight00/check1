using System.Collections;
using System.Diagnostics;
using System.Drawing;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;
using x79578da6a8a3ae37;

namespace Aspose.Words;

public class PageSetup : x0e9935be205598e7
{
	private readonly x38e21b53aa8148da xc454c03c23d4b4d9;

	private readonly xdade2366eaa6f915 x6620bd3d0342c0f4;

	private TextColumnCollection xbfdb8d74dae5f9c0;

	private BorderCollection x52f94035dff03a3d;

	private FootnoteOptions xce12c3e8eb510bf2;

	private FootnoteOptions x5d55ff5fadb3fbf1;

	private static readonly SortedList x795b1a140ee9d68b;

	public bool OddAndEvenPagesHeaderFooter
	{
		get
		{
			return x6620bd3d0342c0f4.x5ac0ad056c3fce83;
		}
		set
		{
			x6620bd3d0342c0f4.x5ac0ad056c3fce83 = value;
		}
	}

	public bool DifferentFirstPageHeaderFooter
	{
		get
		{
			return (bool)xfe91eeeafcb3026a(2040);
		}
		set
		{
			xc454c03c23d4b4d9.xa2dc0badd30e7585(2040, value);
		}
	}

	public bool MirrorMargins
	{
		get
		{
			return x6620bd3d0342c0f4.xd02fc99dc9c3221e;
		}
		set
		{
			x6620bd3d0342c0f4.xd02fc99dc9c3221e = value;
		}
	}

	public SectionStart SectionStart
	{
		get
		{
			return (SectionStart)xfe91eeeafcb3026a(2030);
		}
		set
		{
			xc454c03c23d4b4d9.xa2dc0badd30e7585(2030, value);
		}
	}

	public bool SuppressEndnotes
	{
		get
		{
			return (bool)xfe91eeeafcb3026a(2100);
		}
		set
		{
			xc454c03c23d4b4d9.xa2dc0badd30e7585(2100, value);
		}
	}

	public PageVerticalAlignment VerticalAlignment
	{
		get
		{
			return (PageVerticalAlignment)xfe91eeeafcb3026a(2340);
		}
		set
		{
			xc454c03c23d4b4d9.xa2dc0badd30e7585(2340, value);
		}
	}

	public bool Bidi
	{
		get
		{
			return (bool)xfe91eeeafcb3026a(2450);
		}
		set
		{
			xc454c03c23d4b4d9.xa2dc0badd30e7585(2450, value);
		}
	}

	public double PageWidth
	{
		get
		{
			return x4574ea26106f0edb.x0e1fdb362561ddb2((int)xfe91eeeafcb3026a(2260));
		}
		set
		{
			xae20093bed1e48a8(2260, x4574ea26106f0edb.x88bf16f2386d633e(value));
		}
	}

	public double PageHeight
	{
		get
		{
			return x4574ea26106f0edb.x0e1fdb362561ddb2((int)xfe91eeeafcb3026a(2270));
		}
		set
		{
			xc454c03c23d4b4d9.xa2dc0badd30e7585(2270, x4574ea26106f0edb.x88bf16f2386d633e(value));
		}
	}

	internal SizeF x840f0682785efa25 => new SizeF((float)PageWidth, (float)PageHeight);

	internal bool x46bd75796885393f
	{
		get
		{
			if (x6620bd3d0342c0f4.xee2d3f1f4ca2502d)
			{
				return !RtlGutter;
			}
			return false;
		}
	}

	internal bool x9e9c8cc34a01d1bc
	{
		get
		{
			if (x6620bd3d0342c0f4.xee2d3f1f4ca2502d)
			{
				return RtlGutter;
			}
			return false;
		}
	}

	internal float xe364b5f54bd2ec4c
	{
		get
		{
			double num = (x46bd75796885393f ? Gutter : 0.0);
			return (float)(LeftMargin + num);
		}
	}

	internal float x5f6c85e261732738
	{
		get
		{
			double num = (x9e9c8cc34a01d1bc ? Gutter : 0.0);
			return (float)(PageWidth - RightMargin - num);
		}
	}

	internal float xd985b37e5f570f69
	{
		get
		{
			double num = (x6620bd3d0342c0f4.xee2d3f1f4ca2502d ? 0.0 : Gutter);
			return (float)(TopMargin + num);
		}
	}

	internal float xd7fab63fabd0a319 => (float)(PageHeight - BottomMargin);

	internal float x887b872a95caaab5 => x5f6c85e261732738 - xe364b5f54bd2ec4c;

	internal float xbcd477821fdbd81b => xd7fab63fabd0a319 - xd985b37e5f570f69;

	public PaperSize PaperSize
	{
		get
		{
			return xb7dbd7bb3ed97d5b.xca878d9befa76e8f((int)xfe91eeeafcb3026a(2260), (int)xfe91eeeafcb3026a(2270), x7104444ac30f945d);
		}
		set
		{
			if (value != PaperSize.Custom)
			{
				Size size = xb7dbd7bb3ed97d5b.x9d0ad238350f058d(value);
				if (x7104444ac30f945d)
				{
					xc454c03c23d4b4d9.xa2dc0badd30e7585(2260, size.Height);
					xc454c03c23d4b4d9.xa2dc0badd30e7585(2270, size.Width);
				}
				else
				{
					xc454c03c23d4b4d9.xa2dc0badd30e7585(2260, size.Width);
					xc454c03c23d4b4d9.xa2dc0badd30e7585(2270, size.Height);
				}
			}
		}
	}

	private bool x7104444ac30f945d => Orientation == Orientation.Landscape;

	public Orientation Orientation
	{
		get
		{
			return (Orientation)xfe91eeeafcb3026a(2210);
		}
		set
		{
			if (Orientation != value)
			{
				xc454c03c23d4b4d9.xa2dc0badd30e7585(2210, value);
				double pageWidth = PageWidth;
				PageWidth = PageHeight;
				PageHeight = pageWidth;
			}
		}
	}

	public double LeftMargin
	{
		get
		{
			return x4574ea26106f0edb.x0e1fdb362561ddb2((int)xfe91eeeafcb3026a(2280));
		}
		set
		{
			xae20093bed1e48a8(2280, x4574ea26106f0edb.x88bf16f2386d633e(value));
		}
	}

	public double RightMargin
	{
		get
		{
			return x4574ea26106f0edb.x0e1fdb362561ddb2((int)xfe91eeeafcb3026a(2290));
		}
		set
		{
			xae20093bed1e48a8(2290, x4574ea26106f0edb.x88bf16f2386d633e(value));
		}
	}

	public double TopMargin
	{
		get
		{
			return x4574ea26106f0edb.x0e1fdb362561ddb2((int)xfe91eeeafcb3026a(2300));
		}
		set
		{
			xc454c03c23d4b4d9.xa2dc0badd30e7585(2300, x4574ea26106f0edb.x88bf16f2386d633e(value));
		}
	}

	public double BottomMargin
	{
		get
		{
			return x4574ea26106f0edb.x0e1fdb362561ddb2((int)xfe91eeeafcb3026a(2310));
		}
		set
		{
			xc454c03c23d4b4d9.xa2dc0badd30e7585(2310, x4574ea26106f0edb.x88bf16f2386d633e(value));
		}
	}

	public double HeaderDistance
	{
		get
		{
			return x4574ea26106f0edb.x0e1fdb362561ddb2((int)xfe91eeeafcb3026a(2320));
		}
		set
		{
			xc454c03c23d4b4d9.xa2dc0badd30e7585(2320, x4574ea26106f0edb.x88bf16f2386d633e(value));
		}
	}

	public double FooterDistance
	{
		get
		{
			return x4574ea26106f0edb.x0e1fdb362561ddb2((int)xfe91eeeafcb3026a(2330));
		}
		set
		{
			xc454c03c23d4b4d9.xa2dc0badd30e7585(2330, x4574ea26106f0edb.x88bf16f2386d633e(value));
		}
	}

	public double Gutter
	{
		get
		{
			return x4574ea26106f0edb.x0e1fdb362561ddb2((int)xfe91eeeafcb3026a(2312));
		}
		set
		{
			xc454c03c23d4b4d9.xa2dc0badd30e7585(2312, x4574ea26106f0edb.x88bf16f2386d633e(value));
		}
	}

	public int FirstPageTray
	{
		get
		{
			return (int)xfe91eeeafcb3026a(2070);
		}
		set
		{
			xc454c03c23d4b4d9.xa2dc0badd30e7585(2070, value);
		}
	}

	public int OtherPagesTray
	{
		get
		{
			return (int)xfe91eeeafcb3026a(2080);
		}
		set
		{
			xc454c03c23d4b4d9.xa2dc0badd30e7585(2080, value);
		}
	}

	internal int xee524e151121559b
	{
		get
		{
			return (int)xfe91eeeafcb3026a(2190);
		}
		set
		{
			xc454c03c23d4b4d9.xa2dc0badd30e7585(2190, value);
		}
	}

	internal xbdc85485688e2cf3 xbdc85485688e2cf3
	{
		get
		{
			return (xbdc85485688e2cf3)xfe91eeeafcb3026a(2020);
		}
		set
		{
			xc454c03c23d4b4d9.xa2dc0badd30e7585(2020, value);
		}
	}

	public NumberStyle PageNumberStyle
	{
		get
		{
			return (NumberStyle)xfe91eeeafcb3026a(2010);
		}
		set
		{
			xc454c03c23d4b4d9.xa2dc0badd30e7585(2010, value);
		}
	}

	public bool RestartPageNumbering
	{
		get
		{
			return (bool)xfe91eeeafcb3026a(2050);
		}
		set
		{
			xc454c03c23d4b4d9.xa2dc0badd30e7585(2050, value);
		}
	}

	public int PageStartingNumber
	{
		get
		{
			return (int)xfe91eeeafcb3026a(2200);
		}
		set
		{
			xc454c03c23d4b4d9.xa2dc0badd30e7585(2200, value);
		}
	}

	public LineNumberRestartMode LineNumberRestartMode
	{
		get
		{
			return (LineNumberRestartMode)xfe91eeeafcb3026a(2110);
		}
		set
		{
			xc454c03c23d4b4d9.xa2dc0badd30e7585(2110, value);
		}
	}

	public int LineNumberCountBy
	{
		get
		{
			return (int)xfe91eeeafcb3026a(2120);
		}
		set
		{
			xc454c03c23d4b4d9.xa2dc0badd30e7585(2120, value);
		}
	}

	public double LineNumberDistanceFromText
	{
		get
		{
			return x4574ea26106f0edb.x0e1fdb362561ddb2((int)xfe91eeeafcb3026a(2400));
		}
		set
		{
			xc454c03c23d4b4d9.xa2dc0badd30e7585(2400, x4574ea26106f0edb.x88bf16f2386d633e(value));
		}
	}

	public int LineStartingNumber
	{
		get
		{
			return (int)xfe91eeeafcb3026a(2180);
		}
		set
		{
			xc454c03c23d4b4d9.xa2dc0badd30e7585(2180, value);
		}
	}

	public TextColumnCollection TextColumns
	{
		get
		{
			if (xbfdb8d74dae5f9c0 == null)
			{
				xbfdb8d74dae5f9c0 = new TextColumnCollection(this);
			}
			return xbfdb8d74dae5f9c0;
		}
	}

	public bool RtlGutter
	{
		get
		{
			return (bool)xfe91eeeafcb3026a(2410);
		}
		set
		{
			xc454c03c23d4b4d9.xa2dc0badd30e7585(2410, value);
		}
	}

	public bool BorderAlwaysInFront
	{
		get
		{
			return (bool)xfe91eeeafcb3026a(2230);
		}
		set
		{
			xc454c03c23d4b4d9.xa2dc0badd30e7585(2230, value);
		}
	}

	public PageBorderDistanceFrom BorderDistanceFrom
	{
		get
		{
			return (PageBorderDistanceFrom)xfe91eeeafcb3026a(2240);
		}
		set
		{
			xc454c03c23d4b4d9.xa2dc0badd30e7585(2240, value);
		}
	}

	public PageBorderAppliesTo BorderAppliesTo
	{
		get
		{
			return (PageBorderAppliesTo)xfe91eeeafcb3026a(2220);
		}
		set
		{
			xc454c03c23d4b4d9.xa2dc0badd30e7585(2220, value);
		}
	}

	public bool BorderSurroundsHeader
	{
		get
		{
			return !x6620bd3d0342c0f4.x8af0b297a9d474ad;
		}
		set
		{
			x6620bd3d0342c0f4.x8af0b297a9d474ad = !value;
		}
	}

	public bool BorderSurroundsFooter
	{
		get
		{
			return !x6620bd3d0342c0f4.x636013cbf60f10b8;
		}
		set
		{
			x6620bd3d0342c0f4.x636013cbf60f10b8 = !value;
		}
	}

	public BorderCollection Borders
	{
		get
		{
			if (x52f94035dff03a3d == null)
			{
				x52f94035dff03a3d = new BorderCollection(this);
			}
			return x52f94035dff03a3d;
		}
	}

	public FootnoteOptions FootnoteOptions
	{
		get
		{
			if (xce12c3e8eb510bf2 == null)
			{
				xce12c3e8eb510bf2 = new FootnoteOptions(xc454c03c23d4b4d9, FootnoteType.Footnote);
			}
			return xce12c3e8eb510bf2;
		}
	}

	public FootnoteOptions EndnoteOptions
	{
		get
		{
			if (x5d55ff5fadb3fbf1 == null)
			{
				x5d55ff5fadb3fbf1 = new FootnoteOptions(xc454c03c23d4b4d9, FootnoteType.Endnote);
			}
			return x5d55ff5fadb3fbf1;
		}
	}

	internal int x3f74ba7d73597c22
	{
		get
		{
			return (int)xfe91eeeafcb3026a(2420);
		}
		set
		{
			xc454c03c23d4b4d9.xa2dc0badd30e7585(2420, value);
		}
	}

	internal double x33678aed4fb5e764
	{
		get
		{
			return x4574ea26106f0edb.x0e1fdb362561ddb2((int)xfe91eeeafcb3026a(2170));
		}
		set
		{
			xc454c03c23d4b4d9.xa2dc0badd30e7585(2170, x4574ea26106f0edb.x88bf16f2386d633e(value));
		}
	}

	internal x6d434087bc06a37d x6d434087bc06a37d
	{
		get
		{
			return (x6d434087bc06a37d)xfe91eeeafcb3026a(2440);
		}
		set
		{
			xc454c03c23d4b4d9.xa2dc0badd30e7585(2440, value);
		}
	}

	internal int xdc363bd6e5544a03
	{
		get
		{
			return (int)xfe91eeeafcb3026a(2430);
		}
		set
		{
			xc454c03c23d4b4d9.xa2dc0badd30e7585(2430, value);
		}
	}

	internal int xb81f492cce31314c
	{
		get
		{
			return (int)xfe91eeeafcb3026a(2090);
		}
		set
		{
			xc454c03c23d4b4d9.xa2dc0badd30e7585(2090, value);
		}
	}

	internal bool x3f5233cee263582a
	{
		get
		{
			return (bool)xfe91eeeafcb3026a(2390);
		}
		set
		{
			xc454c03c23d4b4d9.xa2dc0badd30e7585(2390, value);
		}
	}

	internal x38e21b53aa8148da x332a8eedb847940d => xc454c03c23d4b4d9;

	SortedList x0e9935be205598e7.xa652231a0259f1c4 => x795b1a140ee9d68b;

	internal PageSetup(x38e21b53aa8148da parent, xdade2366eaa6f915 docPr)
	{
		xc454c03c23d4b4d9 = parent;
		x6620bd3d0342c0f4 = docPr;
	}

	public void ClearFormatting()
	{
		xc454c03c23d4b4d9.x6e641a758e328481();
	}

	private object xfe91eeeafcb3026a(int xba08ce632055a1d9)
	{
		object obj = xc454c03c23d4b4d9.xb25c0862ce36b53c(xba08ce632055a1d9);
		if (obj == null)
		{
			return xc454c03c23d4b4d9.xe5b82b9f0104471f(xba08ce632055a1d9);
		}
		return obj;
	}

	private object x4497e36644489fd4(int xba08ce632055a1d9)
	{
		return xc454c03c23d4b4d9.xb25c0862ce36b53c(xba08ce632055a1d9);
	}

	object x0e9935be205598e7.x6e9ebce5ff38cae9(int xba08ce632055a1d9)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x4497e36644489fd4
		return this.x4497e36644489fd4(xba08ce632055a1d9);
	}

	private object x38e65374c3e63df4(int xba08ce632055a1d9)
	{
		return xc454c03c23d4b4d9.xe5b82b9f0104471f(xba08ce632055a1d9);
	}

	object x0e9935be205598e7.x3087b5fa67bcf3f4(int xba08ce632055a1d9)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x38e65374c3e63df4
		return this.x38e65374c3e63df4(xba08ce632055a1d9);
	}

	private void xf448a09b8f5e15e8(int xba08ce632055a1d9, object xbcea506a33cf9111)
	{
		xc454c03c23d4b4d9.xa2dc0badd30e7585(xba08ce632055a1d9, xbcea506a33cf9111);
	}

	void x0e9935be205598e7.x039f0f0de50f5575(int xba08ce632055a1d9, object xbcea506a33cf9111)
	{
		//ILSpy generated this explicit interface implementation from .override directive in xf448a09b8f5e15e8
		this.xf448a09b8f5e15e8(xba08ce632055a1d9, xbcea506a33cf9111);
	}

	static PageSetup()
	{
		x795b1a140ee9d68b = new SortedList();
		x795b1a140ee9d68b.Add(BorderType.Top, 2130);
		x795b1a140ee9d68b.Add(BorderType.Left, 2140);
		x795b1a140ee9d68b.Add(BorderType.Bottom, 2150);
		x795b1a140ee9d68b.Add(BorderType.Right, 2160);
	}

	[Conditional("ASPOSE_EDITOR")]
	internal static void x3f0e062546899b8b()
	{
	}

	private void xae20093bed1e48a8(int xba08ce632055a1d9, object xbcea506a33cf9111)
	{
		xc454c03c23d4b4d9.xa2dc0badd30e7585(xba08ce632055a1d9, xbcea506a33cf9111);
	}
}
