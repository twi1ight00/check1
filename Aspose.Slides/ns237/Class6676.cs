using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns224;
using ns234;

namespace ns237;

internal class Class6676
{
	private bool bool_0;

	private readonly Class6672 class6672_0;

	private Class6675 class6675_0;

	private readonly Stack stack_0 = new Stack();

	internal Class6675 GraphicState => class6675_0;

	internal bool IsAlteredTransparency => bool_0;

	internal bool IsTransparencyNonDefault
	{
		get
		{
			if (!(class6675_0.StrokingAlpha < 1f))
			{
				return class6675_0.NonStrokingAlpha < 1f;
			}
			return true;
		}
	}

	internal Class6676(Class6672 context)
	{
		class6672_0 = context;
	}

	internal void ResetGraphicState()
	{
		class6675_0 = new Class6675();
	}

	internal void method_0(Class6514 stream)
	{
		stream.method_4("q");
		stack_0.Push(class6675_0.Clone());
	}

	internal void method_1(Class6514 stream)
	{
		stream.method_4("Q");
		class6675_0 = (Class6675)stack_0.Pop();
	}

	internal void method_2(Class6002 matrix, Class6514 stream)
	{
		int num = ((matrix != null) ? Class6678.smethod_3(matrix.M31, matrix.M32) : 0);
		if (num > 1)
		{
			Class6002 @class = new Class6002();
			@class.method_8(matrix.M31 / (float)num, matrix.M32 / (float)num);
			for (int i = 0; i < num; i++)
			{
				method_3(@class, stream);
			}
			Class6002 matrix2 = new Class6002(matrix.M11, matrix.M12, matrix.M21, matrix.M22, 0f, 0f);
			method_3(matrix2, stream);
		}
		else
		{
			method_3(matrix, stream);
		}
	}

	private void method_3(Class6002 matrix, Class6514 stream)
	{
		stream.method_9(matrix, "cm");
		class6675_0.TransformationMatrix.method_9(matrix, MatrixOrder.Prepend);
	}

	internal void method_4(Class6670 colorSpace, bool isStroking, Class6514 stream)
	{
		if (isStroking)
		{
			if (colorSpace == class6675_0.StrokingColorSpace)
			{
				return;
			}
			class6675_0.StrokingColorSpace = colorSpace;
		}
		else
		{
			if (colorSpace == class6675_0.NonStrokingColorSpace)
			{
				return;
			}
			class6675_0.NonStrokingColorSpace = colorSpace;
		}
		stream.method_6("/{0} {1}", colorSpace.FullName, isStroking ? "CS" : "cs");
	}

	internal void method_5(Class5998 color, bool isStroking, Class6514 stream)
	{
		if (isStroking)
		{
			if (class6675_0.StrokingColorSpace == Class6670.DeviceRgb && color == class6675_0.StrokingColor)
			{
				return;
			}
			class6675_0.StrokingColorSpace = Class6670.DeviceRgb;
			class6675_0.StrokingColor = color;
		}
		else
		{
			if (class6675_0.NonStrokingColorSpace == Class6670.DeviceRgb && color == class6675_0.NonStrokingColor)
			{
				return;
			}
			class6675_0.NonStrokingColorSpace = Class6670.DeviceRgb;
			class6675_0.NonStrokingColor = color;
		}
		if (color.A < 255)
		{
			Class6542 @class = class6672_0.Resources.method_3();
			float num = (float)color.A / 255f;
			if (isStroking)
			{
				class6675_0.StrokingAlpha = num;
			}
			else
			{
				class6675_0.NonStrokingAlpha = num;
			}
			@class.NonstrokingAlpha = class6675_0.NonStrokingAlpha;
			@class.StrokingAlpha = class6675_0.StrokingAlpha;
			smethod_0(@class, stream);
			bool_0 = true;
		}
		else if (IsTransparencyNonDefault)
		{
			Class6542 class2 = class6672_0.Resources.method_3();
			if (isStroking)
			{
				class6675_0.StrokingAlpha = 1f;
			}
			else
			{
				class6675_0.NonStrokingAlpha = 1f;
			}
			class2.NonstrokingAlpha = class6675_0.NonStrokingAlpha;
			class2.StrokingAlpha = class6675_0.StrokingAlpha;
			smethod_0(class2, stream);
		}
		stream.method_6("{0} {1}", Class6678.smethod_1(color), isStroking ? "RG" : "rg");
	}

	internal void method_6(float leading, Class6514 stream)
	{
		if (leading != class6675_0.TextLeading)
		{
			class6675_0.TextLeading = leading;
			stream.method_5("{0} TL", Class6678.smethod_2(leading));
		}
	}

	internal void method_7(Class6527 font, float fontSize, Class6514 stream)
	{
		if (font != class6675_0.TextFont || fontSize != class6675_0.TextFontSize)
		{
			class6675_0.TextFont = font;
			class6675_0.TextFontSize = fontSize;
			stream.method_6("/{0} {1} Tf", font.ResourceName, Class6678.smethod_2(fontSize));
		}
	}

	internal void method_8(int mode, Class6514 stream)
	{
		if (mode != class6675_0.TextRenderingMode)
		{
			class6675_0.TextRenderingMode = mode;
			stream.method_5("{0} Tr", Class6159.smethod_24(mode));
		}
	}

	internal void method_9(float charSpace, Class6514 stream)
	{
		if (charSpace != class6675_0.TextCharSpace)
		{
			class6675_0.TextCharSpace = charSpace;
			stream.method_5("{0} Tc", Class6678.smethod_2(charSpace));
		}
	}

	internal void method_10(float lineWidth, Class6514 stream)
	{
		if (lineWidth != class6675_0.LineWidth)
		{
			class6675_0.LineWidth = lineWidth;
			stream.method_5("{0} w", Class6678.smethod_2(lineWidth));
		}
	}

	internal void method_11(int lineCap, Class6514 stream)
	{
		if (lineCap != class6675_0.LineCap)
		{
			class6675_0.LineCap = lineCap;
			stream.method_5("{0} J", Class6159.smethod_24(lineCap));
		}
	}

	internal void method_12(int lineJoin, Class6514 stream)
	{
		if (lineJoin != class6675_0.LineJoin)
		{
			class6675_0.LineJoin = lineJoin;
			stream.method_5("{0} j", Class6159.smethod_24(lineJoin));
		}
	}

	internal void method_13(float miterLimit, Class6514 stream)
	{
		if (miterLimit != class6675_0.MiterLimit)
		{
			class6675_0.MiterLimit = miterLimit;
			stream.method_5("{0} M", Class6678.smethod_2(miterLimit));
		}
	}

	private static void smethod_0(Class6542 parameterDictionary, Class6514 stream)
	{
		stream.method_5("/{0} gs", parameterDictionary.ResourceName);
	}

	internal RectangleF method_14(RectangleF rect)
	{
		PointF[] array = new PointF[2]
		{
			new PointF(rect.Left, rect.Top),
			new PointF(rect.Right, rect.Bottom)
		};
		class6675_0.TransformationMatrix.method_3(array);
		return new RectangleF(Math.Min(array[0].X, array[1].X), Math.Min(array[0].Y, array[1].Y), Math.Abs(array[0].X - array[1].X), Math.Abs(array[0].Y - array[1].Y));
	}

	internal PointF method_15(PointF point)
	{
		PointF[] array = new PointF[1] { point };
		class6675_0.TransformationMatrix.method_3(array);
		return array[0];
	}
}
