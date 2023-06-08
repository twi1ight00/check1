using System.Drawing.Drawing2D;
using System.Text;
using ns218;
using ns224;
using ns234;
using ns235;

namespace ns220;

internal static class Class6705
{
	internal static bool smethod_0(Class5947 builder, Class6688 context, Class6217 path)
	{
		Class6201 @class = new Class6201();
		string text = @class.method_0(path);
		if (Class5964.smethod_20(text) && !(text == "F 1 "))
		{
			builder.method_2("Path");
			if (path.Pen != null)
			{
				builder.method_20("StrokeThickness", path.Pen.Width);
				builder.method_14("StrokeLineJoin", Class6693.smethod_1(path.Pen.LineJoin));
				if (path.Pen.LineJoin == LineJoin.Miter || path.Pen.LineJoin == LineJoin.MiterClipped)
				{
					builder.method_20("StrokeMiterLimit", path.Pen.MiterLimit);
				}
				builder.method_14("StrokeStartLineCap", Class6693.smethod_2(path.Pen.StartCap));
				builder.method_14("StrokeEndLineCap", Class6693.smethod_2(path.Pen.EndCap));
				if (path.Pen.DashStyle != 0)
				{
					builder.method_20("StrokeDashOffset", path.Pen.DashOffset);
					builder.method_14("StrokeDashCap", Class6693.smethod_3(path.Pen.DashCap));
					builder.method_14("StrokeDashArray", smethod_2(path.Pen.DashPattern));
				}
			}
			if (path.RenderTransform != null)
			{
				builder.method_24("RenderTransform", path.RenderTransform);
			}
			builder.method_14("Data", text);
			if (path.Clip != null)
			{
				builder.method_14("Clip", @class.method_0(path.Clip));
			}
			if (path.Brush != null)
			{
				smethod_4(builder, context, path.Brush);
			}
			if (path.Pen != null)
			{
				smethod_3(builder, context, path.Pen);
			}
			return true;
		}
		return false;
	}

	internal static void smethod_1(Class5946 builder)
	{
		builder.method_3();
	}

	private static string smethod_2(float[] dashPattern)
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < dashPattern.Length; i++)
		{
			stringBuilder.Append(Class6159.smethod_43(dashPattern[i]));
			if (i < dashPattern.Length - 1)
			{
				stringBuilder.Append(" ");
			}
		}
		return stringBuilder.ToString();
	}

	internal static void smethod_3(Class5947 builder, Class6688 context, Class6003 pen)
	{
		builder.method_2("Path.Stroke");
		Class6692.smethod_0(builder, context, pen.Brush);
		builder.method_3();
	}

	internal static void smethod_4(Class5947 builder, Class6688 context, Class5990 brush)
	{
		builder.method_2("Path.Fill");
		Class6692.smethod_0(builder, context, brush);
		builder.method_3();
	}
}
