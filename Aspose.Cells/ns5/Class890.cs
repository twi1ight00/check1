using System.Collections;
using System.Runtime.CompilerServices;

namespace ns5;

internal class Class890
{
	private Enum100 enum100_0;

	private ArrayList arrayList_0;

	internal Enum100 Type
	{
		get
		{
			return enum100_0;
		}
		set
		{
			enum100_0 = value;
		}
	}

	internal ArrayList PointList => arrayList_0;

	[SpecialName]
	internal void method_0(ArrayList arrayList_1)
	{
		arrayList_0 = arrayList_1;
	}
}
