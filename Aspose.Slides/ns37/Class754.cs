using System;
using Aspose.Slides;
using ns36;

namespace ns37;

internal class Class754 : ICloneable, Interface17
{
	private double double_0;

	private Enum155 enum155_0;

	private LineDashStyle lineDashStyle_0;

	private Enum154 enum154_0;

	private LineJoinStyle lineJoinStyle_0;

	private Enum147 enum147_0;

	private Enum148 enum148_0;

	private Enum146 enum146_0;

	private Enum147 enum147_1;

	private Enum148 enum148_1;

	private Enum146 enum146_1;

	public double Width
	{
		get
		{
			return double_0;
		}
		set
		{
			if (double_0 > 0.0 && double_0 < 1.0)
			{
				double_0 = 1.0;
			}
			else
			{
				double_0 = value;
			}
		}
	}

	public Enum155 Compound
	{
		get
		{
			return enum155_0;
		}
		set
		{
			enum155_0 = value;
		}
	}

	public LineDashStyle DashStyle
	{
		get
		{
			return lineDashStyle_0;
		}
		set
		{
			lineDashStyle_0 = value;
		}
	}

	public Enum154 LineCap
	{
		get
		{
			return enum154_0;
		}
		set
		{
			enum154_0 = value;
		}
	}

	public LineJoinStyle LineJoin
	{
		get
		{
			return lineJoinStyle_0;
		}
		set
		{
			lineJoinStyle_0 = value;
		}
	}

	public Enum147 BeginheadStyle
	{
		get
		{
			return enum147_0;
		}
		set
		{
			enum147_0 = value;
		}
	}

	public Enum148 BeginheadWidth
	{
		get
		{
			return enum148_0;
		}
		set
		{
			enum148_0 = value;
		}
	}

	public Enum146 BeginheadLength
	{
		get
		{
			return enum146_0;
		}
		set
		{
			enum146_0 = value;
		}
	}

	public Enum147 EndheadStyle
	{
		get
		{
			return enum147_1;
		}
		set
		{
			enum147_1 = value;
		}
	}

	public Enum148 EndheadWidth
	{
		get
		{
			return enum148_1;
		}
		set
		{
			enum148_1 = value;
		}
	}

	public Enum146 EndheadLength
	{
		get
		{
			return enum146_1;
		}
		set
		{
			enum146_1 = value;
		}
	}

	internal Class754()
	{
		double_0 = 0.0;
		enum155_0 = Enum155.const_0;
		lineDashStyle_0 = LineDashStyle.Solid;
		enum147_0 = Enum147.const_0;
		enum148_0 = Enum148.const_0;
		enum146_0 = Enum146.const_0;
		enum147_1 = Enum147.const_0;
		enum148_1 = Enum148.const_0;
		enum146_1 = Enum146.const_0;
	}

	internal bool method_0(Class754 other)
	{
		if (Width != other.Width)
		{
			return false;
		}
		if (Compound != other.Compound)
		{
			return false;
		}
		if (DashStyle != other.DashStyle)
		{
			return false;
		}
		if (LineCap != other.LineCap)
		{
			return false;
		}
		if (LineJoin != other.LineJoin)
		{
			return false;
		}
		if (BeginheadStyle != other.BeginheadStyle)
		{
			return false;
		}
		if (BeginheadWidth != other.BeginheadWidth)
		{
			return false;
		}
		if (BeginheadLength != other.BeginheadLength)
		{
			return false;
		}
		if (EndheadStyle != other.EndheadStyle)
		{
			return false;
		}
		if (EndheadWidth != other.EndheadWidth)
		{
			return false;
		}
		if (EndheadLength != other.EndheadLength)
		{
			return false;
		}
		if (BeginheadStyle == Enum147.const_0 && EndheadStyle == Enum147.const_0)
		{
			return true;
		}
		return false;
	}

	public object Clone()
	{
		Class754 @class = new Class754();
		@class.Width = Width;
		@class.Compound = Compound;
		@class.DashStyle = DashStyle;
		@class.LineCap = LineCap;
		@class.LineJoin = LineJoin;
		@class.BeginheadStyle = BeginheadStyle;
		@class.BeginheadWidth = BeginheadWidth;
		@class.BeginheadLength = BeginheadLength;
		@class.EndheadStyle = EndheadStyle;
		@class.EndheadWidth = EndheadWidth;
		@class.EndheadLength = EndheadLength;
		return @class;
	}
}
