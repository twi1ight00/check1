using System.IO;

namespace ns4;

internal class Class1161
{
	public static Stream smethod_0(Stream stream)
	{
		if (stream.CanSeek)
		{
			return stream;
		}
		byte[] array = new byte[4096];
		MemoryStream memoryStream = new MemoryStream(0);
		while (true)
		{
			int num = stream.Read(array, 0, array.Length);
			if (num == 0)
			{
				break;
			}
			memoryStream.Write(array, 0, num);
		}
		memoryStream.Seek(0L, SeekOrigin.Begin);
		return memoryStream;
	}

	private Class1161()
	{
	}
}
