using System.IO;

namespace x6c95d9cf46ff5f25;

internal class x73087173962e3778
{
	private readonly BinaryWriter x9b287b671d592594;

	public Stream x9e418ad9a56d1cf5 => x9b287b671d592594.BaseStream;

	public x73087173962e3778(Stream stream)
	{
		x9b287b671d592594 = new BinaryWriter(stream);
	}

	public void x6ff7c65ed4805c27(int xbcea506a33cf9111)
	{
		x9b287b671d592594.Write(x26000ce44ebda9ea.xc44c58d0078e5f2e(xbcea506a33cf9111));
	}

	public void x04aa082effd9db6b(uint xbcea506a33cf9111)
	{
		x9b287b671d592594.Write((int)x26000ce44ebda9ea.x539dc61123306a51(xbcea506a33cf9111));
	}

	public void xab5f6b7526efa5be(int xbcea506a33cf9111)
	{
		x9b287b671d592594.Write(x26000ce44ebda9ea.xf3c41a4b1dccb1c1((short)xbcea506a33cf9111));
	}

	public void xb0c682b9901a2443(int xbcea506a33cf9111)
	{
		x9b287b671d592594.Write(x26000ce44ebda9ea.xb26c35b8f72ab749((ushort)xbcea506a33cf9111));
	}

	public void xc3961295e3201124(int xbcea506a33cf9111)
	{
		byte value = (byte)((xbcea506a33cf9111 & 0xFF0000) >> 16);
		byte value2 = (byte)((xbcea506a33cf9111 & 0xFF00) >> 8);
		byte value3 = (byte)((uint)xbcea506a33cf9111 & 0xFFu);
		x9b287b671d592594.Write(value);
		x9b287b671d592594.Write(value2);
		x9b287b671d592594.Write(value3);
	}

	public void x1cc8cfe834f421cf(long xbcea506a33cf9111)
	{
		x9b287b671d592594.Write(x26000ce44ebda9ea.x12faa55b48ce2747(xbcea506a33cf9111));
	}

	public void xc351d479ff7ee789(byte xbcea506a33cf9111)
	{
		x9b287b671d592594.Write(xbcea506a33cf9111);
	}

	public void x4c116b70372a3c6d(byte[] x5cafa8d49ea71ea1, int xc0c4c459c6ccbd00, int x10f4d88af727adbc)
	{
		x9b287b671d592594.Write(x5cafa8d49ea71ea1, xc0c4c459c6ccbd00, x10f4d88af727adbc);
	}

	public void x4c116b70372a3c6d(byte[] x5cafa8d49ea71ea1)
	{
		x9b287b671d592594.Write(x5cafa8d49ea71ea1, 0, x5cafa8d49ea71ea1.Length);
	}

	public void xbb7550bbb62a218c()
	{
		x9b287b671d592594.Flush();
	}
}
