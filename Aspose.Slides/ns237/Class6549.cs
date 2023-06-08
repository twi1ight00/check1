using System.IO;

namespace ns237;

internal class Class6549
{
	private readonly byte[] byte_0;

	private readonly int int_0;

	internal Class6549(byte[] key, int keySize)
	{
		byte_0 = key;
		int_0 = keySize;
	}

	internal byte[] Encrypt(byte[] b)
	{
		using MemoryStream memoryStream = new MemoryStream();
		Stream2 stream = method_0(memoryStream);
		stream.Write(b, 0, b.Length);
		return memoryStream.ToArray();
	}

	internal Stream2 method_0(Stream outStream)
	{
		return new Stream2(outStream, byte_0, 0, int_0);
	}
}
