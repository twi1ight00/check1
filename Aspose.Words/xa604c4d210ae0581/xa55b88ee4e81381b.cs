using System;
using System.Collections;
using System.IO;
using Aspose.Words;
using Aspose.Words.Drawing;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;

namespace xa604c4d210ae0581;

internal class xa55b88ee4e81381b : x485adbf5506556e8, x456c8b07916a8790
{
	private const int xe9c635e5fa756e91 = 128;

	private const int x670c40b17604babe = 64;

	private const int xedb191219aba8619 = 31680;

	private static readonly Hashtable x70d4527179984b0c;

	private static readonly Hashtable xeab5798c11bf469e;

	private readonly xd503583b32a53cea x7ff04dd244132d8e;

	private x6ace28180a74825a x49f284ee51507f12;

	private x1a78664fa10a3755 x1a78664fa10a3755 => (x1a78664fa10a3755)x66c02128fdc6436a;

	internal xa55b88ee4e81381b(BinaryReader dataReader, xd47c6c7442eb8033 revisionAuthors, IWarningCallback warningCallback)
		: base(revisionAuthors, warningCallback)
	{
		x7ff04dd244132d8e = new xd503583b32a53cea(this, dataReader);
	}

	internal x3ff949c473a702d2 x6210059f049f0d48(x1a78664fa10a3755 x062aae8c9613eeaa, x6ace28180a74825a xbd40d7ce3aca91e3)
	{
		x49f284ee51507f12 = xbd40d7ce3aca91e3;
		return new x3ff949c473a702d2(x062aae8c9613eeaa.x8301ab10c226b0c2, x6210059f049f0d48(x062aae8c9613eeaa));
	}

	internal void x06b0e25aa6ad68a9(x3ff949c473a702d2 x03ef0b0129c670a6, x1a78664fa10a3755 x062aae8c9613eeaa, x6ace28180a74825a x94736b9db6910973)
	{
		x062aae8c9613eeaa.x8301ab10c226b0c2 = x03ef0b0129c670a6.x8301ab10c226b0c2;
		x06b0e25aa6ad68a9(x03ef0b0129c670a6.x6b73aa01aa019d3a, x062aae8c9613eeaa, x94736b9db6910973);
	}

	internal void x06b0e25aa6ad68a9(byte[] x24c45257571ea504, x1a78664fa10a3755 x062aae8c9613eeaa, x6ace28180a74825a x94736b9db6910973)
	{
		x53d3302394a93aa5(x062aae8c9613eeaa, x94736b9db6910973);
		x7ff04dd244132d8e.x06b0e25aa6ad68a9(x24c45257571ea504);
		x3301471272508313();
	}

	internal void x06b0e25aa6ad68a9(byte[] x24c45257571ea504, TableStyle x13eeaa19b4289a25)
	{
		xe5ef82d048062925 = x13eeaa19b4289a25;
		x66c02128fdc6436a = x13eeaa19b4289a25.x1a78664fa10a3755;
		x7ff04dd244132d8e.x06b0e25aa6ad68a9(x24c45257571ea504);
	}

	internal void x53d3302394a93aa5(x1a78664fa10a3755 x062aae8c9613eeaa, x6ace28180a74825a x94736b9db6910973)
	{
		x66c02128fdc6436a = x062aae8c9613eeaa;
		x49f284ee51507f12 = x94736b9db6910973;
	}

	internal void x3301471272508313()
	{
	}

	public bool x09a3d4a7eac8f520(x875aca5784596b73 x28180b3c3774af93, x8de82539c936c298 xe780cde24dcce6f2, int x0d4f7f21e78721d6, BinaryReader xe134235b3526fa75)
	{
		if (xe780cde24dcce6f2 != x8de82539c936c298.x5c9e93d8164a04e3)
		{
			return true;
		}
		x7450cc1e48712286 = xe134235b3526fa75;
		switch (x28180b3c3774af93)
		{
		case x875aca5784596b73.x99c0e7ea80a2ad9a:
			x7da53fcf55413cb5(this, xe134235b3526fa75, x0d4f7f21e78721d6, x70d40b77e7fb14d0.xb0d0149484e84c46);
			break;
		case x875aca5784596b73.xa2190aa71f82aab3:
			x1a78664fa10a3755.x8301ab10c226b0c2 = x7450cc1e48712286.ReadInt16();
			break;
		case x875aca5784596b73.xb100c734d5255938:
		{
			xe134235b3526fa75.ReadByte();
			int num = xe134235b3526fa75.ReadUInt16();
			int num2 = xe134235b3526fa75.ReadUInt16();
			int num3 = num2 - num;
			int[] array = new int[num3 + 1];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = xe134235b3526fa75.ReadUInt16();
			}
			if (x1a78664fa10a3755.x8301ab10c226b0c2 > num && x1a78664fa10a3755.x8301ab10c226b0c2 <= num2)
			{
				x1a78664fa10a3755.x8301ab10c226b0c2 = array[x1a78664fa10a3755.x8301ab10c226b0c2 - num];
			}
			break;
		}
		case x875aca5784596b73.x31c5870a253a7c1c:
			xd28f53fd94b9c0e4("Paragraph formatting modifier 0x{0:x4} is not supported for DOC format by Aspose.Words.", (int)x28180b3c3774af93);
			break;
		case x875aca5784596b73.xd6a9c845ad311b8f:
			x66c02128fdc6436a.xae20093bed1e48a8(1610, (ParagraphAlignment)x7450cc1e48712286.ReadByte());
			break;
		case x875aca5784596b73.x45d4b2f2344779a7:
			x66c02128fdc6436a.xae20093bed1e48a8(1020, (ParagraphAlignment)x7450cc1e48712286.ReadByte());
			break;
		case x875aca5784596b73.x17aab5f4420a355d:
			x66c02128fdc6436a.xae20093bed1e48a8(1022, x7450cc1e48712286.ReadByte() == 1);
			break;
		case x875aca5784596b73.xac14d57d5c1653d3:
			x66c02128fdc6436a.xae20093bed1e48a8(1030, x7450cc1e48712286.ReadByte() == 1);
			break;
		case x875aca5784596b73.xb33cd2e87916ea51:
			x66c02128fdc6436a.xae20093bed1e48a8(1040, x7450cc1e48712286.ReadByte() == 1);
			break;
		case x875aca5784596b73.xcde91d1b12dacaf2:
			x66c02128fdc6436a.xae20093bed1e48a8(1050, x7450cc1e48712286.ReadByte() == 1);
			break;
		case x875aca5784596b73.x6d0211a915e0124c:
			x66c02128fdc6436a.xae20093bed1e48a8(1060, x7450cc1e48712286.ReadByte() == 1);
			break;
		case x875aca5784596b73.xc0ed70cb70e35a8f:
			x66c02128fdc6436a.xae20093bed1e48a8(1130, x7450cc1e48712286.ReadByte() == 1);
			break;
		case x875aca5784596b73.x266a6a75cb4d5110:
			x66c02128fdc6436a.xae20093bed1e48a8(1410, x7450cc1e48712286.ReadByte() == 1);
			break;
		case x875aca5784596b73.xb76554c41c7854f7:
			x66c02128fdc6436a.xae20093bed1e48a8(1470, x7450cc1e48712286.ReadByte() == 1);
			break;
		case x875aca5784596b73.x4498585def27358f:
			x66c02128fdc6436a.xae20093bed1e48a8(1070, x7450cc1e48712286.ReadByte() == 1);
			break;
		case x875aca5784596b73.x015f126843fed559:
			x66c02128fdc6436a.xae20093bed1e48a8(1080, x7450cc1e48712286.ReadByte() == 1);
			break;
		case x875aca5784596b73.x4f248e3ce072e6d2:
			x66c02128fdc6436a.xae20093bed1e48a8(1090, x7450cc1e48712286.ReadByte() == 1);
			break;
		case x875aca5784596b73.x238f7a0d35423710:
			x66c02128fdc6436a.xae20093bed1e48a8(1100, x7450cc1e48712286.ReadByte() == 1);
			break;
		case x875aca5784596b73.x1e55b582c87841bb:
			x66c02128fdc6436a.xae20093bed1e48a8(1240, x7450cc1e48712286.ReadByte() == 1);
			break;
		case x875aca5784596b73.x93c8b1472ffd489c:
			x66c02128fdc6436a.xae20093bed1e48a8(1250, x7450cc1e48712286.ReadByte() == 1);
			break;
		case x875aca5784596b73.x9e441f4b536d4d74:
			if (x49f284ee51507f12 != null && x7450cc1e48712286.ReadByte() == 1 && x49f284ee51507f12.xb8414804f39a9e90 == 0)
			{
				x49f284ee51507f12.xb8414804f39a9e90 = 1;
			}
			break;
		case x875aca5784596b73.x1ba1feeb2544d304:
			if (x49f284ee51507f12 != null)
			{
				x49f284ee51507f12.x26614a31f1c1d1df = x7450cc1e48712286.ReadByte() == 1;
			}
			break;
		case x875aca5784596b73.xefca19385fba0ef8:
			if (x49f284ee51507f12 != null)
			{
				x49f284ee51507f12.x521051256585691d = x7450cc1e48712286.ReadByte() == 1;
			}
			break;
		case x875aca5784596b73.x4519d1f3b418bc97:
			if (x49f284ee51507f12 != null)
			{
				x49f284ee51507f12.xd7d26444f1f80de0 = x7450cc1e48712286.ReadByte() == 1;
			}
			break;
		case x875aca5784596b73.x0729646d6f6298d6:
			if (x49f284ee51507f12 != null)
			{
				x49f284ee51507f12.xb8414804f39a9e90 = x7450cc1e48712286.ReadInt32();
				if (x49f284ee51507f12.xb8414804f39a9e90 < 0 || x49f284ee51507f12.xb8414804f39a9e90 > 1000)
				{
					x49f284ee51507f12.xb8414804f39a9e90 = 1;
				}
			}
			break;
		case x875aca5784596b73.x54e21fc16be4c624:
			x66c02128fdc6436a.xae20093bed1e48a8(1260, x7450cc1e48712286.ReadByte() == 1);
			break;
		case x875aca5784596b73.x82cee2754301ce50:
			x66c02128fdc6436a.xae20093bed1e48a8(1270, x7450cc1e48712286.ReadByte() == 1);
			break;
		case x875aca5784596b73.x90b0425ac81b5d54:
			x66c02128fdc6436a.xae20093bed1e48a8(1510, (x8fdc64e3f5579ea8)x7450cc1e48712286.ReadUInt16());
			break;
		case x875aca5784596b73.x7e5fff453524e5dd:
			x1a78664fa10a3755.xcedf9c82728ad579 = x7450cc1e48712286.ReadByte() == 1;
			break;
		case x875aca5784596b73.xa01e4fb5e0668955:
			x1a78664fa10a3755.xf13a626e550cef8f = x7450cc1e48712286.ReadByte();
			break;
		case x875aca5784596b73.xdd6702fdf1a51edc:
		{
			int num7 = x7450cc1e48712286.ReadInt16();
			if (num7 == 2047)
			{
				num7 = 0;
			}
			x66c02128fdc6436a.xae20093bed1e48a8(1120, num7);
			break;
		}
		case x875aca5784596b73.x0aa03598392dc553:
			xf8f1d4fa6aa69b02(1620, x7450cc1e48712286.ReadInt16());
			break;
		case x875aca5784596b73.xae4893bbf7ab3850:
			x66c02128fdc6436a.xae20093bed1e48a8(1630, (int)x7450cc1e48712286.ReadInt16());
			break;
		case x875aca5784596b73.x174cc93abf5d7db6:
			xf8f1d4fa6aa69b02(1160, x7450cc1e48712286.ReadInt16());
			break;
		case x875aca5784596b73.x5cbb2c72b0e3a8c8:
			x66c02128fdc6436a.xae20093bed1e48a8(1150, (int)x7450cc1e48712286.ReadInt16());
			break;
		case x875aca5784596b73.xd66b0990c798a7b0:
			xf8f1d4fa6aa69b02(1170, x7450cc1e48712286.ReadInt16());
			break;
		case x875aca5784596b73.x7db104e159465dcd:
			xf8f1d4fa6aa69b02(1640, x7450cc1e48712286.ReadInt16());
			break;
		case x875aca5784596b73.x7211988ddcf0a25b:
			x06507864ca0ca96a(1620);
			break;
		case x875aca5784596b73.x16ccdb8f5dc0845e:
			x06507864ca0ca96a(1160);
			break;
		case x875aca5784596b73.x6b429f8bb1c5cc1a:
			x66c02128fdc6436a.xae20093bed1e48a8(1210, x7450cc1e48712286.ReadByte() == 1);
			break;
		case x875aca5784596b73.xcbdf0d1fb9aa787a:
			x66c02128fdc6436a.xae20093bed1e48a8(1230, x7450cc1e48712286.ReadByte() == 1);
			break;
		case x875aca5784596b73.x0848b1703dbdf34a:
			x66c02128fdc6436a.xae20093bed1e48a8(1200, (int)x7450cc1e48712286.ReadInt16());
			break;
		case x875aca5784596b73.x29f3e14168bdbe35:
			x66c02128fdc6436a.xae20093bed1e48a8(1220, (int)x7450cc1e48712286.ReadInt16());
			break;
		case x875aca5784596b73.xab85bfb8fed6cf1a:
		{
			int num6 = x7450cc1e48712286.ReadInt16();
			bool flag2 = x7450cc1e48712286.ReadInt16() != 0;
			LineSpacingRule rule = ((num6 < 0) ? LineSpacingRule.Exactly : (flag2 ? LineSpacingRule.Multiple : LineSpacingRule.AtLeast));
			x66c02128fdc6436a.xae20093bed1e48a8(1650, new x84bbacdc1fc0efd2(Math.Abs(num6), rule));
			break;
		}
		case x875aca5784596b73.x26ede848a19386f3:
			x66c02128fdc6436a.xae20093bed1e48a8(1310, (int)x7450cc1e48712286.ReadInt16());
			break;
		case x875aca5784596b73.x6669e162e85f560b:
		{
			int num5 = x7450cc1e48712286.ReadInt16();
			if (num5 > 0)
			{
				x66c02128fdc6436a.xae20093bed1e48a8(1420, num5);
				x66c02128fdc6436a.xae20093bed1e48a8(1430, HeightRule.Exactly);
			}
			else if (num5 < 0)
			{
				x66c02128fdc6436a.xae20093bed1e48a8(1420, num5 & 0x7FFF);
				x66c02128fdc6436a.xae20093bed1e48a8(1430, HeightRule.AtLeast);
			}
			else
			{
				x66c02128fdc6436a.xae20093bed1e48a8(1420, 0);
				x66c02128fdc6436a.xae20093bed1e48a8(1430, HeightRule.Auto);
			}
			break;
		}
		case x875aca5784596b73.xeba171ed3ea6b665:
			x2b63788f541b61ed(1292, 1290);
			break;
		case x875aca5784596b73.x691a201a94bab9b0:
			xe58888a235038afd(1302, 1300);
			break;
		case x875aca5784596b73.xcd62e25a4e88140a:
			x66c02128fdc6436a.xae20093bed1e48a8(1520, x7450cc1e48712286.ReadByte() == 1);
			break;
		case x875aca5784596b73.x89e63bfffb72592c:
			xfcbfa618cffcaf3b(1320, 1330);
			break;
		case x875aca5784596b73.x337301c4cab6fc99:
			x66c02128fdc6436a.xae20093bed1e48a8(1340, (WrapType)x7450cc1e48712286.ReadByte());
			break;
		case x875aca5784596b73.x7d265b162d33f9d5:
			x66c02128fdc6436a.xae20093bed1e48a8(1490, (int)x7450cc1e48712286.ReadInt16());
			break;
		case x875aca5784596b73.x2046ad994bb51e5e:
			x66c02128fdc6436a.xae20093bed1e48a8(1500, (int)x7450cc1e48712286.ReadInt16());
			break;
		case x875aca5784596b73.x9f70c48339586f3f:
			x66c02128fdc6436a.xae20093bed1e48a8(1480, (TextOrientation)x7450cc1e48712286.ReadInt16());
			break;
		case x875aca5784596b73.xb7f456cd50d6dcb4:
			xd28f53fd94b9c0e4("Paragraph formatting modifier 0x{0:x4} is not supported for DOC format by Aspose.Words.", (int)x28180b3c3774af93);
			break;
		case x875aca5784596b73.x8946c36c504db7d4:
			xd28f53fd94b9c0e4("Paragraph formatting modifier 0x{0:x4} is not supported for DOC format by Aspose.Words.", (int)x28180b3c3774af93);
			break;
		case x875aca5784596b73.x5346b460cd381370:
			x2640c2c8da422cb3(1350);
			break;
		case x875aca5784596b73.xc763465873bb1b78:
			x2640c2c8da422cb3(1360);
			break;
		case x875aca5784596b73.xe8f74ff69b7e2e5d:
			x2640c2c8da422cb3(1370);
			break;
		case x875aca5784596b73.xd78c166dca256545:
			x2640c2c8da422cb3(1380);
			break;
		case x875aca5784596b73.x4894d09e6698b75b:
			x2640c2c8da422cb3(1390);
			break;
		case x875aca5784596b73.x951c383f1dd4184e:
			x2640c2c8da422cb3(1400);
			break;
		case x875aca5784596b73.xfde93fbb791923be:
			x263126e767bb1792(1350);
			break;
		case x875aca5784596b73.x0eb6a636dca9e4ee:
			x263126e767bb1792(1360);
			break;
		case x875aca5784596b73.x3d37fccc6a21a3be:
			x263126e767bb1792(1370);
			break;
		case x875aca5784596b73.x5258a9227a5145be:
			x263126e767bb1792(1380);
			break;
		case x875aca5784596b73.x9b5c0ee27451d230:
			x263126e767bb1792(1390);
			break;
		case x875aca5784596b73.xd9042f5a2b29ad32:
			x7d7320edca68565e(1460);
			break;
		case x875aca5784596b73.x0b4bb08b4f48ed17:
			x19ce25c3c13b0c39(1460);
			break;
		case x875aca5784596b73.x9959d218c0fef226:
			x66c02128fdc6436a.xae20093bed1e48a8(1280, (OutlineLevel)x7450cc1e48712286.ReadByte());
			break;
		case x875aca5784596b73.x4cb825907d5a811a:
		{
			int num4 = x7450cc1e48712286.ReadInt16();
			x66c02128fdc6436a.xae20093bed1e48a8(1440, (DropCapPosition)(num4 & 7));
			x66c02128fdc6436a.xae20093bed1e48a8(1450, (num4 & 0xF8) >> 3);
			break;
		}
		case x875aca5784596b73.xb11f973f5b4b3b79:
			if (x1a78664fa10a3755.x8df6f6ca274123b0 == null)
			{
				x1a78664fa10a3755.x8df6f6ca274123b0 = new TabStopCollection();
			}
			xbf47b732017d34a9.x06b0e25aa6ad68a9(x7450cc1e48712286, x1a78664fa10a3755.x8df6f6ca274123b0, xaded964d2765d9b8: false, base.xf69ca7a9bb4a4a51);
			break;
		case x875aca5784596b73.x0d02b68a5ba692ca:
			if (x1a78664fa10a3755.x8df6f6ca274123b0 == null)
			{
				x1a78664fa10a3755.x8df6f6ca274123b0 = new TabStopCollection();
			}
			xbf47b732017d34a9.x06b0e25aa6ad68a9(x7450cc1e48712286, x1a78664fa10a3755.x8df6f6ca274123b0, xaded964d2765d9b8: true, base.xf69ca7a9bb4a4a51);
			break;
		case x875aca5784596b73.x96930f392ad812ff:
			x66c02128fdc6436a.xae20093bed1e48a8(1580, x7450cc1e48712286.ReadInt32());
			break;
		case x875aca5784596b73.x37ca268f500c60e6:
			xf9b50472de6f2a55(new x1a78664fa10a3755());
			break;
		case x875aca5784596b73.xd72dc8f1fcced105:
			x7450cc1e48712286.ReadByte();
			break;
		case x875aca5784596b73.x6322f436f75b1bcc:
			x1a78664fa10a3755.x7a5eec3388ce254f();
			x1a78664fa10a3755.x978620a99b6d5014.x55e2dcfc986cb10b = xe134235b3526fa75.ReadByte() != 0;
			break;
		case x875aca5784596b73.xb296d295de3e2a44:
			x1a78664fa10a3755.x7a5eec3388ce254f();
			x5f15d3f95e847ae4(x1a78664fa10a3755.x978620a99b6d5014);
			break;
		case x875aca5784596b73.x7b39e56f5fe8ddd5:
			x66c02128fdc6436a.xae20093bed1e48a8(1145, x7450cc1e48712286.ReadByte() == 1);
			break;
		case x875aca5784596b73.x43e70ea491ff9354:
			x66c02128fdc6436a.xae20093bed1e48a8(1660, x7450cc1e48712286.ReadByte() == 1);
			break;
		case x875aca5784596b73.x68753e5d2933ba69:
			xd28f53fd94b9c0e4("Paragraph formatting modifier 0x{0:x4} is not supported for DOC format by Aspose.Words.", (int)x28180b3c3774af93);
			break;
		default:
		{
			bool flag = x0f03d48d1248b7d1(x28180b3c3774af93, xe134235b3526fa75);
			if (!flag && x28180b3c3774af93 != 0)
			{
				x3dc950453374051a("Unknown formatting modifier 0x{0:x4} occurred while reading DOC file.", (int)x28180b3c3774af93);
			}
			return flag;
		}
		case x875aca5784596b73.xe300e699444c1f39:
		case x875aca5784596b73.xaf54d722557c7b64:
			break;
		}
		return true;
	}

	private bool x0f03d48d1248b7d1(x875aca5784596b73 x28180b3c3774af93, BinaryReader xe134235b3526fa75)
	{
		object obj = x682712679dbc585a.xadb8a11581ae0f33(x70d4527179984b0c, x28180b3c3774af93);
		if (obj != null)
		{
			x1a78664fa10a3755.xae20093bed1e48a8((int)obj, (int)xe134235b3526fa75.ReadInt16());
		}
		return obj != null;
	}

	private void xf8f1d4fa6aa69b02(int xba08ce632055a1d9, int xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111 < 31680)
		{
			x66c02128fdc6436a.xae20093bed1e48a8(xba08ce632055a1d9, xbcea506a33cf9111);
			return;
		}
		x3dc950453374051a("Invalid indent value {0} read, ignore.", xbcea506a33cf9111);
	}

	private void x06507864ca0ca96a(int x8b0acd4325099a50)
	{
		int num = x7450cc1e48712286.ReadInt16();
		int num2 = (int)x66c02128fdc6436a.xfe91eeeafcb3026a(x8b0acd4325099a50);
		int num3 = num2 + num;
		x66c02128fdc6436a.xae20093bed1e48a8(x8b0acd4325099a50, (num3 >= 0) ? num3 : 0);
	}

	internal byte[] x746ca66f5c31e314(TableStyle x44ecfea61c937b8e)
	{
		x9b287b671d592594.BaseStream.Position = 0L;
		x66c02128fdc6436a = x44ecfea61c937b8e.x1a78664fa10a3755;
		WriteCore();
		foreach (xe12ab2f55355c7f0 item in x44ecfea61c937b8e.x7205cb42c2f994a4)
		{
			if (item.x1a78664fa10a3755 != null)
			{
				long x30cc7819189f11b = x6d582d881359c5db(x875aca5784596b73.x99c0e7ea80a2ad9a, item.x3146d638ec378671);
				x66c02128fdc6436a = item.x1a78664fa10a3755;
				WriteCore();
				xdff84d5a65b9347a(x30cc7819189f11b);
			}
		}
		return x6ca2fe3c7f213f3e();
	}

	protected override void WriteCore()
	{
		x66c02128fdc6436a.x43c6155e35f47d2b(1174);
		x66c02128fdc6436a.x43c6155e35f47d2b(1172);
		x66c02128fdc6436a.x43c6155e35f47d2b(1288);
		x66c02128fdc6436a.x43c6155e35f47d2b(1522);
		try
		{
			for (int i = 0; i < x66c02128fdc6436a.xd44988f225497f3a; i++)
			{
				int num = x66c02128fdc6436a.xf15263674eb297bb(i);
				object obj = x66c02128fdc6436a.x6d3720b962bd3112(i);
				switch (num)
				{
				case 1000:
					if (base.x48388be4dc888d53)
					{
						x2819fd3ae48985bb(x875aca5784596b73.xa2190aa71f82aab3, obj);
					}
					break;
				case 1125:
					x72bc48dae6f74342();
					break;
				case 1020:
					x9aca0d8489ab1040((ParagraphAlignment)obj);
					break;
				case 1030:
					x992a87e8a159fe04(x875aca5784596b73.xac14d57d5c1653d3, obj);
					break;
				case 1040:
					x992a87e8a159fe04(x875aca5784596b73.xb33cd2e87916ea51, obj);
					break;
				case 1050:
					x992a87e8a159fe04(x875aca5784596b73.xcde91d1b12dacaf2, obj);
					break;
				case 1060:
					x992a87e8a159fe04(x875aca5784596b73.x6d0211a915e0124c, obj);
					break;
				case 1070:
					x992a87e8a159fe04(x875aca5784596b73.x4498585def27358f, obj);
					break;
				case 1080:
					x992a87e8a159fe04(x875aca5784596b73.x015f126843fed559, obj);
					break;
				case 1090:
					x992a87e8a159fe04(x875aca5784596b73.x4f248e3ce072e6d2, obj);
					break;
				case 1100:
					x992a87e8a159fe04(x875aca5784596b73.x238f7a0d35423710, obj);
					break;
				case 1110:
					xdd694ce55709aeca(x875aca5784596b73.xa01e4fb5e0668955, obj);
					break;
				case 1120:
					x2819fd3ae48985bb(x875aca5784596b73.xdd6702fdf1a51edc, obj);
					break;
				case 1130:
					x992a87e8a159fe04(x875aca5784596b73.xc0ed70cb70e35a8f, obj);
					break;
				case 1140:
				{
					TabStopCollection x8df6f6ca274123b2 = x1a78664fa10a3755.x8df6f6ca274123b0;
					if (x8df6f6ca274123b2 != null && !x8df6f6ca274123b2.HasTolerances)
					{
						xbf47b732017d34a9.x6210059f049f0d48(x8df6f6ca274123b2, x9b287b671d592594);
					}
					break;
				}
				case 1150:
					xcf2ca8141e629667((int)obj, x875aca5784596b73.xae4893bbf7ab3850, x875aca5784596b73.x0aa03598392dc553);
					break;
				case 1160:
					xcf2ca8141e629667((int)obj, x875aca5784596b73.x0aa03598392dc553, x875aca5784596b73.xae4893bbf7ab3850);
					break;
				case 1170:
					x2819fd3ae48985bb(x875aca5784596b73.x7db104e159465dcd, obj);
					break;
				case 1172:
				{
					TabStopCollection x8df6f6ca274123b = x1a78664fa10a3755.x8df6f6ca274123b0;
					if (x8df6f6ca274123b != null && x8df6f6ca274123b.HasTolerances)
					{
						xbf47b732017d34a9.x6210059f049f0d48(x8df6f6ca274123b, x9b287b671d592594);
					}
					break;
				}
				case 1174:
					x0903e691b4eb3676();
					break;
				case 1200:
					x2819fd3ae48985bb(x875aca5784596b73.x0848b1703dbdf34a, obj);
					break;
				case 1210:
					x992a87e8a159fe04(x875aca5784596b73.x6b429f8bb1c5cc1a, obj);
					break;
				case 1220:
					x2819fd3ae48985bb(x875aca5784596b73.x29f3e14168bdbe35, obj);
					break;
				case 1230:
					x992a87e8a159fe04(x875aca5784596b73.xcbdf0d1fb9aa787a, obj);
					break;
				case 1240:
					x992a87e8a159fe04(x875aca5784596b73.x1e55b582c87841bb, obj);
					break;
				case 1250:
					x992a87e8a159fe04(x875aca5784596b73.x93c8b1472ffd489c, obj);
					break;
				case 1260:
					x992a87e8a159fe04(x875aca5784596b73.x54e21fc16be4c624, obj);
					break;
				case 1270:
					x992a87e8a159fe04(x875aca5784596b73.x82cee2754301ce50, obj);
					break;
				case 1280:
					xdd694ce55709aeca(x875aca5784596b73.x9959d218c0fef226, obj);
					break;
				case 1288:
					x1ca1a6c61763ad66(x875aca5784596b73.xeba171ed3ea6b665, 1292, 1290);
					x21d53041f795334c(x875aca5784596b73.x691a201a94bab9b0, 1302, 1300);
					xab5f6b7526efa5be(x875aca5784596b73.x26ede848a19386f3, 1310);
					x8911bca820bfab79(x875aca5784596b73.x89e63bfffb72592c, 1320, 1330);
					xc351d479ff7ee789(x875aca5784596b73.x337301c4cab6fc99, 1340);
					break;
				case 1350:
					xf4829300ee2ded8a(x875aca5784596b73.x5346b460cd381370, obj);
					break;
				case 1360:
					xf4829300ee2ded8a(x875aca5784596b73.xc763465873bb1b78, obj);
					break;
				case 1370:
					xf4829300ee2ded8a(x875aca5784596b73.xe8f74ff69b7e2e5d, obj);
					break;
				case 1380:
					xf4829300ee2ded8a(x875aca5784596b73.xd78c166dca256545, obj);
					break;
				case 1390:
					xf4829300ee2ded8a(x875aca5784596b73.x4894d09e6698b75b, obj);
					break;
				case 1400:
					xf4829300ee2ded8a(x875aca5784596b73.x951c383f1dd4184e, obj);
					break;
				case 1410:
					x992a87e8a159fe04(x875aca5784596b73.x266a6a75cb4d5110, obj);
					break;
				case 1430:
				{
					int num3 = (int)x66c02128fdc6436a.xfe91eeeafcb3026a(1420);
					if ((HeightRule)x66c02128fdc6436a.xfe91eeeafcb3026a(1430) == HeightRule.AtLeast)
					{
						num3 |= 0x8000;
					}
					x9b287b671d592594.xd776ae6f68bc4d9c(x875aca5784596b73.x6669e162e85f560b, num3);
					break;
				}
				case 1440:
				{
					DropCapPosition dropCapPosition = (DropCapPosition)x66c02128fdc6436a.xfe91eeeafcb3026a(1440);
					int num2 = (int)x66c02128fdc6436a.xfe91eeeafcb3026a(1450);
					int xbcea506a33cf = (int)dropCapPosition | (num2 << 3);
					x9b287b671d592594.xd776ae6f68bc4d9c(x875aca5784596b73.x4cb825907d5a811a, xbcea506a33cf);
					break;
				}
				case 1460:
					xc8950caaebdd16ee(x875aca5784596b73.xd9042f5a2b29ad32, obj);
					break;
				case 1470:
					x992a87e8a159fe04(x875aca5784596b73.xb76554c41c7854f7, obj);
					break;
				case 1480:
					x2819fd3ae48985bb(x875aca5784596b73.x9f70c48339586f3f, obj);
					break;
				case 1490:
					x2819fd3ae48985bb(x875aca5784596b73.x7d265b162d33f9d5, obj);
					break;
				case 1500:
					x2819fd3ae48985bb(x875aca5784596b73.x2046ad994bb51e5e, obj);
					break;
				case 1510:
					x2819fd3ae48985bb(x875aca5784596b73.x90b0425ac81b5d54, obj);
					break;
				case 1520:
					x992a87e8a159fe04(x875aca5784596b73.xcd62e25a4e88140a, obj);
					break;
				case 1522:
					x254ca7c3e16cd9eb(x875aca5784596b73.x0b4bb08b4f48ed17, 1460);
					x5f45ba3056182cdb(x875aca5784596b73.xfde93fbb791923be, 1350);
					x5f45ba3056182cdb(x875aca5784596b73.x0eb6a636dca9e4ee, 1360);
					x5f45ba3056182cdb(x875aca5784596b73.x3d37fccc6a21a3be, 1370);
					x5f45ba3056182cdb(x875aca5784596b73.x5258a9227a5145be, 1380);
					x5f45ba3056182cdb(x875aca5784596b73.x9b5c0ee27451d230, 1390);
					break;
				case 1560:
					x992a87e8a159fe04(x875aca5784596b73.x7e5fff453524e5dd, (bool)obj);
					break;
				case 1660:
					x992a87e8a159fe04(x875aca5784596b73.x43e70ea491ff9354, obj);
					break;
				case 1145:
					x992a87e8a159fe04(x875aca5784596b73.x7b39e56f5fe8ddd5, (bool)obj);
					break;
				default:
					x832d82fa4c25ecca(num, obj);
					break;
				}
			}
			if (x49f284ee51507f12 != null)
			{
				if (x49f284ee51507f12.x521051256585691d)
				{
					x9b287b671d592594.x9d91059a64953e89(x875aca5784596b73.xefca19385fba0ef8, x49f284ee51507f12.x521051256585691d);
				}
				if (x49f284ee51507f12.xd7d26444f1f80de0)
				{
					x9b287b671d592594.x9d91059a64953e89(x875aca5784596b73.x4519d1f3b418bc97, x49f284ee51507f12.xd7d26444f1f80de0);
				}
				if (x49f284ee51507f12.xb8414804f39a9e90 != 0)
				{
					x9b287b671d592594.x9d91059a64953e89(x875aca5784596b73.x9e441f4b536d4d74, xbcea506a33cf9111: true);
				}
				if (x49f284ee51507f12.x26614a31f1c1d1df)
				{
					x9b287b671d592594.x9d91059a64953e89(x875aca5784596b73.x1ba1feeb2544d304, x49f284ee51507f12.x26614a31f1c1d1df);
				}
				if (x49f284ee51507f12.xb8414804f39a9e90 != 0)
				{
					x9b287b671d592594.x138617e45a6d57be(x875aca5784596b73.x0729646d6f6298d6, x49f284ee51507f12.xb8414804f39a9e90);
				}
			}
			xab5f6b7526efa5be(x875aca5784596b73.x5cbb2c72b0e3a8c8, 1150);
			xab5f6b7526efa5be(x875aca5784596b73.x174cc93abf5d7db6, 1160);
			xab5f6b7526efa5be(x875aca5784596b73.xd66b0990c798a7b0, 1170);
			xc351d479ff7ee789(x875aca5784596b73.x45d4b2f2344779a7, 1020);
			x8af4cf76757a2ae7(x875aca5784596b73.x17aab5f4420a355d, 1022);
			x6ff7c65ed4805c27(x875aca5784596b73.x96930f392ad812ff, 1580);
			x9566f11596f04e72(x875aca5784596b73.x37ca268f500c60e6, x875aca5784596b73.xd72dc8f1fcced105);
		}
		finally
		{
			x66c02128fdc6436a.x52b190e626f65140(1174);
			x66c02128fdc6436a.x52b190e626f65140(1172);
			x66c02128fdc6436a.x52b190e626f65140(1288);
			x66c02128fdc6436a.x52b190e626f65140(1522);
		}
	}

	private bool x832d82fa4c25ecca(int xba08ce632055a1d9, object xbcea506a33cf9111)
	{
		object obj = x682712679dbc585a.xadb8a11581ae0f33(xeab5798c11bf469e, xba08ce632055a1d9);
		if (obj != null)
		{
			x2819fd3ae48985bb((x875aca5784596b73)obj, (int)xbcea506a33cf9111);
		}
		return obj != null;
	}

	private void x9aca0d8489ab1040(ParagraphAlignment x4ec4022180cbf8f4)
	{
		if (x1a78664fa10a3755.xcedf9c82728ad579)
		{
			x4ec4022180cbf8f4 = x1a78664fa10a3755.xbf8ba56877f02689(x4ec4022180cbf8f4);
		}
		x9b287b671d592594.x1680160a63ff3e0b(x875aca5784596b73.xd6a9c845ad311b8f, (int)x4ec4022180cbf8f4);
	}

	private void xcf2ca8141e629667(int xbcea506a33cf9111, x875aca5784596b73 x3e2b608986674046, x875aca5784596b73 x9bf5a9845502afeb)
	{
		x875aca5784596b73 x9035cf16181332fc = (x1a78664fa10a3755.xcedf9c82728ad579 ? x9bf5a9845502afeb : x3e2b608986674046);
		x9b287b671d592594.xd776ae6f68bc4d9c(x9035cf16181332fc, xbcea506a33cf9111);
	}

	private void x0903e691b4eb3676()
	{
		if (x66c02128fdc6436a.xbc5dc59d0d9b620d(1650))
		{
			x84bbacdc1fc0efd2 x84bbacdc1fc0efd = (x84bbacdc1fc0efd2)x66c02128fdc6436a.xfe91eeeafcb3026a(1650);
			int num = ((x84bbacdc1fc0efd.xea9485ec61071863 == LineSpacingRule.Exactly) ? (-x84bbacdc1fc0efd.xd2f68ee6f47e9dfb) : x84bbacdc1fc0efd.xd2f68ee6f47e9dfb);
			x9b287b671d592594.x3a52c4e37999b16e(x875aca5784596b73.xab85bfb8fed6cf1a);
			x9b287b671d592594.Write((short)num);
			x9b287b671d592594.Write((x84bbacdc1fc0efd.xea9485ec61071863 == LineSpacingRule.Multiple) ? ((short)1) : ((short)0));
		}
	}

	private void x5f15d3f95e847ae4(x978620a99b6d5014 x2041c52b7802a313)
	{
		int num = x7450cc1e48712286.ReadByte();
		x2041c52b7802a313.x713b07324dddc470 = num != 0;
		x7450cc1e48712286.ReadByte();
		x2041c52b7802a313.xb063bbfcfeade526 = xaca3428582882d9d.x8f3a8caf455fbd75(x7450cc1e48712286.ReadInt16());
		x2041c52b7802a313.x242851e6278ed355 = xed28c1e5772a17ea.x06b0e25aa6ad68a9(x7450cc1e48712286);
		for (int i = 0; i < 9; i++)
		{
			x2041c52b7802a313.x044891ce086d094b[i] = x7450cc1e48712286.ReadByte();
		}
		for (int j = 0; j < 9; j++)
		{
			x2041c52b7802a313.x7e30db41abd34a71[j] = (NumberStyle)x7450cc1e48712286.ReadByte();
		}
		x7450cc1e48712286.ReadInt16();
		for (int k = 0; k < 9; k++)
		{
			x2041c52b7802a313.x632f31cdeda76ff9[k] = x7450cc1e48712286.ReadInt32();
		}
		x2041c52b7802a313.x5051a4a3b273ffce = x93b05c1ad709a695.x9c35bca780965b65(x7450cc1e48712286, 64);
	}

	private void x72bc48dae6f74342()
	{
		x978620a99b6d5014 x978620a99b6d = x1a78664fa10a3755.x978620a99b6d5014;
		if (x978620a99b6d == null)
		{
			return;
		}
		if (x978620a99b6d.x55e2dcfc986cb10b)
		{
			x9b287b671d592594.x9d91059a64953e89(x875aca5784596b73.x6322f436f75b1bcc, xbcea506a33cf9111: true);
		}
		if (x978620a99b6d.x8c84b6fad60c11f5)
		{
			x9b287b671d592594.x3a52c4e37999b16e(x875aca5784596b73.xb296d295de3e2a44);
			x9b287b671d592594.Write((byte)128);
			int num = (int)x9b287b671d592594.BaseStream.Position;
			x9b287b671d592594.Write((byte)(x978620a99b6d.x713b07324dddc470 ? 1u : 0u));
			x9b287b671d592594.Write((byte)0);
			x9b287b671d592594.Write((short)xaca3428582882d9d.x157cb2cfc16453ee(x978620a99b6d.xb063bbfcfeade526));
			xed28c1e5772a17ea.x6210059f049f0d48(x978620a99b6d.x242851e6278ed355, x9b287b671d592594);
			for (int i = 0; i < 9; i++)
			{
				x9b287b671d592594.Write(x978620a99b6d.x044891ce086d094b[i]);
			}
			for (int j = 0; j < 9; j++)
			{
				x9b287b671d592594.Write((byte)x978620a99b6d.x7e30db41abd34a71[j]);
			}
			x9b287b671d592594.Write((short)0);
			for (int k = 0; k < 9; k++)
			{
				x9b287b671d592594.Write(x978620a99b6d.x632f31cdeda76ff9[k]);
			}
			x93b05c1ad709a695.xb8560c54099c0da8(x978620a99b6d.x5051a4a3b273ffce, x9b287b671d592594, 64);
			_ = x9b287b671d592594.BaseStream.Position;
		}
	}

	static xa55b88ee4e81381b()
	{
		x70d4527179984b0c = new Hashtable();
		xeab5798c11bf469e = new Hashtable();
		x682712679dbc585a.x70fa1602ceccddee(new object[10]
		{
			x875aca5784596b73.x1356a17f29366cce,
			1205,
			x875aca5784596b73.x9716caaf1a74daa8,
			1225,
			x875aca5784596b73.xaf7f3b60d33166f1,
			1175,
			x875aca5784596b73.x6e2e5a5f2ae4bc7d,
			1165,
			x875aca5784596b73.x4a97cb25fb40a0d2,
			1155
		}, x70d4527179984b0c, xeab5798c11bf469e);
	}
}
