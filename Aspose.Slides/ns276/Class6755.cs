namespace ns276;

internal sealed class Class6755
{
	private static int int_0 = 65521;

	private static int int_1 = 5552;

	internal static long smethod_0(long adler, byte[] buf, int index, int len)
	{
		if (buf == null)
		{
			return 1L;
		}
		long num = adler & 0xFFFFL;
		long num2 = (adler >> 16) & 0xFFFFL;
		while (len > 0)
		{
			int num3 = ((len < int_1) ? len : int_1);
			len -= num3;
			while (num3 >= 16)
			{
				num += buf[index++] & 0xFF;
				num2 += num;
				num += buf[index++] & 0xFF;
				num2 += num;
				num += buf[index++] & 0xFF;
				num2 += num;
				num += buf[index++] & 0xFF;
				num2 += num;
				num += buf[index++] & 0xFF;
				num2 += num;
				num += buf[index++] & 0xFF;
				num2 += num;
				num += buf[index++] & 0xFF;
				num2 += num;
				num += buf[index++] & 0xFF;
				num2 += num;
				num += buf[index++] & 0xFF;
				num2 += num;
				num += buf[index++] & 0xFF;
				num2 += num;
				num += buf[index++] & 0xFF;
				num2 += num;
				num += buf[index++] & 0xFF;
				num2 += num;
				num += buf[index++] & 0xFF;
				num2 += num;
				num += buf[index++] & 0xFF;
				num2 += num;
				num += buf[index++] & 0xFF;
				num2 += num;
				num += buf[index++] & 0xFF;
				num2 += num;
				num3 -= 16;
			}
			if (num3 != 0)
			{
				do
				{
					num += buf[index++] & 0xFF;
					num2 += num;
				}
				while (--num3 != 0);
			}
			num %= int_0;
			num2 %= int_0;
		}
		return (num2 << 16) | num;
	}
}
