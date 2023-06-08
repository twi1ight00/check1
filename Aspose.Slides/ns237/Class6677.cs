using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns218;
using ns224;
using ns233;

namespace ns237;

internal class Class6677
{
	private readonly Class6672 class6672_0;

	private readonly Class6514 class6514_0;

	private readonly Class6683 class6683_0;

	private static readonly float[] float_0 = new float[0];

	private static readonly float[] float_1 = new float[2] { 3f, 1f };

	private static readonly float[] float_2 = new float[2] { 1f, 1f };

	private static readonly float[] float_3 = new float[4] { 3f, 1f, 1f, 1f };

	private static readonly float[] float_4 = new float[6] { 3f, 1f, 1f, 1f, 1f, 1f };

	internal Class6677(Class6672 context, Class6683 resources, Class6514 stream)
	{
		class6672_0 = context;
		class6683_0 = resources;
		class6514_0 = stream;
	}

	internal void method_0(Class6003 pen)
	{
		method_1(pen.Brush, isStroking: true);
		class6672_0.GraphicStateWriter.method_10(pen.Width, class6514_0);
		int num = smethod_1(pen);
		class6672_0.GraphicStateWriter.method_11(num, class6514_0);
		int lineJoin = smethod_2(pen);
		class6672_0.GraphicStateWriter.method_12(lineJoin, class6514_0);
		if (pen.LineJoin == LineJoin.MiterClipped)
		{
			class6672_0.GraphicStateWriter.method_13(pen.MiterLimit, class6514_0);
		}
		if (pen.DashStyle != 0)
		{
			int num2 = 0;
			if (num == 0)
			{
				num2 = smethod_3(pen);
				class6672_0.GraphicStateWriter.method_11(num2, class6514_0);
			}
			float[] dashArray = smethod_4(pen, num != 0 || num2 != 0);
			smethod_0(dashArray, pen.DashOffset, class6514_0);
		}
	}

	private static void smethod_0(float[] dashArray, float dashPhase, Class6514 stream)
	{
		stream.method_8(dashArray);
		stream.Write(" ");
		stream.Write(Class6678.smethod_2(dashPhase));
		stream.Write(" d ");
	}

	internal void method_1(Class5990 brush, bool isStroking)
	{
		if (brush.BrushType == Enum746.const_0)
		{
			method_2((Class5997)brush, isStroking);
			return;
		}
		Class6525 @class = class6683_0.method_2(brush);
		class6672_0.GraphicStateWriter.method_4(Class6670.Pattern, isStroking, class6514_0);
		class6514_0.method_6("/{0} {1}", @class.ResourceName, isStroking ? "SCN" : "scn");
	}

	private void method_2(Class5997 brush, bool isStroking)
	{
		Class5998 @class = brush.Color;
		if (class6672_0.PdfaCompliant && brush.Color.A < 255)
		{
			@class = Class5998.smethod_3(@class, new Class5998(255, 255, 255, 255));
		}
		class6672_0.GraphicStateWriter.method_5(@class, isStroking, class6514_0);
	}

	internal void method_3(byte[] imageBytes, Class6145 crop, RectangleF rect, Class6140 chromaKey, bool isReverseRows)
	{
		class6672_0.GraphicStateWriter.method_0(class6514_0);
		Class6002 matrix = ((!isReverseRows) ? new Class6002(rect.Width, 0f, 0f, rect.Height, rect.X, rect.Y) : new Class6002(rect.Width, 0f, 0f, 0f - rect.Height, rect.X, rect.Y + rect.Height));
		class6672_0.GraphicStateWriter.method_2(matrix, class6514_0);
		Class6521 @class = class6683_0.method_4(imageBytes, crop, chromaKey);
		class6514_0.method_5("/{0} Do", @class.ResourceName);
		class6672_0.GraphicStateWriter.method_1(class6514_0);
	}

	private static int smethod_1(Class6003 pen)
	{
		return pen.StartCap switch
		{
			LineCap.Square => 2, 
			LineCap.Round => 1, 
			_ => pen.EndCap switch
			{
				LineCap.Square => 2, 
				LineCap.Round => 1, 
				_ => 0, 
			}, 
		};
	}

	private static int smethod_2(Class6003 pen)
	{
		return pen.LineJoin switch
		{
			LineJoin.Bevel => 2, 
			LineJoin.Round => 1, 
			_ => 0, 
		};
	}

	private static int smethod_3(Class6003 pen)
	{
		DashCap dashCap = pen.DashCap;
		if (dashCap == DashCap.Round)
		{
			return 1;
		}
		return 0;
	}

	private static float[] smethod_4(Class6003 pen, bool isCaps)
	{
		float[] array = (float[])(pen.DashStyle switch
		{
			DashStyle.Solid => float_0, 
			DashStyle.Dash => float_1, 
			DashStyle.Dot => float_2, 
			DashStyle.DashDot => float_3, 
			DashStyle.DashDotDot => float_4, 
			DashStyle.Custom => pen.DashPattern, 
			_ => throw new InvalidOperationException("Unknown dash style."), 
		}).Clone();
		smethod_5(pen, array, isCaps);
		return array;
	}

	private static void smethod_5(Class6003 pen, float[] dashPattern, bool isCaps)
	{
		float num = Math.Max(pen.Width, 1f);
		for (int i = 0; i < dashPattern.Length; i++)
		{
			if (Class5964.smethod_4(i))
			{
				float num2 = dashPattern[i];
				if (isCaps)
				{
					num2 += 1f;
				}
				dashPattern[i] = num2 * num;
			}
			else
			{
				float num3 = dashPattern[i];
				if (isCaps)
				{
					num3 -= 1f;
				}
				dashPattern[i] = num3 * num;
			}
		}
	}
}
