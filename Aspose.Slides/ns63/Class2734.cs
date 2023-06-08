using System.Collections.Generic;

namespace ns63;

internal class Class2734 : Class2639
{
	public const int int_0 = 2020;

	private static readonly int[] int_1 = new int[4] { 2021, 2147483647, 2022, 2147483647 };

	public Class2890 SoundCollectionAtom => (Class2890)method_1(2021);

	public Class2733[] RgSoundContainer
	{
		get
		{
			List<Class2733> list = new List<Class2733>();
			for (int i = 0; i < base.Records.Count; i++)
			{
				if (base.Records[i] is Class2733 item)
				{
					list.Add(item);
				}
			}
			return list.ToArray();
		}
	}

	public Class2734()
	{
		base.Header.Type = 2020;
		base.Header.Instance = 5;
		base.Records.Add(new Class2890());
	}

	public Class2734(int dummi)
	{
		base.Header.Type = 2020;
		base.Header.Instance = 5;
	}

	public Class2733 method_5(int id)
	{
		int num = 0;
		while (true)
		{
			if (num < base.Records.Count)
			{
				if (base.Records[num] is Class2733 && ((Class2733)base.Records[num]).Id == id)
				{
					break;
				}
				num++;
				continue;
			}
			return null;
		}
		return (Class2733)base.Records[num].method_0();
	}

	public Class2733[] method_6()
	{
		List<Class2733> list = new List<Class2733>();
		for (int i = 0; i < base.Records.Count; i++)
		{
			if (base.Records[i] is Class2733 @class && !@class.IsGrabbed)
			{
				list.Add(@class);
			}
		}
		if (list.Count != 0)
		{
			return list.ToArray();
		}
		return null;
	}

	protected override int[] vmethod_6()
	{
		return int_1;
	}
}
