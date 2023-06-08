using System.IO;

namespace x1a62aaf14e3c5909;

internal class x753e51109756f7c2 : xddf6304144fd3863
{
	private x23b42b2a85a030f4 x9737526bc515045a;

	internal x23b42b2a85a030f4 xd2f68ee6f47e9dfb
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

	internal x753e51109756f7c2()
		: base(x773fe540042dad03.x5381fc3ac16f2f52, 0)
	{
	}

	protected override void DoRead(BinaryReader reader)
	{
		x9737526bc515045a = (x23b42b2a85a030f4)reader.ReadInt32();
	}

	protected override void DoWrite(BinaryWriter writer)
	{
		writer.Write((int)x9737526bc515045a);
	}
}
