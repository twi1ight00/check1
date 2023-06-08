using System.IO;

namespace x1a62aaf14e3c5909;

internal class xe98b7313e69b63e3 : xddf6304144fd3863
{
	internal int x90b1cee5d7d50332;

	internal int xf3f83627f93fe18e;

	internal xe98b7313e69b63e3()
		: base(x773fe540042dad03.xbc9fe6190e5749fa, 0)
	{
	}

	protected override void DoRead(BinaryReader reader)
	{
		x90b1cee5d7d50332 = reader.ReadInt32();
		xf3f83627f93fe18e = reader.ReadInt32();
	}

	protected override void DoWrite(BinaryWriter writer)
	{
		writer.Write(x90b1cee5d7d50332);
		writer.Write(xf3f83627f93fe18e);
	}
}
