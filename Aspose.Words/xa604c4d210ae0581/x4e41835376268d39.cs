using System;
using System.Collections.Specialized;
using System.IO;
using Aspose.Words;
using Aspose.Words.Fonts;
using Aspose.Words.Lists;
using x13f1efc79617a47b;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;
using xd2754ae26d400653;
using xf989f31a236ff98c;

namespace xa604c4d210ae0581;

internal class x4e41835376268d39
{
	private readonly ListCollection xbc2e79ef0cee7243;

	private readonly xa55b88ee4e81381b x17258deefeb290b7;

	private readonly x3af03f5f12c5ee73 x326d2c4737b8a926;

	private x8aeace2bf92692ab xa6172040dc8d693f;

	private BinaryReader x7450cc1e48712286;

	private BinaryWriter x9b287b671d592594;

	private IWarningCallback xa056586c1f99e199;

	internal static bool x492f529cee830a40;

	internal x4e41835376268d39(FontInfoCollection fontInfos, xd47c6c7442eb8033 revisionAuthors, ListCollection lists, IWarningCallback warningCallback)
	{
		xa056586c1f99e199 = warningCallback;
		xbc2e79ef0cee7243 = lists;
		x17258deefeb290b7 = new xa55b88ee4e81381b(null, revisionAuthors, warningCallback);
		x326d2c4737b8a926 = new x3af03f5f12c5ee73(fontInfos, revisionAuthors, warningCallback);
	}

	internal void x06b0e25aa6ad68a9(x8aeace2bf92692ab xf0c8411938a86cbf, BinaryReader xe134235b3526fa75)
	{
		xa6172040dc8d693f = xf0c8411938a86cbf;
		x7450cc1e48712286 = xe134235b3526fa75;
		x881f16699ca1a14e();
		xa784f0f0ea1df870();
		x88be735a878b4bcb();
	}

	internal void x6210059f049f0d48(x8aeace2bf92692ab xf0c8411938a86cbf, BinaryWriter xbdfb620b7167944b)
	{
		xa6172040dc8d693f = xf0c8411938a86cbf;
		x9b287b671d592594 = xbdfb620b7167944b;
		xa6172040dc8d693f.x955a03f821588c52.x54ba2d9dae44a315.xe53f0e68147463d1 = (int)x9b287b671d592594.BaseStream.Position;
		xa6172040dc8d693f.x955a03f821588c52.x54ba2d9dae44a315.x04c290dc4d04369c = x2788ff87c749937c();
		xa6172040dc8d693f.x955a03f821588c52.x40856f8b8f886cb2.xe53f0e68147463d1 = (int)x9b287b671d592594.BaseStream.Position;
		xa6172040dc8d693f.x955a03f821588c52.x40856f8b8f886cb2.x04c290dc4d04369c = x785545f7afb8428d();
		xa6172040dc8d693f.x955a03f821588c52.x98eb40491ac510a4.xe53f0e68147463d1 = (int)x9b287b671d592594.BaseStream.Position;
		xa6172040dc8d693f.x955a03f821588c52.x98eb40491ac510a4.x04c290dc4d04369c = xe192b4c162a90639();
	}

	private void x881f16699ca1a14e()
	{
		if (xa6172040dc8d693f.x955a03f821588c52.x54ba2d9dae44a315.x04c290dc4d04369c == 0)
		{
			return;
		}
		x7450cc1e48712286.BaseStream.Position = xa6172040dc8d693f.x955a03f821588c52.x54ba2d9dae44a315.xe53f0e68147463d1;
		int num = x7450cc1e48712286.ReadInt16();
		for (int i = 0; i < num; i++)
		{
			xbc2e79ef0cee7243.x3698cb58c2e87a72(x57a3c62b6759137e());
		}
		for (int j = 0; j < num; j++)
		{
			x178ff6dcbf808c38 x178ff6dcbf808c = xbc2e79ef0cee7243.x3bfa6064d69ac0da(j);
			if (!x9f88fc648c228e8b(x178ff6dcbf808c))
			{
				x3dc950453374051a("List level in list definition 0x{0:x} is corrupted, stop reading.", x178ff6dcbf808c.x1eac770549050632);
				break;
			}
		}
	}

	private int x2788ff87c749937c()
	{
		if (xbc2e79ef0cee7243.xddf1da3d36406847 == 0)
		{
			return 0;
		}
		int num = (int)x9b287b671d592594.BaseStream.Position;
		x9b287b671d592594.Write((short)xbc2e79ef0cee7243.xddf1da3d36406847);
		for (int i = 0; i < xbc2e79ef0cee7243.xddf1da3d36406847; i++)
		{
			x723106ba2e8579a1(xbc2e79ef0cee7243.x3bfa6064d69ac0da(i));
		}
		int result = (int)x9b287b671d592594.BaseStream.Position - num;
		for (int j = 0; j < xbc2e79ef0cee7243.xddf1da3d36406847; j++)
		{
			x54189970700b9a30(xbc2e79ef0cee7243.x3bfa6064d69ac0da(j));
		}
		return result;
	}

	private x178ff6dcbf808c38 x57a3c62b6759137e()
	{
		int listDefId = x7450cc1e48712286.ReadInt32();
		int templateCode = x7450cc1e48712286.ReadInt32();
		int[] array = new int[9];
		bool flag = true;
		for (int i = 0; i < 9; i++)
		{
			array[i] = x7450cc1e48712286.ReadInt16();
			if (array[i] != 0)
			{
				flag = false;
			}
		}
		if (flag)
		{
			for (int j = 0; j < 9; j++)
			{
				array[j] = 4095;
			}
		}
		int num = x7450cc1e48712286.ReadByte();
		x7450cc1e48712286.ReadByte();
		x902c8ac86fbaf048 listType = (((num & 1) == 0) ? (((num & 0x10) == 0) ? x902c8ac86fbaf048.x7e86ac926e2dc940 : x902c8ac86fbaf048.x598f41525926b38a) : x902c8ac86fbaf048.xabed123f43874357);
		x178ff6dcbf808c38 x178ff6dcbf808c = new x178ff6dcbf808c38(xbc2e79ef0cee7243.Document, listDefId, listType, templateCode);
		for (int k = 0; k < x178ff6dcbf808c.x438a2a8db4b2d07b.Count; k++)
		{
			x178ff6dcbf808c.x438a2a8db4b2d07b.x90a164d2f15bfc09(k).x4a1340b0df048976 = array[k];
		}
		return x178ff6dcbf808c;
	}

	private void x723106ba2e8579a1(x178ff6dcbf808c38 x02c001fe9bc75871)
	{
		x9b287b671d592594.Write(x02c001fe9bc75871.x1eac770549050632);
		x9b287b671d592594.Write(x02c001fe9bc75871.x18f9fc979b70e77f);
		for (int i = 0; i < 9; i++)
		{
			int num = ((i < x02c001fe9bc75871.x438a2a8db4b2d07b.Count) ? x02c001fe9bc75871.x438a2a8db4b2d07b.x90a164d2f15bfc09(i).x4a1340b0df048976 : 4095);
			x9b287b671d592594.Write((short)num);
		}
		int num2 = 0;
		switch (x02c001fe9bc75871.x902c8ac86fbaf048)
		{
		case x902c8ac86fbaf048.xabed123f43874357:
			num2 |= 1;
			break;
		case x902c8ac86fbaf048.x598f41525926b38a:
			num2 |= 0x10;
			break;
		default:
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("deamjfhmdfomdffnbfmngfdokekojpapceipmdppdegabenakodbldlbndccbdjcdcadjogd", 1236254702)));
		case x902c8ac86fbaf048.x7e86ac926e2dc940:
			break;
		}
		x9b287b671d592594.Write((ushort)num2);
	}

	private bool x9f88fc648c228e8b(x178ff6dcbf808c38 x02c001fe9bc75871)
	{
		for (int i = 0; i < x02c001fe9bc75871.x438a2a8db4b2d07b.Count; i++)
		{
			if (!x56db4489fc80c354(x02c001fe9bc75871.x438a2a8db4b2d07b[i]))
			{
				return false;
			}
		}
		return true;
	}

	private void x54189970700b9a30(x178ff6dcbf808c38 x02c001fe9bc75871)
	{
		for (int i = 0; i < x02c001fe9bc75871.x438a2a8db4b2d07b.Count; i++)
		{
			x788718c529bf1726(x02c001fe9bc75871.x438a2a8db4b2d07b[i]);
		}
	}

	private bool x56db4489fc80c354(ListLevel xdcfcc0186c9811f1)
	{
		xdcfcc0186c9811f1.xd62f9a1bfab2aceb(x7450cc1e48712286.ReadInt32());
		xdcfcc0186c9811f1.NumberStyle = (NumberStyle)x7450cc1e48712286.ReadByte();
		int num = x7450cc1e48712286.ReadByte();
		xdcfcc0186c9811f1.Alignment = (ListLevelAlignment)(num & 3);
		xdcfcc0186c9811f1.IsLegal = (num & 4) != 0;
		bool flag = (num & 8) != 0;
		xdcfcc0186c9811f1.x969abf858b3fe7e8 = (num & 0x10) != 0;
		xdcfcc0186c9811f1.x91bd46873c858a0c = (num & 0x20) != 0;
		xdcfcc0186c9811f1.xf9be1d0b8b44c7e8 = (num & 0x40) != 0;
		xdcfcc0186c9811f1.x83b68d5fabfc1faa = (num & 0x80) != 0;
		x7450cc1e48712286.ReadBytes(9);
		xdcfcc0186c9811f1.TrailingCharacter = (ListTrailingCharacter)x7450cc1e48712286.ReadByte();
		xdcfcc0186c9811f1.x42bf8be828fc1b33 = x7450cc1e48712286.ReadInt32();
		xdcfcc0186c9811f1.x5cf63f659ff5ee9f = x7450cc1e48712286.ReadInt32();
		int grpprlSize = x7450cc1e48712286.ReadByte();
		int grpprlSize2 = x7450cc1e48712286.ReadByte();
		int xbcea506a33cf = x7450cc1e48712286.ReadByte() - 1;
		x7450cc1e48712286.ReadByte();
		if (flag)
		{
			xdcfcc0186c9811f1.xb90138cd78a1ba8e(xbcea506a33cf);
		}
		x32939c68497cb083 x32939c68497cb84 = new x32939c68497cb083(x7450cc1e48712286, grpprlSize2);
		x17258deefeb290b7.x06b0e25aa6ad68a9(x32939c68497cb84.x6b73aa01aa019d3a, xdcfcc0186c9811f1.x1a78664fa10a3755, null);
		if (xa6172040dc8d693f.x4debd6958bcd2b55 == x3a9e25666c8d1ee1.x002fff412acd012e && !xdcfcc0186c9811f1.x1a78664fa10a3755.x263d579af1d0d43f(1560))
		{
			xdcfcc0186c9811f1.x1a78664fa10a3755.xcedf9c82728ad579 = true;
			x20eec3666a2dc8d0.xb07a1ad51e61e4f3(xdcfcc0186c9811f1.x1a78664fa10a3755);
			xdcfcc0186c9811f1.x1a78664fa10a3755.x52b190e626f65140(1560);
		}
		else
		{
			x20eec3666a2dc8d0.xb07a1ad51e61e4f3(xdcfcc0186c9811f1.x1a78664fa10a3755);
		}
		x32939c68497cb083 x32939c68497cb85 = new x32939c68497cb083(x7450cc1e48712286, grpprlSize);
		x326d2c4737b8a926.x06b0e25aa6ad68a9(x32939c68497cb85.x6b73aa01aa019d3a, xdcfcc0186c9811f1.xeedad81aaed42a76, null);
		uint xc7367ec35e = x7450cc1e48712286.ReadUInt16();
		x7450cc1e48712286.BaseStream.Position -= 2L;
		bool flag2 = x0d299f323d241756.xd7d2f6dd32a72a3b(x7450cc1e48712286, (int)xc7367ec35e);
		if (flag2)
		{
			string xbcea506a33cf2 = x93b05c1ad709a695.x602d3c3fbfa56f51(x7450cc1e48712286, x5be1cad1d00af914: true, xac1baf51b3e43d13: false);
			if (ListLevel.xed41d88c7868b0c8(xbcea506a33cf2))
			{
				xdcfcc0186c9811f1.xcf5f81ead54b5e79(xbcea506a33cf2);
			}
			else
			{
				x3dc950453374051a("Invalid number format definition, skipped.");
			}
		}
		else
		{
			x3dc950453374051a("Invalid number format definition, skipped.");
		}
		x301c07c1b0ebe49c(xdcfcc0186c9811f1);
		return flag2;
	}

	private static void x301c07c1b0ebe49c(ListLevel xdcfcc0186c9811f1)
	{
		object obj = xdcfcc0186c9811f1.xeedad81aaed42a76.x9bd0b4c41657450b(490);
		object obj2 = xdcfcc0186c9811f1.xeedad81aaed42a76.x9bd0b4c41657450b(480);
		if (obj != null && obj2 != null)
		{
			x9c3f027bfeb42e13 x9c3f027bfeb42e14 = (x9c3f027bfeb42e13)obj;
			if ((x9c3f027bfeb42e14 & x9c3f027bfeb42e13.xac2476e21cf9ff96) != 0)
			{
				xdcfcc0186c9811f1.x4d819daa8b29e86b = (int)obj2;
			}
		}
		xdcfcc0186c9811f1.xeedad81aaed42a76.x52b190e626f65140(490);
		xdcfcc0186c9811f1.xeedad81aaed42a76.x52b190e626f65140(480);
	}

	private void x788718c529bf1726(ListLevel x66bbd7ed8c65740d)
	{
		x9b287b671d592594.Write(x66bbd7ed8c65740d.StartAt);
		x9b287b671d592594.Write((byte)x66bbd7ed8c65740d.NumberStyle);
		int num = 0;
		num |= (byte)x66bbd7ed8c65740d.Alignment;
		num |= (x66bbd7ed8c65740d.IsLegal ? 4 : 0);
		num |= (x66bbd7ed8c65740d.xfbad6d0650721048 ? 8 : 0);
		num |= (x66bbd7ed8c65740d.x969abf858b3fe7e8 ? 16 : 0);
		num |= (x66bbd7ed8c65740d.x91bd46873c858a0c ? 32 : 0);
		num |= (x66bbd7ed8c65740d.xf9be1d0b8b44c7e8 ? 64 : 0);
		num |= (x66bbd7ed8c65740d.x83b68d5fabfc1faa ? 128 : 0);
		x9b287b671d592594.Write((byte)num);
		byte[] buffer = xd51c6adaa2c36634(x66bbd7ed8c65740d.NumberFormat);
		x9b287b671d592594.Write(buffer);
		x9b287b671d592594.Write((byte)x66bbd7ed8c65740d.TrailingCharacter);
		x9b287b671d592594.Write(x66bbd7ed8c65740d.x42bf8be828fc1b33);
		x9b287b671d592594.Write(x66bbd7ed8c65740d.x5cf63f659ff5ee9f);
		x541de24856776554(x66bbd7ed8c65740d);
		x9dba795deb731d48 x9dba795deb731d49 = x326d2c4737b8a926.x6210059f049f0d48(x66bbd7ed8c65740d.xeedad81aaed42a76, null, x0463a6b206bbf7e4: false);
		x9b287b671d592594.Write((byte)x9dba795deb731d49.x6b73aa01aa019d3a.Length);
		x3ff949c473a702d2 x3ff949c473a702d3 = x17258deefeb290b7.x6210059f049f0d48(x66bbd7ed8c65740d.x1a78664fa10a3755, null);
		x9b287b671d592594.Write((byte)x3ff949c473a702d3.x6b73aa01aa019d3a.Length);
		int num2 = (x66bbd7ed8c65740d.xfbad6d0650721048 ? (x66bbd7ed8c65740d.RestartAfterLevel + 1) : 0);
		x9b287b671d592594.Write((short)num2);
		x9b287b671d592594.Write(x3ff949c473a702d3.x6b73aa01aa019d3a);
		x9b287b671d592594.Write(x9dba795deb731d49.x6b73aa01aa019d3a);
		x93b05c1ad709a695.x4a3c44ae9b1cf5ab(x66bbd7ed8c65740d.NumberFormat, int.MaxValue, x9b287b671d592594, x5be1cad1d00af914: true, xac1baf51b3e43d13: false);
	}

	private static void x541de24856776554(ListLevel xdcfcc0186c9811f1)
	{
		xeedad81aaed42a76 xeedad81aaed42a = xdcfcc0186c9811f1.xeedad81aaed42a76;
		if (xdcfcc0186c9811f1.x44b52529222cea8a)
		{
			xeedad81aaed42a.xae20093bed1e48a8(480, xdcfcc0186c9811f1.x4d819daa8b29e86b);
			xeedad81aaed42a.xae20093bed1e48a8(490, x9c3f027bfeb42e13.xac2476e21cf9ff96);
		}
		else
		{
			xeedad81aaed42a.xae20093bed1e48a8(480, 0);
			xeedad81aaed42a.xae20093bed1e48a8(490, x9c3f027bfeb42e13.x4d0b9d4447ba7566);
		}
	}

	private static byte[] xd51c6adaa2c36634(string x2eebe5b22e29f252)
	{
		byte[] array = new byte[9];
		int num = 0;
		for (int i = 0; i < x2eebe5b22e29f252.Length; i++)
		{
			if (ListLevel.x775a459d4e3c3432(x2eebe5b22e29f252[i]))
			{
				array[num] = (byte)(i + 1);
				num++;
				if (num >= array.Length)
				{
					break;
				}
			}
		}
		return array;
	}

	private void xa784f0f0ea1df870()
	{
		if (xa6172040dc8d693f.x955a03f821588c52.x40856f8b8f886cb2.x04c290dc4d04369c != 0)
		{
			x7450cc1e48712286.BaseStream.Seek(xa6172040dc8d693f.x955a03f821588c52.x40856f8b8f886cb2.xe53f0e68147463d1, SeekOrigin.Begin);
			int num = x7450cc1e48712286.ReadInt32();
			for (int i = 0; i < num; i++)
			{
				int x43eb71c4e55e38d = i + 1;
				xbc2e79ef0cee7243.xa22e280934fc3004(xa30a8a5303f393bc(x43eb71c4e55e38d));
			}
			for (int j = 0; j < num; j++)
			{
				x9d113a9122f2b634(xbc2e79ef0cee7243[j]);
			}
		}
	}

	private int x785545f7afb8428d()
	{
		int num = (int)x9b287b671d592594.BaseStream.Position;
		x9b287b671d592594.Write(xbc2e79ef0cee7243.Count);
		for (int i = 0; i < xbc2e79ef0cee7243.Count; i++)
		{
			x43a6cd780ee8d38f(xbc2e79ef0cee7243[i]);
		}
		for (int j = 0; j < xbc2e79ef0cee7243.Count; j++)
		{
			x82947fa62394b22e(xbc2e79ef0cee7243[j]);
		}
		return (int)x9b287b671d592594.BaseStream.Position - num;
	}

	private List xa30a8a5303f393bc(int x43eb71c4e55e38d0)
	{
		List list = new List(xbc2e79ef0cee7243.Document, x43eb71c4e55e38d0);
		list.x1eac770549050632 = x7450cc1e48712286.ReadInt32();
		list.x1eac770549050632 = list.x178ff6dcbf808c38.x1eac770549050632;
		x7450cc1e48712286.ReadInt32();
		x7450cc1e48712286.ReadInt32();
		int num = Math.Min((int)x7450cc1e48712286.ReadByte(), 9);
		for (int i = 0; i < num; i++)
		{
			list.x6047afa6812e47bc.Add(new x136abcf7d9c0eef3());
		}
		int num2 = x7450cc1e48712286.ReadByte();
		if (num2 > 0)
		{
			x3dc950453374051a("Lists linked to AutoNum fields are not supported by Aspose.Words.");
		}
		x7450cc1e48712286.ReadByte();
		x7450cc1e48712286.ReadByte();
		return list;
	}

	private void x43a6cd780ee8d38f(List x8a0b266419f09a55)
	{
		x9b287b671d592594.Write(x8a0b266419f09a55.x1eac770549050632);
		x9b287b671d592594.Write(0);
		x9b287b671d592594.Write(0);
		x9b287b671d592594.Write((byte)x8a0b266419f09a55.x6047afa6812e47bc.Count);
		x9b287b671d592594.Write((byte)0);
		x9b287b671d592594.Write((short)0);
	}

	private void x9d113a9122f2b634(List x8a0b266419f09a55)
	{
		x7450cc1e48712286.ReadInt32();
		foreach (x136abcf7d9c0eef3 item in x8a0b266419f09a55.x6047afa6812e47bc)
		{
			xf577670a68bf3be4(item);
		}
	}

	private void x82947fa62394b22e(List x8a0b266419f09a55)
	{
		x9b287b671d592594.Write(uint.MaxValue);
		foreach (x136abcf7d9c0eef3 item in x8a0b266419f09a55.x6047afa6812e47bc)
		{
			x17e24f2f6a306892(item);
		}
	}

	private void xf577670a68bf3be4(x136abcf7d9c0eef3 x39fa68e7c3713aec)
	{
		x39fa68e7c3713aec.x6da6130e001c6962 = x7450cc1e48712286.ReadInt32();
		int num = x7450cc1e48712286.ReadByte();
		int levelNumber = num & 0xF;
		x39fa68e7c3713aec.xf13a626e550cef8f = new ListLevel(xbc2e79ef0cee7243.Document, levelNumber);
		x39fa68e7c3713aec.x33160172e2e7ff13 = (num & 0x10) != 0;
		x39fa68e7c3713aec.x178c863a9c967cd2 = (num & 0x20) != 0;
		x39fa68e7c3713aec.xda76c7dfd195022e = x7450cc1e48712286.ReadInt16();
		x39fa68e7c3713aec.x41c02f247da65443 = x7450cc1e48712286.ReadByte();
		if (x39fa68e7c3713aec.x178c863a9c967cd2)
		{
			x56db4489fc80c354(x39fa68e7c3713aec.xf13a626e550cef8f);
		}
	}

	private void x17e24f2f6a306892(x136abcf7d9c0eef3 x39fa68e7c3713aec)
	{
		x9b287b671d592594.Write(x39fa68e7c3713aec.x6da6130e001c6962);
		int num = 0;
		num |= x39fa68e7c3713aec.xf13a626e550cef8f.x008c23e8f687bbd3;
		num |= (x39fa68e7c3713aec.x33160172e2e7ff13 ? 16 : 0);
		num |= (x39fa68e7c3713aec.x178c863a9c967cd2 ? 32 : 0);
		x9b287b671d592594.Write((byte)num);
		x9b287b671d592594.Write((short)x39fa68e7c3713aec.xda76c7dfd195022e);
		x9b287b671d592594.Write((byte)x39fa68e7c3713aec.x41c02f247da65443);
		if (x39fa68e7c3713aec.x178c863a9c967cd2)
		{
			x788718c529bf1726(x39fa68e7c3713aec.xf13a626e550cef8f);
		}
	}

	private void x88be735a878b4bcb()
	{
		StringCollection stringCollection = new StringCollection();
		xaf807f6784ee1743.x06b0e25aa6ad68a9(x7450cc1e48712286, xa6172040dc8d693f.x955a03f821588c52.x98eb40491ac510a4, stringCollection);
		int num = Math.Min(stringCollection.Count, xbc2e79ef0cee7243.xddf1da3d36406847);
		for (int i = 0; i < num; i++)
		{
			x178ff6dcbf808c38 x178ff6dcbf808c = xbc2e79ef0cee7243.x3bfa6064d69ac0da(i);
			x178ff6dcbf808c.x759aa16c2016a289 = stringCollection[i];
		}
	}

	private int xe192b4c162a90639()
	{
		StringCollection stringCollection = new StringCollection();
		for (int i = 0; i < xbc2e79ef0cee7243.xddf1da3d36406847; i++)
		{
			stringCollection.Add(xbc2e79ef0cee7243.x3bfa6064d69ac0da(i).x759aa16c2016a289);
		}
		return xaf807f6784ee1743.x6210059f049f0d48(x9b287b671d592594, stringCollection);
	}

	private void x3dc950453374051a(string xc2358fbac7da3d45, params object[] xce8d8c7e3c2c2426)
	{
		x98b0e09ccece0a5a.x3dc950453374051a(xa056586c1f99e199, WarningSource.Doc, xc2358fbac7da3d45, xce8d8c7e3c2c2426);
	}
}
