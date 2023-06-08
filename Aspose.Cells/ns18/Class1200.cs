using System;
using System.Collections;
using System.Drawing;
using Aspose.Cells.Drawing;

namespace ns18;

internal class Class1200
{
	internal static ArrayList smethod_0(Color color_0, Color color_1, RectangleF rectangleF_0, GradientStyleType gradientStyleType_0, int int_0)
	{
		ArrayList arrayList = new ArrayList();
		Class1199 @class = null;
		Class458 class2 = null;
		switch (gradientStyleType_0)
		{
		case GradientStyleType.DiagonalDown:
			switch (int_0)
			{
			case 1:
				@class = new Class1199(new PointF(rectangleF_0.Right, rectangleF_0.Top), new PointF(rectangleF_0.Right, rectangleF_0.Bottom), color_0, color_1, 1f);
				class2 = Class458.smethod_2(rectangleF_0);
				class2.method_3(@class);
				arrayList.Add(class2);
				break;
			case 2:
				@class = new Class1199(new PointF(rectangleF_0.Left, rectangleF_0.Bottom), new PointF(rectangleF_0.Right, rectangleF_0.Top), color_0, color_1, 1f);
				class2 = Class458.smethod_2(rectangleF_0);
				class2.method_3(@class);
				arrayList.Add(class2);
				break;
			case 3:
			{
				double a2 = Math.Atan2(rectangleF_0.Height, rectangleF_0.Width);
				float num3 = (float)((double)rectangleF_0.Width * Math.Sin(a2) * Math.Sin(a2));
				float num4 = (float)((double)num3 * Math.Tan(a2));
				@class = new Class1199(new PointF(rectangleF_0.Right, rectangleF_0.Top), new PointF(rectangleF_0.Right - num3, rectangleF_0.Bottom - num4), color_0, color_1, 1f);
				class2 = Class458.smethod_0(rectangleF_0.Location, new PointF(rectangleF_0.Right, rectangleF_0.Top), new PointF(rectangleF_0.Right, rectangleF_0.Bottom));
				class2.method_3(@class);
				arrayList.Add(class2);
				class2 = Class458.smethod_3(new PointF(rectangleF_0.Right, rectangleF_0.Bottom), new PointF(rectangleF_0.Left, rectangleF_0.Top));
				class2.class770_0 = new Class770(color_1);
				arrayList.Add(class2);
				@class = new Class1199(new PointF(rectangleF_0.Left, rectangleF_0.Bottom), new PointF(rectangleF_0.Left + num3, rectangleF_0.Top + num4), color_0, color_1, 1f);
				class2 = Class458.smethod_0(new PointF(rectangleF_0.Right, rectangleF_0.Bottom), new PointF(rectangleF_0.Left, rectangleF_0.Bottom), rectangleF_0.Location);
				class2.method_3(@class);
				arrayList.Add(class2);
				break;
			}
			}
			break;
		case GradientStyleType.DiagonalUp:
			switch (int_0)
			{
			case 1:
				@class = new Class1199(rectangleF_0.Location, new PointF(rectangleF_0.Right, rectangleF_0.Bottom), color_0, color_1, 1f);
				class2 = Class458.smethod_2(rectangleF_0);
				class2.method_3(@class);
				arrayList.Add(class2);
				break;
			case 2:
				@class = new Class1199(new PointF(rectangleF_0.Right, rectangleF_0.Bottom), rectangleF_0.Location, color_0, color_1, 1f);
				class2 = Class458.smethod_2(rectangleF_0);
				class2.method_3(@class);
				arrayList.Add(class2);
				break;
			case 3:
			{
				double a = Math.Atan2(rectangleF_0.Height, rectangleF_0.Width);
				float num = (float)((double)rectangleF_0.Width * Math.Sin(a) * Math.Sin(a));
				float num2 = (float)((double)num * Math.Tan(a));
				@class = new Class1199(rectangleF_0.Location, new PointF(rectangleF_0.Left + num, rectangleF_0.Bottom - num2), color_0, color_1, 1f);
				class2 = Class458.smethod_0(rectangleF_0.Location, new PointF(rectangleF_0.Right, rectangleF_0.Top), new PointF(rectangleF_0.Left, rectangleF_0.Bottom));
				class2.method_3(@class);
				arrayList.Add(class2);
				class2 = Class458.smethod_3(new PointF(rectangleF_0.Left, rectangleF_0.Bottom), new PointF(rectangleF_0.Right, rectangleF_0.Top));
				class2.class770_0 = new Class770(color_1);
				arrayList.Add(class2);
				@class = new Class1199(new PointF(rectangleF_0.Right, rectangleF_0.Bottom), new PointF(rectangleF_0.Right - num, rectangleF_0.Top + num2), color_0, color_1, 1f);
				class2 = Class458.smethod_0(new PointF(rectangleF_0.Right, rectangleF_0.Bottom), new PointF(rectangleF_0.Right, rectangleF_0.Top), new PointF(rectangleF_0.Left, rectangleF_0.Bottom));
				class2.method_3(@class);
				arrayList.Add(class2);
				break;
			}
			}
			break;
		case GradientStyleType.FromCenter:
		{
			PointF pointF_ = new PointF((rectangleF_0.Left + rectangleF_0.Right) / 2f, (rectangleF_0.Top + rectangleF_0.Bottom) / 2f);
			PointF pointF_2 = new PointF(rectangleF_0.Left, rectangleF_0.Top);
			PointF pointF = new PointF(rectangleF_0.Right, rectangleF_0.Top);
			PointF pointF2 = new PointF(rectangleF_0.Right, rectangleF_0.Bottom);
			PointF pointF_3 = new PointF(rectangleF_0.Left, rectangleF_0.Bottom);
			@class = new Class1199(new PointF(rectangleF_0.Left, rectangleF_0.Top), new PointF(pointF_.X, rectangleF_0.Top), color_1, color_0, 1f);
			class2 = Class458.smethod_0(pointF_2, pointF_, pointF_3);
			class2.method_3(@class);
			arrayList.Add(class2);
			@class = new Class1199(new PointF(rectangleF_0.Left, rectangleF_0.Top), new PointF(rectangleF_0.Left, pointF_.Y), color_1, color_0, 1f);
			class2 = Class458.smethod_0(pointF_2, pointF_, pointF);
			class2.method_3(@class);
			arrayList.Add(class2);
			@class = new Class1199(new PointF(rectangleF_0.Right, rectangleF_0.Top), new PointF(pointF_.X, rectangleF_0.Top), color_1, color_0, 1f);
			class2 = Class458.smethod_0(pointF, pointF_, pointF2);
			class2.method_3(@class);
			arrayList.Add(class2);
			@class = new Class1199(new PointF(rectangleF_0.Right, rectangleF_0.Bottom), new PointF(rectangleF_0.Right, pointF_.Y), color_1, color_0, 1f);
			class2 = Class458.smethod_0(pointF2, pointF_, pointF_3);
			class2.method_3(@class);
			arrayList.Add(class2);
			break;
		}
		case GradientStyleType.Horizontal:
			switch (int_0)
			{
			case 1:
				@class = new Class1199(rectangleF_0.Location, new PointF(rectangleF_0.Left, rectangleF_0.Bottom), color_0, color_1, 1f);
				class2 = Class458.smethod_2(rectangleF_0);
				class2.method_3(@class);
				arrayList.Add(class2);
				break;
			case 2:
				@class = new Class1199(new PointF(rectangleF_0.Left, rectangleF_0.Bottom), rectangleF_0.Location, color_0, color_1, 1f);
				class2 = Class458.smethod_2(rectangleF_0);
				class2.method_3(@class);
				arrayList.Add(class2);
				break;
			case 3:
				@class = new Class1199(rectangleF_0.Location, new PointF(rectangleF_0.Left, rectangleF_0.Top + rectangleF_0.Height / 2f), color_0, color_1, 1f);
				class2 = Class458.smethod_2(new RectangleF(rectangleF_0.Location, new SizeF(rectangleF_0.Width, rectangleF_0.Height / 2f)));
				class2.method_3(@class);
				arrayList.Add(class2);
				@class = new Class1199(new PointF(rectangleF_0.Left, rectangleF_0.Bottom), new PointF(rectangleF_0.Left, rectangleF_0.Top + rectangleF_0.Height / 2f), color_0, color_1, 1f);
				class2 = Class458.smethod_2(new RectangleF(rectangleF_0.Left, rectangleF_0.Top + rectangleF_0.Height / 2f, rectangleF_0.Width, rectangleF_0.Height / 2f));
				class2.method_3(@class);
				arrayList.Add(class2);
				break;
			}
			break;
		case GradientStyleType.Vertical:
			switch (int_0)
			{
			case 1:
				@class = new Class1199(rectangleF_0.Location, new PointF(rectangleF_0.Right, rectangleF_0.Top), color_0, color_1, 1f);
				class2 = Class458.smethod_2(rectangleF_0);
				class2.method_3(@class);
				arrayList.Add(class2);
				break;
			case 2:
				@class = new Class1199(new PointF(rectangleF_0.Right, rectangleF_0.Top), rectangleF_0.Location, color_0, color_1, 1f);
				class2 = Class458.smethod_2(rectangleF_0);
				class2.method_3(@class);
				arrayList.Add(class2);
				break;
			case 3:
				@class = new Class1199(rectangleF_0.Location, new PointF(rectangleF_0.Right - rectangleF_0.Width / 2f, rectangleF_0.Top), color_0, color_1, 1f);
				class2 = Class458.smethod_2(new RectangleF(rectangleF_0.Left, rectangleF_0.Top, rectangleF_0.Width / 2f, rectangleF_0.Height));
				class2.method_3(@class);
				arrayList.Add(class2);
				@class = new Class1199(new PointF(rectangleF_0.Right, rectangleF_0.Top), new PointF(rectangleF_0.Right - rectangleF_0.Width / 2f, rectangleF_0.Top), color_0, color_1, 1f);
				class2 = Class458.smethod_2(new RectangleF(rectangleF_0.Left + rectangleF_0.Width / 2f, rectangleF_0.Top, rectangleF_0.Width / 2f, rectangleF_0.Height));
				class2.method_3(@class);
				arrayList.Add(class2);
				break;
			}
			break;
		}
		return arrayList;
	}
}
