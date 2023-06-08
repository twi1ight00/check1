using System;
using System.IO;
using Aspose.Words;
using Aspose.Words.Fonts;
using x13f1efc79617a47b;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;

namespace xa604c4d210ae0581;

internal class x44ac55e8c9dbd30d
{
	private const int x44b60cf6f48e5a4c = 10;

	private const int x28e1ff789b103b80 = 18;

	private readonly FontInfoCollection xcf7aa3cc906cdb68;

	private readonly StyleCollection x18c770831ef0bf38;

	private readonly x82985a3d7a64e540 x172509d410571cfd;

	private readonly xa55b88ee4e81381b x17258deefeb290b7;

	private readonly x3af03f5f12c5ee73 x326d2c4737b8a926;

	private BinaryReader x7450cc1e48712286;

	private BinaryWriter x9b287b671d592594;

	private readonly x6ace28180a74825a x3e35d31c960f9b62 = new x6ace28180a74825a();

	private readonly xa52f2632c0ffdfaf x69976e932774eb61 = new xa52f2632c0ffdfaf();

	private IWarningCallback xa056586c1f99e199;

	internal static bool x492f529cee830a40;

	internal x44ac55e8c9dbd30d(FontInfoCollection fontInfos, xd47c6c7442eb8033 revisionAuthors, StyleCollection styles, IWarningCallback warningCallback)
	{
		xcf7aa3cc906cdb68 = fontInfos;
		x18c770831ef0bf38 = styles;
		x17258deefeb290b7 = new xa55b88ee4e81381b(null, revisionAuthors, warningCallback);
		x326d2c4737b8a926 = new x3af03f5f12c5ee73(xcf7aa3cc906cdb68, revisionAuthors, warningCallback);
		x172509d410571cfd = new x82985a3d7a64e540(null, revisionAuthors, x3a9e25666c8d1ee1.x1ab0f9731505945e, warningCallback);
	}

	internal void x06b0e25aa6ad68a9(BinaryReader xe134235b3526fa75, x8aeace2bf92692ab xf0c8411938a86cbf, IWarningCallback x57fef5933b41d0c2)
	{
		xa056586c1f99e199 = x57fef5933b41d0c2;
		if (xf0c8411938a86cbf.x955a03f821588c52.x9865ed3780825cad.x04c290dc4d04369c == 0)
		{
			x3dc950453374051a("Document contains empty stylesheet.");
			return;
		}
		x7450cc1e48712286 = xe134235b3526fa75;
		xe134235b3526fa75.BaseStream.Position = xf0c8411938a86cbf.x955a03f821588c52.x9865ed3780825cad.xe53f0e68147463d1;
		int num = xe134235b3526fa75.ReadUInt16();
		long position = xe134235b3526fa75.BaseStream.Position;
		int x2989fb35371d4c = xe134235b3526fa75.ReadUInt16();
		int x1d3bd9314facb = xe134235b3526fa75.ReadUInt16();
		xe134235b3526fa75.ReadUInt16();
		int num2 = xe134235b3526fa75.ReadUInt16();
		int num3 = xe134235b3526fa75.ReadUInt16();
		if (num3 != 15)
		{
			x3dc950453374051a("Invalid fixed styles count, ignore whole stylesheet.");
			return;
		}
		xe134235b3526fa75.ReadUInt16();
		xeedad81aaed42a76 x27096df7ca0cfe2e = x18c770831ef0bf38.x27096df7ca0cfe2e;
		x27096df7ca0cfe2e.x51cf23ce6e71b84c = xcf7aa3cc906cdb68.x7bcd2fb72fb7aae6(xe134235b3526fa75.ReadInt16());
		x27096df7ca0cfe2e.x31ece097bda75a20 = xcf7aa3cc906cdb68.x7bcd2fb72fb7aae6(xe134235b3526fa75.ReadInt16());
		x27096df7ca0cfe2e.xd08cbc518cf39317 = xcf7aa3cc906cdb68.x7bcd2fb72fb7aae6(xe134235b3526fa75.ReadInt16());
		x27096df7ca0cfe2e.xf3d194b4e6a2594a = (string)xeedad81aaed42a76.x0095b789d636f3ae(270);
		long num4 = position + num;
		if (xe134235b3526fa75.BaseStream.Position < num4)
		{
			x27096df7ca0cfe2e.xf3d194b4e6a2594a = xcf7aa3cc906cdb68.x7bcd2fb72fb7aae6(xe134235b3526fa75.ReadInt16());
		}
		if (xe134235b3526fa75.BaseStream.Position < num4)
		{
			if (num2 <= 156)
			{
				x18c770831ef0bf38.x90347bcd8deede01.x02824d1044e558e0();
			}
			x1c5a4b9b4b4e4b53(num2);
		}
		else
		{
			x18c770831ef0bf38.x90347bcd8deede01.x02b347558ccec04e();
		}
		if (xe134235b3526fa75.BaseStream.Position < num4)
		{
			x7a3428c10957ca93();
		}
		xe134235b3526fa75.BaseStream.Position = num4;
		x06ec73ba9728bac8(xf0c8411938a86cbf, x2989fb35371d4c, x1d3bd9314facb);
		if (num2 <= 156)
		{
			x1b50eb5c581c8f66();
		}
	}

	private void x1b50eb5c581c8f66()
	{
		x90347bcd8deede01 x90347bcd8deede = x18c770831ef0bf38.x90347bcd8deede01;
		foreach (Style item in x18c770831ef0bf38)
		{
			if (item.StyleIdentifier == StyleIdentifier.DefaultParagraphFont)
			{
				continue;
			}
			x565726a756595ed4 x565726a756595ed = x90347bcd8deede.x31805fef2aff8b5f.get_xe6d4b1b411ed94b5(item.StyleIdentifier);
			if (x565726a756595ed != null)
			{
				item.x2d8aaa05bddcf40c = x565726a756595ed.x2d8aaa05bddcf40c;
				item.xebe0f6c7e6f4ae3a = x565726a756595ed.xebe0f6c7e6f4ae3a;
				item.x9eb07da9aa5bbf9e = x565726a756595ed.x9eb07da9aa5bbf9e;
				if (x565726a756595ed.x5356a3af7e7ecdfa)
				{
					item.x45101ac87546632f = false;
					item.x5356a3af7e7ecdfa = false;
					x565726a756595ed.x45101ac87546632f = false;
					x565726a756595ed.x5356a3af7e7ecdfa = false;
				}
			}
		}
	}

	private void x1c5a4b9b4b4e4b53(int x3432df34cf468e00)
	{
		x7450cc1e48712286.ReadUInt16();
		x90347bcd8deede01 x90347bcd8deede = x18c770831ef0bf38.x90347bcd8deede01;
		for (int i = 0; i < x3432df34cf468e00; i++)
		{
			int num = x7450cc1e48712286.ReadInt32();
			bool locked = (num & 1) != 0;
			bool semiHidden = (num & 2) != 0;
			bool unhideWhenUsed = (num & 4) != 0;
			bool quickFormat = (num & 8) != 0;
			int uiPriority = (num >> 4) & 0xFFF;
			x565726a756595ed4 x4ee045c = new x565726a756595ed4((StyleIdentifier)i, locked, quickFormat, semiHidden, uiPriority, unhideWhenUsed);
			if (!x90347bcd8deede.x9363513ed6397cdf(x4ee045c))
			{
				x90347bcd8deede.x31805fef2aff8b5f.xd6b6ed77479ef68c(x4ee045c);
			}
		}
	}

	private void x7a3428c10957ca93()
	{
		int count = x7450cc1e48712286.ReadInt32();
		byte[] x24c45257571ea = x7450cc1e48712286.ReadBytes(count);
		x326d2c4737b8a926.x06b0e25aa6ad68a9(x24c45257571ea, x18c770831ef0bf38.x27096df7ca0cfe2e, x69976e932774eb61);
		int count2 = x7450cc1e48712286.ReadInt32();
		byte[] x24c45257571ea2 = x7450cc1e48712286.ReadBytes(count2);
		x1a78664fa10a3755 x062aae8c9613eeaa = new x1a78664fa10a3755();
		x17258deefeb290b7.x06b0e25aa6ad68a9(x24c45257571ea2, x062aae8c9613eeaa, x3e35d31c960f9b62);
	}

	private void x06ec73ba9728bac8(x8aeace2bf92692ab xf0c8411938a86cbf, int x2989fb35371d4c32, int x1d3bd9314facb312)
	{
		bool x4b7fd0812887bd2f = xf0c8411938a86cbf.xc6ad7b9979f7a862 != 0;
		int num = xf0c8411938a86cbf.x955a03f821588c52.x9865ed3780825cad.xe53f0e68147463d1 + xf0c8411938a86cbf.x955a03f821588c52.x9865ed3780825cad.x04c290dc4d04369c;
		for (int i = 0; i < x2989fb35371d4c32; i++)
		{
			if (x7450cc1e48712286.BaseStream.Position >= num)
			{
				break;
			}
			if (!x637d7e009920d5a9(i, x1d3bd9314facb312, x4b7fd0812887bd2f))
			{
				x3dc950453374051a("Style definition is corrupted, ignore rest of stylesheet.");
				break;
			}
		}
	}

	internal int x6210059f049f0d48(BinaryWriter xbdfb620b7167944b)
	{
		x9b287b671d592594 = xbdfb620b7167944b;
		int x7312ec443a13e4d = x18c770831ef0bf38.xdc32dcfe6668100d();
		int num = (int)x9b287b671d592594.BaseStream.Position;
		x9b287b671d592594.Write((ushort)0);
		int num2 = (int)x9b287b671d592594.BaseStream.Position;
		xef4b25fc8f80bf8b(x7312ec443a13e4d, 267);
		x8bccb17ab62e1c13(267);
		x69db0b7124cbfdbc();
		int num3 = (int)x9b287b671d592594.BaseStream.Position;
		int num4 = num3 - num2;
		x9b287b671d592594.BaseStream.Position = num;
		x9b287b671d592594.Write((ushort)num4);
		x9b287b671d592594.BaseStream.Position = num3;
		x6f126bc7f29ba4bf(x7312ec443a13e4d);
		return (int)x9b287b671d592594.BaseStream.Position - num;
	}

	private void xef4b25fc8f80bf8b(int x7312ec443a13e4d8, int x3432df34cf468e00)
	{
		x9b287b671d592594.Write((ushort)x7312ec443a13e4d8);
		x9b287b671d592594.Write((ushort)18);
		x9b287b671d592594.Write((ushort)1);
		x9b287b671d592594.Write((ushort)x3432df34cf468e00);
		x9b287b671d592594.Write((ushort)15);
		x9b287b671d592594.Write((ushort)7);
		x9b287b671d592594.Write((ushort)xcf7aa3cc906cdb68.x04327ff503798cdd(x18c770831ef0bf38.x27096df7ca0cfe2e.x51cf23ce6e71b84c));
		x9b287b671d592594.Write((ushort)xcf7aa3cc906cdb68.x04327ff503798cdd(x18c770831ef0bf38.x27096df7ca0cfe2e.x31ece097bda75a20));
		x9b287b671d592594.Write((ushort)xcf7aa3cc906cdb68.x04327ff503798cdd(x18c770831ef0bf38.x27096df7ca0cfe2e.xd08cbc518cf39317));
		x9b287b671d592594.Write((ushort)xcf7aa3cc906cdb68.x04327ff503798cdd(x18c770831ef0bf38.x27096df7ca0cfe2e.xf3d194b4e6a2594a));
	}

	private void x8bccb17ab62e1c13(int x3432df34cf468e00)
	{
		x9b287b671d592594.Write((ushort)4);
		x90347bcd8deede01 x90347bcd8deede = x18c770831ef0bf38.x90347bcd8deede01;
		int num = 0;
		num |= (x90347bcd8deede.x799a64ee3b4ce806 ? 1 : 0);
		num |= (x90347bcd8deede.xe27cb3f1d698353d ? 2 : 0);
		num |= (x90347bcd8deede.xa657c8b674ff2f76 ? 4 : 0);
		num |= (x90347bcd8deede.x0c40b3ed8738297c ? 8 : 0);
		num |= x90347bcd8deede.x4d0e04ab61f50baa << 4;
		for (int i = 0; i < x3432df34cf468e00; i++)
		{
			int num2 = 0;
			x565726a756595ed4 x565726a756595ed = x90347bcd8deede.x31805fef2aff8b5f.get_xe6d4b1b411ed94b5((StyleIdentifier)i);
			if (x565726a756595ed != null)
			{
				num2 |= (x565726a756595ed.x2d8aaa05bddcf40c ? 1 : 0);
				num2 |= (x565726a756595ed.x45101ac87546632f ? 2 : 0);
				num2 |= (x565726a756595ed.x5356a3af7e7ecdfa ? 4 : 0);
				num2 |= (x565726a756595ed.xebe0f6c7e6f4ae3a ? 8 : 0);
				num2 |= x565726a756595ed.x9eb07da9aa5bbf9e << 4;
			}
			else
			{
				num2 = num;
			}
			x9b287b671d592594.Write(num2);
		}
	}

	private void x69db0b7124cbfdbc()
	{
		x9dba795deb731d48 x9dba795deb731d49 = x326d2c4737b8a926.x6210059f049f0d48(x18c770831ef0bf38.x27096df7ca0cfe2e, x69976e932774eb61, x0463a6b206bbf7e4: false);
		x9b287b671d592594.Write(x9dba795deb731d49.x6b73aa01aa019d3a.Length);
		x9b287b671d592594.Write(x9dba795deb731d49.x6b73aa01aa019d3a);
		x3ff949c473a702d2 x3ff949c473a702d3 = x17258deefeb290b7.x6210059f049f0d48(x18c770831ef0bf38.xf4eb04b8b9073eeb, x3e35d31c960f9b62);
		x9b287b671d592594.Write(x3ff949c473a702d3.x6b73aa01aa019d3a.Length);
		x9b287b671d592594.Write(x3ff949c473a702d3.x6b73aa01aa019d3a);
	}

	private void x6f126bc7f29ba4bf(int x7312ec443a13e4d8)
	{
		int i = 0;
		for (int j = 0; j < x18c770831ef0bf38.Count; j++)
		{
			Style style;
			for (style = x18c770831ef0bf38[j]; i < style.x8301ab10c226b0c2; i++)
			{
				x9b287b671d592594.Write((ushort)0);
			}
			xaedce5725e456ac5(style);
			i++;
		}
		for (; i < x7312ec443a13e4d8; i++)
		{
			x9b287b671d592594.Write((ushort)0);
		}
	}

	private bool x637d7e009920d5a9(int xddd12ddd8b1e4a90, int x1d3bd9314facb312, bool x4b7fd0812887bd2f)
	{
		int num = x7450cc1e48712286.ReadUInt16();
		if (num == 0)
		{
			return true;
		}
		int num2 = (int)x7450cc1e48712286.BaseStream.Position;
		Style style = x67444bb9c65701d9(xddd12ddd8b1e4a90);
		if (style == null)
		{
			return false;
		}
		if (x1d3bd9314facb312 > 10)
		{
			x35e239dc2d4197e8(style);
		}
		x7450cc1e48712286.BaseStream.Position = num2 + x1d3bd9314facb312;
		x29d811387c0dde4f(x7450cc1e48712286.BaseStream, num2);
		string text = x93b05c1ad709a695.x602d3c3fbfa56f51(x7450cc1e48712286, x4b7fd0812887bd2f, xac1baf51b3e43d13: true);
		string[] array = text.Split(',');
		style.x2b8399f052630a13(array[0]);
		if (x7450cc1e48712286.BaseStream.Position - num2 < num)
		{
			x9eb5f88766bf29b0(style, num2);
			x29d811387c0dde4f(x7450cc1e48712286.BaseStream, num2);
			int num3 = num2 + num;
			int num4 = num3 - (int)x7450cc1e48712286.BaseStream.Position;
			if (num4 > 0)
			{
				x3dc950453374051a("Unexpected extra data in style found, read as raw bytes.");
				x7450cc1e48712286.BaseStream.Position += num4;
			}
			x29d811387c0dde4f(x7450cc1e48712286.BaseStream, num2);
		}
		string[] array2 = new string[array.Length - 1];
		Array.Copy(array, 1, array2, 0, array2.Length);
		if (style.StyleIdentifier == StyleIdentifier.Normal && style.xe709b224f455b863 != 4095)
		{
			x3dc950453374051a("Normal style is based on other style which is not allowed, corrected.");
			style.xe709b224f455b863 = 4095;
		}
		x18c770831ef0bf38.x4880cad9f3196627(style, array2);
		return true;
	}

	private Style x67444bb9c65701d9(int xddd12ddd8b1e4a90)
	{
		Style style = null;
		int num = x7450cc1e48712286.ReadUInt16();
		StyleIdentifier xa3be2ccad541ab = (StyleIdentifier)(num & 0xFFF);
		bool x4848603eaf370e = (num & 0x2000) != 0;
		bool xcbf95a2bd7b4de = (num & 0x4000) != 0;
		num = x7450cc1e48712286.ReadUInt16();
		StyleType styleType = (StyleType)(num & 0xF);
		if (styleType > StyleType.List)
		{
			x3dc950453374051a($"Invalid style type value 0x{(int)styleType:x2}, style is ignored.");
		}
		else
		{
			style = Style.xebcf83b00134300b(styleType, xddd12ddd8b1e4a90, xa3be2ccad541ab, null);
			style.xe709b224f455b863 = (num >> 4) & 0xFFF;
			style.x4848603eaf370e03 = x4848603eaf370e;
			style.xcbf95a2bd7b4de24 = xcbf95a2bd7b4de;
			num = x7450cc1e48712286.ReadUInt16();
			style.xfb77c9ea054ac31c = (num >> 4) & 0xFFF;
			x7450cc1e48712286.ReadUInt16();
			num = x7450cc1e48712286.ReadUInt16();
			style.x913ff5916b187824 = (num & 1) != 0;
			style.x96e55b5d052d1279 = (num & 2) != 0;
			style.x5463d55288b12514 = (num & 0xC) != 0;
			style.xde61abbe9514a1ee = (num & 0x10) != 0;
			style.x3bbb21ee843f081c = (num & 0x20) != 0;
			style.xdf3672ec434b4524 = (num & 0x40) != 0;
			style.x45101ac87546632f = (num & 0x100) != 0;
			style.x2d8aaa05bddcf40c = (num & 0x200) != 0;
			style.x698badc7f383579c = (num & 0x400) != 0;
			style.x5356a3af7e7ecdfa = (num & 0x800) != 0;
			style.xebe0f6c7e6f4ae3a = (num & 0x1000) != 0;
		}
		return style;
	}

	private void x35e239dc2d4197e8(Style x44ecfea61c937b8e)
	{
		int num = x7450cc1e48712286.ReadUInt16();
		x44ecfea61c937b8e.x4cf1854ef833220f = num & 0xFFF;
		if (x44ecfea61c937b8e.x4cf1854ef833220f == 0)
		{
			x44ecfea61c937b8e.x4cf1854ef833220f = 4095;
		}
		x44ecfea61c937b8e.xe12a6bc6d222e782 = x7450cc1e48712286.ReadInt32();
		num = x7450cc1e48712286.ReadUInt16();
		x44ecfea61c937b8e.x9eb07da9aa5bbf9e = (num >> 4) & 0xFFF;
	}

	private void x9eb5f88766bf29b0(Style x44ecfea61c937b8e, int x79e3bb911730b0d4)
	{
		TableStyle x44ecfea61c937b8e2 = ((x44ecfea61c937b8e.Type == StyleType.Table) ? ((TableStyle)x44ecfea61c937b8e) : null);
		switch (x44ecfea61c937b8e.Type)
		{
		case StyleType.Paragraph:
			x29d811387c0dde4f(x7450cc1e48712286.BaseStream, x79e3bb911730b0d4);
			xbd12d1ad296c44a8(x44ecfea61c937b8e.x1a78664fa10a3755);
			x29d811387c0dde4f(x7450cc1e48712286.BaseStream, x79e3bb911730b0d4);
			x52a6f794e080ea91(x44ecfea61c937b8e.xeedad81aaed42a76);
			break;
		case StyleType.Character:
			x29d811387c0dde4f(x7450cc1e48712286.BaseStream, x79e3bb911730b0d4);
			x52a6f794e080ea91(x44ecfea61c937b8e.xeedad81aaed42a76);
			break;
		case StyleType.List:
			x29d811387c0dde4f(x7450cc1e48712286.BaseStream, x79e3bb911730b0d4);
			xbd12d1ad296c44a8(x44ecfea61c937b8e.x1a78664fa10a3755);
			break;
		case StyleType.Table:
			x29d811387c0dde4f(x7450cc1e48712286.BaseStream, x79e3bb911730b0d4);
			xe0e3addf31436a45(x44ecfea61c937b8e2);
			x29d811387c0dde4f(x7450cc1e48712286.BaseStream, x79e3bb911730b0d4);
			xeedbfa015fd1cb67(x44ecfea61c937b8e2);
			x29d811387c0dde4f(x7450cc1e48712286.BaseStream, x79e3bb911730b0d4);
			x99de4c12f23317ce(x44ecfea61c937b8e2);
			break;
		default:
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("ekaaklhaeloaelfbclmbhldclkkckfbdkkidikpdkkgekjneajefielfjjcgljjgpiahbihhheoh", 1871708239)));
		}
	}

	private void xaedce5725e456ac5(Style x44ecfea61c937b8e)
	{
		int num = (int)x9b287b671d592594.BaseStream.Position;
		x9b287b671d592594.Write((ushort)0);
		int num2 = (int)x9b287b671d592594.BaseStream.Position;
		int num3 = x7fd774787149ab50(x44ecfea61c937b8e);
		x29d811387c0dde4f(x9b287b671d592594.BaseStream, num2);
		string xbcea506a33cf = x18c770831ef0bf38.x4c0f9b9b517a1ec4(x44ecfea61c937b8e, xe9f84f829511a789: true);
		x93b05c1ad709a695.x4a3c44ae9b1cf5ab(xbcea506a33cf, int.MaxValue, x9b287b671d592594, x5be1cad1d00af914: true, xac1baf51b3e43d13: true);
		x2b45c45a079180eb(x44ecfea61c937b8e, num2);
		x29d811387c0dde4f(x9b287b671d592594.BaseStream, num2);
		int num4 = (int)x9b287b671d592594.BaseStream.Position;
		int num5 = num4 - num2;
		if (x0d299f323d241756.x7e32f71c3f39b6bc(num5))
		{
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("kokgaachgajhmpphgahihpnimkejipljmockdkjkboalnjhlnoollofmnommnndndnknlibommiokmpoimgpimnpkmeacmlakmcbmljbplacllhckgocalfdhlmdbgdedkkedlbfikifkjpffjggdkngbjehnilhgecihjjipiajndhjmhojmhfkedmkghdleiklahbmghimfcpmahgnehnnjgeolflolfcpfgjpabaamfhaafoahafbgembkfdccfkcaebdleiddapd", 1625189022)));
		}
		x9b287b671d592594.BaseStream.Seek(num, SeekOrigin.Begin);
		x9b287b671d592594.Write((ushort)num5);
		x9b287b671d592594.BaseStream.Seek(num3, SeekOrigin.Begin);
		x9b287b671d592594.Write((ushort)num5);
		x9b287b671d592594.BaseStream.Seek(num4, SeekOrigin.Begin);
	}

	private int x7fd774787149ab50(Style x44ecfea61c937b8e)
	{
		int styleIdentifier = (int)x44ecfea61c937b8e.StyleIdentifier;
		styleIdentifier |= (x44ecfea61c937b8e.x4848603eaf370e03 ? 8192 : 0);
		styleIdentifier |= (x44ecfea61c937b8e.xcbf95a2bd7b4de24 ? 16384 : 0);
		x9b287b671d592594.Write((ushort)styleIdentifier);
		styleIdentifier = (int)x44ecfea61c937b8e.Type;
		styleIdentifier |= x44ecfea61c937b8e.xe709b224f455b863 << 4;
		x9b287b671d592594.Write((ushort)styleIdentifier);
		styleIdentifier = x5f24bbfe9853bd49(x44ecfea61c937b8e.Type);
		styleIdentifier |= x44ecfea61c937b8e.xfb77c9ea054ac31c << 4;
		x9b287b671d592594.Write((ushort)styleIdentifier);
		int result = (int)x9b287b671d592594.BaseStream.Position;
		x9b287b671d592594.Write((ushort)0);
		styleIdentifier = 0;
		styleIdentifier |= (x44ecfea61c937b8e.x913ff5916b187824 ? 1 : 0);
		styleIdentifier |= (x44ecfea61c937b8e.x96e55b5d052d1279 ? 2 : 0);
		styleIdentifier |= (x44ecfea61c937b8e.x5463d55288b12514 ? 12 : 0);
		styleIdentifier |= (x44ecfea61c937b8e.xde61abbe9514a1ee ? 16 : 0);
		styleIdentifier |= (x44ecfea61c937b8e.x3bbb21ee843f081c ? 32 : 0);
		styleIdentifier |= (x44ecfea61c937b8e.xdf3672ec434b4524 ? 64 : 0);
		styleIdentifier |= (x44ecfea61c937b8e.x45101ac87546632f ? 256 : 0);
		styleIdentifier |= (x44ecfea61c937b8e.x2d8aaa05bddcf40c ? 512 : 0);
		styleIdentifier |= (x44ecfea61c937b8e.x698badc7f383579c ? 1024 : 0);
		styleIdentifier |= (x44ecfea61c937b8e.x5356a3af7e7ecdfa ? 2048 : 0);
		styleIdentifier |= (x44ecfea61c937b8e.xebe0f6c7e6f4ae3a ? 4096 : 0);
		x9b287b671d592594.Write((ushort)styleIdentifier);
		int num = ((x44ecfea61c937b8e.x4cf1854ef833220f != 4095) ? x44ecfea61c937b8e.x4cf1854ef833220f : 0);
		x9b287b671d592594.Write((ushort)num);
		x9b287b671d592594.Write(x44ecfea61c937b8e.xe12a6bc6d222e782);
		styleIdentifier = 0;
		styleIdentifier |= x44ecfea61c937b8e.x9eb07da9aa5bbf9e << 4;
		x9b287b671d592594.Write((ushort)styleIdentifier);
		return result;
	}

	private void x2b45c45a079180eb(Style x44ecfea61c937b8e, int x79e3bb911730b0d4)
	{
		switch (x44ecfea61c937b8e.Type)
		{
		case StyleType.Paragraph:
			x29d811387c0dde4f(x9b287b671d592594.BaseStream, x79e3bb911730b0d4);
			xfb80633b3fcbe371(x44ecfea61c937b8e.x1a78664fa10a3755);
			x29d811387c0dde4f(x9b287b671d592594.BaseStream, x79e3bb911730b0d4);
			x27f9815450371ee9(x44ecfea61c937b8e.xeedad81aaed42a76);
			break;
		case StyleType.Character:
			x29d811387c0dde4f(x9b287b671d592594.BaseStream, x79e3bb911730b0d4);
			x27f9815450371ee9(x44ecfea61c937b8e.xeedad81aaed42a76);
			break;
		case StyleType.List:
			x29d811387c0dde4f(x9b287b671d592594.BaseStream, x79e3bb911730b0d4);
			xfb80633b3fcbe371(x44ecfea61c937b8e.x1a78664fa10a3755);
			break;
		case StyleType.Table:
		{
			TableStyle tableStyle = (TableStyle)x44ecfea61c937b8e;
			x29d811387c0dde4f(x9b287b671d592594.BaseStream, x79e3bb911730b0d4);
			x5c12f3cc90da0a84 x5c12f3cc90da0a85 = x172509d410571cfd.x746ca66f5c31e314(tableStyle);
			x5c12f3cc90da0a85.x6210059f049f0d48(x9b287b671d592594);
			x29d811387c0dde4f(x9b287b671d592594.BaseStream, x79e3bb911730b0d4);
			x3ff949c473a702d2 x3ff949c473a702d3 = new x3ff949c473a702d2(x44ecfea61c937b8e.x8301ab10c226b0c2, x17258deefeb290b7.x746ca66f5c31e314(tableStyle));
			x3ff949c473a702d3.x6210059f049f0d48(x9b287b671d592594, x0381b6dfdcc2d7b9: false);
			x29d811387c0dde4f(x9b287b671d592594.BaseStream, x79e3bb911730b0d4);
			x9dba795deb731d48 x9dba795deb731d49 = new x9dba795deb731d48(x326d2c4737b8a926.x746ca66f5c31e314(tableStyle));
			x9dba795deb731d49.x6210059f049f0d48(x9b287b671d592594, x0381b6dfdcc2d7b9: false);
			break;
		}
		default:
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("edbkkeikeepkeeglcenlheemldlmkobnkdjnidaokdhokcooacfpinlpjcdalckapbbbbbibhnob", 1079419103)));
		}
	}

	private void xe0e3addf31436a45(TableStyle x44ecfea61c937b8e)
	{
		x5c12f3cc90da0a84 x5c12f3cc90da0a85 = new x5c12f3cc90da0a84(x7450cc1e48712286);
		x172509d410571cfd.xf75fc5b2f257a111(x5c12f3cc90da0a85.x6b73aa01aa019d3a, x44ecfea61c937b8e);
	}

	private void x99de4c12f23317ce(TableStyle x44ecfea61c937b8e)
	{
		x9dba795deb731d48 x9dba795deb731d49 = new x9dba795deb731d48(x7450cc1e48712286, isInFKP: false);
		x326d2c4737b8a926.xf75fc5b2f257a111(x9dba795deb731d49.x6b73aa01aa019d3a, x44ecfea61c937b8e);
	}

	private void xeedbfa015fd1cb67(TableStyle x44ecfea61c937b8e)
	{
		x3ff949c473a702d2 x3ff949c473a702d3 = new x3ff949c473a702d2(x7450cc1e48712286, isInFKP: false);
		x17258deefeb290b7.x06b0e25aa6ad68a9(x3ff949c473a702d3.x6b73aa01aa019d3a, x44ecfea61c937b8e);
	}

	private void xbd12d1ad296c44a8(x1a78664fa10a3755 x062aae8c9613eeaa)
	{
		x3ff949c473a702d2 x03ef0b0129c670a = new x3ff949c473a702d2(x7450cc1e48712286, isInFKP: false);
		x17258deefeb290b7.x06b0e25aa6ad68a9(x03ef0b0129c670a, x062aae8c9613eeaa, x3e35d31c960f9b62);
	}

	private void x52a6f794e080ea91(xeedad81aaed42a76 x789564759d365819)
	{
		x9dba795deb731d48 x9dba795deb731d49 = new x9dba795deb731d48(x7450cc1e48712286, isInFKP: false);
		x326d2c4737b8a926.x06b0e25aa6ad68a9(x9dba795deb731d49.x6b73aa01aa019d3a, x789564759d365819, x69976e932774eb61);
	}

	private void xfb80633b3fcbe371(x1a78664fa10a3755 x062aae8c9613eeaa)
	{
		x3ff949c473a702d2 x3ff949c473a702d3 = x17258deefeb290b7.x6210059f049f0d48(x062aae8c9613eeaa, x3e35d31c960f9b62);
		x3ff949c473a702d3.x6210059f049f0d48(x9b287b671d592594, x0381b6dfdcc2d7b9: false);
	}

	private void x27f9815450371ee9(xeedad81aaed42a76 x789564759d365819)
	{
		x9dba795deb731d48 x9dba795deb731d49 = x326d2c4737b8a926.x6210059f049f0d48(x4c8d992f901ee838(x789564759d365819), x69976e932774eb61, x0463a6b206bbf7e4: false);
		x9dba795deb731d49.x6210059f049f0d48(x9b287b671d592594, x0381b6dfdcc2d7b9: false);
	}

	private static xeedad81aaed42a76 x4c8d992f901ee838(xeedad81aaed42a76 x789564759d365819)
	{
		xeedad81aaed42a76 xeedad81aaed42a = (xeedad81aaed42a76)x789564759d365819.x8b61531c8ea35b85();
		xeedad81aaed42a.x52b190e626f65140(50);
		return xeedad81aaed42a;
	}

	internal static void x29d811387c0dde4f(Stream xcf18e5243f8d5fd3, int x5a919fd2d73941b8)
	{
		int num = (int)xcf18e5243f8d5fd3.Position - x5a919fd2d73941b8;
		if (x0d299f323d241756.x7e32f71c3f39b6bc(num))
		{
			int num2 = (int)xcf18e5243f8d5fd3.Position + 1;
			if (xcf18e5243f8d5fd3.Length < num2)
			{
				xcf18e5243f8d5fd3.SetLength(num2);
			}
			xcf18e5243f8d5fd3.Position = num2;
		}
	}

	private static int x5f24bbfe9853bd49(StyleType x43163d22e8cd5a71)
	{
		return x43163d22e8cd5a71 switch
		{
			StyleType.Character => 1, 
			StyleType.Paragraph => 2, 
			StyleType.List => 1, 
			StyleType.Table => 3, 
			_ => throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("hmiennpehngfhnnffnegknlgomchnhjhnmailmhinmoinlfjdlmjlgdkmlkkolblclilekplkggm", 1325090930))), 
		};
	}

	private void xbbf9a1ead81dd3a1(WarningType x43163d22e8cd5a71, string xc2358fbac7da3d45)
	{
		if (xa056586c1f99e199 != null)
		{
			xa056586c1f99e199.Warning(new WarningInfo(x43163d22e8cd5a71, WarningSource.Doc, xc2358fbac7da3d45));
		}
	}

	private void x3dc950453374051a(string xc2358fbac7da3d45)
	{
		if (xa056586c1f99e199 != null)
		{
			xa056586c1f99e199.Warning(new WarningInfo(WarningType.UnexpectedContent, WarningSource.Doc, xc2358fbac7da3d45));
		}
	}
}
