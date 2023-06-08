using System.IO;
using ns221;

namespace ns271;

internal class Class6655 : Class6654
{
	private readonly string string_0;

	public string FileName => string_0;

	public Class6655(string fileName)
	{
		string_0 = fileName;
	}

	public override Stream vmethod_0()
	{
		return File.OpenRead(FileName);
	}

	[Attribute7(false)]
	public override int vmethod_1()
	{
		if (!vmethod_2())
		{
			return 0;
		}
		FileInfo fileInfo = new FileInfo(FileName);
		return (int)fileInfo.Length;
	}

	[Attribute7(false)]
	public override bool vmethod_2()
	{
		if (FileName == null)
		{
			return false;
		}
		return File.Exists(FileName);
	}
}
