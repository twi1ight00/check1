using System.IO;
using x6c95d9cf46ff5f25;

namespace x38a89dee67fc7a16;

internal class x1c047fe8b1465e42
{
	private const ushort x86dd572c91d4f094 = 1;

	private const ushort x43a62dbb1a213744 = 4;

	private readonly long x74afe665483b0b92;

	private uint xd74c65b8d28b1740;

	private uint x8918dc7c534575e5;

	private double xdd5b32d64ccc2330;

	private double x3bf767adc197eb5c;

	private xd98a74f601ff6302 x039eb3c312e07a1b = xd98a74f601ff6302.xa0d7d1e10a42163a;

	private x22f5ba34a82a8fcb x3cbf95d1cae99683 = x22f5ba34a82a8fcb.x12a36b56521f3632;

	private x858159a2ee718ca5 x4a66f2abeb17a818 = x858159a2ee718ca5.x4d0b9d4447ba7566;

	private x1800d50a23725505 x3c5a879dec9bd66f = x1800d50a23725505.x61796aac0d56fb65;

	private xea3ce45c7a5f886d x7072c8eaf673048f = xea3ce45c7a5f886d.xf3119ae74f13ec2d;

	private ushort x28de69df171d1282 = 1;

	private ushort x47fb009cb825f1ce = 4;

	private ushort[] xb2961e7e54ae4624 = new ushort[1];

	public int x14e8b156e543b781
	{
		get
		{
			if (xd74c65b8d28b1740 == 0)
			{
				return 100;
			}
			return (int)xd74c65b8d28b1740;
		}
	}

	public int x0fcd93defd62912a
	{
		get
		{
			if (x8918dc7c534575e5 == 0)
			{
				return 100;
			}
			return (int)x8918dc7c534575e5;
		}
	}

	public double x91fd56349bcbd19a => xdd5b32d64ccc2330;

	public double xa15f3bd9139b31c2 => x3bf767adc197eb5c;

	public bool x1bf0af404c1b05e9
	{
		get
		{
			if (x3cbf95d1cae99683 != x22f5ba34a82a8fcb.x4d0b9d4447ba7566 && x3cbf95d1cae99683 != x22f5ba34a82a8fcb.x12a36b56521f3632 && x3cbf95d1cae99683 != x22f5ba34a82a8fcb.x9a0c4af681302747)
			{
				return false;
			}
			if (!x6c26df414c2f36ca && !x1a45922beb1c2175 && !xf52e1d9a88552b26 && !x8b4acbfca33efe22)
			{
				return x79ae9fd93a17d020;
			}
			return true;
		}
	}

	private bool x6c26df414c2f36ca
	{
		get
		{
			if ((x039eb3c312e07a1b == xd98a74f601ff6302.x3c21ee72dc24790e || x039eb3c312e07a1b == xd98a74f601ff6302.xff02aba05f183bcd) && xb2961e7e54ae4624[0] == 0)
			{
				if (x4a66f2abeb17a818 != x858159a2ee718ca5.x4d0b9d4447ba7566 && x4a66f2abeb17a818 != x858159a2ee718ca5.x67749da60288d66c && x4a66f2abeb17a818 != x858159a2ee718ca5.xf6875da725c82a98 && x4a66f2abeb17a818 != x858159a2ee718ca5.xd9c34d7c9f00a2f9 && x4a66f2abeb17a818 != x858159a2ee718ca5.x79eafe89940e5b0e)
				{
					return x4a66f2abeb17a818 == x858159a2ee718ca5.x38e60322261de778;
				}
				return true;
			}
			return false;
		}
	}

	private bool x1a45922beb1c2175
	{
		get
		{
			if ((x039eb3c312e07a1b == xd98a74f601ff6302.x3c21ee72dc24790e || x039eb3c312e07a1b == xd98a74f601ff6302.xff02aba05f183bcd) && (xb2961e7e54ae4624[0] == 4 || xb2961e7e54ae4624[0] == 8 || xb2961e7e54ae4624[0] == 16))
			{
				if (x4a66f2abeb17a818 != x858159a2ee718ca5.x4d0b9d4447ba7566 && x4a66f2abeb17a818 != x858159a2ee718ca5.x67749da60288d66c)
				{
					return x4a66f2abeb17a818 == x858159a2ee718ca5.x38e60322261de778;
				}
				return true;
			}
			return false;
		}
	}

	private bool xf52e1d9a88552b26
	{
		get
		{
			if (x039eb3c312e07a1b == xd98a74f601ff6302.x7ca143d33b68b1cd && (xb2961e7e54ae4624[0] == 1 || xb2961e7e54ae4624[0] == 4 || xb2961e7e54ae4624[0] == 8))
			{
				if (x4a66f2abeb17a818 != x858159a2ee718ca5.x4d0b9d4447ba7566 && x4a66f2abeb17a818 != x858159a2ee718ca5.x79eafe89940e5b0e)
				{
					return x4a66f2abeb17a818 == x858159a2ee718ca5.x38e60322261de778;
				}
				return true;
			}
			return false;
		}
	}

	private bool x8b4acbfca33efe22
	{
		get
		{
			if (x039eb3c312e07a1b == xd98a74f601ff6302.x2c689d7a8a2c3c93 && x3c5a879dec9bd66f == x1800d50a23725505.x61796aac0d56fb65 && xb2961e7e54ae4624.Length == x28de69df171d1282 && x7c77059c31110ada)
			{
				if (x4a66f2abeb17a818 != x858159a2ee718ca5.x4d0b9d4447ba7566 && x4a66f2abeb17a818 != x858159a2ee718ca5.x79eafe89940e5b0e && x4a66f2abeb17a818 != x858159a2ee718ca5.x796ab23ce57ee1e0)
				{
					return x4a66f2abeb17a818 == x858159a2ee718ca5.x38e60322261de778;
				}
				return true;
			}
			return false;
		}
	}

	private bool x79ae9fd93a17d020
	{
		get
		{
			if (x039eb3c312e07a1b == xd98a74f601ff6302.xf3119ae74f13ec2d && x3c5a879dec9bd66f == x1800d50a23725505.x61796aac0d56fb65 && x7072c8eaf673048f == xea3ce45c7a5f886d.xf3119ae74f13ec2d && x47fb009cb825f1ce == 4 && xb2961e7e54ae4624.Length == x28de69df171d1282 && x7c77059c31110ada)
			{
				if (x4a66f2abeb17a818 != x858159a2ee718ca5.x4d0b9d4447ba7566 && x4a66f2abeb17a818 != x858159a2ee718ca5.x79eafe89940e5b0e && x4a66f2abeb17a818 != x858159a2ee718ca5.x796ab23ce57ee1e0)
				{
					return x4a66f2abeb17a818 == x858159a2ee718ca5.x38e60322261de778;
				}
				return true;
			}
			return false;
		}
	}

	private bool x7c77059c31110ada
	{
		get
		{
			bool flag = xb2961e7e54ae4624[0] == 8 || xb2961e7e54ae4624[0] == 16;
			for (int i = 0; i < xb2961e7e54ae4624.Length; i++)
			{
				flag = flag && xb2961e7e54ae4624[i] == xb2961e7e54ae4624[0];
			}
			return flag;
		}
	}

	public x1c047fe8b1465e42(byte[] imageBytes)
		: this(new MemoryStream(imageBytes))
	{
	}

	public x1c047fe8b1465e42(Stream imageStream)
		: this(new xa8866d7566da0aa2(imageStream))
	{
	}

	public x1c047fe8b1465e42(xa8866d7566da0aa2 reader)
	{
		x74afe665483b0b92 = reader.x9e418ad9a56d1cf5.Position;
		xa94ad96daa38fef6(reader);
	}

	private void xa94ad96daa38fef6(xa8866d7566da0aa2 xe134235b3526fa75)
	{
		short num = xe134235b3526fa75.x2e6b89ad8001e18f();
		bool x3d70d9580008e = num == 19789;
		ushort num2 = x29d047c5edca4872(xe134235b3526fa75, x3d70d9580008e);
		if (num2 != 42)
		{
			return;
		}
		uint num3 = x9d5a1b62e244390e(xe134235b3526fa75, x3d70d9580008e);
		xe134235b3526fa75.x9e418ad9a56d1cf5.Position = x74afe665483b0b92 + num3;
		ushort num4 = x29d047c5edca4872(xe134235b3526fa75, x3d70d9580008e);
		long num5 = xe134235b3526fa75.x9e418ad9a56d1cf5.Position;
		for (int i = 0; i < num4; i++)
		{
			xe134235b3526fa75.x9e418ad9a56d1cf5.Position = num5;
			num5 += 12;
			ushort num6 = x29d047c5edca4872(xe134235b3526fa75, x3d70d9580008e);
			ushort num7 = x29d047c5edca4872(xe134235b3526fa75, x3d70d9580008e);
			uint num8 = x9d5a1b62e244390e(xe134235b3526fa75, x3d70d9580008e);
			if (((num7 == 1 || num7 == 2) && num8 > 4) || (num7 == 3 && num8 > 2) || (num7 == 4 && num8 > 1) || num7 == 5)
			{
				uint num9 = x9d5a1b62e244390e(xe134235b3526fa75, x3d70d9580008e);
				xe134235b3526fa75.x9e418ad9a56d1cf5.Position = x74afe665483b0b92 + num9;
			}
			switch (num6)
			{
			case 256:
				xd74c65b8d28b1740 = ((num7 == 3) ? x29d047c5edca4872(xe134235b3526fa75, x3d70d9580008e) : x9d5a1b62e244390e(xe134235b3526fa75, x3d70d9580008e));
				break;
			case 257:
				x8918dc7c534575e5 = ((num7 == 3) ? x29d047c5edca4872(xe134235b3526fa75, x3d70d9580008e) : x9d5a1b62e244390e(xe134235b3526fa75, x3d70d9580008e));
				break;
			case 282:
				xdd5b32d64ccc2330 = x1ab801ddf17d764e(xe134235b3526fa75, x3d70d9580008e);
				break;
			case 283:
				x3bf767adc197eb5c = x1ab801ddf17d764e(xe134235b3526fa75, x3d70d9580008e);
				break;
			case 262:
				x039eb3c312e07a1b = (xd98a74f601ff6302)x29d047c5edca4872(xe134235b3526fa75, x3d70d9580008e);
				break;
			case 296:
				x3cbf95d1cae99683 = (x22f5ba34a82a8fcb)x29d047c5edca4872(xe134235b3526fa75, x3d70d9580008e);
				break;
			case 259:
				x4a66f2abeb17a818 = (x858159a2ee718ca5)x29d047c5edca4872(xe134235b3526fa75, x3d70d9580008e);
				break;
			case 258:
				xb2961e7e54ae4624 = xaa8141cf87feb753(xe134235b3526fa75, x3d70d9580008e, num8);
				break;
			case 284:
				x3c5a879dec9bd66f = (x1800d50a23725505)x29d047c5edca4872(xe134235b3526fa75, x3d70d9580008e);
				break;
			case 277:
				x28de69df171d1282 = x29d047c5edca4872(xe134235b3526fa75, x3d70d9580008e);
				break;
			case 332:
				x7072c8eaf673048f = (xea3ce45c7a5f886d)x29d047c5edca4872(xe134235b3526fa75, x3d70d9580008e);
				break;
			case 334:
				x47fb009cb825f1ce = x29d047c5edca4872(xe134235b3526fa75, x3d70d9580008e);
				break;
			}
		}
	}

	public static bool x4ed600f0cf9f5b0c(byte[] x4a3f0a05c02f235f)
	{
		using MemoryStream xcf18e5243f8d5fd = new MemoryStream(x4a3f0a05c02f235f);
		return x4ed600f0cf9f5b0c(xcf18e5243f8d5fd);
	}

	public static bool x4ed600f0cf9f5b0c(Stream xcf18e5243f8d5fd3)
	{
		BinaryReader binaryReader = new BinaryReader(xcf18e5243f8d5fd3);
		int num = binaryReader.ReadInt16();
		if (num != 18761)
		{
			return num == 19789;
		}
		return true;
	}

	private static ushort x29d047c5edca4872(xa8866d7566da0aa2 xe134235b3526fa75, bool x3d70d9580008e911)
	{
		ushort num = xe134235b3526fa75.xdb264d863790ee7b();
		if (!x3d70d9580008e911)
		{
			num = x26000ce44ebda9ea.xb26c35b8f72ab749(num);
		}
		return num;
	}

	private static uint x9d5a1b62e244390e(xa8866d7566da0aa2 xe134235b3526fa75, bool x3d70d9580008e911)
	{
		uint num = xe134235b3526fa75.x2aa9a7ff4efa6ddf();
		if (!x3d70d9580008e911)
		{
			num = x26000ce44ebda9ea.x539dc61123306a51(num);
		}
		return num;
	}

	private static ushort[] xaa8141cf87feb753(xa8866d7566da0aa2 xe134235b3526fa75, bool x3d70d9580008e911, uint x4de2e1f96b762443)
	{
		ushort[] array = new ushort[x4de2e1f96b762443];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = x29d047c5edca4872(xe134235b3526fa75, x3d70d9580008e911);
		}
		return array;
	}

	private static double x1ab801ddf17d764e(xa8866d7566da0aa2 xe134235b3526fa75, bool x3d70d9580008e911)
	{
		uint num = x9d5a1b62e244390e(xe134235b3526fa75, x3d70d9580008e911);
		uint num2 = x9d5a1b62e244390e(xe134235b3526fa75, x3d70d9580008e911);
		return (num2 != 0) ? (num / num2) : 0u;
	}
}
