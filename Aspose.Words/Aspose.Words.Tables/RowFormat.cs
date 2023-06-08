using System;
using System.Collections;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;
using x9db5f2e5af3d596e;

namespace Aspose.Words.Tables;

public class RowFormat : x0e9935be205598e7
{
	private readonly x8f424b921df6c21a xc454c03c23d4b4d9;

	private BorderCollection xac8df3ffedaa82be;

	[Obsolete("Use Table.PreferredWidth instead.")]
	public PreferredWidth PreferredWidth
	{
		get
		{
			return (PreferredWidth)xfe91eeeafcb3026a(4230);
		}
		set
		{
			xc454c03c23d4b4d9.x422daa4ae9c73301(4230, value);
		}
	}

	[Obsolete("Use Table.Alignment instead.")]
	public RowAlignment Alignment
	{
		get
		{
			return (RowAlignment)(TableAlignment)xfe91eeeafcb3026a(4010);
		}
		set
		{
			xc454c03c23d4b4d9.x422daa4ae9c73301(4010, (TableAlignment)value);
		}
	}

	[Obsolete("Use Table.AllowAutoFit instead.")]
	public bool AllowAutoFit
	{
		get
		{
			return (bool)xfe91eeeafcb3026a(4240);
		}
		set
		{
			xc454c03c23d4b4d9.x422daa4ae9c73301(4240, value);
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

	[Obsolete("Use Table.Bidi instead.")]
	public bool Bidi
	{
		get
		{
			return (bool)xfe91eeeafcb3026a(4380);
		}
		set
		{
			xc454c03c23d4b4d9.x422daa4ae9c73301(4380, value);
		}
	}

	[Obsolete("Use Table.LeftPadding instead.")]
	public double LeftPadding
	{
		get
		{
			return x4574ea26106f0edb.x0e1fdb362561ddb2((int)xfe91eeeafcb3026a(4020));
		}
		set
		{
			xc454c03c23d4b4d9.x422daa4ae9c73301(4020, x4574ea26106f0edb.x88bf16f2386d633e(value));
		}
	}

	[Obsolete("Use Table.RightPadding instead.")]
	public double RightPadding
	{
		get
		{
			return x4574ea26106f0edb.x0e1fdb362561ddb2((int)xfe91eeeafcb3026a(4320));
		}
		set
		{
			xc454c03c23d4b4d9.x422daa4ae9c73301(4320, x4574ea26106f0edb.x88bf16f2386d633e(value));
		}
	}

	[Obsolete("Use Table.TopPadding instead.")]
	public double TopPadding
	{
		get
		{
			return x4574ea26106f0edb.x0e1fdb362561ddb2((int)xfe91eeeafcb3026a(4300));
		}
		set
		{
			xc454c03c23d4b4d9.x422daa4ae9c73301(4300, x4574ea26106f0edb.x88bf16f2386d633e(value));
		}
	}

	[Obsolete("Use Table.BottomPadding instead.")]
	public double BottomPadding
	{
		get
		{
			return x4574ea26106f0edb.x0e1fdb362561ddb2((int)xfe91eeeafcb3026a(4310));
		}
		set
		{
			xc454c03c23d4b4d9.x422daa4ae9c73301(4310, x4574ea26106f0edb.x88bf16f2386d633e(value));
		}
	}

	[Obsolete("Use Table.CellSpacing instead.")]
	public double CellSpacing
	{
		get
		{
			return x4574ea26106f0edb.x0e1fdb362561ddb2((int)xfe91eeeafcb3026a(4290));
		}
		set
		{
			xc454c03c23d4b4d9.x422daa4ae9c73301(4290, x4574ea26106f0edb.x88bf16f2386d633e(value));
		}
	}

	public double Height
	{
		get
		{
			return x4574ea26106f0edb.x0e1fdb362561ddb2((int)xfe91eeeafcb3026a(4120));
		}
		set
		{
			xc454c03c23d4b4d9.x422daa4ae9c73301(4120, x4574ea26106f0edb.x88bf16f2386d633e(value));
		}
	}

	public HeightRule HeightRule
	{
		get
		{
			return (HeightRule)xfe91eeeafcb3026a(4110);
		}
		set
		{
			xc454c03c23d4b4d9.x422daa4ae9c73301(4110, value);
		}
	}

	public bool AllowBreakAcrossPages
	{
		get
		{
			return (bool)xfe91eeeafcb3026a(4360);
		}
		set
		{
			xc454c03c23d4b4d9.x422daa4ae9c73301(4360, value);
		}
	}

	public bool HeadingFormat
	{
		get
		{
			return (bool)xfe91eeeafcb3026a(4040);
		}
		set
		{
			xc454c03c23d4b4d9.x422daa4ae9c73301(4040, value);
		}
	}

	[Obsolete("Use Table.LeftIndent instead.")]
	public double LeftIndent
	{
		get
		{
			return x4574ea26106f0edb.x0e1fdb362561ddb2((int)xfe91eeeafcb3026a(4340));
		}
		set
		{
			xc454c03c23d4b4d9.x422daa4ae9c73301(4340, x4574ea26106f0edb.x88bf16f2386d633e(value));
		}
	}

	SortedList x0e9935be205598e7.xa652231a0259f1c4 => xedb0eb766e25e0c9.x01e813efe52383e6;

	internal RowFormat(x8f424b921df6c21a parent)
	{
		xc454c03c23d4b4d9 = parent;
	}

	public void ClearFormatting()
	{
		xc454c03c23d4b4d9.x7ac658ee35724fbe();
	}

	[Obsolete("Use padding properties on the Table instead.")]
	public void ClearCellPadding()
	{
		LeftPadding = 0.0;
		TopPadding = 0.0;
		RightPadding = 0.0;
		BottomPadding = 0.0;
	}

	private object xfe91eeeafcb3026a(int xba08ce632055a1d9)
	{
		object obj = xc454c03c23d4b4d9.xdc39376725eb2ee7(xba08ce632055a1d9);
		if (obj == null)
		{
			return xc454c03c23d4b4d9.x75cd79b986a36485(xba08ce632055a1d9);
		}
		return obj;
	}

	private object x4497e36644489fd4(int xba08ce632055a1d9)
	{
		return xc454c03c23d4b4d9.xdc39376725eb2ee7(xba08ce632055a1d9);
	}

	object x0e9935be205598e7.x6e9ebce5ff38cae9(int xba08ce632055a1d9)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x4497e36644489fd4
		return this.x4497e36644489fd4(xba08ce632055a1d9);
	}

	private object x38e65374c3e63df4(int xba08ce632055a1d9)
	{
		return xc454c03c23d4b4d9.x75cd79b986a36485(xba08ce632055a1d9);
	}

	object x0e9935be205598e7.x3087b5fa67bcf3f4(int xba08ce632055a1d9)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x38e65374c3e63df4
		return this.x38e65374c3e63df4(xba08ce632055a1d9);
	}

	private void xf448a09b8f5e15e8(int xba08ce632055a1d9, object xbcea506a33cf9111)
	{
		xc454c03c23d4b4d9.x422daa4ae9c73301(xba08ce632055a1d9, xbcea506a33cf9111);
	}

	void x0e9935be205598e7.x039f0f0de50f5575(int xba08ce632055a1d9, object xbcea506a33cf9111)
	{
		//ILSpy generated this explicit interface implementation from .override directive in xf448a09b8f5e15e8
		this.xf448a09b8f5e15e8(xba08ce632055a1d9, xbcea506a33cf9111);
	}
}
