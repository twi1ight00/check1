using System.Drawing;
using System.IO;
using System.Text;
using x0097836593a6a96a;
using x1c8faa688b1f0b0c;
using x38a89dee67fc7a16;
using x5794c252ba25e723;
using x64e9a8098b90b398;
using x6c95d9cf46ff5f25;
using xa7850104c8d8c135;
using xf269d97e8a02e911;

namespace x74500b509de15565;

internal class x055feb40a6f16001 : x4cb7537b071ca71a
{
	private const int xdf8b9c27ac4337b9 = 6;

	private xa1f7a3d42bca7cb8 x7450cc1e48712286;

	private x9bef3b1e893f7f2e xea288d4121bac055;

	protected xa1f7a3d42bca7cb8 xf86de1bd2f396938 => x7450cc1e48712286;

	private x620a827d91bf9cfe x145e3af29556cafe => xea288d4121bac055.x28fcdc775a1d069c.x145e3af29556cafe;

	private xcf56b3bea2f7249b x9992adc923692d1d => xea288d4121bac055.x28fcdc775a1d069c.x9992adc923692d1d;

	public x055feb40a6f16001(x3fa09e8d7b952fbc metafileInfo)
		: this(metafileInfo, new xb0d8039f74776744())
	{
	}

	public x055feb40a6f16001(x3fa09e8d7b952fbc metafileInfo, xb0d8039f74776744 apsBuilderContext)
		: base(metafileInfo, apsBuilderContext)
	{
	}

	public RectangleF xa49375d14353c60f()
	{
		xea288d4121bac055 = new xbf1cbfb9791580a6(base.x4aca0559c9e6ddc0, isEmf: false);
		xea288d4121bac055.xd586e0c16bdae7fc();
		xa2eb08930231a488();
		return ((xbf1cbfb9791580a6)xea288d4121bac055).x6ae4612a8469678e;
	}

	protected override xb8e7e788f6d59708 DoPlay()
	{
		xea288d4121bac055 = new xa3c1321313fe9f8e(base.x4aca0559c9e6ddc0, base.x437e3b626c0fdd43, isEmf: false);
		xea288d4121bac055.xd586e0c16bdae7fc();
		xa2eb08930231a488();
		return ((xa3c1321313fe9f8e)xea288d4121bac055).x5fe28c2b4826581d;
	}

	private void xa2eb08930231a488()
	{
		Stream xb8a774e0111d0fbe = base.x4aca0559c9e6ddc0.xb8a774e0111d0fbe;
		xb8a774e0111d0fbe.Position = base.x4aca0559c9e6ddc0.xeb1dab4c802b7198;
		x7450cc1e48712286 = new xa1f7a3d42bca7cb8(xb8a774e0111d0fbe);
		while (xb8a774e0111d0fbe.Position < xb8a774e0111d0fbe.Length && (!base.xa6f30a6360be2a75.xec8728ceac69f279 || !base.x6cd834400ec1b81e) && xb8a774e0111d0fbe.Position + 6 <= xb8a774e0111d0fbe.Length)
		{
			int num = x7450cc1e48712286.ReadInt32();
			x58dacb9696b2ceb9 recordType = (x58dacb9696b2ceb9)x7450cc1e48712286.ReadUInt16();
			int num2 = (int)xb8a774e0111d0fbe.Position;
			int num3 = num * 2 - 6;
			if (xb8a774e0111d0fbe.Position + num3 > xb8a774e0111d0fbe.Length || !DoPlayRecord(recordType, num3))
			{
				break;
			}
			int num4 = num2 + num3;
			xb8a774e0111d0fbe.Position = num4;
		}
	}

	protected virtual bool DoPlayRecord(x58dacb9696b2ceb9 recordType, int dataSize)
	{
		switch (recordType)
		{
		case x58dacb9696b2ceb9.x4d0b9d4447ba7566:
			return false;
		case x58dacb9696b2ceb9.x621fb7f0626d088a:
			xea288d4121bac055.x28fcdc775a1d069c.x99324070390852e2();
			break;
		case x58dacb9696b2ceb9.x6660fbcb4840ac2e:
			xea288d4121bac055.x28fcdc775a1d069c.x0619fa143f5de07c();
			break;
		case x58dacb9696b2ceb9.xdfe43dbca9a9e323:
		{
			x66ec63675332b85f mapMode = (x66ec63675332b85f)x7450cc1e48712286.ReadInt16();
			x145e3af29556cafe.xf30a67c117fb87d6.SetMapMode(mapMode);
			break;
		}
		case x58dacb9696b2ceb9.xa7ae776108b4fcb8:
			x145e3af29556cafe.xf30a67c117fb87d6.SetWindowOrg(x7450cc1e48712286.x7e2a3c059f5793af());
			break;
		case x58dacb9696b2ceb9.x52dba942ff997276:
			x145e3af29556cafe.xf30a67c117fb87d6.SetWindowExt(x7450cc1e48712286.xb4a9b516a22e4a7a());
			break;
		case x58dacb9696b2ceb9.x31d9d2f6018ce275:
			x145e3af29556cafe.xf30a67c117fb87d6.OffsetWindowOrg(x7450cc1e48712286.xb4a9b516a22e4a7a());
			break;
		case x58dacb9696b2ceb9.xd2bbf70aa8812cc5:
			x145e3af29556cafe.xf30a67c117fb87d6.ScaleWindowExt(x7450cc1e48712286.x322e9b24055afef2());
			break;
		case x58dacb9696b2ceb9.xb66161bc59cb7a57:
			x145e3af29556cafe.xf30a67c117fb87d6.SetViewportOrg(x7450cc1e48712286.x7e2a3c059f5793af());
			break;
		case x58dacb9696b2ceb9.x3aa65537b855d9dd:
			x145e3af29556cafe.xf30a67c117fb87d6.SetViewportExt(x7450cc1e48712286.xb4a9b516a22e4a7a());
			break;
		case x58dacb9696b2ceb9.xeedf509d3cc0ddac:
			x145e3af29556cafe.xf30a67c117fb87d6.OffsetViewportOrg(x7450cc1e48712286.xb4a9b516a22e4a7a());
			break;
		case x58dacb9696b2ceb9.xa83a556067bce394:
			x145e3af29556cafe.xf30a67c117fb87d6.ScaleViewportExt(x7450cc1e48712286.x322e9b24055afef2());
			break;
		case x58dacb9696b2ceb9.x2041bc7a26b1993a:
			x2135aa476e811ffd();
			break;
		case x58dacb9696b2ceb9.xa498aabddadf3aa0:
			x47f94de585d8823c();
			break;
		case x58dacb9696b2ceb9.x70eb033132565d4f:
			x22c0177e93680b36();
			break;
		case x58dacb9696b2ceb9.xfb2e95c065901004:
			x72e575a6c02e65f9();
			break;
		case x58dacb9696b2ceb9.x51ffdd09d53b47ea:
			x06bb00d1a70035f8();
			break;
		case x58dacb9696b2ceb9.x0371fb9895a73d9e:
			xdbf009d252dca700();
			break;
		case x58dacb9696b2ceb9.x69a348af8a6e1351:
			x33de56df0a95ed83();
			break;
		case x58dacb9696b2ceb9.xc5af74139eb6fc05:
		{
			int x45cb9c2 = x7450cc1e48712286.ReadUInt16();
			x145e3af29556cafe.x008e4a8833e5d929(x45cb9c2);
			break;
		}
		case x58dacb9696b2ceb9.x3e72eaf7a69c253d:
		{
			int x45cb9c = x7450cc1e48712286.ReadUInt16();
			x9992adc923692d1d.xddae736767606eb7(x45cb9c);
			break;
		}
		case x58dacb9696b2ceb9.x2f5d00bb9794922c:
		{
			x26d9ecb4bdf0456d x83729c7ebf48ae = x7450cc1e48712286.x07d1b52af8293592();
			x145e3af29556cafe.x83729c7ebf48ae24 = x83729c7ebf48ae;
			break;
		}
		case x58dacb9696b2ceb9.xc7f783e60ae680ff:
			x145e3af29556cafe.x11f92ed76a223c08 = (x6f10e58a0574e489)x7450cc1e48712286.ReadInt16();
			break;
		case x58dacb9696b2ceb9.x3c545c2b8ea90ef4:
			x145e3af29556cafe.x0cd10c3b6c8154d6 = x7450cc1e48712286.x07d1b52af8293592();
			break;
		case x58dacb9696b2ceb9.x4bc7acc8081f6cfd:
			x145e3af29556cafe.x2f4602b24218079d = (x3bd09d63c3e0d655)x7450cc1e48712286.ReadUInt16();
			break;
		case x58dacb9696b2ceb9.x8647dafaadac08c5:
			x445c9fce3166713b();
			break;
		case x58dacb9696b2ceb9.x73f725cce5fe5602:
			x6c3c99d0027e2cc0();
			break;
		case x58dacb9696b2ceb9.x1123d3ce5a92413f:
			xb0e579c49f7aaf5c();
			break;
		case x58dacb9696b2ceb9.xa043fc75b3b99954:
			xadc28ef17d897ad9();
			break;
		case x58dacb9696b2ceb9.x9d20124ed7bf90d4:
			xd9c8acf0e5a12504();
			break;
		case x58dacb9696b2ceb9.xa43055eb03a1eab6:
			xea288d4121bac055.x28fcdc775a1d069c.x01b2723108ff3dfe(x7450cc1e48712286.x7e2a3c059f5793af());
			break;
		case x58dacb9696b2ceb9.x18971675d115ad2e:
			xea288d4121bac055.x28fcdc775a1d069c.xd0baff30d99dc152(x7450cc1e48712286.x7e2a3c059f5793af());
			break;
		case x58dacb9696b2ceb9.xb61e041350f29e98:
			xea288d4121bac055.x404d528fe2f10961(x7450cc1e48712286.xf1575d122ac7f90e());
			break;
		case x58dacb9696b2ceb9.xc3f25f29170813f3:
			xdc17f546fee300d3();
			break;
		case x58dacb9696b2ceb9.xe84e40bc738ac740:
			x03d68de1c2f74051();
			break;
		case x58dacb9696b2ceb9.x5de02317a4b39379:
			xd245cbaa83c34942();
			break;
		case x58dacb9696b2ceb9.xa13b8e8e6c7634ed:
			x26a9b6a08a70bcb9();
			break;
		case x58dacb9696b2ceb9.x0bbfde77f2eb15df:
			xc72009430f04e936();
			break;
		case x58dacb9696b2ceb9.xf232deb12e00d1d7:
			x9c41f408fac0860b();
			break;
		case x58dacb9696b2ceb9.x4bfcdd84aac0938e:
			xbde68cf069398941();
			break;
		case x58dacb9696b2ceb9.xcb62ad3bda81961a:
			x627d6ea467c20240();
			break;
		case x58dacb9696b2ceb9.x97a22b82bda979bd:
			xe2fbf8cbac6fd57f(dataSize);
			break;
		case x58dacb9696b2ceb9.xa9c8783dde41d5d2:
			x07251f3a807a0d5e(dataSize);
			break;
		case x58dacb9696b2ceb9.x73c15d5e40aaa4b0:
			x2791516c0206b47b(dataSize);
			break;
		case x58dacb9696b2ceb9.x7285d7dbd6e26181:
			x145e3af29556cafe.x5cf444f06e13725e(x7450cc1e48712286.xf1575d122ac7f90e());
			break;
		case x58dacb9696b2ceb9.xda36c0c80e486de2:
			x145e3af29556cafe.xe62e57b8a0115fad(x7450cc1e48712286.xf1575d122ac7f90e());
			break;
		case x58dacb9696b2ceb9.xb40e8b487a522c80:
			x145e3af29556cafe.x20b5b38def9b8b3a(x7450cc1e48712286.xb4a9b516a22e4a7a());
			break;
		case x58dacb9696b2ceb9.x70af8406c596bd40:
			x035f3b654b9e9e79();
			break;
		case x58dacb9696b2ceb9.xe87e12a4d29236a9:
			x5b198f85704beb8e();
			break;
		case x58dacb9696b2ceb9.x6ab1952d861ad517:
			xa6f1319572e0608b();
			break;
		case x58dacb9696b2ceb9.xbe8a67c6c7068417:
			x9b6097d0c38350cb();
			break;
		case x58dacb9696b2ceb9.x55296f30fbea1597:
			x7d730fb8836a2f34();
			break;
		case x58dacb9696b2ceb9.x8a8af6d1876e37e5:
			x63bb2170e6549217();
			break;
		case x58dacb9696b2ceb9.xf0d08a2942bd707c:
			x7c705b15e7fe6e95();
			break;
		case x58dacb9696b2ceb9.x6fc0305104c11650:
			x64ab84ce3729cb06();
			break;
		case x58dacb9696b2ceb9.x815efdccb24b6c09:
		case x58dacb9696b2ceb9.x2292e48eeb785b97:
		case x58dacb9696b2ceb9.x214d573eddc1d772:
		case x58dacb9696b2ceb9.x4739a25c3678cf1c:
		case x58dacb9696b2ceb9.x55cd7f8b53627d86:
		case x58dacb9696b2ceb9.xc8c6d3bef30f8fc8:
		case x58dacb9696b2ceb9.xd87f90a87d9bda92:
		case x58dacb9696b2ceb9.xb342bf565b7403bc:
		case x58dacb9696b2ceb9.xe458e6c97cf8dc2f:
		case x58dacb9696b2ceb9.xfb855c4bc04c8582:
		case x58dacb9696b2ceb9.x755a315768c01079:
		case x58dacb9696b2ceb9.xa9640766dab84588:
		case x58dacb9696b2ceb9.x3c1a94cbaf18b6e1:
			xcd7edd4e2c88d730(recordType);
			break;
		default:
			xddce54eaf1607c56(recordType);
			break;
		}
		return true;
	}

	private void xcd7edd4e2c88d730(x58dacb9696b2ceb9 xc1674de501b364d0)
	{
		string xe88104aeaa19b45d = x402d9b5f181ddd8c.xd8d63c4bf397de98(xc1674de501b364d0);
		base.xf69ca7a9bb4a4a51.xbbf9a1ead81dd3a1(x6d058fdf61831c39.x42daab0e7e499260, x3959df40367ac8a3.x5459fadea977d08d, "'{0}' record is not supported.", xe88104aeaa19b45d);
	}

	private void xddce54eaf1607c56(x58dacb9696b2ceb9 xc1674de501b364d0)
	{
		base.xf69ca7a9bb4a4a51.xbbf9a1ead81dd3a1(x6d058fdf61831c39.x65def832e35c82b0, x3959df40367ac8a3.x5459fadea977d08d, "Record with '{0}' type is not supported.", (int)xc1674de501b364d0);
	}

	private void x5b198f85704beb8e()
	{
		int x45cb9c = x7450cc1e48712286.ReadUInt16();
		int x45cb9c2 = x7450cc1e48712286.ReadUInt16();
		xfc986ef9bf7fc434 xa4d52e34b62b = (xfc986ef9bf7fc434)x9992adc923692d1d.get_xe6d4b1b411ed94b5(x45cb9c);
		xea288d4121bac055.x1915e1f68bab8628(xa4d52e34b62b, null, x145e3af29556cafe.x97bd6a468f76745e(x45cb9c2));
	}

	private void xa6f1319572e0608b()
	{
		int x45cb9c = x7450cc1e48712286.ReadUInt16();
		int x45cb9c2 = x7450cc1e48712286.ReadUInt16();
		x7450cc1e48712286.ReadInt16();
		int num = x7450cc1e48712286.ReadInt16();
		x31c19fcb724dfaf5 x90279591611601bc = new x31c19fcb724dfaf5(x145e3af29556cafe.x97bd6a468f76745e(x45cb9c2), num);
		xfc986ef9bf7fc434 xa4d52e34b62b = (xfc986ef9bf7fc434)x9992adc923692d1d.get_xe6d4b1b411ed94b5(x45cb9c);
		xea288d4121bac055.x1915e1f68bab8628(xa4d52e34b62b, x90279591611601bc, null);
	}

	private void x9b6097d0c38350cb()
	{
		int x45cb9c = x7450cc1e48712286.ReadUInt16();
		xfc986ef9bf7fc434 xa4d52e34b62b = (xfc986ef9bf7fc434)x9992adc923692d1d.get_xe6d4b1b411ed94b5(x45cb9c);
		xea288d4121bac055.x1915e1f68bab8628(xa4d52e34b62b, new x31c19fcb724dfaf5(x26d9ecb4bdf0456d.x89fffa2751fdecbe), null);
	}

	private void x7d730fb8836a2f34()
	{
		int x45cb9c = x7450cc1e48712286.ReadUInt16();
		xfc986ef9bf7fc434 xa4d52e34b62b = (xfc986ef9bf7fc434)x9992adc923692d1d.get_xe6d4b1b411ed94b5(x45cb9c);
		xea288d4121bac055.x1915e1f68bab8628(xa4d52e34b62b, null, x145e3af29556cafe.x60465f602599d327);
	}

	private void xdbf009d252dca700()
	{
		xd8229e5e57d947ce xbcea506a33cf = new xd8229e5e57d947ce();
		x9992adc923692d1d.xd6b6ed77479ef68c(xbcea506a33cf);
	}

	private void x33de56df0a95ed83()
	{
		xfc986ef9bf7fc434 xfc986ef9bf7fc = new xfc986ef9bf7fc434();
		xfc986ef9bf7fc.xda72e69795827549(x7450cc1e48712286);
		x9992adc923692d1d.xd6b6ed77479ef68c(xfc986ef9bf7fc);
	}

	private void x2135aa476e811ffd()
	{
		xd8229e5e57d947ce xd8229e5e57d947ce = new xd8229e5e57d947ce();
		xd8229e5e57d947ce.xda72e69795827549(x7450cc1e48712286);
		x9992adc923692d1d.xd6b6ed77479ef68c(xd8229e5e57d947ce);
	}

	private void x47f94de585d8823c()
	{
		xb6b31e10a27b56a2 xb6b31e10a27b56a = new xb6b31e10a27b56a2();
		xb6b31e10a27b56a.xda72e69795827549(x7450cc1e48712286);
		x9992adc923692d1d.xd6b6ed77479ef68c(xb6b31e10a27b56a);
	}

	private void x22c0177e93680b36()
	{
		x3cc1f6fa2c94cf17 x3cc1f6fa2c94cf = new x3cc1f6fa2c94cf17();
		x3cc1f6fa2c94cf.xda72e69795827549(x7450cc1e48712286);
		x9992adc923692d1d.xd6b6ed77479ef68c(x3cc1f6fa2c94cf);
	}

	private void x72e575a6c02e65f9()
	{
		xb6b31e10a27b56a2 xb6b31e10a27b56a = new xb6b31e10a27b56a2();
		xb6b31e10a27b56a.xca29b0d786deb760(x7450cc1e48712286);
		x9992adc923692d1d.xd6b6ed77479ef68c(xb6b31e10a27b56a);
	}

	private void x06bb00d1a70035f8()
	{
		x7450cc1e48712286.ReadInt32();
		xb6b31e10a27b56a2 xb6b31e10a27b56a = new xb6b31e10a27b56a2();
		xb6b31e10a27b56a.x27093997fc9d86ae(x7450cc1e48712286);
		x9992adc923692d1d.xd6b6ed77479ef68c(xb6b31e10a27b56a);
	}

	private void xadc28ef17d897ad9()
	{
		x145e3af29556cafe.x4eada1f74f43bddb = (x1e707bbc21c4527d)x7450cc1e48712286.ReadUInt16();
	}

	private void x63bb2170e6549217()
	{
		x145e3af29556cafe.xb6766c282a26f397 = (x5625eea5e5dfbfa3)x7450cc1e48712286.ReadUInt16();
	}

	private void x445c9fce3166713b()
	{
		int x04d6233650cd5fc = x7450cc1e48712286.ReadInt16();
		x145e3af29556cafe.x04d6233650cd5fc0 = x04d6233650cd5fc;
	}

	private void x6c3c99d0027e2cc0()
	{
		int x961016a387451f = x7450cc1e48712286.ReadUInt16();
		string xb41faee6912a = xc3a6fb8513d320a3(x961016a387451f);
		if (x0d299f323d241756.x7e32f71c3f39b6bc(x7450cc1e48712286.BaseStream.Position))
		{
			x7450cc1e48712286.BaseStream.Position++;
		}
		PointF x96963e0bda = x7450cc1e48712286.x7e2a3c059f5793af();
		xea288d4121bac055.x73f725cce5fe5602(x96963e0bda, xb41faee6912a);
	}

	private void xb0e579c49f7aaf5c()
	{
		PointF x96963e0bda = x7450cc1e48712286.x7e2a3c059f5793af();
		int num = x7450cc1e48712286.ReadUInt16();
		int num2 = x7450cc1e48712286.ReadInt16();
		RectangleF xda73fcb97c77d = RectangleF.Empty;
		if (num2 != 0)
		{
			xda73fcb97c77d = x7450cc1e48712286.x70a5bafbe8fbfeb2();
		}
		if (num != 0)
		{
			string xb41faee6912a = xc3a6fb8513d320a3(num);
			xea288d4121bac055.x73f725cce5fe5602(x96963e0bda, xb41faee6912a);
		}
		else if (((uint)num2 & 2u) != 0)
		{
			xea288d4121bac055.xe281a5e162365979(xda73fcb97c77d);
		}
	}

	private string xc3a6fb8513d320a3(int x961016a387451f05)
	{
		byte[] array = x7450cc1e48712286.ReadBytes(x961016a387451f05);
		if (x145e3af29556cafe.x79604dbb6e9b817b.xbab94787eb927948 == 2 || x09d499c483428bd1.xadc83cc585a89881(x145e3af29556cafe.x79604dbb6e9b817b.x77a92edb600f019b))
		{
			StringBuilder stringBuilder = new StringBuilder();
			byte[] array2 = array;
			foreach (byte b in array2)
			{
				char x3c4da2980d043c = (char)(b & 0xFFu);
				stringBuilder.Append(x09d499c483428bd1.x1ea7c95c824f6882(x3c4da2980d043c));
			}
			return stringBuilder.ToString();
		}
		Encoding x9ee491ab5579b9fc = x145e3af29556cafe.x79604dbb6e9b817b.x9ee491ab5579b9fc;
		return x9ee491ab5579b9fc.GetString(array);
	}

	private void xd9c8acf0e5a12504()
	{
		x26d9ecb4bdf0456d x6c50a99faab7d = x7450cc1e48712286.x07d1b52af8293592();
		PointF x13d4cb8d1bd = x7450cc1e48712286.x7e2a3c059f5793af();
		xea288d4121bac055.xd9c8acf0e5a12504(x13d4cb8d1bd, x6c50a99faab7d);
	}

	private void xdc17f546fee300d3()
	{
		xea288d4121bac055.xdc17f546fee300d3(x7450cc1e48712286.x22cd88977f8c06b2());
	}

	private void x03d68de1c2f74051()
	{
		xea288d4121bac055.x03d68de1c2f74051(x7450cc1e48712286.x22cd88977f8c06b2());
	}

	private void xd245cbaa83c34942()
	{
		xea288d4121bac055.xd245cbaa83c34942(x7450cc1e48712286.x155f861783e460dc());
	}

	private void x26a9b6a08a70bcb9()
	{
		PointF x10aaa7cdfa38f = x7450cc1e48712286.x7e2a3c059f5793af();
		PointF xca09b6c2b5b = x7450cc1e48712286.x7e2a3c059f5793af();
		RectangleF xda73fcb97c77d = x7450cc1e48712286.xf1575d122ac7f90e();
		xea288d4121bac055.x26a9b6a08a70bcb9(xda73fcb97c77d, x10aaa7cdfa38f, xca09b6c2b5b);
	}

	private void xc72009430f04e936()
	{
		xea288d4121bac055.xc72009430f04e936(x7450cc1e48712286.xf1575d122ac7f90e());
	}

	private void x9c41f408fac0860b()
	{
		PointF xca09b6c2b5b = x7450cc1e48712286.x7e2a3c059f5793af();
		PointF x10aaa7cdfa38f = x7450cc1e48712286.x7e2a3c059f5793af();
		RectangleF xda73fcb97c77d = x7450cc1e48712286.xf1575d122ac7f90e();
		xea288d4121bac055.x9c41f408fac0860b(xda73fcb97c77d, x10aaa7cdfa38f, xca09b6c2b5b);
	}

	private void xbde68cf069398941()
	{
		PointF xca09b6c2b5b = x7450cc1e48712286.x7e2a3c059f5793af();
		PointF x10aaa7cdfa38f = x7450cc1e48712286.x7e2a3c059f5793af();
		RectangleF xda73fcb97c77d = x7450cc1e48712286.xf1575d122ac7f90e();
		xea288d4121bac055.xbde68cf069398941(xda73fcb97c77d, x10aaa7cdfa38f, xca09b6c2b5b);
	}

	private void x627d6ea467c20240()
	{
		SizeF x9c1283b780bba3a = x7450cc1e48712286.xb4a9b516a22e4a7a();
		RectangleF xda73fcb97c77d = x7450cc1e48712286.xf1575d122ac7f90e();
		xea288d4121bac055.x627d6ea467c20240(xda73fcb97c77d, x9c1283b780bba3a);
	}

	private void xe2fbf8cbac6fd57f(int xff884decc91dea16)
	{
		int num = 0;
		x5bb294979783141d x66e4da5eb4b8a03a = (x5bb294979783141d)x7450cc1e48712286.ReadInt32();
		x7450cc1e48712286.ReadUInt16();
		num += 6;
		RectangleF x4522b57e50ea54a = x7450cc1e48712286.x5134dcd1deb72a24();
		RectangleF x334178e22916b6db = x7450cc1e48712286.x5134dcd1deb72a24();
		num += 16;
		x827270a50ade3585(x66e4da5eb4b8a03a, x4522b57e50ea54a, x334178e22916b6db, x6b0da3a7d057ed3a: true, xff884decc91dea16 - num);
	}

	private void x07251f3a807a0d5e(int xff884decc91dea16)
	{
		int num = 0;
		bool flag = xf01bb7c2cab4e490(xff884decc91dea16, x58dacb9696b2ceb9.x73c15d5e40aaa4b0);
		x5bb294979783141d x66e4da5eb4b8a03a = (x5bb294979783141d)x7450cc1e48712286.ReadInt32();
		RectangleF x4522b57e50ea54a = x7450cc1e48712286.x5134dcd1deb72a24();
		num += 12;
		if (!flag)
		{
			x7450cc1e48712286.ReadInt16();
			num += 2;
		}
		RectangleF x334178e22916b6db = x7450cc1e48712286.x5134dcd1deb72a24();
		num += 8;
		x827270a50ade3585(x66e4da5eb4b8a03a, x4522b57e50ea54a, x334178e22916b6db, flag, xff884decc91dea16 - num);
	}

	private void x2791516c0206b47b(int xff884decc91dea16)
	{
		int num = 0;
		bool flag = xf01bb7c2cab4e490(xff884decc91dea16, x58dacb9696b2ceb9.x73c15d5e40aaa4b0);
		x5bb294979783141d x66e4da5eb4b8a03a = (x5bb294979783141d)x7450cc1e48712286.ReadInt32();
		float y = (int)x7450cc1e48712286.ReadUInt16();
		float x = (int)x7450cc1e48712286.ReadUInt16();
		num += 8;
		if (!flag)
		{
			x7450cc1e48712286.ReadInt16();
			num += 2;
		}
		RectangleF x334178e22916b6db = x7450cc1e48712286.x5134dcd1deb72a24();
		num += 8;
		RectangleF x4522b57e50ea54a = new RectangleF(x, y, x334178e22916b6db.Width, x334178e22916b6db.Height);
		x827270a50ade3585(x66e4da5eb4b8a03a, x4522b57e50ea54a, x334178e22916b6db, flag, xff884decc91dea16 - num);
	}

	private void x827270a50ade3585(x5bb294979783141d x66e4da5eb4b8a03a, RectangleF x4522b57e50ea54a2, RectangleF x334178e22916b6db, bool x6b0da3a7d057ed3a, int xf3df8caccbf90f13)
	{
		switch (x66e4da5eb4b8a03a)
		{
		case x5bb294979783141d.xd3a9565e9ce44a25:
			if (x6b0da3a7d057ed3a)
			{
				xea288d4121bac055.xf1c59e95a2a1c03b(x4522b57e50ea54a2, x334178e22916b6db, xdd1b8f14cc8ba86d.x10e7a0599aa303ae(x7450cc1e48712286, xf3df8caccbf90f13));
			}
			else
			{
				xe8910a4cbe002e2a(x66e4da5eb4b8a03a);
			}
			break;
		case x5bb294979783141d.x97a3b1b2e4996054:
		case x5bb294979783141d.x0fefcf429c22b63f:
		case x5bb294979783141d.xfbdb7e642cc66992:
		case x5bb294979783141d.x1d5d09d79cf2ee77:
			if (x6b0da3a7d057ed3a)
			{
				xea288d4121bac055.xf1c59e95a2a1c03b(x4522b57e50ea54a2, x334178e22916b6db, xdd1b8f14cc8ba86d.x10e7a0599aa303ae(x7450cc1e48712286, xf3df8caccbf90f13));
			}
			xe8910a4cbe002e2a(x66e4da5eb4b8a03a);
			break;
		case x5bb294979783141d.x5e1ecefbb95a6614:
			xea288d4121bac055.x7cfc143904bcbd0a(x334178e22916b6db);
			break;
		default:
			xe8910a4cbe002e2a(x66e4da5eb4b8a03a);
			break;
		case x5bb294979783141d.x5d593cee9d844848:
			break;
		}
	}

	private void xe8910a4cbe002e2a(x5bb294979783141d x66e4da5eb4b8a03a)
	{
		base.xf69ca7a9bb4a4a51.xbbf9a1ead81dd3a1(x6d058fdf61831c39.x65def832e35c82b0, x3959df40367ac8a3.x5459fadea977d08d, "{0} raster operation is not supported.", x402d9b5f181ddd8c.xb579f5df08774159(x66e4da5eb4b8a03a));
		base.xa6f30a6360be2a75.xec8728ceac69f279 = true;
	}

	private void x035f3b654b9e9e79()
	{
		x7450cc1e48712286.ReadInt16();
		x7450cc1e48712286.ReadUInt16();
	}

	private void x7c705b15e7fe6e95()
	{
		x7450cc1e48712286.ReadInt32();
		RectangleF xda73fcb97c77d = x7450cc1e48712286.x5134dcd1deb72a24();
		xea288d4121bac055.x7cfc143904bcbd0a(xda73fcb97c77d);
	}

	private void x64ab84ce3729cb06()
	{
		int x45cb9c = x7450cc1e48712286.ReadUInt16();
		object obj = x9992adc923692d1d.get_xe6d4b1b411ed94b5(x45cb9c);
		if (!(obj is xfc986ef9bf7fc434))
		{
			return;
		}
		xfc986ef9bf7fc434 xfc986ef9bf7fc = (xfc986ef9bf7fc434)obj;
		Region region = new Region();
		region.MakeEmpty();
		foreach (RectangleF item in xfc986ef9bf7fc.x58efbacd665a3e59)
		{
			region.Union(item);
		}
		x145e3af29556cafe.x64ab84ce3729cb06(region, x209db13a33ccc536.x775521112ede5e6f);
	}

	private static bool xf01bb7c2cab4e490(int xff884decc91dea16, x58dacb9696b2ceb9 x8e14ee863dfc4cca)
	{
		return (xff884decc91dea16 + 6) / 2 != ((int)x8e14ee863dfc4cca >> 8) + 3;
	}
}
