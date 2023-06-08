using System;
using System.IO;
using System.Text;
using x13f1efc79617a47b;
using x38d3ef1c1d247e82;
using x6c95d9cf46ff5f25;

namespace xb92b7270f78a4e8d;

internal class xd8c3135513b9115b
{
	private Stream x98f97e78dec888c9;

	private x1ea60bde2b5d0d28 xf49591a44359232f;

	private x4b3117edb6fb43b5 xeddfdc17e4cfb944;

	private x022e9ea87bd0a4c7 xfa34c6d1e9266e06;

	private x41ac37a3e855c773 x3f85a8b1d8c3409b;

	private MemoryStream xd2aeaa828e17bd89;

	private xe7be411416cfcd54 xb98a60faee9bf68f;

	public xe7be411416cfcd54 x29e7ace4c90f74cd
	{
		get
		{
			if (xb98a60faee9bf68f == null)
			{
				x855150d0664edd8d();
			}
			return xb98a60faee9bf68f;
		}
	}

	internal x4b3117edb6fb43b5 x4b3117edb6fb43b5 => xeddfdc17e4cfb944;

	public static bool x995d1a25f2eac7ea(Stream xcf18e5243f8d5fd3)
	{
		long position = xcf18e5243f8d5fd3.Position;
		byte[] array = new byte[4];
		int x73ff96c61b2f324f = xcf18e5243f8d5fd3.Read(array, 0, 4);
		xcf18e5243f8d5fd3.Position = position;
		return x995d1a25f2eac7ea(array, x73ff96c61b2f324f);
	}

	public static bool x995d1a25f2eac7ea(byte[] x4a3f0a05c02f235f, int x73ff96c61b2f324f)
	{
		if (x73ff96c61b2f324f >= 4 && x4a3f0a05c02f235f[0] == 208 && x4a3f0a05c02f235f[1] == 207 && x4a3f0a05c02f235f[2] == 17)
		{
			return x4a3f0a05c02f235f[3] == 224;
		}
		return false;
	}

	public xd8c3135513b9115b(xe7be411416cfcd54 root)
	{
		xb98a60faee9bf68f = root;
	}

	public xd8c3135513b9115b(Guid clsid)
		: this(new xe7be411416cfcd54(clsid))
	{
	}

	public xd8c3135513b9115b(string fileName)
	{
		using Stream xcf18e5243f8d5fd = File.OpenRead(fileName);
		x5d95f5f98c940295(xcf18e5243f8d5fd);
		x855150d0664edd8d();
	}

	public xd8c3135513b9115b(Stream stream)
	{
		x5d95f5f98c940295(stream);
	}

	private void x5d95f5f98c940295(Stream xcf18e5243f8d5fd3)
	{
		x98f97e78dec888c9 = xcf18e5243f8d5fd3;
		x98f97e78dec888c9.Position = 0L;
		xf49591a44359232f = new x1ea60bde2b5d0d28(new BinaryReader(x98f97e78dec888c9, Encoding.Unicode));
		xeddfdc17e4cfb944 = new x4b3117edb6fb43b5(x98f97e78dec888c9, xf49591a44359232f);
		xeddfdc17e4cfb944.x06b0e25aa6ad68a9();
		x2355d119f1664bd8();
		xfa34c6d1e9266e06 = new x022e9ea87bd0a4c7(x53cce0b6abbd65ad(xf49591a44359232f.xcbd766b7a87c398a, xf49591a44359232f.xf6cc479785131f12, xf49591a44359232f.xf6cc479785131f12, x1e38b61ec7dc13de: true));
		x2f7b1d8f41a4e758();
	}

	private void x2355d119f1664bd8()
	{
		int num = Math.Min(10, xeddfdc17e4cfb944.xd44988f225497f3a);
		for (uint num2 = 0u; num2 < num; num2++)
		{
			if (((x022e9ea87bd0a4c7)xeddfdc17e4cfb944).get_xe6d4b1b411ed94b5(num2) != 0)
			{
				return;
			}
		}
		throw new InvalidOperationException("The FAT in the structured storage document seems to be corrupted.");
	}

	public void x0acd3c2012ea2ee8(string xafe2f3653ee64ebc)
	{
		using Stream xcf18e5243f8d5fd = File.Create(xafe2f3653ee64ebc);
		x0acd3c2012ea2ee8(xcf18e5243f8d5fd);
	}

	public void x0acd3c2012ea2ee8(Stream xcf18e5243f8d5fd3)
	{
		x98f97e78dec888c9 = xcf18e5243f8d5fd3;
		x98f97e78dec888c9.Position = 512L;
		xf49591a44359232f = new x1ea60bde2b5d0d28();
		xeddfdc17e4cfb944 = new x4b3117edb6fb43b5(x98f97e78dec888c9, xf49591a44359232f);
		xfa34c6d1e9266e06 = new x022e9ea87bd0a4c7();
		xd2aeaa828e17bd89 = new MemoryStream();
		x3f85a8b1d8c3409b = new x41ac37a3e855c773();
		xe32d771fa0f8a73f(xb98a60faee9bf68f, null);
		if (xd2aeaa828e17bd89.Length > 0)
		{
			x3f85a8b1d8c3409b.get_xe6d4b1b411ed94b5(0u).x3d319b452cb554cd = x25b763a23176450f(xd2aeaa828e17bd89, x1e38b61ec7dc13de: true);
			x3f85a8b1d8c3409b.get_xe6d4b1b411ed94b5(0u).x437e3b626c0fdd43 = xd2aeaa828e17bd89.Length;
			xf49591a44359232f.xcbd766b7a87c398a = x25b763a23176450f(xfa34c6d1e9266e06.x0fe354a7e0ea7cc1(), x1e38b61ec7dc13de: true, out var xc256571e5bb4bd);
			xf49591a44359232f.x882726c619a098c1 = xc256571e5bb4bd;
		}
		else
		{
			xf49591a44359232f.xcbd766b7a87c398a = 4294967294u;
		}
		xf49591a44359232f.x2cd0ae7c6528d4cd = x25b763a23176450f(x3f85a8b1d8c3409b.x0fe354a7e0ea7cc1(), x1e38b61ec7dc13de: true);
		xeddfdc17e4cfb944.x6210059f049f0d48();
		x98f97e78dec888c9.Position = 0L;
		xf49591a44359232f.x6210059f049f0d48(new BinaryWriter(x98f97e78dec888c9, Encoding.Unicode));
		x98f97e78dec888c9.Position = x98f97e78dec888c9.Length;
	}

	private void xe32d771fa0f8a73f(xe7be411416cfcd54 x630baaeb4d769680, xd686a7cfdb7bddb2 x5e4607c99a2c3e96)
	{
		if (x5e4607c99a2c3e96 == null)
		{
			x5e4607c99a2c3e96 = new xd686a7cfdb7bddb2("Root Entry", isRoot: true, x630baaeb4d769680.x933ed8cf24f04c67);
			x3f85a8b1d8c3409b.xd6b6ed77479ef68c(x5e4607c99a2c3e96);
		}
		if (x630baaeb4d769680.Count > 0)
		{
			x5e4607c99a2c3e96.xafe684f748981f4f = (uint)x3f85a8b1d8c3409b.xd44988f225497f3a;
		}
		for (int i = 0; i < x630baaeb4d769680.Count; i++)
		{
			string name = (string)x630baaeb4d769680.GetKey(i);
			object byIndex = x630baaeb4d769680.GetByIndex(i);
			xd686a7cfdb7bddb2 xd686a7cfdb7bddb3;
			if (byIndex is xe7be411416cfcd54)
			{
				xe7be411416cfcd54 xe7be411416cfcd55 = (xe7be411416cfcd54)byIndex;
				xd686a7cfdb7bddb3 = new xd686a7cfdb7bddb2(name, isRoot: false, xe7be411416cfcd55.x933ed8cf24f04c67);
				x3f85a8b1d8c3409b.xd6b6ed77479ef68c(xd686a7cfdb7bddb3);
				xe32d771fa0f8a73f(xe7be411416cfcd55, xd686a7cfdb7bddb3);
			}
			else
			{
				if (!(byIndex is Stream))
				{
					throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("phimfjpmpignpinnnieocjlogicpfdjpbiaabhhaghoaogfbjgmbhhdcackcggbdigidhbpdbggegfnelfefkflfkfcgofjgcaahcfhhafohiefiiemieddjhdkjcdbkiphk", 1325123626)));
				}
				Stream stream = (Stream)byIndex;
				xd686a7cfdb7bddb3 = new xd686a7cfdb7bddb2(name, xb824d4787cda57d9.xb8a774e0111d0fbe, stream.Length);
				x3f85a8b1d8c3409b.xd6b6ed77479ef68c(xd686a7cfdb7bddb3);
				xd686a7cfdb7bddb3.x3d319b452cb554cd = x25b763a23176450f(stream, x1e38b61ec7dc13de: false);
			}
			if (i < x630baaeb4d769680.Count - 1)
			{
				xd686a7cfdb7bddb3.xcb628eae42e96691 = (uint)x3f85a8b1d8c3409b.xd44988f225497f3a;
			}
		}
	}

	private uint x25b763a23176450f(Stream x23cda4cfdf81f2cf, bool x1e38b61ec7dc13de, out int xc256571e5bb4bd01)
	{
		xc256571e5bb4bd01 = 0;
		if (x23cda4cfdf81f2cf.Length == 0)
		{
			return 4294967294u;
		}
		bool flag = xf49591a44359232f.x981a3cbd5ad60807(x23cda4cfdf81f2cf.Length) || x1e38b61ec7dc13de;
		x022e9ea87bd0a4c7 x022e9ea87bd0a4c8 = (flag ? xeddfdc17e4cfb944 : xfa34c6d1e9266e06);
		Stream stream = (flag ? x98f97e78dec888c9 : xd2aeaa828e17bd89);
		int num = (flag ? 512 : 64);
		uint num2 = x4952846e23c21e88.x2ef840043f42e207(stream.Position, flag);
		x23cda4cfdf81f2cf.Position = 0L;
		x0d299f323d241756.x3ad8e53785c39acd(x23cda4cfdf81f2cf, stream);
		x0d299f323d241756.xb66a70c14b63a912(stream, num);
		xc256571e5bb4bd01 = x0d299f323d241756.xc82acf77a8e0e053(x23cda4cfdf81f2cf.Length, num);
		for (uint num3 = 1u; num3 < xc256571e5bb4bd01; num3++)
		{
			x022e9ea87bd0a4c8.xd6b6ed77479ef68c(num2 + num3);
		}
		x022e9ea87bd0a4c8.xd6b6ed77479ef68c(4294967294u);
		return num2;
	}

	private uint x25b763a23176450f(Stream x23cda4cfdf81f2cf, bool x1e38b61ec7dc13de)
	{
		int xc256571e5bb4bd;
		return x25b763a23176450f(x23cda4cfdf81f2cf, x1e38b61ec7dc13de, out xc256571e5bb4bd);
	}

	private void x2f7b1d8f41a4e758()
	{
		x3f85a8b1d8c3409b = new x41ac37a3e855c773();
		BinaryReader reader = new BinaryReader(x98f97e78dec888c9, Encoding.Unicode);
		uint num = xf49591a44359232f.x2cd0ae7c6528d4cd;
		x94c83b1ca7961561 x94c83b1ca = new x94c83b1ca7961561();
		while (num != 4294967294u)
		{
			x98f97e78dec888c9.Position = x4952846e23c21e88.x29cc5da3d9d1b58a(num, x0a996d99793b1739: true);
			for (int i = 0; i < 4; i++)
			{
				x3f85a8b1d8c3409b.xd6b6ed77479ef68c(new xd686a7cfdb7bddb2(reader));
			}
			x94c83b1ca.xd6b6ed77479ef68c(num);
			num = ((x022e9ea87bd0a4c7)xeddfdc17e4cfb944).get_xe6d4b1b411ed94b5(num);
			if (x94c83b1ca.x263d579af1d0d43f(num))
			{
				throw new InvalidOperationException("The structured storage file seems to be corrupt. FAT contains cycles.");
			}
		}
	}

	private MemoryStream x53cce0b6abbd65ad(uint x444500d221585c6d, int xf9a442f2008665fe, int x7175d4aa00527258, bool x1e38b61ec7dc13de)
	{
		x7175d4aa00527258 = Math.Min(xf9a442f2008665fe, x7175d4aa00527258);
		MemoryStream memoryStream = new MemoryStream(x7175d4aa00527258);
		memoryStream.SetLength(x7175d4aa00527258);
		bool flag = x1e38b61ec7dc13de || xf49591a44359232f.x981a3cbd5ad60807(xf9a442f2008665fe);
		if (!flag)
		{
			xd686a7cfdb7bddb2 xd686a7cfdb7bddb3 = x3f85a8b1d8c3409b.get_xe6d4b1b411ed94b5(0u);
			if (xd686a7cfdb7bddb3.x3d319b452cb554cd != uint.MaxValue && xd2aeaa828e17bd89 == null)
			{
				xd2aeaa828e17bd89 = x53cce0b6abbd65ad(xd686a7cfdb7bddb3.x3d319b452cb554cd, (int)xd686a7cfdb7bddb3.x437e3b626c0fdd43, (int)xd686a7cfdb7bddb3.x437e3b626c0fdd43, x1e38b61ec7dc13de: true);
			}
			if (xf49591a44359232f.xf6cc479785131f12 == 0 || xd2aeaa828e17bd89 == null)
			{
				memoryStream.SetLength(0L);
				return memoryStream;
			}
		}
		x022e9ea87bd0a4c7 x022e9ea87bd0a4c8 = (flag ? xeddfdc17e4cfb944 : xfa34c6d1e9266e06);
		Stream stream = (flag ? x98f97e78dec888c9 : xd2aeaa828e17bd89);
		int val = (flag ? 512 : 64);
		int num = 0;
		long num2 = stream.Position;
		uint num3 = x444500d221585c6d;
		while (num3 != 4294967294u && num3 != uint.MaxValue)
		{
			long num4 = x4952846e23c21e88.x29cc5da3d9d1b58a(num3, flag);
			if (num2 != num4)
			{
				num2 = (stream.Position = num4);
			}
			int num6 = x7175d4aa00527258 - num;
			if (num6 == 0)
			{
				break;
			}
			int num7 = Math.Min(val, num6);
			int num8 = stream.Read(memoryStream.GetBuffer(), num, num7);
			num += num7;
			num2 += num7;
			num3 = x022e9ea87bd0a4c8.get_xe6d4b1b411ed94b5(num3);
		}
		return memoryStream;
	}

	public MemoryStream xc99244dbac07283d(string x6b3767cca34443a2)
	{
		xd686a7cfdb7bddb2 xd686a7cfdb7bddb3 = x3f85a8b1d8c3409b.xb0080c4621a1d053(x6b3767cca34443a2);
		if (xd686a7cfdb7bddb3 == null)
		{
			throw new InvalidOperationException(string.Format(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("ldgggfngagehnflhlfcinfjigaajjehjjeojlefkodmkhpclidklkdbmaeimadpmlcgnjdnnbdeobdlofdcpjniplbaabchaecoapbfbdcmbhmccpbkcbnadlbidjmod", 197879288)), x6b3767cca34443a2));
		}
		return x53cce0b6abbd65ad(xd686a7cfdb7bddb3.x3d319b452cb554cd, (int)xd686a7cfdb7bddb3.x437e3b626c0fdd43, 512, x1e38b61ec7dc13de: false);
	}

	private void x855150d0664edd8d()
	{
		x855150d0664edd8d(x3f85a8b1d8c3409b.get_xe6d4b1b411ed94b5(0u), null);
	}

	private void x855150d0664edd8d(xd686a7cfdb7bddb2 x2451e88e57006ea5, xe7be411416cfcd54 xb6a159a84cb992d6)
	{
		if (x2451e88e57006ea5.x81bf7528425f51e7)
		{
			return;
		}
		x2451e88e57006ea5.x81bf7528425f51e7 = true;
		switch (x2451e88e57006ea5.x2ff6d9d680555933)
		{
		case xb824d4787cda57d9.xd7ae645a9c8bbc47:
		case xb824d4787cda57d9.x29e7ace4c90f74cd:
		{
			xe7be411416cfcd54 xe7be411416cfcd55 = new xe7be411416cfcd54(x2451e88e57006ea5.x933ed8cf24f04c67);
			if (x2451e88e57006ea5.x2ff6d9d680555933 == xb824d4787cda57d9.x29e7ace4c90f74cd && xb98a60faee9bf68f == null)
			{
				xb98a60faee9bf68f = xe7be411416cfcd55;
			}
			else
			{
				xb6a159a84cb992d6.xd6b6ed77479ef68c(x2451e88e57006ea5.x759aa16c2016a289, xe7be411416cfcd55);
			}
			xd686a7cfdb7bddb2 xd686a7cfdb7bddb3 = x3f85a8b1d8c3409b.x856a7e9b6bed6a7a(x2451e88e57006ea5, x2451e88e57006ea5.xafe684f748981f4f);
			if (xd686a7cfdb7bddb3 != null)
			{
				x855150d0664edd8d(xd686a7cfdb7bddb3, xe7be411416cfcd55);
			}
			break;
		}
		case xb824d4787cda57d9.xb8a774e0111d0fbe:
			xb6a159a84cb992d6.xd6b6ed77479ef68c(x2451e88e57006ea5.x759aa16c2016a289, x53cce0b6abbd65ad(x2451e88e57006ea5.x3d319b452cb554cd, (int)x2451e88e57006ea5.x437e3b626c0fdd43, (int)x2451e88e57006ea5.x437e3b626c0fdd43, x1e38b61ec7dc13de: false));
			break;
		case xb824d4787cda57d9.xcde3a31c5a88fc93:
			return;
		default:
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("egmikhdjehkjehbkchikhhpklgglkbnllgemnglmbgcndfjnlaaohfholeoocafpdempfedalekaldbbgdibeepbmdgcmdncaeedeokdgccemcjepcafkchfocofcnegibmgkbdhjmjhkbbilaiifapinlfjnanjlaekgalkgaclbpilppplnpgmhpnmhoendolnmjcomojokoapcohpcoopomfabnmammdbcjkb", 1777110031)));
		}
		xd686a7cfdb7bddb2 xd686a7cfdb7bddb4 = x3f85a8b1d8c3409b.x856a7e9b6bed6a7a(x2451e88e57006ea5, x2451e88e57006ea5.xf469c807ba339d90);
		if (xd686a7cfdb7bddb4 != null)
		{
			x855150d0664edd8d(xd686a7cfdb7bddb4, xb6a159a84cb992d6);
		}
		xd686a7cfdb7bddb2 xd686a7cfdb7bddb5 = x3f85a8b1d8c3409b.x856a7e9b6bed6a7a(x2451e88e57006ea5, x2451e88e57006ea5.xcb628eae42e96691);
		if (xd686a7cfdb7bddb5 != null)
		{
			x855150d0664edd8d(xd686a7cfdb7bddb5, xb6a159a84cb992d6);
		}
	}

	public bool x25b20c8fab66a43d(string xc15bd84e01929885)
	{
		return x3f85a8b1d8c3409b.xb0080c4621a1d053(xc15bd84e01929885) != null;
	}
}
