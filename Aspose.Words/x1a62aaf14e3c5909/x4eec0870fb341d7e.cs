using System.IO;

namespace x1a62aaf14e3c5909;

internal class x4eec0870fb341d7e : xddf6304144fd3863
{
	private int[] x416daa5f27da7c5c;

	internal x4eec0870fb341d7e()
		: base(x773fe540042dad03.xa3ef8c286944e3ed, 0)
	{
	}

	protected override void DoRead(BinaryReader reader)
	{
		int x9834ddb0e0bd = base.x1ea60bde2b5d0d28.x9834ddb0e0bd5996;
		x416daa5f27da7c5c = new int[x9834ddb0e0bd];
		for (int i = 0; i < x9834ddb0e0bd; i++)
		{
			x416daa5f27da7c5c[i] = reader.ReadInt32();
		}
	}

	protected override void DoWrite(BinaryWriter writer)
	{
		base.x1ea60bde2b5d0d28.x9834ddb0e0bd5996 = x416daa5f27da7c5c.Length;
		for (int i = 0; i < x416daa5f27da7c5c.Length; i++)
		{
			writer.Write(x416daa5f27da7c5c[i]);
		}
	}
}
