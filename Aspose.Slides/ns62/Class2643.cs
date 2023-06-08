using System.Collections.Generic;
using ns60;
using ns63;

namespace ns62;

internal class Class2643 : Class2639
{
	internal const int int_0 = 61442;

	private static readonly int[] int_1 = new int[10] { 61448, 2147483647, 61720, 2147483647, 61443, 2147483647, 61444, 2147483647, 61445, 2147483647 };

	public Class2743 DrawingData => method_1(61448) as Class2743;

	public Class2819 RegroupItems => method_1(61720) as Class2819;

	public Class2671 GroupShape => method_1(61443) as Class2671;

	public Class2670 Shape => method_1(61444) as Class2670;

	public Class2669[] DeletedShapes
	{
		get
		{
			bool flag = false;
			List<Class2669> list = new List<Class2669>();
			for (int i = 0; i < base.Records.Count; i++)
			{
				Class2623 @class = base.Records[i];
				if (!flag && @class.Header.Type == 61444)
				{
					flag = true;
				}
				if (flag && @class.GetType().IsSubclassOf(typeof(Class2669)))
				{
					list.Add((Class2669)@class.method_0());
				}
			}
			if (list.Count > 0)
			{
				return list.ToArray();
			}
			return null;
		}
	}

	public Class2668 Solvers => method_1(61445) as Class2668;

	public Class2643()
		: base(61442)
	{
	}

	internal void method_5(Enum452 queryType)
	{
		Class2743 @class = new Class2743();
		@class.Header.Version = 0;
		base.Records.Add(@class);
		Class2671 class2 = new Class2671();
		class2.method_5(queryType);
		class2.Header.Version = 15;
		class2.Header.Instance = 0;
		base.Records.Add(class2);
		Class2670 class3 = new Class2670();
		class3.method_5(queryType, 0);
		class3.Header.Version = 15;
		class3.Header.Instance = 0;
		base.Records.Add(class3);
		switch (queryType)
		{
		default:
			@class.Header.Instance = 1;
			@class.ShapeCount = 3u;
			@class.SpidLast = 2051u;
			break;
		case Enum452.const_1:
			@class.Header.Instance = 1;
			@class.ShapeCount = 6u;
			@class.SpidLast = 1030u;
			break;
		case Enum452.const_2:
			@class.Header.Instance = 2;
			@class.ShapeCount = 3u;
			@class.SpidLast = 2051u;
			break;
		}
	}

	internal void method_6()
	{
		int num = base.Records.Count;
		while (num > 0)
		{
			num--;
			if (base.Records[num] is Class2670)
			{
				Class2670 @class = base.Records[num] as Class2670;
				if (@class.ShapeProp.FDeleted)
				{
					base.Records.RemoveAt(num);
				}
			}
			else if (base.Records[num] is Class2671)
			{
				Class2671 class2 = base.Records[num] as Class2671;
				if (class2.ShapeProp.FDeleted)
				{
					base.Records.RemoveAt(num);
				}
			}
		}
	}

	protected override int[] vmethod_6()
	{
		return int_1;
	}
}
