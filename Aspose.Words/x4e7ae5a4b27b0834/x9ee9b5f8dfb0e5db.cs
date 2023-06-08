using System;

namespace x4e7ae5a4b27b0834;

internal class x9ee9b5f8dfb0e5db
{
	private byte[] x73f065a6b420cfe1;

	public int x437e3b626c0fdd43 => x73f065a6b420cfe1.Length;

	private x9ee9b5f8dfb0e5db()
	{
	}

	public static x9ee9b5f8dfb0e5db x06b0e25aa6ad68a9(xe2451c6b5635cb1b xe134235b3526fa75, int x97a1a99c489af2b1)
	{
		x9ee9b5f8dfb0e5db x9ee9b5f8dfb0e5db2 = new x9ee9b5f8dfb0e5db();
		long position = xe134235b3526fa75.x9e418ad9a56d1cf5.Position;
		int x10f4d88af727adbc = xe134235b3526fa75.xa323b362e90db435() switch
		{
			0 => x58bdb04aabafe960(x97a1a99c489af2b1), 
			3 => x9c40f9aee383f2a3(xe134235b3526fa75), 
			_ => throw new InvalidOperationException("Unknown CFF FDSelect format."), 
		};
		xe134235b3526fa75.x9e418ad9a56d1cf5.Position = position;
		x9ee9b5f8dfb0e5db2.x73f065a6b420cfe1 = xe134235b3526fa75.x0f6807cca84a8e5b(x10f4d88af727adbc);
		return x9ee9b5f8dfb0e5db2;
	}

	private static int x58bdb04aabafe960(int x97a1a99c489af2b1)
	{
		return x97a1a99c489af2b1 + 1;
	}

	private static int x9c40f9aee383f2a3(xe2451c6b5635cb1b xe134235b3526fa75)
	{
		int num = xe134235b3526fa75.x0646818fa18eea2f();
		return 3 + num * 3 + 2;
	}

	public void x6210059f049f0d48(xc0e60c4cd8683899 xbdfb620b7167944b)
	{
		xbdfb620b7167944b.x4c116b70372a3c6d(x73f065a6b420cfe1);
	}
}
