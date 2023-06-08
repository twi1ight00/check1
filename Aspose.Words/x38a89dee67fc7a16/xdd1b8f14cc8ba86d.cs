using System;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Text;
using Aspose;
using x13f1efc79617a47b;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;
using x74500b509de15565;
using xa7850104c8d8c135;

namespace x38a89dee67fc7a16;

internal class xdd1b8f14cc8ba86d
{
	private const double x0ab3d40da307c5ad = 39.37007874015748;

	public const float x69ac478a39d121cc = 96f;

	public const int xd628c9e5a750e293 = 300;

	private xdd1b8f14cc8ba86d()
	{
	}

	public static xfe2ff3c162b47c70 x22bfb60fc9ca9282(byte[] x4a3f0a05c02f235f)
	{
		if (x4a3f0a05c02f235f == null || x4a3f0a05c02f235f.Length == 0)
		{
			return xfe2ff3c162b47c70.xf6c17f648b65c793;
		}
		using Stream xcf18e5243f8d5fd = new MemoryStream(x4a3f0a05c02f235f);
		return x22bfb60fc9ca9282(xcf18e5243f8d5fd);
	}

	public static xfe2ff3c162b47c70 x22bfb60fc9ca9282(Stream xcf18e5243f8d5fd3)
	{
		if (xcf18e5243f8d5fd3 == null || xcf18e5243f8d5fd3.Length == 0)
		{
			return xfe2ff3c162b47c70.xf6c17f648b65c793;
		}
		long position = xcf18e5243f8d5fd3.Position;
		try
		{
			bool flag = xa112135733098ff7(xcf18e5243f8d5fd3);
			xcf18e5243f8d5fd3.Position = position;
			if (flag)
			{
				return xfe2ff3c162b47c70.xb5fe04c34562f438;
			}
			flag = xf04378a5bde2c741(xcf18e5243f8d5fd3);
			xcf18e5243f8d5fd3.Position = position;
			if (flag)
			{
				return xfe2ff3c162b47c70.xb5fe04c34562f438;
			}
			flag = xb9c89ee787d0f8de(xcf18e5243f8d5fd3);
			xcf18e5243f8d5fd3.Position = position;
			if (flag)
			{
				return xfe2ff3c162b47c70.xd69df86e2a88ddb2;
			}
			flag = xb2eef06ebfac9e03(xcf18e5243f8d5fd3);
			xcf18e5243f8d5fd3.Position = position;
			if (flag)
			{
				return xfe2ff3c162b47c70.x796ab23ce57ee1e0;
			}
			flag = x089c7614af854409(xcf18e5243f8d5fd3);
			xcf18e5243f8d5fd3.Position = position;
			if (flag)
			{
				return xfe2ff3c162b47c70.x6339cdb9e2b512c7;
			}
			flag = x29bd9635a09ae6a3(xcf18e5243f8d5fd3);
			xcf18e5243f8d5fd3.Position = position;
			if (flag)
			{
				return xfe2ff3c162b47c70.xc2746d872ce402e9;
			}
			flag = xe65281acce503132(xcf18e5243f8d5fd3);
			xcf18e5243f8d5fd3.Position = position;
			if (flag)
			{
				return xfe2ff3c162b47c70.x26c36dd85013b919;
			}
			flag = x1bfd70c1f4fe13bd(xcf18e5243f8d5fd3);
			xcf18e5243f8d5fd3.Position = position;
			if (flag)
			{
				return xfe2ff3c162b47c70.x8e716ec1cb703e9f;
			}
			flag = x4ed600f0cf9f5b0c(xcf18e5243f8d5fd3);
			xcf18e5243f8d5fd3.Position = position;
			if (flag)
			{
				return xfe2ff3c162b47c70.x15c106572f1e1fbf;
			}
			flag = x666cba10ac910cc0(xcf18e5243f8d5fd3);
			xcf18e5243f8d5fd3.Position = position;
			if (flag)
			{
				return xfe2ff3c162b47c70.x6fcc29eace04fce1;
			}
			flag = x5188b06a528c8ec9(xcf18e5243f8d5fd3);
			xcf18e5243f8d5fd3.Position = position;
			if (flag)
			{
				return xfe2ff3c162b47c70.x6b60f7630a7ba83e;
			}
		}
		catch (Exception)
		{
		}
		xcf18e5243f8d5fd3.Position = position;
		return xfe2ff3c162b47c70.xf6c17f648b65c793;
	}

	public static xfe2ff3c162b47c70 x50ba8f29b1c5ad67(string xe125219852864557)
	{
		return xb9015fe823e7e228.x0f2906e6dae0813a(Path.GetExtension(xe125219852864557));
	}

	public static xa2745adfabe0c674 x16a7fb03c627ebfb(string xb469c015ff0466a1)
	{
		using FileStream xc8f3f690897a858e = new FileStream(xb469c015ff0466a1, FileMode.Open);
		return x16a7fb03c627ebfb(xc8f3f690897a858e);
	}

	public static xa2745adfabe0c674 x16a7fb03c627ebfb(Stream xc8f3f690897a858e)
	{
		return x16a7fb03c627ebfb(xc8f3f690897a858e, x22bfb60fc9ca9282(xc8f3f690897a858e));
	}

	public static xa2745adfabe0c674 x16a7fb03c627ebfb(byte[] x43e181e083db6cdf)
	{
		return x16a7fb03c627ebfb(x43e181e083db6cdf, x22bfb60fc9ca9282(x43e181e083db6cdf));
	}

	public static xa2745adfabe0c674 x16a7fb03c627ebfb(byte[] x43e181e083db6cdf, xfe2ff3c162b47c70 x0182a6dae298f8a4)
	{
		return x16a7fb03c627ebfb(new MemoryStream(x43e181e083db6cdf), x0182a6dae298f8a4);
	}

	[JavaConvertCheckedExceptions]
	public static xa2745adfabe0c674 x16a7fb03c627ebfb(Stream xc8f3f690897a858e, xfe2ff3c162b47c70 x0182a6dae298f8a4)
	{
		long position = xc8f3f690897a858e.Position;
		xa2745adfabe0c674 result;
		switch (x0182a6dae298f8a4)
		{
		case xfe2ff3c162b47c70.xd69df86e2a88ddb2:
		case xfe2ff3c162b47c70.xb5fe04c34562f438:
			result = x59837dfeb1fc5a82(xc8f3f690897a858e);
			break;
		case xfe2ff3c162b47c70.x26c36dd85013b919:
			result = x50da520b0fc223ec(xc8f3f690897a858e);
			break;
		case xfe2ff3c162b47c70.xc2746d872ce402e9:
			result = x44229719ff801b86(xc8f3f690897a858e);
			break;
		case xfe2ff3c162b47c70.x6339cdb9e2b512c7:
			result = x5d8883ce13fdc89f(xc8f3f690897a858e);
			break;
		case xfe2ff3c162b47c70.x796ab23ce57ee1e0:
			result = xbb061e7ac9208b52(xc8f3f690897a858e);
			break;
		case xfe2ff3c162b47c70.x8e716ec1cb703e9f:
			result = x8ed0b86a5fd3c18d(xc8f3f690897a858e);
			break;
		case xfe2ff3c162b47c70.x15c106572f1e1fbf:
			result = x170379fd54d953bf(xc8f3f690897a858e);
			break;
		default:
			result = xa2745adfabe0c674.xe6a756f8b9f6fe18(100, 100, 96.0, 96.0);
			break;
		}
		xc8f3f690897a858e.Position = position;
		return result;
	}

	public static bool x4ed600f0cf9f5b0c(byte[] x4a3f0a05c02f235f)
	{
		return x1c047fe8b1465e42.x4ed600f0cf9f5b0c(x4a3f0a05c02f235f);
	}

	public static bool x4ed600f0cf9f5b0c(Stream xcf18e5243f8d5fd3)
	{
		return x1c047fe8b1465e42.x4ed600f0cf9f5b0c(xcf18e5243f8d5fd3);
	}

	public static bool xb2eef06ebfac9e03(byte[] x4a3f0a05c02f235f)
	{
		using MemoryStream xcf18e5243f8d5fd = new MemoryStream(x4a3f0a05c02f235f);
		return xb2eef06ebfac9e03(xcf18e5243f8d5fd);
	}

	public static bool xb2eef06ebfac9e03(Stream xcf18e5243f8d5fd3)
	{
		BinaryReader binaryReader = new BinaryReader(xcf18e5243f8d5fd3);
		uint num = binaryReader.ReadUInt16();
		if (num != 55551)
		{
			return false;
		}
		return true;
	}

	public static bool x089c7614af854409(byte[] x4a3f0a05c02f235f)
	{
		using MemoryStream xcf18e5243f8d5fd = new MemoryStream(x4a3f0a05c02f235f);
		return x089c7614af854409(xcf18e5243f8d5fd);
	}

	public static bool x089c7614af854409(Stream xcf18e5243f8d5fd3)
	{
		BinaryReader binaryReader = new BinaryReader(xcf18e5243f8d5fd3);
		uint num = binaryReader.ReadUInt32();
		if (num != 1196314761)
		{
			return false;
		}
		uint num2 = binaryReader.ReadUInt32();
		if (num2 != 169478669)
		{
			return false;
		}
		return true;
	}

	public static bool x29bd9635a09ae6a3(byte[] x4a3f0a05c02f235f)
	{
		using MemoryStream xcf18e5243f8d5fd = new MemoryStream(x4a3f0a05c02f235f);
		return x29bd9635a09ae6a3(xcf18e5243f8d5fd);
	}

	public static bool x29bd9635a09ae6a3(Stream xcf18e5243f8d5fd3)
	{
		BinaryReader binaryReader = new BinaryReader(xcf18e5243f8d5fd3);
		uint num = binaryReader.ReadUInt16();
		if (num != 19778)
		{
			return false;
		}
		uint num2 = binaryReader.ReadUInt32();
		binaryReader.ReadUInt32();
		uint num3 = binaryReader.ReadUInt32();
		if (num2 != 0 && num3 > num2)
		{
			return false;
		}
		uint num4 = binaryReader.ReadUInt32();
		bool flag = num4 == 12;
		if (!flag && num4 < 16)
		{
			return false;
		}
		if (flag)
		{
			binaryReader.ReadUInt32();
		}
		else
		{
			binaryReader.ReadInt32();
			binaryReader.ReadInt32();
		}
		uint num5 = binaryReader.ReadUInt16();
		if (num5 != 1)
		{
			return false;
		}
		uint num6 = binaryReader.ReadUInt16();
		if (num6 != 1 && num6 != 4 && num6 != 8 && num6 != 16 && num6 != 24 && num6 != 32)
		{
			return false;
		}
		return true;
	}

	public static bool x1bfd70c1f4fe13bd(byte[] x4a3f0a05c02f235f)
	{
		using MemoryStream xcf18e5243f8d5fd = new MemoryStream(x4a3f0a05c02f235f);
		return x1bfd70c1f4fe13bd(xcf18e5243f8d5fd);
	}

	public static bool x1bfd70c1f4fe13bd(Stream xcf18e5243f8d5fd3)
	{
		BinaryReader binaryReader = new BinaryReader(xcf18e5243f8d5fd3);
		int num = binaryReader.ReadInt32() & 0xFFFFFF;
		return num == 4606279;
	}

	public static bool xe65281acce503132(byte[] x4a3f0a05c02f235f)
	{
		using MemoryStream xcf18e5243f8d5fd = new MemoryStream(x4a3f0a05c02f235f);
		return xe65281acce503132(xcf18e5243f8d5fd);
	}

	public static bool xe65281acce503132(Stream xcf18e5243f8d5fd3)
	{
		BinaryReader binaryReader = new BinaryReader(xcf18e5243f8d5fd3);
		binaryReader.ReadUInt16();
		binaryReader.ReadUInt16();
		binaryReader.ReadUInt16();
		binaryReader.ReadUInt16();
		binaryReader.ReadUInt16();
		switch (x26000ce44ebda9ea.xb26c35b8f72ab749(binaryReader.ReadUInt16()))
		{
		case 273:
			return true;
		case 17:
		{
			int num = x26000ce44ebda9ea.xb26c35b8f72ab749(binaryReader.ReadUInt16());
			if (num == 767)
			{
				return true;
			}
			break;
		}
		}
		return false;
	}

	public static bool x1967a07ab3a7757e(byte[] x4a3f0a05c02f235f)
	{
		using MemoryStream input = new MemoryStream(x4a3f0a05c02f235f);
		BinaryReader binaryReader = new BinaryReader(input);
		uint num = binaryReader.ReadUInt16();
		if (num != 40)
		{
			return false;
		}
		return true;
	}

	public static bool xa112135733098ff7(byte[] x43e181e083db6cdf)
	{
		using MemoryStream xc8f3f690897a858e = new MemoryStream(x43e181e083db6cdf);
		return xa112135733098ff7(xc8f3f690897a858e);
	}

	public static bool xa112135733098ff7(Stream xc8f3f690897a858e)
	{
		if (xc8f3f690897a858e.Length < 18)
		{
			return false;
		}
		BinaryReader binaryReader = new BinaryReader(xc8f3f690897a858e);
		int num = binaryReader.ReadInt16();
		if (num != 0 && num != 1)
		{
			return false;
		}
		int num2 = binaryReader.ReadInt16();
		if (num2 != 9)
		{
			return false;
		}
		binaryReader.ReadInt16();
		binaryReader.ReadInt32();
		binaryReader.ReadInt16();
		binaryReader.ReadInt32();
		if (binaryReader.ReadInt16() != 0)
		{
			return false;
		}
		return true;
	}

	public static bool xf04378a5bde2c741(byte[] x43e181e083db6cdf)
	{
		using MemoryStream xc8f3f690897a858e = new MemoryStream(x43e181e083db6cdf);
		return xf04378a5bde2c741(xc8f3f690897a858e);
	}

	public static bool xf04378a5bde2c741(Stream xc8f3f690897a858e)
	{
		BinaryReader binaryReader = new BinaryReader(xc8f3f690897a858e);
		uint num = binaryReader.ReadUInt32();
		if (num != 2596720087u)
		{
			return false;
		}
		if (binaryReader.ReadInt16() != 0)
		{
			return false;
		}
		return true;
	}

	public static bool xc1b340365f5fd1f7(byte[] x43e181e083db6cdf)
	{
		if (!xa112135733098ff7(x43e181e083db6cdf))
		{
			return xf04378a5bde2c741(x43e181e083db6cdf);
		}
		return true;
	}

	public static bool xb9c89ee787d0f8de(byte[] x43e181e083db6cdf)
	{
		using MemoryStream xc8f3f690897a858e = new MemoryStream(x43e181e083db6cdf);
		return xb9c89ee787d0f8de(xc8f3f690897a858e);
	}

	public static bool xb9c89ee787d0f8de(Stream xc8f3f690897a858e)
	{
		BinaryReader binaryReader = new BinaryReader(xc8f3f690897a858e);
		uint num = binaryReader.ReadUInt32();
		if (num != 1)
		{
			return false;
		}
		binaryReader.BaseStream.Position = 40L;
		uint num2 = binaryReader.ReadUInt32();
		if (num2 != 1179469088)
		{
			return false;
		}
		return true;
	}

	public static bool x94d6c004900d4806(xfe2ff3c162b47c70 x0182a6dae298f8a4)
	{
		if (x0182a6dae298f8a4 != xfe2ff3c162b47c70.xb5fe04c34562f438)
		{
			return x0182a6dae298f8a4 == xfe2ff3c162b47c70.xd69df86e2a88ddb2;
		}
		return true;
	}

	public static bool x94d6c004900d4806(byte[] x43e181e083db6cdf)
	{
		return x94d6c004900d4806(x22bfb60fc9ca9282(x43e181e083db6cdf));
	}

	public static bool x666cba10ac910cc0(Stream xcf18e5243f8d5fd3)
	{
		return x666cba10ac910cc0(x0d299f323d241756.x0c3d0a26320bf3c4(xcf18e5243f8d5fd3, 4));
	}

	public static bool x666cba10ac910cc0(byte[] x4a3f0a05c02f235f)
	{
		if (x4a3f0a05c02f235f != null)
		{
			if (x4a3f0a05c02f235f[0] == 37 && x4a3f0a05c02f235f[1] == 80 && x4a3f0a05c02f235f[2] == 68)
			{
				return x4a3f0a05c02f235f[3] == 70;
			}
			return false;
		}
		return false;
	}

	public static bool x5188b06a528c8ec9(byte[] x4a3f0a05c02f235f)
	{
		using MemoryStream xcf18e5243f8d5fd = new MemoryStream(x4a3f0a05c02f235f);
		return x5188b06a528c8ec9(xcf18e5243f8d5fd);
	}

	public static bool x5188b06a528c8ec9(Stream xcf18e5243f8d5fd3)
	{
		try
		{
			xc1dcd6189d01216e xc1dcd6189d01216e = new xc1dcd6189d01216e(xcf18e5243f8d5fd3);
			if (xc1dcd6189d01216e.xa66385d80d4d296f.ToLower() == "svg" && xc1dcd6189d01216e.x91d35d7dc070c876 == "http://www.w3.org/2000/svg")
			{
				return true;
			}
			return false;
		}
		catch
		{
			return false;
		}
	}

	public static x3ad1f4cb1f0990ad x3c96a90989303334(byte[] x43e181e083db6cdf)
	{
		if (xb9c89ee787d0f8de(x43e181e083db6cdf))
		{
			using (MemoryStream input = new MemoryStream(x43e181e083db6cdf))
			{
				BinaryReader binaryReader = new BinaryReader(input);
				binaryReader.ReadUInt32();
				uint num = binaryReader.ReadUInt32();
				binaryReader.BaseStream.Position = num;
				uint num2 = binaryReader.ReadUInt32();
				if (num2 != 70)
				{
					return x3ad1f4cb1f0990ad.x6b99da0700ba955b;
				}
				binaryReader.ReadInt32();
				binaryReader.ReadInt32();
				int num3 = binaryReader.ReadInt32();
				if (num3 == 726027589)
				{
					int num4 = binaryReader.ReadUInt16();
					if (num4 != 16385)
					{
						return x3ad1f4cb1f0990ad.x6b99da0700ba955b;
					}
					int num5 = binaryReader.ReadUInt16();
					if ((num5 & 1) == 1)
					{
						return x3ad1f4cb1f0990ad.x93a6fe984442be6b;
					}
					return x3ad1f4cb1f0990ad.xd82e588b84205868;
				}
				return x3ad1f4cb1f0990ad.x6b99da0700ba955b;
			}
		}
		return x3ad1f4cb1f0990ad.xcde3a31c5a88fc93;
	}

	public static x3ad1f4cb1f0990ad x7d51d162df026657(byte[] x43e181e083db6cdf)
	{
		if (xa112135733098ff7(x43e181e083db6cdf))
		{
			return x3ad1f4cb1f0990ad.xb5fe04c34562f438;
		}
		if (xf04378a5bde2c741(x43e181e083db6cdf))
		{
			return x3ad1f4cb1f0990ad.x054b6b6a51ff7486;
		}
		return x3c96a90989303334(x43e181e083db6cdf);
	}

	public static x3ad1f4cb1f0990ad x7d51d162df026657(Stream xcf18e5243f8d5fd3)
	{
		xcf18e5243f8d5fd3.Position = 0L;
		return x7d51d162df026657(x0d299f323d241756.x0c3d0a26320bf3c4(xcf18e5243f8d5fd3, 512));
	}

	public static byte[] x10e7a0599aa303ae(BinaryReader xe134235b3526fa75, int xf3df8caccbf90f13)
	{
		int num = (int)xe134235b3526fa75.BaseStream.Position;
		x915c8f78319ef101 x915c8f78319ef102 = new x915c8f78319ef101();
		x915c8f78319ef102.x06b0e25aa6ad68a9(xe134235b3526fa75);
		xe134235b3526fa75.BaseStream.Position = num;
		int num2 = x915c8f78319ef102.x437e3b626c0fdd43 + x915c8f78319ef102.x05d54d372c55b01e;
		return x10e7a0599aa303ae(xe134235b3526fa75, num2, xf3df8caccbf90f13 - num2);
	}

	public static byte[] x10e7a0599aa303ae(BinaryReader xe134235b3526fa75, int xe873ef11b0a8e5d9, int xced22864f0ce3ee6)
	{
		int num = (int)xe134235b3526fa75.BaseStream.Position;
		x915c8f78319ef101 x915c8f78319ef102 = new x915c8f78319ef101();
		x915c8f78319ef102.x06b0e25aa6ad68a9(xe134235b3526fa75);
		byte[] xc9808022f4ecf = xe134235b3526fa75.ReadBytes(x915c8f78319ef102.x05d54d372c55b01e);
		xe134235b3526fa75.BaseStream.Position = num + xe873ef11b0a8e5d9;
		return xb84bf905df8c2961(x915c8f78319ef102, xc9808022f4ecf, xe134235b3526fa75, xced22864f0ce3ee6);
	}

	internal static byte[] xb84bf905df8c2961(x915c8f78319ef101 xd3c24a6f8f17d348, x26d9ecb4bdf0456d[] xc9808022f4ecf319, BinaryReader xe134235b3526fa75, int x0bdd6c63d4872aa6)
	{
		return xb84bf905df8c2961(xd3c24a6f8f17d348, xc2693658405c3600(xc9808022f4ecf319), xe134235b3526fa75, x0bdd6c63d4872aa6);
	}

	private static byte[] xc2693658405c3600(x26d9ecb4bdf0456d[] xc9808022f4ecf319)
	{
		byte[] array = new byte[xc9808022f4ecf319.Length * 4];
		for (int i = 0; i < xc9808022f4ecf319.Length; i++)
		{
			array[4 * i] = (byte)xc9808022f4ecf319[i].x8e8f6cc6a0756b05;
			array[4 * i + 1] = (byte)xc9808022f4ecf319[i].x26463655896fd90a;
			array[4 * i + 2] = (byte)xc9808022f4ecf319[i].xc613adc4330033f3;
			array[4 * i + 3] = 0;
		}
		return array;
	}

	internal static byte[] xb84bf905df8c2961(x915c8f78319ef101 xd3c24a6f8f17d348, byte[] xc9808022f4ecf319, BinaryReader xe134235b3526fa75, int x0bdd6c63d4872aa6)
	{
		int num = 14 + xd3c24a6f8f17d348.x437e3b626c0fdd43 + xc9808022f4ecf319.Length;
		byte[] array = new byte[num + x0bdd6c63d4872aa6];
		using MemoryStream output = new MemoryStream(array);
		BinaryWriter binaryWriter = new BinaryWriter(output);
		x50037126099ecac7 x50037126099ecac8 = new x50037126099ecac7();
		x50037126099ecac8.x437e3b626c0fdd43 = (uint)(num + x0bdd6c63d4872aa6);
		x50037126099ecac8.x990ff855f953a143 = (uint)num;
		x50037126099ecac8.x6210059f049f0d48(binaryWriter);
		xd3c24a6f8f17d348.x6210059f049f0d48(binaryWriter);
		binaryWriter.Write(xc9808022f4ecf319);
		binaryWriter.Flush();
		xe134235b3526fa75.Read(array, num, x0bdd6c63d4872aa6);
		return array;
	}

	public static byte[] xaef648f0fd1e5f8e(int x9b0739496f8b5475, int x4d5aabc7a55b12ba, int x95621538cdd84e0c, int xc96b6f9ff71ab366, int x71e74606dda4bdd9, int x80ff1ce603a06d5e, int xac1b90c8cfc4187d, byte[] x6cf40389cd4c82ce)
	{
		if (x71e74606dda4bdd9 != 1)
		{
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("kgockjfdpimdbidemhkekibfihifehpfncggldnghcehehlhngcipfjijgajnfhjfbojbgfknfmkifdlcgklgabmleimfepmpegnpdnnfaeo", 1932078629)));
		}
		if (x80ff1ce603a06d5e != 1)
		{
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("opmkoceldcllfbcmabjmobanmahniaonbmeopmlollcpkpjpopaagaiapkoampfboombipdcdkkcapbdgoidcppdmngeaonebjefnnlfjncgenjgonahcihhhmohbmfilmmilldjbikj", 1560915129)));
		}
		int num = 62 + x6cf40389cd4c82ce.Length * 2;
		byte[] array = new byte[num];
		using MemoryStream output = new MemoryStream(array);
		BinaryWriter binaryWriter = new BinaryWriter(output);
		x50037126099ecac7 x50037126099ecac8 = new x50037126099ecac7();
		x50037126099ecac8.x437e3b626c0fdd43 = (uint)num;
		x50037126099ecac8.x990ff855f953a143 = 62u;
		x50037126099ecac8.x6210059f049f0d48(binaryWriter);
		x915c8f78319ef101 x915c8f78319ef102 = new x915c8f78319ef101();
		x915c8f78319ef102.xdc1bf80853046136 = x9b0739496f8b5475;
		x915c8f78319ef102.xb0f146032f47c24e = x4d5aabc7a55b12ba;
		x915c8f78319ef102.x80f735ca6313e2a9 = (ushort)x71e74606dda4bdd9;
		x915c8f78319ef102.xce53a4f2835cab70 = (ushort)x80ff1ce603a06d5e;
		x915c8f78319ef102.xf5547eeeda8d5059 = x95621538cdd84e0c;
		x915c8f78319ef102.x7a5cb8870c565aea = xc96b6f9ff71ab366;
		x915c8f78319ef102.x6210059f049f0d48(binaryWriter);
		binaryWriter.Write(0);
		binaryWriter.Write(16777215);
		binaryWriter.Flush();
		int num2 = x0d299f323d241756.x8b2ecf3d830a9342(xac1b90c8cfc4187d, 4);
		int num3 = num2 - xac1b90c8cfc4187d;
		int num4 = (int)x50037126099ecac8.x990ff855f953a143;
		for (int num5 = x4d5aabc7a55b12ba - 1; num5 >= 0; num5--)
		{
			for (int i = 0; i < xac1b90c8cfc4187d; i++)
			{
				int num6 = num5 * xac1b90c8cfc4187d + i;
				array[num4] = x6cf40389cd4c82ce[num6];
				num4++;
			}
			for (int j = 0; j < num3; j++)
			{
				array[num4] = 0;
				num4++;
			}
		}
		return array;
	}

	public static xa2745adfabe0c674 x44229719ff801b86(byte[] x43e181e083db6cdf)
	{
		using MemoryStream xc8f3f690897a858e = new MemoryStream(x43e181e083db6cdf);
		return x44229719ff801b86(xc8f3f690897a858e);
	}

	public static xa2745adfabe0c674 x44229719ff801b86(Stream xc8f3f690897a858e)
	{
		xc8f3f690897a858e.Position = 14L;
		BinaryReader xe134235b3526fa = new BinaryReader(xc8f3f690897a858e);
		x915c8f78319ef101 x915c8f78319ef102 = new x915c8f78319ef101();
		x915c8f78319ef102.x06b0e25aa6ad68a9(xe134235b3526fa);
		return xa2745adfabe0c674.xe6a756f8b9f6fe18(x915c8f78319ef102.xdc1bf80853046136, Math.Abs(x915c8f78319ef102.xb0f146032f47c24e), xe3fe762bd89d8658(x915c8f78319ef102.xf5547eeeda8d5059), xe3fe762bd89d8658(x915c8f78319ef102.x7a5cb8870c565aea));
	}

	public static xa2745adfabe0c674 x8ed0b86a5fd3c18d(byte[] x43e181e083db6cdf)
	{
		using MemoryStream xc8f3f690897a858e = new MemoryStream(x43e181e083db6cdf);
		return x8ed0b86a5fd3c18d(xc8f3f690897a858e);
	}

	public static xa2745adfabe0c674 x8ed0b86a5fd3c18d(Stream xc8f3f690897a858e)
	{
		xc8f3f690897a858e.Position = 6L;
		BinaryReader binaryReader = new BinaryReader(xc8f3f690897a858e);
		ushort x9b0739496f8b = binaryReader.ReadUInt16();
		ushort x4d5aabc7a55b12ba = binaryReader.ReadUInt16();
		return xa2745adfabe0c674.xe6a756f8b9f6fe18(x9b0739496f8b, x4d5aabc7a55b12ba, 0.0, 0.0);
	}

	public static xa2745adfabe0c674 x5d8883ce13fdc89f(byte[] x43e181e083db6cdf)
	{
		using MemoryStream xcf18e5243f8d5fd = new MemoryStream(x43e181e083db6cdf);
		return x5d8883ce13fdc89f(xcf18e5243f8d5fd);
	}

	public static xa2745adfabe0c674 x5d8883ce13fdc89f(Stream xcf18e5243f8d5fd3)
	{
		xa8866d7566da0aa2 xa8866d7566da0aa = new xa8866d7566da0aa2(xcf18e5243f8d5fd3);
		xcf18e5243f8d5fd3.Position = 8L;
		int x9b0739496f8b = 0;
		int x4d5aabc7a55b12ba = 0;
		double x6088974b0138bee = 0.0;
		double x722d7c3d74d98c = 0.0;
		bool flag = false;
		while (!flag && xcf18e5243f8d5fd3.Position < xcf18e5243f8d5fd3.Length)
		{
			uint num = xa8866d7566da0aa.x2aa9a7ff4efa6ddf();
			switch (new string(xa8866d7566da0aa.x9a839f0ae94bc95f(4)))
			{
			case "IHDR":
				x9b0739496f8b = xa8866d7566da0aa.x95ea7d23cc8ee04d();
				x4d5aabc7a55b12ba = xa8866d7566da0aa.x95ea7d23cc8ee04d();
				xcf18e5243f8d5fd3.Seek(-8L, SeekOrigin.Current);
				break;
			case "pHYs":
			{
				int x5095ad3eae14470d = (int)xa8866d7566da0aa.x2aa9a7ff4efa6ddf();
				int x5095ad3eae14470d2 = (int)xa8866d7566da0aa.x2aa9a7ff4efa6ddf();
				short num2 = xa8866d7566da0aa.x672ed37ee25c078c();
				if (num2 == 1)
				{
					x6088974b0138bee = xe3fe762bd89d8658(x5095ad3eae14470d);
					x722d7c3d74d98c = xe3fe762bd89d8658(x5095ad3eae14470d2);
				}
				flag = true;
				break;
			}
			case "IEND":
				flag = true;
				break;
			}
			xcf18e5243f8d5fd3.Seek(num + 4, SeekOrigin.Current);
		}
		return xa2745adfabe0c674.xe6a756f8b9f6fe18(x9b0739496f8b, x4d5aabc7a55b12ba, x6088974b0138bee, x722d7c3d74d98c);
	}

	public static xa2745adfabe0c674 xbb061e7ac9208b52(byte[] x43e181e083db6cdf)
	{
		using MemoryStream xc8f3f690897a858e = new MemoryStream(x43e181e083db6cdf);
		return xbb061e7ac9208b52(xc8f3f690897a858e);
	}

	public static xa2745adfabe0c674 xbb061e7ac9208b52(Stream xc8f3f690897a858e)
	{
		xa8866d7566da0aa2 xa8866d7566da0aa = new xa8866d7566da0aa2(xc8f3f690897a858e);
		xa8866d7566da0aa.xdb264d863790ee7b();
		ushort num = xa8866d7566da0aa.xdb264d863790ee7b();
		PointF x1de68a531466236f = PointF.Empty;
		while ((num & 0xFFF0) != 65472 || num == 65476 || num == 65484)
		{
			if (!x632ef74d0186bef5(num, xa8866d7566da0aa, ref x1de68a531466236f))
			{
				ushort num2 = xa8866d7566da0aa.xdb264d863790ee7b();
				xc8f3f690897a858e.Seek(num2 - 2, SeekOrigin.Current);
			}
			num = xa8866d7566da0aa.xdb264d863790ee7b();
			if ((num & 0xFF00) != 65280)
			{
				num = xbba26440828bdc8b(xa8866d7566da0aa);
			}
		}
		xc8f3f690897a858e.Seek(3L, SeekOrigin.Current);
		int x4d5aabc7a55b12ba = xa8866d7566da0aa.xdb264d863790ee7b();
		int x9b0739496f8b = xa8866d7566da0aa.xdb264d863790ee7b();
		return xa2745adfabe0c674.xe6a756f8b9f6fe18(x9b0739496f8b, x4d5aabc7a55b12ba, x1de68a531466236f.X, x1de68a531466236f.Y);
	}

	private static bool x632ef74d0186bef5(ushort x8f2400368d1c57d3, xa8866d7566da0aa2 xe134235b3526fa75, ref PointF x1de68a531466236f)
	{
		switch (x8f2400368d1c57d3)
		{
		case 65504:
			xc666c80fc5ff73c0(xe134235b3526fa75, ref x1de68a531466236f);
			return true;
		case 65505:
			x0e8c7099554b9940(xe134235b3526fa75, ref x1de68a531466236f);
			return true;
		default:
			return false;
		}
	}

	private static void xc666c80fc5ff73c0(xa8866d7566da0aa2 xe134235b3526fa75, ref PointF x1de68a531466236f)
	{
		ushort num = xe134235b3526fa75.xdb264d863790ee7b();
		xe134235b3526fa75.x9e418ad9a56d1cf5.Seek(7L, SeekOrigin.Current);
		short num2 = xe134235b3526fa75.x672ed37ee25c078c();
		ushort num3 = xe134235b3526fa75.xdb264d863790ee7b();
		ushort num4 = xe134235b3526fa75.xdb264d863790ee7b();
		switch (num2)
		{
		case 1:
			x1de68a531466236f = new PointF((int)num3, (int)num4);
			break;
		case 2:
			x1de68a531466236f = new PointF((float)((double)(int)num3 * 2.54), (float)((double)(int)num4 * 2.54));
			break;
		}
		xe134235b3526fa75.x9e418ad9a56d1cf5.Seek(num - 14, SeekOrigin.Current);
	}

	private static void x0e8c7099554b9940(xa8866d7566da0aa2 xe134235b3526fa75, ref PointF x1de68a531466236f)
	{
		long position = xe134235b3526fa75.x9e418ad9a56d1cf5.Position;
		ushort num = xe134235b3526fa75.xdb264d863790ee7b();
		string text = new string(xe134235b3526fa75.x9a839f0ae94bc95f(6));
		if (text.StartsWith("Exif"))
		{
			x1c047fe8b1465e42 x1c047fe8b1465e43 = new x1c047fe8b1465e42(xe134235b3526fa75);
			if (x1c047fe8b1465e43.x91fd56349bcbd19a > 0.0 && x1c047fe8b1465e43.xa15f3bd9139b31c2 > 0.0)
			{
				x1de68a531466236f = new PointF((float)x1c047fe8b1465e43.x91fd56349bcbd19a, (float)x1c047fe8b1465e43.xa15f3bd9139b31c2);
			}
		}
		xe134235b3526fa75.x9e418ad9a56d1cf5.Position = position + num;
	}

	private static ushort xbba26440828bdc8b(xa8866d7566da0aa2 xe134235b3526fa75)
	{
		short num;
		do
		{
			num = xe134235b3526fa75.x672ed37ee25c078c();
		}
		while ((num & 0xFF) != 255);
		short num2 = xe134235b3526fa75.x672ed37ee25c078c();
		return (ushort)((ushort)(num << 8) | (ushort)num2);
	}

	public static xa2745adfabe0c674 x170379fd54d953bf(byte[] x43e181e083db6cdf)
	{
		return x170379fd54d953bf(new MemoryStream(x43e181e083db6cdf));
	}

	public static xa2745adfabe0c674 x170379fd54d953bf(Stream xc8f3f690897a858e)
	{
		x1c047fe8b1465e42 x1c047fe8b1465e43 = new x1c047fe8b1465e42(xc8f3f690897a858e);
		return xa2745adfabe0c674.xe6a756f8b9f6fe18(x1c047fe8b1465e43.x14e8b156e543b781, x1c047fe8b1465e43.x0fcd93defd62912a, x1c047fe8b1465e43.x91fd56349bcbd19a, x1c047fe8b1465e43.xa15f3bd9139b31c2);
	}

	public static xa2745adfabe0c674 x59837dfeb1fc5a82(byte[] x43e181e083db6cdf)
	{
		return x59837dfeb1fc5a82(new MemoryStream(x43e181e083db6cdf));
	}

	public static xa2745adfabe0c674 x59837dfeb1fc5a82(Stream xc8f3f690897a858e)
	{
		x3fa09e8d7b952fbc x3fa09e8d7b952fbc = new x3fa09e8d7b952fbc(xc8f3f690897a858e);
		return xa2745adfabe0c674.xe6a756f8b9f6fe18((int)x3fa09e8d7b952fbc.x2ae4e44a2787f337.Width, (int)x3fa09e8d7b952fbc.x2ae4e44a2787f337.Height, x3fa09e8d7b952fbc.xf2b3620f7bfc9ed5, x3fa09e8d7b952fbc.x5c6fc5693c6898cd);
	}

	public static xa2745adfabe0c674 x50da520b0fc223ec(byte[] x43e181e083db6cdf)
	{
		using MemoryStream xc8f3f690897a858e = new MemoryStream(x43e181e083db6cdf);
		return x50da520b0fc223ec(xc8f3f690897a858e);
	}

	public static xa2745adfabe0c674 x50da520b0fc223ec(Stream xc8f3f690897a858e)
	{
		BinaryReader binaryReader = new BinaryReader(xc8f3f690897a858e);
		binaryReader.ReadUInt16();
		int num = x26000ce44ebda9ea.xb26c35b8f72ab749(binaryReader.ReadUInt16());
		int num2 = x26000ce44ebda9ea.xb26c35b8f72ab749(binaryReader.ReadUInt16());
		int num3 = x26000ce44ebda9ea.xb26c35b8f72ab749(binaryReader.ReadUInt16());
		int num4 = x26000ce44ebda9ea.xb26c35b8f72ab749(binaryReader.ReadUInt16());
		int x1c991b839ad1125f = x4574ea26106f0edb.x3aa08882c9feaf96(num4 - num2);
		int xf578678e53bd422f = x4574ea26106f0edb.x3aa08882c9feaf96(num3 - num);
		return xa2745adfabe0c674.xa0a47601432e91a8(num2, num, num4, num3, x1c991b839ad1125f, xf578678e53bd422f);
	}

	public static byte[] x300bc69d382eb52c(byte[] x43e181e083db6cdf, xa2745adfabe0c674 x95dac044246123ac)
	{
		using MemoryStream memoryStream = new MemoryStream();
		BinaryWriter binaryWriter = new BinaryWriter(memoryStream, Encoding.Unicode);
		int num = 0;
		binaryWriter.Write((ushort)52695);
		num ^= 0xCDD7;
		binaryWriter.Write((ushort)39622);
		num ^= 0x9AC6;
		binaryWriter.Write((short)0);
		num = num;
		binaryWriter.Write((short)x95dac044246123ac.x72d92bd1aff02e37);
		num ^= x95dac044246123ac.x72d92bd1aff02e37;
		binaryWriter.Write((short)x95dac044246123ac.xe360b1885d8d4a41);
		num ^= x95dac044246123ac.xe360b1885d8d4a41;
		binaryWriter.Write((short)x95dac044246123ac.x419ba17a5322627b);
		num ^= x95dac044246123ac.x419ba17a5322627b;
		binaryWriter.Write((short)x95dac044246123ac.x9bcb07e204e30218);
		num ^= x95dac044246123ac.x9bcb07e204e30218;
		binaryWriter.Write((short)x95dac044246123ac.xf2b3620f7bfc9ed5);
		num ^= (int)x95dac044246123ac.xf2b3620f7bfc9ed5;
		binaryWriter.Write((short)0);
		num = num;
		binaryWriter.Write((short)0);
		num = num;
		binaryWriter.Write((ushort)num);
		binaryWriter.Write(x43e181e083db6cdf);
		return memoryStream.ToArray();
	}

	public static byte[] x36948be2ab2261b1(byte[] x43e181e083db6cdf)
	{
		if (xf04378a5bde2c741(x43e181e083db6cdf))
		{
			byte[] array = new byte[x43e181e083db6cdf.Length - 22];
			Array.Copy(x43e181e083db6cdf, 22, array, 0, array.Length);
			return array;
		}
		return x43e181e083db6cdf;
	}

	public static byte[] x9e116920a3e699d8(byte[] xd14440268e1b8cd1)
	{
		MemoryStream memoryStream = new MemoryStream(xd14440268e1b8cd1);
		BinaryReader xe134235b3526fa = new BinaryReader(memoryStream);
		x50037126099ecac7 x50037126099ecac8 = new x50037126099ecac7();
		x50037126099ecac8.x06b0e25aa6ad68a9(xe134235b3526fa);
		x915c8f78319ef101 x915c8f78319ef102 = new x915c8f78319ef101();
		x915c8f78319ef102.x06b0e25aa6ad68a9(xe134235b3526fa);
		memoryStream.Seek(-40L, SeekOrigin.Current);
		byte[] array = new byte[xd14440268e1b8cd1.Length - 14];
		memoryStream.Read(array, 0, array.Length);
		int num = (array.Length + 26 + 1) / 2;
		MemoryStream memoryStream2 = new MemoryStream();
		BinaryWriter binaryWriter = new BinaryWriter(memoryStream2);
		binaryWriter.Write((ushort)1);
		binaryWriter.Write((ushort)9);
		binaryWriter.Write((ushort)768);
		binaryWriter.Write((uint)(30 + num + 4 + 3));
		binaryWriter.Write((ushort)0);
		binaryWriter.Write((uint)num);
		binaryWriter.Write((ushort)0);
		binaryWriter.Write(4u);
		binaryWriter.Write((ushort)259);
		binaryWriter.Write((ushort)8);
		binaryWriter.Write(5u);
		binaryWriter.Write((ushort)523);
		binaryWriter.Write((ushort)0);
		binaryWriter.Write((ushort)0);
		binaryWriter.Write(5u);
		binaryWriter.Write((ushort)524);
		binaryWriter.Write((ushort)(x915c8f78319ef102.xb0f146032f47c24e + 1));
		binaryWriter.Write((ushort)(x915c8f78319ef102.xdc1bf80853046136 + 1));
		binaryWriter.Write(3u);
		binaryWriter.Write((ushort)30);
		binaryWriter.Write(4u);
		binaryWriter.Write((ushort)263);
		binaryWriter.Write((ushort)4);
		binaryWriter.Write((uint)num);
		binaryWriter.Write((ushort)2881);
		binaryWriter.Write(13369376u);
		binaryWriter.Write((ushort)x915c8f78319ef102.xb0f146032f47c24e);
		binaryWriter.Write((ushort)x915c8f78319ef102.xdc1bf80853046136);
		binaryWriter.Write((ushort)0);
		binaryWriter.Write((ushort)0);
		binaryWriter.Write((ushort)x915c8f78319ef102.xb0f146032f47c24e);
		binaryWriter.Write((ushort)x915c8f78319ef102.xdc1bf80853046136);
		binaryWriter.Write((ushort)0);
		binaryWriter.Write((ushort)0);
		binaryWriter.Write(array);
		if (x0d299f323d241756.x7e32f71c3f39b6bc(array.Length))
		{
			binaryWriter.Write((byte)0);
		}
		binaryWriter.Write(4u);
		binaryWriter.Write((ushort)295);
		binaryWriter.Write(ushort.MaxValue);
		binaryWriter.Write(3u);
		binaryWriter.Write((ushort)0);
		binaryWriter.Close();
		return memoryStream2.ToArray();
	}

	public static byte[] x8d9c7de3ed8f8607(int x9b0739496f8b5475, int x4d5aabc7a55b12ba)
	{
		MemoryStream memoryStream = new MemoryStream();
		BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
		binaryWriter.Write((ushort)1);
		binaryWriter.Write((ushort)9);
		binaryWriter.Write((ushort)768);
		binaryWriter.Write(26u);
		binaryWriter.Write((ushort)0);
		binaryWriter.Write(5u);
		binaryWriter.Write((ushort)0);
		binaryWriter.Write(4u);
		binaryWriter.Write((ushort)259);
		binaryWriter.Write((ushort)8);
		binaryWriter.Write(5u);
		binaryWriter.Write((ushort)523);
		binaryWriter.Write((ushort)0);
		binaryWriter.Write((ushort)0);
		binaryWriter.Write(5u);
		binaryWriter.Write((ushort)524);
		binaryWriter.Write((ushort)(x9b0739496f8b5475 + 1));
		binaryWriter.Write((ushort)(x4d5aabc7a55b12ba + 1));
		binaryWriter.Write(3u);
		binaryWriter.Write((ushort)0);
		binaryWriter.Close();
		return memoryStream.ToArray();
	}

	public static bool x92d069eca6ec3dfb(int x9b0739496f8b5475, int x4d5aabc7a55b12ba)
	{
		return x9b0739496f8b5475 * x4d5aabc7a55b12ba > 20971520;
	}

	internal static double xe3fe762bd89d8658(int x5095ad3eae14470d)
	{
		return (double)x5095ad3eae14470d / 39.37007874015748;
	}

	internal static int xc813712c5ace5def(double xfa7300893f01343a)
	{
		return (int)(xfa7300893f01343a * 39.37007874015748);
	}

	public static StringCollection xdf30c5cd56940123(byte[] xf9a0d04800d70471)
	{
		return x22bfb60fc9ca9282(xf9a0d04800d70471) switch
		{
			xfe2ff3c162b47c70.xb5fe04c34562f438 => x4f1e41f0c166b4ce.x06b0e25aa6ad68a9(xf9a0d04800d70471), 
			xfe2ff3c162b47c70.xd69df86e2a88ddb2 => xd85458a85f379338.x06b0e25aa6ad68a9(xf9a0d04800d70471), 
			_ => null, 
		};
	}
}
