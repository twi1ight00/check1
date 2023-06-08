namespace ns63;

internal class Class2702 : Class2639
{
	public const int int_0 = 4014;

	public Class2702()
	{
		base.Header.Type = 4014;
	}

	public Class2898 method_5(uint slideId, short refInstance)
	{
		int num = 0;
		refInstance = (short)(refInstance & 0xFFF0);
		while (true)
		{
			if (num < base.Records.Count)
			{
				if (base.Records[num] is Class2877 @class)
				{
					if (@class.SlideIdRef == slideId && @class.Header.Instance == refInstance && num < base.Records.Count - 1)
					{
						break;
					}
					num++;
				}
				num++;
				continue;
			}
			return null;
		}
		return base.Records[num + 1] as Class2898;
	}

	public void method_6(uint slideId, short refInstance)
	{
		int num = 0;
		refInstance = (short)(refInstance & 0xFFF0);
		while (true)
		{
			if (num >= base.Records.Count)
			{
				return;
			}
			if (base.Records[num] is Class2877 @class)
			{
				if (@class.SlideIdRef == slideId && @class.Header.Instance == refInstance)
				{
					break;
				}
				num++;
			}
			num++;
		}
		if (num < base.Records.Count - 1)
		{
			base.Records.RemoveAt(num + 1);
		}
		base.Records.RemoveAt(num);
	}

	public Class2898 method_7(uint slideId, short refInstance, Enum449 frameType)
	{
		refInstance = (short)(refInstance & 0xFFF0);
		Class2898 @class = method_5(slideId, refInstance);
		if (@class != null)
		{
			return @class;
		}
		@class = new Class2898();
		method_8(slideId, refInstance, frameType, @class);
		return @class;
	}

	public void method_8(uint slideId, short refInstance, Enum449 frameType, Class2898 epa)
	{
		Class2898 @class = method_5(slideId, refInstance);
		if (@class != null)
		{
			method_6(slideId, refInstance);
		}
		Class2877 class2 = new Class2877();
		class2.Header.Instance = (short)((refInstance & 0xFFF0) >> 4);
		class2.Header.Version = (byte)((uint)refInstance & 0xFu);
		class2.SlideIdRef = slideId;
		class2.TxType = frameType;
		base.Records.Add(class2);
		base.Records.Add(epa);
	}
}
