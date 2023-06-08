using System;
using Aspose.Cells;

namespace ns12;

internal class Class1250
{
	internal static object smethod_0(object object_0, object object_1, bool bool_0)
	{
		if (object_1 is Array)
		{
			Array array = (Array)object_1;
			object value = array.GetValue(0);
			bool flag;
			if (flag = value is Array)
			{
				Array array2 = (Array)value;
				if (array2.Length > array.Length)
				{
					int num = array2.Length - 1;
					while (true)
					{
						if (num >= 0)
						{
							object value2 = array2.GetValue(num);
							object obj = Class1662.CompareTo(object_0, value2, bool_0, bool_1: true);
							if (!(obj is ErrorType))
							{
								double num2 = (double)obj;
								if (!(num2 < 0.0))
								{
									break;
								}
								num--;
								continue;
							}
							return obj;
						}
						return ErrorType.NA;
					}
					return ((Array)array.GetValue(array.Length - 1)).GetValue(num);
				}
			}
			int num3 = array.Length - 1;
			while (num3 >= 0)
			{
				value = array.GetValue(num3);
				Array array3 = (Array)value;
				if (flag)
				{
					value = array3.GetValue(0);
				}
				object obj2 = Class1662.CompareTo(object_0, value, bool_0, bool_1: true);
				if (!(obj2 is ErrorType))
				{
					double num4 = (double)obj2;
					if (num4 < 0.0)
					{
						num3--;
						continue;
					}
					if (!flag)
					{
						return value;
					}
					return array3.GetValue(array3.Length - 1);
				}
				return obj2;
			}
		}
		return ErrorType.NA;
	}
}
