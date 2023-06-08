using Aspose.Words;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;
using xbe73d5820f7f4ae3;

namespace xfce5b6a304778b89;

internal class x533663bbcdc757a9
{
	private double x542ec23a3d6a14e3;

	private LineStyle x8001c24628d75f20;

	private x26d9ecb4bdf0456d x78e4acec873c7675 = x26d9ecb4bdf0456d.x45260ad4b94166f2;

	internal double xeae235558dc44397
	{
		get
		{
			return x542ec23a3d6a14e3;
		}
		set
		{
			x542ec23a3d6a14e3 = value;
		}
	}

	internal LineStyle x3d0571719b5893b4
	{
		get
		{
			return x8001c24628d75f20;
		}
		set
		{
			x8001c24628d75f20 = value;
		}
	}

	internal x26d9ecb4bdf0456d x9b41425268471380
	{
		get
		{
			return x78e4acec873c7675;
		}
		set
		{
			x78e4acec873c7675 = value;
		}
	}

	internal static x533663bbcdc757a9 x28f49f0eeecaafb7(x533663bbcdc757a9 x14cf9593b86ecbaa, string x9799ebb747c54e3a)
	{
		if (x14cf9593b86ecbaa == null)
		{
			x14cf9593b86ecbaa = new x533663bbcdc757a9();
		}
		if (x9799ebb747c54e3a == "none")
		{
			x14cf9593b86ecbaa.x3d0571719b5893b4 = LineStyle.None;
		}
		else
		{
			string[] array = x9799ebb747c54e3a.Split(' ');
			for (int i = 0; i < array.Length; i++)
			{
				string text = array[i].Trim();
				if (text.StartsWith("#") || text == "transparent")
				{
					x14cf9593b86ecbaa.x9b41425268471380 = xbb857c9fc36f5054.xd9a94ec83011098f(text);
				}
				else if (xbb857c9fc36f5054.xd1ddac1c3a154564(text))
				{
					x14cf9593b86ecbaa.xeae235558dc44397 = xbb857c9fc36f5054.x85ddf5f63df4b542(text);
				}
				else if (x14cf9593b86ecbaa.x3d0571719b5893b4 == LineStyle.None)
				{
					x14cf9593b86ecbaa.x3d0571719b5893b4 = x0eb9a864413f34de.xd3fb949f1a59cf0a(text);
				}
			}
		}
		return x14cf9593b86ecbaa;
	}

	internal static Border x95dfc63190e8c019(x533663bbcdc757a9 x895c40fd497ba465, double x31033071d2f3713b, int x13ebc58426767551)
	{
		Border border = new Border();
		if (x895c40fd497ba465 != null)
		{
			border.LineStyle = x895c40fd497ba465.x3d0571719b5893b4;
			border.x63b1a7c31a962459 = x895c40fd497ba465.x9b41425268471380;
			border.xab266ea415f07c09 = xbb857c9fc36f5054.xb6d2cca5c1ea6936(border, x895c40fd497ba465.xeae235558dc44397);
		}
		double num = xbb857c9fc36f5054.x7ee6ab51d3d84831(x31033071d2f3713b);
		border.x1f2d5df87a5c4f81 = x15e971129fd80714.x43fcc3f62534530b((num > 31.0) ? 31.0 : num);
		return border;
	}

	internal static Border x95dfc63190e8c019(x533663bbcdc757a9 x895c40fd497ba465)
	{
		return x95dfc63190e8c019(x895c40fd497ba465, 0.0, 0);
	}
}
