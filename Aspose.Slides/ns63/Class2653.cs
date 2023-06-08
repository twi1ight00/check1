using System.Collections.Generic;

namespace ns63;

internal class Class2653 : Class2639
{
	internal const int int_0 = 61759;

	private List<Class2938> list_1;

	public List<Class2938> RgTimeAnimValueList
	{
		get
		{
			if (list_1 != null)
			{
				return list_1;
			}
			list_1 = method_5();
			return list_1;
		}
	}

	public Class2653()
	{
		base.Header.Type = 61759;
		base.Header.Version = 15;
	}

	private List<Class2938> method_5()
	{
		list_1 = new List<Class2938>();
		int num = 0;
		while (num < base.Records.Count && base.Records[num] is Class2746 timeAnimationValueAtom)
		{
			num++;
			Class2760 @class = null;
			if (num < base.Records.Count)
			{
				@class = base.Records[num] as Class2760;
				if (@class != null && @class.Header.Instance == 0)
				{
					num++;
				}
			}
			Class2764 class2 = null;
			if (num < base.Records.Count)
			{
				class2 = base.Records[num] as Class2764;
				if (class2 != null && class2.Header.Instance == 1)
				{
					num++;
				}
			}
			list_1.Add(new Class2938(timeAnimationValueAtom, @class, class2));
		}
		return list_1;
	}
}
