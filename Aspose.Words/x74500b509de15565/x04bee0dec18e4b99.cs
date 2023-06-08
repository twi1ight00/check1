using xa7850104c8d8c135;

namespace x74500b509de15565;

internal class x04bee0dec18e4b99
{
	private readonly x28a5d52551b64191 x7450cc1e48712286;

	private xec95ecd2fe18d5f2 xf263b01e2956834c;

	private long x3b77a41bd57164d6;

	private long x3ac2fd1cbfc260c4;

	public xec95ecd2fe18d5f2 x3146d638ec378671 => xf263b01e2956834c;

	public long x437e3b626c0fdd43 => x3b77a41bd57164d6;

	public x04bee0dec18e4b99(x28a5d52551b64191 reader)
	{
		x7450cc1e48712286 = reader;
	}

	public void x2785b0923dba0723()
	{
		long position = x7450cc1e48712286.BaseStream.Position;
		xf263b01e2956834c = (xec95ecd2fe18d5f2)x7450cc1e48712286.ReadInt32();
		x3b77a41bd57164d6 = x7450cc1e48712286.ReadUInt32();
		x3ac2fd1cbfc260c4 = position + x3b77a41bd57164d6;
	}

	public void x0863f2d944829994()
	{
		x7450cc1e48712286.BaseStream.Position = x3ac2fd1cbfc260c4;
	}
}
