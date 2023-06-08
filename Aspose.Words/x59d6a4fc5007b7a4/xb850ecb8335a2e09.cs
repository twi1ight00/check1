using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using Aspose;
using Aspose.Words;
using x4adf554d20d941a6;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;

namespace x59d6a4fc5007b7a4;

internal class xb850ecb8335a2e09
{
	internal x398b3bd0acd94b61 xf54a8003057d59ef;

	internal readonly x398b3bd0acd94b61 x9fb0e9c0b1bdc4b3;

	private x54366fa5f75a02f7 x435b26849f0d2436;

	private object x933fbdb4e4f6c448;

	private object x51556d800a83de54;

	private object xa8548d289a49a30a;

	internal virtual PointF xc22eade24b085d91
	{
		get
		{
			return new PointF(x72d92bd1aff02e37, xe360b1885d8d4a41);
		}
		set
		{
			x72d92bd1aff02e37 = value.X;
			xe360b1885d8d4a41 = value.Y;
		}
	}

	internal virtual float x72d92bd1aff02e37
	{
		get
		{
			if (x933fbdb4e4f6c448 == null)
			{
				return x4574ea26106f0edb.xc96d70553223ee04(x9fb0e9c0b1bdc4b3.x8df91a2f90079e88);
			}
			return (float)x933fbdb4e4f6c448;
		}
		set
		{
			x933fbdb4e4f6c448 = value;
		}
	}

	[JavaThrows(true)]
	internal virtual float xe360b1885d8d4a41
	{
		get
		{
			if (x51556d800a83de54 == null)
			{
				return x4574ea26106f0edb.xc96d70553223ee04(x9fb0e9c0b1bdc4b3.xc821290d7ecc08bf);
			}
			return (float)x51556d800a83de54;
		}
		set
		{
			x51556d800a83de54 = value;
		}
	}

	internal virtual float xdc1bf80853046136 => x4574ea26106f0edb.xc96d70553223ee04(x9fb0e9c0b1bdc4b3.xdc1bf80853046136);

	internal virtual float xb0f146032f47c24e => x4574ea26106f0edb.xc96d70553223ee04(x9fb0e9c0b1bdc4b3.xb0f146032f47c24e);

	internal RectangleF xa07a9457a2ebbbfc => new RectangleF(x72d92bd1aff02e37, xe360b1885d8d4a41, xdc1bf80853046136, xb0f146032f47c24e);

	[JavaThrows(true)]
	internal virtual RectangleF x0e1bf8242ad10272
	{
		get
		{
			if (xa8548d289a49a30a == null)
			{
				xa8548d289a49a30a = new RectangleF(-1584f, -1584f, 3168f, 3168f);
			}
			return (RectangleF)xa8548d289a49a30a;
		}
		set
		{
			xa8548d289a49a30a = value;
		}
	}

	internal x54366fa5f75a02f7 xaccac17571a8d9fa
	{
		get
		{
			return x435b26849f0d2436;
		}
		set
		{
			x435b26849f0d2436 = value;
		}
	}

	internal xb850ecb8335a2e09(x398b3bd0acd94b61 part)
	{
		x9fb0e9c0b1bdc4b3 = part;
	}

	[JavaThrows(true)]
	internal virtual void x7012609bcdb39574(x3adba2572f6b9747 x672ff13faf031f3d)
	{
	}

	internal static void xa246eb87eda7b55d(x3adba2572f6b9747 x672ff13faf031f3d, x398b3bd0acd94b61 xd7e5673853e47af4)
	{
		while (xd7e5673853e47af4 != null)
		{
			x398b3bd0acd94b61 x398b3bd0acd94b = x9445729c314bb80f(xd7e5673853e47af4);
			if (x398b3bd0acd94b != xd7e5673853e47af4)
			{
				xd7e5673853e47af4 = x398b3bd0acd94b;
				continue;
			}
			x954503abc583f675 x954503abc583f = xd7e5673853e47af4.x954503abc583f675;
			xb850ecb8335a2e09 xb850ecb8335a2e10 = ((x954503abc583f != x954503abc583f675.x48cc0c3eaf9f5f05) ? ((xb850ecb8335a2e09)new xa68c54b19fa2b58c(xd7e5673853e47af4)) : ((xb850ecb8335a2e09)new xbf5b03855bcdbdae(xd7e5673853e47af4)));
			xb850ecb8335a2e10.x7012609bcdb39574(x672ff13faf031f3d);
			xd7e5673853e47af4 = xb850ecb8335a2e10.xf54a8003057d59ef;
		}
	}

	internal static void xa0d387f9dc55e84f(x3adba2572f6b9747 x672ff13faf031f3d, xd4c1d21f07094800 x9b3f1d96a5b5faee)
	{
		if (x9b3f1d96a5b5faee == null)
		{
			return;
		}
		for (int i = 0; i < x9b3f1d96a5b5faee.xd44988f225497f3a; i++)
		{
			x109e3389933c23a8 x109e3389933c23a = x9b3f1d96a5b5faee.xaadb22af27962896(i);
			if (x109e3389933c23a.xbd46d5308b22d9fd || x109e3389933c23a.xf8c20af9fe5edca0 == 25604)
			{
				continue;
			}
			xb850ecb8335a2e09 xb850ecb8335a2e10 = new xb850ecb8335a2e09(x109e3389933c23a.x38ced5a01a389303);
			xb850ecb8335a2e10.xaccac17571a8d9fa = new x54366fa5f75a02f7();
			RectangleF rectangleF = x4574ea26106f0edb.xc96d70553223ee04(x109e3389933c23a.x6ae4612a8469678e);
			if (x109e3389933c23a.x705ed5f9769744e5.x01bc5527a261f633)
			{
				float num = ((x109e3389933c23a.x705ed5f9769744e5.x2c5926113e101674 == TextOrientation.Upward) ? (-90) : 90);
				xb850ecb8335a2e10.xaccac17571a8d9fa.xa77087bb05d9ef76(num, MatrixOrder.Append);
				if (num > 0f)
				{
					xb850ecb8335a2e10.xaccac17571a8d9fa.xce92de628aa023cf(rectangleF.Width, 0f, MatrixOrder.Append);
				}
				else
				{
					xb850ecb8335a2e10.xaccac17571a8d9fa.xce92de628aa023cf(0f, rectangleF.Height, MatrixOrder.Append);
				}
			}
			xb850ecb8335a2e10.xaccac17571a8d9fa.xce92de628aa023cf(rectangleF.X, rectangleF.Y, MatrixOrder.Append);
			x672ff13faf031f3d.xdfc9ad174ecab9eb(xb850ecb8335a2e10);
			x398b3bd0acd94b61 x398b3bd0acd94b = x109e3389933c23a.xed3e432f7c9bf846.xf34a54c031e96d83();
			x398b3bd0acd94b61 x398b3bd0acd94b2 = x109e3389933c23a.x38ced5a01a389303;
			while (x398b3bd0acd94b2 != x398b3bd0acd94b)
			{
				PointF pointF = x4574ea26106f0edb.xc96d70553223ee04(new Point(x398b3bd0acd94b2.x8df91a2f90079e88, x398b3bd0acd94b2.xc821290d7ecc08bf));
				xb850ecb8335a2e09 xb850ecb8335a2e11;
				switch (x109e3389933c23a.xf8c20af9fe5edca0)
				{
				case 25604:
					throw new InvalidOperationException();
				case 21595:
					xb850ecb8335a2e11 = new xa68c54b19fa2b58c(x398b3bd0acd94b2);
					x398b3bd0acd94b2 = x398b3bd0acd94b;
					break;
				default:
					if (x398b3bd0acd94b2.x954503abc583f675 == x954503abc583f675.x48cc0c3eaf9f5f05)
					{
						xb850ecb8335a2e11 = new xbf5b03855bcdbdae(x398b3bd0acd94b2);
						x398b3bd0acd94b2 = x398b3bd0acd94b2.x332a8eedb847940d.x7e2e5dd40daabc3b;
					}
					else
					{
						xb850ecb8335a2e11 = new xa68c54b19fa2b58c(x398b3bd0acd94b2);
						x398b3bd0acd94b2 = ((x694f001896973fe3)x398b3bd0acd94b2).x838c6c67b5953bb0.x133f2db9e5b5690d.xbc3a1ad7f75a88f9.xbc3a1ad7f75a88f9;
					}
					x398b3bd0acd94b2 = x398b3bd0acd94b2.xf34a54c031e96d83();
					break;
				}
				xb850ecb8335a2e11.xc22eade24b085d91 = pointF;
				xb850ecb8335a2e11.x7012609bcdb39574(x672ff13faf031f3d);
			}
			x672ff13faf031f3d.x3bd3c50d2c5e3ad7(xb850ecb8335a2e10);
		}
	}

	private static x398b3bd0acd94b61 x9445729c314bb80f(x398b3bd0acd94b61 xd7e5673853e47af4)
	{
		if (!xa7a98231d4a67a0f.xdd724c73394f5594(xd7e5673853e47af4))
		{
			return xd7e5673853e47af4;
		}
		return ((x3d1ad8ce75f0db3a)xd7e5673853e47af4.xc255c495fd9232ca).x556327bb6ae40c9e(xd7e5673853e47af4);
	}
}
