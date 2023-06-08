using System;
using System.IO;
using x13f1efc79617a47b;

namespace xb92b7270f78a4e8d;

internal class x1ea60bde2b5d0d28
{
	internal const int xa9b7427a7de30e40 = 109;

	internal const int x6024219c8fa60263 = 76;

	private const int xaf4bef38a0d487f7 = 3;

	private const long x545048f80bdbb450 = -2226271756974174256L;

	private const int xe1aa1375e543ab39 = 16;

	internal ushort xffbf3409cec57ea0;

	internal ushort x1a8c28546e58bc1e;

	internal ushort x1084c29080e6bf1e;

	internal ushort xba12e3bec7f4e829;

	internal int xc035bc9ee6aaf576;

	internal int xa8cfe0f15be4bf6f;

	internal uint x2cd0ae7c6528d4cd;

	internal uint xd5f3925cb0108628;

	internal uint xcbd766b7a87c398a;

	internal int x882726c619a098c1;

	internal uint xa488c50953a4b64c;

	internal int xed20a3f26053569b;

	internal int xf6cc479785131f12 => x882726c619a098c1 * 512;

	internal x1ea60bde2b5d0d28()
	{
		xffbf3409cec57ea0 = 33;
		x1a8c28546e58bc1e = 3;
		x1084c29080e6bf1e = 9;
		xba12e3bec7f4e829 = 6;
		xd5f3925cb0108628 = 4096u;
	}

	internal x1ea60bde2b5d0d28(BinaryReader reader)
	{
		long num = reader.ReadInt64();
		if (num != -2226271756974174256L)
		{
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("ilcfjmjfhmagomhgihogolfhfmmhpgdiklkiilbjklijdgpjbkgknfnknkellkllgkcmgkjmbjanpjhnnjonhjfohimodidpmdkpmibakiiacipacigbognbbhecmglceccdhgjdhgaehghenfoedcff", 499733092)));
		}
		reader.ReadBytes(16);
		xffbf3409cec57ea0 = reader.ReadUInt16();
		x1a8c28546e58bc1e = reader.ReadUInt16();
		if (x1a8c28546e58bc1e > 3)
		{
			throw new NotSupportedException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("oebkpfiknfpkeggloanlofemmflmhfcnhfjnceaoafhooeooiefpidmpeddanojandbbldibddpbddgcpbncccednbldfnbeicjeebafobhfmbofpafgcbmgoadhnljhdabikaiieloippfjnpmjppdkikkkipblhpilpoplmogmionmioenholnfncobnjoijap", 2007408890)));
		}
		reader.ReadUInt16();
		x1084c29080e6bf1e = reader.ReadUInt16();
		xba12e3bec7f4e829 = reader.ReadUInt16();
		reader.ReadUInt16();
		reader.ReadUInt32();
		xc035bc9ee6aaf576 = reader.ReadInt32();
		xa8cfe0f15be4bf6f = reader.ReadInt32();
		x2cd0ae7c6528d4cd = reader.ReadUInt32();
		reader.ReadUInt32();
		xd5f3925cb0108628 = reader.ReadUInt32();
		xcbd766b7a87c398a = reader.ReadUInt32();
		x882726c619a098c1 = reader.ReadInt32();
		xa488c50953a4b64c = reader.ReadUInt32();
		xed20a3f26053569b = reader.ReadInt32();
	}

	internal void x6210059f049f0d48(BinaryWriter xbdfb620b7167944b)
	{
		xbdfb620b7167944b.Write(-2226271756974174256L);
		xbdfb620b7167944b.Write(new byte[16]);
		xbdfb620b7167944b.Write(xffbf3409cec57ea0);
		xbdfb620b7167944b.Write(x1a8c28546e58bc1e);
		xbdfb620b7167944b.Write((ushort)65534);
		xbdfb620b7167944b.Write(x1084c29080e6bf1e);
		xbdfb620b7167944b.Write(xba12e3bec7f4e829);
		xbdfb620b7167944b.Write((short)0);
		xbdfb620b7167944b.Write(0);
		xbdfb620b7167944b.Write(xc035bc9ee6aaf576);
		xbdfb620b7167944b.Write(xa8cfe0f15be4bf6f);
		xbdfb620b7167944b.Write(x2cd0ae7c6528d4cd);
		xbdfb620b7167944b.Write(0);
		xbdfb620b7167944b.Write(xd5f3925cb0108628);
		xbdfb620b7167944b.Write(xcbd766b7a87c398a);
		xbdfb620b7167944b.Write(x882726c619a098c1);
		xbdfb620b7167944b.Write(xa488c50953a4b64c);
		xbdfb620b7167944b.Write(xed20a3f26053569b);
	}

	internal bool x981a3cbd5ad60807(long xf9a442f2008665fe)
	{
		return xf9a442f2008665fe >= xd5f3925cb0108628;
	}
}
