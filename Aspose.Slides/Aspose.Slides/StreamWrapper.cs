using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Aspose.Slides;

[Guid("E6D327AD-ACDB-4F44-8682-350A2A0A93A4")]
[ComVisible(true)]
[ClassInterface(ClassInterfaceType.None)]
public class StreamWrapper : IDisposable, IStreamWrapper
{
	private bool bool_0;

	private readonly Stream stream_0;

	public Stream Stream => stream_0;

	public bool CanRead => stream_0.CanRead;

	public bool CanSeek => stream_0.CanSeek;

	public bool CanWrite => stream_0.CanWrite;

	public long Length => stream_0.Length;

	public long Position => stream_0.Position;

	public IDisposable AsIDisposable => this;

	public void Close()
	{
		stream_0.Close();
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	public void Flush()
	{
		stream_0.Flush();
	}

	public void Read(byte[] buffer, int offset, int count)
	{
		stream_0.Read(buffer, offset, count);
	}

	public int ReadByte()
	{
		return stream_0.ReadByte();
	}

	public long Seek(long offset, SeekOrigin origin)
	{
		return stream_0.Seek(offset, origin);
	}

	public void Write(byte[] buffer, int offset, int count)
	{
		stream_0.Write(buffer, offset, count);
	}

	public void WriteByte(byte value)
	{
		stream_0.WriteByte(value);
	}

	internal StreamWrapper(Stream stream)
	{
		if (stream == null)
		{
			throw new ArgumentNullException("stream");
		}
		stream_0 = stream;
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!bool_0)
		{
			if (disposing)
			{
				((IDisposable)stream_0).Dispose();
			}
			bool_0 = true;
		}
	}
}
