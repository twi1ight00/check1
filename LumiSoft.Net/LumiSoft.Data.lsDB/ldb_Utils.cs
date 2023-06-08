namespace LumiSoft.Data.lsDB;

internal class ldb_Utils
{
	public static byte[] LongToByte(long val)
	{
		return new byte[8]
		{
			(byte)((val >> 56) & 0xFF),
			(byte)((val >> 48) & 0xFF),
			(byte)((val >> 40) & 0xFF),
			(byte)((val >> 32) & 0xFF),
			(byte)((val >> 24) & 0xFF),
			(byte)((val >> 16) & 0xFF),
			(byte)((val >> 8) & 0xFF),
			(byte)(val & 0xFF)
		};
	}

	public static long ByteToLong(byte[] array, int offset)
	{
		long num = 0L;
		num |= (long)((ulong)array[offset] << 56);
		num |= (long)((ulong)array[offset + 1] << 48);
		num |= (long)((ulong)array[offset + 2] << 40);
		num |= (long)((ulong)array[offset + 3] << 32);
		num |= (long)((ulong)array[offset + 4] << 24);
		num |= (long)((ulong)array[offset + 5] << 16);
		num |= (long)((ulong)array[offset + 6] << 8);
		return num | array[offset + 7];
	}

	public static byte[] IntToByte(int val)
	{
		return new byte[4]
		{
			(byte)((uint)(val >> 24) & 0xFFu),
			(byte)((uint)(val >> 16) & 0xFFu),
			(byte)((uint)(val >> 8) & 0xFFu),
			(byte)((uint)val & 0xFFu)
		};
	}

	public static int ByteToInt(byte[] array, int offset)
	{
		int num = 0;
		num |= array[offset] << 24;
		num |= array[offset + 1] << 16;
		num |= array[offset + 2] << 8;
		return num | array[offset + 3];
	}
}
