using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using ns224;
using ns233;
using ns234;
using ns235;
using ns315;

namespace ns318;

internal class Class7190
{
	internal class Class6203 : Class6176
	{
		private float float_0;

		public override void vmethod_0(Class6216 page)
		{
			float_0 = page.Height;
		}

		public override void vmethod_4(Class6219 glyphs)
		{
			if (glyphs.RenderTransform == null)
			{
				glyphs.Origin = new PointF(glyphs.Origin.X, float_0 - glyphs.Origin.Y);
				return;
			}
			glyphs.RenderTransform.method_9(new Class6002(1f, 0f, 0f, -1f, 0f, 0f), MatrixOrder.Prepend);
			glyphs.RenderTransform.method_9(new Class6002(1f, 0f, 0f, -1f, 0f, float_0), MatrixOrder.Append);
		}

		public override void vmethod_11(Class6220 image)
		{
			if (image.Size.Height < 0f && image.Parent is Class6213 @class)
			{
				if (@class.RenderTransform == null)
				{
					@class.RenderTransform = new Class6002();
				}
				@class.RenderTransform.method_10(new Class6002(1f, 0f, 0f, -1f, 0f, 0f));
			}
		}

		public override void vmethod_5(Class6217 path)
		{
			if (path.RenderTransform == null)
			{
				path.RenderTransform = new Class6002(1f, 0f, 0f, 1f, 0f, 0f);
			}
			path.RenderTransform.method_9(new Class6002(1f, 0f, 0f, -1f, 0f, float_0), MatrixOrder.Append);
		}

		public override void vmethod_2(Class6213 canvas)
		{
			if (canvas.RenderTransform != null && canvas.Count == 1 && canvas[0] is Class6220)
			{
				Class6220 @class = canvas[0] as Class6220;
				canvas.RenderTransform.method_9(new Class6002(1f / @class.Size.Width, 0f, 0f, -1f / @class.Size.Height, 0f, 1f), MatrixOrder.Prepend);
				canvas.RenderTransform.method_9(new Class6002(1f, 0f, 0f, -1f, 0f, float_0), MatrixOrder.Append);
			}
		}
	}

	private static CultureInfo cultureInfo_0 = new CultureInfo("en-US");

	private Interface385 interface385_0;

	private bool bool_0;

	private int int_0;

	[ThreadStatic]
	private static int int_1 = 0;

	private int int_2;

	private string string_0 = string.Empty;

	public static void smethod_0(ref Class6216 apsPage, bool normalizeAps, Interface385 callback)
	{
		if (callback == null)
		{
			throw new ArgumentException("callback can't be null");
		}
		Class7190 @class = new Class7190();
		@class.interface385_0 = callback;
		string s = @class.method_0(ref apsPage, normalizeAps);
		callback.imethod_2(Encoding.UTF8.GetBytes(s), "svg");
	}

	public static string smethod_1(ref Class6216 apsPage, bool normalizeAps)
	{
		Class7190 @class = new Class7190();
		return @class.method_0(ref apsPage, normalizeAps);
	}

	public static void smethod_2(ref Class6216 apsPage, Class7189 options)
	{
		if (options.Callback == null)
		{
			throw new ArgumentException("callback can't be null");
		}
		Class7190 @class = new Class7190();
		@class.interface385_0 = options.Callback;
		@class.bool_0 = options.AddAspectRatio;
		string s = @class.method_0(ref apsPage, options.NormalizeAps);
		options.Callback.imethod_2(Encoding.UTF8.GetBytes(s), "svg");
	}

	public static void smethod_3()
	{
		int_1 = 0;
	}

	private string method_0(ref Class6216 apsPage, bool normalizeAps)
	{
		CultureInfo cultureInfo = null;
		try
		{
			cultureInfo = Thread.CurrentThread.CurrentCulture;
			Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
			if (normalizeAps)
			{
				Class6203 visitor = new Class6203();
				apsPage.vmethod_0(visitor);
			}
			float num = apsPage.WidthPixels;
			float num2 = apsPage.HeightPixels;
			if (num < 300f)
			{
				num = 600f;
			}
			if (num2 < 300f)
			{
				num2 = 300f;
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("<?xml version=\"1.0\" standalone=\"no\"?>\n");
			stringBuilder.Append("<!DOCTYPE svg PUBLIC \"-//W3C//DTD SVG 1.0//EN\" \"http://www.w3.org/TR/2001/REC-SVG-20010904/DTD/svg10.dtd\">\n");
			stringBuilder.Append("<svg xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" id=\"body_");
			stringBuilder.Append(++int_1).Append("\"");
			if (bool_0)
			{
				stringBuilder.AppendFormat(" preserveAspectRatio=\"xMinYMin meet\" viewBox=\"0 0 {0} {1}\"", num, num2);
			}
			else
			{
				stringBuilder.AppendFormat(" width=\"{0}\"", num);
				stringBuilder.AppendFormat(" height=\"{0}\"", num2);
			}
			stringBuilder.Append(">\n");
			string value = string.Empty;
			int tagLevel = 0;
			for (int i = 0; i < apsPage.Count; i++)
			{
				if (apsPage[i] is Class6213)
				{
					Class6213 canvas = (Class6213)apsPage[i];
					value = method_2(apsPage, canvas, tagLevel);
				}
			}
			if (!string.IsNullOrEmpty(string_0))
			{
				stringBuilder.Append("\n<defs>\n");
				stringBuilder.Append(string_0);
				stringBuilder.Append("</defs>\n");
			}
			stringBuilder.Append(value);
			stringBuilder.Append("\n</svg>");
			return stringBuilder.ToString();
		}
		finally
		{
			string_0 = string.Empty;
			int_2 = 0;
			if (cultureInfo != null)
			{
				Thread.CurrentThread.CurrentCulture = cultureInfo;
			}
		}
	}

	private static string smethod_4(int tagLevel)
	{
		string text = string.Empty;
		for (int i = 0; i < tagLevel; i++)
		{
			text += "    ";
		}
		return text;
	}

	internal static Bitmap smethod_5(Bitmap image, RectangleF cropArea)
	{
		Bitmap bitmap = new Bitmap(Convert.ToInt32(cropArea.Width), Convert.ToInt32(cropArea.Height));
		Graphics graphics = Graphics.FromImage(bitmap);
		graphics.DrawImage(image, 0f - cropArea.X, 0f - cropArea.Y);
		return bitmap;
	}

	private string method_1(Class6220 apsImage, int tagLevel)
	{
		Image image = Image.FromStream(new MemoryStream(apsImage.ImageBytes));
		Bitmap bitmap = null;
		try
		{
			bitmap = ((ImageFormat.Wmf.Equals(image.RawFormat) || ImageFormat.Emf.Equals(image.RawFormat)) ? new Bitmap(image, image.Width, image.Height) : ((Bitmap)image));
			StringBuilder stringBuilder = new StringBuilder($"\n{smethod_4(tagLevel)}<image ");
			float width = apsImage.Size.Width;
			float height = apsImage.Size.Height;
			stringBuilder.Append($" x=\"{apsImage.Origin.X.ToString(cultureInfo_0)}\" y=\"{apsImage.Origin.Y.ToString(cultureInfo_0)}\"");
			byte[] array;
			if (apsImage.Crop != null && !apsImage.Crop.IsEmpty)
			{
				Class6145 crop = apsImage.Crop;
				GraphicsUnit pageUnit = GraphicsUnit.Pixel;
				RectangleF bounds = image.GetBounds(ref pageUnit);
				_ = apsImage.Bounds;
				bounds = crop.method_0(bounds);
				using Bitmap bitmap2 = smethod_5(bitmap, bounds);
				MemoryStream memoryStream = new MemoryStream();
				bitmap2.Save(memoryStream, ImageFormat.Png);
				array = memoryStream.ToArray();
			}
			else if (ImageFormat.Png.Equals(image.RawFormat))
			{
				array = apsImage.ImageBytes;
			}
			else
			{
				MemoryStream memoryStream2 = new MemoryStream();
				bitmap.Save(memoryStream2, ImageFormat.Png);
				array = memoryStream2.ToArray();
			}
			if (interface385_0 != null)
			{
				string value = interface385_0.imethod_0(array, Enum979.const_1, "svg_img" + ++int_0 + ".png");
				stringBuilder.Append(" xlink:href=").Append("\"").Append(value)
					.Append("\"");
			}
			else
			{
				stringBuilder.Append(" xlink:href=\"data:image/");
				stringBuilder.Append("png");
				stringBuilder.Append(";base64,");
				stringBuilder.Append(Convert.ToBase64String(array) + "\"");
			}
			stringBuilder.Append($" width=\"{width.ToString(cultureInfo_0)}\" height=\"{height.ToString(cultureInfo_0)}\"");
			stringBuilder.Append("/>");
			return stringBuilder.ToString();
		}
		finally
		{
			bitmap?.Dispose();
		}
	}

	private string method_2(Class6216 page, Class6213 canvas, int tagLevel)
	{
		if (canvas.Clip != null)
		{
			int_2++;
			string_0 += $"{smethod_4(tagLevel + 1)}<clipPath  id=\"{int_2}\">\n";
			string_0 += method_3(page, canvas.Clip, getGraphInfo: false, tagLevel + 2);
			string_0 += $"{smethod_4(tagLevel + 1)}</clipPath>\n";
		}
		Class7137 @class = new Class7137();
		@class.method_1().method_2(tagLevel).method_11();
		if (canvas.RenderTransform != null)
		{
			@class.method_6(canvas.RenderTransform);
		}
		if (canvas.Clip != null)
		{
			@class.Write($" clip-path=\"url(#{int_2})\" ");
		}
		@class.method_7();
		for (int i = 0; i < canvas.Count; i++)
		{
			if (canvas[i] is Class6222)
			{
				@class.Write(smethod_6(i, page, (Class6222)canvas[i], tagLevel + 1));
			}
			if (canvas[i] is Class6217)
			{
				@class.Write(method_3(page, (Class6217)canvas[i], getGraphInfo: true, tagLevel + 1));
			}
			if (canvas[i] is Class6223)
			{
				@class.Write(smethod_10(page, (Class6223)canvas[i], tagLevel + 1));
			}
			if (canvas[i] is Class6219)
			{
				@class.Write(smethod_12(page, (Class6219)canvas[i], tagLevel + 1));
			}
			if (canvas[i] is Class6213)
			{
				@class.Write(method_2(page, (Class6213)canvas[i], tagLevel + 1));
			}
			if (canvas[i] is Class6220)
			{
				@class.Write(method_1((Class6220)canvas[i], tagLevel + 1));
			}
		}
		@class.method_1().method_2(tagLevel).method_8();
		return @class.Content;
	}

	private static string smethod_6(int cmdNumber, Class6216 page, Class6222 seg, int tagLevel)
	{
		StringBuilder stringBuilder = new StringBuilder($"\n{smethod_4(tagLevel)}<path d=\"");
		stringBuilder.Append(smethod_8(cmdNumber, page, seg) + "\"");
		stringBuilder.Append(" stroke=\"black\" stroke-width=\"1\"");
		stringBuilder.Append(" />\n");
		return stringBuilder.ToString();
	}

	private static float smethod_7(Class6216 page, float yPos)
	{
		return yPos;
	}

	private static string smethod_8(int cmdNumber, Class6216 page, Class6222 seg)
	{
		Class7137 @class = new Class7137();
		@class.method_16(seg.Curve.StartPoint, seg.Curve.ControlPoint1, seg.Curve.ControlPoint2, seg.Curve.EndPoint, cmdNumber != 0);
		return @class.Content;
	}

	private string method_3(Class6216 page, Class6217 path, bool getGraphInfo, int tagLevel)
	{
		StringBuilder stringBuilder = new StringBuilder(string.Empty);
		stringBuilder.Append($"\n{smethod_4(tagLevel)}<path");
		if (path.RenderTransform != null)
		{
			stringBuilder.Append($" transform=\"matrix({path.RenderTransform.M11.ToString(cultureInfo_0)} {path.RenderTransform.M12.ToString(cultureInfo_0)} {path.RenderTransform.M21.ToString(cultureInfo_0)} {path.RenderTransform.M22.ToString(cultureInfo_0)} {path.RenderTransform.M31.ToString(cultureInfo_0)} {path.RenderTransform.M32.ToString(cultureInfo_0)})\" ");
		}
		if (path.Clip != null)
		{
			int_2++;
			stringBuilder.Append($" clip-path=\"url(#{int_2})\" ");
			string_0 += $"{smethod_4(tagLevel + 1)}<clipPath  id=\"{int_2}\">\n";
			string_0 += method_3(page, path.Clip, getGraphInfo: false, tagLevel + 2);
			string_0 += $"{smethod_4(tagLevel + 1)}</clipPath>\n";
		}
		stringBuilder.Append(" d=\"");
		for (int i = 0; i < path.Count; i++)
		{
			if (path[i] is Class6218)
			{
				Class6218 @class = (Class6218)path[i];
				Class6218 class2 = null;
				if (i > 0)
				{
					class2 = (Class6218)path[i - 1];
				}
				_ = class2?.IsClosed;
				for (int j = 0; j < @class.Count; j++)
				{
					if (@class[j] is Class6222)
					{
						stringBuilder.Append(smethod_8(j, page, (Class6222)@class[j]));
					}
					if (@class[j] is Class6223)
					{
						stringBuilder.Append(smethod_13(j, page, (Class6223)@class[j]));
					}
				}
				if (@class.IsClosed)
				{
					stringBuilder.Append("z");
				}
			}
			else
			{
				if (path[i] is Class6222)
				{
					stringBuilder.Append(smethod_8(i, page, (Class6222)path[i]));
				}
				if (path[i] is Class6223)
				{
					stringBuilder.Append(smethod_13(i, page, (Class6223)path[i]));
				}
			}
		}
		stringBuilder.Append("\"");
		if (getGraphInfo)
		{
			float num = 1f;
			float num2 = 1f;
			if (path.Pen != null && path.Pen.Brush != null && ((Class5997)path.Pen.Brush).Color != null)
			{
				stringBuilder.Append(" stroke=\"#" + Class6159.smethod_33(((Class5997)path.Pen.Brush).Color.R) + Class6159.smethod_33(((Class5997)path.Pen.Brush).Color.G) + Class6159.smethod_33(((Class5997)path.Pen.Brush).Color.B) + "\"");
				stringBuilder.Append($" stroke-width=\"{path.Pen.Width}\"");
				if (((Class5997)path.Pen.Brush).Color.A != 1)
				{
					num = (float)((Class5997)path.Pen.Brush).Color.A / 255f;
				}
				switch (path.Pen.StartCap)
				{
				case LineCap.Square:
					stringBuilder.Append(" stroke-linecap=\"square\"");
					break;
				case LineCap.Round:
					stringBuilder.Append(" stroke-linecap=\"round\"");
					break;
				}
				if (path.Pen.DashPattern.Length > 0)
				{
					stringBuilder.Append(" stroke-dasharray=\"");
					for (int k = 0; k < path.Pen.DashPattern.Length; k++)
					{
						if (k > 0)
						{
							stringBuilder.Append(",");
						}
						stringBuilder.Append(Convert.ToString(path.Pen.DashPattern[k]));
					}
					stringBuilder.Append("\"");
				}
			}
			else
			{
				stringBuilder.Append(" stroke=\"none\"");
			}
			if (path.Brush != null)
			{
				if (path.Brush is Class5997)
				{
					stringBuilder.Append($" fill=\"#{Class6159.smethod_33(((Class5997)path.Brush).Color.R)}{Class6159.smethod_33(((Class5997)path.Brush).Color.G)}{Class6159.smethod_33(((Class5997)path.Brush).Color.B)}\"");
					if (((Class5997)path.Brush).Color.A != 1)
					{
						num2 = (float)((Class5997)path.Brush).Color.A / 255f;
					}
					switch (path.FillMode)
					{
					case FillMode.Alternate:
						stringBuilder.Append(" fill-rule=\"evenodd\"");
						break;
					case FillMode.Winding:
						stringBuilder.Append(" fill-rule=\"winding\"");
						break;
					}
				}
				else if (path.Brush is Class5993)
				{
					Class5993 class3 = path.Brush as Class5993;
					string text = (string_0.Length + 1).ToString();
					string text2 = smethod_4(1) + "<linearGradient";
					if (class3.Transform != null)
					{
						text2 += $" transform=\"matrix({class3.Transform.M11.ToString(cultureInfo_0)} {class3.Transform.M12.ToString(cultureInfo_0)} {class3.Transform.M21.ToString(cultureInfo_0)} {class3.Transform.M22.ToString(cultureInfo_0)} {class3.Transform.M31.ToString(cultureInfo_0)} {class3.Transform.M32.ToString(cultureInfo_0)})\" ";
					}
					text2 += string.Format(" id=\"{0}\" x1=\"{1}\" y1=\"{2}\" x2=\"{1}{2}\" y2=\"{1}{3}\">", text, class3.Rectangle.Left.ToString(cultureInfo_0), class3.Rectangle.Bottom.ToString(cultureInfo_0), class3.Rectangle.Height.ToString(cultureInfo_0));
					text2 += $"\n{smethod_4(2)}<stop stop-color=\"{smethod_11(class3.StartColor)}\" offset=\"0%\"/>";
					text2 += $"\n{smethod_4(2)}<stop stop-color=\"{smethod_11(class3.EndColor)}\" offset=\"100%\"/>";
					text2 += $"\n{smethod_4(1)}</linearGradient>";
					string_0 = string_0 + text2 + "\n";
					stringBuilder.Append($" fill=\"url(#{text})\"");
				}
				else if (path.Brush is Class5995)
				{
					Class5995 class4 = path.Brush as Class5995;
					Class6147 class5 = Class6148.smethod_3(class4.ImageBytes);
					RectangleF rectangleF = new RectangleF(0f, 0f, class5.Width, class5.Height);
					string arg = (string_0.Length + 1).ToString();
					StringBuilder stringBuilder2 = new StringBuilder();
					stringBuilder2.Append(smethod_4(1)).Append("<pattern");
					if (class4.Transform != null)
					{
						stringBuilder2.AppendFormat(" patternTransform=\"matrix({0} {1} {2} {3} {4} {5})\" ", class4.Transform.M11.ToString(cultureInfo_0), class4.Transform.M12.ToString(cultureInfo_0), class4.Transform.M21.ToString(cultureInfo_0), class4.Transform.M22.ToString(cultureInfo_0), class4.Transform.M31.ToString(cultureInfo_0), class4.Transform.M32.ToString(cultureInfo_0));
					}
					stringBuilder2.AppendFormat(" id=\"{0}\" x=\"0\" y=\"0\" width=\"{1}\" height=\"{2}\" patternUnits=\"userSpaceOnUse\">", arg, rectangleF.Width.ToString(cultureInfo_0), rectangleF.Height.ToString(cultureInfo_0));
					stringBuilder2.AppendFormat("\n{0}<image ", smethod_4(2));
					stringBuilder2.Append(" x=\"0\" y=\"0\"");
					stringBuilder2.Append($" width=\"{rectangleF.Width.ToString(cultureInfo_0)}\" height=\"{rectangleF.Height.ToString(cultureInfo_0)}\"");
					if (interface385_0 != null)
					{
						string value = interface385_0.imethod_0(class4.ImageBytes, Enum979.const_1, "svg_img" + ++int_0 + ".png");
						stringBuilder2.Append(" xlink:href=").Append("\"").Append(value)
							.Append("\"");
					}
					else
					{
						stringBuilder2.Append(" xlink:href=\"data:image/");
						stringBuilder2.Append("png");
						stringBuilder2.Append(";base64,");
						stringBuilder2.Append(Convert.ToBase64String(class4.ImageBytes) + "\"");
					}
					stringBuilder2.Append("/>");
					stringBuilder2.AppendFormat("\n{0}</pattern>", smethod_4(1)).Append("\n");
					string_0 += stringBuilder2.ToString();
					stringBuilder.AppendFormat(" fill=\"url(#{0})\"", arg);
				}
			}
			else
			{
				stringBuilder.Append(" fill=\"none\"");
			}
			if (num == num2 && num2 != 1f)
			{
				stringBuilder.Append($" opacity=\"{num2}\"");
			}
			else
			{
				if (num != 1f)
				{
					stringBuilder.Append($" stroke-opacity=\"{num.ToString(cultureInfo_0)}\"");
				}
				if (num2 != 1f)
				{
					stringBuilder.Append($" fill-opacity=\"{num2.ToString(cultureInfo_0)}\"");
				}
			}
		}
		stringBuilder.Append(" />");
		return stringBuilder.ToString();
	}

	private static string smethod_9(Class6216 page, Class6223 seg)
	{
		StringBuilder stringBuilder = new StringBuilder(string.Empty);
		for (int i = 0; i < seg.Points.Count; i++)
		{
			PointF pointF = seg.Points[i];
			stringBuilder.Append($"{pointF.X.ToString(cultureInfo_0)},{smethod_7(page, pointF.Y).ToString(cultureInfo_0)},");
		}
		return stringBuilder.ToString();
	}

	private static string smethod_10(Class6216 page, Class6223 seg, int tagLevel)
	{
		string text = $"\n{smethod_4(tagLevel)}<polyline points=\"{smethod_9(page, seg)}";
		text += "\"";
		text += " stroke=\"black\" stroke-width=\"1\"";
		return text + " />\n";
	}

	private static string smethod_11(Class5998 drColor)
	{
		string text = "#";
		text += Class6159.smethod_33(drColor.R);
		text += Class6159.smethod_33(drColor.G);
		return text + Class6159.smethod_33(drColor.B);
	}

	private static string smethod_12(Class6216 page, Class6219 apsText, int tagLevel)
	{
		Class7137 @class = new Class7137();
		@class.method_1().method_2(tagLevel).method_12();
		if (apsText.RenderTransform != null)
		{
			@class.method_6(apsText.RenderTransform);
		}
		@class.method_5("x", apsText.Origin.X).method_5("y", smethod_7(page, apsText.Origin.Y));
		Class7136 class2 = @class.method_13();
		class2.method_2(apsText.Color);
		class2.method_6(apsText.Font.FamilyName);
		if (apsText.Font.IsItalic)
		{
			class2.method_7("italic");
		}
		if (apsText.Font.IsBold)
		{
			class2.method_8("bold");
		}
		class2.method_1().method_5("font-size", apsText.Font.SizePoints).method_7()
			.method_1()
			.method_0(apsText.Text)
			.method_1()
			.method_2(tagLevel)
			.method_8();
		return @class.Content;
	}

	private static string smethod_13(int cmdNumber, Class6216 page, Class6223 seg)
	{
		Class7137 @class = new Class7137();
		for (int i = 0; i < seg.Points.Count; i++)
		{
			PointF point = seg.Points[i];
			if (cmdNumber == 0 && i == 0)
			{
				@class.method_14(point);
			}
			else
			{
				@class.method_15(point);
			}
		}
		return @class.Content;
	}
}
