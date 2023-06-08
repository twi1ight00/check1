using System.IO;

namespace x0ba9768691592c95;

internal class x3ea449289926ff85
{
	internal int xea1e81378298fa81;

	internal int xf1d9b91c9700c401;

	internal x3ea449289926ff85(int id, int offset)
	{
		xea1e81378298fa81 = id;
		xf1d9b91c9700c401 = offset;
	}

	internal x3ea449289926ff85(BinaryReader reader)
	{
		xea1e81378298fa81 = reader.ReadInt32();
		xf1d9b91c9700c401 = reader.ReadInt32();
	}

	internal void x6210059f049f0d48(BinaryWriter xbdfb620b7167944b)
	{
		xbdfb620b7167944b.Write(xea1e81378298fa81);
		xbdfb620b7167944b.Write(xf1d9b91c9700c401);
	}
}
