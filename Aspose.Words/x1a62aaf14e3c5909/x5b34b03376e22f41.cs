using System.IO;

namespace x1a62aaf14e3c5909;

internal class x5b34b03376e22f41 : xddf6304144fd3863
{
	internal int x90b1cee5d7d50332;

	internal int xca04f1d9a3c2b835;

	internal x5b34b03376e22f41()
		: base(x773fe540042dad03.x4d4c1c7ea2b00c54, 0)
	{
	}

	protected override void DoRead(BinaryReader reader)
	{
		x90b1cee5d7d50332 = reader.ReadInt32();
		xca04f1d9a3c2b835 = reader.ReadInt32();
	}

	protected override void DoWrite(BinaryWriter writer)
	{
		writer.Write(x90b1cee5d7d50332);
		writer.Write(xca04f1d9a3c2b835);
	}
}
