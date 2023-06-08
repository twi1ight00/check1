using System.IO;
using ns22;

namespace ns18;

internal class Class1050 : Class1049
{
	public Class1050(Stream stream_0)
	{
		class1030_0 = new Class1030(stream_0);
		class1030_0.method_2(2);
		method_1(new Class1052(class1030_0));
	}

	public void method_3()
	{
		method_0().Close();
		class1030_0.method_1();
	}
}
