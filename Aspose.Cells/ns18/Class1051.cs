using System.IO;
using System.Runtime.CompilerServices;

namespace ns18;

internal class Class1051
{
	private readonly string string_0;

	private string string_1;

	private MemoryStream memoryStream_0;

	private readonly Class1054 class1054_0;

	public string Name => string_0;

	public string ContentType => string_1;

	public Class1051(string string_2, string string_3)
	{
		Class1015.smethod_12(string_2, "partName");
		string_0 = string_2;
		string_1 = string_3;
		memoryStream_0 = new MemoryStream(2048);
		class1054_0 = new Class1054(string_2);
	}

	[SpecialName]
	public string method_0()
	{
		return Path.GetExtension(string_0).TrimStart('.');
	}

	[SpecialName]
	public MemoryStream method_1()
	{
		return memoryStream_0;
	}

	[SpecialName]
	public void method_2(MemoryStream memoryStream_1)
	{
		memoryStream_0 = memoryStream_1;
	}

	[SpecialName]
	public Class1054 method_3()
	{
		return class1054_0;
	}
}
