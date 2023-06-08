using System.IO;

namespace ns119;

internal class Class4489 : Class4487
{
	private string string_0;

	public string FileName
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	private Class4489()
	{
	}

	public Class4489(string fileName)
	{
		string_0 = fileName;
	}

	public override Stream vmethod_0()
	{
		return File.OpenRead(string_0);
	}

	public override object Clone()
	{
		return new Class4489(string_0);
	}
}
