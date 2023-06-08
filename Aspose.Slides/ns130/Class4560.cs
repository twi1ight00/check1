using System;

namespace ns130;

internal class Class4560
{
	private const byte byte_0 = byte.MaxValue;

	private const byte byte_1 = 248;

	private const byte byte_2 = 247;

	private const byte byte_3 = 240;

	private const byte byte_4 = 239;

	private const byte byte_5 = 238;

	private const short short_0 = 238;

	public static byte[] smethod_0(byte[] data)
	{
		Class4572 @class = new Class4572(data);
		byte[] array = new byte[@class.method_3() * 2];
		short num = 0;
		for (int i = 0; i < array.Length; i += 2)
		{
			byte b = @class.ReadByte();
			short num2;
			if (b < 238)
			{
				num2 = b;
			}
			else if (b >= 248 && b <= byte.MaxValue)
			{
				num2 = @class.ReadByte();
				num2 = (short)(num2 + (b - 248 + 1) * 238);
			}
			else if (b >= 239 && b <= 247)
			{
				num2 = @class.ReadByte();
				num2 = (short)(-(num2 + (b - 239) * 238));
			}
			else
			{
				num2 = @class.method_4();
			}
			num2 = (short)(num2 + num);
			num = num2;
			array[i] = (byte)((uint)(num2 >> 8) & 0xFFu);
			array[i + 1] = (byte)((uint)num2 & 0xFFu);
		}
		if (@class.Position == array.Length)
		{
			throw new InvalidOperationException("Incorrect length of 'cvt' table");
		}
		return array;
	}
}
