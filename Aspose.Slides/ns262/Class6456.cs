using System.Collections.Generic;
using System.Drawing;
using ns253;

namespace ns262;

internal class Class6456 : Interface302
{
	private double double_0;

	private double double_1;

	private List<Interface307> list_0 = new List<Interface307>();

	private double double_2;

	private double double_3;

	private double double_4;

	public RectangleF Bounds
	{
		get
		{
			return new RectangleF((float)X, (float)Y, (float)Width, (float)Height);
		}
		set
		{
			X = value.X;
			Y = value.Y;
			Width = value.Width;
			Height = value.Height;
		}
	}

	public double Height
	{
		get
		{
			return double_1;
		}
		set
		{
			double_1 = value;
		}
	}

	public double Width
	{
		get
		{
			return double_2;
		}
		set
		{
			double_2 = value;
		}
	}

	public double X
	{
		get
		{
			return double_3;
		}
		set
		{
			double_3 = value;
		}
	}

	public double Y
	{
		get
		{
			return double_4;
		}
		set
		{
			double_4 = value;
		}
	}

	public double ActualHeight => double_0;

	public void imethod_0(Interface307 line, Interface299 lineSpacing)
	{
		Interface300 @interface = lineSpacing.imethod_1(line.VerticalMeasurement);
		line.Y = double_4 + double_0 + @interface.Ascent;
		line.X = X;
		if (list_0.Count == 0)
		{
			line.IsOverflowed = false;
		}
		else
		{
			line.IsOverflowed = @interface.Height + double_0 > double_1;
		}
		double_0 += @interface.LineSpacing;
		list_0.Add(line);
	}

	public void imethod_1(double spaceBefore)
	{
		if (list_0.Count != 0)
		{
			double_0 += spaceBefore;
		}
	}

	public void imethod_2(double spaceAfter)
	{
		double_0 += spaceAfter;
	}

	public void imethod_3(Interface307 line)
	{
		list_0.Remove(line);
	}
}
