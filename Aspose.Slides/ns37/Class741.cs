using System.Drawing;
using System.Drawing.Drawing2D;
using Aspose.Slides;
using ns35;
using ns36;

namespace ns37;

internal class Class741 : Interface6
{
	private Class740 class740_0;

	private Enum140 enum140_0;

	private Color color_0;

	private Class770 class770_0;

	private Color color_1;

	private FillType fillType_0;

	private bool bool_0;

	internal bool bool_1;

	private object object_0;

	private bool bool_2 = true;

	internal Class740 Chart => class740_0;

	internal Enum140 AreaParentType => enum140_0;

	public bool InvertIfNegative
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
			bool_1 = false;
		}
	}

	public Color BackgroundColor
	{
		get
		{
			if (fillType_0 == FillType.NoFill)
			{
				return Color.Empty;
			}
			return color_0;
		}
		set
		{
			color_0 = value;
		}
	}

	internal Class770 FillFormatInternal => class770_0;

	public Interface25 FillFormat => class770_0;

	public Color ForegroundColor
	{
		get
		{
			if (fillType_0 == FillType.NoFill)
			{
				return Color.Empty;
			}
			return color_1;
		}
		set
		{
			color_1 = value;
		}
	}

	public FillType Formatting
	{
		get
		{
			return fillType_0;
		}
		set
		{
			fillType_0 = value;
		}
	}

	internal bool IsFillFormat
	{
		get
		{
			if (fillType_0 != FillType.Gradient && fillType_0 != FillType.Pattern && fillType_0 != FillType.Picture)
			{
				return false;
			}
			return true;
		}
	}

	internal bool IsTransparent
	{
		get
		{
			if (IsFillFormat)
			{
				return false;
			}
			if (fillType_0 == FillType.NoFill)
			{
				return true;
			}
			if (color_1.A <= 250)
			{
				return true;
			}
			return false;
		}
	}

	internal Class741(Class740 chart, object parent, Enum140 areaParentType)
	{
		class740_0 = chart;
		object_0 = parent;
		enum140_0 = areaParentType;
		color_1 = Color.Empty;
		color_0 = Color.Empty;
		bool_0 = false;
		bool_1 = true;
		fillType_0 = FillType.NotDefined;
		class770_0 = new Class770(this);
	}

	public bool method_0(Class741 other)
	{
		if (!IsFillFormat && !other.IsFillFormat)
		{
			if (Formatting != other.Formatting)
			{
				return false;
			}
			if (!BackgroundColor.Equals(other.BackgroundColor))
			{
				return false;
			}
			if (!ForegroundColor.Equals(other.ForegroundColor))
			{
				return false;
			}
			return true;
		}
		if (IsFillFormat != other.IsFillFormat)
		{
			return false;
		}
		Bitmap bitmap = new Bitmap(100, 100);
		Graphics graphics = Graphics.FromImage(bitmap);
		RectangleF rect = new RectangleF(0f, 0f, 100f, 100f);
		Brush brush = method_13(rect);
		graphics.FillRectangle(brush, rect);
		Bitmap bitmap2 = new Bitmap(100, 100);
		Graphics graphics2 = Graphics.FromImage(bitmap2);
		Brush brush2 = other.method_13(rect);
		graphics2.FillRectangle(brush2, rect);
		Class775 @class = new Class775();
		bool result = @class.method_5(bitmap, bitmap2);
		graphics.Dispose();
		graphics2.Dispose();
		bitmap.Dispose();
		bitmap2.Dispose();
		return result;
	}

	internal void method_1(Color color)
	{
		if (fillType_0 == FillType.NotDefined)
		{
			ForegroundColor = color;
		}
	}

	internal void method_2()
	{
		if (fillType_0 != FillType.NotDefined || !bool_2)
		{
			return;
		}
		Color color = class740_0.Themes.ThemeColors.method_3("dk1");
		switch (enum140_0)
		{
		case Enum140.const_0:
			if (class740_0.StyleIndex <= 32)
			{
				color_1 = class740_0.Themes.ThemeColors.method_3("bg1");
				color_1 = Color.FromArgb(255, color_1);
			}
			else if (class740_0.StyleIndex <= 40)
			{
				color_1 = class740_0.Themes.ThemeColors.method_3("lt1");
				color_1 = Color.FromArgb(255, color_1);
			}
			else
			{
				color_1 = color;
				color_1 = Color.FromArgb(255, color_1);
			}
			break;
		case Enum140.const_1:
			if (class740_0.Is3DChart())
			{
				fillType_0 = FillType.NoFill;
			}
			else
			{
				method_3(isPlotArea: true);
			}
			break;
		case Enum140.const_3:
		case Enum140.const_4:
			method_3(isPlotArea: false);
			break;
		case Enum140.const_14:
			if (class740_0.StyleIndex == 1)
			{
				color_1 = class740_0.Themes.ThemeColors.method_7(color, 0.25);
				color_1 = Color.FromArgb(255, color_1);
			}
			else if (class740_0.StyleIndex == 2)
			{
				color_1 = class740_0.Themes.ThemeColors.method_7(color, 0.05);
				color_1 = Color.FromArgb(255, color_1);
			}
			else if (class740_0.StyleIndex <= 8)
			{
				int num7 = class740_0.StyleIndex - 2;
				color_1 = class740_0.Themes.ThemeColors.method_3("accent" + num7);
				color_1 = class740_0.Themes.ThemeColors.method_7(color_1, 0.25);
				color_1 = Color.FromArgb(255, color_1);
			}
			else if (class740_0.StyleIndex == 9)
			{
				color_1 = class740_0.Themes.ThemeColors.method_7(color, 0.25);
				color_1 = Color.FromArgb(255, color_1);
			}
			else if (class740_0.StyleIndex == 10)
			{
				color_1 = class740_0.Themes.ThemeColors.method_7(color, 0.05);
				color_1 = Color.FromArgb(255, color_1);
			}
			else if (class740_0.StyleIndex <= 16)
			{
				int num8 = class740_0.StyleIndex - 10;
				color_1 = class740_0.Themes.ThemeColors.method_3("accent" + num8);
				color_1 = class740_0.Themes.ThemeColors.method_7(color_1, 0.25);
				color_1 = Color.FromArgb(255, color_1);
			}
			else if (class740_0.StyleIndex == 17)
			{
				color_1 = class740_0.Themes.ThemeColors.method_7(color, 0.25);
				color_1 = Color.FromArgb(255, color_1);
			}
			else if (class740_0.StyleIndex == 18)
			{
				color_1 = class740_0.Themes.ThemeColors.method_7(color, 0.05);
				color_1 = Color.FromArgb(255, color_1);
			}
			else if (class740_0.StyleIndex <= 24)
			{
				int num9 = class740_0.StyleIndex - 18;
				color_1 = class740_0.Themes.ThemeColors.method_3("accent" + num9);
				color_1 = class740_0.Themes.ThemeColors.method_7(color_1, 0.25);
				color_1 = Color.FromArgb(255, color_1);
			}
			else if (class740_0.StyleIndex == 25)
			{
				color_1 = class740_0.Themes.ThemeColors.method_7(color, 0.25);
				color_1 = Color.FromArgb(255, color_1);
			}
			else if (class740_0.StyleIndex == 26)
			{
				color_1 = class740_0.Themes.ThemeColors.method_7(color, 0.05);
				color_1 = Color.FromArgb(255, color_1);
			}
			else if (class740_0.StyleIndex <= 32)
			{
				int num10 = class740_0.StyleIndex - 26;
				color_1 = class740_0.Themes.ThemeColors.method_3("accent" + num10);
				color_1 = class740_0.Themes.ThemeColors.method_7(color_1, 0.25);
				color_1 = Color.FromArgb(255, color_1);
			}
			else if (class740_0.StyleIndex <= 40)
			{
				color_1 = class740_0.Themes.ThemeColors.method_3("lt1");
				color_1 = Color.FromArgb(255, color_1);
			}
			else if (class740_0.StyleIndex == 41)
			{
				color_1 = class740_0.Themes.ThemeColors.method_7(color, 0.25);
				color_1 = Color.FromArgb(255, color_1);
			}
			else if (class740_0.StyleIndex == 42)
			{
				color_1 = class740_0.Themes.ThemeColors.method_3("lt1");
				color_1 = Color.FromArgb(255, color_1);
			}
			else if (class740_0.StyleIndex <= 48)
			{
				int num11 = class740_0.StyleIndex - 42;
				color_1 = class740_0.Themes.ThemeColors.method_3("accent" + num11);
				color_1 = class740_0.Themes.ThemeColors.method_7(color_1, 0.25);
				color_1 = Color.FromArgb(255, color_1);
			}
			break;
		case Enum140.const_15:
			if (class740_0.StyleIndex == 1)
			{
				color_1 = class740_0.Themes.ThemeColors.method_7(color, 0.85);
				color_1 = Color.FromArgb(255, color_1);
			}
			else if (class740_0.StyleIndex == 2)
			{
				color_1 = class740_0.Themes.ThemeColors.method_7(color, 0.95);
				color_1 = Color.FromArgb(255, color_1);
			}
			else if (class740_0.StyleIndex <= 8)
			{
				int num = class740_0.StyleIndex - 2;
				color_1 = class740_0.Themes.ThemeColors.method_3("accent" + num);
				color_1 = class740_0.Themes.ThemeColors.method_8(color_1, 0.25);
				color_1 = Color.FromArgb(255, color_1);
			}
			else if (class740_0.StyleIndex == 9)
			{
				color_1 = class740_0.Themes.ThemeColors.method_7(color, 0.85);
				color_1 = Color.FromArgb(255, color_1);
			}
			else if (class740_0.StyleIndex == 10)
			{
				color_1 = class740_0.Themes.ThemeColors.method_7(color, 0.95);
				color_1 = Color.FromArgb(255, color_1);
			}
			else if (class740_0.StyleIndex <= 16)
			{
				int num2 = class740_0.StyleIndex - 10;
				color_1 = class740_0.Themes.ThemeColors.method_3("accent" + num2);
				color_1 = class740_0.Themes.ThemeColors.method_8(color_1, 0.25);
				color_1 = Color.FromArgb(255, color_1);
			}
			else if (class740_0.StyleIndex == 17)
			{
				color_1 = class740_0.Themes.ThemeColors.method_7(color, 0.85);
				color_1 = Color.FromArgb(255, color_1);
			}
			else if (class740_0.StyleIndex == 18)
			{
				color_1 = class740_0.Themes.ThemeColors.method_7(color, 0.95);
				color_1 = Color.FromArgb(255, color_1);
			}
			else if (class740_0.StyleIndex <= 24)
			{
				int num3 = class740_0.StyleIndex - 18;
				color_1 = class740_0.Themes.ThemeColors.method_3("accent" + num3);
				color_1 = class740_0.Themes.ThemeColors.method_8(color_1, 0.25);
				color_1 = Color.FromArgb(255, color_1);
			}
			else if (class740_0.StyleIndex == 25)
			{
				color_1 = class740_0.Themes.ThemeColors.method_7(color, 0.85);
				color_1 = Color.FromArgb(255, color_1);
			}
			else if (class740_0.StyleIndex == 26)
			{
				color_1 = class740_0.Themes.ThemeColors.method_7(color, 0.95);
				color_1 = Color.FromArgb(255, color_1);
			}
			else if (class740_0.StyleIndex <= 32)
			{
				int num4 = class740_0.StyleIndex - 26;
				color_1 = class740_0.Themes.ThemeColors.method_3("accent" + num4);
				color_1 = class740_0.Themes.ThemeColors.method_8(color_1, 0.25);
				color_1 = Color.FromArgb(255, color_1);
			}
			else if (class740_0.StyleIndex == 33)
			{
				color_1 = class740_0.Themes.ThemeColors.method_7(color, 0.85);
				color_1 = Color.FromArgb(255, color_1);
			}
			else if (class740_0.StyleIndex == 34)
			{
				color_1 = class740_0.Themes.ThemeColors.method_7(color, 0.95);
				color_1 = Color.FromArgb(255, color_1);
			}
			else if (class740_0.StyleIndex <= 40)
			{
				int num5 = class740_0.StyleIndex - 34;
				color_1 = class740_0.Themes.ThemeColors.method_3("accent" + num5);
				color_1 = class740_0.Themes.ThemeColors.method_8(color_1, 0.25);
				color_1 = Color.FromArgb(255, color_1);
			}
			else if (class740_0.StyleIndex == 41)
			{
				color_1 = class740_0.Themes.ThemeColors.method_7(color, 0.85);
				color_1 = Color.FromArgb(255, color_1);
			}
			else if (class740_0.StyleIndex == 42)
			{
				color_1 = color;
				color_1 = Color.FromArgb(255, color_1);
			}
			else if (class740_0.StyleIndex <= 48)
			{
				int num6 = class740_0.StyleIndex - 42;
				color_1 = class740_0.Themes.ThemeColors.method_3("accent" + num6);
				color_1 = class740_0.Themes.ThemeColors.method_8(color_1, 0.25);
				color_1 = Color.FromArgb(255, color_1);
			}
			break;
		}
		bool_2 = false;
	}

	private void method_3(bool isPlotArea)
	{
		if (class740_0.StyleIndex <= 32)
		{
			if (isPlotArea)
			{
				color_1 = Color.Empty;
			}
		}
		else if (class740_0.StyleIndex <= 34)
		{
			color_1 = class740_0.Themes.ThemeColors.method_3("dk1");
			color_1 = class740_0.Themes.ThemeColors.method_7(color_1, 0.2);
			color_1 = Color.FromArgb(255, color_1);
		}
		else if (class740_0.StyleIndex <= 40)
		{
			int num = class740_0.StyleIndex - 34;
			color_1 = class740_0.Themes.ThemeColors.method_3("accent" + num);
			color_1 = class740_0.Themes.ThemeColors.method_7(color_1, 0.2);
			color_1 = Color.FromArgb(255, color_1);
		}
		else
		{
			color_1 = class740_0.Themes.ThemeColors.method_3("dk1");
			color_1 = class740_0.Themes.ThemeColors.method_7(color_1, 0.95);
			color_1 = Color.FromArgb(255, color_1);
		}
	}

	internal void method_4(Rectangle rect)
	{
		method_5(new RectangleF(rect.X, rect.Y, rect.Width, rect.Height));
	}

	internal void method_5(RectangleF rect)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddRectangle(rect);
		method_7(graphicsPath, 1f);
	}

	internal void method_6(GraphicsPath path)
	{
		method_7(path, 1f);
	}

	internal void method_7(GraphicsPath path, float colorGene)
	{
		method_11(path, colorGene, path);
	}

	internal void method_8(Rectangle rect, GraphicsPath brushPath)
	{
		RectangleF rect2 = new RectangleF(rect.X, rect.Y, rect.Width, rect.Height);
		method_9(rect2, brushPath);
	}

	internal void method_9(RectangleF rect, GraphicsPath brushPath)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddRectangle(rect);
		method_11(graphicsPath, 1f, brushPath);
	}

	internal void method_10(GraphicsPath fillPath, GraphicsPath brushPath)
	{
		method_11(fillPath, 1f, brushPath);
	}

	internal void method_11(GraphicsPath fillPath, float colorGene, GraphicsPath brushPath)
	{
		if (Formatting != 0 && fillPath != null && brushPath != null)
		{
			Brush brush = method_15(brushPath, colorGene);
			Interface32 graphics = class740_0.Graphics;
			graphics.imethod_77(brush, fillPath);
			method_16(brush);
		}
	}

	internal Brush method_12(Rectangle rect)
	{
		RectangleF rect2 = new RectangleF(rect.X, rect.Y, rect.Width, rect.Height);
		return method_13(rect2);
	}

	internal Brush method_13(RectangleF rect)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddRectangle(rect);
		return method_15(graphicsPath, 1f);
	}

	internal Brush method_14(GraphicsPath path)
	{
		return method_15(path, 1f);
	}

	internal Brush method_15(GraphicsPath path, float colorGene)
	{
		method_2();
		bool flag = method_17();
		Brush brush = null;
		if (IsFillFormat)
		{
			return class770_0.method_2(path, flag, colorGene);
		}
		Color color = color_1;
		if (flag)
		{
			color = color_0;
		}
		return new SolidBrush(Color.FromArgb(color.A, (int)((float)(int)color.R * colorGene), (int)((float)(int)color.G * colorGene), (int)((float)(int)color.B * colorGene)));
	}

	private void method_16(Brush brush)
	{
		if (IsFillFormat)
		{
			class770_0.method_3(brush);
		}
		else
		{
			brush.Dispose();
		}
	}

	internal bool method_17()
	{
		bool result = false;
		if (enum140_0 == Enum140.const_7 && !bool_1)
		{
			Class748 @class = (Class748)object_0;
			if (InvertIfNegative && @class.IsValueNegative)
			{
				result = true;
			}
		}
		else if (enum140_0 == Enum140.const_7 && bool_1)
		{
			Class748 class2 = (Class748)object_0;
			if (class2.ChartPoints.ASeries.AreaInternal.InvertIfNegative && class2.IsValueNegative)
			{
				result = true;
			}
		}
		return result;
	}
}
