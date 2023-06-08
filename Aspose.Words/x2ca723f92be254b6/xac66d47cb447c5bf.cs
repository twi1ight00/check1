using System;
using System.IO;
using x6c95d9cf46ff5f25;

namespace x2ca723f92be254b6;

internal class xac66d47cb447c5bf
{
	private const int x2056efe1ac39fcb4 = 4;

	private const int xbc22d39efed71f91 = 268435456;

	private const short xb10d05bc0e744d16 = 20556;

	private const int x2d32dac78ff5c1fb = 65536;

	private const int xf85465796a4911d0 = 131073;

	private const int xe6de700539dd7656 = 131074;

	private const byte x78739f3d57e625d1 = 80;

	public static byte[] xb257ab73498e1e07(byte[] x75a6930151cf7bd0)
	{
		try
		{
			return x6d411cbbdb5a222d(x75a6930151cf7bd0);
		}
		catch (Exception)
		{
			return null;
		}
	}

	public static byte[] x6d411cbbdb5a222d(byte[] x75a6930151cf7bd0)
	{
		if (x75a6930151cf7bd0 == null || x75a6930151cf7bd0.Length == 0)
		{
			return null;
		}
		using MemoryStream input = new MemoryStream(x75a6930151cf7bd0);
		using BinaryReader binaryReader = new BinaryReader(input);
		uint num = binaryReader.ReadUInt32();
		if (num != binaryReader.BaseStream.Length)
		{
			throw new InvalidOperationException("The EOT file is not valid.");
		}
		uint num2 = binaryReader.ReadUInt32();
		xcb8bd210026f27bc xcb8bd210026f27bc2 = x6c168122d9ebdca6(binaryReader.ReadInt32());
		if (xcb8bd210026f27bc2 == xcb8bd210026f27bc.xf6c17f648b65c793)
		{
			throw new InvalidOperationException("Unsupported EOT version.");
		}
		int xbf5a7e14ee8e42b = binaryReader.ReadInt32();
		binaryReader.BaseStream.Position += 18L;
		short num3 = binaryReader.ReadInt16();
		if (num3 != 20556)
		{
			throw new InvalidOperationException("The EOT file is not valid.");
		}
		binaryReader.BaseStream.Position += 46L;
		ushort num4 = binaryReader.ReadUInt16();
		binaryReader.BaseStream.Position += num4 + 2;
		ushort num5 = binaryReader.ReadUInt16();
		binaryReader.BaseStream.Position += num5 + 2;
		ushort num6 = binaryReader.ReadUInt16();
		binaryReader.BaseStream.Position += num6 + 2;
		ushort num7 = binaryReader.ReadUInt16();
		binaryReader.BaseStream.Position += num7;
		if (xcb8bd210026f27bc2 == xcb8bd210026f27bc.xf85465796a4911d0 || xcb8bd210026f27bc2 == xcb8bd210026f27bc.xe6de700539dd7656)
		{
			binaryReader.BaseStream.Position += 2L;
			ushort num8 = binaryReader.ReadUInt16();
			binaryReader.BaseStream.Position += num8;
			if (xcb8bd210026f27bc2 == xcb8bd210026f27bc.xe6de700539dd7656)
			{
				binaryReader.BaseStream.Position += 10L;
				ushort num9 = binaryReader.ReadUInt16();
				binaryReader.BaseStream.Position += num9;
				binaryReader.BaseStream.Position += 4L;
				uint num10 = binaryReader.ReadUInt32();
				binaryReader.BaseStream.Position += num10;
			}
		}
		if (binaryReader.BaseStream.Position + num2 != binaryReader.BaseStream.Length)
		{
			throw new InvalidOperationException("The EOT file is not valid.");
		}
		byte[] array = binaryReader.ReadBytes((int)num2);
		if (x26000ce44ebda9ea.xf73042981b08c3f7(xbf5a7e14ee8e42b, 268435456))
		{
			x824a51111d1ad0a4(array);
		}
		if (x26000ce44ebda9ea.xf73042981b08c3f7(xbf5a7e14ee8e42b, 4))
		{
			array = xe6eaeb8a1018d62a.xf76803be5e9ee2aa(array);
		}
		return array;
	}

	private static xcb8bd210026f27bc x6c168122d9ebdca6(int x272bc993a9d89cb6)
	{
		return x272bc993a9d89cb6 switch
		{
			65536 => xcb8bd210026f27bc.x2d32dac78ff5c1fb, 
			131073 => xcb8bd210026f27bc.xf85465796a4911d0, 
			131074 => xcb8bd210026f27bc.xe6de700539dd7656, 
			_ => xcb8bd210026f27bc.xf6c17f648b65c793, 
		};
	}

	private static void x824a51111d1ad0a4(byte[] x0db5e88527e18b81)
	{
		for (int i = 0; i < x0db5e88527e18b81.Length; i++)
		{
			x0db5e88527e18b81[i] = (byte)(x0db5e88527e18b81[i] ^ 0x50u);
		}
	}
}
