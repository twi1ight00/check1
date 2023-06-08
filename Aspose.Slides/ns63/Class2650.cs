using System;
using System.Collections.Generic;
using ns60;
using ns64;

namespace ns63;

internal class Class2650 : Class2639, Interface39, Interface42
{
	internal const int int_0 = 61764;

	private static readonly int[] int_1 = new int[34]
	{
		61735, 2147483647, 61757, 2147483647, 61739, 2147483647, 61740, 2147483647, 61741, 2147483647,
		61742, 2147483647, 61743, 2147483647, 61744, 2147483647, 61745, 2147483647, 61746, 2147483647,
		61756, 2147483647, 61760, 2147483647, 61761, 2147483647, 61733, 2147483647, 61737, 2147483647,
		61765, 1, 61764, 1
	};

	public Class2755 TimeNodeAtom => (Class2755)method_1(61735);

	public Class2662 TimePropertyList => (Class2662)method_1(61757);

	public Class2652 TimeAnimateBehavior => (Class2652)method_1(61739);

	public Class2655 TimeColorBehavior => (Class2655)method_1(61740);

	public Class2658 TimeEffectBehavior => (Class2658)method_1(61741);

	public Class2659 TimeMotionBehavior => (Class2659)method_1(61742);

	public Class2663 TimeRotationBehavior => (Class2663)method_1(61743);

	public Class2664 TimeScaleBehavior => (Class2664)method_1(61744);

	public Class2665 TimeSetBehavior => (Class2665)method_1(61745);

	public Class2656 TimeCommandBehavior => (Class2656)method_1(61746);

	public Class2649 ClientVisualElement => (Class2649)method_1(61756);

	public Class2752 TimeIterateDataAtom => (Class2752)method_1(61760);

	public Class2758 TimeSequenceDataAtom => (Class2758)method_1(61761);

	public Class2657[] RgBeginTimeCondition
	{
		get
		{
			List<Class2657> list = new List<Class2657>();
			for (int i = 0; i < base.Records.Count; i++)
			{
				if (base.Records[i] is Class2657 @class && smethod_2(@class, TimeNodeAtom))
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
				if (base.Records[i] is Class2657 @class && method_5(@class, TimeNodeAtom))
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

	public Class2657 TimeEndSyncTimeCondition => (Class2657)method_3(61733, 5);

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

	public Class2651[] RgSubEffect
	{
		get
		{
			List<Class2651> list = new List<Class2651>();
			for (int i = 0; i < base.Records.Count; i++)
			{
				if (base.Records[i] is Class2651 item)
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

	public Class2650[] RgExtTimeNodeChildren
	{
		get
		{
			List<Class2650> list = new List<Class2650>();
			for (int i = 0; i < base.Records.Count; i++)
			{
				if (base.Records[i] is Class2650 item)
				{
					list.Add(item);
				}
			}
			return list.ToArray();
		}
	}

	public Class2650()
	{
		base.Header.Type = 61764;
		base.Header.Version = 15;
		base.Header.Instance = 1;
	}

	internal static bool smethod_2(Class2657 timeCondition, Class2755 timeNodeAtom)
	{
		if (timeCondition == null)
		{
			throw new ArgumentNullException("timeCondition");
		}
		if (timeNodeAtom == null)
		{
			throw new ArgumentNullException("timeNodeAtom");
		}
		if (timeCondition.Header.Instance == 1)
		{
			return true;
		}
		if (timeCondition.Header.Instance == 3 && timeNodeAtom.TimeNodeType == Enum398.const_1)
		{
			return true;
		}
		return false;
	}

	private bool method_5(Class2657 timeCondition, Class2755 timeNodeAtom)
	{
		if (timeCondition == null)
		{
			throw new ArgumentNullException("timeCondition");
		}
		if (timeNodeAtom == null)
		{
			throw new ArgumentNullException("timeNodeAtom");
		}
		if (timeCondition.Header.Instance == 2)
		{
			return true;
		}
		if (timeCondition.Header.Instance == 4 && timeNodeAtom.TimeNodeType == Enum398.const_1)
		{
			return true;
		}
		return false;
	}

	protected override int[] vmethod_6()
	{
		return int_1;
	}
}
