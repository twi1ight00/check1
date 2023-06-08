using System.IO;
using System.Text;

namespace xa604c4d210ae0581;

internal class x354e9ebad65eecc8 : BinaryWriter
{
	internal x354e9ebad65eecc8(Stream stream)
		: base(stream, Encoding.Unicode)
	{
	}

	internal void x1680160a63ff3e0b(x875aca5784596b73 x9035cf16181332fc, int xbcea506a33cf9111)
	{
		x3a52c4e37999b16e(x9035cf16181332fc);
		Write((byte)xbcea506a33cf9111);
	}

	internal void xd776ae6f68bc4d9c(x875aca5784596b73 x9035cf16181332fc, int xbcea506a33cf9111)
	{
		x3a52c4e37999b16e(x9035cf16181332fc);
		Write((short)xbcea506a33cf9111);
	}

	internal void x52cfd1b813a1514a(x875aca5784596b73 x9035cf16181332fc, int xbcea506a33cf9111)
	{
		x3a52c4e37999b16e(x9035cf16181332fc);
		Write((ushort)xbcea506a33cf9111);
	}

	internal void x138617e45a6d57be(x875aca5784596b73 x9035cf16181332fc, int xbcea506a33cf9111)
	{
		x3a52c4e37999b16e(x9035cf16181332fc);
		Write(xbcea506a33cf9111);
	}

	internal void x9d91059a64953e89(x875aca5784596b73 x9035cf16181332fc, bool xbcea506a33cf9111)
	{
		x1680160a63ff3e0b(x9035cf16181332fc, xbcea506a33cf9111 ? 1 : 0);
	}

	internal void x3a52c4e37999b16e(x875aca5784596b73 x9035cf16181332fc)
	{
		Write((ushort)x9035cf16181332fc);
	}
}
