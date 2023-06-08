using System;
using ns45;

namespace ns71;

internal class Class3519
{
	internal const string string_0 = "\u0003VBFrame";

	private readonly int int_0;

	private readonly Class1107 class1107_0;

	private string string_1;

	public Class3519(Class1107 storage, int codePage)
	{
		if (storage == null)
		{
			throw new ArgumentNullException();
		}
		int_0 = codePage;
		class1107_0 = storage;
		method_1();
	}

	public void method_0(Class1107 storage)
	{
		storage.Add(class1107_0);
	}

	private void method_1()
	{
		if (!(class1107_0.method_2("\u0003VBFrame") is Class1106 @class))
		{
			throw new InvalidOperationException();
		}
		string_1 = Class3524.smethod_1(@class.method_7(), int_0);
	}
}
