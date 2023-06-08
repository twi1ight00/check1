using System.Drawing;
using ns224;
using ns235;
using ns271;

namespace ns220;

internal class Class6594
{
	private static readonly Class5998 class5998_0 = Class5998.class5998_137;

	private static readonly Class5998 class5998_1 = Class5998.class5998_24;

	private Class6596 class6596_0;

	private Class5999 class5999_0 = new Class5999(12f, FontStyle.Regular, Class6652.Instance.method_0("Times New Roman", FontStyle.Regular, "Arial"));

	public Class6594(Class6596 options)
	{
		class6596_0 = options;
	}

	private Class6217 method_0(RectangleF rect)
	{
		Class6217 @class = new Class6217();
		Class6218 class2 = new Class6218();
		class2.method_3(rect);
		class2.IsClosed = true;
		@class.Add(class2);
		return @class;
	}

	private void method_1(Class6213 canvas, RectangleF rect)
	{
		if (class6596_0.EmulateFormFieldRendering.RenderBordersAndBackground)
		{
			Class6217 @class = method_0(rect);
			@class.Pen = new Class6003(class5998_1);
			canvas.Add(@class);
		}
	}

	private void method_2(Class6213 canvas, RectangleF rect, Class5998 color)
	{
		if (class6596_0.EmulateFormFieldRendering.RenderBordersAndBackground)
		{
			Class6217 @class = method_0(rect);
			@class.Brush = new Class5997(color);
			canvas.Add(@class);
		}
	}

	private void method_3(Class6213 canvas, PointF pos)
	{
		Class6217 @class = new Class6217(new Class6003(Class5998.class5998_7));
		@class.Brush = new Class5997(Class5998.class5998_7);
		Class6218 class2 = new Class6218();
		class2.method_1(new PointF[3]
		{
			new PointF(0f, 0f),
			new PointF(4f, 0f),
			new PointF(2f, 4f)
		});
		class2.IsClosed = true;
		@class.Add(class2);
		@class.RenderTransform = new Class6002(1f, 0f, 0f, 1f, pos.X - 2f, pos.Y - 2f);
		canvas.Add(@class);
	}

	private void method_4(Class6213 canvas, PointF pos)
	{
		Class6217 @class = new Class6217(new Class6003(Class5998.class5998_7));
		Class6218 class2 = new Class6218();
		class2.method_1(new PointF[3]
		{
			new PointF(3f, 5f),
			new PointF(4f, 8f),
			new PointF(9f, 1f)
		});
		@class.Add(class2);
		@class.RenderTransform = new Class6002(1f, 0f, 0f, 1f, pos.X, pos.Y);
		canvas.Add(@class);
	}

	private void method_5(Class6213 canvas, RectangleF rect)
	{
		rect.Inflate(1f, 1f);
		canvas.Clip = method_0(rect);
	}

	private static void smethod_0(float midX, float midY, float radius, Class6213 canvas, Class5990 brush)
	{
		Class6217 @class = new Class6217(new Class6003(class5998_1, 0.7f));
		@class.RenderTransform = new Class6002(1f, 0f, 0f, 1f, midX, midY);
		Class6218 class2 = new Class6218();
		class2.IsClosed = true;
		@class.Add(class2);
		float num = 0.55228f;
		float num2 = 0f;
		float y = 0f + radius;
		float num3 = 0f + radius;
		float num4 = 0f;
		float x = num2 + radius * num;
		float y2 = radius;
		float x2 = num3;
		float y3 = num4 + radius * num;
		Class6222 node = new Class6222(new PointF(num2, y), new PointF(x, y2), new PointF(x2, y3), new PointF(num3, num4));
		class2.Add(node);
		num2 = num3;
		y = num4;
		num3 = 0f;
		num4 = 0f - radius;
		x = num2;
		y2 = y - radius * num;
		x2 = num3 + radius * num;
		y3 = num4;
		node = new Class6222(new PointF(num2, y), new PointF(x, y2), new PointF(x2, y3), new PointF(num3, num4));
		class2.Add(node);
		num2 = num3;
		y = num4;
		num3 = 0f - radius;
		num4 = 0f;
		x = num2 - radius * num;
		y2 = y;
		x2 = num3;
		y3 = num4 - radius * num;
		node = new Class6222(new PointF(num2, y), new PointF(x, y2), new PointF(x2, y3), new PointF(num3, num4));
		class2.Add(node);
		num2 = num3;
		y = num4;
		num3 = 0f;
		num4 = 0f + radius;
		x = num2;
		y2 = y + radius * num;
		x2 = num3 - radius * num;
		y3 = num4;
		node = new Class6222(new PointF(num2, y), new PointF(x, y2), new PointF(x2, y3), new PointF(num3, num4));
		class2.Add(node);
		@class.Brush = brush;
		canvas.Add(@class);
	}

	internal Class6213 method_6(Class6210 field)
	{
		Class6213 @class = new Class6213();
		RectangleF boundingBox = field.BoundingBox;
		boundingBox.Inflate(0f, 2f);
		if (!string.IsNullOrEmpty(field.PlainText))
		{
			if (field.IsMultiline)
			{
				string[] array = field.PlainText.Split('\r', '\n', '\u2029');
				float num = field.DefaultFont.AscentPoints + field.DefaultFont.DescentPoints;
				float num2 = ((field.LineHeight > 0f) ? field.LineHeight : (num + 1f));
				int num3 = 0;
				string[] array2 = array;
				foreach (string text in array2)
				{
					Class6219 class2 = new Class6219(field.DefaultFont, Class5998.class5998_7, Class5998.class5998_7, new PointF(0f, 0f), text, boundingBox.Size, 0f);
					class2.RenderTransform = new Class6002(1f, 0f, 0f, 1f, boundingBox.Location.X + 1f, boundingBox.Location.Y + num2 * (float)(++num3) - field.DefaultFont.DescentPoints);
					@class.Add(class2);
				}
			}
			else
			{
				float num4 = field.DefaultFont.AscentPoints + field.DefaultFont.DescentPoints;
				Class6219 class3 = new Class6219(field.DefaultFont, Class5998.class5998_7, Class5998.class5998_7, new PointF(0f, 0f), field.PlainText, boundingBox.Size, 0f);
				class3.RenderTransform = new Class6002(1f, 0f, 0f, 1f, boundingBox.Location.X + 1f, boundingBox.Location.Y + field.Size.Height / 2f + num4 / 2f);
				@class.Add(class3);
			}
		}
		method_1(@class, boundingBox);
		method_5(@class, boundingBox);
		return @class;
	}

	internal Class6213 method_7(Class6207 field)
	{
		Class6213 @class = new Class6213();
		method_1(@class, new RectangleF(field.Origin, new SizeF(10f, 10f)));
		if (field.Value)
		{
			RectangleF boundingBox = field.BoundingBox;
			method_4(@class, new PointF(boundingBox.X, boundingBox.Y));
		}
		return @class;
	}

	internal Class6213 method_8(Class6209 field)
	{
		Class6213 @class = new Class6213();
		RectangleF boundingBox = field.BoundingBox;
		boundingBox.Inflate(0f, 2f);
		if (field.Value > 0 && field.Value < field.Items.Count)
		{
			Class6219 class2 = new Class6219(field.DefaultFont, Class5998.class5998_7, Class5998.class5998_7, new PointF(0f, 0f), field.Items[field.Value], boundingBox.Size, 0f);
			class2.RenderTransform = new Class6002(1f, 0f, 0f, 1f, boundingBox.Location.X + 1f, boundingBox.Location.Y + field.Size.Height / 2f + (field.DefaultFont.AscentPoints + field.DefaultFont.DescentPoints) / 2f);
			@class.Add(class2);
		}
		method_1(@class, boundingBox);
		method_3(@class, new PointF(boundingBox.Right - 8f, boundingBox.Y + boundingBox.Height / 2f));
		method_5(@class, boundingBox);
		return @class;
	}

	internal Class6213 method_9(Class6208 field)
	{
		Class6213 @class = new Class6213();
		if (class6596_0.EmulateFormFieldRendering.RenderBordersAndBackground)
		{
			smethod_0(field.Origin.X + 5f, field.Origin.Y + 5f, 3.5f, @class, new Class5997(class5998_0));
		}
		if (field.Value)
		{
			smethod_0(field.Origin.X + 5f, field.Origin.Y + 5f, 1.5f, @class, new Class5997(class5998_1));
		}
		return @class;
	}

	internal Class6213 method_10(Class6206 field)
	{
		Class6213 @class = new Class6213();
		RectangleF boundingBox = field.BoundingBox;
		method_2(@class, boundingBox, class5998_0);
		if (!string.IsNullOrEmpty(field.Caption))
		{
			Class6219 class2 = new Class6219(class5999_0, Class5998.class5998_7, Class5998.class5998_7, new PointF(0f, 0f), field.Caption, boundingBox.Size, 0f);
			SizeF sizeF = class5999_0.method_4(field.Caption);
			PointF pointF = new PointF(sizeF.Width / 2f, sizeF.Height / 2f);
			PointF pointF2 = new PointF(field.Size.Width / 2f, field.Size.Height / 2f);
			class2.RenderTransform = new Class6002(1f, 0f, 0f, 1f, pointF2.X - pointF.X, pointF2.Y + pointF.Y);
			@class.Add(class2);
		}
		method_1(@class, boundingBox);
		method_5(@class, boundingBox);
		return @class;
	}
}
