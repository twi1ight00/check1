using System.Collections;
using System.Collections.Generic;
using ns234;

namespace ns237;

internal class Class6669
{
	private readonly List<Interface320> list_0;

	private readonly IDictionary idictionary_0;

	private readonly IDictionary idictionary_1;

	internal Class6669()
	{
		list_0 = new List<Interface320>();
		idictionary_0 = Class6152.smethod_0();
		idictionary_1 = Class6152.smethod_0();
	}

	internal void method_0(Interface320 annot)
	{
		list_0.Add(annot);
	}

	internal void method_1(string name, Class6673 dest)
	{
		idictionary_0[name] = dest;
	}

	internal void method_2(int pageNumber, Class6673 dest)
	{
		idictionary_1[pageNumber] = dest;
	}

	internal void method_3(Class6679 writer)
	{
		for (int i = 0; i < list_0.Count; i++)
		{
			Interface320 @interface = list_0[i];
			@interface.imethod_0(writer, idictionary_0, idictionary_1);
		}
	}
}
