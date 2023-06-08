using System.Runtime.CompilerServices;

namespace ns21;

internal class Class1287
{
	private bool bool_0 = true;

	internal int int_0;

	[SpecialName]
	internal bool method_0()
	{
		return bool_0;
	}

	[SpecialName]
	internal void method_1(bool bool_1)
	{
		bool_0 = bool_1;
	}

	internal void Copy(Class1287 class1287_0)
	{
		bool_0 = class1287_0.bool_0;
		int_0 = class1287_0.int_0;
	}
}
