using x38a89dee67fc7a16;
using x6c95d9cf46ff5f25;

namespace Aspose.Words.Drawing;

public class ImageSize
{
	private readonly int xc46f3d1a3128ad99;

	private readonly int x8c6f4c646bb85281;

	private readonly double x2d1c271174d2f5d5;

	private readonly double xc01fd179bbea222c;

	internal bool x22ab5dfa6f12e902
	{
		get
		{
			if (WidthPixels > 0)
			{
				return HeightPixels > 0;
			}
			return false;
		}
	}

	public int WidthPixels => xc46f3d1a3128ad99;

	public int HeightPixels => x8c6f4c646bb85281;

	public double HorizontalResolution => x2d1c271174d2f5d5;

	public double VerticalResolution => xc01fd179bbea222c;

	public double WidthPoints => ConvertUtil.PixelToPoint(xc46f3d1a3128ad99, x2d1c271174d2f5d5);

	public double HeightPoints => ConvertUtil.PixelToPoint(x8c6f4c646bb85281, xc01fd179bbea222c);

	internal int x2293d3e399e86e50 => x4574ea26106f0edb.xad0a638147bf044e(xc46f3d1a3128ad99, x2d1c271174d2f5d5);

	internal int x2a8c8b799b415917 => x4574ea26106f0edb.xad0a638147bf044e(x8c6f4c646bb85281, xc01fd179bbea222c);

	public ImageSize(int widthPixels, int heightPixels)
		: this(widthPixels, heightPixels, 96.0, 96.0)
	{
	}

	public ImageSize(int widthPixels, int heightPixels, double horizontalResolution, double verticalResolution)
	{
		xc46f3d1a3128ad99 = widthPixels;
		x8c6f4c646bb85281 = heightPixels;
		x2d1c271174d2f5d5 = horizontalResolution;
		xc01fd179bbea222c = verticalResolution;
	}

	internal ImageSize(xa2745adfabe0c674 core)
	{
		xc46f3d1a3128ad99 = core.xdc1bf80853046136;
		x8c6f4c646bb85281 = core.xb0f146032f47c24e;
		x2d1c271174d2f5d5 = core.xf2b3620f7bfc9ed5;
		xc01fd179bbea222c = core.x5c6fc5693c6898cd;
	}
}
