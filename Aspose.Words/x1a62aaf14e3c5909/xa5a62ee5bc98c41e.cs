using System.IO;
using Aspose.Words;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;

namespace x1a62aaf14e3c5909;

internal class xa5a62ee5bc98c41e : x09ce2c02826e31a6
{
	internal void xd6b6ed77479ef68c(xef8fbb0f103c0bb1 x46710263f0fedd95)
	{
		xd6b6ed77479ef68c(x46710263f0fedd95.xea1e81378298fa81, x46710263f0fedd95);
	}

	internal void x790922ad5280636d(int x01dfff6a67355342, int xbcea506a33cf9111)
	{
		xd6b6ed77479ef68c(new xba3d4617457193ff(x01dfff6a67355342, xbcea506a33cf9111));
	}

	internal void x510567f1132da166(int x01dfff6a67355342, string xbcea506a33cf9111)
	{
		xd6b6ed77479ef68c(new x7dacc4d0459cdf99(x01dfff6a67355342, xbcea506a33cf9111));
	}

	internal void x06b0e25aa6ad68a9(BinaryReader xe134235b3526fa75, int x8f82f2c8a2a00dcb, IWarningCallback x57fef5933b41d0c2)
	{
		for (int i = 0; i < x8f82f2c8a2a00dcb; i++)
		{
			int num = xe134235b3526fa75.ReadUInt16();
			int num2 = num & 0x3FFF;
			bool flag = (num & 0x8000) != 0;
			int num3 = xe134235b3526fa75.ReadInt32();
			xef8fbb0f103c0bb1 xef8fbb0f103c0bb2;
			if (flag)
			{
				switch (num2 & -64)
				{
				case 448:
				case 1344:
				case 1408:
				case 1472:
				case 1536:
				case 1600:
				{
					int x75a9c8b35c93c27a2 = num3;
					xef8fbb0f103c0bb2 = x8b97ae3d01364f40(num2, x75a9c8b35c93c27a2, x57fef5933b41d0c2);
					break;
				}
				default:
				{
					int x75a9c8b35c93c27a = num3;
					xef8fbb0f103c0bb2 = x77e4ec59e899d1e3(num2, x75a9c8b35c93c27a, x57fef5933b41d0c2);
					break;
				}
				}
			}
			else
			{
				xef8fbb0f103c0bb2 = new xba3d4617457193ff(num2, num3);
			}
			if (xef8fbb0f103c0bb2 != null)
			{
				xd6b6ed77479ef68c(xef8fbb0f103c0bb2);
			}
		}
		for (int j = 0; j < base.xd44988f225497f3a; j++)
		{
			xef8fbb0f103c0bb1 xef8fbb0f103c0bb3 = (xef8fbb0f103c0bb1)x6d3720b962bd3112(j);
			if (xef8fbb0f103c0bb3.x74a7f36e76358cb5)
			{
				((x47d90533fe3ed43a)xef8fbb0f103c0bb3).x855150d0664edd8d(xe134235b3526fa75);
			}
		}
	}

	private static xef8fbb0f103c0bb1 x8b97ae3d01364f40(int x5b898c7a7c731e45, int x75a9c8b35c93c27a, IWarningCallback x57fef5933b41d0c2)
	{
		int num = x5b898c7a7c731e45 & -64;
		switch (x5b898c7a7c731e45 + (num - 448))
		{
		case 454:
			return new x7dacc4d0459cdf99(x5b898c7a7c731e45, x75a9c8b35c93c27a);
		case 463:
			return new xf7d2bc4cd6535591(x5b898c7a7c731e45, x75a9c8b35c93c27a);
		default:
			x98b0e09ccece0a5a.x3dc950453374051a(x57fef5933b41d0c2, WarningSource.Doc, "Unknown OfficeArt property found 0x{0:x4}, ignored.", x5b898c7a7c731e45);
			return new xaf6617e7eaccdeb7(x5b898c7a7c731e45, x75a9c8b35c93c27a);
		}
	}

	private static xef8fbb0f103c0bb1 x77e4ec59e899d1e3(int x5b898c7a7c731e45, int x75a9c8b35c93c27a, IWarningCallback x57fef5933b41d0c2)
	{
		switch (x5b898c7a7c731e45)
		{
		case 325:
		case 326:
		case 337:
		case 338:
		case 341:
		case 342:
		case 343:
		case 407:
		case 899:
		case 1284:
		case 1288:
			return new xf7d2bc4cd6535591(x5b898c7a7c731e45, x75a9c8b35c93c27a);
		case 192:
		case 197:
		case 261:
		case 272:
		case 391:
		case 896:
		case 897:
		case 909:
		case 910:
		case 919:
		case 922:
			return new x7dacc4d0459cdf99(x5b898c7a7c731e45, x75a9c8b35c93c27a);
		case 898:
			return new x9bd10249890baaef(x5b898c7a7c731e45, x75a9c8b35c93c27a);
		case 1792:
			return new xb9d557c2e4fd83cd(x5b898c7a7c731e45, x75a9c8b35c93c27a);
		case 1921:
		case 1922:
		case 1923:
		case 1924:
		case 1925:
		case 1926:
		case 1927:
		case 1928:
			return new x7dacc4d0459cdf99(x5b898c7a7c731e45, x75a9c8b35c93c27a);
		case 780:
			return new x35c861f511323d4d(x5b898c7a7c731e45, x75a9c8b35c93c27a);
		default:
			x98b0e09ccece0a5a.x3dc950453374051a(x57fef5933b41d0c2, WarningSource.Doc, "Unknown OfficeArt property found 0x{0:x4}, ignored.", x5b898c7a7c731e45);
			return new xaf6617e7eaccdeb7(x5b898c7a7c731e45, x75a9c8b35c93c27a);
		}
	}

	internal int x6210059f049f0d48(BinaryWriter xbdfb620b7167944b)
	{
		int num = (int)xbdfb620b7167944b.BaseStream.Position;
		for (int i = 0; i < base.xd44988f225497f3a; i++)
		{
			xef8fbb0f103c0bb1 xef8fbb0f103c0bb2 = (xef8fbb0f103c0bb1)x6d3720b962bd3112(i);
			int num2 = xef8fbb0f103c0bb2.xea1e81378298fa81;
			if (x708991eb2ed6e1c7(xef8fbb0f103c0bb2.xea1e81378298fa81))
			{
				num2 |= 0x4000;
			}
			if (xef8fbb0f103c0bb2.x74a7f36e76358cb5)
			{
				num2 |= 0x8000;
			}
			xbdfb620b7167944b.Write((short)num2);
			xbdfb620b7167944b.Write(xef8fbb0f103c0bb2.x74a7f36e76358cb5 ? ((x47d90533fe3ed43a)xef8fbb0f103c0bb2).x3719d1992877f6f9 : xef8fbb0f103c0bb2.x9a1915e0a5a745b7);
		}
		for (int j = 0; j < base.xd44988f225497f3a; j++)
		{
			xef8fbb0f103c0bb1 xef8fbb0f103c0bb3 = (xef8fbb0f103c0bb1)x6d3720b962bd3112(j);
			if (xef8fbb0f103c0bb3.x74a7f36e76358cb5)
			{
				((x47d90533fe3ed43a)xef8fbb0f103c0bb3).xc26afd5362f5c1ec(xbdfb620b7167944b);
			}
		}
		return (int)xbdfb620b7167944b.BaseStream.Position - num;
	}

	private static bool x708991eb2ed6e1c7(int x5b898c7a7c731e45)
	{
		switch (x5b898c7a7c731e45)
		{
		case 260:
		case 261:
		case 390:
		case 391:
		case 453:
		case 454:
			return true;
		default:
			return false;
		}
	}
}
