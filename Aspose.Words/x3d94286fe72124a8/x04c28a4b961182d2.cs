using System;
using System.Drawing;
using Aspose.Words;
using Aspose.Words.Drawing;
using x011d489fb9df7027;
using x13f1efc79617a47b;
using x6c95d9cf46ff5f25;

namespace x3d94286fe72124a8;

internal class x04c28a4b961182d2
{
	internal static void x4fe2e6db635d321d(xa37343ccb8cd8c70 x0f7b23d1c393aed9)
	{
		if (x0f7b23d1c393aed9.xa9993ed2e0c64574 == null)
		{
			throw new ArgumentNullException();
		}
		Shape xa9993ed2e0c = x0f7b23d1c393aed9.xa9993ed2e0c64574;
		int[] array = x5fed11ea6295c1d5(xa9993ed2e0c);
		x08d932077485c285[] xdbed53246e7dd53a = xa9993ed2e0c.xdbed53246e7dd53a;
		PointF[] array2 = new PointF[1] { PointF.Empty };
		if (xdbed53246e7dd53a != null)
		{
			array2 = new PointF[xdbed53246e7dd53a.Length];
			for (int i = 0; i < xdbed53246e7dd53a.Length; i++)
			{
				x08d932077485c285 x08d932077485c = xdbed53246e7dd53a[i];
				int num = x08d932077485c.x8df91a2f90079e88.xd2f68ee6f47e9dfb;
				int num2 = x08d932077485c.xc821290d7ecc08bf.xd2f68ee6f47e9dfb;
				if (array != null)
				{
					if (x08d932077485c.x8df91a2f90079e88.x11f06dbf14c9ade8)
					{
						num = array[x08d932077485c.x8df91a2f90079e88.xd2f68ee6f47e9dfb];
					}
					if (x08d932077485c.xc821290d7ecc08bf.x11f06dbf14c9ade8)
					{
						num2 = array[x08d932077485c.xc821290d7ecc08bf.xd2f68ee6f47e9dfb];
					}
				}
				ref PointF reference = ref array2[i];
				reference = new PointF(num, num2);
			}
		}
		x0f7b23d1c393aed9.x22346b9b537191fa = x1afb9760911ef360(xa9993ed2e0c, array);
		x5e4d9bea8d26a1d0(x0f7b23d1c393aed9, array2);
	}

	private static RectangleF x1afb9760911ef360(Shape x5770cdefd8931aa9, int[] xfa523b911e124475)
	{
		bool flag = x2f50861482c5f2b5(x5770cdefd8931aa9);
		xbc9979937c838d75[] x055ad2518a1ca81c = x5770cdefd8931aa9.x055ad2518a1ca81c;
		return x055ad2518a1ca81c.Length switch
		{
			1 => x03cb6e00f56e1288(x055ad2518a1ca81c[0], xfa523b911e124475), 
			2 => x03cb6e00f56e1288(flag ? x055ad2518a1ca81c[0] : x055ad2518a1ca81c[3], xfa523b911e124475), 
			3 => x1604a8bb5b05c58d(x5770cdefd8931aa9, x055ad2518a1ca81c, xfa523b911e124475), 
			6 => x1604a8bb5b05c58d(x5770cdefd8931aa9, x055ad2518a1ca81c, xfa523b911e124475), 
			_ => new RectangleF(0f, 0f, x5770cdefd8931aa9.x133d653c1b9b01f2, x5770cdefd8931aa9.xc97e136f0019c237), 
		};
	}

	private static RectangleF x1604a8bb5b05c58d(Shape x5770cdefd8931aa9, xbc9979937c838d75[] x09d9444f882ac964, int[] xfa523b911e124475)
	{
		int num = 0;
		if (x09d9444f882ac964.Length == 6 && !x2f50861482c5f2b5(x5770cdefd8931aa9))
		{
			num = 3;
		}
		if (x5770cdefd8931aa9.x89e0f1069b9786a1 == null || x5770cdefd8931aa9.x89e0f1069b9786a1.Length == 0)
		{
			return x03cb6e00f56e1288(x09d9444f882ac964[num], xfa523b911e124475);
		}
		x7efbe0a2dc0d335f x7efbe0a2dc0d335f = x5770cdefd8931aa9.x89e0f1069b9786a1[0];
		int num2 = x5770cdefd8931aa9.x9036b7becf593874(1);
		float num3;
		float num4;
		if (x7efbe0a2dc0d335f.x3b1bddb38a858693.x3146d638ec378671 == xc548449aaa21fea5.xfaab97dd0218026f && x7efbe0a2dc0d335f.x3b1bddb38a858693.xd2f68ee6f47e9dfb == 0)
		{
			num3 = x665810f5089c5cac(x7efbe0a2dc0d335f.x9462c8df936efa39, xfa523b911e124475);
			num4 = x665810f5089c5cac(x7efbe0a2dc0d335f.x11f73230b9b436a7, xfa523b911e124475);
		}
		else
		{
			num3 = x665810f5089c5cac(x7efbe0a2dc0d335f.x5b051452efe1bbe3, xfa523b911e124475);
			num4 = x665810f5089c5cac(x7efbe0a2dc0d335f.xbed6b6abe5a7fcce, xfa523b911e124475);
		}
		float num5 = num3 + (num4 - num3) / 2f;
		RectangleF x6dff41da97c6ea6c;
		RectangleF x4b26934ffbb138ec;
		float x0e8d64ad39a2867f;
		if ((float)num2 < num5)
		{
			x6dff41da97c6ea6c = x03cb6e00f56e1288(x09d9444f882ac964[num], xfa523b911e124475);
			x4b26934ffbb138ec = x03cb6e00f56e1288(x09d9444f882ac964[num + 1], xfa523b911e124475);
			x0e8d64ad39a2867f = x7b384931baeb1cfe(num3, num5, num2);
		}
		else
		{
			x6dff41da97c6ea6c = x03cb6e00f56e1288(x09d9444f882ac964[num + 1], xfa523b911e124475);
			x4b26934ffbb138ec = x03cb6e00f56e1288(x09d9444f882ac964[num + 2], xfa523b911e124475);
			x0e8d64ad39a2867f = x7b384931baeb1cfe(num5, num4, (float)num2 - num5);
		}
		return x6549c64ab4494ad5(x6dff41da97c6ea6c, x4b26934ffbb138ec, x0e8d64ad39a2867f);
	}

	private static bool x2f50861482c5f2b5(Shape x5770cdefd8931aa9)
	{
		if (x5770cdefd8931aa9.TextBox.LayoutFlow != 0)
		{
			return x5770cdefd8931aa9.TextBox.LayoutFlow == LayoutFlow.HorizontalIdeographic;
		}
		return true;
	}

	private static float x7b384931baeb1cfe(float xd088075e67f6ea91, float xffd6352b2e5d70e3, float xb78174440fd3d329)
	{
		return xb78174440fd3d329 / (xffd6352b2e5d70e3 - xd088075e67f6ea91);
	}

	private static RectangleF x6549c64ab4494ad5(RectangleF x6dff41da97c6ea6c, RectangleF x4b26934ffbb138ec, float x0e8d64ad39a2867f)
	{
		float num = x9155d9b03e4a9fbb(x6dff41da97c6ea6c.X, x4b26934ffbb138ec.X, x0e8d64ad39a2867f);
		float num2 = x9155d9b03e4a9fbb(x6dff41da97c6ea6c.Y, x4b26934ffbb138ec.Y, x0e8d64ad39a2867f);
		float width = x9155d9b03e4a9fbb(x6dff41da97c6ea6c.Right, x4b26934ffbb138ec.Right, x0e8d64ad39a2867f) - num;
		float height = x9155d9b03e4a9fbb(x6dff41da97c6ea6c.Bottom, x4b26934ffbb138ec.Bottom, x0e8d64ad39a2867f) - num2;
		return new RectangleF(num, num2, width, height);
	}

	private static float x9155d9b03e4a9fbb(float xd088075e67f6ea91, float xffd6352b2e5d70e3, float x0e8d64ad39a2867f)
	{
		return xd088075e67f6ea91 + (xffd6352b2e5d70e3 - xd088075e67f6ea91) * x0e8d64ad39a2867f;
	}

	private static RectangleF x03cb6e00f56e1288(xbc9979937c838d75 x0d1d762ec380db87, int[] xfa523b911e124475)
	{
		float num = xd5f40653dad2b6bb(x0d1d762ec380db87.x72d92bd1aff02e37, xfa523b911e124475);
		float num2 = xd5f40653dad2b6bb(x0d1d762ec380db87.xe360b1885d8d4a41, xfa523b911e124475);
		float width = xd5f40653dad2b6bb(x0d1d762ec380db87.x419ba17a5322627b, xfa523b911e124475) - num;
		float height = xd5f40653dad2b6bb(x0d1d762ec380db87.x9bcb07e204e30218, xfa523b911e124475) - num2;
		return new RectangleF(num, num2, width, height);
	}

	private static void x5e4d9bea8d26a1d0(xa37343ccb8cd8c70 x0f7b23d1c393aed9, PointF[] x130960a25431bacb)
	{
		switch (x0f7b23d1c393aed9.xa9993ed2e0c64574.ShapeType)
		{
		case ShapeType.Rectangle:
			x0076a6bcbcf0eda9(x0f7b23d1c393aed9);
			break;
		case ShapeType.RoundRectangle:
		{
			Size coordSize = x0f7b23d1c393aed9.xa9993ed2e0c64574.CoordSize;
			int num = x0f7b23d1c393aed9.xa9993ed2e0c64574.x9036b7becf593874(1);
			if (num == 0)
			{
				x0076a6bcbcf0eda9(x0f7b23d1c393aed9);
			}
			else
			{
				x7d80b47b4639d6a0(x0f7b23d1c393aed9, num, coordSize);
			}
			break;
		}
		case ShapeType.Ellipse:
			x0f7b23d1c393aed9.x22346b9b537191fa = xfe86f193b918ca9c(x0f7b23d1c393aed9);
			break;
		case ShapeType.Line:
			x1ea20439627372a8(x0f7b23d1c393aed9);
			break;
		default:
			x0f7b23d1c393aed9.xdb6e255971c32d6d = x0f7b23d1c393aed9.xa9993ed2e0c64574.xa31cfc0117535bfa;
			x0f7b23d1c393aed9.xdbed53246e7dd53a = x130960a25431bacb;
			break;
		}
	}

	private static void x0076a6bcbcf0eda9(xa37343ccb8cd8c70 x0f7b23d1c393aed9)
	{
		Size coordSize = x0f7b23d1c393aed9.xa9993ed2e0c64574.CoordSize;
		x0f7b23d1c393aed9.xdb6e255971c32d6d = new x44f2b8bf33b16275[3];
		x0f7b23d1c393aed9.xdb6e255971c32d6d[0] = new x44f2b8bf33b16275(x4dd8a59ec8974a5f.x01b2723108ff3dfe, 0);
		x0f7b23d1c393aed9.xdb6e255971c32d6d[1] = new x44f2b8bf33b16275(x4dd8a59ec8974a5f.xd0baff30d99dc152, 3);
		x0f7b23d1c393aed9.xdbed53246e7dd53a = new PointF[4]
		{
			PointF.Empty,
			PointF.Empty,
			PointF.Empty,
			PointF.Empty
		};
		ref PointF reference = ref x0f7b23d1c393aed9.xdbed53246e7dd53a[0];
		reference = new PointF(0f, 0f);
		ref PointF reference2 = ref x0f7b23d1c393aed9.xdbed53246e7dd53a[1];
		reference2 = new PointF(coordSize.Width, 0f);
		ref PointF reference3 = ref x0f7b23d1c393aed9.xdbed53246e7dd53a[2];
		reference3 = new PointF(coordSize.Width, coordSize.Height);
		ref PointF reference4 = ref x0f7b23d1c393aed9.xdbed53246e7dd53a[3];
		reference4 = new PointF(0f, coordSize.Height);
		x0f7b23d1c393aed9.xdb6e255971c32d6d[2] = new x44f2b8bf33b16275(x4dd8a59ec8974a5f.x8ffe90e7fbccfccd, 0);
	}

	private static void x1ea20439627372a8(xa37343ccb8cd8c70 x0f7b23d1c393aed9)
	{
		Size coordSize = x0f7b23d1c393aed9.xa9993ed2e0c64574.CoordSize;
		x0f7b23d1c393aed9.xdb6e255971c32d6d = new x44f2b8bf33b16275[2];
		x0f7b23d1c393aed9.xdb6e255971c32d6d[0] = new x44f2b8bf33b16275(x4dd8a59ec8974a5f.x01b2723108ff3dfe, 0);
		x0f7b23d1c393aed9.xdb6e255971c32d6d[1] = new x44f2b8bf33b16275(x4dd8a59ec8974a5f.xd0baff30d99dc152, 1);
		x0f7b23d1c393aed9.xdbed53246e7dd53a = new PointF[2]
		{
			PointF.Empty,
			PointF.Empty
		};
		ref PointF reference = ref x0f7b23d1c393aed9.xdbed53246e7dd53a[1];
		reference = new PointF(coordSize.Width, coordSize.Height);
	}

	private static RectangleF xfe86f193b918ca9c(xa37343ccb8cd8c70 x0f7b23d1c393aed9)
	{
		Size coordSize = x0f7b23d1c393aed9.xa9993ed2e0c64574.CoordSize;
		x0f7b23d1c393aed9.xdb6e255971c32d6d = new x44f2b8bf33b16275[2];
		x0f7b23d1c393aed9.xdb6e255971c32d6d[0] = new x44f2b8bf33b16275(x4dd8a59ec8974a5f.x8dc4eedb9f218057, 3);
		x0f7b23d1c393aed9.xdbed53246e7dd53a = new PointF[3]
		{
			PointF.Empty,
			PointF.Empty,
			PointF.Empty
		};
		float x = (float)coordSize.Width * 0.5f;
		float y = (float)coordSize.Height * 0.5f;
		ref PointF reference = ref x0f7b23d1c393aed9.xdbed53246e7dd53a[0];
		reference = new PointF(x, y);
		ref PointF reference2 = ref x0f7b23d1c393aed9.xdbed53246e7dd53a[1];
		reference2 = new PointF(x, y);
		ref PointF reference3 = ref x0f7b23d1c393aed9.xdbed53246e7dd53a[2];
		reference3 = new PointF(0f, -23592960f);
		x0f7b23d1c393aed9.xdb6e255971c32d6d[1] = new x44f2b8bf33b16275(x4dd8a59ec8974a5f.x8ffe90e7fbccfccd, 0);
		return x7ea38cc8ad518161(coordSize);
	}

	private static RectangleF x7ea38cc8ad518161(Size x0ceec69a97f73617)
	{
		float num = (float)x0ceec69a97f73617.Height / (float)x0ceec69a97f73617.Width;
		float num2 = (float)x0ceec69a97f73617.Width * 0.5f;
		float num3 = (float)x0ceec69a97f73617.Height * 0.5f;
		float num4 = num3 * num3;
		float num5 = num2 * num2;
		float num6 = (float)Math.Sqrt(num5 * num4 / (num4 + num * num * num5));
		float num7 = num * num6;
		float num8 = 0f - num6;
		float num9 = num * num8;
		PointF location = new PointF(num8 + num2, num9 + num3);
		PointF pointF = new PointF(num6 + num2, num7 + num3);
		return new RectangleF(size: new SizeF(pointF.X - location.X, pointF.Y - location.Y), location: location);
	}

	private static void x7d80b47b4639d6a0(xa37343ccb8cd8c70 x0f7b23d1c393aed9, int x5cbe79ee0656575d, Size x931b9f2b029e19c2)
	{
		int num;
		int num2;
		if (x0f7b23d1c393aed9.x1f2f266ad77d3736.Width > x0f7b23d1c393aed9.x1f2f266ad77d3736.Height)
		{
			num = x5cbe79ee0656575d;
			num2 = (int)(x0f7b23d1c393aed9.x1f2f266ad77d3736.Height / x0f7b23d1c393aed9.x1f2f266ad77d3736.Width * (float)x5cbe79ee0656575d);
		}
		else
		{
			num2 = x5cbe79ee0656575d;
			num = (int)(x0f7b23d1c393aed9.x1f2f266ad77d3736.Width / x0f7b23d1c393aed9.x1f2f266ad77d3736.Height * (float)x5cbe79ee0656575d);
		}
		x0f7b23d1c393aed9.xdb6e255971c32d6d = new x44f2b8bf33b16275[10];
		x0f7b23d1c393aed9.xdbed53246e7dd53a = new PointF[8]
		{
			PointF.Empty,
			PointF.Empty,
			PointF.Empty,
			PointF.Empty,
			PointF.Empty,
			PointF.Empty,
			PointF.Empty,
			PointF.Empty
		};
		x0f7b23d1c393aed9.xdb6e255971c32d6d[0] = new x44f2b8bf33b16275(x4dd8a59ec8974a5f.x01b2723108ff3dfe, 0);
		ref PointF reference = ref x0f7b23d1c393aed9.xdbed53246e7dd53a[0];
		reference = new PointF(0f, num);
		x0f7b23d1c393aed9.xdb6e255971c32d6d[1] = new x44f2b8bf33b16275(x4dd8a59ec8974a5f.xbfb6f7deb7122782, 1);
		ref PointF reference2 = ref x0f7b23d1c393aed9.xdbed53246e7dd53a[1];
		reference2 = new PointF(num2, 0f);
		x0f7b23d1c393aed9.xdb6e255971c32d6d[2] = new x44f2b8bf33b16275(x4dd8a59ec8974a5f.xd0baff30d99dc152, 1);
		ref PointF reference3 = ref x0f7b23d1c393aed9.xdbed53246e7dd53a[2];
		reference3 = new PointF(x931b9f2b029e19c2.Width - num2, 0f);
		x0f7b23d1c393aed9.xdb6e255971c32d6d[3] = new x44f2b8bf33b16275(x4dd8a59ec8974a5f.xb9fb25f53beaeb97, 1);
		ref PointF reference4 = ref x0f7b23d1c393aed9.xdbed53246e7dd53a[3];
		reference4 = new PointF(x931b9f2b029e19c2.Width, num);
		x0f7b23d1c393aed9.xdb6e255971c32d6d[4] = new x44f2b8bf33b16275(x4dd8a59ec8974a5f.xd0baff30d99dc152, 1);
		ref PointF reference5 = ref x0f7b23d1c393aed9.xdbed53246e7dd53a[4];
		reference5 = new PointF(x931b9f2b029e19c2.Width, x931b9f2b029e19c2.Height - num);
		x0f7b23d1c393aed9.xdb6e255971c32d6d[5] = new x44f2b8bf33b16275(x4dd8a59ec8974a5f.xbfb6f7deb7122782, 1);
		ref PointF reference6 = ref x0f7b23d1c393aed9.xdbed53246e7dd53a[5];
		reference6 = new PointF(x931b9f2b029e19c2.Width - num2, x931b9f2b029e19c2.Height);
		x0f7b23d1c393aed9.xdb6e255971c32d6d[6] = new x44f2b8bf33b16275(x4dd8a59ec8974a5f.xd0baff30d99dc152, 1);
		ref PointF reference7 = ref x0f7b23d1c393aed9.xdbed53246e7dd53a[6];
		reference7 = new PointF(num2, x931b9f2b029e19c2.Height);
		x0f7b23d1c393aed9.xdb6e255971c32d6d[7] = new x44f2b8bf33b16275(x4dd8a59ec8974a5f.xb9fb25f53beaeb97, 1);
		ref PointF reference8 = ref x0f7b23d1c393aed9.xdbed53246e7dd53a[7];
		reference8 = new PointF(0f, x931b9f2b029e19c2.Height - num);
		x0f7b23d1c393aed9.xdb6e255971c32d6d[8] = new x44f2b8bf33b16275(x4dd8a59ec8974a5f.x8ffe90e7fbccfccd, 1);
		x0f7b23d1c393aed9.xdb6e255971c32d6d[9] = new x44f2b8bf33b16275(x4dd8a59ec8974a5f.x9fd888e65466818c, 0);
	}

	private static float x665810f5089c5cac(x06e4f09a90ca939a x3ddf36d606250c6f, int[] xfa523b911e124475)
	{
		return x3ddf36d606250c6f.x11f06dbf14c9ade8 ? xfa523b911e124475[x3ddf36d606250c6f.xd2f68ee6f47e9dfb - 3] : x3ddf36d606250c6f.xd2f68ee6f47e9dfb;
	}

	private static float xd5f40653dad2b6bb(x06e4f09a90ca939a x3ddf36d606250c6f, int[] xfa523b911e124475)
	{
		if (x3ddf36d606250c6f.x11f06dbf14c9ade8 && xfa523b911e124475 == null)
		{
			return 0f;
		}
		return x3ddf36d606250c6f.x11f06dbf14c9ade8 ? xfa523b911e124475[x3ddf36d606250c6f.xd2f68ee6f47e9dfb] : x3ddf36d606250c6f.xd2f68ee6f47e9dfb;
	}

	internal static int[] x5fed11ea6295c1d5(Shape x5770cdefd8931aa9)
	{
		x40937ad35b1cf5f7[] x821a79f = x5770cdefd8931aa9.x821a79f393210107;
		if (x821a79f == null || x821a79f.Length == 0)
		{
			return null;
		}
		int[] array = new int[x821a79f.Length];
		for (int i = 0; i < x821a79f.Length; i++)
		{
			x40937ad35b1cf5f7 x40937ad35b1cf5f = x821a79f[i];
			int num = (x40937ad35b1cf5f.x3a15c124e3abc8f7 ? x988e99295de68a1b(x5770cdefd8931aa9, array, x40937ad35b1cf5f.xf63e76e85f8fbc50) : x40937ad35b1cf5f.xf63e76e85f8fbc50);
			int num2 = (x40937ad35b1cf5f.x6a7e7993810130e9 ? x988e99295de68a1b(x5770cdefd8931aa9, array, x40937ad35b1cf5f.xe7e30aeba78bbcd2) : x40937ad35b1cf5f.xe7e30aeba78bbcd2);
			int num3 = (x40937ad35b1cf5f.x417ba1327575286a ? x988e99295de68a1b(x5770cdefd8931aa9, array, x40937ad35b1cf5f.x7cc7f538a3b98861) : x40937ad35b1cf5f.x7cc7f538a3b98861);
			int num4;
			switch (x40937ad35b1cf5f.xca0517fe66f52202)
			{
			case xca0517fe66f52202.xc90003e3c7f9589e:
				num4 = num + num2 - num3;
				break;
			case xca0517fe66f52202.xb3ea67b45a7cc545:
				num4 = num * num2;
				if (num3 != 0)
				{
					num4 /= num3;
				}
				break;
			case xca0517fe66f52202.x1a5e7a3f96903df8:
				num4 = (num + num2) / 2;
				break;
			case xca0517fe66f52202.x474fa9db0a5aefbf:
				num4 = Math.Abs(num);
				break;
			case xca0517fe66f52202.xf41d956c067e2b4d:
				num4 = Math.Min(num, num2);
				break;
			case xca0517fe66f52202.x9f4c543928c73298:
				num4 = Math.Max(num, num2);
				break;
			case xca0517fe66f52202.xade037ec67604ede:
				num4 = ((num > 0) ? num2 : num3);
				break;
			case xca0517fe66f52202.x4d5d68fd467f9bed:
				num4 = (int)Math.Sqrt(num * num + num2 * num2 + num3 * num3);
				break;
			case xca0517fe66f52202.xedf80090b89873d1:
				num4 = (int)(x15e971129fd80714.xc9211137ad7bfa2a(Math.Atan2(num2, num)) * 65536.0);
				break;
			case xca0517fe66f52202.xc0b452cd0b4db635:
				num4 = (int)((double)num * Math.Sin(x15e971129fd80714.xcdc7b29a812dd7df((float)num2 / 65536f)));
				break;
			case xca0517fe66f52202.xb979b67432fd6d34:
				num4 = (int)((double)num * Math.Cos(x15e971129fd80714.xcdc7b29a812dd7df((float)num2 / 65536f)));
				break;
			case xca0517fe66f52202.x04b2091113c47052:
				num4 = (int)((double)num * Math.Cos(Math.Atan2(num3, num2)));
				break;
			case xca0517fe66f52202.x23436fe121839e17:
				num4 = (int)((double)num * Math.Sin(Math.Atan2(num3, num2)));
				break;
			case xca0517fe66f52202.xe76aea2b7c5e5bbf:
				num4 = (int)Math.Floor(Math.Sqrt(num));
				break;
			case xca0517fe66f52202.x2626908b470ceb32:
				num4 = num + num2 * 65536 - num3 * 65536;
				break;
			case xca0517fe66f52202.xc72009430f04e936:
				num4 = (int)((double)num3 * Math.Sqrt(1.0 - Math.Pow((double)num / (double)num2, 2.0)));
				break;
			case xca0517fe66f52202.xa42cc9739957de4d:
				num4 = (int)((double)num * Math.Tan(x15e971129fd80714.xcdc7b29a812dd7df((float)num2 / 65536f)));
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
			array[i] = num4;
		}
		return array;
	}

	private static int x988e99295de68a1b(Shape x5770cdefd8931aa9, int[] xfa523b911e124475, int x0d173b5435b4d6ad)
	{
		if (x0d173b5435b4d6ad >= 1024 && x0d173b5435b4d6ad <= 1151)
		{
			return xfa523b911e124475[x0d173b5435b4d6ad - 1024];
		}
		switch (x0d173b5435b4d6ad)
		{
		case 320:
			return x5770cdefd8931aa9.x06c65daad0c0656c + x5770cdefd8931aa9.x133d653c1b9b01f2 / 2;
		case 321:
			return x5770cdefd8931aa9.x399bb78ac51a4081 + x5770cdefd8931aa9.xc97e136f0019c237 / 2;
		case 322:
			return x5770cdefd8931aa9.x133d653c1b9b01f2;
		case 323:
			return x5770cdefd8931aa9.xc97e136f0019c237;
		case 327:
			return x5770cdefd8931aa9.x9036b7becf593874(1);
		case 328:
			return x5770cdefd8931aa9.x9036b7becf593874(2);
		case 329:
			return x5770cdefd8931aa9.x9036b7becf593874(3);
		case 330:
			return x5770cdefd8931aa9.x9036b7becf593874(4);
		case 331:
			return x5770cdefd8931aa9.x9036b7becf593874(5);
		case 332:
			return x5770cdefd8931aa9.x9036b7becf593874(6);
		case 333:
			return x5770cdefd8931aa9.x9036b7becf593874(7);
		case 334:
			return x5770cdefd8931aa9.x9036b7becf593874(8);
		case 339:
			return x5770cdefd8931aa9.x14450b2cd7bcfcfa;
		case 340:
			return x5770cdefd8931aa9.xe915b3cb9284a483;
		case 508:
			if (!x5770cdefd8931aa9.x6bdad93be187fcba)
			{
				return 0;
			}
			return 1;
		case 1271:
			return (int)x4574ea26106f0edb.x6e9f5b67f7d0b8da((int)x5770cdefd8931aa9.xffa1fc725bf36690);
		case 1272:
			return (int)ConvertUtil.PointToPixel(x5770cdefd8931aa9.Width);
		case 1273:
			return (int)ConvertUtil.PointToPixel(x5770cdefd8931aa9.Height);
		case 1276:
			return x4574ea26106f0edb.x3aa08882c9feaf96(x5770cdefd8931aa9.Width);
		case 1277:
			return x4574ea26106f0edb.x3aa08882c9feaf96(x5770cdefd8931aa9.Height);
		case 1278:
			return x4574ea26106f0edb.x3aa08882c9feaf96(x5770cdefd8931aa9.Width * 0.5);
		case 1279:
			return x4574ea26106f0edb.x3aa08882c9feaf96(x5770cdefd8931aa9.Height * 0.5);
		default:
			throw new ArgumentOutOfRangeException("param", string.Format(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("hamincdjnckjfcbkkcikobpkabglmmmlmaemhalmpacndajncbaogahoipnoiafpgplpcpcalkjaipabgohbepobaofcjomconddkokdinbecoienipecngfimnfhnegbilgenchmljhemaikmhihloipgfjllmjpkdkaikkdgblllilngplhlgm", 2042923969)), x0d173b5435b4d6ad));
		}
	}
}
