using System;

namespace x4e7ae5a4b27b0834;

internal class xb67de7dfc17262be
{
	private byte[] x73f065a6b420cfe1;

	public int x437e3b626c0fdd43 => x73f065a6b420cfe1.Length;

	private xb67de7dfc17262be()
	{
	}

	public static xb67de7dfc17262be x06b0e25aa6ad68a9(xe2451c6b5635cb1b xe134235b3526fa75, int x97a1a99c489af2b1)
	{
		xb67de7dfc17262be xb67de7dfc17262be2 = new xb67de7dfc17262be();
		long position = xe134235b3526fa75.x9e418ad9a56d1cf5.Position;
		int x10f4d88af727adbc = x12486aaf1fc72d15(xe134235b3526fa75, x97a1a99c489af2b1);
		xe134235b3526fa75.x9e418ad9a56d1cf5.Position = position;
		xb67de7dfc17262be2.x73f065a6b420cfe1 = xe134235b3526fa75.x0f6807cca84a8e5b(x10f4d88af727adbc);
		return xb67de7dfc17262be2;
	}

	private static int x12486aaf1fc72d15(xe2451c6b5635cb1b xe134235b3526fa75, int x97a1a99c489af2b1)
	{
		return xe134235b3526fa75.xa323b362e90db435() switch
		{
			0 => x58bdb04aabafe960(x97a1a99c489af2b1), 
			1 => xf35a5ca800256d75(xe134235b3526fa75, x97a1a99c489af2b1, xb35a2b7b2c7fee34: true), 
			2 => xf35a5ca800256d75(xe134235b3526fa75, x97a1a99c489af2b1, xb35a2b7b2c7fee34: false), 
			_ => throw new InvalidOperationException("Unknown CFF charset format."), 
		};
	}

	private static int x58bdb04aabafe960(int x97a1a99c489af2b1)
	{
		return 1 + 2 * (x97a1a99c489af2b1 - 1);
	}

	private static int xf35a5ca800256d75(xe2451c6b5635cb1b xe134235b3526fa75, int x97a1a99c489af2b1, bool xb35a2b7b2c7fee34)
	{
		int num = 1;
		int num2 = 0;
		while (num2 < x97a1a99c489af2b1 - 1)
		{
			xe134235b3526fa75.x0646818fa18eea2f();
			int num3 = (xb35a2b7b2c7fee34 ? ((int)xe134235b3526fa75.xa323b362e90db435()) : ((int)xe134235b3526fa75.x0646818fa18eea2f()));
			num2 += num3 + 1;
			num += 2 + (xb35a2b7b2c7fee34 ? 1 : 2);
		}
		return num;
	}

	public void x6210059f049f0d48(xc0e60c4cd8683899 xbdfb620b7167944b)
	{
		xbdfb620b7167944b.x4c116b70372a3c6d(x73f065a6b420cfe1);
	}
}
