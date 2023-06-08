using System;
using System.IO;
using Aspose;

namespace x4f4df92b75ba3b67;

internal class x8fbf0a5e230a8cae : Stream
{
	protected readonly Stream x6169576fb3c218d3;

	public override bool CanRead => false;

	public override bool CanSeek => false;

	public override bool CanWrite => true;

	public override long Length => x6169576fb3c218d3.Length;

	public override long Position
	{
		get
		{
			return x6169576fb3c218d3.Position;
		}
		set
		{
			throw new InvalidOperationException();
		}
	}

	internal x8fbf0a5e230a8cae(Stream outputStream)
	{
		x6169576fb3c218d3 = outputStream;
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

	[JavaThrows(true)]
	public override void WriteByte(byte value)
	{
		throw new InvalidOperationException();
	}

	public override void Write(byte[] srcBuffer, int srcOffset, int srcCount)
	{
		x6169576fb3c218d3.Write(srcBuffer, srcOffset, srcCount);
	}
}
