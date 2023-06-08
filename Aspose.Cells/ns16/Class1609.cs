using System.Collections;

namespace ns16;

internal class Class1609 : IComparer
{
	int IComparer.Compare(object x, object y)
	{
		Class1564 @class = (Class1564)x;
		Class1564 class2 = (Class1564)y;
		int num = Class1618.smethod_145(@class.string_1);
		int num2 = Class1618.smethod_145(class2.string_1);
		if (num > num2)
		{
			return 1;
		}
		if (num2 > num)
		{
			return -1;
		}
		return 0;
	}
}
