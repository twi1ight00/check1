using System;
using System.IO;

namespace ns82;

internal class Class7330 : Class7328
{
	public static readonly int int_6 = 1024;

	public static readonly int int_7 = 1024;

	protected Class7330()
	{
	}

	public Class7330(TextReader reader)
		: this(reader, int_7, int_6)
	{
	}

	public Class7330(TextReader reader, int size)
		: this(reader, size, int_6)
	{
	}

	public Class7330(TextReader reader, int size, int readChunkSize)
	{
		vmethod_0(reader, size, readChunkSize);
	}

	public virtual void vmethod_0(TextReader reader, int size, int readChunkSize)
	{
		if (reader == null)
		{
			return;
		}
		if (size <= 0)
		{
			size = int_7;
		}
		if (readChunkSize <= 0)
		{
			readChunkSize = int_6;
		}
		try
		{
			char_0 = new char[size];
			int num = 0;
			int num2 = 0;
			do
			{
				if (num2 + readChunkSize > char_0.Length)
				{
					char[] destinationArray = new char[char_0.Length * 2];
					Array.Copy(char_0, 0, destinationArray, 0, char_0.Length);
					char_0 = destinationArray;
				}
				num = reader.Read(char_0, num2, readChunkSize);
				num2 += num;
			}
			while (num != 0);
			int_0 = num2;
		}
		finally
		{
			reader.Close();
		}
	}
}
