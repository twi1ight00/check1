using System;
using Aspose.Cells;
using ns10;
using ns2;

namespace ns9;

internal class Class404 : Class316
{
	internal Class404()
	{
		int_0 = 64;
	}

	internal void method_6(Validation validation_0)
	{
		int num = 20;
		num = 20 + (validation_0.AreaList.Count * 16 + 4);
		if (validation_0.ErrorTitle != null)
		{
			num += validation_0.ErrorTitle.Length * 2;
		}
		if (validation_0.ErrorMessage != null)
		{
			num += validation_0.ErrorMessage.Length * 2;
		}
		if (validation_0.InputTitle != null)
		{
			num += validation_0.InputTitle.Length * 2;
		}
		if (validation_0.InputMessage != null)
		{
			num += validation_0.InputMessage.Length * 2;
		}
		byte[] array = validation_0.method_7();
		num = ((array == null) ? (num + 8) : (num + (array.Length + 4 + 4)));
		byte[] array2 = validation_0.method_9();
		num = ((array2 == null) ? (num + 8) : (num + (array2.Length + 4 + 4)));
		byte_0 = new byte[num];
		uint num2 = 0u;
		uint num3 = 0u;
		switch (validation_0.Type)
		{
		case ValidationType.AnyValue:
			num3 = 0u;
			break;
		case ValidationType.WholeNumber:
			num3 = 1u;
			break;
		case ValidationType.Decimal:
			num3 = 2u;
			break;
		case ValidationType.List:
			num3 = 3u;
			break;
		case ValidationType.Date:
			num3 = 4u;
			break;
		case ValidationType.Time:
			num3 = 5u;
			break;
		case ValidationType.TextLength:
			num3 = 6u;
			break;
		case ValidationType.Custom:
			num3 = 7u;
			break;
		}
		num2 |= num3;
		num3 = 0u;
		switch (validation_0.AlertStyle)
		{
		case ValidationAlertType.Information:
			num3 = 32u;
			break;
		case ValidationAlertType.Stop:
			num3 = 0u;
			break;
		case ValidationAlertType.Warning:
			num3 = 16u;
			break;
		}
		num2 |= num3;
		if (validation_0.IgnoreBlank)
		{
			num2 |= 0x100u;
		}
		if (!validation_0.InCellDropDown)
		{
			num2 |= 0x200u;
		}
		num3 = 0u;
		num2 |= (uint)(validation_0.method_5() switch
		{
			Enum228.const_0 => 0, 
			Enum228.const_1 => 1, 
			Enum228.const_2 => 2, 
			_ => 0, 
		} << 10);
		if (validation_0.ShowInput)
		{
			num2 |= 0x40000u;
		}
		if (validation_0.ShowError)
		{
			num2 |= 0x80000u;
		}
		num3 = 0u;
		switch (validation_0.Operator)
		{
		case OperatorType.Between:
			num3 = 0u;
			break;
		case OperatorType.Equal:
			num3 = 2u;
			break;
		case OperatorType.GreaterThan:
			num3 = 4u;
			break;
		case OperatorType.GreaterOrEqual:
			num3 = 6u;
			break;
		case OperatorType.LessThan:
			num3 = 5u;
			break;
		case OperatorType.LessOrEqual:
			num3 = 7u;
			break;
		case OperatorType.NotBetween:
			num3 = 1u;
			break;
		case OperatorType.NotEqual:
			num3 = 3u;
			break;
		}
		num2 |= num3 << 20;
		Array.Copy(BitConverter.GetBytes(num2), 0, byte_0, 0, 4);
		Class1217.smethod_3(validation_0.AreaList, byte_0, 4);
		int num4 = validation_0.AreaList.Count * 16 + 4 + 4;
		Class1217.smethod_7(byte_0, ref num4, validation_0.ErrorTitle);
		Class1217.smethod_7(byte_0, ref num4, validation_0.ErrorMessage);
		Class1217.smethod_7(byte_0, ref num4, validation_0.InputTitle);
		Class1217.smethod_7(byte_0, ref num4, validation_0.InputMessage);
		if (array != null)
		{
			Array.Copy(BitConverter.GetBytes(array.Length), 0, byte_0, num4, 4);
			num4 += 4;
			Array.Copy(array, 0, byte_0, num4, array.Length);
			num4 += array.Length + 4;
		}
		else
		{
			num4 += 8;
		}
		if (array2 != null)
		{
			Array.Copy(BitConverter.GetBytes(array2.Length), 0, byte_0, num4, 4);
			num4 += 4;
			Array.Copy(array2, 0, byte_0, num4, array2.Length);
		}
	}
}
