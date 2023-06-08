using System.Collections;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;
using x9db5f2e5af3d596e;

namespace Aspose.Words.Tables;

public class CellFormat : x0e9935be205598e7, x39462b2e4fc652e7
{
	private readonly xf516b6b0dd7e0d14 xc454c03c23d4b4d9;

	private BorderCollection xac8df3ffedaa82be;

	public double LeftPadding
	{
		get
		{
			return x4574ea26106f0edb.x0e1fdb362561ddb2((int)xfe91eeeafcb3026a(3090));
		}
		set
		{
			xc454c03c23d4b4d9.xad3f776eaf7a915d(3090, x4574ea26106f0edb.x88bf16f2386d633e(value));
		}
	}

	public double RightPadding
	{
		get
		{
			return x4574ea26106f0edb.x0e1fdb362561ddb2((int)xfe91eeeafcb3026a(3100));
		}
		set
		{
			xc454c03c23d4b4d9.xad3f776eaf7a915d(3100, x4574ea26106f0edb.x88bf16f2386d633e(value));
		}
	}

	public double TopPadding
	{
		get
		{
			return x4574ea26106f0edb.x0e1fdb362561ddb2((int)xfe91eeeafcb3026a(3070));
		}
		set
		{
			xc454c03c23d4b4d9.xad3f776eaf7a915d(3070, x4574ea26106f0edb.x88bf16f2386d633e(value));
		}
	}

	public double BottomPadding
	{
		get
		{
			return x4574ea26106f0edb.x0e1fdb362561ddb2((int)xfe91eeeafcb3026a(3080));
		}
		set
		{
			xc454c03c23d4b4d9.xad3f776eaf7a915d(3080, x4574ea26106f0edb.x88bf16f2386d633e(value));
		}
	}

	public BorderCollection Borders
	{
		get
		{
			if (xac8df3ffedaa82be == null)
			{
				xac8df3ffedaa82be = new BorderCollection(this);
			}
			return xac8df3ffedaa82be;
		}
	}

	public Shading Shading
	{
		get
		{
			Shading shading = (Shading)xc454c03c23d4b4d9.x34f1b0fbc88f0b8a(3170);
			if (shading == null)
			{
				shading = new Shading(this, 3170);
				xc454c03c23d4b4d9.xad3f776eaf7a915d(3170, shading);
			}
			return shading;
		}
	}

	public CellVerticalAlignment VerticalAlignment
	{
		get
		{
			return (CellVerticalAlignment)xfe91eeeafcb3026a(3060);
		}
		set
		{
			xc454c03c23d4b4d9.xad3f776eaf7a915d(3060, value);
		}
	}

	public double Width
	{
		get
		{
			return x4574ea26106f0edb.x0e1fdb362561ddb2((int)xfe91eeeafcb3026a(3010));
		}
		set
		{
			xc454c03c23d4b4d9.xad3f776eaf7a915d(3010, x4574ea26106f0edb.x88bf16f2386d633e(value));
		}
	}

	public PreferredWidth PreferredWidth
	{
		get
		{
			return (PreferredWidth)xfe91eeeafcb3026a(3020);
		}
		set
		{
			xc454c03c23d4b4d9.xad3f776eaf7a915d(3020, value);
		}
	}

	public CellMerge VerticalMerge
	{
		get
		{
			return (CellMerge)xfe91eeeafcb3026a(3030);
		}
		set
		{
			xc454c03c23d4b4d9.xad3f776eaf7a915d(3030, value);
		}
	}

	public CellMerge HorizontalMerge
	{
		get
		{
			return (CellMerge)xfe91eeeafcb3026a(3040);
		}
		set
		{
			xc454c03c23d4b4d9.xad3f776eaf7a915d(3040, value);
		}
	}

	public TextOrientation Orientation
	{
		get
		{
			return (TextOrientation)xfe91eeeafcb3026a(3050);
		}
		set
		{
			xc454c03c23d4b4d9.xad3f776eaf7a915d(3050, value);
		}
	}

	public bool FitText
	{
		get
		{
			return (bool)xfe91eeeafcb3026a(3190);
		}
		set
		{
			xc454c03c23d4b4d9.xad3f776eaf7a915d(3190, value);
		}
	}

	public bool WrapText
	{
		get
		{
			return (bool)xfe91eeeafcb3026a(3180);
		}
		set
		{
			xc454c03c23d4b4d9.xad3f776eaf7a915d(3180, value);
		}
	}

	SortedList x0e9935be205598e7.xa652231a0259f1c4 => xf8cef531dae89ea3.x01e813efe52383e6;

	internal CellFormat(xf516b6b0dd7e0d14 parent)
	{
		xc454c03c23d4b4d9 = parent;
	}

	public void ClearFormatting()
	{
		object obj = xc454c03c23d4b4d9.x34f1b0fbc88f0b8a(3010);
		object obj2 = xc454c03c23d4b4d9.x34f1b0fbc88f0b8a(3020);
		xc454c03c23d4b4d9.xff94bebb1f5a007f();
		if (obj != null)
		{
			xc454c03c23d4b4d9.xad3f776eaf7a915d(3010, obj);
		}
		if (obj2 != null)
		{
			xc454c03c23d4b4d9.xad3f776eaf7a915d(3020, obj2);
		}
	}

	internal void xc51abb79cd36bee7()
	{
		xc454c03c23d4b4d9.xff94bebb1f5a007f();
	}

	private object xfe91eeeafcb3026a(int xba08ce632055a1d9)
	{
		object obj = xc454c03c23d4b4d9.x34f1b0fbc88f0b8a(xba08ce632055a1d9);
		if (obj == null)
		{
			return xc454c03c23d4b4d9.x4c5c531cd5714601(xba08ce632055a1d9);
		}
		return obj;
	}

	private object x4497e36644489fd4(int xba08ce632055a1d9)
	{
		return xc454c03c23d4b4d9.x34f1b0fbc88f0b8a(xba08ce632055a1d9);
	}

	object x0e9935be205598e7.x6e9ebce5ff38cae9(int xba08ce632055a1d9)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x4497e36644489fd4
		return this.x4497e36644489fd4(xba08ce632055a1d9);
	}

	private object x38e65374c3e63df4(int xba08ce632055a1d9)
	{
		return xc454c03c23d4b4d9.x4c5c531cd5714601(xba08ce632055a1d9);
	}

	object x0e9935be205598e7.x3087b5fa67bcf3f4(int xba08ce632055a1d9)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x38e65374c3e63df4
		return this.x38e65374c3e63df4(xba08ce632055a1d9);
	}

	private void xf448a09b8f5e15e8(int xba08ce632055a1d9, object xbcea506a33cf9111)
	{
		xc454c03c23d4b4d9.xad3f776eaf7a915d(xba08ce632055a1d9, xbcea506a33cf9111);
	}

	void x0e9935be205598e7.x039f0f0de50f5575(int xba08ce632055a1d9, object xbcea506a33cf9111)
	{
		//ILSpy generated this explicit interface implementation from .override directive in xf448a09b8f5e15e8
		this.xf448a09b8f5e15e8(xba08ce632055a1d9, xbcea506a33cf9111);
	}

	private object xb654ea8c7931bb83(int xba08ce632055a1d9)
	{
		return xc454c03c23d4b4d9.x4c5c531cd5714601(xba08ce632055a1d9);
	}

	object x39462b2e4fc652e7.xccf76df3dc24953f(int xba08ce632055a1d9)
	{
		//ILSpy generated this explicit interface implementation from .override directive in xb654ea8c7931bb83
		return this.xb654ea8c7931bb83(xba08ce632055a1d9);
	}
}
