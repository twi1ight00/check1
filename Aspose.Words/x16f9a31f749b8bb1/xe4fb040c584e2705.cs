using System.IO;
using xa604c4d210ae0581;

namespace x16f9a31f749b8bb1;

internal class xe4fb040c584e2705 : xc9072e4c3fa520ad
{
	private const int x9732033903ef58a4 = 4;

	internal xe4fb040c584e2705()
		: base(4)
	{
	}

	internal int xfbe217fe06e4abb5(int xc0c4c459c6ccbd00)
	{
		return (int)xe84e6ff66aac2a0e(xc0c4c459c6ccbd00) * 512;
	}

	protected override object DoReadItem(BinaryReader reader)
	{
		return reader.ReadInt32();
	}
}
