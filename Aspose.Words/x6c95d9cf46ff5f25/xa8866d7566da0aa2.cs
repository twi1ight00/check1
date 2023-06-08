using System.IO;

namespace x6c95d9cf46ff5f25;

internal class xa8866d7566da0aa2
{
	private readonly BinaryReader x7450cc1e48712286;

	public Stream x9e418ad9a56d1cf5 => x7450cc1e48712286.BaseStream;

	public xa8866d7566da0aa2(Stream stream)
	{
		x7450cc1e48712286 = new BinaryReader(stream);
	}

	public int x95ea7d23cc8ee04d()
	{
		return x26000ce44ebda9ea.xc44c58d0078e5f2e(x7450cc1e48712286.ReadInt32());
	}

	public uint x2aa9a7ff4efa6ddf()
	{
		return x26000ce44ebda9ea.x539dc61123306a51(x7450cc1e48712286.ReadUInt32());
	}

	public short x2e6b89ad8001e18f()
	{
		return x26000ce44ebda9ea.xf3c41a4b1dccb1c1(x7450cc1e48712286.ReadInt16());
	}

	public ushort xdb264d863790ee7b()
	{
		return x26000ce44ebda9ea.xb26c35b8f72ab749(x7450cc1e48712286.ReadUInt16());
	}

	public long xadf3d86ee4125c04()
	{
		return x26000ce44ebda9ea.x12faa55b48ce2747(x7450cc1e48712286.ReadInt64());
	}

	public int x5b77aaf600f3aee7()
	{
		byte[] array = x7450cc1e48712286.ReadBytes(3);
		int num = 0;
		int num2 = 1;
		for (int num3 = 2; num3 >= 0; num3--)
		{
			num += array[num3] * num2;
			num2 <<= 8;
		}
		return num;
	}

	public short x672ed37ee25c078c()
	{
		return x7450cc1e48712286.ReadByte();
	}

	public byte[] x0f6807cca84a8e5b(int x10f4d88af727adbc)
	{
		return x7450cc1e48712286.ReadBytes(x10f4d88af727adbc);
	}

	public char[] x9a839f0ae94bc95f(int x10f4d88af727adbc)
	{
		char[] array = new char[x10f4d88af727adbc];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = (char)x7450cc1e48712286.ReadByte();
		}
		return array;
	}
}
