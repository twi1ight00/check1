using System.Collections;

namespace ns57;

internal class Class1300 : ArrayList
{
	public new Class1326 this[int int_0]
	{
		get
		{
			return base[int_0] as Class1326;
		}
		set
		{
			base[int_0] = value;
		}
	}

	internal int method_0(int int_0)
	{
		int num = 0;
		while (true)
		{
			if (num < Count)
			{
				if (this[num].int_0 == int_0)
				{
					break;
				}
				num++;
				continue;
			}
			return -1;
		}
		return this[num].int_1;
	}
}
