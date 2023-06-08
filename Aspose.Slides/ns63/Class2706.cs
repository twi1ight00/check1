using System;

namespace ns63;

internal class Class2706 : Class2639
{
	internal const int int_0 = 2005;

	public Class2706()
	{
		base.Header.Type = 2005;
	}

	internal void method_5()
	{
		Class2879 @class = new Class2879();
		@class.method_1();
		@class.Header.Version = 0;
		@class.Header.Instance = 0;
		base.Records.Add(@class);
	}

	public int method_6()
	{
		int num = 0;
		for (int i = 0; i < base.Records.Count; i++)
		{
			if (base.Records[i] is Class2879)
			{
				num = Math.Max(num, ((Class2879)base.Records[i]).Header.Instance);
			}
		}
		return num;
	}

	public int method_7()
	{
		int num = -1;
		for (int i = 0; i < base.Records.Count; i++)
		{
			if (base.Records[i] is Class2879)
			{
				num = Math.Max(num, ((Class2879)base.Records[i]).Header.Instance);
			}
		}
		return num;
	}

	public Class2879 method_8(int index)
	{
		int num = 0;
		while (true)
		{
			if (num < base.Records.Count)
			{
				if (base.Records[num] is Class2879 && ((Class2879)base.Records[num]).Header.Instance == index)
				{
					break;
				}
				num++;
				continue;
			}
			return null;
		}
		return (Class2879)base.Records[num];
	}
}
