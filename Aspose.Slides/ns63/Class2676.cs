using System.Collections.Generic;

namespace ns63;

internal class Class2676 : Class2673
{
	private static readonly int[] int_1 = new int[2] { 4013, 2147483647 };

	public Class2899[] RgTextMasterStyleAtom
	{
		get
		{
			List<Class2899> list = new List<Class2899>();
			for (int i = 0; i < base.Records.Count; i++)
			{
				if (base.Records[i] is Class2899 item)
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
