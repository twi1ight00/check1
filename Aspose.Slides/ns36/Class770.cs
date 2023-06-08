using System.Drawing;
using System.Drawing.Drawing2D;
using Aspose.Slides;

namespace ns36;

internal class Class770 : Interface25
{
	private Interface6 interface6_0;

	private HatchBrush hatchBrush_0;

	private Class781 class781_0;

	private Class771 class771_0;

	internal HatchBrush PatternBrush => hatchBrush_0;

	internal Class771 GradientFillInernal => class771_0;

	internal Class781 TextureFillInernal => class781_0;

	public Interface26 GradientFill => class771_0;

	public Interface31 TextureFill => class781_0;

	internal FillType FormattingType => interface6_0.Formatting;

	public Class770(Interface6 parent)
	{
		interface6_0 = parent;
		class771_0 = new Class771();
		class781_0 = new Class781();
	}

	public void imethod_0(Color color1, Color color2, HatchStyle style)
	{
		interface6_0.Formatting = FillType.Pattern;
		hatchBrush_0 = new HatchBrush(style, color1, color2);
	}

	internal Brush method_0(Rectangle rect)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddRectangle(rect);
		return method_2(graphicsPath, isColorReserved: false, 1f);
	}

	internal Brush method_1(RectangleF rect)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddRectangle(rect);
		return method_2(graphicsPath, isColorReserved: false, 1f);
	}

	public Brush method_2(GraphicsPath path, bool isColorReserved, float colorGene)
	{
		switch (FormattingType)
		{
		default:
			return new SolidBrush(Color.White);
		case FillType.Gradient:
			return GradientFillInernal.method_0(path, null, isColorReserved, colorGene);
		case FillType.Pattern:
		{
			Color foreColor = Color.FromArgb(hatchBrush_0.ForegroundColor.A, (int)((float)(int)hatchBrush_0.ForegroundColor.R * colorGene), (int)((float)(int)hatchBrush_0.ForegroundColor.G * colorGene), (int)((float)(int)hatchBrush_0.ForegroundColor.B * colorGene));
			Color backColor = Color.FromArgb(hatchBrush_0.BackgroundColor.A, (int)((float)(int)hatchBrush_0.BackgroundColor.R * colorGene), (int)((float)(int)hatchBrush_0.BackgroundColor.G * colorGene), (int)((float)(int)hatchBrush_0.BackgroundColor.B * colorGene));
			return new HatchBrush(hatchBrush_0.HatchStyle, foreColor, backColor);
		}
		case FillType.Picture:
			return class781_0.method_2(path, colorGene);
		}
	}

	public void method_3(Brush brush)
	{
		switch (FormattingType)
		{
		case FillType.Gradient:
		case FillType.Pattern:
			brush.Dispose();
			break;
		case FillType.Picture:
			brush.Dispose();
			break;
		}
	}

	public bool method_4(Class770 other)
	{
		if (other == null)
		{
			return false;
		}
		if (FormattingType != other.FormattingType)
		{
			return false;
		}
		if (FormattingType == FillType.Gradient)
		{
			return GradientFillInernal.method_3(other.GradientFillInernal);
		}
		if (FormattingType == FillType.Pattern)
		{
			if (PatternBrush.HatchStyle != other.PatternBrush.HatchStyle)
			{
				return false;
			}
			if (PatternBrush.BackgroundColor.A == other.PatternBrush.BackgroundColor.A && PatternBrush.BackgroundColor.R == other.PatternBrush.BackgroundColor.R && PatternBrush.BackgroundColor.G == other.PatternBrush.BackgroundColor.B && PatternBrush.BackgroundColor.B == other.PatternBrush.BackgroundColor.B)
			{
				if (PatternBrush.ForegroundColor.A == other.PatternBrush.ForegroundColor.A && PatternBrush.ForegroundColor.R == other.PatternBrush.ForegroundColor.R && PatternBrush.ForegroundColor.G == other.PatternBrush.ForegroundColor.B && PatternBrush.ForegroundColor.B == other.PatternBrush.ForegroundColor.B)
				{
					return true;
				}
				return false;
			}
			return false;
		}
		if (FormattingType == FillType.Picture)
		{
			return TextureFillInernal.method_1(other.TextureFillInernal);
		}
		return false;
	}
}
