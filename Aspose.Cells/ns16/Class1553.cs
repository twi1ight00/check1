using System.IO;
using Aspose.Cells;

namespace ns16;

internal class Class1553
{
	internal MemoryStream memoryStream_0;

	internal Class746 class746_0;

	internal void method_0(Stream stream_0)
	{
		long length = stream_0.Length;
		if (length > int.MaxValue)
		{
			throw new CellsException(ExceptionType.Limitation, "File Size is too large to process...");
		}
		int capacity = (int)length;
		memoryStream_0 = new MemoryStream(capacity);
		byte[] array = new byte[1024];
		int num;
		do
		{
			num = stream_0.Read(array, 0, array.Length);
			memoryStream_0.Write(array, 0, num);
		}
		while (num > 0);
		memoryStream_0.Position = 0L;
		class746_0 = Class746.Read(memoryStream_0);
	}

	internal void Close()
	{
		memoryStream_0 = null;
	}

	internal void method_1()
	{
	}
}
