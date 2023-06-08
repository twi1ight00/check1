using System.Drawing;
using System.Drawing.Drawing2D;
using ns22;

namespace ns18;

internal class Class773
{
	internal static bool smethod_0(Class1009 class1009_0, Class1057 class1057_0, Class458 class458_0)
	{
		Class470 @class = new Class470();
		string text = @class.method_2(class458_0, bool_3: false);
		if (!Class1015.smethod_11(text))
		{
			return false;
		}
		class1009_0.method_3("Path");
		if (class458_0.class770_0 != null)
		{
			class1009_0.method_9("StrokeThickness", Class1025.smethod_11(class458_0.class770_0.float_0));
			class1009_0.method_9("StrokeLineJoin", Class1059.smethod_5(class458_0.class770_0.lineJoin_0));
			if (class458_0.class770_0.lineJoin_0 == LineJoin.Miter || class458_0.class770_0.lineJoin_0 == LineJoin.MiterClipped)
			{
				class1009_0.method_9("StrokeMiterLimit", Class1025.smethod_11(class458_0.class770_0.float_2));
			}
			class1009_0.method_9("StrokeStartLineCap", Class1059.smethod_6(class458_0.class770_0.lineCap_0));
			class1009_0.method_9("StrokeEndLineCap", Class1059.smethod_6(class458_0.class770_0.lineCap_1));
			if (class458_0.class770_0.dashStyle_0 != 0)
			{
				class1009_0.method_9("StrokeDashOffset", Class1025.smethod_11(class458_0.class770_0.float_3));
				class1009_0.method_9("StrokeDashCap", Class1059.smethod_7(class458_0.class770_0.dashCap_0));
				class1009_0.method_9("StrokeDashArray", Class1059.smethod_8(class458_0.class770_0.method_0()));
			}
		}
		if (class458_0.imethod_0() != null)
		{
			class1009_0.method_9("RenderTransform", Class1059.smethod_3(class458_0.imethod_0()));
		}
		class1009_0.method_9("Data", text);
		if (class458_0.imethod_1() != null)
		{
			class1009_0.method_9("Clip", @class.method_2(class458_0.imethod_1(), bool_3: true));
		}
		if (class458_0.method_2() != null)
		{
			smethod_3(class1009_0, class1057_0, class458_0.method_2());
		}
		if (class458_0.class770_0 != null)
		{
			smethod_2(class1009_0, class1057_0, class458_0.class770_0);
		}
		return true;
	}

	internal static void smethod_1(Class1009 class1009_0)
	{
		class1009_0.method_4();
	}

	internal static void smethod_2(Class1009 class1009_0, Class1057 class1057_0, Class770 class770_0)
	{
		class1009_0.method_3("Path.Stroke");
		class1009_0.method_3("SolidColorBrush");
		class1009_0.method_9("Color", Class1059.smethod_2(class770_0.color_0));
		class1009_0.method_4();
		class1009_0.method_4();
	}

	internal static void smethod_3(Class1009 class1009_0, Class1057 class1057_0, Brush brush_0)
	{
		class1009_0.method_3("Path.Fill");
		Class1056.smethod_0(class1009_0, class1057_0, brush_0);
		class1009_0.method_4();
	}
}
