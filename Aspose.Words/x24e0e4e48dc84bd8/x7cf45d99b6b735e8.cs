using x74500b509de15565;
using xa7850104c8d8c135;

namespace x24e0e4e48dc84bd8;

internal class x7cf45d99b6b735e8
{
	private readonly xa078e85e8e8af73b xdda6cfd28220b3fb = new xa078e85e8e8af73b();

	private readonly x28a5d52551b64191 x7450cc1e48712286;

	private int x8034a70bc0fc90d1;

	private long x3ac2fd1cbfc260c4;

	private int x17b72ea1ae200b71;

	private xb1d54f2a80cb4dfb x9605723d4e6d4be5;

	public xa078e85e8e8af73b x586b7652ac7cefe0 => xdda6cfd28220b3fb;

	public int xd407167a86d34054 => x8034a70bc0fc90d1;

	public xb1d54f2a80cb4dfb xca723db1b703243f => x9605723d4e6d4be5;

	public long x0f9c80dc8a285b63 => x3ac2fd1cbfc260c4;

	public int xd9e89f699f91918a => x17b72ea1ae200b71;

	public x28a5d52551b64191 xf86de1bd2f396938 => x7450cc1e48712286;

	public int x03816e55fbe27e07 => (int)(x3ac2fd1cbfc260c4 - x7450cc1e48712286.BaseStream.Position);

	public x7cf45d99b6b735e8(x28a5d52551b64191 reader)
	{
		x7450cc1e48712286 = reader;
	}

	public void x2785b0923dba0723()
	{
		long position = xf86de1bd2f396938.BaseStream.Position;
		x9605723d4e6d4be5 = (xb1d54f2a80cb4dfb)x7450cc1e48712286.ReadInt16();
		xdda6cfd28220b3fb.x1b4522c8590b3e1a(x7450cc1e48712286);
		x17b72ea1ae200b71 = x7450cc1e48712286.ReadInt32();
		x8034a70bc0fc90d1 = x7450cc1e48712286.ReadInt32();
		x3ac2fd1cbfc260c4 = position + x17b72ea1ae200b71;
	}

	public void x0863f2d944829994()
	{
		x7450cc1e48712286.BaseStream.Position = x3ac2fd1cbfc260c4;
	}
}
