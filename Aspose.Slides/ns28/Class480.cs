using ns223;
using ns276;

namespace ns28;

internal class Class480
{
	private long long_0 = long.MinValue;

	internal string string_0;

	internal Class6751 class6751_0;

	internal byte[] byte_0;

	internal string string_1;

	internal object object_0;

	internal Class461 class461_0;

	public long Crc32 => long_0;

	public Class480(Class6751 zentry)
	{
		string_0 = zentry.FileName;
		class6751_0 = zentry;
		long_0 = zentry.Crc;
	}

	public Class480(string name)
	{
		string_0 = name;
	}

	public Class480(string name, byte[] data)
	{
		string_0 = name;
		byte_0 = data;
		uint num = Class5979.smethod_2(data);
		long_0 = num;
	}
}
