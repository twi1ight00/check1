using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace ns16;

internal class Stream1 : Stream, IDisposable
{
	private static readonly long long_0 = -99L;

	internal Stream stream_0;

	private Class741 class741_0;

	private long long_1 = -99L;

	private bool bool_0;

	public override bool CanRead => stream_0.CanRead;

	public override bool CanSeek => false;

	public override bool CanWrite => stream_0.CanWrite;

	public override long Length
	{
		get
		{
			if (long_1 == long_0)
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
			return class741_0.method_0();
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	public Stream1(Stream stream_1)
		: this(bool_1: true, long_0, stream_1, null)
	{
	}

	public Stream1(Stream stream_1, bool bool_1)
		: this(bool_1, long_0, stream_1, null)
	{
	}

	public Stream1(Stream stream_1, long long_2)
		: this(bool_1: true, long_2, stream_1, null)
	{
		if (long_2 < 0)
		{
			throw new ArgumentException("length");
		}
	}

	private Stream1(bool bool_1, long long_2, Stream stream_1, Class741 class741_1)
	{
		stream_0 = stream_1;
		class741_0 = class741_1 ?? new Class741();
		long_1 = long_2;
		bool_0 = bool_1;
	}

	[SpecialName]
	public long method_0()
	{
		return class741_0.method_0();
	}

	[SpecialName]
	public int method_1()
	{
		return class741_0.method_1();
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		int count2 = count;
		if (long_1 != long_0)
		{
			if (class741_0.method_0() >= long_1)
			{
				return 0;
			}
			long num = long_1 - class741_0.method_0();
			if (num < count)
			{
				count2 = (int)num;
			}
		}
		return stream_0.Read(buffer, offset, count2);
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		if (count > 0)
		{
			class741_0.method_6(buffer, offset, count);
		}
		stream_0.Write(buffer, offset, count);
	}

	public override void Flush()
	{
		stream_0.Flush();
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		throw new NotSupportedException();
	}

	public override void SetLength(long value)
	{
		throw new NotSupportedException();
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
