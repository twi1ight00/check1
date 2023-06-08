using System.IO;

namespace x1a62aaf14e3c5909;

internal class x60a83a1c77a6b0d0 : xddf6304144fd3863
{
	private int x0a308ac4b6c16cbd;

	internal int xc95ed8e8690eb564
	{
		get
		{
			return x0a308ac4b6c16cbd;
		}
		set
		{
			x0a308ac4b6c16cbd = value;
		}
	}

	internal x60a83a1c77a6b0d0()
		: base(x773fe540042dad03.x1962dcc80a92cc09, 0)
	{
	}

	protected override void DoRead(BinaryReader reader)
	{
		x0a308ac4b6c16cbd = reader.ReadInt32();
	}

	protected override void DoWrite(BinaryWriter writer)
	{
		writer.Write(x0a308ac4b6c16cbd);
	}
}
