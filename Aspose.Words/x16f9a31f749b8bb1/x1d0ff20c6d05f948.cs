using System.IO;

namespace x16f9a31f749b8bb1;

internal abstract class x1d0ff20c6d05f948
{
	private readonly BinaryReader x7450cc1e48712286;

	private readonly long x3ad07a87511e33c6;

	private readonly int xb4e2ccbe94d17841;

	protected long x0a77cc42460213ba => x3ad07a87511e33c6;

	protected int x73cd64f2630e68ba => xb4e2ccbe94d17841;

	protected BinaryReader xf86de1bd2f396938 => x7450cc1e48712286;

	internal x1d0ff20c6d05f948(BinaryReader reader)
	{
		x7450cc1e48712286 = reader;
		x3ad07a87511e33c6 = reader.BaseStream.Position;
		reader.BaseStream.Seek(511L, SeekOrigin.Current);
		xb4e2ccbe94d17841 = reader.ReadByte();
		reader.BaseStream.Seek(x3ad07a87511e33c6, SeekOrigin.Begin);
	}
}
