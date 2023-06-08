using System;
using System.Drawing;
using x1c8faa688b1f0b0c;
using x74500b509de15565;
using xa7850104c8d8c135;

namespace x24e0e4e48dc84bd8;

internal class x25d42836be873e27
{
	private readonly x28a5d52551b64191 x7450cc1e48712286;

	private readonly x4e88096751fad171 xd995695f8e3419d6;

	public x25d42836be873e27(x4e88096751fad171 serviceLocator)
		: this(serviceLocator.xf86de1bd2f396938, serviceLocator)
	{
	}

	public x25d42836be873e27(x28a5d52551b64191 reader, x4e88096751fad171 serviceLocator)
	{
		x7450cc1e48712286 = reader;
		xd995695f8e3419d6 = serviceLocator;
	}

	public xab391c46ff9a0a38 xe6dd7bd4e532d8a6()
	{
		xab391c46ff9a0a38 xab391c46ff9a0a = new xab391c46ff9a0a38();
		x7450cc1e48712286.ReadInt32();
		int num = x7450cc1e48712286.ReadInt32();
		if (num <= 1)
		{
			return xab391c46ff9a0a;
		}
		xa078e85e8e8af73b xa078e85e8e8af73b2 = new xa078e85e8e8af73b();
		xa078e85e8e8af73b2.x1b4522c8590b3e1a(x7450cc1e48712286);
		if (xa078e85e8e8af73b2.x6df3968c42b004a7)
		{
			x739a42b0136a625d();
			return xab391c46ff9a0a;
		}
		x7450cc1e48712286.ReadInt16();
		PointF[] x6fa2570084b2ad = x321be38d1b51099b(num, xa078e85e8e8af73b2.x4e9908888e512fd5, xa078e85e8e8af73b2.xaf09b1a5e6d60a5c);
		x19cc08252a4f3241[] x3d9709791ef8d = new x19cc08252a4f3241[num];
		x5bd0488c530a6d04[] xcccfa01a2209434a = new x5bd0488c530a6d04[num];
		x42046897c34aec73(xa078e85e8e8af73b2, x3d9709791ef8d, xcccfa01a2209434a);
		if (x7450cc1e48712286.BaseStream.Position % 4 != 0)
		{
			x7450cc1e48712286.BaseStream.Position += x7450cc1e48712286.BaseStream.Position % 4;
		}
		x8d60d99fd03ed306(xab391c46ff9a0a, x6fa2570084b2ad, x3d9709791ef8d, xcccfa01a2209434a);
		return xab391c46ff9a0a;
	}

	public xab391c46ff9a0a38 xc2ab51a3232e3fd7()
	{
		int num = x7450cc1e48712286.ReadInt32();
		PointF[] array = new PointF[num];
		for (int i = 0; i < num; i++)
		{
			ref PointF reference = ref array[i];
			reference = x7450cc1e48712286.xa4a92a61b2092da6();
		}
		xab391c46ff9a0a38 xab391c46ff9a0a = new xab391c46ff9a0a38();
		x1cab6af0a41b70e2 xda5bf54deb817e = x1cab6af0a41b70e2.xa7b580afa8756d69(array, x7a848427f2a9a3b5: true);
		xab391c46ff9a0a.xd6b6ed77479ef68c(xda5bf54deb817e);
		return xab391c46ff9a0a;
	}

	public PointF[] x321be38d1b51099b(int x10f4d88af727adbc, bool x2cb185189be14c4e, bool x1eb3b526211e71f1)
	{
		if (x2cb185189be14c4e)
		{
			return x1b4876d92faa2eff(x10f4d88af727adbc);
		}
		if (!x1eb3b526211e71f1)
		{
			return x69c5f7838382b3e1(x10f4d88af727adbc);
		}
		return xdcd9d5aa9f331355(x10f4d88af727adbc);
	}

	internal static int x2c8ba2e6d95bb512(x28a5d52551b64191 xe134235b3526fa75)
	{
		int num = 0;
		byte b = xe134235b3526fa75.ReadByte();
		num |= b & 0x7F;
		if ((b & 0x80u) != 0)
		{
			b = xe134235b3526fa75.ReadByte();
			num |= b << 7;
			if (num > 16383)
			{
				return 16383 - num;
			}
		}
		else if (num > 63 && num <= 143)
		{
			return 63 - num;
		}
		return num;
	}

	private void x8d60d99fd03ed306(xab391c46ff9a0a38 xe125219852864557, PointF[] x6fa2570084b2ad39, x19cc08252a4f3241[] x3d9709791ef8d296, x5bd0488c530a6d04[] xcccfa01a2209434a)
	{
		PointF pointF = x6fa2570084b2ad39[0];
		PointF cubP = x6fa2570084b2ad39[0];
		int num = 0;
		x1cab6af0a41b70e2 x1cab6af0a41b70e = new x1cab6af0a41b70e2();
		xe125219852864557.xd6b6ed77479ef68c(x1cab6af0a41b70e);
		for (int i = 1; i < x6fa2570084b2ad39.Length; i++)
		{
			switch (x3d9709791ef8d296[i])
			{
			case x19cc08252a4f3241.xe3f57937d6714d0b:
				if ((xcccfa01a2209434a[i - 1] & x5bd0488c530a6d04.x466781d23a46dcc7) != 0)
				{
					x1cab6af0a41b70e.x5e6c52cb3256cc85 = true;
				}
				x1cab6af0a41b70e = new x1cab6af0a41b70e2();
				xe125219852864557.xd6b6ed77479ef68c(x1cab6af0a41b70e);
				break;
			case x19cc08252a4f3241.x1135f35e19e0a9fb:
				x1cab6af0a41b70e.x49babf6761229eb5(pointF, x6fa2570084b2ad39[i]);
				break;
			case x19cc08252a4f3241.xdfa84b4d7391e51a:
				if (num == 0)
				{
					cubP = pointF;
				}
				num++;
				if (num == 3)
				{
					x1cab6af0a41b70e.xd6b6ed77479ef68c(new x519b1bd0625473ff(cubP, x6fa2570084b2ad39[i - 2], x6fa2570084b2ad39[i - 1], x6fa2570084b2ad39[i]));
					num = 0;
				}
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
			pointF = x6fa2570084b2ad39[i];
		}
		if ((xcccfa01a2209434a[x6fa2570084b2ad39.Length - 1] & x5bd0488c530a6d04.x466781d23a46dcc7) != 0)
		{
			x1cab6af0a41b70e.x5e6c52cb3256cc85 = true;
		}
	}

	private void x42046897c34aec73(xa078e85e8e8af73b xebf45bdcaa1fd1e1, x19cc08252a4f3241[] x3d9709791ef8d296, x5bd0488c530a6d04[] xcccfa01a2209434a)
	{
		if (xebf45bdcaa1fd1e1.x6df3968c42b004a7)
		{
			x739a42b0136a625d();
			return;
		}
		for (int i = 0; i < x3d9709791ef8d296.Length; i++)
		{
			byte b = x7450cc1e48712286.ReadByte();
			xcccfa01a2209434a[i] = (x5bd0488c530a6d04)((b & 0xF0) >> 4);
			x3d9709791ef8d296[i] = (x19cc08252a4f3241)(b & 0xF);
		}
	}

	public PointF[] x69c5f7838382b3e1(int xe1abc3319cdbcea3)
	{
		PointF[] array = new PointF[xe1abc3319cdbcea3];
		for (int i = 0; i < xe1abc3319cdbcea3; i++)
		{
			ref PointF reference = ref array[i];
			reference = x7450cc1e48712286.xa4a92a61b2092da6();
		}
		return array;
	}

	public PointF[] xdcd9d5aa9f331355(int xe1abc3319cdbcea3)
	{
		PointF[] array = new PointF[xe1abc3319cdbcea3];
		for (int i = 0; i < xe1abc3319cdbcea3; i++)
		{
			ref PointF reference = ref array[i];
			reference = new PointF(x7450cc1e48712286.ReadInt16(), x7450cc1e48712286.ReadInt16());
		}
		return array;
	}

	private PointF[] x1b4876d92faa2eff(int xe1abc3319cdbcea3)
	{
		PointF[] array = new PointF[xe1abc3319cdbcea3];
		PointF pointF = default(PointF);
		for (int i = 0; i < xe1abc3319cdbcea3; i++)
		{
			SizeF sizeF = xc6e0d39e02741089();
			ref PointF reference = ref array[i];
			reference = new PointF(pointF.X + sizeF.Width, pointF.Y + sizeF.Width);
			if (i == 0)
			{
				pointF = array[0];
			}
		}
		return array;
	}

	private SizeF xc6e0d39e02741089()
	{
		return new SizeF(x2c8ba2e6d95bb512(x7450cc1e48712286), x2c8ba2e6d95bb512(x7450cc1e48712286));
	}

	private void x739a42b0136a625d()
	{
		xd995695f8e3419d6.x5e3cfff57135d485("RLE compression is not supported.");
	}
}
