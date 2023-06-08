using System.Collections;
using System.IO;
using Aspose.Words.Markup;
using x6c95d9cf46ff5f25;
using xa604c4d210ae0581;

namespace xaa035fc640f94856;

internal class x31a5ab258b5c21f3
{
	private const int x7b417667953b8608 = 6;

	private const int x297ba7840eaf5eba = 12;

	private const int x26b84e78c13d9b2d = 256;

	private readonly xd8cce4761dc846ee xbe793cee381eb540 = new xd8cce4761dc846ee();

	private readonly x5be798592fa7b9f9 x821d54c0137f779d = new x5be798592fa7b9f9();

	private readonly x9902572311b44647 xf47d9022f2504162 = new x9902572311b44647();

	private readonly Hashtable xdbfa7d816cbfb1ea = new Hashtable();

	private readonly ArrayList x844a06e73f5fb69e = new ArrayList();

	private readonly ArrayList x8612fde1eaae1e06 = new ArrayList();

	private readonly Hashtable x0eee21c387b02825 = new Hashtable();

	private readonly Hashtable x60a282a7c6313768 = new Hashtable();

	private readonly Hashtable xd548d8ac682e0940 = new Hashtable();

	internal static bool x492f529cee830a40;

	internal x5be798592fa7b9f9 x1213e861660862e7 => x821d54c0137f779d;

	internal x9902572311b44647 x8a4e50b3272d2d52 => xf47d9022f2504162;

	internal x31a5ab258b5c21f3()
	{
	}

	internal x31a5ab258b5c21f3(x8aeace2bf92692ab fib, BinaryReader reader)
	{
		if (fib.x4605e55a1901024b.x9b77e34959b5e6a4.x04c290dc4d04369c != 0)
		{
			x0ce60e3f14280aec(reader, fib.x4605e55a1901024b.x9b77e34959b5e6a4);
			x821d54c0137f779d.x06b0e25aa6ad68a9(reader, fib.x4605e55a1901024b.x350fb672526dee97);
			xf47d9022f2504162.x06b0e25aa6ad68a9(reader, fib.x4605e55a1901024b.x4eda30a2ce8d1048);
			x4fac8de2a5262c9a(reader, fib.x4605e55a1901024b.xd54287c5ba73a4b9);
		}
	}

	private void x0ce60e3f14280aec(BinaryReader xe134235b3526fa75, x3fdb33c580a0bef3 x30fd2092179cb141)
	{
		if (x30fd2092179cb141.x04c290dc4d04369c != 0)
		{
			xe134235b3526fa75.BaseStream.Position = x30fd2092179cb141.xe53f0e68147463d1;
			xe134235b3526fa75.ReadUInt16();
			int num = xe134235b3526fa75.ReadInt16();
			xe134235b3526fa75.ReadInt16();
			_ = x492f529cee830a40;
			for (int i = 0; i < num; i++)
			{
				xe134235b3526fa75.ReadInt16();
				int xbcea506a33cf = xe134235b3526fa75.ReadInt32();
				xbe793cee381eb540.xd6b6ed77479ef68c(xbcea506a33cf);
				xe134235b3526fa75.ReadInt32();
				xe134235b3526fa75.ReadInt32();
				_ = x492f529cee830a40;
			}
		}
	}

	private void x4fac8de2a5262c9a(BinaryReader xe134235b3526fa75, x3fdb33c580a0bef3 x647dcec2a1df44a2)
	{
		if (x647dcec2a1df44a2.x04c290dc4d04369c != 0)
		{
			xe134235b3526fa75.BaseStream.Position = x647dcec2a1df44a2.xe53f0e68147463d1;
			x4a088a24e1bb365e(xe134235b3526fa75);
			xec96158beefbaee9(xe134235b3526fa75);
			xe3573b222303f05e(xe134235b3526fa75);
		}
	}

	private void x4a088a24e1bb365e(BinaryReader xe134235b3526fa75)
	{
		int num = xe134235b3526fa75.ReadInt32();
		_ = x492f529cee830a40;
		for (int i = 0; i < num; i++)
		{
			xf0391b353ea8ab43 xf0391b353ea8ab44 = new xf0391b353ea8ab43(xe134235b3526fa75);
			xdbfa7d816cbfb1ea[xf0391b353ea8ab44.xea1e81378298fa81] = xf0391b353ea8ab44;
			_ = x492f529cee830a40;
		}
	}

	private void xec96158beefbaee9(BinaryReader xe134235b3526fa75)
	{
		xe134235b3526fa75.ReadUInt16();
		xe134235b3526fa75.ReadUInt16();
		xe134235b3526fa75.ReadInt32();
		int num = xe134235b3526fa75.ReadInt32();
		_ = x492f529cee830a40;
		for (int i = 0; i < num; i++)
		{
			x844a06e73f5fb69e.Add(xc20b6ff0d1c320ff.x06b0e25aa6ad68a9(xe134235b3526fa75));
		}
	}

	private void xe3573b222303f05e(BinaryReader xe134235b3526fa75)
	{
		int xd44988f225497f3a = xbe793cee381eb540.xd44988f225497f3a;
		for (int i = 0; i < xd44988f225497f3a; i++)
		{
			x8612fde1eaae1e06.Add(new x077550583a096f29(xe134235b3526fa75));
		}
	}

	internal void x6210059f049f0d48(x8aeace2bf92692ab xf0c8411938a86cbf, BinaryWriter xbdfb620b7167944b)
	{
		xf0c8411938a86cbf.x4605e55a1901024b.x9b77e34959b5e6a4.xe53f0e68147463d1 = (int)xbdfb620b7167944b.BaseStream.Position;
		xf0c8411938a86cbf.x4605e55a1901024b.x9b77e34959b5e6a4.x04c290dc4d04369c = xf27748bc86965ef6(xbdfb620b7167944b);
		xf0c8411938a86cbf.x4605e55a1901024b.x350fb672526dee97.xe53f0e68147463d1 = (int)xbdfb620b7167944b.BaseStream.Position;
		xf0c8411938a86cbf.x4605e55a1901024b.x350fb672526dee97.x04c290dc4d04369c = x821d54c0137f779d.x6210059f049f0d48(xbdfb620b7167944b);
		xf0c8411938a86cbf.x4605e55a1901024b.x4eda30a2ce8d1048.xe53f0e68147463d1 = (int)xbdfb620b7167944b.BaseStream.Position;
		xf0c8411938a86cbf.x4605e55a1901024b.x4eda30a2ce8d1048.x04c290dc4d04369c = xf47d9022f2504162.x6210059f049f0d48(xbdfb620b7167944b);
		xf0c8411938a86cbf.x4605e55a1901024b.xd54287c5ba73a4b9.xe53f0e68147463d1 = (int)xbdfb620b7167944b.BaseStream.Position;
		xf0c8411938a86cbf.x4605e55a1901024b.xd54287c5ba73a4b9.x04c290dc4d04369c = xe9640986fba82f7f(xbdfb620b7167944b);
	}

	private int xf27748bc86965ef6(BinaryWriter xbdfb620b7167944b)
	{
		if (xbe793cee381eb540.xd44988f225497f3a == 0)
		{
			return 0;
		}
		int num = (int)xbdfb620b7167944b.BaseStream.Position;
		xbdfb620b7167944b.Write(ushort.MaxValue);
		xbdfb620b7167944b.Write((short)xbe793cee381eb540.xd44988f225497f3a);
		xbdfb620b7167944b.Write((short)0);
		for (int i = 0; i < xbe793cee381eb540.xd44988f225497f3a; i++)
		{
			xbdfb620b7167944b.Write((short)6);
			xbdfb620b7167944b.Write(xbe793cee381eb540.get_xe6d4b1b411ed94b5(i));
			xbdfb620b7167944b.Write(0);
			xbdfb620b7167944b.Write(0);
		}
		return (int)xbdfb620b7167944b.BaseStream.Position - num;
	}

	private int xe9640986fba82f7f(BinaryWriter xbdfb620b7167944b)
	{
		if (xdbfa7d816cbfb1ea.Count == 0)
		{
			return 0;
		}
		int num = (int)xbdfb620b7167944b.BaseStream.Position;
		x1eac7d80e954c655(xbdfb620b7167944b);
		x7fed27b2f88adea5(xbdfb620b7167944b);
		x7a093124b20eba30(xbdfb620b7167944b);
		return (int)xbdfb620b7167944b.BaseStream.Position - num;
	}

	private void x1eac7d80e954c655(BinaryWriter xbdfb620b7167944b)
	{
		xbdfb620b7167944b.Write(xdbfa7d816cbfb1ea.Count);
		foreach (xf0391b353ea8ab43 value in xdbfa7d816cbfb1ea.Values)
		{
			value.x6210059f049f0d48(xbdfb620b7167944b);
		}
	}

	private void x7fed27b2f88adea5(BinaryWriter xbdfb620b7167944b)
	{
		xbdfb620b7167944b.Write((ushort)12);
		xbdfb620b7167944b.Write((ushort)256);
		xbdfb620b7167944b.Write(0);
		xbdfb620b7167944b.Write(x844a06e73f5fb69e.Count);
		foreach (string item in x844a06e73f5fb69e)
		{
			xc20b6ff0d1c320ff.x6210059f049f0d48(xbdfb620b7167944b, item);
		}
	}

	private void x7a093124b20eba30(BinaryWriter xbdfb620b7167944b)
	{
		foreach (x077550583a096f29 item in x8612fde1eaae1e06)
		{
			item.x6210059f049f0d48(xbdfb620b7167944b);
		}
	}

	internal void xffb003338cfde846(int x18d1054d82981887, SmartTag xdc6161a296532e34)
	{
		xbe793cee381eb540.xd6b6ed77479ef68c(1001 + xbe793cee381eb540.xd44988f225497f3a);
		x0c7cf732a4f0c4d1 xccb63ca5f63dc = new x0c7cf732a4f0c4d1();
		int num = x821d54c0137f779d.xd6b6ed77479ef68c(x18d1054d82981887, xccb63ca5f63dc);
		x0eee21c387b02825.Add(xdc6161a296532e34, num);
		xf0391b353ea8ab43 xf0391b353ea8ab44 = x4ec1f744410ac6d6(xdc6161a296532e34.Uri, xdc6161a296532e34.Element);
		x077550583a096f29 x077550583a096f30 = new x077550583a096f29(xf0391b353ea8ab44.xea1e81378298fa81, xdc6161a296532e34.Properties.Count);
		x8612fde1eaae1e06.Add(x077550583a096f30);
		int num2 = 0;
		foreach (CustomXmlProperty property in xdc6161a296532e34.Properties)
		{
			x077550583a096f30.xf74d8efdcaef8ee6[num2] = xeaabfed5576c567c(property.Name);
			x077550583a096f30.xa32ede1025f7736e[num2] = xeaabfed5576c567c(property.Value);
			num2++;
		}
	}

	internal void x1ff8ac05a72bd9dd(int x18d1054d82981887, SmartTag xdc6161a296532e34)
	{
		int num = (int)x0eee21c387b02825[xdc6161a296532e34];
		xf1e709b281c70a73 xf1e709b281c70a74 = new xf1e709b281c70a73();
		xf1e709b281c70a74.x59e3e1af7fa7fc44 = num;
		int xff616fa638fdd6e = xf47d9022f2504162.xd6b6ed77479ef68c(x18d1054d82981887, xf1e709b281c70a74);
		x0c7cf732a4f0c4d1 x0c7cf732a4f0c4d2 = (x0c7cf732a4f0c4d1)x821d54c0137f779d.xe84e6ff66aac2a0e(num);
		x0c7cf732a4f0c4d2.xff616fa638fdd6e3 = xff616fa638fdd6e;
	}

	internal void x21befe581f77d29a(x31a5ab258b5c21f3 x50a18ad2656e7181, int x03d82212f016d5f9)
	{
		int xd44988f225497f3a = xbe793cee381eb540.xd44988f225497f3a;
		for (int i = 0; i < x50a18ad2656e7181.x1213e861660862e7.x23719734cf1f138c; i++)
		{
			xbe793cee381eb540.xd6b6ed77479ef68c(xd44988f225497f3a + x50a18ad2656e7181.xb10809a9d84aa18f(i));
			x0c7cf732a4f0c4d1 x0c7cf732a4f0c4d2 = (x0c7cf732a4f0c4d1)x50a18ad2656e7181.x1213e861660862e7.xe84e6ff66aac2a0e(i);
			x0c7cf732a4f0c4d2.xff616fa638fdd6e3 += xd44988f225497f3a;
			int num = x50a18ad2656e7181.x1213e861660862e7.xed8a0d4499d6f292(i);
			x821d54c0137f779d.xd6b6ed77479ef68c(x03d82212f016d5f9 + num, x0c7cf732a4f0c4d2);
			x077550583a096f29 x077550583a096f30 = x50a18ad2656e7181.x1e59dca0d9402f11(i);
			xf0391b353ea8ab43 xf0391b353ea8ab44 = x50a18ad2656e7181.x4ac1c3cc4f5e7e94(x077550583a096f30.xea1e81378298fa81);
			xf0391b353ea8ab43 xf0391b353ea8ab45 = x4ec1f744410ac6d6(xf0391b353ea8ab44.xb405a444ca77e2d4, xf0391b353ea8ab44.xd229d86af0f16fb0);
			x077550583a096f30.xea1e81378298fa81 = xf0391b353ea8ab45.xea1e81378298fa81;
			x8612fde1eaae1e06.Add(x077550583a096f30);
			for (int j = 0; j < x077550583a096f30.xf74d8efdcaef8ee6.Length; j++)
			{
				string xe4115acdf4fbfccc = x50a18ad2656e7181.x48112399d54b30c7(x077550583a096f30.xf74d8efdcaef8ee6[j]);
				x077550583a096f30.xf74d8efdcaef8ee6[j] = xeaabfed5576c567c(xe4115acdf4fbfccc);
				string xe4115acdf4fbfccc2 = x50a18ad2656e7181.x48112399d54b30c7(x077550583a096f30.xa32ede1025f7736e[j]);
				x077550583a096f30.xa32ede1025f7736e[j] = xeaabfed5576c567c(xe4115acdf4fbfccc2);
			}
		}
		for (int k = 0; k < x50a18ad2656e7181.x8a4e50b3272d2d52.x23719734cf1f138c; k++)
		{
			xf1e709b281c70a73 xf1e709b281c70a74 = (xf1e709b281c70a73)x50a18ad2656e7181.x8a4e50b3272d2d52.xe84e6ff66aac2a0e(k);
			xf1e709b281c70a74.x59e3e1af7fa7fc44 += xd44988f225497f3a;
			int num2 = x50a18ad2656e7181.x8a4e50b3272d2d52.xed8a0d4499d6f292(k);
			xf47d9022f2504162.xd6b6ed77479ef68c(x03d82212f016d5f9 + num2, xf1e709b281c70a74);
		}
	}

	private xf0391b353ea8ab43 x4ec1f744410ac6d6(string xbda579af315c6893, string xffe521cc76054baf)
	{
		string key = xbda579af315c6893 + xffe521cc76054baf;
		xf0391b353ea8ab43 xf0391b353ea8ab44 = (xf0391b353ea8ab43)x60a282a7c6313768[key];
		if (xf0391b353ea8ab44 == null)
		{
			int id = xdbfa7d816cbfb1ea.Count + 1;
			xf0391b353ea8ab44 = new xf0391b353ea8ab43(id, xbda579af315c6893, xffe521cc76054baf);
			xdbfa7d816cbfb1ea.Add(xf0391b353ea8ab44.xea1e81378298fa81, xf0391b353ea8ab44);
			x60a282a7c6313768.Add(key, xf0391b353ea8ab44);
		}
		return xf0391b353ea8ab44;
	}

	private int xeaabfed5576c567c(string xe4115acdf4fbfccc)
	{
		object obj = xd548d8ac682e0940[xe4115acdf4fbfccc];
		if (obj == null)
		{
			int num = x844a06e73f5fb69e.Add(xe4115acdf4fbfccc);
			xd548d8ac682e0940.Add(xe4115acdf4fbfccc, num);
			return num;
		}
		return (int)obj;
	}

	internal void x8ffe90e7fbccfccd(int x881407805cd3b591)
	{
		if (xbe793cee381eb540.xd44988f225497f3a != 0)
		{
			x821d54c0137f779d.xd6b6ed77479ef68c(x881407805cd3b591);
			xf47d9022f2504162.xd6b6ed77479ef68c(x881407805cd3b591);
			x9da221c6e7ce9284();
			x980184f64b28bc8f();
		}
	}

	private void x9da221c6e7ce9284()
	{
		int x23719734cf1f138c = x821d54c0137f779d.x23719734cf1f138c;
		for (int i = 0; i < x23719734cf1f138c; i++)
		{
			int num = x821d54c0137f779d.xed8a0d4499d6f292(i);
			x0c7cf732a4f0c4d1 x0c7cf732a4f0c4d2 = (x0c7cf732a4f0c4d1)x821d54c0137f779d.xe84e6ff66aac2a0e(i);
			x0c7cf732a4f0c4d2.x0363b0ac9a967bd2 = 0;
			for (int j = 0; j < x23719734cf1f138c; j++)
			{
				xa6101120b8ed585e xa6101120b8ed585e = new xa6101120b8ed585e(x821d54c0137f779d.xed8a0d4499d6f292(j), xf47d9022f2504162.xed8a0d4499d6f292(j));
				if (xa6101120b8ed585e.x7149c962c02931b3() || xa6101120b8ed585e.x263d579af1d0d43f(num))
				{
					x0c7cf732a4f0c4d2.x0363b0ac9a967bd2++;
				}
				if (xa6101120b8ed585e.x12cb12b5d2cad53d > num)
				{
					break;
				}
			}
		}
	}

	private void x980184f64b28bc8f()
	{
		int x23719734cf1f138c = xf47d9022f2504162.x23719734cf1f138c;
		for (int i = 0; i < x23719734cf1f138c; i++)
		{
			int num = xf47d9022f2504162.xed8a0d4499d6f292(i);
			xf1e709b281c70a73 xf1e709b281c70a74 = (xf1e709b281c70a73)xf47d9022f2504162.xe84e6ff66aac2a0e(i);
			xf1e709b281c70a74.x0363b0ac9a967bd2 = 0;
			for (int j = 0; j < x23719734cf1f138c; j++)
			{
				xa6101120b8ed585e xa6101120b8ed585e = new xa6101120b8ed585e(x821d54c0137f779d.xed8a0d4499d6f292(j), xf47d9022f2504162.xed8a0d4499d6f292(j));
				if (!xa6101120b8ed585e.x7149c962c02931b3() && xa6101120b8ed585e.x263d579af1d0d43f(num))
				{
					xf1e709b281c70a74.x0363b0ac9a967bd2++;
				}
				if (xa6101120b8ed585e.x12cb12b5d2cad53d > num)
				{
					break;
				}
			}
		}
	}

	private int xb10809a9d84aa18f(int xc0c4c459c6ccbd00)
	{
		return xbe793cee381eb540.get_xe6d4b1b411ed94b5(xc0c4c459c6ccbd00);
	}

	internal x077550583a096f29 x1e59dca0d9402f11(int xc0c4c459c6ccbd00)
	{
		return (x077550583a096f29)x8612fde1eaae1e06[xc0c4c459c6ccbd00];
	}

	internal xf0391b353ea8ab43 x4ac1c3cc4f5e7e94(int xeaf1b27180c0557b)
	{
		return (xf0391b353ea8ab43)xdbfa7d816cbfb1ea[xeaf1b27180c0557b];
	}

	internal string x48112399d54b30c7(int xc0c4c459c6ccbd00)
	{
		if (xc0c4c459c6ccbd00 < 0 || xc0c4c459c6ccbd00 >= x844a06e73f5fb69e.Count)
		{
			return "";
		}
		return (string)x844a06e73f5fb69e[xc0c4c459c6ccbd00];
	}
}
