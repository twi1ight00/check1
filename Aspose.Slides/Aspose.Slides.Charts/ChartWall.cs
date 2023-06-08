using ns25;

namespace Aspose.Slides.Charts;

public class ChartWall : IChartWall
{
	internal Chart chart_0;

	internal int int_0;

	internal Format format_0;

	internal PictureType pictureType_0 = PictureType.NotDefined;

	private Class320 class320_0 = new Class320();

	internal Class320 PPTXUnsupportedProps => class320_0;

	public int Thickness
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	public IFormat Format => format_0;

	public PictureType PictureType
	{
		get
		{
			return pictureType_0;
		}
		set
		{
			pictureType_0 = value;
		}
	}

	internal ChartWall(Chart parent)
	{
		chart_0 = parent;
		format_0 = new Format(chart_0);
	}
}
