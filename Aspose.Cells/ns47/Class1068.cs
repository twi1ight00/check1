using System;
using ns18;

namespace ns47;

internal class Class1068 : Class1067
{
	private Class1073 class1073_0;

	private readonly Class1072 class1072_0;

	private readonly Class1074 class1074_0;

	internal Class1068(Class1393 class1393_0)
	{
		class1073_0 = new Class1073(class1393_0);
		method_2();
		class1073_0.method_5();
		class1072_0 = class1073_0.method_5();
		Class1071 @class = new Class1071(class1072_0.method_0());
		class1074_0 = new Class1074(@class.method_0());
	}

	internal bool method_1()
	{
		return class1074_0.method_0() != null;
	}

	private void method_2()
	{
		class1073_0.method_0();
		class1073_0.method_0();
		class1073_0.method_0();
		class1073_0.method_2();
	}

	internal override void Write(Class1394 class1394_0)
	{
		throw new NotImplementedException("Not supposed to write CFF yet because no subsetting for CFF is implemented.");
	}
}
