using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using ns167;
using ns235;

namespace ns163;

internal class Class4752
{
	private const float float_0 = 2f;

	internal static void smethod_0(Class4786 container)
	{
		Class4786 @class = new Class4786();
		foreach (Class4845 item in container)
		{
			if (!item.Value.BoundingBox.IsEmpty)
			{
				Class4846 class3 = smethod_1(item, container);
				if (class3.Count > 1)
				{
					Class4790 element = smethod_3(class3);
					@class.Add(element);
					class3.method_4();
				}
			}
		}
		container.Flush();
		container.Add(@class);
	}

	internal static Class4846 smethod_1(Class4845 el, Class4786 container)
	{
		Class4846 @class = new Class4846();
		if (el.Value is Class4790)
		{
			@class.Add(el);
			smethod_2(@class, container);
		}
		return @class;
	}

	private static void smethod_2(Class4846 elements, Class4786 container)
	{
		RectangleF region = RectangleF.Inflate(elements.method_5(), 2f, 2f);
		if (region.X < 0f)
		{
			region.X = 0f;
		}
		if (region.Y < 0f)
		{
			region.Y = 0f;
		}
		Class4846 collection = container.method_8(region, checkForLooseOverlap: false);
		if (elements.method_9(collection))
		{
			smethod_2(elements, container);
		}
	}

	private static Class4790 smethod_3(Class4846 pictures)
	{
		RectangleF rectangleF = pictures.method_5();
		PointF origin = smethod_4(pictures);
		Bitmap bitmap = new Bitmap(Math.Max((int)rectangleF.Width, 10), Math.Max((int)rectangleF.Height, 10));
		bitmap.SetResolution(1f, 1f);
		Graphics graphics = Graphics.FromImage(bitmap);
		foreach (Class4845 picture in pictures)
		{
			if (picture.Value is Class4790 class2)
			{
				Bitmap bitmap2 = new Bitmap(new MemoryStream(class2.ImageData));
				bitmap2.SetResolution(1f, 1f);
				graphics.DrawImage(bitmap2, (float)Math.Floor(class2.Origin.X - origin.X) * 1f, (float)Math.Floor(class2.Origin.Y - origin.Y) * 1f);
			}
		}
		MemoryStream memoryStream = new MemoryStream();
		bitmap.Save(memoryStream, ImageFormat.Png);
		return new Class4790(new Class6220(origin, new SizeF(rectangleF.Size.Width * 1f, rectangleF.Size.Height * 1f), memoryStream.ToArray()));
	}

	private static PointF smethod_4(Class4846 pictures)
	{
		pictures.method_12(Enum673.const_0);
		PointF origin = pictures[0].Value.Origin;
		foreach (Class4845 picture in pictures)
		{
			if (origin.X > picture.Value.Origin.X)
			{
				origin.X = picture.Value.Origin.X;
			}
			if (origin.Y > picture.Value.Origin.Y)
			{
				origin.Y = picture.Value.Origin.Y;
			}
		}
		return origin;
	}
}
