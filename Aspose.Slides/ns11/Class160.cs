using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using Aspose.Slides;
using ns224;
using ns33;
using ns4;

namespace ns11;

internal sealed class Class160 : Class159
{
	private readonly Image image_0;

	private readonly float float_0;

	private readonly float float_1;

	private Class6002 class6002_1;

	public override float DpiX => float_0;

	public override float DpiY => float_1;

	public override int Width => (int)((double)image_0.Width * 576.0 / (double)float_0);

	public override int Height => (int)((double)image_0.Height * 576.0 / (double)float_1);

	protected override Class6002 TransformImpl
	{
		get
		{
			return class6002_1;
		}
		set
		{
			if (value != null)
			{
				class6002_1 = value.Clone();
				graphics_0.Transform = Class1170.smethod_3(value.Clone());
				graphics_0.ScaleTransform(DpiX / 576f, DpiY / 576f, MatrixOrder.Append);
			}
			else
			{
				class6002_1 = null;
				graphics_0.Transform = new Matrix(DpiX / 576f, 0f, 0f, DpiY / 576f, 0f, 0f);
			}
			vmethod_4();
		}
	}

	public Class160(Bitmap bmp, float canvasWidth, float canvasHeight)
		: base(bmp)
	{
		image_0 = bmp;
		float_0 = 576f * (float)bmp.Width / canvasWidth;
		float_1 = 576f * (float)bmp.Height / canvasHeight;
		TransformImpl = new Class6002();
	}

	public override void vmethod_5(GraphicsPath graphicsPath, Class66 lineParam, Class63 fillParam)
	{
		Brush brush = null;
		Pen pen = null;
		try
		{
			if (fillParam != null && fillParam.FillType != 0)
			{
				brush = fillParam.method_9();
				graphics_0.FillPath(brush, graphicsPath);
			}
			if (lineParam != null && lineParam.ShowLines)
			{
				pen = lineParam.method_5();
				graphics_0.DrawPath(pen, graphicsPath);
			}
		}
		finally
		{
			brush?.Dispose();
			pen?.Dispose();
		}
	}

	public override void vmethod_6(Image img, int x, int y)
	{
		graphics_0.DrawImage(img, x, y);
	}

	public override void vmethod_20(IPPImage image, RectangleF rectangle, RectangleF sourceRectangle, Class65 imageParam)
	{
		graphics_0.DrawImage(image.SystemImage, rectangle, sourceRectangle, GraphicsUnit.Pixel);
	}

	public override void vmethod_13(string text, RectangleF rect, Class151 textParam)
	{
		if (string.IsNullOrEmpty(text))
		{
			return;
		}
		Class733 @class = textParam.method_1();
		if (textParam.TextCapType != TextCapType.Small)
		{
			method_9(text, rect, textParam, @class);
			return;
		}
		Class151 class2 = (Class151)textParam.Clone();
		class2.FFontHeight *= @class.SmallCapsScaleFactor;
		Class733 class3 = class2.method_1();
		StringBuilder stringBuilder = new StringBuilder(text.Length);
		bool flag = smethod_1(text, 0);
		int num = 0;
		while (num < text.Length)
		{
			do
			{
				stringBuilder.Append(text[num++]);
			}
			while (num < text.Length && flag == smethod_1(text, num));
			string text2;
			Class151 textParam2;
			Class733 fontWrapper;
			if (flag)
			{
				text2 = stringBuilder.ToString().ToUpperInvariant();
				textParam2 = class2;
				fontWrapper = class3;
			}
			else
			{
				text2 = stringBuilder.ToString();
				textParam2 = textParam;
				fontWrapper = @class;
			}
			SizeF sizeF = method_6(text2, rect.Location, textParam2);
			method_9(text2, rect, textParam2, fontWrapper);
			if (num < text.Length)
			{
				rect.Offset(sizeF.Width, 0f);
				flag = smethod_1(text, num);
				stringBuilder.Remove(0, stringBuilder.Length);
			}
		}
	}

	private static bool smethod_1(string s, int idx)
	{
		char c = s[idx];
		if (char.IsLetter(c))
		{
			return char.IsLower(c);
		}
		return false;
	}

	private void method_9(string text, RectangleF rect, Class151 textParam, Class733 fontWrapper)
	{
		if (text.Length > 2 && text[0] == '\u202d' && text[text.Length - 1] == '\u202c')
		{
			char[] array = new char[text.Length];
			for (int i = 1; i < text.Length - 1; i++)
			{
				array[array.Length - i] = text[i];
			}
			text = new string(array);
		}
		Font font = fontWrapper.Font;
		FontStyle style = font.Style;
		FontFamily fontFamily = font.FontFamily;
		float num = textParam.FFontHeight;
		Brush brush = ((textParam.FontFill != null) ? textParam.FontFill.method_9() : Brushes.Transparent);
		Pen pen = ((textParam.FontOutline != null) ? textParam.FontOutline.method_5() : null);
		float num2 = (float)fontFamily.GetCellAscent(style) / (float)fontFamily.GetLineSpacing(style) * font.GetHeight(graphics_0);
		rect.Y -= num2 + num * (float)textParam.Escapement / 100f;
		if (textParam.Escapement != 0)
		{
			num *= 0.66f;
		}
		PointF location = rect.Location;
		GraphicsPath graphicsPath = new GraphicsPath(FillMode.Winding);
		if (text.Length > 0 && ((double)Math.Abs(textParam.Spacing) > 0.005 || !float.IsNaN(textParam.ForcedWidth)))
		{
			StringBuilder stringBuilder = new StringBuilder();
			int num3 = 0;
			int num4 = text.Length;
			if (text[0] == '\u202d')
			{
				num3++;
			}
			if (text[text.Length - 1] == '\u202c')
			{
				num4--;
			}
			do
			{
				if ((num3 == num4 || !Class1153.smethod_12(text[num3])) && stringBuilder.Length > 0)
				{
					string text2 = stringBuilder.ToString();
					stringBuilder.Remove(0, stringBuilder.Length);
					graphicsPath.AddString(text2, fontFamily, (int)style, num, location, stringFormat_0);
					location.X += method_6(text2, location, textParam).Width;
				}
				if (num3 < num4)
				{
					if (Class1153.smethod_11(text[num3]) == Class1153.Enum175.const_4)
					{
						stringBuilder.Append('\u200d');
						stringBuilder.Append(text[num3++]);
						stringBuilder.Append('\u200d');
					}
					else
					{
						stringBuilder.Append(text[num3++]);
					}
				}
			}
			while (stringBuilder.Length > 0);
		}
		else
		{
			graphicsPath.AddString(text, fontFamily, (int)style, num, location, stringFormat_0);
		}
		if (textParam.FontShadow)
		{
			PointF pointF = method_8();
			Matrix transform = graphics_0.Transform;
			graphics_0.TranslateTransform(pointF.X * num / 15f, pointF.Y * num / 15f);
			using (Brush brush2 = new SolidBrush(textParam.ShadowColor))
			{
				if (brush is SolidBrush solidBrush && solidBrush.Color.A > 0)
				{
					graphics_0.FillPath(brush2, graphicsPath);
					if (fontWrapper.NeedBoldEmulation)
					{
						using Pen pen2 = new Pen(brush2, fontWrapper.SizeInPoints * 0.02f);
						graphics_0.DrawPath(pen2, graphicsPath);
					}
				}
				if (pen != null)
				{
					using Pen pen3 = (Pen)pen.Clone();
					pen3.Brush = brush2;
					graphics_0.DrawPath(pen3, graphicsPath);
				}
			}
			graphics_0.Transform = transform;
			graphics_0.FillPath(brush, graphicsPath);
			if (fontWrapper.NeedBoldEmulation)
			{
				using Pen pen4 = new Pen(brush, fontWrapper.SizeInPoints * 0.02f);
				graphics_0.DrawPath(pen4, graphicsPath);
			}
			if (pen != null)
			{
				graphics_0.DrawPath(pen, graphicsPath);
			}
		}
		else if (textParam.FontEmbossed)
		{
			PointF pointF2 = method_8();
			Color backColor = textParam.BackColor;
			SolidBrush solidBrush2 = new SolidBrush(Color.FromArgb(backColor.A, (int)((double)(int)backColor.R * 0.6 + 0.5), (int)((double)(int)backColor.G * 0.6 + 0.5), (int)((double)(int)backColor.B * 0.6 + 0.5)));
			SolidBrush solidBrush3 = new SolidBrush(Color.FromArgb(backColor.A, 255 - (int)((double)(255 - backColor.R) * 0.6 + 0.5), 255 - (int)((double)(255 - backColor.G) * 0.6 + 0.5), 255 - (int)((double)(255 - backColor.B) * 0.6 + 0.5)));
			Matrix transform2 = graphics_0.Transform;
			graphics_0.TranslateTransform((0f - pointF2.X) * num / 60f, (0f - pointF2.Y) * num / 60f);
			graphics_0.FillPath(solidBrush3, graphicsPath);
			if (fontWrapper.NeedBoldEmulation)
			{
				using Pen pen5 = new Pen(solidBrush3, fontWrapper.SizeInPoints * 0.02f);
				graphics_0.DrawPath(pen5, graphicsPath);
			}
			graphics_0.Transform = transform2;
			graphics_0.TranslateTransform(pointF2.X * num / 60f, pointF2.Y * num / 60f);
			graphics_0.FillPath(solidBrush2, graphicsPath);
			if (fontWrapper.NeedBoldEmulation)
			{
				using Pen pen6 = new Pen(solidBrush2, fontWrapper.SizeInPoints * 0.02f);
				graphics_0.DrawPath(pen6, graphicsPath);
			}
			graphics_0.Transform = transform2;
			graphics_0.FillPath(brush, graphicsPath);
			if (fontWrapper.NeedBoldEmulation)
			{
				using Pen pen7 = new Pen(brush, fontWrapper.SizeInPoints * 0.02f);
				graphics_0.DrawPath(pen7, graphicsPath);
			}
			solidBrush2.Dispose();
			solidBrush3.Dispose();
		}
		else
		{
			graphics_0.FillPath(brush, graphicsPath);
			if (fontWrapper.NeedBoldEmulation)
			{
				using Pen pen8 = new Pen(brush, fontWrapper.SizeInPoints * 0.02f);
				graphics_0.DrawPath(pen8, graphicsPath);
			}
			if (pen != null)
			{
				graphics_0.DrawPath(pen, graphicsPath);
			}
		}
		if (textParam.TextStrikethrough != 0)
		{
			if (textParam.FontShadow)
			{
				method_7(rect, num2, textParam, isItShadow: true);
			}
			method_7(rect, num2, textParam, isItShadow: false);
		}
		graphicsPath.Dispose();
		brush.Dispose();
		pen?.Dispose();
	}
}
