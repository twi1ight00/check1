using System.Drawing;
using ns219;
using ns235;
using ns251;
using ns261;

namespace ns249;

internal class Class6360
{
	private Interface275 interface275_0;

	private Class6217 class6217_0;

	private Interface293 interface293_0;

	private Interface280 interface280_0;

	private RectangleF rectangleF_0;

	private double double_0;

	private Class6420 class6420_0;

	private Interface297 interface297_0;

	public Interface293 DataProvider => interface293_0;

	public Interface280 FillProvider => interface280_0;

	public Interface297 ThemeProvider => interface297_0;

	public Interface275 AdditionalColorModifier
	{
		get
		{
			return interface275_0;
		}
		set
		{
			interface275_0 = value;
		}
	}

	public RectangleF ShapeBoundingBox
	{
		get
		{
			return rectangleF_0;
		}
		set
		{
			rectangleF_0 = value;
		}
	}

	public double ShapeRotationAngle
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = value;
		}
	}

	public Class6217 CurrentPath
	{
		get
		{
			return class6217_0;
		}
		set
		{
			class6217_0 = value;
		}
	}

	public Class6420 Style => class6420_0;

	public Class6360(Interface280 fillProvider, Interface297 themeProvider, Interface293 dataProvider, Class6420 style)
	{
		interface293_0 = dataProvider;
		class6420_0 = style;
		interface280_0 = fillProvider;
		interface297_0 = themeProvider;
	}
}
