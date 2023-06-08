using System.Collections.Generic;

namespace ns63;

internal class Class2661 : Class2660
{
	private static readonly int[] int_1 = new int[2] { 61762, 2147483647 };

	public Class2760[] RgChildRec
	{
		get
		{
			List<Class2760> list = new List<Class2760>();
			for (int i = 0; i < base.Records.Count; i++)
			{
				if (base.Records[i] is Class2760 item)
				{
					list.Add(item);
				}
			}
			return list.ToArray();
		}
	}

	protected override int[] vmethod_6()
	{
		return int_1;
	}
}
