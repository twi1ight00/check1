using System;
using ns224;

namespace ns233;

internal class Class6140
{
	private readonly Class5998 class5998_0;

	private readonly Class5998 class5998_1;

	public Class5998 LowColor => class5998_0;

	public Class5998 HighColor => class5998_1;

	public Class6140(Class5998 center, int range)
	{
		if (center == null || center.IsEmpty)
		{
			throw new ArgumentNullException("center");
		}
		class5998_0 = new Class5998(Math.Max(center.R - range, 0), Math.Max(center.G - range, 0), Math.Max(center.B - range, 0));
		class5998_1 = new Class5998(Math.Min(center.R + range, 255), Math.Min(center.G + range, 255), Math.Min(center.B + range, 255));
	}

	public Class6140(Class5998 lowColor, Class5998 highColor)
	{
		if (!(lowColor == null) && !lowColor.IsEmpty)
		{
			if (highColor == null || highColor.IsEmpty)
			{
				throw new ArgumentNullException("highColor");
			}
			class5998_0 = lowColor;
			class5998_1 = highColor;
			return;
		}
		throw new ArgumentNullException("lowColor");
	}

	public bool method_0(Class5998 color)
	{
		if (color.R >= LowColor.R && color.R <= HighColor.R && color.G >= LowColor.G && color.G <= HighColor.G && color.B >= LowColor.B)
		{
			return color.B <= HighColor.B;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return (class5998_0.GetHashCode() * 397) ^ class5998_1.GetHashCode();
	}
}
