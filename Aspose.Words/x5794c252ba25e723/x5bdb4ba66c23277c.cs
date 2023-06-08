using System;
using System.Drawing.Drawing2D;

namespace x5794c252ba25e723;

internal class x5bdb4ba66c23277c : x845d6a068e0b03c5
{
	private x26d9ecb4bdf0456d x673d591644543f05;

	private x26d9ecb4bdf0456d xfd2ce88fa11a1590;

	private HatchStyle x1466148dad621cc1;

	public HatchStyle xaf9d27b89edd7fea
	{
		get
		{
			return x1466148dad621cc1;
		}
		set
		{
			x1466148dad621cc1 = value;
		}
	}

	public x26d9ecb4bdf0456d x8fdbd80e8da6b0e6
	{
		get
		{
			return xfd2ce88fa11a1590;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			xfd2ce88fa11a1590 = value;
		}
	}

	public x26d9ecb4bdf0456d x83729c7ebf48ae24
	{
		get
		{
			return x673d591644543f05;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			x673d591644543f05 = value;
		}
	}

	public x5bdb4ba66c23277c(HatchStyle hatchStyle, x26d9ecb4bdf0456d foreColor, x26d9ecb4bdf0456d backColor)
		: base(x0b257a9fb413b6c3.x1b1f1b9a5f55b7ee)
	{
		xaf9d27b89edd7fea = hatchStyle;
		x8fdbd80e8da6b0e6 = foreColor;
		x83729c7ebf48ae24 = backColor;
	}
}
