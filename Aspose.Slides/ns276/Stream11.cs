using System;
using System.IO;

namespace ns276;

internal class Stream11 : Stream
{
	private Class6750 class6750_0;

	private Stream stream_0;

	private Enum913 enum913_0;

	public override bool CanRead => enum913_0 == Enum913.const_1;

	public override bool CanSeek => false;

	public override bool CanWrite => enum913_0 == Enum913.const_0;

	public override long Length
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	public override long Position
	{
		get
		{
			throw new NotImplementedException();
		}
		set
		{
			throw new NotImplementedException();
		}
	}

	public Stream11(Stream s, Class6750 cipher, Enum913 mode)
	{
		class6750_0 = cipher;
		stream_0 = s;
		enum913_0 = mode;
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		if (enum913_0 == Enum913.const_0)
		{
			throw new NotImplementedException();
		}
		byte[] array = new byte[count];
		int num = stream_0.Read(array, 0, count);
		byte[] array2 = class6750_0.method_0(array, num);
		for (int i = 0; i < num; i++)
		{
			buffer[offset + i] = array2[i];
		}
		return num;
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		if (enum913_0 == Enum913.const_1)
		{
			throw new NotImplementedException();
		}
		if (count == 0)
		{
			return;
		}
		byte[] array;
		if (offset != 0)
		{
			array = new byte[count];
			for (int i = 0; i < count; i++)
			{
				array[i] = buffer[offset + i];
			}
		}
		else
		{
			array = buffer;
		}
		byte[] array2 = class6750_0.method_1(array, count);
		stream_0.Write(array2, 0, array2.Length);
	}

	public override void Flush()
	{
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		throw new NotImplementedException();
	}

	public override void SetLength(long value)
	{
		throw new NotImplementedException();
	}
}
