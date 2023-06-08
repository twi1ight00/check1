using ns2;

namespace Aspose.Cells.Drawing;

public class TilePicOption
{
	private int int_0;

	private int int_1;

	private int int_2 = 100000;

	private int int_3 = 100000;

	private MirrorType mirrorType_0;

	private RectangleAlignmentType rectangleAlignmentType_0 = RectangleAlignmentType.TopLeft;

	public double OffsetX
	{
		get
		{
			return (double)int_0 / Class1391.double_0;
		}
		set
		{
			int_0 = (int)(value * Class1391.double_0 + 0.5);
		}
	}

	public double OffsetY
	{
		get
		{
			return (double)int_1 / Class1391.double_0;
		}
		set
		{
			int_1 = (int)(value * Class1391.double_0 + 0.5);
		}
	}

	public double ScaleX
	{
		get
		{
			return (double)int_2 / 1000.0;
		}
		set
		{
			int_2 = (int)(value * 1000.0 + 0.5);
		}
	}

	public double ScaleY
	{
		get
		{
			return (double)int_3 / 1000.0;
		}
		set
		{
			int_3 = (int)(value * 1000.0 + 0.5);
		}
	}

	public MirrorType MirrorType
	{
		get
		{
			return mirrorType_0;
		}
		set
		{
			mirrorType_0 = value;
		}
	}

	public RectangleAlignmentType AlignmentType
	{
		get
		{
			return rectangleAlignmentType_0;
		}
		set
		{
			rectangleAlignmentType_0 = value;
		}
	}

	internal void Copy(TilePicOption tilePicOption_0)
	{
		int_0 = tilePicOption_0.int_0;
		int_2 = tilePicOption_0.int_2;
		int_1 = tilePicOption_0.int_1;
		int_3 = tilePicOption_0.int_3;
		mirrorType_0 = tilePicOption_0.mirrorType_0;
		rectangleAlignmentType_0 = tilePicOption_0.rectangleAlignmentType_0;
	}
}
