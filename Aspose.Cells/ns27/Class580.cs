using System;
using Aspose.Cells;
using ns2;

namespace ns27;

internal class Class580 : Class538
{
	internal Class580()
	{
		method_2(433);
	}

	internal void method_4(Class995 class995_0)
	{
		FormatCondition formatCondition_ = class995_0.formatCondition_0;
		int num = ((class995_0.class578_0 == null) ? 12 : (class995_0.class578_0.Length + 6));
		int num2 = 0;
		int num3 = 0;
		FormatConditionType formatConditionType = formatCondition_.formatConditionType_0;
		OperatorType operatorType = formatCondition_.operatorType_0;
		byte[] array = null;
		if (class995_0.byte_0 != null)
		{
			formatConditionType = FormatConditionType.Expression;
			array = class995_0.byte_0;
		}
		else
		{
			formatCondition_.method_11();
			array = formatCondition_.method_0();
		}
		if (formatConditionType == FormatConditionType.Expression)
		{
			operatorType = OperatorType.None;
		}
		num += array.Length - 2;
		num2 = array.Length - 2;
		if (formatConditionType == FormatConditionType.CellValue && formatCondition_.method_4() != null && (operatorType == OperatorType.Between || operatorType == OperatorType.NotBetween))
		{
			num += formatCondition_.method_4().Length - 2;
			num3 = formatCondition_.method_4().Length - 2;
		}
		method_0((short)num);
		byte_0 = new byte[base.Length];
		int num4 = 0;
		switch (formatConditionType)
		{
		case FormatConditionType.CellValue:
			byte_0[num4] = 1;
			break;
		case FormatConditionType.Expression:
			byte_0[num4] = 2;
			break;
		}
		byte_0[num4 + 1] = smethod_0(operatorType);
		num4 += 2;
		Array.Copy(BitConverter.GetBytes((short)num2), 0, byte_0, num4, 2);
		Array.Copy(BitConverter.GetBytes((short)num3), 0, byte_0, num4 + 2, 2);
		num4 += 4;
		if (class995_0.class578_0 != null)
		{
			Array.Copy(class995_0.class578_0.Data, 0, byte_0, num4, class995_0.class578_0.Length);
			num4 += class995_0.class578_0.Length;
		}
		else
		{
			num4 += 6;
		}
		Array.Copy(array, 2, byte_0, num4, array.Length - 2);
		num4 += array.Length - 2;
		if (operatorType == OperatorType.Between || operatorType == OperatorType.NotBetween)
		{
			byte[] array2 = formatCondition_.method_4();
			Array.Copy(array2, 2, byte_0, num4, array2.Length - 2);
			num4 += array2.Length - 2;
		}
	}

	internal static byte smethod_0(OperatorType operatorType_0)
	{
		return operatorType_0 switch
		{
			OperatorType.Between => 1, 
			OperatorType.Equal => 3, 
			OperatorType.GreaterThan => 5, 
			OperatorType.GreaterOrEqual => 7, 
			OperatorType.LessThan => 6, 
			OperatorType.LessOrEqual => 8, 
			OperatorType.NotBetween => 2, 
			OperatorType.NotEqual => 4, 
			_ => 0, 
		};
	}
}
