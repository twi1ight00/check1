using System;
using System.Drawing.Drawing2D;

namespace ns224;

internal class Class5996 : Class5990
{
	private Class5998 class5998_0;

	private Class5998 class5998_1;

	private HatchStyle hatchStyle_0;

	public HatchStyle HatchStyle
	{
		get
		{
			return hatchStyle_0;
		}
		set
		{
			hatchStyle_0 = value;
		}
	}

	public Class5998 ForegroundColor
	{
		get
		{
			return class5998_1;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			class5998_1 = value;
		}
	}

	public Class5998 BackgroundColor
	{
		get
		{
			return class5998_0;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			class5998_0 = value;
		}
	}

	public Class5996(HatchStyle hatchStyle, Class5998 foreColor, Class5998 backColor)
		: base(Enum746.const_1)
	{
		HatchStyle = hatchStyle;
		ForegroundColor = foreColor;
		BackgroundColor = backColor;
	}
}
