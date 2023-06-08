using System.Drawing;
using Aspose.Words;
using Aspose.Words.Drawing;
using x1c8faa688b1f0b0c;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;

namespace x3d94286fe72124a8;

internal class x77e280b75b2323b7
{
	private float xbacf01351a7abde7;

	private float x7fd2c9eaff9eeb64;

	private float xc83c3dc19dabc3fa;

	private float x28424f25b3a830a6;

	internal static RectangleF xae3e25d147fd1867(x7721ad963b03c6eb x8d3f74e5f925679c, xb8e7e788f6d59708 x08ce8f4769eb3234)
	{
		x77e280b75b2323b7 x77e280b75b2323b8 = new x77e280b75b2323b7();
		return x77e280b75b2323b8.x33088749588f5eaa(x8d3f74e5f925679c, x08ce8f4769eb3234);
	}

	private RectangleF x33088749588f5eaa(x7721ad963b03c6eb x8d3f74e5f925679c, xb8e7e788f6d59708 x08ce8f4769eb3234)
	{
		PointF[] xe879760fea4dbedc = xa15db86d8764e648(x8d3f74e5f925679c, x08ce8f4769eb3234);
		if (x8d3f74e5f925679c.xa9993ed2e0c64574.ShapeType != ShapeType.Group)
		{
			xe33e09e296b755ab(x8d3f74e5f925679c, xe879760fea4dbedc);
		}
		xae0714000a67184e(xe879760fea4dbedc);
		return new RectangleF(xbacf01351a7abde7, xc83c3dc19dabc3fa, x7fd2c9eaff9eeb64 - xbacf01351a7abde7, x28424f25b3a830a6 - xc83c3dc19dabc3fa);
	}

	private static PointF[] xa15db86d8764e648(x7721ad963b03c6eb x8d3f74e5f925679c, xb8e7e788f6d59708 x08ce8f4769eb3234)
	{
		RectangleF rectangleF;
		if (x8d3f74e5f925679c.xa9993ed2e0c64574.ShapeType == ShapeType.Group)
		{
			rectangleF = x093776ce9c765449(x08ce8f4769eb3234);
			PointF[] array = x37d2d88f96f87b47.x73aa13730a957b6c(x52df58faf21fc20a(x8d3f74e5f925679c));
			xe33e09e296b755ab(x8d3f74e5f925679c, array);
			rectangleF = ((rectangleF == RectangleF.Empty) ? x52df58faf21fc20a(x8d3f74e5f925679c) : x37d2d88f96f87b47.xb79f5c307f99b920(rectangleF, x37d2d88f96f87b47.x37b1dbbad6246778(array)));
			return x37d2d88f96f87b47.x73aa13730a957b6c(rectangleF);
		}
		rectangleF = x52df58faf21fc20a(x8d3f74e5f925679c);
		Shape shape = (Shape)x8d3f74e5f925679c.xa9993ed2e0c64574;
		float left = rectangleF.Left;
		float top = rectangleF.Top;
		float right = rectangleF.Right;
		float bottom = rectangleF.Bottom;
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
		float num4 = 0f;
		Stroke stroke = shape.Stroke;
		bool flag = x7ad8b429df4d1783.xbcb10825d2277113(shape);
		if (stroke.On)
		{
			num = (float)stroke.Weight;
			num2 = num;
			num3 = num;
			num4 = num;
		}
		else if (flag)
		{
			BorderCollection borders = shape.ImageData.Borders;
			Border border = borders[BorderType.Top];
			Border border2 = borders[BorderType.Left];
			Border border3 = borders[BorderType.Right];
			Border border4 = borders[BorderType.Bottom];
			num = ((border.IsVisible && !x8d3f74e5f925679c.x2cd066fdf892c9fb) ? border.xeae235558dc44397 : 0f);
			num2 = ((border4.IsVisible && !x8d3f74e5f925679c.x6ffa01a29fd5c940) ? border4.xeae235558dc44397 : 0f);
			num3 = ((border2.IsVisible && !x8d3f74e5f925679c.x3e68ffe1419e6481) ? border2.xeae235558dc44397 : 0f);
			num4 = ((border3.IsVisible && !x8d3f74e5f925679c.x7d3f5b36733451fa) ? border3.xeae235558dc44397 : 0f);
		}
		float num5 = (flag ? 1f : 0.5f);
		left -= num3 * num5;
		top -= num * num5;
		right += num4 * num5;
		bottom += num2 * num5;
		return new PointF[4]
		{
			new PointF(left, top),
			new PointF(right, top),
			new PointF(right, bottom),
			new PointF(left, bottom)
		};
	}

	private static RectangleF x093776ce9c765449(xb8e7e788f6d59708 x08ce8f4769eb3234)
	{
		x8abed58e51c8641c x8abed58e51c8641c = new x8abed58e51c8641c();
		return x8abed58e51c8641c.xb1de1ba20faeeff8(x08ce8f4769eb3234);
	}

	private static RectangleF x52df58faf21fc20a(x7721ad963b03c6eb x8d3f74e5f925679c)
	{
		float width;
		float height;
		if (x8d3f74e5f925679c.x178374f0600f2696.IsEmpty)
		{
			SizeF sizeInPoints = x8d3f74e5f925679c.xa9993ed2e0c64574.SizeInPoints;
			width = sizeInPoints.Width;
			height = sizeInPoints.Height;
		}
		else
		{
			RectangleF rectangleF = x8d3f74e5f925679c.xa9993ed2e0c64574.xdd95551ca745bb85(new RectangleF(0f, 0f, x8d3f74e5f925679c.x178374f0600f2696.Width, x8d3f74e5f925679c.x178374f0600f2696.Height));
			width = rectangleF.Width;
			height = rectangleF.Height;
		}
		return new RectangleF(0f, 0f, width, height);
	}

	private static void xe33e09e296b755ab(x7721ad963b03c6eb x8d3f74e5f925679c, PointF[] xe879760fea4dbedc)
	{
		x54366fa5f75a02f7 x54366fa5f75a02f = new x54366fa5f75a02f7();
		double xb494f7568f = x8d3f74e5f925679c.xa9993ed2e0c64574.xb494f7568f103233;
		PointF pointF = xe879760fea4dbedc[0];
		PointF pointF2 = xe879760fea4dbedc[2];
		if (xb494f7568f != 0.0)
		{
			x54366fa5f75a02f.x49d618948c467be6((float)xb494f7568f, new PointF(pointF.X + (pointF2.X - pointF.X) * 0.5f, pointF.Y + (pointF2.Y - pointF.Y) * 0.5f));
		}
		x54366fa5f75a02f.xa4b699bd47eb7372(xe879760fea4dbedc);
	}

	private void xae0714000a67184e(PointF[] xe879760fea4dbedc)
	{
		xbacf01351a7abde7 = xe879760fea4dbedc[0].X;
		xc83c3dc19dabc3fa = xe879760fea4dbedc[0].Y;
		x7fd2c9eaff9eeb64 = xbacf01351a7abde7;
		x28424f25b3a830a6 = xc83c3dc19dabc3fa;
		for (int i = 0; i < 4; i++)
		{
			PointF pointF = xe879760fea4dbedc[i];
			if (pointF.X < xbacf01351a7abde7)
			{
				xbacf01351a7abde7 = pointF.X;
			}
			else if (pointF.X > x7fd2c9eaff9eeb64)
			{
				x7fd2c9eaff9eeb64 = pointF.X;
			}
			if (pointF.Y < xc83c3dc19dabc3fa)
			{
				xc83c3dc19dabc3fa = pointF.Y;
			}
			else if (pointF.Y > x28424f25b3a830a6)
			{
				x28424f25b3a830a6 = pointF.Y;
			}
		}
	}
}
