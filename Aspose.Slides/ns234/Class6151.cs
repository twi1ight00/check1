using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using ns224;
using ns236;

namespace ns234;

internal static class Class6151
{
	public static Brush smethod_0(Class5990 brush)
	{
		return brush.BrushType switch
		{
			Enum746.const_0 => smethod_10((Class5997)brush), 
			Enum746.const_1 => smethod_9((Class5996)brush), 
			Enum746.const_2 => smethod_5((Class5995)brush), 
			Enum746.const_3 => smethod_2((Class5993)brush), 
			Enum746.const_4 => smethod_1((Class5994)brush), 
			_ => throw new InvalidOperationException("Unknown brush type."), 
		};
	}

	private static Brush smethod_1(Class5994 brush)
	{
		Class6188 @class = new Class6188();
		brush.Path.vmethod_0(@class);
		PathGradientBrush pathGradientBrush = new PathGradientBrush(@class.GraphicsPath);
		pathGradientBrush.CenterPoint = brush.CenterPoint;
		pathGradientBrush.MultiplyTransform(Class6161.smethod_0(brush.Transform));
		pathGradientBrush.WrapMode = brush.WrapMode;
		if (brush.InterpolationColors != null)
		{
			pathGradientBrush.InterpolationColors = smethod_3(brush, inverseColorOrder: true);
		}
		return pathGradientBrush;
	}

	private static Brush smethod_2(Class5993 brush)
	{
		LinearGradientBrush linearGradientBrush = ((brush.StartPoint.IsEmpty || brush.EndPoint.IsEmpty) ? new LinearGradientBrush(brush.Rectangle, brush.StartColor.method_0(), brush.EndColor.method_0(), (float)brush.Angle, brush.IsScaled) : new LinearGradientBrush(brush.StartPoint, brush.EndPoint, brush.StartColor.method_0(), brush.EndColor.method_0()));
		linearGradientBrush.MultiplyTransform(Class6161.smethod_0(brush.Transform));
		linearGradientBrush.WrapMode = brush.WrapMode;
		if (brush.BlendFactors != null)
		{
			linearGradientBrush.Blend = smethod_4(brush);
		}
		if (brush.InterpolationColors != null)
		{
			linearGradientBrush.InterpolationColors = smethod_3(brush, inverseColorOrder: false);
		}
		return linearGradientBrush;
	}

	private static ColorBlend smethod_3(Class5992 brush, bool inverseColorOrder)
	{
		Color[] array = new Color[brush.InterpolationColors.Length];
		float[] array2 = new float[brush.InterpolationColors.Length];
		for (int i = 0; i < brush.InterpolationColors.Length; i++)
		{
			ref Color reference = ref array[i];
			reference = brush.InterpolationColors[i].Color.method_0();
			array2[i] = brush.InterpolationColors[i].Position;
		}
		ColorBlend colorBlend = new ColorBlend();
		colorBlend.Colors = array;
		colorBlend.Positions = array2;
		return colorBlend;
	}

	private static Blend smethod_4(Class5992 brush)
	{
		Blend blend = new Blend();
		blend.Factors = brush.BlendFactors;
		blend.Positions = brush.BlendPositions;
		return blend;
	}

	private static Brush smethod_5(Class5995 brush)
	{
		ImageAttributes imageAttributes = new ImageAttributes();
		smethod_6(brush, imageAttributes);
		smethod_7(brush, imageAttributes);
		Image image = Image.FromStream(new MemoryStream(brush.ImageBytes));
		RectangleF dstRect = smethod_8(brush, image);
		TextureBrush textureBrush = new TextureBrush(image, dstRect, imageAttributes);
		textureBrush.Transform = Class6161.smethod_0(brush.Transform);
		textureBrush.WrapMode = brush.WrapMode;
		return textureBrush;
	}

	private static void smethod_6(Class5995 brush, ImageAttributes imageAttrs)
	{
		if (brush.ColorMap != null)
		{
			ColorMap[] array = new ColorMap[brush.ColorMap.Length / 2];
			for (int i = 0; i < array.Length; i++)
			{
				ColorMap colorMap = new ColorMap();
				colorMap.OldColor = brush.ColorMap[i * 2].method_0();
				colorMap.NewColor = brush.ColorMap[i * 2 + 1].method_0();
				array[i] = colorMap;
			}
			imageAttrs.SetRemapTable(array);
		}
	}

	private static void smethod_7(Class5995 brush, ImageAttributes imageAttrs)
	{
		if (brush.Opacity != float.MinValue)
		{
			ColorMatrix colorMatrix = new ColorMatrix();
			colorMatrix[3, 3] = brush.Opacity;
			imageAttrs.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
		}
	}

	private static RectangleF smethod_8(Class5995 brush, Image image)
	{
		if (!(brush.ImageArea == RectangleF.Empty))
		{
			return brush.ImageArea;
		}
		return new RectangleF(0f, 0f, image.Width, image.Height);
	}

	private static Brush smethod_9(Class5996 brush)
	{
		return new HatchBrush(brush.HatchStyle, brush.ForegroundColor.method_0(), brush.BackgroundColor.method_0());
	}

	private static Brush smethod_10(Class5997 brush)
	{
		return new SolidBrush(brush.Color.method_0());
	}
}
