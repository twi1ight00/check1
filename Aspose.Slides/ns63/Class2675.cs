using System.Collections.Generic;

namespace ns63;

internal class Class2675 : Class2673
{
	private static readonly int[] int_1 = new int[18]
	{
		4018, 2147483647, 12000, 2147483647, 12007, 2147483647, 12006, 2147483647, 12010, 2147483647,
		12011, 2147483647, 11008, 2147483647, 61764, 1, 11010, 2147483647
	};

	public Class2816[] RgTextMasterStyleAtom
	{
		get
		{
			List<Class2816> list = new List<Class2816>();
			for (int i = 0; i < base.Records.Count; i++)
			{
				if (base.Records[i] is Class2816 item)
				{
					list.Add(item);
				}
			}
			return list.ToArray();
		}
	}

	public Class2685[] RgComment10Container
	{
		get
		{
			List<Class2685> list = new List<Class2685>();
			for (int i = 0; i < base.Records.Count; i++)
			{
				if (base.Records[i] is Class2685 item)
				{
					list.Add(item);
				}
			}
			return list.ToArray();
		}
	}

	public Class2800 LinkedSlideAtom => method_1(12007) as Class2800;

	public Class2801[] RgLinkedShape10Atom
	{
		get
		{
			List<Class2801> list = new List<Class2801>();
			for (int i = 0; i < base.Records.Count; i++)
			{
				if (base.Records[i] is Class2801 item)
				{
					list.Add(item);
				}
			}
			return list.ToArray();
		}
	}

	public Class2809 SlideFlagsAtom => method_1(12010) as Class2809;

	public Class2889 SlideTimeAtom => method_1(12011) as Class2889;

	public Class2880 HashCodeAtom => method_1(11008) as Class2880;

	public Class2650 ExtTimeNodeContainer => method_1(61764) as Class2650;

	public Class2684 BuildListContainer => method_1(11010) as Class2684;

	protected override int[] vmethod_6()
	{
		return int_1;
	}
}
