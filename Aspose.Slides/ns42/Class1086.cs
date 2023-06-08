using System.IO;
using ns223;
using ns276;

namespace ns42;

internal class Class1086
{
	private long long_0 = long.MinValue;

	internal string string_0;

	internal string string_1;

	internal byte[] byte_0;

	internal Class6751 class6751_0;

	internal Class822 class822_0;

	internal Class1090 class1090_0;

	internal object object_0;

	public long Crc32 => long_0;

	public long Size
	{
		get
		{
			if (class6751_0 != null)
			{
				return class6751_0.UncompressedSize;
			}
			if (byte_0 != null)
			{
				return byte_0.Length;
			}
			return -1L;
		}
	}

	public Class1086(string name)
	{
		string_0 = name;
	}

	public Class1086(Class6751 zentry)
	{
		string_0 = "/" + zentry.FileName;
		class6751_0 = zentry;
		long_0 = zentry.Crc;
	}

	public Class1086(string name, byte[] data)
	{
		string_0 = name;
		byte_0 = data;
		uint num = Class5979.smethod_2(data);
		long_0 = num;
	}

	public void method_0(Class6752 zfile)
	{
		if (byte_0 == null)
		{
			byte_0 = smethod_0(zfile, class6751_0);
		}
	}

	internal static byte[] smethod_0(Class6752 zfile, Class6751 zentry)
	{
		byte[] array = new byte[zentry.UncompressedSize];
		using Stream stream = zentry.method_19();
		for (int i = 0; i < array.Length; i += stream.Read(array, i, array.Length - i))
		{
		}
		return array;
	}
}
