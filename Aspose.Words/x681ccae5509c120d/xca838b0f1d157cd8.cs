using System;
using System.IO;
using xa604c4d210ae0581;

namespace x681ccae5509c120d;

internal class xca838b0f1d157cd8 : xf67718a36ff889c3
{
	internal const int xa230444f4711f2cc = 30;

	internal const int x90b0f3d3450e1a68 = 18;

	private const int xf97064f6a477fcd2 = 20;

	internal string x660adf533ba4edef;

	internal int x57653a46aad8df6a;

	internal int x745c3a5e8101c8d9;

	internal DateTime x242851e6278ed355;

	private int xd3c04920a4e99e88;

	private int xf311c633b56e6f6c;

	private int xdda6cfd28220b3fb;

	internal xca838b0f1d157cd8()
	{
	}

	internal xca838b0f1d157cd8(BinaryReader reader)
	{
		x660adf533ba4edef = x93b05c1ad709a695.x9c35bca780965b65(reader, 20);
		x57653a46aad8df6a = reader.ReadInt16();
		reader.ReadInt16();
		reader.ReadInt16();
		x745c3a5e8101c8d9 = reader.ReadInt32();
	}

	public void x6210059f049f0d48(BinaryWriter xbdfb620b7167944b)
	{
		x93b05c1ad709a695.xb8560c54099c0da8(x660adf533ba4edef, xbdfb620b7167944b, 20);
		xbdfb620b7167944b.Write((short)x57653a46aad8df6a);
		xbdfb620b7167944b.Write((short)0);
		xbdfb620b7167944b.Write((short)0);
		xbdfb620b7167944b.Write(x745c3a5e8101c8d9);
	}

	internal void x5f571ea8c74d391b(BinaryReader xe134235b3526fa75)
	{
		x242851e6278ed355 = xed28c1e5772a17ea.x06b0e25aa6ad68a9(xe134235b3526fa75);
		xe134235b3526fa75.ReadInt16();
		xd3c04920a4e99e88 = xe134235b3526fa75.ReadInt32();
		xf311c633b56e6f6c = xe134235b3526fa75.ReadInt32();
		xdda6cfd28220b3fb = xe134235b3526fa75.ReadInt32();
	}

	public void xbab4a8354252fa3b(BinaryWriter xbdfb620b7167944b)
	{
		xed28c1e5772a17ea.x6210059f049f0d48(x242851e6278ed355, xbdfb620b7167944b);
		xbdfb620b7167944b.Write((short)0);
		xbdfb620b7167944b.Write(0);
		xbdfb620b7167944b.Write(0);
		xbdfb620b7167944b.Write(0);
	}
}
