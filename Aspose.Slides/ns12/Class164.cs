using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using Aspose.Slides;
using ns11;
using ns218;
using ns224;
using ns233;
using ns235;
using ns33;
using ns4;

namespace ns12;

internal class Class164 : Class159
{
	private const int int_0 = 2097152;

	private readonly float float_0;

	private readonly float float_1;

	private SizeF sizeF_0;

	private Class5990 class5990_0;

	private Class6003 class6003_0;

	private Class6002 class6002_1;

	private readonly Class6213 class6213_0 = new Class6213();

	private IHyperlink ihyperlink_0;

	private IHyperlink ihyperlink_1;

	private bool bool_2;

	private readonly bool bool_3;

	private RectangleF rectangleF_0;

	private readonly Class54 class54_0;

	private readonly bool bool_4;

	public override float DpiX => float_0;

	public override float DpiY => float_1;

	public override int Width => (int)sizeF_0.Width;

	public override int Height => (int)sizeF_0.Height;

	protected override Class6002 TransformImpl
	{
		get
		{
			return class6002_1;
		}
		set
		{
			class6002_1 = value.Clone();
			vmethod_4();
		}
	}

	internal Class6213 Canvas => class6213_0;

	internal bool SaveMetafileAsPng => bool_3;

	internal Class164(int canvasWidth, int canvasHeight, float horizontalResolution, float verticalResolution, bool saveMetafileAsPng, bool isPdfIntent, Class54 fontsManager)
		: base(null)
	{
		if (fontsManager == null)
		{
			throw new ArgumentNullException("fontsManager");
		}
		bool_4 = isPdfIntent;
		class54_0 = fontsManager;
		float_0 = horizontalResolution;
		float_1 = verticalResolution;
		bool_3 = saveMetafileAsPng;
		SizeF size = new SizeF((float)Class5955.smethod_10(canvasWidth, 72.0), (float)Class5955.smethod_10(canvasHeight, 72.0));
		sizeF_0 = new SizeF(canvasWidth, canvasHeight);
		class6002_1 = new Class6002();
		rectangleF_0 = new RectangleF(0f, 0f, 0f, 0f);
		method_10(size);
	}

	public override void vmethod_5(GraphicsPath graphicsPath, Class66 lineParam, Class63 fillParam)
	{
		bool isStroke = false;
		bool isFill = false;
		rectangleF_0 = graphicsPath.GetBounds();
		FillMode fillMode = FillMode.Alternate;
		if (fillParam != null && fillParam.FillType != 0)
		{
			class5990_0 = fillParam.method_5();
			class5990_0 = smethod_2(class5990_0, fillParam);
			isFill = true;
		}
		if (lineParam != null && lineParam.ShowLines)
		{
			if (lineParam.EndArrowheadStyle == LineArrowheadStyle.None && lineParam.BeginArrowheadStyle == LineArrowheadStyle.None)
			{
				class6003_0 = lineParam.method_3();
				isStroke = true;
			}
			else
			{
				Pen pen = lineParam.method_5();
				graphicsPath.Widen(pen);
				if (fillParam == null)
				{
					class5990_0 = new Class5997(Class5998.smethod_0(lineParam.ForeColor));
					isFill = true;
					class6003_0 = null;
					fillMode = FillMode.Winding;
				}
			}
		}
		PointF[] pathPoints = graphicsPath.PathPoints;
		PathPointType[] array = new PathPointType[graphicsPath.PathTypes.Length];
		for (int i = 0; i < graphicsPath.PathTypes.Length; i++)
		{
			array[i] = (PathPointType)graphicsPath.PathTypes[i];
		}
		List<Class167> list = new List<Class167>();
		Class167 @class = null;
		for (int j = 0; j < array.Length; j++)
		{
			if (array[j] == PathPointType.Start)
			{
				@class = new Class167();
				list.Add(@class);
			}
			if (@class != null)
			{
				if ((array[j] & PathPointType.CloseSubpath) == PathPointType.CloseSubpath)
				{
					@class.Closed = true;
				}
				@class.Add(pathPoints[j], array[j]);
			}
		}
		Class6217 path = new Class6217();
		foreach (Class167 item in list)
		{
			Class168.smethod_0(ref path, item.method_1(), item.method_0(), item.Closed);
		}
		method_12(path, isStroke, isFill, fillMode);
	}

	public override void vmethod_6(Image img, int x, int y)
	{
		SizeF size = new SizeF(img.Width, img.Height);
		Class6213 @class = new Class6213();
		byte[] imageBytes;
		using (MemoryStream memoryStream = new MemoryStream())
		{
			img.Save(memoryStream, ImageFormat.Png);
			imageBytes = memoryStream.ToArray();
		}
		Class6220 node = new Class6220(new PointF(x, y), size, imageBytes, new Class6145(0.0, 0.0, 0.0, 0.0));
		@class.Add(node);
		@class.RenderTransform = TransformImpl.Clone();
		class6213_0.Add(@class);
	}

	public override void vmethod_8(Rectangle rectangle, Class66 lineParam, Class63 fillParam)
	{
		RectangleF rectangle2 = new RectangleF(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
		vmethod_7(rectangle2, lineParam, fillParam);
	}

	public override void vmethod_7(RectangleF rectangle, Class66 lineParam, Class63 fillParam)
	{
		rectangleF_0 = rectangle;
		bool isStroke = false;
		bool isFill = false;
		if (fillParam != null && fillParam.FillType != 0)
		{
			class5990_0 = fillParam.method_5();
			class5990_0 = smethod_2(class5990_0, fillParam);
			isFill = true;
		}
		if (lineParam != null && lineParam.ShowLines)
		{
			class6003_0 = lineParam.method_3();
			isStroke = true;
		}
		Class6217 path = Class6217.smethod_1(rectangle);
		method_11(path, isStroke, isFill);
	}

	public override void vmethod_10(Rectangle rectangle, Class66 lineParam, Class63 fillParam)
	{
		RectangleF rectangle2 = new RectangleF(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
		vmethod_9(rectangle2, lineParam, fillParam);
	}

	public override void vmethod_9(RectangleF rectangle, Class66 lineParam, Class63 fillParam)
	{
		rectangleF_0 = rectangle;
		bool isStroke = false;
		bool isFill = false;
		if (fillParam != null && fillParam.FillType != 0)
		{
			class5990_0 = fillParam.method_5();
			class5990_0 = smethod_2(class5990_0, fillParam);
			isFill = true;
		}
		if (lineParam != null && lineParam.ShowLines)
		{
			class6003_0 = lineParam.method_3();
			isStroke = true;
		}
		Class6217 path = Class6217.smethod_1(rectangle);
		method_11(path, isStroke, isFill);
	}

	public override void vmethod_20(IPPImage image, RectangleF rectangle, RectangleF sourceRectangle, Class65 imageParam)
	{
		vmethod_21(image, rectangle, imageParam);
	}

	public override void vmethod_21(IPPImage image, RectangleF rectangle, Class65 imageParam)
	{
		SizeF imageSize = new SizeF(rectangle.Width, rectangle.Height);
		Class6213 @class = new Class6213();
		byte[] imageBytes = method_14(image, imageSize);
		Class6145 crop = ((imageParam == null) ? new Class6145(0.0, 0.0, 0.0, 0.0) : imageParam.Crop);
		Class6220 node = new Class6220(rectangle.Location, rectangle.Size, imageBytes, crop);
		@class.Add(node);
		@class.RenderTransform = TransformImpl.Clone();
		class6213_0.Add(@class);
	}

	private Class6219 method_9(Class5999 drFont, Class63 fillParam, Color outlineColor, Color fontColor, PointF origin, string text, float charSpacing)
	{
		if (text.Length > 1 && text[0] == '\u202d' && text[text.Length - 1] == '\u202c')
		{
			text = text.Substring(1, text.Length - 2);
		}
		Class6219 class2;
		using (Class5971 @class = new Class5971())
		{
			Font font = class54_0.method_3(drFont.FamilyName, drFont.SizePoints, drFont.Style);
			SizeF size = default(SizeF);
			lock (Class1164.Lock)
			{
				for (int i = 0; i < 3; i++)
				{
					try
					{
						size = @class.method_0(text, font);
					}
					catch
					{
						if (i == 2)
						{
							throw;
						}
						continue;
					}
					break;
				}
			}
			Class5998 color = new Class5998(fontColor.ToArgb());
			Class5998 outlineColor2 = ((outlineColor != Color.Empty) ? new Class5998(outlineColor.ToArgb()) : Class5998.class5998_141);
			class2 = new Class6219(drFont, color, outlineColor2, origin, text, size, charSpacing);
		}
		class2.RenderTransform = TransformImpl.Clone();
		class2.Origin = origin;
		if (ihyperlink_0 != null)
		{
			PointF location = new PointF(class2.Origin.X, class2.Origin.Y - class2.Font.AscentPoints);
			rectangleF_0 = new RectangleF(location, class2.Size);
			class2.Hyperlink = method_13(ihyperlink_0);
		}
		return class2;
	}

	public override void vmethod_13(string text, RectangleF rect, Class151 textParam)
	{
		for (int i = 0; i < text.Length; i++)
		{
			if (text[i] != '\u200d' && text[i] != '\u202d' && text[i] != '\u202e' && text[i] != '\u202c')
			{
				continue;
			}
			StringBuilder stringBuilder = new StringBuilder();
			for (int j = 0; j < text.Length; j++)
			{
				if (text[j] != '\u200d' && text[j] != '\u202d' && text[j] != '\u202e' && text[j] != '\u202c')
				{
					stringBuilder.Append(text[j]);
				}
			}
			text = stringBuilder.ToString();
			break;
		}
		Class733 @class = textParam.method_1();
		Color fontColor = Color.Empty;
		if (textParam.FontFill != null && textParam.FontFill.FillType != 0)
		{
			Brush brush = textParam.FontFill.method_9();
			if (brush is SolidBrush solidBrush)
			{
				fontColor = solidBrush.Color;
			}
			else if (brush is LinearGradientBrush linearGradientBrush)
			{
				int num = 0;
				int num2 = 0;
				int num3 = 0;
				int num4 = 0;
				if (linearGradientBrush.InterpolationColors == null)
				{
					for (int k = 0; k < linearGradientBrush.LinearColors.Length; k++)
					{
						num += linearGradientBrush.LinearColors[k].A;
						num2 += linearGradientBrush.LinearColors[k].R;
						num3 += linearGradientBrush.LinearColors[k].R;
						num4 += linearGradientBrush.LinearColors[k].B;
					}
					if (linearGradientBrush.LinearColors.Length > 0)
					{
						num /= linearGradientBrush.LinearColors.Length;
						num2 /= linearGradientBrush.LinearColors.Length;
						num3 /= linearGradientBrush.LinearColors.Length;
						num4 /= linearGradientBrush.LinearColors.Length;
					}
					fontColor = Color.FromArgb(num, num2, num3, num4);
				}
				else
				{
					for (int l = 0; l < linearGradientBrush.InterpolationColors.Colors.Length; l++)
					{
						num += linearGradientBrush.InterpolationColors.Colors[l].A;
						num2 += linearGradientBrush.InterpolationColors.Colors[l].R;
						num3 += linearGradientBrush.InterpolationColors.Colors[l].R;
						num4 += linearGradientBrush.InterpolationColors.Colors[l].B;
					}
					if (linearGradientBrush.InterpolationColors.Colors.Length > 0)
					{
						num /= linearGradientBrush.InterpolationColors.Colors.Length;
						num2 /= linearGradientBrush.InterpolationColors.Colors.Length;
						num3 /= linearGradientBrush.InterpolationColors.Colors.Length;
						num4 /= linearGradientBrush.InterpolationColors.Colors.Length;
					}
					fontColor = Color.FromArgb(num, num2, num3, num4);
				}
			}
		}
		else
		{
			Console.WriteLine("\tnone");
		}
		float num5 = (float)textParam.Escapement / 100f;
		PointF location = rect.Location;
		location.Y -= (float)textParam.FontHeight * num5;
		Class5999 drFont = class54_0.method_2(@class.FontFamily, @class.EmSize * 1.3333334f, @class.Style, textParam);
		if (textParam.FontShadow)
		{
			PointF pointF = method_8();
			Color shadowColor = textParam.ShadowColor;
			float height = @class.Font.GetHeight(graphics_0);
			PointF origin = new PointF(location.X + pointF.X * height / 20f, location.Y + pointF.Y * height / 20f);
			Color outlineColor = Color.Empty;
			if (textParam.FontOutline != null && textParam.FontOutline.class63_0.FillType == FillType.Solid)
			{
				outlineColor = textParam.ShadowColor;
			}
			class6213_0.Add(method_9(drFont, textParam.FontFill, outlineColor, shadowColor, origin, text, textParam.Spacing));
		}
		Color outlineColor2 = Color.Empty;
		if (textParam.FontOutline != null && textParam.FontOutline.class63_0.FillType == FillType.Solid)
		{
			outlineColor2 = textParam.FontOutline.ForeColor;
		}
		class6213_0.Add(method_9(drFont, textParam.FontFill, outlineColor2, fontColor, location, text, textParam.Spacing));
		if (textParam.TextStrikethrough != 0)
		{
			FontStyle style = @class.Style;
			float num6 = (float)@class.Font.FontFamily.GetCellAscent(style) / (float)@class.Font.FontFamily.GetLineSpacing(style) * @class.Font.GetHeight(graphics_0);
			float y = rect.Y - num6 + textParam.FFontHeight * (float)textParam.Escapement / 100f;
			RectangleF rect2 = new RectangleF(location.X, y, rect.Width, rect.Height);
			if (textParam.FontShadow)
			{
				method_7(rect2, num6, textParam, isItShadow: true);
			}
			method_7(rect2, num6, textParam, isItShadow: false);
		}
	}

	public override void vmethod_14(IHyperlink link)
	{
		ihyperlink_0 = link;
	}

	public override void vmethod_15()
	{
		ihyperlink_0 = null;
	}

	public override void vmethod_16(IHyperlink link)
	{
		ihyperlink_1 = link;
		bool_2 = false;
	}

	public override void vmethod_17()
	{
		ihyperlink_1 = null;
		bool_2 = false;
	}

	protected override void vmethod_4()
	{
	}

	private void method_10(SizeF size)
	{
		float m = size.Width / sizeF_0.Width;
		float m2 = size.Height / sizeF_0.Height;
		class6213_0.RenderTransform = new Class6002(m, 0f, 0f, m2, 0f, 0f);
	}

	private void method_11(Class6217 path, bool isStroke, bool isFill)
	{
		method_12(path, isStroke, isFill, FillMode.Alternate);
	}

	private void method_12(Class6217 path, bool isStroke, bool isFill, FillMode fillMode)
	{
		if (!isFill && !isStroke)
		{
			if (ihyperlink_1 == null)
			{
				return;
			}
			path.Clear();
		}
		else
		{
			path.Pen = (isStroke ? class6003_0 : null);
			path.Brush = (isFill ? class5990_0 : null);
			path.FillMode = fillMode;
			path.RenderTransform = TransformImpl.Clone();
		}
		if (ihyperlink_1 != null && !bool_2)
		{
			path.Hyperlink = method_13(ihyperlink_1);
			bool_2 = true;
		}
		class6213_0.Add(path);
	}

	private Class6270 method_13(IHyperlink link)
	{
		Hyperlink hyperlink = (Hyperlink)link;
		Class6270 result = null;
		switch (hyperlink.ActionType)
		{
		case HyperlinkActionType.JumpFirstSlide:
			result = new Class6270(rectangleF_0, Enum803.const_3);
			break;
		case HyperlinkActionType.JumpPreviousSlide:
			result = new Class6270(rectangleF_0, Enum803.const_2);
			break;
		case HyperlinkActionType.JumpNextSlide:
			result = new Class6270(rectangleF_0, Enum803.const_1);
			break;
		case HyperlinkActionType.JumpLastSlide:
			result = new Class6270(rectangleF_0, Enum803.const_4);
			break;
		case HyperlinkActionType.JumpLastViewedSlide:
			result = new Class6270(rectangleF_0, Enum803.const_5);
			break;
		case HyperlinkActionType.JumpSpecificSlide:
		{
			ISlide targetSlide = hyperlink.TargetSlide;
			if (targetSlide != null)
			{
				result = new Class6270(rectangleF_0, targetSlide.SlideNumber - 1);
			}
			break;
		}
		case HyperlinkActionType.Hyperlink:
		case HyperlinkActionType.OpenFile:
		case HyperlinkActionType.OpenPresentation:
			result = new Class6270(rectangleF_0, bool_4 ? smethod_1(hyperlink.ExternalUrl) : hyperlink.ExternalUrl);
			break;
		}
		return result;
	}

	private static string smethod_1(string uri)
	{
		try
		{
			Uri uri2 = new Uri(uri);
			if (!string.IsNullOrEmpty(uri2.Scheme) && !uri2.Scheme.Equals(Uri.UriSchemeFile))
			{
				return uri;
			}
			if (uri2.IsUnc)
			{
				return "//" + uri2.Host + Uri.UnescapeDataString(uri2.AbsolutePath);
			}
			if (uri2.IsAbsoluteUri)
			{
				return Uri.UnescapeDataString(uri2.AbsolutePath);
			}
			return Uri.UnescapeDataString(uri);
		}
		catch (UriFormatException)
		{
			return Uri.UnescapeDataString(uri);
		}
		catch (Exception ex2)
		{
			Class1165.smethod_28(ex2);
			return uri;
		}
	}

	private static Class5990 smethod_2(Class5990 brush, Class63 fillParam)
	{
		if (brush != null && brush is Class5994)
		{
			SizeF sizeF = new SizeF(fillParam.Rectangle.Width, fillParam.Rectangle.Height);
			Bitmap bitmap = new Bitmap((int)sizeF.Width, (int)sizeF.Height);
			bitmap.SetResolution(96f, 96f);
			Graphics graphics = Graphics.FromImage(bitmap);
			Matrix transform = graphics.Transform;
			transform.Translate(0f - fillParam.Rectangle.Left, 0f - fillParam.Rectangle.Top);
			graphics.Transform = transform;
			graphics.FillRectangle(fillParam.method_9(), fillParam.Rectangle);
			Class5995 class2;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				bitmap.Save(memoryStream, ImageFormat.Png);
				class2 = new Class5995(memoryStream.ToArray());
			}
			Class6002 class3 = new Class6002();
			class3.method_8(fillParam.Rectangle.Left, fillParam.Rectangle.Top);
			class2.Transform = class3;
			graphics.Dispose();
			bitmap.Dispose();
			return class2;
		}
		return brush;
	}

	private static byte[] smethod_3(byte[] imageBytes, SizeF imageSize)
	{
		return Class1159.smethod_3(imageBytes, imageSize, isReturnIncreasedImage: true);
	}

	private static SizeF smethod_4(SizeF imageSize)
	{
		float num = imageSize.Width * imageSize.Height;
		if (num > 2097152f)
		{
			float num2 = (float)Math.Sqrt(num / 2097152f);
			imageSize.Width /= num2;
			imageSize.Height /= num2;
		}
		return imageSize;
	}

	private static byte[] smethod_5(byte[] imageBytes, Color transparentColor)
	{
		if (transparentColor != Color.Empty)
		{
			MemoryStream stream = new MemoryStream(imageBytes);
			Bitmap bitmap = new Bitmap(stream);
			bitmap.MakeTransparent(transparentColor);
			if (bitmap.RawFormat.Guid.Equals(ImageFormat.Jpeg.Guid) || bitmap.RawFormat.Guid.Equals(ImageFormat.Exif.Guid) || bitmap.RawFormat.Guid.Equals(ImageFormat.MemoryBmp.Guid))
			{
				Class1170.smethod_8(bitmap, transparentColor, 99);
			}
			MemoryStream memoryStream = new MemoryStream();
			bitmap.Save(memoryStream, ImageFormat.Png);
			memoryStream.Position = 0L;
			bitmap.Dispose();
			byte[] array = new byte[memoryStream.Length];
			memoryStream.Read(array, 0, array.Length);
			memoryStream.SetLength(0L);
			return array;
		}
		return imageBytes;
	}

	private byte[] method_14(IPPImage image, SizeF imageSize)
	{
		byte[] imageBytes = ((PPImage)image).data;
		if ((image.ContentType == "image/x-emf" || image.ContentType == "image/x-wmf") && bool_3)
		{
			imageBytes = smethod_3(imageBytes, imageSize);
		}
		return smethod_5(imageBytes, Color.Empty);
	}
}
