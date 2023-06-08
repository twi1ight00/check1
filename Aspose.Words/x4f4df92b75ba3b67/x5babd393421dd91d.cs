using System.IO;

namespace x4f4df92b75ba3b67;

internal class x5babd393421dd91d
{
	private readonly byte[] x824f14e92de69876;

	private readonly int x14e90011f7c5c019;

	internal x5babd393421dd91d(byte[] key, int keySize)
	{
		x824f14e92de69876 = key;
		x14e90011f7c5c019 = keySize;
	}

	internal byte[] x246b032720dd4c0d(byte[] xe7ebe10fa44d8d49)
	{
		using MemoryStream memoryStream = new MemoryStream();
		xdb975c70fd3d8ff7 xdb975c70fd3d8ff8 = x228ae9311abe60ed(memoryStream);
		xdb975c70fd3d8ff8.Write(xe7ebe10fa44d8d49, 0, xe7ebe10fa44d8d49.Length);
		return memoryStream.ToArray();
	}

	internal xdb975c70fd3d8ff7 x228ae9311abe60ed(Stream x0ecec17af75ebd13)
	{
		return new xdb975c70fd3d8ff7(x0ecec17af75ebd13, x824f14e92de69876, 0, x14e90011f7c5c019);
	}
}
