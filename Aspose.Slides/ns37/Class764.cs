using System.Drawing;
using Aspose.Slides;
using ns36;

namespace ns37;

internal class Class764 : Interface24
{
	private Class740 class740_0;

	private Class741 class741_0;

	private Class755 class755_0;

	private float float_0;

	private float float_1;

	private float float_2;

	private float float_3;

	private float float_4;

	internal Class740 Chart => class740_0;

	public Class755 BorderInternal => class755_0;

	public Interface18 Border => class755_0;

	internal Class741 AreaInternal => class741_0;

	public Interface6 Area => class741_0;

	internal float X
	{
		get
		{
			return float_0;
		}
		set
		{
			float_0 = value;
		}
	}

	internal float Y
	{
		get
		{
			return float_1;
		}
		set
		{
			float_1 = value;
		}
	}

	internal float Width
	{
		get
		{
			return float_2;
		}
		set
		{
			float_2 = value;
		}
	}

	internal float Depth
	{
		get
		{
			return float_3;
		}
		set
		{
			float_3 = value;
		}
	}

	internal float Height
	{
		get
		{
			return float_4;
		}
		set
		{
			float_4 = value;
		}
	}

	internal float xCenter => X + Width / 2f;

	internal Class764(Class740 chart)
	{
		class740_0 = chart;
		class755_0 = new Class755(chart, Enum145.const_6);
		class741_0 = new Class741(chart, this, Enum140.const_4);
		class741_0.Formatting = FillType.NotDefined;
		class741_0.ForegroundColor = Color.Empty;
		class755_0.Formatting = FillType.NotDefined;
		class755_0.Color = Color.Empty;
	}

	internal float method_0(bool isBar, int unit, int seriesCount)
	{
		float num = (float)class740_0.GapWidth / 100f;
		float num2 = 0f;
		num2 = ((!isBar) ? (Width / (float)unit) : (Height / (float)unit));
		return num2 / ((float)seriesCount + num);
	}

	internal float method_1()
	{
		float num = (float)class740_0.GapDepth / 100f;
		return Depth / (1f + num);
	}
}
