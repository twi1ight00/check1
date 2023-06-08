using System;
using System.IO;

namespace ns276;

internal class Stream8 : Stream, IDisposable
{
	internal Stream13 stream13_0;

	private bool bool_0;

	public virtual Enum898 FlushMode
	{
		get
		{
			return stream13_0.enum898_0;
		}
		set
		{
			if (bool_0)
			{
				throw new ObjectDisposedException("DeflateStream");
			}
			stream13_0.enum898_0 = value;
		}
	}

	public int BufferSize
	{
		get
		{
			return stream13_0.int_0;
		}
		set
		{
			if (bool_0)
			{
				throw new ObjectDisposedException("DeflateStream");
			}
			if (stream13_0.byte_0 != null)
			{
				throw new Exception67("The working buffer is already set.");
			}
			if (value < 128)
			{
				throw new Exception67($"Don't be silly. {value} bytes?? Use a bigger buffer.");
			}
			stream13_0.int_0 = value;
		}
	}

	public Enum915 Strategy
	{
		get
		{
			return stream13_0.enum915_0;
		}
		set
		{
			if (bool_0)
			{
				throw new ObjectDisposedException("DeflateStream");
			}
			stream13_0.enum915_0 = value;
		}
	}

	public virtual long TotalIn => stream13_0.class6756_0.long_0;

	public virtual long TotalOut => stream13_0.class6756_0.long_1;

	public override bool CanRead
	{
		get
		{
			if (bool_0)
			{
				throw new ObjectDisposedException("DeflateStream");
			}
			return stream13_0.stream_0.CanRead;
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
			return stream13_0.stream_0.CanWrite;
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
			if (stream13_0.enum918_0 == Stream13.Enum918.const_0)
			{
				return stream13_0.class6756_0.long_1;
			}
			if (stream13_0.enum918_0 == Stream13.Enum918.const_1)
			{
				return stream13_0.class6756_0.long_0;
			}
			return 0L;
		}
		set
		{
			throw new NotImplementedException();
		}
	}

	public Stream8(Stream stream, Enum916 mode)
		: this(stream, mode, Enum914.const_8, leaveOpen: false)
	{
	}

	public Stream8(Stream stream, Enum916 mode, Enum914 level)
		: this(stream, mode, level, leaveOpen: false)
	{
	}

	public Stream8(Stream stream, Enum916 mode, bool leaveOpen)
		: this(stream, mode, Enum914.const_8, leaveOpen)
	{
	}

	public Stream8(Stream stream, Enum916 mode, Enum914 level, bool leaveOpen)
	{
		stream13_0 = new Stream13(stream, mode, level, Enum917.const_1, leaveOpen);
	}

	public override void Close()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected new virtual void Dispose(bool disposing)
	{
		if (!bool_0)
		{
			if (disposing && stream13_0 != null)
			{
				stream13_0.Close();
			}
			bool_0 = true;
		}
	}

	public override void Flush()
	{
		if (bool_0)
		{
			throw new ObjectDisposedException("DeflateStream");
		}
		stream13_0.Flush();
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		if (bool_0)
		{
			throw new ObjectDisposedException("DeflateStream");
		}
		return stream13_0.Read(buffer, offset, count);
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
		stream13_0.Write(buffer, offset, count);
	}

	public static byte[] smethod_0(string s)
	{
		return Stream13.smethod_0(s, typeof(Stream8));
	}

	public static byte[] smethod_1(byte[] b)
	{
		return Stream13.smethod_2(b, typeof(Stream8));
	}

	public static string smethod_2(byte[] compressed)
	{
		return Stream13.smethod_1(compressed, typeof(Stream8));
	}

	public static byte[] smethod_3(byte[] compressed)
	{
		return Stream13.smethod_3(compressed, typeof(Stream8));
	}

	void IDisposable.Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}
}
