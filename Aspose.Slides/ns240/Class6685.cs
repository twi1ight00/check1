using System;
using System.IO;
using ns218;
using ns233;

namespace ns240;

internal class Class6685
{
	private string string_0;

	private string string_1;

	private string string_2;

	private int int_0;

	internal Class6685(string fileName)
	{
		if (fileName == null)
		{
			throw new NotSupportedException("later");
		}
		string_0 = Path.GetDirectoryName(fileName);
		string_1 = string.Empty;
		string_2 = Path.GetFileNameWithoutExtension(fileName);
	}

	internal string method_0(Enum788 imageType)
	{
		int_0++;
		string path = $"{string_2}.{int_0:D3}.{Class6148.smethod_1(imageType)}";
		return Path.Combine(string_0, path);
	}

	internal string method_1(string fileName)
	{
		if (!Class5973.smethod_6(fileName))
		{
			return Class5973.smethod_12(string_1, Path.GetFileName(fileName));
		}
		return fileName;
	}
}
