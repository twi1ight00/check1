using System.Collections;

namespace ns56;

internal class Class1283 : CollectionBase
{
	public Class1282 this[int int_0] => (Class1282)base.InnerList[int_0];

	internal int Add(string string_0, string string_1)
	{
		int num = 0;
		while (true)
		{
			if (num < base.Count)
			{
				Class1282 @class = (Class1282)base.InnerList[num];
				if (string.Compare(string_0, @class.Uri, ignoreCase: true) == 0 && string.Compare(string_1, @class.Name, ignoreCase: true) == 0)
				{
					break;
				}
				num++;
				continue;
			}
			Class1282 value = new Class1282(string_0, string_1);
			base.InnerList.Add(value);
			return base.Count - 1;
		}
		return num;
	}

	internal int Add(string string_0, string string_1, string string_2)
	{
		int num = 0;
		while (true)
		{
			if (num < base.Count)
			{
				Class1282 @class = (Class1282)base.InnerList[num];
				if (string.Compare(string_0, @class.Uri, ignoreCase: true) == 0 && string.Compare(string_1, @class.Name, ignoreCase: true) == 0)
				{
					break;
				}
				num++;
				continue;
			}
			Class1282 class2 = new Class1282(string_0, string_1);
			class2.string_2 = string_2;
			base.InnerList.Add(class2);
			return base.Count - 1;
		}
		return num;
	}

	internal int IndexOf(Class1282 class1282_0)
	{
		return base.InnerList.IndexOf(class1282_0);
	}
}
