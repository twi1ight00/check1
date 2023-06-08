using System;
using System.IO;

namespace ns16;

internal class Stream12 : Stream
{
	internal Stream11 stream11_0;

	private bool bool_0;

	public override bool CanRead
	{
		get
		{
			if (bool_0)
			{
				throw new ObjectDisposedException("ZlibStream");
			}
			return stream11_0.stream_0.CanRead;
		}
	}

	public override bool CanSeek => false;

	public override bool CanWrite
	{
		get
		{
			if (bool_0)
			{
				throw new ObjectDisposedException("ZlibStream");
			}
			return stream11_0.stream_0.CanWrite;
		}
	}

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
			if (stream11_0.enum46_0 == Stream11.Enum46.const_0)
			{
				return stream11_0.class765_0.long_1;
			}
			if (stream11_0.enum46_0 == Stream11.Enum46.const_1)
			{
				return stream11_0.class765_0.long_0;
			}
			return 0L;
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	public Stream12(Stream stream_0, Enum44 enum44_0)
		: this(stream_0, enum44_0, Enum42.const_8, bool_1: false)
	{
	}

	public Stream12(Stream stream_0, Enum44 enum44_0, Enum42 enum42_0, bool bool_1)
	{
		stream11_0 = new Stream11(stream_0, enum44_0, enum42_0, Enum45.const_0, bool_1);
	}

	protected override void Dispose(bool disposing)
	{
		try
		{
			if (!bool_0)
			{
				if (disposing && stream11_0 != null)
				{
					stream11_0.Close();
				}
				bool_0 = true;
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	public override void Flush()
	{
		if (bool_0)
		{
			throw new ObjectDisposedException("ZlibStream");
		}
		stream11_0.Flush();
	}

	public void method_0()
	{
		stream11_0.method_4();
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		if (bool_0)
		{
			throw new ObjectDisposedException("ZlibStream");
		}
		return stream11_0.Read(buffer, offset, count);
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		throw new NotSupportedException();
	}

	public override void SetLength(long value)
	{
		throw new NotSupportedException();
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		if (bool_0)
		{
			throw new ObjectDisposedException("ZlibStream");
		}
		stream11_0.Write(buffer, offset, count);
	}
}
