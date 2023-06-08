using System;
using System.IO;

namespace ns18;

internal class Class771
{
	private string string_0;

	private string string_1;

	private string string_2;

	private int int_0;

	internal Class771(string string_3)
	{
		if (string_3 == null)
		{
			throw new NotSupportedException("later");
		}
		string_0 = Path.GetDirectoryName(string_3);
		string_1 = "";
		string_2 = Path.GetFileNameWithoutExtension(string_3);
	}

	internal string method_0(Enum200 enum200_0)
	{
		int_0++;
		string path = $"{string_2}.{int_0:000}.{Class1404.smethod_2(enum200_0)}";
		return Path.Combine(string_0, path);
	}

	internal string method_1(string string_3)
	{
		if (!Class1399.smethod_0(string_3))
		{
			return Class1399.smethod_5(string_1, Path.GetFileName(string_3));
		}
		return string_3;
	}
}
