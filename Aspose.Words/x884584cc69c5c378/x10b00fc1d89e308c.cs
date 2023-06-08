using System.IO;
using xa604c4d210ae0581;

namespace x884584cc69c5c378;

internal class x10b00fc1d89e308c : xf67718a36ff889c3
{
	internal const int xa230444f4711f2cc = 22;

	internal int x5db45988d4e40802;

	internal int x7654e18682a4d934;

	internal bool x76115adcf5870592;

	internal int x1ef9a40b80c97477;

	internal int x835e4449b464b4ff;

	internal int x8eff7dbadb88d757;

	internal static bool x492f529cee830a40;

	internal x10b00fc1d89e308c()
	{
	}

	internal x10b00fc1d89e308c(BinaryReader reader)
	{
		x5db45988d4e40802 = reader.ReadInt32();
		x7654e18682a4d934 = reader.ReadInt32();
		x76115adcf5870592 = reader.ReadInt16() != 0;
		x1ef9a40b80c97477 = reader.ReadInt32();
		x835e4449b464b4ff = reader.ReadInt32();
		x8eff7dbadb88d757 = reader.ReadInt32();
		_ = x492f529cee830a40;
	}

	private void x85313d56ab6f266e(BinaryWriter xbdfb620b7167944b)
	{
		xbdfb620b7167944b.Write(x5db45988d4e40802);
		xbdfb620b7167944b.Write(x7654e18682a4d934);
		xbdfb620b7167944b.Write((short)(x76115adcf5870592 ? 1 : 0));
		xbdfb620b7167944b.Write(x1ef9a40b80c97477);
		xbdfb620b7167944b.Write(x835e4449b464b4ff);
		xbdfb620b7167944b.Write(x8eff7dbadb88d757);
	}

	void xf67718a36ff889c3.x6210059f049f0d48(BinaryWriter xbdfb620b7167944b)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x85313d56ab6f266e
		this.x85313d56ab6f266e(xbdfb620b7167944b);
	}
}
