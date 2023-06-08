using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using Aspose.Words.Drawing;
using x5794c252ba25e723;

namespace x3d94286fe72124a8;

internal class xa99f8d94adfe1070
{
	private readonly Shape x317be79405176667;

	private readonly x54366fa5f75a02f7 x892999702ade1088;

	private readonly float x68d51220507cdf5a;

	private readonly float x2c86c0d70178a916;

	private readonly float x33d0867e2f97610c;

	private readonly int xf7b6243694399d8b;

	private readonly int xfb9bdc55d534b3ca;

	private x0fd9cfae6bc4080f x506b5d132211727a;

	private float x14992df8411b994e;

	private x54366fa5f75a02f7 x435b26849f0d2436;

	private x54366fa5f75a02f7 x53ff5935581f97a4;

	private SizeF x3b77a41bd57164d6 = SizeF.Empty;

	private PointF x5a8a0e5b0655f03c;

	internal PointF xe5aa6d515a201cc4 => x5a8a0e5b0655f03c;

	internal xa99f8d94adfe1070(Shape shape, SizeF size, x54366fa5f75a02f7 parentCenterTransform, float parentScaleX, float parentScaleY, float parentAngle)
	{
		x317be79405176667 = shape;
		x3b77a41bd57164d6 = (size.IsEmpty ? x317be79405176667.x437e3b626c0fdd43 : size);
		x892999702ade1088 = parentCenterTransform;
		SizeF sizeF = xa85a34732ecd05c1(shape, parentScaleX, parentScaleY);
		x68d51220507cdf5a = sizeF.Width;
		x2c86c0d70178a916 = sizeF.Height;
		x33d0867e2f97610c = parentAngle;
		x506b5d132211727a = x0fd9cfae6bc4080f.x4d0b9d4447ba7566;
		x14992df8411b994e = 0f;
		x435b26849f0d2436 = null;
		xf7b6243694399d8b = shape.x14450b2cd7bcfcfa;
		xfb9bdc55d534b3ca = shape.xe915b3cb9284a483;
		xb42d0f543391319d();
	}

	internal static SizeF xa85a34732ecd05c1(ShapeBase x5770cdefd8931aa9, float x50d264e6da53d913, float x2d2c4e2c948cba27)
	{
		if (!x45fb8e49520ded21(x5770cdefd8931aa9))
		{
			return new SizeF(x50d264e6da53d913, x2d2c4e2c948cba27);
		}
		return new SizeF(x2d2c4e2c948cba27, x50d264e6da53d913);
	}

	internal static bool x45fb8e49520ded21(ShapeBase x5770cdefd8931aa9)
	{
		return xafc97f7981b1cd86((float)x5770cdefd8931aa9.Rotation);
	}

	internal static bool xafc97f7981b1cd86(float xcb83cdf6822fc99d)
	{
		xcb83cdf6822fc99d = x37bba7c72ab9ad63(xcb83cdf6822fc99d);
		if (!(xcb83cdf6822fc99d >= 45f) || !(xcb83cdf6822fc99d < 135f))
		{
			if (xcb83cdf6822fc99d >= 225f)
			{
				return xcb83cdf6822fc99d < 315f;
			}
			return false;
		}
		return true;
	}

	internal static float x37bba7c72ab9ad63(float xcb83cdf6822fc99d)
	{
		if (Math.Abs(xcb83cdf6822fc99d) > 360f)
		{
			xcb83cdf6822fc99d %= 360f;
		}
		if (xcb83cdf6822fc99d < 0f)
		{
			xcb83cdf6822fc99d += 360f;
		}
		return xcb83cdf6822fc99d;
	}

	internal PointF x80cf8ffbecbca30d()
	{
		return x80cf8ffbecbca30d(x317be79405176667, x3b77a41bd57164d6, x68d51220507cdf5a, x2c86c0d70178a916);
	}

	private static PointF x80cf8ffbecbca30d(ShapeBase x8739b0dd3627f37e, SizeF x0ceec69a97f73617, float x50d264e6da53d913, float x2d2c4e2c948cba27)
	{
		int x133d653c1b9b01f = x8739b0dd3627f37e.x133d653c1b9b01f2;
		int xc97e136f0019c = x8739b0dd3627f37e.xc97e136f0019c237;
		float num = x0ceec69a97f73617.Width / (float)x133d653c1b9b01f;
		float num2 = x0ceec69a97f73617.Height / (float)xc97e136f0019c;
		if (x8739b0dd3627f37e is Shape)
		{
			Shape shape = (Shape)x8739b0dd3627f37e;
			if (shape.x14450b2cd7bcfcfa != 0 || shape.xe915b3cb9284a483 != 0)
			{
				float num3 = Math.Min(num, num2);
				num = num3;
				num2 = num3;
			}
		}
		num *= x50d264e6da53d913;
		num2 *= x2d2c4e2c948cba27;
		return new PointF((num == 0f) ? 1f : num, (num2 == 0f) ? 1f : num2);
	}

	internal static SizeF x4e7435b66e33dc1b(SizeF x0ceec69a97f73617, ShapeBase x5770cdefd8931aa9, float x50d264e6da53d913, float x2d2c4e2c948cba27)
	{
		if (x0ceec69a97f73617.IsEmpty)
		{
			return x0ceec69a97f73617;
		}
		PointF pointF = x80cf8ffbecbca30d(x5770cdefd8931aa9, x5770cdefd8931aa9.x437e3b626c0fdd43, x50d264e6da53d913, x2d2c4e2c948cba27);
		return new SizeF(x0ceec69a97f73617.Width / pointF.X, x0ceec69a97f73617.Height / pointF.Y);
	}

	internal void xa4b699bd47eb7372(PointF[] x6fa2570084b2ad39, bool x16aef18841fa33ad)
	{
		if (x506b5d132211727a != 0)
		{
			for (int i = 0; i < x6fa2570084b2ad39.Length; i++)
			{
				PointF pointF = x6fa2570084b2ad39[i];
				float num = pointF.X;
				float num2 = pointF.Y;
				if (x506b5d132211727a == x0fd9cfae6bc4080f.x7f419cac4dfc7309)
				{
					if (num > (float)xf7b6243694399d8b)
					{
						num += x14992df8411b994e;
					}
				}
				else if (num2 > (float)xfb9bdc55d534b3ca)
				{
					num2 += x14992df8411b994e;
				}
				ref PointF reference = ref x6fa2570084b2ad39[i];
				reference = new PointF(num, num2);
			}
		}
		if (x16aef18841fa33ad)
		{
			x53ff5935581f97a4.xa4b699bd47eb7372(x6fa2570084b2ad39);
		}
		else
		{
			x435b26849f0d2436.xa4b699bd47eb7372(x6fa2570084b2ad39);
		}
	}

	internal x54366fa5f75a02f7 xd311686697c8cc84(Size x696d2300154be222, bool x2fc79b6a9ba3d6bf)
	{
		PointF[] array = new PointF[4]
		{
			PointF.Empty,
			new PointF(x317be79405176667.x133d653c1b9b01f2, 0f),
			new PointF(x317be79405176667.x133d653c1b9b01f2, x317be79405176667.xc97e136f0019c237),
			new PointF(0f, x317be79405176667.xc97e136f0019c237)
		};
		xa4b699bd47eb7372(array, x16aef18841fa33ad: false);
		RectangleF rectangleF = x37b1dbbad6246778(array);
		float x = rectangleF.X;
		float y = rectangleF.Y;
		float width = rectangleF.Width;
		float height = rectangleF.Height;
		if (x317be79405176667.x22d2b300aac1d857)
		{
			RectangleF rectangleF2 = x317be79405176667.xdd95551ca745bb85(new RectangleF(0f, 0f, x3b77a41bd57164d6.Width, x3b77a41bd57164d6.Height));
			width = rectangleF2.Width;
			height = rectangleF2.Height;
		}
		float num = width / (float)x696d2300154be222.Width;
		float num2 = height / (float)x696d2300154be222.Height;
		if (x2fc79b6a9ba3d6bf)
		{
			if (num > num2)
			{
				num2 = num;
			}
			else
			{
				num = num2;
			}
		}
		x54366fa5f75a02f7 x54366fa5f75a02f = new x54366fa5f75a02f7();
		x54366fa5f75a02f.x5152a5707921c783(num, num2, MatrixOrder.Prepend);
		double num3 = (double)x33d0867e2f97610c + x317be79405176667.Rotation;
		if (x317be79405176667.x22d2b300aac1d857 && num3 != 0.0)
		{
			x = array[0].X;
			y = array[0].Y;
			x54366fa5f75a02f.xa77087bb05d9ef76((float)num3, MatrixOrder.Append);
		}
		x54366fa5f75a02f.xce92de628aa023cf(x, y, MatrixOrder.Append);
		return x54366fa5f75a02f;
	}

	internal static RectangleF x37b1dbbad6246778(PointF[] x6fa2570084b2ad39)
	{
		float x = x6fa2570084b2ad39[0].X;
		float num = x;
		float y = x6fa2570084b2ad39[0].Y;
		float num2 = y;
		for (int i = 0; i < x6fa2570084b2ad39.Length; i++)
		{
			PointF pointF = x6fa2570084b2ad39[i];
			if (pointF.X > num)
			{
				num = pointF.X;
			}
			else if (pointF.X < x)
			{
				x = pointF.X;
			}
			if (pointF.Y > num2)
			{
				num2 = pointF.Y;
			}
			else if (pointF.Y < y)
			{
				y = pointF.Y;
			}
		}
		return new RectangleF(x, y, num - x, num2 - y);
	}

	private void xb42d0f543391319d()
	{
		int x06c65daad0c0656c = x317be79405176667.x06c65daad0c0656c;
		int x399bb78ac51a = x317be79405176667.x399bb78ac51a4081;
		int x133d653c1b9b01f = x317be79405176667.x133d653c1b9b01f2;
		int xc97e136f0019c = x317be79405176667.xc97e136f0019c237;
		float num = (float)x133d653c1b9b01f * 0.5f;
		float num2 = (float)xc97e136f0019c * 0.5f;
		float num3 = x3b77a41bd57164d6.Width / (float)x133d653c1b9b01f;
		float num4 = x3b77a41bd57164d6.Height / (float)xc97e136f0019c;
		float xcb83cdf6822fc99d = (float)x317be79405176667.Rotation;
		if (xf7b6243694399d8b != 0 || xfb9bdc55d534b3ca != 0)
		{
			if (num3 > num4)
			{
				x506b5d132211727a = x0fd9cfae6bc4080f.x7f419cac4dfc7309;
				x14992df8411b994e = (float)x133d653c1b9b01f * (num3 / num4 - 1f);
				num += x14992df8411b994e * 0.5f;
			}
			else
			{
				x506b5d132211727a = x0fd9cfae6bc4080f.x5edc1b201486f4c2;
				x14992df8411b994e = (float)xc97e136f0019c * (num4 / num3 - 1f);
				num2 += x14992df8411b994e * 0.5f;
			}
			float num5 = Math.Min(num3, num4);
			num3 = num5;
			num4 = num5;
		}
		x3083faac9f7704a8(num3, num4, num, num2, x06c65daad0c0656c, x399bb78ac51a);
		x435b26849f0d2436 = new x54366fa5f75a02f7();
		x435b26849f0d2436.xce92de628aa023cf(-x06c65daad0c0656c, -x399bb78ac51a, MatrixOrder.Append);
		x435b26849f0d2436.xce92de628aa023cf(0f - num, 0f - num2, MatrixOrder.Append);
		num3 *= x68d51220507cdf5a;
		num4 *= x2c86c0d70178a916;
		x53ff5935581f97a4 = x435b26849f0d2436.x8b61531c8ea35b85();
		x435b26849f0d2436.x5152a5707921c783(num3, num4, MatrixOrder.Append);
		x53ff5935581f97a4.x5152a5707921c783(num3, num4, MatrixOrder.Append);
		x435b26849f0d2436.xa77087bb05d9ef76(xcb83cdf6822fc99d, MatrixOrder.Append);
		xb079a9f9aff86b4a(x317be79405176667, x435b26849f0d2436);
		x435b26849f0d2436.xa77087bb05d9ef76(x33d0867e2f97610c, MatrixOrder.Append);
		x435b26849f0d2436.xce92de628aa023cf(num * num3, num2 * num4, MatrixOrder.Append);
		x53ff5935581f97a4.xce92de628aa023cf(num * num3, num2 * num4, MatrixOrder.Append);
	}

	private void x3083faac9f7704a8(float x681e90ee27c889ce, float xeaff04143bcea2b5, float xde09ea6038f07fb3, float xe84723962214bc3e, float xef72ec3a4b271758, float x138373ef1b97ea00)
	{
		PointF[] array = new PointF[1]
		{
			new PointF(xde09ea6038f07fb3, xe84723962214bc3e)
		};
		x54366fa5f75a02f7 x54366fa5f75a02f = new x54366fa5f75a02f7();
		x54366fa5f75a02f.xce92de628aa023cf(0f - xef72ec3a4b271758, 0f - x138373ef1b97ea00, MatrixOrder.Append);
		x54366fa5f75a02f.x5152a5707921c783(x681e90ee27c889ce, xeaff04143bcea2b5, MatrixOrder.Append);
		if (!x317be79405176667.IsTopLevel)
		{
			x54366fa5f75a02f.xce92de628aa023cf((float)x317be79405176667.Left, (float)x317be79405176667.Top, MatrixOrder.Append);
		}
		x54366fa5f75a02f.x490e30087768649f(x892999702ade1088, MatrixOrder.Append);
		x54366fa5f75a02f.xce92de628aa023cf((0f - xde09ea6038f07fb3) * x681e90ee27c889ce * x68d51220507cdf5a, (0f - xe84723962214bc3e) * xeaff04143bcea2b5 * x2c86c0d70178a916, MatrixOrder.Append);
		x54366fa5f75a02f.xa4b699bd47eb7372(array);
		x5a8a0e5b0655f03c = array[0];
	}

	private static void xb079a9f9aff86b4a(Shape x5770cdefd8931aa9, x54366fa5f75a02f7 x678241938de24d81)
	{
		switch (x5770cdefd8931aa9.FlipOrientation)
		{
		case FlipOrientation.Both:
			x678241938de24d81.x5152a5707921c783(-1f, -1f, MatrixOrder.Append);
			break;
		case FlipOrientation.Horizontal:
			x678241938de24d81.x5152a5707921c783(-1f, 1f, MatrixOrder.Append);
			break;
		case FlipOrientation.Vertical:
			x678241938de24d81.x5152a5707921c783(1f, -1f, MatrixOrder.Append);
			break;
		case FlipOrientation.None:
			break;
		}
	}

	internal static x54366fa5f75a02f7 x936ca47202325634(Shape x5770cdefd8931aa9, float x58be563164758381, float x7b0313c998fb2b98, float xa50156fedadf52fb)
	{
		int x06c65daad0c0656c = x5770cdefd8931aa9.x06c65daad0c0656c;
		int x399bb78ac51a = x5770cdefd8931aa9.x399bb78ac51a4081;
		float num = (float)x5770cdefd8931aa9.Width;
		float num2 = (float)x5770cdefd8931aa9.Height;
		float num3 = num * 0.5f;
		float num4 = num2 * 0.5f;
		x54366fa5f75a02f7 x54366fa5f75a02f = new x54366fa5f75a02f7();
		x54366fa5f75a02f.xce92de628aa023cf(-x06c65daad0c0656c, -x399bb78ac51a, MatrixOrder.Append);
		x54366fa5f75a02f.xce92de628aa023cf(0f - num3, 0f - num4, MatrixOrder.Append);
		switch (x5770cdefd8931aa9.FlipOrientation)
		{
		case FlipOrientation.Both:
			x54366fa5f75a02f.x5152a5707921c783(-1f, -1f, MatrixOrder.Append);
			break;
		case FlipOrientation.Horizontal:
			x54366fa5f75a02f.x5152a5707921c783(-1f, 1f, MatrixOrder.Append);
			break;
		case FlipOrientation.Vertical:
			x54366fa5f75a02f.x5152a5707921c783(1f, -1f, MatrixOrder.Append);
			break;
		}
		float num5 = (float)x5770cdefd8931aa9.Rotation + xa50156fedadf52fb;
		x54366fa5f75a02f.x5152a5707921c783(x58be563164758381, x7b0313c998fb2b98, MatrixOrder.Append);
		x54366fa5f75a02f.xa77087bb05d9ef76(num5, MatrixOrder.Append);
		float num6;
		float num7;
		if (Math.Abs(num5 % 180f) == 90f)
		{
			num6 = num4;
			num7 = num3;
		}
		else
		{
			num6 = num3;
			num7 = num4;
		}
		x54366fa5f75a02f.xce92de628aa023cf(num6 * x58be563164758381, num7 * x7b0313c998fb2b98, MatrixOrder.Append);
		return x54366fa5f75a02f;
	}

	internal static x54366fa5f75a02f7 xd1f77e3bec02ca04(ShapeBase x5770cdefd8931aa9, SizeF x0ceec69a97f73617, bool x24045939618dc027)
	{
		int x06c65daad0c0656c = x5770cdefd8931aa9.x06c65daad0c0656c;
		int x399bb78ac51a = x5770cdefd8931aa9.x399bb78ac51a4081;
		int x133d653c1b9b01f = x5770cdefd8931aa9.x133d653c1b9b01f2;
		int xc97e136f0019c = x5770cdefd8931aa9.xc97e136f0019c237;
		float num = (float)x133d653c1b9b01f * 0.5f;
		float num2 = (float)xc97e136f0019c * 0.5f;
		if (x0ceec69a97f73617.IsEmpty)
		{
			x0ceec69a97f73617 = x5770cdefd8931aa9.x437e3b626c0fdd43;
		}
		float num3 = x0ceec69a97f73617.Width / (float)x133d653c1b9b01f;
		float num4 = x0ceec69a97f73617.Height / (float)xc97e136f0019c;
		if (x24045939618dc027)
		{
			num3 = x0ceec69a97f73617.Height / (float)xc97e136f0019c;
			num4 = x0ceec69a97f73617.Width / (float)x133d653c1b9b01f;
		}
		x54366fa5f75a02f7 x54366fa5f75a02f = new x54366fa5f75a02f7();
		x54366fa5f75a02f.xce92de628aa023cf(-x06c65daad0c0656c, -x399bb78ac51a, MatrixOrder.Append);
		x54366fa5f75a02f.xce92de628aa023cf(0f - num, 0f - num2, MatrixOrder.Append);
		switch (x5770cdefd8931aa9.FlipOrientation)
		{
		case FlipOrientation.Both:
			x54366fa5f75a02f.x5152a5707921c783(-1f, -1f, MatrixOrder.Append);
			break;
		case FlipOrientation.Horizontal:
			x54366fa5f75a02f.x5152a5707921c783(-1f, 1f, MatrixOrder.Append);
			break;
		case FlipOrientation.Vertical:
			x54366fa5f75a02f.x5152a5707921c783(1f, -1f, MatrixOrder.Append);
			break;
		}
		x54366fa5f75a02f.x5152a5707921c783(num3, num4, MatrixOrder.Append);
		x54366fa5f75a02f.xa77087bb05d9ef76((float)x5770cdefd8931aa9.Rotation, MatrixOrder.Append);
		x54366fa5f75a02f.xce92de628aa023cf(num * num3, num2 * num4, MatrixOrder.Append);
		if (!x5770cdefd8931aa9.IsTopLevel)
		{
			x54366fa5f75a02f.xce92de628aa023cf((float)x5770cdefd8931aa9.Left, (float)x5770cdefd8931aa9.Top, MatrixOrder.Append);
		}
		return x54366fa5f75a02f;
	}
}
