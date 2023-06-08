using System.Collections;
using System.Runtime.CompilerServices;

namespace ns6;

internal class Class907
{
	private Enum119 enum119_0;

	private ArrayList arrayList_0;

	internal Enum119 Type
	{
		get
		{
			return enum119_0;
		}
		set
		{
			enum119_0 = value;
		}
	}

	internal ArrayList PointList => arrayList_0;

	[SpecialName]
	internal void method_0(ArrayList arrayList_1)
	{
		arrayList_0 = arrayList_1;
	}
}
