using System.Collections.Generic;
using ns60;

namespace ns63;

internal class Class2662 : Class2660
{
	private static readonly int[] int_1 = new int[2] { 61762, 2147483647 };

	public Class2760[] RgTimeVariant
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

	public Class2760 method_5(Enum399 type)
	{
		return method_3(61762, (short)type) as Class2760;
	}

	protected override int[] vmethod_6()
	{
		return int_1;
	}
}
