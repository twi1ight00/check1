using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using ns218;
using ns224;
using ns233;
using ns234;
using ns235;

namespace ns237;

internal abstract class Class6525 : Class6514
{
	protected Class6683 class6683_0;

	protected Class6677 class6677_0;

	private readonly Class6002 class6002_0;

	protected abstract int PatternType { get; }

	protected abstract Class6002 BrushTransform { get; }

	internal override Enum892 ResourceType => Enum892.const_2;

	internal Class6525(Class6672 context)
		: base(context)
	{
		class6683_0 = new Class6683(context);
		class6677_0 = new Class6677(class6672_0, class6683_0, this);
		class6002_0 = class6672_0.GraphicStateWriter.GraphicState.TransformationMatrix.Clone();
	}

	internal override void vmethod_2(Class6679 writer)
	{
		writer.method_8("/Type", "/Pattern");
		writer.method_18("/PatternType", PatternType);
	}

	internal static Class6525 smethod_0(Class5990 brush, Class6672 context)
	{
		switch (brush.BrushType)
		{
		default:
			throw new NotSupportedException("Unsupported brush type.");
		case Enum746.const_1:
			return new Class6526(context, (Class5996)brush);
		case Enum746.const_2:
			return new Class6526(context, (Class5995)brush);
		case Enum746.const_3:
		{
			Class5993 class7 = (Class5993)brush;
			RectangleF rectangle = class7.Rectangle;
			Class6002 transform2 = class7.Transform;
			float num6;
			float num5;
			RectangleF rectangle2;
			if (rectangle.Width * rectangle.Height > 262144f)
			{
				num6 = (num5 = (float)Math.Sqrt(262144f / rectangle.Width / rectangle.Height));
				rectangle2 = new RectangleF((float)Math.Floor(rectangle.X * num6), (float)Math.Floor(rectangle.Y * num5), (float)Math.Ceiling(rectangle.Width * num6), (float)Math.Ceiling(rectangle.Height * num5));
			}
			else
			{
				rectangle2 = new RectangleF((float)Math.Floor(rectangle.X), (float)Math.Floor(rectangle.Y), (float)Math.Ceiling(rectangle.Width), (float)Math.Ceiling(rectangle.Height));
				num5 = 1f;
				num6 = 1f;
				double angle = class7.Angle;
				if (class7.Angle % 90.0 != 0.0)
				{
					class7.Angle = 0.0;
				}
				using (LinearGradientBrush linearGradientBrush = (LinearGradientBrush)Class6151.smethod_0(class7))
				{
					PointF[] array = new PointF[2]
					{
						new PointF(rectangle2.Left, rectangle2.Top),
						new PointF(rectangle2.Right, rectangle2.Top)
					};
					double num7 = smethod_1(array[0], array[1]);
					linearGradientBrush.Transform.TransformPoints(array);
					double num8 = smethod_1(array[0], array[1]);
					if (num7 < num8)
					{
						rectangle2 = new RectangleF((float)Math.Floor(rectangle.X), (float)Math.Floor(rectangle.Y), (float)Math.Ceiling(num8), (float)Math.Ceiling(rectangle.Height));
						num6 = rectangle.Width / rectangle2.Width;
					}
				}
				class7.Angle = angle;
			}
			class7.Rectangle = rectangle2;
			using Class6150 class8 = new Class6150((int)rectangle2.Width, (int)rectangle2.Height);
			using Class6160 class10 = new Class6160(class8);
			using LinearGradientBrush linearGradientBrush2 = (LinearGradientBrush)Class6151.smethod_0(class7);
			using MemoryStream memoryStream2 = new MemoryStream();
			Class6002 class9 = Class6161.smethod_1(linearGradientBrush2.Transform);
			linearGradientBrush2.Transform = new Matrix();
			class10.method_6().FillRectangle(linearGradientBrush2, 0, 0, class8.Width, class8.Height);
			class8.Save(memoryStream2, Enum788.const_5);
			byte[] imageBytes2 = memoryStream2.ToArray();
			Class5995 class11 = new Class5995(imageBytes2);
			class9.method_7(rectangle2.X, rectangle2.Y, MatrixOrder.Append);
			class9.method_5(1f / num6, 1f / num5, MatrixOrder.Append);
			class9.method_7(0f - rectangle.X, 0f - rectangle.Y, MatrixOrder.Append);
			class11.Transform = class9;
			class7.Transform = transform2;
			class7.Rectangle = rectangle;
			return context.Resources.method_2(class11);
		}
		case Enum746.const_4:
		{
			Class5994 @class = (Class5994)brush;
			float num = float.MaxValue;
			float num2 = float.MaxValue;
			float num3 = 0f;
			float num4 = 0f;
			for (int i = 0; i < @class.Path.Count; i++)
			{
				if (!(@class.Path[i] is Class6218 class2))
				{
					continue;
				}
				for (int j = 0; j < class2.Count; j++)
				{
					if (!(class2[j] is Class6223 class3))
					{
						continue;
					}
					foreach (PointF point in class3.Points)
					{
						if (point.X < num)
						{
							num = point.X;
						}
						if (point.X > num3)
						{
							num3 = point.X;
						}
						if (point.Y < num2)
						{
							num2 = point.Y;
						}
						if (point.Y > num4)
						{
							num4 = point.Y;
						}
					}
				}
			}
			if (num3 != num && num4 != num2)
			{
				using Class6150 class4 = new Class6150((int)(num3 - num), (int)(num4 - num2));
				using Class6160 class5 = new Class6160(class4);
				using PathGradientBrush pathGradientBrush = (PathGradientBrush)Class6151.smethod_0(@class);
				using MemoryStream memoryStream = new MemoryStream();
				Class6002 transform = Class6161.smethod_1(pathGradientBrush.Transform);
				pathGradientBrush.Transform = new Matrix();
				class5.method_6().FillRectangle(pathGradientBrush, 0, 0, class4.Width, class4.Height);
				class4.Save(memoryStream, Enum788.const_5);
				byte[] imageBytes = memoryStream.ToArray();
				Class5995 class6 = new Class5995(imageBytes);
				class6.Transform = transform;
				return context.Resources.method_2(class6);
			}
			throw new Exception59(brush);
		}
		}
	}

	protected void method_12(Class6679 writer)
	{
		Class6002 @class;
		if (BrushTransform == null)
		{
			float num = (float)Class5955.smethod_8(1.0);
			@class = new Class6002(num, 0f, 0f, num, 0f, 0f);
		}
		else
		{
			@class = BrushTransform.Clone();
			@class.method_9(class6002_0, MatrixOrder.Append);
		}
		writer.method_20("/Matrix", @class);
	}

	private static double smethod_1(PointF p, PointF q)
	{
		double num = p.X - q.X;
		double num2 = p.Y - q.Y;
		return Math.Sqrt(num * num + num2 * num2);
	}
}
