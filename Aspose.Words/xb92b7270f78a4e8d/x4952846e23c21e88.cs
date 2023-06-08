using System.IO;

namespace xb92b7270f78a4e8d;

internal class x4952846e23c21e88
{
	internal const int x580d212c8fa631ce = 512;

	internal const int x5152570431cb705c = 64;

	internal const int x6ba3a6a074ca1119 = 4;

	internal const int xe6b6010005ef1148 = 128;

	internal const int x14c9b53fcf911347 = 127;

	internal static long x29cc5da3d9d1b58a(uint xb933bead4255f31b, bool x0a996d99793b1739)
	{
		if (x0a996d99793b1739)
		{
			return (xb933bead4255f31b + 1) * 512;
		}
		return xb933bead4255f31b * 64;
	}

	internal static uint x2ef840043f42e207(long x374ea4fe62468d0f, bool x0a996d99793b1739)
	{
		if (x0a996d99793b1739)
		{
			return (uint)(x374ea4fe62468d0f / 512 - 1);
		}
		return (uint)(x374ea4fe62468d0f / 64);
	}

	internal static void xdd43f3d19173b660(BinaryWriter xbdfb620b7167944b)
	{
		while (xbdfb620b7167944b.BaseStream.Position % 512 != 0)
		{
			xbdfb620b7167944b.Write(uint.MaxValue);
		}
	}
}
