using System;
using System.IO;

namespace ns276;

internal class Stream10 : Stream
{
	private Stream stream_0;

	private long long_0;

	private long long_1;

	public long BytesWritten => long_0;

	public override bool CanRead => stream_0.CanRead;

	public override bool CanSeek => stream_0.CanSeek;

	public override bool CanWrite => stream_0.CanWrite;

	public override long Length => stream_0.Length;

	public override long Position
	{
		get
		{
			return stream_0.Position;
		}
		set
		{
			stream_0.Seek(value, SeekOrigin.Begin);
		}
	}

	public Stream10(Stream s)
	{
		stream_0 = s;
	}

	public void method_0(long delta)
	{
		long_0 -= delta;
		if (long_0 < 0L)
		{
			throw new InvalidOperationException();
		}
		if (stream_0 is Stream10)
		{
			((Stream10)stream_0).method_0(delta);
		}
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		int num = stream_0.Read(buffer, offset, count);
		long_1 += num;
		return num;
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		stream_0.Write(buffer, offset, count);
		long_0 += count;
	}

	public override void Flush()
	{
		stream_0.Flush();
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		return stream_0.Seek(offset, origin);
	}

	public override void SetLength(long value)
	{
		stream_0.SetLength(value);
	}
}
