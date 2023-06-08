using System;
using x6c95d9cf46ff5f25;

namespace x4e7ae5a4b27b0834;

internal class xc0e60c4cd8683899
{
	private readonly x73087173962e3778 x0eda88637a678099;

	public xc0e60c4cd8683899(x73087173962e3778 binaryWriter)
	{
		x0eda88637a678099 = binaryWriter;
	}

	public void x4c116b70372a3c6d(byte[] x5cafa8d49ea71ea1)
	{
		x0eda88637a678099.x4c116b70372a3c6d(x5cafa8d49ea71ea1);
	}

	public void x9059344d17e0002f(short xbcea506a33cf9111)
	{
		x0eda88637a678099.xc351d479ff7ee789((byte)xbcea506a33cf9111);
	}

	public void x49ac741484894752(ushort xbcea506a33cf9111)
	{
		x0eda88637a678099.xb0c682b9901a2443(xbcea506a33cf9111);
	}

	public void xf9a7663e3fa37cc6(short xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111 < 0 || xbcea506a33cf9111 > 4)
		{
			throw new InvalidOperationException("Invalid offset.");
		}
		x0eda88637a678099.xc351d479ff7ee789((byte)xbcea506a33cf9111);
	}

	public void x5f3901d45fe874c1(int[] x2b837002a494e808, short x6c83912428ceacb1)
	{
		foreach (int num in x2b837002a494e808)
		{
			switch (x6c83912428ceacb1)
			{
			case 1:
				x0eda88637a678099.xc351d479ff7ee789((byte)num);
				break;
			case 2:
				x0eda88637a678099.xb0c682b9901a2443(num);
				break;
			case 3:
				x0eda88637a678099.xc3961295e3201124(num);
				break;
			case 4:
				x0eda88637a678099.x04aa082effd9db6b((uint)num);
				break;
			}
		}
	}
}
