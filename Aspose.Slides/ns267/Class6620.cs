using System;
using ns224;

namespace ns267;

internal class Class6620
{
	private Class6616 class6616_0;

	public Class6620(Class6616 context)
	{
		class6616_0 = context;
	}

	public void Write(Class5990 brush)
	{
		switch (brush.BrushType)
		{
		default:
			throw new NotSupportedException("Unsupported brush type.");
		case Enum746.const_0:
			method_0((Class5997)brush);
			break;
		case Enum746.const_1:
			method_2((Class5996)brush);
			break;
		case Enum746.const_2:
			method_1((Class5995)brush);
			break;
		case Enum746.const_3:
			method_3((Class5993)brush);
			break;
		case Enum746.const_4:
			method_4((Class5994)brush);
			break;
		}
	}

	private void method_0(Class5997 brush)
	{
		class6616_0.Writer.method_0("SolidBrush");
		class6616_0.Writer.method_28("Color", brush.Color);
		class6616_0.Writer.method_2();
	}

	private void method_1(Class5995 brush)
	{
		class6616_0.Writer.method_0("TextureBrush");
		int value = class6616_0.Resources.Write(brush.ImageBytes);
		class6616_0.Writer.method_23("ResourceId", value);
		if (brush.Transform != null)
		{
			class6616_0.Writer.method_26("Transform", brush.Transform);
		}
		class6616_0.Writer.method_27("WrapMode", brush.WrapMode);
		class6616_0.Writer.method_22("Opacity", brush.Opacity);
		class6616_0.Writer.method_13("ImageArea", brush.ImageArea);
		if (brush.ColorMap != null)
		{
			class6616_0.Writer.method_0("ColorMap");
			Class5998[] colorMap = brush.ColorMap;
			foreach (Class5998 value2 in colorMap)
			{
				class6616_0.Writer.method_0("Color");
				class6616_0.Writer.method_28("Value", value2);
				class6616_0.Writer.method_2();
			}
			class6616_0.Writer.method_2();
		}
		class6616_0.Writer.method_2();
	}

	private void method_2(Class5996 brush)
	{
		class6616_0.Writer.method_0("HatchBrush");
		class6616_0.Writer.method_28("BackgroundColor", brush.BackgroundColor);
		class6616_0.Writer.method_28("ForegroundColor", brush.ForegroundColor);
		class6616_0.Writer.method_27("HatchStyle", brush.HatchStyle);
		class6616_0.Writer.method_2();
	}

	private void method_3(Class5993 brush)
	{
		class6616_0.Writer.method_0("LinearGradientBrush");
		class6616_0.Writer.method_21("Angle", brush.Angle);
		if (brush.BlendFactors != null)
		{
			class6616_0.Writer.method_29("BlendFactors", brush.BlendFactors);
		}
		if (brush.BlendPositions != null)
		{
			class6616_0.Writer.method_29("BlendPositions", brush.BlendPositions);
		}
		if (brush.EndColor != null)
		{
			class6616_0.Writer.method_28("EndColor", brush.EndColor);
		}
		class6616_0.Writer.method_24("IsScaled", brush.IsScaled);
		if (brush.StartColor != null)
		{
			class6616_0.Writer.method_28("StartColor", brush.StartColor);
		}
		if (brush.Transform != null)
		{
			class6616_0.Writer.method_26("Transform", brush.Transform);
		}
		class6616_0.Writer.method_27("WrapMode", brush.WrapMode);
		class6616_0.Writer.method_13("Rectangle", brush.Rectangle);
		if (brush.InterpolationColors != null)
		{
			class6616_0.Writer.method_0("InterpolationColors");
			Class6000[] interpolationColors = brush.InterpolationColors;
			foreach (Class6000 @class in interpolationColors)
			{
				class6616_0.Writer.method_0("Color");
				class6616_0.Writer.method_28("Color", @class.Color);
				class6616_0.Writer.method_22("Position", @class.Position);
				class6616_0.Writer.method_2();
			}
			class6616_0.Writer.method_2();
		}
		class6616_0.Writer.method_2();
	}

	private void method_4(Class5994 brush)
	{
		class6616_0.Writer.method_0("PathGradientBrush");
		if (brush.BlendFactors != null)
		{
			class6616_0.Writer.method_29("BlendFactors", brush.BlendFactors);
		}
		if (brush.BlendPositions != null)
		{
			class6616_0.Writer.method_29("BlendPositions", brush.BlendPositions);
		}
		if (brush.Transform != null)
		{
			class6616_0.Writer.method_26("Transform", brush.Transform);
		}
		class6616_0.Writer.method_27("WrapMode", brush.WrapMode);
		class6616_0.Writer.method_14("CenterPoint", brush.CenterPoint);
		class6616_0.Writer.method_14("FocusScales", brush.FocusScales);
		if (brush.InterpolationColors != null)
		{
			class6616_0.Writer.method_0("InterpolationColors");
			Class6000[] interpolationColors = brush.InterpolationColors;
			foreach (Class6000 @class in interpolationColors)
			{
				class6616_0.Writer.method_0("Color");
				class6616_0.Writer.method_28("Color", @class.Color);
				class6616_0.Writer.method_22("Position", @class.Position);
				class6616_0.Writer.method_2();
			}
			class6616_0.Writer.method_2();
		}
		if (brush.Path != null)
		{
			class6616_0.Writer.method_8("Path", brush.Path);
		}
		class6616_0.Writer.method_2();
	}
}
