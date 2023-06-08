using System;
using System.Collections;

namespace ns206;

internal class Class5449 : ArrayList
{
	public static Class5449 smethod_0(string valuesString)
	{
		Class5449 @class = new Class5449();
		string[] array = valuesString.Split(',');
		if (array.Length > 1)
		{
			string[] array2 = array;
			foreach (string valuesString2 in array2)
			{
				Class5449 c = smethod_0(valuesString2);
				@class.AddRange(c);
			}
		}
		else
		{
			string text = array[0].Trim();
			object obj = null;
			try
			{
				obj = int.Parse(text);
			}
			catch (Exception ex)
			{
				if (ex is FormatException)
				{
					obj = Class5454.smethod_0(text);
					if (obj == null)
					{
						obj = text;
					}
				}
			}
			if (obj != null)
			{
				@class.Add(obj);
			}
		}
		return @class;
	}
}
