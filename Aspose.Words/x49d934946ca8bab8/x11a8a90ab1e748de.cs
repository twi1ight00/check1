using System.IO;
using x6c95d9cf46ff5f25;

namespace x49d934946ca8bab8;

internal class x11a8a90ab1e748de
{
	private readonly int x320973f25e1d35ae;

	private readonly int x7fffe685af9f0d78;

	private readonly int x5b9c5b1be40f383d;

	private readonly int x91a33d8a3bb2cf64;

	private readonly int xb21cc6aa730b2a57;

	private readonly int xa6e74357695173f0;

	private readonly int x2b8a10123c61e8cc;

	private static readonly x11a8a90ab1e748de[] xc128c06c67d9f953 = new x11a8a90ab1e748de[128]
	{
		new x11a8a90ab1e748de(2, 0, 8, 0, 0, 0, -1),
		new x11a8a90ab1e748de(2, 0, 8, 0, 0, 0, 1),
		new x11a8a90ab1e748de(2, 0, 8, 0, 256, 0, -1),
		new x11a8a90ab1e748de(2, 0, 8, 0, 256, 0, 1),
		new x11a8a90ab1e748de(2, 0, 8, 0, 512, 0, -1),
		new x11a8a90ab1e748de(2, 0, 8, 0, 512, 0, 1),
		new x11a8a90ab1e748de(2, 0, 8, 0, 768, 0, -1),
		new x11a8a90ab1e748de(2, 0, 8, 0, 768, 0, 1),
		new x11a8a90ab1e748de(2, 0, 8, 0, 1024, 0, -1),
		new x11a8a90ab1e748de(2, 0, 8, 0, 1024, 0, 1),
		new x11a8a90ab1e748de(2, 8, 0, 0, 0, -1, 0),
		new x11a8a90ab1e748de(2, 8, 0, 0, 0, 1, 0),
		new x11a8a90ab1e748de(2, 8, 0, 256, 0, -1, 0),
		new x11a8a90ab1e748de(2, 8, 0, 256, 0, 1, 0),
		new x11a8a90ab1e748de(2, 8, 0, 512, 0, -1, 0),
		new x11a8a90ab1e748de(2, 8, 0, 512, 0, 1, 0),
		new x11a8a90ab1e748de(2, 8, 0, 768, 0, -1, 0),
		new x11a8a90ab1e748de(2, 8, 0, 768, 0, 1, 0),
		new x11a8a90ab1e748de(2, 8, 0, 1024, 0, -1, 0),
		new x11a8a90ab1e748de(2, 8, 0, 1024, 0, 1, 0),
		new x11a8a90ab1e748de(2, 4, 4, 1, 1, -1, -1),
		new x11a8a90ab1e748de(2, 4, 4, 1, 1, 1, -1),
		new x11a8a90ab1e748de(2, 4, 4, 1, 1, -1, 1),
		new x11a8a90ab1e748de(2, 4, 4, 1, 1, 1, 1),
		new x11a8a90ab1e748de(2, 4, 4, 1, 17, -1, -1),
		new x11a8a90ab1e748de(2, 4, 4, 1, 17, 1, -1),
		new x11a8a90ab1e748de(2, 4, 4, 1, 17, -1, 1),
		new x11a8a90ab1e748de(2, 4, 4, 1, 17, 1, 1),
		new x11a8a90ab1e748de(2, 4, 4, 1, 33, -1, -1),
		new x11a8a90ab1e748de(2, 4, 4, 1, 33, 1, -1),
		new x11a8a90ab1e748de(2, 4, 4, 1, 33, -1, 1),
		new x11a8a90ab1e748de(2, 4, 4, 1, 33, 1, 1),
		new x11a8a90ab1e748de(2, 4, 4, 1, 49, -1, -1),
		new x11a8a90ab1e748de(2, 4, 4, 1, 49, 1, -1),
		new x11a8a90ab1e748de(2, 4, 4, 1, 49, -1, 1),
		new x11a8a90ab1e748de(2, 4, 4, 1, 49, 1, 1),
		new x11a8a90ab1e748de(2, 4, 4, 17, 1, -1, -1),
		new x11a8a90ab1e748de(2, 4, 4, 17, 1, 1, -1),
		new x11a8a90ab1e748de(2, 4, 4, 17, 1, -1, 1),
		new x11a8a90ab1e748de(2, 4, 4, 17, 1, 1, 1),
		new x11a8a90ab1e748de(2, 4, 4, 17, 17, -1, -1),
		new x11a8a90ab1e748de(2, 4, 4, 17, 17, 1, -1),
		new x11a8a90ab1e748de(2, 4, 4, 17, 17, -1, 1),
		new x11a8a90ab1e748de(2, 4, 4, 17, 17, 1, 1),
		new x11a8a90ab1e748de(2, 4, 4, 17, 33, -1, -1),
		new x11a8a90ab1e748de(2, 4, 4, 17, 33, 1, -1),
		new x11a8a90ab1e748de(2, 4, 4, 17, 33, -1, 1),
		new x11a8a90ab1e748de(2, 4, 4, 17, 33, 1, 1),
		new x11a8a90ab1e748de(2, 4, 4, 17, 49, -1, -1),
		new x11a8a90ab1e748de(2, 4, 4, 17, 49, 1, -1),
		new x11a8a90ab1e748de(2, 4, 4, 17, 49, -1, 1),
		new x11a8a90ab1e748de(2, 4, 4, 17, 49, 1, 1),
		new x11a8a90ab1e748de(2, 4, 4, 33, 1, -1, -1),
		new x11a8a90ab1e748de(2, 4, 4, 33, 1, 1, -1),
		new x11a8a90ab1e748de(2, 4, 4, 33, 1, -1, 1),
		new x11a8a90ab1e748de(2, 4, 4, 33, 1, 1, 1),
		new x11a8a90ab1e748de(2, 4, 4, 33, 17, -1, -1),
		new x11a8a90ab1e748de(2, 4, 4, 33, 17, 1, -1),
		new x11a8a90ab1e748de(2, 4, 4, 33, 17, -1, 1),
		new x11a8a90ab1e748de(2, 4, 4, 33, 17, 1, 1),
		new x11a8a90ab1e748de(2, 4, 4, 33, 33, -1, -1),
		new x11a8a90ab1e748de(2, 4, 4, 33, 33, 1, -1),
		new x11a8a90ab1e748de(2, 4, 4, 33, 33, -1, 1),
		new x11a8a90ab1e748de(2, 4, 4, 33, 33, 1, 1),
		new x11a8a90ab1e748de(2, 4, 4, 33, 49, -1, -1),
		new x11a8a90ab1e748de(2, 4, 4, 33, 49, 1, -1),
		new x11a8a90ab1e748de(2, 4, 4, 33, 49, -1, 1),
		new x11a8a90ab1e748de(2, 4, 4, 33, 49, 1, 1),
		new x11a8a90ab1e748de(2, 4, 4, 49, 1, -1, -1),
		new x11a8a90ab1e748de(2, 4, 4, 49, 1, 1, -1),
		new x11a8a90ab1e748de(2, 4, 4, 49, 1, -1, 1),
		new x11a8a90ab1e748de(2, 4, 4, 49, 1, 1, 1),
		new x11a8a90ab1e748de(2, 4, 4, 49, 17, -1, -1),
		new x11a8a90ab1e748de(2, 4, 4, 49, 17, 1, -1),
		new x11a8a90ab1e748de(2, 4, 4, 49, 17, -1, 1),
		new x11a8a90ab1e748de(2, 4, 4, 49, 17, 1, 1),
		new x11a8a90ab1e748de(2, 4, 4, 49, 33, -1, -1),
		new x11a8a90ab1e748de(2, 4, 4, 49, 33, 1, -1),
		new x11a8a90ab1e748de(2, 4, 4, 49, 33, -1, 1),
		new x11a8a90ab1e748de(2, 4, 4, 49, 33, 1, 1),
		new x11a8a90ab1e748de(2, 4, 4, 49, 49, -1, -1),
		new x11a8a90ab1e748de(2, 4, 4, 49, 49, 1, -1),
		new x11a8a90ab1e748de(2, 4, 4, 49, 49, -1, 1),
		new x11a8a90ab1e748de(2, 4, 4, 49, 49, 1, 1),
		new x11a8a90ab1e748de(3, 8, 8, 1, 1, -1, -1),
		new x11a8a90ab1e748de(3, 8, 8, 1, 1, 1, -1),
		new x11a8a90ab1e748de(3, 8, 8, 1, 1, -1, 1),
		new x11a8a90ab1e748de(3, 8, 8, 1, 1, 1, 1),
		new x11a8a90ab1e748de(3, 8, 8, 1, 257, -1, -1),
		new x11a8a90ab1e748de(3, 8, 8, 1, 257, 1, -1),
		new x11a8a90ab1e748de(3, 8, 8, 1, 257, -1, 1),
		new x11a8a90ab1e748de(3, 8, 8, 1, 257, 1, 1),
		new x11a8a90ab1e748de(3, 8, 8, 1, 513, -1, -1),
		new x11a8a90ab1e748de(3, 8, 8, 1, 513, 1, -1),
		new x11a8a90ab1e748de(3, 8, 8, 1, 513, -1, 1),
		new x11a8a90ab1e748de(3, 8, 8, 1, 513, 1, 1),
		new x11a8a90ab1e748de(3, 8, 8, 257, 1, -1, -1),
		new x11a8a90ab1e748de(3, 8, 8, 257, 1, 1, -1),
		new x11a8a90ab1e748de(3, 8, 8, 257, 1, -1, 1),
		new x11a8a90ab1e748de(3, 8, 8, 257, 1, 1, 1),
		new x11a8a90ab1e748de(3, 8, 8, 257, 257, -1, -1),
		new x11a8a90ab1e748de(3, 8, 8, 257, 257, 1, -1),
		new x11a8a90ab1e748de(3, 8, 8, 257, 257, -1, 1),
		new x11a8a90ab1e748de(3, 8, 8, 257, 257, 1, 1),
		new x11a8a90ab1e748de(3, 8, 8, 257, 513, -1, -1),
		new x11a8a90ab1e748de(3, 8, 8, 257, 513, 1, -1),
		new x11a8a90ab1e748de(3, 8, 8, 257, 513, -1, 1),
		new x11a8a90ab1e748de(3, 8, 8, 257, 513, 1, 1),
		new x11a8a90ab1e748de(3, 8, 8, 513, 1, -1, -1),
		new x11a8a90ab1e748de(3, 8, 8, 513, 1, 1, -1),
		new x11a8a90ab1e748de(3, 8, 8, 513, 1, -1, 1),
		new x11a8a90ab1e748de(3, 8, 8, 513, 1, 1, 1),
		new x11a8a90ab1e748de(3, 8, 8, 513, 257, -1, -1),
		new x11a8a90ab1e748de(3, 8, 8, 513, 257, 1, -1),
		new x11a8a90ab1e748de(3, 8, 8, 513, 257, -1, 1),
		new x11a8a90ab1e748de(3, 8, 8, 513, 257, 1, 1),
		new x11a8a90ab1e748de(3, 8, 8, 513, 513, -1, -1),
		new x11a8a90ab1e748de(3, 8, 8, 513, 513, 1, -1),
		new x11a8a90ab1e748de(3, 8, 8, 513, 513, -1, 1),
		new x11a8a90ab1e748de(3, 8, 8, 513, 513, 1, 1),
		new x11a8a90ab1e748de(4, 12, 12, 0, 0, -1, -1),
		new x11a8a90ab1e748de(4, 12, 12, 0, 0, 1, -1),
		new x11a8a90ab1e748de(4, 12, 12, 0, 0, -1, 1),
		new x11a8a90ab1e748de(4, 12, 12, 0, 0, 1, 1),
		new x11a8a90ab1e748de(5, 16, 16, 0, 0, -1, -1),
		new x11a8a90ab1e748de(5, 16, 16, 0, 0, 1, -1),
		new x11a8a90ab1e748de(5, 16, 16, 0, 0, -1, 1),
		new x11a8a90ab1e748de(5, 16, 16, 0, 0, 1, 1)
	};

	private x11a8a90ab1e748de(int byteCount, int xBits, int yBits, int deltaX, int deltaY, int xSign, int ySign)
	{
		x320973f25e1d35ae = byteCount;
		x7fffe685af9f0d78 = xBits;
		x5b9c5b1be40f383d = yBits;
		x91a33d8a3bb2cf64 = deltaX;
		xb21cc6aa730b2a57 = deltaY;
		xa6e74357695173f0 = xSign;
		x2b8a10123c61e8cc = ySign;
	}

	public static void x5a3accf79af477fd(xa8866d7566da0aa2 xe134235b3526fa75, byte x8fc2d66566293701, x0fddf8d807b6807c x2f7096dac971d6ec)
	{
		x2f7096dac971d6ec.x3608e1d09b3fd55d = (x8fc2d66566293701 & 0x80) == 0;
		int num = x8fc2d66566293701 & 0x7F;
		x11a8a90ab1e748de x11a8a90ab1e748de2 = xc128c06c67d9f953[num];
		byte[] buffer = xe134235b3526fa75.x0f6807cca84a8e5b(x11a8a90ab1e748de2.x320973f25e1d35ae - 1);
		using MemoryStream stream = new MemoryStream(buffer);
		x05cddb129b0360cd x05cddb129b0360cd = new x05cddb129b0360cd(stream, useMsbFirstBitOrdering: true);
		long num2 = x05cddb129b0360cd.x59692b33f32fe96f(x11a8a90ab1e748de2.x7fffe685af9f0d78);
		long num3 = x05cddb129b0360cd.x59692b33f32fe96f(x11a8a90ab1e748de2.x5b9c5b1be40f383d);
		x2f7096dac971d6ec.x8df91a2f90079e88 = (short)(x11a8a90ab1e748de2.xa6e74357695173f0 * (num2 + x11a8a90ab1e748de2.x91a33d8a3bb2cf64));
		x2f7096dac971d6ec.xc821290d7ecc08bf = (short)(x11a8a90ab1e748de2.x2b8a10123c61e8cc * (num3 + x11a8a90ab1e748de2.xb21cc6aa730b2a57));
	}
}
