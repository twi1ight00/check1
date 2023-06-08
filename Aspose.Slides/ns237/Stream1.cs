using System;
using System.IO;
using ns221;

namespace ns237;

internal class Stream1 : Stream
{
	protected readonly Stream stream_0;

	public override bool CanRead => false;

	public override bool CanSeek => false;

	public override bool CanWrite => true;

	public override long Length => stream_0.Length;

	public override long Position
	{
		get
		{
			return stream_0.Position;
		}
		set
		{
			throw new InvalidOperationException();
		}
	}

	internal Stream1(Stream outputStream)
	{
		stream_0 = outputStream;
	}

	public override void Flush()
	{
	}

	public override void Close()
	{
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		throw new InvalidOperationException();
	}

	public override void SetLength(long value)
	{
		throw new InvalidOperationException();
	}

	public override int ReadByte()
	{
		throw new InvalidOperationException();
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		throw new InvalidOperationException();
	}

	[Attribute7(true)]
	public override void WriteByte(byte value)
	{
		throw new InvalidOperationException();
	}

	public override void Write(byte[] srcBuffer, int srcOffset, int srcCount)
	{
		stream_0.Write(srcBuffer, srcOffset, srcCount);
	}
}
