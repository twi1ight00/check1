using System.IO;
using System.Runtime.CompilerServices;

namespace ns18;

internal class Class1447 : Class1446
{
	private Class1398 class1398_0;

	public Class1447(Stream stream_1)
		: base(stream_1)
	{
		class1398_0 = new Class1398();
		class1398_0.Add(0, 0);
	}

	[SpecialName]
	public int method_23()
	{
		return class1398_0.Count;
	}

	public void method_24(Class938 class938_0)
	{
		class1398_0.Add(class938_0.method_0(), (int)method_0().Position);
		Write(class938_0.method_0().ToString());
		method_6(" 0 obj");
	}

	public void method_25()
	{
		Write("\r\nendobj\r\n");
	}

	public int method_26()
	{
		int result = (int)method_0().Position;
		method_6("xref");
		Write("0 ");
		method_6(class1398_0.Count.ToString());
		method_6("0000000000 65535 f");
		for (int i = 1; i < class1398_0.Count; i++)
		{
			method_7("{0:0000000000} 00000 n", class1398_0.GetByIndex(i));
		}
		return result;
	}
}
