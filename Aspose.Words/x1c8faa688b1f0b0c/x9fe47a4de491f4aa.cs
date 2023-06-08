using System.Collections;
using System.Drawing;

namespace x1c8faa688b1f0b0c;

internal struct x9fe47a4de491f4aa
{
	private PointF x92be23f9da255ff5;

	private PointF x361eac9a0ff32a3d;

	private PointF x66cd9622bea96696;

	private PointF x1eb0f2079082dc31;

	public PointF xaf4e0fbe61814cf5
	{
		get
		{
			return x92be23f9da255ff5;
		}
		set
		{
			x92be23f9da255ff5 = value;
		}
	}

	public PointF xc7cf0e43653f9c41
	{
		get
		{
			return x361eac9a0ff32a3d;
		}
		set
		{
			x361eac9a0ff32a3d = value;
		}
	}

	public PointF xf52fe1c3cad11afd
	{
		get
		{
			return x66cd9622bea96696;
		}
		set
		{
			x66cd9622bea96696 = value;
		}
	}

	public PointF x2271dea312f4a835
	{
		get
		{
			return x1eb0f2079082dc31;
		}
		set
		{
			x1eb0f2079082dc31 = value;
		}
	}

	public x9fe47a4de491f4aa(PointF quadP0, PointF quadP1, PointF quadP2)
	{
		x92be23f9da255ff5 = quadP0;
		x361eac9a0ff32a3d = new PointF(x9344bb0120371606(quadP0.X, quadP1.X), x9344bb0120371606(quadP0.Y, quadP1.Y));
		x66cd9622bea96696 = new PointF(x9344bb0120371606(quadP2.X, quadP1.X), x9344bb0120371606(quadP2.Y, quadP1.Y));
		x1eb0f2079082dc31 = quadP2;
	}

	private static float x9344bb0120371606(float x6dc6b09ecfb3d913, float x013a4ebaf606f55e)
	{
		return (x6dc6b09ecfb3d913 + 2f * x013a4ebaf606f55e) / 3f;
	}

	public x67293147609631f8[] xd3f5c72f5a1d6688()
	{
		return x6da6c77693819bd9(this);
	}

	private static x67293147609631f8[] x6da6c77693819bd9(x9fe47a4de491f4aa xadae7073f524691b)
	{
		ArrayList arrayList = new ArrayList();
		x21d347d46d4936d5(xadae7073f524691b, 4, arrayList);
		x67293147609631f8[] array = new x67293147609631f8[arrayList.Count];
		for (int i = 0; i < arrayList.Count; i++)
		{
			ref x67293147609631f8 reference = ref array[i];
			reference = x29ffb12adbf84140((x9fe47a4de491f4aa)arrayList[i]);
		}
		return array;
	}

	private static x67293147609631f8 x29ffb12adbf84140(x9fe47a4de491f4aa xadae7073f524691b)
	{
		x67293147609631f8 result = default(x67293147609631f8);
		result.xaf4e0fbe61814cf5 = xadae7073f524691b.xaf4e0fbe61814cf5;
		result.x2f997a78d547d657 = x54df8a837cb8697b(xadae7073f524691b.xc7cf0e43653f9c41, xadae7073f524691b.xf52fe1c3cad11afd);
		result.x2271dea312f4a835 = xadae7073f524691b.x2271dea312f4a835;
		return result;
	}

	private static void x21d347d46d4936d5(x9fe47a4de491f4aa xadae7073f524691b, int x903b3cb5afe8e46c, ArrayList x51efd71b3cdcbf9c)
	{
		x9fe47a4de491f4aa[] array = x1047a564b7994e93(xadae7073f524691b);
		if (x903b3cb5afe8e46c > 2)
		{
			int x903b3cb5afe8e46c2 = x903b3cb5afe8e46c / 2;
			x9fe47a4de491f4aa[] array2 = array;
			foreach (x9fe47a4de491f4aa xadae7073f524691b2 in array2)
			{
				x21d347d46d4936d5(xadae7073f524691b2, x903b3cb5afe8e46c2, x51efd71b3cdcbf9c);
			}
		}
		else
		{
			x9fe47a4de491f4aa[] array3 = array;
			foreach (x9fe47a4de491f4aa x9fe47a4de491f4aa2 in array3)
			{
				x51efd71b3cdcbf9c.Add(x9fe47a4de491f4aa2);
			}
		}
	}

	private static x9fe47a4de491f4aa[] x1047a564b7994e93(x9fe47a4de491f4aa xadae7073f524691b)
	{
		x9fe47a4de491f4aa[] array = new x9fe47a4de491f4aa[2];
		PointF x9b61de08eafdb = x54df8a837cb8697b(xadae7073f524691b.xaf4e0fbe61814cf5, xadae7073f524691b.xc7cf0e43653f9c41);
		PointF pointF = x54df8a837cb8697b(xadae7073f524691b.xc7cf0e43653f9c41, xadae7073f524691b.xf52fe1c3cad11afd);
		PointF x5bc3b3e534cfe6dc = x54df8a837cb8697b(xadae7073f524691b.xf52fe1c3cad11afd, xadae7073f524691b.x2271dea312f4a835);
		PointF x9b61de08eafdb2 = x54df8a837cb8697b(x9b61de08eafdb, pointF);
		PointF x5bc3b3e534cfe6dc2 = x54df8a837cb8697b(pointF, x5bc3b3e534cfe6dc);
		PointF pointF2 = x54df8a837cb8697b(x9b61de08eafdb2, x5bc3b3e534cfe6dc2);
		array[0] = default(x9fe47a4de491f4aa);
		array[0].xaf4e0fbe61814cf5 = xadae7073f524691b.xaf4e0fbe61814cf5;
		array[0].xc7cf0e43653f9c41 = x9b61de08eafdb;
		array[0].xf52fe1c3cad11afd = x9b61de08eafdb2;
		array[0].x2271dea312f4a835 = pointF2;
		array[1] = default(x9fe47a4de491f4aa);
		array[1].xaf4e0fbe61814cf5 = pointF2;
		array[1].xc7cf0e43653f9c41 = x5bc3b3e534cfe6dc2;
		array[1].xf52fe1c3cad11afd = x5bc3b3e534cfe6dc;
		array[1].x2271dea312f4a835 = xadae7073f524691b.x2271dea312f4a835;
		return array;
	}

	private static PointF x54df8a837cb8697b(PointF x9b61de08eafdb554, PointF x5bc3b3e534cfe6dc)
	{
		return new PointF((x9b61de08eafdb554.X + x5bc3b3e534cfe6dc.X) / 2f, (x9b61de08eafdb554.Y + x5bc3b3e534cfe6dc.Y) / 2f);
	}
}
