using System.Collections.Generic;
using ns60;

namespace ns63;

internal abstract class Class2727 : Class2639
{
	public const int int_0 = 5000;

	public Class2726[] ProgStringTags
	{
		get
		{
			List<Class2726> list = new List<Class2726>();
			for (int i = 0; i < base.Records.Count; i++)
			{
				if (base.Records[i] is Class2726 item)
				{
					list.Add(item);
				}
			}
			return list.ToArray();
		}
	}

	public Class2722[] UnknownBinaryTags
	{
		get
		{
			List<Class2722> list = new List<Class2722>();
			for (int i = 0; i < base.Records.Count; i++)
			{
				if (base.Records[i] is Class2722 @class && @class.Records[1] is Class2897)
				{
					list.Add(@class);
				}
			}
			return list.ToArray();
		}
	}

	public Class2727()
	{
		base.Header.Type = 5000;
		base.Header.Instance = 0;
	}

	internal void method_5(Enum452 queryType)
	{
		Class2722 @class = null;
		switch (queryType)
		{
		case Enum452.const_0:
			@class = new Class2725();
			@class.method_5(queryType);
			break;
		case Enum452.const_1:
		case Enum452.const_2:
			@class = new Class2723();
			@class.method_5(queryType);
			break;
		}
		base.Records.Add(@class);
	}

	internal Class2722 method_6(string tagStr)
	{
		int num = 0;
		while (true)
		{
			if (num < base.Records.Count)
			{
				if (base.Records[num].Type == 5002)
				{
					Class2722 @class = (Class2722)base.Records[num];
					if (@class.Records.Count > 0 && @class.Records[0].Type == 4026 && ((Class2843)@class.Records[0]).String.Equals(tagStr))
					{
						break;
					}
				}
				num++;
				continue;
			}
			return null;
		}
		return (Class2722)base.Records[num];
	}

	public void method_7(string tagStr)
	{
		Class2722 item = method_6(tagStr);
		base.Records.Remove(item);
	}
}
