using System.Drawing;
using System.Drawing.Drawing2D;
using Aspose.Slides;
using Aspose.Slides.Charts;
using ns36;
using ns38;

namespace ns37;

internal class Class756 : Interface19
{
	private Class740 class740_0;

	private Class741 class741_0;

	private Class755 class755_0;

	private int int_0;

	private MarkerStyleType markerStyleType_0 = MarkerStyleType.NotDefined;

	private FillType fillType_0 = FillType.NotDefined;

	private object object_0;

	internal Class741 AreaInternal => class741_0;

	public Interface6 Area => class741_0;

	internal Class755 BorderInternal => class755_0;

	public Interface18 Border => class755_0;

	public int MarkerSize
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

	public MarkerStyleType MarkerStyle
	{
		get
		{
			if (fillType_0 == FillType.NoFill)
			{
				return MarkerStyleType.None;
			}
			return markerStyleType_0;
		}
		set
		{
			markerStyleType_0 = value;
		}
	}

	internal bool IsVisible
	{
		get
		{
			if (MarkerStyle == MarkerStyleType.None)
			{
				return false;
			}
			return true;
		}
	}

	internal Class756(Class740 chart, object parent)
	{
		class740_0 = chart;
		object_0 = parent;
		method_0();
	}

	private void method_0()
	{
		class741_0 = new Class741(class740_0, object_0, Enum140.const_5);
		class755_0 = new Class755(class740_0, Enum145.const_7);
		float num = class740_0.Graphics?.DpiX ?? 96f;
		int_0 = Struct41.smethod_5(7f * num / 72f);
	}

	internal bool method_1(Class756 other)
	{
		if (IsVisible == other.IsVisible && IsVisible)
		{
			if (MarkerStyle != other.MarkerStyle)
			{
				return false;
			}
			if (!AreaInternal.method_0(other.AreaInternal))
			{
				return false;
			}
			if (!BorderInternal.method_0(other.BorderInternal))
			{
				return false;
			}
			if (MarkerStyle != other.MarkerStyle)
			{
				return false;
			}
			if (MarkerSize != other.MarkerSize)
			{
				return false;
			}
		}
		return true;
	}

	internal void method_2(MarkerStyleType markerStyle)
	{
		if (MarkerStyle == MarkerStyleType.NotDefined)
		{
			MarkerStyle = markerStyle;
		}
	}

	internal void method_3(int size)
	{
		if (MarkerStyle == MarkerStyleType.NotDefined)
		{
			float num = class740_0.Graphics?.DpiX ?? 96f;
			int_0 = Struct41.smethod_5((float)size * num / 72f);
		}
	}

	internal void method_4(float x, float y)
	{
		method_5(x, y, MarkerSize);
	}

	internal void method_5(float x, float y, float markerSize)
	{
		if (MarkerStyle != MarkerStyleType.None)
		{
			new RectangleF(x - markerSize / 2f, y - markerSize / 2f, markerSize, markerSize);
			_ = class740_0.Graphics;
			int num = Struct41.smethod_5(markerSize / 2f);
			GraphicsPath graphicsPath = new GraphicsPath();
			switch (MarkerStyle)
			{
			case MarkerStyleType.Circle:
				x -= (float)num;
				y -= (float)num;
				graphicsPath.AddEllipse(x, y, num * 2, num * 2);
				AreaInternal.method_6(graphicsPath);
				class755_0.method_8(graphicsPath);
				break;
			case MarkerStyleType.Dash:
			{
				int num2 = Struct41.smethod_5(markerSize);
				int num3 = Struct41.smethod_5(markerSize / 4f);
				x -= (float)(num2 / 2);
				y -= (float)(num3 / 2);
				AreaInternal.method_5(new RectangleF(x, y, num2, num3));
				class755_0.method_7(new RectangleF(x, y, num2, num3));
				break;
			}
			case MarkerStyleType.Diamond:
			{
				PointF[] array2 = new PointF[4];
				array2[0].X = x - (float)num;
				array2[0].Y = y;
				array2[1].X = x;
				array2[1].Y = y - (float)num;
				array2[2].X = x + (float)num;
				array2[2].Y = y;
				array2[3].X = x;
				array2[3].Y = y + (float)num;
				graphicsPath.AddPolygon(array2);
				AreaInternal.method_6(graphicsPath);
				class755_0.method_8(graphicsPath);
				break;
			}
			case MarkerStyleType.Dot:
			{
				int num2 = Struct41.smethod_5(markerSize / 2f);
				int num3 = Struct41.smethod_5(markerSize / 4f);
				y = ((num3 >= 2) ? (y - (float)(num3 / 2)) : ((float)(int)((double)(y - (float)(num3 / 2)) + 0.5)));
				AreaInternal.method_5(new RectangleF(x, y, num2, num3));
				class755_0.method_7(new RectangleF(x, y, num2, num3));
				break;
			}
			case MarkerStyleType.None:
			case MarkerStyleType.Picture:
			case MarkerStyleType.Plus:
				break;
			case MarkerStyleType.Square:
				x -= (float)num;
				y -= (float)num;
				graphicsPath.AddRectangle(new RectangleF(x, y, 2 * num, 2 * num));
				AreaInternal.method_6(graphicsPath);
				class755_0.method_8(graphicsPath);
				break;
			case MarkerStyleType.Star:
				x -= (float)num;
				y -= (float)num;
				AreaInternal.method_5(new RectangleF(x, y, num * 2, num * 2));
				class755_0.method_3(x, y, x + (float)(num * 2), y + (float)(num * 2));
				class755_0.method_3(x, y + (float)(num * 2), x + (float)(num * 2), y);
				class755_0.method_3(x + (float)num, y, x + (float)num, y + (float)(num * 2));
				break;
			case MarkerStyleType.Triangle:
			{
				PointF[] array = new PointF[3];
				array[0].X = x - (float)num;
				array[0].Y = y + (float)num;
				array[1].X = x;
				array[1].Y = y - (float)num;
				array[2].X = x + (float)num;
				array[2].Y = y + (float)num;
				graphicsPath.AddPolygon(array);
				AreaInternal.method_6(graphicsPath);
				class755_0.method_8(graphicsPath);
				break;
			}
			case MarkerStyleType.X:
				x -= (float)num;
				y -= (float)num;
				AreaInternal.method_5(new RectangleF(x, y, num * 2, num * 2));
				class755_0.method_5(new PointF(x, y), new PointF(x + (float)(num * 2), y + (float)(num * 2)));
				class755_0.method_5(new PointF(x, y + (float)(num * 2)), new PointF(x + (float)(num * 2), y));
				break;
			}
		}
	}
}
