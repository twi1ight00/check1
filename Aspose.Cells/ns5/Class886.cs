using System.Collections;
using System.Runtime.CompilerServices;

namespace ns5;

internal class Class886
{
	private ArrayList arrayList_0;

	private long long_0;

	private long long_1;

	internal ArrayList PathList => arrayList_0;

	internal long Height
	{
		get
		{
			return long_0;
		}
		set
		{
			long_0 = value;
		}
	}

	internal long Width
	{
		get
		{
			return long_1;
		}
		set
		{
			long_1 = value;
		}
	}

	[SpecialName]
	internal void method_0(ArrayList arrayList_1)
	{
		arrayList_0 = arrayList_1;
	}
}
