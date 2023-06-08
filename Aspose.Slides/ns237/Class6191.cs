using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using ns218;
using ns224;
using ns233;
using ns234;
using ns235;
using ns236;

namespace ns237;

internal class Class6191 : Class6190
{
	private Class6220 class6220_0;

	private Class6217 class6217_0;

	private bool bool_0;

	internal bool bool_1;

	public override void vmethod_12(Class6211 bookmark)
	{
		if (!bool_0)
		{
			base.vmethod_12(bookmark);
		}
	}

	public override void vmethod_3(Class6213 canvas)
	{
		if (!bool_0)
		{
			base.vmethod_3(canvas);
		}
	}

	public override void vmethod_2(Class6213 canvas)
	{
		if (!bool_0)
		{
			base.vmethod_2(canvas);
		}
	}

	public override void vmethod_16(Class6209 field)
	{
		if (!bool_0)
		{
			base.vmethod_16(field);
		}
	}

	public override void vmethod_15(Class6207 field)
	{
		if (!bool_0)
		{
			base.vmethod_15(field);
		}
	}

	public override void vmethod_14(Class6210 field)
	{
		if (!bool_0)
		{
			base.vmethod_14(field);
		}
	}

	public override void vmethod_4(Class6219 glyphs)
	{
		if (!bool_0)
		{
			base.vmethod_4(glyphs);
		}
	}

	public override void vmethod_13(Class6221 outlineItem)
	{
		if (!bool_0)
		{
			base.vmethod_13(outlineItem);
		}
	}

	public override void vmethod_1(Class6216 page)
	{
		if (!bool_0)
		{
			base.vmethod_1(page);
		}
	}

	public override void vmethod_0(Class6216 page)
	{
		if (!bool_0)
		{
			base.vmethod_0(page);
		}
	}

	public override void vmethod_6(Class6217 path)
	{
		if (!bool_0 || bool_1)
		{
			bool_1 = false;
			base.vmethod_6(path);
		}
	}

	public override void vmethod_8(Class6218 pathFigure)
	{
		if (!bool_0)
		{
			base.vmethod_8(pathFigure);
		}
	}

	public override void vmethod_7(Class6218 pathFigure)
	{
		if (!bool_0)
		{
			base.vmethod_7(pathFigure);
		}
	}

	public override void vmethod_5(Class6217 path)
	{
		if (!bool_0)
		{
			if (path == class6217_0)
			{
				bool_0 = true;
			}
			bool_1 = true;
			base.vmethod_5(path);
		}
	}

	public override void vmethod_9(Class6223 segment)
	{
		if (!bool_0)
		{
			base.vmethod_9(segment);
		}
	}

	public override void vmethod_10(Class6222 segment)
	{
		if (!bool_0)
		{
			base.vmethod_10(segment);
		}
	}

	public override void vmethod_11(Class6220 imageNode)
	{
		if (!bool_0)
		{
			base.vmethod_11(imageNode);
			if (imageNode == class6220_0)
			{
				bool_0 = true;
			}
		}
	}

	public void method_6(Class6217 path)
	{
		if (path != null && path.Brush != null && smethod_3(path.Brush))
		{
			if (path.Brush.BrushType == Enum746.const_0)
			{
				method_8(path);
			}
			else if (path.Brush.BrushType == Enum746.const_2)
			{
				method_7(path);
			}
		}
	}

	private static bool smethod_3(Class5990 brush)
	{
		switch (brush.BrushType)
		{
		case Enum746.const_0:
			if (((Class5997)brush).Color.A == 255)
			{
				return false;
			}
			return true;
		default:
			return false;
		case Enum746.const_2:
		{
			using Class6150 @class = new Class6150(((Class5995)brush).ImageBytes);
			if (!Image.IsAlphaPixelFormat(@class.method_2().PixelFormat))
			{
				return false;
			}
			return @class.method_15(isConvertTo1Bpp: false, isAllowTransparencyToColorHack: false).HasTransparentPixels;
		}
		}
	}

	private void method_7(Class6217 path)
	{
		Class5995 @class = (Class5995)path.Brush;
		using Class6150 class2 = new Class6150(@class);
		if (!Image.IsAlphaPixelFormat(class2.method_2().PixelFormat) || !class2.method_15(isConvertTo1Bpp: false, isAllowTransparencyToColorHack: false).HasTransparentPixels)
		{
			return;
		}
		class6217_0 = path;
		Class6204 class3 = path;
		while (class3.Parent != null)
		{
			class3 = class3.Parent;
		}
		Class6216 class4 = class3 as Class6216;
		using Bitmap image = new Bitmap(class4.WidthPixels, class4.HeightPixels);
		using Graphics graphics = Graphics.FromImage(image);
		method_0(class4, graphics);
		graphics.ResetTransform();
		graphics.PageUnit = GraphicsUnit.Point;
		graphics.PageScale = 1f;
		Class6002 transform = @class.Transform;
		Class6002 renderTransform = path.RenderTransform;
		Matrix matrix = Class6161.smethod_0(renderTransform);
		Matrix matrix2 = Class6161.smethod_0(transform);
		matrix.Invert();
		matrix2.Invert();
		float num = 0.75f;
		Class6188 class5 = new Class6188();
		path.vmethod_0(class5);
		GraphicsPath graphicsPath = class5.GraphicsPath;
		graphicsPath.Transform(matrix2);
		graphicsPath.Transform(new Matrix(num, 0f, 0f, num, 0f, 0f));
		TextureBrush textureBrush = (TextureBrush)Class6151.smethod_0(path.Brush);
		textureBrush.MultiplyTransform(matrix2);
		textureBrush.ScaleTransform(num, num);
		float num2 = 0f;
		float num3 = 0f;
		float num4 = 0f;
		float num5 = 0f;
		if (graphicsPath.PointCount > 0)
		{
			num2 = graphicsPath.PathPoints[0].X;
			num3 = graphicsPath.PathPoints[0].Y;
			num4 = num2;
			num5 = num3;
		}
		for (int i = 0; i < graphicsPath.PointCount; i++)
		{
			PointF pointF = graphicsPath.PathPoints[i];
			if (num2 > pointF.X)
			{
				num2 = pointF.X;
			}
			if (num3 > pointF.Y)
			{
				num3 = pointF.Y;
			}
			if (num4 < pointF.X)
			{
				num4 = pointF.X;
			}
			if (num5 < pointF.Y)
			{
				num5 = pointF.Y;
			}
		}
		num2 = num2 * 4f / 3f;
		num4 = num4 * 4f / 3f;
		num3 = num3 * 4f / 3f;
		num5 = num5 * 4f / 3f;
		float num6 = Math.Abs(matrix2.Elements[0] * matrix.Elements[0] * 0.75f);
		float num7 = Math.Abs(matrix2.Elements[3] * matrix.Elements[3] * 0.75f);
		num6 = ((num6 == 0f) ? 1f : ((!(num6 < 1f)) ? 1f : (1f / num6)));
		num7 = ((num7 == 0f) ? 1f : ((!(num7 < 1f)) ? 1f : (1f / num7)));
		int width = (int)((num4 - num2) * num6);
		int height = (int)((num5 - num3) * num7 * 1f);
		using Class6150 class6 = new Class6150(width, height);
		using Graphics graphics2 = Graphics.FromImage(class6.method_2());
		graphics2.PageUnit = GraphicsUnit.Point;
		graphics2.PageScale = 1f;
		graphics2.TranslateTransform(-1f, 0f);
		graphics2.MultiplyTransform(matrix2);
		graphics2.MultiplyTransform(matrix);
		graphics2.ScaleTransform(0.75f, 0.75f, MatrixOrder.Append);
		graphics2.ScaleTransform(num6, num7, MatrixOrder.Append);
		graphics2.DrawImage(image, 0, 0);
		graphics2.ResetTransform();
		graphicsPath.Transform(new Matrix(num6, 0f, 0f, num7, 0f, 0f));
		textureBrush.ScaleTransform(num6, num7, MatrixOrder.Append);
		graphics2.FillPath(textureBrush, graphicsPath);
		using MemoryStream memoryStream = new MemoryStream();
		class6.Save(memoryStream, class2.ImageType);
		Class5995 class7 = new Class5995(Class5964.smethod_11(memoryStream));
		class7.Opacity = @class.Opacity;
		@class.Transform.method_5(1f / num6, 1f / num7, MatrixOrder.Prepend);
		class7.Transform = @class.Transform;
		class7.WrapMode = @class.WrapMode;
		path.Brush = class7;
	}

	private void method_8(Class6217 path)
	{
		Class6185 @class = new Class6185();
		RectangleF rectangleF = @class.method_2(path);
		Class6204 class2 = path;
		while (class2.Parent != null)
		{
			class2 = class2.Parent;
		}
		Class6216 class3 = class2 as Class6216;
		using Bitmap bitmap = new Bitmap(class3.WidthPixels, class3.HeightPixels);
		using Graphics graphics = Graphics.FromImage(bitmap);
		graphics.FillRectangle(Brushes.White, new Rectangle(Point.Empty, bitmap.Size));
		class6217_0 = path;
		method_0(class3, graphics);
		bool_0 = false;
		class6217_0 = null;
		method_0(path, graphics);
		Matrix matrix = new Matrix();
		matrix.Scale(1.3333334f, 1.3333334f);
		PointF[] array = new PointF[1] { rectangleF.Size.ToPointF() };
		matrix.TransformPoints(array);
		int num = (int)Math.Ceiling(array[0].X);
		int num2 = (int)Math.Ceiling(array[0].Y);
		float num3 = (array[0].X - (float)num) / array[0].X;
		float num4 = (array[0].Y - (float)num2) / array[0].Y;
		using Bitmap image = new Bitmap(num, num2);
		using Graphics graphics2 = Graphics.FromImage(image);
		using MemoryStream memoryStream = new MemoryStream();
		Matrix transform = graphics2.Transform;
		array = new PointF[1] { rectangleF.Location };
		matrix.TransformPoints(array);
		transform.Translate(0f - array[0].X, 0f - array[0].Y);
		graphics2.Transform = transform;
		graphics2.DrawImage(bitmap, 0, 0);
		Class6146.smethod_0(image, memoryStream, 100);
		Class5995 class4 = new Class5995(memoryStream.ToArray());
		class4.Transform.method_8(rectangleF.X, rectangleF.Y);
		matrix = new Matrix();
		matrix.Scale(0.75f + 0.75f * num3, 0.75f + 0.75f * num4);
		class4.Transform.method_10(Class6161.smethod_1(matrix));
		path.Brush = class4;
	}

	public Class6220 method_9(Class6220 image)
	{
		class6220_0 = image;
		Class6204 @class = image;
		while (@class.Parent != null)
		{
			@class = @class.Parent;
		}
		Class6216 class2 = @class as Class6216;
		RectangleF rectangleF;
		using (MemoryStream stream = new MemoryStream(image.ImageBytes))
		{
			using Image image2 = Image.FromStream(stream);
			rectangleF = new RectangleF(0f, 0f, image2.Size.Width, image2.Size.Height);
		}
		RectangleF bounds = image.Bounds;
		using Bitmap image3 = new Bitmap(class2.WidthPixels, class2.HeightPixels);
		using Graphics graphics = Graphics.FromImage(image3);
		method_0(class2, graphics);
		int width = Class5955.smethod_2(Math.Max(image.Size.Width, class2.Width));
		int height = Class5955.smethod_2(Math.Max(image.Size.Height, class2.Height));
		using Bitmap image4 = new Bitmap(width, height);
		using (Graphics graphics2 = Graphics.FromImage(image4))
		{
			graphics2.PageUnit = GraphicsUnit.Point;
			graphics2.PageScale = 1f;
			graphics2.TranslateTransform(0f - bounds.Location.X, 0f - bounds.Location.Y);
			Matrix transform = graphics.Transform;
			transform.Invert();
			graphics2.MultiplyTransform(transform);
			graphics2.DrawImage(image3, PointF.Empty);
		}
		using Bitmap bitmap = new Bitmap((int)rectangleF.Width, (int)rectangleF.Height);
		using (Graphics graphics3 = Graphics.FromImage(bitmap))
		{
			graphics3.PageUnit = GraphicsUnit.Point;
			graphics3.PageScale = 1f;
			graphics3.ScaleTransform(rectangleF.Width / (float)Class5955.smethod_4(bounds.Width, 96.0), rectangleF.Height / (float)Class5955.smethod_3(bounds.Height, 96.0));
			graphics3.Clear(Color.White);
			graphics3.DrawImage(image4, PointF.Empty);
		}
		using MemoryStream memoryStream = new MemoryStream();
		bitmap.Save(memoryStream, ImageFormat.Jpeg);
		memoryStream.Seek(0L, SeekOrigin.Begin);
		Class6220 class3 = new Class6220(image.Origin, image.Size, memoryStream.ToArray(), image.Crop, image.ChromaKey);
		class3.Hyperlink = image.Hyperlink;
		return class3;
	}
}
