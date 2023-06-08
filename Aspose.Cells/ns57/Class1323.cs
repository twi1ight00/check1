using System.Collections;
using System.Runtime.CompilerServices;

namespace ns57;

internal class Class1323 : ArrayList
{
	public new Class1322 this[int int_0]
	{
		get
		{
			return base[int_0] as Class1322;
		}
		set
		{
			base[int_0] = value;
		}
	}

	[SpecialName]
	internal bool method_0()
	{
		int num = 0;
		while (true)
		{
			if (num < Count)
			{
				if (this[num].method_0())
				{
					break;
				}
				num++;
				continue;
			}
			return false;
		}
		return true;
	}

	[SpecialName]
	internal int method_1()
	{
		int num = 0;
		for (int i = 0; i < Count; i++)
		{
			if (this[i].method_0())
			{
				num++;
			}
		}
		return num;
	}
}
