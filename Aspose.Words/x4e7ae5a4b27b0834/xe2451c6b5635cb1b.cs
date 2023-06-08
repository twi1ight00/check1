using System.IO;
using x6c95d9cf46ff5f25;

namespace x4e7ae5a4b27b0834;

internal class xe2451c6b5635cb1b
{
	private readonly xa8866d7566da0aa2 x7450cc1e48712286;

	private readonly long x904c523501275af4;

	public Stream x9e418ad9a56d1cf5 => x7450cc1e48712286.x9e418ad9a56d1cf5;

	public xe2451c6b5635cb1b(xa8866d7566da0aa2 reader)
	{
		x7450cc1e48712286 = reader;
		x904c523501275af4 = reader.x9e418ad9a56d1cf5.Position;
	}

	public byte[] x0f6807cca84a8e5b(int x10f4d88af727adbc)
	{
		return x7450cc1e48712286.x0f6807cca84a8e5b(x10f4d88af727adbc);
	}

	public short xa323b362e90db435()
	{
		return x7450cc1e48712286.x672ed37ee25c078c();
	}

	public ushort x0646818fa18eea2f()
	{
		return x7450cc1e48712286.xdb264d863790ee7b();
	}

	public short xe11775cf079e846f()
	{
		return x7450cc1e48712286.x672ed37ee25c078c();
	}

	public int[] xeff8397bc628aeba(short x6c83912428ceacb1, int x10f4d88af727adbc)
	{
		int[] array = new int[x10f4d88af727adbc];
		for (int i = 0; i < x10f4d88af727adbc; i++)
		{
			switch (x6c83912428ceacb1)
			{
			case 1:
				array[i] = x7450cc1e48712286.x672ed37ee25c078c();
				break;
			case 2:
				array[i] = x7450cc1e48712286.xdb264d863790ee7b();
				break;
			case 3:
				array[i] = x7450cc1e48712286.x5b77aaf600f3aee7();
				break;
			case 4:
				array[i] = (int)x7450cc1e48712286.x2aa9a7ff4efa6ddf();
				break;
			}
		}
		return array;
	}

	public xcb3ed34a3eba8ce2 x53d922d8067784fb()
	{
		return xcb3ed34a3eba8ce2.x06b0e25aa6ad68a9(this);
	}

	public void xcaa93d37b4fef121(int x374ea4fe62468d0f)
	{
		x7450cc1e48712286.x9e418ad9a56d1cf5.Position = x904c523501275af4 + x374ea4fe62468d0f;
	}
}
