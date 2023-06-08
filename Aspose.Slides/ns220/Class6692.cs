using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using ns224;
using ns233;
using ns234;
using ns235;

namespace ns220;

internal static class Class6692
{
	internal static void smethod_0(Class5947 builder, Class6688 context, Class5990 brush)
	{
		switch (brush.BrushType)
		{
		default:
			throw new NotSupportedException("Unsupported brush type.");
		case Enum746.const_0:
			smethod_2(builder, (Class5997)brush);
			break;
		case Enum746.const_1:
			smethod_5(builder, context, (Class5996)brush);
			break;
		case Enum746.const_2:
			smethod_6(builder, context, (Class5995)brush);
			break;
		case Enum746.const_3:
			smethod_3(builder, context, (Class5993)brush);
			break;
		case Enum746.const_4:
			smethod_6(builder, context, smethod_7((Class5994)brush));
			break;
		}
	}

	internal static void smethod_1(Class5947 builder, Class6688 context, byte[] imageBytes, Class6145 crop, RectangleF dstRect, WrapMode wrapMode, Class6002 renderTransform)
	{
		Class6696 @class = context.AddImage(imageBytes, crop);
		builder.method_2("ImageBrush");
		builder.method_14("ImageSource", @class.Uri);
		Class6147 size = @class.Size;
		RectangleF value = new RectangleF(0f, 0f, (float)Class6693.smethod_0(size.WidthPoints), (float)Class6693.smethod_0(size.HeightPoints));
		builder.method_23("Viewbox", value);
		if (!Class6145.smethod_0(crop))
		{
			dstRect = crop.method_2(dstRect);
		}
		RectangleF value2 = new RectangleF(dstRect.X, dstRect.Y, (dstRect.Width > 0f) ? dstRect.Width : ((float)size.WidthPoints), (dstRect.Height > 0f) ? dstRect.Height : ((float)size.HeightPoints));
		builder.method_23("Viewport", value2);
		builder.method_14("ViewboxUnits", "Absolute");
		builder.method_14("ViewportUnits", "Absolute");
		if (renderTransform != null)
		{
			builder.method_24("Transform", renderTransform);
		}
		builder.method_14("TileMode", Class6693.smethod_4(wrapMode));
		builder.method_3();
	}

	private static void smethod_2(Class5947 builder, Class5997 brush)
	{
		builder.method_2("SolidColorBrush");
		builder.method_21("Color", brush.Color);
		builder.method_3();
	}

	private static void smethod_3(Class5947 builder, Class6688 context, Class5993 brush)
	{
		if (!brush.Angle.Equals(0.0))
		{
			Class5995 brush2 = smethod_8(brush);
			smethod_6(builder, context, brush2);
			return;
		}
		builder.method_2("LinearGradientBrush");
		builder.method_14("MappingMode", "Absolute");
		if (!brush.StartPoint.IsEmpty && !brush.EndPoint.IsEmpty)
		{
			builder.method_22("StartPoint", brush.StartPoint.X, brush.StartPoint.Y);
			builder.method_22("EndPoint", brush.EndPoint.X, brush.EndPoint.Y);
		}
		else
		{
			builder.method_22("StartPoint", brush.Rectangle.X, brush.Rectangle.Y);
			builder.method_22("EndPoint", brush.Rectangle.Right, brush.Rectangle.Top);
		}
		if (brush.WrapMode == WrapMode.TileFlipX)
		{
			builder.method_14("SpreadMethod", "Reflect");
		}
		else
		{
			builder.method_14("SpreadMethod", "Repeat");
		}
		if (brush.Transform != null)
		{
			builder.method_24("Transform", brush.Transform);
		}
		builder.method_2("LinearGradientBrush.GradientStops");
		if (brush.InterpolationColors == null)
		{
			smethod_4(builder, brush.StartColor, 0f);
			smethod_4(builder, brush.EndColor, 1f);
		}
		else
		{
			Class6000[] interpolationColors = brush.InterpolationColors;
			foreach (Class6000 @class in interpolationColors)
			{
				smethod_4(builder, @class.Color, @class.Position);
			}
		}
		builder.method_3();
		builder.method_3();
	}

	private static void smethod_4(Class5947 builder, Class5998 color, float offset)
	{
		builder.method_2("GradientStop");
		builder.method_21("Color", color);
		builder.method_20("Offset", offset);
		builder.method_3();
	}

	private static void smethod_5(Class5947 builder, Class6688 context, Class5996 brush)
	{
		byte[] imageBytes = Class6141.smethod_0(brush);
		smethod_1(builder, context, imageBytes, null, RectangleF.Empty, WrapMode.Tile, null);
	}

	private static void smethod_6(Class5947 builder, Class6688 context, Class5995 brush)
	{
		using Class6150 palImage = new Class6150(brush);
		byte[] imageBytes = Class6697.smethod_0(palImage);
		Class6147 @class = Class6148.smethod_3(imageBytes);
		RectangleF dstRect = new RectangleF(0f, 0f, @class.Width, @class.Height);
		smethod_1(builder, context, imageBytes, null, dstRect, brush.WrapMode, brush.Transform.Clone());
	}

	private static Class5995 smethod_7(Class5994 brush)
	{
		Class6185 @class = new Class6185();
		RectangleF rectangleF = @class.method_2(brush.Path);
		using Class6150 class2 = new Class6150((int)rectangleF.Width, (int)rectangleF.Height);
		using PathGradientBrush pathGradientBrush = (PathGradientBrush)Class6151.smethod_0(brush);
		Class6002 transform = Class6161.smethod_1(pathGradientBrush.Transform);
		pathGradientBrush.Transform = new Matrix();
		using (Class6160 class3 = new Class6160(class2))
		{
			class3.method_6().FillRectangle(pathGradientBrush, 0, 0, class2.Width, class2.Height);
		}
		byte[] imageBytes;
		using (MemoryStream memoryStream = new MemoryStream())
		{
			class2.Save(memoryStream, Enum788.const_5);
			imageBytes = memoryStream.ToArray();
		}
		Class5995 class4 = new Class5995(imageBytes);
		class4.Transform = transform;
		return class4;
	}

	private static Class5995 smethod_8(Class5993 brush)
	{
		RectangleF rectangle = brush.Rectangle;
		Class6002 transform = brush.Transform;
		RectangleF rectangle2 = new RectangleF((float)Math.Floor(rectangle.X), (float)Math.Floor(rectangle.Y), (float)Math.Ceiling(rectangle.Width), (float)Math.Ceiling(rectangle.Height));
		float num = 1f;
		float num2 = 1f;
		using (LinearGradientBrush linearGradientBrush = (LinearGradientBrush)Class6151.smethod_0(brush))
		{
			PointF[] array = new PointF[2]
			{
				new PointF(rectangle2.Left, rectangle2.Top),
				new PointF(rectangle2.Right, rectangle2.Top)
			};
			double num3 = smethod_9(array[0], array[1]);
			linearGradientBrush.Transform.TransformPoints(array);
			double num4 = smethod_9(array[0], array[1]);
			if (num3 < num4)
			{
				rectangle2 = new RectangleF((float)Math.Floor(rectangle.X), (float)Math.Floor(rectangle.Y), (float)Math.Ceiling(num4), (float)Math.Ceiling(rectangle.Height));
				num2 = rectangle.Width / rectangle2.Width;
			}
		}
		brush.Rectangle = rectangle2;
		using Class6150 @class = new Class6150((int)rectangle2.Width, (int)rectangle2.Height);
		using Class6160 class3 = new Class6160(@class);
		using LinearGradientBrush linearGradientBrush2 = (LinearGradientBrush)Class6151.smethod_0(brush);
		using MemoryStream memoryStream = new MemoryStream();
		Class6002 class2 = Class6161.smethod_1(linearGradientBrush2.Transform);
		linearGradientBrush2.Transform = new Matrix();
		class3.method_6().FillRectangle(linearGradientBrush2, 0, 0, @class.Width, @class.Height);
		@class.Save(memoryStream, Enum788.const_5);
		byte[] imageBytes = memoryStream.ToArray();
		Class5995 class4 = new Class5995(imageBytes);
		class2.method_7(rectangle2.X, rectangle2.Y, MatrixOrder.Append);
		class2.method_5(1f / num2, 1f / num, MatrixOrder.Append);
		class2.method_7(0f - rectangle.X, 0f - rectangle.Y, MatrixOrder.Append);
		class4.Transform = class2;
		brush.Transform = transform;
		brush.Rectangle = rectangle;
		return class4;
	}

	private static double smethod_9(PointF p, PointF q)
	{
		double num = p.X - q.X;
		double num2 = p.Y - q.Y;
		return Math.Sqrt(num * num + num2 * num2);
	}
}
