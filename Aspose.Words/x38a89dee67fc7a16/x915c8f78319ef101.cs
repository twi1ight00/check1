using System.IO;

namespace x38a89dee67fc7a16;

internal class x915c8f78319ef101
{
	internal const int xa230444f4711f2cc = 40;

	internal int x437e3b626c0fdd43 = 40;

	internal int xdc1bf80853046136;

	internal int xb0f146032f47c24e;

	internal ushort x80f735ca6313e2a9;

	internal ushort xce53a4f2835cab70;

	internal uint x71a6ddb5fe0b25f5;

	internal uint x5c0e6ccaf80e6f55;

	internal int xf5547eeeda8d5059;

	internal int x7a5cb8870c565aea;

	internal uint x01571e32334b32e8;

	internal uint x4591cb72ff824525;

	internal int x05d54d372c55b01e
	{
		get
		{
			if ((xce53a4f2835cab70 == 32 || xce53a4f2835cab70 == 16) && x71a6ddb5fe0b25f5 == 3)
			{
				return 12;
			}
			if (xce53a4f2835cab70 > 8)
			{
				return 0;
			}
			int num = ((x01571e32334b32e8 != 0) ? ((int)x01571e32334b32e8) : (1 << (int)xce53a4f2835cab70));
			return num * 4;
		}
	}

	internal x915c8f78319ef101()
	{
	}

	internal void x06b0e25aa6ad68a9(BinaryReader xe134235b3526fa75)
	{
		x437e3b626c0fdd43 = xe134235b3526fa75.ReadInt32();
		switch (x437e3b626c0fdd43)
		{
		case 12:
			x437e3b626c0fdd43 = 40;
			xdc1bf80853046136 = xe134235b3526fa75.ReadUInt16();
			xb0f146032f47c24e = xe134235b3526fa75.ReadUInt16();
			x80f735ca6313e2a9 = xe134235b3526fa75.ReadUInt16();
			xce53a4f2835cab70 = xe134235b3526fa75.ReadUInt16();
			break;
		default:
			xdc1bf80853046136 = xe134235b3526fa75.ReadInt32();
			xb0f146032f47c24e = xe134235b3526fa75.ReadInt32();
			x80f735ca6313e2a9 = xe134235b3526fa75.ReadUInt16();
			xce53a4f2835cab70 = xe134235b3526fa75.ReadUInt16();
			x71a6ddb5fe0b25f5 = xe134235b3526fa75.ReadUInt32();
			x5c0e6ccaf80e6f55 = xe134235b3526fa75.ReadUInt32();
			xf5547eeeda8d5059 = xe134235b3526fa75.ReadInt32();
			x7a5cb8870c565aea = xe134235b3526fa75.ReadInt32();
			x01571e32334b32e8 = xe134235b3526fa75.ReadUInt32();
			x4591cb72ff824525 = xe134235b3526fa75.ReadUInt32();
			break;
		}
	}

	internal void x6210059f049f0d48(BinaryWriter xbdfb620b7167944b)
	{
		xbdfb620b7167944b.Write(x437e3b626c0fdd43);
		xbdfb620b7167944b.Write(xdc1bf80853046136);
		xbdfb620b7167944b.Write(xb0f146032f47c24e);
		xbdfb620b7167944b.Write((short)x80f735ca6313e2a9);
		xbdfb620b7167944b.Write((short)xce53a4f2835cab70);
		xbdfb620b7167944b.Write((int)x71a6ddb5fe0b25f5);
		xbdfb620b7167944b.Write((int)x5c0e6ccaf80e6f55);
		xbdfb620b7167944b.Write(xf5547eeeda8d5059);
		xbdfb620b7167944b.Write(x7a5cb8870c565aea);
		xbdfb620b7167944b.Write((int)x01571e32334b32e8);
		xbdfb620b7167944b.Write((int)x4591cb72ff824525);
	}
}
