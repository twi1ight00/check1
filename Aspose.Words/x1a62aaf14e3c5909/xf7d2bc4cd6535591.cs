using System;
using System.IO;
using x011d489fb9df7027;
using x13f1efc79617a47b;
using xf989f31a236ff98c;

namespace x1a62aaf14e3c5909;

internal class xf7d2bc4cd6535591 : x47d90533fe3ed43a
{
	private const int xff28320d39eb4f34 = int.MinValue;

	private int x5ce7ce445509f601;

	private int x86ff07bdcfe4be45;

	private int x39e46a286f75f41c;

	private byte[] x82b70567a5f68f41;

	internal xf7d2bc4cd6535591(int id, int dataLength)
		: base(id, dataLength)
	{
	}

	private xf7d2bc4cd6535591(int id, int itemCount, int itemSize)
		: base(id, x70b89157a16bf4cf(itemCount, itemSize))
	{
		x5ce7ce445509f601 = itemCount;
		x86ff07bdcfe4be45 = itemCount;
		x39e46a286f75f41c = itemSize;
		x82b70567a5f68f41 = new byte[x39e46a286f75f41c * x5ce7ce445509f601];
	}

	private static int x70b89157a16bf4cf(int x046c167834ef261f, int x4cb8d2c926f9fad1)
	{
		return 6 + x046c167834ef261f * x4cb8d2c926f9fad1;
	}

	internal xf7d2bc4cd6535591(int id, x9fb6ff04f20b10d0[] colors)
		: this(id, colors.Length, 8)
	{
		using MemoryStream output = new MemoryStream(x82b70567a5f68f41);
		BinaryWriter binaryWriter = new BinaryWriter(output);
		for (int i = 0; i < colors.Length; i++)
		{
			binaryWriter.Write(x195cb055715b526e.x103636c839f725d7(colors[i].x9b41425268471380));
			binaryWriter.Write(colors[i].x12cb12b5d2cad53d);
		}
	}

	internal xf7d2bc4cd6535591(int id, x580ae020787e37f2[] values)
		: this(id, values.Length, 12)
	{
		using MemoryStream output = new MemoryStream(x82b70567a5f68f41);
		BinaryWriter binaryWriter = new BinaryWriter(output);
		for (int i = 0; i < values.Length; i++)
		{
			binaryWriter.Write(values[i].xda71bf6f7c07c3bc);
			binaryWriter.Write(values[i].x8e8f6cc6a0756b05);
			binaryWriter.Write(values[i].x857912840ffd015f);
		}
	}

	internal xf7d2bc4cd6535591(int id, x08d932077485c285[] values)
		: this(id, values.Length, 8)
	{
		using MemoryStream output = new MemoryStream(x82b70567a5f68f41);
		BinaryWriter binaryWriter = new BinaryWriter(output);
		for (int i = 0; i < values.Length; i++)
		{
			binaryWriter.Write(x990d3e2e1a133b7d(values[i].x8df91a2f90079e88));
			binaryWriter.Write(x990d3e2e1a133b7d(values[i].xc821290d7ecc08bf));
		}
	}

	internal xf7d2bc4cd6535591(int id, x40937ad35b1cf5f7[] values)
		: this(id, values.Length, 8)
	{
		using MemoryStream output = new MemoryStream(x82b70567a5f68f41);
		BinaryWriter binaryWriter = new BinaryWriter(output);
		for (int i = 0; i < values.Length; i++)
		{
			binaryWriter.Write((byte)values[i].xca0517fe66f52202);
			binaryWriter.Write((byte)values[i].x586b7652ac7cefe0);
			binaryWriter.Write((short)values[i].xf63e76e85f8fbc50);
			binaryWriter.Write((short)values[i].xe7e30aeba78bbcd2);
			binaryWriter.Write((short)values[i].x7cc7f538a3b98861);
		}
	}

	internal xf7d2bc4cd6535591(int id, x7efbe0a2dc0d335f[] values)
		: this(id, values.Length, 36)
	{
		using MemoryStream output = new MemoryStream(x82b70567a5f68f41);
		BinaryWriter binaryWriter = new BinaryWriter(output);
		for (int i = 0; i < values.Length; i++)
		{
			binaryWriter.Write(values[i].xabe60eaba2fa6780());
			binaryWriter.Write(values[i].x3b1bddb38a858693.x98a6bc3f2b64620b);
			binaryWriter.Write(values[i].x97a3447730c7ceb9.x98a6bc3f2b64620b);
			binaryWriter.Write(values[i].xb6af3939c9fabf06.xd2f68ee6f47e9dfb);
			binaryWriter.Write(values[i].x8d8e3bafebd1a122.xd2f68ee6f47e9dfb);
			binaryWriter.Write(values[i].x9462c8df936efa39.xd2f68ee6f47e9dfb);
			binaryWriter.Write(values[i].x11f73230b9b436a7.xd2f68ee6f47e9dfb);
			binaryWriter.Write(values[i].x5b051452efe1bbe3.xd2f68ee6f47e9dfb);
			binaryWriter.Write(values[i].xbed6b6abe5a7fcce.xd2f68ee6f47e9dfb);
		}
	}

	internal xf7d2bc4cd6535591(int id, xbc9979937c838d75[] rects)
		: this(id, rects.Length, 16)
	{
		using MemoryStream output = new MemoryStream(x82b70567a5f68f41);
		BinaryWriter binaryWriter = new BinaryWriter(output);
		foreach (xbc9979937c838d75 xbc9979937c838d in rects)
		{
			binaryWriter.Write(x990d3e2e1a133b7d(xbc9979937c838d.x72d92bd1aff02e37));
			binaryWriter.Write(x990d3e2e1a133b7d(xbc9979937c838d.xe360b1885d8d4a41));
			binaryWriter.Write(x990d3e2e1a133b7d(xbc9979937c838d.x419ba17a5322627b));
			binaryWriter.Write(x990d3e2e1a133b7d(xbc9979937c838d.x9bcb07e204e30218));
		}
	}

	internal xf7d2bc4cd6535591(int id, int[] values)
		: this(id, values.Length, 4)
	{
		using MemoryStream output = new MemoryStream(x82b70567a5f68f41);
		BinaryWriter binaryWriter = new BinaryWriter(output);
		for (int i = 0; i < values.Length; i++)
		{
			binaryWriter.Write(values[i]);
		}
	}

	internal xf7d2bc4cd6535591(int id, x44f2b8bf33b16275[] values)
		: this(id, values.Length, 2)
	{
		using MemoryStream output = new MemoryStream(x82b70567a5f68f41);
		BinaryWriter binaryWriter = new BinaryWriter(output);
		for (int i = 0; i < values.Length; i++)
		{
			int num = x30145fee5dd2eb06.xeda895769860002f(values[i]);
			binaryWriter.Write((ushort)num);
		}
	}

	internal override void x855150d0664edd8d(BinaryReader xe134235b3526fa75)
	{
		if (base.x3719d1992877f6f9 != 0)
		{
			x5ce7ce445509f601 = xe134235b3526fa75.ReadUInt16();
			x86ff07bdcfe4be45 = xe134235b3526fa75.ReadUInt16();
			x39e46a286f75f41c = xe134235b3526fa75.ReadUInt16();
			if (x39e46a286f75f41c == 65520)
			{
				x39e46a286f75f41c = 4;
			}
			x82b70567a5f68f41 = xe134235b3526fa75.ReadBytes(x5ce7ce445509f601 * x39e46a286f75f41c);
		}
	}

	internal override void xc26afd5362f5c1ec(BinaryWriter xbdfb620b7167944b)
	{
		xbdfb620b7167944b.Write((short)x5ce7ce445509f601);
		xbdfb620b7167944b.Write((short)x86ff07bdcfe4be45);
		xbdfb620b7167944b.Write((short)x39e46a286f75f41c);
		xbdfb620b7167944b.Write(x82b70567a5f68f41);
	}

	internal x9fb6ff04f20b10d0[] x54f9561cb7ef62b1()
	{
		if (x5ce7ce445509f601 == 0)
		{
			return null;
		}
		using MemoryStream input = new MemoryStream(x82b70567a5f68f41);
		BinaryReader binaryReader = new BinaryReader(input);
		x9fb6ff04f20b10d0[] array = new x9fb6ff04f20b10d0[x5ce7ce445509f601];
		for (int i = 0; i < array.Length; i++)
		{
			x9fb6ff04f20b10d0 x9fb6ff04f20b10d = new x9fb6ff04f20b10d0();
			x9fb6ff04f20b10d.x9b41425268471380 = x195cb055715b526e.xfa7086ee0c6b6330(binaryReader.ReadInt32());
			x9fb6ff04f20b10d.x12cb12b5d2cad53d = binaryReader.ReadInt32();
			array[i] = x9fb6ff04f20b10d;
		}
		return array;
	}

	internal x580ae020787e37f2[] x82d97fa3a533f142()
	{
		if (x5ce7ce445509f601 == 0)
		{
			return null;
		}
		using MemoryStream input = new MemoryStream(x82b70567a5f68f41);
		BinaryReader binaryReader = new BinaryReader(input);
		x580ae020787e37f2[] array = new x580ae020787e37f2[x5ce7ce445509f601];
		for (int i = 0; i < array.Length; i++)
		{
			x580ae020787e37f2 x580ae020787e37f = new x580ae020787e37f2();
			x580ae020787e37f.xda71bf6f7c07c3bc = binaryReader.ReadInt32();
			x580ae020787e37f.x8e8f6cc6a0756b05 = binaryReader.ReadInt32();
			x580ae020787e37f.x857912840ffd015f = binaryReader.ReadInt32();
			array[i] = x580ae020787e37f;
		}
		return array;
	}

	internal x08d932077485c285[] xe512752f228eb379()
	{
		if (x5ce7ce445509f601 == 0)
		{
			return null;
		}
		using MemoryStream input = new MemoryStream(x82b70567a5f68f41);
		BinaryReader binaryReader = new BinaryReader(input);
		x08d932077485c285[] array = new x08d932077485c285[x5ce7ce445509f601];
		switch (x39e46a286f75f41c)
		{
		case 4:
		{
			for (int j = 0; j < array.Length; j++)
			{
				int x = binaryReader.ReadInt16();
				int y = binaryReader.ReadInt16();
				array[j] = new x08d932077485c285(x, y);
			}
			break;
		}
		case 8:
		{
			for (int i = 0; i < array.Length; i++)
			{
				int x9b4602d5e4f04fcb = binaryReader.ReadInt32();
				int x9b4602d5e4f04fcb2 = binaryReader.ReadInt32();
				array[i] = new x08d932077485c285(x783efc6c84a26fe0(x9b4602d5e4f04fcb), x783efc6c84a26fe0(x9b4602d5e4f04fcb2));
			}
			break;
		}
		default:
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("jlccpmjcjmadjmhdhmodmmfeammepgdfclkfilbgiligalpgbkghblnhkfeinjlidkcjdkjjoeakojhkajokgiflcjmleidmmdkmjibnhhinhipnihgoldno", 2071077476)));
		}
		return array;
	}

	internal x7efbe0a2dc0d335f[] xb6ff3138565feb6c()
	{
		if (x5ce7ce445509f601 == 0)
		{
			return null;
		}
		using MemoryStream input = new MemoryStream(x82b70567a5f68f41);
		BinaryReader binaryReader = new BinaryReader(input);
		x7efbe0a2dc0d335f[] array = new x7efbe0a2dc0d335f[x5ce7ce445509f601];
		for (int i = 0; i < array.Length; i++)
		{
			x7efbe0a2dc0d335f x7efbe0a2dc0d335f = new x7efbe0a2dc0d335f();
			int num = binaryReader.ReadInt32();
			x7efbe0a2dc0d335f.x7ab55132a5c2e47e = (num & 0x2000) != 0;
			x7efbe0a2dc0d335f.x22dfdc5e2d91486e = (num & 0x20) != 0;
			x7efbe0a2dc0d335f.x9183a138a4fced5c = (num & 0x10) != 0;
			x7efbe0a2dc0d335f.x7937f9e8f355e258 = (num & 8) != 0;
			x7efbe0a2dc0d335f.xcc2d426b867d703d = (num & 4) != 0;
			x7efbe0a2dc0d335f.x916221819f469b19 = (num & 2) != 0;
			x7efbe0a2dc0d335f.x2f612cdfb1f62c32 = (num & 1) != 0;
			x7efbe0a2dc0d335f.x3b1bddb38a858693 = new x98655ffe05324a50(xa8f5ae79475a2ff9(binaryReader, x837eb909aa2929b2: true).xd2f68ee6f47e9dfb);
			x7efbe0a2dc0d335f.x97a3447730c7ceb9 = new x98655ffe05324a50(xa8f5ae79475a2ff9(binaryReader, x837eb909aa2929b2: true).xd2f68ee6f47e9dfb);
			x7efbe0a2dc0d335f.xb6af3939c9fabf06 = xa8f5ae79475a2ff9(binaryReader, (num & 0x800) != 0);
			x7efbe0a2dc0d335f.x8d8e3bafebd1a122 = xa8f5ae79475a2ff9(binaryReader, (num & 0x1000) != 0);
			x7efbe0a2dc0d335f.x9462c8df936efa39 = xa8f5ae79475a2ff9(binaryReader, (num & 0x80) != 0);
			x7efbe0a2dc0d335f.x11f73230b9b436a7 = xa8f5ae79475a2ff9(binaryReader, (num & 0x100) != 0);
			x7efbe0a2dc0d335f.x5b051452efe1bbe3 = xa8f5ae79475a2ff9(binaryReader, (num & 0x200) != 0);
			x7efbe0a2dc0d335f.xbed6b6abe5a7fcce = xa8f5ae79475a2ff9(binaryReader, (num & 0x400) != 0);
			array[i] = x7efbe0a2dc0d335f;
		}
		return array;
	}

	private static x06e4f09a90ca939a xa8f5ae79475a2ff9(BinaryReader xe134235b3526fa75, bool x837eb909aa2929b2)
	{
		int value = xe134235b3526fa75.ReadInt32();
		return new x06e4f09a90ca939a(value, x837eb909aa2929b2);
	}

	internal xbc9979937c838d75[] xaf85c1a1ad8ed83a()
	{
		if (x39e46a286f75f41c == 0)
		{
			return null;
		}
		using MemoryStream input = new MemoryStream(x82b70567a5f68f41);
		xbc9979937c838d75[] array = new xbc9979937c838d75[x5ce7ce445509f601];
		for (int i = 0; i < x5ce7ce445509f601; i++)
		{
			BinaryReader binaryReader = new BinaryReader(input);
			xbc9979937c838d75 xbc9979937c838d = new xbc9979937c838d75();
			xbc9979937c838d.x72d92bd1aff02e37 = x783efc6c84a26fe0(binaryReader.ReadInt32());
			xbc9979937c838d.xe360b1885d8d4a41 = x783efc6c84a26fe0(binaryReader.ReadInt32());
			xbc9979937c838d.x419ba17a5322627b = x783efc6c84a26fe0(binaryReader.ReadInt32());
			xbc9979937c838d.x9bcb07e204e30218 = x783efc6c84a26fe0(binaryReader.ReadInt32());
			array[i] = xbc9979937c838d;
		}
		return array;
	}

	internal static int x990d3e2e1a133b7d(x06e4f09a90ca939a xbcea506a33cf9111)
	{
		int num = xbcea506a33cf9111.xd2f68ee6f47e9dfb;
		if (xbcea506a33cf9111.x11f06dbf14c9ade8 && xd4b7b39da92c1d6f(num))
		{
			num |= int.MinValue;
		}
		return num;
	}

	internal static x06e4f09a90ca939a x783efc6c84a26fe0(int x9b4602d5e4f04fcb)
	{
		if (((uint)x9b4602d5e4f04fcb & 0x80000000u) != 0)
		{
			int num = x9b4602d5e4f04fcb & 0x7FFFFFFF;
			if (xd4b7b39da92c1d6f(num))
			{
				return new x06e4f09a90ca939a(num, isFormula: true);
			}
		}
		return new x06e4f09a90ca939a(x9b4602d5e4f04fcb, isFormula: false);
	}

	private static bool xd4b7b39da92c1d6f(int x9b4602d5e4f04fcb)
	{
		if (x9b4602d5e4f04fcb >= 0)
		{
			return x9b4602d5e4f04fcb <= 127;
		}
		return false;
	}

	internal x40937ad35b1cf5f7[] x767e62a423f94754()
	{
		if (x5ce7ce445509f601 == 0)
		{
			return null;
		}
		using MemoryStream input = new MemoryStream(x82b70567a5f68f41);
		BinaryReader binaryReader = new BinaryReader(input);
		x40937ad35b1cf5f7[] array = new x40937ad35b1cf5f7[x5ce7ce445509f601];
		for (int i = 0; i < array.Length; i++)
		{
			x40937ad35b1cf5f7 x40937ad35b1cf5f = new x40937ad35b1cf5f7();
			x40937ad35b1cf5f.xca0517fe66f52202 = (xca0517fe66f52202)binaryReader.ReadByte();
			x40937ad35b1cf5f.x586b7652ac7cefe0 = binaryReader.ReadByte();
			x40937ad35b1cf5f.xf63e76e85f8fbc50 = binaryReader.ReadInt16();
			x40937ad35b1cf5f.xe7e30aeba78bbcd2 = binaryReader.ReadInt16();
			x40937ad35b1cf5f.x7cc7f538a3b98861 = binaryReader.ReadInt16();
			array[i] = x40937ad35b1cf5f;
		}
		return array;
	}

	internal x44f2b8bf33b16275[] x1f564d9c310beda1()
	{
		if (x5ce7ce445509f601 == 0)
		{
			return null;
		}
		using MemoryStream input = new MemoryStream(x82b70567a5f68f41);
		BinaryReader binaryReader = new BinaryReader(input);
		x44f2b8bf33b16275[] array = new x44f2b8bf33b16275[x5ce7ce445509f601];
		for (int i = 0; i < array.Length; i++)
		{
			int xebf45bdcaa1fd1e = binaryReader.ReadUInt16();
			array[i] = x30145fee5dd2eb06.x475eb9088d78b9cf(xebf45bdcaa1fd1e);
		}
		return array;
	}

	internal int[] xaf14ff6cf5955691()
	{
		if (x5ce7ce445509f601 == 0)
		{
			return null;
		}
		using MemoryStream input = new MemoryStream(x82b70567a5f68f41);
		BinaryReader binaryReader = new BinaryReader(input);
		int[] array = new int[x5ce7ce445509f601];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = binaryReader.ReadInt32();
		}
		return array;
	}
}
