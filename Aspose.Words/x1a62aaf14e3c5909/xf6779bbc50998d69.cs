using System.IO;

namespace x1a62aaf14e3c5909;

internal class xf6779bbc50998d69 : xddf6304144fd3863
{
	private byte[] x73f065a6b420cfe1;

	internal byte[] x6b73aa01aa019d3a
	{
		get
		{
			return x73f065a6b420cfe1;
		}
		set
		{
			x73f065a6b420cfe1 = value;
		}
	}

	protected override void DoRead(BinaryReader reader)
	{
		x73f065a6b420cfe1 = reader.ReadBytes(base.x1ea60bde2b5d0d28.x1be93eed8950d961);
	}

	protected override void DoWrite(BinaryWriter writer)
	{
		writer.Write(x73f065a6b420cfe1);
	}
}
