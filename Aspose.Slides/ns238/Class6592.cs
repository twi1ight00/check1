using System.IO;
using ns218;
using ns234;

namespace ns238;

internal static class Class6592
{
	private static byte[] byte_0;

	private static object object_0 = new object();

	private static byte[] byte_1;

	private static object object_1 = new object();

	private static byte[] byte_2;

	private static object object_2 = new object();

	public static byte[] ViewerUi
	{
		get
		{
			if (byte_0 == null)
			{
				lock (object_0)
				{
					if (byte_0 == null)
					{
						using Stream stream = Class6166.smethod_0("Aspose.Resources.Viewer.swf");
						using MemoryStream memoryStream = new MemoryStream();
						using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
						byte[] buffer = new byte[8];
						stream.Read(buffer, 0, 8);
						binaryWriter.Write(buffer);
						byte[] srcBytes = Class5964.smethod_8(stream, (int)(stream.Length - 8L));
						byte[] buffer2 = Class6171.smethod_0(srcBytes, 0, Enum794.const_1);
						binaryWriter.Write(buffer2);
						binaryWriter.BaseStream.Position = 38L;
						byte_0 = Class5964.smethod_8(memoryStream, (int)(memoryStream.Length - 42L));
					}
				}
			}
			return byte_0;
		}
	}

	public static byte[] PageAbcData
	{
		get
		{
			if (byte_1 == null)
			{
				lock (object_1)
				{
					if (byte_1 == null)
					{
						using Stream srcStream = Class6166.smethod_0("Aspose.Resources.PageAbcData.bin");
						byte_1 = Class5964.smethod_11(srcStream);
					}
				}
			}
			return byte_1;
		}
	}

	public static byte[] DocumentDescriptorAbcData
	{
		get
		{
			if (byte_2 == null)
			{
				lock (object_2)
				{
					if (byte_2 == null)
					{
						using Stream srcStream = Class6166.smethod_0("Aspose.Resources.DocumentDescriptorAbcData.bin");
						byte_2 = Class5964.smethod_11(srcStream);
					}
				}
			}
			return byte_2;
		}
	}
}
