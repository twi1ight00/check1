using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Aspose.Slides;

[Guid("774C0DFE-E38C-4D3C-8EF1-0C67EE1EF214")]
[ComVisible(true)]
public interface IStreamWrapper : IDisposable
{
	Stream Stream { get; }

	bool CanRead { get; }

	bool CanSeek { get; }

	bool CanWrite { get; }

	long Length { get; }

	long Position { get; }

	IDisposable AsIDisposable { get; }

	void Close();

	void Flush();

	void Read(byte[] buffer, int offset, int count);

	int ReadByte();

	long Seek(long offset, SeekOrigin origin);

	void Write(byte[] buffer, int offset, int count);

	void WriteByte(byte value);
}
