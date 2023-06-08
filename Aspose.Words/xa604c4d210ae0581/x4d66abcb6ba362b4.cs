using System.IO;
using System.Reflection;

namespace xa604c4d210ae0581;

[DefaultMember("Item")]
internal class x4d66abcb6ba362b4 : xc9072e4c3fa520ad
{
	private BinaryReader xc473da6c14318d1e;

	internal static bool x492f529cee830a40;

	internal xb7b1bf2d89bd7ff4 xe6d4b1b411ed94b5 => (xb7b1bf2d89bd7ff4)xe84e6ff66aac2a0e(xc0c4c459c6ccbd00);

	internal x4d66abcb6ba362b4()
		: base(12)
	{
	}

	internal x4d66abcb6ba362b4(x8aeace2bf92692ab fib, BinaryReader docStreamReader, BinaryReader tableStreamReader)
		: this()
	{
		_ = x492f529cee830a40;
		xc473da6c14318d1e = docStreamReader;
		x06b0e25aa6ad68a9(tableStreamReader, fib.x955a03f821588c52.x55ca9798f02b1f37);
	}

	protected override object DoReadItem(BinaryReader reader)
	{
		xb7b1bf2d89bd7ff4 xb7b1bf2d89bd7ff5 = new xb7b1bf2d89bd7ff4(reader);
		if (xb7b1bf2d89bd7ff5.x7d0bd15adbf82de2 != uint.MaxValue)
		{
			xc473da6c14318d1e.BaseStream.Seek(xb7b1bf2d89bd7ff5.x7d0bd15adbf82de2, SeekOrigin.Begin);
			xb7b1bf2d89bd7ff5.x34e183d0e3285c7e = new x735141fc00f56ce0(xc473da6c14318d1e);
		}
		return xb7b1bf2d89bd7ff5;
	}

	internal void x105c8f2ef9d7db1b(BinaryWriter x4a600b88481f153e)
	{
		for (int i = 0; i < base.x23719734cf1f138c; i++)
		{
			xb7b1bf2d89bd7ff4 xb7b1bf2d89bd7ff5 = this.get_xe6d4b1b411ed94b5(i);
			xb7b1bf2d89bd7ff5.x7a940f2d4e5b2394 = uint.MaxValue;
			if (xb7b1bf2d89bd7ff5.x34e183d0e3285c7e.x6b73aa01aa019d3a.Length > 0)
			{
				xb7b1bf2d89bd7ff5.x7d0bd15adbf82de2 = (uint)x4a600b88481f153e.BaseStream.Position;
				xb7b1bf2d89bd7ff5.x34e183d0e3285c7e.x6210059f049f0d48(x4a600b88481f153e);
			}
			else
			{
				xb7b1bf2d89bd7ff5.x7d0bd15adbf82de2 = uint.MaxValue;
			}
		}
	}
}
