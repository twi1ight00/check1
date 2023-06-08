using System.Drawing;
using System.Drawing.Drawing2D;
using ns22;

namespace ns18;

internal class Class1056
{
	private Class1056()
	{
	}

	internal static void smethod_0(Class1009 class1009_0, Class1057 class1057_0, Brush brush_0)
	{
		if (brush_0 != null)
		{
			if (brush_0 is SolidBrush)
			{
				smethod_2(class1009_0, (SolidBrush)brush_0);
			}
			else if (brush_0 is TextureBrush)
			{
				TextureBrush textureBrush_ = brush_0 as TextureBrush;
				smethod_6(class1009_0, class1057_0, textureBrush_);
			}
			else if (brush_0 is HatchBrush)
			{
				smethod_5(class1009_0, class1057_0, (HatchBrush)brush_0);
			}
			else if (brush_0 is Class1199)
			{
				Class1199 @class = (Class1199)brush_0;
				LinearGradientBrush linearGradientBrush_ = new LinearGradientBrush(@class.method_3(), @class.method_2(), @class.method_1(), @class.method_0());
				smethod_3(class1009_0, linearGradientBrush_);
			}
		}
	}

	internal static void smethod_1(Class1009 class1009_0, Class1057 class1057_0, byte[] byte_0, RectangleF rectangleF_0, WrapMode wrapMode_0, Matrix matrix_0)
	{
		Class1063 @class = class1057_0.vmethod_1(byte_0);
		class1009_0.method_3("ImageBrush");
		class1009_0.method_9("ImageSource", @class.Uri);
		Class1403 size = @class.Size;
		string string_ = $"{0},{0},{Class1059.smethod_1(size.method_0())},{Class1059.smethod_1(size.method_1())}";
		class1009_0.method_9("Viewbox", string_);
		string string_2 = $"{Class1025.smethod_11(rectangleF_0.X)},{Class1025.smethod_11(rectangleF_0.Y)},{Class1025.smethod_11((rectangleF_0.Width > 0f) ? rectangleF_0.Width : ((float)size.method_0()))},{Class1025.smethod_11((rectangleF_0.Height > 0f) ? rectangleF_0.Height : ((float)size.method_1()))}";
		class1009_0.method_9("Viewport", string_2);
		class1009_0.method_9("ViewboxUnits", "Absolute");
		class1009_0.method_9("ViewportUnits", "Absolute");
		if (matrix_0 != null)
		{
			class1009_0.method_9("Transform", Class1059.smethod_3(matrix_0.Clone()));
		}
		class1009_0.method_9("TileMode", Class1059.smethod_9(wrapMode_0));
		class1009_0.method_4();
	}

	private static void smethod_2(Class1009 class1009_0, SolidBrush solidBrush_0)
	{
		class1009_0.method_3("SolidColorBrush");
		class1009_0.method_9("Color", Class1059.smethod_2(solidBrush_0.Color));
		class1009_0.method_4();
	}

	private static void smethod_3(Class1009 class1009_0, LinearGradientBrush linearGradientBrush_0)
	{
		class1009_0.method_3("LinearGradientBrush");
		class1009_0.method_9("MappingMode", "Absolute");
		class1009_0.method_9("StartPoint", $"{Class1025.smethod_11(linearGradientBrush_0.Rectangle.X)},{Class1025.smethod_11(linearGradientBrush_0.Rectangle.Y)}");
		class1009_0.method_9("EndPoint", $"{Class1025.smethod_11(linearGradientBrush_0.Rectangle.Right)},{Class1025.smethod_11(linearGradientBrush_0.Rectangle.Top)}");
		class1009_0.method_9("SpreadMethod", "Repeat");
		if (linearGradientBrush_0.Transform != null)
		{
			class1009_0.method_9("Transform", Class1059.smethod_3(linearGradientBrush_0.Transform));
		}
		else
		{
			class1009_0.method_9("Transform", Class1059.smethod_3(new Matrix()));
		}
		class1009_0.method_3("LinearGradientBrush.GradientStops");
		if (linearGradientBrush_0.LinearColors != null)
		{
			for (int i = 0; i < linearGradientBrush_0.LinearColors.Length; i++)
			{
				smethod_4(class1009_0, linearGradientBrush_0.LinearColors[i], i);
			}
		}
		class1009_0.method_4();
		class1009_0.method_4();
	}

	private static void smethod_4(Class1009 class1009_0, Color color_0, float float_0)
	{
		class1009_0.method_3("GradientStop");
		class1009_0.method_9("Color", Class1059.smethod_2(color_0));
		class1009_0.method_9("Offset", Class1025.smethod_11(float_0));
		class1009_0.method_4();
	}

	private static void smethod_5(Class1009 class1009_0, Class1057 class1057_0, Brush brush_0)
	{
		byte[] byte_ = Class1019.smethod_0((HatchBrush)brush_0);
		smethod_1(class1009_0, class1057_0, byte_, RectangleF.Empty, WrapMode.Tile, null);
	}

	private static void smethod_6(Class1009 class1009_0, Class1057 class1057_0, TextureBrush textureBrush_0)
	{
		using Class1021 class1021_ = new Class1021(textureBrush_0);
		byte[] byte_ = Class1064.smethod_1(class1021_);
		try
		{
			Class1403 @class = Class1404.smethod_4(byte_);
			RectangleF rectangleF_ = new RectangleF(0f, 0f, @class.Width, @class.Height);
			smethod_1(class1009_0, class1057_0, byte_, rectangleF_, textureBrush_0.WrapMode, textureBrush_0.Transform.Clone());
		}
		catch
		{
		}
	}
}
