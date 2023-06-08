using System.Collections.Generic;

namespace ns63;

internal class Class2732 : Class2639
{
	internal const int int_0 = 1018;

	private static readonly int[] int_1 = new int[6] { 1022, 2147483647, 1021, 2147483647, 1019, 7 };

	public Class2905 SlideViewInfoAtom => (Class2905)method_1(1022);

	public Class2904 ZoomViewInfoAtom => (Class2904)method_1(1021);

	public Class2903[] RgGuideAtom
	{
		get
		{
			List<Class2903> list = new List<Class2903>();
			for (int i = 0; i < base.Records.Count; i++)
			{
				if (base.Records[i] is Class2903 item)
				{
					list.Add(item);
				}
			}
			return list.ToArray();
		}
	}

	internal Class2732()
	{
		base.Header.Type = 1018;
	}

	internal void method_5()
	{
		Class2905 @class = new Class2905();
		@class.method_1();
		@class.Header.Version = 0;
		@class.Header.Instance = 0;
		base.Records.Add(@class);
		Class2904 class2 = new Class2904();
		class2.method_1(0);
		class2.Header.Version = 0;
		class2.Header.Instance = 0;
		base.Records.Add(class2);
		Class2903 class3 = new Class2903();
		class3.method_1(0);
		class3.Header.Version = 0;
		base.Records.Add(class3);
		class3 = new Class2903();
		class3.method_1(1);
		class3.Header.Version = 0;
		base.Records.Add(class3);
	}

	protected override int[] vmethod_6()
	{
		return int_1;
	}
}
