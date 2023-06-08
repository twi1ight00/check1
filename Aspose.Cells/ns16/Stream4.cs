using System;
using System.IO;

namespace ns16;

internal class Stream4 : Stream
{
	private Class743 class743_0;

	private Stream stream_0;

	private Enum27 enum27_0;

	public override bool CanRead => enum27_0 == Enum27.const_1;

	public override bool CanSeek => false;

	public override bool CanWrite => enum27_0 == Enum27.const_0;

	public override long Length
	{
		get
		{
			throw new NotSupportedException();
		}
	}

	public override long Position
	{
		get
		{
			throw new NotSupportedException();
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	public Stream4(Stream stream_1, Class743 class743_1, Enum27 enum27_1)
	{
		class743_0 = class743_1;
		stream_0 = stream_1;
		enum27_0 = enum27_1;
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		if (enum27_0 == Enum27.const_0)
		{
			throw new NotSupportedException("This stream does not encrypt via Read()");
		}
		if (buffer == null)
		{
			throw new ArgumentNullException("buffer");
		}
		byte[] array = new byte[count];
		int num = stream_0.Read(array, 0, count);
		byte[] array2 = class743_0.method_1(array, num);
		for (int i = 0; i < num; i++)
		{
			buffer[offset + i] = array2[i];
		}
		return num;
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		if (enum27_0 == Enum27.const_1)
		{
			throw new NotSupportedException("This stream does not Decrypt via Write()");
		}
		if (buffer == null)
		{
			throw new ArgumentNullException("buffer");
		}
		if (count == 0)
		{
			return;
		}
		byte[] array = null;
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
		byte[] array2 = class743_0.method_2(array, count);
		stream_0.Write(array2, 0, array2.Length);
	}

	public override void Flush()
	{
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		throw new NotSupportedException();
	}

	public override void SetLength(long value)
	{
		throw new NotSupportedException();
	}
}
