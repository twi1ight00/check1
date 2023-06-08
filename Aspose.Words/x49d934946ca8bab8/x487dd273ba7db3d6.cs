using System.IO;
using x6c95d9cf46ff5f25;

namespace x49d934946ca8bab8;

internal class x487dd273ba7db3d6
{
	private readonly x05cddb129b0360cd x9eedea82aaf54561;

	public x487dd273ba7db3d6(MemoryStream stream)
	{
		x9eedea82aaf54561 = new x05cddb129b0360cd(stream, useMsbFirstBitOrdering: false);
	}

	public short x231ff899272d7d88()
	{
		short num = 0;
		while (x9eedea82aaf54561.xa1e7dc86736d5ffd())
		{
			num = (short)(num + 1);
		}
		if (num > 0 && x9eedea82aaf54561.xa1e7dc86736d5ffd())
		{
			num = (short)(num * -1);
		}
		return num;
	}
}
