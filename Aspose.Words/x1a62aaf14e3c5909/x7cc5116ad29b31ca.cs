using System.IO;

namespace x1a62aaf14e3c5909;

internal class x7cc5116ad29b31ca : xddf6304144fd3863
{
	private int x9737526bc515045a;

	internal int x3a89c964078835a5
	{
		get
		{
			return x9737526bc515045a;
		}
		set
		{
			x9737526bc515045a = value;
		}
	}

	internal x7cc5116ad29b31ca()
		: base(x773fe540042dad03.xbdcae400829f58c2, 0)
	{
	}

	protected override void DoRead(BinaryReader reader)
	{
		x9737526bc515045a = reader.ReadInt32();
	}

	protected override void DoWrite(BinaryWriter writer)
	{
		writer.Write(x9737526bc515045a);
	}
}
