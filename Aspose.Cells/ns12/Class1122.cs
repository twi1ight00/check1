using System;
using System.Collections;

namespace ns12;

internal class Class1122
{
	internal static object Calculate(object object_0)
	{
		if (object_0 == null)
		{
			return null;
		}
		Hashtable hashtable = new Hashtable();
		ArrayList arrayList = new ArrayList();
		if (object_0 is Array)
		{
			Array array = (Array)object_0;
			for (int i = 0; i < array.Length; i++)
			{
				object value = array.GetValue(i);
				if (value == null)
				{
					continue;
				}
				if (value is Array)
				{
					Array array2 = (Array)value;
					for (int j = 0; j < array2.Length; j++)
					{
						object value2 = array2.GetValue(j);
						if (value2 != null)
						{
							object obj = hashtable[value2];
							if (obj != null)
							{
								hashtable[value2] = (int)obj + 1;
								continue;
							}
							hashtable.Add(value2, 1);
							arrayList.Add(value2);
						}
					}
				}
				else
				{
					object obj2 = hashtable[value];
					if (obj2 != null)
					{
						hashtable[value] = (int)obj2 + 1;
						continue;
					}
					hashtable.Add(value, 1);
					arrayList.Add(value);
				}
			}
			object result = null;
			int num = 0;
			{
				foreach (object item in arrayList)
				{
					int num2 = (int)hashtable[item];
					if (num2 > num)
					{
						num = num2;
						result = item;
					}
				}
				return result;
			}
		}
		return object_0;
	}
}
