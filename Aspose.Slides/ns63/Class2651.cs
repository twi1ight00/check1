using System.Collections.Generic;

namespace ns63;

internal class Class2651 : Class2639
{
	internal const int int_0 = 61765;

	private static readonly int[] int_1 = new int[18]
	{
		61735, 2147483647, 61757, 2147483647, 61740, 2147483647, 61745, 2147483647, 61746, 2147483647,
		61756, 2147483647, 61733, 2, 61733, 3, 61737, 2147483647
	};

	public Class2755 TimeNodeAtom => (Class2755)method_1(61735);

	public Class2662 TimePropertyList => (Class2662)method_1(61757);

	public Class2655 TimeColorBehavior => (Class2655)method_1(61740);

	public Class2665 TimeSetBehavior => (Class2665)method_1(61745);

	public Class2656 TimeCommandBehavior => (Class2656)method_1(61746);

	public Class2649 ClientVisualElement => (Class2649)method_1(61756);

	public Class2657[] RgBeginTimeCondition
	{
		get
		{
			List<Class2657> list = new List<Class2657>();
			for (int i = 0; i < base.Records.Count; i++)
			{
				if (base.Records[i] is Class2657 @class && @class.Header.Instance == 2)
				{
					list.Add(@class);
				}
			}
			if (list.Count <= 0)
			{
				return null;
			}
			return list.ToArray();
		}
	}

	public Class2657[] RgEndTimeCondition
	{
		get
		{
			List<Class2657> list = new List<Class2657>();
			for (int i = 0; i < base.Records.Count; i++)
			{
				if (base.Records[i] is Class2657 @class && @class.Header.Instance == 3)
				{
					list.Add(@class);
				}
			}
			if (list.Count <= 0)
			{
				return null;
			}
			return list.ToArray();
		}
	}

	public Class2753[] RgTimeModifierAtom
	{
		get
		{
			List<Class2753> list = new List<Class2753>();
			for (int i = 0; i < base.Records.Count; i++)
			{
				if (base.Records[i] is Class2753 item)
				{
					list.Add(item);
				}
			}
			if (list.Count <= 0)
			{
				return null;
			}
			return list.ToArray();
		}
	}

	internal Class2651()
	{
		base.Header.Type = 61765;
	}

	protected override int[] vmethod_6()
	{
		return int_1;
	}
}
