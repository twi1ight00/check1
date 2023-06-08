using System.IO;

namespace ns18;

internal abstract class Stream14 : Stream
{
	protected Stream stream_0;

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
			stream_0.Position = value;
		}
	}

	protected Stream14(Stream stream_1)
	{
		stream_0 = stream_1;
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

	public override int Read(byte[] buffer, int offset, int count)
	{
		return stream_0.Read(buffer, offset, count);
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		stream_0.Write(buffer, offset, count);
	}
}
