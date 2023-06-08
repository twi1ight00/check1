using System;
using System.Drawing.Drawing2D;
using ns224;

namespace ns267;

internal class Class6624
{
	private Class6616 class6616_0;

	public Class6624(Class6616 context)
	{
		class6616_0 = context;
	}

	public bool method_0(out Class5990 brush)
	{
		if (class6616_0.Reader.method_1())
		{
			if ("SolidBrush".Equals(class6616_0.Reader.CurrentElement.Name))
			{
				return method_1(out brush);
			}
			if ("TextureBrush".Equals(class6616_0.Reader.CurrentElement.Name))
			{
				return method_2(out brush);
			}
			if ("HatchBrush".Equals(class6616_0.Reader.CurrentElement.Name))
			{
				return method_3(out brush);
			}
			if ("LinearGradientBrush".Equals(class6616_0.Reader.CurrentElement.Name))
			{
				return method_4(out brush);
			}
			if ("PathGradientBrush".Equals(class6616_0.Reader.CurrentElement.Name))
			{
				return method_5(out brush);
			}
		}
		brush = null;
		return false;
	}

	private bool method_1(out Class5990 brush)
	{
		if (class6616_0.Reader.method_10("Color", out var value))
		{
			brush = new Class5997(value);
			return true;
		}
		brush = null;
		return false;
	}

	private bool method_2(out Class5990 brush)
	{
		if (class6616_0.Reader.method_5("ResourceId", out var value))
		{
			byte[] imageBytes = class6616_0.Resources.Read(value);
			Class5995 @class = new Class5995(imageBytes);
			if (class6616_0.Reader.method_9("Transform", out var value2))
			{
				@class.Transform = value2;
			}
			Enum value3 = WrapMode.Tile;
			if (class6616_0.Reader.method_7("WrapMode", ref value3))
			{
				@class.WrapMode = (WrapMode)(object)value3;
			}
			if (class6616_0.Reader.method_3("Opacity", out var value4))
			{
				@class.Opacity = value4;
			}
			if (class6616_0.Reader.method_18("ImageArea", out var value5))
			{
				@class.ImageArea = value5;
			}
			if (class6616_0.Reader.method_28("ColorMap", out var value6))
			{
				@class.ColorMap = value6;
			}
			brush = @class;
			return true;
		}
		brush = null;
		return false;
	}

	private bool method_3(out Class5990 brush)
	{
		Enum value = HatchStyle.Cross;
		if (class6616_0.Reader.method_10("BackgroundColor", out var value2) && class6616_0.Reader.method_10("ForegroundColor", out var value3) && class6616_0.Reader.method_7("HatchStyle", ref value))
		{
			brush = new Class5996((HatchStyle)(object)value, value3, value2);
			return true;
		}
		brush = null;
		return false;
	}

	private bool method_4(out Class5990 brush)
	{
		if (class6616_0.Reader.method_18("Rectangle", out var value) && class6616_0.Reader.method_4("Angle", out var value2) && class6616_0.Reader.method_6("IsScaled", out var value3))
		{
			Class5993 @class = new Class5993(value, value2, value3);
			if (class6616_0.Reader.method_10("StartColor", out var value4))
			{
				@class.StartColor = value4;
			}
			if (class6616_0.Reader.method_10("EndColor", out value4))
			{
				@class.EndColor = value4;
			}
			if (class6616_0.Reader.method_9("Transform", out var value5))
			{
				@class.Transform = value5;
			}
			Enum value6 = WrapMode.Tile;
			if (class6616_0.Reader.method_7("WrapMode", ref value6))
			{
				@class.WrapMode = (WrapMode)(object)value6;
			}
			if (class6616_0.Reader.method_8("BlendFactors", out var value7))
			{
				@class.BlendFactors = value7;
			}
			if (class6616_0.Reader.method_8("BlendPositions", out value7))
			{
				@class.BlendPositions = value7;
			}
			if (class6616_0.Reader.method_29("InterpolationColors", out var value8))
			{
				@class.InterpolationColors = value8;
			}
			brush = @class;
			return true;
		}
		brush = null;
		return false;
	}

	private bool method_5(out Class5990 brush)
	{
		if (class6616_0.Reader.method_22("Path", out var value) && class6616_0.Reader.method_14("CenterPoint", out var value2))
		{
			Class5994 @class = new Class5994(value, value2);
			if (class6616_0.Reader.method_8("BlendFactors", out var value3))
			{
				@class.BlendFactors = value3;
			}
			if (class6616_0.Reader.method_8("BlendPositions", out value3))
			{
				@class.BlendPositions = value3;
			}
			if (class6616_0.Reader.method_9("Transform", out var value4))
			{
				@class.Transform = value4;
			}
			Enum value5 = WrapMode.Tile;
			if (class6616_0.Reader.method_7("WrapMode", ref value5))
			{
				@class.WrapMode = (WrapMode)(object)value5;
			}
			if (class6616_0.Reader.method_29("InterpolationColors", out var value6))
			{
				@class.InterpolationColors = value6;
			}
			if (class6616_0.Reader.method_14("FocusScales", out var value7))
			{
				@class.FocusScales = value7;
			}
			brush = @class;
			return true;
		}
		brush = null;
		return false;
	}
}
