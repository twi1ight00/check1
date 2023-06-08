using System;
using System.Drawing;

namespace ns224;

internal class Class5993 : Class5992
{
	private double double_0;

	private Class5998 class5998_0;

	private bool bool_0;

	private RectangleF rectangleF_0 = RectangleF.Empty;

	private Class5998 class5998_1;

	private PointF pointF_0 = PointF.Empty;

	private PointF pointF_1 = PointF.Empty;

	public RectangleF Rectangle
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

	public Class5998 StartColor
	{
		get
		{
			return class5998_1;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			class5998_1 = value;
		}
	}

	public Class5998 EndColor
	{
		get
		{
			return class5998_0;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			class5998_0 = value;
		}
	}

	public bool IsScaled
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public double Angle
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

	public PointF StartPoint => pointF_0;

	public PointF EndPoint => pointF_1;

	public Class5993(RectangleF rect, Class5998 startColor, Class5998 endColor)
		: base(Enum746.const_3)
	{
		Rectangle = rect;
		StartColor = startColor;
		EndColor = endColor;
	}

	public Class5993(RectangleF rect, double angle, bool isScaled)
		: this(rect, Class5998.class5998_141, Class5998.class5998_141)
	{
		double_0 = angle;
		bool_0 = isScaled;
	}

	public Class5993(PointF startPoint, PointF endPoint, Class5998 startColor, Class5998 endColor)
		: base(Enum746.const_3)
	{
		StartColor = startColor;
		EndColor = endColor;
		pointF_0 = startPoint;
		pointF_1 = endPoint;
	}
}
