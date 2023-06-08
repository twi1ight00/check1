using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace ns16;

internal class Stream8 : Stream
{
	internal Stream11 stream11_0;

	internal Stream stream_0;

	private bool bool_0;

	public override bool CanRead
	{
		get
		{
			if (bool_0)
			{
				throw new ObjectDisposedException("DeflateStream");
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
				throw new ObjectDisposedException("DeflateStream");
			}
			return stream11_0.stream_0.CanWrite;
		}
	}

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
			throw new NotImplementedException();
		}
	}

	public Stream8(Stream stream_1, Enum44 enum44_0, bool bool_1)
		: this(stream_1, enum44_0, Enum42.const_8, bool_1)
	{
	}

	public Stream8(Stream stream_1, Enum44 enum44_0, Enum42 enum42_0, bool bool_1)
	{
		stream_0 = stream_1;
		stream11_0 = new Stream11(stream_1, enum44_0, enum42_0, Enum45.const_1, bool_1);
	}

	[SpecialName]
	public void method_0(int int_0)
	{
		if (bool_0)
		{
			throw new ObjectDisposedException("DeflateStream");
		}
		if (stream11_0.byte_0 != null)
		{
			throw new Exception5("The working buffer is already set.");
		}
		if (int_0 < 1024)
		{
			throw new Exception5($"Don't be silly. {int_0} bytes?? Use a bigger buffer, at least {1024}.");
		}
		stream11_0.int_0 = int_0;
	}

	[SpecialName]
	public void method_1(Enum43 enum43_0)
	{
		if (bool_0)
		{
			throw new ObjectDisposedException("DeflateStream");
		}
		stream11_0.enum43_0 = enum43_0;
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
			throw new ObjectDisposedException("DeflateStream");
		}
		stream11_0.Flush();
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		if (bool_0)
		{
			throw new ObjectDisposedException("DeflateStream");
		}
		return stream11_0.Read(buffer, offset, count);
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		throw new NotImplementedException();
	}

	public override void SetLength(long value)
	{
		throw new NotImplementedException();
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		if (bool_0)
		{
			throw new ObjectDisposedException("DeflateStream");
		}
		stream11_0.Write(buffer, offset, count);
	}
}
