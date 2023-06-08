using System;
using System.Collections;
using System.IO;
using x28925c9b27b37a46;

namespace x650fee20d618512c;

internal class xe526d9d41a46b695
{
	internal int x8a2ae9a469ed31be;

	internal int x22f9b3dbd98925ea;

	internal x4545604e3e0a6327 xef17eed5e57cb379;

	internal int x0d173b5435b4d6ad;

	internal xe526d9d41a46b695(BinaryReader reader)
	{
		reader.ReadInt16();
		reader.ReadInt16();
		x8a2ae9a469ed31be = reader.ReadUInt16();
		x22f9b3dbd98925ea = reader.ReadUInt16();
		xef17eed5e57cb379 = (x4545604e3e0a6327)reader.ReadInt16();
		x0d173b5435b4d6ad = reader.ReadInt32();
	}

	internal void x6210059f049f0d48(BinaryWriter xbdfb620b7167944b)
	{
		xbdfb620b7167944b.Write((short)0);
		xbdfb620b7167944b.Write((short)0);
		xbdfb620b7167944b.Write((short)x8a2ae9a469ed31be);
		xbdfb620b7167944b.Write((short)x22f9b3dbd98925ea);
		xbdfb620b7167944b.Write((short)xef17eed5e57cb379);
		xbdfb620b7167944b.Write(x0d173b5435b4d6ad);
	}

	internal xe526d9d41a46b695(x8ee6b62105cb1a44 keyMap, ArrayList macroNamesUpper)
	{
		x8a2ae9a469ed31be = keyMap.x57a5e17c3ececd6e;
		x22f9b3dbd98925ea = ((keyMap.xc6f6af1a95493305 == 0) ? 255 : keyMap.xc6f6af1a95493305);
		switch (keyMap.x3146d638ec378671)
		{
		case xf396a2b7859eb922.x4d0b9d4447ba7566:
			xef17eed5e57cb379 = x4545604e3e0a6327.xaf9c485b734d243f;
			x0d173b5435b4d6ad = -1;
			break;
		case xf396a2b7859eb922.x2c8724332a4788a6:
			xef17eed5e57cb379 = x4545604e3e0a6327.x2c8724332a4788a6;
			break;
		case xf396a2b7859eb922.xf5e19a19d8e0a0e6:
			xef17eed5e57cb379 = x4545604e3e0a6327.xaf9c485b734d243f;
			x0d173b5435b4d6ad = (keyMap.x2d2721048f49b2bd << 16) | 3;
			break;
		case xf396a2b7859eb922.x76ad36638702d9bf:
			xef17eed5e57cb379 = x4545604e3e0a6327.xaf9c485b734d243f;
			x0d173b5435b4d6ad = (keyMap.x8399367fe4b42e85 << 16) | ((int)keyMap.x74c5a2d6929342db << 3) | 1;
			break;
		case xf396a2b7859eb922.x9ad02857f9b5feb6:
			xef17eed5e57cb379 = x4545604e3e0a6327.xaf9c485b734d243f;
			x0d173b5435b4d6ad = (macroNamesUpper.Count << 16) | 2;
			macroNamesUpper.Add(keyMap.x71dd8c34587f8fc0);
			break;
		case xf396a2b7859eb922.xef7830d5b1716fcd:
			xef17eed5e57cb379 = x4545604e3e0a6327.xfb1fc02db7c42694;
			x0d173b5435b4d6ad = keyMap.x32dcc9d3ca30726c;
			break;
		default:
			throw new InvalidOperationException("Unknown keymap type.");
		}
	}

	internal x8ee6b62105cb1a44 xc3b9c8ea66b06532(Hashtable x35fc228f9d4513e3)
	{
		x8ee6b62105cb1a44 x8ee6b62105cb1a = new x8ee6b62105cb1a44();
		x8ee6b62105cb1a.x57a5e17c3ececd6e = x8a2ae9a469ed31be;
		x8ee6b62105cb1a.xc6f6af1a95493305 = ((x22f9b3dbd98925ea != 255) ? x22f9b3dbd98925ea : 0);
		switch (xef17eed5e57cb379)
		{
		case x4545604e3e0a6327.xaf9c485b734d243f:
			switch ((x51e9f07426c90be1)(x0d173b5435b4d6ad & 7))
			{
			case x51e9f07426c90be1.x54d340bd7737ea5b:
				x8ee6b62105cb1a.x3146d638ec378671 = xf396a2b7859eb922.x76ad36638702d9bf;
				x8ee6b62105cb1a.x74c5a2d6929342db = (x74c5a2d6929342db)((x0d173b5435b4d6ad >> 3) & 0x1FFF);
				x8ee6b62105cb1a.x8399367fe4b42e85 = (x0d173b5435b4d6ad >> 16) & 0xFFFF;
				break;
			case x51e9f07426c90be1.x9ad02857f9b5feb6:
				x8ee6b62105cb1a.x3146d638ec378671 = xf396a2b7859eb922.x9ad02857f9b5feb6;
				x8ee6b62105cb1a.x71dd8c34587f8fc0 = (string)x35fc228f9d4513e3[(x0d173b5435b4d6ad >> 16) & 0xFFFF];
				break;
			case x51e9f07426c90be1.x8e2172d9faebadfe:
				x8ee6b62105cb1a.x3146d638ec378671 = xf396a2b7859eb922.xf5e19a19d8e0a0e6;
				x8ee6b62105cb1a.x2d2721048f49b2bd = (x0d173b5435b4d6ad >> 16) & 0xFFFF;
				break;
			case x51e9f07426c90be1.x58ca3d95412cdb78:
				x8ee6b62105cb1a.x3146d638ec378671 = xf396a2b7859eb922.x4d0b9d4447ba7566;
				break;
			default:
				throw new InvalidOperationException("Unknown cmt value.");
			}
			break;
		case x4545604e3e0a6327.xfb1fc02db7c42694:
			x8ee6b62105cb1a.x3146d638ec378671 = xf396a2b7859eb922.xef7830d5b1716fcd;
			x8ee6b62105cb1a.x32dcc9d3ca30726c = x0d173b5435b4d6ad;
			break;
		case x4545604e3e0a6327.x2c8724332a4788a6:
			x8ee6b62105cb1a.x3146d638ec378671 = xf396a2b7859eb922.x2c8724332a4788a6;
			break;
		default:
			throw new InvalidOperationException("Unknown kt value.");
		}
		return x8ee6b62105cb1a;
	}
}
