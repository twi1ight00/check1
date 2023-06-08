using System;
using System.IO;
using System.Text;
using x13f1efc79617a47b;
using x6c95d9cf46ff5f25;

namespace xb92b7270f78a4e8d;

internal class xd686a7cfdb7bddb2
{
	internal const int xa230444f4711f2cc = 128;

	internal const uint x75a41e7cc19d4ff6 = uint.MaxValue;

	private const int x24a8f740f32f2656 = 64;

	private const int xe1aa1375e543ab39 = 16;

	private const int xd1ffefc1ea99c471 = 20;

	internal string x759aa16c2016a289;

	internal xb824d4787cda57d9 x2ff6d9d680555933;

	internal x256aac0252732d90 x3aa285be658a6bd4;

	internal uint xf469c807ba339d90;

	internal uint xcb628eae42e96691;

	internal uint xafe684f748981f4f;

	internal Guid x933ed8cf24f04c67;

	internal uint x271ff33499468cfb;

	internal long xd8875e98e200125b;

	internal long x4ca66853eaa6dc5f;

	internal uint x3d319b452cb554cd;

	internal long x437e3b626c0fdd43;

	internal bool x81bf7528425f51e7;

	internal xd686a7cfdb7bddb2()
	{
		x2ff6d9d680555933 = xb824d4787cda57d9.xcde3a31c5a88fc93;
		x3aa285be658a6bd4 = x256aac0252732d90.x89fffa2751fdecbe;
		xf469c807ba339d90 = uint.MaxValue;
		xcb628eae42e96691 = uint.MaxValue;
		xafe684f748981f4f = uint.MaxValue;
		x933ed8cf24f04c67 = Guid.Empty;
	}

	internal xd686a7cfdb7bddb2(string name, bool isRoot, Guid clsid)
		: this()
	{
		x759aa16c2016a289 = name;
		x2ff6d9d680555933 = ((!isRoot) ? xb824d4787cda57d9.xd7ae645a9c8bbc47 : xb824d4787cda57d9.x29e7ace4c90f74cd);
		x933ed8cf24f04c67 = clsid;
		x3d319b452cb554cd = (isRoot ? uint.MaxValue : 0u);
	}

	internal xd686a7cfdb7bddb2(string name, xb824d4787cda57d9 entryType, long size)
		: this()
	{
		x759aa16c2016a289 = name;
		x2ff6d9d680555933 = entryType;
		x437e3b626c0fdd43 = size;
		x3d319b452cb554cd = uint.MaxValue;
	}

	internal xd686a7cfdb7bddb2(BinaryReader reader)
	{
		int num = (int)reader.BaseStream.Position;
		byte[] array = reader.ReadBytes(64);
		if (array.Length < 64)
		{
			return;
		}
		int num2 = reader.ReadUInt16();
		if (num2 > 64)
		{
			return;
		}
		if (num2 > 0)
		{
			if (num2 > array.Length)
			{
				throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("jfjpkgaaeghamboamgfbkgmbfgdcfgkcafbdofidmfpdgfgegeneceeflpkflecgjejgbeahbehhncohadfilcmidocjddkjccbkpbikecpkhcglbnmlccemkblmimbnhajnhaaoplgoppnoiafpiampfadafakanpabophbflob", 1792866565)));
			}
			x759aa16c2016a289 = Encoding.Unicode.GetString(array, 0, num2 - 2);
		}
		else
		{
			x759aa16c2016a289 = null;
		}
		x2ff6d9d680555933 = (xb824d4787cda57d9)reader.ReadByte();
		if (x2ff6d9d680555933 == xb824d4787cda57d9.xcde3a31c5a88fc93)
		{
			reader.BaseStream.Position = num + 128;
			return;
		}
		x3aa285be658a6bd4 = (x256aac0252732d90)reader.ReadByte();
		xf469c807ba339d90 = reader.ReadUInt32();
		xcb628eae42e96691 = reader.ReadUInt32();
		xafe684f748981f4f = reader.ReadUInt32();
		x933ed8cf24f04c67 = new Guid(reader.ReadBytes(16));
		x271ff33499468cfb = reader.ReadUInt32();
		xd8875e98e200125b = reader.ReadInt64();
		if (x0d299f323d241756.xd7d2f6dd32a72a3b(reader, 20))
		{
			x4ca66853eaa6dc5f = reader.ReadInt64();
			x3d319b452cb554cd = reader.ReadUInt32();
			x437e3b626c0fdd43 = reader.ReadUInt32();
			reader.ReadInt32();
		}
	}

	internal void x6210059f049f0d48(BinaryWriter xbdfb620b7167944b)
	{
		byte[] array = new byte[64];
		int num;
		if (x0d299f323d241756.x5959bccb67bbf051(x759aa16c2016a289))
		{
			byte[] bytes = Encoding.Unicode.GetBytes(x759aa16c2016a289);
			if (bytes.Length > 62)
			{
				throw new InvalidOperationException(string.Format(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("cookdpflnomlfkdmapkmaobnjoinonpngjgokjnoloepnjlphocaoijaeiabkmhbbnoblhfcmmmcemddbmkdpgbeilieilpeelgfkknfagegdklgjkchjkjhefaiikhiakoiejfjmjmjoidkajkkgiblmdilniplfigmddnmdienbilnmhcomhjohgapfhhpdhopngfanfmajfdbcbkbcgbcagicifpcifgdeendheeeceleiacf", 2113908366)), x759aa16c2016a289));
			}
			Array.Copy(bytes, 0, array, 0, bytes.Length);
			num = bytes.Length + 2;
		}
		else
		{
			num = 0;
		}
		xbdfb620b7167944b.Write(array);
		xbdfb620b7167944b.Write((ushort)num);
		xbdfb620b7167944b.Write((byte)x2ff6d9d680555933);
		xbdfb620b7167944b.Write((byte)x3aa285be658a6bd4);
		xbdfb620b7167944b.Write(xf469c807ba339d90);
		xbdfb620b7167944b.Write(xcb628eae42e96691);
		xbdfb620b7167944b.Write(xafe684f748981f4f);
		xbdfb620b7167944b.Write(x933ed8cf24f04c67.ToByteArray());
		xbdfb620b7167944b.Write(x271ff33499468cfb);
		xbdfb620b7167944b.Write(xd8875e98e200125b);
		xbdfb620b7167944b.Write(x4ca66853eaa6dc5f);
		xbdfb620b7167944b.Write(x3d319b452cb554cd);
		xbdfb620b7167944b.Write((uint)x437e3b626c0fdd43);
		xbdfb620b7167944b.Write(0);
	}
}
