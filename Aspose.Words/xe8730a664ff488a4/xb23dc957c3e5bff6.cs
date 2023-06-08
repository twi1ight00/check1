using Aspose;

namespace xe8730a664ff488a4;

[JavaDelete("Using java zip instead.")]
internal sealed class xb23dc957c3e5bff6
{
	private static int x89574df7ee777036 = 65521;

	private static int x8e6afc7e7c50732d = 5552;

	internal static long x7ab4a0dd1a2efc16(long x51f0c843867fac77, byte[] x1ef26dbdd5d13d24, int xc0c4c459c6ccbd00, int xb5964a891b6cf7c3)
	{
		if (x1ef26dbdd5d13d24 == null)
		{
			return 1L;
		}
		long num = x51f0c843867fac77 & 0xFFFF;
		long num2 = (x51f0c843867fac77 >> 16) & 0xFFFF;
		while (xb5964a891b6cf7c3 > 0)
		{
			int num3 = ((xb5964a891b6cf7c3 < x8e6afc7e7c50732d) ? xb5964a891b6cf7c3 : x8e6afc7e7c50732d);
			xb5964a891b6cf7c3 -= num3;
			while (num3 >= 16)
			{
				num += x1ef26dbdd5d13d24[xc0c4c459c6ccbd00++] & 0xFF;
				num2 += num;
				num += x1ef26dbdd5d13d24[xc0c4c459c6ccbd00++] & 0xFF;
				num2 += num;
				num += x1ef26dbdd5d13d24[xc0c4c459c6ccbd00++] & 0xFF;
				num2 += num;
				num += x1ef26dbdd5d13d24[xc0c4c459c6ccbd00++] & 0xFF;
				num2 += num;
				num += x1ef26dbdd5d13d24[xc0c4c459c6ccbd00++] & 0xFF;
				num2 += num;
				num += x1ef26dbdd5d13d24[xc0c4c459c6ccbd00++] & 0xFF;
				num2 += num;
				num += x1ef26dbdd5d13d24[xc0c4c459c6ccbd00++] & 0xFF;
				num2 += num;
				num += x1ef26dbdd5d13d24[xc0c4c459c6ccbd00++] & 0xFF;
				num2 += num;
				num += x1ef26dbdd5d13d24[xc0c4c459c6ccbd00++] & 0xFF;
				num2 += num;
				num += x1ef26dbdd5d13d24[xc0c4c459c6ccbd00++] & 0xFF;
				num2 += num;
				num += x1ef26dbdd5d13d24[xc0c4c459c6ccbd00++] & 0xFF;
				num2 += num;
				num += x1ef26dbdd5d13d24[xc0c4c459c6ccbd00++] & 0xFF;
				num2 += num;
				num += x1ef26dbdd5d13d24[xc0c4c459c6ccbd00++] & 0xFF;
				num2 += num;
				num += x1ef26dbdd5d13d24[xc0c4c459c6ccbd00++] & 0xFF;
				num2 += num;
				num += x1ef26dbdd5d13d24[xc0c4c459c6ccbd00++] & 0xFF;
				num2 += num;
				num += x1ef26dbdd5d13d24[xc0c4c459c6ccbd00++] & 0xFF;
				num2 += num;
				num3 -= 16;
			}
			if (num3 != 0)
			{
				do
				{
					num += x1ef26dbdd5d13d24[xc0c4c459c6ccbd00++] & 0xFF;
					num2 += num;
				}
				while (--num3 != 0);
			}
			num %= x89574df7ee777036;
			num2 %= x89574df7ee777036;
		}
		return (num2 << 16) | num;
	}
}
