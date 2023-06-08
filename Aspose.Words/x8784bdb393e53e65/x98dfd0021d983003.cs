using System.Collections;
using System.Drawing;
using x5794c252ba25e723;
using x996431aaaaf00543;

namespace x8784bdb393e53e65;

internal class x98dfd0021d983003 : xe6a3cd72932c03df
{
	public RectangleF xf826e069ce77642d(ArrayList x038de6326e825e2f)
	{
		if (x038de6326e825e2f.Count == 0)
		{
			return default(RectangleF);
		}
		PointF[] xe879760fea4dbedc = x0948e2deeec3ae64(x038de6326e825e2f);
		return x59f5c51015d4d2c2(xe879760fea4dbedc);
	}

	public RectangleF xf826e069ce77642d(x78e18bdf9a108059 x59b69f1c3bf7c3e9)
	{
		PointF[] array = new PointF[4];
		x8bf25db5cd25faad(array, 0, x59b69f1c3bf7c3e9);
		return x59f5c51015d4d2c2(array);
	}

	private static void x8bf25db5cd25faad(PointF[] x6fa2570084b2ad39, int x77a4be227aff1505, x78e18bdf9a108059 x59b69f1c3bf7c3e9)
	{
		ref PointF reference = ref x6fa2570084b2ad39[x77a4be227aff1505];
		reference = new PointF((float)x59b69f1c3bf7c3e9.x8df91a2f90079e88, (float)x59b69f1c3bf7c3e9.xc821290d7ecc08bf);
		ref PointF reference2 = ref x6fa2570084b2ad39[x77a4be227aff1505 + 1];
		reference2 = new PointF((float)(x59b69f1c3bf7c3e9.x8df91a2f90079e88 + x59b69f1c3bf7c3e9.xdc1bf80853046136), (float)x59b69f1c3bf7c3e9.xc821290d7ecc08bf);
		ref PointF reference3 = ref x6fa2570084b2ad39[x77a4be227aff1505 + 2];
		reference3 = new PointF((float)(x59b69f1c3bf7c3e9.x8df91a2f90079e88 + x59b69f1c3bf7c3e9.xdc1bf80853046136), (float)(x59b69f1c3bf7c3e9.xc821290d7ecc08bf + x59b69f1c3bf7c3e9.x1be93eed8950d961));
		ref PointF reference4 = ref x6fa2570084b2ad39[x77a4be227aff1505 + 3];
		reference4 = new PointF((float)x59b69f1c3bf7c3e9.x8df91a2f90079e88, (float)(x59b69f1c3bf7c3e9.xc821290d7ecc08bf + x59b69f1c3bf7c3e9.x1be93eed8950d961));
		x54366fa5f75a02f7 x54366fa5f75a02f = x59b69f1c3bf7c3e9.CreateRotateFlipTransformation();
		x54366fa5f75a02f.xa4b699bd47eb7372(x6fa2570084b2ad39, x77a4be227aff1505, 4);
	}

	private PointF[] x0948e2deeec3ae64(ArrayList x038de6326e825e2f)
	{
		PointF[] array = new PointF[x038de6326e825e2f.Count * 4];
		for (int i = 0; i < x038de6326e825e2f.Count; i++)
		{
			x18041b360bf02656 x18041b360bf = (x18041b360bf02656)x038de6326e825e2f[i];
			int x77a4be227aff = i * 4;
			x8bf25db5cd25faad(array, x77a4be227aff, x18041b360bf.GetTransform());
		}
		return array;
	}

	private RectangleF x59f5c51015d4d2c2(PointF[] xe879760fea4dbedc)
	{
		if (xe879760fea4dbedc.Length == 0)
		{
			return default(RectangleF);
		}
		float x = xe879760fea4dbedc[0].X;
		float x2 = xe879760fea4dbedc[0].X;
		float y = xe879760fea4dbedc[0].Y;
		float y2 = xe879760fea4dbedc[0].Y;
		for (int i = 0; i < xe879760fea4dbedc.Length; i++)
		{
			PointF pointF = xe879760fea4dbedc[i];
			if (pointF.X < x)
			{
				x = pointF.X;
			}
			else if (pointF.X > x2)
			{
				x2 = pointF.X;
			}
			if (pointF.Y < y)
			{
				y = pointF.Y;
			}
			else if (pointF.Y > y2)
			{
				y2 = pointF.Y;
			}
		}
		return new RectangleF(x, y, x2 - x, y2 - y);
	}
}
