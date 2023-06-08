using System.IO;
using x1a62aaf14e3c5909;

namespace xf989f31a236ff98c;

internal class xef515ac4d57187c2
{
	private xef515ac4d57187c2()
	{
	}

	internal static byte[] xed1b33c4a41501bf(string xa490ad5ef1682691)
	{
		BinaryWriter binaryWriter = new BinaryWriter(new MemoryStream());
		binaryWriter.Write((byte)8);
		x9bd10249890baaef x9bd10249890baaef = new x9bd10249890baaef(0, null, xa490ad5ef1682691, null);
		x9bd10249890baaef.xc26afd5362f5c1ec(binaryWriter);
		return ((MemoryStream)binaryWriter.BaseStream).ToArray();
	}
}
