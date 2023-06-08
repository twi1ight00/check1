using System.Collections;

namespace ns52;

internal class Class1135 : IComparer
{
	int IComparer.Compare(object x, object y)
	{
		int num = ((Class1136)x).method_1() & 0x3FFF;
		int num2 = ((Class1136)y).method_1() & 0x3FFF;
		return num - num2;
	}
}
