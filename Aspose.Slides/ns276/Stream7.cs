using System;
using System.IO;

namespace ns276;

internal class Stream7 : Stream, IDisposable
{
	private const long long_0 = -99L;

	private Stream stream_0;

	private Class6740 class6740_0;

	private long long_1 = -99L;

	private bool bool_0;

	public long TotalBytesSlurped => class6740_0.TotalBytesRead;

	public int Crc => class6740_0.Crc32Result;

	public bool LeaveOpen
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public override bool CanRead => stream_0.CanRead;

	public override bool CanSeek => stream_0.CanSeek;

	public override bool CanWrite => stream_0.CanWrite;

	public override long Length
	{
		get
		{
			if (long_1 == -99L)
			{
				return stream_0.Length;
			}
			return long_1;
		}
	}

	public override long Position
	{
		get
		{
			return class6740_0.TotalBytesRead;
		}
		set
		{
			throw new NotImplementedException();
		}
	}

	public Stream7(Stream stream)
		: this(leaveOpen: true, -99L, stream)
	{
	}

	public Stream7(Stream stream, bool leaveOpen)
		: this(leaveOpen, -99L, stream)
	{
	}

	public Stream7(Stream stream, long length)
		: this(leaveOpen: true, length, stream)
	{
		if (length < 0L)
		{
			throw new ArgumentException("length");
		}
	}

	public Stream7(Stream stream, long length, bool leaveOpen)
		: this(leaveOpen, length, stream)
	{
		if (length < 0L)
		{
			throw new ArgumentException("length");
		}
	}

	private Stream7(bool leaveOpen, long length, Stream stream)
	{
		stream_0 = stream;
		class6740_0 = new Class6740();
		long_1 = length;
		bool_0 = leaveOpen;
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		int count2 = count;
		if (long_1 != -99L)
		{
			if (class6740_0.TotalBytesRead >= long_1)
			{
				return 0;
			}
			long num = long_1 - class6740_0.TotalBytesRead;
			if (num < count)
			{
				count2 = (int)num;
			}
		}
		int num2 = stream_0.Read(buffer, offset, count2);
		if (num2 > 0)
		{
			class6740_0.method_3(buffer, offset, num2);
		}
		return num2;
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		if (count > 0)
		{
			class6740_0.method_3(buffer, offset, count);
		}
		stream_0.Write(buffer, offset, count);
	}

	public override void Flush()
	{
		stream_0.Flush();
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		throw new NotImplementedException();
	}

	public override void SetLength(long value)
	{
		throw new NotImplementedException();
	}

	void IDisposable.Dispose()
	{
		Close();
	}

	public override void Close()
	{
		base.Close();
		if (!bool_0)
		{
			stream_0.Close();
		}
	}
}
