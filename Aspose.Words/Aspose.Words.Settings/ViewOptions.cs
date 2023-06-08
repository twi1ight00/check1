using System;

namespace Aspose.Words.Settings;

public class ViewOptions
{
	private ViewType x3712fa2c07b34438 = ViewType.Normal;

	private ZoomType xc2e63984b3f2c18c;

	private int x436904229bb236a0 = 100;

	private bool xefac03beafbe6e53;

	private bool x8196b1cf8e720e80;

	private bool x0bc34acee680cad6;

	public ViewType ViewType
	{
		get
		{
			return x3712fa2c07b34438;
		}
		set
		{
			x3712fa2c07b34438 = value;
		}
	}

	public ZoomType ZoomType
	{
		get
		{
			return xc2e63984b3f2c18c;
		}
		set
		{
			xc2e63984b3f2c18c = value;
		}
	}

	public int ZoomPercent
	{
		get
		{
			return x436904229bb236a0;
		}
		set
		{
			if (value == 0)
			{
				value = 100;
			}
			if (value < 10 || value > 500)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			x436904229bb236a0 = value;
		}
	}

	public bool DoNotDisplayPageBoundaries
	{
		get
		{
			return xefac03beafbe6e53;
		}
		set
		{
			xefac03beafbe6e53 = value;
		}
	}

	public bool DisplayBackgroundShape
	{
		get
		{
			return x8196b1cf8e720e80;
		}
		set
		{
			x8196b1cf8e720e80 = value;
		}
	}

	public bool FormsDesign
	{
		get
		{
			return x0bc34acee680cad6;
		}
		set
		{
			x0bc34acee680cad6 = value;
		}
	}

	internal ViewOptions()
	{
	}

	internal ViewOptions x8b61531c8ea35b85()
	{
		return (ViewOptions)MemberwiseClone();
	}
}
