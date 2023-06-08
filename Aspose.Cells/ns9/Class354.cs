using System;
using Aspose.Cells;
using ns10;

namespace ns9;

internal class Class354 : Class316
{
	internal Class354()
	{
		int_0 = 174;
	}

	internal void method_6(CustomFilter customFilter_0)
	{
		int num = 10;
		int num2 = 0;
		byte b = Class1224.smethod_20(customFilter_0.FilterOperatorType);
		object criteria = customFilter_0.Criteria;
		if (criteria != null)
		{
			switch (Type.GetTypeCode(criteria.GetType()))
			{
			case TypeCode.Boolean:
				byte_0 = new byte[num];
				byte_0[0] = 8;
				if ((bool)criteria)
				{
					byte_0[2] = 1;
				}
				break;
			case TypeCode.String:
			{
				string text = (string)criteria;
				num += text.Length * 2 + 4;
				byte_0 = new byte[num];
				byte_0[0] = 6;
				num2 = 10;
				Class1217.smethod_7(byte_0, ref num2, text);
				break;
			}
			default:
				byte_0 = new byte[num];
				break;
			case TypeCode.Int32:
			case TypeCode.Double:
				byte_0 = new byte[num];
				byte_0[0] = 4;
				Array.Copy(BitConverter.GetBytes((double)criteria), 0, byte_0, 2, 8);
				break;
			}
			byte_0[1] = b;
		}
		else
		{
			byte_0 = new byte[num];
		}
	}
}
