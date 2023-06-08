using System;
using System.IO;

namespace ns22;

internal class Class936
{
	public static void smethod_0(Stream stream_0, Stream stream_1)
	{
		if (stream_0 == null)
		{
			throw new ArgumentNullException("srcStream");
		}
		if (stream_1 == null)
		{
			throw new ArgumentNullException("dstStream");
		}
		byte[] array = new byte[4096];
		while (true)
		{
			int num = stream_0.Read(array, 0, array.Length);
			if (num > 0)
			{
				stream_1.Write(array, 0, num);
				continue;
			}
			break;
		}
	}

	internal static byte[] smethod_1(Stream stream_0, bool bool_0)
	{
		int num = (int)stream_0.Length;
		byte[] array = null;
		if (num == 0)
		{
			if (stream_0.CanSeek)
			{
				stream_0.Position = 0L;
			}
			array = new byte[4096];
			MemoryStream memoryStream = new MemoryStream();
			while (true)
			{
				int num2 = stream_0.Read(array, 0, array.Length);
				if (num2 <= 0)
				{
					break;
				}
				memoryStream.Write(array, 0, num2);
			}
			return memoryStream.ToArray();
		}
		array = new byte[num];
		if (stream_0.CanSeek)
		{
			stream_0.Position = 0L;
		}
		stream_0.Read(array, 0, num);
		if (bool_0)
		{
			stream_0.Close();
		}
		return array;
	}
}
